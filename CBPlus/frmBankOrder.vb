Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports CommonLibrary
Imports System.Collections
Imports AppCore
Imports AppCore.modCoreLib
Imports System.IO



Public Class frmBankOrder
    Inherits System.Windows.Forms.Form

    Friend WithEvents ResultGrid As New GridEx
    Private ResourceManager As Resources.ResourceManager

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


    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents pnODSendInfo As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.pnlTitle = New System.Windows.Forms.Panel
        Me.pnODSendInfo = New System.Windows.Forms.Panel
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnExport = New System.Windows.Forms.Button
        Me.btnSubmit = New System.Windows.Forms.Button
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
        'pnODSendInfo
        '
        Me.pnODSendInfo.BackColor = System.Drawing.SystemColors.Control
        Me.pnODSendInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnODSendInfo.Location = New System.Drawing.Point(8, 56)
        Me.pnODSendInfo.Name = "pnODSendInfo"
        Me.pnODSendInfo.Size = New System.Drawing.Size(776, 480)
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
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(623, 545)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(75, 23)
        Me.btnExport.TabIndex = 29
        Me.btnExport.Tag = "btnExport"
        Me.btnExport.Text = "btnExport"
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(466, 545)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(151, 23)
        Me.btnSubmit.TabIndex = 30
        Me.btnSubmit.Tag = "btnSubmit"
        Me.btnSubmit.Text = "&Submit"
        '
        'frmBankOrder
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(794, 575)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.pnODSendInfo)
        Me.Controls.Add(Me.pnlTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Name = "frmBankOrder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmBankOrder"
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Declare constant and variables "
    Const c_ResourceManager = "_DIRECT.frmBankOrder-"

    Dim mv_strEXECTYPE, mv_strEXECTYPE_VAL, mv_strCUSTODYCD, mv_strSYMBOL, mv_strBANKNAME, mv_strFULLNAME, mv_strACCTNO, mv_strIDCODE, mv_strCOREBANK, mv_strBANKACCTNO As String
    Dim mv_strOODSTATUS, mv_strPRICE, mv_strQTTY, mv_strORDERID, mv_strORDERQTTY, mv_strDESC_PRICETYPE, mv_strQUOTEPRICE, mv_strLIMITPRICE As String
    Dim mv_strCURRPRICE, mv_strMATCHTYPE, mv_strNORK, mv_strCODEID, mv_strSECURERATIOTMIN, mv_strSECURERATIOMAX, mv_strTYP_BRATIO, mv_strAF_BRATIO As String


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

        Dim v_intODKIND As Int16



        If Action = "A" Then

            v_strCmdInquiry = "SELECT MST.AUTOID, MST.VERSION,MST.VERSIONLOCAL, MST.TXDATE, MST.AFFECTDATE,DTL.CRDATE,MST.REFBANK||':'||A2.CDCONTENT REFBANK,MST.REFBANK BANKQUEUE,MST.TRFCODE, MST.CREATETST, MST.SENDTST" & ControlChars.CrLf _
                                & ",FN_CRB_GETVOUCHERNO(MST.TRFCODE, MST.TXDATE, MST.VERSION) VOUCHERNO,DTL.AMT,DTL.ITEMCNT," & ControlChars.CrLf _
                                & "CASE WHEN MST.STATUS='E' AND DTL.STATUS='Z' THEN 'D' ELSE MST.STATUS END STATUS," & ControlChars.CrLf _
                            & "CASE WHEN (MST.STATUS='S' AND MST.AFFECTDATE>(SELECT TO_DATE(SYS.VARVALUE,'DD/MM/RRRR')" & ControlChars.CrLf _
                             & "FROM SYSVAR SYS WHERE SYS.VARNAME='CURRDATE'))" & ControlChars.CrLf _
                                       & "OR MST.STATUS IN ('F','C','B') THEN 'Y'" & ControlChars.CrLf _
                                 & "WHEN MST.STATUS='H' AND DTL.STATUS='Z' THEN 'Y'" & ControlChars.CrLf _
                                 & "WHEN CASE WHEN MST.STATUS='E' AND DTL.STATUS='Z' THEN 'D' ELSE MST.STATUS END='D' THEN 'Y'" & ControlChars.CrLf _
                                    & "Else 'N' END CHECKSTATUS," & ControlChars.CrLf _
                            & "A0.CDCONTENT DESC_STATUS, A1.CDCONTENT DESC_TRFCODE, ERR.ERRDESC," & ControlChars.CrLf _
                            & "DECODE(MST.STATUS,'P','Y','N') APRALLOW, DECODE(MST.STATUS,'P','Y','N') EDITALLOW," & ControlChars.CrLf _
                            & "CASE WHEN MST.STATUS IN ('B') THEN 'N' ELSE 'Y' END DISPALLOW" & ControlChars.CrLf _
                            & "FROM CRBTRFLOG MST, ALLCODE A0, ALLCODE A1,DEFERROR ERR,CRBDEFACCT CRA,ALLCODE A2," & ControlChars.CrLf _
                            & "(" & ControlChars.CrLf _
                                & "SELECT DTL.BANKCODE,DTL.VERSION,DTL.TRFCODE,DTL.TXDATE,MAX(REQ.TXDATE) CRDATE,SUM(DTL.AMT) AMT,COUNT(DTL.AUTOID) ITEMCNT," & ControlChars.CrLf _
                                & "MAX(CASE WHEN DTL.STATUS IN ('D','B') THEN 'Z' ELSE 'A' END) STATUS" & ControlChars.CrLf _
                                & "FROM CRBTRFLOGDTL DTL,CRBTXREQ REQ" & ControlChars.CrLf _
                                        & "WHERE(DTL.REFREQID = REQ.REQID)" & ControlChars.CrLf _
                                & "GROUP BY DTL.BANKCODE,DTL.VERSION,DTL.TRFCODE,DTL.TXDATE" & ControlChars.CrLf _
                            & ") DTL" & ControlChars.CrLf _
                            & "WHERE A0.CDTYPE='RM' AND A0.CDNAME='TRFLOGSTS' AND A0.CDVAL=(CASE WHEN MST.STATUS='E' AND DTL.STATUS='Z' THEN 'D' ELSE MST.STATUS END)" & ControlChars.CrLf _
                            & "AND A1.CDTYPE='SY' AND A1.CDNAME='TRFCODE' AND A1.CDVAL=MST.TRFCODE" & ControlChars.CrLf _
                            & "AND MST.REFBANK=A2.CDVAL AND A2.CDNAME='BANKNAME' AND A2.CDTYPE='CF'" & ControlChars.CrLf _
                            & "AND MST.TRFCODE=CRA.TRFCODE" & ControlChars.CrLf _
                            & "AND MST.REFBANK=CRA.REFBANK AND cspks_rmproc.is_number(CRA.MSGID)=1" & ControlChars.CrLf _
                            & "AND MST.REFBANK=DTL.BANKCODE AND MST.TRFCODE=DTL.TRFCODE AND MST.TXDATE=DTL.TXDATE" & ControlChars.CrLf _
                            & "AND MST.VERSION=DTL.VERSION AND MST.ERRCODE=ERR.ERRNUM(+)" & ControlChars.CrLf _
                            & "AND MST.VERSION IS NOT NULL" & ControlChars.CrLf _
                            & "AND MST.VERSIONLOCAL IS NOT NULL AND MST.VERSIONLOCAL <>'---' AND cspks_rmproc.is_number(CRA.MSGID)=1 AND (MST.STATUS IN ('S') or (MST.STATUS = 'E'))" & ControlChars.CrLf _
                            & "ORDER BY MST.TXDATE DESC,MST.AFFECTDATE DESC,MST.REFBANK,MST.VERSION DESC"


        Else
            v_strCmdInquiry = "SELECT MST.AUTOID, MST.VERSION,MST.VERSIONLOCAL, MST.TXDATE, MST.AFFECTDATE,DTL.CRDATE,MST.REFBANK||':'||A2.CDCONTENT REFBANK,MST.REFBANK BANKQUEUE,MST.TRFCODE, MST.CREATETST, MST.SENDTST," & ControlChars.CrLf _
                               & "FN_CRB_GETVOUCHERNO(MST.TRFCODE, MST.TXDATE, MST.VERSION) VOUCHERNO,DTL.AMT,DTL.ITEMCNT," & ControlChars.CrLf _
                               & "CASE WHEN MST.STATUS='E' AND DTL.STATUS='Z' THEN 'D' ELSE MST.STATUS END STATUS," & ControlChars.CrLf _
                                & "CASE WHEN (MST.STATUS='S' AND MST.AFFECTDATE>(SELECT TO_DATE(SYS.VARVALUE,'DD/MM/RRRR')" & ControlChars.CrLf _
                                & "FROM SYSVAR SYS WHERE SYS.VARNAME='CURRDATE'))" & ControlChars.CrLf _
                                & "OR MST.STATUS IN ('F','C','B') THEN 'Y'" & ControlChars.CrLf _
                                & "WHEN MST.STATUS='H' AND DTL.STATUS='Z' THEN 'Y'" & ControlChars.CrLf _
                                & "WHEN CASE WHEN MST.STATUS='E' AND DTL.STATUS='Z' THEN 'D' ELSE MST.STATUS END='D' THEN 'Y'" & ControlChars.CrLf _
                                & "Else 'N' END CHECKSTATUS," & ControlChars.CrLf _
                               & "A0.CDCONTENT DESC_STATUS, A1.CDCONTENT DESC_TRFCODE, ERR.ERRDESC," & ControlChars.CrLf _
                           & "DECODE(MST.STATUS,'P','Y','N') APRALLOW, DECODE(MST.STATUS,'P','Y','N') EDITALLOW," & ControlChars.CrLf _
                           & "CASE WHEN MST.STATUS IN ('B') THEN 'N' ELSE 'Y' END DISPALLOW" & ControlChars.CrLf _
                           & "FROM CRBTRFLOG MST, ALLCODE A0, ALLCODE A1,DEFERROR ERR,CRBDEFACCT CRA,ALLCODE A2," & ControlChars.CrLf _
                           & "(" & ControlChars.CrLf _
                            & "SELECT DTL.BANKCODE,DTL.VERSION,DTL.TRFCODE,DTL.TXDATE,MAX(REQ.TXDATE) CRDATE,SUM(DTL.AMT) AMT,COUNT(DTL.AUTOID) ITEMCNT," & ControlChars.CrLf _
                             & "MAX(CASE WHEN DTL.STATUS IN ('D','B') THEN 'Z' ELSE 'A' END) STATUS" & ControlChars.CrLf _
                             & "FROM CRBTRFLOGDTL DTL,CRBTXREQ REQ" & ControlChars.CrLf _
                            & "WHERE(DTL.REFREQID = REQ.REQID)" & ControlChars.CrLf _
                            & "GROUP BY DTL.BANKCODE,DTL.VERSION,DTL.TRFCODE,DTL.TXDATE" & ControlChars.CrLf _
                           & ") DTL" & ControlChars.CrLf _
                           & "WHERE A0.CDTYPE='RM' AND A0.CDNAME='TRFLOGSTS' AND A0.CDVAL=(CASE WHEN MST.STATUS='E' AND DTL.STATUS='Z' THEN 'D' ELSE MST.STATUS END)" & ControlChars.CrLf _
                           & "AND A1.CDTYPE='SY' AND A1.CDNAME='TRFCODE' AND A1.CDVAL=MST.TRFCODE" & ControlChars.CrLf _
                           & "AND MST.REFBANK=A2.CDVAL AND A2.CDNAME='BANKNAME' AND A2.CDTYPE='CF'" & ControlChars.CrLf _
                           & "AND MST.TRFCODE=CRA.TRFCODE" & ControlChars.CrLf _
                           & "AND MST.REFBANK=CRA.REFBANK AND cspks_rmproc.is_number(CRA.MSGID)=1" & ControlChars.CrLf _
                           & "AND MST.REFBANK=DTL.BANKCODE AND MST.TRFCODE=DTL.TRFCODE AND MST.TXDATE=DTL.TXDATE" & ControlChars.CrLf _
                           & "AND MST.VERSION=DTL.VERSION AND MST.ERRCODE=ERR.ERRNUM(+)" & ControlChars.CrLf _
                           & "AND MST.VERSION IS NOT NULL" & ControlChars.CrLf _
                           & "AND MST.VERSIONLOCAL IS NOT NULL AND MST.VERSIONLOCAL <>'---' AND cspks_rmproc.is_number(CRA.MSGID)=1 AND (MST.STATUS IN ('S') or (MST.STATUS = 'E'))" & ControlChars.CrLf _
                           & "ORDER BY MST.TXDATE DESC,MST.AFFECTDATE DESC,MST.REFBANK,MST.VERSION DESC"



        End If
        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strCmdInquiry)
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        v_ws.Message(v_strObjMsg)

        FillDataGrid(ResultGrid, v_strObjMsg, "")


        If mv_intCurrentRow >= ResultGrid.DataRows.Count Then mv_intCurrentRow = 0
        If ResultGrid.DataRows.Count > 0 Then
            ResultGrid.CurrentRow = ResultGrid.DataRows(mv_intCurrentRow)
            ResultGrid.SelectedRows.Clear()
            ResultGrid.SelectedRows.Add(ResultGrid.CurrentRow)
            'btnConnect.Focus()
        End If

    End Sub
    Private Sub InitializeGrid()
        'Khá»Ÿi táº¡o Grid contacts
        ResultGrid = New GridEx
        Dim v_cmrContactsHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrContactsHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrContactsHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        ResultGrid.FixedHeaderRows.Add(v_cmrContactsHeader)

        ResultGrid.Columns.Add(New Xceed.Grid.Column("VERSION", GetType(System.String)))
        ResultGrid.Columns.Add(New Xceed.Grid.Column("VERSIONLOCAL", GetType(System.String)))
        ResultGrid.Columns.Add(New Xceed.Grid.Column("TXDATE", GetType(System.String)))
        ResultGrid.Columns.Add(New Xceed.Grid.Column("AFFECTDATE", GetType(System.String)))
        ResultGrid.Columns.Add(New Xceed.Grid.Column("CRDATE", GetType(System.String)))
        ResultGrid.Columns.Add(New Xceed.Grid.Column("REFBANK", GetType(System.String)))
        ResultGrid.Columns.Add(New Xceed.Grid.Column("TRFCODE", GetType(System.String)))
        ResultGrid.Columns.Add(New Xceed.Grid.Column("AMT", GetType(System.String)))
        ResultGrid.Columns.Add(New Xceed.Grid.Column("CREATETST", GetType(System.String)))
        ResultGrid.Columns.Add(New Xceed.Grid.Column("SENDTST", GetType(System.String)))
        ResultGrid.Columns.Add(New Xceed.Grid.Column("DESC_STATUS", GetType(System.String)))
        ResultGrid.Columns.Add(New Xceed.Grid.Column("ERRDESC", GetType(System.String)))
        ResultGrid.Columns.Add(New Xceed.Grid.Column("CHECKSTATUS", GetType(System.String)))



        'Khai bao Resource
        ResultGrid.Columns("VERSION").Title = mv_ResourceManager.GetString("VERSION")
        ResultGrid.Columns("VERSIONLOCAL").Title = mv_ResourceManager.GetString("VERSIONLOCAL")
        ResultGrid.Columns("TXDATE").Title = mv_ResourceManager.GetString("TXDATE")
        ResultGrid.Columns("AFFECTDATE").Title = mv_ResourceManager.GetString("AFFECTDATE")
        ResultGrid.Columns("CRDATE").Title = mv_ResourceManager.GetString("CRDATE")
        ResultGrid.Columns("REFBANK").Title = mv_ResourceManager.GetString("REFBANK")
        ResultGrid.Columns("TRFCODE").Title = mv_ResourceManager.GetString("TRFCODE")
        ResultGrid.Columns("AMT").Title = mv_ResourceManager.GetString("AMT")
        ResultGrid.Columns("CREATETST").Title = mv_ResourceManager.GetString("CREATETST")
        ResultGrid.Columns("SENDTST").Title = mv_ResourceManager.GetString("SENDTST")
        ResultGrid.Columns("DESC_STATUS").Title = mv_ResourceManager.GetString("DESC_STATUS")
        ResultGrid.Columns("CHECKSTATUS").Title = mv_ResourceManager.GetString("CHECKSTATUS")
       


        Me.pnODSendInfo.Controls.Clear()
        Me.pnODSendInfo.Controls.Add(ResultGrid)
        ResultGrid.Dock = Windows.Forms.DockStyle.Fill
        'AddHandler ResultGrid.SelectedRowsChanged, AddressOf ODSendCurrentCellChanged
        If Me.ResultGrid.DataRowTemplate.Cells.Count >= 0 Then
            For i As Integer = 1 To Me.ResultGrid.DataRowTemplate.Cells.Count - 1
                AddHandler ResultGrid.DataRowTemplate.Cells(i).DoubleClick, AddressOf OnView
            Next
        End If



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

            v_strClause = Trim(CType(ResultGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ORDERID").Value)

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
            If Not ResultGrid Is Nothing And Len(pv_strSQLCMD) > 0 Then
                'Remove cÃ¡c báº£n ghi cÅ©
                ResultGrid.DataRows.Clear()
                Dim v_strSQL As String = pv_strSQLCMD
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                Dim v_strResourceManager As String

                FillDataGrid(ResultGrid, v_strObjMsg, "")

                If Me.ResultGrid.DataRows.Count > 0 Then
                    ResultGrid.CurrentRow = Me.ResultGrid.DataRows(0)
                    'setGridRowValue(ResultGrid.DataRows(0))
                End If

            End If
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
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

    Protected Overridable Function InitDialog()
        'Khá»Ÿi táº¡o kÃ­ch thÆ°á»›c form vÃ  load resource
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)
        DoResizeForm()


        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL As String, v_strObjMsg As String



        setBlankGridRowValue()
    End Function

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click

        Try
            Dim v_dlgSave As New SaveFileDialog
            v_dlgSave.Filter = "Text files (*.txt)|*.txt|Excel files (*.xls)|*.xls|All files (*.*)|*.*"
            v_dlgSave.RestoreDirectory = True
            Dim v_res As DialogResult = v_dlgSave.ShowDialog(Me)
            If v_res = DialogResult.OK Then
                Dim v_strFileName As String = v_dlgSave.FileName
                Dim v_strData As String
                Dim v_streamWriter As New StreamWriter(v_strFileName, False, System.Text.Encoding.Unicode)

                If (ResultGrid.DataRows.Count > 0) Then
                    'Write file's header
                    v_strData = String.Empty
                    For idx As Integer = 0 To ResultGrid.Columns.Count - 1
                        If ResultGrid.Columns(idx).Visible Then
                            v_strData &= ResultGrid.Columns(idx).Title & vbTab
                        End If
                    Next
                    v_streamWriter.WriteLine(v_strData)

                    'Write data
                    For i As Integer = 0 To ResultGrid.DataRows.Count - 1
                        v_strData = String.Empty

                        For j As Integer = 0 To ResultGrid.DataRows(i).Cells.Count - 1
                            If ResultGrid.Columns(j).Visible Then
                                v_strData &= ResultGrid.DataRows(i).Cells(j).Value & vbTab
                            End If
                        Next
                        'Write data to the file
                        v_streamWriter.WriteLine(v_strData)
                    Next
                Else
                    MsgBox(mv_ResourceManager.GetString("NothingToExport"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Exit Sub
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

    Private Sub OnView(ByVal sender As Object, ByVal e As System.EventArgs)
        'Chuyển trạng thái core bank

        Dim v_ws
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strSQL As String

        Dim i As Integer
        If Me.ResultGrid.DataRows.Count > 0 Then
            For i = 0 To Me.ResultGrid.DataRows.Count - 1
                If ResultGrid.DataRows(i).Cells("BANKACCTNO").Value <> ResultGrid.DataRows(i).Cells("BANKNAME").Value Then
                    Dim v_strObjMsg As String = BuildXMLObjMsg(Me.BusDate, BranchId, , TellerId, gc_IsNotLocalMsg, _
                                                            gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionAdhoc, , _
                                                                       ResultGrid.DataRows(i).Cells("CUSTID").Value, "CheckBankAcctAuthorize", , , _
                                                                       ResultGrid.DataRows(i).Cells("CUSTODYCD").Value & "|" & _
                                                                       ResultGrid.DataRows(i).Cells("BANKACCTNO").Value & "|" & _
                                                                       ResultGrid.DataRows(i).Cells("BANKNAME").Value)
                    v_ws = New BDSDeliveryManagement
                    Dim v_strErrorSource, v_strErrorMessage As String
                    Dim v_lngError As Long = v_ws.Message(v_strObjMsg)
                    If v_lngError <> ERR_SYSTEM_OK Then
                        ResultGrid.DataRows(i).Cells("STATUS").Value = "Chưa kích hoạt"
                    Else
                        ResultGrid.DataRows(i).Cells("STATUS").Value = "Đã kích hoạt"
                    End If
                End If

            Next

        End If
    End Sub
#End Region


#Region " Event "
    Private Sub ODSendCurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'Hiá»ƒn thá»‹ thÃ´ng tin lÃªn mÃ n hÃ¬nh
        If (ResultGrid.CurrentRow Is Nothing) Then
            Exit Sub
        End If
        'setGridRowValue(CType(ResultGrid.CurrentRow, Xceed.Grid.DataRow))

    End Sub

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        OnView(sender, e)


    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub


    Private Sub frmODSend_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load



    End Sub
    Private Sub cboTradePlace_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ExecuteGetBatchStsProcess()
    End Sub
    Private Sub cboODKIND_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ExecuteGetBatchStsProcess()
    End Sub
    Private Sub cboPRICETYPE_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ExecuteGetBatchStsProcess()
    End Sub
#End Region

    Private Sub cboBranch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ExecuteGetBatchStsProcess()
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
                GetOrder()
                Exit Sub
            Else
                GetOrder()
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
    Friend WithEvents btnExport As System.Windows.Forms.Button

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        ExecuteGetBatchStsProcess()
    End Sub
End Class
