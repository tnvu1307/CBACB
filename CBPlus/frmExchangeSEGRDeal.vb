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
Imports Xceed.Editors
Imports Xceed.Grid.Editors
Imports Xceed.Grid.DataRow


Public Class frmExchangeSEGRDeal
    Inherits System.Windows.Forms.Form
    Friend WithEvents MemberGrid As New GridEx


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mv_strLanguage = pv_strLanguage
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
    Friend WithEvents chkDetail As System.Windows.Forms.CheckBox
    Friend WithEvents lblAFACCTNO As System.Windows.Forms.Label
    Friend WithEvents mskAFACCTNO As FlexMaskEditBox
    Friend WithEvents lblAFNAME As System.Windows.Forms.Label
    Friend WithEvents lblAFINFO As System.Windows.Forms.Label
    'Public cboCODEID As AppCore.ComboBoxEx
    Friend WithEvents cboPriceTime As AppCore.ComboBoxEx
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents SEMemberGrid As New GridEx
    Friend WithEvents SEMortageGrid As New GridEx
    Friend WithEvents SEInfoReceive As New GridEx
    Friend WithEvents lblDealNo As System.Windows.Forms.Label
    Friend WithEvents btnGetDeal As System.Windows.Forms.Button
    Friend WithEvents txtDealNO As System.Windows.Forms.TextBox
    Friend WithEvents pnMember As System.Windows.Forms.Panel
    Friend WithEvents lblDealInfo As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents txtPAIDPENAFEE As System.Windows.Forms.TextBox
    Friend WithEvents lbllPAIDPENAFEE As System.Windows.Forms.Label
    Friend WithEvents txtPAIDFEE As System.Windows.Forms.TextBox
    Friend WithEvents lblPAIDFEE As System.Windows.Forms.Label
    Friend WithEvents txtPAIDINT As System.Windows.Forms.TextBox
    Friend WithEvents lblPAIDINT As System.Windows.Forms.Label
    Friend WithEvents txtPAIDAMT As System.Windows.Forms.TextBox
    Friend WithEvents lblPAIDAMT As System.Windows.Forms.Label
    Friend WithEvents txtTOTALPENAFEE As System.Windows.Forms.TextBox
    Friend WithEvents lblTOTALPENAFEE As System.Windows.Forms.Label
    Friend WithEvents txtTOTALFEE As System.Windows.Forms.TextBox
    Friend WithEvents lblTOTALFEE As System.Windows.Forms.Label
    Friend WithEvents txtTOTALINT As System.Windows.Forms.TextBox
    Friend WithEvents lblTOTALINT As System.Windows.Forms.Label
    Friend WithEvents txtDFAMT As System.Windows.Forms.TextBox
    Friend WithEvents lblDFAMT As System.Windows.Forms.Label
    Friend WithEvents txtLRATE As System.Windows.Forms.TextBox
    Friend WithEvents lblLRATE As System.Windows.Forms.Label
    Friend WithEvents txtMRATE As System.Windows.Forms.TextBox
    Friend WithEvents lblMRATE As System.Windows.Forms.Label
    Friend WithEvents txtTTRATE As System.Windows.Forms.TextBox
    Friend WithEvents lblTTRATE As System.Windows.Forms.Label
    Friend WithEvents lblLNINFOR As System.Windows.Forms.Label
    Friend WithEvents lblACTYPENAME As System.Windows.Forms.Label
    Friend WithEvents lblAcType As System.Windows.Forms.Label
    Friend WithEvents txtIRATE As System.Windows.Forms.TextBox
    Friend WithEvents lblIRATE As System.Windows.Forms.Label
    Friend WithEvents txtACTYPE As System.Windows.Forms.TextBox
    Friend WithEvents lblTTLOAN As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCANCEL As System.Windows.Forms.Button
    Private mv_dblOnload As Boolean = False
    Friend WithEvents btnDOWN As System.Windows.Forms.Button
    Friend WithEvents btnUP As System.Windows.Forms.Button
    Friend WithEvents btnAllocate As System.Windows.Forms.Button

    Private mv_dblPAIDAMT As Double
    Private mv_blnLoadForm As Boolean
    Private mv_strLNACCMOR As String
    Private mv_strLNACCSE As String
    Private mv_strISVSD As String = ""
    Friend WithEvents pnSplit As System.Windows.Forms.Panel
    Friend WithEvents lblDealNoReceive As System.Windows.Forms.Label
    Friend WithEvents pnMemberReceive As System.Windows.Forms.Panel
    Friend WithEvents txtTOTALINTRECEIVE As System.Windows.Forms.TextBox
    Friend WithEvents lblTOTALINTRECEIVE As System.Windows.Forms.Label
    Friend WithEvents txtDFAMTRECEIVE As System.Windows.Forms.TextBox
    Friend WithEvents lblDFAMTRECEIVE As System.Windows.Forms.Label
    Friend WithEvents txtTTRATERECEIVE As System.Windows.Forms.TextBox
    Friend WithEvents lblTTRATEReceive As System.Windows.Forms.Label
    Friend WithEvents pnSEInfoReceive As System.Windows.Forms.Panel
    Friend WithEvents pnSEInfo As System.Windows.Forms.Panel
    Friend WithEvents pnMortage As System.Windows.Forms.Panel
    Friend WithEvents lblDescMortage As System.Windows.Forms.Label
    Friend WithEvents lblDescSec As System.Windows.Forms.Label
    Friend WithEvents lbllSUMVALUE As System.Windows.Forms.Label
    Friend WithEvents txtSUMVALUE As System.Windows.Forms.TextBox
    Friend WithEvents cboAFACCREC As AppCore.ComboBoxEx
    Friend WithEvents lblDescSecReceive As System.Windows.Forms.Label
    Friend WithEvents ComboBoxEx1 As AppCore.ComboBoxEx
    Friend WithEvents lblSUMVALUEREC As System.Windows.Forms.Label
    Friend WithEvents txtSUMVALUEREC As System.Windows.Forms.TextBox
    Friend WithEvents txtIRATERECEIVE As System.Windows.Forms.TextBox
    Friend WithEvents btnAdjust As System.Windows.Forms.Button
    Private v_strObjMsgTMP As String



    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExchangeSEGRDeal))
        Me.pnlTitle = New System.Windows.Forms.Panel
        Me.ComboBoxEx1 = New AppCore.ComboBoxEx
        Me.cboAFACCREC = New AppCore.ComboBoxEx
        Me.lblDealNoReceive = New System.Windows.Forms.Label
        Me.lblDealNo = New System.Windows.Forms.Label
        Me.btnGetDeal = New System.Windows.Forms.Button
        Me.txtDealNO = New System.Windows.Forms.TextBox
        Me.lblDealInfo = New System.Windows.Forms.Label
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.pnMember = New System.Windows.Forms.Panel
        Me.lblDescSec = New System.Windows.Forms.Label
        Me.lbllSUMVALUE = New System.Windows.Forms.Label
        Me.lblDescMortage = New System.Windows.Forms.Label
        Me.pnSEInfo = New System.Windows.Forms.Panel
        Me.pnMortage = New System.Windows.Forms.Panel
        Me.txtSUMVALUE = New System.Windows.Forms.TextBox
        Me.txtTOTALINT = New System.Windows.Forms.TextBox
        Me.lblTOTALINT = New System.Windows.Forms.Label
        Me.txtDFAMT = New System.Windows.Forms.TextBox
        Me.lblDFAMT = New System.Windows.Forms.Label
        Me.txtTTRATE = New System.Windows.Forms.TextBox
        Me.lblTTRATE = New System.Windows.Forms.Label
        Me.lblTTLOAN = New System.Windows.Forms.Label
        Me.txtACTYPE = New System.Windows.Forms.TextBox
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.lblDescription = New System.Windows.Forms.Label
        Me.txtPAIDPENAFEE = New System.Windows.Forms.TextBox
        Me.lbllPAIDPENAFEE = New System.Windows.Forms.Label
        Me.txtPAIDFEE = New System.Windows.Forms.TextBox
        Me.lblPAIDFEE = New System.Windows.Forms.Label
        Me.txtPAIDINT = New System.Windows.Forms.TextBox
        Me.lblPAIDINT = New System.Windows.Forms.Label
        Me.txtPAIDAMT = New System.Windows.Forms.TextBox
        Me.lblPAIDAMT = New System.Windows.Forms.Label
        Me.txtTOTALPENAFEE = New System.Windows.Forms.TextBox
        Me.lblTOTALPENAFEE = New System.Windows.Forms.Label
        Me.txtTOTALFEE = New System.Windows.Forms.TextBox
        Me.lblTOTALFEE = New System.Windows.Forms.Label
        Me.txtLRATE = New System.Windows.Forms.TextBox
        Me.lblLRATE = New System.Windows.Forms.Label
        Me.txtIRATE = New System.Windows.Forms.TextBox
        Me.lblIRATE = New System.Windows.Forms.Label
        Me.txtMRATE = New System.Windows.Forms.TextBox
        Me.lblMRATE = New System.Windows.Forms.Label
        Me.lblLNINFOR = New System.Windows.Forms.Label
        Me.lblACTYPENAME = New System.Windows.Forms.Label
        Me.lblAcType = New System.Windows.Forms.Label
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCANCEL = New System.Windows.Forms.Button
        Me.btnDOWN = New System.Windows.Forms.Button
        Me.btnUP = New System.Windows.Forms.Button
        Me.btnAllocate = New System.Windows.Forms.Button
        Me.pnSplit = New System.Windows.Forms.Panel
        Me.pnMemberReceive = New System.Windows.Forms.Panel
        Me.lblSUMVALUEREC = New System.Windows.Forms.Label
        Me.txtSUMVALUEREC = New System.Windows.Forms.TextBox
        Me.lblDescSecReceive = New System.Windows.Forms.Label
        Me.txtTOTALINTRECEIVE = New System.Windows.Forms.TextBox
        Me.lblTOTALINTRECEIVE = New System.Windows.Forms.Label
        Me.txtDFAMTRECEIVE = New System.Windows.Forms.TextBox
        Me.lblDFAMTRECEIVE = New System.Windows.Forms.Label
        Me.txtTTRATERECEIVE = New System.Windows.Forms.TextBox
        Me.lblTTRATEReceive = New System.Windows.Forms.Label
        Me.pnSEInfoReceive = New System.Windows.Forms.Panel
        Me.txtIRATERECEIVE = New System.Windows.Forms.TextBox
        Me.btnAdjust = New System.Windows.Forms.Button
        Me.pnlTitle.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnMember.SuspendLayout()
        Me.pnMemberReceive.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTitle
        '
        Me.pnlTitle.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlTitle.Controls.Add(Me.ComboBoxEx1)
        Me.pnlTitle.Controls.Add(Me.cboAFACCREC)
        Me.pnlTitle.Controls.Add(Me.lblDealNoReceive)
        Me.pnlTitle.Controls.Add(Me.lblDealNo)
        Me.pnlTitle.Controls.Add(Me.btnGetDeal)
        Me.pnlTitle.Controls.Add(Me.txtDealNO)
        Me.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitle.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(893, 41)
        Me.pnlTitle.TabIndex = 0
        '
        'ComboBoxEx1
        '
        Me.ComboBoxEx1.DisplayMember = "DISPLAY"
        Me.ComboBoxEx1.FormattingEnabled = True
        Me.ComboBoxEx1.Location = New System.Drawing.Point(845, -454)
        Me.ComboBoxEx1.Name = "ComboBoxEx1"
        Me.ComboBoxEx1.Size = New System.Drawing.Size(10, 21)
        Me.ComboBoxEx1.TabIndex = 13
        Me.ComboBoxEx1.Tag = "AFACCREC"
        Me.ComboBoxEx1.ValueMember = "VALUE"
        '
        'cboAFACCREC
        '
        Me.cboAFACCREC.DisplayMember = "DISPLAY"
        Me.cboAFACCREC.FormattingEnabled = True
        Me.cboAFACCREC.Location = New System.Drawing.Point(660, 11)
        Me.cboAFACCREC.Name = "cboAFACCREC"
        Me.cboAFACCREC.Size = New System.Drawing.Size(214, 21)
        Me.cboAFACCREC.TabIndex = 11
        Me.cboAFACCREC.Tag = "AFACCREC"
        Me.cboAFACCREC.ValueMember = "VALUE"
        '
        'lblDealNoReceive
        '
        Me.lblDealNoReceive.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDealNoReceive.Location = New System.Drawing.Point(497, 13)
        Me.lblDealNoReceive.Name = "lblDealNoReceive"
        Me.lblDealNoReceive.Size = New System.Drawing.Size(188, 20)
        Me.lblDealNoReceive.TabIndex = 10
        Me.lblDealNoReceive.Tag = "DealNoReceive"
        Me.lblDealNoReceive.Text = "lblDealNoReceive"
        '
        'lblDealNo
        '
        Me.lblDealNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDealNo.Location = New System.Drawing.Point(12, 13)
        Me.lblDealNo.Name = "lblDealNo"
        Me.lblDealNo.Size = New System.Drawing.Size(160, 20)
        Me.lblDealNo.TabIndex = 10
        Me.lblDealNo.Tag = "DealNo"
        Me.lblDealNo.Text = "lblDealNo"
        '
        'btnGetDeal
        '
        Me.btnGetDeal.Location = New System.Drawing.Point(324, 9)
        Me.btnGetDeal.Name = "btnGetDeal"
        Me.btnGetDeal.Size = New System.Drawing.Size(80, 25)
        Me.btnGetDeal.TabIndex = 2
        Me.btnGetDeal.Tag = "GetDeal"
        Me.btnGetDeal.Text = "btnGETDEAL"
        Me.btnGetDeal.UseVisualStyleBackColor = True
        '
        'txtDealNO
        '
        Me.txtDealNO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDealNO.Location = New System.Drawing.Point(182, 11)
        Me.txtDealNO.Name = "txtDealNO"
        Me.txtDealNO.Size = New System.Drawing.Size(136, 20)
        Me.txtDealNO.TabIndex = 1
        Me.txtDealNO.Tag = "txtDealNO"
        '
        'lblDealInfo
        '
        Me.lblDealInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDealInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDealInfo.ForeColor = System.Drawing.Color.Black
        Me.lblDealInfo.Location = New System.Drawing.Point(27, 49)
        Me.lblDealInfo.Name = "lblDealInfo"
        Me.lblDealInfo.Size = New System.Drawing.Size(838, 20)
        Me.lblDealInfo.TabIndex = 4
        Me.lblDealInfo.Tag = "DealInfo"
        Me.lblDealInfo.Text = "lblDealInfo"
        Me.lblDealInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'pnMember
        '
        Me.pnMember.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnMember.Controls.Add(Me.lblDescSec)
        Me.pnMember.Controls.Add(Me.lbllSUMVALUE)
        Me.pnMember.Controls.Add(Me.lblDescMortage)
        Me.pnMember.Controls.Add(Me.pnSEInfo)
        Me.pnMember.Controls.Add(Me.pnMortage)
        Me.pnMember.Controls.Add(Me.txtSUMVALUE)
        Me.pnMember.Controls.Add(Me.txtTOTALINT)
        Me.pnMember.Controls.Add(Me.lblTOTALINT)
        Me.pnMember.Controls.Add(Me.txtDFAMT)
        Me.pnMember.Controls.Add(Me.lblDFAMT)
        Me.pnMember.Controls.Add(Me.txtTTRATE)
        Me.pnMember.Controls.Add(Me.lblTTRATE)
        Me.pnMember.Location = New System.Drawing.Point(6, 78)
        Me.pnMember.Name = "pnMember"
        Me.pnMember.Size = New System.Drawing.Size(432, 339)
        Me.pnMember.TabIndex = 2
        '
        'lblDescSec
        '
        Me.lblDescSec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescSec.Location = New System.Drawing.Point(3, 180)
        Me.lblDescSec.Name = "lblDescSec"
        Me.lblDescSec.Size = New System.Drawing.Size(406, 20)
        Me.lblDescSec.TabIndex = 86
        Me.lblDescSec.Tag = "DescSec"
        Me.lblDescSec.Text = "lblDescSec"
        Me.lblDescSec.Visible = False
        '
        'lbllSUMVALUE
        '
        Me.lbllSUMVALUE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllSUMVALUE.ForeColor = System.Drawing.Color.Red
        Me.lbllSUMVALUE.Location = New System.Drawing.Point(178, 34)
        Me.lbllSUMVALUE.Name = "lbllSUMVALUE"
        Me.lbllSUMVALUE.Size = New System.Drawing.Size(137, 20)
        Me.lbllSUMVALUE.TabIndex = 86
        Me.lbllSUMVALUE.Tag = "SUMVALUE"
        Me.lbllSUMVALUE.Text = "lblSUMVALUE"
        '
        'lblDescMortage
        '
        Me.lblDescMortage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescMortage.Location = New System.Drawing.Point(5, 74)
        Me.lblDescMortage.Name = "lblDescMortage"
        Me.lblDescMortage.Size = New System.Drawing.Size(181, 20)
        Me.lblDescMortage.TabIndex = 86
        Me.lblDescMortage.Tag = "DescMortage"
        Me.lblDescMortage.Text = "lblDescMortage"
        '
        'pnSEInfo
        '
        Me.pnSEInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnSEInfo.Location = New System.Drawing.Point(1, 204)
        Me.pnSEInfo.Name = "pnSEInfo"
        Me.pnSEInfo.Size = New System.Drawing.Size(428, 132)
        Me.pnSEInfo.TabIndex = 73
        Me.pnSEInfo.Visible = False
        '
        'pnMortage
        '
        Me.pnMortage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnMortage.Location = New System.Drawing.Point(1, 99)
        Me.pnMortage.Name = "pnMortage"
        Me.pnMortage.Size = New System.Drawing.Size(428, 237)
        Me.pnMortage.TabIndex = 73
        '
        'txtSUMVALUE
        '
        Me.txtSUMVALUE.Enabled = False
        Me.txtSUMVALUE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUMVALUE.Location = New System.Drawing.Point(317, 32)
        Me.txtSUMVALUE.Name = "txtSUMVALUE"
        Me.txtSUMVALUE.Size = New System.Drawing.Size(106, 20)
        Me.txtSUMVALUE.TabIndex = 9
        Me.txtSUMVALUE.Tag = "SUMVALUE"
        Me.txtSUMVALUE.Text = "txtSUMVALUE"
        Me.txtSUMVALUE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTOTALINT
        '
        Me.txtTOTALINT.Enabled = False
        Me.txtTOTALINT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTOTALINT.Location = New System.Drawing.Point(317, 6)
        Me.txtTOTALINT.Name = "txtTOTALINT"
        Me.txtTOTALINT.Size = New System.Drawing.Size(106, 20)
        Me.txtTOTALINT.TabIndex = 9
        Me.txtTOTALINT.Tag = "TOTALINT"
        Me.txtTOTALINT.Text = "txtTOTALINT"
        Me.txtTOTALINT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTOTALINT
        '
        Me.lblTOTALINT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTOTALINT.Location = New System.Drawing.Point(178, 8)
        Me.lblTOTALINT.Name = "lblTOTALINT"
        Me.lblTOTALINT.Size = New System.Drawing.Size(126, 20)
        Me.lblTOTALINT.TabIndex = 72
        Me.lblTOTALINT.Tag = "TOTALINT"
        Me.lblTOTALINT.Text = "lblTOTALINT"
        '
        'txtDFAMT
        '
        Me.txtDFAMT.Enabled = False
        Me.txtDFAMT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDFAMT.Location = New System.Drawing.Point(72, 6)
        Me.txtDFAMT.Name = "txtDFAMT"
        Me.txtDFAMT.Size = New System.Drawing.Size(106, 20)
        Me.txtDFAMT.TabIndex = 8
        Me.txtDFAMT.Tag = "DFAMT"
        Me.txtDFAMT.Text = "txtDFAMT"
        Me.txtDFAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDFAMT
        '
        Me.lblDFAMT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDFAMT.Location = New System.Drawing.Point(2, 8)
        Me.lblDFAMT.Name = "lblDFAMT"
        Me.lblDFAMT.Size = New System.Drawing.Size(74, 20)
        Me.lblDFAMT.TabIndex = 70
        Me.lblDFAMT.Tag = "DFAMT"
        Me.lblDFAMT.Text = "lblDFAMT"
        '
        'txtTTRATE
        '
        Me.txtTTRATE.Enabled = False
        Me.txtTTRATE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTTRATE.Location = New System.Drawing.Point(72, 32)
        Me.txtTTRATE.Name = "txtTTRATE"
        Me.txtTTRATE.Size = New System.Drawing.Size(106, 20)
        Me.txtTTRATE.TabIndex = 4
        Me.txtTTRATE.Tag = "TTRATE"
        Me.txtTTRATE.Text = "txtTTRATE"
        Me.txtTTRATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTTRATE
        '
        Me.lblTTRATE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTTRATE.Location = New System.Drawing.Point(2, 34)
        Me.lblTTRATE.Name = "lblTTRATE"
        Me.lblTTRATE.Size = New System.Drawing.Size(74, 20)
        Me.lblTTRATE.TabIndex = 64
        Me.lblTTRATE.Tag = "TTRATE"
        Me.lblTTRATE.Text = "lblTTRATE"
        '
        'lblTTLOAN
        '
        Me.lblTTLOAN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTTLOAN.Location = New System.Drawing.Point(30, 601)
        Me.lblTTLOAN.Name = "lblTTLOAN"
        Me.lblTTLOAN.Size = New System.Drawing.Size(72, 20)
        Me.lblTTLOAN.TabIndex = 89
        Me.lblTTLOAN.Tag = "TTLOAN"
        Me.lblTTLOAN.Text = "lblTTLOAN"
        '
        'txtACTYPE
        '
        Me.txtACTYPE.Enabled = False
        Me.txtACTYPE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtACTYPE.Location = New System.Drawing.Point(108, 578)
        Me.txtACTYPE.Name = "txtACTYPE"
        Me.txtACTYPE.Size = New System.Drawing.Size(90, 20)
        Me.txtACTYPE.TabIndex = 3
        Me.txtACTYPE.Tag = "ACTYPE"
        Me.txtACTYPE.Text = "txtACTYPE"
        '
        'txtDescription
        '
        Me.txtDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(81, 429)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(535, 20)
        Me.txtDescription.TabIndex = 16
        Me.txtDescription.Tag = "txtDescription"
        Me.txtDescription.Text = "txtDescription"
        '
        'lblDescription
        '
        Me.lblDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.Location = New System.Drawing.Point(3, 429)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(88, 20)
        Me.lblDescription.TabIndex = 86
        Me.lblDescription.Tag = "DESCRIPTION"
        Me.lblDescription.Text = "lblDescription"
        '
        'txtPAIDPENAFEE
        '
        Me.txtPAIDPENAFEE.Enabled = False
        Me.txtPAIDPENAFEE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPAIDPENAFEE.Location = New System.Drawing.Point(623, 674)
        Me.txtPAIDPENAFEE.Name = "txtPAIDPENAFEE"
        Me.txtPAIDPENAFEE.Size = New System.Drawing.Size(90, 20)
        Me.txtPAIDPENAFEE.TabIndex = 15
        Me.txtPAIDPENAFEE.Tag = "PAIDPENAFEE"
        Me.txtPAIDPENAFEE.Text = "txtPAIDPENAFEE"
        '
        'lbllPAIDPENAFEE
        '
        Me.lbllPAIDPENAFEE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllPAIDPENAFEE.Location = New System.Drawing.Point(547, 674)
        Me.lbllPAIDPENAFEE.Name = "lbllPAIDPENAFEE"
        Me.lbllPAIDPENAFEE.Size = New System.Drawing.Size(76, 20)
        Me.lbllPAIDPENAFEE.TabIndex = 84
        Me.lbllPAIDPENAFEE.Tag = "lPAIDPENAFEE"
        Me.lbllPAIDPENAFEE.Text = "lbllPAIDPENAFEE"
        '
        'txtPAIDFEE
        '
        Me.txtPAIDFEE.Enabled = False
        Me.txtPAIDFEE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPAIDFEE.Location = New System.Drawing.Point(457, 674)
        Me.txtPAIDFEE.Name = "txtPAIDFEE"
        Me.txtPAIDFEE.Size = New System.Drawing.Size(90, 20)
        Me.txtPAIDFEE.TabIndex = 14
        Me.txtPAIDFEE.Tag = "PAIDFEE"
        Me.txtPAIDFEE.Text = "txtPAIDFEE"
        '
        'lblPAIDFEE
        '
        Me.lblPAIDFEE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPAIDFEE.Location = New System.Drawing.Point(366, 674)
        Me.lblPAIDFEE.Name = "lblPAIDFEE"
        Me.lblPAIDFEE.Size = New System.Drawing.Size(102, 20)
        Me.lblPAIDFEE.TabIndex = 82
        Me.lblPAIDFEE.Tag = "PAIDFEE"
        Me.lblPAIDFEE.Text = "lblPAIDFEE"
        '
        'txtPAIDINT
        '
        Me.txtPAIDINT.Enabled = False
        Me.txtPAIDINT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPAIDINT.Location = New System.Drawing.Point(275, 674)
        Me.txtPAIDINT.Name = "txtPAIDINT"
        Me.txtPAIDINT.Size = New System.Drawing.Size(90, 20)
        Me.txtPAIDINT.TabIndex = 13
        Me.txtPAIDINT.Tag = "PAIDINT"
        Me.txtPAIDINT.Text = "txtPAIDINT"
        '
        'lblPAIDINT
        '
        Me.lblPAIDINT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPAIDINT.Location = New System.Drawing.Point(185, 674)
        Me.lblPAIDINT.Name = "lblPAIDINT"
        Me.lblPAIDINT.Size = New System.Drawing.Size(88, 20)
        Me.lblPAIDINT.TabIndex = 80
        Me.lblPAIDINT.Tag = "PAIDINT"
        Me.lblPAIDINT.Text = "lblPAIDINT"
        '
        'txtPAIDAMT
        '
        Me.txtPAIDAMT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPAIDAMT.Location = New System.Drawing.Point(95, 674)
        Me.txtPAIDAMT.Name = "txtPAIDAMT"
        Me.txtPAIDAMT.Size = New System.Drawing.Size(90, 20)
        Me.txtPAIDAMT.TabIndex = 12
        Me.txtPAIDAMT.Tag = "PAIDAMT"
        Me.txtPAIDAMT.Text = "txtPAIDAMT"
        '
        'lblPAIDAMT
        '
        Me.lblPAIDAMT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPAIDAMT.Location = New System.Drawing.Point(17, 674)
        Me.lblPAIDAMT.Name = "lblPAIDAMT"
        Me.lblPAIDAMT.Size = New System.Drawing.Size(88, 20)
        Me.lblPAIDAMT.TabIndex = 78
        Me.lblPAIDAMT.Tag = "PAIDAMT"
        Me.lblPAIDAMT.Text = "lblPAIDAMT"
        '
        'txtTOTALPENAFEE
        '
        Me.txtTOTALPENAFEE.Enabled = False
        Me.txtTOTALPENAFEE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTOTALPENAFEE.Location = New System.Drawing.Point(623, 647)
        Me.txtTOTALPENAFEE.Name = "txtTOTALPENAFEE"
        Me.txtTOTALPENAFEE.Size = New System.Drawing.Size(90, 20)
        Me.txtTOTALPENAFEE.TabIndex = 11
        Me.txtTOTALPENAFEE.Tag = "TOTALPENAFEE"
        Me.txtTOTALPENAFEE.Text = "txtTOTALPENAFEE"
        '
        'lblTOTALPENAFEE
        '
        Me.lblTOTALPENAFEE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTOTALPENAFEE.Location = New System.Drawing.Point(547, 647)
        Me.lblTOTALPENAFEE.Name = "lblTOTALPENAFEE"
        Me.lblTOTALPENAFEE.Size = New System.Drawing.Size(76, 20)
        Me.lblTOTALPENAFEE.TabIndex = 76
        Me.lblTOTALPENAFEE.Tag = "TOTALPENAFEE"
        Me.lblTOTALPENAFEE.Text = "lblTOTALPENAFEE"
        '
        'txtTOTALFEE
        '
        Me.txtTOTALFEE.Enabled = False
        Me.txtTOTALFEE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTOTALFEE.Location = New System.Drawing.Point(457, 647)
        Me.txtTOTALFEE.Name = "txtTOTALFEE"
        Me.txtTOTALFEE.Size = New System.Drawing.Size(90, 20)
        Me.txtTOTALFEE.TabIndex = 10
        Me.txtTOTALFEE.Tag = "TOTALFEE"
        Me.txtTOTALFEE.Text = "txtTOTALFEE"
        '
        'lblTOTALFEE
        '
        Me.lblTOTALFEE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTOTALFEE.Location = New System.Drawing.Point(366, 647)
        Me.lblTOTALFEE.Name = "lblTOTALFEE"
        Me.lblTOTALFEE.Size = New System.Drawing.Size(102, 20)
        Me.lblTOTALFEE.TabIndex = 74
        Me.lblTOTALFEE.Tag = "TOTALFEE"
        Me.lblTOTALFEE.Text = "lblTOTALFEE"
        '
        'txtLRATE
        '
        Me.txtLRATE.Enabled = False
        Me.txtLRATE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLRATE.Location = New System.Drawing.Point(491, 624)
        Me.txtLRATE.Name = "txtLRATE"
        Me.txtLRATE.Size = New System.Drawing.Size(90, 20)
        Me.txtLRATE.TabIndex = 7
        Me.txtLRATE.Tag = "LRATE"
        Me.txtLRATE.Text = "txtLRATE"
        '
        'lblLRATE
        '
        Me.lblLRATE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLRATE.Location = New System.Drawing.Point(415, 624)
        Me.lblLRATE.Name = "lblLRATE"
        Me.lblLRATE.Size = New System.Drawing.Size(102, 20)
        Me.lblLRATE.TabIndex = 68
        Me.lblLRATE.Tag = "LRATE"
        Me.lblLRATE.Text = "lblLRATE"
        '
        'txtIRATE
        '
        Me.txtIRATE.Enabled = False
        Me.txtIRATE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIRATE.Location = New System.Drawing.Point(143, 624)
        Me.txtIRATE.Name = "txtIRATE"
        Me.txtIRATE.Size = New System.Drawing.Size(90, 20)
        Me.txtIRATE.TabIndex = 5
        Me.txtIRATE.Tag = "IRATE"
        Me.txtIRATE.Text = "txtIRATE"
        '
        'lblIRATE
        '
        Me.lblIRATE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIRATE.Location = New System.Drawing.Point(53, 624)
        Me.lblIRATE.Name = "lblIRATE"
        Me.lblIRATE.Size = New System.Drawing.Size(88, 20)
        Me.lblIRATE.TabIndex = 66
        Me.lblIRATE.Tag = "IRATE"
        Me.lblIRATE.Text = "lblIRATE"
        '
        'txtMRATE
        '
        Me.txtMRATE.Enabled = False
        Me.txtMRATE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMRATE.Location = New System.Drawing.Point(325, 624)
        Me.txtMRATE.Name = "txtMRATE"
        Me.txtMRATE.Size = New System.Drawing.Size(90, 20)
        Me.txtMRATE.TabIndex = 6
        Me.txtMRATE.Tag = "MRATE"
        Me.txtMRATE.Text = "txtMRATE"
        '
        'lblMRATE
        '
        Me.lblMRATE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMRATE.Location = New System.Drawing.Point(234, 624)
        Me.lblMRATE.Name = "lblMRATE"
        Me.lblMRATE.Size = New System.Drawing.Size(88, 20)
        Me.lblMRATE.TabIndex = 66
        Me.lblMRATE.Tag = "MRATE"
        Me.lblMRATE.Text = "lblMRATE"
        '
        'lblLNINFOR
        '
        Me.lblLNINFOR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLNINFOR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLNINFOR.ForeColor = System.Drawing.Color.Black
        Me.lblLNINFOR.Location = New System.Drawing.Point(108, 601)
        Me.lblLNINFOR.Name = "lblLNINFOR"
        Me.lblLNINFOR.Size = New System.Drawing.Size(617, 20)
        Me.lblLNINFOR.TabIndex = 63
        Me.lblLNINFOR.Tag = "LNINFOR"
        Me.lblLNINFOR.Text = "lblLNINFOR"
        '
        'lblACTYPENAME
        '
        Me.lblACTYPENAME.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblACTYPENAME.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblACTYPENAME.ForeColor = System.Drawing.Color.Black
        Me.lblACTYPENAME.Location = New System.Drawing.Point(197, 578)
        Me.lblACTYPENAME.Name = "lblACTYPENAME"
        Me.lblACTYPENAME.Size = New System.Drawing.Size(527, 20)
        Me.lblACTYPENAME.TabIndex = 62
        Me.lblACTYPENAME.Text = "lblACTYPENAME"
        '
        'lblAcType
        '
        Me.lblAcType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAcType.Location = New System.Drawing.Point(30, 578)
        Me.lblAcType.Name = "lblAcType"
        Me.lblAcType.Size = New System.Drawing.Size(94, 20)
        Me.lblAcType.TabIndex = 60
        Me.lblAcType.Tag = "ACTYPE"
        Me.lblAcType.Text = "lblAcType"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(718, 426)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(80, 25)
        Me.btnOK.TabIndex = 17
        Me.btnOK.Tag = "btnOK"
        Me.btnOK.Text = "btnOK"
        '
        'btnCANCEL
        '
        Me.btnCANCEL.Location = New System.Drawing.Point(800, 426)
        Me.btnCANCEL.Name = "btnCANCEL"
        Me.btnCANCEL.Size = New System.Drawing.Size(80, 25)
        Me.btnCANCEL.TabIndex = 18
        Me.btnCANCEL.Tag = "btnCANCEL"
        Me.btnCANCEL.Text = "btnCANCEL"
        '
        'btnDOWN
        '
        Me.btnDOWN.Location = New System.Drawing.Point(96, 527)
        Me.btnDOWN.Name = "btnDOWN"
        Me.btnDOWN.Size = New System.Drawing.Size(80, 25)
        Me.btnDOWN.TabIndex = 20
        Me.btnDOWN.Tag = "btnDOWN"
        Me.btnDOWN.Text = "btnDOWN"
        '
        'btnUP
        '
        Me.btnUP.Location = New System.Drawing.Point(10, 527)
        Me.btnUP.Name = "btnUP"
        Me.btnUP.Size = New System.Drawing.Size(80, 25)
        Me.btnUP.TabIndex = 19
        Me.btnUP.Tag = "btnUP"
        Me.btnUP.Text = "btnUP"
        '
        'btnAllocate
        '
        Me.btnAllocate.Location = New System.Drawing.Point(182, 527)
        Me.btnAllocate.Name = "btnAllocate"
        Me.btnAllocate.Size = New System.Drawing.Size(80, 25)
        Me.btnAllocate.TabIndex = 21
        Me.btnAllocate.Tag = "btnAllocate"
        Me.btnAllocate.Text = "btnAllocate"
        '
        'pnSplit
        '
        Me.pnSplit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnSplit.Location = New System.Drawing.Point(445, 76)
        Me.pnSplit.Name = "pnSplit"
        Me.pnSplit.Size = New System.Drawing.Size(3, 341)
        Me.pnSplit.TabIndex = 90
        Me.pnSplit.Tag = "pnSplit"
        '
        'pnMemberReceive
        '
        Me.pnMemberReceive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnMemberReceive.Controls.Add(Me.lblSUMVALUEREC)
        Me.pnMemberReceive.Controls.Add(Me.txtSUMVALUEREC)
        Me.pnMemberReceive.Controls.Add(Me.lblDescSecReceive)
        Me.pnMemberReceive.Controls.Add(Me.txtTOTALINTRECEIVE)
        Me.pnMemberReceive.Controls.Add(Me.lblTOTALINTRECEIVE)
        Me.pnMemberReceive.Controls.Add(Me.txtDFAMTRECEIVE)
        Me.pnMemberReceive.Controls.Add(Me.lblDFAMTRECEIVE)
        Me.pnMemberReceive.Controls.Add(Me.txtTTRATERECEIVE)
        Me.pnMemberReceive.Controls.Add(Me.lblTTRATEReceive)
        Me.pnMemberReceive.Controls.Add(Me.pnSEInfoReceive)
        Me.pnMemberReceive.Location = New System.Drawing.Point(455, 78)
        Me.pnMemberReceive.Name = "pnMemberReceive"
        Me.pnMemberReceive.Size = New System.Drawing.Size(432, 339)
        Me.pnMemberReceive.TabIndex = 2
        Me.pnMemberReceive.Tag = "pnMemberReceive"
        '
        'lblSUMVALUEREC
        '
        Me.lblSUMVALUEREC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSUMVALUEREC.ForeColor = System.Drawing.Color.Red
        Me.lblSUMVALUEREC.Location = New System.Drawing.Point(180, 34)
        Me.lblSUMVALUEREC.Name = "lblSUMVALUEREC"
        Me.lblSUMVALUEREC.Size = New System.Drawing.Size(137, 20)
        Me.lblSUMVALUEREC.TabIndex = 88
        Me.lblSUMVALUEREC.Tag = "SUMVALUEREC"
        Me.lblSUMVALUEREC.Text = "lblSUMVALUEREC"
        '
        'txtSUMVALUEREC
        '
        Me.txtSUMVALUEREC.Enabled = False
        Me.txtSUMVALUEREC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSUMVALUEREC.Location = New System.Drawing.Point(318, 32)
        Me.txtSUMVALUEREC.Name = "txtSUMVALUEREC"
        Me.txtSUMVALUEREC.Size = New System.Drawing.Size(106, 20)
        Me.txtSUMVALUEREC.TabIndex = 87
        Me.txtSUMVALUEREC.Tag = "SUMVALUEREC"
        Me.txtSUMVALUEREC.Text = "txtSUMVALUEREC"
        Me.txtSUMVALUEREC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDescSecReceive
        '
        Me.lblDescSecReceive.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescSecReceive.Location = New System.Drawing.Point(3, 74)
        Me.lblDescSecReceive.Name = "lblDescSecReceive"
        Me.lblDescSecReceive.Size = New System.Drawing.Size(406, 20)
        Me.lblDescSecReceive.TabIndex = 86
        Me.lblDescSecReceive.Tag = "DescSecReceive"
        Me.lblDescSecReceive.Text = "lblDescSecReceive"
        '
        'txtTOTALINTRECEIVE
        '
        Me.txtTOTALINTRECEIVE.Enabled = False
        Me.txtTOTALINTRECEIVE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTOTALINTRECEIVE.Location = New System.Drawing.Point(318, 6)
        Me.txtTOTALINTRECEIVE.Name = "txtTOTALINTRECEIVE"
        Me.txtTOTALINTRECEIVE.Size = New System.Drawing.Size(106, 20)
        Me.txtTOTALINTRECEIVE.TabIndex = 9
        Me.txtTOTALINTRECEIVE.Tag = "TOTALINTRECEIVE"
        Me.txtTOTALINTRECEIVE.Text = "txtTOTALINTRECEIVE"
        Me.txtTOTALINTRECEIVE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTOTALINTRECEIVE
        '
        Me.lblTOTALINTRECEIVE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTOTALINTRECEIVE.Location = New System.Drawing.Point(180, 8)
        Me.lblTOTALINTRECEIVE.Name = "lblTOTALINTRECEIVE"
        Me.lblTOTALINTRECEIVE.Size = New System.Drawing.Size(100, 20)
        Me.lblTOTALINTRECEIVE.TabIndex = 72
        Me.lblTOTALINTRECEIVE.Tag = "TOTALINTRECEIVE"
        Me.lblTOTALINTRECEIVE.Text = "lblTOTALINTRECEIVE"
        '
        'txtDFAMTRECEIVE
        '
        Me.txtDFAMTRECEIVE.Enabled = False
        Me.txtDFAMTRECEIVE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDFAMTRECEIVE.Location = New System.Drawing.Point(73, 6)
        Me.txtDFAMTRECEIVE.Name = "txtDFAMTRECEIVE"
        Me.txtDFAMTRECEIVE.Size = New System.Drawing.Size(106, 20)
        Me.txtDFAMTRECEIVE.TabIndex = 8
        Me.txtDFAMTRECEIVE.Tag = "DFAMTRECEIVE"
        Me.txtDFAMTRECEIVE.Text = "txtDFAMTRECEIVE"
        Me.txtDFAMTRECEIVE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDFAMTRECEIVE
        '
        Me.lblDFAMTRECEIVE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDFAMTRECEIVE.Location = New System.Drawing.Point(2, 8)
        Me.lblDFAMTRECEIVE.Name = "lblDFAMTRECEIVE"
        Me.lblDFAMTRECEIVE.Size = New System.Drawing.Size(74, 20)
        Me.lblDFAMTRECEIVE.TabIndex = 70
        Me.lblDFAMTRECEIVE.Tag = "DFAMTRECEIVE"
        Me.lblDFAMTRECEIVE.Text = "lblDFAMTRECEIVE"
        '
        'txtTTRATERECEIVE
        '
        Me.txtTTRATERECEIVE.Enabled = False
        Me.txtTTRATERECEIVE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTTRATERECEIVE.Location = New System.Drawing.Point(73, 32)
        Me.txtTTRATERECEIVE.Name = "txtTTRATERECEIVE"
        Me.txtTTRATERECEIVE.Size = New System.Drawing.Size(106, 20)
        Me.txtTTRATERECEIVE.TabIndex = 4
        Me.txtTTRATERECEIVE.Tag = "TTRATERECEIVE"
        Me.txtTTRATERECEIVE.Text = "txtTTRATERECEIVE"
        Me.txtTTRATERECEIVE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTTRATEReceive
        '
        Me.lblTTRATEReceive.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTTRATEReceive.Location = New System.Drawing.Point(2, 34)
        Me.lblTTRATEReceive.Name = "lblTTRATEReceive"
        Me.lblTTRATEReceive.Size = New System.Drawing.Size(75, 20)
        Me.lblTTRATEReceive.TabIndex = 64
        Me.lblTTRATEReceive.Tag = "TTRATEReceive"
        Me.lblTTRATEReceive.Text = "lblTTRATEReceive"
        '
        'pnSEInfoReceive
        '
        Me.pnSEInfoReceive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnSEInfoReceive.Location = New System.Drawing.Point(1, 99)
        Me.pnSEInfoReceive.Name = "pnSEInfoReceive"
        Me.pnSEInfoReceive.Size = New System.Drawing.Size(428, 237)
        Me.pnSEInfoReceive.TabIndex = 73
        '
        'txtIRATERECEIVE
        '
        Me.txtIRATERECEIVE.Enabled = False
        Me.txtIRATERECEIVE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIRATERECEIVE.Location = New System.Drawing.Point(569, 532)
        Me.txtIRATERECEIVE.Name = "txtIRATERECEIVE"
        Me.txtIRATERECEIVE.Size = New System.Drawing.Size(90, 20)
        Me.txtIRATERECEIVE.TabIndex = 5
        Me.txtIRATERECEIVE.Tag = "IRATERECEIVE"
        Me.txtIRATERECEIVE.Text = "txtIRATERECEIVE"
        '
        'btnAdjust
        '
        Me.btnAdjust.Location = New System.Drawing.Point(636, 426)
        Me.btnAdjust.Name = "btnAdjust"
        Me.btnAdjust.Size = New System.Drawing.Size(80, 25)
        Me.btnAdjust.TabIndex = 92
        Me.btnAdjust.Tag = "btnAdjust"
        Me.btnAdjust.Text = "btnAdjust"
        Me.btnAdjust.Visible = False
        '
        'frmExchangeSEGRDeal
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ClientSize = New System.Drawing.Size(893, 458)
        Me.Controls.Add(Me.btnAdjust)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.pnSplit)
        Me.Controls.Add(Me.txtACTYPE)
        Me.Controls.Add(Me.lblDealInfo)
        Me.Controls.Add(Me.lblTTLOAN)
        Me.Controls.Add(Me.btnAllocate)
        Me.Controls.Add(Me.btnDOWN)
        Me.Controls.Add(Me.btnUP)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.txtPAIDPENAFEE)
        Me.Controls.Add(Me.btnCANCEL)
        Me.Controls.Add(Me.lbllPAIDPENAFEE)
        Me.Controls.Add(Me.lblACTYPENAME)
        Me.Controls.Add(Me.pnMemberReceive)
        Me.Controls.Add(Me.pnMember)
        Me.Controls.Add(Me.lblAcType)
        Me.Controls.Add(Me.txtLRATE)
        Me.Controls.Add(Me.lblLRATE)
        Me.Controls.Add(Me.lblLNINFOR)
        Me.Controls.Add(Me.txtPAIDFEE)
        Me.Controls.Add(Me.txtIRATERECEIVE)
        Me.Controls.Add(Me.txtIRATE)
        Me.Controls.Add(Me.pnlTitle)
        Me.Controls.Add(Me.lblIRATE)
        Me.Controls.Add(Me.lblPAIDFEE)
        Me.Controls.Add(Me.txtMRATE)
        Me.Controls.Add(Me.lblMRATE)
        Me.Controls.Add(Me.txtPAIDINT)
        Me.Controls.Add(Me.lblTOTALFEE)
        Me.Controls.Add(Me.lblPAIDINT)
        Me.Controls.Add(Me.txtTOTALFEE)
        Me.Controls.Add(Me.txtPAIDAMT)
        Me.Controls.Add(Me.lblTOTALPENAFEE)
        Me.Controls.Add(Me.lblPAIDAMT)
        Me.Controls.Add(Me.txtTOTALPENAFEE)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(200, 100)
        Me.MaximizeBox = False
        Me.Name = "frmExchangeSEGRDeal"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "frmExchangeSEGRDeal"
        Me.Text = "frmExchangeSEGRDeal"
        Me.pnlTitle.ResumeLayout(False)
        Me.pnlTitle.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnMember.ResumeLayout(False)
        Me.pnMember.PerformLayout()
        Me.pnMemberReceive.ResumeLayout(False)
        Me.pnMemberReceive.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region " Declare constant and variables "
    Const c_ResourceManager = "_DIRECT.frmExchangeSEGRDeal-"
    Private mv_strSYMBOLLIST As String
    Private mv_strAuthCustID As String
    Private mv_strCurrentTime As String
    Private mv_strTellerName As String
    Private mv_strBusDate As String
    Private mv_strTellerType As String
    Private mv_strTxDate As String
    Private mv_blnAdvanceOrder As Boolean = True
    Private mv_blnUPCOMOrder As Boolean
    Private mv_blnViewMode As Boolean = False
    Private mv_strTranStatus As String
    Private mv_strDeltd As String
    Private mv_xmlDocumentInquiryData As Xml.XmlDocument
    Private mv_ResourceManager As Resources.ResourceManager
    Private mv_arrObjFields() As CFieldMaster
    Private mv_arrObjFldVals() As CFieldVal

    Private mv_strRRNAME As String = ""
    Private mv_strCUSTBANK As String = ""
    Private mv_strCIACCTNO As String = ""
    Private mv_strRRTYPE As String = ""
    Private mv_strLIMITCHK As String = ""
    Private mv_strOPTPRICE As String = ""
    Private mv_strCALLTYPE As String = ""
    Private mv_strDEALACTYPE As String = ""
    Private mv_strTypeCondition As String = "('N','R','P','B')"
    Private mv_strXmlMessageData As String
    Private mv_strLocalObject As String
    Private mv_strBranchId As String
    Private mv_strTellerId As String
    Private mv_strIpAddress As String
    Private mv_strWsName As String
    Private mv_strTxNum As String = String.Empty
    Private mv_isBackDate As Boolean = False
    Private mv_arrSYMBOL As Hashtable
    Private mv_strObjectName As String
    Private mv_strTltxcd As String
    Private mv_strModuleCode As String
    Private mv_strLanguage As String
    Private mv_strKeyFieldType As String
    Private mv_strKeyFieldValue As String
    Private mv_blnIsHistoryView As Boolean = False
    Dim mv_strTableName As String = ""
    Dim mv_intExecFlag As String = ""
    Dim mv_strTellerRight As String = ""
    Dim mv_strGroupCareBy As String = ""
    Dim mv_strAuthString As String = ""
    Dim mv_strKeyFieldName As String = ""
    Dim mv_strLinkValue As String = ""
    Dim mv_strLinkFIeld As String = ""
    Dim mv_strDFTYPE As String
    Dim mv_strAFACCTNO As String
    Private mv_dblSumAmt As Double
    Private mv_GroupCareBy As String = ""
    Private mv_InitParam As String = ""
    Private mv_CloseOnFinish As Boolean = False
    Private mv_ReturnValue As String = ""



