Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports CommonLibrary
Imports System.Collections
Imports AppCore
Imports AppCore.modCoreLib
Imports System.Security.Cryptography
Imports System.Xml

Public Class frmTeleInq
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New()

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
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents pnInfo As System.Windows.Forms.Panel
    Friend WithEvents pnACCTNO As System.Windows.Forms.Panel
    Friend WithEvents lblACCTNO As System.Windows.Forms.Label
    Friend WithEvents txtACCTNO As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents lblCaption As System.Windows.Forms.Label
    Friend WithEvents lblTimer As System.Windows.Forms.Label
    Friend WithEvents tmrOrder As System.Windows.Forms.Timer
    Friend WithEvents txtIDCODE As System.Windows.Forms.TextBox
    Friend WithEvents lblIDCODE As System.Windows.Forms.Label
    Friend WithEvents txtMOBILE As System.Windows.Forms.TextBox
    Friend WithEvents grbACCTNOINFO As System.Windows.Forms.GroupBox
    Friend WithEvents lblCODE As System.Windows.Forms.Label
    Friend WithEvents lblPIN As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblSE As System.Windows.Forms.Label
    Friend WithEvents lblCI As System.Windows.Forms.Label
    'Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    'Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents pnSE As System.Windows.Forms.Panel
    Friend WithEvents pnCI As System.Windows.Forms.Panel
    Friend WithEvents btnCIIncrease As System.Windows.Forms.Button
    Friend WithEvents btnRightOff As System.Windows.Forms.Button
    Friend WithEvents btnChangePIN As System.Windows.Forms.Button
    Friend WithEvents lblACCLIST As System.Windows.Forms.Label
    Friend WithEvents lblBankAVLBAL As System.Windows.Forms.Label
    Friend WithEvents lblBankBalance As System.Windows.Forms.Label
    Friend WithEvents lblBankAVLBALV As System.Windows.Forms.Label
    Friend WithEvents lblBankBalanceV As System.Windows.Forms.Label
    Friend WithEvents txtPinValidate As System.Windows.Forms.TextBox
    Friend WithEvents lblPinValidate As System.Windows.Forms.Label
    Friend WithEvents btnPinValidate As System.Windows.Forms.Button
    Friend WithEvents lblMOBILEV As System.Windows.Forms.Label
    Friend WithEvents lblMOBILESMSV As System.Windows.Forms.Label
    Friend WithEvents lblMOBILE1 As System.Windows.Forms.Label
    Friend WithEvents lblMOBILESMS As System.Windows.Forms.Label
    Friend WithEvents btnCIDecrease As System.Windows.Forms.Button
    Friend WithEvents btnCIBlocked As System.Windows.Forms.Button
    Friend WithEvents btnCIUnBlocked As System.Windows.Forms.Button
    Friend WithEvents btnSEIncrease As System.Windows.Forms.Button
    Friend WithEvents btnSEDecrease As System.Windows.Forms.Button
    Friend WithEvents btnSEBlocked As System.Windows.Forms.Button
    Friend WithEvents btnSEUnBlocked As System.Windows.Forms.Button
    Friend WithEvents lblMOBILE As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.pnlTitle = New System.Windows.Forms.Panel
        Me.lblTimer = New System.Windows.Forms.Label
        Me.lblCaption = New System.Windows.Forms.Label
        Me.pnInfo = New System.Windows.Forms.Panel
        Me.txtMOBILE = New System.Windows.Forms.TextBox
        Me.lblMOBILE = New System.Windows.Forms.Label
        Me.txtPinValidate = New System.Windows.Forms.TextBox
        Me.lblPinValidate = New System.Windows.Forms.Label
        Me.txtIDCODE = New System.Windows.Forms.TextBox
        Me.lblIDCODE = New System.Windows.Forms.Label
        Me.btnPinValidate = New System.Windows.Forms.Button
        Me.btnSearch = New System.Windows.Forms.Button
        Me.txtACCTNO = New System.Windows.Forms.TextBox
        Me.lblACCTNO = New System.Windows.Forms.Label
        Me.pnACCTNO = New System.Windows.Forms.Panel
        Me.btnCancel = New System.Windows.Forms.Button
        Me.tmrOrder = New System.Windows.Forms.Timer(Me.components)
        Me.grbACCTNOINFO = New System.Windows.Forms.GroupBox
        Me.lblMOBILEV = New System.Windows.Forms.Label
        Me.lblMOBILESMSV = New System.Windows.Forms.Label
        Me.lblMOBILE1 = New System.Windows.Forms.Label
        Me.lblMOBILESMS = New System.Windows.Forms.Label
        Me.lblBankAVLBALV = New System.Windows.Forms.Label
        Me.lblBankBalanceV = New System.Windows.Forms.Label
        Me.lblBankAVLBAL = New System.Windows.Forms.Label
        Me.lblBankBalance = New System.Windows.Forms.Label
        Me.pnSE = New System.Windows.Forms.Panel
        Me.pnCI = New System.Windows.Forms.Panel
        Me.lblSE = New System.Windows.Forms.Label
        Me.lblCI = New System.Windows.Forms.Label
        Me.lblCODE = New System.Windows.Forms.Label
        Me.lblPIN = New System.Windows.Forms.Label
        Me.lblName = New System.Windows.Forms.Label
        Me.btnCIIncrease = New System.Windows.Forms.Button
        Me.btnRightOff = New System.Windows.Forms.Button
        Me.btnChangePIN = New System.Windows.Forms.Button
        Me.lblACCLIST = New System.Windows.Forms.Label
        Me.btnCIDecrease = New System.Windows.Forms.Button
        Me.btnCIBlocked = New System.Windows.Forms.Button
        Me.btnCIUnBlocked = New System.Windows.Forms.Button
        Me.btnSEIncrease = New System.Windows.Forms.Button
        Me.btnSEDecrease = New System.Windows.Forms.Button
        Me.btnSEBlocked = New System.Windows.Forms.Button
        Me.btnSEUnBlocked = New System.Windows.Forms.Button
        Me.pnlTitle.SuspendLayout()
        Me.pnInfo.SuspendLayout()
        Me.grbACCTNOINFO.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTitle
        '
        Me.pnlTitle.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlTitle.Controls.Add(Me.lblTimer)
        Me.pnlTitle.Controls.Add(Me.lblCaption)
        Me.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitle.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(872, 50)
        Me.pnlTitle.TabIndex = 0
        '
        'lblTimer
        '
        Me.lblTimer.Location = New System.Drawing.Point(770, 13)
        Me.lblTimer.Name = "lblTimer"
        Me.lblTimer.Size = New System.Drawing.Size(95, 24)
        Me.lblTimer.TabIndex = 1
        Me.lblTimer.Tag = "lblTimer"
        Me.lblTimer.Text = "lblTimer"
        Me.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCaption
        '
        Me.lblCaption.Location = New System.Drawing.Point(16, 17)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(464, 23)
        Me.lblCaption.TabIndex = 0
        Me.lblCaption.Tag = "lblCaption"
        Me.lblCaption.Text = "lblCaption"
        '
        'pnInfo
        '
        Me.pnInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnInfo.Controls.Add(Me.txtMOBILE)
        Me.pnInfo.Controls.Add(Me.lblMOBILE)
        Me.pnInfo.Controls.Add(Me.txtPinValidate)
        Me.pnInfo.Controls.Add(Me.lblPinValidate)
        Me.pnInfo.Controls.Add(Me.txtIDCODE)
        Me.pnInfo.Controls.Add(Me.lblIDCODE)
        Me.pnInfo.Controls.Add(Me.btnPinValidate)
        Me.pnInfo.Controls.Add(Me.btnSearch)
        Me.pnInfo.Controls.Add(Me.txtACCTNO)
        Me.pnInfo.Controls.Add(Me.lblACCTNO)
        Me.pnInfo.Location = New System.Drawing.Point(8, 57)
        Me.pnInfo.Name = "pnInfo"
        Me.pnInfo.Size = New System.Drawing.Size(424, 118)
        Me.pnInfo.TabIndex = 1
        '
        'txtMOBILE
        '
        Me.txtMOBILE.Location = New System.Drawing.Point(86, 8)
        Me.txtMOBILE.MaxLength = 11
        Me.txtMOBILE.Name = "txtMOBILE"
        Me.txtMOBILE.Size = New System.Drawing.Size(125, 20)
        Me.txtMOBILE.TabIndex = 3
        Me.txtMOBILE.Tag = "MOBILE"
        Me.txtMOBILE.Text = "txtMOBILE"
        '
        'lblMOBILE
        '
        Me.lblMOBILE.Location = New System.Drawing.Point(6, 8)
        Me.lblMOBILE.Name = "lblMOBILE"
        Me.lblMOBILE.Size = New System.Drawing.Size(80, 23)
        Me.lblMOBILE.TabIndex = 1
        Me.lblMOBILE.Tag = "lblMOBILE"
        Me.lblMOBILE.Text = "lblMOBILE"
        '
        'txtPinValidate
        '
        Me.txtPinValidate.Location = New System.Drawing.Point(86, 86)
        Me.txtPinValidate.MaxLength = 15
        Me.txtPinValidate.Name = "txtPinValidate"
        Me.txtPinValidate.Size = New System.Drawing.Size(125, 20)
        Me.txtPinValidate.TabIndex = 7
        Me.txtPinValidate.Tag = "PINVALIDATE"
        Me.txtPinValidate.Text = "txtPinValidate"
        '
        'lblPinValidate
        '
        Me.lblPinValidate.Location = New System.Drawing.Point(6, 86)
        Me.lblPinValidate.Name = "lblPinValidate"
        Me.lblPinValidate.Size = New System.Drawing.Size(80, 23)
        Me.lblPinValidate.TabIndex = 5
        Me.lblPinValidate.Tag = "PINVALIDATE"
        Me.lblPinValidate.Text = "lblPinValidate"
        '
        'txtIDCODE
        '
        Me.txtIDCODE.Location = New System.Drawing.Point(86, 60)
        Me.txtIDCODE.MaxLength = 15
        Me.txtIDCODE.Name = "txtIDCODE"
        Me.txtIDCODE.Size = New System.Drawing.Size(125, 20)
        Me.txtIDCODE.TabIndex = 5
        Me.txtIDCODE.Tag = "IDCODE"
        Me.txtIDCODE.Text = "txtIDCODE"
        '
        'lblIDCODE
        '
        Me.lblIDCODE.Location = New System.Drawing.Point(6, 60)
        Me.lblIDCODE.Name = "lblIDCODE"
        Me.lblIDCODE.Size = New System.Drawing.Size(80, 23)
        Me.lblIDCODE.TabIndex = 5
        Me.lblIDCODE.Tag = "IDCODE"
        Me.lblIDCODE.Text = "lblIDCODE"
        '
        'btnPinValidate
        '
        Me.btnPinValidate.Location = New System.Drawing.Point(217, 83)
        Me.btnPinValidate.Name = "btnPinValidate"
        Me.btnPinValidate.Size = New System.Drawing.Size(75, 24)
        Me.btnPinValidate.TabIndex = 8
        Me.btnPinValidate.Tag = "btnPINVALIDATE"
        Me.btnPinValidate.Text = "btnPinValidate"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(217, 8)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 46)
        Me.btnSearch.TabIndex = 6
        Me.btnSearch.Tag = "SEARCH"
        Me.btnSearch.Text = "btnSearch"
        '
        'txtACCTNO
        '
        Me.txtACCTNO.Location = New System.Drawing.Point(86, 34)
        Me.txtACCTNO.MaxLength = 10
        Me.txtACCTNO.Name = "txtACCTNO"
        Me.txtACCTNO.Size = New System.Drawing.Size(125, 20)
        Me.txtACCTNO.TabIndex = 4
        Me.txtACCTNO.Tag = "ACCTNO"
        Me.txtACCTNO.Text = "txtACCTNO"
        '
        'lblACCTNO
        '
        Me.lblACCTNO.Location = New System.Drawing.Point(6, 34)
        Me.lblACCTNO.Name = "lblACCTNO"
        Me.lblACCTNO.Size = New System.Drawing.Size(80, 23)
        Me.lblACCTNO.TabIndex = 3
        Me.lblACCTNO.Tag = "ACCTNO"
        Me.lblACCTNO.Text = "lblACCTNO"
        '
        'pnACCTNO
        '
        Me.pnACCTNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnACCTNO.Location = New System.Drawing.Point(8, 210)
        Me.pnACCTNO.Name = "pnACCTNO"
        Me.pnACCTNO.Size = New System.Drawing.Size(424, 245)
        Me.pnACCTNO.TabIndex = 2
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(756, 470)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(104, 66)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "btnCancel"
        '
        'tmrOrder
        '
        '
        'grbACCTNOINFO
        '
        Me.grbACCTNOINFO.Controls.Add(Me.lblMOBILEV)
        Me.grbACCTNOINFO.Controls.Add(Me.lblMOBILESMSV)
        Me.grbACCTNOINFO.Controls.Add(Me.lblMOBILE1)
        Me.grbACCTNOINFO.Controls.Add(Me.lblMOBILESMS)
        Me.grbACCTNOINFO.Controls.Add(Me.lblBankAVLBALV)
        Me.grbACCTNOINFO.Controls.Add(Me.lblBankBalanceV)
        Me.grbACCTNOINFO.Controls.Add(Me.lblBankAVLBAL)
        Me.grbACCTNOINFO.Controls.Add(Me.lblBankBalance)
        Me.grbACCTNOINFO.Controls.Add(Me.pnSE)
        Me.grbACCTNOINFO.Controls.Add(Me.pnCI)
        Me.grbACCTNOINFO.Controls.Add(Me.lblSE)
        Me.grbACCTNOINFO.Controls.Add(Me.lblCI)
        Me.grbACCTNOINFO.Controls.Add(Me.lblCODE)
        Me.grbACCTNOINFO.Controls.Add(Me.lblPIN)
        Me.grbACCTNOINFO.Controls.Add(Me.lblName)
        Me.grbACCTNOINFO.Location = New System.Drawing.Point(438, 56)
        Me.grbACCTNOINFO.Name = "grbACCTNOINFO"
        Me.grbACCTNOINFO.Size = New System.Drawing.Size(422, 399)
        Me.grbACCTNOINFO.TabIndex = 5
        Me.grbACCTNOINFO.TabStop = False
        Me.grbACCTNOINFO.Text = "Thông tin tiểu khoản"
        '
        'lblMOBILEV
        '
        Me.lblMOBILEV.AutoSize = True
        Me.lblMOBILEV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMOBILEV.Location = New System.Drawing.Point(332, 88)
        Me.lblMOBILEV.Name = "lblMOBILEV"
        Me.lblMOBILEV.Size = New System.Drawing.Size(74, 13)
        Me.lblMOBILEV.TabIndex = 15
        Me.lblMOBILEV.Tag = "lblMOBILEV"
        Me.lblMOBILEV.Text = "lblMOBILEV"
        '
        'lblMOBILESMSV
        '
        Me.lblMOBILESMSV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMOBILESMSV.Location = New System.Drawing.Point(299, 69)
        Me.lblMOBILESMSV.Name = "lblMOBILESMSV"
        Me.lblMOBILESMSV.Size = New System.Drawing.Size(100, 13)
        Me.lblMOBILESMSV.TabIndex = 14
        Me.lblMOBILESMSV.Tag = "lblMOBILESMSV"
        Me.lblMOBILESMSV.Text = "lblMOBILESMSV"
        '
        'lblMOBILE1
        '
        Me.lblMOBILE1.AutoSize = True
        Me.lblMOBILE1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMOBILE1.Location = New System.Drawing.Point(227, 88)
        Me.lblMOBILE1.Name = "lblMOBILE1"
        Me.lblMOBILE1.Size = New System.Drawing.Size(105, 13)
        Me.lblMOBILE1.TabIndex = 13
        Me.lblMOBILE1.Tag = "MOBILE"
        Me.lblMOBILE1.Text = "Số Mobile2/Cố định:"
        '
        'lblMOBILESMS
        '
        Me.lblMOBILESMS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMOBILESMS.Location = New System.Drawing.Point(227, 69)
        Me.lblMOBILESMS.Name = "lblMOBILESMS"
        Me.lblMOBILESMS.Size = New System.Drawing.Size(66, 13)
        Me.lblMOBILESMS.TabIndex = 12
        Me.lblMOBILESMS.Tag = "MOBILESMS"
        Me.lblMOBILESMS.Text = "Số Mobile 1:"
        '
        'lblBankAVLBALV
        '
        Me.lblBankAVLBALV.AutoSize = True
        Me.lblBankAVLBALV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBankAVLBALV.Location = New System.Drawing.Point(125, 88)
        Me.lblBankAVLBALV.Name = "lblBankAVLBALV"
        Me.lblBankAVLBALV.Size = New System.Drawing.Size(85, 13)
        Me.lblBankAVLBALV.TabIndex = 11
        Me.lblBankAVLBALV.Tag = "lblBankAVLBALV"
        Me.lblBankAVLBALV.Text = "1000,000,000"
        '
        'lblBankBalanceV
        '
        Me.lblBankBalanceV.AutoSize = True
        Me.lblBankBalanceV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBankBalanceV.Location = New System.Drawing.Point(76, 68)
        Me.lblBankBalanceV.Name = "lblBankBalanceV"
        Me.lblBankBalanceV.Size = New System.Drawing.Size(85, 13)
        Me.lblBankBalanceV.TabIndex = 10
        Me.lblBankBalanceV.Tag = "lblBankBalanceV"
        Me.lblBankBalanceV.Text = "1000,000,000"
        '
        'lblBankAVLBAL
        '
        Me.lblBankAVLBAL.AutoSize = True
        Me.lblBankAVLBAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBankAVLBAL.Location = New System.Drawing.Point(7, 88)
        Me.lblBankAVLBAL.Name = "lblBankAVLBAL"
        Me.lblBankAVLBAL.Size = New System.Drawing.Size(112, 13)
        Me.lblBankAVLBAL.TabIndex = 9
        Me.lblBankAVLBAL.Tag = "lblBankAVLBAL"
        Me.lblBankAVLBAL.Text = "Tiền khả dụng tại NH:"
        '
        'lblBankBalance
        '
        Me.lblBankBalance.AutoSize = True
        Me.lblBankBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBankBalance.Location = New System.Drawing.Point(7, 68)
        Me.lblBankBalance.Name = "lblBankBalance"
        Me.lblBankBalance.Size = New System.Drawing.Size(64, 13)
        Me.lblBankBalance.TabIndex = 8
        Me.lblBankBalance.Tag = "lblBankBalance"
        Me.lblBankBalance.Text = "Tiền tại NH:"
        '
        'pnSE
        '
        Me.pnSE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnSE.Location = New System.Drawing.Point(7, 242)
        Me.pnSE.Name = "pnSE"
        Me.pnSE.Size = New System.Drawing.Size(409, 141)
        Me.pnSE.TabIndex = 7
        '
        'pnCI
        '
        Me.pnCI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnCI.Location = New System.Drawing.Point(7, 127)
        Me.pnCI.Name = "pnCI"
        Me.pnCI.Size = New System.Drawing.Size(409, 77)
        Me.pnCI.TabIndex = 6
        '
        'lblSE
        '
        Me.lblSE.AutoSize = True
        Me.lblSE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSE.Location = New System.Drawing.Point(7, 214)
        Me.lblSE.Name = "lblSE"
        Me.lblSE.Size = New System.Drawing.Size(120, 13)
        Me.lblSE.TabIndex = 5
        Me.lblSE.Text = "Thông tin danh mục"
        '
        'lblCI
        '
        Me.lblCI.AutoSize = True
        Me.lblCI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCI.Location = New System.Drawing.Point(9, 106)
        Me.lblCI.Name = "lblCI"
        Me.lblCI.Size = New System.Drawing.Size(115, 13)
        Me.lblCI.TabIndex = 4
        Me.lblCI.Text = "Tiền mặt - sức mua"
        '
        'lblCODE
        '
        Me.lblCODE.AutoSize = True
        Me.lblCODE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCODE.Location = New System.Drawing.Point(7, 47)
        Me.lblCODE.Name = "lblCODE"
        Me.lblCODE.Size = New System.Drawing.Size(214, 13)
        Me.lblCODE.TabIndex = 2
        Me.lblCODE.Tag = "lblCODE"
        Me.lblCODE.Text = "CMT: 012345678 - 10/02/2000 - HN"
        '
        'lblPIN
        '
        Me.lblPIN.AutoSize = True
        Me.lblPIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPIN.Location = New System.Drawing.Point(290, 23)
        Me.lblPIN.Name = "lblPIN"
        Me.lblPIN.Size = New System.Drawing.Size(78, 13)
        Me.lblPIN.TabIndex = 1
        Me.lblPIN.Tag = "lblPIN"
        Me.lblPIN.Text = "PIN: 123456"
        Me.lblPIN.Visible = False
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(6, 23)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(118, 13)
        Me.lblName.TabIndex = 0
        Me.lblName.Tag = "lblName"
        Me.lblName.Text = "Tên: Nguyễn Văn A"
        '
        'btnCIIncrease
        '
        Me.btnCIIncrease.Location = New System.Drawing.Point(9, 470)
        Me.btnCIIncrease.Name = "btnCIIncrease"
        Me.btnCIIncrease.Size = New System.Drawing.Size(134, 24)
        Me.btnCIIncrease.TabIndex = 7
        Me.btnCIIncrease.Tag = "btnCIIncrease"
        Me.btnCIIncrease.Text = "btnCIIncrease"
        '
        'btnRightOff
        '
        Me.btnRightOff.Location = New System.Drawing.Point(615, 470)
        Me.btnRightOff.Name = "btnRightOff"
        Me.btnRightOff.Size = New System.Drawing.Size(134, 24)
        Me.btnRightOff.TabIndex = 8
        Me.btnRightOff.Tag = "btnRightOff"
        Me.btnRightOff.Text = "btnRightOff"
        '
        'btnChangePIN
        '
        Me.btnChangePIN.Location = New System.Drawing.Point(615, 512)
        Me.btnChangePIN.Name = "btnChangePIN"
        Me.btnChangePIN.Size = New System.Drawing.Size(134, 24)
        Me.btnChangePIN.TabIndex = 13
        Me.btnChangePIN.Tag = "btnChangePIN"
        Me.btnChangePIN.Text = "btnChangePIN"
        '
        'lblACCLIST
        '
        Me.lblACCLIST.AutoSize = True
        Me.lblACCLIST.Location = New System.Drawing.Point(6, 194)
        Me.lblACCLIST.Name = "lblACCLIST"
        Me.lblACCLIST.Size = New System.Drawing.Size(158, 13)
        Me.lblACCLIST.TabIndex = 14
        Me.lblACCLIST.Tag = "lblACCLIST"
        Me.lblACCLIST.Text = "Danh sách tiểu khoản giao dịch"
        '
        'btnCIDecrease
        '
        Me.btnCIDecrease.Location = New System.Drawing.Point(160, 470)
        Me.btnCIDecrease.Name = "btnCIDecrease"
        Me.btnCIDecrease.Size = New System.Drawing.Size(134, 24)
        Me.btnCIDecrease.TabIndex = 7
        Me.btnCIDecrease.Tag = "btnCIDecrease"
        Me.btnCIDecrease.Text = "btnCIDecrease"
        '
        'btnCIBlocked
        '
        Me.btnCIBlocked.Location = New System.Drawing.Point(311, 470)
        Me.btnCIBlocked.Name = "btnCIBlocked"
        Me.btnCIBlocked.Size = New System.Drawing.Size(134, 24)
        Me.btnCIBlocked.TabIndex = 7
        Me.btnCIBlocked.Tag = "btnCIBlocked"
        Me.btnCIBlocked.Text = "btnCIBlocked"
        '
        'btnCIUnBlocked
        '
        Me.btnCIUnBlocked.Location = New System.Drawing.Point(463, 470)
        Me.btnCIUnBlocked.Name = "btnCIUnBlocked"
        Me.btnCIUnBlocked.Size = New System.Drawing.Size(134, 24)
        Me.btnCIUnBlocked.TabIndex = 7
        Me.btnCIUnBlocked.Tag = "btnCIUnBlocked"
        Me.btnCIUnBlocked.Text = "btnCIUnBlocked"
        '
        'btnSEIncrease
        '
        Me.btnSEIncrease.Location = New System.Drawing.Point(9, 512)
        Me.btnSEIncrease.Name = "btnSEIncrease"
        Me.btnSEIncrease.Size = New System.Drawing.Size(134, 24)
        Me.btnSEIncrease.TabIndex = 7
        Me.btnSEIncrease.Tag = "btnSEIncrease"
        Me.btnSEIncrease.Text = "btnSEIncrease"
        '
        'btnSEDecrease
        '
        Me.btnSEDecrease.Location = New System.Drawing.Point(160, 512)
        Me.btnSEDecrease.Name = "btnSEDecrease"
        Me.btnSEDecrease.Size = New System.Drawing.Size(134, 24)
        Me.btnSEDecrease.TabIndex = 7
        Me.btnSEDecrease.Tag = "btnSEDecrease"
        Me.btnSEDecrease.Text = "btnSEDecrease"
        '
        'btnSEBlocked
        '
        Me.btnSEBlocked.Location = New System.Drawing.Point(311, 512)
        Me.btnSEBlocked.Name = "btnSEBlocked"
        Me.btnSEBlocked.Size = New System.Drawing.Size(134, 24)
        Me.btnSEBlocked.TabIndex = 7
        Me.btnSEBlocked.Tag = "btnSEBlocked"
        Me.btnSEBlocked.Text = "btnSEBlocked"
        '
        'btnSEUnBlocked
        '
        Me.btnSEUnBlocked.Location = New System.Drawing.Point(463, 512)
        Me.btnSEUnBlocked.Name = "btnSEUnBlocked"
        Me.btnSEUnBlocked.Size = New System.Drawing.Size(134, 24)
        Me.btnSEUnBlocked.TabIndex = 7
        Me.btnSEUnBlocked.Tag = "btnSEUnBlocked"
        Me.btnSEUnBlocked.Text = "btnSEUnBlocked"
        '
        'frmTeleInq
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(872, 548)
        Me.Controls.Add(Me.lblACCLIST)
        Me.Controls.Add(Me.btnChangePIN)
        Me.Controls.Add(Me.btnRightOff)
        Me.Controls.Add(Me.btnSEUnBlocked)
        Me.Controls.Add(Me.btnSEBlocked)
        Me.Controls.Add(Me.btnCIUnBlocked)
        Me.Controls.Add(Me.btnSEDecrease)
        Me.Controls.Add(Me.btnCIBlocked)
        Me.Controls.Add(Me.btnSEIncrease)
        Me.Controls.Add(Me.btnCIDecrease)
        Me.Controls.Add(Me.btnCIIncrease)
        Me.Controls.Add(Me.grbACCTNOINFO)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.pnACCTNO)
        Me.Controls.Add(Me.pnInfo)
        Me.Controls.Add(Me.pnlTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTeleInq"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "frmTeleInq"
        Me.Text = "Giao dịch qua điện thoại"
        Me.pnlTitle.ResumeLayout(False)
        Me.pnInfo.ResumeLayout(False)
        Me.pnInfo.PerformLayout()
        Me.grbACCTNOINFO.ResumeLayout(False)
        Me.grbACCTNOINFO.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region " Declare constant and variables "
    Const c_ResourceManager = "_DIRECT.frmTeleInq-"
    Public AccountInqGrid, CIGrid, SEGrid As GridEx

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

    Private mv_strOrderStatus As String
#End Region

#Region " Properties "
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

#Region " Other Methods "
    Public Sub ShowNewCall(ByVal pv_PhoneNumber As String)
        If pv_PhoneNumber.Length > 7 Then
            If MsgBox(mv_ResourceManager.GetString("HAVENEWCALL"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
                Me.PhoneNumber = pv_PhoneNumber
                Me.txtMOBILE.Text = PhoneNumber
                Me.txtACCTNO.Text = ""
                Me.txtIDCODE.Text = ""
                GetAccount()
                Me.btnChangePIN.Enabled = False
                Me.btnCIIncrease.Enabled = False
                'Me.btnSETransfer.Enabled = False
                'Me.btnOneFirm.Enabled = False
                'Me.btnTwofirm.Enabled = False
                'Me.btnPlaceOrder.Enabled = False
                'Me.btnAdvance.Enabled = False
                Me.btnRightOff.Enabled = False
                If Me.AccountInqGrid.DataRows.Count > 0 Then
                    Me.txtPinValidate.Enabled = True
                    Me.btnPinValidate.Enabled = True
                Else
                    Me.txtPinValidate.Enabled = False
                    Me.btnPinValidate.Enabled = False
                End If
                If AccountInqGrid.DataRows.Count = 0 Then
                    MessageBox.Show(mv_ResourceManager.GetString("INFONOTFOUND"))
                End If
            End If
        End If
    End Sub
    Public Sub GetAccount(Optional ByVal pv_strCustid As String = "")
        Dim v_strCmdInquiry, v_strFilter As String
        Dim v_strACCTNO, v_strMOBILE, v_strIDCODE As String
        Dim v_strRightCondition As String

        v_strMOBILE = Me.txtMOBILE.Text.Trim.ToUpper()
        v_strACCTNO = Me.txtACCTNO.Text.Trim.ToUpper()
        v_strIDCODE = Me.txtIDCODE.Text.Trim.ToUpper()
        If v_strMOBILE.Length + v_strACCTNO.Length + v_strIDCODE.Length > 0 Then
            'Select Top 10
            v_strCmdInquiry = " select * from (select cf.custodycd, cf.fullname, af.acctno, " & ControlChars.CrLf & _
                                " cf.idcode, cf.idplace, cf.iddate, cf.PIN password,AF.ACCTNO || ': ' || AFT.TYPENAME ACCNAME, " & ControlChars.CrLf & _
                                " (case when af.corebank = 'Y' then af.corebank else af.alternateacct end) allowcorebank, " & ControlChars.CrLf & _
                                " cf.mobilesms, cf.mobile " & ControlChars.CrLf & _
                                " from cfmast cf, afmast af, aftype aft " & ControlChars.CrLf & _
                                " where cf.custid = af.custid and af.actype = aft.actype and af.status <> 'C' " & ControlChars.CrLf & _
                                " and (nvl(cf.mobilesms,'XXXYYYZZZ') like '%" & v_strMOBILE & "%' or nvl(cf.mobile,'XXXYYYZZZ') like '%" & v_strMOBILE & "%')" & ControlChars.CrLf & _
                                " and cf.custodycd like '%" & v_strACCTNO & "%'" & ControlChars.CrLf & _
                                " and cf.idcode like '%" & v_strIDCODE & "%' and cf.tradetelephone <> 'N') where rownum <=10"

            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strCmdInquiry)
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            v_ws.Message(v_strObjMsg)
            FillDataGrid(AccountInqGrid, v_strObjMsg, "")
            AccountInqGrid.Focus()
        End If
    End Sub
    Private Sub InitializeGrid()
        'Khởi tạo Grid Account
        AccountInqGrid = New GridEx
        Dim v_cmrContactsHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrContactsHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrContactsHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        AccountInqGrid.FixedHeaderRows.Add(v_cmrContactsHeader)

        AccountInqGrid.Columns.Add(New Xceed.Grid.Column("CUSTODYCD", GetType(System.String)))
        AccountInqGrid.Columns.Add(New Xceed.Grid.Column("ACCTNO", GetType(System.String)))
        AccountInqGrid.Columns.Add(New Xceed.Grid.Column("ACCNAME", GetType(System.String)))
        AccountInqGrid.Columns.Add(New Xceed.Grid.Column("FULLNAME", GetType(System.String)))
        AccountInqGrid.Columns.Add(New Xceed.Grid.Column("IDCODE", GetType(System.String)))
        AccountInqGrid.Columns.Add(New Xceed.Grid.Column("IDDATE", GetType(System.String)))
        AccountInqGrid.Columns.Add(New Xceed.Grid.Column("IDPLACE", GetType(System.String)))
        AccountInqGrid.Columns.Add(New Xceed.Grid.Column("PASSWORD", GetType(System.String)))
        AccountInqGrid.Columns.Add(New Xceed.Grid.Column("ALLOWCOREBANK", GetType(System.String)))
        AccountInqGrid.Columns.Add(New Xceed.Grid.Column("MOBILESMS", GetType(System.String)))
        AccountInqGrid.Columns.Add(New Xceed.Grid.Column("MOBILE", GetType(System.String)))


        AccountInqGrid.Columns("CUSTODYCD").Title = mv_ResourceManager.GetString("CUSTODYCD")
        AccountInqGrid.Columns("ACCTNO").Title = mv_ResourceManager.GetString("ACCTNO")
        AccountInqGrid.Columns("ACCNAME").Title = mv_ResourceManager.GetString("ACCNAME")
        AccountInqGrid.Columns("FULLNAME").Title = mv_ResourceManager.GetString("FULLNAME")
        AccountInqGrid.Columns("IDCODE").Title = mv_ResourceManager.GetString("IDCODE")
        AccountInqGrid.Columns("IDDATE").Title = mv_ResourceManager.GetString("IDDATE")
        AccountInqGrid.Columns("IDPLACE").Title = mv_ResourceManager.GetString("IDPLACE")
        AccountInqGrid.Columns("PASSWORD").Title = mv_ResourceManager.GetString("PASSWORD")
        AccountInqGrid.Columns("ALLOWCOREBANK").Title = "ALLOWCOREBANK"
        AccountInqGrid.Columns("MOBILESMS").Title = mv_ResourceManager.GetString("lblMOBILESMS")
        AccountInqGrid.Columns("MOBILE").Title = mv_ResourceManager.GetString("lblMOBILE1")

        AccountInqGrid.Columns("CUSTODYCD").Width = 65
        AccountInqGrid.Columns("CUSTODYCD").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        AccountInqGrid.Columns("ACCTNO").Width = 0
        AccountInqGrid.Columns("ACCTNO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        AccountInqGrid.Columns("ACCNAME").Width = 240
        AccountInqGrid.Columns("ACCNAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        AccountInqGrid.Columns("FULLNAME").Width = 130
        AccountInqGrid.Columns("FULLNAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        AccountInqGrid.Columns("IDCODE").Width = 0
        AccountInqGrid.Columns("IDCODE").Visible = False
        AccountInqGrid.Columns("IDCODE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        AccountInqGrid.Columns("IDDATE").Width = 0
        AccountInqGrid.Columns("IDDATE").Visible = False
        AccountInqGrid.Columns("IDDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        AccountInqGrid.Columns("IDPLACE").Width = 0
        AccountInqGrid.Columns("IDPLACE").Visible = False
        AccountInqGrid.Columns("IDPLACE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left

        AccountInqGrid.Columns("PASSWORD").Width = 0
        AccountInqGrid.Columns("PASSWORD").Visible = False
        AccountInqGrid.Columns("PASSWORD").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        AccountInqGrid.Columns("ACCTNO").Visible = False
        AccountInqGrid.Columns("ALLOWCOREBANK").Width = 0
        AccountInqGrid.Columns("ALLOWCOREBANK").Visible = False
        AccountInqGrid.Columns("MOBILESMS").Width = 0
        AccountInqGrid.Columns("MOBILESMS").Visible = False
        AccountInqGrid.Columns("MOBILE").Width = 0
        AccountInqGrid.Columns("MOBILE").Visible = False

        Me.pnACCTNO.Controls.Clear()
        Me.pnACCTNO.Controls.Add(AccountInqGrid)
        AccountInqGrid.Dock = Windows.Forms.DockStyle.Fill
        If Me.AccountInqGrid.DataRowTemplate.Cells.Count >= 0 Then
            For i As Integer = 0 To Me.AccountInqGrid.DataRowTemplate.Cells.Count - 1
                AddHandler AccountInqGrid.DataRowTemplate.Cells(i).DoubleClick, AddressOf OnGetAccountInfo
                AddHandler AccountInqGrid.DataRowTemplate.Cells(i).Click, AddressOf OnGetAccountInfo 'OnGetAccountInfo
            Next
        End If


        'Khởi tạo Grid CI
        CIGrid = New GridEx
        Dim v_cmrCIHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrCIHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrCIHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        CIGrid.FixedHeaderRows.Add(v_cmrCIHeader)

        CIGrid.Columns.Add(New Xceed.Grid.Column("BALANCE", GetType(System.Decimal)))
        CIGrid.Columns.Add(New Xceed.Grid.Column("AVLADVANCE", GetType(System.Decimal)))
        CIGrid.Columns.Add(New Xceed.Grid.Column("CARECEIVING", GetType(System.Decimal)))
        CIGrid.Columns.Add(New Xceed.Grid.Column("PP", GetType(System.Decimal)))
        CIGrid.Columns.Add(New Xceed.Grid.Column("OUTSTANDING", GetType(System.Decimal)))


        CIGrid.Columns("BALANCE").Title = mv_ResourceManager.GetString("BALANCE")
        CIGrid.Columns("AVLADVANCE").Title = mv_ResourceManager.GetString("AVLADVANCE")
        CIGrid.Columns("CARECEIVING").Title = mv_ResourceManager.GetString("CARECEIVING")
        CIGrid.Columns("PP").Title = mv_ResourceManager.GetString("PP")
        CIGrid.Columns("OUTSTANDING").Title = mv_ResourceManager.GetString("OUTSTANDING")

        CIGrid.Columns("BALANCE").Width = 150
        CIGrid.Columns("BALANCE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        CIGrid.Columns("AVLADVANCE").Width = 150
        CIGrid.Columns("AVLADVANCE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        CIGrid.Columns("CARECEIVING").Width = 150
        CIGrid.Columns("CARECEIVING").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        CIGrid.Columns("PP").Width = 150
        CIGrid.Columns("PP").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        CIGrid.Columns("OUTSTANDING").Width = 150
        CIGrid.Columns("OUTSTANDING").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right

        CIGrid.Columns("BALANCE").FormatSpecifier = "#,##0"
        CIGrid.Columns("AVLADVANCE").FormatSpecifier = "#,##0"
        CIGrid.Columns("CARECEIVING").FormatSpecifier = "#,##0"
        CIGrid.Columns("PP").FormatSpecifier = "#,##0"
        CIGrid.Columns("OUTSTANDING").FormatSpecifier = "#,##0"

        Me.pnCI.Controls.Clear()
        Me.pnCI.Controls.Add(CIGrid)
        CIGrid.Dock = Windows.Forms.DockStyle.Fill


        'Khởi tạo Grid SE
        SEGrid = New GridEx
        Dim v_cmrSEHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrSEHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrSEHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        SEGrid.FixedHeaderRows.Add(v_cmrSEHeader)

        SEGrid.Columns.Add(New Xceed.Grid.Column("SYMBOL", GetType(System.String)))
        SEGrid.Columns.Add(New Xceed.Grid.Column("TRADE", GetType(System.Decimal)))
        SEGrid.Columns.Add(New Xceed.Grid.Column("RECEIVING", GetType(System.Decimal)))
        SEGrid.Columns.Add(New Xceed.Grid.Column("MORTAGE", GetType(System.Decimal)))


        SEGrid.Columns("SYMBOL").Title = mv_ResourceManager.GetString("SYMBOL")
        SEGrid.Columns("TRADE").Title = mv_ResourceManager.GetString("TRADE")
        SEGrid.Columns("RECEIVING").Title = mv_ResourceManager.GetString("RECEIVING")
        SEGrid.Columns("MORTAGE").Title = mv_ResourceManager.GetString("MORTAGE")

        SEGrid.Columns("SYMBOL").Width = 100
        SEGrid.Columns("SYMBOL").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        SEGrid.Columns("TRADE").Width = 100
        SEGrid.Columns("TRADE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        SEGrid.Columns("RECEIVING").Width = 90
        SEGrid.Columns("RECEIVING").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        SEGrid.Columns("MORTAGE").Width = 90
        SEGrid.Columns("MORTAGE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right

        SEGrid.Columns("TRADE").FormatSpecifier = "#,##0"
        SEGrid.Columns("RECEIVING").FormatSpecifier = "#,##0"
        SEGrid.Columns("MORTAGE").FormatSpecifier = "#,##0"

        Me.pnSE.Controls.Clear()
        Me.pnSE.Controls.Add(SEGrid)
        SEGrid.Dock = Windows.Forms.DockStyle.Fill

    End Sub
    Private Sub OnSelectAccountInfo()
        Dim v_strPINIDCODE As String
        Dim v_strinPin As String
        v_strinPin = txtPinValidate.Text
        v_strPINIDCODE = Trim(CType(AccountInqGrid.CurrentRow, Xceed.Grid.DataRow).Cells("PASSWORD").Value)
        mv_strCUSTODYCD = Trim(CType(AccountInqGrid.CurrentRow, Xceed.Grid.DataRow).Cells("CUSTODYCD").Value)
        Using md5Hash As MD5 = MD5.Create()
            v_strinPin = GetMd5Hash(md5Hash, txtPinValidate.Text)
        End Using
        If v_strPINIDCODE <> v_strinPin Then
            Me.btnChangePIN.Enabled = False
            Me.btnCIIncrease.Enabled = False
            'Me.btnSETransfer.Enabled = False
            'Me.btnOneFirm.Enabled = False
            'Me.btnTwofirm.Enabled = False
            'Me.btnPlaceOrder.Enabled = False
            'Me.btnAdvance.Enabled = False
            Me.btnRightOff.Enabled = False
            Me.txtPinValidate.Enabled = True
            Me.btnPinValidate.Enabled = True
        End If
    End Sub

    Private Sub OnGetAccountInfo()
        Dim v_StrIDCODE, v_strMOBILESMS, v_strMOBILE As String
        Dim v_strCmdInquiry As String
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        If Me.AccountInqGrid.DataRows.Count > 0 Then
            mv_strACCTNO = Trim(CType(AccountInqGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ACCTNO").Value)
            mv_strCUSTODYCD = Trim(CType(AccountInqGrid.CurrentRow, Xceed.Grid.DataRow).Cells("CUSTODYCD").Value)
            mv_strCOREBANK = Trim(CType(AccountInqGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ALLOWCOREBANK").Value)
            'Fill thong tin tieu khoan
            Me.grbACCTNOINFO.Text = mv_ResourceManager.GetString("grbACCTNOINFO") & Trim(CType(AccountInqGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ACCNAME").Value)
            Me.lblName.Text = mv_ResourceManager.GetString("lblName") & Trim(CType(AccountInqGrid.CurrentRow, Xceed.Grid.DataRow).Cells("FULLNAME").Value)
            Me.lblPIN.Text = mv_ResourceManager.GetString("lblPIN") & Trim(CType(AccountInqGrid.CurrentRow, Xceed.Grid.DataRow).Cells("PASSWORD").Value)
            v_StrIDCODE = mv_ResourceManager.GetString("lblCODE")
            v_StrIDCODE = Strings.Replace(v_StrIDCODE, "IDCODE", Trim(CType(AccountInqGrid.CurrentRow, Xceed.Grid.DataRow).Cells("IDCODE").Value))
            v_StrIDCODE = Strings.Replace(v_StrIDCODE, "IDPLACE", Trim(CType(AccountInqGrid.CurrentRow, Xceed.Grid.DataRow).Cells("IDPLACE").Value))
            v_StrIDCODE = Strings.Replace(v_StrIDCODE, "IDDATE", Trim(CType(AccountInqGrid.CurrentRow, Xceed.Grid.DataRow).Cells("IDDATE").Value))
            Me.lblMOBILESMSV.Text = Trim(CType(AccountInqGrid.CurrentRow, Xceed.Grid.DataRow).Cells("MOBILESMS").Value)
            Me.lblMOBILEV.Text = Trim(CType(AccountInqGrid.CurrentRow, Xceed.Grid.DataRow).Cells("MOBILE").Value)
            Me.lblCODE.Text = v_StrIDCODE
            '
            'Lay thong tin so du co ban cua ngan hang
            If mv_strCOREBANK = "Y" Then
                Dim v_arr() As String = GetBankBalance(mv_strACCTNO).Split("|")
                Me.lblBankBalanceV.Text = Format(Math.Round(CDbl(v_arr(1))), gc_FORMAT_NUMBER_0)
                Me.lblBankAVLBALV.Text = Format(Math.Round(CDbl(Math.Max(v_arr(0) - v_arr(2), 0))), gc_FORMAT_NUMBER_0)
            Else
                Me.lblBankBalanceV.Text = "0"
                Me.lblBankAVLBALV.Text = "0"
            End If

            'Fill thong tin chung khoan
            v_strCmdInquiry = " select symbol,trade,securities_receiving_t0+securities_receiving_t1+securities_receiving_t2+securities_receiving_t3+securities_receiving_tn receiving,mortage from buf_se_account " & ControlChars.CrLf & _
                              " where afacctno = '" & mv_strACCTNO & "' and trade+securities_receiving_t0+securities_receiving_t1+securities_receiving_t2+securities_receiving_t3+securities_receiving_tn+mortage>0"

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strCmdInquiry)
            v_ws.Message(v_strObjMsg)
            FillDataGrid(SEGrid, v_strObjMsg, "")
            SEGrid.Focus()


            'Fill thong tin Tien, suc mua
            v_strCmdInquiry = "select buf.balance, buf.avladvance,buf.pp, buf.MRODAMT + buf.T0ODAMT outstanding, nvl(ca.amt,0) careceiving from buf_ci_account buf, " & ControlChars.CrLf & _
                                "    (SELECT CA.AFACCTNO, SUM(NVL(CA.AMT,0)) AMT  " & ControlChars.CrLf & _
                                "        FROM CAMAST CAM, CASCHD CA  " & ControlChars.CrLf & _
                                "        WHERE CA.CAMASTID = CAM.CAMASTID AND CAM.CATYPE IN ('010','015','016')  " & ControlChars.CrLf & _
                                "            AND CA.STATUS = 'S'  " & ControlChars.CrLf & _
                                "            AND CA.AFACCTNO LIKE '" & mv_strACCTNO & "'  " & ControlChars.CrLf & _
                                "        GROUP BY CA.AFACCTNO  " & ControlChars.CrLf & _
                                "    ) CA  " & ControlChars.CrLf & _
                                "where buf.afacctno = ca.AFACCTNO(+) and buf.afacctno = '" & mv_strACCTNO & "'"

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strCmdInquiry)
            v_ws.Message(v_strObjMsg)
            FillDataGrid(CIGrid, v_strObjMsg, "")
            Dim v_strPINIDCODE As String
            Dim v_strinPin As String
            v_strinPin = txtPinValidate.Text
            v_strPINIDCODE = Trim(CType(AccountInqGrid.CurrentRow, Xceed.Grid.DataRow).Cells("PASSWORD").Value)
            mv_strCUSTODYCD = Trim(CType(AccountInqGrid.CurrentRow, Xceed.Grid.DataRow).Cells("CUSTODYCD").Value)
            Using md5Hash As MD5 = MD5.Create()
                v_strinPin = GetMd5Hash(md5Hash, txtPinValidate.Text)
            End Using
            If v_strPINIDCODE <> v_strinPin Then
                Me.btnChangePIN.Enabled = False
                Me.btnCIIncrease.Enabled = False
                Me.btnCIDecrease.Enabled = False
                Me.btnCIBlocked.Enabled = False
                Me.btnCIUnBlocked.Enabled = False
                Me.btnSEIncrease.Enabled = False
                Me.btnSEDecrease.Enabled = False
                Me.btnSEBlocked.Enabled = False
                Me.btnSEUnBlocked.Enabled = False
                'Me.btnSETransfer.Enabled = False
                'Me.btnOneFirm.Enabled = False
                'Me.btnTwofirm.Enabled = False
                'Me.btnPlaceOrder.Enabled = False
                'Me.btnAdvance.Enabled = False
                Me.btnRightOff.Enabled = False
                Me.txtPinValidate.Enabled = True
                Me.btnPinValidate.Enabled = True
            End If
        End If
    End Sub

    Private Sub RefreshAccountInfo()
        Dim v_StrIDCODE As String
        Dim v_strCmdInquiry As String
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        If mv_strACCTNO.Length = 10 Then
            'Fill thong tin chung khoan
            v_strCmdInquiry = " select symbol,trade,securities_receiving_t0+securities_receiving_t1+securities_receiving_t2+securities_receiving_t3+securities_receiving_tn receiving,mortage from buf_se_account " & ControlChars.CrLf & _
                              " where afacctno = '" & mv_strACCTNO & "' and trade+securities_receiving_t0+securities_receiving_t1+securities_receiving_t2+securities_receiving_t3+securities_receiving_tn+mortage>0"

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strCmdInquiry)
            v_ws.Message(v_strObjMsg)
            FillDataGrid(SEGrid, v_strObjMsg, "")

            'Fill thong tin Tien, suc mua
            v_strCmdInquiry = "select buf.balance, buf.avladvance,buf.pp, buf.MRODAMT + buf.T0ODAMT outstanding, nvl(ca.amt,0) careceiving from buf_ci_account buf, " & ControlChars.CrLf & _
                                "    (SELECT CA.AFACCTNO, SUM(NVL(CA.AMT,0)) AMT  " & ControlChars.CrLf & _
                                "        FROM CAMAST CAM, CASCHD CA  " & ControlChars.CrLf & _
                                "        WHERE CA.CAMASTID = CAM.CAMASTID AND CAM.CATYPE IN ('010','015','016')  " & ControlChars.CrLf & _
                                "            AND CA.STATUS = 'S'  " & ControlChars.CrLf & _
                                "            AND CA.AFACCTNO LIKE '" & mv_strACCTNO & "'  " & ControlChars.CrLf & _
                                "        GROUP BY CA.AFACCTNO  " & ControlChars.CrLf & _
                                "    ) CA  " & ControlChars.CrLf & _
                                "where buf.afacctno = ca.AFACCTNO(+) and buf.afacctno = '" & mv_strACCTNO & "'"

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strCmdInquiry)
            v_ws.Message(v_strObjMsg)
            FillDataGrid(CIGrid, v_strObjMsg, "")
        End If
    End Sub

    'Private Sub OnPlaceOrderKey(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    Try
    '        If e.KeyCode >= Keys.D1 And e.KeyCode <= Keys.D9 Then
    '            Dim i As Integer = Strings.Right(e.KeyCode.ToString, 1)
    '            If Me.AccountInqGrid.DataRows.Count > i - 1 Then
    '                Dim v_strAcctno = Trim(AccountInqGrid.DataRows(i - 1).Cells("ACCTNO").Value)
    '                ShowOrderForm(v_strAcctno, AccountInqGrid.DataRows(i - 1))
    '            End If
    '        ElseIf e.KeyCode >= Keys.NumPad1 And e.KeyCode <= Keys.NumPad9 Then
    '            If Me.AccountInqGrid.DataRows.Count > e.KeyCode - 97 Then
    '                Dim v_strAcctno = Trim(AccountInqGrid.DataRows(e.KeyCode - 97).Cells("ACCTNO").Value)
    '                ShowOrderForm(v_strAcctno, AccountInqGrid.DataRows(e.KeyCode - 97))
    '            End If
    '        ElseIf e.KeyCode = Keys.Enter Then
    '            If Not AccountInqGrid.CurrentRow Is Nothing Then
    '                Dim v_strAcctno = Trim(CType(AccountInqGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ACCTNO").Value)
    '                ShowOrderForm(v_strAcctno, AccountInqGrid.CurrentRow)
    '            End If
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub


    Private Sub ComputeUpTime()
        Dim nTicks As Double
        Dim nDays As Integer
        Dim nHours As Integer
        Dim nMin As Integer
        Dim nSec As Integer
        Dim TimeUp As String
        nTicks = tickCount
        nTicks = nTicks / 1000
        nTicks = nTicks - (Int(nTicks / (3600 * 24)) * (3600 * 24))
        nHours = Int(nTicks / 3600)
        nTicks = nTicks - (Int(nTicks / 3600) * 3600)
        nMin = Int(nTicks / 60)
        nTicks = nTicks - (Int(nTicks / 60) * 60)
        nSec = nTicks
        lblTimer.Text = Format$(nHours, "00") & ":" & Format$(nMin, "00") & ":" & Format$(nSec, "00")
        tickCount += 1000
    End Sub

#End Region

#Region " Other method "
    Protected Overridable Function InitDialog()
        Me.tmrOrder.Interval = 1000
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)
        Me.txtACCTNO.Text = ""
        Me.txtIDCODE.Text = ""
        Me.txtMOBILE.Text = ""
        Me.txtPinValidate.Text = ""
        Me.txtMOBILE.Focus()
        tickCount = CDec(Strings.Left(mv_strCurrentTime, 2)) * 3600
        tickCount += CDec(Strings.Mid(mv_strCurrentTime, 4, 2)) * 60
        tickCount += CDec(Strings.Right(mv_strCurrentTime, 2))
        tickCount *= 1000
        tmrOrder.Start()
        tmrOrder.Enabled = True
        If PhoneNumber.Length > 7 Then
            Me.txtMOBILE.Text = PhoneNumber
            GetAccount()
            Me.btnChangePIN.Enabled = False
            Me.btnCIIncrease.Enabled = False
            Me.btnCIDecrease.Enabled = False
            Me.btnCIBlocked.Enabled = False
            Me.btnCIUnBlocked.Enabled = False
            Me.btnSEIncrease.Enabled = False
            Me.btnSEDecrease.Enabled = False
            Me.btnSEBlocked.Enabled = False
            Me.btnSEUnBlocked.Enabled = False
            
            Me.btnRightOff.Enabled = False
            If Me.AccountInqGrid.DataRows.Count > 0 Then
                Me.txtPinValidate.Enabled = True
                Me.btnPinValidate.Enabled = True
            Else
                Me.txtPinValidate.Enabled = False
                Me.btnPinValidate.Enabled = False
            End If
            If AccountInqGrid.DataRows.Count = 0 Then
                MessageBox.Show("Khong tim thay thong tin khach hang phu hop!")
            End If
        End If
        Me.btnChangePIN.Enabled = False
        Me.btnCIIncrease.Enabled = False
        Me.btnCIDecrease.Enabled = False
        Me.btnCIBlocked.Enabled = False
        Me.btnCIUnBlocked.Enabled = False
        Me.btnSEIncrease.Enabled = False
        Me.btnSEDecrease.Enabled = False
        Me.btnSEBlocked.Enabled = False
        Me.btnSEUnBlocked.Enabled = False
        Me.btnRightOff.Enabled = False
        Me.btnPinValidate.Enabled = False
        Me.txtPinValidate.Enabled = False
    End Function
    Private Sub OnClose()
        Me.Dispose()
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
#End Region

#Region " Event "
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmTeleInq_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        OnClose()
    End Sub


    Private Sub frmTeleInq_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            'Case Keys.Escape
            '    OnClose()
            'Case Keys.Enter
            '    GetAccount()
            '    Me.btnChangePIN.Enabled = False
            '    Me.btnCITransfer.Enabled = False
            '    Me.btnSETransfer.Enabled = False
            '    Me.btnOneFirm.Enabled = False
            '    Me.btnTwofirm.Enabled = False
            '    Me.btnPlaceOrder.Enabled = False
            '    Me.btnAdvance.Enabled = False
            '    Me.btnRightOff.Enabled = False
            '    If Me.AccountInqGrid.DataRows.Count > 0 Then
            '        Me.txtPinValidate.Enabled = True
            '        Me.btnPinValidate.Enabled = True
            '    Else
            '        Me.txtPinValidate.Enabled = False
            '        Me.btnPinValidate.Enabled = False
            '    End If
            'Case Keys.End
            '    Me.ActiveControl = Me.txtMOBILE

            Case Keys.F1
                'Dat lenh
                PlaceOrder()

            Case Keys.F2
                'Ung truoc
                ManualAdvance()

            Case Keys.F3
                'Chuyen tien
                CITransfer()

            Case Keys.F4
                'DKQM
                RightOffRegiter()

            Case Keys.F5
                'Chuyen CK
                SETransfer("", "")

            Case Keys.F6
                'TT 1Firm
                OneFirmOrder()

            Case Keys.F7
                'TT 2Firm
                TwoFirmOrder()

            Case Keys.F8
                'Doi PIN
                ChangePIN()


        End Select
    End Sub
#End Region

    Private Sub tmrOrder_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrOrder.Tick
        ComputeUpTime()
    End Sub

    Private Sub frmTeleInq_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitializeGrid()
        InitDialog()
        'Add any initialization after the InitializeComponent() call
        mv_xmlDocumentInquiryData = New System.Xml.XmlDocument
        Me.ActiveControl = Me.txtACCTNO
        mv_strACCTNO = Nothing
        mv_strCUSTODYCD = Nothing

        'Me.txtMOBILE.Enabled = False
    End Sub

    Private Sub btnPlaceOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PlaceOrder()
    End Sub
    Private Sub PlaceOrder() 'F1
        'If Not mv_strACCTNO Is Nothing Then
        '    If mv_strACCTNO.Length = 10 Then

        '        Dim strLanguage As String = "vi-VN"
        '        If Me.UserLanguage = "EN" Then
        '            strLanguage = "en"
        '        End If

        '        Dim frm As New BrokerScreen.BrokerScreen(strLanguage)
        '        With frm
        '            .Name = "BrokerScreen"
        '            .TellerName = Me.TellerName
        '            .ObjectName = "BD.Router"
        '            .ModuleCode = "BD"
        '            .LocalObject = gc_IsNotLocalMsg
        '            .BranchId = Me.BranchId
        '            .TellerId = Me.TellerId
        '            .IpAddress = Me.IpAddress
        '            .WsName = Me.WsName
        '            .BusDate = Me.BusDate
        '            .IsCareBy = True
        '            .Via = "T"
        '            .CustodyCD = mv_strCUSTODYCD
        '            .AfAcctNO = mv_strACCTNO
        '            .SymbolList = mv_SymbolList
        '            '.ShowDialog()
        '            .Show()
        '        End With
        '        RefreshAccountInfo()
        '    End If
        'End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        SearchEnter()
    End Sub
    Private Sub OnInputSearchInfo()
        mv_blSearchFlag = False
    End Sub

    Private Sub SearchEnter(ByVal sender As System.Object)
        If mv_blSearchFlag = False Then
            GetAccount()
            Dim obj As TextBox = sender
            Me.btnChangePIN.Enabled = False
            Me.btnCIIncrease.Enabled = False
            Me.btnCIDecrease.Enabled = False
            Me.btnCIBlocked.Enabled = False
            Me.btnCIUnBlocked.Enabled = False
            Me.btnSEIncrease.Enabled = False
            Me.btnSEDecrease.Enabled = False
            Me.btnSEBlocked.Enabled = False
            Me.btnSEUnBlocked.Enabled = False
            Me.btnRightOff.Enabled = False
            If Me.AccountInqGrid.DataRows.Count > 0 Then
                Me.txtPinValidate.Enabled = True
                Me.btnPinValidate.Enabled = True
                OnGetAccountInfo()
                Me.txtPinValidate.Clear()
                Me.txtPinValidate.Focus()
                mv_blSearchFlag = True
            Else
                Me.txtPinValidate.Enabled = False
                Me.btnPinValidate.Enabled = False
                'obj.Focus()
                mv_blSearchFlag = False
            End If
        End If
    End Sub
    Private Sub SearchEnter()
        If mv_blSearchFlag = False Then
            GetAccount()
            Me.btnChangePIN.Enabled = False
            Me.btnCIIncrease.Enabled = False
            Me.btnCIIncrease.Enabled = False
            Me.btnCIDecrease.Enabled = False
            Me.btnCIBlocked.Enabled = False
            Me.btnCIUnBlocked.Enabled = False
            Me.btnSEIncrease.Enabled = False
            Me.btnSEDecrease.Enabled = False
            Me.btnSEBlocked.Enabled = False
            Me.btnSEUnBlocked.Enabled = False
            Me.btnRightOff.Enabled = False
            If Me.AccountInqGrid.DataRows.Count > 0 Then
                Me.txtPinValidate.Enabled = True
                Me.btnPinValidate.Enabled = True
                OnGetAccountInfo()
                Me.txtPinValidate.Clear()
                Me.txtPinValidate.Focus()
                mv_blSearchFlag = True
            Else
                Me.txtPinValidate.Enabled = False
                Me.btnPinValidate.Enabled = False
                mv_blSearchFlag = False
            End If
        End If

    End Sub
    Private Sub btnAdvance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ManualAdvance() 'F2
    End Sub
    Private Sub ManualAdvance()
        If Not mv_strACCTNO Is Nothing Then
            If mv_strACCTNO.Length = 10 Then
                Dim frm As New frmManualAdvance(Me.UserLanguage)
                frm.TellerName = Me.TellerName
                frm.LocalObject = gc_IsNotLocalMsg
                frm.ModuleCode = "CI"
                frm.BranchId = Me.BranchId
                frm.TellerId = Me.TellerId
                frm.TellerName = Me.TellerName
                frm.IpAddress = Me.IpAddress
                frm.WsName = Me.WsName
                frm.BusDate = Me.BusDate
                'frm.CurrentTime = Me.CurrentTime
                frm.AFACCTNO = mv_strACCTNO
                frm.CUSTODYCD = mv_strCUSTODYCD
                'frm.ShowDialog()
                'frm.Dispose()
                frm.Show()
                RefreshAccountInfo()
            End If
        End If
    End Sub

    Private Sub CITransfer()
        If Not mv_strACCTNO Is Nothing Then
            If mv_strACCTNO.Length = 10 Then
                Dim frm As New frmTransferInq(Me.UserLanguage)
                frm.TellerName = Me.TellerName
                frm.LocalObject = gc_IsNotLocalMsg
                frm.BranchId = Me.BranchId
                frm.TellerId = Me.TellerId
                frm.TellerName = Me.TellerName
                frm.IpAddress = Me.IpAddress
                frm.WsName = Me.WsName
                frm.BusDate = Me.BusDate
                frm.CurrentTime = Me.CurrentTime
                frm.AccountInquiry = mv_strACCTNO
                'frm.ShowDialog()
                'frm.Dispose()
                frm.Show()
                RefreshAccountInfo()
            End If

        End If
    End Sub

    Private Sub btnRightOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRightOff.Click
        RightOffRegiter()
    End Sub
    Private Sub RightOffRegiter()
        If Not mv_strACCTNO Is Nothing Then
            If mv_strACCTNO.Length = 10 Then
                Dim v_strModCode As String = "CA"
                Dim v_strObjName As String = "CA3394"
                Dim v_strCMDTYPE As String = "V"

                'Goi màn hình tra cứu với SEARCHCODE=v_strRETURNDATA: Màn hình này chỉ cho phép tìm kiếm và thực hiện giao dịch kế tiếp
                Dim frmSearch As New frmSearchMaster(mv_strLanguage)
                frmSearch.BusDate = Me.BusDate
                frmSearch.AFACCTNO = mv_strACCTNO
                frmSearch.TableName = v_strObjName
                frmSearch.ModuleCode = v_strModCode
                frmSearch.AuthCode = "NYNNYYYNNN" 'Chỉ cho phép g?i chức năng tạo giao dịch kế tiếp (Choose)
                frmSearch.CMDTYPE = v_strCMDTYPE
                frmSearch.IsLocalSearch = gc_IsNotLocalMsg
                frmSearch.SearchOnInit = False
                frmSearch.BranchId = Me.BranchId
                frmSearch.TellerId = Me.TellerId
                'frmSearch.ShowDialog()
                'frmSearch.Dispose()
                frmSearch.Show()
                RefreshAccountInfo()
            End If
        End If
    End Sub


    Private Sub SETransfer(ByVal pv_strObjName As String, ByVal pv_strModcode As String)
        If Not mv_strACCTNO Is Nothing Then
            If mv_strACCTNO.Length = 10 Then
                Dim v_strModCode As String = pv_strModcode
                Dim v_strObjName As String = pv_strObjName '"SE2268"
                Dim v_strCMDTYPE As String = "V"

                'Goi màn hình tra cứu với SEARCHCODE=v_strRETURNDATA: Màn hình này chỉ cho phép tìm kiếm và thực hiện giao dịch kế tiếp
                Dim frmSearch As New frmSearchMaster(mv_strLanguage)
                frmSearch.BusDate = Me.BusDate
                frmSearch.AFACCTNO = mv_strACCTNO
                frmSearch.TableName = v_strObjName
                frmSearch.ModuleCode = v_strModCode
                frmSearch.AuthCode = "NYNNYYYNNN" 'Chỉ cho phép g?i chức năng tạo giao dịch kế tiếp (Choose)
                frmSearch.CMDTYPE = v_strCMDTYPE
                frmSearch.IsLocalSearch = gc_IsNotLocalMsg
                frmSearch.SearchOnInit = False
                frmSearch.BranchId = Me.BranchId
                frmSearch.TellerId = Me.TellerId
                frmSearch.Show()
                RefreshAccountInfo()
            End If
        End If
    End Sub


    Private Sub btnOneFirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        OneFirmOrder()
    End Sub
    Private Sub OneFirmOrder()
        'Màn hình đặt lệnh thoa thuan 1 firm
        If Not mv_strACCTNO Is Nothing Then
            If mv_strACCTNO.Length = 10 Then
                Dim frm As New frmQuickOrderPTOneFirm(Me.UserLanguage)
                frm.TellerName = Me.TellerName
                frm.LocalObject = gc_IsNotLocalMsg
                frm.ModuleCode = "OD"
                frm.BranchId = Me.BranchId
                frm.TellerId = Me.TellerId
                frm.TellerName = Me.TellerName
                frm.IpAddress = Me.IpAddress
                frm.WsName = Me.WsName
                frm.BusDate = Me.BusDate
                frm.AdvanceOrder = True
                frm.CurrentTime = Me.CurrentTime
                frm.AFACCTNO = mv_strACCTNO
                frm.CUSTODYCD = mv_strCUSTODYCD
                'frm.ShowDialog()
                'frm.Dispose()
                frm.Show()
                RefreshAccountInfo()
            End If
        End If
    End Sub
    Private Sub btnTwofirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TwoFirmOrder()
    End Sub
    Private Sub TwoFirmOrder()
        'Màn hình đặt lệnh thoa thuan 1 firm
        If Not mv_strACCTNO Is Nothing Then
            If mv_strACCTNO.Length = 10 Then
                Dim frm As New frmQuickOrderTransactPT(Me.UserLanguage)
                frm.TellerName = Me.TellerName
                frm.LocalObject = gc_IsNotLocalMsg
                frm.ModuleCode = "OD"
                frm.BranchId = Me.BranchId
                frm.TellerId = Me.TellerId
                frm.TellerName = Me.TellerName
                frm.IpAddress = Me.IpAddress
                frm.WsName = Me.WsName
                frm.BusDate = Me.BusDate
                frm.AdvanceOrder = True
                frm.CurrentTime = Me.CurrentTime
                frm.AFACCTNO = mv_strACCTNO
                frm.CUSTODYCD = mv_strCUSTODYCD
                'frm.ShowDialog()
                'frm.Dispose()
                frm.Show()
                RefreshAccountInfo()
            End If
        End If
    End Sub

    Private Sub btnChangePIN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangePIN.Click
        ChangePIN()
    End Sub
    Private Sub ChangePIN()
        If Not mv_strACCTNO Is Nothing Then
            If mv_strACCTNO.Length = 10 Then
                Dim mv_frmTransactScreen = New frmTransact(Me.UserLanguage)
                Dim v_strFLDDEFVAL As String
                v_strFLDDEFVAL = ""
                'Truyen so Luu ky
                v_strFLDDEFVAL = v_strFLDDEFVAL & "[88." & mv_strCUSTODYCD & "]"
                Try
                    mv_frmTransactScreen.ObjectName = "0089"
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                mv_frmTransactScreen.ModuleCode = "CF"
                mv_frmTransactScreen.LocalObject = gc_IsNotLocalMsg
                mv_frmTransactScreen.BranchId = Me.BranchId
                mv_frmTransactScreen.TellerId = Me.TellerId
                mv_frmTransactScreen.IpAddress = Me.IpAddress
                mv_frmTransactScreen.WsName = Me.WsName
                mv_frmTransactScreen.BusDate = Me.BusDate

                mv_frmTransactScreen.DefaultValue = v_strFLDDEFVAL
                mv_frmTransactScreen.AutoClosedWhenOK = True
                'mv_frmTransactScreen.AutoSubmitWhenExecute = True
                'mv_frmTransactScreen.ShowDialog()
                'mv_frmTransactScreen.Dispose()
                mv_frmTransactScreen.show()
                RefreshAccountInfo()
            End If
        End If
    End Sub

    Private Sub CallTran(ByVal pv_tltxcd As String, ByVal pv_modcode As String)
        If Not mv_strACCTNO Is Nothing Then
            If mv_strACCTNO.Length = 10 Then
                Dim mv_frmTransactScreen = New frmTransactMaster(Me.UserLanguage)
                Dim v_strFLDDEFVAL As String
                v_strFLDDEFVAL = v_strFLDDEFVAL & "[88." & mv_strCUSTODYCD & "]"

                mv_frmTransactScreen.ObjectName = pv_tltxcd
                mv_frmTransactScreen.ModuleCode = pv_modcode
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
                    Exit Sub
                End If
                mv_frmTransactScreen.Dispose()
                v_strFLDDEFVAL = String.Empty
                RefreshAccountInfo()

                'v_strFLDDEFVAL = ""
                ''Truyen so Luu ky
                'v_strFLDDEFVAL = v_strFLDDEFVAL & "[88." & mv_strCUSTODYCD & "]"
                'Try
                '    mv_frmTransactScreen.ObjectName = pv_tltxcd
                'Catch ex As Exception
                '    MsgBox(ex.Message)
                'End Try
                'mv_frmTransactScreen.ModuleCode = pv_modcode
                'mv_frmTransactScreen.LocalObject = gc_IsNotLocalMsg
                'mv_frmTransactScreen.BranchId = Me.BranchId
                'mv_frmTransactScreen.TellerId = Me.TellerId
                'mv_frmTransactScreen.IpAddress = Me.IpAddress
                'mv_frmTransactScreen.WsName = Me.WsName
                'mv_frmTransactScreen.BusDate = Me.BusDate

                'mv_frmTransactScreen.DefaultValue = v_strFLDDEFVAL
                'mv_frmTransactScreen.AutoClosedWhenOK = True
                'mv_frmTransactScreen.show()

            End If
        End If
    End Sub

    Private Sub txtACCTNO_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtACCTNO.KeyUp
        Select Case e.KeyCode
            Case Keys.F5
                Dim frm As New frmSearch(Me.UserLanguage)
                frm.TableName = "CUSTODYCD_CF"
                frm.ModuleCode = "CF"
                frm.KeyFieldType = "C"
                frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                frm.IsLocalSearch = gc_IsNotLocalMsg
                frm.IsLookup = "Y"
                frm.SearchOnInit = False
                frm.BranchId = Me.BranchId
                frm.TellerId = Me.TellerId
                frm.ShowDialog()
                Me.ActiveControl.Text = Trim(frm.ReturnValue)
            Case Keys.Enter
                SearchEnter(sender)
        End Select
    End Sub
    Private Sub btnPinValidate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPinValidate.Click
        Validate_PIN()
    End Sub
    Private Sub Validate_PIN()
        Try
            Dim v_strPin As String = Trim(CType(AccountInqGrid.CurrentRow, Xceed.Grid.DataRow).Cells("PASSWORD").Value)
            Dim v_strinPin As String
            If txtPinValidate.Text.Length < 0 Then
                MessageBox.Show(mv_ResourceManager.GetString("ERR_INSERTPIN"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            Else
                Using md5Hash As MD5 = MD5.Create()
                    v_strinPin = GetMd5Hash(md5Hash, txtPinValidate.Text)
                End Using

            End If
            If v_strinPin = v_strPin Then
                Me.btnChangePIN.Enabled = True
                Me.btnCIIncrease.Enabled = True
                Me.btnCIDecrease.Enabled = True
                Me.btnCIBlocked.Enabled = True
                Me.btnCIUnBlocked.Enabled = True
                Me.btnSEIncrease.Enabled = True
                Me.btnSEDecrease.Enabled = True
                Me.btnSEBlocked.Enabled = True
                Me.btnSEUnBlocked.Enabled = True
                Me.btnRightOff.Enabled = True
                Me.btnPinValidate.Enabled = False
                Me.txtPinValidate.Enabled = False
                'MessageBox.Show(mv_ResourceManager.GetString("SSS_Corecct"), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.txtPinValidate.Clear()
            Else
                MessageBox.Show(mv_ResourceManager.GetString("ERR_Incorrect"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.btnChangePIN.Enabled = False
                Me.btnCIIncrease.Enabled = False
                Me.btnCIIncrease.Enabled = False
                Me.btnCIDecrease.Enabled = False
                Me.btnCIBlocked.Enabled = False
                Me.btnCIUnBlocked.Enabled = False
                Me.btnSEIncrease.Enabled = False
                Me.btnSEDecrease.Enabled = False
                Me.btnSEBlocked.Enabled = False
                Me.btnSEUnBlocked.Enabled = False
                Me.btnRightOff.Enabled = False
                Me.btnPinValidate.Enabled = True
                Me.txtPinValidate.Enabled = True
                txtPinValidate.Focus()
            End If

        Catch ex As Exception
            LogError.Write("Error source: _DIRECT.frmTeleInq" & vbNewLine _
                             & "Error code: System error!" & vbNewLine _
                             & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(mv_ResourceManager.GetString("ERR_Invalid"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtPinValidate_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPinValidate.KeyUp
        Select Case e.KeyCode
            Case Keys.Enter
                Validate_PIN()
        End Select
    End Sub

    Private Sub txtMOBILE_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMOBILE.KeyUp
        Select Case e.KeyCode
            Case Keys.Enter
                SearchEnter(sender)
        End Select
    End Sub

    Private Sub txtIDCODE_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIDCODE.KeyUp
        Select Case e.KeyCode
            Case Keys.Enter
                SearchEnter(sender)
        End Select
    End Sub

    Private Sub pnACCTNO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnACCTNO.Click
        SearchEnter(sender)
    End Sub

    Private Sub txtMOBILE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMOBILE.TextChanged
        OnInputSearchInfo()
    End Sub

    Private Sub txtACCTNO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtACCTNO.TextChanged
        OnInputSearchInfo()
    End Sub

    Private Sub txtIDCODE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIDCODE.TextChanged
        OnInputSearchInfo()
    End Sub

    Private Sub txtMOBILE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMOBILE.Validated
        SearchEnter(sender)
    End Sub

    Private Sub txtACCTNO_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtACCTNO.Validated
        SearchEnter(sender)
    End Sub

    Private Sub txtIDCODE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIDCODE.Validated
        SearchEnter(sender)
    End Sub

    Private Sub btnCIIncrease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCIIncrease.Click
        CallTran("1141", "CI")
    End Sub

    Private Sub btnCIDecrease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCIDecrease.Click
        CallTran("1132", "CI")
    End Sub

    Private Sub btnCIBlocked_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCIBlocked.Click
        CallTran("1144", "CI")
    End Sub

    Private Sub btnCIUnBlocked_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCIUnBlocked.Click
        CallTran("1145", "CI")
    End Sub

    Private Sub btnSEIncrease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSEIncrease.Click
        CallTran("2245", "SE")
    End Sub

    Private Sub btnSEDecrease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSEDecrease.Click
        CallTran("2200", "SE")
    End Sub

    Private Sub btnSEBlocked_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSEBlocked.Click
        CallTran("2202", "SE")
    End Sub

    Private Sub btnSEUnBlocked_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSEUnBlocked.Click
        SETransfer("SE2203", "SE")
    End Sub
End Class
