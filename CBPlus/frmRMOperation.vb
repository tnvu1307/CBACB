Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports CommonLibrary
Imports System.Collections
Imports System.IO
Public Class frmRMOperation
    Inherits System.Windows.Forms.Form

#Region " Declare constant and variables "
    Const c_ResourceManager = "_DIRECT.frmRMOperation-"

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


    Dim mv_blnIsRunningMapOrderBook As Boolean = False
    Dim mv_blnIsRunningMapTradeBook As Boolean = False
    Dim mv_blnIsRunningSendSMS As Boolean = False
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
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)
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
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents txtFeedBack As System.Windows.Forms.TextBox
    Friend WithEvents pnInfo As System.Windows.Forms.Panel
    Friend WithEvents chklistTasks As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnCache As System.Windows.Forms.Button
    Friend WithEvents btnTicker As System.Windows.Forms.Button
    Friend WithEvents txtInterval As System.Windows.Forms.TextBox
    Friend WithEvents tmAutoProcess As System.Windows.Forms.Timer
    Friend WithEvents chkAuto As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnSubmit = New System.Windows.Forms.Button
        Me.txtFeedBack = New System.Windows.Forms.TextBox
        Me.btnCache = New System.Windows.Forms.Button
        Me.btnTicker = New System.Windows.Forms.Button
        Me.pnInfo = New System.Windows.Forms.Panel
        Me.chklistTasks = New System.Windows.Forms.CheckedListBox
        Me.tmAutoProcess = New System.Windows.Forms.Timer(Me.components)
        Me.chkAuto = New System.Windows.Forms.CheckBox
        Me.txtInterval = New System.Windows.Forms.TextBox
        Me.pnInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(511, 267)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(88, 23)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "&Close"
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(421, 267)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(88, 23)
        Me.btnSubmit.TabIndex = 2
        Me.btnSubmit.Text = "&Submit"
        '
        'txtFeedBack
        '
        Me.txtFeedBack.Location = New System.Drawing.Point(8, 167)
        Me.txtFeedBack.Multiline = True
        Me.txtFeedBack.Name = "txtFeedBack"
        Me.txtFeedBack.Size = New System.Drawing.Size(592, 94)
        Me.txtFeedBack.TabIndex = 5
        '
        'btnCache
        '
        Me.btnCache.Location = New System.Drawing.Point(103, 267)
        Me.btnCache.Name = "btnCache"
        Me.btnCache.Size = New System.Drawing.Size(88, 23)
        Me.btnCache.TabIndex = 2
        Me.btnCache.Text = "Reset &cache"
        '
        'btnTicker
        '
        Me.btnTicker.Location = New System.Drawing.Point(7, 267)
        Me.btnTicker.Name = "btnTicker"
        Me.btnTicker.Size = New System.Drawing.Size(88, 23)
        Me.btnTicker.TabIndex = 2
        Me.btnTicker.Text = "Reset &ticker"
        '
        'pnInfo
        '
        Me.pnInfo.Controls.Add(Me.chklistTasks)
        Me.pnInfo.Location = New System.Drawing.Point(8, 8)
        Me.pnInfo.Name = "pnInfo"
        Me.pnInfo.Size = New System.Drawing.Size(592, 153)
        Me.pnInfo.TabIndex = 6
        '
        'chklistTasks
        '
        Me.chklistTasks.Items.AddRange(New Object() {"RMEXCA3384: Transfer buy right amount to Bank", "RMEXCA3386: Transfer cancel buy right amount to Bank", "RMEXCA3350: Transfer cash dividen amount to Bank", "RMEXCA3350DF: Transfer cash dividen duty fee amount to Bank", "RMEX8879: Transfer retail sell amount to Bank", "RMEX8879DF: Transfer retail sell duty fee amount to Bank"})
        Me.chklistTasks.Location = New System.Drawing.Point(8, 8)
        Me.chklistTasks.Name = "chklistTasks"
        Me.chklistTasks.Size = New System.Drawing.Size(576, 109)
        Me.chklistTasks.TabIndex = 0
        '
        'tmAutoProcess
        '
        '
        'chkAuto
        '
        Me.chkAuto.Location = New System.Drawing.Point(199, 267)
        Me.chkAuto.Name = "chkAuto"
        Me.chkAuto.Size = New System.Drawing.Size(112, 24)
        Me.chkAuto.TabIndex = 7
        Me.chkAuto.Text = "Auto-process (s)"
        '
        'txtInterval
        '
        Me.txtInterval.Location = New System.Drawing.Point(311, 267)
        Me.txtInterval.Name = "txtInterval"
        Me.txtInterval.Size = New System.Drawing.Size(40, 20)
        Me.txtInterval.TabIndex = 8
        Me.txtInterval.Text = "180"
        '
        'frmRMOperation
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(608, 300)
        Me.Controls.Add(Me.txtInterval)
        Me.Controls.Add(Me.chkAuto)
        Me.Controls.Add(Me.pnInfo)
        Me.Controls.Add(Me.txtFeedBack)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.btnCache)
        Me.Controls.Add(Me.btnTicker)
        Me.Name = "frmRMOperation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "frmOperation"
        Me.Text = "RM Operation panel"
        Me.pnInfo.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region " Form events "
    Private Sub btnSyn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SynchronousTransaction()
    End Sub
    Private Sub btnResetCache_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        OnResetCache()
    End Sub

    'Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
    '    Dim v_ws As New StockTicker.StockTicker, v_strRETURN, v_strValue As String, i, j As Integer
    '    Try
    '        Me.txtFeedBack.Text = String.Empty
    '        Dim v_strCMDLINE As String
    '        For i = 0 To Me.chklistTasks.Items.Count - 1
    '            If chklistTasks.GetItemChecked(i) = True Then
    '                v_strCMDLINE = CType(chklistTasks.Items(i), String)
    '                j = InStr(v_strCMDLINE, ":")
    '                v_strValue = Mid(v_strCMDLINE, 1, j - 1)
    '                Select Case v_strValue
    '                    Case "AUTOGV"
    '                        AutoRunGeneralView()
    '                    Case "SYNCTRANS"
    '                        SynchronousTransaction()
    '                    Case "START_VSMKTINFO"
    '                        v_strRETURN = v_ws.StartSTCAdapter("VS", "MARKETINFO")
    '                    Case "START_VNMKTINFO"
    '                        v_strRETURN = v_ws.StartSTCAdapter("VN", "MARKETINFO")
    '                    Case "START_VSTRADE"
    '                        v_strRETURN = v_ws.StartSTCAdapter("VS", "TRADINGDATA")
    '                    Case "START_VNTRADE"
    '                        v_strRETURN = v_ws.StartSTCAdapter("VN", "TRADINGDATA")
    '                    Case "GET_VSMARKETWATCH"
    '                        v_strRETURN = v_ws.StartSTCAdapter("VS", "MARKETWATCH")
    '                    Case "GET_VNMARKETWATCH"
    '                        v_strRETURN = v_ws.StartSTCAdapter("VN", "MARKETWATCH")
    '                    Case "START_MAP_STCORDERBOOK"
    '                        'Get current exchange order book
    '                        v_strRETURN = v_ws.GetOrderBook
    '                        MapExchangeOrderBook(v_strRETURN)
    '                    Case "START_MAP_STCTRADEBOOK"
    '                        v_strRETURN = v_ws.GetTradeBook
    '                        MapExchangeTradeBook(v_strRETURN)
    '                End Select
    '                Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": " + v_strValue + "-DONE"
    '            End If
    '        Next
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    Finally
    '        v_ws = Nothing
    '    End Try
    'End Sub
    Private Sub OnProcess()

        'Dim v_ws As New StockTickerServices.StockTickerClient, v_strRETURN, v_strValue As String, i, j As Integer
        Dim v_strRETURN, v_strValue As String, i, j As Integer
        Try
            Me.txtFeedBack.Text = String.Empty
            Dim v_strCMDLINE As String
            For i = 0 To Me.chklistTasks.Items.Count - 1
                If chklistTasks.GetItemChecked(i) = True Then
                    v_strCMDLINE = CType(chklistTasks.Items(i), String)
                    j = InStr(v_strCMDLINE, ":")
                    v_strValue = Mid(v_strCMDLINE, 1, j - 1)
                    Select Case v_strValue
                        Case "AUTOGV"
                            AutoRunGeneralView()
                        Case "SENDCMP"
                            SendOrderToCompany()
                        Case "SENDHAGTC"
                            SendGTCOrderToCompany("GTC-HA")
                        Case "SENDHOGTC"
                            SendGTCOrderToCompany("GTC-HO")
                        Case "SENDHASL"
                            SendGTCOrderToCompany("SL-HA")
                        Case "SENDHOSL"
                            SendGTCOrderToCompany("SL-HO")
                        Case "SYNCTRANS"
                            SynchronousTransaction()
                        Case "START_VSMKTINFO"
                            ' v_strRETURN = v_ws.StartSTCAdapter("VS", "MARKETINFO")
                        Case "START_VNMKTINFO"
                            ' v_strRETURN = v_ws.StartSTCAdapter("VN", "MARKETINFO")
                        Case "START_VSTRADE"
                            'v_strRETURN = v_ws.StartSTCAdapter("VS", "TRADINGDATA")
                        Case "START_VNTRADE"
                            ' v_strRETURN = v_ws.StartSTCAdapter("VN", "TRADINGDATA")
                        Case "GET_VSMARKETWATCH"
                            ' v_strRETURN = v_ws.StartSTCAdapter("VS", "MARKETWATCH")
                        Case "GET_VNMARKETWATCH"
                            '  v_strRETURN = v_ws.StartSTCAdapter("VN", "MARKETWATCH")
                        Case "START_MAP_STCORDERBOOK"
                            'Get current exchange order book
                            'v_strRETURN = v_ws.GetOrderBook()
                            'MapExchangeOrderBook(v_strRETURN)
                            ThreadMapOrderBook()
                        Case "START_MAP_STCTRADEBOOK"
                            'v_strRETURN = v_ws.GetTradeBook()
                            'MapExchangeTradeBook(v_strRETURN)
                            ThreadMapTradeBook()
                        Case "SMS"
                            ThreadSendSMS()
                            'SendSMS()
                        Case "BAMTTRF"
                            BuyAmountTransferProcess()
                        Case "BFEETRF"
                            BuyFeeTransferProcess()
                        Case "RMEXCA3384"
                            ExecuteCA3384Process()
                        Case "RMEXCA3386"
                            ExecuteCA3386Process()
                        Case "RMEXCA3350"
                            ExecuteCA3350Process()
                        Case "RMEXCA3350DF"
                            ExecuteCA3350DFProcess()
                        Case "RMEX8879"
                            ExecuteRM8879Process()
                        Case "RMEX8879DF"
                            ExecuteRM8879DFProcess()
                        Case "RMEXTRFQUEUE"
                            ExecuteTRFBatchProcess()
                        Case "RMEXTRFSTS"
                            ExecuteGetBatchStsProcess()
                    End Select
                    Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": " + v_strValue + "-DONE"
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            'v_ws = Nothing
        End Try
    End Sub

    ' async method --nghiemnt
    Delegate Sub UpdateUsingCallback(ByVal ar As IAsyncResult)

    Private Sub ThreadMapOrderBook()

    End Sub

    Private Sub ThreadMapTradeBook()

    End Sub

    Private Sub ThreadSendSMS()

    End Sub

    Private Sub wsThreadMapOrderBook(ByVal ar As IAsyncResult)
        If txtFeedBack.InvokeRequired Then
            Dim callback As UpdateUsingCallback = New UpdateUsingCallback(AddressOf wsThreadMapOrderBook)
            Me.Invoke(callback, New Object() {ar})
        Else
            Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + "[MapOrderBook] " + Now.ToLongTimeString + ": Done"
            'Swith off flag: allow to request again
            mv_blnIsRunningMapOrderBook = False
        End If
    End Sub

    Private Sub wsThreadMapTradeBook(ByVal ar As IAsyncResult)
        If txtFeedBack.InvokeRequired Then
            Dim callback As UpdateUsingCallback = New UpdateUsingCallback(AddressOf wsThreadMapTradeBook)
            Me.Invoke(callback, New Object() {ar})
        Else
            Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + "[MapTradeBook] " + Now.ToLongTimeString + ": Done"
            'Swith off flag: allow to request again
            mv_blnIsRunningMapTradeBook = False
        End If
    End Sub

    Private Sub wsThreadSendSMS(ByVal ar As IAsyncResult)
        If txtFeedBack.InvokeRequired Then
            Dim callback As UpdateUsingCallback = New UpdateUsingCallback(AddressOf wsThreadSendSMS)
            Me.Invoke(callback, New Object() {ar})
        Else
            Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + "[SendSMS] " + Now.ToLongTimeString + ": Done"
            'Swith off flag: allow to request again
            mv_blnIsRunningSendSMS = False
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Onclose()
    End Sub
