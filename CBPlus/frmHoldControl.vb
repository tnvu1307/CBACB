Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports CommonLibrary
Imports System.Collections
Imports System.Xml
Imports AppCore
Imports AppCore.modCoreLib
Imports System.Threading

Public Class frmHoldControl

#Region " Constans and Variables "

    Const c_ResourceManager = "_DIRECT.frmHoldControl-"
    Private mv_ResourceManager As Resources.ResourceManager
    Private mv_strLanguage As String
    Private mv_strModuleCode As String
    Private mv_strObjectName As String
    Private mv_strTableName As String
    Private mv_strBranchId As String
    Private mv_strTellerId As String
    Private mv_strTellerName As String
    Private mv_strIpAddress As String
    Private mv_strWsName As String
    Private mv_strTxDate As String = String.Empty
    Private mv_htBankInfo As New Hashtable()
    Private mv_thQueueProcess As Thread

    Private mv_blStop As Boolean = True
#End Region

#Region " Properties "

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

    Public Property TxDate() As String
        Get
            Return mv_strTxDate
        End Get
        Set(ByVal Value As String)
            mv_strTxDate = Value
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

#Region " Custom Events "

#Region " Delegate "

    Delegate Sub StatusUpdate(ByVal pv_blStatus As Boolean)
    Delegate Sub LogMessageUpdate(ByVal pv_strText As String)

#End Region

    Private _evtStUpdate As StatusUpdate
    Private _evtMsgUpdate As LogMessageUpdate

#End Region

#Region " Constructor "

    Public Sub New(ByVal pv_strLanguage As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mv_strLanguage = pv_strLanguage
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)

        _evtStUpdate = New StatusUpdate(AddressOf OnUpdateStatus)
        _evtMsgUpdate = New LogMessageUpdate(AddressOf OnLogMessageUpdate)
    End Sub

#End Region

#Region " Custom Event Methods "

    Private Sub OnUpdateStatus(ByVal pv_blStatus As Boolean)
        If pv_blStatus Then
            cmdAction.Text = mv_ResourceManager.GetString("CMDACTION_RUN")
            chkBIDVActive.Enabled = True
            chkBVBActive.Enabled = True
            chkDABActive.Enabled = True
            chkSTBActive.Enabled = True
            txtInterval.Enabled = True
            txtQueueSize.Enabled = True
            txtEmail.Enabled = True
        Else
            cmdAction.Text = mv_ResourceManager.GetString("CMDACTION_STOP")
            chkBIDVActive.Enabled = False
            chkBVBActive.Enabled = False
            chkDABActive.Enabled = False
            chkSTBActive.Enabled = False
            txtInterval.Enabled = False
            txtQueueSize.Enabled = False
            txtEmail.Enabled = False
        End If
    End Sub

    Private Sub OnLogMessageUpdate(ByVal pv_strText As String)
        txtLog.Text &= pv_strText
        txtLog.Focus()
        txtLog.SelectionStart = txtLog.Text.Length
    End Sub

#Region "Invoke Methods"

    Protected Sub UpdateStatus(ByVal pv_blStatus As Boolean)
        Me.Invoke(_evtStUpdate, pv_blStatus)
    End Sub

    Protected Sub LogMessage(ByVal pv_strMessage As String)
        Me.Invoke(_evtMsgUpdate, pv_strMessage)
    End Sub

#End Region

#End Region

#Region " Thread Methods "

    Protected Sub ProcessQueue()
        Dim v_strObjMsg As String, v_xmlDocument As New Xml.XmlDocument, v_xmlNode As XmlNode
        Dim v_strReference As String = String.Empty, v_strErrorSource As String = String.Empty, _
        v_strErrorMessage As String = String.Empty
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Dim v_ws As New AuthManagement
        'Thuc hien lap vo han
        LogMessage("[" & DateTime.Now.ToString("HH:mm:ss") & "][Starting queue...]" & vbCrLf)
        While Not mv_blStop
            'Call len server xu ly
            'Lay ket qua ve, build log
            'Show ra man hinh log
            'Neu co error ma co dia chi email thi ban email ve cho nha quan tri
            Try
                'v_strReference = IIf(chkBVBActive.Checked, IIf(String.IsNullOrEmpty(v_strReference), "", ",") & "BVB", "")
                'v_strReference &= IIf(chkDABActive.Checked, IIf(String.IsNullOrEmpty(v_strReference), "", ",") & "DAB", "")
                'v_strReference &= IIf(chkBIDVActive.Checked, IIf(String.IsNullOrEmpty(v_strReference), "", ",") & "BIDV", "")
                'v_strReference &= IIf(chkSTBActive.Checked, IIf(String.IsNullOrEmpty(v_strReference), "", ",") & "STB", "")
                'v_strReference &= "|" & txtQueueSize.Text.Trim().Replace(",", "")
                v_strReference = "BIDV|" & txtQueueSize.Text.Trim().Replace(",", "")
                v_strObjMsg = BuildXMLObjMsg(Me.TxDate, Me.BranchId, DateTime.Now.ToString("HH:mm:ss"), Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "BankHoldQueueExecute", , , v_strReference, WsName, IpAddress)
                v_lngError = v_ws.Message(v_strObjMsg)
                If v_lngError <> ERR_SYSTEM_OK Then
                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                    LogMessage("[" & DateTime.Now.ToString("HH:mm:ss") & "][Host Error -Message:" & v_strErrorMessage & "]" & vbCrLf)
                    'Neu co dia chi mail thi phai ban ve
                    If txtEmail.Text.Trim().Length > 0 Then

                    End If
                Else
                    'Show log tu server ra
                    v_xmlDocument.LoadXml(v_strObjMsg)
                    LogMessage(v_xmlDocument.DocumentElement.Attributes(gc_AtributeREFERENCE).Value.Replace("<![CDATA[", "").Replace("]]>", ""))
                End If
            Catch ex As Exception
                LogMessage("[" & DateTime.Now.ToString("HH:mm:ss") & "][Exception -Message:" & ex.Message & "]" & vbCrLf)
            End Try

            Thread.Sleep(Convert.ToInt32(txtInterval.Text.Replace(",", "")))
        End While
        LogMessage("[" & DateTime.Now.ToString("HH:mm:ss") & "][Stopping queue...]" & vbCrLf)
    End Sub

