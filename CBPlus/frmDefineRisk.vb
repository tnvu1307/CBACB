Imports AppCore
Imports CommonLibrary
Imports System.Xml.XmlNode
Imports System.Xml
Imports TestBase64
Imports ZetaCompressionLibrary
Imports System.IO
Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports System.Collections
Imports AppCore.ComboBoxEx
Public Class frmDefineRisk
    Inherits System.Windows.Forms.Form
    Friend WithEvents SYSVARGrid As New GridEx
    Friend WithEvents MarginSECGrid As New GridEx
    Friend WithEvents SERISKGrid As New GridEx
    Friend WithEvents IRRATEGrid As New GridEx
    Friend WithEvents ACTYPEGrid As New GridEx
    Friend WithEvents ICCFGrid As New GridEx

#Region " Declare constant and variables "
    Const c_ResourceManager = "_DIRECT.frmDefineRisk-"
    Private v_xmlDefACTYPEDocument As New Xml.XmlDocument
    Private v_xmlDefSYSVARDocument As New Xml.XmlDocument
    Private v_xmlDefMarginSECDocument As New Xml.XmlDocument
    Private v_xmlDefSEINFODocument As New Xml.XmlDocument
    Private v_xmlDefIRRATEDocument As New Xml.XmlDocument
    Private v_xmlDefICCFDocument As New Xml.XmlDocument

    Private mv_strXmlMessageData As String
    Private mv_strLocalObject As String
    Private mv_strLanguage As String
    Private mv_strBranchId As String
    Private mv_strTellerId As String
    Private mv_strIpAddress As String
    Private mv_strWsName As String
    Private mv_strBusDate As String
    Private mv_strTxDate As String = String.Empty
    Private mv_strTxNum As String = String.Empty
    Private ResourceManager As Resources.ResourceManager