#End Region

#Region " Private function "

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

        If TypeOf (v_ctrl) Is System.Windows.Forms.CheckedListBox Then
            Me.chklistTasks.Items.Clear()
            Me.chklistTasks.Items.AddRange(New Object() { _
            mv_ResourceManager.GetString("RMEXCA3384"), _
            mv_ResourceManager.GetString("RMEXCA3386"), _
            mv_ResourceManager.GetString("RMEXCA3350"), _
            mv_ResourceManager.GetString("RMEXCA3350DF"), _
            mv_ResourceManager.GetString("RMEX8879"), _
            mv_ResourceManager.GetString("RMEX8879DF"), _
            mv_ResourceManager.GetString("RMEXTRFQUEUE"), _
            mv_ResourceManager.GetString("RMEXTRFSTS")})
        End If
    End Sub

    Private Sub Onclose()
        Me.Close()
        Me.tmAutoProcess.Enabled = False
    End Sub

    Private Sub SendOrderToCompany()
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
        Try
            Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
            'TruongLD Comment when convert
            'Dim v_ws As New AuthWS.AuthService
            'TruongLD Add when convert
            Dim v_ws As New AuthManagement
            'End TruongLD
            v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "SendOrderToCompany", , , "GetDate")
            v_lngError = v_ws.Message(v_strObjMsg)
            pv_xmlDocument.LoadXml(v_strObjMsg)
            If v_lngError <> ERR_SYSTEM_OK Then
                'Thông báo l?i
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                Cursor.Current = Cursors.Default
                Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": " + v_strErrorMessage
                Exit Sub
            Else
                Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": Send order from FO to company successfully"
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub SendGTCOrderToCompany(ByVal v_strFunType As String)
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
        Try
            Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
            'TruongLD Comment when convert
            'Dim v_ws As New AuthWS.AuthService
            'TruongLD Add when convert
            Dim v_ws As New AuthManagement
            'End TruongLD
            v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "SendGTCOrderToCompany", , , "GetDate", v_strFunType)
            v_lngError = v_ws.Message(v_strObjMsg)
            pv_xmlDocument.LoadXml(v_strObjMsg)
            If v_lngError <> ERR_SYSTEM_OK Then
                'Thông báo l?i
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                Cursor.Current = Cursors.Default
                Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": " + v_strErrorMessage
                Exit Sub
            Else
                Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": Send order from FO to company successfully"
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub OnResetCache()
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
        Try
            Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
            'TruongLD Comment when convert
            'Dim v_ws As New AuthWS.AuthService
            'TruongLD Add when convert
            Dim v_ws As New AuthManagement
            'End TruongLD
            v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "ResetCacheProcessing", , , "GetDate")
            v_lngError = v_ws.Message(v_strObjMsg)
            pv_xmlDocument.LoadXml(v_strObjMsg)
            If v_lngError <> ERR_SYSTEM_OK Then
                'Thông báo l?i
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                Cursor.Current = Cursors.Default
                Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": " + v_strErrorMessage
                Exit Sub
            Else
                Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": OnResetCache successfully" + v_strErrorMessage
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                     & "Error code: System error!" & vbNewLine _
                                     & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub SynchronousTransaction()
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
        Try
            Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
            'TruongLD Comment when convert
            'Dim v_ws As New AuthWS.AuthService
            'TruongLD Add when convert
            Dim v_ws As New AuthManagement
            'End TruongLD
            v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "AsynchronousProcessing", , , "GetDate")
            v_lngError = v_ws.Message(v_strObjMsg)
            pv_xmlDocument.LoadXml(v_strObjMsg)
            If v_lngError <> ERR_SYSTEM_OK Then
                'Thông báo l?i
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                Cursor.Current = Cursors.Default
                Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": " + v_strErrorMessage
                Exit Sub
            Else
                Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": Change status successfully"
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub AutoRunGeneralView()
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
        Try
            Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
            'TruongLD Comment when convert
            'Dim v_ws As New AuthWS.AuthService
            'TruongLD Add when convert
            Dim v_ws As New AuthManagement
            'End TruongLD
            v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "AutoRunGeneralView", , , "GetDate")
            v_lngError = v_ws.Message(v_strObjMsg)
            pv_xmlDocument.LoadXml(v_strObjMsg)
            If v_lngError <> ERR_SYSTEM_OK Then
                'Thông báo l?i
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                Cursor.Current = Cursors.Default
                Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": " + v_strErrorMessage
                Exit Sub
            Else
                Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": Change status successfully"
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub MapExchangeStockTicker(ByVal v_strStockTicker As String)
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
        Try
            'Create message
            Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
            'TruongLD Comment when convert
            'Dim v_ws As New AuthWS.AuthService
            'TruongLD Add when convert
            Dim v_ws As New AuthManagement
            'End TruongLD
            v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "MapExchangeStockTicker", , , "GetDate")
            pv_xmlDocument.LoadXml(v_strObjMsg)

            'Map exchange order book
            Dim nodeItem As Xml.XmlNode, pv_xmlSTCBook As New Xml.XmlDocument
            pv_xmlSTCBook.LoadXml(v_strStockTicker)
            nodeItem = pv_xmlDocument.ImportNode(pv_xmlSTCBook.SelectSingleNode("/StockTicker"), True)
            pv_xmlDocument.DocumentElement.AppendChild(nodeItem)

            'Send message to HOST to map
            v_strObjMsg = pv_xmlDocument.InnerXml
            v_lngError = v_ws.Message(v_strObjMsg)
            pv_xmlDocument.LoadXml(v_strObjMsg)
            If v_lngError <> ERR_SYSTEM_OK Then
                'Thông báo l?i
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                Cursor.Current = Cursors.Default
                Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": " + v_strErrorMessage
                Exit Sub
            Else
                Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": Map stock ticker successfully"
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                     & "Error code: System error!" & vbNewLine _
                                     & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub MapExchangeOrderBook(ByVal v_strSTCOrderBook As String)
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
        Try
            'Create message
            Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
            'TruongLD Comment when convert
            'Dim v_ws As New AuthWS.AuthService
            'TruongLD Add when convert
            Dim v_ws As New AuthManagement
            'End TruongLD
            v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "MapExchangeOrderBook", , , "GetDate")
            pv_xmlDocument.LoadXml(v_strObjMsg)

            'Map exchange order book
            Dim nodeItem As Xml.XmlNode, pv_xmlSTCBook As New Xml.XmlDocument
            pv_xmlSTCBook.LoadXml(v_strSTCOrderBook)
            nodeItem = pv_xmlDocument.ImportNode(pv_xmlSTCBook.SelectSingleNode("/OrderBook"), True)
            pv_xmlDocument.DocumentElement.AppendChild(nodeItem)

            'Send message to HOST to map
            v_strObjMsg = pv_xmlDocument.InnerXml
            v_lngError = v_ws.Message(v_strObjMsg)
            pv_xmlDocument.LoadXml(v_strObjMsg)
            If v_lngError <> ERR_SYSTEM_OK Then
                'Thông báo l?i
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                Cursor.Current = Cursors.Default
                Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": " + v_strErrorMessage
                Exit Sub
            Else
                Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": Map exchange order book successfully"
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                     & "Error code: System error!" & vbNewLine _
                                     & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub MapExchangeTradeBook(ByVal v_strSTCTradeBook As String)
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
        Try
            'Create message
            Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
            'TruongLD Comment when convert
            'Dim v_ws As New AuthWS.AuthService
            'TruongLD Add when convert
            Dim v_ws As New AuthManagement
            'End TruongLD
            v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "MapExchangeTradeBook", , , "GetDate")
            pv_xmlDocument.LoadXml(v_strObjMsg)

            'Map exchange order book
            Dim nodeItem As Xml.XmlNode, pv_xmlSTCBook As New Xml.XmlDocument
            pv_xmlSTCBook.LoadXml(v_strSTCTradeBook)
            nodeItem = pv_xmlDocument.ImportNode(pv_xmlSTCBook.SelectSingleNode("/TradeBook"), True)
            pv_xmlDocument.DocumentElement.AppendChild(nodeItem)

            'Send message to HOST to map
            v_strObjMsg = pv_xmlDocument.InnerXml
            v_lngError = v_ws.Message(v_strObjMsg)
            pv_xmlDocument.LoadXml(v_strObjMsg)
            If v_lngError <> ERR_SYSTEM_OK Then
                'Thông báo l?i
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                Cursor.Current = Cursors.Default
                Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": " + v_strErrorMessage
                Exit Sub
            Else
                Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": Map exchange trade book successfully"
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                     & "Error code: System error!" & vbNewLine _
                                     & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub BuyAmountTransferProcess()
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
        Try
            Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
            Dim v_ws As New AuthManagement
            v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "BuyAmountTransfer", , , "GetDate")
            v_lngError = v_ws.Message(v_strObjMsg)
            pv_xmlDocument.LoadXml(v_strObjMsg)
            If v_lngError <> ERR_SYSTEM_OK Then
                'Thông báo l?i
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                Cursor.Current = Cursors.Default
                Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": " + v_strErrorMessage
                Exit Sub
            Else
                Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": Buy Amount Transfer Successfully!"
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub BuyFeeTransferProcess()
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
        Try
            Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
            Dim v_ws As New AuthManagement
            v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "BuyFeeTransfer", , , "GetDate")
            v_lngError = v_ws.Message(v_strObjMsg)
            pv_xmlDocument.LoadXml(v_strObjMsg)
            If v_lngError <> ERR_SYSTEM_OK Then
                'Thông báo l?i
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                Cursor.Current = Cursors.Default
                Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": " + v_strErrorMessage
                Exit Sub
            Else
                Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": Buy fee Transfer Successfully!"
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub ExecuteCA3384Process()
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
        Try
            Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
            Dim v_ws As New AuthManagement
            v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "ExecuteCA3384", , , "GetDate")
            v_lngError = v_ws.Message(v_strObjMsg)
            pv_xmlDocument.LoadXml(v_strObjMsg)
            If v_lngError <> ERR_SYSTEM_OK Then
                'Thông báo l?i
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                Cursor.Current = Cursors.Default
                Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": " + v_strErrorMessage
                Exit Sub
            Else
                Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": Execute CA 3384 Successfully!"
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub ExecuteCA3386Process()
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
        Try
            Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
            Dim v_ws As New AuthManagement
            v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "ExecuteCA3386", , , "GetDate")
            v_lngError = v_ws.Message(v_strObjMsg)
            pv_xmlDocument.LoadXml(v_strObjMsg)
            If v_lngError <> ERR_SYSTEM_OK Then
                'Thông báo l?i
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                Cursor.Current = Cursors.Default
                Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": " + v_strErrorMessage
                Exit Sub
            Else
                Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": Execute CA 3386 Successfully!"
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub ExecuteCA3350Process()
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
        Try
            Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
            Dim v_ws As New AuthManagement
            v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "ExecuteCA3350", , , "GetDate")
            v_lngError = v_ws.Message(v_strObjMsg)
            pv_xmlDocument.LoadXml(v_strObjMsg)
            If v_lngError <> ERR_SYSTEM_OK Then
                'Thông báo l?i
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                Cursor.Current = Cursors.Default
                Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": " + v_strErrorMessage
                Exit Sub
            Else
                Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": Execute CA 3350 Successfully!"
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub ExecuteCA3350DFProcess()
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
        Try
            Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
            Dim v_ws As New AuthManagement
            v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "ExecuteCA3350DF", , , "GetDate")
            v_lngError = v_ws.Message(v_strObjMsg)
            pv_xmlDocument.LoadXml(v_strObjMsg)
            If v_lngError <> ERR_SYSTEM_OK Then
                'Thông báo l?i
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                Cursor.Current = Cursors.Default
                Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": " + v_strErrorMessage
                Exit Sub
            Else
                Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": Execute CA 3350 duty fee Successfully!"
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub ExecuteRM8879Process()
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
        Try
            Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
            Dim v_ws As New AuthManagement
            v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "ExecuteRM8879", , , "GetDate")
            v_lngError = v_ws.Message(v_strObjMsg)
            pv_xmlDocument.LoadXml(v_strObjMsg)
            If v_lngError <> ERR_SYSTEM_OK Then
                'Thông báo l?i
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                Cursor.Current = Cursors.Default
                Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": " + v_strErrorMessage
                Exit Sub
            Else
                Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": Execute RM8879 Successfully!"
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub ExecuteRM8879DFProcess()
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
        Try
            Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
            Dim v_ws As New AuthManagement
            v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "ExecuteRM8879DF", , , "GetDate")
            v_lngError = v_ws.Message(v_strObjMsg)
            pv_xmlDocument.LoadXml(v_strObjMsg)
            If v_lngError <> ERR_SYSTEM_OK Then
                'Thông báo l?i
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                Cursor.Current = Cursors.Default
                Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": " + v_strErrorMessage
                Exit Sub
            Else
                Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": Execute RM8879 Successfully!"
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub ExecuteTRFBatchProcess()
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
        Try
            Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
            Dim v_ws As New AuthManagement
            v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "BankTrfReport", , , "GetDate", WsName, IpAddress)
            v_lngError = v_ws.Message(v_strObjMsg)
            pv_xmlDocument.LoadXml(v_strObjMsg)
            If v_lngError <> ERR_SYSTEM_OK Then
                'Thông báo l?i
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                Cursor.Current = Cursors.Default
                Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": " + v_strErrorMessage
                Exit Sub
            Else
                Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": Execute transfer batch Successfully!"
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub ExecuteGetBatchStsProcess()
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
        Try
            Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
            Dim v_ws As New AuthManagement
            v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "BankGetReportSts", , , "GetDate", WsName, IpAddress)
            v_lngError = v_ws.Message(v_strObjMsg)
            pv_xmlDocument.LoadXml(v_strObjMsg)
            If v_lngError <> ERR_SYSTEM_OK Then
                'Thông báo l?i
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                Cursor.Current = Cursors.Default
                Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": " + v_strErrorMessage
                Exit Sub
            Else
                Me.txtFeedBack.Text = Me.txtFeedBack.Text + ControlChars.CrLf + Now.ToLongTimeString + ": Execute transfer batch Successfully!"
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub SendSMS()

    End Sub

