Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports CommonLibrary
Imports System.Collections
Imports AppCore
Imports AppCore.modCoreLib
Imports System.Security.Cryptography
Imports System.Xml.XmlNode
Imports System.Xml
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.Utils
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.Controls


Public Class frmBrokerConfirm
    'Inherits System.Windows.Forms.Form
    Inherits FormBase


#Region " Declare constant and variables "
    Const c_ResourceManager = "_DIRECT.frmBrokerConfirm-"

    Private mv_PopupMenuItem() As DevExpress.Utils.Menu.DXMenuItem
    Private v_strObjMsg_search As String = ""

    Const strBank_unholdbalance_param As String = "P_REFHOLDTXNUM!{0}!VARCHAR2!50" & _
                                                 "^P_DDACCTNO!{1}!VARCHAR2!50" & _
                                                  "^P_AMOUNT!{2}!NUMBER!50" & _
                                                  "^P_REQCODE!{3}!VARCHAR2!50" & _
                                                   "^P_REQKEY!{4}!VARCHAR2!30" & _
                                                    "^P_DESC!{5}!VARCHAR2!250" & _
                                                   "^P_TLID!{6}!VARCHAR2!4" & _
                                                   "^P_ERR_CODE!{7}!VARCHAR2!30"

    Const strBank_holdbalance_param As String = "P_DDACCTNO!{0}!VARCHAR2!50" & _
                                                 "^P_MEMBERID!{1}!VARCHAR2!10" & _
                                                 "^P_BRNAME!{2}!VARCHAR2!150" & _
                                                  "^P_BRPHONE!{3}!VARCHAR2!50" & _
                                                  "^P_AMOUNT!{4}!NUMBER!50" & _
                                                  "^P_REQCODE!{5}!VARCHAR2!50" & _
                                                   "^P_REQKEY!{6}!VARCHAR2!30" & _
                                                    "^P_DESC!{7}!VARCHAR2!250" & _
                                                   "^P_TLID!{8}!VARCHAR2!4" & _
                                                   "^P_ERR_CODE!{9}!VARCHAR2!30"

    Const strBank_inquiry_param As String = "P_DDACCTNO!{0}!VARCHAR2!50" & _
                                                 "^P_REQCODE!{1}!VARCHAR2!50" & _
                                                   "^P_REQKEY!{2}!VARCHAR2!30" & _
                                                    "^P_DESC!{3}!VARCHAR2!250" & _
                                                   "^P_TLID!{4}!VARCHAR2!4" & _
                                                   "^P_ERR_CODE!{5}!VARCHAR2!30"

    Const str_holdse_param As String = "P_SEACCTNO!{0}!VARCHAR2!50" & _
                                                 "^P_MEMBERID!{1}!VARCHAR2!10" & _
                                                 "^P_BRNAME!{2}!VARCHAR2!150" & _
                                                  "^P_BRPHONE!{3}!VARCHAR2!50" & _
                                                  "^P_QTTY!{4}!NUMBER!50" & _
                                                  "^P_DESC!{5}!VARCHAR2!250" & _
                                                   "^P_TLID!{6}!VARCHAR2!4" & _
                                                   "^P_ERR_CODE!{7}!VARCHAR2!30"

    Const str_unholdse_param As String = "P_SEACCTNO!{0}!VARCHAR2!50" & _
                                                 "^P_MEMBERID!{1}!VARCHAR2!10" & _
                                                 "^P_BRNAME!{2}!VARCHAR2!150" & _
                                                  "^P_BRPHONE!{3}!VARCHAR2!50" & _
                                                  "^P_QTTY!{4}!NUMBER!50" & _
                                                  "^P_DESC!{5}!VARCHAR2!250" & _
                                                   "^P_TLID!{6}!VARCHAR2!4" & _
                                                   "^P_ERR_CODE!{7}!VARCHAR2!30"

    'trung.luu hold/unhold cho tai khoan tu doanh
    Const strTD_hold_param As String = "P_CUSTODYCD!{0}!VARCHAR2!50" & _
                                                  "^P_MEMBERID!{1}!VARCHAR2!10" & _
                                                 "^P_BRNAME!{2}!VARCHAR2!150" & _
                                                  "^P_BRPHONE!{3}!VARCHAR2!50" & _
                                                  "^P_AMOUNT!{4}!NUMBER!50" & _
                                                   "^P_TLID!{5}!VARCHAR2!10" & _
                                                   "^P_DESC!{6}!VARCHAR2!250" & _
                                                   "^P_ERR_CODE!{7}!VARCHAR2!30"
    'trung.luu hold/unhold cho tai khoan tu doanh
    Const strTD_unhold_param As String = "P_CUSTODYCD!{0}!VARCHAR2!50" & _
                                                  "^P_AMOUNT!{1}!NUMBER!50" & _
                                                  "^P_TLID!{2}!VARCHAR2!4" & _
                                                  "^P_DESC!{3}!VARCHAR2!250" & _
                                                   "^P_ERR_CODE!{4}!VARCHAR2!30"
    'thunt send mail 
    Const str_send_email As String = "P_DDACCTNO!{0}!varchar2!50" & _
                                         "^P_SEACCTNO!{1}!varchar2!50" & _
                                         "^P_MEMBERID!{2}!varchar2!10" & _
                                         "^P_AMOUNT!{3}!Number!50" & _
                                         "^P_QTTY!{4}!Number!50" & _
                                         "^P_MessageError!{5}!Number!1"

    Dim mv_strACCTNO As String
    Dim mv_strCUSTODYCD As String
    Dim mv_strCOREBANK As String
    Dim mv_strTellerName As String
    Dim mv_strINQAction As String
    Dim tickCount As Double
    Dim mv_blSearchFlag As Boolean = False

    Private mv_SymbolList As New DataSet
    Private mv_strPhoneNumber As String
    Private mv_strCurrentTime As String = String.Empty
    Private mv_strSYMBOLLIST As String
    Private mv_blnIsPutthrough As Boolean = False
    Private mv_strAction As String = "N"
    Private mv_strSQLCMD As String = String.Empty
    Private mv_strObjectName As String
    Private mv_TableName As String
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
    Private mv_xmlDocumentInquiryData As System.Xml.XmlDocument
    Private mv_xmlGridFormat As System.Xml.XmlDocument

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

    Private mv_strOldCUSTID As String = String.Empty
    Private mv_strCUSTID As String = String.Empty

    Private mv_blnOrderSendingEx As Boolean = True
    Private mv_intCurrentRow As Integer

    Private Const CONTROL_PNL_CONTRACT_TOP = 200
    Private Const CONTROL_BUTTON_TOP = 400
    Private Const FRM_DEFAULT_HEIGHT = 260
    Private Const FRM_EXTEND_HEIGHT = 460
    Private mv_intTotalRow As Integer
    Private mv_strOrderStatus As String
    Dim gvSearchCashholdSelection As GridCheckMarksSelection
    Dim gvSearchSEholdSelection As GridCheckMarksSelection

    Dim mv_arrformatDic As New Dictionary(Of String, String())()
    Dim mv_arrsummary As New Dictionary(Of String, String())()
    Dim mv_arrWithDic As New Dictionary(Of String, Integer())()
    Dim mv_arrstrSearch As New Dictionary(Of String, String)()
    Dim mv_arrDataSource As New Dictionary(Of String, DataTable)()
    Dim mv_arrstrObjMsg As New Dictionary(Of String, String)()
    Public mv_strSearchFilterStore As String
    Private mv_strcmdMenu As String