#End Region

#Region " Properties "

    Public Property SYMBOLLIST() As String
        Get
            Return mv_strSYMBOLLIST
        End Get
        Set(ByVal Value As String)
            mv_strSYMBOLLIST = Value
        End Set
    End Property

    Public Property AuthCustomer() As String
        Get
            Return mv_strAuthCustID
        End Get
        Set(ByVal Value As String)
            mv_strAuthCustID = Value
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
    Public Property TransactionDeleted() As String
        Get
            Return mv_strDeltd
        End Get
        Set(ByVal Value As String)
            mv_strDeltd = Value
        End Set
    End Property
    Public Property TransactionStatus() As String
        Get
            Return mv_strTranStatus
        End Get
        Set(ByVal Value As String)
            mv_strTranStatus = Value
        End Set
    End Property
    Public Property ViewMode() As Boolean
        Get
            Return mv_blnViewMode
        End Get
        Set(ByVal Value As Boolean)
            mv_blnViewMode = Value
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
    Public Property KeyFieldType() As String
        Get
            Return mv_strKeyFieldType
        End Get
        Set(ByVal Value As String)
            mv_strKeyFieldType = Value
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


    Public Property InitParam() As String
        Get
            Return mv_InitParam
        End Get
        Set(ByVal Value As String)
            mv_InitParam = Value
        End Set
    End Property

    Public Property ReturnValue() As String
        Get
            Return mv_ReturnValue
        End Get
        Set(ByVal Value As String)
            mv_ReturnValue = Value
        End Set
    End Property


    Public Property TableName() As String
        Get
            Return mv_strTableName
        End Get
        Set(ByVal Value As String)
            mv_strTableName = Value
        End Set
    End Property

    Public Property ExeFlag() As Integer
        Get
            Return mv_intExecFlag
        End Get
        Set(ByVal Value As Integer)
            mv_intExecFlag = Value
        End Set
    End Property

    Public Property TellerRight() As String
        Get
            Return mv_strTellerRight
        End Get
        Set(ByVal Value As String)
            mv_strTellerRight = Value
        End Set
    End Property

    Public Property GroupCareBy() As String
        Get
            Return mv_strGroupCareBy
        End Get
        Set(ByVal Value As String)
            mv_strGroupCareBy = Value
        End Set
    End Property

    Public Property AuthString() As String
        Get
            Return mv_strAuthString
        End Get
        Set(ByVal Value As String)
            mv_strAuthString = Value
        End Set
    End Property

    Public Property KeyFieldName() As String
        Get
            Return mv_strKeyFieldName
        End Get
        Set(ByVal Value As String)
            mv_strKeyFieldName = Value
        End Set
    End Property
    Public Property KeyFieldValue() As String
        Get
            Return mv_strKeyFieldValue
        End Get
        Set(ByVal Value As String)
            mv_strKeyFieldValue = Value
        End Set
    End Property

    Public Property LinkValue() As String
        Get
            Return mv_strLinkValue
        End Get
        Set(ByVal Value As String)
            mv_strLinkValue = Value
        End Set
    End Property

    Public Property LinkFIeld() As String
        Get
            Return mv_strLinkFIeld
        End Get
        Set(ByVal Value As String)
            mv_strLinkFIeld = Value
        End Set
    End Property

    Public Property CALLTYPE() As String
        Get
            Return mv_strCALLTYPE
        End Get
        Set(ByVal Value As String)
            mv_strCALLTYPE = Value
        End Set
    End Property