#End Region

    Private Sub btnCache_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCache.Click
        OnResetCache()
    End Sub

    Private Sub btnTicker_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTicker.Click

    End Sub

    Private Sub tmAutoProcess_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmAutoProcess.Tick
        If Me.chkAuto.Checked Then
            OnProcess()
        End If
    End Sub
  
    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        tmAutoProcess.Enabled = False
        If Me.chkAuto.Checked Then
            Dim v_strINTERVAL As String = Me.txtInterval.Text
            If IsNumeric(v_strINTERVAL) Then
                Me.tmAutoProcess.Interval = CDbl(v_strINTERVAL) * 1000
            Else
                Me.tmAutoProcess.Interval = 30000
            End If
            tmAutoProcess.Enabled = True
            OnProcess()
        Else
            OnProcess()
            tmAutoProcess.Enabled = False
        End If
    End Sub

    Private Sub chkAuto_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAuto.CheckedChanged
        If Me.txtInterval.Text > 0 Then
            tmAutoProcess.Interval = CDbl(Me.txtInterval.Text) * 1000
            tmAutoProcess.Enabled = True
        End If
    End Sub

    Private Sub frmOperation_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        tmAutoProcess.Enabled = False
    End Sub

    Private Sub chklistTasks_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chklistTasks.SelectedIndexChanged

    End Sub
End Class
