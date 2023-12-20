Imports CommonLibrary
Imports AppCore
'Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports System.IO.Path
Imports System.Windows.Forms.Application

Public Class frmPaymentOrder
    Inherits AppCore.frmSearch

    Private mv_strLanguage As String
    Private mv_ResourceManager As Resources.ResourceManager
    Private c_ResourceManager As String = "_DIRECT.frmPaymentOrder-"
    Private c_SearchResourceManager As String = "AppCore.frmSearch-"
    Private Const LEN_AFACCTNO As Integer = 10
    Private mv_arrObjFields() As CFieldMaster
    Private mv_arrObjFldVals() As CFieldVal
    Private c_BankTyp As String = "N"
    'System.Windows.Forms.TextBox
    Friend WithEvents txtBANKNAME As System.Windows.Forms.TextBox
    Friend WithEvents lblTXNUM As System.Windows.Forms.Label
    Friend WithEvents txtTXNUM As System.Windows.Forms.Label
    Friend WithEvents cmdPrePrint As System.Windows.Forms.Button
    Friend WithEvents txtBANKACCNAME As System.Windows.Forms.TextBox
    Friend WithEvents lblBANKACCNAME As System.Windows.Forms.Label
    Friend WithEvents lblBANKACC As System.Windows.Forms.Label
    Friend WithEvents txtBANKACC As System.Windows.Forms.TextBox
    Dim mv_strBANKID As String = String.Empty
    Dim mv_strBANKNAME As String = String.Empty
    Dim mv_strBANKACC As String = String.Empty
    Dim mv_strBANKACCNAME As String = String.Empty
    Dim mv_strLastBANKID As String = String.Empty
    Dim mv_strLastCitad As String = String.Empty
    Dim mv_strGLACCOUNT As String = String.Empty
    Friend WithEvents lblGLACCTNO As System.Windows.Forms.Label
    Friend WithEvents txtGLACCTNO As System.Windows.Forms.TextBox
    Dim mv_blnAcctEntry As Boolean
    Friend WithEvents lblGLNAME As System.Windows.Forms.Label
    Friend WithEvents txtAMT As System.Windows.Forms.Label
    Friend WithEvents lblAMT As System.Windows.Forms.Label
    Dim mv_dblTotalAmt As Double = 0
    Private BranchName As String
    Private BranchAddress As String
    Private BranchPhoneFax As String
    Private ReportTitle As String
    Private HEADOFFICE As String
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents TabTranferInfo As System.Windows.Forms.TabPage
    Friend WithEvents TabBenefInfo As System.Windows.Forms.TabPage
    Friend WithEvents grbMain As System.Windows.Forms.GroupBox
    Friend WithEvents mskBANKID As AppCore.FlexMaskEditBox
    Friend WithEvents lblBANKID As System.Windows.Forms.Label
    Friend WithEvents grbBeneficiary As System.Windows.Forms.GroupBox
    Friend WithEvents txtBENEFNAME As System.Windows.Forms.TextBox
    Friend WithEvents lblBENEFNAME As System.Windows.Forms.Label
    Friend WithEvents txtBENEFBANKNAME As System.Windows.Forms.TextBox
    Friend WithEvents txtBENEFBANKACCT As System.Windows.Forms.TextBox
    Friend WithEvents txtDESCRIPTION As System.Windows.Forms.TextBox
    Friend WithEvents lblDESCRIPTION As System.Windows.Forms.Label
    Friend WithEvents lblBENEFBANKNAME As System.Windows.Forms.Label
    Friend WithEvents lblBENEFBANKACCT As System.Windows.Forms.Label
    
    Friend WithEvents TabAdvanced As System.Windows.Forms.TabPage
    Friend WithEvents lblRRTYPE As System.Windows.Forms.Label
    Friend WithEvents txtSRCACCTNO As AppCore.FlexMaskEditBox
    Friend WithEvents cboRRTYPE As AppCore.ComboBoxEx
    Friend WithEvents lblAVLPOOL As System.Windows.Forms.Label
    Friend WithEvents lblSCRACCTNO As System.Windows.Forms.Label
    Friend WithEvents lblADVAMT As System.Windows.Forms.Label
    Friend WithEvents txtAVLPOOL As System.Windows.Forms.TextBox
    Friend WithEvents txtADVFEEAMT As System.Windows.Forms.TextBox
    Friend WithEvents lblADVFEEAMT As System.Windows.Forms.Label
    Friend WithEvents txtADVAMT As System.Windows.Forms.TextBox
    Friend WithEvents txtPOOLREMAIN As System.Windows.Forms.TextBox
    Friend WithEvents lblPOOLREMAIN As System.Windows.Forms.Label
    Friend WithEvents grbAdvanced As System.Windows.Forms.GroupBox
    Private DEALINGCUSTODYCD As String
    Private Const mv_CONST_PREPRINT As String = "YES"
    Private Const mv_CONST_NOT_PREPRINT As String = "NO"
    Private Const mv_CONST_SEARCHCODE_1104 As String = "CI1104"
    Private Const mv_CONST_SEARCHCODE_3387 As String = "CA3387"
    Private Const mv_CONST_SEARCHCODE_1108 As String = "CI1108"
    Friend WithEvents txtADTXNUM As System.Windows.Forms.TextBox
    Friend WithEvents lblADTXNUM As System.Windows.Forms.Label
    Private Const mv_CONST_SEARCHCODE_ADVANCED As String = "CI1179/CI1178"
    Private mv_strIS1Transaction As String = "Y"
    Private mv_strBANKNAME_REF As String = String.Empty
    Private mv_strBANKACC_REF As String = String.Empty
    Private mv_strBANKCUSNAME_REF As String = String.Empty
    Private mv_strDESC_REF As String = String.Empty
    Private mv_strTLTXCD As String
    Private WithEvents SmartToolBar1 As Xceed.SmartUI.Controls.ToolBar.SmartToolBar
    Private WithEvents ssbInfo As Xceed.SmartUI.Controls.StatusBar.SmartStatusBar
    Friend WithEvents txtDESC As System.Windows.Forms.TextBox
    Friend WithEvents lblDESC As System.Windows.Forms.Label
    Private mv_strBENEFIDCODE_REF As String = String.Empty
    Friend WithEvents lblBANKDTID As System.Windows.Forms.Label
    Friend WithEvents mskBANKDTID As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtCITAD As System.Windows.Forms.TextBox
    Friend WithEvents lblCITAD As System.Windows.Forms.Label
    Private mv_strVoucherID As String = String.Empty


