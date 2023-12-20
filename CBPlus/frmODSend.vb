Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports CommonLibrary
Imports System.Collections
Imports AppCore
Imports AppCore.modCoreLib


Public Class frmODSend
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
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents pnOrder As System.Windows.Forms.Panel
    Friend WithEvents lblExecType As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSendAll As System.Windows.Forms.Button
    Friend WithEvents pnODSendInfo As System.Windows.Forms.Panel
    Friend WithEvents cboTradePlace As AppCore.ComboBoxEx
    Friend WithEvents cboODKIND As AppCore.ComboBoxEx
    Friend WithEvents lblODKIND As System.Windows.Forms.Label
    Friend WithEvents lblPRICETYPE As System.Windows.Forms.Label
    Friend WithEvents cboBranch As AppCore.ComboBoxEx
    Friend WithEvents lblBranch As System.Windows.Forms.Label
    Friend WithEvents cboPRICETYPE As AppCore.ComboBoxEx
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmODSend))
        Me.pnlTitle = New System.Windows.Forms.Panel
        Me.pnOrder = New System.Windows.Forms.Panel
        Me.cboBranch = New AppCore.ComboBoxEx
        Me.lblBranch = New System.Windows.Forms.Label
        Me.cboPRICETYPE = New AppCore.ComboBoxEx
        Me.lblPRICETYPE = New System.Windows.Forms.Label
        Me.cboODKIND = New AppCore.ComboBoxEx
        Me.lblODKIND = New System.Windows.Forms.Label
        Me.cboTradePlace = New AppCore.ComboBoxEx
        Me.lblExecType = New System.Windows.Forms.Label
        Me.pnODSendInfo = New System.Windows.Forms.Panel
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSendAll = New System.Windows.Forms.Button
        Me.pnOrder.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTitle
        '
        Me.pnlTitle.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitle.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(794, 50)
        Me.pnlTitle.TabIndex = 0
        '
        'pnOrder
        '
        Me.pnOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnOrder.Controls.Add(Me.cboBranch)
        Me.pnOrder.Controls.Add(Me.lblBranch)
        Me.pnOrder.Controls.Add(Me.cboPRICETYPE)
        Me.pnOrder.Controls.Add(Me.lblPRICETYPE)
        Me.pnOrder.Controls.Add(Me.cboODKIND)
        Me.pnOrder.Controls.Add(Me.lblODKIND)
        Me.pnOrder.Controls.Add(Me.cboTradePlace)
        Me.pnOrder.Controls.Add(Me.lblExecType)
        Me.pnOrder.Location = New System.Drawing.Point(8, 57)
        Me.pnOrder.Name = "pnOrder"
        Me.pnOrder.Size = New System.Drawing.Size(776, 39)
        Me.pnOrder.TabIndex = 1
        '
        'cboBranch
        '
        Me.cboBranch.DisplayMember = "DISPLAY"
        Me.cboBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBranch.Location = New System.Drawing.Point(632, 8)
        Me.cboBranch.Name = "cboBranch"
        Me.cboBranch.Size = New System.Drawing.Size(136, 21)
        Me.cboBranch.TabIndex = 4
        Me.cboBranch.Tag = "22"
        Me.cboBranch.ValueMember = "VALUE"
        '
        'lblBranch
        '
        Me.lblBranch.Location = New System.Drawing.Point(517, 8)
        Me.lblBranch.Name = "lblBranch"
        Me.lblBranch.Size = New System.Drawing.Size(104, 21)
        Me.lblBranch.TabIndex = 6
        Me.lblBranch.Tag = "BRANCH"
        Me.lblBranch.Text = "lblBranch"
        Me.lblBranch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPRICETYPE
        '
        Me.cboPRICETYPE.DisplayMember = "DISPLAY"
        Me.cboPRICETYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPRICETYPE.Location = New System.Drawing.Point(375, 8)
        Me.cboPRICETYPE.Name = "cboPRICETYPE"
        Me.cboPRICETYPE.Size = New System.Drawing.Size(136, 21)
        Me.cboPRICETYPE.TabIndex = 5
        Me.cboPRICETYPE.Tag = "PRICETYPE"
        Me.cboPRICETYPE.ValueMember = "VALUE"
        '
        'lblPRICETYPE
        '
        Me.lblPRICETYPE.Location = New System.Drawing.Point(279, 8)
        Me.lblPRICETYPE.Name = "lblPRICETYPE"
        Me.lblPRICETYPE.Size = New System.Drawing.Size(88, 21)
        Me.lblPRICETYPE.TabIndex = 4
        Me.lblPRICETYPE.Tag = "PRICETYPE"
        Me.lblPRICETYPE.Text = "lblPRICETYPE"
        Me.lblPRICETYPE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboODKIND
        '
        Me.cboODKIND.DisplayMember = "DISPLAY"
        Me.cboODKIND.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboODKIND.Location = New System.Drawing.Point(632, 8)
        Me.cboODKIND.Name = "cboODKIND"
        Me.cboODKIND.Size = New System.Drawing.Size(136, 21)
        Me.cboODKIND.TabIndex = 3
        Me.cboODKIND.Tag = "22"
        Me.cboODKIND.ValueMember = "VALUE"
        '
        'lblODKIND
        '
        Me.lblODKIND.Location = New System.Drawing.Point(520, 8)
        Me.lblODKIND.Name = "lblODKIND"
        Me.lblODKIND.Size = New System.Drawing.Size(104, 21)
        Me.lblODKIND.TabIndex = 2
        Me.lblODKIND.Tag = "ODKIND"
        Me.lblODKIND.Text = "lblODKIND"
        Me.lblODKIND.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboTradePlace
        '
        Me.cboTradePlace.DisplayMember = "DISPLAY"
        Me.cboTradePlace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTradePlace.Location = New System.Drawing.Point(120, 8)
        Me.cboTradePlace.Name = "cboTradePlace"
        Me.cboTradePlace.Size = New System.Drawing.Size(136, 21)
        Me.cboTradePlace.TabIndex = 1
        Me.cboTradePlace.Tag = "22"
        Me.cboTradePlace.ValueMember = "VALUE"
        '
        'lblExecType
        '
        Me.lblExecType.Location = New System.Drawing.Point(8, 8)
        Me.lblExecType.Name = "lblExecType"
        Me.lblExecType.Size = New System.Drawing.Size(104, 21)
        Me.lblExecType.TabIndex = 0
        Me.lblExecType.Tag = "EXECTYPE"
        Me.lblExecType.Text = "lblTradePlace"
        Me.lblExecType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnODSendInfo
        '
        Me.pnODSendInfo.BackColor = System.Drawing.SystemColors.Control
        Me.pnODSendInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnODSendInfo.Location = New System.Drawing.Point(8, 104)
        Me.pnODSendInfo.Name = "pnODSendInfo"
        Me.pnODSendInfo.Size = New System.Drawing.Size(776, 432)
        Me.pnODSendInfo.TabIndex = 2
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(704, 544)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 24)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "btnCancel"
        '
        'btnSendAll
        '
        Me.btnSendAll.Location = New System.Drawing.Point(616, 544)
        Me.btnSendAll.Name = "btnSendAll"
        Me.btnSendAll.Size = New System.Drawing.Size(80, 24)
        Me.btnSendAll.TabIndex = 4
        Me.btnSendAll.Text = "btnSendAll"
        '
        'frmODSend
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(794, 575)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.pnODSendInfo)
        Me.Controls.Add(Me.pnOrder)
        Me.Controls.Add(Me.pnlTitle)
        Me.Controls.Add(Me.btnSendAll)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Name = "frmODSend"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmODSend"
        Me.pnOrder.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Declare constant and variables "
    Const c_ResourceManager = "_DIRECT.frmODSend-"
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

        v_intIndex = cboTradePlace.SelectedIndex

        'If v_intIndex > 0 Then
        'v_strFilter = " AND B.TRADEPLACE = '" & cboTradePlace.SelectedValue & "'"
        'Else
        '    v_strFilter = ""
        'End If

        v_strFilter = " AND B.TRADEPLACE = '" & cboTradePlace.SelectedValue & "'"


        Select Case cboBranch.SelectedValue
            Case "9999"
                v_strFilter &= " AND substr(C.AFACCTNO,1,4) like '%' "
            Case Else
                v_strFilter &= " AND substr(C.AFACCTNO,1,4)='" & cboBranch.SelectedValue & "'"
        End Select


        If cboPRICETYPE.SelectedValue <> "AA" Then
            v_strFilter &= " AND C.PRICETYPE = '" & cboPRICETYPE.SelectedValue & "' "
        End If
        Select Case Action
            Case "N"
                v_strFilter &= " AND C.ORSTATUS <> '7'"
                If Me.IsPutthought Then
                    v_strFilter &= " AND C.MATCHTYPE ='P' "
                Else
                    v_strFilter &= " AND C.MATCHTYPE ='N' "
                End If
            Case Else
                Select Case cboODKIND.SelectedValue
                    Case "C"
                        v_strFilter &= " AND TLLOG.TLTXCD IN ('8882','8883')"
                    Case "A"
                        v_strFilter &= " AND TLLOG.TLTXCD IN ('8884','8885')"
                    Case "ALL"
                        v_strFilter &= " AND TLLOG.TLTXCD IN ('8882','8883','8884','8885')"
                End Select
        End Select

        If Action = "A" Then
            v_strCmdInquiry = "SELECT * FROM (SELECT C.ACTYPE, D.TYPENAME, ORGORDERID ORDERID, C.EXECTYPE, A.CODEID, A.SYMBOL , C.QUOTEPRICE/L.TRADEUNIT QUOTEPRICE,L.TRADELOT, C.STOPPRICE, C.LIMITPRICE, C.ORDERQTTY,A.PRICE OODPRICE, A.QTTY OODQTTY, " & vbCrLf & _
                                    " A.TXDATE, A.TXNUM, J.FULLNAME, J.CUSTODYCD, K.FULLNAME ISSUERS, J.CUSTID, A.OODSTATUS, C.AFACCTNO, C.CIACCTNO, C.SEACCTNO, L.TRADEUNIT, E.BRATIO ,C.BRATIO OLDBRATIO, E.REFORDERID, " & vbCrLf & _
                                    " L.SECUREDRATIOMIN, L.SECUREDRATIOMAX, C.MATCHTYPE, C.NORK, E.PRICETYPE, C.CLEARDAY, TLLOG.TXDESC, TLLOG.TLTXCD,C.ORSTATUS, c.EXECQTTY,C.MAPORDERID  " & vbCrLf & _
                                    " FROM OOD A, SBSECURITIES B, (SELECT OD.*, NVL(BK.ORDERNUMBER,'') MAPORDERID FROM ODMAST OD, STCORDERBOOK BK WHERE OD.ORDERID=BK.ORDERID (+)) C,ODMAST E, ODTYPE D, AFMAST I, CFMAST J, ISSUERS K, SECURITIES_INFO L, TLLOG " & vbCrLf & _
                                    " WHERE (A.CODEID = B.CODEID And A.ORGORDERID = E.ORDERID AND E.REFORDERID=C.ORDERID And C.ACTYPE = D.ACTYPE) " & vbCrLf & _
                                    "   AND A.TXDATE = TLLOG.TXDATE AND A.TXNUM = TLLOG.TXNUM AND (TLLOG.TXSTATUS = '" & TransactStatus.Completed & "' OR (TLLOG.TLTXCD IN ('8882','8883') AND TLLOG.TXSTATUS = '" & TransactStatus.Completed & "' ) )" & ControlChars.CrLf & _
                                    "   AND B.CODEID = L.CODEID " & vbCrLf & _
                                    "   AND C.ORSTATUS NOT IN ('3','5','0','6','8') " & vbCrLf & _
                                    "   AND C.AFACCTNO = I.ACCTNO AND I.CUSTID = J.CUSTID " & vbCrLf & _
                                    "   AND B.ISSUERID = K.ISSUERID  " & vbCrLf & _
                                    "   AND OODSTATUS ='N' AND C.DELTD <> 'Y' " & v_strFilter & vbCrLf & _
                                    "   ORDER BY j.class DESC," & vbCrLf & _
                                    "  SUBSTR(A.ORGORDERID,5,12),(CASE WHEN TLLOG.OFFTIME IS NULL THEN TLLOG.TXTIME ELSE TLLOG.OFFTIME END)) WHERE ROWNUM BETWEEN 0 AND (SELECT VARVALUE FROM SYSVAR WHERE GRNAME='SYSTEM' AND VARNAME='ODSENDSIZE')"
            '"   AND (OODSTATUS ='N' OR (OODSTATUS='B' AND NVL(TLIDSENT,'0')= '" & TellerId & "')) AND C.DELTD <> 'Y' " & v_strFilter & vbCrLf & _
        Else
            v_strCmdInquiry = "   SELECT * FROM (SELECT * FROM (SELECT C.ACTYPE, D.TYPENAME,J.CLASS,TLLOG.OFFTIME,TLLOG.TXTIME, ORGORDERID ORDERID, C.EXECTYPE, A.CODEID, A.SYMBOL , C.QUOTEPRICE/L.TRADEUNIT QUOTEPRICE,L.TRADELOT, C.STOPPRICE, C.LIMITPRICE, C.ORDERQTTY,A.PRICE OODPRICE, A.QTTY OODQTTY, " & ControlChars.CrLf & _
                     "    A.TXDATE, A.TXNUM, J.FULLNAME, J.CUSTODYCD, K.FULLNAME ISSUERS, J.CUSTID, A.OODSTATUS, C.AFACCTNO, C.CIACCTNO, C.SEACCTNO, L.TRADEUNIT, C.BRATIO ,C.BRATIO OLDBRATIO, C.REFORDERID, " & ControlChars.CrLf & _
                     "    L.SECUREDRATIOMIN, L.SECUREDRATIOMAX, C.MATCHTYPE, C.NORK, C.PRICETYPE, C.CLEARDAY, TLLOG.TXDESC, TLLOG.TLTXCD,C.ORSTATUS,'' MAPORDERID " & ControlChars.CrLf & _
                     "    FROM OOD A, SBSECURITIES B, ODMAST C, ODTYPE D, AFMAST I, CFMAST J, ISSUERS K, SECURITIES_INFO L, TLLOG " & ControlChars.CrLf & _
                     "    WHERE (A.CODEID = B.CODEID AND A.ORGORDERID = C.ORDERID AND C.ACTYPE = D.ACTYPE) " & ControlChars.CrLf & _
                     "      AND A.TXDATE = TLLOG.TXDATE AND A.TXNUM = TLLOG.TXNUM AND (TLLOG.TXSTATUS = '1' OR (TLLOG.TLTXCD IN ('8882','8883') AND TLLOG.TXSTATUS = '1' ) )" & ControlChars.CrLf & _
                     "      AND B.CODEID = L.CODEID " & ControlChars.CrLf & _
                     "      AND C.ORSTATUS NOT IN ('3','5','0','6') " & ControlChars.CrLf & _
                     "      AND C.AFACCTNO = I.ACCTNO AND I.CUSTID = J.CUSTID " & ControlChars.CrLf & _
                     "      AND B.ISSUERID = K.ISSUERID  " & ControlChars.CrLf & _
                     "      AND (OODSTATUS ='N' OR (OODSTATUS='B' AND NVL(TLIDSENT,'0')= '" & TellerId & "')) AND C.DELTD <> 'Y' AND C.QUOTEPRICE <= L.CEILINGPRICE AND C.QUOTEPRICE >= L.FLOORPRICE " & v_strFilter & vbCrLf & _
                     "         UNION " & ControlChars.CrLf & _
                     "    SELECT C.ACTYPE, D.TYPENAME,J.CLASS,TLLOG.OFFTIME,TLLOG.TXTIME, ORGORDERID ORDERID, C.EXECTYPE, A.CODEID, A.SYMBOL , C.QUOTEPRICE/L.TRADEUNIT QUOTEPRICE,L.TRADELOT, C.STOPPRICE, C.LIMITPRICE, C.ORDERQTTY,A.PRICE OODPRICE, A.QTTY OODQTTY, " & ControlChars.CrLf & _
                     "    A.TXDATE, A.TXNUM, J.FULLNAME, J.CUSTODYCD, K.FULLNAME ISSUERS, J.CUSTID, A.OODSTATUS, C.AFACCTNO, C.CIACCTNO, C.SEACCTNO, L.TRADEUNIT, E.BRATIO ,C.BRATIO OLDBRATIO, E.REFORDERID, " & ControlChars.CrLf & _
                     "    L.SECUREDRATIOMIN, L.SECUREDRATIOMAX, C.MATCHTYPE, C.NORK, E.PRICETYPE, C.CLEARDAY, TLLOG.TXDESC, TLLOG.TLTXCD,C.ORSTATUS,'' MAPORDERID  " & ControlChars.CrLf & _
                     "    FROM OOD A, SBSECURITIES B, ODMAST C,ODMAST E, ODTYPE D, AFMAST I, CFMAST J, ISSUERS K, SECURITIES_INFO L, TLLOG " & ControlChars.CrLf & _
                     "    WHERE (A.CODEID = B.CODEID AND A.ORGORDERID = E.ORDERID AND E.REFORDERID=C.ORDERID AND C.ACTYPE = D.ACTYPE) " & ControlChars.CrLf & _
                     "      AND A.TXDATE = TLLOG.TXDATE AND A.TXNUM = TLLOG.TXNUM AND (TLLOG.TXSTATUS = '1' OR (TLLOG.TLTXCD IN ('8882','8883') AND TLLOG.TXSTATUS = '1' ) )" & ControlChars.CrLf & _
                     "      AND B.CODEID = L.CODEID " & ControlChars.CrLf & _
                     "      AND C.ORSTATUS IN ('8') " & ControlChars.CrLf & _
                     "      AND C.AFACCTNO = I.ACCTNO AND I.CUSTID = J.CUSTID " & ControlChars.CrLf & _
                     "      AND B.ISSUERID = K.ISSUERID  " & ControlChars.CrLf & _
                     "      AND OODSTATUS ='N' AND C.DELTD <> 'Y' " & v_strFilter & " AND TLLOG.TLTXCD IN ('8884','8885') AND C.QUOTEPRICE <=L.CEILINGPRICE  AND  C.QUOTEPRICE >=L.FLOORPRICE ) " & ControlChars.CrLf & _
                     "    ORDER BY SUBSTR(ORDERID,5,12),(CASE WHEN OFFTIME IS NULL THEN TXTIME ELSE OFFTIME END) )" & ControlChars.CrLf & _
                     "    WHERE ROWNUM BETWEEN 0 AND (SELECT VARVALUE FROM SYSVAR WHERE GRNAME='SYSTEM' AND VARNAME='ODSENDSIZE')"

            'If AdvancedSending Then
            '    v_strCmdInquiry = "   SELECT * FROM (SELECT * FROM (SELECT C.ACTYPE, D.TYPENAME,J.CLASS,TLLOG.OFFTIME,TLLOG.TXTIME, ORGORDERID ORDERID, C.EXECTYPE, A.CODEID, A.SYMBOL , C.QUOTEPRICE/L.TRADEUNIT QUOTEPRICE,L.TRADELOT, C.STOPPRICE, C.LIMITPRICE, C.ORDERQTTY,A.PRICE OODPRICE, A.QTTY OODQTTY, " & ControlChars.CrLf & _
            '         "    A.TXDATE, A.TXNUM, J.FULLNAME, J.CUSTODYCD, K.FULLNAME ISSUERS, J.CUSTID, A.OODSTATUS, C.AFACCTNO, C.CIACCTNO, C.SEACCTNO, L.TRADEUNIT, C.BRATIO ,C.BRATIO OLDBRATIO, C.REFORDERID, " & ControlChars.CrLf & _
            '         "    L.SECUREDRATIOMIN, L.SECUREDRATIOMAX, C.MATCHTYPE, C.NORK, C.PRICETYPE, C.CLEARDAY, TLLOG.TXDESC, TLLOG.TLTXCD,C.ORSTATUS,'' MAPORDERID " & ControlChars.CrLf & _
            '         "    FROM OOD A, SBSECURITIES B, ODMAST C, ODTYPE D, AFMAST I, CFMAST J, ISSUERS K, SECURITIES_INFO L, TLLOG " & ControlChars.CrLf & _
            '         "    WHERE (A.CODEID = B.CODEID AND A.ORGORDERID = C.ORDERID AND C.ACTYPE = D.ACTYPE) " & ControlChars.CrLf & _
            '         "      AND A.TXDATE = TLLOG.TXDATE AND A.TXNUM = TLLOG.TXNUM AND (TLLOG.TXSTATUS = '1' OR (TLLOG.TLTXCD IN ('8882','8883') AND TLLOG.TXSTATUS = '1' ) )" & ControlChars.CrLf & _
            '         "      AND B.CODEID = L.CODEID " & ControlChars.CrLf & _
            '         "      AND C.ORSTATUS NOT IN ('3','5','0','6') " & ControlChars.CrLf & _
            '         "      AND C.AFACCTNO = I.ACCTNO AND I.CUSTID = J.CUSTID " & ControlChars.CrLf & _
            '         "      AND B.ISSUERID = K.ISSUERID  " & ControlChars.CrLf & _
            '         "      AND (OODSTATUS ='N' OR (OODSTATUS='B' AND NVL(TLIDSENT,'0')= '" & TellerId & "')) AND C.DELTD <> 'Y' AND C.QUOTEPRICE <= L.CEILINGPRICE AND C.QUOTEPRICE >= L.FLOORPRICE " & v_strFilter & vbCrLf & _
            '         "         UNION " & ControlChars.CrLf & _
            '         "    SELECT C.ACTYPE, D.TYPENAME,J.CLASS,TLLOG.OFFTIME,TLLOG.TXTIME, ORGORDERID ORDERID, C.EXECTYPE, A.CODEID, A.SYMBOL , C.QUOTEPRICE/L.TRADEUNIT QUOTEPRICE,L.TRADELOT, C.STOPPRICE, C.LIMITPRICE, C.ORDERQTTY,A.PRICE OODPRICE, A.QTTY OODQTTY, " & ControlChars.CrLf & _
            '         "    A.TXDATE, A.TXNUM, J.FULLNAME, J.CUSTODYCD, K.FULLNAME ISSUERS, J.CUSTID, A.OODSTATUS, C.AFACCTNO, C.CIACCTNO, C.SEACCTNO, L.TRADEUNIT, E.BRATIO ,C.BRATIO OLDBRATIO, E.REFORDERID, " & ControlChars.CrLf & _
            '         "    L.SECUREDRATIOMIN, L.SECUREDRATIOMAX, C.MATCHTYPE, C.NORK, E.PRICETYPE, C.CLEARDAY, TLLOG.TXDESC, TLLOG.TLTXCD,C.ORSTATUS,'' MAPORDERID  " & ControlChars.CrLf & _
            '         "    FROM OOD A, SBSECURITIES B, ODMAST C,ODMAST E, ODTYPE D, AFMAST I, CFMAST J, ISSUERS K, SECURITIES_INFO L, TLLOG " & ControlChars.CrLf & _
            '         "    WHERE (A.CODEID = B.CODEID AND A.ORGORDERID = E.ORDERID AND E.REFORDERID=C.ORDERID AND C.ACTYPE = D.ACTYPE) " & ControlChars.CrLf & _
            '         "      AND A.TXDATE = TLLOG.TXDATE AND A.TXNUM = TLLOG.TXNUM AND (TLLOG.TXSTATUS = '1' OR (TLLOG.TLTXCD IN ('8882','8883') AND TLLOG.TXSTATUS = '1' ) )" & ControlChars.CrLf & _
            '         "      AND B.CODEID = L.CODEID " & ControlChars.CrLf & _
            '         "      AND C.ORSTATUS IN ('8') " & ControlChars.CrLf & _
            '         "      AND C.AFACCTNO = I.ACCTNO AND I.CUSTID = J.CUSTID " & ControlChars.CrLf & _
            '         "      AND B.ISSUERID = K.ISSUERID  " & ControlChars.CrLf & _
            '         "      AND OODSTATUS ='N' AND C.DELTD <> 'Y' " & v_strFilter & " AND TLLOG.TLTXCD IN ('8884','8885') AND C.QUOTEPRICE <=L.CEILINGPRICE  AND  C.QUOTEPRICE >=L.FLOORPRICE ) " & ControlChars.CrLf & _
            '         "    ORDER BY SUBSTR(ORDERID,5,12),(CASE WHEN OFFTIME IS NULL THEN TXTIME ELSE OFFTIME END) )" & ControlChars.CrLf & _
            '         "    WHERE ROWNUM BETWEEN 0 AND (SELECT VARVALUE FROM SYSVAR WHERE GRNAME='SYSTEM' AND VARNAME='ODSENDSIZE')"
            '    '"    WHERE (INSTR((SELECT VARVALUE FROM SYSVAR WHERE GRNAME='SYSTEM' AND VARNAME='NORMALLASS'),CLASS)=0 OR  " & IIf(IsPutthought, 1, 0) & "=1)" & ControlChars.CrLf & _
            '    '"    ORDER BY (CASE WHEN QUOTEPRICE*ORDERQTTY>=((SELECT TO_NUMBER(VARVALUE) FROM SYSVAR WHERE GRNAME='SYSTEM' AND VARNAME='ADVPRIOAMOUNT')) THEN '111' ELSE CLASS END) DESC, CLASS DESC , SUBSTR(ORDERID,5,12),(CASE WHEN OFFTIME IS NULL THEN TXTIME ELSE OFFTIME END) )" & ControlChars.CrLf & _
            'Else
            '    'Cho class 000,001,002 va lenh >300.000.000 thi len tren
            '    v_strCmdInquiry = "   SELECT * FROM (SELECT * FROM (SELECT C.ACTYPE, D.TYPENAME,J.CLASS,TLLOG.OFFTIME,TLLOG.TXTIME, ORGORDERID ORDERID, C.EXECTYPE, A.CODEID, A.SYMBOL , C.QUOTEPRICE/L.TRADEUNIT QUOTEPRICE,L.TRADELOT, C.STOPPRICE, C.LIMITPRICE, C.ORDERQTTY,A.PRICE OODPRICE, A.QTTY OODQTTY, " & ControlChars.CrLf & _
            '                         "    A.TXDATE, A.TXNUM, J.FULLNAME, J.CUSTODYCD, K.FULLNAME ISSUERS, J.CUSTID, A.OODSTATUS, C.AFACCTNO, C.CIACCTNO, C.SEACCTNO, L.TRADEUNIT, C.BRATIO ,C.BRATIO OLDBRATIO, C.REFORDERID, " & ControlChars.CrLf & _
            '                         "    L.SECUREDRATIOMIN, L.SECUREDRATIOMAX, C.MATCHTYPE, C.NORK, C.PRICETYPE, C.CLEARDAY, TLLOG.TXDESC, TLLOG.TLTXCD,C.ORSTATUS,'' MAPORDERID " & ControlChars.CrLf & _
            '                         "    FROM OOD A, SBSECURITIES B, ODMAST C, ODTYPE D, AFMAST I, CFMAST J, ISSUERS K, SECURITIES_INFO L, TLLOG " & ControlChars.CrLf & _
            '                         "    WHERE (A.CODEID = B.CODEID AND A.ORGORDERID = C.ORDERID AND C.ACTYPE = D.ACTYPE) " & ControlChars.CrLf & _
            '                         "      AND A.TXDATE = TLLOG.TXDATE AND A.TXNUM = TLLOG.TXNUM AND (TLLOG.TXSTATUS = '1' OR (TLLOG.TLTXCD IN ('8882','8883') AND TLLOG.TXSTATUS = '1' ) )" & ControlChars.CrLf & _
            '                         "      AND B.CODEID = L.CODEID " & ControlChars.CrLf & _
            '                         "      AND C.ORSTATUS NOT IN ('3','5','0','6') " & ControlChars.CrLf & _
            '                         "      AND C.AFACCTNO = I.ACCTNO AND I.CUSTID = J.CUSTID " & ControlChars.CrLf & _
            '                         "      AND B.ISSUERID = K.ISSUERID  " & ControlChars.CrLf & _
            '                         "      AND (OODSTATUS ='N' OR (OODSTATUS='B' AND NVL(TLIDSENT,'0')= '" & TellerId & "')) AND C.DELTD <> 'Y' AND C.QUOTEPRICE <= L.CEILINGPRICE AND C.QUOTEPRICE >= L.FLOORPRICE " & v_strFilter & vbCrLf & _
            '                         "         UNION " & ControlChars.CrLf & _
            '                         "    SELECT C.ACTYPE, D.TYPENAME,J.CLASS,TLLOG.OFFTIME,TLLOG.TXTIME, ORGORDERID ORDERID, C.EXECTYPE, A.CODEID, A.SYMBOL , C.QUOTEPRICE/L.TRADEUNIT QUOTEPRICE,L.TRADELOT, C.STOPPRICE, C.LIMITPRICE, C.ORDERQTTY,A.PRICE OODPRICE, A.QTTY OODQTTY, " & ControlChars.CrLf & _
            '                         "    A.TXDATE, A.TXNUM, J.FULLNAME, J.CUSTODYCD, K.FULLNAME ISSUERS, J.CUSTID, A.OODSTATUS, C.AFACCTNO, C.CIACCTNO, C.SEACCTNO, L.TRADEUNIT, E.BRATIO ,C.BRATIO OLDBRATIO, E.REFORDERID, " & ControlChars.CrLf & _
            '                         "    L.SECUREDRATIOMIN, L.SECUREDRATIOMAX, C.MATCHTYPE, C.NORK, E.PRICETYPE, C.CLEARDAY, TLLOG.TXDESC, TLLOG.TLTXCD,C.ORSTATUS,'' MAPORDERID  " & ControlChars.CrLf & _
            '                         "    FROM OOD A, SBSECURITIES B, ODMAST C,ODMAST E, ODTYPE D, AFMAST I, CFMAST J, ISSUERS K, SECURITIES_INFO L, TLLOG " & ControlChars.CrLf & _
            '                         "    WHERE (A.CODEID = B.CODEID AND A.ORGORDERID = E.ORDERID AND E.REFORDERID=C.ORDERID AND C.ACTYPE = D.ACTYPE) " & ControlChars.CrLf & _
            '                         "      AND A.TXDATE = TLLOG.TXDATE AND A.TXNUM = TLLOG.TXNUM AND (TLLOG.TXSTATUS = '1' OR (TLLOG.TLTXCD IN ('8882','8883') AND TLLOG.TXSTATUS = '1' ) )" & ControlChars.CrLf & _
            '                         "      AND B.CODEID = L.CODEID " & ControlChars.CrLf & _
            '                         "      AND C.ORSTATUS IN ('8') " & ControlChars.CrLf & _
            '                         "      AND C.AFACCTNO = I.ACCTNO AND I.CUSTID = J.CUSTID " & ControlChars.CrLf & _
            '                         "      AND B.ISSUERID = K.ISSUERID  " & ControlChars.CrLf & _
            '                         "      AND OODSTATUS ='N' AND C.DELTD <> 'Y' " & v_strFilter & " AND TLLOG.TLTXCD IN ('8884','8885') AND C.QUOTEPRICE <=L.CEILINGPRICE  AND  C.QUOTEPRICE >=L.FLOORPRICE )" & ControlChars.CrLf & _
            '                         "    ORDER BY  SUBSTR(ORDERID,5,12),(CASE WHEN OFFTIME IS NULL THEN TXTIME ELSE OFFTIME END) )" & ControlChars.CrLf & _
            '                         "    WHERE ROWNUM BETWEEN 0 AND (SELECT VARVALUE FROM SYSVAR WHERE GRNAME='SYSTEM' AND VARNAME='ODSENDSIZE')"
            '    '"    WHERE (INSTR((SELECT VARVALUE FROM SYSVAR WHERE GRNAME='SYSTEM' AND VARNAME='NORMALLASS'),CLASS)>0  OR  " & IIf(IsPutthought, 1, 0) & "=1)" & ControlChars.CrLf & _
            '    '"    ORDER BY (CASE WHEN QUOTEPRICE*ORDERQTTY>=((SELECT TO_NUMBER(VARVALUE) FROM SYSVAR WHERE GRNAME='SYSTEM' AND VARNAME='PRIOAMOUNT')) THEN '003' ELSE CLASS END) DESC , CLASS DESC, SUBSTR(ORDERID,5,12),(CASE WHEN OFFTIME IS NULL THEN TXTIME ELSE OFFTIME END) )" & ControlChars.CrLf & _
            'End If


        End If
        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strCmdInquiry)
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        v_ws.Message(v_strObjMsg)

        FillDataGrid(ODSendGrid, v_strObjMsg, "")
        cboTradePlace.SelectedIndex = v_intIndex

        If mv_intCurrentRow >= ODSendGrid.DataRows.Count Then mv_intCurrentRow = 0
        If ODSendGrid.DataRows.Count > 0 Then
            ODSendGrid.CurrentRow = ODSendGrid.DataRows(mv_intCurrentRow)
            ODSendGrid.SelectedRows.Clear()
            ODSendGrid.SelectedRows.Add(ODSendGrid.CurrentRow)
            btnSendAll.Focus()
        End If

    End Sub
    Private Sub InitializeGrid()
        'Khởi tạo Grid contacts
        ODSendGrid = New GridEx
        Dim v_cmrContactsHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrContactsHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrContactsHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        ODSendGrid.FixedHeaderRows.Add(v_cmrContactsHeader)
        'ODSendGrid.Columns.Add(New Xceed.Grid.Column("CHECKALL", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("EXECTYPE_VAL", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("CUSTODYCD", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("AFACCTNO", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("EXECTYPE", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("SYMBOL", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("ORDERQTTY", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("OODQTTY", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("OODPRICE", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("QTTY", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("ORDERID", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("EXECQTTY", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("QUOTEPRICE", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("LIMITPRICE", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("OODSTATUS", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("PRICE", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("CIACCTNO", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("SEACCTNO", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("DESC_PRICETYPE", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("CURRPRICE", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("MATCHTYPE", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("NORK", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("CODEID", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("SECUREDRATIOMIN", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("SECUREDRATIOMAX", GetType(System.String)))
        'ODSendGrid.Columns.Add(New Xceed.Grid.Column("TYP_BRATIO", GetType(System.String)))
        'ODSendGrid.Columns.Add(New Xceed.Grid.Column("AF_BRATIO", GetType(System.String)))

        ODSendGrid.Columns.Add(New Xceed.Grid.Column("PARVALUE", GetType(System.String)))
        'ODSendGrid.Columns.Add(New Xceed.Grid.Column("TRADEPLACE", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("TXNUM", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("TXDATE", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("ISSUERS", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("FULLNAME", GetType(System.String)))
        'ODSendGrid.Columns.Add(New Xceed.Grid.Column("VIA", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("PRICETYPE", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("CLEARDAY", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("TXDESC", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("TLTXCD", GetType(System.String)))

        ODSendGrid.Columns.Add(New Xceed.Grid.Column("TRADEUNIT", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("BRATIO", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("OLDBRATIO", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("REFORDERID", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("ORSTATUS", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("TRADELOT", GetType(System.String)))
        ODSendGrid.Columns.Add(New Xceed.Grid.Column("MAPORDERID", GetType(System.String)))


        'ODSendGrid.Columns("CHECKALL").Title = mv_ResourceManager.GetString("CHECKALL")
        ODSendGrid.Columns("EXECTYPE").Title = mv_ResourceManager.GetString("EXECTYPE")
        ODSendGrid.Columns("EXECTYPE_VAL").Title = ""
        ODSendGrid.Columns("CUSTODYCD").Title = mv_ResourceManager.GetString("CUSTODYCD")
        ODSendGrid.Columns("SYMBOL").Title = mv_ResourceManager.GetString("SYMBOL")
        ODSendGrid.Columns("OODSTATUS").Title = mv_ResourceManager.GetString("OODSTATUS")
        ODSendGrid.Columns("PRICE").Title = mv_ResourceManager.GetString("PRICE")
        ODSendGrid.Columns("QTTY").Title = mv_ResourceManager.GetString("QTTY")
        ODSendGrid.Columns("ORDERID").Title = mv_ResourceManager.GetString("ORDERID")
        ODSendGrid.Columns("ORDERQTTY").Title = mv_ResourceManager.GetString("ORDERQTTY")
        ODSendGrid.Columns("EXECQTTY").Title = mv_ResourceManager.GetString("EXECQTTY")
        ODSendGrid.Columns("OODQTTY").Title = mv_ResourceManager.GetString("OODQTTY")
        ODSendGrid.Columns("DESC_PRICETYPE").Title = mv_ResourceManager.GetString("DESC_PRICETYPE")
        ODSendGrid.Columns("QUOTEPRICE").Title = mv_ResourceManager.GetString("QUOTEPRICE")
        ODSendGrid.Columns("OODPRICE").Title = mv_ResourceManager.GetString("OODPRICE")
        ODSendGrid.Columns("LIMITPRICE").Title = mv_ResourceManager.GetString("LIMITPRICE")
        ODSendGrid.Columns("CURRPRICE").Title = mv_ResourceManager.GetString("CURRPRICE")
        ODSendGrid.Columns("MATCHTYPE").Title = mv_ResourceManager.GetString("MATCHTYPE")
        ODSendGrid.Columns("NORK").Title = mv_ResourceManager.GetString("NORK")
        ODSendGrid.Columns("CODEID").Title = mv_ResourceManager.GetString("CODEID")
        ODSendGrid.Columns("SECUREDRATIOMIN").Title = mv_ResourceManager.GetString("SECUREDRATIOMIN")
        ODSendGrid.Columns("SECUREDRATIOMAX").Title = mv_ResourceManager.GetString("SECUREDRATIOMAX")
        ODSendGrid.Columns("CIACCTNO").Title = mv_ResourceManager.GetString("CIACCTNO")
        ODSendGrid.Columns("SEACCTNO").Title = mv_ResourceManager.GetString("SEACCTNO")
        ODSendGrid.Columns("AFACCTNO").Title = mv_ResourceManager.GetString("AFACCTNO")
        ODSendGrid.Columns("PARVALUE").Title = mv_ResourceManager.GetString("PARVALUE")
        'ODSendGrid.Columns("TRADEPLACE").Title = mv_ResourceManager.GetString("NORK")
        ODSendGrid.Columns("TXDATE").Title = mv_ResourceManager.GetString("TXDATE")
        ODSendGrid.Columns("TXNUM").Title = mv_ResourceManager.GetString("TXNUM")
        ODSendGrid.Columns("ISSUERS").Title = mv_ResourceManager.GetString("ISSUERS")
        ODSendGrid.Columns("FULLNAME").Title = mv_ResourceManager.GetString("FULLNAME")
        'ODSendGrid.Columns("VIA").Title = mv_ResourceManager.GetString("VIA")
        ODSendGrid.Columns("PRICETYPE").Title = mv_ResourceManager.GetString("PRICETYPE")
        ODSendGrid.Columns("CLEARDAY").Title = mv_ResourceManager.GetString("FULLNAME")
        ODSendGrid.Columns("TXDESC").Title = mv_ResourceManager.GetString("TXDESC")
        ODSendGrid.Columns("TLTXCD").Title = mv_ResourceManager.GetString("TLTXCD")
        ODSendGrid.Columns("TRADEUNIT").Title = mv_ResourceManager.GetString("TLTXCD")
        ODSendGrid.Columns("BRATIO").Title = mv_ResourceManager.GetString("TLTXCD")
        ODSendGrid.Columns("OLDBRATIO").Title = mv_ResourceManager.GetString("TLTXCD")
        ODSendGrid.Columns("REFORDERID").Title = mv_ResourceManager.GetString("TLTXCD")
        ODSendGrid.Columns("ORSTATUS").Title = mv_ResourceManager.GetString("ORSTATUS")
        ODSendGrid.Columns("TRADELOT").Title = mv_ResourceManager.GetString("TRADELOT")


        ODSendGrid.Columns("EXECTYPE_VAL").Width = 0
        'ODSendGrid.Columns("CHECKALL").Width = 15
        'ODSendGrid.Columns("CHECKALL").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("EXECTYPE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("EXECTYPE_VAL").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("CUSTODYCD").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("SYMBOL").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("OODSTATUS").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("OODSTATUS").Width = 0
        ODSendGrid.Columns("PRICE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("PRICE").Width = 0
        ODSendGrid.Columns("OODPRICE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("OODPRICE").Width = 100
        ODSendGrid.Columns("QTTY").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("QTTY").Width = 0
        ODSendGrid.Columns("OODQTTY").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("OODQTTY").Width = 100
        ODSendGrid.Columns("ORDERID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("ORDERID").Width = 150
        ODSendGrid.Columns("CODEID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("CODEID").Width = 120
        ODSendGrid.Columns("ORDERQTTY").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("ORDERQTTY").Width = 0
        ODSendGrid.Columns("QUOTEPRICE").Width = 0

        ODSendGrid.Columns("DESC_PRICETYPE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("DESC_PRICETYPE").Width = 0
        ODSendGrid.Columns("QUOTEPRICE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("LIMITPRICE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("LIMITPRICE").Width = 0
        ODSendGrid.Columns("CURRPRICE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("CURRPRICE").Width = 0
        ODSendGrid.Columns("MATCHTYPE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("NORK").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("CODEID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("SECUREDRATIOMIN").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("SECUREDRATIOMIN").Width = 150
        ODSendGrid.Columns("SECUREDRATIOMAX").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("SECUREDRATIOMAX").Width = 150
        'ODSendGrid.Columns("TYP_BRATIO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        'ODSendGrid.Columns("TYP_BRATIO").Width = 0
        'ODSendGrid.Columns("AF_BRATIO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        'ODSendGrid.Columns("AF_BRATIO").Width = 0
        ODSendGrid.Columns("CIACCTNO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("CIACCTNO").Width = 0
        ODSendGrid.Columns("SEACCTNO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("SEACCTNO").Width = 0
        ODSendGrid.Columns("AFACCTNO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("AFACCTNO").Width = 150
        ODSendGrid.Columns("PARVALUE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("PARVALUE").Width = 0
        'ODSendGrid.Columns("TRADEPLACE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        'ODSendGrid.Columns("TRADEPLACE").Width = 0
        ODSendGrid.Columns("TXDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("TXDATE").Width = 0
        ODSendGrid.Columns("TXNUM").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODSendGrid.Columns("TXNUM").Width = 0
        ODSendGrid.Columns("ISSUERS").Width = 0
        ODSendGrid.Columns("FULLNAME").Width = 0
        'ODSendGrid.Columns("VIA").Width = 0
        ODSendGrid.Columns("PRICETYPE").Width = 0
        ODSendGrid.Columns("CLEARDAY").Width = 0
        ODSendGrid.Columns("TXDESC").Width = 0
        ODSendGrid.Columns("TLTXCD").Width = 0
        ODSendGrid.Columns("EXECTYPE_VAL").Width = 0
        ODSendGrid.Columns("TRADEUNIT").Width = 0
        ODSendGrid.Columns("BRATIO").Width = 0
        ODSendGrid.Columns("OLDBRATIO").Width = 0
        ODSendGrid.Columns("REFORDERID").Width = 0
        ODSendGrid.Columns("ORSTATUS").Width = 0
        ODSendGrid.Columns("TRADELOT").Width = 0
        ODSendGrid.Columns("MAPORDERID").Width = 0


        ODSendGrid.Columns("EXECTYPE_VAL").CanBeSorted = False
        ODSendGrid.Columns("CUSTODYCD").CanBeSorted = False
        ODSendGrid.Columns("AFACCTNO").CanBeSorted = False
        ODSendGrid.Columns("EXECTYPE").CanBeSorted = False
        ODSendGrid.Columns("SYMBOL").CanBeSorted = False
        ODSendGrid.Columns("ORDERQTTY").CanBeSorted = False
        ODSendGrid.Columns("OODQTTY").CanBeSorted = False
        ODSendGrid.Columns("OODPRICE").CanBeSorted = False
        ODSendGrid.Columns("QTTY").CanBeSorted = False
        ODSendGrid.Columns("ORDERID").CanBeSorted = False
        ODSendGrid.Columns("EXECQTTY").CanBeSorted = False
        ODSendGrid.Columns("QUOTEPRICE").CanBeSorted = False
        ODSendGrid.Columns("LIMITPRICE").CanBeSorted = False
        ODSendGrid.Columns("OODSTATUS").CanBeSorted = False
        ODSendGrid.Columns("PRICE").CanBeSorted = False
        ODSendGrid.Columns("CIACCTNO").CanBeSorted = False
        ODSendGrid.Columns("SEACCTNO").CanBeSorted = False
        ODSendGrid.Columns("DESC_PRICETYPE").CanBeSorted = False
        ODSendGrid.Columns("CURRPRICE").CanBeSorted = False
        ODSendGrid.Columns("MATCHTYPE").CanBeSorted = False
        ODSendGrid.Columns("NORK").CanBeSorted = False
        ODSendGrid.Columns("CODEID").CanBeSorted = False
        ODSendGrid.Columns("SECUREDRATIOMIN").CanBeSorted = False
        ODSendGrid.Columns("SECUREDRATIOMAX").CanBeSorted = False
        ODSendGrid.Columns("MAPORDERID").CanBeSorted = False
        'ODSendGrid.Columns.("TYP_BRATIO").CanBeSorted = False
        'ODSendGrid.Columns.("AF_BRATIO").CanBeSorted = False

        ODSendGrid.Columns("PARVALUE").CanBeSorted = False
        'ODSendGrid.Columns("TRADEPLACE").CanBeSorted = False
        ODSendGrid.Columns("TXNUM").CanBeSorted = False
        ODSendGrid.Columns("TXDATE").CanBeSorted = False
        ODSendGrid.Columns("ISSUERS").CanBeSorted = False
        ODSendGrid.Columns("FULLNAME").CanBeSorted = False
        'ODSendGrid.Columns.("VIA").CanBeSorted = False
        ODSendGrid.Columns("PRICETYPE").CanBeSorted = False
        ODSendGrid.Columns("CLEARDAY").CanBeSorted = False
        ODSendGrid.Columns("TXDESC").CanBeSorted = False
        ODSendGrid.Columns("TLTXCD").CanBeSorted = False

        ODSendGrid.Columns("TRADEUNIT").CanBeSorted = False
        ODSendGrid.Columns("BRATIO").CanBeSorted = False
        ODSendGrid.Columns("OLDBRATIO").CanBeSorted = False
        ODSendGrid.Columns("REFORDERID").CanBeSorted = False
        ODSendGrid.Columns("ORSTATUS").CanBeSorted = False
        ODSendGrid.Columns("TRADELOT").CanBeSorted = False

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

            'Kiểm tra thông tin và xử lý lỗi (nếu có) từ message trả v�?            
            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                'Thông báo lỗi
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
                'Remove các bản ghi cũ
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
                setControlValue()
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

        'Tính toán tỷ lệ ký quỹ của lệnh
        If IsNumeric(mv_strSECURERATIOTMIN) And IsNumeric(mv_strSECURERATIOMAX) _
             And IsNumeric(mv_strTYP_BRATIO) And IsNumeric(mv_strAF_BRATIO) Then
            'Lấy theo tham số mức hệ thống
            mv_dblSecureRatio = CDbl(mv_strSECURERATIOTMIN)
            'So sánh với tham số loại hình
            mv_dblSecureRatio = IIf(mv_dblSecureRatio > CDbl(mv_strTYP_BRATIO), mv_dblSecureRatio, CDbl(mv_strTYP_BRATIO))
            'So sánh với tham số hợp đồng
            mv_dblSecureRatio = IIf(mv_dblSecureRatio > CDbl(mv_strAF_BRATIO), mv_dblSecureRatio, CDbl(mv_strAF_BRATIO))
            'Không vượt qua Max của tham số hệ thống
            mv_dblSecureRatio = IIf(mv_dblSecureRatio > CDbl(mv_strSECURERATIOMAX), CDbl(mv_strSECURERATIOMAX), mv_dblSecureRatio)
        Else
            'Mặc định là ký quỹ 100%
            mv_dblSecureRatio = 100
        End If

    End Sub

    Private Sub setBlankGridRowValue()
        mv_strMATCHTYPE = String.Empty
    End Sub
    Private Sub setControlValue()
        Me.cboTradePlace.SelectedValue = mv_strMATCHTYPE
    End Sub
#End Region

#Region " Other method "

    '---------------------------------------------------------------------------------------------------------
    'Hàm này được sử dụng để nạp màn hình.
    'Biến vào 
    '   strTLTXCD là mã giao dịch, dùng để xác định các trư�?ng trong giao dịch
    '   v_blnChain  Xác định xem có phải nạp màn hình sau khi đã tra cứu không
    '   v_blnData   Xác định xem có phải nạp màn hình xem chi tiết giao dịch không
    '   v_strXML    Là nội dung chuỗi XML tương ứng với v_blnChain hoặc v_blnData
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

            'Lấy thông tin chung v�? giao dịch
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
                'Nếu không tồn tại mã giao dịch
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

            'Lấy thông tin chi tiết các trư�?ng của giao dịch
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
                        'Xử lý cho trư�?ng Description
                        v_strDefVal = Me.Text
                    ElseIf v_strDefVal = "<$BUSDATE>" Then
                        'Lấy ngày làm việc hiện tại
                        v_strDefVal = Me.BusDate
                    End If
                    If v_blnChain Then
                        'Nếu giao dịch được nạp qua giao dịch tra cứu
                        If Len(v_strChainName) > 0 Then
                            'Nếu trư�?ng này có sử dụng CHAINNAME để lấy giá trị từ màn hình tra cứu
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

            'Lấy các luật kiểm tra của các trư�?ng giao dịch
            v_strClause = "SELECT FLDNAME, VALTYPE, OPERATOR, VALEXP, VALEXP2, ERRMSG, EN_ERRMSG FROM FLDVAL " & _
                "WHERE upper(OBJNAME) = '" & strTLTXCD & "' ORDER BY VALTYPE, FLDNAME, ODRNUM" 'Thứ tự order by là quan tr�?ng không sửa
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
                        'Ghi nhận thuật toán để kiểm tra và tính toán cho từng trư�?ng của giao dịch
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

                '�?i�?u kiện xử lý
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
    'Verify rules của giao dịch, trả v�? điện giao dịch đã được tạo
    Private Function VerifyRules(ByRef v_strTxMsg As String) As Boolean
        Try
            Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
            Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode, v_intIndex As Long, i, v_intCount As Integer
            Dim v_strFLDNAME As String, v_strFLDDEFNAME As String, v_strDATATYPE As String, v_strFLDVALUE As String
            Dim v_strERRMSG, v_strENERRMSG, v_strOPERATOR, v_strVALEXP, v_strVALEXP2 As String, v_strACTYPE, v_strDESC As String
            Dim v_dtVALEXP, v_dtVALEXP2, v_dtFLDVALUE As Date, v_strCMDSQL As String
            Dim v_ctl As Control, v_attrFLDNAME As Xml.XmlAttribute, v_attrDATATYPE As Xml.XmlAttribute, v_objEval As New Evaluator
            Dim v_strTLTXCD As String

            'Tạo điện giao dịch
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

    'Hàm này được dùng để hiển thị lại điện giao dịch trả v�? từ trên HOST đối với giao dịch Submit 02 lần
    Private Function DisplayConfirm(ByVal v_xmlDocument As Xml.XmlDocument) As Boolean
        'Try
        '    Dim v_dataElement As Xml.XmlElement, v_nodetxData As Xml.XmlNode, v_ctl As Control, v_objAccount As CAccountEntry
        '    Dim v_strPRINTINFO, v_strPRINTNAME, v_strPRINTVALUE, v_strFLDNAME As String, i, j, v_intIndex As Integer
        '    'Hiển thị lại màn hình
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
        'Khởi tạo kích thước form và load resource
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)
        DoResizeForm()
        ResetScreen(Me)

        'Thiết lập các thuộc tính ban đầu cho form
        'Me.pnOrder.Enabled = False
        For Each v_ctl As Control In Me.pnOrder.Controls
            If TypeOf (v_ctl) Is TextBox Then
                CType(v_ctl, TextBox).ReadOnly = True
            End If
            If TypeOf (v_ctl) Is ComboBox Then
                CType(v_ctl, ComboBox).Enabled = True
            End If
        Next
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL As String, v_strObjMsg As String

        v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE A, SYSVAR S  WHERE CDTYPE='OD' AND TRIM(CDNAME)='TRADEPLACE' AND VARNAME ='ODSEND_TRADEPLACE' AND INSTR(VARVALUE,CDVAL)>0 ORDER BY LSTODR"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        FillComboEx(v_strObjMsg, cboTradePlace, "", Me.UserLanguage)

        v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='OD' AND TRIM(CDNAME)='ODKIND' ORDER BY LSTODR"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        FillComboEx(v_strObjMsg, cboODKIND, "", Me.UserLanguage)

        v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='SA' AND TRIM(CDNAME)='PRICETYPE' AND CDUSER='Y' ORDER BY LSTODR"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        FillComboEx(v_strObjMsg, cboPRICETYPE, "", Me.UserLanguage)

        v_strCmdSQL = "SELECT VALUE, DISPLAY, DISPLAY EN_DISPLAY FROM (SELECT ab.brid VALUE,to_char(ab.brname) display FROM brgrp ab UNION ALL select '9999' VALUE,'ALL' DISPLAY  from dual) WHERE 0=0 order by display"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        FillComboEx(v_strObjMsg, cboBranch, "", Me.UserLanguage)

        If cboTradePlace.Items.Count > 0 Then cboTradePlace.SelectedIndex = -1
        If cboTradePlace.Items.Count > 0 Then cboODKIND.SelectedIndex = 0
        If cboTradePlace.Items.Count > 0 Then cboPRICETYPE.SelectedIndex = 0
        If cboTradePlace.Items.Count > 0 Then cboBranch.SelectedIndex = 0

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
        '    Me.lblNumChecked.Text = v_intNumSelected.ToString & "/" & v_intNum.ToString & " dòng được ch�?n!"
        'End If

        setBlankGridRowValue()
        If Me.ODSendGrid.DataRows.Count > 0 Then
            ODSendGrid.CurrentRow = Me.ODSendGrid.DataRows(0)
            setGridRowValue(ODSendGrid.DataRows(0))
        End If
        setControlValue()
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
            'pnODSendInfo.Top = pnOrder.Top
            'pnODSendInfo.Left = pnOrder.Left
            'pnODSendInfo.Height = pnODSendInfo.Height + pnOrder.Height + 10

            'ODSendGrid.Columns("CHECKALL").CanBeSorted = False
            ODSendGrid.Columns("EXECTYPE_VAL").CanBeSorted = False
            ODSendGrid.Columns("AFACCTNO").CanBeSorted = False
            ODSendGrid.Columns("CUSTODYCD").CanBeSorted = False
            ODSendGrid.Columns("EXECTYPE").CanBeSorted = False
            ODSendGrid.Columns("SYMBOL").CanBeSorted = False
            ODSendGrid.Columns("QUOTEPRICE").CanBeSorted = False
            ODSendGrid.Columns("LIMITPRICE").CanBeSorted = False
            ODSendGrid.Columns("OODSTATUS").CanBeSorted = False
            ODSendGrid.Columns("PRICE").CanBeSorted = False
            ODSendGrid.Columns("QTTY").CanBeSorted = False
            ODSendGrid.Columns("ORDERID").CanBeSorted = False
            ODSendGrid.Columns("ORDERQTTY").CanBeSorted = False
            ODSendGrid.Columns("DESC_PRICETYPE").CanBeSorted = False
            ODSendGrid.Columns("CURRPRICE").CanBeSorted = False
            ODSendGrid.Columns("MATCHTYPE").CanBeSorted = False
            ODSendGrid.Columns("NORK").CanBeSorted = False
            ODSendGrid.Columns("CODEID").CanBeSorted = False
            ODSendGrid.Columns("SECUREDRATIOMIN").CanBeSorted = False
            ODSendGrid.Columns("SECUREDRATIOMAX").CanBeSorted = False
            'ODSendGrid.Columns("TYP_BRATIO").CanBeSorted = False
            'ODSendGrid.Columns("AF_BRATIO").CanBeSorted = False
            ODSendGrid.Columns("CIACCTNO").CanBeSorted = False
            ODSendGrid.Columns("SEACCTNO").CanBeSorted = False
            ODSendGrid.Columns("PARVALUE").CanBeSorted = False
            ODSendGrid.Columns("NORK").CanBeSorted = False
            ODSendGrid.Columns("MATCHTYPE").CanBeSorted = False
            ODSendGrid.Columns("ORSTATUS").CanBeSorted = False

            'pnOrder.Visible = pv_enable
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
            v_strClause = Trim(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ORDERID").Value)
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strClause, "CheckOrderStatus", , , , IpAddress)
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            v_lngErrorCode = v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)

            'Kiểm tra thông tin và xử lý lỗi (nếu có) từ message trả v�?            
            If v_lngErrorCode <> ERR_SYSTEM_OK Then
                'Thông báo lỗi
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                Cursor.Current = Cursors.Default
                MsgBox(v_strErrorMessage, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)
                GetOrder()
                Exit Sub
            End If

            Dim v_frm As New frmOrderSendingConfirm(Me.UserLanguage)
            'v_strFullObjName = ModuleCode & "." & ObjectName

            'v_frm.ExeFlag = pv_intExecFlag
            v_frm.BranchId = BranchId
            v_frm.TellerID = TellerId
            v_frm.TellerType = TellerType
            v_frm.UserLanguage = UserLanguage

            v_frm.TxDate = Trim(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TXDATE").Value)
            v_frm.TxNum = Trim(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TXNUM").Value)
            v_frm.AFAccount = Trim(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AFACCTNO").Value)
            v_frm.CustodyCode = Trim(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("CUSTODYCD").Value)
            v_frm.CustomerFullName = Trim(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("FULLNAME").Value)
            v_frm.Symbol = Trim(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("SYMBOL").Value)
            v_frm.Issuer = Trim(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ISSUERS").Value)
            v_frm.Price = Trim(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("QUOTEPRICE").Value)
            v_frm.OldAmendmentPrice = Trim(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("OODPRICE").Value)
            v_frm.OldAmendmentQtty = Trim(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("OODQTTY").Value)
            v_frm.AmendmentPrice = Trim(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("OODPRICE").Value)
            v_frm.AmendmentQtty = Trim(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("OODQTTY").Value)
            v_frm.Quantity = Trim(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ORDERQTTY").Value)
            v_frm.ExecQtty = Trim(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("EXECQTTY").Value)
            v_frm.OrderID = Trim(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ORDERID").Value)
            v_frm.RefOrderID = Trim(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("REFORDERID").Value)
            v_frm.FullName = Trim(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("FULLNAME").Value)
            v_frm.ExecType = Trim(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("EXECTYPE").Value)

            'v_frm.Via = Trim(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("VIA").Value)
            'v_frm.TradePlace = Trim(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TRADEPLACE").Value)
            v_frm.PriceType = Trim(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("PRICETYPE").Value)
            v_frm.TLTXCD = Trim(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TLTXCD").Value)
            v_frm.Bratio = Trim(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("BRATIO").Value)
            v_frm.OldBratio = Trim(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("OLDBRATIO").Value)
            v_frm.TradeUnit = Trim(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TRADEUNIT").Value)
            v_frm.SEAcctNo = Trim(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("SEACCTNO").Value)
            v_frm.OrderStatus = Trim(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ORSTATUS").Value)
            v_frm.OutOrderStatus = Trim(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("OODSTATUS").Value)
            v_frm.TradeLot = Trim(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TRADELOT").Value)
            v_frm.MapOrder = Trim(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("MAPORDERID").Value)
            v_frm.IpAddress = Me.IpAddress
            v_frm.WsName = Me.WsName
            v_frm.BusDate = Me.BusDate

            If Strings.Left(Trim(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("MATCHTYPE").Value), 1) = "P" Then
                v_frm.ClearDays = Trim(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("CLEARDAY").Value)
                v_frm.TxDesc = Trim(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TXDESC").Value)
                v_frm.BOrS = "P." & Trim(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("EXECTYPE").Value)
            Else
                v_frm.ClearDays = String.Empty
                v_frm.TxDesc = Trim(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TXDESC").Value)
                v_frm.BOrS = Trim(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow).Cells("EXECTYPE").Value)
            End If

            v_frm.ShowDialog()

            mv_intCurrentRow = mv_intCurrentRow + v_frm.mv_intStep
            GetOrder()

        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
#End Region

#Region " Event "
    Private Sub ODSendCurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'Hiển thị thông tin lên màn hình
        If (ODSendGrid.CurrentRow Is Nothing) Then
            Exit Sub
        End If
        setGridRowValue(CType(ODSendGrid.CurrentRow, Xceed.Grid.DataRow))
        setControlValue()
    End Sub

    Private Sub ODSendSelectedRowChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'Hiển thị thông tin lên màn hình
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
        '    Me.lblNumChecked.Text = v_intNumSelected.ToString & "/" & v_intNum.ToString & " dòng được ch�?n!"
        'End If

    End Sub

    Private Sub btnSendAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendAll.Click
        OnView(sender, e)
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    'Private Sub cboCheckAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Dim i, v_intNumSelected, v_intNum As Integer
    '    If Me.cboCheckAll.Checked = True Then
    '        v_intNumSelected = ODSendGrid.DataRows.Count
    '        v_intNum = ODSendGrid.DataRows.Count
    '        If Me.ODSendGrid.DataRows.Count > 0 Then
    '            For i = 0 To Me.ODSendGrid.DataRows.Count - 1
    '                ODSendGrid.DataRows(i).Cells("CHECKALL").Value = "X"
    '            Next
    '        End If
    '        If UserLanguage = "EN" Then
    '            Me.lblNumChecked.Text = v_intNumSelected.ToString & "/" & v_intNum.ToString & " items seleted!"
    '        Else
    '            Me.lblNumChecked.Text = v_intNumSelected.ToString & "/" & v_intNum.ToString & " dòng được ch�?n!"
    '        End If
    '    Else
    '        v_intNumSelected = 0
    '        v_intNum = ODSendGrid.DataRows.Count
    '        If Me.ODSendGrid.DataRows.Count > 0 Then
    '            For i = 0 To Me.ODSendGrid.DataRows.Count - 1
    '                ODSendGrid.DataRows(i).Cells("CHECKALL").Value = ""
    '            Next
    '        End If
    '        If UserLanguage = "EN" Then
    '            Me.lblNumChecked.Text = v_intNumSelected.ToString & "/" & v_intNum.ToString & " items seleted!"
    '        Else
    '            Me.lblNumChecked.Text = v_intNumSelected.ToString & "/" & v_intNum.ToString & " dòng được ch�?n!"
    '        End If
    '    End If
    'End Sub

    Private Sub frmODSend_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                OnClose()
            Case Keys.F5
                GetOrder()
        End Select
    End Sub
    Private Sub frmODSend_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'mv_strSQLCMD = "SELECT CD1.CDCONTENT EXECTYPE, CD1.CDVAL EXECTYPE_VAL , CF.CUSTODYCD, SEC.SYMBOL, SEC.CODEID, CD5.CDCONTENT DESC_ORSTATUS, " & _
        '   "(CASE WHEN MST.PRICETYPE='LO' THEN MST.QUOTEPRICE WHEN MST.PRICETYPE='MO' THEN SEC.CURRPRICE " & _
        '   "WHEN MST.PRICETYPE='SL' THEN MST.LIMITPRICE WHEN MST.PRICETYPE='SM' THEN SEC.CURRPRICE ELSE SEC.CURRPRICE END) PRICE, " & _
        '   "MST.ORDERQTTY-MST.EXECQTTY-MST.REMAINQTTY QTTY,  " & _
        '   "MST.ORDERID, MST.ORDERQTTY, CD2.CDCONTENT DESC_PRICETYPE, MST.QUOTEPRICE, MST.LIMITPRICE, SEC.CURRPRICE, " & _
        '   "CD3.CDCONTENT DESC_MATCHTYPE, CD4.CDCONTENT DESC_NORK, SECMST.PARVALUE, " & _
        '   "MST.CODEID, SEC.SECUREDRATIOMIN, SEC.SECUREDRATIOMAX, TYP.BRATIO TYP_BRATIO, AF.BRATIO AF_BRATIO, AF.ACCTNO AFACCTNO, AF.ACTNO CIACCTNO, AF.ACCTNO || MST.CODEID SEACCTNO, MST.NORK, MST.MATCHTYPE " & _
        '   "FROM CFMAST CF, AFMAST AF, ODTYPE TYP, ODMAST MST, SBSECURITIES SECMST, SECURITIES_INFO SEC, ALLCODE CD1, ALLCODE CD2, ALLCODE CD3, ALLCODE CD4, ALLCODE CD5 " & _
        '   "WHERE (MST.ORSTATUS <> '5' AND MST.ORSTATUS <> '7') AND MST.DELTD<>'Y' AND MST.ORDERQTTY-MST.EXECQTTY-MST.REMAINQTTY > 0 AND MST.CODEID=SEC.CODEID AND mst.expdate>=TO_DATE('" & Me.BusDate & "', '" & gc_FORMAT_DATE & "') " & _
        '   "AND SECMST.CODEID=SEC.CODEID AND MST.ACTYPE=TYP.ACTYPE AND TRIM(MST.AFACCTNO)=TRIM(AF.ACCTNO) AND (AF.CUSTID)=(CF.CUSTID) " & _
        '   "AND CD1.CDTYPE='OD' AND CD1.CDNAME='EXECTYPE' AND CD1.CDVAL=MST.EXECTYPE  " & _
        '   "AND CD2.CDTYPE='OD' AND CD2.CDNAME='PRICETYPE' AND CD2.CDVAL=MST.PRICETYPE  " & _
        '   "AND CD3.CDTYPE='OD' AND CD3.CDNAME='MATCHTYPE' AND CD3.CDVAL=MST.MATCHTYPE  " & _
        '   "AND CD4.CDTYPE='OD' AND CD4.CDNAME='NORK' AND CD4.CDVAL=MST.NORK " & _
        '   "AND CD5.CDTYPE='OD' AND CD5.CDNAME='ORSTATUS' AND CD5.CDVAL=MST.ORSTATUS  "
        'LoadODSend(mv_strSQLCMD)
        GetOrder()
        If Me.Action = "N" Then
            Me.cboODKIND.Visible = False
            Me.lblODKIND.Visible = False
            Me.cboBranch.Visible = True
            Me.lblBranch.Visible = True
        Else
            Me.cboODKIND.Visible = True
            Me.lblODKIND.Visible = True
            Me.cboBranch.Visible = False
            Me.lblBranch.Visible = False

        End If
        ShowSearchFunction(mv_blnOrderSendingEx)
    End Sub
    Private Sub cboTradePlace_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTradePlace.SelectedValueChanged
        GetOrder()
    End Sub
    Private Sub cboODKIND_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboODKIND.SelectedIndexChanged
        GetOrder()
    End Sub
    Private Sub cboPRICETYPE_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPRICETYPE.SelectedValueChanged
        GetOrder()
    End Sub
#End Region

    Private Sub cboBranch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBranch.SelectedIndexChanged
        GetOrder()
    End Sub
End Class