#End Region

#Region " User Methods "

    Private Sub OnInit()
        Dim v_strSQL As String = String.Empty, v_strObjMsg As String = String.Empty
        Dim v_ws As New BDSDeliveryManagement
        Dim v_xmlDoc As New XmlDocument()
        Dim v_xmlNodeList As XmlNodeList
        Dim v_strFLDNAME As String, v_strFLDTYPE As String, v_strValue As String
        Dim v_strBankCode As String, v_strBankName As String, v_strStatus As String

        'Load BankInfo
        v_strSQL = "SELECT * FROM V_RM_GETBANKDEF"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_RM_CRBDEFBANK, gc_ActionInquiry, v_strSQL)
        v_ws.Message(v_strObjMsg)
        If Not String.IsNullOrEmpty(v_strObjMsg) Then
            'Tao bang de chua
            Dim v_dt As New DataTable
            v_dt.Columns.Add("BANKCODE", Type.GetType("System.String"))
            v_dt.Columns.Add("BANKNAME", Type.GetType("System.String"))
            v_dt.Columns.Add("STATUS", Type.GetType("System.String"))
            Dim v_dr As DataRow

            v_xmlDoc.LoadXml(v_strObjMsg)
            v_xmlNodeList = v_xmlDoc.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_xmlNodeList.Count - 1
                v_dr = v_dt.NewRow()
                For j As Integer = 0 To v_xmlNodeList(i).ChildNodes.Count - 1
                    With v_xmlNodeList(i).ChildNodes(j)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = UCase(CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value))
                        v_strFLDTYPE = CStr(CType(.Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)
                        If Not (v_strValue Is DBNull.Value) Then
                            If Trim(v_strValue) = "" Then
                                v_strValue = Nothing
                            End If
                        End If
                        Select Case v_strFLDNAME
                            Case "BANKCODE"
                                v_dr("BANKCODE") = v_strValue
                            Case "BANKNAME"
                                v_dr("BANKNAME") = v_strValue
                            Case "STATUS"
                                v_dr("STATUS") = v_strValue
                        End Select
                    End With
                Next
                v_dt.Rows.Add(v_dr)
                mv_htBankInfo.Add(v_dr("BANKCODE").ToString(), v_dr)
            Next
        End If

        'Cap nhat len label
        lblBIDVStatus.Text = IIf(CType(mv_htBankInfo("BIDV"), DataRow)("STATUS").ToString() = "A", _
                                 "Online", "Down")
        lblBIDVStatus.ForeColor = IIf(CType(mv_htBankInfo("BIDV"), DataRow)("STATUS").ToString() = "A", _
                                      System.Drawing.Color.Blue, System.Drawing.Color.Red)
        chkBIDVActive.Visible = IIf(CType(mv_htBankInfo("BIDV"), DataRow)("STATUS").ToString() = "A", _
                                 True, False)
        chkBIDVActive.Checked = IIf(CType(mv_htBankInfo("BIDV"), DataRow)("STATUS").ToString() = "A", _
                                 True, False)

        'lblBVBStatus.Text = IIf(CType(mv_htBankInfo("BVB"), DataRow)("STATUS").ToString() = "A", _
        '                         "Online", "Down")
        'lblBVBStatus.ForeColor = IIf(CType(mv_htBankInfo("BVB"), DataRow)("STATUS").ToString() = "A", _
        '                              System.Drawing.Color.Blue, System.Drawing.Color.Red)
        'chkBVBActive.Visible = IIf(CType(mv_htBankInfo("BVB"), DataRow)("STATUS").ToString() = "A", _
        '                         True, False)
        'chkBVBActive.Checked = IIf(CType(mv_htBankInfo("BVB"), DataRow)("STATUS").ToString() = "A", _
        '                                 True, False)

        'lblDABStatus.Text = IIf(CType(mv_htBankInfo("DAB"), DataRow)("STATUS").ToString() = "A", _
        '                         "Online", "Down")
        'lblDABStatus.ForeColor = IIf(CType(mv_htBankInfo("DAB"), DataRow)("STATUS").ToString() = "A", _
        '                              System.Drawing.Color.Blue, System.Drawing.Color.Red)
        'chkDABActive.Visible = IIf(CType(mv_htBankInfo("DAB"), DataRow)("STATUS").ToString() = "A", _
        '                         True, False)
        'chkDABActive.Checked = IIf(CType(mv_htBankInfo("DAB"), DataRow)("STATUS").ToString() = "A", _
        '                         True, False)

        'lblSTBStatus.Text = IIf(CType(mv_htBankInfo("STB"), DataRow)("STATUS").ToString() = "A", _
        '                         "Online", "Down")
        'lblSTBStatus.ForeColor = IIf(CType(mv_htBankInfo("STB"), DataRow)("STATUS").ToString() = "A", _
        '                              System.Drawing.Color.Blue, System.Drawing.Color.Red)
        'chkSTBActive.Visible = IIf(CType(mv_htBankInfo("STB"), DataRow)("STATUS").ToString() = "A", _
        '                         True, False)
        'chkSTBActive.Checked = IIf(CType(mv_htBankInfo("STB"), DataRow)("STATUS").ToString() = "A", _
        '                         True, False)
        lblBVBStatus.Visible = False
        lblBVB.Visible = False
        chkBVBActive.Visible = False
        lblDABStatus.Visible = False
        lblDAB.Visible = False
        chkDABActive.Visible = False
        lblSTBStatus.Visible = False
        lblSTB.Visible = False
        chkSTBActive.Visible = False
        'Load tu config
        txtInterval.Text = GetConfigValue("HoldQueueInterval", "5000") 'Mac dinh 5 giay 1 lan
        txtQueueSize.Text = GetConfigValue("HoldQueueSize", "10") 'Mac dinh xu ly 25 dong 1 lan
        txtEmail.Text = GetConfigValue("MasterEmail", "") 'Lay email cua quan tri
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
            End If
        Next
        Me.Text = mv_ResourceManager.GetString(Me.Name)
    End Sub

#End Region

#Region " Form Events "

    Private Sub frmHoldControl_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        mv_blStop = True

        If Not mv_thQueueProcess Is Nothing Then
            If mv_thQueueProcess.IsAlive Then
                mv_thQueueProcess.Abort()
                mv_thQueueProcess = Nothing
            End If
        End If
    End Sub

    Private Sub frmHoldControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OnInit()
    End Sub

    Private Sub cmdAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAction.Click
        If mv_blStop Then
            'Kill thread cu di
            If Not mv_thQueueProcess Is Nothing Then
                If mv_thQueueProcess.IsAlive Then
                    mv_thQueueProcess.Abort()
                    mv_thQueueProcess = Nothing
                End If
            End If

            'Khoi dong thread moi
            mv_blStop = False
            mv_thQueueProcess = New Thread(AddressOf ProcessQueue)
            mv_thQueueProcess.IsBackground = True
            mv_thQueueProcess.Start()
            OnUpdateStatus(mv_blStop)
            LogMessage("[" & DateTime.Now.ToString("HH:mm:ss") & "][Begin queue...]" & vbCrLf)
        Else
            mv_blStop = True
            cmdAction.Enabled = False
            Thread.Sleep(txtInterval.Text.Replace(",", ""))

            If Not mv_thQueueProcess Is Nothing Then
                If mv_thQueueProcess.IsAlive Then
                    mv_thQueueProcess.Abort()
                    mv_thQueueProcess = Nothing
                End If
            End If

            OnUpdateStatus(mv_blStop)
            cmdAction.Enabled = True
            LogMessage("[" & DateTime.Now.ToString("HH:mm:ss") & "][Queue stopped!]" & vbCrLf)
        End If
    End Sub
    Private Sub GetBankTransList()
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
        Try
            Dim v_strObjMsg As String, pv_xmlDocument As New Xml.XmlDocument
            Dim v_ws As New AuthManagement
            v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "BankGetTransList", , , "GetDate", WsName, IpAddress)
            v_lngError = v_ws.Message(v_strObjMsg)
            pv_xmlDocument.LoadXml(v_strObjMsg)
            If v_lngError <> ERR_SYSTEM_OK Then
                'Thong bao loi
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                Cursor.Current = Cursors.Default
                MessageBox.Show(v_strErrorMessage)
                Exit Sub
            Else
                MessageBox.Show(mv_ResourceManager.GetString("msg_sucess"))
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
    Private Sub cmdBANKREQUEST_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBANKREQUEST.Click
        GetBankTransList()
    End Sub

#End Region

End Class