#End Region

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New()

        InitializeComponent()
        mv_strLanguage = pv_strLanguage
        ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        'InitializeGrid()
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
    Friend WithEvents tabDefineRisk As System.Windows.Forms.TabControl
    Protected WithEvents Panel1 As System.Windows.Forms.Panel
    Protected WithEvents lblCaption As System.Windows.Forms.Label
    Friend WithEvents btnVIEW As System.Windows.Forms.Button
    Friend WithEvents btnEDIT As System.Windows.Forms.Button
    Friend WithEvents btnCLOSE As System.Windows.Forms.Button
    Friend WithEvents btnIMPORT As System.Windows.Forms.Button
    Friend WithEvents pnIRRATE As System.Windows.Forms.Panel
    Friend WithEvents TabSYSVAR As System.Windows.Forms.TabPage
    Friend WithEvents pnlSYSVAR As System.Windows.Forms.Panel
    Friend WithEvents pnSERISK As System.Windows.Forms.Panel
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents TabSERISK As System.Windows.Forms.TabPage
    Friend WithEvents TabIRRATE As System.Windows.Forms.TabPage
    Friend WithEvents tabPRODUCT As System.Windows.Forms.TabPage
    Friend WithEvents lblModule As System.Windows.Forms.Label
    Friend WithEvents pnlPRODUCT As System.Windows.Forms.Panel
    Friend WithEvents TabICCF As System.Windows.Forms.TabPage
    Friend WithEvents pnlICCF As System.Windows.Forms.Panel
    Friend WithEvents cboModule As AppCore.ComboBoxEx
    Friend WithEvents pnlMarginSec As System.Windows.Forms.Panel
    Friend WithEvents TabMarginSec As System.Windows.Forms.TabPage

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.tabDefineRisk = New System.Windows.Forms.TabControl
        Me.TabSYSVAR = New System.Windows.Forms.TabPage
        Me.pnlSYSVAR = New System.Windows.Forms.Panel
        Me.TabIRRATE = New System.Windows.Forms.TabPage
        Me.pnIRRATE = New System.Windows.Forms.Panel
        Me.TabSERISK = New System.Windows.Forms.TabPage
        Me.pnSERISK = New System.Windows.Forms.Panel
        Me.tabPRODUCT = New System.Windows.Forms.TabPage
        Me.cboModule = New AppCore.ComboBoxEx
        Me.pnlPRODUCT = New System.Windows.Forms.Panel
        Me.lblModule = New System.Windows.Forms.Label
        Me.TabICCF = New System.Windows.Forms.TabPage
        Me.pnlICCF = New System.Windows.Forms.Panel
        Me.TabMarginSec = New System.Windows.Forms.TabPage
        Me.pnlMarginSec = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblCaption = New System.Windows.Forms.Label
        Me.btnVIEW = New System.Windows.Forms.Button
        Me.btnEDIT = New System.Windows.Forms.Button
        Me.btnCLOSE = New System.Windows.Forms.Button
        Me.btnIMPORT = New System.Windows.Forms.Button
        Me.btnExport = New System.Windows.Forms.Button
        Me.tabDefineRisk.SuspendLayout()
        Me.TabSYSVAR.SuspendLayout()
        Me.TabIRRATE.SuspendLayout()
        Me.TabSERISK.SuspendLayout()
        Me.tabPRODUCT.SuspendLayout()
        Me.TabICCF.SuspendLayout()
        Me.TabMarginSec.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabDefineRisk
        '
        Me.tabDefineRisk.Controls.Add(Me.TabSYSVAR)
        Me.tabDefineRisk.Controls.Add(Me.TabIRRATE)
        Me.tabDefineRisk.Controls.Add(Me.TabSERISK)
        Me.tabDefineRisk.Controls.Add(Me.tabPRODUCT)
        Me.tabDefineRisk.Controls.Add(Me.TabICCF)
        Me.tabDefineRisk.Controls.Add(Me.TabMarginSec)
        Me.tabDefineRisk.Location = New System.Drawing.Point(4, 56)
        Me.tabDefineRisk.Name = "tabDefineRisk"
        Me.tabDefineRisk.SelectedIndex = 0
        Me.tabDefineRisk.Size = New System.Drawing.Size(784, 408)
        Me.tabDefineRisk.TabIndex = 14
        Me.tabDefineRisk.Tag = "tabDefineRisk"
        '
        'TabSYSVAR
        '
        Me.TabSYSVAR.Controls.Add(Me.pnlSYSVAR)
        Me.TabSYSVAR.Location = New System.Drawing.Point(4, 22)
        Me.TabSYSVAR.Name = "TabSYSVAR"
        Me.TabSYSVAR.Size = New System.Drawing.Size(776, 382)
        Me.TabSYSVAR.TabIndex = 2
        Me.TabSYSVAR.Tag = "TabSYSVAR"
        Me.TabSYSVAR.Text = "TabSYSVAR"
        '
        'pnlSYSVAR
        '
        Me.pnlSYSVAR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlSYSVAR.Location = New System.Drawing.Point(8, 8)
        Me.pnlSYSVAR.Name = "pnlSYSVAR"
        Me.pnlSYSVAR.Size = New System.Drawing.Size(760, 368)
        Me.pnlSYSVAR.TabIndex = 0
        Me.pnlSYSVAR.Tag = "pnlSYSVAR"
        '
        'TabIRRATE
        '
        Me.TabIRRATE.Controls.Add(Me.pnIRRATE)
        Me.TabIRRATE.Location = New System.Drawing.Point(4, 22)
        Me.TabIRRATE.Name = "TabIRRATE"
        Me.TabIRRATE.Size = New System.Drawing.Size(776, 382)
        Me.TabIRRATE.TabIndex = 1
        Me.TabIRRATE.Tag = "TabIRRATE"
        Me.TabIRRATE.Text = "TabIRRATE"
        '
        'pnIRRATE
        '
        Me.pnIRRATE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnIRRATE.Location = New System.Drawing.Point(6, 7)
        Me.pnIRRATE.Name = "pnIRRATE"
        Me.pnIRRATE.Size = New System.Drawing.Size(766, 373)
        Me.pnIRRATE.TabIndex = 1
        Me.pnIRRATE.Tag = "pnIRRATE"
        '
        'TabSERISK
        '
        Me.TabSERISK.Controls.Add(Me.pnSERISK)
        Me.TabSERISK.Location = New System.Drawing.Point(4, 22)
        Me.TabSERISK.Name = "TabSERISK"
        Me.TabSERISK.Size = New System.Drawing.Size(776, 382)
        Me.TabSERISK.TabIndex = 0
        Me.TabSERISK.Tag = "TabSERISK"
        Me.TabSERISK.Text = "TabSERISK"
        '
        'pnSERISK
        '
        Me.pnSERISK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnSERISK.Location = New System.Drawing.Point(8, 8)
        Me.pnSERISK.Name = "pnSERISK"
        Me.pnSERISK.Size = New System.Drawing.Size(764, 368)
        Me.pnSERISK.TabIndex = 0
        Me.pnSERISK.Tag = "pnSERISK"
        '
        'tabPRODUCT
        '
        Me.tabPRODUCT.Controls.Add(Me.cboModule)
        Me.tabPRODUCT.Controls.Add(Me.pnlPRODUCT)
        Me.tabPRODUCT.Controls.Add(Me.lblModule)
        Me.tabPRODUCT.Location = New System.Drawing.Point(4, 22)
        Me.tabPRODUCT.Name = "tabPRODUCT"
        Me.tabPRODUCT.Size = New System.Drawing.Size(776, 382)
        Me.tabPRODUCT.TabIndex = 3
        Me.tabPRODUCT.Text = "tabPRODUCT"
        '
        'cboModule
        '
        Me.cboModule.DisplayMember = "DISPLAY"
        Me.cboModule.Location = New System.Drawing.Point(139, 6)
        Me.cboModule.Name = "cboModule"
        Me.cboModule.Size = New System.Drawing.Size(237, 21)
        Me.cboModule.TabIndex = 3
        Me.cboModule.Tag = "cboModule"
        Me.cboModule.ValueMember = "VALUE"
        '
        'pnlPRODUCT
        '
        Me.pnlPRODUCT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPRODUCT.Location = New System.Drawing.Point(8, 40)
        Me.pnlPRODUCT.Name = "pnlPRODUCT"
        Me.pnlPRODUCT.Size = New System.Drawing.Size(760, 336)
        Me.pnlPRODUCT.TabIndex = 2
        '
        'lblModule
        '
        Me.lblModule.Location = New System.Drawing.Point(8, 8)
        Me.lblModule.Name = "lblModule"
        Me.lblModule.Size = New System.Drawing.Size(120, 23)
        Me.lblModule.TabIndex = 0
        Me.lblModule.Text = "Module"
        '
        'TabICCF
        '
        Me.TabICCF.Controls.Add(Me.pnlICCF)
        Me.TabICCF.Location = New System.Drawing.Point(4, 22)
        Me.TabICCF.Name = "TabICCF"
        Me.TabICCF.Size = New System.Drawing.Size(776, 382)
        Me.TabICCF.TabIndex = 4
        Me.TabICCF.Tag = "TabICCF"
        Me.TabICCF.Text = "TabICCF"
        '
        'pnlICCF
        '
        Me.pnlICCF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlICCF.Location = New System.Drawing.Point(8, 8)
        Me.pnlICCF.Name = "pnlICCF"
        Me.pnlICCF.Size = New System.Drawing.Size(764, 372)
        Me.pnlICCF.TabIndex = 0
        Me.pnlICCF.Tag = "pnlICCF"
        '
        'TabMarginSec
        '
        Me.TabMarginSec.Controls.Add(Me.pnlMarginSec)
        Me.TabMarginSec.Location = New System.Drawing.Point(4, 22)
        Me.TabMarginSec.Name = "TabMarginSec"
        Me.TabMarginSec.Size = New System.Drawing.Size(776, 382)
        Me.TabMarginSec.TabIndex = 5
        Me.TabMarginSec.Text = "TabMarginSec"
        '
        'pnlMarginSec
        '
        Me.pnlMarginSec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMarginSec.Location = New System.Drawing.Point(6, 5)
        Me.pnlMarginSec.Name = "pnlMarginSec"
        Me.pnlMarginSec.Size = New System.Drawing.Size(764, 372)
        Me.pnlMarginSec.TabIndex = 1
        Me.pnlMarginSec.Tag = "pnlMarginSec"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.lblCaption)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(792, 50)
        Me.Panel1.TabIndex = 15
        '
        'lblCaption
        '
        Me.lblCaption.AutoSize = True
        Me.lblCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaption.Location = New System.Drawing.Point(7, 16)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(62, 17)
        Me.lblCaption.TabIndex = 0
        Me.lblCaption.Tag = "lblCaption"
        Me.lblCaption.Text = "lblCaption"
        '
        'btnVIEW
        '
        Me.btnVIEW.Location = New System.Drawing.Point(552, 468)
        Me.btnVIEW.Name = "btnVIEW"
        Me.btnVIEW.TabIndex = 18
        Me.btnVIEW.Tag = "btnVIEW"
        Me.btnVIEW.Text = "btnVIEW"
        '
        'btnEDIT
        '
        Me.btnEDIT.Location = New System.Drawing.Point(632, 468)
        Me.btnEDIT.Name = "btnEDIT"
        Me.btnEDIT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnEDIT.TabIndex = 17
        Me.btnEDIT.Tag = "btnEDIT"
        Me.btnEDIT.Text = "btnEDIT"
        '
        'btnCLOSE
        '
        Me.btnCLOSE.Location = New System.Drawing.Point(712, 468)
        Me.btnCLOSE.Name = "btnCLOSE"
        Me.btnCLOSE.TabIndex = 16
        Me.btnCLOSE.Tag = "btnCLOSE"
        Me.btnCLOSE.Text = "btnCLOSE"
        '
        'btnIMPORT
        '
        Me.btnIMPORT.Location = New System.Drawing.Point(388, 468)
        Me.btnIMPORT.Name = "btnIMPORT"
        Me.btnIMPORT.TabIndex = 19
        Me.btnIMPORT.Tag = "btnIMPORT"
        Me.btnIMPORT.Text = "btnIMPORT"
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(472, 468)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.TabIndex = 20
        Me.btnExport.Tag = "btnExport"
        Me.btnExport.Text = "btnExport"
        '
        'frmDefineRisk
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(792, 498)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.btnIMPORT)
        Me.Controls.Add(Me.btnVIEW)
        Me.Controls.Add(Me.btnEDIT)
        Me.Controls.Add(Me.btnCLOSE)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tabDefineRisk)
        Me.Name = "frmDefineRisk"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmDefineRisk"
        Me.tabDefineRisk.ResumeLayout(False)
        Me.TabSYSVAR.ResumeLayout(False)
        Me.TabIRRATE.ResumeLayout(False)
        Me.TabSERISK.ResumeLayout(False)
        Me.tabPRODUCT.ResumeLayout(False)
        Me.TabICCF.ResumeLayout(False)
        Me.TabMarginSec.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Properties "
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