#End Region

#Region " InitExternal"
    Private Sub InitExternal()


        'Khởi tạo SE Grid
        Dim v_cmrSEMemberHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrSEMemberHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrSEMemberHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)

        SEMemberGrid = New GridEx
        SEMemberGrid.FixedHeaderRows.Add(v_cmrSEMemberHeader)
        SEMemberGrid.Columns.Add(New Xceed.Grid.Column("ACCTNO", GetType(System.String)))
        SEMemberGrid.Columns.Add(New Xceed.Grid.Column("SYMBOL", GetType(System.String)))
        SEMemberGrid.Columns.Add(New Xceed.Grid.Column("QTTY", GetType(System.Decimal)))
        SEMemberGrid.Columns.Add(New Xceed.Grid.Column("BASICPRICE", GetType(System.Decimal)))
        SEMemberGrid.Columns.Add(New Xceed.Grid.Column("MAXRELEASE", GetType(System.Decimal)))
        SEMemberGrid.Columns.Add(New Xceed.Grid.Column("LOT", GetType(System.Decimal)))
        SEMemberGrid.Columns.Add(New Xceed.Grid.Column("QTTYRELEASE", GetType(System.Decimal)))
        SEMemberGrid.Columns.Add(New Xceed.Grid.Column("IRATE", GetType(System.Decimal)))
        SEMemberGrid.Columns.Add(New Xceed.Grid.Column("TADF", GetType(System.Decimal)))
        SEMemberGrid.Columns.Add(New Xceed.Grid.Column("DDF", GetType(System.Decimal)))
        SEMemberGrid.Columns.Add(New Xceed.Grid.Column("DFRATE", GetType(System.Decimal)))
        SEMemberGrid.Columns.Add(New Xceed.Grid.Column("AMTRELEASEALL", GetType(System.Decimal)))
        SEMemberGrid.Columns.Add(New Xceed.Grid.Column("AMTRELEASE", GetType(System.Decimal)))
        SEMemberGrid.Columns.Add(New Xceed.Grid.Column("DEALTYPE", GetType(System.String)))



        SEMemberGrid.Columns("ACCTNO").Title = "ACCTNO"
        SEMemberGrid.Columns("SYMBOL").Title = "Mã CK"
        SEMemberGrid.Columns("QTTY").Title = "Số lượng"
        SEMemberGrid.Columns("MAXRELEASE").Title = "MAXRELEASE"
        SEMemberGrid.Columns("LOT").Title = "LOT"
        SEMemberGrid.Columns("QTTYRELEASE").Title = "Hoán đổi"
        SEMemberGrid.Columns("IRATE").Title = "IRATE"
        SEMemberGrid.Columns("TADF").Title = "TADF"
        SEMemberGrid.Columns("DDF").Title = "DDF"
        SEMemberGrid.Columns("DFRATE").Title = "DFRATE"
        SEMemberGrid.Columns("BASICPRICE").Title = "Giá vay"
        SEMemberGrid.Columns("AMTRELEASEALL").Title = "AMTRELEASEALL"
        SEMemberGrid.Columns("AMTRELEASE").Title = "AMTRELEASE"
        SEMemberGrid.Columns("DEALTYPE").Title = "DEALTYPE"



        SEMemberGrid.Columns("SYMBOL").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        SEMemberGrid.Columns("LOT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        SEMemberGrid.Columns("QTTY").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        SEMemberGrid.Columns("QTTY").FormatSpecifier = "#,##0"
        SEMemberGrid.Columns("MAXRELEASE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        SEMemberGrid.Columns("MAXRELEASE").FormatSpecifier = "#,##0"
        SEMemberGrid.Columns("QTTYRELEASE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        SEMemberGrid.Columns("QTTYRELEASE").FormatSpecifier = "#,##0"

        SEMemberGrid.Columns("SYMBOL").Width = 50
        SEMemberGrid.Columns("QTTY").Width = 100
        SEMemberGrid.Columns("MAXRELEASE").Width = 0
        SEMemberGrid.Columns("LOT").Width = 0
        SEMemberGrid.Columns("QTTYRELEASE").Width = 100
        SEMemberGrid.Columns("IRATE").Width = 0
        SEMemberGrid.Columns("TADF").Width = 0
        SEMemberGrid.Columns("DDF").Width = 0
        SEMemberGrid.Columns("DFRATE").Width = 0
        SEMemberGrid.Columns("BASICPRICE").Width = 100
        SEMemberGrid.Columns("AMTRELEASEALL").Width = 0
        SEMemberGrid.Columns("AMTRELEASE").Width = 0
        SEMemberGrid.Columns("ACCTNO").Width = 0
        SEMemberGrid.Columns("DEALTYPE").Width = 0


        SEMemberGrid.Width = pnSEInfo.Width
        SEMemberGrid.Height = pnSEInfo.Height
        SEMemberGrid.Columns("QTTYRELEASE").ReadOnly = False
        'SEMemberGrid.ReadOnly = False
        Me.pnSEInfo.Controls.Clear()
        Me.pnSEInfo.Controls.Add(SEMemberGrid)

        If Me.SEMemberGrid.DataRowTemplate.Cells.Count >= 0 Then
            For i As Integer = 1 To Me.SEMemberGrid.DataRowTemplate.Cells.Count - 1
                AddHandler SEMemberGrid.DataRowTemplate.Cells(i).ValueChanged, AddressOf SEMemberLeavingEdit
            Next
        End If


        'Khởi tạo SEMortage Grid
        Dim v_cmrMortageHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrMortageHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrMortageHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)

        SEMortageGrid = New GridEx
        SEMortageGrid.FixedHeaderRows.Add(v_cmrMortageHeader)
        SEMortageGrid.Columns.Add(New Xceed.Grid.Column("ACCTNO", GetType(System.String)))
        SEMortageGrid.Columns.Add(New Xceed.Grid.Column("SYMBOL", GetType(System.String)))
        SEMortageGrid.Columns.Add(New Xceed.Grid.Column("QTTY", GetType(System.Decimal)))
        SEMortageGrid.Columns.Add(New Xceed.Grid.Column("AMTRELEASEALL", GetType(System.Decimal)))
        SEMortageGrid.Columns.Add(New Xceed.Grid.Column("BASICPRICE", GetType(System.Decimal)))
        SEMortageGrid.Columns.Add(New Xceed.Grid.Column("MAXRELEASE", GetType(System.Decimal)))
        SEMortageGrid.Columns.Add(New Xceed.Grid.Column("LOT", GetType(System.Decimal)))
        SEMortageGrid.Columns.Add(New Xceed.Grid.Column("QTTYRELEASE", GetType(System.Decimal)))
        SEMortageGrid.Columns.Add(New Xceed.Grid.Column("AMTRELEASE", GetType(System.Decimal)))
        SEMortageGrid.Columns.Add(New Xceed.Grid.Column("IRATE", GetType(System.Decimal)))
        SEMortageGrid.Columns.Add(New Xceed.Grid.Column("TADF", GetType(System.Decimal)))
        SEMortageGrid.Columns.Add(New Xceed.Grid.Column("DDF", GetType(System.Decimal)))
        SEMortageGrid.Columns.Add(New Xceed.Grid.Column("DFRATE", GetType(System.Decimal)))
        SEMortageGrid.Columns.Add(New Xceed.Grid.Column("DEALTYPE", GetType(System.String)))
        SEMortageGrid.Columns.Add(New Xceed.Grid.Column("LNACCTNO", GetType(System.String)))
        SEMortageGrid.Columns.Add(New Xceed.Grid.Column("CODEID", GetType(System.String)))
        SEMortageGrid.Columns.Add(New Xceed.Grid.Column("ORDERID", GetType(System.String)))
        SEMortageGrid.Columns.Add(New Xceed.Grid.Column("DFACCTNO", GetType(System.String)))



        SEMortageGrid.Columns("ORDERID").Title = "ORDERID"
        SEMortageGrid.Columns("DEALTYPE").Title = "DEALTYPE"
        SEMortageGrid.Columns("LNACCTNO").Title = "LNACCTNO"
        SEMortageGrid.Columns("DFACCTNO").Title = "DFACCTNO"
        SEMortageGrid.Columns("CODEID").Title = "CODEID"
        SEMortageGrid.Columns("ACCTNO").Title = "ACCTNO"
        SEMortageGrid.Columns("SYMBOL").Title = "Mã CK"
        SEMortageGrid.Columns("QTTY").Title = "KL bán"
        SEMortageGrid.Columns("MAXRELEASE").Title = "MAXRELEASE"
        SEMortageGrid.Columns("LOT").Title = "LOT"
        SEMortageGrid.Columns("QTTYRELEASE").Title = "KL Chuyển"
        SEMortageGrid.Columns("IRATE").Title = "IRATE"
        SEMortageGrid.Columns("TADF").Title = "TADF"
        SEMortageGrid.Columns("DDF").Title = "DDF"
        SEMortageGrid.Columns("DFRATE").Title = "DFRATE"
        SEMortageGrid.Columns("BASICPRICE").Title = "BASICPRICE"
        SEMortageGrid.Columns("AMTRELEASEALL").Title = "Giá trị"
        SEMortageGrid.Columns("AMTRELEASE").Title = "Giá trị chuyển"


        SEMortageGrid.Columns("SYMBOL").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        SEMortageGrid.Columns("LOT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        SEMortageGrid.Columns("QTTY").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        SEMortageGrid.Columns("QTTY").FormatSpecifier = "#,##0"
        SEMortageGrid.Columns("MAXRELEASE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        SEMortageGrid.Columns("MAXRELEASE").FormatSpecifier = "#,##0"
        SEMortageGrid.Columns("QTTYRELEASE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        SEMortageGrid.Columns("QTTYRELEASE").FormatSpecifier = "#,##0"
        SEMortageGrid.Columns("AMTRELEASEALL").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        SEMortageGrid.Columns("AMTRELEASEALL").FormatSpecifier = "#,##0"
        SEMortageGrid.Columns("AMTRELEASE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        SEMortageGrid.Columns("AMTRELEASE").FormatSpecifier = "#,##0"


        SEMortageGrid.Columns("SYMBOL").Width = 50
        SEMortageGrid.Columns("QTTY").Width = 80
        SEMortageGrid.Columns("MAXRELEASE").Width = 0
        SEMortageGrid.Columns("LOT").Width = 0
        SEMortageGrid.Columns("QTTYRELEASE").Width = 80
        SEMortageGrid.Columns("IRATE").Width = 0
        SEMortageGrid.Columns("TADF").Width = 0
        SEMortageGrid.Columns("DDF").Width = 0
        SEMortageGrid.Columns("DFRATE").Width = 0
        SEMortageGrid.Columns("BASICPRICE").Width = 0
        SEMortageGrid.Columns("AMTRELEASEALL").Width = 90
        SEMortageGrid.Columns("AMTRELEASE").Width = 90
        SEMortageGrid.Columns("ACCTNO").Width = 0
        SEMortageGrid.Columns("LNACCTNO").Width = 0
        SEMortageGrid.Columns("DEALTYPE").Width = 0
        SEMortageGrid.Columns("CODEID").Width = 0
        SEMortageGrid.Columns("ORDERID").Width = 0
        SEMortageGrid.Columns("DFACCTNO").Width = 0


        SEMortageGrid.Width = pnMortage.Width
        SEMortageGrid.Height = pnMortage.Height
        SEMortageGrid.Columns("QTTYRELEASE").ReadOnly = False
        'SEMortageGrid.ReadOnly = False
        Me.pnMortage.Controls.Clear()
        Me.pnMortage.Controls.Add(SEMortageGrid)

        If Me.SEMortageGrid.DataRowTemplate.Cells.Count >= 0 Then
            For i As Integer = 1 To Me.SEMortageGrid.DataRowTemplate.Cells.Count - 1
                AddHandler SEMortageGrid.DataRowTemplate.Cells(i).ValueChanged, AddressOf SEMortageLeavingEdit
            Next
        End If



        'Khởi tạo SEInfoReceive Grid
        Dim v_cmrInfoReceiveHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrInfoReceiveHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrInfoReceiveHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)

        SEInfoReceive = New GridEx
        SEInfoReceive.FixedHeaderRows.Add(v_cmrInfoReceiveHeader)

        SEInfoReceive.Columns.Add(New Xceed.Grid.Column("ACCTNO", GetType(System.String)))
        SEInfoReceive.Columns.Add(New Xceed.Grid.Column("SYMBOL", GetType(System.String)))
        SEInfoReceive.Columns.Add(New Xceed.Grid.Column("QTTY", GetType(System.Decimal)))
        SEInfoReceive.Columns.Add(New Xceed.Grid.Column("BASICPRICE", GetType(System.Decimal)))
        SEInfoReceive.Columns.Add(New Xceed.Grid.Column("MAXRELEASE", GetType(System.Decimal)))
        SEInfoReceive.Columns.Add(New Xceed.Grid.Column("LOT", GetType(System.Decimal)))
        SEInfoReceive.Columns.Add(New Xceed.Grid.Column("QTTYRELEASE", GetType(System.Decimal)))
        SEInfoReceive.Columns.Add(New Xceed.Grid.Column("DEALTYPE", GetType(System.String)))
        SEInfoReceive.Columns.Add(New Xceed.Grid.Column("IRATE", GetType(System.Decimal)))
        SEInfoReceive.Columns.Add(New Xceed.Grid.Column("DFREF", GetType(System.String)))
        SEInfoReceive.Columns.Add(New Xceed.Grid.Column("DDF", GetType(System.Decimal)))
        SEInfoReceive.Columns.Add(New Xceed.Grid.Column("DFRATE", GetType(System.Decimal)))
        SEInfoReceive.Columns.Add(New Xceed.Grid.Column("AMTRELEASEALL", GetType(System.Decimal)))
        SEInfoReceive.Columns.Add(New Xceed.Grid.Column("AMTRELEASE", GetType(System.Decimal)))
        SEInfoReceive.Columns.Add(New Xceed.Grid.Column("LNACCTNO", GetType(System.String)))
        SEInfoReceive.Columns.Add(New Xceed.Grid.Column("CODEID", GetType(System.String)))

        SEInfoReceive.Columns("ACCTNO").Title = "ACCTNO"
        SEInfoReceive.Columns("SYMBOL").Title = "Mã CK"
        SEInfoReceive.Columns("QTTY").Title = "Số lượng"
        SEInfoReceive.Columns("MAXRELEASE").Title = "MAXRELEASE"
        SEInfoReceive.Columns("LOT").Title = "LOT"
        SEInfoReceive.Columns("QTTYRELEASE").Title = "Hoán đổi"
        SEInfoReceive.Columns("IRATE").Title = "IRATE"
        SEInfoReceive.Columns("DFREF").Title = "DFREF"
        SEInfoReceive.Columns("DDF").Title = "DDF"
        SEInfoReceive.Columns("DFRATE").Title = "DFRATE"
        SEInfoReceive.Columns("BASICPRICE").Title = "Giá vay"
        SEInfoReceive.Columns("AMTRELEASEALL").Title = "AMTRELEASEALL"
        SEInfoReceive.Columns("AMTRELEASE").Title = "AMTRELEASE"
        SEInfoReceive.Columns("DEALTYPE").Title = "DEALTYPE"
        SEInfoReceive.Columns("LNACCTNO").Title = "LNACCTNO"
        SEInfoReceive.Columns("CODEID").Title = "CODEID"


        SEInfoReceive.Columns("SYMBOL").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        SEInfoReceive.Columns("LOT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        SEInfoReceive.Columns("QTTY").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        SEInfoReceive.Columns("QTTY").FormatSpecifier = "#,##0"
        SEInfoReceive.Columns("MAXRELEASE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        SEInfoReceive.Columns("MAXRELEASE").FormatSpecifier = "#,##0"
        SEInfoReceive.Columns("QTTYRELEASE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        SEInfoReceive.Columns("QTTYRELEASE").FormatSpecifier = "#,##0"

        SEInfoReceive.Columns("SYMBOL").Width = 50
        SEInfoReceive.Columns("QTTY").Width = 100
        SEInfoReceive.Columns("MAXRELEASE").Width = 0
        SEInfoReceive.Columns("LOT").Width = 0
        SEInfoReceive.Columns("QTTYRELEASE").Width = 100
        SEInfoReceive.Columns("IRATE").Width = 0
        SEInfoReceive.Columns("DFREF").Width = 0
        SEInfoReceive.Columns("DDF").Width = 0
        SEInfoReceive.Columns("DFRATE").Width = 0
        SEInfoReceive.Columns("BASICPRICE").Width = 100
        SEInfoReceive.Columns("AMTRELEASEALL").Width = 0
        SEInfoReceive.Columns("AMTRELEASE").Width = 0
        SEInfoReceive.Columns("ACCTNO").Width = 0
        SEInfoReceive.Columns("LNACCTNO").Width = 0
        SEInfoReceive.Columns("CODEID").Width = 0
        SEInfoReceive.Columns("DEALTYPE").Width = 100


        SEInfoReceive.Width = pnSEInfoReceive.Width
        SEInfoReceive.Height = pnSEInfoReceive.Height
        SEInfoReceive.Columns("QTTYRELEASE").ReadOnly = False
        'SEInfoReceive.ReadOnly = False
        Me.pnSEInfoReceive.Controls.Clear()
        Me.pnSEInfoReceive.Controls.Add(SEInfoReceive)

        If Me.SEInfoReceive.DataRowTemplate.Cells.Count >= 0 Then
            For i As Integer = 1 To Me.SEInfoReceive.DataRowTemplate.Cells.Count - 1
                AddHandler SEInfoReceive.DataRowTemplate.Cells(i).ValueChanged, AddressOf SEInfoReceiveLeavingEdit
            Next
        End If





    End Sub
#End Region

    Private Sub frmExchangeSEGRDeal_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Dim v_intPos As Int16, ctl As Control, strFLDNAME As String, v_intIndex As Integer
        Select Case e.KeyCode
            Case Keys.Escape
                OnClose()
            Case Keys.Enter
                If (Not TypeOf (Me.ActiveControl) Is Button) And (Not TypeOf (Me.ActiveControl) Is GridEx) Then
                    SendKeys.Send("{Tab}")
                    e.Handled = True
                End If
            Case Keys.F5
                If Me.ActiveControl.Name = "txtDealNO" Then
                    Dim frm As New frmSearch(Me.UserLanguage)
                    'ResetScreen(Me)
                    frm.TableName = "DF3001"
                    frm.ModuleCode = "DF"
                    frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                    frm.IsLocalSearch = gc_IsNotLocalMsg
                    frm.IsLookup = "Y"
                    frm.SearchOnInit = False
                    frm.BranchId = Me.BranchId
                    frm.TellerId = Me.TellerId
                    'frm.AFACCTNO = Trim(mskAFACCTNO.Text)
                    'frm.mv_strSearchFilter = " AND DFTRADING>0 "
                    frm.ShowDialog()
                    Me.txtDealNO.Text = Trim(frm.ReturnValue)
                    If Len(frm.ReturnValue) > 0 Then
                        GetDealInfo(frm.ReturnValue)
                    End If
                    frm.Dispose()
                End If
        End Select
    End Sub


    Private Sub frmExchangeSEGRDeal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InitDialog()
    End Sub



    Protected Overridable Function InitDialog()
        'Thiết lập các thuộc tính ban đầu cho form
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL As String, v_strObjMsg As String
        Try
            'Khởi tạo kích thước form và load resource
            mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            LoadResource(Me)


            ResetScreen(Me)

            'Khởi tạo Grid Member
            InitExternal()

            Me.txtDealNO.BackColor = System.Drawing.Color.GreenYellow
            Me.txtDescription.Text = mv_ResourceManager.GetString("frmExchangeSEGRDeal")

            mv_dblSumAmt = 0
            txtDFAMT.Text = "0"
            txtDFAMTRECEIVE.Text = "0"
            txtTOTALINTRECEIVE.Text = "0"
            txtTOTALINT.Text = "0"

            If Me.TxDate.Length > 0 And Me.TxNum.Length > 0 Then
                Dim v_ctrl As Windows.Forms.Control
                For Each v_ctrl In Me.Controls
                    v_ctrl.Enabled = False
                Next

                Viewgrpdeal(TxDate, TxNum)

                mv_dblOnload = False

                Exit Function
            End If



        Catch ex As Exception

        End Try
    End Function

    Private Sub Viewgrpdeal(ByVal TxDate As String, ByVal TxNum As String)
        SEInfoReceive.DataRows.Clear()
        SEMemberGrid.DataRows.Clear()

        Dim v_nodeList As Xml.XmlNodeList
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_strValue, v_strFLDNAME, V_STRDT, l_ACTYPE, l_DFTYPE, l_AUTODRAWNDOWN, l_ISAPPROVE, l_DESCRIPTION, l_GROUPID, l_AFACCTNODRD, l_ref, l_custodycd As String
        Dim l_AFACCTNO, l_DTYPE, l_SYMBOL, l_CODEID, v_strSQL As String
        Dim l_IRATE, l_MRATE, l_LRATE, l_QTTY, l_DFPRICE, l_DFRATE, l_AMT, l_ORGAMT As Double
        Dim v_strSendDeal, v_strDFACCTSendTmp, v_strDFACCTRecTmp, v_strRecDeal As String
        Dim i As Integer

        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL As String, v_strObjMsg As String


        v_strCmdSQL = "SELECT cvalue  STRDT FROM tllogfld WHERE TXNUM  = '" & TxNum & "' AND fldcd='06'"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        v_xmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

        For i = 0 To v_nodeList.Count - 1
            V_STRDT = String.Empty
            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                With v_nodeList.Item(i).ChildNodes(j)
                    v_strValue = Trim(.InnerText.ToString)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    Select Case Trim(v_strFLDNAME)
                        Case "STRDT"
                            V_STRDT = v_strValue

                    End Select
                End With
            Next
        Next

        Dim v_arrGrp(), v_arrdeal(), v_strAftype As String
        v_arrGrp = V_STRDT.Split("@")
        v_arrdeal = V_STRDT.Split("|")

        For i = 0 To v_arrGrp.Length - 2
            v_arrdeal = v_arrGrp(i).Split("|")
            If CStr(v_arrdeal(4)).Trim = "M" Then
                Dim v_xDataRow As Xceed.Grid.DataRow = SEMortageGrid.DataRows.AddNew()
                v_xDataRow.Cells("SYMBOL").Value = CStr(v_arrdeal(1)).Trim
                v_xDataRow.Cells("QTTY").Value = CDec(v_arrdeal(3))
                v_xDataRow.Cells("QTTYRELEASE").Value = CDec(v_arrdeal(3))
                v_xDataRow.Cells("AMTRELEASEALL").Value = CDec(v_arrdeal(2))
                v_xDataRow.Cells("AMTRELEASE").Value = CDec(v_arrdeal(2))
                v_strDFACCTSendTmp = CStr(v_arrdeal(6)).Trim
                v_xDataRow.EndEdit()
                SEMortageGrid.EndInit()
            Else
                Dim v_xInfoRow As Xceed.Grid.DataRow = SEInfoReceive.DataRows.AddNew()
                v_xInfoRow.Cells("SYMBOL").Value = CStr(v_arrdeal(1)).Trim
                v_xInfoRow.Cells("QTTY").Value = CDec(v_arrdeal(3))
                v_xInfoRow.Cells("QTTYRELEASE").Value = CDec(v_arrdeal(3))
                v_xInfoRow.Cells("BASICPRICE").Value = CDec(v_arrdeal(2)) / CDec(v_arrdeal(3))
                v_xInfoRow.Cells("DEALTYPE").Value = CStr(v_arrdeal(4)).Trim
                v_strDFACCTRecTmp = CStr(v_arrdeal(6)).Trim
                v_xInfoRow.EndEdit()
                SEInfoReceive.EndInit()
            End If
        Next

        v_strSQL = "SELECT A.GROUPID SENDDEAL, B.GROUPID RECDEAL FROM vw_dfmast_all A, vw_dfmast_all B WHERE A.ACCTNO = '" & v_strDFACCTSendTmp & "' AND B.ACCTNO = '" & v_strDFACCTRecTmp & "'"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SE_SEMAST, gc_ActionInquiry, v_strSQL)
        v_ws.Message(v_strObjMsg)
        v_xmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

        For i = 0 To v_nodeList.Count - 1
            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                With v_nodeList.Item(i).ChildNodes(j)
                    v_strValue = .InnerText.ToString
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    Select Case Trim(v_strFLDNAME)
                        Case "SENDDEAL"
                            txtDealNO.Text = Trim(v_strValue)
                        Case "RECDEAL"
                            cboAFACCREC.Text = Trim(v_strValue)
                    End Select
                End With
            Next
        Next
        btnCANCEL.Enabled = True

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
    Private Sub ResetScreen(ByRef pv_ctrl As Windows.Forms.Control)
        ResetControl(pv_ctrl)
        lblDealInfo.Text = String.Empty
        lblLNINFOR.Text = String.Empty
        MemberGrid.DataRows.Clear()
        SEMemberGrid.DataRows.Clear()
        Me.txtDescription.Text = mv_ResourceManager.GetString("frmExchangeSEGRDeal")
        mv_dblSumAmt = 0
        txtDFAMT.Text = "0"
        txtDFAMTRECEIVE.Text = "0"
        txtTOTALINTRECEIVE.Text = "0"
        txtTOTALINT.Text = "0"
        txtTTRATE.Text = "0"
        txtTTRATERECEIVE.Text = "0"
        txtSUMVALUE.Text = "0"
        txtSUMVALUEREC.Text = "0"
        mv_blnLoadForm = False

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
                End If
            Next
            Me.Text = mv_ResourceManager.GetString(Me.Name)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub btnGetDeal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetDeal.Click
        'If Len(txtDealNO.Text) > 0 Then
        Dim frm As New frmSearch(Me.UserLanguage)
        'ResetScreen(Me)
        frm.TableName = "DF3001"
        frm.ModuleCode = "DF"
        frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
        frm.IsLocalSearch = gc_IsNotLocalMsg
        frm.IsLookup = "Y"
        frm.SearchOnInit = False
        frm.BranchId = Me.BranchId
        frm.TellerId = Me.TellerId
        'frm.AFACCTNO = Trim(mskAFACCTNO.Text)
        'frm.mv_strSearchFilter = " AND DFTRADING>0 "
        frm.ShowDialog()
        Me.txtDealNO.Text = Trim(frm.ReturnValue)
        If Len(frm.ReturnValue) > 0 Then
            GetDealInfo(frm.ReturnValue)
        End If
        frm.Dispose()
        'End If
    End Sub

    Private Sub GetDealInfo(ByVal v_strDealID As String)
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_strValue, v_strFLDNAME, v_strTEXT, v_strMINBRATIO, v_strMAXBRATIO As String, i, j As Integer
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strCmdSQL As String, v_strObjMsg As String
            ResetScreen(Me)
            'v_strCmdSQL = " SELECT * FROM v_getgrpdealinfo A WHERE A.groupid ='" & v_strDealID & "'"
            v_strCmdSQL = "SELECT A.*, B.* FROM v_getgrpdealinfo A , v_getgrpdealformular B WHERE A.GROUPID=B.GROUPID AND A.groupid ='" & v_strDealID & "'"
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
                                Case "GROUPID"
                                    txtDealNO.Text = Trim(v_strValue)
                                Case "CUSTODYCD"
                                    lblDealInfo.Text = lblDealInfo.Text & Trim(v_strValue) & "  "
                                Case "AFACCTNO"
                                    lblDealInfo.Text = lblDealInfo.Text & Trim(v_strValue) & "  "
                                    mv_strAFACCTNO = Trim(v_strValue)
                                Case "FULLNAME"
                                    lblDealInfo.Text = lblDealInfo.Text & Trim(v_strValue) & "  "
                                Case "DFTYPE"
                                    txtACTYPE.Text = Trim(v_strValue)
                                    mv_strDFTYPE = Trim(v_strValue)
                                Case "DFTYPENAME"
                                    lblACTYPENAME.Text = Trim(v_strValue)
                                Case "LNTYPE"
                                    lblLNINFOR.Text = lblLNINFOR.Text & Trim(v_strValue) & "  "
                                Case "LNTYPENAME"
                                    lblLNINFOR.Text = lblLNINFOR.Text & Trim(v_strValue) & "  "
                                Case "RRTYPE"
                                    lblLNINFOR.Text = lblLNINFOR.Text & Trim(v_strValue) & "  "
                                Case "INTPAIDMETHODDIS"
                                    lblLNINFOR.Text = lblLNINFOR.Text & Trim(v_strValue) & "  "
                                Case "RTTDF"
                                    txtTTRATE.Text = Format(CDbl(v_strValue), gc_FORMAT_NUMBER_2)
                                Case "IRATE"
                                    txtIRATE.Text = Trim(v_strValue)
                                Case "MRATE"
                                    txtMRATE.Text = Trim(v_strValue)
                                Case "LRATE"
                                    txtLRATE.Text = Trim(v_strValue)
                                Case "CURAMT"
                                    txtDFAMT.Text = Format(Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_0)
                                Case "CURINT"
                                    txtTOTALINT.Text = Format(CDbl(Replace(txtTOTALINT.Text, ",", "")) + Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_0)
                                Case "CURFEE"
                                    txtTOTALINT.Text = Format(CDbl(Replace(txtTOTALINT.Text, ",", "")) + Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_0)
                                    txtTOTALFEE.Text = Format(Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_0)
                                Case "FEEINTNMLACR"
                                    txtTOTALPENAFEE.Text = Format(Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_0)
                                Case "LNACCTNO"
                                    mv_strLNACCMOR = Trim(v_strValue)
                                Case "ISVSD"
                                    mv_strISVSD = Trim(v_strValue)

                            End Select
                        End With
                    Next
                Next

                If mv_strISVSD <> "N" Then
                    MsgBox(mv_ResourceManager.GetString("DEALINVALID"), MsgBoxStyle.Information, Me.Text)
                    Me.ActiveControl = Me.btnGetDeal
                    Exit Sub
                End If

                v_strCmdSQL = "SELECT AFACCTNO VALUE, AFACCTNO DISPLAY, GROUPID EN_DISPLAY,AFACCTNO LSTODR FROM DFGROUP DF, DFTYPE DFT WHERE AFACCTNO LIKE '%" & mv_strAFACCTNO & "%' AND GROUPID NOT IN ('" & txtDealNO.Text & "') AND DF.ACTYPE = DFT.ACTYPE AND DFT.ISVSD <> 'Y'"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)
                FillComboEx(v_strObjMsg, cboAFACCREC, "", Me.UserLanguage)

                GetSEMortageGrid(txtDealNO.Text)
                GetSEMemberGrid(txtDealNO.Text)
                GetDealInfoReceive(cboAFACCREC.Text)

            Else
                MsgBox(mv_ResourceManager.GetString("DEALINVALID"), MsgBoxStyle.Information, Me.Text)
                Me.ActiveControl = Me.btnGetDeal
            End If

            mv_blnLoadForm = True
            CalcAmtTrans()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GetDealInfoReceive(ByVal v_strDealID As String)
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_strValue, v_strFLDNAME, v_strTEXT, v_strMINBRATIO, v_strMAXBRATIO As String, i, j As Integer
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strCmdSQL As String, v_strObjMsg As String
            mv_blnLoadForm = False
            'v_strCmdSQL = " SELECT * FROM v_getgrpdealinfo A WHERE A.groupid ='" & v_strDealID & "'"
            v_strCmdSQL = "SELECT A.*, B.* FROM v_getgrpdealinfo A , v_getgrpdealformular B WHERE A.GROUPID=B.GROUPID AND A.groupid ='" & v_strDealID & "'"
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
                                'Case "GROUPID"
                                '    txtDealNO.Text = Trim(v_strValue)
                                'Case "CUSTODYCD"
                                '    lblDealInfo.Text = lblDealInfo.Text & Trim(v_strValue) & "  "
                                'Case "AFACCTNO"
                                '    lblDealInfo.Text = lblDealInfo.Text & Trim(v_strValue) & "  "
                                '    mv_strAFACCTNO = Trim(v_strValue)
                                'Case "FULLNAME"
                                '    lblDealInfo.Text = lblDealInfo.Text & Trim(v_strValue) & "  "
                                'Case "DFTYPE"
                                '    txtACTYPE.Text = Trim(v_strValue)
                                '    mv_strDFTYPE = Trim(v_strValue)
                                'Case "DFTYPENAME"
                                '    lblACTYPENAME.Text = Trim(v_strValue)
                                'Case "LNTYPE"
                                '    lblLNINFOR.Text = lblLNINFOR.Text & Trim(v_strValue) & "  "
                                'Case "LNTYPENAME"
                                '    lblLNINFOR.Text = lblLNINFOR.Text & Trim(v_strValue) & "  "
                                'Case "RRTYPE"
                                '    lblLNINFOR.Text = lblLNINFOR.Text & Trim(v_strValue) & "  "
                                'Case "INTPAIDMETHODDIS"
                                '    lblLNINFOR.Text = lblLNINFOR.Text & Trim(v_strValue) & "  "
                                Case "RTTDF"
                                    txtTTRATERECEIVE.Text = Format(Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_2)
                                Case "IRATE"
                                    txtIRATERECEIVE.Text = Trim(v_strValue)
                                    'Case "MRATE"
                                    '    txtMRATE.Text = Trim(v_strValue)
                                    'Case "LRATE"
                                    '    txtLRATE.Text = Trim(v_strValue)
                                Case "CURAMT"
                                    txtDFAMTRECEIVE.Text = Format(Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_0)
                                Case "CURINT"
                                    txtTOTALINTRECEIVE.Text = Format(CDbl(Replace(txtTOTALINTRECEIVE.Text, ",", "")) + Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_0)
                                Case "CURFEE"
                                    txtTOTALINTRECEIVE.Text = Format(CDbl(Replace(txtTOTALINTRECEIVE.Text, ",", "")) + Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_0)
                                    'Case "FEEINTNMLACR"
                                    '    txtTOTALPENAFEE.Text = Trim(v_strValue)
                                Case "LNACCTNO"
                                    mv_strLNACCSE = Trim(v_strValue)

                            End Select
                        End With
                    Next
                Next

                GetSEInfoReceiveGrid(v_strDealID)
                mv_blnLoadForm = True
                CalcAmtTrans()
            Else
                MsgBox(mv_ResourceManager.GetString("DEALDNOTFOUNT"), MsgBoxStyle.Information, Me.Text)
                Me.ActiveControl = Me.cboAFACCREC
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub OnClose()
        Me.Dispose()
    End Sub

    Private Sub btnCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCANCEL.Click
        OnClose()
    End Sub


    Private Sub txtDealNO_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDealNO.Leave
        If Len(txtDealNO.Text) > 0 Then
            GetDealInfo(txtDealNO.Text)
        End If
    End Sub

    Private Sub txtPAIDAMT_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPAIDAMT.Leave
        If CDbl(txtPAIDAMT.Text) <= CDbl(txtDFAMT.Text) Then
            txtPAIDINT.Text = Format(Math.Round(CDbl(Replace(txtPAIDAMT.Text, ",", ""))) * Math.Round(CDbl(Replace(txtTOTALINT.Text, ",", ""))) / Math.Round(CDbl(Replace(txtDFAMT.Text, ",", ""))), gc_FORMAT_NUMBER_0)
            txtPAIDFEE.Text = Format(Math.Round(CDbl(Replace(txtPAIDAMT.Text, ",", ""))) * Math.Round(CDbl(Replace(txtTOTALFEE.Text, ",", ""))) / Math.Round(CDbl(Replace(txtDFAMT.Text, ",", ""))), gc_FORMAT_NUMBER_0)
            txtPAIDPENAFEE.Text = Format(Math.Round(CDbl(Replace(txtPAIDAMT.Text, ",", ""))) * Math.Round(CDbl(Replace(txtTOTALPENAFEE.Text, ",", ""))) / Math.Round(CDbl(Replace(txtDFAMT.Text, ",", ""))), gc_FORMAT_NUMBER_0)
            GetSEMemberGrid(txtDealNO.Text)
        End If

    End Sub

    Private Sub GetSEMemberGrid(ByVal v_strGroupID As String)
        Dim v_strCmdSQL, v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_dec As Decimal


        v_strCmdSQL = "SELECT DFM.ACCTNO, SEC.SYMBOL, CASE WHEN DFM.DEALTYPE IN('N','T') THEN DFQTTY ELSE  CASE WHEN DFM.DEALTYPE='B' THEN BLOCKQTTY ELSE CASE WHEN DFM.DEALTYPE='R' THEN RCVQTTY " & _
                      " ELSE  CARCVQTTY END END END QTTY, DFM.DFPRICE BASICPRICE, 0 QTTYRELEASE, DFM.DEALTYPE  " & _
                      " FROM DFGROUP DF, DFMAST DFM, DFTYPE DFT, DFBASKET DFB, SECURITIES_INFO SEC  " & _
                      " WHERE DF.GROUPID=DFM.GROUPID AND DFM.ACTYPE=DFT.ACTYPE AND DFT.BASKETID=DFB.BASKETID AND DFM.CODEID=SEC.CODEID AND " & _
                      " DFB.SYMBOL=SEC.SYMBOL AND DFM.DEALTYPE=DFB.DEALTYPE AND DF.GROUPID='" & v_strGroupID & "'"

        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        v_strObjMsgTMP = v_strObjMsg
        FillDataGrid(SEMemberGrid, v_strObjMsg, "")
        'AllocateSERelease()
        'mv_dblPAIDAMT = txtPAIDAMT.Text
        'Dim i As Integer
        'Dim v_decTemp As Decimal
        'For i = 0 To SEMemberGrid.DataRows.Count - 1
        '    SEMemberGrid.DataRows(i).Cells("ORDNUM").Value = CDec(i + 1)
        '    If mv_dblPAIDAMT >= CDbl(SEMemberGrid.DataRows(i).Cells("AMTRELEASEALL").Value) Then
        '        SEMemberGrid.DataRows(i).Cells("QTTYRELEASE").Value = Math.Floor(SEMemberGrid.DataRows(i).Cells("QTTY").Value / SEMemberGrid.DataRows(i).Cells("LOT").Value) * SEMemberGrid.DataRows(i).Cells("LOT").Value
        '        v_decTemp = CDbl(SEMemberGrid.DataRows(i).Cells("AMTRELEASEALL").Value)
        '        SEMemberGrid.DataRows(i).Cells("AMTRELEASE").Value = v_decTemp
        '        mv_dblPAIDAMT = mv_dblPAIDAMT - CDbl(SEMemberGrid.DataRows(i).Cells("AMTRELEASEALL").Value)
        '    Else
        '        'SEMemberGrid.DataRows(i).Cells("QTTYRELEASE").Value = CDec(Format((v_dblTADF - v_dblIRATE / 100 * (v_dblDDF - mv_dblPAIDAMT)) / (v_dblDFRATE / 100 * v_dblBASICPRICE), "#,##0"))
        '        SEMemberGrid.DataRows(i).Cells("QTTYRELEASE").Value = CDec(Math.Floor((CDbl(SEMemberGrid.DataRows(i).Cells("TADF").Value) - CDbl(SEMemberGrid.DataRows(i).Cells("IRATE").Value) / 100 * (CDbl(SEMemberGrid.DataRows(i).Cells("DDF").Value) - mv_dblPAIDAMT)) / (CDbl(SEMemberGrid.DataRows(i).Cells("DFRATE").Value) / 100 * CDbl(SEMemberGrid.DataRows(i).Cells("BASICPRICE").Value)) / SEMemberGrid.DataRows(i).Cells("LOT").Value) * SEMemberGrid.DataRows(i).Cells("LOT").Value)
        '        SEMemberGrid.DataRows(i).Cells("AMTRELEASE").Value = CDec(mv_dblPAIDAMT)
        '        Exit For
        '    End If
        'Next


    End Sub


    Private Sub GetSEInfoReceiveGrid(ByVal v_strGroupID As String)
        Dim v_strCmdSQL, v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_dec As Decimal


        v_strCmdSQL = "SELECT DFM.LNACCTNO,DFM.CODEID, DFM.ACCTNO, SEC.SYMBOL, CASE WHEN DFM.DEALTYPE IN('N') THEN DFQTTY - SECURED ELSE CASE WHEN DFM.DEALTYPE='B' THEN BLOCKQTTY ELSE CASE WHEN DFM.DEALTYPE='R' THEN RCVQTTY  ELSE " & _
                      " CASE WHEN DFM.DEALTYPE='P' THEN  CARCVQTTY ELSE CACASHQTTY  END END END END QTTY, DFM.DFPRICE BASICPRICE, 0 QTTYRELEASE, DFM.DEALTYPE, DFM.DFREF, DFM.DFRATE " & _
                      " FROM DFGROUP DF, v_getdealinfo DFM, DFTYPE DFT, DFBASKET DFB, SECURITIES_INFO SEC  " & _
                      " WHERE DF.GROUPID=DFM.GROUPID AND DFM.ACTYPE=DFT.ACTYPE AND DFT.BASKETID=DFB.BASKETID AND DFM.CODEID=SEC.CODEID AND " & _
                      " DFB.SYMBOL=SEC.SYMBOL AND DFM.DEALTYPE=DFB.DEALTYPE AND DF.GROUPID='" & v_strGroupID & "'"

        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        v_strObjMsgTMP = v_strObjMsg
        FillDataGrid(SEInfoReceive, v_strObjMsg, "")

    End Sub

    Private Sub GetSEMortageGrid(ByVal v_strGroupID As String)
        Dim v_strCmdSQL, v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_dec As Decimal


        v_strCmdSQL = "SELECT DFM.DFRATE, DFM.LNACCTNO,DFM.CODEID, DFM.ACCTNO, DFM.GROUPID,ORGORDERID ORDERID, REFID DFACCTNO , SYMBOL,odm.execqtty QTTY, ODM.execqtty * O.EXPRICE AMTRELEASEALL, 0 QTTYRELEASE, 0 AMTRELEASE, '' DEALTYPE   " & _
                      "  FROM STSCHD OD, SECURITIES_INFO SEC, ODMAPEXT ODM, DFMAST DFM, DFGROUP DFG, ODMAST O " & _
                      "  WHERE DUETYPE='RM' AND OD.QTTY-OD.AQTTY>0 AND OD.CODEID=SEC.CODEID  " & _
                      "  AND OD.ORGORDERID = ODM.ORDERID AND OD.ORGORDERID=O.ORDERID AND ODM.DELTD <> 'Y' AND ODM.REFID=DFM.ACCTNO AND DFM.GROUPID=DFG.GROUPID " & _
                      "  AND ORGORDERID IN (SELECT ORDERID FROM ODMAST WHERE EXECTYPE='MS') AND DFM.GROUPID='" & txtDealNO.Text & "' AND OD.DELTD <> 'Y'"


        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        v_strObjMsgTMP = v_strObjMsg
        FillDataGrid(SEMortageGrid, v_strObjMsg, "")

    End Sub



    Private Sub SEMortageLeavingEdit(ByVal sender As Object, ByVal e As System.EventArgs)
        'Lay thong tin ve chung khoan
        Dim i As Integer
        Dim v_dblSumMortage As Double
        If (SEMortageGrid.CurrentCell Is Nothing) Then
            Exit Sub
        End If
        If (SEMortageGrid.CurrentRow Is SEMortageGrid.HeaderRows) Then
            Exit Sub
        End If

        v_dblSumMortage = 0

        If Me.SEMortageGrid.DataRows.Count > 0 Then
            For i = 0 To Me.SEMortageGrid.DataRows.Count - 1
                If Not IsNumeric(SEMortageGrid.DataRows(i).Cells("QTTYRELEASE").Value) Then
                    Exit Sub
                ElseIf SEMortageGrid.DataRows(i).Cells("QTTYRELEASE").Value > SEMortageGrid.DataRows(i).Cells("QTTY").Value Then
                    MessageBox.Show(mv_ResourceManager.GetString("ERR_QTTYRELEASE_INVALID"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    SEMortageGrid.DataRows(i).Cells("QTTYRELEASE").Value = CDec(0)
                    SEMortageGrid.DataRows(i).Cells("AMTRELEASE").Value = CDec(0)
                    Exit Sub
                Else
                    SEMortageGrid.DataRows(i).Cells("AMTRELEASE").Value = SEMortageGrid.DataRows(i).Cells("AMTRELEASEALL").Value / SEMortageGrid.DataRows(i).Cells("QTTY").Value * SEMortageGrid.DataRows(i).Cells("QTTYRELEASE").Value
                    v_dblSumMortage = v_dblSumMortage + SEMortageGrid.DataRows(i).Cells("AMTRELEASE").Value
                End If
            Next
            If mv_blnLoadForm Then
                CalcAmtTrans()
            End If
        End If

    End Sub


    Private Sub SEMemberLeavingEdit(ByVal sender As Object, ByVal e As System.EventArgs)
        'Lay thong tin ve chung khoan
        Dim i As Integer
        Dim v_dblSumMortage As Double
        If (SEMemberGrid.CurrentCell Is Nothing) Then
            Exit Sub
        End If
        If (SEMemberGrid.CurrentRow Is SEMemberGrid.HeaderRows) Then
            Exit Sub
        End If

        v_dblSumMortage = 0

        If Me.SEMemberGrid.DataRows.Count > 0 Then
            For i = 0 To Me.SEMemberGrid.DataRows.Count - 1
                If Not IsNumeric(SEMemberGrid.DataRows(i).Cells("QTTYRELEASE").Value) Then
                    Exit Sub
                ElseIf SEMemberGrid.DataRows(i).Cells("QTTYRELEASE").Value > SEMemberGrid.DataRows(i).Cells("QTTY").Value Then
                    MessageBox.Show(mv_ResourceManager.GetString("ERR_QTTYRELEASE_INVALID"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    SEMemberGrid.DataRows(i).Cells("QTTYRELEASE").Value = CDec(0)
                    SEMemberGrid.DataRows(i).Cells("AMTRELEASE").Value = CDec(0)
                    Exit Sub
                Else
                    SEMemberGrid.DataRows(i).Cells("AMTRELEASE").Value = SEMemberGrid.DataRows(i).Cells("QTTYRELEASE").Value * SEMemberGrid.DataRows(i).Cells("BASICPRICE").Value
                    v_dblSumMortage = v_dblSumMortage + SEMemberGrid.DataRows(i).Cells("AMTRELEASE").Value
                End If
            Next

            'CalcAmtTrans()
        End If

    End Sub

    Private Sub SEInfoReceiveLeavingEdit(ByVal sender As Object, ByVal e As System.EventArgs)
        'Lay thong tin ve chung khoan
        Dim i As Integer
        Dim v_dblSumMortage As Double
        If (SEInfoReceive.CurrentCell Is Nothing) Then
            Exit Sub
        End If
        If (SEInfoReceive.CurrentRow Is SEInfoReceive.HeaderRows) Then
            Exit Sub
        End If

        v_dblSumMortage = 0

        If Me.SEInfoReceive.DataRows.Count > 0 Then
            For i = 0 To Me.SEInfoReceive.DataRows.Count - 1
                If Not IsNumeric(SEInfoReceive.DataRows(i).Cells("QTTYRELEASE").Value) Then
                    Exit Sub
                ElseIf SEInfoReceive.DataRows(i).Cells("QTTYRELEASE").Value > SEInfoReceive.DataRows(i).Cells("QTTY").Value Then
                    MessageBox.Show(mv_ResourceManager.GetString("ERR_QTTYRELEASE_INVALID"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    SEInfoReceive.DataRows(i).Cells("QTTYRELEASE").Value = CDec(0)
                    SEInfoReceive.DataRows(i).Cells("AMTRELEASE").Value = CDec(0)
                    Exit Sub
                Else
                    SEInfoReceive.DataRows(i).Cells("AMTRELEASE").Value = SEInfoReceive.DataRows(i).Cells("QTTYRELEASE").Value * SEInfoReceive.DataRows(i).Cells("BASICPRICE").Value
                    v_dblSumMortage = v_dblSumMortage + SEInfoReceive.DataRows(i).Cells("AMTRELEASE").Value
                End If
            Next
            If mv_blnLoadForm Then
                CalcAmtTrans()
            End If
        End If

    End Sub

    Private Sub CalcAmtTrans()
        Dim v_dblSumMortage, v_dblSumValue, v_dblSumValueRec, v_dblSumTemp As Double
        Dim i As Integer
        Dim v_strTEMP As String

        Dim v_strCmdSQL, v_strObjMsg, v_strClause As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_dec As Decimal
        Dim v_blnExitFor As Boolean
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strValue, v_strFLDNAME, v_strTEXT, v_strSTSCHD, v_strSTSCHDRec As String
        Dim j, k, m, n, intSEQ As Integer
        Dim v_dblINTMIN, v_dblFEEMIN, v_dblCURFEE, v_dblCURINT As Double
        Dim v_dblTemp, v_dblDFQTTY, v_dblRCVQTTY, v_dblBLOCKQTTY, v_dblCARCVQTTY, v_dblCACASHQTTY As Double

        Dim v_strMORTAGE, v_strMORTAGERec, v_strODMAPEXT, v_strODMAPEXTRec, v_strDEALTYPE, v_strSE, v_strSERec, v_strDFMAST, v_strDFMASTRec, v_strSEReceive, v_strDFMASTReceive, v_strSQLTmp As String

        intSEQ = 1
        v_strSTSCHDRec = " UNION ALL "
        v_strSTSCHD = " UNION ALL "
        If Me.SEMortageGrid.DataRows.Count > 0 Then
            For i = 0 To Me.SEMortageGrid.DataRows.Count - 1
                With SEMortageGrid.DataRows(i)
                    If .Cells("QTTYRELEASE").Value > 0 Then
                        'v_strTEMP = SEMortageGrid.DataRows(i).Cells("ACCTNO").Value & "|" & SEMortageGrid.DataRows(i).Cells("SYMBOL").Value & "|" & SEMortageGrid.DataRows(i).Cells("QTTYRELEASE").Value & "M" & "@"
                        v_strMORTAGE = v_strMORTAGE & "SELECT ORDERID, REFID, TYPE, ORDERNUM, -" & .Cells("QTTYRELEASE").Value & " QTTY, AMT, DELTD, DFPRICE, DFRATE, STATUS, -" & .Cells("QTTYRELEASE").Value & " EXECQTTY FROM ODMAPEXT WHERE ORDERID = '" & .Cells("ORDERID").Value & "' AND REFID = '" & .Cells("DFACCTNO").Value & "' UNION ALL "

                        v_strMORTAGERec = v_strMORTAGERec & "SELECT 'STSCHD" & Format(intSEQ, "000000") & "' ORDERID, 'MORTAGE" & Format(intSEQ, "000000") & "' REFID, TYPE, ORDERNUM, " & .Cells("QTTYRELEASE").Value & " QTTY, AMT, DELTD, DFPRICE, DFRATE, STATUS, " & .Cells("QTTYRELEASE").Value & " EXECQTTY FROM ODMAPEXT WHERE ORDERID = '" & .Cells("ORDERID").Value & "' AND REFID = '" & .Cells("DFACCTNO").Value & "' UNION ALL "

                        v_strSTSCHDRec = v_strSTSCHDRec & " SELECT 'STSCHD" & Format(intSEQ, "000000") & "' ORDERID ,STS.TXDATE,STS.AFACCTNO, STS.CODEID," & _
                                    " STS.CLEARDAY,STS.CLEARCD, STS.AMT/STS.QTTY * " & .Cells("QTTYRELEASE").Value & " AMT , " & .Cells("QTTYRELEASE").Value & " QTTY, 0 FAMT,0 AAMT,0 PAIDAMT, 0 PAIDFEEAMT, MST.actype, MST.EXECTYPE, " & _
                                    " AF.custid , sts.CLEARDATE, SEC.SYMBOL, (CASE WHEN TYP.VAT='Y' THEN TO_NUMBER(SYS.VARVALUE) ELSE 0 END) SECDUTY " & _
                                    " FROM STSCHD STS,ODMAST MST,AFMAST AF,SBSECURITIES SEC, AFTYPE TYP, SYSVAR SYS " & _
                                    " WHERE STS.ORGORDERID= '" & .Cells("ORDERID").Value & "' AND STS.codeid=SEC.codeid AND STS.orgorderid=MST.orderid and mst.afacctno=af.acctno " & _
                                    " AND STS.DELTD <> 'Y' AND STS.STATUS='N' AND STS.DUETYPE='RM' " & _
                                    " AND AF.ACTYPE=TYP.ACTYPE AND SYS.VARNAME='ADVSELLDUTY' AND SYS.GRNAME='SYSTEM' UNION ALL "

                        v_strSTSCHD = v_strSTSCHD & " SELECT ORDERID ,STS.TXDATE,STS.AFACCTNO, STS.CODEID," & _
                                   " STS.CLEARDAY,STS.CLEARCD, -STS.AMT/STS.QTTY * " & .Cells("QTTYRELEASE").Value & " AMT , -" & .Cells("QTTYRELEASE").Value & " QTTY, 0 FAMT,0 AAMT,0 PAIDAMT, 0 PAIDFEEAMT, MST.actype, MST.EXECTYPE, " & _
                                   " AF.custid , sts.CLEARDATE, SEC.SYMBOL, (CASE WHEN TYP.VAT='Y' THEN TO_NUMBER(SYS.VARVALUE) ELSE 0 END) SECDUTY " & _
                                   " FROM STSCHD STS,ODMAST MST,AFMAST AF,SBSECURITIES SEC, AFTYPE TYP, SYSVAR SYS " & _
                                   " WHERE STS.ORGORDERID= '" & .Cells("ORDERID").Value & "' AND STS.codeid=SEC.codeid AND STS.orgorderid=MST.orderid and mst.afacctno=af.acctno " & _
                                   " AND STS.DELTD <> 'Y' AND STS.STATUS='N' AND STS.DUETYPE='RM' " & _
                                   " AND AF.ACTYPE=TYP.ACTYPE AND SYS.VARNAME='ADVSELLDUTY' AND SYS.GRNAME='SYSTEM' UNION ALL "


                        v_strSE = "SELECT ACCTNO, DFRATE, 0 CACASHQTTY, 0 CARCVQTTY, 0 RCVQTTY , -" & .Cells("QTTYRELEASE").Value & " DFQTTY , 0 BLOCKQTTY , AFACCTNO,LNACCTNO, CODEID, GROUPID,  DEALTYPE  FROM DFMAST WHERE ACCTNO ='" & .Cells("DFACCTNO").Value & "' UNION ALL "

                        v_strSERec = v_strSERec & "SELECT 'MORTAGE" & Format(intSEQ, "000000") & "' ACCTNO, " & .Cells("DFRATE").Value & " DFRATE, 0 CACASHQTTY, 0 CARCVQTTY, 0 RCVQTTY , " & .Cells("QTTYRELEASE").Value & " DFQTTY , 0 BLOCKQTTY , '" & mv_strAFACCTNO & "' AFACCTNO, '" & mv_strLNACCSE & "' LNACCTNO, '" & .Cells("CODEID").Value & "' CODEID, '" & cboAFACCREC.Text & "' GROUPID,  'N' DEALTYPE  FROM DUAL UNION ALL "

                        intSEQ = intSEQ + 1
                    End If
                End With
            Next

        End If


        If v_strMORTAGE Is Nothing Then
            v_strMORTAGE = "SELECT ORDERID, REFID, A.TYPE, A.ORDERNUM, 0 QTTY, A.AMT, A.DELTD, A.DFPRICE, A.DFRATE, A.STATUS, 0 EXECQTTY FROM ODMAPEXT A UNION ALL "
        End If
        If v_strMORTAGERec Is Nothing Then
            v_strMORTAGERec = "SELECT ORDERID, REFID, A.TYPE, A.ORDERNUM, 0 QTTY, A.AMT, A.DELTD, A.DFPRICE, A.DFRATE, A.STATUS, 0 EXECQTTY FROM ODMAPEXT A UNION ALL "
        End If

        v_strODMAPEXT = " SELECT ORDERID, REFID, TYPE, ORDERNUM, DELTD, DFPRICE, DFRATE, STATUS, SUM(QTTY) QTTY, SUM(EXECQTTY) EXECQTTY ,SUM(AMT) AMT FROM ( " & _
                    v_strMORTAGE & " SELECT A.ORDERID, A.REFID, A.TYPE, A.ORDERNUM, A.QTTY, A.AMT, A.DELTD, A.DFPRICE, A.DFRATE, A.STATUS, A.EXECQTTY FROM ODMAPEXT A ) GROUP BY ORDERID, REFID, TYPE, ORDERNUM, DELTD, DFPRICE, DFRATE, STATUS"

        v_strODMAPEXTRec = " SELECT ORDERID, REFID, TYPE, ORDERNUM, DELTD, DFPRICE, DFRATE, STATUS, SUM(QTTY) QTTY, SUM(EXECQTTY) EXECQTTY ,SUM(AMT) AMT FROM ( " & _
                            v_strMORTAGERec & " SELECT A.ORDERID, A.REFID, A.TYPE, A.ORDERNUM, A.QTTY, A.AMT, A.DELTD, A.DFPRICE, A.DFRATE, A.STATUS, A.EXECQTTY FROM ODMAPEXT A ) GROUP BY ORDERID, REFID, TYPE, ORDERNUM, DELTD, DFPRICE, DFRATE, STATUS"


        intSEQ = intSEQ + 1

        If Me.SEInfoReceive.DataRows.Count > 0 Then
            For i = 0 To Me.SEInfoReceive.DataRows.Count - 1
                With SEInfoReceive.DataRows(i)
                    If .Cells("QTTYRELEASE").Value > 0 Then

                        v_dblDFQTTY = 0
                        v_dblRCVQTTY = 0
                        v_dblBLOCKQTTY = 0
                        v_dblCARCVQTTY = 0
                        v_dblCACASHQTTY = 0

                        'Kiem tra xem ben Mortage co' ma chung khoan va loai DEALTYPE, DFREF giong' khong, neu khong co thi sinh 1 dong moi'                         
                        v_strSQLTmp = "SELECT * FROM DFMAST WHERE GROUPID='" & txtDealNO.Text & "' AND CODEID= (SELECT CODEID FROM SECURITIES_INFO WHERE SYMBOL='" & .Cells("SYMBOL").Value & "') AND NVL(DFREF,'')= '" & .Cells("DFREF").Value & "'"
                        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strSQLTmp)
                        v_ws.Message(v_strObjMsg)
                        v_xmlDocument.LoadXml(v_strObjMsg)
                        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")


                        If .Cells("DEALTYPE").Value = "T" Then
                            v_dblCACASHQTTY = .Cells("QTTYRELEASE").Value
                        ElseIf .Cells("DEALTYPE").Value = "N" Then
                            v_dblDFQTTY = .Cells("QTTYRELEASE").Value
                        ElseIf .Cells("DEALTYPE").Value = "P" Then
                            v_dblCARCVQTTY = .Cells("QTTYRELEASE").Value
                        ElseIf .Cells("DEALTYPE").Value = "R" Then
                            v_dblRCVQTTY = .Cells("QTTYRELEASE").Value
                        ElseIf .Cells("DEALTYPE").Value = "B" Then
                            v_dblBLOCKQTTY = .Cells("QTTYRELEASE").Value
                        End If

                        If v_nodeList.Count > 0 Then


                            For m = 0 To v_nodeList.Count - 1
                                For n = 0 To v_nodeList.Item(m).ChildNodes.Count - 1
                                    With v_nodeList.Item(m).ChildNodes(n)
                                        'Ghi nhận thuật toán để kiểm tra và tính toán cho từng trư?ng c�ủa giao dịch
                                        v_strValue = .InnerText.ToString
                                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                        Select Case Trim(v_strFLDNAME)
                                            'Case "LNACCTNO"
                                            '    mv_strLNACCMOR = Trim(v_strValue)

                                        End Select
                                    End With
                                Next
                            Next

                            v_strSE = v_strSE & "SELECT 'DFMAST" & Format(intSEQ + 1, "000000") & "' ACCTNO, DFRATE, " & v_dblCACASHQTTY & " CACASHQTTY, " & v_dblCARCVQTTY & " CARCVQTTY, " & v_dblRCVQTTY & " RCVQTTY, " & v_dblDFQTTY & " DFQTTY, " & v_dblBLOCKQTTY & " BLOCKQTTY, " & _
                                        "AFACCTNO, '" & mv_strLNACCMOR & "'LNACCTNO, CODEID,'" & txtDealNO.Text & "' GROUPID, DEALTYPE FROM DFMAST WHERE ACCTNO ='" & .Cells("ACCTNO").Value & "' UNION ALL "

                            v_strSERec = v_strSERec & "SELECT ACCTNO, DFRATE, -" & v_dblCACASHQTTY & " CACASHQTTY, -" & v_dblCARCVQTTY & " CARCVQTTY, -" & v_dblRCVQTTY & " RCVQTTY, -" & v_dblDFQTTY & " DFQTTY, -" & v_dblBLOCKQTTY & " BLOCKQTTY, " & _
                                        "AFACCTNO, '" & mv_strLNACCSE & "' LNACCTNO, CODEID, '" & cboAFACCREC.Text & "' GROUPID , DEALTYPE FROM DFMAST WHERE ACCTNO ='" & .Cells("ACCTNO").Value & "' UNION ALL "

                        Else
                            v_strSE = v_strSE & "SELECT 'DFMAST" & Format(intSEQ + 1, "000000") & "' ACCTNO, " & .Cells("DFRATE").Value & " DFRATE, " & v_dblCACASHQTTY & " CACASHQTTY, " & v_dblCARCVQTTY & " CARCVQTTY, " & v_dblRCVQTTY & " RCVQTTY, " & v_dblDFQTTY & " DFQTTY, " & v_dblBLOCKQTTY & " BLOCKQTTY, " & _
                                    "'" & mv_strAFACCTNO & "' AFACCTNO, '" & mv_strLNACCMOR & "' LNACCTNO, '" & .Cells("CODEID").Value & "' CODEID, '" & txtDealNO.Text & "' GROUPID, '" & .Cells("DEALTYPE").Value & "' DEALTYPE FROM DUAL UNION ALL "

                            v_strSERec = v_strSERec & "SELECT '" & .Cells("ACCTNO").Value & "'  ACCTNO, " & .Cells("DFRATE").Value & " DFRATE, -" & v_dblCACASHQTTY & " CACASHQTTY, -" & v_dblCARCVQTTY & " CARCVQTTY, -" & v_dblRCVQTTY & " RCVQTTY, -" & v_dblDFQTTY & " DFQTTY, -" & v_dblBLOCKQTTY & " BLOCKQTTY, " & _
                                    "'" & mv_strAFACCTNO & "' AFACCTNO, '" & mv_strLNACCSE & "' LNACCTNO, '" & .Cells("CODEID").Value & "' CODEID, '" & cboAFACCREC.Text & "' GROUPID, '" & .Cells("DEALTYPE").Value & "' DEALTYPE FROM DUAL UNION ALL "


                        End If
                    End If
                End With
                intSEQ = intSEQ + 1
            Next
        End If


        If v_strSE Is Nothing Then
            v_strSE = "SELECT ACCTNO, DFRATE, 0 CACASHQTTY, 0 CARCVQTTY, 0 RCVQTTY , 0 DFQTTY , 0 BLOCKQTTY , AFACCTNO,LNACCTNO, CODEID, GROUPID,  DEALTYPE  FROM DFMAST UNION ALL "
        End If
        If v_strSERec Is Nothing Then
            v_strSERec = "SELECT ACCTNO, DFRATE, 0 CACASHQTTY, 0 CARCVQTTY, 0 RCVQTTY , 0 DFQTTY , 0 BLOCKQTTY , AFACCTNO,LNACCTNO, CODEID, GROUPID,  DEALTYPE  FROM DFMAST UNION ALL "
        End If

        v_strDFMAST = " SELECT ACCTNO, DFRATE, AFACCTNO, LNACCTNO, CODEID, GROUPID,  DEALTYPE, SUM(CACASHQTTY) CACASHQTTY , SUM(CARCVQTTY) CARCVQTTY ,SUM (RCVQTTY) RCVQTTY , SUM(DFQTTY) DFQTTY, SUM(BLOCKQTTY) BLOCKQTTY FROM ( " & v_strSE & _
                " SELECT ACCTNO, DFRATE, CACASHQTTY, CARCVQTTY,RCVQTTY , DFQTTY ,BLOCKQTTY , AFACCTNO,LNACCTNO, CODEID, GROUPID,  DEALTYPE FROM DFMAST " & _
                ") GROUP BY ACCTNO, DFRATE, AFACCTNO, LNACCTNO, CODEID, GROUPID,  DEALTYPE"

        v_strDFMASTRec = " SELECT ACCTNO, DFRATE, AFACCTNO, LNACCTNO, CODEID, GROUPID,  DEALTYPE, SUM(CACASHQTTY) CACASHQTTY , SUM(CARCVQTTY) CARCVQTTY ,SUM (RCVQTTY) RCVQTTY , SUM(DFQTTY) DFQTTY, SUM(BLOCKQTTY) BLOCKQTTY FROM ( " & v_strSERec & _
        " SELECT ACCTNO, DFRATE, CACASHQTTY, CARCVQTTY,RCVQTTY , DFQTTY ,BLOCKQTTY , AFACCTNO,LNACCTNO, CODEID, GROUPID,  DEALTYPE FROM DFMAST " & _
        ") GROUP BY ACCTNO, DFRATE, AFACCTNO, LNACCTNO, CODEID, GROUPID,  DEALTYPE"


        'Tinh lai ti le thuc te ben chuyen

        v_strCmdSQL = "GETGRPDEALFORMULAR"
        v_strClause = "p_GROUPID!" & txtDealNO.Text & "!varchar2!20^p_Mortage!" & v_strODMAPEXT & "!varchar2!3000^p_DFMAST!" & v_strDFMAST & "!varchar2!3000^p_STSCHD!" & IIf(Len(v_strSTSCHD) > 15, Mid(v_strSTSCHD, 1, Len(v_strSTSCHD) - 11), Mid(v_strSTSCHD, 11)) & "!varchar2!3000^p_EXAMT!" & 0 & "!NUMBER!20^p_TYPE!" & "" & "!varchar2!3000"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL, v_strClause, , , , , , , gc_CommandProcedure)
        'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        v_xmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

        For i = 0 To v_nodeList.Count - 1
            For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                With v_nodeList.Item(i).ChildNodes(j)
                    v_strValue = Trim(.InnerText.ToString)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    Select Case Trim(v_strFLDNAME)
                        Case "RTTDF"
                            txtTTRATE.Text = Format(CDbl(v_strValue), gc_FORMAT_NUMBER_2)
                    End Select
                End With
            Next
        Next

        ' Tinh lai Ti le thuc te cua ben Nhan.

        v_strCmdSQL = "GETGRPDEALFORMULAR"
        v_strClause = "p_GROUPID!" & cboAFACCREC.Text & "!varchar2!20^p_Mortage!" & v_strODMAPEXTRec & "!varchar2!3000^p_DFMAST!" & v_strDFMASTRec & "!varchar2!3000^p_STSCHD!" & IIf(Len(v_strSTSCHDRec) > 15, Mid(v_strSTSCHDRec, 1, Len(v_strSTSCHDRec) - 11), Mid(v_strSTSCHDRec, 11)) & "!varchar2!3000^p_EXAMT!" & 0 & "!NUMBER!20^p_TYPE!" & "" & "!varchar2!3000"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL, v_strClause, , , , , , , gc_CommandProcedure)
        v_ws.Message(v_strObjMsg)
        v_xmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

        For i = 0 To v_nodeList.Count - 1
            For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                With v_nodeList.Item(i).ChildNodes(j)
                    v_strValue = Trim(.InnerText.ToString)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    Select Case Trim(v_strFLDNAME)
                        Case "RTTDF"
                            txtTTRATERECEIVE.Text = Format(CDbl(v_strValue), gc_FORMAT_NUMBER_2)
                    End Select
                End With
            Next
        Next



        ' Tinh lai so tien chuyen cua ca 2 ben

        For i = 0 To SEMortageGrid.DataRows.Count - 1
            With SEMortageGrid.DataRows(i)
                If gf_CorrectNumericField(.Cells("AMTRELEASE").Value) > 0 Then
                    v_dblSumValue = v_dblSumValue + gf_CorrectNumericField(.Cells("AMTRELEASE").Value)
                End If
            End With
        Next

        txtSUMVALUE.Text = Format(Math.Round(CDbl(v_dblSumValue)), gc_FORMAT_NUMBER_0)

        For i = 0 To SEInfoReceive.DataRows.Count - 1
            With SEInfoReceive.DataRows(i)
                If gf_CorrectNumericField(.Cells("AMTRELEASE").Value) > 0 Then
                    v_dblSumValueRec = v_dblSumValueRec + gf_CorrectNumericField(.Cells("AMTRELEASE").Value)
                End If
            End With
        Next

        txtSUMVALUEREC.Text = Format(Math.Round(CDbl(v_dblSumValueRec)), gc_FORMAT_NUMBER_0)


    End Sub

    Private Sub AllocateSERelease()

        Dim i, j As Integer
        Dim v_decTemp As Decimal
        mv_dblPAIDAMT = Math.Round(CDbl(Replace(txtPAIDAMT.Text, ",", "")))
        SEMemberGrid.SortedColumns.Clear()

        For j = 0 To SEMemberGrid.DataRows.Count - 1
            For i = 0 To SEMemberGrid.DataRows.Count - 1
                If SEMemberGrid.DataRows(i).Cells("ORDNUM").Value = CDec(j + 1) Then
                    If mv_dblPAIDAMT >= CDbl(SEMemberGrid.DataRows(i).Cells("AMTRELEASEALL").Value) Then
                        SEMemberGrid.DataRows(i).Cells("QTTYRELEASE").Value = SEMemberGrid.DataRows(i).Cells("QTTY").Value
                        v_decTemp = CDbl(SEMemberGrid.DataRows(i).Cells("AMTRELEASEALL").Value)
                        SEMemberGrid.DataRows(i).Cells("AMTRELEASE").Value = v_decTemp
                        mv_dblPAIDAMT = mv_dblPAIDAMT - CDbl(SEMemberGrid.DataRows(i).Cells("AMTRELEASEALL").Value)


                    Else
                        'SEMemberGrid.DataRows(i).Cells("QTTYRELEASE").Value = CDec(Format((v_dblTADF - v_dblIRATE / 100 * (v_dblDDF - mv_dblPAIDAMT)) / (v_dblDFRATE / 100 * v_dblBASICPRICE), "#,##0"))
                        SEMemberGrid.DataRows(i).Cells("QTTYRELEASE").Value = CDec(Format((CDbl(SEMemberGrid.DataRows(i).Cells("TADF").Value) - CDbl(SEMemberGrid.DataRows(i).Cells("IRATE").Value) / 100 * (CDbl(SEMemberGrid.DataRows(i).Cells("DDF").Value) - mv_dblPAIDAMT)) / (CDbl(SEMemberGrid.DataRows(i).Cells("DFRATE").Value) / 100 * CDbl(SEMemberGrid.DataRows(i).Cells("BASICPRICE").Value)), "#,##0"))
                        SEMemberGrid.DataRows(i).Cells("AMTRELEASE").Value = CDec(mv_dblPAIDAMT)
                    End If
                    Exit For
                End If
            Next
        Next

        SEMemberGrid.SortedColumns.Add("ORDNUM")

    End Sub

    Private Sub btnUP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUP.Click

        Dim thisRow As Xceed.Grid.DataRow = SEMemberGrid.CurrentRow
        Dim previousRow As Xceed.Grid.DataRow
        Dim currRow As Xceed.Grid.DataRow
        Dim sdrl As Xceed.Grid.Collections.ReadOnlyDataRowList = SEMemberGrid.GetSortedDataRows(False)

        'Xceed.Grid.DataRow thisRow = (Xceed.Grid.DataRow)gridControl1.CurrentRow;
        'Xceed.Grid.Collections.ReadOnlyDataRowList sdrl = gridControl1.GetSortedDataRows(false);
        '	int index = sdrl.IndexOf(thisRow);
        Dim index As Integer = sdrl.IndexOf(thisRow)
        Dim temp As Decimal
        If (index > 0) Then

            previousRow = sdrl(index - 1)
            SEMemberGrid.SortedColumns.Clear()

            temp = previousRow.Cells("ORDNUM").Value
            'currRow = previousRow
            previousRow.Cells("ORDNUM").Value = thisRow.Cells("ORDNUM").Value
            'previousRow = thisRow
            thisRow.Cells("ORDNUM").Value = temp
            'thisRow = currRow


            SEMemberGrid.SortedColumns.Add("ORDNUM")
            SEMemberGrid.CurrentRow = thisRow
            SEMemberGrid.SelectedRows.Clear()
            SEMemberGrid.SelectedRows.Add(thisRow)
        End If


        SEMemberGrid.Focus()

    End Sub

    Private Sub btnDOWN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDOWN.Click
        Dim thisRow As Xceed.Grid.DataRow = SEMemberGrid.CurrentRow
        Dim nextRow As Xceed.Grid.DataRow
        Dim sdrl As Xceed.Grid.Collections.ReadOnlyDataRowList = SEMemberGrid.GetSortedDataRows(False)
        Dim index As Integer = sdrl.IndexOf(thisRow)
        Dim temp As Decimal

        If (index < (SEMemberGrid.DataRows.Count - 1)) Then

            nextRow = sdrl(index + 1)
            SEMemberGrid.SortedColumns.Clear()

            temp = nextRow.Cells("ORDNUM").Value
            nextRow.Cells("ORDNUM").Value = thisRow.Cells("ORDNUM").Value
            thisRow.Cells("ORDNUM").Value = temp
            SEMemberGrid.SortedColumns.Add("ORDNUM")
            SEMemberGrid.CurrentRow = thisRow
            SEMemberGrid.SelectedRows.Clear()
            SEMemberGrid.SelectedRows.Add(thisRow)
        End If
        SEMemberGrid.SynchronizeDetailGrids = False
        SEMemberGrid.UpdateDetailGrids()
        'SEMemberGrid.Update()
        SEMemberGrid.Focus()

    End Sub


    Private Sub btnAllocate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllocate.Click
        AllocateSERelease()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        OnSubmit()
    End Sub

    Public Overridable Sub OnSubmit()
        Dim v_strTxMsg, MessageData_NB As String, v_xmlDocument As New Xml.XmlDocument, v_attrColl As Xml.XmlAttributeCollection
        Dim i, j As Integer
        Dim v_blnCheck2Acc As Boolean
        Dim v_intNOSUBMIT As Integer, v_strNEXTTX As String = String.Empty
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strLate, v_strORDERID As String
        Try
            'Control Validate
            If Not ControlValidation() Then
                Exit Sub
            End If


            'Lay thong tin Margin cua tai khoan
            'GetMarginInfo(Me.mskAFACCTNO.Text.Trim, cboCODEID.SelectedValue)
            'Verify và tạo điện giao dịch
            If cboAFACCREC.Items.Count = 0 Then
                MsgBox(mv_ResourceManager.GetString("DEALDNOTFOUNT"), MsgBoxStyle.Information, Me.Text)
                Me.ActiveControl = Me.btnGetDeal
                Exit Sub
            End If
            If txtDealNO.Enabled Then 'Submit lần đầu tiên
                MessageData = vbNullString
                If Not VerifyRules(v_strTxMsg) Then
                    Exit Sub
                Else
                    v_lngError = v_ws.Message(v_strTxMsg)
                    If v_lngError <> ERR_SYSTEM_OK Then
                        'Thông báo lỗi
                        GetErrorFromMessage(v_strTxMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                        Cursor.Current = Cursors.Default
                        If v_lngError <> ERR_SA_CHECKER1_OVR And v_lngError <> ERR_SA_CHECKER2_OVR Then
                            'Reset lai Description

                            MessageBox.Show(v_strErrorMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        Else
                            'Lấy thêm nguyên nhân duyệt
                            GetReasonFromMessage(v_strTxMsg, v_strErrorMessage, Me.UserLanguage)
                            MessageBox.Show(v_strErrorMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    End If
                    MessageData = v_strTxMsg
                End If
                ShowAdjustButton(True)
            Else
                v_xmlDocument.LoadXml(MessageData)

                v_strLate = CType(v_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeLATE), Xml.XmlAttribute).Value
                If String.Compare(v_strLate, "0") = 0 Then
                    v_strTxMsg = MessageData
                    v_lngError = v_ws.Message(v_strTxMsg)
                    If v_lngError <> ERR_SYSTEM_OK Then
                        Me.ReturnValue = ""
                        'Thông báo lỗi
                        GetErrorFromMessage(v_strTxMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                        Cursor.Current = Cursors.Default
                        If v_lngError <> ERR_SA_CHECKER1_OVR And v_lngError <> ERR_SA_CHECKER2_OVR Then
                            MessageBox.Show(v_strErrorMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        Else
                            'Lấy thêm nguyên nhân duyệt
                            GetReasonFromMessage(v_strTxMsg, v_strErrorMessage, Me.UserLanguage)
                            MessageBox.Show(v_strErrorMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        'Get OrderID
                        Dim v_node As XmlNode = v_xmlDocument.SelectSingleNode("TransactMessage/fields/entry[@fldname='04']")
                        If Not v_node Is Nothing Then
                            Me.ReturnValue = v_node.InnerXml
                        End If
                        'End
                    End If
                End If
                ResetScreen(Me)
            End If

        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ControlValidation() As Boolean
        Dim i As Integer

        If CDbl(Replace(txtSUMVALUEREC.Text, ",", "")) <= 0 Then
            MsgBox(mv_ResourceManager.GetString("ERR_AMT_INFO"), MsgBoxStyle.Information, Me.Text)
            'Me.ActiveControl = txtPAIDAMT
            Return False
        End If

        ''Tổng giá trị hoán đổi bên nhận phải >= tổng giá trị được tính toán ở bên hợp đông cầm cố chuyển.
        'If CDbl(Replace(txtSUMVALUEREC.Text, ",", "")) < CDbl(Replace(txtSUMVALUE.Text, ",", "")) Then
        '    MsgBox(mv_ResourceManager.GetString("ERR_SUM_AMT_INFO"), MsgBoxStyle.Information, Me.Text)
        '    Return False
        'End If

        If (CDbl(txtTTRATE.Text) < CDbl(txtIRATE.Text)) Or (CDbl(Replace(txtTTRATERECEIVE.Text, ",", "")) < CDbl(Replace(txtIRATERECEIVE.Text, ",", ""))) Then
            MsgBox(mv_ResourceManager.GetString("ERR_RATE_INFO"), MsgBoxStyle.Information, Me.Text)
            Return False
        End If

        Return True
    End Function


    Private Function VerifyRules(ByRef v_strTxMsg As String) As Boolean

        Try
            Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
            Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode, v_intIndex As Long, v_intCount As Integer
            Dim v_strFLDNAME As String, v_strFLDDEFNAME As String, v_strDATATYPE As String, v_strFLDVALUE As String
            Dim v_strERRMSG, v_strENERRMSG, v_strOPERATOR, v_strVALEXP, v_strVALEXP2 As String, v_strACTYPE, v_strDESC As String
            Dim v_dtVALEXP, v_dtVALEXP2, v_dtFLDVALUE As Date
            Dim v_ctl As Control, v_attrFLDNAME As Xml.XmlAttribute, v_attrDATATYPE As Xml.XmlAttribute, v_objEval As New Evaluator
            Dim i, j As Integer


            Dim v_strSTRING As String


            For i = 0 To SEMortageGrid.DataRows.Count - 1
                With SEMortageGrid.DataRows(i)
                    If gf_CorrectNumericField(.Cells("AMTRELEASE").Value) > 0 Then
                        'Truong dau tien la ORDERID,SYMBOL,AMTRELEASE, QTTYRELEASE, DEALTYPE, TO_GROUPID, DFACCTNO
                        v_strSTRING = v_strSTRING & .Cells("ORDERID").Value & "|" & gf_CorrectStringField(.Cells("SYMBOL").Value) & "|" & gf_CorrectNumericField(.Cells("AMTRELEASE").Value) & "|" & gf_CorrectNumericField(.Cells("QTTYRELEASE").Value) & "|M|" & cboAFACCREC.Text & "|" & gf_CorrectStringField(.Cells("DFACCTNO").Value) & "@"
                    End If
                End With
            Next

            For i = 0 To SEMemberGrid.DataRows.Count - 1
                With SEMemberGrid.DataRows(i)
                    If gf_CorrectNumericField(.Cells("QTTYRELEASE").Value) > 0 Then
                        'Truong dau tien la DFACCTNO,SYMBOL,AMTRELEASE, QTTYRELEASE, DEALTYPE,TO_GROUPID, DFACCTNO
                        v_strSTRING = v_strSTRING & .Cells("ACCTNO").Value & "|" & gf_CorrectStringField(.Cells("SYMBOL").Value) & "|" & gf_CorrectNumericField(.Cells("AMTRELEASE").Value) & "|" & gf_CorrectNumericField(.Cells("QTTYRELEASE").Value) & "|" & gf_CorrectStringField(.Cells("DEALTYPE").Value) & "|" & cboAFACCREC.Text & "|" & gf_CorrectStringField(.Cells("DFACCTNO").Value) & "@"
                    End If
                End With
            Next


            For i = 0 To SEInfoReceive.DataRows.Count - 1
                With SEInfoReceive.DataRows(i)
                    If gf_CorrectNumericField(.Cells("QTTYRELEASE").Value) > 0 Then
                        'Truong dau tien la DFACCTNO,SYMBOL,AMTRELEASE, QTTYRELEASE, DEALTYPE, TO_GROUPID, DFACCTNO
                        v_strSTRING = v_strSTRING & .Cells("ACCTNO").Value & "|" & gf_CorrectStringField(.Cells("SYMBOL").Value) & "|" & gf_CorrectNumericField(.Cells("AMTRELEASE").Value) & "|" & gf_CorrectNumericField(.Cells("QTTYRELEASE").Value) & "|" & gf_CorrectStringField(.Cells("DEALTYPE").Value) & "|" & txtDealNO.Text & "|" & gf_CorrectStringField(.Cells("ACCTNO").Value) & "@"
                    End If
                End With
            Next

            'Tạo điện giao dịch 2688- dung de tao gd hoan doi chung khoan
            LoadScreen("2688")
            v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, "2688", Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)
            v_xmlDocument.LoadXml(v_strTxMsg)
            v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")
            If mv_arrObjFields.GetLength(0) > 0 Then
                For v_intIndex = 0 To mv_arrObjFields.GetLength(0) - 1 Step 1
                    If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                        v_strFLDNAME = mv_arrObjFields(v_intIndex).FieldName
                        v_strDATATYPE = mv_arrObjFields(v_intIndex).DataType
                        Select Case Trim(v_strFLDNAME)
                            Case "20" 'GROUPID
                                v_strFLDVALUE = txtDealNO.Text
                            Case "06" 'STRDATA
                                v_strFLDVALUE = v_strSTRING
                            Case "30" 'DESC
                                v_strFLDVALUE = Me.txtDescription.Text
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
            v_strTxMsg = v_xmlDocument.InnerXml

            Return True
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function


    '---------------------------------------------------------------------------------------------------------
    'Hàm này được sử dụng để nạp màn hình.
    'Biến vào 
    '   strTLTXCD là mã giao dịch, dùng để xác định các trư?ng trong giao dịch
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

            'Lấy thông tin chung v? giao d�ịch
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
                                'If v_strValue = "Y" Then
                                '    mv_blnAcctEntry = True
                                'Else
                                '    mv_blnAcctEntry = False
                                'End If
                            Case "BGCOLOR"

                        End Select

                    End With
                Next
            Next

            'Lấy thông tin chi tiết các trư?ng c�ủa giao dịch
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
                        'Xử lý cho trư?ng Description
                        v_strDefVal = Me.Text
                    ElseIf v_strDefVal = "<$BUSDATE>" Then
                        'L�ấy ngày làm việc hiện tại
                        v_strDefVal = Me.BusDate
                    End If
                    If v_blnChain Then
                        'Nếu giao dịch được nạp qua giao dịch tra cứu
                        If Len(v_strChainName) > 0 Then
                            'Nếu trư?ng n�ày có sử dụng CHAINNAME để lấy giá trị từ màn hình tra cứu
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

            'Lấy các luật kiểm tra của các trư?ng giao d�ịch
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
                        'Ghi nhận thuật toán để kiểm tra và tính toán cho từng trư?ng c�ủa giao dịch
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

                '?i�?u ki�ện xử lý
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

    Private Sub cboAFACCREC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAFACCREC.Validated
        'GetSEInfoReceiveGrid(cboAFACCREC.Text)
        GetDealInfoReceive(cboAFACCREC.Text)
    End Sub

    Private Sub ShowAdjustButton(ByVal pv_Enable As Boolean)
        If pv_Enable Then

            btnAdjust.Visible = True
            btnAdjust.Enabled = True
            txtDealNO.Enabled = False
            cboAFACCREC.Enabled = False
            txtPAIDAMT.Enabled = False
            SEMortageGrid.Enabled = False
            SEInfoReceive.Enabled = False
            txtDescription.Enabled = False
            btnGetDeal.Enabled = False
        Else
            btnOK.Visible = True
            btnOK.Enabled = True
            btnAdjust.Visible = False
            btnAdjust.Enabled = False
            btnGetDeal.Enabled = True
            txtDealNO.Enabled = True
            cboAFACCREC.Enabled = True
            txtPAIDAMT.Enabled = True
            SEMortageGrid.Enabled = True
            SEInfoReceive.Enabled = True

        End If
    End Sub

    Private Sub btnAdjust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdjust.Click
        ShowAdjustButton(False)
    End Sub
End Class