#Region " Windows Form Designer generated code "

    'Public Sub New()
    '    MyBase.New()

    '    'This call is required by the Windows Form Designer.
    '    InitializeComponent()

    '    'Add any initialization after the InitializeComponent() call

    'End Sub

    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New(pv_strLanguage)

        'This call is required by the Windows Form Designer.
        mv_strLanguage = pv_strLanguage
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())

        InitializeComponent()

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
    Friend WithEvents lblBANKNAME As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPaymentOrder))
        Me.SmartToolBar1 = New Xceed.SmartUI.Controls.ToolBar.SmartToolBar(Me.components)
        Me.ssbInfo = New Xceed.SmartUI.Controls.StatusBar.SmartStatusBar(Me.components)
        Me.txtAMT = New System.Windows.Forms.Label()
        Me.lblAMT = New System.Windows.Forms.Label()
        Me.lblGLNAME = New System.Windows.Forms.Label()
        Me.lblGLACCTNO = New System.Windows.Forms.Label()
        Me.txtGLACCTNO = New System.Windows.Forms.TextBox()
        Me.lblBANKACC = New System.Windows.Forms.Label()
        Me.txtBANKACC = New System.Windows.Forms.TextBox()
        Me.cmdPrePrint = New System.Windows.Forms.Button()
        Me.txtBANKACCNAME = New System.Windows.Forms.TextBox()
        Me.lblBANKACCNAME = New System.Windows.Forms.Label()
        Me.txtTXNUM = New System.Windows.Forms.Label()
        Me.lblTXNUM = New System.Windows.Forms.Label()
        Me.txtBANKNAME = New System.Windows.Forms.TextBox()
        Me.lblBANKNAME = New System.Windows.Forms.Label()
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.TabTranferInfo = New System.Windows.Forms.TabPage()
        Me.grbMain = New System.Windows.Forms.GroupBox()
        Me.lblBANKDTID = New System.Windows.Forms.Label()
        Me.mskBANKDTID = New System.Windows.Forms.MaskedTextBox()
        Me.txtDESC = New System.Windows.Forms.TextBox()
        Me.lblDESC = New System.Windows.Forms.Label()
        Me.mskBANKID = New AppCore.FlexMaskEditBox()
        Me.lblBANKID = New System.Windows.Forms.Label()
        Me.TabBenefInfo = New System.Windows.Forms.TabPage()
        Me.grbBeneficiary = New System.Windows.Forms.GroupBox()
        Me.txtCITAD = New System.Windows.Forms.TextBox()
        Me.lblCITAD = New System.Windows.Forms.Label()
        Me.txtBENEFBANKNAME = New System.Windows.Forms.TextBox()
        Me.txtBENEFBANKACCT = New System.Windows.Forms.TextBox()
        Me.txtDESCRIPTION = New System.Windows.Forms.TextBox()
        Me.txtBENEFNAME = New System.Windows.Forms.TextBox()
        Me.lblDESCRIPTION = New System.Windows.Forms.Label()
        Me.lblBENEFBANKNAME = New System.Windows.Forms.Label()
        Me.lblBENEFBANKACCT = New System.Windows.Forms.Label()
        Me.lblBENEFNAME = New System.Windows.Forms.Label()
        Me.TabAdvanced = New System.Windows.Forms.TabPage()
        Me.grbAdvanced = New System.Windows.Forms.GroupBox()
        Me.lblRRTYPE = New System.Windows.Forms.Label()
        Me.txtPOOLREMAIN = New System.Windows.Forms.TextBox()
        Me.lblPOOLREMAIN = New System.Windows.Forms.Label()
        Me.txtADVFEEAMT = New System.Windows.Forms.TextBox()
        Me.lblADVFEEAMT = New System.Windows.Forms.Label()
        Me.lblSCRACCTNO = New System.Windows.Forms.Label()
        Me.lblADVAMT = New System.Windows.Forms.Label()
        Me.txtADVAMT = New System.Windows.Forms.TextBox()
        Me.txtADTXNUM = New System.Windows.Forms.TextBox()
        Me.txtAVLPOOL = New System.Windows.Forms.TextBox()
        Me.lblADTXNUM = New System.Windows.Forms.Label()
        Me.cboRRTYPE = New AppCore.ComboBoxEx()
        Me.lblAVLPOOL = New System.Windows.Forms.Label()
        Me.txtSRCACCTNO = New AppCore.FlexMaskEditBox()
        CType(Me.SmartToolBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ssbInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mv_SymbolTable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabMain.SuspendLayout()
        Me.TabTranferInfo.SuspendLayout()
        Me.grbMain.SuspendLayout()
        Me.TabBenefInfo.SuspendLayout()
        Me.grbBeneficiary.SuspendLayout()
        Me.TabAdvanced.SuspendLayout()
        Me.grbAdvanced.SuspendLayout()
        Me.SuspendLayout()
        '
        'SmartToolBar1
        '
        Me.SmartToolBar1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.SmartToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.SmartToolBar1.Name = "SmartToolBar1"
        Me.SmartToolBar1.Size = New System.Drawing.Size(861, 85)
        Me.SmartToolBar1.TabIndex = 0
        Me.SmartToolBar1.Text = "SMS"
        Me.SmartToolBar1.UIStyle = Xceed.SmartUI.UIStyle.UIStyle.WindowsClassic
        '
        'grbSearchFilter
        '
        Me.grbSearchFilter.Location = New System.Drawing.Point(5, 206)
        Me.grbSearchFilter.Size = New System.Drawing.Size(859, 139)
        Me.grbSearchFilter.Text = "Điều kiện tìm kiếm:"
        '
        'grbSearchResult
        '
        Me.grbSearchResult.Location = New System.Drawing.Point(5, 351)
        Me.grbSearchResult.Size = New System.Drawing.Size(859, 299)
        Me.grbSearchResult.Text = "Kết quả tìm kiếm:"
        '
        'lstCondition
        '
        Me.lstCondition.Size = New System.Drawing.Size(342, 84)
        '
        'ssbInfo
        '
        Me.ssbInfo.Location = New System.Drawing.Point(0, 575)
        Me.ssbInfo.Name = "ssbInfo"
        Me.ssbInfo.Size = New System.Drawing.Size(833, 23)
        Me.ssbInfo.TabIndex = 3
        Me.ssbInfo.Text = "ssbInfo"
        Me.ssbInfo.UIStyle = Xceed.SmartUI.UIStyle.UIStyle.WindowsClassic
        '
        'btnNEXT
        '
        Me.btnNEXT.Location = New System.Drawing.Point(64, 651)
        Me.btnNEXT.Text = "Sau"
        '
        'btnBACK
        '
        Me.btnBACK.Location = New System.Drawing.Point(8, 651)
        Me.btnBACK.Text = "Trước"
        '
        'chkALL
        '
        Me.chkALL.Location = New System.Drawing.Point(317, 654)
        '
        'chkExeAll
        '
        Me.chkExeAll.Location = New System.Drawing.Point(713, 652)
        '
        'chkauto
        '
        Me.chkauto.Location = New System.Drawing.Point(517, 653)
        '
        'txtAMT
        '
        Me.txtAMT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtAMT.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAMT.Location = New System.Drawing.Point(693, 47)
        Me.txtAMT.Name = "txtAMT"
        Me.txtAMT.Size = New System.Drawing.Size(148, 20)
        Me.txtAMT.TabIndex = 37
        Me.txtAMT.Tag = "txtAMT"
        Me.txtAMT.Text = "txtAMT"
        Me.txtAMT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAMT
        '
        Me.lblAMT.Location = New System.Drawing.Point(624, 47)
        Me.lblAMT.Name = "lblAMT"
        Me.lblAMT.Size = New System.Drawing.Size(72, 20)
        Me.lblAMT.TabIndex = 36
        Me.lblAMT.Tag = "lblAMT"
        Me.lblAMT.Text = "lblAMT"
        Me.lblAMT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGLNAME
        '
        Me.lblGLNAME.Location = New System.Drawing.Point(625, 18)
        Me.lblGLNAME.Name = "lblGLNAME"
        Me.lblGLNAME.Size = New System.Drawing.Size(219, 20)
        Me.lblGLNAME.TabIndex = 35
        Me.lblGLNAME.Tag = "lblGLNAME"
        Me.lblGLNAME.Text = "lblGLNAME"
        Me.lblGLNAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblGLNAME.Visible = False
        '
        'lblGLACCTNO
        '
        Me.lblGLACCTNO.Location = New System.Drawing.Point(632, 20)
        Me.lblGLACCTNO.Name = "lblGLACCTNO"
        Me.lblGLACCTNO.Size = New System.Drawing.Size(66, 20)
        Me.lblGLACCTNO.TabIndex = 34
        Me.lblGLACCTNO.Tag = "lblGLACCTNO"
        Me.lblGLACCTNO.Text = "lblGLACCTNO"
        Me.lblGLACCTNO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblGLACCTNO.Visible = False
        '
        'txtGLACCTNO
        '
        Me.txtGLACCTNO.Location = New System.Drawing.Point(620, 19)
        Me.txtGLACCTNO.Name = "txtGLACCTNO"
        Me.txtGLACCTNO.Size = New System.Drawing.Size(223, 21)
        Me.txtGLACCTNO.TabIndex = 2
        Me.txtGLACCTNO.Tag = "txtGLACCTNO"
        Me.txtGLACCTNO.Visible = False
        '
        'lblBANKACC
        '
        Me.lblBANKACC.Location = New System.Drawing.Point(283, 18)
        Me.lblBANKACC.Name = "lblBANKACC"
        Me.lblBANKACC.Size = New System.Drawing.Size(93, 20)
        Me.lblBANKACC.TabIndex = 32
        Me.lblBANKACC.Tag = "lblBANKACC"
        Me.lblBANKACC.Text = "lblBANKACC"
        Me.lblBANKACC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBANKACC
        '
        Me.txtBANKACC.Location = New System.Drawing.Point(382, 18)
        Me.txtBANKACC.Name = "txtBANKACC"
        Me.txtBANKACC.Size = New System.Drawing.Size(162, 21)
        Me.txtBANKACC.TabIndex = 1
        Me.txtBANKACC.Tag = "txtBANKACC"
        '
        'cmdPrePrint
        '
        Me.cmdPrePrint.Location = New System.Drawing.Point(769, 73)
        Me.cmdPrePrint.Name = "cmdPrePrint"
        Me.cmdPrePrint.Size = New System.Drawing.Size(75, 23)
        Me.cmdPrePrint.TabIndex = 26
        Me.cmdPrePrint.Tag = "PrePrint"
        Me.cmdPrePrint.Text = "&In lại"
        Me.cmdPrePrint.UseVisualStyleBackColor = True
        '
        'txtBANKACCNAME
        '
        Me.txtBANKACCNAME.Location = New System.Drawing.Point(117, 74)
        Me.txtBANKACCNAME.MaxLength = 5
        Me.txtBANKACCNAME.Name = "txtBANKACCNAME"
        Me.txtBANKACCNAME.Size = New System.Drawing.Size(499, 21)
        Me.txtBANKACCNAME.TabIndex = 4
        Me.txtBANKACCNAME.Tag = "txtBANKACCNAME"
        '
        'lblBANKACCNAME
        '
        Me.lblBANKACCNAME.AutoSize = True
        Me.lblBANKACCNAME.Location = New System.Drawing.Point(6, 78)
        Me.lblBANKACCNAME.Name = "lblBANKACCNAME"
        Me.lblBANKACCNAME.Size = New System.Drawing.Size(92, 13)
        Me.lblBANKACCNAME.TabIndex = 29
        Me.lblBANKACCNAME.Tag = "lblBANKACCNAME"
        Me.lblBANKACCNAME.Text = "lblBANKACCNAME"
        Me.lblBANKACCNAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTXNUM
        '
        Me.txtTXNUM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtTXNUM.Location = New System.Drawing.Point(693, 74)
        Me.txtTXNUM.Name = "txtTXNUM"
        Me.txtTXNUM.Size = New System.Drawing.Size(75, 20)
        Me.txtTXNUM.TabIndex = 25
        Me.txtTXNUM.Tag = "txtTXNUM"
        Me.txtTXNUM.Text = "txtTXNUM"
        Me.txtTXNUM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTXNUM
        '
        Me.lblTXNUM.Location = New System.Drawing.Point(624, 74)
        Me.lblTXNUM.Name = "lblTXNUM"
        Me.lblTXNUM.Size = New System.Drawing.Size(75, 20)
        Me.lblTXNUM.TabIndex = 24
        Me.lblTXNUM.Tag = "lblTXNUM"
        Me.lblTXNUM.Text = "lblTXNUM"
        Me.lblTXNUM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBANKNAME
        '
        Me.txtBANKNAME.Location = New System.Drawing.Point(118, 47)
        Me.txtBANKNAME.Name = "txtBANKNAME"
        Me.txtBANKNAME.Size = New System.Drawing.Size(498, 21)
        Me.txtBANKNAME.TabIndex = 3
        Me.txtBANKNAME.Tag = "BANKNAME"
        '
        'lblBANKNAME
        '
        Me.lblBANKNAME.Location = New System.Drawing.Point(6, 46)
        Me.lblBANKNAME.Name = "lblBANKNAME"
        Me.lblBANKNAME.Size = New System.Drawing.Size(92, 20)
        Me.lblBANKNAME.TabIndex = 14
        Me.lblBANKNAME.Tag = "lblBANKNAME"
        Me.lblBANKNAME.Text = "lblBANKNAME"
        Me.lblBANKNAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.TabTranferInfo)
        Me.TabMain.Controls.Add(Me.TabBenefInfo)
        Me.TabMain.Controls.Add(Me.TabAdvanced)
        Me.TabMain.Location = New System.Drawing.Point(0, 43)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(861, 156)
        Me.TabMain.TabIndex = 15
        '
        'TabTranferInfo
        '
        Me.TabTranferInfo.BackColor = System.Drawing.Color.LightSteelBlue
        Me.TabTranferInfo.Controls.Add(Me.grbMain)
        Me.TabTranferInfo.Location = New System.Drawing.Point(4, 22)
        Me.TabTranferInfo.Name = "TabTranferInfo"
        Me.TabTranferInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.TabTranferInfo.Size = New System.Drawing.Size(853, 130)
        Me.TabTranferInfo.TabIndex = 0
        Me.TabTranferInfo.Tag = "TabTranferInfo"
        Me.TabTranferInfo.Text = "THÔNG TIN ĐƠN VỊ CHI TRẢ"
        Me.TabTranferInfo.UseVisualStyleBackColor = True
        '
        'grbMain
        '
        Me.grbMain.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grbMain.Controls.Add(Me.lblBANKDTID)
        Me.grbMain.Controls.Add(Me.mskBANKDTID)
        Me.grbMain.Controls.Add(Me.txtDESC)
        Me.grbMain.Controls.Add(Me.lblDESC)
        Me.grbMain.Controls.Add(Me.cmdPrePrint)
        Me.grbMain.Controls.Add(Me.txtAMT)
        Me.grbMain.Controls.Add(Me.txtTXNUM)
        Me.grbMain.Controls.Add(Me.txtBANKACCNAME)
        Me.grbMain.Controls.Add(Me.lblTXNUM)
        Me.grbMain.Controls.Add(Me.mskBANKID)
        Me.grbMain.Controls.Add(Me.lblBANKACCNAME)
        Me.grbMain.Controls.Add(Me.lblAMT)
        Me.grbMain.Controls.Add(Me.lblBANKID)
        Me.grbMain.Controls.Add(Me.lblGLNAME)
        Me.grbMain.Controls.Add(Me.lblBANKACC)
        Me.grbMain.Controls.Add(Me.txtGLACCTNO)
        Me.grbMain.Controls.Add(Me.lblGLACCTNO)
        Me.grbMain.Controls.Add(Me.txtBANKACC)
        Me.grbMain.Controls.Add(Me.txtBANKNAME)
        Me.grbMain.Controls.Add(Me.lblBANKNAME)
        Me.grbMain.Location = New System.Drawing.Point(3, 5)
        Me.grbMain.Name = "grbMain"
        Me.grbMain.Size = New System.Drawing.Size(848, 129)
        Me.grbMain.TabIndex = 0
        Me.grbMain.TabStop = False
        '
        'lblBANKDTID
        '
        Me.lblBANKDTID.Location = New System.Drawing.Point(673, 16)
        Me.lblBANKDTID.Name = "lblBANKDTID"
        Me.lblBANKDTID.Size = New System.Drawing.Size(95, 20)
        Me.lblBANKDTID.TabIndex = 41
        Me.lblBANKDTID.Text = "lblBANKDTID"
        Me.lblBANKDTID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblBANKDTID.Visible = False
        '
        'mskBANKDTID
        '
        Me.mskBANKDTID.Location = New System.Drawing.Point(732, 16)
        Me.mskBANKDTID.Name = "mskBANKDTID"
        Me.mskBANKDTID.Size = New System.Drawing.Size(90, 21)
        Me.mskBANKDTID.TabIndex = 40
        Me.mskBANKDTID.Visible = False
        '
        'txtDESC
        '
        Me.txtDESC.Location = New System.Drawing.Point(117, 101)
        Me.txtDESC.MaxLength = 200
        Me.txtDESC.Name = "txtDESC"
        Me.txtDESC.Size = New System.Drawing.Size(499, 21)
        Me.txtDESC.TabIndex = 38
        Me.txtDESC.Tag = "txtDESC"
        '
        'lblDESC
        '
        Me.lblDESC.Location = New System.Drawing.Point(6, 100)
        Me.lblDESC.Name = "lblDESC"
        Me.lblDESC.Size = New System.Drawing.Size(92, 20)
        Me.lblDESC.TabIndex = 39
        Me.lblDESC.Tag = "lblDESC"
        Me.lblDESC.Text = "lblDESC"
        Me.lblDESC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mskBANKID
        '
        Me.mskBANKID.Location = New System.Drawing.Point(118, 17)
        Me.mskBANKID.Name = "mskBANKID"
        Me.mskBANKID.Size = New System.Drawing.Size(120, 21)
        Me.mskBANKID.TabIndex = 3
        Me.mskBANKID.Tag = "BANKID"
        '
        'lblBANKID
        '
        Me.lblBANKID.Location = New System.Drawing.Point(6, 18)
        Me.lblBANKID.Name = "lblBANKID"
        Me.lblBANKID.Size = New System.Drawing.Size(94, 20)
        Me.lblBANKID.TabIndex = 2
        Me.lblBANKID.Tag = "lblBANKID"
        Me.lblBANKID.Text = "lblBANKID"
        Me.lblBANKID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabBenefInfo
        '
        Me.TabBenefInfo.BackColor = System.Drawing.Color.LightSteelBlue
        Me.TabBenefInfo.Controls.Add(Me.grbBeneficiary)
        Me.TabBenefInfo.Location = New System.Drawing.Point(4, 22)
        Me.TabBenefInfo.Name = "TabBenefInfo"
        Me.TabBenefInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.TabBenefInfo.Size = New System.Drawing.Size(859, 130)
        Me.TabBenefInfo.TabIndex = 1
        Me.TabBenefInfo.Tag = "TabBenefInfo"
        Me.TabBenefInfo.Text = "THÔNG TIN ĐƠN VỊ THỤ HƯỞNG"
        Me.TabBenefInfo.UseVisualStyleBackColor = True
        '
        'grbBeneficiary
        '
        Me.grbBeneficiary.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grbBeneficiary.Controls.Add(Me.txtCITAD)
        Me.grbBeneficiary.Controls.Add(Me.lblCITAD)
        Me.grbBeneficiary.Controls.Add(Me.txtBENEFBANKNAME)
        Me.grbBeneficiary.Controls.Add(Me.txtBENEFBANKACCT)
        Me.grbBeneficiary.Controls.Add(Me.txtDESCRIPTION)
        Me.grbBeneficiary.Controls.Add(Me.txtBENEFNAME)
        Me.grbBeneficiary.Controls.Add(Me.lblDESCRIPTION)
        Me.grbBeneficiary.Controls.Add(Me.lblBENEFBANKNAME)
        Me.grbBeneficiary.Controls.Add(Me.lblBENEFBANKACCT)
        Me.grbBeneficiary.Controls.Add(Me.lblBENEFNAME)
        Me.grbBeneficiary.Location = New System.Drawing.Point(2, 5)
        Me.grbBeneficiary.Name = "grbBeneficiary"
        Me.grbBeneficiary.Size = New System.Drawing.Size(850, 122)
        Me.grbBeneficiary.TabIndex = 0
        Me.grbBeneficiary.TabStop = False
        '
        'txtCITAD
        '
        Me.txtCITAD.Location = New System.Drawing.Point(122, 70)
        Me.txtCITAD.Name = "txtCITAD"
        Me.txtCITAD.Size = New System.Drawing.Size(200, 21)
        Me.txtCITAD.TabIndex = 2
        Me.txtCITAD.Tag = "CITAD"
        '
        'lblCITAD
        '
        Me.lblCITAD.AutoSize = True
        Me.lblCITAD.Location = New System.Drawing.Point(14, 72)
        Me.lblCITAD.Name = "lblCITAD"
        Me.lblCITAD.Size = New System.Drawing.Size(48, 13)
        Me.lblCITAD.TabIndex = 0
        Me.lblCITAD.Tag = "lblCITAD"
        Me.lblCITAD.Text = "lblCITAD"
        Me.lblCITAD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBENEFBANKNAME
        '
        Me.txtBENEFBANKNAME.Location = New System.Drawing.Point(433, 69)
        Me.txtBENEFBANKNAME.Name = "txtBENEFBANKNAME"
        Me.txtBENEFBANKNAME.Size = New System.Drawing.Size(411, 21)
        Me.txtBENEFBANKNAME.TabIndex = 3
        '
        'txtBENEFBANKACCT
        '
        Me.txtBENEFBANKACCT.Location = New System.Drawing.Point(121, 43)
        Me.txtBENEFBANKACCT.Name = "txtBENEFBANKACCT"
        Me.txtBENEFBANKACCT.Size = New System.Drawing.Size(722, 21)
        Me.txtBENEFBANKACCT.TabIndex = 1
        '
        'txtDESCRIPTION
        '
        Me.txtDESCRIPTION.Location = New System.Drawing.Point(121, 96)
        Me.txtDESCRIPTION.Name = "txtDESCRIPTION"
        Me.txtDESCRIPTION.Size = New System.Drawing.Size(723, 21)
        Me.txtDESCRIPTION.TabIndex = 4
        Me.txtDESCRIPTION.Tag = "DESCRIPTION"
        Me.txtDESCRIPTION.MaxLength = 210
        '
        'txtBENEFNAME
        '
        Me.txtBENEFNAME.Location = New System.Drawing.Point(121, 17)
        Me.txtBENEFNAME.Name = "txtBENEFNAME"
        Me.txtBENEFNAME.Size = New System.Drawing.Size(723, 21)
        Me.txtBENEFNAME.TabIndex = 0
        Me.txtBENEFNAME.MaxLength = 70
        '
        'lblDESCRIPTION
        '
        Me.lblDESCRIPTION.AutoSize = True
        Me.lblDESCRIPTION.Location = New System.Drawing.Point(14, 99)
        Me.lblDESCRIPTION.Name = "lblDESCRIPTION"
        Me.lblDESCRIPTION.Size = New System.Drawing.Size(85, 13)
        Me.lblDESCRIPTION.TabIndex = 0
        Me.lblDESCRIPTION.Tag = "lblDESCRIPTION"
        Me.lblDESCRIPTION.Text = "lblDESCRIPTION"
        Me.lblDESCRIPTION.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBENEFBANKNAME
        '
        Me.lblBENEFBANKNAME.AutoSize = True
        Me.lblBENEFBANKNAME.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblBENEFBANKNAME.Location = New System.Drawing.Point(327, 73)
        Me.lblBENEFBANKNAME.Name = "lblBENEFBANKNAME"
        Me.lblBENEFBANKNAME.Size = New System.Drawing.Size(102, 13)
        Me.lblBENEFBANKNAME.TabIndex = 0
        Me.lblBENEFBANKNAME.Tag = "lblBENEFBANKNAME"
        Me.lblBENEFBANKNAME.Text = "lblBENEFBANKNAME"
        Me.lblBENEFBANKNAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBENEFBANKACCT
        '
        Me.lblBENEFBANKACCT.AutoSize = True
        Me.lblBENEFBANKACCT.Location = New System.Drawing.Point(14, 47)
        Me.lblBENEFBANKACCT.Name = "lblBENEFBANKACCT"
        Me.lblBENEFBANKACCT.Size = New System.Drawing.Size(101, 13)
        Me.lblBENEFBANKACCT.TabIndex = 0
        Me.lblBENEFBANKACCT.Tag = "lblBENEFBANKACCT"
        Me.lblBENEFBANKACCT.Text = "lblBENEFBANKACCT"
        Me.lblBENEFBANKACCT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBENEFNAME
        '
        Me.lblBENEFNAME.AutoSize = True
        Me.lblBENEFNAME.Location = New System.Drawing.Point(14, 20)
        Me.lblBENEFNAME.Name = "lblBENEFNAME"
        Me.lblBENEFNAME.Size = New System.Drawing.Size(76, 13)
        Me.lblBENEFNAME.TabIndex = 0
        Me.lblBENEFNAME.Tag = "lblBENEFNAME"
        Me.lblBENEFNAME.Text = "lblBENEFNAME"
        Me.lblBENEFNAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabAdvanced
        '
        Me.TabAdvanced.Controls.Add(Me.grbAdvanced)
        Me.TabAdvanced.Location = New System.Drawing.Point(4, 22)
        Me.TabAdvanced.Name = "TabAdvanced"
        Me.TabAdvanced.Padding = New System.Windows.Forms.Padding(3)
        Me.TabAdvanced.Size = New System.Drawing.Size(859, 130)
        Me.TabAdvanced.TabIndex = 2
        Me.TabAdvanced.Tag = "TabAdvanced"
        Me.TabAdvanced.Text = "THÔNG TIN NGUỒN ỨNG TRƯỚC"
        Me.TabAdvanced.UseVisualStyleBackColor = True
        '
        'grbAdvanced
        '
        Me.grbAdvanced.Controls.Add(Me.lblRRTYPE)
        Me.grbAdvanced.Controls.Add(Me.txtPOOLREMAIN)
        Me.grbAdvanced.Controls.Add(Me.lblPOOLREMAIN)
        Me.grbAdvanced.Controls.Add(Me.txtADVFEEAMT)
        Me.grbAdvanced.Controls.Add(Me.lblADVFEEAMT)
        Me.grbAdvanced.Controls.Add(Me.lblSCRACCTNO)
        Me.grbAdvanced.Controls.Add(Me.lblADVAMT)
        Me.grbAdvanced.Controls.Add(Me.txtADVAMT)
        Me.grbAdvanced.Controls.Add(Me.txtADTXNUM)
        Me.grbAdvanced.Controls.Add(Me.txtAVLPOOL)
        Me.grbAdvanced.Controls.Add(Me.lblADTXNUM)
        Me.grbAdvanced.Controls.Add(Me.cboRRTYPE)
        Me.grbAdvanced.Controls.Add(Me.lblAVLPOOL)
        Me.grbAdvanced.Controls.Add(Me.txtSRCACCTNO)
        Me.grbAdvanced.Location = New System.Drawing.Point(7, 6)
        Me.grbAdvanced.Name = "grbAdvanced"
        Me.grbAdvanced.Size = New System.Drawing.Size(846, 94)
        Me.grbAdvanced.TabIndex = 9
        Me.grbAdvanced.TabStop = False
        Me.grbAdvanced.Tag = "grbAdvanced"
        '
        'lblRRTYPE
        '
        Me.lblRRTYPE.AutoSize = True
        Me.lblRRTYPE.Location = New System.Drawing.Point(8, 18)
        Me.lblRRTYPE.Name = "lblRRTYPE"
        Me.lblRRTYPE.Size = New System.Drawing.Size(55, 13)
        Me.lblRRTYPE.TabIndex = 3
        Me.lblRRTYPE.Tag = "RRTYPE"
        Me.lblRRTYPE.Text = "lblRRTYPE"
        Me.lblRRTYPE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPOOLREMAIN
        '
        Me.txtPOOLREMAIN.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtPOOLREMAIN.Enabled = False
        Me.txtPOOLREMAIN.Location = New System.Drawing.Point(402, 67)
        Me.txtPOOLREMAIN.Name = "txtPOOLREMAIN"
        Me.txtPOOLREMAIN.Size = New System.Drawing.Size(139, 21)
        Me.txtPOOLREMAIN.TabIndex = 6
        Me.txtPOOLREMAIN.Tag = "POOLREMAIN"
        Me.txtPOOLREMAIN.Text = "0"
        Me.txtPOOLREMAIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPOOLREMAIN
        '
        Me.lblPOOLREMAIN.AutoSize = True
        Me.lblPOOLREMAIN.Location = New System.Drawing.Point(269, 69)
        Me.lblPOOLREMAIN.Name = "lblPOOLREMAIN"
        Me.lblPOOLREMAIN.Size = New System.Drawing.Size(83, 13)
        Me.lblPOOLREMAIN.TabIndex = 5
        Me.lblPOOLREMAIN.Tag = "POOLREMAIN"
        Me.lblPOOLREMAIN.Text = "lblPOOLREMAIN"
        Me.lblPOOLREMAIN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtADVFEEAMT
        '
        Me.txtADVFEEAMT.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtADVFEEAMT.Enabled = False
        Me.txtADVFEEAMT.Location = New System.Drawing.Point(117, 67)
        Me.txtADVFEEAMT.Name = "txtADVFEEAMT"
        Me.txtADVFEEAMT.Size = New System.Drawing.Size(139, 21)
        Me.txtADVFEEAMT.TabIndex = 8
        Me.txtADVFEEAMT.Tag = "ADVFEEAMT"
        Me.txtADVFEEAMT.Text = "0"
        Me.txtADVFEEAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblADVFEEAMT
        '
        Me.lblADVFEEAMT.AutoSize = True
        Me.lblADVFEEAMT.Location = New System.Drawing.Point(8, 69)
        Me.lblADVFEEAMT.Name = "lblADVFEEAMT"
        Me.lblADVFEEAMT.Size = New System.Drawing.Size(76, 13)
        Me.lblADVFEEAMT.TabIndex = 7
        Me.lblADVFEEAMT.Tag = "ADVFEEAMT"
        Me.lblADVFEEAMT.Text = "lblADVFEEAMT"
        Me.lblADVFEEAMT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSCRACCTNO
        '
        Me.lblSCRACCTNO.AutoSize = True
        Me.lblSCRACCTNO.Location = New System.Drawing.Point(563, 18)
        Me.lblSCRACCTNO.Name = "lblSCRACCTNO"
        Me.lblSCRACCTNO.Size = New System.Drawing.Size(79, 13)
        Me.lblSCRACCTNO.TabIndex = 4
        Me.lblSCRACCTNO.Tag = "SCRACCTNO"
        Me.lblSCRACCTNO.Text = "lblSCRACCTNO"
        Me.lblSCRACCTNO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblADVAMT
        '
        Me.lblADVAMT.AutoSize = True
        Me.lblADVAMT.Location = New System.Drawing.Point(8, 43)
        Me.lblADVAMT.Name = "lblADVAMT"
        Me.lblADVAMT.Size = New System.Drawing.Size(58, 13)
        Me.lblADVAMT.TabIndex = 7
        Me.lblADVAMT.Tag = "ADVAMT"
        Me.lblADVAMT.Text = "lblADVAMT"
        Me.lblADVAMT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtADVAMT
        '
        Me.txtADVAMT.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtADVAMT.Enabled = False
        Me.txtADVAMT.Location = New System.Drawing.Point(117, 40)
        Me.txtADVAMT.Name = "txtADVAMT"
        Me.txtADVAMT.Size = New System.Drawing.Size(139, 21)
        Me.txtADVAMT.TabIndex = 8
        Me.txtADVAMT.Tag = "ADVAMT"
        Me.txtADVAMT.Text = "0"
        Me.txtADVAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtADTXNUM
        '
        Me.txtADTXNUM.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtADTXNUM.Enabled = False
        Me.txtADTXNUM.Location = New System.Drawing.Point(696, 43)
        Me.txtADTXNUM.Name = "txtADTXNUM"
        Me.txtADTXNUM.Size = New System.Drawing.Size(139, 21)
        Me.txtADTXNUM.TabIndex = 6
        Me.txtADTXNUM.Tag = "ADTXNUM"
        Me.txtADTXNUM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAVLPOOL
        '
        Me.txtAVLPOOL.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtAVLPOOL.Enabled = False
        Me.txtAVLPOOL.Location = New System.Drawing.Point(402, 40)
        Me.txtAVLPOOL.Name = "txtAVLPOOL"
        Me.txtAVLPOOL.Size = New System.Drawing.Size(139, 21)
        Me.txtAVLPOOL.TabIndex = 6
        Me.txtAVLPOOL.Tag = "AVLPOOL"
        Me.txtAVLPOOL.Text = "0"
        Me.txtAVLPOOL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblADTXNUM
        '
        Me.lblADTXNUM.AutoSize = True
        Me.lblADTXNUM.Location = New System.Drawing.Point(563, 46)
        Me.lblADTXNUM.Name = "lblADTXNUM"
        Me.lblADTXNUM.Size = New System.Drawing.Size(65, 13)
        Me.lblADTXNUM.TabIndex = 5
        Me.lblADTXNUM.Tag = "ADTXNUM"
        Me.lblADTXNUM.Text = "lblADTXNUM"
        Me.lblADTXNUM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboRRTYPE
        '
        Me.cboRRTYPE.DisplayMember = "DISPLAY"
        Me.cboRRTYPE.FormattingEnabled = True
        Me.cboRRTYPE.Location = New System.Drawing.Point(117, 14)
        Me.cboRRTYPE.Name = "cboRRTYPE"
        Me.cboRRTYPE.Size = New System.Drawing.Size(425, 21)
        Me.cboRRTYPE.TabIndex = 1
        Me.cboRRTYPE.Tag = "RRTYPE"
        Me.cboRRTYPE.ValueMember = "VALUE"
        '
        'lblAVLPOOL
        '
        Me.lblAVLPOOL.AutoSize = True
        Me.lblAVLPOOL.Location = New System.Drawing.Point(269, 43)
        Me.lblAVLPOOL.Name = "lblAVLPOOL"
        Me.lblAVLPOOL.Size = New System.Drawing.Size(62, 13)
        Me.lblAVLPOOL.TabIndex = 5
        Me.lblAVLPOOL.Tag = "AVLPOOL"
        Me.lblAVLPOOL.Text = "lblAVLPOOL"
        Me.lblAVLPOOL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSRCACCTNO
        '
        Me.txtSRCACCTNO.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtSRCACCTNO.Enabled = False
        Me.txtSRCACCTNO.Location = New System.Drawing.Point(696, 14)
        Me.txtSRCACCTNO.Name = "txtSRCACCTNO"
        Me.txtSRCACCTNO.Size = New System.Drawing.Size(139, 21)
        Me.txtSRCACCTNO.TabIndex = 2
        Me.txtSRCACCTNO.Tag = "SRCACCTNO"
        '
        'frmPaymentOrder
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(861, 694)
        Me.Controls.Add(Me.TabMain)
        Me.Name = "frmPaymentOrder"
        Me.Text = ""
        'Me.Controls.SetChildIndex(Me.SmartToolBar1, 0)
        'Me.Controls.SetChildIndex(Me.ssbInfo, 0)
        Me.Controls.SetChildIndex(Me.chkExeAll, 0)
        Me.Controls.SetChildIndex(Me.chkauto, 0)
        Me.Controls.SetChildIndex(Me.grbSearchResult, 0)
        Me.Controls.SetChildIndex(Me.TabMain, 0)
        Me.Controls.SetChildIndex(Me.chkALL, 0)
        Me.Controls.SetChildIndex(Me.btnBACK, 0)
        Me.Controls.SetChildIndex(Me.btnNEXT, 0)
        Me.Controls.SetChildIndex(Me.grbSearchFilter, 0)
        CType(Me.SmartToolBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ssbInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mv_SymbolTable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabMain.ResumeLayout(False)
        Me.TabTranferInfo.ResumeLayout(False)
        Me.grbMain.ResumeLayout(False)
        Me.grbMain.PerformLayout()
        Me.TabBenefInfo.ResumeLayout(False)
        Me.grbBeneficiary.ResumeLayout(False)
        Me.grbBeneficiary.PerformLayout()
        Me.TabAdvanced.ResumeLayout(False)
        Me.grbAdvanced.ResumeLayout(False)
        Me.grbAdvanced.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Private "
    Private Function CalcTotalAmt() As Double
        Dim v_intRow As Integer
        Try
            mv_dblTotalAmt = 0
            For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
                If Not SearchGrid.DataRows(v_intRow) Is Nothing Then
                    If SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X" Then
                        mv_dblTotalAmt = mv_dblTotalAmt + CDbl(SearchGrid.DataRows(v_intRow).Cells("AMT").Value)
                    End If
                End If
            Next
        Catch ex As Exception

        End Try
        Return mv_dblTotalAmt

    End Function

    Private Sub LoadComboRRType()
        Try
            Dim v_strSQL As String = String.Empty
            Dim v_strObjMsg As String = String.Empty
            Dim v_ws As New BDSDeliveryManagement
            Dim v_xmlDocument As New XmlDocumentEx
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strValue, v_strFLDNAME, v_strErrorSource, v_strErrorMessage As String
            Dim v_lngError As Long = ERR_SYSTEM_OK

            v_strSQL = "SELECT * FROM VW_ADTYPE_INFO"

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
            v_lngError = v_ws.Message(v_strObjMsg)

            If v_lngError <> ERR_SYSTEM_OK Then
                'Thông báo lỗi
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                Cursor.Current = Cursors.Default
                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            End If

            FillComboEx(v_strObjMsg, cboRRTYPE, "", Me.UserLanguage)

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub SetAdvTypeInfo(ByVal pv_strACTYPE As String)
        Try
            Dim v_strSQL As String = String.Empty
            Dim v_strObjMsg As String = String.Empty
            Dim v_ws As New BDSDeliveryManagement
            Dim v_xmlDocument As New XmlDocumentEx
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strValue, v_strFLDNAME, v_strErrorSource, v_strErrorMessage As String
            Dim v_lngError As Long = ERR_SYSTEM_OK
            Dim v_dblTotalADVMINFEE, v_dblADVMINFEE, v_dblADVMINFEEBANK As Double

            Me.txtADVAMT.Text = Format(0, gc_FORMAT_NUMBER_0)
            Me.txtADVFEEAMT.Text = Format(0, gc_FORMAT_NUMBER_0)
            Me.txtPOOLREMAIN.Text = Format(0, gc_FORMAT_NUMBER_0)

            v_strSQL = "SELECT * FROM VW_ADTYPE_INFO WHERE ACTYPE ='" & pv_strACTYPE & "'"

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
            v_lngError = v_ws.Message(v_strObjMsg)

            If v_lngError <> ERR_SYSTEM_OK Then
                'Thông báo lỗi
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                Cursor.Current = Cursors.Default
                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            End If

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "SCRACCTNO"
                                txtSRCACCTNO.Text = Trim(v_strValue)
                            Case "AVLPOOL"
                                txtAVLPOOL.Text = IIf(gf_IsNumeric(v_strValue), Format(CDbl(v_strValue), gc_FORMAT_NUMBER_0), 0)
                        End Select
                    End With
                Next
            Next

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Function GetTXNUM(ByVal pv_strClause As String) As String
        Dim v_strClause, v_strAutoID As String
        'Lấy ra số tự tăng
        v_strClause = pv_strClause '"POTXNUM"
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_wsBDS As New BDSDeliveryManagement
        Try
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strClause, "GetInventory")
            v_wsBDS.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_strAutoID = v_xmlDocument.DocumentElement.Attributes("CLAUSE").Value

            Dim v_strTXNUM As String
            'Tạo số bảng kê = Mã chi nhánh + Số tự tăng
            v_strTXNUM = Me.BranchId & v_strAutoID.PadLeft(Len(gc_FORMAT_ODAUTOID), "0")

            Return v_strTXNUM
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Function

    Private Sub GetBankInfo(ByVal v_strBANKID As String)

        Dim v_ws As New BDSDeliveryManagement

        Try
            v_strBANKID = v_strBANKID.Replace(".", "")
            txtBANKACC.ReadOnly = False
            txtDESC.ReadOnly = False
            txtBANKACCNAME.ReadOnly = False
            If mv_strLastBANKID <> v_strBANKID Then
                'Dim v_strCODEID As String = Me.cboCODEID.SelectedValue
                Dim v_nodeList As Xml.XmlNodeList
                Dim v_xmlDocument As New Xml.XmlDocument
                Dim v_strValue, v_strFLDNAME, v_strTEXT As String, i, j As Integer

                Dim v_strCmdSQL As String, v_strObjMsg, v_strCURRPRICE, v_strSQL, v_strClause As String


                'v_strCmdSQL = "SELECT CF.CUSTID BANKID, CF.FULLNAME BANKNAME, CF.ORGINF BANKACC, CF.DESCRIPTION BANKACCNAME  FROM CFMAST CF WHERE CF.CUSTID = '" & v_strBANKID & "'"
                'v_strCmdSQL = "SELECT A.SHORTNAME BANKID, A.FULLNAME BANKNAME, A.OWNERNAME, A.BANKACCTNO, A.GLACCOUNT FROM BANKNOSTRO A WHERE BANKACCTNO='" & v_strBANKID & "'"
                v_strCmdSQL = "SELECT A.BANKACCTNO BANKID, A.OWNERNAME BANKNAME, A.OWNERNAME, A.BANKACCTNO, A.GLACCOUNT FROM BANKNOSTRO A WHERE AUTOID='" & v_strBANKID & "'"

                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL, , , , , , , , gc_CommandText)
                v_ws.Message(v_strObjMsg)

                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                v_strTEXT = String.Empty

                For i = 0 To v_nodeList.Count - 1
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = Trim(.InnerText.ToString)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)

                                Case "BANKNAME"
                                    mv_strBANKNAME = v_strValue
                                Case "BANKACCTNO"
                                    mv_strBANKACC = v_strValue
                                Case "OWNERNAME"
                                    mv_strBANKACCNAME = v_strValue
                                Case "GLACCOUNT"
                                    mv_strGLACCOUNT = v_strValue
                            End Select
                        End With
                    Next
                Next

                mv_strLastBANKID = v_strBANKID
                txtBANKNAME.Text = mv_strBANKNAME
                txtBANKACC.Text = mv_strBANKACC
                txtBANKACCNAME.Text = mv_strBANKACCNAME
                txtGLACCTNO.Text = mv_strGLACCOUNT
                mskBANKDTID.Text = ""
            End If
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Information, Me.Text)
        Finally
            'v_ws.Dispose()
        End Try
    End Sub

    Private Sub GetBankDTInfo(ByVal v_strBANKID As String)

        Dim v_ws As New BDSDeliveryManagement

        Try
            v_strBANKID = v_strBANKID.Replace(".", "")
            txtBANKACC.ReadOnly = True
            txtDESC.ReadOnly = True
            txtBANKACCNAME.ReadOnly = True
            If mv_strLastBANKID <> v_strBANKID Then
                'Dim v_strCODEID As String = Me.cboCODEID.SelectedValue
                Dim v_nodeList As Xml.XmlNodeList
                Dim v_xmlDocument As New Xml.XmlDocument
                Dim v_strValue, v_strFLDNAME, v_strTEXT As String, i, j As Integer

                Dim v_strCmdSQL As String, v_strObjMsg, v_strCURRPRICE, v_strSQL, v_strClause As String


                'v_strCmdSQL = "SELECT CF.CUSTID BANKID, CF.FULLNAME BANKNAME, CF.ORGINF BANKACC, CF.DESCRIPTION BANKACCNAME  FROM CFMAST CF WHERE CF.CUSTID = '" & v_strBANKID & "'"
                v_strCmdSQL = "SELECT case when BANKCODE='NULL' then BANKNAME else BANKCODE END BANKID , BANKCODE, BANKNAME FROM CRBBANKLIST " & vbNewLine _
                            & " WHERE (case when BANKCODE='NULL' then BANKNAME else BANKCODE END) ='" & v_strBANKID & "'"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL, , , , , , , , gc_CommandText)
                v_ws.Message(v_strObjMsg)

                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                v_strTEXT = String.Empty

                For i = 0 To v_nodeList.Count - 1
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = Trim(.InnerText.ToString)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)

                                Case "BANKNAME"
                                    mv_strBANKNAME = v_strValue

                            End Select
                        End With
                    Next
                Next

                mv_strLastBANKID = v_strBANKID
                txtBANKNAME.Text = mv_strBANKNAME
                txtBANKACC.Text = ""
                txtBANKACCNAME.Text = ""
                txtDESC.Text = ""
                mskBANKID.Text = ""
            End If
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Information, Me.Text)
        Finally
            'v_ws.Dispose()
        End Try
    End Sub

    'Private Sub GetGLInfo(ByVal v_strGLACCTNO As String)

    '    Dim v_ws As New BDSDeliveryManagement

    '    Try
    '        v_strGLACCTNO = v_strGLACCTNO.Replace(".", "")

    '        If mv_strLastGLACCTNO <> v_strGLACCTNO Then
    '            Dim v_nodeList As Xml.XmlNodeList
    '            Dim v_xmlDocument As New Xml.XmlDocument
    '            Dim v_strValue, v_strFLDNAME, v_strTEXT As String, i, j As Integer
    '            Dim v_strGLNAME As String
    '            Dim v_strCmdSQL As String, v_strObjMsg, v_strCURRPRICE, v_strSQL, v_strClause As String


    '            v_strCmdSQL = "SELECT ACCTNO, ACNAME FROM GLMAST WHERE ACTYPE='B' AND ACCTNO = '" & v_strGLACCTNO & "'"
    '            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_GL_GLMAST, gc_ActionInquiry, v_strCmdSQL, , , , , , , , gc_CommandText)
    '            v_ws.Message(v_strObjMsg)

    '            v_xmlDocument.LoadXml(v_strObjMsg)
    '            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

    '            For i = 0 To v_nodeList.Count - 1
    '                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
    '                    With v_nodeList.Item(i).ChildNodes(j)
    '                        v_strValue = Trim(.InnerText.ToString)
    '                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
    '                        Select Case Trim(v_strFLDNAME)

    '                            Case "ACNAME"
    '                                v_strGLNAME = v_strValue
    '                        End Select
    '                    End With
    '                Next
    '            Next

    '            mv_strLastBANKID = v_strGLACCTNO

    '            lblGLNAME.Text = v_strGLNAME

    '        End If
    '    Catch ex As Exception
    '    Finally
    '    End Try
    'End Sub

    Protected Sub LoadResourceLocal(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control

        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is Label Then
                CType(v_ctrl, Label).Text = mv_ResourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString(v_ctrl.Name)
                LoadResourceLocal(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is TabControl Then
                CType(v_ctrl, TabControl).Text = mv_ResourceManager.GetString(v_ctrl.Name)
                LoadResourceLocal(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Button Then
                CType(v_ctrl, Button).Text = mv_ResourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is CheckBox Then
                CType(v_ctrl, CheckBox).Text = mv_ResourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString(v_ctrl.Name)
            End If
        Next

    End Sub

    Protected Function SetPaymentOrderList(ByRef v_strObjMsg As String, ByRef blnFlag As Boolean) As Long
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Dim v_strSQL, v_strClause As String
        Dim lngReturn As Long
        Try
            '0. TXDATE 
            '1. TXNUM  
            '2. AMT
            '3. BRID   
            '4. STATUS 
            '5. BANKID 
            '6. BANKNAME 
            '7. BANKACC 
            '8. BANKACCNAME
            '9. GLACCTNO
            Dim v_strSTATUS As String = "A"
            Dim v_dblAMT As Double = 0
            txtTXNUM.Text = GetTXNUM("POTXNUM")
            txtAMT.Text = FormatNumber(mv_dblTotalAmt, 0) 'FormatNumber(CalcTotalAmt(), 0)
            v_strClause = Me.BusDate & "|" & txtTXNUM.Text & "|" & v_dblAMT & "|" & Me.BranchId & "|" & v_strSTATUS & "|" & mskBANKID.Text.Replace(".", "") & "|" & txtBANKNAME.Text & "|" & txtBANKACC.Text & "|" & txtBANKACCNAME.Text & "|" & txtGLACCTNO.Text
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, ObjectName, gc_ActionAdhoc, , v_strClause, "SetPaymentOrderList", gc_AutoIdUsed)
            blnFlag = True
            lngReturn = v_ws.Message(v_strObjMsg)
            Return lngReturn

        Catch ex As Exception
            Return -1
        End Try
    End Function

    Protected Function OnLocalSearch(ByVal page As Double) As Int32
        Dim i, j As Integer
        Dim v_xColumn As Xceed.Grid.Column, v_strFLDNAME, Value, pv_strModule As String
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Dim strRow, vd As String
        Dim rownumber, v_intFrom, v_intTo As Int32
        Try
            txtADVAMT.Text = 0
            txtADVFEEAMT.Text = 0
            txtPOOLREMAIN.Text = 0

            For i = 0 To lstCondition.Items.Count - 1
                If lstCondition.GetItemChecked(i) Then
                    mv_strSearchFilter &= " AND " & hFilter(lstCondition.Items(i).ToString())
                End If
            Next i

            strRow = "SELECT * FROM VW_ADSCHD_INFO WHERE ADTYPE = '" & cboRRTYPE.SelectedValue & "'"
            strRow &= mv_strSearchFilter

            v_intTo = page * mv_rowpage
            v_intFrom = v_intTo + 1 - mv_rowpage

            strRow = "SELECT * FROM ( SELECT T1.*,ROWNUM RN FROM(" & strRow & ")T1) WHERE RN BETWEEN " & v_intFrom & " AND " & v_intTo

            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, IsLocalSearch, gc_MsgTypeObj, pv_strModule, _
                                                gc_ActionInquiry, strRow)
            v_ws.Message(v_strObjMsg)
            Me.FULLDATA = v_strObjMsg
            'Fill data into search grid
            FillDataGrid(SearchGrid, v_strObjMsg, "AppCore.frmSearch-" & UserLanguage, mv_strTableName, , v_intFrom, v_intTo, CountRow())
            'Format data in search grid
            For Each v_xColumn In SearchGrid.Columns
                v_strFLDNAME = UCase(Trim(v_xColumn.FieldName))
                For i = 0 To mv_arrSrFieldSrch.GetLength(0) - 1
                    If UCase(mv_arrSrFieldSrch(i)) = v_strFLDNAME Then
                        v_xColumn.FormatSpecifier = mv_arrSrFieldFormat(i)
                        Exit For
                    End If
                Next
            Next

            ''Update mouse pointer
            Cursor.Current = Cursors.Default
            SetFocusGrid(Value)
            Me.btnNEXT.Enabled = True
            Me.btnBACK.Enabled = True

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    Protected Overrides Function OnSearch(Optional ByVal pv_strIsLocal As String = "", Optional ByVal pv_strModule As String = "", Optional ByVal page As Int32 = 1) As Int32
        Dim i, j As Integer
        Dim v_xColumn As Xceed.Grid.Column, v_strFLDNAME, Value As String
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Dim strRow, vd As String
        Dim v_strADTYPE As String
        Dim rownumber, v_intFrom, v_intTo As Int32
        Try
            'Update mouse pointer
            If Not SearchGrid.DataRows.Count = 0 Then
                If Not SearchGrid.CurrentRow Is Nothing Then
                    If KeyColumn Is Nothing Then
                    Else
                        If checkTypeGridCurrentRow(SearchGrid.CurrentRow) Then
                            Value = Trim(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells(KeyColumn).Value)
                        End If
                    End If
                End If
            End If

            Cursor.Current = Cursors.WaitCursor

            'Update status bar
            'ssbPanelStatus.Text = mv_ResourceManager.GetString("frmSearch.Searching")
            'ssbPanelExecFlag.Text = String.Empty
            mv_strSearchFilter = String.Empty

            If CommandType = gc_CommandProcedure Then 'Command Procedure
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, IsLocalSearch, gc_MsgTypeObj, pv_strModule, _
                                                  gc_ActionInquiry, StoreName, StoreParam, , , , , , , CommandType)
                v_ws.Message(v_strObjMsg)
                Me.FULLDATA = v_strObjMsg
                'Fill data into search grid
                FillDataGrid(SearchGrid, v_strObjMsg, c_SearchResourceManager & UserLanguage, mv_strTableName, , v_intFrom, v_intTo)
                'Format data in search grid
                For Each v_xColumn In SearchGrid.Columns
                    v_strFLDNAME = UCase(Trim(v_xColumn.FieldName))
                    For i = 0 To mv_arrSrFieldSrch.GetLength(0) - 1
                        If UCase(mv_arrSrFieldSrch(i)) = v_strFLDNAME Then
                            v_xColumn.FormatSpecifier = mv_arrSrFieldFormat(i)
                            Exit For
                        End If
                    Next
                Next

            Else 'Command text. Only for defaul condition
                'If ModuleCode & "." & mv_strObjName = OBJNAME_CA_CAMAST And Me.CMDMenu <> "" Then
                '    mv_strSearchFilter = " AND TYPEID = '" & Strings.Right(Me.CMDMenu, 3) & "'"
                'End If

                'If InStr(mv_CONST_SEARCHCODE_ADVANCED, mv_strTableName) > 0 Then
                '    v_strADTYPE = cboRRTYPE.SelectedValue
                '    mv_strSearchFilter = " AND ADTYPE<>'" & v_strADTYPE & "'"
                'End If

                For i = 0 To lstCondition.Items.Count - 1
                    If lstCondition.GetItemChecked(i) Then
                        mv_strSearchFilter &= " AND " & hFilter(lstCondition.Items(i).ToString())
                    End If
                Next i

                'Filter by Careby - TungNT modified
                If mv_isCareBy = True Then
                    If ModuleCode & "." & mv_strObjName = OBJNAME_CF_AFMAST Then
                        mv_strSearchFilter &= " AND INSTR('" & mv_strGroupCareBy & "',CAREBYID)>0 "
                    ElseIf (ModuleCode & "." & mv_strObjName = OBJNAME_OD_ODCANCEL) Or ModuleCode & "." & mv_strObjName = "OD.ODMASTVIEW" Or ModuleCode & "." & mv_strObjName = "OD.ODMAST" Then
                        mv_strSearchFilter &= " AND REPLACE(CUSTODYCD,'.') IN (SELECT CUSTODYCD FROM CFMAST WHERE INSTR('" & mv_strGroupCareBy & "',CAREBY)>0) "
                    ElseIf (ModuleCode & "." & mv_strObjName = "OD.ODCTCIVIEW") Then
                        mv_strSearchFilter &= " AND REPLACE(CUSTID,'.') IN (SELECT CUSTID FROM CFMAST WHERE INSTR('" & mv_strGroupCareBy & "',CAREBY)>0) "
                    End If
                End If
                'End Modified

                mv_strSearchFilter = Mid(mv_strSearchFilter, 5)

                If (pv_strIsLocal <> "") And (pv_strModule <> "") Then
                    v_intTo = page * mv_rowpage
                    v_intFrom = v_intTo + 1 - mv_rowpage

                    If (mv_strSrOderByCmd <> "") And (mv_strSearchFilter <> "") Then
                        mv_strSearchFilter &= "ORDER BY " & mv_strSrOderByCmd
                    End If

                    If mv_strSearchFilter = "" Then
                        If mv_strSrOderByCmd <> "" Then
                            mv_strSearchFilter = " 0=0 ORDER BY " & mv_strSrOderByCmd
                        Else
                            mv_strSearchFilter = " 0 = 0 "
                        End If
                        If Me.chkALL.Checked = True Then
                            strRow = "SELECT * FROM ( SELECT T1.*,ROWNUM RN FROM(" & mv_strCmdSql & " AND " & mv_strSearchFilter & ")T1)" ' WHERE RN BETWEEN " & v_intFrom & " AND " & v_intTo
                        Else
                            strRow = "SELECT * FROM ( SELECT T1.*,ROWNUM RN FROM(" & mv_strCmdSql & " AND " & mv_strSearchFilter & ")T1) WHERE RN BETWEEN " & v_intFrom & " AND " & v_intTo
                        End If
                        mv_strCmdSqlTemp = mv_strCmdSql & " AND " & mv_strSearchFilter
                    Else
                        If Me.chkALL.Checked = True Then
                            strRow = "SELECT * FROM ( SELECT T1.*,ROWNUM RN FROM(SELECT * FROM (" & mv_strCmdSql & ") T WHERE  " & mv_strSearchFilter & ")T1)" '  WHERE RN BETWEEN " & v_intFrom & " AND " & v_intTo
                        Else
                            strRow = "SELECT * FROM ( SELECT T1.*,ROWNUM RN FROM(SELECT * FROM (" & mv_strCmdSql & ") T WHERE  " & mv_strSearchFilter & ")T1)  WHERE RN BETWEEN " & v_intFrom & " AND " & v_intTo
                        End If

                        mv_strCmdSqlTemp = "SELECT * FROM (" & mv_strCmdSql & ") T WHERE  " & mv_strSearchFilter
                    End If
                    If SearchByTransact = True Then
                        strRow = strRow.Replace("<$BRID>", HO_BRID)
                    Else
                        strRow = strRow.Replace("<$BRID>", Me.BranchId)
                    End If
                    'TheNN sua
                    strRow = strRow.Replace("<$HO_BRID>", HO_BRID)
                    strRow = strRow.Replace("<$BUSDATE>", Me.BusDate)
                    strRow = strRow.Replace("<$AFACCTNO>", Me.AFACCTNO)
                    strRow = strRow.Replace("<$CUSTID>", Me.CUSTID)
                    strRow = strRow.Replace("<@KEYVALUE>", LinkValue)
                    strRow = strRow.Replace("<$TELLERID>", Me.TellerId)

                    'Trung.luu Them song ngu ơ form search
                    If Me.UserLanguage = gc_LANG_ENGLISH Then
                        strRow = strRow.Replace("<@CDCONTENT>", "EN_CDCONTENT")
                        strRow = strRow.Replace("<@DESCRIPTION>", "EN_DESCRIPTION")
                    Else
                        strRow = strRow.Replace("<@CDCONTENT>", "CDCONTENT")
                        strRow = strRow.Replace("<@DESCRIPTION>", "DESCRIPTION")
                    End If

                    If InStr(mv_CONST_SEARCHCODE_ADVANCED, mv_strTableName) > 0 Then
                        v_strADTYPE = cboRRTYPE.SelectedValue
                        strRow = strRow.Replace("<$ADTYPE>", v_strADTYPE)
                    End If

                    'Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId , pv_strIsLocal, gc_MsgTypeObj, pv_strModule, _
                    '                                    gc_ActionInquiry, strRow)
                    'VanNT
                    Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, IsLocalSearch, gc_MsgTypeObj, pv_strModule, _
                                                        gc_ActionInquiry, strRow)
                    v_ws.Message(v_strObjMsg)
                    Me.FULLDATA = v_strObjMsg
                    'Fill data into search grid
                    FillDataGrid(SearchGrid, v_strObjMsg, c_SearchResourceManager & UserLanguage, mv_strTableName, , v_intFrom, v_intTo, CountRow())
                    'Format data in search grid
                    For Each v_xColumn In SearchGrid.Columns
                        v_strFLDNAME = UCase(Trim(v_xColumn.FieldName))
                        For i = 0 To mv_arrSrFieldSrch.GetLength(0) - 1
                            If UCase(mv_arrSrFieldSrch(i)) = v_strFLDNAME Then
                                v_xColumn.FormatSpecifier = mv_arrSrFieldFormat(i)
                                Exit For
                            End If
                        Next
                    Next
                End If
            End If


            'ssbPanelStatus.Text = String.Empty
            'Update mouse pointer
            Cursor.Current = Cursors.Default
            SetFocusGrid(Value)
            Me.btnNEXT.Enabled = True
            Me.btnBACK.Enabled = True
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    Protected Overrides Function OnExecute(ByRef v_strObjMsg As String, ByVal pv_intRow As Integer, ByRef blnFlag As Boolean) As Integer
        Try
            If InStr(mv_CONST_SEARCHCODE_ADVANCED, mv_strTableName) > 0 Then

                ManualAdvance(v_strObjMsg, pv_intRow, blnFlag)

            Else

                PaymentOrder(v_strObjMsg, pv_intRow, blnFlag)

                Dim v_returnvalue As String
                Dim v_arrVoucher As String()
                If blnFlag = True Then
                    If mv_strVoucherID.Trim.Length > 0 Then
                        v_arrVoucher = mv_strVoucherID.Split("/")
                        If v_arrVoucher.Length > 1 Then
                            Dim frmVouchers As New frmVouchers(Me.UserLanguage)
                            frmVouchers.BranchID = BranchId
                            frmVouchers.TellerID = TellerId
                            frmVouchers.TLTXCD = Me.TltxCD
                            frmVouchers.ShowDialog()
                            v_returnvalue = Trim(frmVouchers.ReturnValue)
                            'PrintPaymentOrder(v_returnvalue, True)
                        Else
                            'PrintPaymentOrder(v_returnvalue, True)
                        End If
                        'Dim blnConfirm As MsgBoxResult = MsgBoxResult.Cancel
                        'blnConfirm = MsgBox(mv_ResourceManager.GetString("ChooseVoucher"), MsgBoxStyle.Information + MsgBoxStyle.YesNo, Me.Text)
                        'blnConfirm = MsgBox(mv_ResourceManager.GetString("ChooseVoucher"), MsgBoxStyle.Information + MsgBoxStyle.YesNoCancel, Me.Text)
                        'Chọn <Yes> in UNC BIDV
                        'Chọn <No> in UNC ngân hàng khác

                        'If blnConfirm = MsgBoxResult.Yes Then
                        '    PrintPaymentOrder("POBIDV")
                        'ElseIf blnConfirm = MsgBoxResult.No Then
                        '    PrintPaymentOrder("POOTHER")
                        'End If
                    End If



                End If
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    Protected Function ManualAdvance(ByRef v_strObjMsg As String, ByVal pv_intRow As Integer, ByRef blnFlag As Boolean) As Integer
        Dim v_strSQL, v_strClause As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode
        Dim v_strValue, v_strFLDNAME, v_strFLDCD, v_strFLDCODE, v_strTLTXCD, v_strMODCODE, v_strFLDDEFVAL, v_strFIELDTYPE As String, i, j, v_intRow As Integer
        Dim v_strPostingDate, v_strVOUCHERID As String
        Dim lngReturn As Long

        txtADTXNUM.Text = GetTXNUM("ADTXNUM")

        'Cac truong hop xu ly dac biet khi thuc hien Execute.
        'Xu ly xong thoat ra.
        'Khi execute goi den giao dich thi thuc hien o day
        'Căn cứ vào SEARCHCODE để lấy mã giao dịch (TLTXCD) và nạp các giá trị mặc định cho trư?ng giao dịch FLDCD.
        v_strSQL = "SELECT APPMODULES.MODCODE, SEARCH.TLTXCD, SEARCHFLD.FIELDCODE, SEARCHFLD.FLDCD,SEARCHFLD.FIELDTYPE  FROM APPMODULES, SEARCH, SEARCHFLD " & ControlChars.CrLf _
            & "WHERE SEARCH.SEARCHCODE=SEARCHFLD.SEARCHCODE AND APPMODULES.TXCODE=SUBSTR(SEARCH.TLTXCD,1,2) AND LENGTH(SEARCH.TLTXCD)=4 AND SEARCH.SEARCHCODE='" & mv_strTableName & "'"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLTX, gc_ActionInquiry, v_strSQL)
        v_ws.Message(v_strObjMsg)
        v_xmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
        v_strFLDDEFVAL = String.Empty
        v_strMODCODE = String.Empty
        v_strTLTXCD = String.Empty

        If Not Me.chkExeAll.Checked Then
            If Not v_nodeList.Count = 0 Then
                'N?u dây là màn hình tra c?u cho phép th?c hi?n giao d?ch k? ti?p
                If Not SearchGrid Is Nothing Then
                    If SearchGrid.DataRows.Count > 0 Then
                        For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
                            If Not SearchGrid.DataRows(v_intRow) Is Nothing Then
                                If SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X" Then

                                    'mv_dblTotalAmt = mv_dblTotalAmt + CDbl(SearchGrid.DataRows(v_intRow).Cells("DEPOAMT").Value)
                                    'txtAMT.Text = FormatNumber(mv_dblTotalAmt, 0)

                                    'Có duoc danh dau chon
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
                                                    Case "FIELDTYPE"
                                                        v_strFIELDTYPE = Trim(v_strValue)
                                                        'longnh 2014-12-02

                                                End Select
                                            End With
                                        Next

                                        If v_strFLDCD <> "" Then

                                            If String.Compare(v_strFLDCD, "PD") = 0 Then
                                                If TypeOf (SearchGrid.CurrentRow) Is Xceed.Grid.DataRow Then
                                                    'Neu la truong posting date
                                                    v_strValue = SearchGrid.DataRows(v_intRow).Cells(v_strFLDCODE).Value
                                                    v_strValue = Replace(v_strValue, ".", "")
                                                    v_strPostingDate = v_strValue
                                                Else
                                                    v_strPostingDate = String.Empty
                                                End If
                                            Else
                                                If TypeOf (SearchGrid.CurrentRow) Is Xceed.Grid.DataRow Then

                                                    v_strValue = SearchGrid.DataRows(v_intRow).Cells(v_strFLDCODE).Value

                                                    If v_strFIELDTYPE = "C" And (v_strFLDCODE <> "DESC" Or v_strFLDCODE <> "DESCRIPTION") Then
                                                        v_strValue = Replace(v_strValue, ".", "")
                                                    End If
                                                    v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & v_strFLDCD & "." & v_strValue & "]"
                                                Else
                                                    v_strFLDDEFVAL = String.Empty
                                                End If

                                            End If
                                        End If
                                    Next

                                    'ADTXNUM : So bang ke
                                    v_strFLDCD = "99"
                                    v_strValue = txtADTXNUM.Text
                                    v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & v_strFLDCD & "." & v_strValue & "]"

                                    'Nap va thuc hien giao dich
                                    SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = String.Empty
                                    SetTransactForm()
                                    If v_strMODCODE <> "" And v_strTLTXCD <> "" Then
                                        mv_frmTransactScreen = New frmTransact(mv_strLanguage)
                                        Try
                                            mv_frmTransactScreen.ObjectName = v_strTLTXCD
                                        Catch ex As Exception
                                            MsgBox(ex.Message)
                                        End Try
                                        mv_frmTransactScreen.ModuleCode = v_strMODCODE
                                        mv_frmTransactScreen.LocalObject = gc_IsNotLocalMsg
                                        mv_frmTransactScreen.BranchId = Me.BranchId
                                        mv_frmTransactScreen.TellerId = Me.TellerId
                                        mv_frmTransactScreen.IpAddress = Me.IpAddress
                                        mv_frmTransactScreen.WsName = Me.WsName
                                        mv_frmTransactScreen.BusDate = Me.BusDate

                                        If IIf(IsDBNull(Len(v_strPostingDate)), 0, Len(v_strPostingDate)) > 0 Then
                                            mv_frmTransactScreen.PostingDate = v_strPostingDate
                                        End If

                                        mv_frmTransactScreen.DefaultValue = v_strFLDDEFVAL
                                        mv_frmTransactScreen.AutoClosedWhenOK = True
                                        'mv_frmTransactScreen.AutoSubmitWhenExecute = True
                                        mv_frmTransactScreen.ShowDialog()
                                        If mv_frmTransactScreen.CancelClick Then
                                            OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                                            Exit Function
                                            blnFlag = False
                                        End If
                                        blnFlag = True
                                        'mv_frmTransactScreen.OnSubmit()
                                        mv_frmTransactScreen.Dispose()
                                        'Reset lai gia tri
                                        v_strFLDDEFVAL = String.Empty
                                    End If
                                End If
                            End If
                        Next
                    End If
                    'Refresh lai màn hình
                    'OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)                 
                End If
            End If
        Else
            If Not v_nodeList.Count = 0 Then
                'N?u dây là màn hình tra c?u cho phép th?c hi?n giao d?ch k? ti?p
                If Not SearchGrid Is Nothing Then
                    If SearchGrid.DataRows.Count > 0 Then
                        For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
                            If Not SearchGrid.DataRows(v_intRow) Is Nothing Then
                                If SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X" Then

                                    'mv_dblTotalAmt = mv_dblTotalAmt + CDbl(SearchGrid.DataRows(v_intRow).Cells("DEPOAMT").Value)
                                    'txtAMT.Text = FormatNumber(mv_dblTotalAmt, 0)

                                    'Có duoc danh dau chon
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
                                                    Case "FIELDTYPE"
                                                        v_strFIELDTYPE = Trim(v_strValue)
                                                End Select
                                            End With
                                        Next

                                        If v_strFLDCD <> "" Then

                                            If String.Compare(v_strFLDCD, "PD") = 0 Then
                                                If TypeOf (SearchGrid.CurrentRow) Is Xceed.Grid.DataRow Then
                                                    'Neu la truong posting date
                                                    v_strValue = SearchGrid.DataRows(v_intRow).Cells(v_strFLDCODE).Value
                                                    v_strValue = Replace(v_strValue, ".", "")
                                                    v_strPostingDate = v_strValue
                                                Else
                                                    v_strPostingDate = String.Empty
                                                End If
                                            Else
                                                If TypeOf (SearchGrid.CurrentRow) Is Xceed.Grid.DataRow Then

                                                    v_strValue = SearchGrid.DataRows(v_intRow).Cells(v_strFLDCODE).Value

                                                    If v_strFIELDTYPE = "C" And (v_strFLDCODE <> "DESC" Or v_strFLDCODE <> "DESCRIPTION") Then
                                                        v_strValue = Replace(v_strValue, ".", "")
                                                    End If
                                                    v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & v_strFLDCD & "." & v_strValue & "]"
                                                Else
                                                    v_strFLDDEFVAL = String.Empty
                                                End If

                                            End If
                                        End If
                                    Next

                                    'ADTXNUM : So bang ke
                                    v_strFLDCD = "99"
                                    v_strValue = txtADTXNUM.Text
                                    v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & v_strFLDCD & "." & v_strValue & "]"

                                    'Nap va thuc hien giao dich
                                    SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = String.Empty
                                    SetTransactForm()
                                    If v_strMODCODE <> "" And v_strTLTXCD <> "" Then
                                        mv_frmTransactScreen = New frmTransact(mv_strLanguage)
                                        Try
                                            mv_frmTransactScreen.ObjectName = v_strTLTXCD
                                        Catch ex As Exception
                                            MsgBox(ex.Message)
                                        End Try
                                        mv_frmTransactScreen.ModuleCode = v_strMODCODE
                                        mv_frmTransactScreen.LocalObject = gc_IsNotLocalMsg
                                        mv_frmTransactScreen.BranchId = Me.BranchId
                                        mv_frmTransactScreen.TellerId = Me.TellerId
                                        mv_frmTransactScreen.IpAddress = Me.IpAddress
                                        mv_frmTransactScreen.WsName = Me.WsName
                                        mv_frmTransactScreen.BusDate = Me.BusDate

                                        If IIf(IsDBNull(Len(v_strPostingDate)), 0, Len(v_strPostingDate)) > 0 Then
                                            mv_frmTransactScreen.PostingDate = v_strPostingDate
                                        End If
                                        mv_frmTransactScreen.DefaultValue = v_strFLDDEFVAL
                                        mv_frmTransactScreen.AutoClosedWhenOK = True
                                        mv_frmTransactScreen.AutoSubmitWhenExecute = True
                                        mv_frmTransactScreen.ShowDialog()
                                        'If mv_frmTransactScreen.CancelClick Then
                                        '    OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                                        '    Exit Function
                                        '    blnFlag = False
                                        'End If
                                        blnFlag = True
                                        'mv_frmTransactScreen.OnSubmit()
                                        mv_frmTransactScreen.Dispose()
                                        'Reset lai gia tri
                                        v_strFLDDEFVAL = String.Empty
                                    End If
                                End If
                            End If
                        Next
                    End If
                    'Refresh lai màn hình
                    'OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                End If
            End If
        End If

    End Function

    Protected Function PaymentOrder(ByRef v_strObjMsg As String, ByVal pv_intRow As Integer, ByRef blnFlag As Boolean) As Integer
        Dim v_strSQL, v_strClause As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode
        Dim v_strValue, v_strFLDNAME, v_strFLDCD, v_strFLDCODE, v_strTLTXCD, v_strMODCODE, v_strFLDDEFVAL, v_strFIELDTYPE As String, i, j, v_intRow As Integer
        Dim v_strPostingDate, v_strVOUCHERID As String
        Dim lngReturn As Long

        '17/09/2015 DieuNDA: Bo truong Ma NH Chi dien tu
        'If (Len(mskBANKID.Text) = 0 Or String.Compare(mskBANKID.Text, "") = 0) And (Len(mskBANKDTID.Text) = 0 Or String.Compare(mskBANKDTID.Text, "") = 0) Then
        If (Len(mskBANKID.Text) = 0 Or String.Compare(mskBANKID.Text, "") = 0) Then
            MsgBox(mv_ResourceManager.GetString("PleaseChooseBankID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
            TabMain.SelectTab(TabTranferInfo)
            mskBANKID.Focus()
            Exit Function
        End If
        'End 17/09/2015 DieuNDA

        ' PhuongHT comment theo yeu cau BVS
        'If Len(txtGLACCTNO.Text) = 0 Or String.Compare(txtGLACCTNO.Text, "") = 0 Then
        '    MsgBox(mv_ResourceManager.GetString("GLAcctnoNotNull"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
        '    TabMain.SelectTab(TabTranferInfo)
        '    mskBANKID.Focus()
        '    Exit Function
        'End If
        If mv_strTableName <> mv_CONST_SEARCHCODE_1104 And mv_strTableName <> mv_CONST_SEARCHCODE_1108 Then

            If (Len(txtBENEFNAME.Text) = 0 Or String.Compare(txtBENEFNAME.Text, "") = 0) Then
                MsgBox(mv_ResourceManager.GetString("BENEFNAMENOTNULL"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                TabMain.SelectTab(TabBenefInfo)
                txtBENEFNAME.Focus()
                Exit Function
            End If

            If (Len(txtBENEFBANKACCT.Text) = 0 Or String.Compare(txtBENEFBANKACCT.Text, "") = 0) Then
                MsgBox(mv_ResourceManager.GetString("BENEFBANKACCTNOTNULL"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                TabMain.SelectTab(TabBenefInfo)
                txtBENEFBANKACCT.Focus()
                Exit Function
            End If

            If (Len(txtBENEFBANKNAME.Text) = 0 Or String.Compare(txtBENEFBANKNAME.Text, "") = 0) Then
                MsgBox(mv_ResourceManager.GetString("BENEFBANKNAMENOTNULL"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                TabMain.SelectTab(TabBenefInfo)
                txtBENEFBANKNAME.Focus()
                Exit Function
            End If



        End If

        txtTXNUM.Text = GetTXNUM("POTXNUM")
        mv_dblTotalAmt = 0
        'Cac truong hop xu ly dac biet khi thuc hien Execute.
        'Xu ly xong thoat ra.
        'Khi execute goi den giao dich thi thuc hien o day
        'Căn cứ vào SEARCHCODE để lấy mã giao dịch (TLTXCD) và nạp các giá trị mặc định cho trư?ng giao dịch FLDCD.
        v_strSQL = "SELECT APPMODULES.MODCODE, SEARCH.TLTXCD, SEARCHFLD.FIELDCODE, SEARCHFLD.FLDCD,SEARCHFLD.FIELDTYPE,NVL(TLTX.VOUCHERID,'')  VOUCHERID   FROM APPMODULES, SEARCH, SEARCHFLD, TLTX " & ControlChars.CrLf _
            & "WHERE SEARCH.SEARCHCODE=SEARCHFLD.SEARCHCODE AND APPMODULES.TXCODE=SUBSTR(SEARCH.TLTXCD,1,2) AND LENGTH(SEARCH.TLTXCD)=4 AND SEARCH.TLTXCD = TLTX.TLTXCD (+) AND SEARCH.SEARCHCODE='" & mv_strTableName & "'"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLTX, gc_ActionInquiry, v_strSQL)
        v_ws.Message(v_strObjMsg)
        v_xmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
        v_strFLDDEFVAL = String.Empty
        v_strMODCODE = String.Empty
        v_strTLTXCD = String.Empty
        'Begin 
        Dim v_intTickCount As Integer = 0
        If Not SearchGrid Is Nothing Then
            If SearchGrid.DataRows.Count > 0 Then
                For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
                    If Not SearchGrid.DataRows(v_intRow) Is Nothing Then
                        If SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X" Then
                            v_intTickCount = v_intTickCount + 1
                        End If
                    End If
                Next
            End If
        End If
        'End


        If mskBANKID.Text.Replace(".", "").Trim.Length > 0 Then
            c_BankTyp = "N"
        Else
            c_BankTyp = "E"
        End If

        If Not Me.chkExeAll.Checked Then
            If Not v_nodeList.Count = 0 Then
                'N?u dây là màn hình tra c?u cho phép th?c hi?n giao d?ch k? ti?p
                If Not SearchGrid Is Nothing Then
                    If SearchGrid.DataRows.Count > 0 Then
                        For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
                            If Not SearchGrid.DataRows(v_intRow) Is Nothing Then
                                If SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X" Then

                                    mv_dblTotalAmt = mv_dblTotalAmt + CDbl(SearchGrid.DataRows(v_intRow).Cells("AMT").Value)
                                    txtAMT.Text = FormatNumber(mv_dblTotalAmt, 0)

                                    'Có duoc danh dau chon
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
                                                        mv_strTLTXCD = Trim(v_strValue)
                                                    Case "FIELDCODE"
                                                        v_strFLDCODE = Trim(v_strValue)
                                                    Case "FLDCD"
                                                        v_strFLDCD = Trim(v_strValue)
                                                    Case "FIELDTYPE"
                                                        v_strFIELDTYPE = Trim(v_strValue)
                                                        'longnh 2014-12-02
                                                    Case "VOUCHERID"
                                                        If v_strVOUCHERID = vbNullString AndAlso v_strVOUCHERID Is Nothing Then
                                                            v_strVOUCHERID = Trim(v_strValue)
                                                            mv_strVoucherID = v_strVOUCHERID
                                                        End If

                                                End Select
                                            End With
                                        Next

                                        If v_strFLDCD <> "" Then

                                            If String.Compare(v_strFLDCD, "PD") = 0 Then
                                                If TypeOf (SearchGrid.CurrentRow) Is Xceed.Grid.DataRow Then
                                                    'Neu la truong posting date
                                                    v_strValue = SearchGrid.DataRows(v_intRow).Cells(v_strFLDCODE).Value
                                                    v_strValue = Replace(v_strValue, ".", "")
                                                    v_strPostingDate = v_strValue
                                                Else
                                                    v_strPostingDate = String.Empty
                                                End If
                                            Else
                                                If TypeOf (SearchGrid.CurrentRow) Is Xceed.Grid.DataRow Then
                                                    'Neu la truong binh thuong 
                                                    'Lay GL Account đưa vào vao dịch
                                                    If String.Compare(v_strFLDCD, "15") = 0 Then 'GLMAST
                                                        v_strValue = txtGLACCTNO.Text.Trim()
                                                        v_strValue = Replace(v_strValue, ".", "")
                                                    ElseIf String.Compare(v_strFLDCD, "05") = 0 Then 'BANKID
                                                        v_strValue = mskBANKID.Text.Trim()
                                                        v_strValue = Replace(v_strValue, ".", "")
                                                    ElseIf String.Compare(v_strFLDCD, "98") = 0 Then 'POTXDATE
                                                        v_strValue = Me.BusDate
                                                    ElseIf String.Compare(v_strFLDCD, "99") = 0 Then 'POTXNUM
                                                        v_strValue = txtTXNUM.Text.Trim()
                                                        v_strValue = Replace(v_strValue, ".", "")
                                                    ElseIf String.Compare(v_strFLDCD, "08") = 0 Then 'BANKACC
                                                        v_strValue = txtBANKACC.Text.Trim()
                                                        v_strValue = Replace(v_strValue, ".", "")
                                                    ElseIf String.Compare(v_strFLDCD, "85") = 0 Then 'BANKNAME
                                                        v_strValue = txtBANKNAME.Text.Trim()
                                                        v_strValue = Replace(v_strValue, ".", "")
                                                    ElseIf String.Compare(v_strFLDCD, "86") = 0 Then 'BANKACCNAME
                                                        v_strValue = txtBANKACCNAME.Text.Trim()
                                                        v_strValue = Replace(v_strValue, ".", "")
                                                    ElseIf String.Compare(v_strFLDCD, "87") = 0 Then 'BANKDTID
                                                        'v_strValue = mskBANKDTID.Text.Trim()
                                                        'v_strValue = Replace(v_strValue, ".", "")
                                                        v_strValue = ""
                                                    ElseIf String.Compare(v_strFLDCD, "89") = 0 Then 'BANKTYP
                                                        v_strValue = c_BankTyp
                                                    ElseIf String.Compare(v_strFLDCD, "80") = 0 Then 'BENEFBANK
                                                        If (mv_strTableName <> mv_CONST_SEARCHCODE_1104) And (mv_strTableName <> mv_CONST_SEARCHCODE_1108) Then
                                                            v_strValue = txtBENEFBANKNAME.Text.Trim()
                                                            'v_strValue = Replace(v_strValue, ".", "")
                                                        Else
                                                            v_strValue = SearchGrid.DataRows(v_intRow).Cells(v_strFLDCODE).Value
                                                        End If
                                                        mv_strBANKNAME_REF = v_strValue
                                                        '80	1104	BENEFBANK    	Tên ngân hàng thụ hưởng     
                                                        '81	1104	BENEFACCT    	Số tài khoản thụ hưởng      
                                                        '82	1104	BENEFCUSTNAME	Tên khách hàng thụ hưởng
                                                        'Private mv_strBANKNAME_REF As String = String.Empty
                                                        'Private mv_strBANKACC_REF As String = String.Empty
                                                        'Private mv_strBANKCUSNAME_REF As String = String.Empty
                                                    ElseIf String.Compare(v_strFLDCD, "81") = 0 Then 'BENEFACCT
                                                        If (mv_strTableName <> mv_CONST_SEARCHCODE_1104) And (mv_strTableName <> mv_CONST_SEARCHCODE_1108) Then
                                                            v_strValue = txtBENEFBANKACCT.Text.Trim()
                                                            'v_strValue = Replace(v_strValue, ".", "")
                                                        Else
                                                            v_strValue = SearchGrid.DataRows(v_intRow).Cells(v_strFLDCODE).Value
                                                        End If
                                                        mv_strBANKACC_REF = v_strValue
                                                    ElseIf String.Compare(v_strFLDCD, "82") = 0 Then 'BENEFCUSTNAME
                                                        If (mv_strTableName <> mv_CONST_SEARCHCODE_1104) And (mv_strTableName <> mv_CONST_SEARCHCODE_1108) Then
                                                            v_strValue = txtBENEFNAME.Text.Trim()
                                                            'v_strValue = Replace(v_strValue, ".", "")
                                                        Else
                                                            v_strValue = SearchGrid.DataRows(v_intRow).Cells(v_strFLDCODE).Value
                                                        End If
                                                        mv_strBANKCUSNAME_REF = v_strValue

                                                    ElseIf String.Compare(v_strFLDCD, "83") = 0 Then 'RECEIVLICENSE

                                                        v_strValue = SearchGrid.DataRows(v_intRow).Cells(v_strFLDCODE).Value
                                                        mv_strBENEFIDCODE_REF = v_strValue
                                                        ''Sua doan nay de len dien giai cho 1104
                                                    ElseIf String.Compare(v_strFLDCD, "27") = 0 Then 'CITAD
                                                        v_strValue = v_strValue = txtCITAD.Text.Trim()
                                                    ElseIf String.Compare(v_strFLDCD, "30") = 0 Then 'DESC
                                                        If (mv_strTableName = mv_CONST_SEARCHCODE_1104) Or (mv_strTableName = mv_CONST_SEARCHCODE_1108) Then
                                                            v_strValue = SearchGrid.DataRows(v_intRow).Cells(v_strFLDCODE).Value
                                                            v_strValue = mv_ResourceManager.GetString("POTNUM_DESC").ToString & " " & txtTXNUM.Text & "." & v_strValue
                                                        Else
                                                            'Neu la 1104 hoac 1108
                                                            'Neu so dong duoc tick >1 thi lay dien giai cua txtDESC
                                                            'Neu so dong = 1 thi lay dien giai cua seachfld
                                                            If v_intTickCount = 1 Then
                                                                v_strValue = SearchGrid.DataRows(v_intRow).Cells(v_strFLDCODE).Value
                                                                'v_strValue = mv_ResourceManager.GetString("POTNUM_DESC").ToString & " " & txtTXNUM.Text & "." & v_strValue
                                                            Else
                                                                v_strValue = Me.txtDESC.Text
                                                                'v_strValue = mv_ResourceManager.GetString("POTNUM_DESC").ToString & " " & txtTXNUM.Text & "." & v_strValue
                                                            End If
                                                        End If
                                                        mv_strDESC_REF = v_strValue
                                                    ElseIf String.Compare(v_strFLDCD, "31") = 0 Then 'PODESCRIPTION
                                                        v_strValue = txtDESCRIPTION.Text.Trim()
                                                        'v_strValue = Replace(v_strValue, ".", "")
                                                    Else
                                                        v_strValue = SearchGrid.DataRows(v_intRow).Cells(v_strFLDCODE).Value
                                                    End If

                                                    'If v_strFIELDTYPE = "C" And (v_strFLDCODE <> "DESC" Or v_strFLDCODE <> "DESCRIPTION") Then
                                                    'v_strValue = Replace(v_strValue, ".", "")
                                                    'End If
                                                    v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & v_strFLDCD & "." & v_strValue & "]"
                                                Else
                                                    v_strFLDDEFVAL = String.Empty
                                            End If

                                            End If
                                        End If
                                    Next

                                    'Nap va thuc hien giao dich
                                    SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = String.Empty
                                    SetTransactForm()
                                    If v_strMODCODE <> "" And v_strTLTXCD <> "" Then
                                        mv_frmTransactScreen = New frmTransact(mv_strLanguage)
                                        Try
                                            mv_frmTransactScreen.ObjectName = v_strTLTXCD
                                        Catch ex As Exception
                                            MsgBox(ex.Message)
                                        End Try
                                        mv_frmTransactScreen.ModuleCode = v_strMODCODE
                                        mv_frmTransactScreen.LocalObject = gc_IsNotLocalMsg
                                        mv_frmTransactScreen.BranchId = Me.BranchId
                                        mv_frmTransactScreen.TellerId = Me.TellerId
                                        mv_frmTransactScreen.IpAddress = Me.IpAddress
                                        mv_frmTransactScreen.WsName = Me.WsName
                                        mv_frmTransactScreen.BusDate = Me.BusDate

                                        If IIf(IsDBNull(Len(v_strPostingDate)), 0, Len(v_strPostingDate)) > 0 Then
                                            mv_frmTransactScreen.PostingDate = v_strPostingDate
                                        End If

                                        mv_frmTransactScreen.DefaultValue = v_strFLDDEFVAL
                                        mv_frmTransactScreen.AutoClosedWhenOK = True
                                        'mv_frmTransactScreen.AutoSubmitWhenExecute = True
                                        mv_frmTransactScreen.ShowDialog()
                                        If mv_frmTransactScreen.CancelClick Then
                                            OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                                            Exit Function
                                            blnFlag = False
                                        End If
                                        blnFlag = True
                                        'mv_frmTransactScreen.OnSubmit()
                                        mv_frmTransactScreen.Dispose()
                                        'Reset lai gia tri
                                        v_strFLDDEFVAL = String.Empty
                                    End If
                                End If
                            End If
                        Next
                    End If
                    'Refresh lai màn hình
                    'OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)                 
                End If
            End If
        Else
            If Not v_nodeList.Count = 0 Then
                'N?u dây là màn hình tra c?u cho phép th?c hi?n giao d?ch k? ti?p
                If Not SearchGrid Is Nothing Then
                    If SearchGrid.DataRows.Count > 0 Then
                        Dim intCuont As Integer = 0
                        For v_intRow = 0 To SearchGrid.DataRows.Count - 1 Step 1
                            If Not SearchGrid.DataRows(v_intRow) Is Nothing Then
                                If SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = "X" Then

                                    mv_dblTotalAmt = mv_dblTotalAmt + CDbl(SearchGrid.DataRows(v_intRow).Cells("AMT").Value)
                                    txtAMT.Text = FormatNumber(mv_dblTotalAmt, 0)
                                    intCuont = intCuont + 1
                                    'Có duoc danh dau chon
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
                                                        mv_strTLTXCD = Trim(v_strValue)
                                                    Case "FIELDCODE"
                                                        v_strFLDCODE = Trim(v_strValue)
                                                    Case "FLDCD"
                                                        v_strFLDCD = Trim(v_strValue)
                                                    Case "FIELDTYPE"
                                                        v_strFIELDTYPE = Trim(v_strValue)
                                                        'longnh 2014-12-02
                                                    Case "VOUCHERID"
                                                        If v_strVOUCHERID = vbNullString AndAlso v_strVOUCHERID Is Nothing Then
                                                            v_strVOUCHERID = Trim(v_strValue)
                                                            mv_strVoucherID = v_strVOUCHERID
                                                        End If

                                                End Select
                                            End With
                                        Next

                                        If v_strFLDCD <> "" Then

                                            If String.Compare(v_strFLDCD, "PD") = 0 Then
                                                If TypeOf (SearchGrid.CurrentRow) Is Xceed.Grid.DataRow Then
                                                    'Neu la truong posting date
                                                    v_strValue = SearchGrid.DataRows(v_intRow).Cells(v_strFLDCODE).Value
                                                    v_strValue = Replace(v_strValue, ".", "")
                                                    v_strPostingDate = v_strValue
                                                Else
                                                    v_strPostingDate = String.Empty
                                                End If
                                            Else
                                                If TypeOf (SearchGrid.CurrentRow) Is Xceed.Grid.DataRow Then
                                                    'Neu la truong binh thuong 
                                                    'Lay GL Account đưa vào vao giao dịch
                                                    If String.Compare(v_strFLDCD, "15") = 0 Then 'GLMAST
                                                        v_strValue = txtGLACCTNO.Text
                                                        v_strValue = Replace(v_strValue, ".", "")
                                                    ElseIf String.Compare(v_strFLDCD, "05") = 0 Then 'BANKID
                                                        v_strValue = mskBANKID.Text
                                                        v_strValue = Replace(v_strValue, ".", "")
                                                    ElseIf String.Compare(v_strFLDCD, "98") = 0 Then 'POTXDATE
                                                        v_strValue = Me.BusDate
                                                    ElseIf String.Compare(v_strFLDCD, "99") = 0 Then 'POTXNUM
                                                        v_strValue = txtTXNUM.Text
                                                        v_strValue = Replace(v_strValue, ".", "")
                                                    ElseIf String.Compare(v_strFLDCD, "08") = 0 Then 'BANKACC
                                                        v_strValue = txtBANKACC.Text
                                                        v_strValue = Replace(v_strValue, ".", "")
                                                    ElseIf String.Compare(v_strFLDCD, "85") = 0 Then 'BANKNAME
                                                        v_strValue = txtBANKNAME.Text
                                                        v_strValue = Replace(v_strValue, ".", "")
                                                    ElseIf String.Compare(v_strFLDCD, "86") = 0 Then 'BANKACCNAME
                                                        v_strValue = txtBANKACCNAME.Text
                                                        v_strValue = Replace(v_strValue, ".", "")
                                                    ElseIf String.Compare(v_strFLDCD, "87") = 0 Then 'BANKDTID
                                                        v_strValue = mskBANKDTID.Text.Trim()
                                                        v_strValue = Replace(v_strValue, ".", "")
                                                    ElseIf String.Compare(v_strFLDCD, "89") = 0 Then 'BANKTYP
                                                        v_strValue = c_BankTyp
                                                        'ElseIf String.Compare(v_strFLDCD, "80") = 0 Then 'BENEFBANK
                                                        '    v_strValue = txtBENEFBANKNAME.Text
                                                        '    v_strValue = Replace(v_strValue, ".", "")
                                                        'ElseIf String.Compare(v_strFLDCD, "81") = 0 Then 'BENEFACCT
                                                        '    v_strValue = txtBENEFBANKACCT.Text
                                                        '    v_strValue = Replace(v_strValue, ".", "")
                                                        'ElseIf String.Compare(v_strFLDCD, "82") = 0 Then 'BENEFCUSTNAME
                                                        '    v_strValue = txtBENEFNAME.Text
                                                        '    v_strValue = Replace(v_strValue, ".", "")
                                                    ElseIf String.Compare(v_strFLDCD, "80") = 0 Then 'BENEFBANK
                                                        If (mv_strTableName <> mv_CONST_SEARCHCODE_1104) And (mv_strTableName <> mv_CONST_SEARCHCODE_1108) Then
                                                            v_strValue = txtBENEFBANKNAME.Text.Trim()
                                                            'v_strValue = Replace(v_strValue, ".", "")
                                                        Else
                                                            v_strValue = SearchGrid.DataRows(v_intRow).Cells(v_strFLDCODE).Value
                                                        End If
                                                        mv_strBANKNAME_REF = v_strValue

                                                    ElseIf String.Compare(v_strFLDCD, "81") = 0 Then 'BENEFACCT
                                                        If (mv_strTableName <> mv_CONST_SEARCHCODE_1104) And (mv_strTableName <> mv_CONST_SEARCHCODE_1108) Then
                                                            v_strValue = txtBENEFBANKACCT.Text.Trim()
                                                            'v_strValue = Replace(v_strValue, ".", "")
                                                        Else
                                                            v_strValue = SearchGrid.DataRows(v_intRow).Cells(v_strFLDCODE).Value
                                                        End If
                                                        mv_strBANKACC_REF = v_strValue

                                                    ElseIf String.Compare(v_strFLDCD, "82") = 0 Then 'BENEFCUSTNAME
                                                        If (mv_strTableName <> mv_CONST_SEARCHCODE_1104) And (mv_strTableName <> mv_CONST_SEARCHCODE_1108) Then
                                                            v_strValue = txtBENEFNAME.Text.Trim()
                                                            'v_strValue = Replace(v_strValue, ".", "")
                                                        Else
                                                            v_strValue = SearchGrid.DataRows(v_intRow).Cells(v_strFLDCODE).Value
                                                        End If
                                                        mv_strBANKCUSNAME_REF = v_strValue
                                                    ElseIf String.Compare(v_strFLDCD, "83") = 0 Then 'RECEIVLICENSE

                                                        v_strValue = SearchGrid.DataRows(v_intRow).Cells(v_strFLDCODE).Value
                                                        mv_strBENEFIDCODE_REF = v_strValue
                                                    ElseIf String.Compare(v_strFLDCD, "27") = 0 Then 'CITAD
                                                        v_strValue = txtCITAD.Text.Trim()
                                                    ElseIf String.Compare(v_strFLDCD, "30") = 0 Then 'BENEFCUSTNAME
                                                        If (mv_strTableName <> mv_CONST_SEARCHCODE_1104) And (mv_strTableName <> mv_CONST_SEARCHCODE_1108) Then
                                                            v_strValue = SearchGrid.DataRows(v_intRow).Cells(v_strFLDCODE).Value
                                                            v_strValue = mv_ResourceManager.GetString("POTNUM_DESC").ToString & " " & txtTXNUM.Text & "." & v_strValue
                                                        Else
                                                            'Neu la 1104 hoac 1108
                                                            'Neu so dong duoc tick >1 thi lay dien giai cua txtDESC
                                                            'Neu so dong = 1 thi lay dien giai cua seachfld
                                                            If v_intTickCount = 1 Then
                                                                v_strValue = SearchGrid.DataRows(v_intRow).Cells(v_strFLDCODE).Value
                                                                'v_strValue = mv_ResourceManager.GetString("POTNUM_DESC").ToString & " " & txtTXNUM.Text & "." & v_strValue
                                                            Else
                                                                v_strValue = Me.txtDESC.Text
                                                                'v_strValue = mv_ResourceManager.GetString("POTNUM_DESC").ToString & " " & txtTXNUM.Text & "." & v_strValue
                                                            End If
                                                        End If
                                                        mv_strDESC_REF = v_strValue
                                                    ElseIf String.Compare(v_strFLDCD, "31") = 0 Then 'PODESCRIPTION
                                                        v_strValue = txtDESCRIPTION.Text.Trim()
                                                        'v_strValue = Replace(v_strValue, ".", "")
                                                    Else
                                                        If v_strTLTXCD = gc_CA_CUT_STOCK_EXCUTE And (v_strFLDCODE = "DESC" Or v_strFLDCODE = "DESCRIPTION") And txtDESCRIPTION.Text.Length > 0 And (txtDESCRIPTION.Text <> "") Then
                                                            v_strValue = txtDESCRIPTION.Text
                                                        Else
                                                            v_strValue = SearchGrid.DataRows(v_intRow).Cells(v_strFLDCODE).Value
                                                        End If
                                                        'v_strValue = SearchGrid.DataRows(v_intRow).Cells(v_strFLDCODE).Value
                                                    End If


                                                    'v_strValue = SearchGrid.DataRows(v_intRow).Cells(v_strFLDCODE).Value
                                                    'If v_strFIELDTYPE = "C" And (v_strFLDCODE <> "DESC" And v_strFLDCODE <> "DESCRIPTION") Then
                                                    'v_strValue = Replace(v_strValue, ".", "")
                                                    'End If
                                                    v_strFLDDEFVAL = v_strFLDDEFVAL & "[" & v_strFLDCD & "." & v_strValue & "]"
                                                Else
                                                    v_strFLDDEFVAL = String.Empty
                                            End If

                                            End If
                                        End If
                                    Next

                                    'Nap va thuc hien giao dich
                                    SearchGrid.DataRows(v_intRow).Cells("__TICK").Value = String.Empty
                                    SetTransactForm()
                                    If v_strMODCODE <> "" And v_strTLTXCD <> "" Then
                                        mv_frmTransactScreen = New frmTransact(mv_strLanguage)
                                        Try
                                            mv_frmTransactScreen.ObjectName = v_strTLTXCD
                                        Catch ex As Exception
                                            MsgBox(ex.Message)
                                        End Try
                                        mv_frmTransactScreen.ModuleCode = v_strMODCODE
                                        mv_frmTransactScreen.LocalObject = gc_IsNotLocalMsg
                                        mv_frmTransactScreen.BranchId = Me.BranchId
                                        mv_frmTransactScreen.TellerId = Me.TellerId
                                        mv_frmTransactScreen.IpAddress = Me.IpAddress
                                        mv_frmTransactScreen.WsName = Me.WsName
                                        mv_frmTransactScreen.BusDate = Me.BusDate

                                        If IIf(IsDBNull(Len(v_strPostingDate)), 0, Len(v_strPostingDate)) > 0 Then
                                            mv_frmTransactScreen.PostingDate = v_strPostingDate
                                        End If
                                        mv_frmTransactScreen.DefaultValue = v_strFLDDEFVAL
                                        mv_frmTransactScreen.AutoClosedWhenOK = True
                                        mv_frmTransactScreen.AutoSubmitWhenExecute = True
                                        mv_frmTransactScreen.ShowDialog()
                                        If mv_frmTransactScreen.CancelClick Then
                                            OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                                            Exit Function
                                            blnFlag = False
                                        End If
                                        blnFlag = True
                                        'mv_frmTransactScreen.OnSubmit()
                                        mv_frmTransactScreen.Dispose()
                                        'Reset lai gia tri
                                        v_strFLDDEFVAL = String.Empty
                                    End If
                                End If
                            End If
                        Next

                        If intCuont > 1 Then
                            mv_strIS1Transaction = "N"
                        Else
                            mv_strIS1Transaction = "Y"
                        End If
                    End If
                    'Refresh lai màn hình
                    'OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, mv_intpage)
                End If
            End If
        End If

        txtBENEFBANKACCT.Text = ""
        txtBENEFBANKNAME.Text = ""
        txtBENEFNAME.Text = ""
        txtDESCRIPTION.Text = ""
        txtCITAD.Text = ""

    End Function

    'Protected Overrides Sub PrintPaymentOrder(ByVal pv_strVoucherID As String, Optional ByVal blnPrePrint As Double = False)
    '    Dim v_strOldCultureName As String = String.Empty
    '    Try
    '        Dim v_rptDocument As New ReportDocument
    '        Dim v_ctl As Control
    '        Dim pv_VoucherID As String
    '        pv_VoucherID = pv_strVoucherID
    '        Dim v_strRptFilePath As String = pv_VoucherID & ".rpt"
    '        Dim v_blnFileExists As Boolean = False
    '        Dim v_strReportDirectory, v_strReportTempDirectory As String

    '        Dim v_strSQL As String = String.Empty
    '        Dim v_strObjMsg As String = String.Empty
    '        Dim v_strOffName, v_strTlName, v_strTXSTATUS As String
    '        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery

    '        Dim v_xmlDocument As New XmlDocumentEx
    '        Dim v_nodeList As Xml.XmlNodeList
    '        Dim v_strValue, v_strFLDNAME As String

    '        'Modifier: Thanh.tran: check KH la nguoi nuoc ngoai hay trong nuoc
    '        Dim v_blnVietnamese As Boolean
    '        Dim v_strDValue As String
    '        Dim v_strMValue As String
    '        Dim v_strYValue As String
    '        Dim v_strTemp As String
    '        Dim d As New Date
    '        'Thanh.Tran end.
    '        v_strReportDirectory = GetReportDirectory()
    '        v_strReportTempDirectory = GetReportTempDirectory(v_strReportDirectory)
    '        Dim v_dirInfo As New DirectoryInfo(v_strReportDirectory)
    '        Dim v_fileInfo() As FileInfo = v_dirInfo.GetFiles("*.rpt")
    '        Dim v_file As FileInfo


    '        ' Check if report template is exists
    '        For Each v_file In v_fileInfo
    '            If v_file.Name = v_strRptFilePath Then
    '                v_blnFileExists = True
    '                Exit For
    '            End If
    '        Next

    '        'TruongLD Add 30/03/2010
    '        If v_blnFileExists = False Then
    '            'MessageBox.Show(mv_ResourceManager.GetString("FileNotExists"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            Exit Sub
    '        End If
    '        'End TruongLD


    '        'Load the report, fill formulars and save it to disk
    '        v_rptDocument.Load(v_strReportDirectory & v_strRptFilePath, CrystalDecisions.Shared.OpenReportMethod.OpenReportByTempCopy)

    '        Dim v_crFFieldDefinitions As FormulaFieldDefinitions
    '        Dim v_crFFieldDefinition As FormulaFieldDefinition
    '        Dim v_strFormulaName As String

    '        GetReportFormularValue()

    '        Dim v_strBANKID, v_strBANKNAME, v_strBANKACC, v_strBANKAFFILIATE, v_strBANKACCNAME, v_strGLACCTNO, v_strTXNUM, v_strTXDATE, v_strFEETYPE As String
    '        Dim V_STRCI_VATAMT, v_strBENEFACCT, v_strBENEFNAME, v_strBENEFCUSTNAME, v_strDESCRIPTION, v_strIORO, v_strCITYBANK, v_strCITYEF As String
    '        Dim v_dblAMT, v_dblFEEAMT, v_dblTRFAMT As Double
    '        'If blnPrePrint Then

    '        Dim v_strPrePrint As String
    '        If blnPrePrint Then
    '            v_strPrePrint = mv_CONST_PREPRINT
    '        Else
    '            v_strPrePrint = mv_CONST_NOT_PREPRINT
    '        End If
    '        Dim v_strClause As String = String.Empty
    '        Dim v_strCI_AMT, v_strCI_FEEAMT, v_strCI_TRFAMT, v_strCI_BENEFBANK, v_strCI_BENEFACCT, v_strCI_BENEFCUSTNAME, v_strCI_BENEFLICENSE, v_strCI_BENEFIDDATE, v_strCI_BENEFIDPLACE, v_strCI_DESCRIPTION, v_strCA_DESCRIPTION, v_strCI_IORO As String
    '        Dim v_strCI_IS1TRN As String = "Y"


    '        'v_strClause = "pv_POTXNUM!" & Me.txtTXNUM.Text.Trim() & "!varchar2!20"
    '        'If mv_strTLTXCD = "1108" Then
    '        '    v_strSQL = "pr_GetVoucher1108"
    '        '    v_strClause = "pv_POTXNUM!" & Me.txtTXNUM.Text.Trim() & "!varchar2!20^pv_OBJNAME!" & Me.mv_strObjName & "!varchar2!20^pv_TLTXCD!" & Me.mv_strTLTXCD & "!varchar2!20^pv_TXDATE!" & Trim(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TXDATE").Value) & "!varchar2!20^pv_TXNUM!" & Trim(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TXNUM").Value) & "!varchar2!20^pv_BANKID!" & mskBANKID.Text & "!varchar2!20"
    '        'Else
    '        v_strSQL = "pr_GetPaymentVoucher"
    '        v_strClause = "pv_POTXNUM!" & Me.txtTXNUM.Text.Trim() & "!varchar2!20^pv_OBJNAME!" & Me.mv_strObjName & "!varchar2!20^pv_TLTXCD!" & Me.mv_strTLTXCD & "!varchar2!20"
    '        'End If

    '        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strSQL, v_strClause, , , , , , , gc_CommandProcedure)
    '        v_ws.Message(v_strObjMsg)

    '        ''v_strSQL = " SELECT * FROM POMAST WHERE TXNUM='" & Me.txtTXNUM.Text.Trim() & "' AND DELTD <> 'Y'"

    '        ''v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
    '        'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL, "")
    '        'v_ws.Message(v_strObjMsg)


    '        v_xmlDocument.LoadXml(v_strObjMsg)
    '        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
    '        For i As Integer = 0 To v_nodeList.Count - 1
    '            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
    '                With v_nodeList.Item(i).ChildNodes(j)
    '                    v_strValue = .InnerText.ToString
    '                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
    '                    Select Case Trim(v_strFLDNAME)
    '                        Case "BANKID"
    '                            v_strBANKID = v_strValue.Trim()
    '                        Case "BANKNAME"
    '                            v_strBANKNAME = v_strValue.Trim()
    '                        Case "BANKACC"
    '                            v_strBANKACC = v_strValue.Trim()
    '                        Case "BANKAFFILIATE"
    '                            v_strBANKAFFILIATE = v_strValue.Trim()
    '                        Case "BANKACCNAME"
    '                            v_strBANKACCNAME = v_strValue.Trim()
    '                        Case "GLACCTNO"
    '                            v_strGLACCTNO = v_strValue.Trim()
    '                        Case "TXNUM"
    '                            v_strTXNUM = v_strValue.Trim()
    '                        Case "TXDATE"
    '                            v_strTXDATE = v_strValue.Trim()
    '                        Case "AMT"
    '                            v_dblAMT = CDbl(v_strValue.Trim())
    '                        Case "FEEAMT"
    '                            v_dblFEEAMT = CDbl(v_strValue.Trim())
    '                        Case "FEETYPE"
    '                            v_strFEETYPE = v_strValue.Trim()
    '                        Case "BENEFACCT"
    '                            v_strBENEFACCT = v_strValue.Trim()
    '                        Case "BENEFNAME"
    '                            v_strBENEFNAME = v_strValue.Trim()
    '                        Case "BENEFCUSTNAME"
    '                            v_strBENEFCUSTNAME = v_strValue.Trim()
    '                        Case "DESCRIPTION"
    '                            v_strDESCRIPTION = v_strValue.Trim()
    '                        Case "CI_AMT"
    '                            v_strCI_AMT = v_strValue
    '                        Case "CI_VATAMT"
    '                            V_STRCI_VATAMT = v_strValue
    '                        Case "CI_FEEAMT"
    '                            v_strCI_FEEAMT = v_strValue
    '                        Case "CI_BENEFBANK"
    '                            v_strCI_BENEFBANK = v_strValue
    '                        Case "CI_BENEFACCT"
    '                            v_strCI_BENEFACCT = v_strValue
    '                        Case "CI_BENEFCUSTNAME"
    '                            v_strCI_BENEFCUSTNAME = v_strValue
    '                        Case "CI_BENEFLICENSE"
    '                            v_strCI_BENEFLICENSE = v_strValue
    '                        Case "CI_BENEFIDDATE"
    '                            v_strCI_BENEFIDDATE = v_strValue
    '                        Case "CI_BENEFIDPLACE"
    '                            v_strCI_BENEFIDPLACE = v_strValue
    '                        Case "CI_DESCRIPTION"
    '                            v_strCI_DESCRIPTION = v_strValue
    '                        Case "CA_DESCRIPTION"
    '                            v_strCA_DESCRIPTION = v_strValue
    '                        Case "CI_IS1TRN"
    '                            v_strCI_IS1TRN = v_strValue
    '                        Case "CITYBANK"
    '                            v_strCITYBANK = v_strValue
    '                        Case "CITYEF"
    '                            v_strCITYEF = v_strValue

    '                    End Select
    '                End With
    '            Next
    '        Next

    '        v_crFFieldDefinitions = v_rptDocument.DataDefinition.FormulaFields()
    '        For i As Integer = 0 To v_crFFieldDefinitions.Count - 1
    '            v_crFFieldDefinition = v_crFFieldDefinitions.Item(i)
    '            v_strFormulaName = v_crFFieldDefinition.Name

    '            Dim v_intCount, v_intIndex As Integer
    '            Select Case v_strFormulaName.ToUpper()
    '                Case "P_BANKID"
    '                    v_crFFieldDefinition.Text = "'" & v_strBANKID & "'"
    '                Case "P_BANKNAME"
    '                    v_crFFieldDefinition.Text = "'" & v_strBANKNAME & "'"
    '                Case "P_BANKACC"
    '                    v_crFFieldDefinition.Text = "'" & v_strBANKACC & "'"
    '                Case "P_BANKACCNAME"
    '                    v_crFFieldDefinition.Text = "'" & v_strBANKACCNAME & "'"
    '                Case "P_BENEFACCT"
    '                    If (v_strCI_BENEFACCT.Length < 1) Then
    '                        v_crFFieldDefinition.Text = "'" & v_strBENEFACCT & "'"
    '                    Else
    '                        v_crFFieldDefinition.Text = "'" & v_strCI_BENEFACCT & "'"
    '                    End If
    '                Case "P_CADESCRIPTION"
    '                    v_crFFieldDefinition.Text = "'" & v_strCA_DESCRIPTION & "'"
    '                Case "P_BENEFNAME"
    '                    If mv_strIS1Transaction = "Y" Then
    '                        v_crFFieldDefinition.Text = "'" & mv_strBANKNAME_REF & "'"
    '                    Else
    '                        v_crFFieldDefinition.Text = "'" & v_strBENEFNAME & "'"
    '                    End If
    '                Case "P_BENEFBANK"
    '                    If (v_strCI_BENEFBANK.Length < 2) Then
    '                        v_crFFieldDefinition.Text = "'" & v_strBENEFNAME & "'"
    '                    Else
    '                        v_crFFieldDefinition.Text = "'" & v_strCI_BENEFBANK & "'"
    '                    End If
    '                Case "P_BENEFCUSTNAME"
    '                    If (v_strCI_BENEFCUSTNAME.Length < 1) Then
    '                        v_crFFieldDefinition.Text = "'" & v_strBENEFCUSTNAME & "'"
    '                    Else
    '                        v_crFFieldDefinition.Text = "'" & v_strCI_BENEFCUSTNAME & "'"
    '                    End If
    '                Case "P_BENEFLICENSE"
    '                    v_crFFieldDefinition.Text = "'" & v_strCI_BENEFLICENSE & "'"
    '                Case "P_DESC"
    '                    If mv_strTableName <> mv_CONST_SEARCHCODE_1104 And mv_strTableName <> mv_CONST_SEARCHCODE_1108 Then
    '                        v_crFFieldDefinition.Text = "'" & v_strCI_DESCRIPTION & "'"
    '                    Else
    '                        v_crFFieldDefinition.Text = "'" & v_strDESCRIPTION & "'"
    '                    End If
    '                Case "P_CITYBANK"
    '                    v_crFFieldDefinition.Text = "'" & v_strCITYBANK & "'"
    '                Case "P_CITYEF"
    '                    v_crFFieldDefinition.Text = "'" & v_strCITYEF & "'"
    '                Case "P_BENEFIDDATE"
    '                    v_crFFieldDefinition.Text = "'" & v_strCI_BENEFIDDATE & "'"
    '                Case "P_BENEFIDPLACE"
    '                    v_crFFieldDefinition.Text = "'" & v_strCI_BENEFIDPLACE & "'"
    '                Case "P_IS1TRN"
    '                    v_crFFieldDefinition.Text = "'" & v_strCI_IS1TRN & "'"
    '                Case "P_GLACCTNO"
    '                    v_crFFieldDefinition.Text = "'" & v_strGLACCTNO & "'"
    '                Case "P_AMT"
    '                    v_crFFieldDefinition.Text = "'" & v_strCI_AMT & "'"
    '                Case "P_FEEAMT"
    '                    v_crFFieldDefinition.Text = "'" & v_strCI_FEEAMT & "'"
    '                Case "P_CI_VATAMT"
    '                    v_crFFieldDefinition.Text = "'" & V_STRCI_VATAMT & "'"
    '                Case "P_DATE"
    '                    v_crFFieldDefinition.Text = "'" & v_strTXDATE & "'"
    '                Case "P_POTXNUM"
    '                    v_crFFieldDefinition.Text = "'" & v_strTXNUM & "'"
    '                Case "P_FEETYPE"
    '                    v_crFFieldDefinition.Text = "'" & v_strFEETYPE & "'"
    '                Case "P_PREPRINT"
    '                    v_crFFieldDefinition.Text = "'" & v_strPrePrint & "'"
    '                Case "P_BANKAFFILIATE"
    '                    v_crFFieldDefinition.Text = "'" & v_strBANKAFFILIATE & "'"
    '                Case gc_RPT_FORMULAR_BRID
    '                    v_crFFieldDefinition.Text = "'" & Me.BranchId & "'"
    '                Case gc_RPT_FORMULAR_HEADOFFICE
    '                    v_crFFieldDefinition.Text = "'" & HEADOFFICE & "'"
    '                Case gc_RPT_FORMULAR_COMPANY_NAME
    '                    v_crFFieldDefinition.Text = "'" & BranchName & "'"
    '                Case gc_RPT_FORMULAR_ADDRESS
    '                    v_crFFieldDefinition.Text = "'" & BranchAddress & "'"
    '                Case gc_RPT_FORMULAR_PHONE_FAX
    '                    v_crFFieldDefinition.Text = "'" & BranchPhoneFax & "'"
    '                Case gc_RPT_FORMULAR_REPORT_TITLE
    '                    v_crFFieldDefinition.Text = "'" & ReportTitle & "'"
    '                Case gc_FORMULAR_DEALINGCUSTODYCD
    '                    v_crFFieldDefinition.Text = "'" & DEALINGCUSTODYCD & "'"
    '                Case gc_RPT_FORMULAR_CREATED_DATE
    '                    v_crFFieldDefinition.Text = "'" & Me.BusDate & "'"
    '                Case gc_RPT_FORMULAR_CREATED_BY
    '                    v_crFFieldDefinition.Text = "'" & Me.TellerId & "'"

    '            End Select
    '        Next

    '        'TruongLD Add 14/09/2011
    '        'Neu dung Culture la "vi-VN" --> khong su dung duoc func Convert Number to Text --> Chuyen ve "en-US"
    '        'Chuyen doi cau hinh User Account Windows theo cau hinh cua Office

    '        v_strOldCultureName = SetCultureInfo("en-US")
    '        'End TruongLD

    '        If v_rptDocument.IsLoaded Then
    '            'Export to PDF
    '            v_rptDocument.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.CrystalReport, v_strReportTempDirectory & pv_VoucherID & ".rpt")
    '        End If

    '        Dim v_frm As New frmReportView
    '        Dim v_Path As String = Environment.CurrentDirectory
    '        v_frm.RptFileName = v_strReportTempDirectory & pv_VoucherID & ".rpt"
    '        v_frm.RptName = pv_VoucherID
    '        v_frm.ShowDialog()
    '        Environment.CurrentDirectory = v_Path
    '        'TruongLD Add 14/09/2011
    '        'Tra lai cau hinh User Account Windows theo mac dinh cua chuong trinh
    '        'v_strOldCultureName = SetCultureInfo(v_strOldCultureName)
    '        'End TruongLD

    '    Catch ex As Exception

    '        LogError.Write("Error source: " & ex.Source & vbNewLine _
    '                     & "Error code: System error!" & vbNewLine _
    '                     & "Error message: " & ex.Message, EventLogEntryType.Error)
    '    Finally
    '        If Len(v_strOldCultureName) > 0 Then
    '            v_strOldCultureName = SetCultureInfo(v_strOldCultureName)
    '        End If
    '    End Try
    'End Sub

    Private Sub GetReportFormularValue()
        Try
            'Get common values from SYSVAR table
            Dim v_strSQL As String = "SELECT VARNAME, VARVALUE FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND varname IN ('BRADDRESS','BRPHONEFAX','BRNAME', 'HEADOFFICE', 'DEALINGCUSTODYCD')"
            Dim v_strObjMsg As String = String.Empty
            Dim v_ws As New BDSRptDeliveryManagement
            Dim v_intRowCount As Integer
            Dim v_strVarName, v_strVarValue As String

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeRpt, , gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)

            Dim v_xmlDocument As New XmlDocumentEx
            Dim v_xmlNode As Xml.XmlNode

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_intRowCount = v_xmlDocument.FirstChild.ChildNodes.Count

            If (v_intRowCount > 0) Then
                v_xmlNode = v_xmlDocument.FirstChild

                For i As Integer = 0 To v_intRowCount - 1
                    v_strVarName = v_xmlNode.ChildNodes(i).ChildNodes(0).InnerText.Trim().ToUpper()

                    Select Case v_strVarName
                        Case "HEADOFFICE"
                            HEADOFFICE = v_xmlNode.ChildNodes(i).ChildNodes(1).InnerText.Trim()
                        Case "BRNAME"
                            BranchName = v_xmlNode.ChildNodes(i).ChildNodes(1).InnerText.Trim()
                        Case "BRADDRESS"
                            BranchAddress = v_xmlNode.ChildNodes(i).ChildNodes(1).InnerText.Trim()
                        Case "BRPHONEFAX"
                            BranchPhoneFax = v_xmlNode.ChildNodes(i).ChildNodes(1).InnerText.Trim()
                        Case "DEALINGCUSTODYCD"
                            DEALINGCUSTODYCD = v_xmlNode.ChildNodes(i).ChildNodes(1).InnerText.Trim()
                    End Select
                Next
            Else
                BranchName = String.Empty
                BranchAddress = String.Empty
                BranchPhoneFax = String.Empty
                DEALINGCUSTODYCD = String.Empty
                HEADOFFICE = String.Empty
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Function GetReportDirectory() As String 'linh add
        Try
            'Get report directory from SYSVAL table on BDS
            Dim v_strSQL As String = String.Empty
            Dim v_strObjMsg As String = String.Empty
            'TruongLD Comment when convert
            'Dim v_ws As New BDSRptDelivery.BDSRptDelivery
            'TruongLD Add when convert
            Dim v_ws As New BDSRptDeliveryManagement
            'End TruongLD
            Dim v_xmlDocument As New XmlDocumentEx
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strValue, v_strFLDNAME As String
            Dim v_strReportDir As String = String.Empty

            v_strSQL = "SELECT VARVALUE FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'DIRRPTFILES'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, , gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)

                        Select Case Trim(v_strFLDNAME)
                            Case "VARVALUE"
                                v_strReportDir = v_strValue.Trim()
                        End Select
                    End With
                Next
            Next

            If Not (v_strReportDir.Length > 0) Then
                v_strReportDir = GetDirectoryName(ExecutablePath) & "\REPORTS\"
            End If
            v_strReportDir = v_strReportDir.Trim() & IIf(v_strReportDir.Trim().Substring(v_strReportDir.Trim().Length - 1) = "\", "", "\")

            'Check if report directory is exists; otherwise, create it
            Dim v_dirInfo As New DirectoryInfo(v_strReportDir)
            If Not (v_dirInfo.Exists) Then
                v_dirInfo.Create()
            End If
            'Check if report temporary directory is exists; otherwise, create it
            v_dirInfo = New DirectoryInfo(GetReportTempDirectory(v_strReportDir))
            If Not (v_dirInfo.Exists) Then
                v_dirInfo.Create()
            End If

            Return v_strReportDir
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function
    Private Function GetReportTempDirectory(ByVal pv_strReportDir As String) As String
        Return pv_strReportDir & "TEMP\"
    End Function

    Private Function checkTypeGridCurrentRow(ByVal pv_ExceedRow As Xceed.Grid.Row) As Boolean
        Try
            Dim obj As New Xceed.Grid.DataRow
            obj = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

#End Region

#Region "Overrides"
    'Protected Overrides Sub Grid_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    MyBase.Grid_Click(sender, e)
    '    Dim v_dblAMT As Double = 0
    '    Dim v_dblFEEAMT As Double = 0
    '    Dim v_dblPoolRemain As Double = 0
    '    Try
    '        If InStr(mv_CONST_SEARCHCODE_ADVANCED, mv_strTableName) > 0 Then
    '            Try


    '                For i As Integer = 0 To SearchGrid.DataRows.Count - 1
    '                    If Not SearchGrid.DataRows(i) Is Nothing Then
    '                        If SearchGrid.DataRows(i).Cells("__TICK").Value = "X" Then
    '                            v_dblAMT = v_dblAMT + SearchGrid.DataRows(i).Cells("DEPOAMT").Value
    '                            v_dblFEEAMT = v_dblFEEAMT + SearchGrid.DataRows(i).Cells("CMPFEEAMT").Value + SearchGrid.DataRows(i).Cells("BANKFEEAMT").Value
    '                        End If

    '                    End If
    '                Next

    '                v_dblPoolRemain = CDbl(txtAVLPOOL.Text) - v_dblAMT
    '                txtADVAMT.Text = Format(v_dblAMT, gc_FORMAT_NUMBER_0)
    '                txtADVFEEAMT.Text = Format(v_dblFEEAMT, gc_FORMAT_NUMBER_0)
    '                txtPOOLREMAIN.Text = Format(v_dblPoolRemain, gc_FORMAT_NUMBER_0)

    '            Catch ex As Exception
    '                v_dblPoolRemain = 0
    '                txtADVAMT.Text = Format(v_dblAMT, gc_FORMAT_NUMBER_0)
    '                txtADVFEEAMT.Text = Format(v_dblFEEAMT, gc_FORMAT_NUMBER_0)
    '                txtPOOLREMAIN.Text = Format(v_dblPoolRemain, gc_FORMAT_NUMBER_0)
    '            End Try
    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Sub

    Protected Overrides Sub InitDialog()

        MyBase.InitDialog()
        Try

            mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())

            If mv_strTableName = mv_CONST_SEARCHCODE_1104 Then
                TabMain.TabPages.Remove(TabBenefInfo)
                TabMain.TabPages.Remove(TabAdvanced)
                LoadResourceLocal(grbMain)
                TabTranferInfo.Text = mv_ResourceManager.GetString(TabTranferInfo.Name)
            ElseIf mv_strTableName = mv_CONST_SEARCHCODE_3387 Then
                TabMain.TabPages.Remove(TabAdvanced)
                LoadResourceLocal(grbMain)
                LoadResourceLocal(grbBeneficiary)
                TabBenefInfo.Text = mv_ResourceManager.GetString(TabBenefInfo.Name)
                TabTranferInfo.Text = mv_ResourceManager.GetString(TabTranferInfo.Name)
            ElseIf InStr(mv_CONST_SEARCHCODE_ADVANCED, mv_strTableName) > 0 Then
                TabMain.TabPages.Remove(TabBenefInfo)
                TabMain.TabPages.Remove(TabTranferInfo)
                LoadResourceLocal(grbAdvanced)
                TabAdvanced.Text = mv_ResourceManager.GetString(TabAdvanced.Name)
                Me.txtSRCACCTNO.Mask = "ccccdcccccc"
                Me.txtSRCACCTNO.TextAlign = HorizontalAlignment.Center
                LoadComboRRType()
            Else
                TabMain.TabPages.Remove(TabAdvanced)
                TabMain.TabPages.Remove(TabBenefInfo)
                LoadResourceLocal(grbMain)
                'LoadResourceLocal(grbBeneficiary)
                'TabBenefInfo.Text = mv_ResourceManager.GetString(TabBenefInfo.Name)
                TabTranferInfo.Text = mv_ResourceManager.GetString(TabTranferInfo.Name)
            End If
            If InStr(mv_CONST_SEARCHCODE_ADVANCED, mv_strTableName) > 0 Then
                If Me.SearchGrid.DataRowTemplate.Cells.Count >= 0 Then
                    For i As Integer = 0 To Me.SearchGrid.DataRowTemplate.Cells.Count - 1
                        If SearchGrid.Columns(i).FieldName = "__TICK" Then
                            AddHandler SearchGrid.DataRowTemplate.Cells(i).ValueChanged, AddressOf AdvanceGrid_ValueChanged
                        End If
                    Next
                End If
            End If
            If mv_strTableName <> mv_CONST_SEARCHCODE_1104 And mv_strTableName <> mv_CONST_SEARCHCODE_1108 Then
                Me.txtDESC.Enabled = False
            End If


            Me.mskBANKID.BackColor = System.Drawing.Color.GreenYellow
            Me.mskBANKID.Focus()
            Me.mskBANKID.Mask = "99999999999999999999999999999999999999999999999999"
            Me.mskBANKID.MaskCharInclude = False
            Me.txtBANKACC.Enabled = False
            Me.txtGLACCTNO.Enabled = False
            Me.txtBANKACCNAME.Enabled = False
            Me.txtBANKNAME.Enabled = False

            Me.chkExeAll.Checked = True

            Me.txtCITAD.BackColor = System.Drawing.Color.GreenYellow
        Catch ex As Exception
        Finally
        End Try

    End Sub

    Protected Overrides Sub DoResizeForm()
    End Sub
#End Region

#Region "Form events "

    Private Sub frmPaymentOrder_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Dim v_intPos As Int16
        Dim ctl As Control
        Dim strFLDNAME As String = String.Empty
        Dim v_intIndex As Integer = 0
        Select Case e.KeyCode
            Case Keys.F5
                If Me.ActiveControl.Name = "mskBANKID" Then
                    Dim frm As New frmSearch(Me.UserLanguage)
                    frm.TableName = "BANKNOSTRO"
                    frm.ModuleCode = "CF"
                    frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                    frm.IsLocalSearch = gc_IsNotLocalMsg
                    frm.IsLookup = "Y"
                    frm.SearchOnInit = False
                    frm.BranchId = Me.BranchId
                    frm.TellerId = Me.TellerId
                    frm.ShowDialog()
                    Me.ActiveControl.Text = Trim(frm.ReturnValue)
                    frm.Dispose()
                    GetBankInfo(mskBANKID.Text.Trim())
                    c_BankTyp = "N"
                ElseIf Me.ActiveControl.Name = "mskBANKDTID" Then
                    Dim frm As New frmSearch(Me.UserLanguage)
                    frm.TableName = "CRBBANKTRFLIST"
                    frm.ModuleCode = "CF"
                    frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                    frm.IsLocalSearch = gc_IsNotLocalMsg
                    frm.IsLookup = "Y"
                    frm.SearchOnInit = False
                    frm.BranchId = Me.BranchId
                    frm.TellerId = Me.TellerId
                    frm.ShowDialog()
                    Me.ActiveControl.Text = Trim(frm.ReturnValue)
                    frm.Dispose()
                End If
            Case Keys.Enter
                If Me.ActiveControl.Name = "mskBANKID" Then
                    'Nạp thông tin tài khoản mới
                    If Len(Trim(ActiveControl.Text.Replace(".", ""))) = LEN_AFACCTNO Then
                        GetBankInfo(ActiveControl.Text)
                        SendKeys.Send("{Tab}")
                        e.Handled = True
                    End If

                ElseIf Not TypeOf (Me.ActiveControl) Is Button Then

                    SendKeys.Send("{Tab}")
                    e.Handled = True
                Else
                End If
        End Select
    End Sub

    'Private Sub mskBANKID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    GetBankInfo(mskBANKID.Text)
    'End Sub

    Private Sub FormatNumericTextbox(ByVal pv_ctrl As TextBox)
        Try
            Dim v_strFormat As String
            Dim v_intDecimal As String
            Dim v_intIndex As Integer
            v_intIndex = CType(pv_ctrl, TextBox).Tag
            v_strFormat = mv_arrObjFields(v_intIndex).FieldFormat
            If (v_strFormat.Length > 0) Then
                If (v_strFormat.IndexOf(".") <> -1) Then
                    v_intDecimal = Mid(v_strFormat, v_strFormat.IndexOf(".") + 2).Length()
                Else
                    v_intDecimal = 0
                End If
            Else
                v_intDecimal = 0
            End If

            If IsNumeric(pv_ctrl.Text) Then
                If FormatNumber(pv_ctrl.Text, v_intDecimal) = FRound(CDbl(pv_ctrl.Text)) Then
                    pv_ctrl.Text = FormatNumber(Math.Floor(CDbl(pv_ctrl.Text)), v_intDecimal)
                Else
                    pv_ctrl.Text = FormatNumber(pv_ctrl.Text, v_intDecimal)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdPrePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrePrint.Click


        Dim v_strSQL, v_strClause, v_strObjMsg As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode
        Dim v_strValue, v_strFLDNAME, v_strFLDCD, v_strFLDCODE, v_strTLTXCD, v_strMODCODE, v_strFLDDEFVAL, v_strFIELDTYPE As String, i, j, v_intRow As Integer
        Dim v_strPostingDate As String
        Dim lngReturn As Long

        'Căn cứ vào SEARCHCODE để lấy mã giao dịch (TLTXCD)
        v_strSQL = "SELECT APPMODULES.MODCODE, SEARCH.TLTXCD, SEARCHFLD.FIELDCODE, SEARCHFLD.FLDCD,SEARCHFLD.FIELDTYPE  FROM APPMODULES, SEARCH, SEARCHFLD " & ControlChars.CrLf _
            & "WHERE SEARCH.SEARCHCODE=SEARCHFLD.SEARCHCODE AND APPMODULES.TXCODE=SUBSTR(SEARCH.TLTXCD,1,2) AND LENGTH(SEARCH.TLTXCD)=4 AND SEARCH.SEARCHCODE='" & mv_strTableName & "'"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLTX, gc_ActionInquiry, v_strSQL)
        v_ws.Message(v_strObjMsg)
        v_xmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
        v_strFLDDEFVAL = String.Empty
        v_strMODCODE = String.Empty
        v_strTLTXCD = String.Empty

        If Not v_nodeList.Count = 0 Then
            For i = 0 To v_nodeList.Count - 1
                v_strFLDCODE = String.Empty
                v_strFLDCD = String.Empty
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "TLTXCD"
                                mv_strTLTXCD = Trim(v_strValue)
                        End Select
                    End With
                Next
            Next
        End If



        Dim frm As New frmSearch(Me.UserLanguage)
        frm.TableName = "POMAST_PR"
        frm.ModuleCode = "CI"
        frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
        frm.IsLocalSearch = gc_IsNotLocalMsg
        frm.IsLookup = "Y"
        frm.SearchOnInit = False
        frm.BranchId = Me.BranchId
        frm.TellerId = Me.TellerId
        frm.BusDate = Me.BusDate
        frm.ShowDialog()
        Me.txtTXNUM.Text = String.Empty
        Me.txtTXNUM.Text = Trim(frm.ReturnValue)
        frm.Dispose()

        If Len(Me.txtTXNUM.Text) > 0 Then

            'Dim blnConfirm As MsgBoxResult = MsgBoxResult.Cancel
            'blnConfirm = MsgBox(mv_ResourceManager.GetString("ChooseVoucher1"), MsgBoxStyle.Information + MsgBoxStyle.YesNo, Me.Text)
            ''Chọn <Yes> in UNC BIDV
            ''Chọn <No> in UNC ngân hàng khác
            'If blnConfirm = MsgBoxResult.Yes Then
            '    PrintPaymentOrder("POBIDV", True)
            'ElseIf blnConfirm = MsgBoxResult.No Then
            '    PrintPaymentOrder("POOTHER", True)
            'End If
            Dim frmVouchers As New frmVouchers(Me.UserLanguage)
            frmVouchers.BranchID = BranchId
            frmVouchers.TellerID = TellerId
            frmVouchers.TLTXCD = Me.TltxCD
            frmVouchers.ShowDialog()
            Dim v_returnvalue As String = Trim(frmVouchers.ReturnValue)
            'PrintPaymentOrder(v_returnvalue, True)
        Else
            'MsgBox(mv_ResourceManager.GetString("NotFoundVoucher"), MsgBoxStyle.Information + MsgBoxStyle.Information, Me.Text)
        End If

    End Sub

    Private Sub mskBANKID_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskBANKID.GotFocus
        mskBANKID.SelectionStart = mskBANKID.Text.Trim().Length
    End Sub

    Private Sub mskBANKID_Validated1(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskBANKID.Validated
        'mskBANKID.Text = Trim(mskBANKID.Text).PadLeft(10, "0")
        'GetBankInfo(mskBANKID.Text.Trim())
        'c_BankTyp = "N"

    End Sub

    Private Sub mskBANKID_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mskBANKID.KeyUp
        'mskBANKID.Text = Trim(mskBANKID.Text).PadLeft(10, "0")
        GetBankInfo(mskBANKID.Text.Trim())
        c_BankTyp = "N"
    End Sub

    Private Sub cboRRTYPE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRRTYPE.SelectedIndexChanged
        If cboRRTYPE.SelectedValue.ToString.Length <> 0 Then
            SetAdvTypeInfo(cboRRTYPE.SelectedValue)
            OnSearch(gc_IsNotLocalMsg, OBJNAME_CI_CIMAST)
        End If
    End Sub



    Protected Overridable Sub AdvanceGrid_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim v_dblAdvanceAmt As Double = 0
        Dim v_dblFeeAmt As Double = 0
        If mv_strTableName = "CI1178" Then
            For i As Integer = 0 To SearchGrid.DataRows.Count - 1 Step 1
                If Not SearchGrid.DataRows(i) Is Nothing Then
                    If SearchGrid.DataRows(i).Cells("__TICK").Value = "X" Then
                        v_dblAdvanceAmt = v_dblAdvanceAmt + CDbl(SearchGrid.DataRows(i).Cells("AMT").Value)
                        v_dblFeeAmt = v_dblFeeAmt + CDbl(SearchGrid.DataRows(i).Cells("FEEAMT").Value)
                    End If
                End If
            Next
        Else
            For i As Integer = 0 To SearchGrid.DataRows.Count - 1 Step 1
                If Not SearchGrid.DataRows(i) Is Nothing Then
                    If SearchGrid.DataRows(i).Cells("__TICK").Value = "X" Then
                        v_dblAdvanceAmt = v_dblAdvanceAmt + CDbl(SearchGrid.DataRows(i).Cells("MAXAVLAMT").Value)
                        v_dblFeeAmt = 0
                    End If
                End If
            Next
        End If

        Me.txtADVAMT.Text = Format(v_dblAdvanceAmt, gc_FORMAT_NUMBER_0)
        Me.txtADVFEEAMT.Text = Format(v_dblFeeAmt, gc_FORMAT_NUMBER_0)
        Me.txtPOOLREMAIN.Text = Format(CDbl(Me.txtAVLPOOL.Text) - v_dblAdvanceAmt - v_dblFeeAmt, gc_FORMAT_NUMBER_0)
        If CDec(CDbl(Me.txtAVLPOOL.Text) - v_dblAdvanceAmt - v_dblFeeAmt) < 0 Then
            Me.txtPOOLREMAIN.ForeColor = Color.Red
        Else
            Me.txtPOOLREMAIN.ForeColor = Color.Green
        End If
    End Sub
#End Region



    Private Sub mskBANKDTID_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mskBANKDTID.Validated
        GetBankDTInfo(mskBANKDTID.Text.Trim())
        c_BankTyp = "E"
    End Sub

    Private Sub txtCITAD_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCITAD.KeyUp
        Select Case e.KeyCode
            Case Keys.F5
                Dim frm As New frmSearch(Me.UserLanguage)
                frm.TableName = "CRBBANKLIST"
                frm.ModuleCode = "SA"
                frm.KeyFieldType = "C"
                frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                frm.IsLocalSearch = gc_IsNotLocalMsg
                frm.IsLookup = "Y"
                frm.SearchOnInit = False
                frm.BranchId = "9999"
                frm.TellerId = Me.TellerId
                frm.ShowDialog()
                Me.ActiveControl.Text = Trim(frm.ReturnValue)
        End Select
    End Sub

    Private Sub txtCITAD_Leave(sender As Object, e As EventArgs) Handles txtCITAD.Leave
        GetCitadInfo(txtCITAD.Text)
    End Sub

    Private Sub GetCitadInfo(ByVal v_strCitad As String)
        Dim v_ws As New BDSDeliveryManagement
        Try
            v_strCitad = v_strCitad.Replace(".", "")
            If mv_strLastCitad <> v_strCitad Then
                'Dim v_strCODEID As String = Me.cboCODEID.SelectedValue
                Dim v_nodeList As Xml.XmlNodeList
                Dim v_xmlDocument As New Xml.XmlDocument
                Dim v_strValue, v_strFLDNAME, v_strTEXT As String, i, j As Integer

                Dim v_strCmdSQL As String, v_strObjMsg, v_strCURRPRICE, v_strSQL, v_strClause As String

                v_strCmdSQL = "SELECT CRB.CITAD,CRB.CITAD BANKCODE,CRB.BANKNAME,CRB.BRANCHNAME,CRB.BANKBICCODE,A1.CDCONTENT STATUS " & _
                            "FROM CRBBANKLIST CRB, ALLCODE A1 WHERE A1.CDTYPE='SY' AND A1.CDNAME='APPRV_STS' AND A1.CDVAL=CRB.STATUS " & _
                            "AND CRB.CITAD = '" & v_strCitad & "'"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL, , , , , , , , gc_CommandText)
                v_ws.Message(v_strObjMsg)

                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                v_strTEXT = String.Empty

                For i = 0 To v_nodeList.Count - 1
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = Trim(.InnerText.ToString)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "BANKNAME"
                                    mv_strBANKNAME = v_strValue
                                Case "BRANCHNAME"
                                    mv_strBANKACCNAME = v_strValue
                            End Select
                        End With
                    Next
                Next

                txtBENEFBANKNAME.Text = mv_strBANKNAME & " " & mv_strBANKACCNAME
                mv_strLastCitad = v_strCitad
            End If
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Information, Me.Text)
        Finally
            'v_ws.Dispose()
        End Try
    End Sub
End Class