#Region " InitExternal "
    Private Sub InitExternal()
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL As String, v_strObjMsg As String, i, v_intCount As Integer

        'Khoi tao SEINFO
        SERISKGrid = New GridEx
        Dim v_cmrHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        SERISKGrid.FixedHeaderRows.Add(v_cmrHeader)
        Me.pnSERISK.Controls.Clear()
        Me.pnSERISK.Controls.Add(SERISKGrid)
        SERISKGrid.Dock = Windows.Forms.DockStyle.Fill
        AddHandler SERISKGrid.DoubleClick, AddressOf SERISKGrid_Click
        If Me.SERISKGrid.DataRowTemplate.Cells.Count >= 0 Then
            For i = 0 To Me.SERISKGrid.DataRowTemplate.Cells.Count - 1
                AddHandler SERISKGrid.DataRowTemplate.Cells(i).DoubleClick, AddressOf SERISKGrid_Click
            Next
        End If

        Dim v_cmrHeader_IRRATE As New Xceed.Grid.ColumnManagerRow
        v_cmrHeader_IRRATE.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrHeader_IRRATE.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        'Khoi tao IRRATE
        IRRATEGrid = New GridEx
        IRRATEGrid.FixedHeaderRows.Add(v_cmrHeader_IRRATE)
        Me.pnIRRATE.Controls.Clear()
        Me.pnIRRATE.Controls.Add(IRRATEGrid)
        IRRATEGrid.Dock = Windows.Forms.DockStyle.Fill
        AddHandler IRRATEGrid.DoubleClick, AddressOf IRRATEGrid_Click
        If Me.IRRATEGrid.DataRowTemplate.Cells.Count >= 0 Then
            For i = 0 To Me.IRRATEGrid.DataRowTemplate.Cells.Count - 1
                AddHandler IRRATEGrid.DataRowTemplate.Cells(i).DoubleClick, AddressOf IRRATEGrid_Click
            Next
        End If

        'Khoi tao SYSVAR
        Dim v_cmrHeader_SYSVAR As New Xceed.Grid.ColumnManagerRow
        v_cmrHeader_SYSVAR.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrHeader_SYSVAR.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        SYSVARGrid = New GridEx
        SYSVARGrid.FixedHeaderRows.Add(v_cmrHeader_SYSVAR)
        Me.pnlSYSVAR.Controls.Clear()
        Me.pnlSYSVAR.Controls.Add(SYSVARGrid)
        SYSVARGrid.Dock = Windows.Forms.DockStyle.Fill
        AddHandler SYSVARGrid.DoubleClick, AddressOf SYSVARGrid_Click
        If Me.SYSVARGrid.DataRowTemplate.Cells.Count >= 0 Then
            For i = 0 To Me.SYSVARGrid.DataRowTemplate.Cells.Count - 1
                AddHandler SYSVARGrid.DataRowTemplate.Cells(i).DoubleClick, AddressOf SYSVARGrid_Click
            Next
        End If

        'Khoi tao MarginSEC
        Dim v_cmrHeader_MarginSEC As New Xceed.Grid.ColumnManagerRow
        v_cmrHeader_MarginSEC.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrHeader_MarginSEC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        MarginSECGrid = New GridEx
        MarginSECGrid.FixedHeaderRows.Add(v_cmrHeader_MarginSEC)
        Me.pnlMarginSec.Controls.Clear()
        Me.pnlMarginSec.Controls.Add(MarginSECGrid)
        MarginSECGrid.Dock = Windows.Forms.DockStyle.Fill


        'Reset ACTYPE grid
        ACTYPEGrid = New GridEx
        Dim v_cmrHeader_ACTYPE As New Xceed.Grid.ColumnManagerRow
        v_cmrHeader_ACTYPE.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrHeader_ACTYPE.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        ACTYPEGrid.FixedHeaderRows.Add(v_cmrHeader_ACTYPE)
        ACTYPEGrid.Columns.Clear()
        Me.pnlPRODUCT.Controls.Clear()
        Me.pnlPRODUCT.Controls.Add(ACTYPEGrid)
        ACTYPEGrid.Dock = Windows.Forms.DockStyle.Fill
        AddHandler ACTYPEGrid.DoubleClick, AddressOf ACTYPEGrid_Click
        If Me.ACTYPEGrid.DataRowTemplate.Cells.Count >= 0 Then
            For i = 0 To Me.ACTYPEGrid.DataRowTemplate.Cells.Count - 1
                AddHandler ACTYPEGrid.DataRowTemplate.Cells(i).DoubleClick, AddressOf ACTYPEGrid_Click
            Next
        End If
        'ICCF grid
        ICCFGrid = New GridEx
        Dim v_cmrHeader_ICCF As New Xceed.Grid.ColumnManagerRow
        v_cmrHeader_ICCF.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrHeader_ICCF.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        ICCFGrid.FixedHeaderRows.Add(v_cmrHeader_ICCF)
        ICCFGrid.Columns.Clear()
        Me.pnlICCF.Controls.Clear()
        Me.pnlICCF.Controls.Add(ICCFGrid)
        ICCFGrid.Dock = Windows.Forms.DockStyle.Fill

        'Load list of parameter for each product type module
        'ACTYPE
        v_strCmdSQL = "SELECT FLD.* FROM FLDMASTER FLD, ALLCODE CD " & ControlChars.CrLf _
                & "WHERE CD.CDTYPE='SY' AND TRIM(CD.CDNAME)='DEFPRODUCT' AND RTRIM(FLD.MODCODE)='SY' AND RTRIM(FLD.OBJNAME)='DEF' || CD.CDVAL || 'TYPE'" & ControlChars.CrLf _
                & "ORDER BY FLD.MODCODE, FLD.OBJNAME, FLD.ODRNUM"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        v_xmlDefACTYPEDocument.LoadXml(v_strObjMsg)
        'SYSVAR
        v_strCmdSQL = "SELECT * FROM FLDMASTER WHERE OBJNAME='DEFSYSVAR'"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        v_xmlDefSYSVARDocument.LoadXml(v_strObjMsg)
        'MARGINSEC
        v_strCmdSQL = "SELECT * FROM FLDMASTER WHERE OBJNAME='SECURITIESRISK' ORDER BY ODRNUM"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        v_xmlDefMarginSECDocument.LoadXml(v_strObjMsg)
        'SEINFO
        v_strCmdSQL = "SELECT * FROM FLDMASTER WHERE OBJNAME='DEFSEINFO'"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        v_xmlDefSEINFODocument.LoadXml(v_strObjMsg)
        'IRRATE
        v_strCmdSQL = "SELECT * FROM FLDMASTER WHERE OBJNAME='DEFIRRATE'"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        v_xmlDefIRRATEDocument.LoadXml(v_strObjMsg)
        'ICCF
        v_strCmdSQL = "SELECT * FROM FLDMASTER WHERE OBJNAME='DEFICCF'"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        v_xmlDefICCFDocument.LoadXml(v_strObjMsg)

        'Load list of business module
        v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY LSTODR FROM ALLCODE WHERE CDTYPE='SY' AND TRIM(CDNAME)='DEFPRODUCT' ORDER BY LSTODR"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        FillComboEx(v_strObjMsg, cboModule, "", Me.UserLanguage)

        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDVALUE, v_strFLDNAME, v_strFLDTYPE, v_strVISIBLE, v_strDATATYPE As String
        Dim v_strOBJNAME, v_strDEFNAME, v_strCAPTION, v_strEN_CAPTION As String
        'Setup Grid format
        'SYSVAR
        v_nodeList = v_xmlDefSYSVARDocument.SelectNodes("/ObjectMessage/ObjData")
        For v_intCount = 0 To v_nodeList.Count - 1 Step 1
            v_strOBJNAME = String.Empty
            v_strDEFNAME = String.Empty
            v_strCAPTION = String.Empty
            v_strEN_CAPTION = String.Empty
            v_strVISIBLE = String.Empty
            For i = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                With v_nodeList.Item(v_intCount).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(v_nodeList.Item(v_intCount).ChildNodes(i).Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strFLDTYPE = CStr(CType(v_nodeList.Item(v_intCount).ChildNodes(i).Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)
                    v_strFLDVALUE = CStr(CType(v_nodeList.Item(v_intCount).ChildNodes(i).Attributes.GetNamedItem("oldval"), Xml.XmlAttribute).Value)
                    Select Case v_strFLDNAME
                        Case "OBJNAME"
                            v_strOBJNAME = v_strFLDVALUE
                        Case "DEFNAME"
                            v_strDEFNAME = v_strFLDVALUE
                        Case "CAPTION"
                            v_strCAPTION = v_strFLDVALUE
                        Case "EN_CAPTION"
                            v_strEN_CAPTION = v_strFLDVALUE
                        Case "VISIBLE"
                            v_strVISIBLE = v_strFLDVALUE
                        Case "DATATYPE"
                            v_strDATATYPE = v_strFLDVALUE
                    End Select
                End With
            Next
            If v_strDATATYPE = "N" Then
                SYSVARGrid.Columns.Add(New Xceed.Grid.Column(v_strDEFNAME, GetType(System.Double)))
                SYSVARGrid.Columns(v_strDEFNAME).HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
                SYSVARGrid.Columns(v_strDEFNAME).FormatSpecifier = "#,##0.##0"
            Else
                If v_strDATATYPE = "I" Then
                    SYSVARGrid.Columns.Add(New Xceed.Grid.Column(v_strDEFNAME, GetType(System.Double)))
                    SYSVARGrid.Columns(v_strDEFNAME).HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
                    SYSVARGrid.Columns(v_strDEFNAME).FormatSpecifier = "#,##0"
                Else
                    SYSVARGrid.Columns.Add(New Xceed.Grid.Column(v_strDEFNAME, GetType(System.String)))
                    SYSVARGrid.Columns(v_strDEFNAME).HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
                End If
            End If
            If v_strVISIBLE = "N" Then
                SYSVARGrid.Columns(v_strDEFNAME).Visible = False
            End If
            If Me.UserLanguage = "VN" Then
                SYSVARGrid.Columns(v_strDEFNAME).Title = v_strCAPTION
            Else
                SYSVARGrid.Columns(v_strDEFNAME).Title = v_strEN_CAPTION
            End If
        Next

        'MARGIN_SEC
        v_nodeList = v_xmlDefMarginSECDocument.SelectNodes("/ObjectMessage/ObjData")
        For v_intCount = 0 To v_nodeList.Count - 1 Step 1
            v_strOBJNAME = String.Empty
            v_strDEFNAME = String.Empty
            v_strCAPTION = String.Empty
            v_strEN_CAPTION = String.Empty
            v_strVISIBLE = String.Empty
            For i = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                With v_nodeList.Item(v_intCount).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(v_nodeList.Item(v_intCount).ChildNodes(i).Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strFLDTYPE = CStr(CType(v_nodeList.Item(v_intCount).ChildNodes(i).Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)
                    v_strFLDVALUE = CStr(CType(v_nodeList.Item(v_intCount).ChildNodes(i).Attributes.GetNamedItem("oldval"), Xml.XmlAttribute).Value)
                    Select Case v_strFLDNAME
                        Case "OBJNAME"
                            v_strOBJNAME = v_strFLDVALUE
                        Case "DEFNAME"
                            v_strDEFNAME = v_strFLDVALUE
                        Case "CAPTION"
                            v_strCAPTION = v_strFLDVALUE
                        Case "EN_CAPTION"
                            v_strEN_CAPTION = v_strFLDVALUE
                        Case "VISIBLE"
                            v_strVISIBLE = v_strFLDVALUE
                        Case "DATATYPE"
                            v_strDATATYPE = v_strFLDVALUE
                    End Select
                End With
            Next
            If v_strDATATYPE = "N" Then
                MarginSECGrid.Columns.Add(New Xceed.Grid.Column(v_strDEFNAME, GetType(System.Double)))
                MarginSECGrid.Columns(v_strDEFNAME).HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
                MarginSECGrid.Columns(v_strDEFNAME).FormatSpecifier = "#,##0.##0"
            Else
                If v_strDATATYPE = "I" Then
                    MarginSECGrid.Columns.Add(New Xceed.Grid.Column(v_strDEFNAME, GetType(System.Double)))
                    MarginSECGrid.Columns(v_strDEFNAME).HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
                    MarginSECGrid.Columns(v_strDEFNAME).FormatSpecifier = "#,##0"
                Else
                    MarginSECGrid.Columns.Add(New Xceed.Grid.Column(v_strDEFNAME, GetType(System.String)))
                    MarginSECGrid.Columns(v_strDEFNAME).HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
                End If
            End If
            If v_strVISIBLE = "N" Then
                MarginSECGrid.Columns(v_strDEFNAME).Visible = False
            End If
            If Me.UserLanguage = "VN" Then
                MarginSECGrid.Columns(v_strDEFNAME).Title = v_strCAPTION
            Else
                MarginSECGrid.Columns(v_strDEFNAME).Title = v_strEN_CAPTION
            End If
        Next

        AddHandler MarginSECGrid.DoubleClick, AddressOf MarginSECGrid_Click
        If Me.MarginSECGrid.DataRowTemplate.Cells.Count >= 0 Then
            For i = 0 To Me.MarginSECGrid.DataRowTemplate.Cells.Count - 1
                AddHandler MarginSECGrid.DataRowTemplate.Cells(i).DoubleClick, AddressOf MarginSECGrid_Click
            Next
        End If

        'SEINFO
        v_nodeList = v_xmlDefSEINFODocument.SelectNodes("/ObjectMessage/ObjData")
        For v_intCount = 0 To v_nodeList.Count - 1 Step 1
            v_strOBJNAME = String.Empty
            v_strDEFNAME = String.Empty
            v_strCAPTION = String.Empty
            v_strEN_CAPTION = String.Empty
            For i = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                With v_nodeList.Item(v_intCount).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(v_nodeList.Item(v_intCount).ChildNodes(i).Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strFLDTYPE = CStr(CType(v_nodeList.Item(v_intCount).ChildNodes(i).Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)
                    v_strFLDVALUE = CStr(CType(v_nodeList.Item(v_intCount).ChildNodes(i).Attributes.GetNamedItem("oldval"), Xml.XmlAttribute).Value)
                    Select Case v_strFLDNAME
                        Case "OBJNAME"
                            v_strOBJNAME = v_strFLDVALUE
                        Case "DEFNAME"
                            v_strDEFNAME = v_strFLDVALUE
                        Case "CAPTION"
                            v_strCAPTION = v_strFLDVALUE
                        Case "EN_CAPTION"
                            v_strEN_CAPTION = v_strFLDVALUE
                        Case "DATATYPE"
                            v_strDATATYPE = v_strFLDVALUE
                        Case "VISIBLE"
                            v_strVISIBLE = v_strFLDVALUE
                    End Select
                End With
            Next
            If v_strDATATYPE = "N" Then
                SERISKGrid.Columns.Add(New Xceed.Grid.Column(v_strDEFNAME, GetType(System.Double)))
                SERISKGrid.Columns(v_strDEFNAME).HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
                SERISKGrid.Columns(v_strDEFNAME).FormatSpecifier = "#,##0.##0"
            Else
                If v_strDATATYPE = "I" Then
                    SERISKGrid.Columns.Add(New Xceed.Grid.Column(v_strDEFNAME, GetType(System.Double)))
                    SERISKGrid.Columns(v_strDEFNAME).HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
                    SERISKGrid.Columns(v_strDEFNAME).FormatSpecifier = "#,##0"
                Else
                    SERISKGrid.Columns.Add(New Xceed.Grid.Column(v_strDEFNAME, GetType(System.String)))
                    SERISKGrid.Columns(v_strDEFNAME).HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
                End If
            End If
            If v_strVISIBLE = "N" Then
                SERISKGrid.Columns(v_strDEFNAME).Visible = False
            End If
            If Me.UserLanguage = "VN" Then
                SERISKGrid.Columns(v_strDEFNAME).Title = v_strCAPTION
            Else
                SERISKGrid.Columns(v_strDEFNAME).Title = v_strEN_CAPTION
            End If
        Next

        'IRRATE
        v_nodeList = v_xmlDefIRRATEDocument.SelectNodes("/ObjectMessage/ObjData")
        For v_intCount = 0 To v_nodeList.Count - 1 Step 1
            v_strOBJNAME = String.Empty
            v_strDEFNAME = String.Empty
            v_strCAPTION = String.Empty
            v_strEN_CAPTION = String.Empty
            For i = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                With v_nodeList.Item(v_intCount).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(v_nodeList.Item(v_intCount).ChildNodes(i).Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strFLDTYPE = CStr(CType(v_nodeList.Item(v_intCount).ChildNodes(i).Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)
                    v_strFLDVALUE = CStr(CType(v_nodeList.Item(v_intCount).ChildNodes(i).Attributes.GetNamedItem("oldval"), Xml.XmlAttribute).Value)
                    Select Case v_strFLDNAME
                        Case "OBJNAME"
                            v_strOBJNAME = v_strFLDVALUE
                        Case "DEFNAME"
                            v_strDEFNAME = v_strFLDVALUE
                        Case "CAPTION"
                            v_strCAPTION = v_strFLDVALUE
                        Case "EN_CAPTION"
                            v_strEN_CAPTION = v_strFLDVALUE
                        Case "DATATYPE"
                            v_strDATATYPE = v_strFLDVALUE
                        Case "VISIBLE"
                            v_strVISIBLE = v_strFLDVALUE
                    End Select
                End With
            Next
            If v_strDATATYPE = "N" Then
                IRRATEGrid.Columns.Add(New Xceed.Grid.Column(v_strDEFNAME, GetType(System.Double)))
                IRRATEGrid.Columns(v_strDEFNAME).HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
                IRRATEGrid.Columns(v_strDEFNAME).FormatSpecifier = "#,##0.##0"
            Else
                If v_strDATATYPE = "I" Then
                    IRRATEGrid.Columns.Add(New Xceed.Grid.Column(v_strDEFNAME, GetType(System.Double)))
                    IRRATEGrid.Columns(v_strDEFNAME).HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
                    IRRATEGrid.Columns(v_strDEFNAME).FormatSpecifier = "#,##0"
                Else
                    IRRATEGrid.Columns.Add(New Xceed.Grid.Column(v_strDEFNAME, GetType(System.String)))
                    IRRATEGrid.Columns(v_strDEFNAME).HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
                End If
            End If
            If v_strVISIBLE = "N" Then
                IRRATEGrid.Columns(v_strDEFNAME).Visible = False
            End If
            If Me.UserLanguage = "VN" Then
                IRRATEGrid.Columns(v_strDEFNAME).Title = v_strCAPTION
            Else
                IRRATEGrid.Columns(v_strDEFNAME).Title = v_strEN_CAPTION
            End If
        Next
        'ICCF
        v_nodeList = v_xmlDefICCFDocument.SelectNodes("/ObjectMessage/ObjData")
        For v_intCount = 0 To v_nodeList.Count - 1 Step 1
            v_strOBJNAME = String.Empty
            v_strDEFNAME = String.Empty
            v_strCAPTION = String.Empty
            v_strEN_CAPTION = String.Empty
            For i = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                With v_nodeList.Item(v_intCount).ChildNodes(i)
                    v_strFLDNAME = CStr(CType(v_nodeList.Item(v_intCount).ChildNodes(i).Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strFLDTYPE = CStr(CType(v_nodeList.Item(v_intCount).ChildNodes(i).Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)
                    v_strFLDVALUE = CStr(CType(v_nodeList.Item(v_intCount).ChildNodes(i).Attributes.GetNamedItem("oldval"), Xml.XmlAttribute).Value)
                    Select Case v_strFLDNAME
                        Case "OBJNAME"
                            v_strOBJNAME = v_strFLDVALUE
                        Case "DEFNAME"
                            v_strDEFNAME = v_strFLDVALUE
                        Case "CAPTION"
                            v_strCAPTION = v_strFLDVALUE
                        Case "EN_CAPTION"
                            v_strEN_CAPTION = v_strFLDVALUE
                        Case "DATATYPE"
                            v_strDATATYPE = v_strFLDVALUE
                        Case "VISIBLE"
                            v_strVISIBLE = v_strFLDVALUE
                    End Select
                End With
            Next
            If v_strDATATYPE = "N" Then
                ICCFGrid.Columns.Add(New Xceed.Grid.Column(v_strDEFNAME, GetType(System.Double)))
                ICCFGrid.Columns(v_strDEFNAME).HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
                ICCFGrid.Columns(v_strDEFNAME).FormatSpecifier = "#,##0.##0"
            Else
                If v_strDATATYPE = "I" Then
                    ICCFGrid.Columns.Add(New Xceed.Grid.Column(v_strDEFNAME, GetType(System.Double)))
                    ICCFGrid.Columns(v_strDEFNAME).HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
                    ICCFGrid.Columns(v_strDEFNAME).FormatSpecifier = "#,##0"
                Else
                    ICCFGrid.Columns.Add(New Xceed.Grid.Column(v_strDEFNAME, GetType(System.String)))
                    ICCFGrid.Columns(v_strDEFNAME).HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
                End If
            End If
            If v_strVISIBLE = "N" Then
                ICCFGrid.Columns(v_strDEFNAME).Visible = False
            End If
            If Me.UserLanguage = "VN" Then
                ICCFGrid.Columns(v_strDEFNAME).Title = v_strCAPTION
            Else
                ICCFGrid.Columns(v_strDEFNAME).Title = v_strEN_CAPTION
            End If
        Next
    End Sub


#End Region

#Region " Other method "

    Protected Overridable Function OnExecute(ByVal v_strCODE As String) As Int32
        Dim v_strSQL, v_strClause, v_strObjMsg, mv_strTableName, v_strBusinessModule As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode
        Dim v_strValue, v_strFLDNAME, v_strFLDCD, v_strFLDCODE, v_strTLTXCD, v_strMODCODE, v_strFLDDEFVAL As String, i, j, v_intRow As Integer
        Dim SearchGrid As GridEx

        'Xac dinh loai thuc hien
        Select Case v_strCODE
            Case "SECURITIES_RISK"
                mv_strTableName = "SECURITIES_RISK"
                SearchGrid = Me.MarginSECGrid
            Case "SYSVAR"
                mv_strTableName = "DEFSYSVAR"
                SearchGrid = Me.SYSVARGrid
            Case "SEINFO"
                mv_strTableName = "DEFSEINFO"
                SearchGrid = Me.SERISKGrid
            Case "IRRATE"
                mv_strTableName = "DEFIRRATE"
                SearchGrid = Me.IRRATEGrid
            Case "ICCF"
                mv_strTableName = "DEFICCF"
                SearchGrid = Me.ICCFGrid
            Case "ACTYPE"
                v_strBusinessModule = cboModule.SelectedValue
                If v_strBusinessModule.Length > 0 Then
                    mv_strTableName = "DEF" & v_strBusinessModule.Trim & "TYPE"
                End If
                SearchGrid = Me.ACTYPEGrid
        End Select

        'Căn cứ vào SEARCHCODE để lấy mã giao dịch (TLTXCD) và nạp các giá trị mặc định cho trư�?ng giao dịch FLDCD.
        v_strSQL = "SELECT APPMODULES.MODCODE, TLTX.TLTXCD, FLDMASTER.DEFNAME FIELDCODE, FLDMASTER.FLDNAME FLDCD FROM APPMODULES, TLTX, FLDMASTER " & ControlChars.CrLf _
            & "WHERE APPMODULES.TXCODE=SUBSTR(TLTX.TLTXCD,1,2) AND FLDMASTER.OBJNAME=TLTX.TLTXCD AND TLTX.MNEM='" & mv_strTableName & "'"

        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLTX, gc_ActionInquiry, v_strSQL)
        v_ws.Message(v_strObjMsg)
        v_xmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
        v_strFLDDEFVAL = String.Empty
        v_strMODCODE = String.Empty
        v_strTLTXCD = String.Empty
        If Not v_nodeList.Count = 0 Then
            'Nếu đây là màn hình tra cứu cho phép thực hiện giao dịch kế tiếp
            If Not SearchGrid Is Nothing Then
                If SearchGrid.DataRows.Count > 0 Then
                    For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
                        If Not SearchGrid.DataRows(v_intRow) Is Nothing Then
                            If SearchGrid.DataRows(v_intRow).IsSelected Then
                                'Có được đánh dấu ch�?n
                                For i = 0 To v_nodeList.Count - 1
                                    v_strFLDCODE = String.Empty
                                    v_strFLDCD = String.Empty
                                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                                        With v_nodeList.Item(i).ChildNodes(j)
                                            v_strValue = .InnerText.ToString
                                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                            Select Case Trim(v_strFLDNAME)
                                                Case "MODCODE"
                                                    v_strMODCODE = Trim(v_strValue)
                                                Case "TLTXCD"
                                                    v_strTLTXCD = Trim(v_strValue)
                                                Case "FIELDCODE"
                                                    v_strFLDCODE = Trim(v_strValue)
                                                Case "FLDCD"
                                                    v_strFLDCD = Trim(v_strValue)
                                            End Select
                                        End With
                                    Next
                                    'Xác định giá trị của trư�?ng dữ liệu
                                    If v_strFLDCD <> "" Then
                                        If Not SearchGrid.DataRows(v_intRow).Cells(v_strFLDCODE) Is Nothing Then
                                            v_strValue = SearchGrid.DataRows(v_intRow).Cells(v_strFLDCODE).Value
                                            v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & v_strFLDCD & "." & v_strValue & "]"
                                        End If
                                    End If
                                Next

                                'Nạp và thực hiện giao dịch
                                Dim mv_frmTransactScreen As New frmTransactMaster(Me.UserLanguage)
                                If v_strMODCODE <> "" And v_strTLTXCD <> "" Then
                                    mv_frmTransactScreen.ObjectName = v_strTLTXCD
                                    mv_frmTransactScreen.ModuleCode = v_strMODCODE
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
                                        'Refresh lại màn hình
                                        Exit Function
                                    End If
                                    mv_frmTransactScreen.Dispose()
                                    'Reset lại giá trị
                                    v_strFLDDEFVAL = String.Empty
                                End If
                            End If
                        End If
                    Next v_intRow
                End If

                'Refresh lại màn hình
                Select Case v_strCODE
                    Case "SYSVAR"
                        LoadSYSVAR()
                    Case "SEINFO"
                        LoadSERISK()
                    Case "IRRATE"
                        LoadIRRATE()
                    Case "ICCF"
                        LoadICCF()
                    Case "ACTYPE"
                        LoadACTYPE()
                    Case "SECURITIES_RISK"
                        LoadMarginSEC()
                End Select
            End If
        End If
    End Function

    Protected Overridable Function InitDialog()
        'Load resources
        ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)
        'Khoi tao Grid
        InitExternal()
    End Function

    Private Sub LoadResource(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control

        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is Label Then
                CType(v_ctrl, Label).Text = ResourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is CheckBox Then
                CType(v_ctrl, CheckBox).Text = ResourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                CType(v_ctrl, GroupBox).Text = ResourceManager.GetString(v_ctrl.Name)
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Button Then
                CType(v_ctrl, Button).Text = ResourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is Panel Then
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is TabControl Then
                For Each v_ctrlTmp As Control In CType(v_ctrl, TabControl).TabPages
                    CType(v_ctrlTmp, TabPage).Text = ResourceManager.GetString(v_ctrlTmp.Name)
                Next
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is TabPage Then
                v_ctrl.BackColor = System.Drawing.SystemColors.InactiveCaptionText
                CType(v_ctrl, TabPage).Text = ResourceManager.GetString(v_ctrl.Name)
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is DateTimePicker Then
                CType(v_ctrl, DateTimePicker).Value = CDate(Me.BusDate)

            End If
        Next
        Me.Text = ResourceManager.GetString("frmDefineRisk")
    End Sub
    Private Sub ShowForm(ByVal pv_intExecFlag As Integer, ByVal pv_strGridName As String)
        Try
            Select Case pv_strGridName
                
                Case "SERISK"
                    Dim v_frm As New frmRISK
                    v_frm.ExeFlag = pv_intExecFlag
                    v_frm.UserLanguage = Me.UserLanguage
                    v_frm.ModuleCode = "SA"
                    v_frm.ObjectName = "SA.ICCFTYPEDEF"
                    v_frm.TableName = "SECURITIES_INFO"
                    v_frm.LocalObject = "N"
                    v_frm.Text = ResourceManager.GetString("frmRISK")
                    If pv_intExecFlag <> ExecuteFlag.AddNew Then
                        v_frm.KeyFieldName = "AUTOID"
                        v_frm.KeyFieldType = "C"
                        v_frm.KeyFieldValue = CType(SERISKGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value
                    End If
                    Dim frmResult As DialogResult = v_frm.ShowDialog()
                    'Case "IRRATE"
                    '    Dim v_frm As New frmIRRATE
                    '    v_frm.ExeFlag = pv_intExecFlag
                    '    v_frm.UserLanguage = Me.UserLanguage
                    '    v_frm.ModuleCode = "SA"
                    '    v_frm.ObjectName = "SA.IRRATE"
                    '    v_frm.TableName = "IRRATE"
                    '    v_frm.LocalObject = "N"
                    '    v_frm.Text = ResourceManager.GetString("frmIRRATE")
                    '    If pv_intExecFlag <> ExecuteFlag.AddNew Then
                    '        v_frm.KeyFieldName = "RATEID"
                    '        v_frm.KeyFieldType = "C"
                    '        v_frm.KeyFieldValue = CType(IRRATEGrid.CurrentRow, Xceed.Grid.DataRow).Cells("RATEID").Value
                    '    End If
                    '    Dim frmResult As DialogResult = v_frm.ShowDialog()
                    'Case "SYSVAR"
                    '    Dim v_frm As New frmSYSVAR
                    '    v_frm.ExeFlag = pv_intExecFlag
                    '    v_frm.UserLanguage = Me.UserLanguage
                    '    v_frm.ModuleCode = "SA"
                    '    v_frm.ObjectName = "SA.SYSVAR"
                    '    v_frm.TableName = "SYSVAR"
                    '    v_frm.LocalObject = "N"
                    '    v_frm.Text = ResourceManager.GetString("frmSYSVAR")
                    '    If pv_intExecFlag <> ExecuteFlag.AddNew Then
                    '        v_frm.KeyFieldName = "VARNAME"
                    '        v_frm.KeyFieldType = "C"
                    '        v_frm.KeyFieldValue = CType(SYSVARGrid.CurrentRow, Xceed.Grid.DataRow).Cells("VARNAME").Value
                    '    End If
                    '    Dim frmResult As DialogResult = v_frm.ShowDialog()
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
    Private Sub LoadSERISK()
        Try
            If Not SERISKGrid Is Nothing Then
                'Remove các bản ghi cũ
                SERISKGrid.DataRows.Clear()
                Dim v_strSQL As String
                v_strSQL = "SELECT SECURITIES_INFO.*,'" & Me.BranchId & "' BRID  FROM SECURITIES_INFO"
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_SYSVAR, gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                FillDataGrid(SERISKGrid, v_strObjMsg, "")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
    Private Sub LoadICCF()
        Try
            If Not ICCFGrid Is Nothing Then
                'Remove các bản ghi cũ
                ICCFGrid.DataRows.Clear()
                Dim v_strSQL As String
                v_strSQL = "SELECT '" & Me.BranchId & "' BRID,ICCF.AUTOID, TYP.TYPENAME, ICCF.EVENTNAME, ICCF.MODCODE, ICCF.ACTYPE, ICCF.EVENTCODE, ICCF.DESC_RULETYPE, " & ControlChars.CrLf _
                & "(CASE WHEN ICCF.ICTYPE='F' THEN ICCF.DESC_ICTYPE ELSE ICCF.DESC_ICRATECD || '.' || ICCF.DESC_ICTYPE END) VALTYPE," & ControlChars.CrLf _
                & "(CASE WHEN ICCF.ICTYPE='F' THEN ICCF.ICFLAT WHEN (ICCF.ICTYPE='P' AND ICCF.ICRATECD='S') THEN ICCF.ICRATE ELSE IRRATEVAL+ICCF.ICRATE END) VALRATE," & ControlChars.CrLf _
                & "ICCF.MINVAL, ICCF.MAXVAL, ICCF.ICRATE ICCFRATE, ICCF.VARRATE, ICCF.ICFLAT, NVL(ICCF.IRRATEVAL,0) IRRATEVAL, ICCF.ICRATEID," & ControlChars.CrLf _
                & "ICCF.DESC_MONTHDAY, ICCF.DESC_YEARDAY, ICCF.DESC_ICTYPE, ICCF.DESC_ICRATECD, ICCF.DESC_PERIOD " & ControlChars.CrLf _
                & "FROM (SELECT 'CI' MODCODE, ACTYPE, TYPENAME FROM CITYPE TYP " & ControlChars.CrLf _
                & "UNION ALL SELECT 'SE' MODCODE, ACTYPE, DESCRIPTION TYPENAME FROM SETYPE TYP " & ControlChars.CrLf _
                & "UNION ALL SELECT 'OD' MODCODE, ACTYPE, TYPENAME FROM ODTYPE TYP) TYP JOIN " & ControlChars.CrLf _
                & "(SELECT APPEVENTS.EVENTNAME, ICCF.*, CD1.CDCONTENT DESC_RULETYPE, CD2.CDCONTENT DESC_MONTHDAY, " & ControlChars.CrLf _
                & "CD3.CDCONTENT DESC_YEARDAY, CD4.CDCONTENT DESC_PERIOD, CD5.CDCONTENT DESC_ICTYPE, CD6.CDCONTENT DESC_ICRATECD " & ControlChars.CrLf _
                & "FROM APPEVENTS, (SELECT ICCFTYPEDEF.*, IRRATE.RATE IRRATEVAL FROM ICCFTYPEDEF LEFT JOIN IRRATE ON ICCFTYPEDEF.ICRATEID=IRRATE.RATEID) ICCF, " & ControlChars.CrLf _
                & "ALLCODE CD1, ALLCODE CD2, ALLCODE CD3, ALLCODE CD4, ALLCODE CD5, ALLCODE CD6 " & ControlChars.CrLf _
                & "WHERE APPEVENTS.MODCODE=ICCF.MODCODE AND APPEVENTS.EVENTCODE=ICCF.EVENTCODE AND ICCF.DELTD<>'Y' AND ICCF.ICCFSTATUS='A' " & ControlChars.CrLf _
                & "AND CD1.CDTYPE='SA' AND CD1.CDNAME='RULETYPE' AND CD1.CDVAL=ICCF.RULETYPE " & ControlChars.CrLf _
                & "AND CD2.CDTYPE='SA' AND CD2.CDNAME='MONTHDAY' AND CD2.CDVAL=ICCF.MONTHDAY " & ControlChars.CrLf _
                & "AND CD3.CDTYPE='SA' AND CD3.CDNAME='YEARDAY' AND CD3.CDVAL=ICCF.YEARDAY " & ControlChars.CrLf _
                & "AND CD4.CDTYPE='SA' AND CD4.CDNAME='PERIOD' AND CD4.CDVAL=ICCF.PERIOD " & ControlChars.CrLf _
                & "AND CD5.CDTYPE='SA' AND CD5.CDNAME='ICTYPE' AND CD5.CDVAL=ICCF.ICTYPE " & ControlChars.CrLf _
                & "AND CD6.CDTYPE='SA' AND CD6.CDNAME='ICRATECD' AND CD6.CDVAL=ICCF.ICRATECD) ICCF " & ControlChars.CrLf _
                & "ON TYP.MODCODE=ICCF.MODCODE AND TYP.ACTYPE=ICCF.ACTYPE ORDER BY ICCF.MODCODE, ICCF.ACTYPE"
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_SYSVAR, gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                FillDataGrid(ICCFGrid, v_strObjMsg, "")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
    Private Sub LoadIRRATE()
        Try
            If Not IRRATEGrid Is Nothing Then
                'Remove các bản ghi cũ
                IRRATEGrid.DataRows.Clear()
                Dim v_strSQL As String
                v_strSQL = "SELECT '" & Me.BranchId & "' BRID, RATEID, RATENAME, S.SHORTCD CCYCD_DESC,IRR.CCYCD,RATE, FLRRATE, CELRATE, EFFECTIVEDT,APPMODULES.MODNAME MODCODE_DESC,IRR.MODCODE," & ControlChars.CrLf _
                & " A0.CDCONTENT STATUS_DESC,IRR.STATUS,A1.CDCONTENT RATETYPE_DESC,IRR.RATETYPE,A2.CDCONTENT RATETERM_DESC,IRR.RATETERM  FROM IRRATE IRR,APPMODULES, ALLCODE A0," & ControlChars.CrLf _
                & "SBCURRENCY S,ALLCODE A1,ALLCODE A2 WHERE A0.CDTYPE = 'SY' AND A0.CDNAME = 'YESNO' AND A0.CDVAL = STATUS " & ControlChars.CrLf _
                & "AND S.CCYCD = IRR.CCYCD   AND A1.CDTYPE ='SA' AND A1.CDNAME ='RATETYPE' AND A1.CDVAL =IRR.RATETYPE " & ControlChars.CrLf _
                & " AND A2.CDTYPE ='SA' AND A2.CDNAME ='RATETERM'  AND A2.CDVAL =IRR.RATETERM AND APPMODULES.MODCODE =IRR.MODCODE "
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_SYSVAR, gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                FillDataGrid(IRRATEGrid, v_strObjMsg, "")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
    Private Sub LoadSYSVAR()
        Try
            If Not SYSVARGrid Is Nothing Then
                'Remove các bản ghi cũ
                SYSVARGrid.DataRows.Clear()
                Dim v_strSQL As String
                v_strSQL = "SELECT GRNAME,VARNAME,VARVALUE,VARVALUE OLD_VARVALUE,VARDESC,VARDESC OLD_VARDESC,EN_VARDESC,EN_VARDESC OLD_EN_VARDESC,'" & Me.BranchId & "' BRID FROM SYSVAR WHERE GRNAME <> 'SYSTEM'"
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_SYSVAR, gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                FillDataGrid(SYSVARGrid, v_strObjMsg, "")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub LoadMarginSEC()
        Try
            If Not MarginSECGrid Is Nothing Then
                'Remove các bản ghi cũ
                MarginSECGrid.DataRows.Clear()
                Dim v_strSQL As String
                v_strSQL = "SELECT B.CODEID ,B.SYMBOL ,A.MRMAXQTTY, RATE.MRRATIORATE, RATE.MRRATIOLOAN,A.MRPRICERATE, A.MRPRICELOAN FROM SECURITIES_RISK A, SECURITIES_INFO B, SECURITIES_RATE RATE WHERE A.CODEID=B.CODEID AND B.CODEID=RATE.CODEID AND B.FLOORPRICE<RATE.TOPRICE AND B.FLOORPRICE>RATE.FROMPRICE"
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_SECURITIES_RISK, gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                FillDataGrid(MarginSECGrid, v_strObjMsg, "")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub LoadACTYPE()
        Try
            If Not ACTYPEGrid Is Nothing Then
                If Not (cboModule.SelectedValue Is Nothing) Then
                    Dim v_strBusinessModule As String = CStr(cboModule.SelectedValue)
                    If v_strBusinessModule.Length > 0 Then
                        'Build Command SQL to get data
                        v_strBusinessModule = v_strBusinessModule.Trim & "TYPE"
                        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                        Dim v_strCmdSQL As String, v_strObjMsg As String
                        '" & Me.BranchId & "' BRID
                        'Get data from host
                        v_strCmdSQL = "SELECT " & v_strBusinessModule & ".*,'" & Me.BranchId & "' BRID FROM " & v_strBusinessModule & " WHERE STATUS='Y'"
                        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_SYSVAR, gc_ActionInquiry, v_strCmdSQL)
                        v_ws.Message(v_strObjMsg)

                        'Remove các bản ghi cũ
                        ACTYPEGrid.DataRows.Clear()
                        ACTYPEGrid.Columns.Clear()

                        'Create grid to display data
                        Dim v_nodeList As Xml.XmlNodeList, i, v_intCount As Integer
                        Dim v_strFLDVALUE, v_strFLDNAME, v_strFLDTYPE As String
                        Dim v_strOBJNAME, v_strDEFNAME, v_strCAPTION, v_strEN_CAPTION, v_strDATATYPE, v_strVISIBLE As String
                        v_nodeList = v_xmlDefACTYPEDocument.SelectNodes("/ObjectMessage/ObjData")
                        For v_intCount = 0 To v_nodeList.Count - 1 Step 1
                            v_strOBJNAME = String.Empty
                            v_strDEFNAME = String.Empty
                            v_strCAPTION = String.Empty
                            v_strEN_CAPTION = String.Empty
                            For i = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                                With v_nodeList.Item(v_intCount).ChildNodes(i)
                                    v_strFLDNAME = CStr(CType(v_nodeList.Item(v_intCount).ChildNodes(i).Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                    v_strFLDTYPE = CStr(CType(v_nodeList.Item(v_intCount).ChildNodes(i).Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)
                                    v_strFLDVALUE = CStr(CType(v_nodeList.Item(v_intCount).ChildNodes(i).Attributes.GetNamedItem("oldval"), Xml.XmlAttribute).Value)
                                    Select Case v_strFLDNAME
                                        Case "OBJNAME"
                                            v_strOBJNAME = v_strFLDVALUE
                                        Case "DEFNAME"
                                            v_strDEFNAME = v_strFLDVALUE
                                        Case "CAPTION"
                                            v_strCAPTION = v_strFLDVALUE
                                        Case "EN_CAPTION"
                                            v_strEN_CAPTION = v_strFLDVALUE
                                        Case "DATATYPE"
                                            v_strDATATYPE = v_strFLDVALUE
                                        Case "VISIBLE"
                                            v_strVISIBLE = v_strFLDVALUE
                                    End Select
                                End With
                            Next
                            If "DEF" & v_strBusinessModule = v_strOBJNAME Then
                                If v_strDATATYPE = "N" Then
                                    ACTYPEGrid.Columns.Add(New Xceed.Grid.Column(v_strDEFNAME, GetType(System.Double)))
                                    ACTYPEGrid.Columns(v_strDEFNAME).HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
                                    ACTYPEGrid.Columns(v_strDEFNAME).FormatSpecifier = "#,##0.##0"
                                Else
                                    If v_strDATATYPE = "I" Then
                                        ACTYPEGrid.Columns.Add(New Xceed.Grid.Column(v_strDEFNAME, GetType(System.Double)))
                                        ACTYPEGrid.Columns(v_strDEFNAME).HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
                                        ACTYPEGrid.Columns(v_strDEFNAME).FormatSpecifier = "#,##0"
                                    Else
                                        ACTYPEGrid.Columns.Add(New Xceed.Grid.Column(v_strDEFNAME, GetType(System.String)))
                                        ACTYPEGrid.Columns(v_strDEFNAME).HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
                                    End If
                                End If
                                'ACTYPEGrid.Columns.Add(New Xceed.Grid.Column(v_strDEFNAME, GetType(System.String)))
                                If v_strVISIBLE = "N" Then
                                    ACTYPEGrid.Columns(v_strDEFNAME).Visible = False
                                End If
                                If Me.UserLanguage = "VN" Then
                                    ACTYPEGrid.Columns(v_strDEFNAME).Title = v_strCAPTION
                                Else
                                    ACTYPEGrid.Columns(v_strDEFNAME).Title = v_strEN_CAPTION
                                End If
                            End If
                        Next
                        'Map data to grid
                        FillDataGrid(ACTYPEGrid, v_strObjMsg, "")
                    End If
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
    Protected Overridable Function OnExport(ByVal pv_Grid As GridEx) As Int32
        Try
            Dim v_dlgSave As New SaveFileDialog
            v_dlgSave.Filter = "Text files (*.txt)|*.txt|Excel files (*.xls)|*.xls|All files (*.*)|*.*"

            Dim v_res As DialogResult = v_dlgSave.ShowDialog(Me)
            If v_res = DialogResult.OK Then
                Dim v_strFileName As String = v_dlgSave.FileName
                Dim v_strData As String
                Dim v_streamWriter As New StreamWriter(v_strFileName, False, System.Text.Encoding.Unicode)

                If (pv_Grid.DataRows.Count > 0) Then
                    'Write file's header
                    v_strData = String.Empty
                    For idx As Integer = 0 To pv_Grid.Columns.Count - 1
                        If pv_Grid.Columns(idx).Visible Then
                            v_strData &= pv_Grid.Columns(idx).Title & vbTab
                        End If
                    Next
                    v_streamWriter.WriteLine(v_strData)

                    'Write data
                    For i As Integer = 0 To pv_Grid.DataRows.Count - 1
                        v_strData = String.Empty

                        For j As Integer = 0 To pv_Grid.DataRows(i).Cells.Count - 1
                            If pv_Grid.Columns(j).Visible Then
                                v_strData &= pv_Grid.DataRows(i).Cells(j).Value & vbTab
                            End If
                        Next
                        'Write data to the file
                        v_streamWriter.WriteLine(v_strData)
                    Next
                Else
                    MsgBox(ResourceManager.GetString("frmDefineRiks.NothingToExport"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Exit Function
                End If
                'Close StreamWriter
                v_streamWriter.Close()
                MsgBox(ResourceManager.GetString("frmDefineRiks.ExportSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

#End Region

#Region " Form events "
    Private Sub SERISKGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SERISKGrid.DoubleClick
        Cursor.Current = Cursors.WaitCursor
        Cursor.Show()
        If Not (SERISKGrid.CurrentRow Is Nothing) Then
            ShowForm(ExecuteFlag.View, "SERISK")
        Else
            MsgBox(ResourceManager.GetString("NotSelected"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text)
        End If
    End Sub
    Private Sub IRRATEGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles IRRATEGrid.DoubleClick
        Cursor.Current = Cursors.WaitCursor
        Cursor.Show()
        If Not (IRRATEGrid.CurrentRow Is Nothing) Then
            ShowForm(ExecuteFlag.View, "IRRATE")
        Else
            MsgBox(ResourceManager.GetString("NotSelected"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text)
        End If
    End Sub

    Private Sub ACTYPEGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ACTYPEGrid.DoubleClick
        Cursor.Current = Cursors.WaitCursor
        Cursor.Show()
        If Not (ACTYPEGrid.CurrentRow Is Nothing) Then

        Else
            MsgBox(ResourceManager.GetString("NotSelected"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text)
        End If
    End Sub

    Private Sub SYSVARGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SYSVARGrid.DoubleClick
        Cursor.Current = Cursors.WaitCursor
        Cursor.Show()
        If Not (SYSVARGrid.CurrentRow Is Nothing) Then
            ShowForm(ExecuteFlag.View, "SYSVAR")
        Else
            MsgBox(ResourceManager.GetString("NotSelected"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text)
        End If
    End Sub
    Private Sub MarginSECGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MarginSECGrid.DoubleClick
        Cursor.Current = Cursors.WaitCursor
        Cursor.Show()
        If Not (MarginSECGrid.CurrentRow Is Nothing) Then
            ShowForm(ExecuteFlag.View, "MARGINSEC")
        Else
            MsgBox(ResourceManager.GetString("NotSelected"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text)
        End If
    End Sub

    Private Sub btnCLOSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCLOSE.Click
        Me.Dispose()
    End Sub

    Private Sub frmDefineRisk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitDialog()
        LoadSERISK()
        LoadIRRATE()
        LoadSYSVAR()
        LoadICCF()
        LoadACTYPE()
        LoadMarginSEC()
    End Sub

    Private Sub btnVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVIEW.Click
        If Me.TabSERISK.Focus = True Then
            If Not (SERISKGrid.CurrentRow Is Nothing) Then
                ShowForm(ExecuteFlag.View, "SERISK")
            End If
        End If
        If Me.TabIRRATE.Focus = True Then
            If Not (IRRATEGrid.CurrentRow Is Nothing) Then
                ShowForm(ExecuteFlag.View, "IRRATE")
            End If
        End If
        If Me.TabSYSVAR.Focus = True Then
            If Not (SYSVARGrid.CurrentRow Is Nothing) Then
                ShowForm(ExecuteFlag.View, "SYSVAR")
            End If
        End If
    End Sub
    Private Sub btnEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEDIT.Click
        If Me.TabSERISK.Focus = True Then
            If Not (SERISKGrid.CurrentRow Is Nothing) Then
                OnExecute("SEINFO")
                'ShowForm(ExecuteFlag.Edit, "SERISK")
            End If
        End If
        If Me.TabIRRATE.Focus = True Then
            If Not (IRRATEGrid.CurrentRow Is Nothing) Then
                OnExecute("IRRATE")
                'ShowForm(ExecuteFlag.Edit, "IRRATE")
            End If
        End If
        If Me.TabSYSVAR.Focus = True Then
            If Not (SYSVARGrid.CurrentRow Is Nothing) Then
                OnExecute("SYSVAR")
                'ShowForm(ExecuteFlag.Edit, "SYSVAR")
            End If
        End If
        If Me.TabICCF.Focus = True Then
            If Not (ICCFGrid.CurrentRow Is Nothing) Then
                OnExecute("ICCF")
            End If
        End If
        If Me.tabPRODUCT.Focus = True Then
            If Not (ACTYPEGrid.CurrentRow Is Nothing) Then
                OnExecute("ACTYPE")
                'ShowForm(ExecuteFlag.Edit, "SYSVAR")
            End If
        End If
    End Sub
    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        If Me.TabSERISK.Focus = True Then
            If Not (SERISKGrid.CurrentRow Is Nothing) Then
                OnExport(SERISKGrid)
            End If
        End If
        If Me.TabIRRATE.Focus = True Then
            If Not (IRRATEGrid.CurrentRow Is Nothing) Then
                OnExport(IRRATEGrid)
            End If
        End If
    End Sub
    Private Sub cboModule_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboModule.Validating
        LoadACTYPE()
    End Sub
#End Region

   
End Class