#End Region
#Region " Properties "

    Public Property CMDID() As String
        Get
            Return mv_strcmdMenu
        End Get
        Set(ByVal Value As String)
            mv_strcmdMenu = Value
        End Set
    End Property

    Public Property PhoneNumber() As String
        Get
            Return mv_strPhoneNumber
        End Get
        Set(ByVal Value As String)
            mv_strPhoneNumber = Value
        End Set
    End Property
    Public Property SYMBOLLIST() As String
        Get
            Return mv_strSYMBOLLIST
        End Get
        Set(ByVal Value As String)
            mv_strSYMBOLLIST = Value
        End Set
    End Property

    Public Property CurrentTime() As String
        Get
            Return mv_strCurrentTime
        End Get
        Set(ByVal Value As String)
            mv_strCurrentTime = Value
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

    Public Property TableName() As String
        Get
            Return mv_TableName
        End Get
        Set(ByVal Value As String)
            mv_TableName = Value
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
    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        mv_strLanguage = pv_strLanguage
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        InitializeComponent()

    End Sub


    Protected Overridable Function InitDialog()
        'Thiết lập các thuộc tính ban đầu cho form
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL As String, v_strObjMsg As String
        Try
            'Khởi tạo kích thước form và load resource
            mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            LoadResource(Me)
            Me.txtSTC.BackColor = System.Drawing.Color.GreenYellow

            'trung.luu:19-03-2020
            Dim heightScreen As Integer = Screen.PrimaryScreen.WorkingArea.Height
            Dim widthScreen As Integer = Screen.PrimaryScreen.WorkingArea.Width
            'Me.Height = heightScreen - 50
            'Me.Width = widthScreen - 50
            'tabSEMain.Height = Me.Height / 3 - 40
            'tabCashMain.Height = Me.Height / 3 - 40
            'Me.CenterToScreen()


            cboEmploy.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cboEmploy.DropDownStyle = ComboBoxStyle.DropDown
            cboEmploy.AutoCompleteSource = AutoCompleteSource.ListItems

            initGrid(grdExchangeRate, "EXCHANGE_RATE", pnlExchangeRate, False)
            LoadGridDataEx(grdExchangeRate, pnlExchangeRate)
            LoadCboxFX()
            initGrid(grdBankAccount, "BROKER_BANK", pnlBankAccount, False)
            initGrid(grdSEHOLD, "BROKER_SEHOLD", pnlSEHOLD, False)
            initGrid(grdCashHOLD, "BROKER_CASHHOLD", pnlCashHold, True)
            initGrid(grdSEUNHOLD, "BROKER_SEUNHOLD", pnlUnholdSE, False)
            initGrid(grdCashUNHOLD, "BROKER_CASHUNHOLD", pnlCashUnhold, False)
            initGrid(grdSE, "BROKER_SEMAST", pnlSE, False)
            initGrid(grdCash, "BROKER_DDMAST", pnlCash, False)
            initGrid(grdCashSummary, "CASH_SUMMARY_BROKER", pnCashSummary, False)
            initGrid(grdSESummary, "SE_SUMMARY_BROKER", pnStockSummary, False)

            ResetScreen()
            txtSTC.Text = gc_COMPANY_CODE
            tabBROKER_DDMAST.Text = mv_ResourceManager.GetString(tabBROKER_DDMAST.Name)
            tabBROKER_SEMAST.Text = mv_ResourceManager.GetString(tabBROKER_SEMAST.Name)
            tabBROKER_CASHHOLD.Text = mv_ResourceManager.GetString(tabBROKER_CASHHOLD.Name)
            tabBROKER_CASHUNHOLD.Text = mv_ResourceManager.GetString(tabBROKER_CASHUNHOLD.Name)
            tabBROKER_SEHOLD.Text = mv_ResourceManager.GetString(tabBROKER_SEHOLD.Name)
            tabCASH_SUMMARY_BROKER.Text = mv_ResourceManager.GetString(tabCASH_SUMMARY_BROKER.Name)
            tabSE_SUMMARY_BROKER.Text = mv_ResourceManager.GetString(tabSE_SUMMARY_BROKER.Name)


            'init combobox symbol
            GetSymbolInfo()

            ''init exhchage rate

            txtAmount.Properties.Mask.EditMask = "n2"





            '' LoadGridDataEx("pr_get_exchange_rate", grdExchangeRate, pnlExchangeRate)


            ' start timer auto refresh
            'tmr1.Interval = 1
            'tmr1.Start() 


        Catch ex As Exception
            LogError.Write("Error source: AppCore.frmSearch.SaveLastSearch" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
        End Try
    End Function

    Public Sub LoadCboxFX()
        cboFX.DisplayMember = "Text"
        cboFX.ValueMember = "Value"
        Dim tb As New DataTable
        tb.Columns.Add("Text", GetType(String))
        tb.Columns.Add("Value", GetType(String))
        If UserLanguage = "VN" Then
            tb.Rows.Add("Có", "Y")
            tb.Rows.Add("Không", "N")
        Else
            tb.Rows.Add("Yes", "Y")
            tb.Rows.Add("No", "N")
        End If

        cboFX.DataSource = tb
    End Sub
    Public Shared Function TienBangChu(ByVal sSoTien As String) As String
        Dim DonVi() As String = {"", "nghìn ", "triệu ", "tỷ ", "nghìn ", "triệu "}
        Dim so As String
        Dim chuoi As String = ""
        Dim temp As String
        Dim id As Byte

        Do While (Not sSoTien.Equals(""))
            If sSoTien.Length <> 0 Then
                so = getNum(sSoTien)
                sSoTien = Strings.Left(sSoTien, sSoTien.Length - so.Length)
                temp = setNum(so)
                so = temp
                If Not so.Equals("") Then
                    temp = temp + DonVi(id)
                    chuoi = temp + chuoi
                End If
                id = id + 1
            End If
        Loop
        temp = UCase(Strings.Left(chuoi, 1))

        Return temp & Strings.Right(chuoi, Len(chuoi) - 1)
    End Function
    Private Shared Function getNum(ByVal sSoTien As String) As String
        Dim so As String

        If sSoTien.Length >= 3 Then
            so = Strings.Right(sSoTien, 3)
        Else
            so = Strings.Right(sSoTien, sSoTien.Length)
        End If
        Return so
    End Function
    Private Shared Function setNum(ByVal sSoTien As String) As String
        Dim chuoi As String = ""
        Dim flag0 As Boolean
        Dim flag1 As Boolean
        Dim temp As String

        temp = sSoTien
        Dim kyso() As String = {"không ", "một ", "hai ", "ba ", "bốn ", "năm ", "sáu ", "bảy ", "tám ", "chín "}
        'Xet hang tram
        sSoTien = sSoTien.Replace(",", "")
        'sSoTien = sSoTien.Replace(".", "")
        If sSoTien.Length = 3 Then
            If Not (Strings.Left(sSoTien, 1) = 0 And Strings.Left(Strings.Right(sSoTien, 2), 1) = 0 And Strings.Right(sSoTien, 1) = 0) Then
                chuoi = kyso(Strings.Left(sSoTien, 1)) + "trăm "
            End If
            sSoTien = Strings.Right(sSoTien, 2)
        End If
        'Xet hang chuc
        If sSoTien.Length = 2 Then
            If Strings.Left(sSoTien, 1) = 0 Then
                If Strings.Right(sSoTien, 1) <> 0 Then
                    chuoi = chuoi + "linh "
                End If
                flag0 = True
            Else
                If Strings.Left(sSoTien, 1) = 1 Then
                    chuoi = chuoi + "mười "
                Else
                    chuoi = chuoi + kyso(Strings.Left(sSoTien, 1)) + "mươi "
                    flag1 = True
                End If
            End If
            sSoTien = Strings.Right(sSoTien, 1)
        End If
        'Xet hang don vi
        If Strings.Right(sSoTien, 1) <> 0 Then
            If Strings.Left(sSoTien, 1) = 5 And Not flag0 Then
                If temp.Length = 1 Then
                    chuoi = chuoi + "năm "
                Else
                    chuoi = chuoi + "lăm "
                End If
            Else
                If Strings.Left(sSoTien, 1) = 1 And Not (Not flag1 Or flag0) And chuoi <> "" Then
                    chuoi = chuoi + "mốt "
                Else
                    chuoi = chuoi + kyso(Strings.Left(sSoTien, 1)) + ""
                End If
            End If
        Else
        End If
        Return chuoi
    End Function

    Function NumberToText(ByVal n As Double) As String
        Select Case n
            Case 0
                Return ""

            Case 1 To 19
                Dim arr() As String = {"One", "Two", "Three", "Four", "Five", "Six", "Seven", _
                  "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", _
                    "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"}
                Return arr(n - 1) & " "

            Case 20 To 99
                Dim arr() As String = {"Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"}
                Return arr(n \ 10 - 2) & " " & NumberToText(n Mod 10)

            Case 100 To 199
                Return "One Hundred " & NumberToText(n Mod 100)

            Case 200 To 999
                Return NumberToText(n \ 100) & "Hundreds " & NumberToText(n Mod 100)

            Case 1000 To 1999
                Return "One Thousand " & NumberToText(n Mod 1000)

            Case 2000 To 999999
                Return NumberToText(n \ 1000) & "Thousands " & NumberToText(n Mod 1000)

            Case 1000000 To 1999999
                Return "One Million " & NumberToText(n Mod 1000000)

            Case 1000000 To 999999999
                Return NumberToText(n \ 1000000) & "Millions " & NumberToText(n Mod 1000000)

            Case 1000000000 To 1999999999
                Return "One Billion " & NumberToText(n Mod 1000000000)

            Case Else
                Return NumberToText(n \ 1000000000) & "Billion " _
                  & NumberToText(n Mod 1000000000)
        End Select
    End Function
    Private Sub initGrid(ByRef pv_xGrid As DevExpress.XtraGrid.GridControl, ByVal strTable As String, ByRef pnlGrid As Panel, Optional ByVal blTickEnable As Boolean = False)

        pv_xGrid = New DevExpress.XtraGrid.GridControl()
        pv_xGrid.Name = strTable
        pv_xGrid.Cursor = System.Windows.Forms.Cursors.Default
        Dim gvResult As DevExpress.XtraGrid.Views.Grid.GridView



        gvResult = New DevExpress.XtraGrid.Views.Grid.GridView()
        gvResult.Name = "gv" & strTable
        pv_xGrid.MainView = gvResult
        pv_xGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {gvResult})
        gvResult.GridControl = pv_xGrid
        gvResult.OptionsView.ShowGroupPanel = False
        gvResult.OptionsSelection.MultiSelect = True
        If pv_xGrid.Name = "BROKER_DDMAST" Then
            gvResult.OptionsView.ShowFooter = True
        Else
            gvResult.OptionsView.ShowFooter = False
        End If
        _initGridFormat(strTable, pv_xGrid)



        pv_xGrid.RefreshDataSource()
        pv_xGrid.ForceInitialize()
        gvResult.PopulateColumns(mv_arrDataSource("DataSource" & pv_xGrid.Name))
        XtraGridFormatSummary(gvResult, "", mv_arrformatDic("mv_arrSrFieldSrch" & pv_xGrid.Name), mv_arrformatDic("mv_arrSrFieldFormat" & pv_xGrid.Name), mv_arrWithDic("mv_arrSrFieldWidth" & pv_xGrid.Name), mv_arrformatDic("mv_arrSrFieldDisp" & pv_xGrid.Name), mv_arrformatDic("mv_arrSrFieldDisplay" & pv_xGrid.Name), mv_arrformatDic("mv_arrStSummaryCode" & pv_xGrid.Name))

        If blTickEnable And Not gvResult.Columns.Contains(gvResult.Columns("CheckMarkSelection")) Then
            If strTable = "BROKER_SEHOLD" Then

                gvSearchSEholdSelection = New GridCheckMarksSelection(gvResult, strTable)

                gvSearchSEholdSelection.CheckMarkColumn.VisibleIndex = 0
                gvSearchSEholdSelection.CheckMarkColumn.OptionsColumn.Printable = DefaultBoolean.False
                gvSearchSEholdSelection.CheckMarkColumn.Visible = True

            Else
                gvSearchCashholdSelection = New GridCheckMarksSelection(gvResult, strTable)
                gvSearchCashholdSelection.CheckMarkColumn.VisibleIndex = 0
                gvSearchCashholdSelection.CheckMarkColumn.OptionsColumn.Printable = DefaultBoolean.False
                gvSearchCashholdSelection.CheckMarkColumn.Visible = True
            End If
        End If



        pnlGrid.Controls.Clear()
        pnlGrid.Controls.Add(pv_xGrid)
        pv_xGrid.Dock = System.Windows.Forms.DockStyle.Fill
        AddHandler pv_xGrid.Click, AddressOf Grid_Click
        AddHandler gvResult.RowCellStyle, AddressOf gvResult_RowCellStyle
        AddHandler gvResult.PopupMenuShowing, AddressOf gridView_PopupMenuClick

    End Sub
    Private Sub gridView_PopupMenuClick(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs)
        Dim item As DevExpress.Utils.Menu.DXMenuItem
        Dim view As GridView = TryCast(sender, GridView)



        If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Row Then
            If view.Name = "gv" & "BROKER_CASHHOLD" Then

                '    item = New DevExpress.Utils.Menu.DXMenuItem(mv_ResourceManager.GetString("btnSEUnBlock"))

                '    AddHandler item.Click, AddressOf SEUnhold
                '    e.Menu.Items.Add(item)
                'Else
                item = New DevExpress.Utils.Menu.DXMenuItem(mv_ResourceManager.GetString("btnCashUnhold"))

                AddHandler item.Click, AddressOf CashUnhold
                e.Menu.Items.Add(item)
            End If
        End If

    End Sub
    Function GetExecuteTLTXCD() As Hashtable
        Dim i, j, v_intRow, v_intCol As Integer, v_hashTLTX As New Hashtable(), v_blnIsThatTLTXCD As Boolean, arrTXFLD() As String
        Dim itemField, v_strTXNAME, v_strFLDCODE, v_strValue, objKey As String
        Try
            'Prevent multiple with check All
            'If Not Me.bciExecuteAll.Checked Then
            '    'Nếu đây là màn hình tra cứu cho phép thực hiện giao dịch kế tiếp
            '    If Not SearchGrid Is Nothing Then
            '        If gvResult.RowCount > 0 Then
            '            For v_intRow = 0 To gvSearchSelection.SelectedCount - 1
            '                'Sau khi l
            '                If Not gvSearchSelection.GetSelectedRow(v_intRow) Is Nothing Then
            '                    'Truoc khi khoi tao form giao dich da clear selection nen luc nao cung lay phan tu so 0
            '                    'Determine appropriate TLTXCD
            '                    'Determine the corresponse TLTXCD base on the selected value on the screen. 
            '                    For Each objKey In mv_arrStrTLTXNAME.Keys
            '                        v_strTXNAME = mv_arrStrTLTXNAME.Item(objKey)
            '                        v_blnIsThatTLTXCD = True
            '                        'Kiem tra cac gia tri cua cot trong row duoc chon co phu hop voi giao dich khong
            '                        For v_intCol = 0 To gvResult.Columns.Count - 1
            '                            v_strFLDCODE = gvResult.Columns(v_intCol).FieldName
            '                            If v_strFLDCODE <> "CheckMarkSelection" Then
            '                                v_strValue = gf_CorrectStringField(gvSearchSelection.GetSelectedRow(v_intRow)(v_strFLDCODE)).Trim
            '                                If mv_arrStrTLTXMAPFLDREF.ContainsKey(objKey & "." & v_strFLDCODE) Then
            '                                    itemField = mv_arrStrTLTXMAPFLDREF.Item(objKey & "." & v_strFLDCODE).trim
            '                                    If itemField.Length > 0 Then
            '                                        If Not itemField.IndexOf(v_strValue) >= 0 Then
            '                                            v_blnIsThatTLTXCD = False
            '                                            Exit For
            '                                        End If
            '                                    End If
            '                                End If
            '                            End If
            '                        Next
            '                        If v_blnIsThatTLTXCD Then
            '                            v_hashTLTX.Add(objKey, v_strTXNAME)
            '                        End If
            '                    Next objKey
            '                End If
            '            Next
            '        End If
            '    End If
            'End If

            Return v_hashTLTX
        Catch ex As Exception
            'Throw ex
            Return v_hashTLTX
        End Try
    End Function
    Private Sub CashUnhold(ByVal sender As Object, ByVal e As EventArgs)
        Dim v_strCommentMessage As String = InputBox(mv_ResourceManager.GetString("ConfirmComment"), Me.Text, v_strCommentMessage)
        If Len(Trim(v_strCommentMessage)) > 0 Then
            Tltxcd = "6691"
            unholdlist(v_strCommentMessage)
            Tltxcd = ""
        End If
    End Sub
    Private Sub SEUnhold(ByVal sender As Object, ByVal e As EventArgs)
        Dim v_strCommentMessage As String = InputBox(mv_ResourceManager.GetString("ConfirmComment"), Me.Text, v_strCommentMessage)
        If Len(Trim(v_strCommentMessage)) > 0 Then
            Tltxcd = "2213"
            unholdSElist(v_strCommentMessage)
            Tltxcd = ""
        End If
    End Sub
    Private Sub gvResult_RowCellStyle(sender As Object, e As RowCellStyleEventArgs)
        Dim gv As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        If gv.Name.ToUpper() = "GVBROKER_CASHHOLD" Or gv.Name.ToUpper() = "GVBROKER_CASHUNHOLD" Then
            If e.Column.FieldName = "STATUSTEXT" AndAlso e.RowHandle >= 0 Then

                If gv.GetRowCellValue(e.RowHandle, "STATUS").ToString = "C" Then
                    e.Appearance.BackColor = ColorTranslator.FromHtml("#56B81D")
                ElseIf gv.GetRowCellValue(e.RowHandle, "STATUS").ToString = "P" Then
                    e.Appearance.BackColor = ColorTranslator.FromHtml("#E3CB32")
                ElseIf gv.GetRowCellValue(e.RowHandle, "STATUS").ToString = "E" Or gv.GetRowCellValue(e.RowHandle, "STATUS").ToString = "R" Then
                    e.Appearance.BackColor = ColorTranslator.FromHtml("#F51D1D")

                End If
            End If

        End If

        If gv.Name.ToUpper() = "GVBROKER_SEHOLD" Or gv.Name.ToUpper() = "GVBROKER_SEUNHOLD" Then
            If e.Column.FieldName = "STATUSTEXT" AndAlso e.RowHandle >= 0 Then

                If gv.GetRowCellValue(e.RowHandle, "STATUS").ToString = "1" Then
                    e.Appearance.BackColor = ColorTranslator.FromHtml("#56B81D")
                ElseIf gv.GetRowCellValue(e.RowHandle, "STATUS").ToString = "4" Then
                    e.Appearance.BackColor = ColorTranslator.FromHtml("#E3CB32")
                ElseIf gv.GetRowCellValue(e.RowHandle, "STATUS").ToString = "2" Or gv.GetRowCellValue(e.RowHandle, "STATUS").ToString = "5" Then
                    e.Appearance.BackColor = ColorTranslator.FromHtml("#F51D1D")

                End If
            End If

        End If

    End Sub

    Protected Overridable Sub Grid_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim gv As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        'btnCashUnhold1.Enabled = False
        'btnUnholdSE.Enabled = False
        'If Not gv.GetFocusedDataRow() Is Nothing Then
        '    If gv.Columns.Contains(gvResult.Columns("APRALLOW")) = True Then
        '        Dim v_strUNHOLDALLOW As String = gvResult.GetFocusedDataRow()("APRALLOW").ToString
        '        If v_strUNHOLDALLOW = "Y" Then
        '            If (gvResult.Name.Contains("CASHHOLD")) Then
        '                btnCashUnhold1.Enabled = True
        '            ElseIf (gvResult.Name.Contains("SEHOLD")) Then
        '                btnUnholdSE.Enabled = False
        '            End If

        '        End If
        '    End If

        'End If
    End Sub


    Public Sub _FormatGridBefore(ByRef pv_xGrid As Xceed.Grid.GridControl, _
                                Optional ByVal pv_strTable As String = vbNullString, _
                                Optional ByVal pv_strResource As String = vbNullString, _
                                Optional ByVal blTickEnable As Boolean = False, _
                                Optional ByVal pv_blnFirst As Boolean = True, _
                                Optional ByVal pv_blnGroup As Boolean = True, _
                                Optional ByVal pv_intFromrow As Int32 = 0, _
                                Optional ByVal pv_intTorow As Int32 = 0, _
                                Optional ByVal pv_intTotalrow As Int32 = 0
                                )
        Dim m_ResourceManager As Resources.ResourceManager
        If Len(pv_strResource) > 0 And pv_blnGroup Then
            m_ResourceManager = New Resources.ResourceManager(pv_strResource, System.Reflection.Assembly.GetExecutingAssembly())
        End If

        'Nếu lần đầu tiên tạo thì xoá trắng định dạng của Grid
        If pv_blnFirst Then pv_xGrid.Clear()

        'Không cho phép sửa dữ liệu trên GRID
        pv_xGrid.ReadOnly = True

        Dim GroupByRow1 As Xceed.Grid.GroupByRow
        Dim ColumnManagerRow1 As Xceed.Grid.ColumnManagerRow
        Dim VisualGridElementStyle1 As Xceed.Grid.VisualGridElementStyle
        Dim VisualGridElementStyle2 As Xceed.Grid.VisualGridElementStyle

        VisualGridElementStyle1 = New Xceed.Grid.VisualGridElementStyle
        VisualGridElementStyle2 = New Xceed.Grid.VisualGridElementStyle

        '?ịnh nghĩa định dạng cho Row dữ liệu
        '
        'VisualGridElementStyle
        '
        VisualGridElementStyle1.BackColor = System.Drawing.Color.FromArgb(CType(32, Byte), CType(1, Byte), CType(152, Byte), CType(2, Byte))
        VisualGridElementStyle2.BackColor = System.Drawing.Color.FromArgb(CType(32, Byte), CType(249, Byte), CType(190, Byte), CType(58, Byte))

        If pv_blnGroup Then
            GroupByRow1 = New Xceed.Grid.GroupByRow
            GroupByRow1.Height = 20
            ColumnManagerRow1 = New Xceed.Grid.ColumnManagerRow
            '
            'GroupByRow1
            '
            '
            If Len(pv_strResource) > 0 Then
                GroupByRow1.NoGroupText = m_ResourceManager.GetString("GridEx.GroupByRow")
            End If

            GroupByRow1.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(127, Byte), CType(123, Byte), CType(122, Byte))
            GroupByRow1.CellBackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            GroupByRow1.CellFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)

            'ColumnManagerRow1
            '
            ColumnManagerRow1.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            ColumnManagerRow1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            ColumnManagerRow1.HorizontalAlignment = HorizontalAlignment.Center
            ColumnManagerRow1.Height = 20

        End If

        pv_xGrid.RowSelectorPane.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        pv_xGrid.RowSelectorPane.ForeColor = System.Drawing.Color.White
        pv_xGrid.SelectionBackColor = System.Drawing.Color.FromArgb(CType(96, Byte), CType(29, Byte), CType(50, Byte), CType(139, Byte))
        pv_xGrid.SelectionForeColor = System.Drawing.Color.Black

        pv_xGrid.Font = New System.Drawing.Font("Tahoma", 8.25!)
        pv_xGrid.ForeColor = System.Drawing.Color.Black
        pv_xGrid.InactiveSelectionBackColor = System.Drawing.Color.FromArgb(CType(48, Byte), CType(29, Byte), CType(50, Byte), CType(139, Byte))
        pv_xGrid.InactiveSelectionForeColor = System.Drawing.Color.Black

        pv_xGrid.DataRowTemplateStyles.Add(VisualGridElementStyle1)
        pv_xGrid.DataRowTemplateStyles.Add(VisualGridElementStyle2)

        ColumnManagerRow1.HorizontalAlignment = HorizontalAlignment.Center

        '' pv_xGrid.FixedHeaderRows.Add(GroupByRow1)
        pv_xGrid.FixedHeaderRows.Add(ColumnManagerRow1)

        pv_xGrid.ScrollBars = Xceed.Grid.GridScrollBars.ForcedVertical
        _FormatGridAfter(pv_xGrid, pv_strTable, UserLanguage)

        pv_xGrid.Columns("__TICK").Visible = blTickEnable
        pv_xGrid.Columns("__TICK").ReadOnly = blTickEnable


        'End If pv_xGrid.EndInit()
    End Sub
    Private Sub LoadResource(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control
        Try
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
                ElseIf TypeOf (v_ctrl) Is TabPage Then
                    CType(v_ctrl, TabPage).Text = mv_ResourceManager.GetString(v_ctrl.Name)
                End If
            Next
            Me.Text = mv_ResourceManager.GetString(Me.Name)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Sub OnClose()
        tmr1.Stop()
        Me.Dispose()
    End Sub
    Private Sub frm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Dim v_intPos As Int16, ctl As Control, strFLDNAME As String, v_intIndex As Integer
        Select Case e.KeyCode
            Case Keys.Escape
                OnClose()
            Case Keys.Enter
                If Not TypeOf (Me.ActiveControl) Is Button Then
                    SendKeys.Send("{Tab}")
                    e.Handled = True
                End If
            Case Keys.F5
                If Me.ActiveControl.Name = "txtSTC" Then
                    'Dim frm As New frmSearch(Me.UserLanguage)
                    Dim frm As New frmXtraSearchLookup(Me.UserLanguage)
                    'ResetScreen(Me)
                    frm.TableName = "CUSTODYCD_CF"
                    frm.ModuleCode = "CF"
                    frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                    frm.IsLocalSearch = gc_IsNotLocalMsg
                    frm.IsLookup = "Y"
                    frm.SearchOnInit = False
                    frm.BranchId = Me.BranchId
                    frm.TellerId = Me.TellerId
                    'frm.AFACCTNO = Trim(mskAFACCTNO.Text)
                    'frm.mv_strSearchFilter = " AND DFTRADING>0 "
                    frm.ShowDialog()


                    'If Len(frm.RefValue) > 0 Then
                    '    lblName.Text = frm.RefValue
                    'End If
                    If Len(frm.ReturnValue) > 0 Then
                        Me.txtSTC.Text = Trim(frm.ReturnValue)
                        'GetAFMASTInfo(frm.ReturnValue)
                    End If
                    frm.Dispose()
                End If
        End Select
    End Sub
    Private Sub GetAFMASTInfo(ByVal v_strSTC As String)
        Try
            Dim v_strCmdSQL As String, v_strObjMsg As String
            Dim v_ws As New BDSDeliveryManagement
            v_strCmdSQL = "SELECT FILTERCD, VALUE, VALUECD, DISPLAY, EN_DISPLAY, DESCRIPTION FROM VW_CUSTODYCD_SUBACCOUNT_ACTIVE WHERE FILTERCD='" & v_strSTC & "' ORDER BY VALUE"

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            '' mv_blnOnDisplayScreen = True    'Disable selected index change
            FillCombo(v_strObjMsg, cboAFMAST, "", Me.UserLanguage)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GetCFfullInfo(ByVal v_strSTC As String)
        Try
            Dim v_nodeList As XmlNodeList
            Dim v_xmlDocument As New XmlDocument
            Dim v_strValue, v_strFLDNAME, v_strTEXT, v_strMINBRATIO, v_strMAXBRATIO As String, i, j As Integer
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strCmdSQL As String, v_strObjMsg As String


            v_strCmdSQL = "select cf.cifid || ' - '||cf.FULLNAME FULLNAME, cfm.custodycd MCUSTODYCD, cfm.fullname MFULLNAME, au.FX" _
                         & " from cfmast cf, cfmast cfm, famembers fa, " _
                         & " (select cfcustid,substr(linkauth,pos,1) FX " _
                         & " from cfauth, (select to_number(cdval)-1 pos from allcode where cdtype ='CF' and cdname='LINKAUTH' and cdcontent = 'FX') " _
                         & "  where shv='Y') au " _
                         & " where cf.custodycd = '" & v_strSTC & "' " _
                         & " and cf.custid = au.cfcustid(+) " _
                         & " and cf.gcbid = fa.autoid(+) " _
                         & " and cf.mcustodycd = cfm.custodycd(+) "

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            '' mv_blnOnDisplayScreen = True    'Disable selected index change

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count > 0 Then
                For i = 0 To v_nodeList.Count - 1
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            'Ghi nhận thuật toán để kiểm tra và tính toán cho từng trư?ng c�ủa giao dịch
                            v_strValue = .InnerText.ToString
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "FULLNAME"
                                    lblName.Text = Trim(v_strValue)
                                Case "FX"
                                    cboFX.SelectedValue = Trim(v_strValue)
                                    cboFX.Enabled = False
                                Case "MCUSTODYCD"
                                    txtMCUSTODYCD.Text = Trim(v_strValue)
                                Case "MFULLNAME"
                                    lblMFULLNAME.Text = Trim(v_strValue)
                            End Select
                        End With
                    Next
                Next
            Else

                lblName.Text = ""

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Private Sub ExcuteStore(Optional v_strClauseParam As String = "", Optional ByVal isAlert As Boolean = True)
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_dec As Decimal
        Dim v_xmlDocument As New XmlDocument
        Dim v_nodeList As XmlNodeList
        Dim v_strValue, v_strFLDNAME As String, i, j As Integer
        Dim v_strErrorSource, v_lngError, v_strErrorMessage As String
        Dim v_strStoreName As String
        Try

            ''StoreParam = "p_GET_TOTAL_ROW!0!Double!20" & _
            ''''                        "^p_FROM_ROW!" & v_intFrom & "!Double!20" & _
            ''                       "^p_TO_ROW!" & v_intTo & "!Double!20" & _
            ''                       "^p_PARA_STRING!" & mv_strSearchFilterStore & "!String!4000"
            Select Case Tltxcd
                Case "6690"
                    v_strStoreName = "pck_bankapi.Bank_holdbalance"
                Case "6691"
                    v_strStoreName = "pck_bankapi.Bank_UNholdbalance"
                Case "6671"
                    v_strStoreName = "pck_bankapi.Bank_Inquiry"
                Case "2212"
                    v_strStoreName = "pck_bankapi.se_hold"
                Case "2213"
                    v_strStoreName = "pck_bankapi.se_unhold"
                    'trung.luu hold/unhold cho tai khoan tu doanh
                Case "6603"
                    v_strStoreName = "pck_bankapi.TD_Hold"
                    'trung.luu hold/unhold cho tai khoan tu doanh
                Case "6604"
                    v_strStoreName = "pck_bankapi.TD_Unhold"
                Case "MAIL"
                    v_strStoreName = "nmpks_ems.pr_GenTemplateCashSec"
            End Select

            If isAlert Then
                If Not ControlValidation() Then
                    'If txtQuantity.EditValue > txtSEBLOCKED.Text Or txtAmount.EditValue > txtBALANCE.Text Then
                    '    btnSendMail.Visible = True
                    '    cboFX.Width = 110
                    'End If
                    Exit Sub
                End If
            End If

            'Verify và tạo điện giao dịch
            If Not VerifyRules(v_strClauseParam) Then
                Exit Sub
            Else
                If Tltxcd = "MAIL" Then
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionExec, v_strStoreName, v_strClauseParam, , , , , , , gc_CommandProcedure)
                    v_lngError = v_ws.Message(v_strObjMsg)
                    If v_lngError <> ERR_SYSTEM_OK Then
                        Exit Sub
                    Else
                        MessageBox.Show(String.Format(mv_ResourceManager.GetString("SendMailSuccessful")), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionExec, v_strStoreName, v_strClauseParam, , , , , , , gc_CommandProcedure)
                    v_lngError = v_ws.Message(v_strObjMsg)
                    If v_lngError <> ERR_SYSTEM_OK Then
                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                        MessageBox.Show(v_strErrorMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    Else
                        If Not isAlert Then Exit Sub
                        Select Case Tltxcd
                            Case "6690", "6603"
                                MessageBox.Show(mv_ResourceManager.GetString("HoldCashSuccessful"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Case "6691", "6604"
                                MessageBox.Show(mv_ResourceManager.GetString("UnHoldCashSuccessful"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Case "2212"
                                MessageBox.Show(mv_ResourceManager.GetString("HoldSeSuccessful"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Case "2213"
                                MessageBox.Show(mv_ResourceManager.GetString("1UnHoldSeSuccessful"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)


                        End Select
                        Refresh()
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GetSymbolInfo()
        Try
            Dim v_strCmdSQL As String, v_strObjMsg As String
            Dim v_ws As New BDSDeliveryManagement
            v_strCmdSQL = "SELECT sb.codeid VALUE , sb.symbol DISPLAY, sb.symbol EN_DISPLAY from  sbsecurities sb"

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            '' mv_blnOnDisplayScreen = True    'Disable selected index change
            FillCombo(v_strObjMsg, cboSymbol, "", Me.UserLanguage)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GetDDMASTInfo(ByVal v_strAFMAST As String)
        Try
            Dim v_strCmdSQL As String, v_strObjMsg As String
            Dim v_ws As New BDSDeliveryManagement
            v_strCmdSQL = "SELECT FILTERCD, VALUE, VALUECD, DISPLAY, EN_DISPLAY, DESCRIPTION FROM VW_AFMAST_DDACCOUNT_ACTIVE WHERE FILTERCD=substr('" & v_strAFMAST & "',1,10) "

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            '' mv_blnOnDisplayScreen = True    'Disable selected index change
            FillCombo(v_strObjMsg, cboDDMAST, "", Me.UserLanguage)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GetMEMBERInfo(ByVal v_strSTC As String)
        Try
            Dim v_strCmdSQL As String, v_strObjMsg As String
            Dim v_ws As New BDSDeliveryManagement
            v_strCmdSQL = "SELECT FILTERCD, VALUE, VALUECD, DISPLAY, EN_DISPLAY, DESCRIPTION FROM VW_CUSTODYCD_MEMBER WHERE FILTERCD='" & v_strSTC & "' ORDER BY VALUE"

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            '' mv_blnOnDisplayScreen = True    'Disable selected index change
            FillCombo(v_strObjMsg, cboBROKER, "", Me.UserLanguage)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GetMEMBERInfo_ByEmploy(ByVal v_cboEmploy As String)
        Try
            Dim v_strCmdSQL As String, v_strObjMsg As String
            Dim v_ws As New BDSDeliveryManagement
            'v_strCmdSQL = "SELECT FILTERCD, VALUE, VALUECD, DISPLAY, EN_DISPLAY, DESCRIPTION FROM VW_CUSTODYCD_MEMBER WHERE FILTERCD='" & v_strSTC & "' ORDER BY VALUE"
            'trung.luu:  SHBVNEX-1365 28-07-2020

            v_strCmdSQL = "   SELECT FILTERCD, VALUE, VALUECD, DISPLAY, EN_DISPLAY, DESCRIPTION FROM VW_CUSTODYCD_MEMBER where value in  ( select filtercd from vw_member_broker where value = '" & v_cboEmploy & "') and  FILTERCD='" & txtSTC.Text & "'   ORDER BY VALUE"

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            '' mv_blnOnDisplayScreen = True    'Disable selected index change
            FillCombo(v_strObjMsg, cboBROKER, "", Me.UserLanguage)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GetEmployInfo(ByVal v_strMember As String, ByVal v_strcustodycd As String)
        Try
            Dim v_strCmdSQL As String, v_strObjMsg As String
            Dim v_ws As New BDSDeliveryManagement
            'v_strCmdSQL = "SELECT FILTERCD, VALUE, VALUECD, DISPLAY, EN_DISPLAY, DESCRIPTION FROM vw_member_broker WHERE FILTERCD='" & v_strMember & "' ORDER BY FILTERCD"

            v_strCmdSQL = "select distinct FILTERCD, VALUE, VALUECD, DISPLAY, EN_DISPLAY, DESCRIPTION from " & _
                  "(select distinct br.FILTERCD, br.VALUE, br.VALUECD, br.DISPLAY, br.EN_DISPLAY, br.DESCRIPTION " & _
                  "from vw_custodycd_member cu,vw_member_broker br " & _
                  "where br.filtercd = cu.value and cu.filtercd = '" & v_strcustodycd & "' " & _
                  "and br.FILTERCD = '" & v_strMember & "' " & _
                  "and  EXISTS (  " & _
                "select * from FABROKERAGEXTRA where custodycd = '" & v_strcustodycd & "' and brkid = br.VALUE) " & _
                "union all " & _
                "select br.FILTERCD, br.VALUE, br.VALUECD, br.DISPLAY, br.EN_DISPLAY, br.DESCRIPTION " & _
                  "from vw_custodycd_member cu,vw_member_broker br " & _
                  "where br.filtercd = cu.value and cu.filtercd = '" & v_strcustodycd & "' " & _
                  "and br.FILTERCD = '" & v_strMember & "' " & _
                "and br.FILTERCD not in " & _
                 "(select distinct br.FILTERCD " & _
                 "from vw_custodycd_member cu,vw_member_broker br " & _
                 "where br.filtercd = cu.value and cu.filtercd = '" & v_strcustodycd & "' " & _
                 "and  EXISTS (select * from FABROKERAGEXTRA where custodycd = '" & v_strcustodycd & "' and brkid = br.VALUE and memberid = '" & v_strMember & "'))) " & _
                "ORDER BY FILTERCD "


            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            '' mv_blnOnDisplayScreen = True    'Disable selected index change
            FillCombo(v_strObjMsg, cboEmploy, "", Me.UserLanguage)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GetEmployInfo_all(ByVal v_strSTC As String)
        Try
            Dim v_strCmdSQL As String, v_strObjMsg As String
            Dim v_ws As New BDSDeliveryManagement
            'v_strCmdSQL = "SELECT FILTERCD, VALUE, VALUECD, DISPLAY, EN_DISPLAY, DESCRIPTION FROM vw_member_broker WHERE FILTERCD='" & v_strMember & "' ORDER BY FILTERCD"
            'trung.luu:  SHBVNEX-1365 28-07-2020
            'v_strCmdSQL = "select br.FILTERCD, br.VALUE, br.VALUECD, br.DISPLAY, br.EN_DISPLAY, br.DESCRIPTION from vw_custodycd_member cu,vw_member_broker br  where br.filtercd = cu.value and cu.filtercd = '" & v_strSTC & "'ORDER BY FILTERCD"





            v_strCmdSQL = "select distinct FILTERCD, VALUE, VALUECD, DISPLAY, EN_DISPLAY, DESCRIPTION from " & _
                  "(select distinct br.FILTERCD, br.VALUE, br.VALUECD, br.DISPLAY, br.EN_DISPLAY, br.DESCRIPTION " & _
                  "from vw_custodycd_member cu,vw_member_broker br " & _
                  "where br.filtercd = cu.value and cu.filtercd = '" & v_strSTC & "' " & _
                  "and  EXISTS (  " & _
                "select * from FABROKERAGEXTRA where custodycd = '" & v_strSTC & "' and brkid = br.VALUE) " & _
                "union all " & _
                "select br.FILTERCD, br.VALUE, br.VALUECD, br.DISPLAY, br.EN_DISPLAY, br.DESCRIPTION " & _
                  "from vw_custodycd_member cu,vw_member_broker br " & _
                  "where br.filtercd = cu.value and cu.filtercd = '" & v_strSTC & "' " & _
                "and br.FILTERCD not in " & _
                 "(select distinct br.FILTERCD " & _
                 "from vw_custodycd_member cu,vw_member_broker br " & _
                 "where br.filtercd = cu.value and cu.filtercd = '" & v_strSTC & "' " & _
                 "and  EXISTS (select * from FABROKERAGEXTRA where custodycd = '" & v_strSTC & "' and brkid = br.VALUE))) " & _
                "ORDER BY FILTERCD "

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            '' mv_blnOnDisplayScreen = True    'Disable selected index change
            FillCombo(v_strObjMsg, cboEmploy, "", Me.UserLanguage)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub GetPhoneInfo(ByVal v_strMember As String)
        Try
            Dim v_strCmdSQL As String, v_strObjMsg As String
            Dim v_ws As New BDSDeliveryManagement
            v_strCmdSQL = "SELECT FILTERCD, VALUE, VALUECD, DISPLAY, EN_DISPLAY, DESCRIPTION FROM vw_member_phone WHERE FILTERCD='" & v_strMember & "' ORDER BY FILTERCD"

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            '' mv_blnOnDisplayScreen = True    'Disable selected index change
            FillCombo(v_strObjMsg, cboPhone, "", Me.UserLanguage)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub grbACCTNOINFO_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub frmBrokerConfirm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitDialog()

    End Sub

    Private Sub txtSTC_Leave(sender As Object, e As EventArgs) Handles txtSTC.Leave
        txtSTC.Text = txtSTC.Text.ToUpper()
        If Not VerifyCustodyCode(txtSTC.Text) Then
            MsgBox(mv_ResourceManager.GetString("CUSTODYCD_INVALID_LENGTH"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            txtSTC.Focus()
        Else
            ResetScreen()

            GetAFMASTInfo(txtSTC.Text)
            If cboDDMAST.Items.Count = 0 Then
                MsgBox(mv_ResourceManager.GetString("DDMAST_INVALID"), MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                txtSTC.Focus()
            Else
                GetEmployInfo_all(txtSTC.Text)
                'GetMEMBERInfo(txtSTC.Text)
                GetCFfullInfo(txtSTC.Text)
                Tltxcd = "6671"
                ExcuteStore(, False)
                Tltxcd = ""
                LoadGridDataEx(grdBankAccount, pnlBankAccount)
                LoadGridDataEx(grdCashHOLD, pnlCashHold)
                LoadGridDataEx(grdSEHOLD, pnlSEHOLD)

                GetMEMBERInfo(txtSTC.Text)

                If cboBROKER.Items.Count = 0 Then
                    MsgBox(mv_ResourceManager.GetString("BROKER_INVALID"), MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    txtSTC.Focus()
                    'thread.Change(0, 0)
                Else
                    'thread.Change(1000, 1000)
                End If
            End If
        End If

        GetNoteInfo(txtSTC.Text)
        'Dim test As Integer = gvCashHOLD.DataRowCount
        'If gvCashHOLD.DataRowCount = 0 Then
        '    gvSearchCashholdSelection = New GridCheckMarksSelection(gvResult, gvCashHOLD.Name)
        '    gvSearchCashholdSelection.CheckMarkColumn.VisibleIndex = 0
        '    gvSearchCashholdSelection.CheckMarkColumn.OptionsColumn.Printable = DefaultBoolean.False
        '    gvSearchCashholdSelection.CheckMarkColumn.Visible = False
        'Else
        '    gvSearchCashholdSelection = New GridCheckMarksSelection(gvResult, gvCashHOLD.Name)
        '    gvSearchCashholdSelection.CheckMarkColumn.VisibleIndex = 0
        '    gvSearchCashholdSelection.CheckMarkColumn.OptionsColumn.Printable = DefaultBoolean.False
        '    gvSearchCashholdSelection.CheckMarkColumn.Visible = True
        'End If
        
        'thread.Change(1000, 1000)
        tmr1.Interval = 1000
        tmr1.Start()


    End Sub

    Private Sub cboAFMAST_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboAFMAST.SelectedValueChanged
        If cboAFMAST.Items.Count > 0 Then
            cboAFMAST.SelectedIndex = 0
            GetDDMASTInfo(CType(cboAFMAST.SelectedItem, ComboBoxItem).Value)
        Else
            cboDDMAST.DataBindings.Clear()
            cboDDMAST.DataSource = Nothing
            cboDDMAST.Items.Clear()
        End If
    End Sub

    Private Sub ResetControl(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control
        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is TextBox Then
                CType(v_ctrl, TextBox).Text = String.Empty
                'CType(v_ctrl, TextBox).Enabled = True
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                ResetControl(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Button Then
            ElseIf TypeOf (v_ctrl) Is Panel Then
                v_ctrl.Enabled = True
                ResetControl(v_ctrl)
            End If
        Next
    End Sub
    Private Sub ResetScreen()

        txtSENAMEEN.Text = ""
        txtSENAMEVN.Text = ""
        txtQuantity.Text = "0"
        txtSETRADE.Text = "0"
        txtSEBLOCKEDBR.Text = "0"

        txtBALANCE.Text = "0"
        txtHOLDBALANCE.Text = "0"
        lblName.Text = ""
        lblCCYCD.Text = ""
        txtBALANCE.Text = "0"
        txtHOLDBALANCE.Text = "0"
        txtHOLDBR.Text = "0"
        txtEXCHANGERATE.Text = "0"
        txtMARKETVALUE.Text = "0"


        'grdBankAccount.DataSource =
        'grdSEHOLD.DataRows.Clear()
        'grdSE.DataRows.Clear()
        'grdCashHOLD.DataRows.Clear()
        'grdCash.DataRows.Clear()

        cboAFMAST.DataBindings.Clear()
        cboAFMAST.DataSource = Nothing
        cboAFMAST.Items.Clear()
        cboDDMAST.DataBindings.Clear()
        cboDDMAST.DataSource = Nothing
        cboDDMAST.Items.Clear()

        cboBROKER.DataBindings.Clear()
        cboBROKER.DataSource = Nothing
        cboBROKER.Items.Clear()

        cboEmploy.DataBindings.Clear()
        cboEmploy.DataSource = Nothing
        cboEmploy.Items.Clear()



        cboPhone.DataBindings.Clear()
        cboPhone.DataSource = Nothing
        cboPhone.Items.Clear()

        '' cboSymbol.DataBindings.Clear()
        ''  cboSymbol.DataSource = Nothing
        ''  cboSymbol.Items.Clear()

    End Sub





    Private Sub GetCashInfo(ByVal v_strDDAccount As String)
        Try
            Dim v_nodeList As XmlNodeList
            Dim v_xmlDocument As New XmlDocument
            Dim v_strValue, v_strFLDNAME, v_strTEXT, v_strMINBRATIO, v_strMAXBRATIO As String, i, j As Integer
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strCmdSQL As String, v_strObjMsg As String

            v_strCmdSQL = "select CF.CUSTODYCD, CF.FULLNAME, DD.AFACCTNO, DD.ACCTNO, DD.CCYCD, DD.REFCASAACCT,DD.BALANCE, DD.HOLDBALANCE, DD.PENDINGHOLD, DD.PENDINGUNHOLD ,DD.CCYCD " _
                          & "from DDMAST DD,AFMAST AF, CFMAST CF where CF.custid = AF.CUSTID AND AF.ACCTNO = DD.AFACCTNO and DD.ACCTNO='" & v_strDDAccount & "'"
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
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                'Case "FULLNAME"
                                '    lblName.Text = Trim(v_strValue)
                                Case "CCYCD"
                                    lblCCYCD.Text = Trim(v_strValue)
                                Case "BALANCE"
                                    txtBALANCE.Text = Format(Math.Round(CDbl(v_strValue), 2), gc_FORMAT_NUMBER_2)
                                Case "HOLDBALANCE"
                                    txtHOLDBALANCE.Text = Format(Math.Round(CDbl(v_strValue), 2), gc_FORMAT_NUMBER_2)


                            End Select
                        End With
                    Next
                Next
            Else

                ''    lblName.Text = ""
                lblCCYCD.Text = ""
                txtBALANCE.Text = "0"
                txtHOLDBALANCE.Text = "0"
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GetNoteInfo(ByVal v_strCustodycd As String)
        Try
            Dim v_nodeList As XmlNodeList
            Dim v_xmlDocument As New XmlDocument
            Dim v_strValue, v_strFLDNAME, v_strTEXT, v_strMINBRATIO, v_strMAXBRATIO As String, i, j As Integer
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strCmdSQL As String, v_strObjMsg As String

            v_strCmdSQL = "select DESCRIPTION from cfmast where custodycd = '" & v_strCustodycd & "'"
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
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "DESCRIPTION"
                                    txtTabNotes.Text = Trim(v_strValue)


                            End Select
                        End With
                    Next
                Next
            Else

                ''    lblName.Text = ""
                lblCCYCD.Text = ""
                txtBALANCE.Text = "0"
                txtHOLDBALANCE.Text = "0"
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub GetBrokerCashInfo(ByVal v_strDDAccount As String, ByVal v_strMemberID As String)
        Try
            Dim v_nodeList As XmlNodeList

            Dim v_xmlDocument As New XmlDocument
            Dim v_strValue, v_strFLDNAME, v_strTEXT, v_strMINBRATIO, v_strMAXBRATIO As String, i, j As Integer
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strCmdSQL As String, v_strObjMsg As String

            v_strCmdSQL = "select getrmbaldefavl('" & v_strDDAccount & "','" & v_strMemberID & "') HOLDBR, Getexchangerate('" & lblCCYCD.Text & "') EXCHANGERATE from dual"
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
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "HOLDBR"
                                    txtHOLDBR.Text = Format(Math.Round(CDbl(v_strValue), 2), gc_FORMAT_NUMBER_2)
                                Case "EXCHANGERATE"
                                    txtEXCHANGERATE.Text = Format(Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_0)


                            End Select
                        End With
                    Next
                Next
            Else
                txtHOLDBR.Text = "0"
                txtEXCHANGERATE.Text = "0"
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub GetBrokerSEInfo(ByVal v_strAFAccount As String, ByVal v_strCodeID As String, ByVal v_strMemberID As String)
        Try
            Dim v_nodeList As XmlNodeList

            Dim v_xmlDocument As New XmlDocument
            Dim v_strValue, v_strFLDNAME, v_strTEXT, v_strMINBRATIO, v_strMAXBRATIO As String, i, j As Integer
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strCmdSQL As String, v_strObjMsg As String

            v_strCmdSQL = "select getseholdbyBroker('" & v_strAFAccount.Substring(0, 10) & "','" & v_strCodeID & "','" & v_strMemberID & "') HOLDBR from dual"
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
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "HOLDBR"
                                    txtSEBLOCKEDBR.Text = Format(Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_0)



                            End Select
                        End With
                    Next
                Next
            Else
                txtSEBLOCKEDBR.Text = "0"

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GetSEInfo(ByVal v_strAFAccount As String, ByVal v_strSymbol As String)
        Try
            Dim v_nodeList As XmlNodeList
            Dim v_xmlDocument As New XmlDocument
            Dim v_strValue, v_strFLDNAME, v_strTEXT, v_strMINBRATIO, v_strMAXBRATIO As String, i, j As Integer
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strCmdSQL As String, v_strObjMsg As String
            ' vi li do cbo dang lay ciacctno de xu ly nen phai cat chuoi ve thanh afacctno
            v_strAFAccount = v_strAFAccount.Substring(0, 10)

            'trung.luu: 03-08-2020 :SHBVNEX-1310 tru truong temp (escrow)
            v_strCmdSQL = " select nvl(TRADE-TEMP,0)TRADE,nvl(HOLD,0)HOLD  ,DD.AFACCTNO, DD.ACCTNO, i.fullname vn_fullname  , i.en_fullname,i.OFFICENAME " _
                         & " from sbsecurities sb,ISSUERS i, (select * from semast where ACCTNO='" & v_strAFAccount & v_strSymbol & "') DD " _
                         & " WHERE  sb.ISSUERID = i.ISSUERID and sb.codeid =dd.codeid(+) and sb.codeid = '" & v_strSymbol & "'"

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
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "VN_FULLNAME"
                                    txtSENAMEVN.Text = Trim(v_strValue)
                                Case "EN_FULLNAME"
                                    txtSENAMEEN.Text = Trim(v_strValue)
                                Case "OFFICENAME"
                                    lblISSSHORTNAME.Text = Trim(v_strValue)
                                Case "TRADE"
                                    txtSETRADE.Text = Format(Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_0)
                                Case "HOLD"
                                    txtSEBLOCKED.Text = Format(Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_0)


                            End Select
                        End With
                    Next
                Next
            Else
                txtSENAMEEN.Text = ""
                txtSENAMEVN.Text = ""
                txtQuantity.Text = "0"
                txtSETRADE.Text = "0"
                'txtSEBLOCKEDBR.Text = "0"
                lblISSSHORTNAME.Text = ""
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub cboDDMAST_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboDDMAST.SelectedValueChanged
        If cboDDMAST.Items.Count > 0 And cboDDMAST.SelectedIndex <> -1 Then
            GetCashInfo(CType(cboDDMAST.SelectedItem, ComboBoxItem).Value)
            If cboBROKER.Items.Count > 0 And cboBROKER.SelectedIndex <> -1 Then
                GetBrokerCashInfo(CType(cboDDMAST.SelectedItem, ComboBoxItem).Value, CType(cboBROKER.SelectedItem, ComboBoxItem).Value)
            End If
        Else
            '' lblName.Text = ""
            txtBALANCE.Text = "0"
            txtHOLDBALANCE.Text = "0"

        End If
    End Sub

    Private Sub cboBROKER_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBROKER.SelectedIndexChanged
        If cboBROKER.Items.Count > 0 And cboBROKER.SelectedIndex <> -1 Then
            'GetEmployInfo(CType(cboBROKER.SelectedItem, ComboBoxItem).Value)
            GetPhoneInfo(CType(cboBROKER.SelectedItem, ComboBoxItem).Value)
            GetBrokerCashInfo(CType(cboDDMAST.SelectedItem, ComboBoxItem).Value, CType(cboBROKER.SelectedItem, ComboBoxItem).Value)
            If cboSymbol.Items.Count > 0 And cboSymbol.SelectedIndex <> -1 Then
                GetBrokerSEInfo(CType(cboAFMAST.SelectedItem, ComboBoxItem).Value, CType(cboSymbol.SelectedItem, ComboBoxItem).Value, CType(cboBROKER.SelectedItem, ComboBoxItem).Value)
            End If


            
            GetEmployInfo(CType(cboBROKER.SelectedItem, ComboBoxItem).Value, txtSTC.Text)

            'Else
            '    cboEmploy.DataBindings.Clear()
            '    cboEmploy.DataSource = Nothing
            '    cboEmploy.Items.Clear()
            '    cboPhone.DataBindings.Clear()
            '    cboPhone.DataSource = Nothing
            '    cboPhone.Items.Clear()
        End If
    End Sub

    Private Sub txtEXCHANGERATE_TextChanged(sender As Object, e As EventArgs) Handles txtEXCHANGERATE.TextChanged
        Dim v_dbmarketvalue As Double
        If txtAmount.EditValue > 0 Then
            v_dbmarketvalue = CDbl(txtEXCHANGERATE.Text) * CDbl(txtAmount.Text)
            txtMARKETVALUE.Text = Format(Math.Round(CDbl(v_dbmarketvalue)), gc_FORMAT_NUMBER_0)
        End If

    End Sub

    Private Sub txtAMOUNT_Leave(sender As Object, e As EventArgs) Handles txtAmount.Leave
        Dim v_dbmarketvalue As Double
        If txtQuantity.EditValue <= txtSETRADE.Text And txtAmount.EditValue <= txtBALANCE.Text Then
            btnSendMail.Enabled = False
            'cboFX.Width = 110
        Else
            btnSendMail.Enabled = True
            'cboFX.Width = 110
        End If
        If txtEXCHANGERATE.Text.Length > 0 And Double.TryParse(txtAmount.Text, v_dbmarketvalue) Then
            v_dbmarketvalue = CDbl(txtEXCHANGERATE.Text) * CDbl(txtAmount.Text)
            txtMARKETVALUE.Text = Format(Math.Round(CDbl(v_dbmarketvalue)), gc_FORMAT_NUMBER_0)

            If Me.UserLanguage = "VN" Then
                If txtAmount.EditValue > 1 Then
                    'lblWords.Text = TienBangChu(txtAmount.Text.Substring(0, txtAmount.Text.Length - 3))
                    lblWords.Text = Num2Text(txtAmount.Text.Substring(0, txtAmount.Text.Length - 3))
                End If
            Else
                If txtAmount.EditValue >= 1 Then
                    lblWords.Text = NumberToText(txtAmount.Text.Substring(0, txtAmount.Text.Length - 3))
                End If
            End If
        End If
    End Sub


    Private Sub cboSymbol_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboSymbol.SelectedValueChanged
        If cboAFMAST.Items.Count > 0 And cboAFMAST.SelectedIndex <> -1 Then
            If cboSymbol.Items.Count > 0 And cboSymbol.SelectedIndex <> -1 Then
                GetSEInfo(CType(cboAFMAST.SelectedItem, ComboBoxItem).Value, CType(cboSymbol.SelectedItem, ComboBoxItem).Value)

                If cboBROKER.Items.Count > 0 And cboBROKER.SelectedIndex <> -1 Then
                    GetBrokerSEInfo(CType(cboAFMAST.SelectedItem, ComboBoxItem).Value, CType(cboSymbol.SelectedItem, ComboBoxItem).Value, CType(cboBROKER.SelectedItem, ComboBoxItem).Value)
                Else
                    txtSEBLOCKEDBR.Text = "0"
                End If
            Else
                txtSENAMEEN.Text = ""
                txtSENAMEVN.Text = ""
                txtQuantity.Text = "0"
                txtSETRADE.Text = "0"
                txtSEBLOCKEDBR.Text = "0"
            End If

        Else
            txtSENAMEEN.Text = ""
            txtSENAMEVN.Text = ""
            txtQuantity.Text = "0"
            txtSETRADE.Text = "0"
            txtSEBLOCKEDBR.Text = "0"

        End If
    End Sub

    Private Sub cboSymbol_Leave(sender As Object, e As EventArgs) Handles cboSymbol.Leave
        'If cboAFMAST.Items.Count > 0 And cboAFMAST.SelectedIndex <> -1 Then
        '    If cboSymbol.Items.Count > 0 And cboSymbol.SelectedIndex <> -1 Then
        '        GetSEInfo(CType(cboAFMAST.SelectedItem, ComboBoxItem).Value, CType(cboSymbol.SelectedItem, ComboBoxItem).Value)
        '    End If
        'Else
        '    txtSENAMEEN.Text = ""
        '    txtSENAMEVN.Text = ""
        '    txtSEBLOCKED.Text = "0"
        '    txtSETRADE.Text = "0"
        '    txtSEBLOCKEDBR.Text = "0"

        'End If
    End Sub

    Private Sub txtAMOUNT_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtQuantity_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub



#Region "Grid control"
    Private grdExchangeRate As DevExpress.XtraGrid.GridControl
    Private grdBankAccount As DevExpress.XtraGrid.GridControl
    Private grdSEHOLD As DevExpress.XtraGrid.GridControl
    Private grdSEUNHOLD As DevExpress.XtraGrid.GridControl
    Private grdSE As DevExpress.XtraGrid.GridControl
    Private grdCashHOLD As DevExpress.XtraGrid.GridControl
    Private grdCashUNHOLD As DevExpress.XtraGrid.GridControl
    Private grdCash As DevExpress.XtraGrid.GridControl
    Private grdCashSummary As DevExpress.XtraGrid.GridControl
    Private grdSESummary As DevExpress.XtraGrid.GridControl

    Friend WithEvents gvExchangeRate As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gvBankAccount As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gvSEHOLD As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gvSEUNHOLD As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gvSE As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gvCashHOLD As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gvCashUNHOLD As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gvCash As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gvCashSummary As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gvSESummary As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gvResult As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents tmr1 As Timer = New Timer()
    Private thread As Threading.Timer = New Threading.Timer(AddressOf AutoSearch, Nothing, -1, -1)

    Private Sub tmr1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr1.Tick
        Dim tp As System.Windows.Forms.TabPage = tabCashMain.SelectedTab

        For Each v_ctrl In tp.Controls
            If TypeOf (v_ctrl) Is System.Windows.Forms.Panel Then
                For Each v_ctrlgrid In v_ctrl.Controls
                    If TypeOf (v_ctrlgrid) Is DevExpress.XtraGrid.GridControl Then
                        Try
                            If mv_arrstrObjMsg("strObjMsg" & TryCast(v_ctrlgrid, DevExpress.XtraGrid.GridControl).Name) = "" Then
                                Exit Sub
                            Else
                                'trung.luu: 10-03-2021 auto search grid
                                Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                                Dim v_strObjMsg As String = mv_arrstrObjMsg("strObjMsg" & TryCast(v_ctrlgrid, DevExpress.XtraGrid.GridControl).Name)
                                v_ws.Message(v_strObjMsg)
                                UpdateDataset(TryCast(v_ctrlgrid, DevExpress.XtraGrid.GridControl), ObjDataToDataset(v_strObjMsg, , TryCast(v_ctrlgrid, DevExpress.XtraGrid.GridControl).Name))
                            End If
                        Catch ex As Exception

                        End Try
                    End If
                Next
            End If
        Next
        Dim tp1 As System.Windows.Forms.TabPage = tabSEMain.SelectedTab

        For Each v_ctrl1 In tp1.Controls
            If TypeOf (v_ctrl1) Is System.Windows.Forms.Panel Then
                For Each v_ctrlgrid1 In v_ctrl1.Controls
                    If TypeOf (v_ctrlgrid1) Is DevExpress.XtraGrid.GridControl Then
                        Try
                            If mv_arrstrObjMsg("strObjMsg" & TryCast(v_ctrlgrid1, DevExpress.XtraGrid.GridControl).Name) = "" Then
                                Exit Sub
                            Else
                                'trung.luu: 10-03-2021 auto search grid
                                Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                                Dim v_strObjMsg As String = mv_arrstrObjMsg("strObjMsg" & TryCast(v_ctrlgrid1, DevExpress.XtraGrid.GridControl).Name)
                                v_ws.Message(v_strObjMsg)
                                UpdateDataset(TryCast(v_ctrlgrid1, DevExpress.XtraGrid.GridControl), ObjDataToDataset(v_strObjMsg, , TryCast(v_ctrlgrid1, DevExpress.XtraGrid.GridControl).Name))
                            End If
                        Catch ex As Exception

                        End Try
                    End If
                Next
            End If
        Next

    End Sub
    Private Sub LoadGridCash(ByVal state As Object)
        Dim sqltr As String
        LoadGridDataEx(grdCash, pnlCash)
        LoadGridDataEx(grdCashHOLD, pnlCashHold, True)
        LoadGridDataEx(grdCashUNHOLD, pnlCashUnhold, True)
        LoadGridDataEx(grdSEHOLD, pnlSEHOLD, True)
        LoadGridDataEx(grdSEUNHOLD, pnlUnholdSE, True)
        LoadGridDataEx(grdSE, pnlSE)
        LoadGridDataEx(grdBankAccount, pnlBankAccount)
    End Sub

    Public Function VerifyCustodyCode(ByVal v_strCustodyCode As String) As Boolean
        Dim v_strErrorMessage As String = String.Empty
        Dim v_strPREFIXED, v_strPCFLAG, v_strRUNNINGNUMBER, v_strIORC, v_strPrefixedStandard As String
        '?�ộ dài phải là 10 ký tự
        If v_strCustodyCode.Length <> 10 Then
            v_strErrorMessage = "CUSTODYCD_INVALID_LENGTH"

            'MsgBox(mv_ResourceManager.GetString(v_strErrorMessage), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            'Me.txtSTC.Focus()
            Return False
        End If


        Dim v_wsFunc As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_xmlDocument As New XmlDocument
        Dim v_nodeList As XmlNodeList
        Dim v_strSQL, v_strObjMsg As String
        Dim v_strFLDNAME, v_strValue As String

        Dim v_number As String
        v_strSQL = "select count(*) SL from cfmast where custodycd = '" & txtSTC.Text & "'"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLPROFILES, gc_ActionInquiry, v_strSQL)
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        v_ws.Message(v_strObjMsg)

        v_xmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
        For k As Integer = 0 To v_nodeList.Count - 1
            For l As Integer = 0 To v_nodeList.Item(k).ChildNodes.Count - 1
                With v_nodeList.Item(k).ChildNodes(l)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), XmlAttribute).Value)
                    v_strValue = .InnerText.ToString
                End With
                Select Case Trim(v_strFLDNAME)
                    Case "SL"
                        v_number = CStr(v_strValue).Trim
                End Select
            Next
        Next
        If v_number = "0" Then
            Me.txtSTC.Focus()
            Return False
        End If
        Return True

    End Function

    Public Sub PrepareSearchParamsAdv(ByVal pv_strUserLanguage As String, ByVal pv_strObjMsg As String, ByRef pv_strSrTitle As String, ByRef pv_strSrEnTitle As String, _
                                   ByRef pv_strSrCmd As String, ByRef pv_strSrObjName As String, _
                                   ByRef pv_strFrmName As String, ByRef pv_arrSrFieldCode() As String, _
                                   ByRef pv_arrSrFieldName() As String, ByRef pv_arrSrFieldType() As String, _
                                   ByRef pv_arrSrFieldMask() As String, ByRef pv_arrSrFieldDefValue() As String, ByRef pv_arrSrFieldOperator() As String, _
                                   ByRef pv_arrSrFieldFormat() As String, ByRef pv_arrSrFieldDisplay() As String, _
                                   ByRef pv_arrSrFieldWidth() As Integer, ByRef pv_arrSrLookupSql() As String, ByRef pv_arrSrFieldMultiLang() As String, _
                                   ByRef pv_arrSrFieldMandatory() As String, ByRef pv_arrSrRefCDType() As String, ByRef pv_arrSrRefCDName() As String, _
                                   ByRef pv_arrSrQuickSearch() As String, ByRef pv_arrSrSummaryCode() As String, _
                                   ByRef pv_strKeyColumn As String, ByRef pv_strKeyFieldType As String, ByRef pv_intSearchNum As Integer, _
                                   ByRef pv_strRefColumn As String, ByRef pv_strRefFieldType As String, Optional ByRef pv_strSrOderByCmd As String = "", _
                                   Optional ByRef pv_strTLTXCD As String = "", Optional ByRef pv_strISSMS As String = "N", _
                                   Optional ByRef pv_strISEMAIL As String = "N", Optional ByRef pv_intRowPerPage As Integer = 0, Optional ByRef pv_strAUTHCODE As String = "", _
                                   Optional ByRef pv_strROWLIMIT As String = "Y", Optional ByRef pv_strCMDTYPE As String = "T", Optional ByRef pv_strCondDefFld As String = "", _
                                   Optional ByRef pv_strBANKINQ As String = "N", Optional ByRef pv_strBANKACCT As String = "",
                                   Optional ByRef pv_ISFLTCODEID As String = "N", Optional ByRef pv_ISFLTMBCODE As String = "N",
                                   Optional ByRef pv_QUICKSRCH As String = "N", Optional ByRef pv_SUMMARYCD As String = "", Optional ByRef pv_intInterval As Integer = 0)

        Dim v_xmlDocument As New XmlDocument
        Dim v_nodeList As XmlNodeList
        Dim v_strFLDNAME, v_strValue As String
        Dim v_strKeyValue, v_strSrch, v_strRefValue As String
        Dim v_strOderbycmdsql, v_strSrTitle, v_strSrEnTitle, v_strSrCmd, v_strSrObjName, v_strFrmName, v_strSrFieldCode, v_strSrFieldMultiLang, _
            v_strSrFieldName, v_strSrEnFieldName, v_strSrFieldType, v_strSrFieldMask, v_strSrFieldDefValue, v_strSrFieldOperator, v_strSrFieldFormat As String
        Dim v_strSrFieldDisplay, v_strSrLookupSql, v_strSrRefACDType, v_strSrRefACDName, v_strSrQuickSearch, v_strSrSummaryCode As String
        Dim v_intSrFieldWidth, v_intFieldCount As Integer

        Try
            pv_intSearchNum = 0

            v_xmlDocument.LoadXml(pv_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            v_intFieldCount = v_nodeList.Count
            ReDim pv_arrSrFieldCode(v_intFieldCount)
            ReDim pv_arrSrFieldName(v_intFieldCount)
            ReDim pv_arrSrFieldType(v_intFieldCount)
            ReDim pv_arrSrFieldMask(v_intFieldCount)
            ReDim pv_arrSrFieldDefValue(v_intFieldCount)
            ReDim pv_arrSrFieldOperator(v_intFieldCount)
            ReDim pv_arrSrFieldFormat(v_intFieldCount)
            ReDim pv_arrSrFieldDisplay(v_intFieldCount)
            ReDim pv_arrSrFieldWidth(v_intFieldCount)
            ReDim pv_arrSrLookupSql(v_intFieldCount)
            ReDim pv_arrSrFieldMultiLang(v_intFieldCount)
            ReDim pv_arrSrFieldMandatory(v_intFieldCount)
            ReDim pv_arrSrRefCDType(v_intFieldCount)
            ReDim pv_arrSrRefCDName(v_intFieldCount)
            ReDim pv_arrSrQuickSearch(v_intFieldCount)
            ReDim pv_arrSrSummaryCode(v_intFieldCount)

            For i As Integer = 0 To v_intFieldCount - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), XmlAttribute).Value)
                        v_strValue = .InnerText.ToString

                        Select Case Trim(v_strFLDNAME)
                            Case "ROWPERPAGE"
                                If IsNumeric(v_strValue) Then
                                    pv_intRowPerPage = CInt(v_strValue)
                                Else
                                    pv_intRowPerPage = 0
                                End If
                            Case "SRCH"
                                v_strSrch = Trim(v_strValue)
                            Case "AUTHCODE"
                                pv_strAUTHCODE = Trim(v_strValue)
                            Case "ROWLIMIT"
                                pv_strROWLIMIT = Trim(v_strValue)
                            Case "CMDTYPE"
                                pv_strCMDTYPE = Trim(v_strValue)
                            Case "SEARCHTITLE"
                                v_strSrTitle = Trim(v_strValue)
                            Case "EN_SEARCHTITLE"
                                v_strSrEnTitle = Trim(v_strValue)
                            Case "SEARCHCMDSQL"
                                v_strSrCmd = Trim(v_strValue)
                            Case "OBJNAME"
                                v_strSrObjName = Trim(v_strValue)
                            Case "FRMNAME"
                                v_strFrmName = Trim(v_strValue)
                            Case "FIELDCODE"
                                v_strSrFieldCode = Trim(v_strValue)
                            Case "FIELDNAME"
                                v_strSrFieldName = Trim(v_strValue)
                            Case "EN_FIELDNAME"
                                v_strSrEnFieldName = Trim(v_strValue)
                            Case "FIELDTYPE"
                                v_strSrFieldType = Trim(v_strValue)
                            Case "MASK"
                                v_strSrFieldMask = Trim(v_strValue)
                            Case "DEFVALUE"
                                v_strSrFieldDefValue = Trim(v_strValue)
                            Case "ORDERBYCMDSQL"
                                v_strOderbycmdsql = Trim(v_strValue)
                            Case "OPERATOR"
                                v_strSrFieldOperator = Trim(v_strValue)
                            Case "FORMAT"
                                v_strSrFieldFormat = Trim(v_strValue)
                            Case "DISPLAY"
                                v_strSrFieldDisplay = Trim(v_strValue)
                            Case "KEY"
                                v_strKeyValue = Trim(v_strValue)
                                If v_strKeyValue = "Y" Then
                                    pv_strKeyColumn = v_strSrFieldCode
                                    pv_strKeyFieldType = v_strSrFieldType
                                End If
                            Case "REFVALUE"
                                v_strRefValue = Trim(v_strValue)

                                If v_strRefValue = "Y" Then
                                    pv_strRefColumn = v_strSrFieldCode
                                    pv_strRefFieldType = v_strSrFieldType
                                End If
                            Case "WIDTH"
                                v_intSrFieldWidth = CInt(Trim(v_strValue))
                            Case "TLTXCD"
                                pv_strTLTXCD = Trim(v_strValue)
                            Case "LOOKUPCMDSQL"
                                v_strSrLookupSql = Trim(v_strValue)
                            Case "ISSMS"
                                pv_strISSMS = Trim(v_strValue)
                            Case "ISEMAIL"
                                pv_strISEMAIL = Trim(v_strValue)
                            Case "MULTILANG"
                                v_strSrFieldMultiLang = Trim(v_strValue)
                            Case "ACDTYPE"
                                v_strSrRefACDType = Trim(v_strValue)
                            Case "ACDNAME"
                                v_strSrRefACDName = Trim(v_strValue)
                            Case "CONDDEFFLD"
                                pv_strCondDefFld = Trim(v_strValue)
                            Case "BANKINQ"
                                pv_strBANKINQ = Trim(v_strValue)
                            Case "BANKACCT"
                                pv_strBANKACCT = Trim(v_strValue)
                            Case "ISFLTCODEID"
                                pv_ISFLTCODEID = Trim(v_strValue)
                            Case "ISFLTMBCODE"
                                pv_ISFLTMBCODE = Trim(v_strValue)
                            Case "QUICKSRCH"
                                v_strSrQuickSearch = Trim(v_strValue)
                            Case "SUMMARYCD"
                                v_strSrSummaryCode = Trim(v_strValue)
                            Case "INTERVAL"
                                If IsNumeric(v_strValue) Then
                                    pv_intInterval = CInt(v_strValue)
                                Else
                                    pv_intInterval = 0
                                End If
                        End Select
                    End With
                Next

                If v_strSrch = "Y" Or v_strSrch = "M" Then  'M là bắt buộc phải nhập giá trị tìm kiếm
                    pv_intSearchNum += 1

                    If pv_intSearchNum = 1 Then
                        pv_strSrTitle = v_strSrTitle
                        pv_strSrEnTitle = v_strSrEnTitle
                        pv_strSrCmd = v_strSrCmd
                        pv_strSrOderByCmd = v_strOderbycmdsql
                        pv_strSrObjName = v_strSrObjName
                        pv_strFrmName = v_strFrmName
                    End If
                    pv_arrSrFieldCode(pv_intSearchNum) = v_strSrFieldCode
                    pv_arrSrFieldName(pv_intSearchNum) = IIf(pv_strUserLanguage = gc_LANG_VIETNAMESE, v_strSrFieldName, v_strSrEnFieldName)
                    pv_arrSrFieldType(pv_intSearchNum) = v_strSrFieldType
                    pv_arrSrFieldMask(pv_intSearchNum) = v_strSrFieldMask
                    pv_arrSrFieldDefValue(pv_intSearchNum) = v_strSrFieldDefValue
                    pv_arrSrFieldOperator(pv_intSearchNum) = v_strSrFieldOperator
                    pv_arrSrFieldFormat(pv_intSearchNum) = v_strSrFieldFormat
                    pv_arrSrFieldDisplay(pv_intSearchNum) = v_strSrFieldDisplay
                    pv_arrSrFieldWidth(pv_intSearchNum) = v_intSrFieldWidth
                    pv_arrSrLookupSql(pv_intSearchNum) = v_strSrLookupSql
                    pv_arrSrFieldMandatory(pv_intSearchNum) = v_strSrch
                    'pv_arrSrFieldName(pv_intSearchNum) = v_strSrFieldName
                    pv_arrSrQuickSearch(pv_intSearchNum) = v_strSrQuickSearch
                    pv_arrSrSummaryCode(pv_intSearchNum) = v_strSrSummaryCode
                    pv_arrSrRefCDType(v_intFieldCount) = v_strSrRefACDType
                    pv_arrSrRefCDName(v_intFieldCount) = v_strSrRefACDName
                End If
            Next

            If pv_intSearchNum > 0 Then
                ReDim Preserve pv_arrSrFieldCode(pv_intSearchNum)
                ReDim Preserve pv_arrSrFieldName(pv_intSearchNum)
                ReDim Preserve pv_arrSrFieldType(pv_intSearchNum)
                ReDim Preserve pv_arrSrFieldMask(pv_intSearchNum)
                ReDim Preserve pv_arrSrFieldDefValue(pv_intSearchNum)
                ReDim Preserve pv_arrSrFieldOperator(pv_intSearchNum)
                ReDim Preserve pv_arrSrFieldFormat(pv_intSearchNum)
                ReDim Preserve pv_arrSrFieldDisplay(pv_intSearchNum)
                ReDim Preserve pv_arrSrFieldWidth(pv_intSearchNum)
                ReDim Preserve pv_arrSrLookupSql(pv_intSearchNum)
                ReDim Preserve pv_arrSrFieldMultiLang(pv_intSearchNum)
                ReDim Preserve pv_arrSrFieldMandatory(pv_intSearchNum)
                ReDim Preserve pv_arrSrQuickSearch(pv_intSearchNum)
                ReDim Preserve pv_arrSrSummaryCode(pv_intSearchNum)
                ReDim Preserve pv_arrSrRefCDType(v_intFieldCount)
                ReDim Preserve pv_arrSrRefCDName(v_intFieldCount)
            End If

        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub

    Private Sub _initGridFormat(ByVal mv_strTableName As String, ByRef ResultGrid As DevExpress.XtraGrid.GridControl)

        Dim mv_strCmdSql, v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_strSQL, V_strdt As String
        Dim v_ds As New DataSet
        Dim tb As New DataTable

        Dim mv_strFormName, mv_arrSrFieldSrch(), mv_arrSrFieldDisp(), mv_arrSrFieldType(), mv_arrSrFieldMask() As String
        Dim mv_arrStFieldDefValue(), mv_arrSrFieldOperator(), mv_arrSrFieldFormat(), mv_arrSrFieldDisplay() As String
        Dim mv_arrSrSQLRef(), mv_arrStFieldMultiLang(), mv_arrStFieldMandartory(), mv_arrStFieldRefCDType(), mv_arrStFieldRefCDName() As String
        Dim mv_strKeyColumn, mv_strKeyFieldType, mv_intSearchNum, mv_strRefColumn, mv_strRefFieldType As String
        Dim mv_strSrOderByCmd, mv_strTLTXCD, mv_strIsSMS, mv_strIsEMAIL, mv_rowpage, mv_strSearchAuthCode As String
        Dim mv_strRowLimit, mv_strCommandType, mv_strCondDefFld, mv_strBANKINQ, mv_strBANKACCT As String
        Dim mv_strCaption, mv_strEnCaption, mv_strObjName, mv_ISFLTCODEID, mv_ISFLTMBCODE As String
        Dim mv_arrSrFieldWidth() As Integer
        Dim v_strCmdInquiry As String = "SELECT * FROM V_SEARCHCD WHERE 0=0 "
        Dim v_strClause As String = " UPPER(SEARCHCODE) = '" & mv_strTableName & "' ORDER BY POSITION"
        Dim mv_arrStQuickSearch() As String                   '
        Dim mv_arrStSummaryCode() As String


        v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_SEARCHFLD, gc_ActionInquiry, v_strCmdInquiry, v_strClause, )
        v_ws.Message(v_strObjMsg)

        'PrepareSearchParams(UserLanguage, v_strObjMsg, mv_strCaption, mv_strEnCaption, mv_strCmdSql, mv_strObjName, _
        '        mv_strFormName, mv_arrSrFieldSrch, mv_arrSrFieldDisp, mv_arrSrFieldType, mv_arrSrFieldMask, _
        '        mv_arrStFieldDefValue, mv_arrSrFieldOperator, mv_arrSrFieldFormat, mv_arrSrFieldDisplay, mv_arrSrFieldWidth, _
        '        mv_arrSrSQLRef, mv_arrStFieldMultiLang, mv_arrStFieldMandartory, mv_arrStFieldRefCDType, mv_arrStFieldRefCDName, _
        '        mv_strKeyColumn, mv_strKeyFieldType, mv_intSearchNum, mv_strRefColumn, mv_strRefFieldType, _
        '        mv_strSrOderByCmd, mv_strTLTXCD, mv_strIsSMS, mv_strIsEMAIL, mv_rowpage, mv_strSearchAuthCode, _
        '        mv_strRowLimit, mv_strCommandType, mv_strCondDefFld, mv_strBANKINQ, mv_strBANKACCT)

        PrepareSearchParamsAdv(UserLanguage, v_strObjMsg, mv_strCaption, mv_strEnCaption, mv_strCmdSql, mv_strObjName, _
            mv_strFormName, mv_arrSrFieldSrch, mv_arrSrFieldDisp, mv_arrSrFieldType, mv_arrSrFieldMask, _
            mv_arrStFieldDefValue, mv_arrSrFieldOperator, mv_arrSrFieldFormat, mv_arrSrFieldDisplay, mv_arrSrFieldWidth, _
            mv_arrSrSQLRef, mv_arrStFieldMultiLang, mv_arrStFieldMandartory, mv_arrStFieldRefCDType, mv_arrStFieldRefCDName, _
            mv_arrStQuickSearch, mv_arrStSummaryCode,
            mv_strKeyColumn, mv_strKeyFieldType, mv_intSearchNum, mv_strRefColumn, mv_strRefFieldType, _
            mv_strSrOderByCmd, mv_strTLTXCD, mv_strIsSMS, mv_strIsEMAIL, mv_rowpage, mv_strSearchAuthCode, _
            mv_strRowLimit, mv_strCommandType, mv_strCondDefFld, mv_strBANKINQ, mv_strBANKACCT, mv_ISFLTCODEID, mv_ISFLTMBCODE)

        Dim ds As DataTable = New DataTable()
        ds = InitGridSearchFields(mv_strTableName, mv_arrSrFieldSrch, mv_arrSrFieldDisp, mv_arrSrFieldType)
        mv_arrDataSource.Add("DataSource" & ResultGrid.Name, ds)
        ResultGrid.DataSource = mv_arrDataSource("DataSource" & ResultGrid.Name)


        mv_arrformatDic("mv_arrSrFieldSrch" & ResultGrid.Name) = mv_arrSrFieldSrch
        mv_arrformatDic("mv_arrSrFieldFormat" & ResultGrid.Name) = mv_arrSrFieldFormat
        mv_arrWithDic("mv_arrSrFieldWidth" & ResultGrid.Name) = mv_arrSrFieldWidth
        mv_arrformatDic("mv_arrSrFieldDisp" & ResultGrid.Name) = mv_arrSrFieldDisp
        mv_arrformatDic("mv_arrSrFieldDisplay" & ResultGrid.Name) = mv_arrSrFieldDisplay
        mv_arrformatDic("mv_arrStSummaryCode" & ResultGrid.Name) = mv_arrStSummaryCode

        mv_arrstrSearch.Add("mv_strSrOderByCmd" & ResultGrid.Name, mv_strSrOderByCmd)

        If Me.UserLanguage = gc_LANG_ENGLISH Then
            mv_strCmdSql = mv_strCmdSql.Replace("<@CDCONTENT>", "EN_CDCONTENT")
            mv_strCmdSql = mv_strCmdSql.Replace("<@DESCRIPTION>", "EN_DESCRIPTION")
        Else
            mv_strCmdSql = mv_strCmdSql.Replace("<@CDCONTENT>", "CDCONTENT")
            mv_strCmdSql = mv_strCmdSql.Replace("<@DESCRIPTION>", "DESCRIPTION")
        End If
        mv_arrstrSearch.Add("mv_strCmdSql" & ResultGrid.Name, mv_strCmdSql)
    End Sub
    Private Function ConvertXmlDocToDataSet(ByVal pv_xmlDoc As XmlDocument) As DataSet
        Try
            Dim v_ds As New DataSet("Object")
            Dim v_dr As DataRow
            Dim v_dc As DataColumn
            Dim v_intCountCol As Integer

            Dim v_nodeXSD, v_nodeXML As XmlNode
            Dim v_strDataXSD, v_strDataXML, v_strBuilder As String
            Dim v_arrXSDByteMessage(), v_arrXMLByteMessage() As Byte
            Dim v_Encoded As Char()

            v_nodeXSD = pv_xmlDoc.SelectSingleNode("/ObjectMessage/ObjDataXSD")
            v_nodeXML = pv_xmlDoc.SelectSingleNode("/ObjectMessage/ObjDataXML")
            v_strDataXSD = v_nodeXSD.InnerText
            v_strDataXML = v_nodeXML.InnerText
            'Get schema
            Dim v_XSD As New TestBase64.Base64Decoder(v_strDataXSD)
            v_arrXSDByteMessage = v_XSD.GetDecoded()
            v_strDataXSD = ZetaCompressionLibrary.CompressionHelper.DecompressString(v_arrXSDByteMessage)
            'Get data
            Dim v_XML As New TestBase64.Base64Decoder(v_strDataXML)
            v_arrXMLByteMessage = v_XML.GetDecoded()
            v_strDataXML = ZetaCompressionLibrary.CompressionHelper.DecompressString(v_arrXMLByteMessage)
            'Create dataset
            Dim v_XMLREADER, v_XSDREADER As System.IO.StringReader
            v_XMLREADER = New System.IO.StringReader(v_strDataXML)
            v_XSDREADER = New System.IO.StringReader(v_strDataXSD)
            If v_ds Is Nothing Then v_ds = New DataSet
            v_ds.Tables.Clear()
            v_ds.ReadXmlSchema(v_XSDREADER)
            v_ds.ReadXml(v_XMLREADER)
            v_ds.Tables(0).TableName = "ObjData"
            Return v_ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Sub LoadGridDataEx(ByRef ResultGrid As DevExpress.XtraGrid.GridControl, Optional ByRef pnlGrid As Panel = Nothing, Optional ByVal blTickEnable As Boolean = False)
        Dim mv_strSQLCMD As String
        Try
            If (Not (tabCashMain.SelectedTab.Name.Contains(ResultGrid.Name) Or tabSEMain.SelectedTab.Name.Contains(ResultGrid.Name))) And ResultGrid.Name <> "BROKER_BANK" And ResultGrid.Name <> "EXCHANGE_RATE" Then
                Exit Sub
            End If
            Dim str_search, str_Clause, mv_strSearchFilter As String
            Dim v_xColumn As Xceed.Grid.Column, v_strFLDNAME As String
            Dim c_ResourceManagerGrid As String = ""
            mv_strSQLCMD = mv_arrstrSearch("mv_strCmdSql" & ResultGrid.Name)
            ''Cursor.Current = Cursors.WaitCursor
            If ResultGrid.Name <> "EXCHANGE_RATE" Then
                mv_strSearchFilter = " CUSTODYCD ='" & txtSTC.Text & "'"
            Else
                mv_strSearchFilter = " 0 = 0"
            End If
            ' mv_strSQLCMD = mv_strSQLCMD & " AND " & mv_strSearchFilter
            mv_strSQLCMD = "SELECT * FROM ( SELECT T1.*,ROWNUM RN FROM(" & mv_strSQLCMD & " AND " & mv_strSearchFilter & ")T1)"
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_SEARCHFLD, gc_ActionInquiry, mv_strSQLCMD)
            mv_arrstrObjMsg("strObjMsg" & ResultGrid.Name) = v_strObjMsg
            v_ws.Message(v_strObjMsg)



            mv_arrDataSource("DataSource" & ResultGrid.Name) = ObjDataToDataset(v_strObjMsg, , ResultGrid.Name)
            'mv_arrDataSource("DataSource" & ResultGrid.Name).Merge(ObjDataToDataset(v_strObjMsg, , ResultGrid.Name))
            ResultGrid.Update()


            ResultGrid.DataSource = mv_arrDataSource("DataSource" & ResultGrid.Name)

            Dim mv_intTotalCountRow As Integer = ResultGrid.MainView.RowCount
            XtraGridFormatLocal(ResultGrid.Views(0), c_ResourceManager & UserLanguage)
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(mv_strSQLCMD & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub AutoSearch(ByVal state As Object)
        Dim tp As System.Windows.Forms.TabPage = tabCashMain.SelectedTab

        For Each v_ctrl In tp.Controls
            If TypeOf (v_ctrl) Is System.Windows.Forms.Panel Then
                For Each v_ctrlgrid In v_ctrl.Controls
                    If TypeOf (v_ctrlgrid) Is DevExpress.XtraGrid.GridControl Then
                        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                        Try
                            If mv_arrstrObjMsg("strObjMsg" & TryCast(v_ctrlgrid, DevExpress.XtraGrid.GridControl).Name) = "" Then
                                Exit Sub
                            Else

                                Dim v_strObjMsg As String = mv_arrstrObjMsg("strObjMsg" & TryCast(v_ctrlgrid, DevExpress.XtraGrid.GridControl).Name)
                                v_ws.Message(v_strObjMsg)
                                UpdateDataset(TryCast(v_ctrlgrid, DevExpress.XtraGrid.GridControl), ObjDataToDataset(v_strObjMsg, , TryCast(v_ctrlgrid, DevExpress.XtraGrid.GridControl).Name))

                            End If
                        Catch ex As Exception
                            LogError.Write("Error source: AppCore.frmSearch.LoadLastSearch" & vbNewLine _
                                         & "Error code: System error!" & vbNewLine _
                                         & "Error message: " & ex.Message, EventLogEntryType.Error)
                        End Try
                    End If
                Next
            End If
        Next

        Dim tp1 As System.Windows.Forms.TabPage = tabSEMain.SelectedTab

        For Each v_ctrl1 In tp1.Controls
            If TypeOf (v_ctrl1) Is System.Windows.Forms.Panel Then
                For Each v_ctrlgrid1 In v_ctrl1.Controls
                    If TypeOf (v_ctrlgrid1) Is DevExpress.XtraGrid.GridControl Then
                        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                        Try
                            If v_strObjMsg_search = "" Then
                                Exit Sub
                            Else
                                Dim v_strObjMsg As String = v_strObjMsg_search
                                v_ws.Message(v_strObjMsg)
                                mv_arrDataSource("DataSource" & TryCast(v_ctrlgrid1, DevExpress.XtraGrid.GridControl).Name) = ObjDataToDataset(v_strObjMsg, , TryCast(v_ctrlgrid1, DevExpress.XtraGrid.GridControl).Name)
                                UpdateDataset(TryCast(v_ctrlgrid1, DevExpress.XtraGrid.GridControl), mv_arrDataSource("DataSource" & TryCast(v_ctrlgrid1, DevExpress.XtraGrid.GridControl).Name))
                            End If
                        Catch ex As Exception
                            LogError.Write("Error source: AppCore.frmSearch.LoadLastSearch" & vbNewLine _
                                         & "Error code: System error!" & vbNewLine _
                                         & "Error message: " & ex.Message, EventLogEntryType.Error)
                        End Try
                    End If
                Next
            End If
        Next


    End Sub

    Public Sub UpdateDataset(ByRef ResultGrid As DevExpress.XtraGrid.GridControl, ByVal ds As DataTable)
        Try
            Dim GridName As String = ResultGrid.Name
            ResultGrid.Invoke(Sub(d As DataTable)
                                  Dim PrimaryKey() As DataColumn = {mv_arrDataSource("DataSource" & GridName).Columns("RN")}
                                  mv_arrDataSource("DataSource" & GridName).PrimaryKey = PrimaryKey
                                  mv_arrDataSource("DataSource" & GridName).Merge(d)
                              End Sub, ds)
        Catch ex As Exception
            LogError.Write("Error source: AppCore.frmSearch.LoadLastSearch" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
        End Try

    End Sub

    Private Sub XtraGridFormatLocal(ByRef pv_xGridView As GridView, pv_strResource As String)

        Dim intarr() As Integer
        ' intarr = TryCast(mv_arrformatDic("mv_arrSrFieldWidth" & ResultGrid.Name), Integer())


        ''   XtraGridFormat(ResultGrid.Views(0), c_ResourceManager & UserLanguage, mv_arrformatDic("mv_arrSrFieldSrch" & ResultGrid.Name), mv_arrformatDic("mv_arrSrFieldFormat" & ResultGrid.Name), mv_arrWithDic("mv_arrSrFieldWidth" & ResultGrid.Name), mv_arrformatDic("mv_arrSrFieldDisp" & ResultGrid.Name), mv_arrformatDic("mv_arrSrFieldDisplay" & ResultGrid.Name))

        Dim mv_arrSrFieldSrch As String() = mv_arrformatDic("mv_arrSrFieldSrch" & pv_xGridView.GridControl.Name)
        Dim mv_arrSrFieldFormat As String() = mv_arrformatDic("mv_arrSrFieldFormat" & pv_xGridView.GridControl.Name)
        Dim mv_arrSrFieldWidth As Integer() = mv_arrWithDic("mv_arrSrFieldWidth" & pv_xGridView.GridControl.Name)
        Dim mv_arrSrFieldDisp As String() = mv_arrformatDic("mv_arrSrFieldDisp" & pv_xGridView.GridControl.Name)
        Dim mv_arrSrFieldDisplay As String() = mv_arrformatDic("mv_arrSrFieldDisplay" & pv_xGridView.GridControl.Name)

        Dim v_xColumn As GridColumn
        Dim i As Integer
        Dim v_strFLDNAME As String

        Dim m_ResourceManager As Resources.ResourceManager
        If Len(pv_strResource) > 0 Then
            m_ResourceManager = New Resources.ResourceManager(pv_strResource, System.Reflection.Assembly.GetExecutingAssembly())
        End If

        'Không cho phép sửa dữ liệu trên GRID
        pv_xGridView.OptionsBehavior.Editable = False
        'pv_xGridView.OptionsBehavior.AllowAddRows = True
        pv_xGridView.OptionsBehavior.ReadOnly = True

        pv_xGridView.OptionsView.ShowAutoFilterRow = True
        pv_xGridView.OptionsView.ShowGroupPanel = False
        pv_xGridView.OptionsView.ShowIndicator = False
        'pv_xGridView.OptionsView.EnableAppearanceEvenRow = True
        'pv_xGridView.OptionsView.EnableAppearanceOddRow = True
        pv_xGridView.OptionsView.ColumnAutoWidth = True

        'Header panel
        pv_xGridView.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center
        pv_xGridView.Appearance.HeaderPanel.Font = New Font(pv_xGridView.Appearance.HeaderPanel.Font, FontStyle.Bold)

        'Selected row color
        'pv_xGridView.Appearance.FocusedRow.BackColor = ColorTranslator.FromHtml("#283593")

        'Alternative rows color
        'pv_xGridView.Appearance.EvenRow.BackColor = ColorTranslator.FromHtml("#e8f5e9")
        'pv_xGridView.Appearance.OddRow.BackColor = ColorTranslator.FromHtml("#c8e6c9")

        'Format column
        Dim l_IsVisible As Boolean = True
        For Each v_xColumn In pv_xGridView.Columns
            v_strFLDNAME = UCase(Trim(v_xColumn.FieldName))
            l_IsVisible = False
            For i = 0 To mv_arrSrFieldSrch.GetLength(0) - 1
                If UCase(mv_arrSrFieldSrch(i)) = v_strFLDNAME Then
                    l_IsVisible = True
                    Select Case v_xColumn.ColumnType.Name

                        Case GetType(System.Decimal).Name, GetType(Integer).Name, GetType(Long).Name, GetType(Double).Name
                            v_xColumn.DisplayFormat.FormatType = FormatType.Numeric
                            v_xColumn.DisplayFormat.FormatString = IIf(String.IsNullOrEmpty(mv_arrSrFieldFormat(i)), "n0", mv_arrSrFieldFormat(i))

                        Case GetType(System.DateTime).Name
                            v_xColumn.DisplayFormat.FormatType = FormatType.DateTime
                            v_xColumn.DisplayFormat.FormatString = IIf(String.IsNullOrEmpty(mv_arrSrFieldFormat(i)), "dd/MM/yy", mv_arrSrFieldFormat(i))
                            v_xColumn.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center

                    End Select

                    Select Case UCase(mv_arrSrFieldFormat(i))

                        Case "C"
                            Dim LookupEditReponsitory As New RepositoryItemLookUpEdit()
                            LookupEditReponsitory.Name = v_strFLDNAME
                            pv_xGridView.GridControl.RepositoryItems.Add(LookupEditReponsitory)
                            '  v_xColumn.ColumnEdit = LookupEditReponsitory

                    End Select

                    v_xColumn.Width = mv_arrSrFieldWidth(i)
                    v_xColumn.Caption = mv_arrSrFieldDisp(i)
                    v_xColumn.Visible = mv_arrSrFieldDisplay(i).Equals("Y")
                End If
            Next
            If l_IsVisible = False And Not v_xColumn.FieldName.Equals("CheckMarkSelection") Then
                v_xColumn.Visible = False
            End If
        Next
    End Sub

    Private Sub LoadGridData(ByVal v_strCmdSQL As String, ByRef ResultGrid As GridEx, ByRef pnlGrid As Panel)
        Dim v_nodeList As XmlNodeList
        Dim v_xmlDocument As New XmlDocument
        Dim v_strValue, v_strFLDNAME, v_strFLDTYPE, v_strTEXT As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strObjMsg As String
        Try
            v_strCmdSQL = "select * from " & v_strCmdSQL & " where custodycd = '" & txtSTC.Text & "'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count > 0 Then
                'Lay tieu de grid
                ResultGrid = New GridEx
                Dim v_cmrODBuyGrid As New Xceed.Grid.ColumnManagerRow
                v_cmrODBuyGrid.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
                v_cmrODBuyGrid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
                'ODBuyGrid.FixedHeaderRows.Add(v_grODBuyGrid)
                ResultGrid.FixedHeaderRows.Add(v_cmrODBuyGrid)


                For j As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                    v_strFLDNAME = CStr(CType(v_nodeList.Item(0).ChildNodes(j).Attributes.GetNamedItem("fldname"), XmlAttribute).Value)
                    v_strFLDTYPE = CStr(CType(v_nodeList.Item(0).ChildNodes(j).Attributes.GetNamedItem("fldtype"), XmlAttribute).Value)
                    Select Case v_strFLDTYPE
                        Case "System.String"
                            ResultGrid.Columns.Add(New Xceed.Grid.Column(v_strFLDNAME, GetType(System.String)))
                        Case "System.DateTime"
                            ResultGrid.Columns.Add(New Xceed.Grid.Column(v_strFLDNAME, GetType(System.String)))
                        Case Else
                            ResultGrid.Columns.Add(New Xceed.Grid.Column(v_strFLDNAME, GetType(System.Double)))
                    End Select
                    ResultGrid.Columns(v_strFLDNAME).Title = v_strFLDNAME


                Next

                'Fill du lieu vao Grid
                For i As Integer = 0 To v_nodeList.Count - 1
                    v_strTEXT = String.Empty
                    Dim v_xDataRow As Xceed.Grid.DataRow = ResultGrid.DataRows.AddNew()
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = Trim(.InnerText.ToString)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), XmlAttribute).Value)
                            v_strFLDTYPE = CStr(CType(.Attributes.GetNamedItem("fldtype"), XmlAttribute).Value)
                            Select Case v_strFLDTYPE
                                Case "System.String"
                                    v_xDataRow.Cells(v_strFLDNAME).Value = IIf(v_strValue Is DBNull.Value, "", CStr(v_strValue))
                                Case "System.DateTime"
                                    v_xDataRow.Cells(v_strFLDNAME).Value = IIf(v_strValue Is DBNull.Value, "", CStr(v_strValue))
                                Case Else
                                    v_xDataRow.Cells(v_strFLDNAME).Value = IIf(v_strValue Is DBNull.Value, 0, CDbl(v_strValue))
                            End Select
                        End With
                    Next
                    v_xDataRow.EndEdit()
                Next

                Dim v_frResultGrid = New Xceed.Grid.TextRow("Kết quả đồng bộ dữ liệu " & v_nodeList.Count & " dòng!")
                v_frResultGrid.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
                v_frResultGrid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic)
                ResultGrid.FixedFooterRows.Clear()
                ResultGrid.FixedFooterRows.Add(v_frResultGrid)

                pnlGrid.Controls.Clear()
                pnlGrid.Controls.Add(ResultGrid)
                ResultGrid.Dock = System.Windows.Forms.DockStyle.Fill





            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



#End Region



#Region "Transact process"
    Private Sub AddElement(ByRef v_xmlDocument As XmlDocument, ByRef v_dataElement As XmlElement,
                             v_strFLDNAME As String, v_strDATATYPE As String, v_strFLDVALUE As String)
        Try
            Dim v_attrFLDNAME As XmlAttribute, v_attrDATATYPE As XmlAttribute
            Dim v_entryNode As XmlNode
            'Append entry to data node
            v_entryNode = v_xmlDocument.CreateNode(XmlNodeType.Element, "entry", "")
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
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function VerifyRulesCash(ByRef v_strTxMsg As String) As Boolean
        Try
            Dim v_xmlDocument As New XmlDocument, v_dataElement As XmlElement, v_entryNode As XmlNode
            Dim v_nodeList As XmlNodeList, v_nodetxData As XmlNode, v_intIndex As Long, i, v_intCount As Integer
            Dim v_strFLDNAME As String, v_strFLDDEFNAME As String, v_strDATATYPE As String, v_strFLDVALUE As String
            Dim v_strERRMSG, v_strENERRMSG, v_strOPERATOR, v_strVALEXP, v_strVALEXP2 As String, v_strACTYPE, v_strDESC As String
            Dim v_dtVALEXP, v_dtVALEXP2, v_dtFLDVALUE As Date, v_strCMDSQL As String
            Dim v_ctl As Control, v_attrFLDNAME As XmlAttribute, v_attrDATATYPE As XmlAttribute, v_objEval As New Evaluator

            ''     LoadScreen(Me.Tltxcd)
            v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, Me.Tltxcd, Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , , Me.BusDate, , , , , , , "BROKERCONFIRM")
            v_xmlDocument.LoadXml(v_strTxMsg)
            v_dataElement = v_xmlDocument.CreateElement(XmlNodeType.Element, "fields", "")



            '' "03" 'SECACCOUNT,C
            v_strFLDVALUE = CType(cboAFMAST.SelectedItem, ComboBoxItem).Value
            AddElement(v_xmlDocument, v_dataElement, "03", "C", v_strFLDVALUE)
            'Remember account field
            Clipboard.SetDataObject(v_strFLDVALUE)
            '' "04" 'DDACCTNO,C
            v_strFLDVALUE = CType(cboDDMAST.SelectedItem, ComboBoxItem).Value
            AddElement(v_xmlDocument, v_dataElement, "04", "C", v_strFLDVALUE)
            '' "05" 'MEMBERID,C
            v_strFLDVALUE = CType(cboBROKER.SelectedItem, ComboBoxItem).Value
            AddElement(v_xmlDocument, v_dataElement, "05", "C", v_strFLDVALUE)
            '' "06" 'BRNAME,N
            v_strFLDVALUE = CType(cboEmploy.SelectedItem, ComboBoxItem).Value
            AddElement(v_xmlDocument, v_dataElement, "06", "C", v_strFLDVALUE)
            '' "07" 'BRPHONE,N
            v_strFLDVALUE = CType(cboPhone.SelectedItem, ComboBoxItem).Value
            AddElement(v_xmlDocument, v_dataElement, "07", "C", v_strFLDVALUE)
            '' "10" 'AMOUNT,N
            v_strFLDVALUE = CDbl(txtAmount.EditValue)
            AddElement(v_xmlDocument, v_dataElement, "10", "N", v_strFLDVALUE)
            '' "11" 'BANKHOLDEDBYBROKER,N
            v_strFLDVALUE = CDbl(txtHOLDBR.Text)
            AddElement(v_xmlDocument, v_dataElement, "11", "N", v_strFLDVALUE)
            '' "12" 'BANKHOLDED,N
            v_strFLDVALUE = CDbl(txtHOLDBALANCE.Text)
            AddElement(v_xmlDocument, v_dataElement, "12", "N", v_strFLDVALUE)
            '' "13" 'BANKBALANCE,N
            v_strFLDVALUE = CDbl(txtBALANCE.Text)
            AddElement(v_xmlDocument, v_dataElement, "13", "N", v_strFLDVALUE)
            '' "20" 'CCYCD,C
            v_strFLDVALUE = lblCCYCD.Text
            AddElement(v_xmlDocument, v_dataElement, "20", "C", v_strFLDVALUE)
            '' "21" 'EXCHANGERATE,N
            v_strFLDVALUE = CDbl(txtEXCHANGERATE.Text)
            AddElement(v_xmlDocument, v_dataElement, "21", "N", v_strFLDVALUE)
            '' "22" 'VALUE,N
            v_strFLDVALUE = CDbl(txtMARKETVALUE.Text)
            AddElement(v_xmlDocument, v_dataElement, "22", "N", v_strFLDVALUE)
            '' "30" 'DESC,N
            v_strFLDVALUE = txtNOTE.Text
            AddElement(v_xmlDocument, v_dataElement, "30", "C", v_strFLDVALUE)
            '' "88" 'CUSTODYCD
            v_strFLDVALUE = txtSTC.Text
            AddElement(v_xmlDocument, v_dataElement, "88", "C", v_strFLDVALUE)
            '' "90" 'CUSTNAME,C
            v_strFLDVALUE = lblName.Text
            AddElement(v_xmlDocument, v_dataElement, "90", "C", v_strFLDVALUE)
            '' "93" 'REFCASAACCT,C
            v_strFLDVALUE = CType(cboDDMAST.SelectedItem, ComboBoxItem).Text
            AddElement(v_xmlDocument, v_dataElement, "93", "C", v_strFLDVALUE)

            v_strTxMsg = v_xmlDocument.InnerXml
            Return True
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    Private Function VerifyRules(ByRef v_strClauseParam As String) As Boolean


        Select Case Tltxcd
            Case "6690"
                v_strClauseParam = String.Format(strBank_holdbalance_param, CType(cboDDMAST.SelectedItem, ComboBoxItem).Value,
                                                                         CType(cboBROKER.SelectedItem, ComboBoxItem).Value,
                                                                         CType(cboEmploy.SelectedItem, ComboBoxItem).Value,
                                                                         CType(cboPhone.SelectedItem, ComboBoxItem).Value,
                                                                         CDbl(txtAmount.EditValue),
                                                                         "BANKHOLDEDBYBROKER",
                                                                         modCommond.gen_req_key(),
                                                                         txtNOTE.Text,
                                                                         TellerId,
                                                                         "")
                'trung.luu hold/unhold cho tai khoan tu doanh
            Case "6603"
                v_strClauseParam = String.Format(strTD_hold_param, txtSTC.Text,
                                                                CType(cboBROKER.SelectedItem, ComboBoxItem).Value,
                                                                CType(cboEmploy.SelectedItem, ComboBoxItem).Value,
                                                                CType(cboPhone.SelectedItem, ComboBoxItem).Value,
                                                                CDbl(txtAmount.EditValue),
                                                                TellerId,
                                                                txtNOTE.Text,
                                                                "")
                'trung.luu hold/unhold cho tai khoan tu doanh
            Case "6604"
                v_strClauseParam = String.Format(strTD_unhold_param, txtSTC.Text,
                                                                CType(cboBROKER.SelectedItem, ComboBoxItem).Value,
                                                                CType(cboEmploy.SelectedItem, ComboBoxItem).Value,
                                                                CType(cboPhone.SelectedItem, ComboBoxItem).Value,
                                                               CDbl(txtAmount.EditValue),
                                                               TellerId,
                                                               txtNOTE.Text,
                                                               "")
                '  System.Guid.NewGuid.ToString()
            Case "6671"
                v_strClauseParam = String.Format(strBank_inquiry_param, CType(cboDDMAST.SelectedItem, ComboBoxItem).Value,
                                                                         "BANKINQUIRYBYBROKER",
                                                                         modCommond.gen_req_key(),
                                                                         "",
                                                                         TellerId,
                                                                         txtNOTE.Text,
                                                                         "")


                Return True
            Case "6691"
                Return True
            Case "2212"
                Dim v_strSEACCTNO As String = CType(cboAFMAST.SelectedItem, ComboBoxItem).Value.Substring(0, 10) & CType(cboSymbol.SelectedItem, ComboBoxItem).Value
                v_strClauseParam = String.Format(str_holdse_param, v_strSEACCTNO,
                                                                         CType(cboBROKER.SelectedItem, ComboBoxItem).Value,
                                                                         CType(cboEmploy.SelectedItem, ComboBoxItem).Value,
                                                                         CType(cboPhone.SelectedItem, ComboBoxItem).Value,
                                                                         CDbl(txtQuantity.Text),
                                                                          txtNoteSE.Text,
                                                                         TellerId,
                                                                         "")
                Return True
            Case "2213"
                If v_strClauseParam = "" Then
                    Dim v_strSEACCTNO As String = CType(cboAFMAST.SelectedItem, ComboBoxItem).Value.Substring(0, 10) & CType(cboSymbol.SelectedItem, ComboBoxItem).Value
                    v_strClauseParam = String.Format(str_unholdse_param, v_strSEACCTNO,
                                                                             CType(cboBROKER.SelectedItem, ComboBoxItem).Value,
                                                                             CType(cboEmploy.SelectedItem, ComboBoxItem).Value,
                                                                             CType(cboPhone.SelectedItem, ComboBoxItem).Value,
                                                                             CDbl(txtQuantity.Text),
                                                                             txtNoteSE.Text,
                                                                             TellerId,
                                                                             "")
                End If
                Return True

        End Select
        Return True
    End Function
    Private Function VerifyRulesSE(ByRef v_strTxMsg As String) As Boolean
        Try
            Dim v_xmlDocument As New XmlDocument, v_dataElement As XmlElement, v_entryNode As XmlNode
            Dim v_nodeList As XmlNodeList, v_nodetxData As XmlNode, v_intIndex As Long, i, v_intCount As Integer
            Dim v_strFLDNAME As String, v_strFLDDEFNAME As String, v_strDATATYPE As String, v_strFLDVALUE As String
            Dim v_strERRMSG, v_strENERRMSG, v_strOPERATOR, v_strVALEXP, v_strVALEXP2 As String, v_strACTYPE, v_strDESC As String
            Dim v_dtVALEXP, v_dtVALEXP2, v_dtFLDVALUE As Date, v_strCMDSQL As String
            Dim v_ctl As Control, v_attrFLDNAME As XmlAttribute, v_attrDATATYPE As XmlAttribute, v_objEval As New Evaluator

            ''     LoadScreen(Me.Tltxcd)
            v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, Me.Tltxcd, Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , 1, , , , , , , , , , , , , , , , Me.BusDate, , , , "N", , , "BROKERCONFIRM")
            v_xmlDocument.LoadXml(v_strTxMsg)
            v_dataElement = v_xmlDocument.CreateElement(XmlNodeType.Element, "fields", "")

            '' "02" 'AFACCTNO,C
            v_strFLDVALUE = CType(cboAFMAST.SelectedItem, ComboBoxItem).Value.Substring(0, 10)
            AddElement(v_xmlDocument, v_dataElement, "02", "C", v_strFLDVALUE)

            '' "03" 'ACCTNO,C
            v_strFLDVALUE = CType(cboAFMAST.SelectedItem, ComboBoxItem).Value.Substring(0, 10) & CType(cboSymbol.SelectedItem, ComboBoxItem).Value
            AddElement(v_xmlDocument, v_dataElement, "03", "C", v_strFLDVALUE)
            'Remember account field
            Clipboard.SetDataObject(v_strFLDVALUE)
            '' "04" 'CODEID,C
            v_strFLDVALUE = CType(cboSymbol.SelectedItem, ComboBoxItem).Value
            AddElement(v_xmlDocument, v_dataElement, "04", "C", v_strFLDVALUE)
            '' "05" 'MEMBERID,C
            v_strFLDVALUE = CType(cboBROKER.SelectedItem, ComboBoxItem).Value
            AddElement(v_xmlDocument, v_dataElement, "05", "C", v_strFLDVALUE)
            '' "06" 'BRNAME,N
            v_strFLDVALUE = CType(cboEmploy.SelectedItem, ComboBoxItem).Value
            AddElement(v_xmlDocument, v_dataElement, "06", "C", v_strFLDVALUE)
            '' "07" 'BRPHONE,N
            v_strFLDVALUE = CType(cboPhone.SelectedItem, ComboBoxItem).Value
            AddElement(v_xmlDocument, v_dataElement, "07", "C", v_strFLDVALUE)
            '' "10" 'QUANTITY,N
            v_strFLDVALUE = CDbl(txtQuantity.Text)
            AddElement(v_xmlDocument, v_dataElement, "10", "N", v_strFLDVALUE)
            '' "11" 'HOLDEDBYBROKER,N
            v_strFLDVALUE = CDbl(txtSEBLOCKEDBR.Text)
            AddElement(v_xmlDocument, v_dataElement, "11", "N", v_strFLDVALUE)
            '' "12" 'HOLDBALANCE,N
            v_strFLDVALUE = CDbl(txtQuantity.Text)
            AddElement(v_xmlDocument, v_dataElement, "12", "N", v_strFLDVALUE)
            '' "13" 'BALANCE,N
            v_strFLDVALUE = CDbl(txtSETRADE.Text)
            AddElement(v_xmlDocument, v_dataElement, "13", "N", v_strFLDVALUE)
            '' "14" 'SYMBOL,C
            v_strFLDVALUE = cboSymbol.Text
            AddElement(v_xmlDocument, v_dataElement, "14", "C", v_strFLDVALUE)
            '' "30" 'DESC,N
            v_strFLDVALUE = txtNoteSE.Text
            AddElement(v_xmlDocument, v_dataElement, "30", "C", v_strFLDVALUE)
            '' "88" 'CUSTODYCD
            v_strFLDVALUE = txtSTC.Text
            AddElement(v_xmlDocument, v_dataElement, "88", "C", v_strFLDVALUE)
            '' "90" 'CUSTNAME,C
            v_strFLDVALUE = lblName.Text
            AddElement(v_xmlDocument, v_dataElement, "90", "C", v_strFLDVALUE)


            v_strTxMsg = v_xmlDocument.InnerXml
            Return True
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    Private Function ControlValidation() As Boolean

        Select Case Tltxcd
            Case "6690"
                Return ControlValidation6690()
            Case "6691"
                Return True
            Case "6671"
                Return True
            Case "2212"
                Return ControlValidation2212()
            Case "2213"
                Return ControlValidation2213()
                'trung.luu hold/unhold cho tai khoan tu doanh
            Case "6603", "6604"
                Return ControlValidation6690()

        End Select






    End Function
    Private Function ControlValidation2213() As Boolean
        Dim a As Double
        If txtQuantity.EditValue > 0 And Double.TryParse(txtQuantity.Text, a) Then

            If a <= 0 Then
                MessageBox.Show(mv_ResourceManager.GetString("INVALIDAQTTY=0"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.txtQuantity.Focus()
                Return False

            Else
                If a > CDbl(txtSEBLOCKEDBR.Text) Then
                    MessageBox.Show(mv_ResourceManager.GetString("INVALIDQTTY<BRO"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtQuantity.Focus()
                    Return False
                End If
            End If
        Else

            MessageBox.Show(mv_ResourceManager.GetString("INVALIDQTTY"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.txtQuantity.Focus()
            Return False
        End If

        If (MessageBox.Show(mv_ResourceManager.GetString(Tltxcd) & txtQuantity.Text, gc_ApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes) Then
            Return True
        Else
            Return False
        End If


    End Function
    Private Function ControlValidation2212() As Boolean
        Dim a As Double
        If txtQuantity.EditValue > 0 And Double.TryParse(txtQuantity.Text, a) Then

            If a <= 0 Then
                MessageBox.Show(mv_ResourceManager.GetString("INVALIDAQTTY=0"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.txtQuantity.Focus()
                Return False

            Else
                If a > CDbl(txtSETRADE.Text) Then
                    MessageBox.Show(mv_ResourceManager.GetString("INVALIDQTTY<AVAI"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtQuantity.Focus()
                    Return False
                End If
            End If
        Else

            MessageBox.Show(mv_ResourceManager.GetString("INVALIDQTTY"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.txtQuantity.Focus()
            Return False
        End If

        If (MessageBox.Show(mv_ResourceManager.GetString(Tltxcd) & txtQuantity.Text, gc_ApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes) Then
            Return True
        Else
            Return False
        End If
        Return True
    End Function

    Private Function ControlValidation6690() As Boolean

        If txtAmount.EditValue <= 0 Then

            MessageBox.Show(mv_ResourceManager.GetString("INVALIDAMOUNT"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.txtAmount.Focus()
            Return False
        Else
            If txtAmount.EditValue > CDbl(txtBALANCE.Text) Then
                MessageBox.Show(mv_ResourceManager.GetString("INVALIDAMOUNT<AVAI"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.txtAmount.Focus()
                Return False
            End If
        End If
        If (MessageBox.Show(mv_ResourceManager.GetString(Tltxcd) & txtAmount.Text, gc_ApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes) Then
            Return True
        Else
            Return False
        End If
        Return True
    End Function

    Private Function ControlValidation6691() As Boolean
        Dim a As Double
        If txtAmount.EditValue > 0 And Double.TryParse(txtAmount.Text, a) Then

            If a <= 0 Then
                MessageBox.Show(mv_ResourceManager.GetString("INVALIDAMOUNT=0"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.txtAmount.Focus()
                Return False

            Else
                If a > CDbl(txtHOLDBR.Text) Then
                    MessageBox.Show(mv_ResourceManager.GetString("INVALIDAMOUNT<BRO"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtAmount.Focus()
                    Return False
                End If
            End If
        Else

            MessageBox.Show(mv_ResourceManager.GetString("INVALIDAMOUNT"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.txtAmount.Focus()
            Return False
        End If
        If (MessageBox.Show(mv_ResourceManager.GetString(Tltxcd) & txtAmount.Text, gc_ApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes) Then
            Return True
        Else
            Return False
        End If
        Return True
    End Function



    Private Sub Execute()
        Dim v_strTxMsg As String, v_xmlDocument As New XmlDocument, v_attrColl As XmlAttributeCollection
        Dim v_intNOSUBMIT As Integer, v_strNEXTTX As String = String.Empty
        Dim v_strErrorSource, v_strErrorMessage, v_strTXDESC As String, v_lngError As Long
        Dim v_ws As New BDSDeliveryManagement
        Dim v_strLate As String
        Dim v_blnSuccess As Boolean = False
        Try
            If Me.txtSTC.Text.Trim = String.Empty Then
                Exit Sub
            End If



            If Not ControlValidation() Then
                Exit Sub
            End If
            'Verify và tạo điện giao dịch
            If Not VerifyRules(v_strTxMsg) Then
                Exit Sub
            Else

                v_lngError = v_ws.Message(v_strTxMsg)

                If v_lngError <> ERR_SYSTEM_OK And v_lngError <> ERR_SA_CHECKER1_OVR And v_lngError <> ERR_SA_CHECKER2_OVR Then
                    GetErrorFromMessage(v_strTxMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                    MessageBox.Show(v_strErrorMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                Else

                    v_xmlDocument.LoadXml(v_strTxMsg)
                    If v_xmlDocument.SelectSingleNode("TransactMessage").Attributes(gc_AtributeNOSUBMIT).InnerText = "2" AndAlso _
                                  v_xmlDocument.SelectSingleNode("TransactMessage").Attributes(gc_AtributePRETRAN).InnerText = "Y" Then
                        v_lngError = v_ws.Message(v_strTxMsg)


                        Cursor.Current = Cursors.Default
                        If v_lngError <> ERR_SYSTEM_OK And v_lngError <> ERR_SA_CHECKER1_OVR And v_lngError <> ERR_SA_CHECKER2_OVR Then
                            'Thông báo lỗi
                            GetErrorFromMessage(v_strTxMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                            MessageBox.Show(v_strErrorMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        Else
                            v_xmlDocument.LoadXml(v_strTxMsg)
                            OnApprove(v_xmlDocument.SelectSingleNode("TransactMessage").Attributes(gc_AtributeTXNUM).InnerText,
                                      v_xmlDocument.SelectSingleNode("TransactMessage").Attributes(gc_AtributeTXDATE).InnerText)
                            Refresh()

                        End If



                    End If

                End If
            End If

        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub





    Private Sub OnApprove(v_strTXNUM As String, v_strTXDATE As String)
        Try

            'Lấy TXDATE và TXNUM
            Dim v_strTxMsg As String, v_intSTATUS As Integer, v_strOVRRQS, v_strCHKID, v_strOFFID, v_strDELTD As String
            Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
            ''  v_strTXNUM = Me.TxNum
            ''  v_strTXDATE = Me.TxDate
            'Lấy thông tin chi tiết v? �điện giao dịch
            Dim v_strClause, v_strObjMsg As String
            Dim v_xmlDocument As New XmlDocument, v_xmlDocumentData As New XmlDocument
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery

            'Lấy thông tin chung v? giao d�ịch. Message trả v? s�ẽ là TxMessage
            v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetMessage", , v_strTXNUM)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            Dim v_attrColl As XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            v_intSTATUS = CInt(CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), XmlAttribute).Value)
            v_strOVRRQS = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOVRRQS), XmlAttribute).Value)
            v_strCHKID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCHKID), XmlAttribute).Value)
            v_strOFFID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOFFID), XmlAttribute).Value)
            v_strDELTD = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), XmlAttribute).Value)
            If v_intSTATUS = TransactStatus.Pending And Trim(v_strDELTD) <> "Y" Then
                'Chỉ cho phép duyệt đối với những giao dịch chưa hoàn tất và 
                If (Len(Trim(Replace(v_strOVRRQS, OVRRQS_CHECKER_CONTROL, vbNullString))) > 0 And Len(v_strCHKID) = 0) _
                    Or (InStr(v_strOVRRQS, OVRRQS_CHECKER_CONTROL) > 0 And Len(v_strOFFID) = 0) Then
                    v_strObjMsg = String.Empty
                    v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , TellerType, "ApproveMessage", , v_strTXNUM)
                    v_lngError = v_ws.Message(v_strObjMsg)
                    If v_lngError <> ERR_SYSTEM_OK Then
                        'Thông báo lỗi
                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Sub
                    End If

                    Select Case Tltxcd
                        Case "6690"
                            MessageBox.Show(mv_ResourceManager.GetString("HoldCashSuccessful"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Case "6691"
                            MessageBox.Show(mv_ResourceManager.GetString("UnHoldCashSuccessful"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Case "2212"
                            MessageBox.Show(mv_ResourceManager.GetString("HoldSeSuccessful"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Case "2213"
                            MessageBox.Show(mv_ResourceManager.GetString("UnHoldSeSuccessful"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)


                    End Select
                End If
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Refresh()
        If Tltxcd = "6690" Or Tltxcd = "6691" Or Tltxcd = "6603" Or Tltxcd = "6604" Then
            txtAmount.Text = "0"
            txtNOTE.Text = ""
            lblWords.Text = ""
            GetCashInfo(CType(cboDDMAST.SelectedItem, ComboBoxItem).Value)
            GetBrokerCashInfo(CType(cboDDMAST.SelectedItem, ComboBoxItem).Value, CType(cboBROKER.SelectedItem, ComboBoxItem).Value)
            LoadGridDataEx(grdBankAccount, pnlBankAccount)
            LoadGridDataEx(grdCash, pnlCash)
            'LoadGridDataEx(grdCashHOLD, pnlCashHold, True)
            LoadGridDataEx(grdCashUNHOLD, pnlCashUnhold, False)
        Else
            GetSEInfo(CType(cboAFMAST.SelectedItem, ComboBoxItem).Value, CType(cboSymbol.SelectedItem, ComboBoxItem).Value)
            GetBrokerSEInfo(CType(cboAFMAST.SelectedItem, ComboBoxItem).Value, CType(cboSymbol.SelectedItem, ComboBoxItem).Value, CType(cboBROKER.SelectedItem, ComboBoxItem).Value)
            LoadGridDataEx(grdSEHOLD, pnlSEHOLD, False)
            LoadGridDataEx(grdSEUNHOLD, pnlUnholdSE, False)
            LoadGridDataEx(grdSE, pnlSE)
            txtQuantity.Text = "0"
            txtNoteSE.Text = ""
        End If
    End Sub


#End Region
    'trung.luu
    Private Function GetSYSVAR(ByVal v_strVARNAME As String) As String
        Try
            Dim v_nodeList As XmlNodeList
            Dim v_xmlDocument As New XmlDocument
            Dim v_strValue, v_strFLDNAME, v_strTEXT, v_strMINBRATIO, v_strMAXBRATIO As String, i, j As Integer
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strCmdSQL As String, v_strObjMsg As String

            v_strCmdSQL = "select VARVALUE from sysvar where varname = '" & v_strVARNAME & "'"

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
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "VARVALUE"
                                    Return Trim(v_strValue)
                            End Select
                        End With
                    Next
                Next
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub btnHoldCash_Click(sender As Object, e As EventArgs) Handles btnCashHold.Click
        Dim Dealingcustody, str_sysvar As String
        Dealingcustody = Strings.Left(txtSTC.Text, 4)
        str_sysvar = GetSYSVAR("DEALINGCUSTODYCD")
        If str_sysvar = Dealingcustody Then
            Tltxcd = "6603"
            ExcuteStore()
            Tltxcd = ""
        Else
            Tltxcd = "6690"
            ExcuteStore()
            Tltxcd = ""
        End If
    End Sub


    Private Sub btnCashUnhold_Click(sender As Object, e As EventArgs) Handles btnCashUnhold1.Click
        Tltxcd = "6691"
        unholdlist()
        Tltxcd = ""
    End Sub


    Private Sub unholdlist(Optional strNote As String = "")
        Dim v_intRow As Integer
        If Not grdCashHOLD Is Nothing Then
            If grdCashHOLD.MainView.RowCount > 0 Then
                If gvSearchCashholdSelection.SelectedCount > 0 Then
                    For v_intRow = 0 To gvSearchCashholdSelection.SelectedCount - 1
                        'Sau khi l
                        If Not gvSearchCashholdSelection.GetSelectedRow(v_intRow) Is Nothing Then
                            ExcuteStore(String.Format(strBank_unholdbalance_param, gf_CorrectStringField(gvSearchCashholdSelection.GetSelectedRow(v_intRow)("REQTXNUM")),
                                                                           gf_CorrectStringField(gvSearchCashholdSelection.GetSelectedRow(v_intRow)("MSGACCT")),
                                                                      CDbl(gf_CorrectStringField(gvSearchCashholdSelection.GetSelectedRow(v_intRow)("AMOUNT"))),
                                                                           "BANKUNHOLDEDBYBROKER",
                                                                           modCommond.gen_req_key(),
                                                                            strNote,
                                                                            TellerId,
                                                                                 ""), False)

                        End If
                    Next
                    MessageBox.Show(String.Format(mv_ResourceManager.GetString("UnHoldCashSuccessful"), v_intRow), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                    gvSearchCashholdSelection.ClearSelection()
                Else
                    MessageBox.Show("No rows to excute !", gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            End If


        End If
    End Sub

    Private Sub unholdSElist(Optional strNote As String = "")
        Dim v_intRow As Integer
        If Not grdSEHOLD Is Nothing Then
            If grdSEHOLD.MainView.RowCount > 0 Then
                If gvSearchSEholdSelection.SelectedCount > 0 Then
                    For v_intRow = 0 To gvSearchSEholdSelection.SelectedCount - 1
                        'Sau khi l
                        If Not gvSearchSEholdSelection.GetSelectedRow(v_intRow) Is Nothing Then
                            ExcuteStore(String.Format(str_unholdse_param, gf_CorrectStringField(gvSearchSEholdSelection.GetSelectedRow(v_intRow)("SEACCOUNT")),
                                                                        gf_CorrectStringField(gvSearchSEholdSelection.GetSelectedRow(v_intRow)("MEMBERID")),
                                                                        gf_CorrectStringField(gvSearchSEholdSelection.GetSelectedRow(v_intRow)("BRNAMEID")),
                                                                        gf_CorrectStringField(gvSearchSEholdSelection.GetSelectedRow(v_intRow)("BRPHONEID")),
                                                                        CDbl(gvSearchSEholdSelection.GetSelectedRow(v_intRow)("QTTY")),
                                                                        strNote,
                                                                        TellerId,
                                                                        ""), False)
                        End If
                    Next
                    MessageBox.Show(String.Format(mv_ResourceManager.GetString("UnHoldSeSuccessful"), v_intRow), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                    gvSearchSEholdSelection.ClearSelection()
                Else
                    MessageBox.Show("No rows to excute !", gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            End If


        End If
    End Sub

    Private Sub btnSEBlock_Click(sender As Object, e As EventArgs) Handles btnHoldSE.Click
        Tltxcd = "2212"
        ExcuteStore()
        Tltxcd = ""
    End Sub

    Private Sub btnSEUnBlock_Click(sender As Object, e As EventArgs) Handles btnUnholdSE.Click
        Tltxcd = "2213"
        ExcuteStore()
        Tltxcd = ""
    End Sub



    Private Sub tabCashMain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabCashMain.SelectedIndexChanged
        Dim tc As System.Windows.Forms.TabControl = TryCast(sender, System.Windows.Forms.TabControl)
        Dim tp As System.Windows.Forms.TabPage = tc.SelectedTab

        For Each v_ctrl In tp.Controls
            If TypeOf (v_ctrl) Is System.Windows.Forms.Panel Then
                For Each v_ctrlgrid In v_ctrl.Controls
                    If TypeOf (v_ctrlgrid) Is DevExpress.XtraGrid.GridControl Then
                        LoadGridDataEx(TryCast(v_ctrlgrid, DevExpress.XtraGrid.GridControl))
                    End If
                Next
            End If
        Next

    End Sub

    Private Sub tabSEMain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabSEMain.SelectedIndexChanged
        Dim tc As System.Windows.Forms.TabControl = TryCast(sender, System.Windows.Forms.TabControl)
        Dim tp As System.Windows.Forms.TabPage = tc.SelectedTab

        For Each v_ctrl In tp.Controls
            If TypeOf (v_ctrl) Is System.Windows.Forms.Panel Then
                For Each v_ctrlgrid In v_ctrl.Controls
                    If TypeOf (v_ctrlgrid) Is DevExpress.XtraGrid.GridControl Then
                        LoadGridDataEx(TryCast(v_ctrlgrid, DevExpress.XtraGrid.GridControl))
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub btnMili_Click(sender As Object, e As EventArgs) Handles btnMili.Click
        If txtAmount.Text.Length + 8 <= 30 Then
            txtAmount.EditValue = txtAmount.EditValue * 1000000
            txtAmount.Focus()
        End If

    End Sub

    Private Sub btnBilli_Click(sender As Object, e As EventArgs) Handles btnBilli.Click
        If txtAmount.Text.Length + 12 <= 30 Then
            txtAmount.EditValue = txtAmount.EditValue * 1000000000
            txtAmount.Focus()
        End If
    End Sub

    Private Sub txtSEBLOCKED_Leave(sender As Object, e As EventArgs)

    End Sub

    Private Sub lblQtBuyWord_Leave(sender As Object, e As EventArgs) Handles lblQtBuyWord.Leave

    End Sub

    Private Sub txtQuantity_Leave(sender As Object, e As EventArgs) Handles txtQuantity.Leave
        Dim v_dbmarketvalue As Double
        If txtQuantity.EditValue <= txtSETRADE.Text And txtAmount.EditValue <= txtBALANCE.Text Then
            btnSendMail.Enabled = False
            'cboFX.Width = 110
        Else
            btnSendMail.Enabled = True
            'cboFX.Width = 110
        End If
        If txtQuantity.EditValue > 0 Then
            If Me.UserLanguage = "VN" Then
                lblQtBuyWord.Text = TienBangChu(txtQuantity.Text)
            Else
                lblQtBuyWord.Text = NumberToText(txtQuantity.EditValue)
            End If
        End If
    End Sub


    Private Sub btnEXRATERefresh_Click(sender As Object, e As EventArgs) Handles btnEXRATERefresh.Click
        LoadGridDataEx(grdExchangeRate, pnlExchangeRate)
    End Sub

    Private Sub btnBankInquiry_Click(sender As Object, e As EventArgs) Handles btnBankInquiry.Click
        Tltxcd = "6671"
        ExcuteStore(, False)
        Tltxcd = ""
        LoadGridDataEx(grdBankAccount, pnlBankAccount)
    End Sub

    Private Sub btnSendMail_Click(sender As Object, e As EventArgs) Handles btnSendMail.Click
        Try
            'thunt-20/01/2020-gửi email thông báo không đủ số dư
            Dim v_strValue, v_strFLDNAME, v_strSEACCTNO As String, i, j As Integer
            Dim v_strCmdSQL, v_strClauseParam As String
            Dim v_lngError As String = 0
            Dim result As DialogResult

            If txtQuantity.EditValue > txtSETRADE.Text And txtAmount.EditValue <= txtBALANCE.Text Then
                result = MessageBox.Show(String.Format(mv_ResourceManager.GetString("SendMailUnHoldSecurities")), gc_ApplicationTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
            ElseIf txtAmount.EditValue > txtBALANCE.Text And txtQuantity.EditValue <= txtSETRADE.Text Then
                result = MessageBox.Show(String.Format(mv_ResourceManager.GetString("SendMailUnHoldCash")), gc_ApplicationTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
            ElseIf txtAmount.EditValue > txtBALANCE.Text And txtQuantity.EditValue > txtSETRADE.Text Then
                result = MessageBox.Show(String.Format(mv_ResourceManager.GetString("SendMailUnHoldCashSecurities")), gc_ApplicationTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
            End If

            If result = DialogResult.OK Then
                Tltxcd = "MAIL"
            ElseIf result = DialogResult.Cancel Then
                Tltxcd = ""
                Exit Sub
            End If
            ExcuteStore(String.Format(str_send_email, CType(cboDDMAST.SelectedItem, ComboBoxItem).Value,
                                                                   CType(cboAFMAST.SelectedItem, ComboBoxItem).Value & CType(cboSymbol.SelectedItem, ComboBoxItem).Value,
                                                                   CType(cboBROKER.SelectedItem, ComboBoxItem).Value,
                                                                   CDbl(txtAmount.EditValue),
                                                                   CDbl(txtQuantity.EditValue), v_lngError), False)

        Catch ex As Exception
            LogError.Write("Error source: " & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
        End Try
    End Sub

    Private Sub txtAmount_Click(sender As Object, e As EventArgs) Handles txtAmount.Click
        txtAmount.SelectAll()
    End Sub

    'Private Sub cboEmploy_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboEmploy.SelectedValueChanged
    '    If cboEmploy.Items.Count > 0 And cboEmploy.SelectedIndex <> -1 Then
    '        GetMEMBERInfo_ByEmploy(CType(cboEmploy.SelectedItem, ComboBoxItem).Value)
    '    End If
    'End Sub

    Private Sub cboEmploy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEmploy.SelectedIndexChanged
        'If cboEmploy.Items.Count > 0 And cboEmploy.SelectedIndex <> -1 Then
        '    GetMEMBERInfo_ByEmploy(CType(cboEmploy.SelectedItem, ComboBoxItem).Value)
        'End If
    End Sub


End Class