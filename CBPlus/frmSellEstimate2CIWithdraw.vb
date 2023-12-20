Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports CommonLibrary
Imports System.Collections
Imports AppCore
Imports AppCore.modCoreLib

Public Class frmSellEstimate2CIWithdraw
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


    Public Sub New(ByVal pv_strLanguage As String, ByVal pv_strObjName As String)
        MyBase.New()
        ObjectName = pv_strObjName

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
    Friend WithEvents pnlAvlSellSec As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlAFInfor As System.Windows.Forms.Panel
    Friend WithEvents txtCUSTODYCD As AppCore.FlexMaskEditBox
    Friend WithEvents lblCUSTODYCD As System.Windows.Forms.Label
    Friend WithEvents cboAFACCTNO As ComboBoxEx
    Friend WithEvents lblAFACCTNO As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnlBeforeSellInfor As System.Windows.Forms.Panel
    Friend WithEvents lblAutoAdvance As System.Windows.Forms.Label
    Friend WithEvents lblWithdrawLimit As System.Windows.Forms.Label
    Friend WithEvents lblRatWithdraw As System.Windows.Forms.Label
    Friend WithEvents lblCIDebt As System.Windows.Forms.Label
    Friend WithEvents lblTotalAssets As System.Windows.Forms.Label
    Friend WithEvents lblNormalWithdraw As System.Windows.Forms.Label
    Friend WithEvents txtNormalWithdraw As System.Windows.Forms.TextBox
    Friend WithEvents txtAutoAdvance As System.Windows.Forms.TextBox
    Friend WithEvents txtWithdrawLimit As System.Windows.Forms.TextBox
    Friend WithEvents txtRatWithdraw As System.Windows.Forms.TextBox
    Friend WithEvents txtCIDebt As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalAssets As System.Windows.Forms.TextBox
    Friend WithEvents txtSellNotMatchAMT As System.Windows.Forms.TextBox
    Friend WithEvents lblSellNotMatchAMT As System.Windows.Forms.Label
    Friend WithEvents lblSellEstimate As System.Windows.Forms.Label
    Friend WithEvents pnlAfterSellInfor As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lblRefPrice As System.Windows.Forms.Label
    Friend WithEvents lblCeilingPrice As System.Windows.Forms.Label
    Friend WithEvents lblMRPrice As System.Windows.Forms.Label
    Friend WithEvents lblFloorPrice As System.Windows.Forms.Label
    Friend WithEvents lblCeilPriceVL As System.Windows.Forms.Label
    Friend WithEvents lblFloorPriceVL As System.Windows.Forms.Label
    Friend WithEvents lblRefPriceVL As System.Windows.Forms.Label
    Friend WithEvents lblMRPriceVL As System.Windows.Forms.Label
    Friend WithEvents lblSumSell As System.Windows.Forms.Label
    Friend WithEvents lblAfterSell As System.Windows.Forms.Label
    Friend WithEvents txtNMWithdrawAfter As System.Windows.Forms.TextBox
    Friend WithEvents lblNMWithdrawAfter As System.Windows.Forms.Label
    Friend WithEvents txtSumSellRemain As System.Windows.Forms.TextBox
    Friend WithEvents txtSumSell As System.Windows.Forms.TextBox
    Friend WithEvents txtSumSellExc As System.Windows.Forms.TextBox
    Friend WithEvents lblSumSellRemain As System.Windows.Forms.Label
    Friend WithEvents lblSumSellExc As System.Windows.Forms.Label
    Friend WithEvents txtSellNotMatchExc As System.Windows.Forms.TextBox
    Friend WithEvents lblSellNotMatchExc As System.Windows.Forms.Label
    Friend WithEvents txtADVAMT As System.Windows.Forms.TextBox
    Friend WithEvents lblADVAMT As System.Windows.Forms.Label
    Friend WithEvents lblBeforeSellInfor As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSellEstimate2CIWithdraw))
        Me.pnlAvlSellSec = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.pnlAfterSellInfor = New System.Windows.Forms.Panel
        Me.txtNMWithdrawAfter = New System.Windows.Forms.TextBox
        Me.lblNMWithdrawAfter = New System.Windows.Forms.Label
        Me.lblAfterSell = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lblSumSellRemain = New System.Windows.Forms.Label
        Me.lblSumSellExc = New System.Windows.Forms.Label
        Me.txtSumSell = New System.Windows.Forms.TextBox
        Me.txtSumSellExc = New System.Windows.Forms.TextBox
        Me.txtSumSellRemain = New System.Windows.Forms.TextBox
        Me.lblSumSell = New System.Windows.Forms.Label
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.lblMRPriceVL = New System.Windows.Forms.Label
        Me.lblFloorPriceVL = New System.Windows.Forms.Label
        Me.lblRefPriceVL = New System.Windows.Forms.Label
        Me.lblCeilPriceVL = New System.Windows.Forms.Label
        Me.lblMRPrice = New System.Windows.Forms.Label
        Me.lblFloorPrice = New System.Windows.Forms.Label
        Me.lblRefPrice = New System.Windows.Forms.Label
        Me.lblCeilingPrice = New System.Windows.Forms.Label
        Me.lblSellEstimate = New System.Windows.Forms.Label
        Me.pnlBeforeSellInfor = New System.Windows.Forms.Panel
        Me.lblADVAMT = New System.Windows.Forms.Label
        Me.txtADVAMT = New System.Windows.Forms.TextBox
        Me.txtSellNotMatchExc = New System.Windows.Forms.TextBox
        Me.lblSellNotMatchExc = New System.Windows.Forms.Label
        Me.txtSellNotMatchAMT = New System.Windows.Forms.TextBox
        Me.lblSellNotMatchAMT = New System.Windows.Forms.Label
        Me.txtAutoAdvance = New System.Windows.Forms.TextBox
        Me.txtWithdrawLimit = New System.Windows.Forms.TextBox
        Me.txtRatWithdraw = New System.Windows.Forms.TextBox
        Me.txtCIDebt = New System.Windows.Forms.TextBox
        Me.txtTotalAssets = New System.Windows.Forms.TextBox
        Me.txtNormalWithdraw = New System.Windows.Forms.TextBox
        Me.lblAutoAdvance = New System.Windows.Forms.Label
        Me.lblWithdrawLimit = New System.Windows.Forms.Label
        Me.lblRatWithdraw = New System.Windows.Forms.Label
        Me.lblCIDebt = New System.Windows.Forms.Label
        Me.lblTotalAssets = New System.Windows.Forms.Label
        Me.lblNormalWithdraw = New System.Windows.Forms.Label
        Me.lblBeforeSellInfor = New System.Windows.Forms.Label
        Me.pnlAFInfor = New System.Windows.Forms.Panel
        Me.lblAFACCTNO = New System.Windows.Forms.Label
        Me.cboAFACCTNO = New AppCore.ComboBoxEx
        Me.lblCUSTODYCD = New System.Windows.Forms.Label
        Me.txtCUSTODYCD = New AppCore.FlexMaskEditBox
        Me.Panel1.SuspendLayout()
        Me.pnlAfterSellInfor.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnlBeforeSellInfor.SuspendLayout()
        Me.pnlAFInfor.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlAvlSellSec
        '
        Me.pnlAvlSellSec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAvlSellSec.Location = New System.Drawing.Point(3, 22)
        Me.pnlAvlSellSec.Name = "pnlAvlSellSec"
        Me.pnlAvlSellSec.Size = New System.Drawing.Size(778, 227)
        Me.pnlAvlSellSec.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.pnlAfterSellInfor)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.pnlBeforeSellInfor)
        Me.Panel1.Controls.Add(Me.pnlAFInfor)
        Me.Panel1.Location = New System.Drawing.Point(0, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(793, 570)
        Me.Panel1.TabIndex = 0
        '
        'pnlAfterSellInfor
        '
        Me.pnlAfterSellInfor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAfterSellInfor.Controls.Add(Me.txtNMWithdrawAfter)
        Me.pnlAfterSellInfor.Controls.Add(Me.lblNMWithdrawAfter)
        Me.pnlAfterSellInfor.Controls.Add(Me.lblAfterSell)
        Me.pnlAfterSellInfor.Location = New System.Drawing.Point(3, 507)
        Me.pnlAfterSellInfor.Name = "pnlAfterSellInfor"
        Me.pnlAfterSellInfor.Size = New System.Drawing.Size(785, 57)
        Me.pnlAfterSellInfor.TabIndex = 3
        '
        'txtNMWithdrawAfter
        '
        Me.txtNMWithdrawAfter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNMWithdrawAfter.ForeColor = System.Drawing.Color.OrangeRed
        Me.txtNMWithdrawAfter.Location = New System.Drawing.Point(222, 28)
        Me.txtNMWithdrawAfter.Name = "txtNMWithdrawAfter"
        Me.txtNMWithdrawAfter.Size = New System.Drawing.Size(150, 20)
        Me.txtNMWithdrawAfter.TabIndex = 0
        Me.txtNMWithdrawAfter.Tag = "txtNMWithdrawAfter"
        Me.txtNMWithdrawAfter.Text = "txtNMWithdrawAfter"
        '
        'lblNMWithdrawAfter
        '
        Me.lblNMWithdrawAfter.AutoSize = True
        Me.lblNMWithdrawAfter.ForeColor = System.Drawing.Color.Blue
        Me.lblNMWithdrawAfter.Location = New System.Drawing.Point(7, 31)
        Me.lblNMWithdrawAfter.Name = "lblNMWithdrawAfter"
        Me.lblNMWithdrawAfter.Size = New System.Drawing.Size(101, 13)
        Me.lblNMWithdrawAfter.TabIndex = 20
        Me.lblNMWithdrawAfter.Tag = "lblNMWithdrawAfter"
        Me.lblNMWithdrawAfter.Text = "lblNMWithdrawAfter"
        '
        'lblAfterSell
        '
        Me.lblAfterSell.AutoSize = True
        Me.lblAfterSell.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAfterSell.ForeColor = System.Drawing.Color.Blue
        Me.lblAfterSell.Location = New System.Drawing.Point(7, 3)
        Me.lblAfterSell.Name = "lblAfterSell"
        Me.lblAfterSell.Size = New System.Drawing.Size(77, 15)
        Me.lblAfterSell.TabIndex = 18
        Me.lblAfterSell.Tag = "lblAfterSell"
        Me.lblAfterSell.Text = "lblAfterSell"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.lblSumSellRemain)
        Me.Panel2.Controls.Add(Me.lblSumSellExc)
        Me.Panel2.Controls.Add(Me.txtSumSell)
        Me.Panel2.Controls.Add(Me.txtSumSellExc)
        Me.Panel2.Controls.Add(Me.txtSumSellRemain)
        Me.Panel2.Controls.Add(Me.lblSumSell)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.lblSellEstimate)
        Me.Panel2.Controls.Add(Me.pnlAvlSellSec)
        Me.Panel2.Location = New System.Drawing.Point(3, 222)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(785, 280)
        Me.Panel2.TabIndex = 2
        '
        'lblSumSellRemain
        '
        Me.lblSumSellRemain.AutoSize = True
        Me.lblSumSellRemain.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSumSellRemain.ForeColor = System.Drawing.Color.Blue
        Me.lblSumSellRemain.Location = New System.Drawing.Point(524, 258)
        Me.lblSumSellRemain.Name = "lblSumSellRemain"
        Me.lblSumSellRemain.Size = New System.Drawing.Size(91, 13)
        Me.lblSumSellRemain.TabIndex = 22
        Me.lblSumSellRemain.Tag = "lblSumSellRemain"
        Me.lblSumSellRemain.Text = "lblSumSellRemain"
        '
        'lblSumSellExc
        '
        Me.lblSumSellExc.AutoSize = True
        Me.lblSumSellExc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSumSellExc.ForeColor = System.Drawing.Color.Blue
        Me.lblSumSellExc.Location = New System.Drawing.Point(261, 258)
        Me.lblSumSellExc.Name = "lblSumSellExc"
        Me.lblSumSellExc.Size = New System.Drawing.Size(73, 13)
        Me.lblSumSellExc.TabIndex = 21
        Me.lblSumSellExc.Tag = "lblSumSellExc"
        Me.lblSumSellExc.Text = "lblSumSellExc"
        '
        'txtSumSell
        '
        Me.txtSumSell.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSumSell.Location = New System.Drawing.Point(125, 255)
        Me.txtSumSell.Name = "txtSumSell"
        Me.txtSumSell.Size = New System.Drawing.Size(130, 20)
        Me.txtSumSell.TabIndex = 20
        Me.txtSumSell.Tag = "txtSumSell"
        Me.txtSumSell.Text = "txtSumSell"
        '
        'txtSumSellExc
        '
        Me.txtSumSellExc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSumSellExc.Location = New System.Drawing.Point(388, 255)
        Me.txtSumSellExc.Name = "txtSumSellExc"
        Me.txtSumSellExc.Size = New System.Drawing.Size(130, 20)
        Me.txtSumSellExc.TabIndex = 19
        Me.txtSumSellExc.Tag = "txtSumSellExc"
        Me.txtSumSellExc.Text = "txtSumSellExc"
        '
        'txtSumSellRemain
        '
        Me.txtSumSellRemain.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSumSellRemain.Location = New System.Drawing.Point(650, 255)
        Me.txtSumSellRemain.Name = "txtSumSellRemain"
        Me.txtSumSellRemain.Size = New System.Drawing.Size(130, 20)
        Me.txtSumSellRemain.TabIndex = 18
        Me.txtSumSellRemain.Tag = "txtSumSellRemain"
        Me.txtSumSellRemain.Text = "txtSumSellRemain"
        '
        'lblSumSell
        '
        Me.lblSumSell.AutoSize = True
        Me.lblSumSell.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSumSell.ForeColor = System.Drawing.Color.Blue
        Me.lblSumSell.Location = New System.Drawing.Point(6, 258)
        Me.lblSumSell.Name = "lblSumSell"
        Me.lblSumSell.Size = New System.Drawing.Size(55, 13)
        Me.lblSumSell.TabIndex = 17
        Me.lblSumSell.Tag = "lblSumSell"
        Me.lblSumSell.Text = "lblSumSell"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Black
        Me.Panel4.Controls.Add(Me.lblMRPriceVL)
        Me.Panel4.Controls.Add(Me.lblFloorPriceVL)
        Me.Panel4.Controls.Add(Me.lblRefPriceVL)
        Me.Panel4.Controls.Add(Me.lblCeilPriceVL)
        Me.Panel4.Controls.Add(Me.lblMRPrice)
        Me.Panel4.Controls.Add(Me.lblFloorPrice)
        Me.Panel4.Controls.Add(Me.lblRefPrice)
        Me.Panel4.Controls.Add(Me.lblCeilingPrice)
        Me.Panel4.Location = New System.Drawing.Point(160, 1)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(621, 20)
        Me.Panel4.TabIndex = 16
        '
        'lblMRPriceVL
        '
        Me.lblMRPriceVL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMRPriceVL.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblMRPriceVL.Location = New System.Drawing.Point(530, 5)
        Me.lblMRPriceVL.Name = "lblMRPriceVL"
        Me.lblMRPriceVL.Size = New System.Drawing.Size(87, 13)
        Me.lblMRPriceVL.TabIndex = 30
        Me.lblMRPriceVL.Tag = "lblMRPriceVL"
        Me.lblMRPriceVL.Text = "lblMRPriceVL"
        Me.lblMRPriceVL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFloorPriceVL
        '
        Me.lblFloorPriceVL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFloorPriceVL.ForeColor = System.Drawing.Color.Cyan
        Me.lblFloorPriceVL.Location = New System.Drawing.Point(370, 5)
        Me.lblFloorPriceVL.Name = "lblFloorPriceVL"
        Me.lblFloorPriceVL.Size = New System.Drawing.Size(87, 13)
        Me.lblFloorPriceVL.TabIndex = 29
        Me.lblFloorPriceVL.Tag = "lblFloorPriceVL"
        Me.lblFloorPriceVL.Text = "lblFloorPriceVL"
        Me.lblFloorPriceVL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRefPriceVL
        '
        Me.lblRefPriceVL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRefPriceVL.ForeColor = System.Drawing.Color.Yellow
        Me.lblRefPriceVL.Location = New System.Drawing.Point(217, 5)
        Me.lblRefPriceVL.Name = "lblRefPriceVL"
        Me.lblRefPriceVL.Size = New System.Drawing.Size(87, 13)
        Me.lblRefPriceVL.TabIndex = 28
        Me.lblRefPriceVL.Tag = "lblRefPriceVL"
        Me.lblRefPriceVL.Text = "lblRefPriceVL"
        Me.lblRefPriceVL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCeilPriceVL
        '
        Me.lblCeilPriceVL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCeilPriceVL.ForeColor = System.Drawing.Color.Magenta
        Me.lblCeilPriceVL.Location = New System.Drawing.Point(62, 5)
        Me.lblCeilPriceVL.Name = "lblCeilPriceVL"
        Me.lblCeilPriceVL.Size = New System.Drawing.Size(87, 13)
        Me.lblCeilPriceVL.TabIndex = 27
        Me.lblCeilPriceVL.Tag = "lblCeilPriceVL"
        Me.lblCeilPriceVL.Text = "lblCeilPriceVL"
        Me.lblCeilPriceVL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMRPrice
        '
        Me.lblMRPrice.AutoSize = True
        Me.lblMRPrice.ForeColor = System.Drawing.Color.White
        Me.lblMRPrice.Location = New System.Drawing.Point(460, 5)
        Me.lblMRPrice.Name = "lblMRPrice"
        Me.lblMRPrice.Size = New System.Drawing.Size(58, 13)
        Me.lblMRPrice.TabIndex = 26
        Me.lblMRPrice.Tag = "lblMRPrice"
        Me.lblMRPrice.Text = "lblMRPrice"
        '
        'lblFloorPrice
        '
        Me.lblFloorPrice.AutoSize = True
        Me.lblFloorPrice.ForeColor = System.Drawing.Color.White
        Me.lblFloorPrice.Location = New System.Drawing.Point(309, 5)
        Me.lblFloorPrice.Name = "lblFloorPrice"
        Me.lblFloorPrice.Size = New System.Drawing.Size(64, 13)
        Me.lblFloorPrice.TabIndex = 25
        Me.lblFloorPrice.Tag = "lblFloorPrice"
        Me.lblFloorPrice.Text = "lblFloorPrice"
        '
        'lblRefPrice
        '
        Me.lblRefPrice.AutoSize = True
        Me.lblRefPrice.ForeColor = System.Drawing.Color.White
        Me.lblRefPrice.Location = New System.Drawing.Point(154, 5)
        Me.lblRefPrice.Name = "lblRefPrice"
        Me.lblRefPrice.Size = New System.Drawing.Size(58, 13)
        Me.lblRefPrice.TabIndex = 24
        Me.lblRefPrice.Tag = "lblRefPrice"
        Me.lblRefPrice.Text = "lblRefPrice"
        '
        'lblCeilingPrice
        '
        Me.lblCeilingPrice.AutoSize = True
        Me.lblCeilingPrice.ForeColor = System.Drawing.Color.White
        Me.lblCeilingPrice.Location = New System.Drawing.Point(3, 5)
        Me.lblCeilingPrice.Name = "lblCeilingPrice"
        Me.lblCeilingPrice.Size = New System.Drawing.Size(72, 13)
        Me.lblCeilingPrice.TabIndex = 23
        Me.lblCeilingPrice.Tag = "lblCeilingPrice"
        Me.lblCeilingPrice.Text = "lblCeilingPrice"
        '
        'lblSellEstimate
        '
        Me.lblSellEstimate.AutoSize = True
        Me.lblSellEstimate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSellEstimate.ForeColor = System.Drawing.Color.Blue
        Me.lblSellEstimate.Location = New System.Drawing.Point(7, 4)
        Me.lblSellEstimate.Name = "lblSellEstimate"
        Me.lblSellEstimate.Size = New System.Drawing.Size(104, 15)
        Me.lblSellEstimate.TabIndex = 5
        Me.lblSellEstimate.Tag = "lblSellEstimate"
        Me.lblSellEstimate.Text = "lblSellEstimate"
        '
        'pnlBeforeSellInfor
        '
        Me.pnlBeforeSellInfor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBeforeSellInfor.Controls.Add(Me.lblADVAMT)
        Me.pnlBeforeSellInfor.Controls.Add(Me.txtADVAMT)
        Me.pnlBeforeSellInfor.Controls.Add(Me.txtSellNotMatchExc)
        Me.pnlBeforeSellInfor.Controls.Add(Me.lblSellNotMatchExc)
        Me.pnlBeforeSellInfor.Controls.Add(Me.txtSellNotMatchAMT)
        Me.pnlBeforeSellInfor.Controls.Add(Me.lblSellNotMatchAMT)
        Me.pnlBeforeSellInfor.Controls.Add(Me.txtAutoAdvance)
        Me.pnlBeforeSellInfor.Controls.Add(Me.txtWithdrawLimit)
        Me.pnlBeforeSellInfor.Controls.Add(Me.txtRatWithdraw)
        Me.pnlBeforeSellInfor.Controls.Add(Me.txtCIDebt)
        Me.pnlBeforeSellInfor.Controls.Add(Me.txtTotalAssets)
        Me.pnlBeforeSellInfor.Controls.Add(Me.txtNormalWithdraw)
        Me.pnlBeforeSellInfor.Controls.Add(Me.lblAutoAdvance)
        Me.pnlBeforeSellInfor.Controls.Add(Me.lblWithdrawLimit)
        Me.pnlBeforeSellInfor.Controls.Add(Me.lblRatWithdraw)
        Me.pnlBeforeSellInfor.Controls.Add(Me.lblCIDebt)
        Me.pnlBeforeSellInfor.Controls.Add(Me.lblTotalAssets)
        Me.pnlBeforeSellInfor.Controls.Add(Me.lblNormalWithdraw)
        Me.pnlBeforeSellInfor.Controls.Add(Me.lblBeforeSellInfor)
        Me.pnlBeforeSellInfor.Location = New System.Drawing.Point(3, 55)
        Me.pnlBeforeSellInfor.Name = "pnlBeforeSellInfor"
        Me.pnlBeforeSellInfor.Size = New System.Drawing.Size(785, 161)
        Me.pnlBeforeSellInfor.TabIndex = 1
        '
        'lblADVAMT
        '
        Me.lblADVAMT.AutoSize = True
        Me.lblADVAMT.ForeColor = System.Drawing.Color.Blue
        Me.lblADVAMT.Location = New System.Drawing.Point(412, 107)
        Me.lblADVAMT.Name = "lblADVAMT"
        Me.lblADVAMT.Size = New System.Drawing.Size(62, 13)
        Me.lblADVAMT.TabIndex = 32
        Me.lblADVAMT.Tag = "lblADVAMT"
        Me.lblADVAMT.Text = "lblADVAMT"
        '
        'txtADVAMT
        '
        Me.txtADVAMT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtADVAMT.Location = New System.Drawing.Point(627, 104)
        Me.txtADVAMT.Name = "txtADVAMT"
        Me.txtADVAMT.Size = New System.Drawing.Size(150, 20)
        Me.txtADVAMT.TabIndex = 31
        Me.txtADVAMT.Tag = "txtADVAMT"
        Me.txtADVAMT.Text = "txtADVAMT"
        '
        'txtSellNotMatchExc
        '
        Me.txtSellNotMatchExc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSellNotMatchExc.Location = New System.Drawing.Point(627, 130)
        Me.txtSellNotMatchExc.Name = "txtSellNotMatchExc"
        Me.txtSellNotMatchExc.Size = New System.Drawing.Size(150, 20)
        Me.txtSellNotMatchExc.TabIndex = 13
        Me.txtSellNotMatchExc.Tag = "txtSellNotMatchExc"
        Me.txtSellNotMatchExc.Text = "txtSellNotMatchExc"
        '
        'lblSellNotMatchExc
        '
        Me.lblSellNotMatchExc.AutoSize = True
        Me.lblSellNotMatchExc.ForeColor = System.Drawing.Color.Blue
        Me.lblSellNotMatchExc.Location = New System.Drawing.Point(412, 134)
        Me.lblSellNotMatchExc.Name = "lblSellNotMatchExc"
        Me.lblSellNotMatchExc.Size = New System.Drawing.Size(99, 13)
        Me.lblSellNotMatchExc.TabIndex = 30
        Me.lblSellNotMatchExc.Tag = "lblSellNotMatchExc"
        Me.lblSellNotMatchExc.Text = "lblSellNotMatchExc"
        '
        'txtSellNotMatchAMT
        '
        Me.txtSellNotMatchAMT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSellNotMatchAMT.Location = New System.Drawing.Point(627, 78)
        Me.txtSellNotMatchAMT.Name = "txtSellNotMatchAMT"
        Me.txtSellNotMatchAMT.Size = New System.Drawing.Size(150, 20)
        Me.txtSellNotMatchAMT.TabIndex = 12
        Me.txtSellNotMatchAMT.Tag = "txtSellNotMatchAMT"
        Me.txtSellNotMatchAMT.Text = "txtSellNotMatchAMT"
        '
        'lblSellNotMatchAMT
        '
        Me.lblSellNotMatchAMT.AutoSize = True
        Me.lblSellNotMatchAMT.ForeColor = System.Drawing.Color.Blue
        Me.lblSellNotMatchAMT.Location = New System.Drawing.Point(412, 82)
        Me.lblSellNotMatchAMT.Name = "lblSellNotMatchAMT"
        Me.lblSellNotMatchAMT.Size = New System.Drawing.Size(104, 13)
        Me.lblSellNotMatchAMT.TabIndex = 28
        Me.lblSellNotMatchAMT.Tag = "lblSellNotMatchAMT"
        Me.lblSellNotMatchAMT.Text = "lblSellNotMatchAMT"
        '
        'txtAutoAdvance
        '
        Me.txtAutoAdvance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAutoAdvance.Location = New System.Drawing.Point(627, 52)
        Me.txtAutoAdvance.Name = "txtAutoAdvance"
        Me.txtAutoAdvance.Size = New System.Drawing.Size(150, 20)
        Me.txtAutoAdvance.TabIndex = 10
        Me.txtAutoAdvance.Tag = "txtAutoAdvance"
        Me.txtAutoAdvance.Text = "txtAutoAdvance"
        '
        'txtWithdrawLimit
        '
        Me.txtWithdrawLimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWithdrawLimit.Location = New System.Drawing.Point(627, 26)
        Me.txtWithdrawLimit.Name = "txtWithdrawLimit"
        Me.txtWithdrawLimit.Size = New System.Drawing.Size(150, 20)
        Me.txtWithdrawLimit.TabIndex = 8
        Me.txtWithdrawLimit.Tag = "txtWithdrawLimit"
        Me.txtWithdrawLimit.Text = "txtWithdrawLimit"
        '
        'txtRatWithdraw
        '
        Me.txtRatWithdraw.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRatWithdraw.Location = New System.Drawing.Point(222, 107)
        Me.txtRatWithdraw.Name = "txtRatWithdraw"
        Me.txtRatWithdraw.Size = New System.Drawing.Size(150, 20)
        Me.txtRatWithdraw.TabIndex = 6
        Me.txtRatWithdraw.Tag = "txtRatWithdraw"
        Me.txtRatWithdraw.Text = "txtRatWithdraw"
        '
        'txtCIDebt
        '
        Me.txtCIDebt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCIDebt.Location = New System.Drawing.Point(222, 81)
        Me.txtCIDebt.Name = "txtCIDebt"
        Me.txtCIDebt.Size = New System.Drawing.Size(150, 20)
        Me.txtCIDebt.TabIndex = 4
        Me.txtCIDebt.Tag = "txtCIDebt"
        Me.txtCIDebt.Text = "txtCIDebt"
        '
        'txtTotalAssets
        '
        Me.txtTotalAssets.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalAssets.Location = New System.Drawing.Point(222, 55)
        Me.txtTotalAssets.Name = "txtTotalAssets"
        Me.txtTotalAssets.Size = New System.Drawing.Size(150, 20)
        Me.txtTotalAssets.TabIndex = 2
        Me.txtTotalAssets.Tag = "txtTotalAssets"
        Me.txtTotalAssets.Text = "txtTotalAssets"
        '
        'txtNormalWithdraw
        '
        Me.txtNormalWithdraw.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNormalWithdraw.Location = New System.Drawing.Point(222, 29)
        Me.txtNormalWithdraw.Name = "txtNormalWithdraw"
        Me.txtNormalWithdraw.Size = New System.Drawing.Size(150, 20)
        Me.txtNormalWithdraw.TabIndex = 0
        Me.txtNormalWithdraw.Tag = "txtNormalWithdraw"
        Me.txtNormalWithdraw.Text = "txtNormalWithdraw"
        '
        'lblAutoAdvance
        '
        Me.lblAutoAdvance.AutoSize = True
        Me.lblAutoAdvance.ForeColor = System.Drawing.Color.Blue
        Me.lblAutoAdvance.Location = New System.Drawing.Point(412, 56)
        Me.lblAutoAdvance.Name = "lblAutoAdvance"
        Me.lblAutoAdvance.Size = New System.Drawing.Size(82, 13)
        Me.lblAutoAdvance.TabIndex = 10
        Me.lblAutoAdvance.Tag = "lblAutoAdvance"
        Me.lblAutoAdvance.Text = "lblAutoAdvance"
        '
        'lblWithdrawLimit
        '
        Me.lblWithdrawLimit.AutoSize = True
        Me.lblWithdrawLimit.ForeColor = System.Drawing.Color.Blue
        Me.lblWithdrawLimit.Location = New System.Drawing.Point(412, 30)
        Me.lblWithdrawLimit.Name = "lblWithdrawLimit"
        Me.lblWithdrawLimit.Size = New System.Drawing.Size(83, 13)
        Me.lblWithdrawLimit.TabIndex = 9
        Me.lblWithdrawLimit.Tag = "lblWithdrawLimit"
        Me.lblWithdrawLimit.Text = "lblWithdrawLimit"
        '
        'lblRatWithdraw
        '
        Me.lblRatWithdraw.AutoSize = True
        Me.lblRatWithdraw.ForeColor = System.Drawing.Color.Blue
        Me.lblRatWithdraw.Location = New System.Drawing.Point(7, 111)
        Me.lblRatWithdraw.Name = "lblRatWithdraw"
        Me.lblRatWithdraw.Size = New System.Drawing.Size(79, 13)
        Me.lblRatWithdraw.TabIndex = 8
        Me.lblRatWithdraw.Tag = "lblRatWithdraw"
        Me.lblRatWithdraw.Text = "lblRatWithdraw"
        '
        'lblCIDebt
        '
        Me.lblCIDebt.AutoSize = True
        Me.lblCIDebt.ForeColor = System.Drawing.Color.Blue
        Me.lblCIDebt.Location = New System.Drawing.Point(7, 85)
        Me.lblCIDebt.Name = "lblCIDebt"
        Me.lblCIDebt.Size = New System.Drawing.Size(50, 13)
        Me.lblCIDebt.TabIndex = 7
        Me.lblCIDebt.Tag = "lblCIDebt"
        Me.lblCIDebt.Text = "lblCIDebt"
        '
        'lblTotalAssets
        '
        Me.lblTotalAssets.AutoSize = True
        Me.lblTotalAssets.ForeColor = System.Drawing.Color.Blue
        Me.lblTotalAssets.Location = New System.Drawing.Point(7, 59)
        Me.lblTotalAssets.Name = "lblTotalAssets"
        Me.lblTotalAssets.Size = New System.Drawing.Size(72, 13)
        Me.lblTotalAssets.TabIndex = 6
        Me.lblTotalAssets.Tag = "lblTotalAssets"
        Me.lblTotalAssets.Text = "lblTotalAssets"
        '
        'lblNormalWithdraw
        '
        Me.lblNormalWithdraw.AutoSize = True
        Me.lblNormalWithdraw.ForeColor = System.Drawing.Color.Blue
        Me.lblNormalWithdraw.Location = New System.Drawing.Point(7, 33)
        Me.lblNormalWithdraw.Name = "lblNormalWithdraw"
        Me.lblNormalWithdraw.Size = New System.Drawing.Size(95, 13)
        Me.lblNormalWithdraw.TabIndex = 5
        Me.lblNormalWithdraw.Tag = "lblNormalWithdraw"
        Me.lblNormalWithdraw.Text = "lblNormalWithdraw"
        '
        'lblBeforeSellInfor
        '
        Me.lblBeforeSellInfor.AutoSize = True
        Me.lblBeforeSellInfor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBeforeSellInfor.ForeColor = System.Drawing.Color.Blue
        Me.lblBeforeSellInfor.Location = New System.Drawing.Point(7, 4)
        Me.lblBeforeSellInfor.Name = "lblBeforeSellInfor"
        Me.lblBeforeSellInfor.Size = New System.Drawing.Size(119, 15)
        Me.lblBeforeSellInfor.TabIndex = 4
        Me.lblBeforeSellInfor.Tag = "lblBeforeSellInfor"
        Me.lblBeforeSellInfor.Text = "lblBeforeSellInfor"
        '
        'pnlAFInfor
        '
        Me.pnlAFInfor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAFInfor.Controls.Add(Me.lblAFACCTNO)
        Me.pnlAFInfor.Controls.Add(Me.cboAFACCTNO)
        Me.pnlAFInfor.Controls.Add(Me.lblCUSTODYCD)
        Me.pnlAFInfor.Controls.Add(Me.txtCUSTODYCD)
        Me.pnlAFInfor.Location = New System.Drawing.Point(3, 3)
        Me.pnlAFInfor.Name = "pnlAFInfor"
        Me.pnlAFInfor.Size = New System.Drawing.Size(785, 48)
        Me.pnlAFInfor.TabIndex = 0
        '
        'lblAFACCTNO
        '
        Me.lblAFACCTNO.AutoSize = True
        Me.lblAFACCTNO.ForeColor = System.Drawing.Color.Blue
        Me.lblAFACCTNO.Location = New System.Drawing.Point(219, 15)
        Me.lblAFACCTNO.Name = "lblAFACCTNO"
        Me.lblAFACCTNO.Size = New System.Drawing.Size(74, 13)
        Me.lblAFACCTNO.TabIndex = 3
        Me.lblAFACCTNO.Tag = "lblAFACCTNO"
        Me.lblAFACCTNO.Text = "lblAFACCTNO"
        '
        'cboAFACCTNO
        '
        Me.cboAFACCTNO.DisplayMember = "DISPLAY"
        Me.cboAFACCTNO.FormattingEnabled = True
        Me.cboAFACCTNO.Location = New System.Drawing.Point(330, 12)
        Me.cboAFACCTNO.Name = "cboAFACCTNO"
        Me.cboAFACCTNO.Size = New System.Drawing.Size(447, 21)
        Me.cboAFACCTNO.TabIndex = 1
        Me.cboAFACCTNO.ValueMember = "VALUE"
        '
        'lblCUSTODYCD
        '
        Me.lblCUSTODYCD.AutoSize = True
        Me.lblCUSTODYCD.ForeColor = System.Drawing.Color.Blue
        Me.lblCUSTODYCD.Location = New System.Drawing.Point(7, 15)
        Me.lblCUSTODYCD.Name = "lblCUSTODYCD"
        Me.lblCUSTODYCD.Size = New System.Drawing.Size(84, 13)
        Me.lblCUSTODYCD.TabIndex = 1
        Me.lblCUSTODYCD.Tag = "lblCUSTODYCD"
        Me.lblCUSTODYCD.Text = "lblCUSTODYCD"
        '
        'txtCUSTODYCD
        '
        Me.txtCUSTODYCD.Location = New System.Drawing.Point(113, 12)
        Me.txtCUSTODYCD.Name = "txtCUSTODYCD"
        Me.txtCUSTODYCD.Size = New System.Drawing.Size(100, 20)
        Me.txtCUSTODYCD.TabIndex = 0
        Me.txtCUSTODYCD.Tag = "txtCUSTODYCD"
        Me.txtCUSTODYCD.Text = "txtCUSTODYCD"
        '
        'frmSellEstimate2CIWithdraw
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(794, 572)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Name = "frmSellEstimate2CIWithdraw"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "frmSellEstimate2CIWithdraw"
        Me.Text = "frmSellEstimate2CIWithdraw"
        Me.Panel1.ResumeLayout(False)
        Me.pnlAfterSellInfor.ResumeLayout(False)
        Me.pnlAfterSellInfor.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.pnlBeforeSellInfor.ResumeLayout(False)
        Me.pnlBeforeSellInfor.PerformLayout()
        Me.pnlAFInfor.ResumeLayout(False)
        Me.pnlAFInfor.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Declare constant and variables "
    Public mv_SymbolTalble As New DataTable
    Const c_ResourceManager = "_DIRECT.frmSellEstimate2CIWithdraw-"
    Public AvlSellSecGrid As GridEx
    Dim mv_strLastAFACCTNO As String = String.Empty
    Private mv_strSQLCMD As String = String.Empty
    Private mv_strObjectName As String
    Private mv_strTltxcd As String
    Private mv_strModuleCode As String
    Private mv_strLanguage As String
    Private mv_ResourceManager As Resources.ResourceManager
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
    Private mv_decMRIRATE As Decimal
    Private mv_strMRSTATUS As String = String.Empty
    Private mv_strAUTOADV As String = String.Empty

#End Region

#Region " Properties "

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

#End Region

#Region " Other Methods "
    Protected Overridable Function InitDialog()
        'Khá»Ÿi táº¡o kÃ­ch thÆ°á»›c form vÃ  load resource
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)
        ResetScreen(Me)

        Me.txtCUSTODYCD.BackColor = System.Drawing.Color.GreenYellow
        Me.txtCUSTODYCD.Mask = "cccc.cccccc"
        Me.txtCUSTODYCD.MaskCharInclude = False
        txtCUSTODYCD.Text = String.Empty

    End Function

    Private Sub ResetScreen(ByRef pv_ctrl As Windows.Forms.Control)
        Dim i, v_intNumSelected, v_intNum As Integer
        v_intNumSelected = 0
        v_intNum = AvlSellSecGrid.DataRows.Count
        If Me.AvlSellSecGrid.DataRows.Count > 0 Then
            AvlSellSecGrid.CurrentRow = Me.AvlSellSecGrid.DataRows(0)
        End If

        'txtCUSTODYCD.Text = String.Empty
        'txtAutoAdvance.Text = String.Empty
        'txtCIDebt.Text = String.Empty
        'txtNMWithdrawAfter.Text = String.Empty
        'txtNormalWithdraw.Text = String.Empty
        'txtRatWithdraw.Text = String.Empty
        'txtSellNotMatchAMT.Text = String.Empty
        'txtTotalAssets.Text = String.Empty
        'txtWithdrawLimit.Text = String.Empty
        'txtT2Amount.Text = String.Empty
        'txtT2CIDept.Text = String.Empty
        'txtT2RatWithdraw.Text = String.Empty
        'txtT2TotalAssets.Text = String.Empty
        'txtT2Withdraw.Text = String.Empty
        'txtT2WithdrawAfter.Text = String.Empty
        'txtT2WithdrawLimit.Text = String.Empty
        AvlSellSecGrid.DataRows.Clear()
        lblCeilPriceVL.Text = String.Empty
        lblRefPriceVL.Text = String.Empty
        lblFloorPriceVL.Text = String.Empty
        lblMRPriceVL.Text = String.Empty
        Dim v_ctrl As Windows.Forms.Control
        For Each v_ctrl In pnlBeforeSellInfor.Controls
            If TypeOf (v_ctrl) Is TextBox Then
                CType(v_ctrl, TextBox).Text = String.Empty
                CType(v_ctrl, TextBox).ReadOnly = True
            End If
        Next
        For Each v_ctrl In pnlAfterSellInfor.Controls
            If TypeOf (v_ctrl) Is TextBox Then
                CType(v_ctrl, TextBox).Text = String.Empty
                CType(v_ctrl, TextBox).ReadOnly = True
            End If
        Next
        'txtNMWithdrawAfter.ReadOnly = True
        'txtT2WithdrawAfter.ReadOnly = True
        txtSumSell.Text = String.Empty
        txtSumSellExc.Text = String.Empty
        txtSumSellRemain.Text = String.Empty
        txtSumSell.ReadOnly = True
        txtSumSellExc.ReadOnly = True
        txtSumSellRemain.ReadOnly = True
        mv_strLastAFACCTNO = String.Empty

    End Sub

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

    Private Sub InitializeGrid()
        'Khá»Ÿi táº¡o Grid contacts
        AvlSellSecGrid = New GridEx
        Dim v_cmrContactsHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrContactsHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrContactsHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        v_cmrContactsHeader.HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        AvlSellSecGrid.FixedHeaderRows.Add(v_cmrContactsHeader)

        AvlSellSecGrid.Columns.Add(New Xceed.Grid.Column("TICK", GetType(System.String)))
        AvlSellSecGrid.Columns.Add(New Xceed.Grid.Column("SYMBOL", GetType(System.String)))
        AvlSellSecGrid.Columns.Add(New Xceed.Grid.Column("QUANTITY", GetType(System.Decimal)))
        AvlSellSecGrid.Columns.Add(New Xceed.Grid.Column("SELLQTTY", GetType(System.Decimal)))
        AvlSellSecGrid.Columns.Add(New Xceed.Grid.Column("SELLPRICE", GetType(System.String)))
        AvlSellSecGrid.Columns.Add(New Xceed.Grid.Column("MRRATE", GetType(System.Decimal)))
        AvlSellSecGrid.Columns.Add(New Xceed.Grid.Column("SELLAMT", GetType(System.Decimal)))
        AvlSellSecGrid.Columns.Add(New Xceed.Grid.Column("ROOMREMAIN", GetType(System.Decimal)))
        AvlSellSecGrid.Columns.Add(New Xceed.Grid.Column("SELLEXCAMT", GetType(System.Decimal)))
        AvlSellSecGrid.Columns.Add(New Xceed.Grid.Column("REMAINSELLAMT", GetType(System.Decimal)))
        AvlSellSecGrid.Columns.Add(New Xceed.Grid.Column("CEILPRICE", GetType(System.Decimal)))
        AvlSellSecGrid.Columns.Add(New Xceed.Grid.Column("REFPRICE", GetType(System.Decimal)))
        AvlSellSecGrid.Columns.Add(New Xceed.Grid.Column("FLOORPRICE", GetType(System.Decimal)))
        AvlSellSecGrid.Columns.Add(New Xceed.Grid.Column("MRPRICE", GetType(System.Decimal)))
        AvlSellSecGrid.Columns.Add(New Xceed.Grid.Column("TRADELOT", GetType(System.Decimal)))
        AvlSellSecGrid.Columns.Add(New Xceed.Grid.Column("TRADEUNIT", GetType(System.Decimal)))
        AvlSellSecGrid.Columns.Add(New Xceed.Grid.Column("TRADEPLACE", GetType(System.String)))
        AvlSellSecGrid.Columns.Add(New Xceed.Grid.Column("FEERATE", GetType(System.Decimal)))
        AvlSellSecGrid.Columns.Add(New Xceed.Grid.Column("TAXRATE", GetType(System.Decimal)))
        AvlSellSecGrid.Columns.Add(New Xceed.Grid.Column("ADVRATE", GetType(System.Decimal)))

        AvlSellSecGrid.Columns("TICK").Title = mv_ResourceManager.GetString("TICK")
        AvlSellSecGrid.Columns("SYMBOL").Title = mv_ResourceManager.GetString("SYMBOL")
        AvlSellSecGrid.Columns("QUANTITY").Title = mv_ResourceManager.GetString("QUANTITY")
        AvlSellSecGrid.Columns("SELLQTTY").Title = mv_ResourceManager.GetString("SELLQTTY")
        AvlSellSecGrid.Columns("SELLPRICE").Title = mv_ResourceManager.GetString("SELLPRICE")
        AvlSellSecGrid.Columns("MRRATE").Title = mv_ResourceManager.GetString("MRRATE")
        AvlSellSecGrid.Columns("SELLAMT").Title = mv_ResourceManager.GetString("SELLAMT")
        AvlSellSecGrid.Columns("ROOMREMAIN").Title = mv_ResourceManager.GetString("ROOMREMAIN")
        AvlSellSecGrid.Columns("SELLEXCAMT").Title = mv_ResourceManager.GetString("SELLEXCAMT")
        AvlSellSecGrid.Columns("REMAINSELLAMT").Title = mv_ResourceManager.GetString("REMAINSELLAMT")

        AvlSellSecGrid.Columns("QUANTITY").FormatSpecifier = "#,##0"
        AvlSellSecGrid.Columns("SELLQTTY").FormatSpecifier = "#,##0"
        'AvlSellSecGrid.Columns("SELLPRICE").FormatSpecifier = "#,##0"
        AvlSellSecGrid.Columns("MRRATE").FormatSpecifier = "#,##0"
        AvlSellSecGrid.Columns("SELLAMT").FormatSpecifier = "#,##0"
        AvlSellSecGrid.Columns("ROOMREMAIN").FormatSpecifier = "#,##0"
        AvlSellSecGrid.Columns("SELLEXCAMT").FormatSpecifier = "#,##0"
        AvlSellSecGrid.Columns("REMAINSELLAMT").FormatSpecifier = "#,##0"

        AvlSellSecGrid.Columns("TICK").Width = 15
        AvlSellSecGrid.Columns("SYMBOL").Width = 80
        AvlSellSecGrid.Columns("QUANTITY").Width = 70
        AvlSellSecGrid.Columns("SELLQTTY").Width = 60
        AvlSellSecGrid.Columns("SELLPRICE").Width = 60
        AvlSellSecGrid.Columns("MRRATE").Width = 60
        AvlSellSecGrid.Columns("SELLAMT").Width = 120
        AvlSellSecGrid.Columns("ROOMREMAIN").Width = 70
        AvlSellSecGrid.Columns("SELLEXCAMT").Width = 120
        AvlSellSecGrid.Columns("REMAINSELLAMT").Width = 120
        AvlSellSecGrid.Columns("CEILPRICE").Visible = False
        AvlSellSecGrid.Columns("REFPRICE").Visible = False
        AvlSellSecGrid.Columns("FLOORPRICE").Visible = False
        AvlSellSecGrid.Columns("MRPRICE").Visible = False
        AvlSellSecGrid.Columns("TRADELOT").Visible = False
        AvlSellSecGrid.Columns("TRADEUNIT").Visible = False
        AvlSellSecGrid.Columns("TRADEPLACE").Visible = False
        AvlSellSecGrid.Columns("FEERATE").Visible = False
        AvlSellSecGrid.Columns("TAXRATE").Visible = False
        AvlSellSecGrid.Columns("ADVRATE").Visible = False

        'AvlSellSecGrid.Columns("SELLQTTY").ReadOnly = False
        'AvlSellSecGrid.Columns("SELLPRICE").ReadOnly = False

        Me.pnlAvlSellSec.Controls.Clear()
        Me.pnlAvlSellSec.Controls.Add(AvlSellSecGrid)
        AvlSellSecGrid.Dock = Windows.Forms.DockStyle.Fill
        'AddHandler AvlSellSecGrid.SelectedRowsChanged, AddressOf ODSendCurrentCellChanged
        'If Me.AvlSellSecGrid.DataRowTemplate.Cells.Count >= 0 Then
        '    For i As Integer = 1 To Me.AvlSellSecGrid.DataRowTemplate.Cells.Count - 1
        '        AddHandler AvlSellSecGrid.DataRowTemplate.Cells(i).DoubleClick, AddressOf OnView
        '    Next
        'End If

        If Me.AvlSellSecGrid.DataRowTemplate.Cells.Count >= 0 Then
            For i As Integer = 1 To Me.AvlSellSecGrid.DataRowTemplate.Cells.Count - 1
                AddHandler AvlSellSecGrid.DataRowTemplate.Cells(i).ValueChanged, AddressOf SellSecLeavingEdit
            Next
        End If

        If Me.AvlSellSecGrid.DataRowTemplate.Cells.Count >= 0 Then
            For i As Integer = 1 To Me.AvlSellSecGrid.DataRowTemplate.Cells.Count - 1
                AddHandler AvlSellSecGrid.DataRowTemplate.Cells(i).Click, AddressOf SellSecClickRowChanged
            Next
        End If

        AddHandler AvlSellSecGrid.DataRowTemplate.Cells("TICK").Click, AddressOf SellSecSelectedRowChanged
    End Sub

    Private Sub GetAFContractInfo(ByVal pv_strAFACCTNO As String)
        Try
            If mv_strLastAFACCTNO <> pv_strAFACCTNO Then
                Dim v_nodeList As Xml.XmlNodeList
                Dim v_xmlDocument As New Xml.XmlDocument
                Dim v_strValue, v_strFLDNAME, v_strTEXT As String, i, j As Integer
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                Dim v_strCmdSQL, v_strClause As String, v_strObjMsg As String
                'Chuyen sang dung procedure
                'Goi store cua bao cao CF0040 de lay len thong tin

                v_strCmdSQL = "CF0040"
                v_strClause = "pv_OPT!A!VARCHAR2!20^pv_BRID!ALL!VARCHAR2!20^pv_AFACCTNO!" & pv_strAFACCTNO & "!varchar2!20"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL, v_strClause, , , , , , , gc_CommandProcedure)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                Dim v_decTRFBUYRATE, v_decTRFBUYEXT, v_decBALANCE, v_decSECUREDAMT, v_decADVANCEAMOUNT, v_decPAIDAMT, v_decAVLADVANCE, v_decOUTSTANDING, v_decOUTSTANDINGT2, _
                    v_decNAVACCOUNT, v_decNAVACCOUNTT2, v_decODAMT, v_decOVAMT, v_decTRFBUYAMT, v_decTRFSECUREDAMT_IN, v_decSECUREDAMT_INDAY, v_decTRFSECUREDAMT_INDAY, _
                    v_decADDADVANCELINE_INDAY, v_decTRFT0AMT_OVER, v_decTRFSECUREDAMT_OVER, v_decFIXTRFSECUREAMT, v_decDEPOFEEAMT, v_decDFODAMT, _
                    v_decMRIRATE, v_decMRMRATE, v_decMRLRATE, v_decMARGINRATE, v_decRLSMARGINRATE, v_decMRCRLIMITMAX, v_decADVANCELINE, v_decT0ADVANCE, _
                    v_decAVLLIMIT, v_decAVLLIMITT2, v_decEMKAMT, v_decBALDEFOVD, v_decBALDEFTRFAMT, v_decSYSTRFBUYRATE, v_decSELLNOTMATCHAMT, v_decSELLNOTMATCHEXCAMT, v_decAVLADVAMT As Decimal
                Dim v_strMARGINTYPE, v_strAUTOADV As String
                For i = 0 To v_nodeList.Count - 1
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = Trim(.InnerText.ToString)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "TRFBUYRATE"
                                    v_decTRFBUYRATE = CDec(v_strValue)
                                Case "TRFBUYEXT"
                                    v_decTRFBUYEXT = CDec(v_strValue)
                                Case "BALANCE"
                                    v_decBALANCE = CDec(v_strValue)
                                Case "SECUREDAMT"
                                    v_decSECUREDAMT = CDec(v_strValue)
                                Case "ADVANCEAMOUNT"
                                    v_decADVANCEAMOUNT = CDec(v_strValue)
                                Case "PAIDAMT"
                                    v_decPAIDAMT = CDec(v_strValue)
                                Case "AVLADVANCE"
                                    v_decAVLADVANCE = CDec(v_strValue)
                                Case "OUTSTANDING"
                                    v_decOUTSTANDING = CDec(v_strValue)
                                Case "OUTSTANDINGT2"
                                    v_decOUTSTANDINGT2 = CDec(v_strValue)
                                Case "NAVACCOUNT"
                                    v_decNAVACCOUNT = CDec(v_strValue)
                                Case "NAVACCOUNTT2"
                                    v_decNAVACCOUNTT2 = CDec(v_strValue)
                                Case "ODAMT"
                                    v_decODAMT = CDec(v_strValue)
                                Case "OVAMT"
                                    v_decOVAMT = CDec(v_strValue)
                                Case "TRFBUYAMT"
                                    v_decTRFBUYAMT = CDec(v_strValue)
                                Case "TRFSECUREDAMT_IN"
                                    v_decTRFSECUREDAMT_IN = CDec(v_strValue)
                                Case "SECUREDAMT_INDAY"
                                    v_decSECUREDAMT_INDAY = CDec(v_strValue)
                                Case "TRFSECUREDAMT_INDAY"
                                    v_decTRFSECUREDAMT_INDAY = CDec(v_strValue)
                                Case "ADDADVANCELINE_INDAY"
                                    v_decADDADVANCELINE_INDAY = CDec(v_strValue)
                                Case "TRFT0AMT_OVER"
                                    v_decTRFT0AMT_OVER = CDec(v_strValue)
                                Case "TRFSECUREDAMT_OVER"
                                    v_decTRFSECUREDAMT_OVER = CDec(v_strValue)
                                Case "FIXTRFSECUREAMT"
                                    v_decFIXTRFSECUREAMT = CDec(v_strValue)
                                Case "DEPOFEEAMT"
                                    v_decDEPOFEEAMT = CDec(v_strValue)
                                Case "DFODAMT"
                                    v_decDFODAMT = CDec(v_strValue)
                                Case "MRIRATE"
                                    v_decMRIRATE = CDec(v_strValue)
                                    mv_decMRIRATE = CDec(v_strValue) / 100
                                Case "MRMRATE"
                                    v_decMRMRATE = CDec(v_strValue)
                                Case "MRLRATE"
                                    v_decMRLRATE = CDec(v_strValue)
                                Case "MARGINRATE"
                                    v_decMARGINRATE = CDec(v_strValue)
                                Case "RLSMARGINRATE"
                                    v_decRLSMARGINRATE = CDec(v_strValue)
                                Case "MRCRLIMITMAX"
                                    v_decMRCRLIMITMAX = CDec(v_strValue)
                                Case "ADVANCELINE"
                                    v_decADVANCELINE = CDec(v_strValue)
                                Case "T0ADVANCE"
                                    v_decT0ADVANCE = CDec(v_strValue)
                                Case "AVLLIMIT"
                                    v_decAVLLIMIT = CDec(v_strValue)
                                Case "AVLLIMITT2"
                                    v_decAVLLIMITT2 = CDec(v_strValue)
                                Case "EMKAMT"
                                    v_decEMKAMT = CDec(v_strValue)
                                Case "BALDEFOVD"
                                    v_decBALDEFOVD = CDec(v_strValue)
                                Case "BALDEFTRFAMT"
                                    v_decBALDEFTRFAMT = CDec(v_strValue)
                                Case "MARGINTYPE"
                                    v_strMARGINTYPE = v_strValue
                                Case "SYSTRFBUYRATE"
                                    v_decSYSTRFBUYRATE = CDec(v_strValue)
                                Case "AUTOADV"
                                    v_strAUTOADV = v_strValue
                                    mv_strAUTOADV = v_strValue
                                Case "SELLNOTMATCHAMT"
                                    v_decSELLNOTMATCHAMT = CDec(v_strValue)
                                Case "SELLNOTMATCHEXCAMT"
                                    v_decSELLNOTMATCHEXCAMT = CDec(v_strValue)
                                Case "MRSTATUS"
                                    mv_strMRSTATUS = v_strValue
                                Case "AVLADVAMT"
                                    v_decAVLADVAMT = CDec(v_strValue)
                            End Select
                        End With
                    Next
                Next

                'Tinh toan va hien thi thong tin
                Dim v_decCIDept, v_decT2CIDept, v_decRatWithdraw, v_decT2RatWithdraw, v_decWithdrawLimit, v_decT2WithdrawLimit, v_decT2Amount As Decimal
                'Tien co - no phai tra
                v_decCIDept = v_decBALANCE + v_decSECUREDAMT + v_decAVLADVANCE - v_decOVAMT - v_decDEPOFEEAMT
                'Tien co - no phai tra (tra cham)
                v_decT2CIDept = v_decCIDept
                'Rut dam bao R an toan
                If v_strMARGINTYPE = "N" Then
                    v_decRatWithdraw = 0
                Else
                    v_decRatWithdraw = v_decNAVACCOUNT / (v_decMRIRATE / 100) + v_decOUTSTANDING
                End If
                'Rut dam bao R an toan (tra cham)
                If v_strMARGINTYPE = "N" Then
                    v_decT2RatWithdraw = 0
                Else
                    v_decT2RatWithdraw = v_decNAVACCOUNTT2 / (v_decMRIRATE / 100) + v_decOUTSTANDINGT2
                End If
                'Han muc rut tien
                If v_strMARGINTYPE = "N" Then
                    v_decWithdrawLimit = 0
                Else
                    v_decWithdrawLimit = v_decMRCRLIMITMAX - v_decDFODAMT + v_decOUTSTANDING
                End If
                'Han muc rut tien (tra cham)
                If v_strMARGINTYPE = "N" Then
                    v_decT2WithdrawLimit = 0
                Else
                    v_decT2WithdrawLimit = v_decMRCRLIMITMAX - v_decDFODAMT + v_decOUTSTANDINGT2
                End If
                'Gia tri tra cham
                v_decT2Amount = v_decTRFBUYAMT

                'Hien thi thong tin
                'Rut thong thuong
                txtNormalWithdraw.Text = FormatNumber(CStr(v_decBALDEFOVD), 0)
                txtNormalWithdraw.TextAlign = HorizontalAlignment.Right
                txtNormalWithdraw.ReadOnly = True

                'Rut tra cham
                'txtT2Withdraw.Text = FormatNumber(CStr(v_decBALDEFTRFAMT), 0)
                'txtT2Withdraw.TextAlign = HorizontalAlignment.Right
                'txtT2Withdraw.ReadOnly = True

                'TS quy doi
                txtTotalAssets.Text = FormatNumber(CStr(v_decNAVACCOUNT), 0)
                txtTotalAssets.TextAlign = HorizontalAlignment.Right
                txtTotalAssets.ReadOnly = True

                'TS quy doi (tra cham)
                'txtT2TotalAssets.Text = FormatNumber(CStr(v_decNAVACCOUNTT2), 0)
                'txtT2TotalAssets.TextAlign = HorizontalAlignment.Right
                'txtT2TotalAssets.ReadOnly = True

                'Tien co - no phai tra
                txtCIDebt.Text = FormatNumber(CStr(v_decCIDept), 0)
                txtCIDebt.TextAlign = HorizontalAlignment.Right
                txtCIDebt.ReadOnly = True

                'Tien co - no phai tra (tra cham)
                'txtT2CIDept.Text = FormatNumber(CStr(v_decT2CIDept), 0)
                'txtT2CIDept.TextAlign = HorizontalAlignment.Right
                'txtT2CIDept.ReadOnly = True

                'Rut dam bao R an toan
                txtRatWithdraw.Text = FormatNumber(CStr(v_decRatWithdraw), 0)
                txtRatWithdraw.TextAlign = HorizontalAlignment.Right
                txtRatWithdraw.ReadOnly = True

                'Rut dam bao R an toan (tra cham)
                'txtT2RatWithdraw.Text = FormatNumber(CStr(v_decT2RatWithdraw), 0)
                'txtT2RatWithdraw.TextAlign = HorizontalAlignment.Right
                'txtT2RatWithdraw.ReadOnly = True

                'Han muc rut tien
                txtWithdrawLimit.Text = FormatNumber(CStr(v_decWithdrawLimit), 0)
                txtWithdrawLimit.TextAlign = HorizontalAlignment.Right
                txtWithdrawLimit.ReadOnly = True

                'Han muc rut tien (tra cham)
                'txtT2WithdrawLimit.Text = FormatNumber(CStr(v_decT2WithdrawLimit), 0)
                'txtT2WithdrawLimit.TextAlign = HorizontalAlignment.Right
                'txtT2WithdrawLimit.ReadOnly = True

                'Tu dong ung truoc
                txtAutoAdvance.Text = IIf(v_strAUTOADV = "Y", mv_ResourceManager.GetString("AUTOADVY"), mv_ResourceManager.GetString("AUTOADVN"))
                txtAutoAdvance.TextAlign = HorizontalAlignment.Left
                txtAutoAdvance.ReadOnly = True

                'Gia tri tra cham
                'txtT2Amount.Text = FormatNumber(CStr(v_decT2Amount), 0)
                'txtT2Amount.TextAlign = HorizontalAlignment.Right
                'txtT2Amount.ReadOnly = True

                'Gia tri ban chua khop
                txtSellNotMatchAMT.Text = FormatNumber(CStr(v_decSELLNOTMATCHAMT), 0)
                txtSellNotMatchAMT.TextAlign = HorizontalAlignment.Right
                txtSellNotMatchAMT.ReadOnly = True

                'Gia tri ban chua khop quy doi
                txtSellNotMatchExc.Text = FormatNumber(CStr(v_decSELLNOTMATCHEXCAMT), 0)
                txtSellNotMatchExc.TextAlign = HorizontalAlignment.Right
                txtSellNotMatchExc.ReadOnly = True

                'Gia tri ban chua ung truoc
                txtADVAMT.Text = FormatNumber(CStr(v_decAVLADVAMT), 0)
                txtADVAMT.TextAlign = HorizontalAlignment.Right
                txtADVAMT.ReadOnly = True

                'Lay thong tin CK co the ban
                GetSEInfor(pv_strAFACCTNO)

                'Set lai thong tin
                mv_strLastAFACCTNO = pv_strAFACCTNO

            Else

            End If
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Information, Me.Text)
        End Try
    End Sub

    Private Sub GetSEInfor(ByVal pv_strAFACCTNO As String)
        Dim v_strCmdSQL, v_strObjMsg, v_strClause As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery

        v_strCmdSQL = "GETSECINFO4SELLEST"
        v_strClause = "pv_AFACCTNO!" & pv_strAFACCTNO & "!varchar2!20"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL, v_strClause, , , , , , , gc_CommandProcedure)
        v_ws.Message(v_strObjMsg)

        'v_strCmdSQL = "SELECT SE.AFACCTNO, SEIF.SYMBOL, SE.TRADE + SE.MORTAGE - NVL(OD.SECUREAMT,0) QUANTITY, " & ControlChars.CrLf _
        '            & "     FLOOR((SE.TRADE + SE.MORTAGE - NVL(OD.SECUREAMT,0))/SEIF.TRADELOT)*SEIF.TRADELOT SELLQTTY, SEIF.FLOORPRICE SELLPRICE, " & ControlChars.CrLf _
        '            & "     AFS.MRRATIORATE MRRATE, " & ControlChars.CrLf _
        '            & "     ROUND((FLOOR((SE.TRADE + SE.MORTAGE - NVL(OD.SECUREAMT,0))/SEIF.TRADELOT)*SEIF.TRADELOT)*SEIF.FLOORPRICE*(1 - ODT.DEFFEERATE/100 - TO_NUMBER(SYS.VARVALUE)/100)*(1 - 3*ADT.ADVRATE/360/100)) SELLAMT," & ControlChars.CrLf _
        '            & "     ROUND((FLOOR((SE.TRADE + SE.MORTAGE - NVL(OD.SECUREAMT,0))/SEIF.TRADELOT)*SEIF.TRADELOT) * NVL(AFS.MRRATIORATE,0)/100 * LEAST(NVL(AFS.MRPRICERATE,0), SEIF.MARGINPRICE)) SELLEXCAMT," & ControlChars.CrLf _
        '            & "     ROUND((FLOOR((SE.TRADE + SE.MORTAGE - NVL(OD.SECUREAMT,0))/SEIF.TRADELOT)*SEIF.TRADELOT) * SEIF.FLOORPRICE * (1 - ODT.DEFFEERATE/100 - TO_NUMBER(SYS.VARVALUE)/100)*(1 - 3*ADT.ADVRATE/360/100))" & ControlChars.CrLf _
        '            & "         - ROUND((FLOOR((SE.TRADE + SE.MORTAGE - NVL(OD.SECUREAMT,0))/SEIF.TRADELOT)*SEIF.TRADELOT) * NVL(AFS.MRRATIORATE,0)/100 * LEAST(NVL(AFS.MRPRICERATE,0), SEIF.MARGINPRICE)) REMAINSELLAMT," & ControlChars.CrLf _
        '            & "     SEIF.CEILINGPRICE CEILPRICE, SEIF.BASICPRICE REFPRICE, SEIF.FLOORPRICE FLOORPRICE, LEAST(AFS.MRPRICERATE, SEIF.MARGINPRICE) MRPRICE," & ControlChars.CrLf _
        '            & "     SEIF.TRADELOT, SEIF.TRADEUNIT, SB.TRADEPLACE,  ODT.DEFFEERATE FEERATE, TO_NUMBER(SYS.VARVALUE) TAXRATE, ROUND(3*ADT.ADVRATE/360, 4) ADVRATE" & ControlChars.CrLf _
        '            & " FROM SEMAST SE, SECURITIES_INFO SEIF, SBSECURITIES SB, AFSERISK AFS, AFMAST AF, SYSVAR SYS, ADTYPE ADT, AFTYPE AFT," & ControlChars.CrLf _
        '            & "     (" & ControlChars.CrLf _
        '            & "         SELECT OD.SEACCTNO, SUM(OD.REMAINQTTY + OD.EXECQTTY) SECUREAMT" & ControlChars.CrLf _
        '            & "         FROM ODMAST OD" & ControlChars.CrLf _
        '            & "         WHERE OD.TXDATE = GETCURRDATE AND OD.EXECTYPE IN ('NS','SS','MS') AND OD.DELTD = 'N' " & ControlChars.CrLf _
        '            & "         GROUP BY OD.SEACCTNO" & ControlChars.CrLf _
        '            & "     ) OD, " & ControlChars.CrLf _
        '            & "     (" & ControlChars.CrLf _
        '            & "         SELECT ACTYPE, CODEID, MIN(DEFFEERATE) DEFFEERATE" & ControlChars.CrLf _
        '            & "         FROM " & ControlChars.CrLf _
        '            & "         (" & ControlChars.CrLf _
        '            & "             SELECT AF.ACTYPE, A.DEFFEERATE, SE.CODEID" & ControlChars.CrLf _
        '            & "             FROM ODTYPE A, AFIDTYPE B, AFMAST AF, SEMAST SE, SBSECURITIES SB" & ControlChars.CrLf _
        '            & "             WHERE A.STATUS = 'Y'" & ControlChars.CrLf _
        '            & "                 AND (A.VIA = 'F' OR A.VIA = 'A')" & ControlChars.CrLf _
        '            & "                 AND A.CLEARCD = 'B' " & ControlChars.CrLf _
        '            & "                 AND (A.EXECTYPE = 'NS' OR A.EXECTYPE = 'AA')" & ControlChars.CrLf _
        '            & "                 AND (A.TIMETYPE = 'T' OR A.TIMETYPE = 'A')                     " & ControlChars.CrLf _
        '            & "                 AND (A.PRICETYPE = 'LO' OR A.PRICETYPE = 'AA')" & ControlChars.CrLf _
        '            & "                 AND (A.MATCHTYPE = 'N' OR A.MATCHTYPE = 'A')" & ControlChars.CrLf _
        '            & "                 AND (A.NORK = 'A')" & ControlChars.CrLf _
        '            & "                 AND A.ACTYPE = B.ACTYPE AND B.AFTYPE = AF.ACTYPE AND B.OBJNAME='OD.ODTYPE'" & ControlChars.CrLf _
        '            & "                 AND AF.ACCTNO = '" & pv_strAFACCTNO & "'" & ControlChars.CrLf _
        '            & "                 AND (INSTR(CASE WHEN SB.SECTYPE IN ('001','002') THEN SB.SECTYPE || ',' || '111,333'" & ControlChars.CrLf _
        '            & "                                 WHEN SB.SECTYPE IN ('003','006') THEN SB.SECTYPE || ',' || '222,333,444'" & ControlChars.CrLf _
        '            & "                                 WHEN SB.SECTYPE IN ('008') THEN SB.SECTYPE || ',' || '111,444'" & ControlChars.CrLf _
        '            & "                                 ELSE SB.SECTYPE END, A.SECTYPE)>0 OR A.SECTYPE = '000')" & ControlChars.CrLf _
        '            & "                 AND (CASE WHEN A.CODEID IS NULL THEN SE.CODEID ELSE A.CODEID END)= SE.CODEID" & ControlChars.CrLf _
        '            & "                 AND SE.CODEID = SB.CODEID  AND SE.AFACCTNO = AF.ACCTNO" & ControlChars.CrLf _
        '            & "         ) GROUP BY ACTYPE, CODEID " & ControlChars.CrLf _
        '            & "     ) ODT" & ControlChars.CrLf _
        '            & " WHERE SE.CODEID = SEIF.CODEID AND SE.CODEID = SB.CODEID AND SB.SECTYPE <> '004' " & ControlChars.CrLf _
        '            & "     AND SE.AFACCTNO = AF.ACCTNO AND SE.CODEID = ODT.CODEID " & ControlChars.CrLf _
        '            & "     AND AF.ACTYPE = AFT.ACTYPE AND AFT.ADTYPE = ADT.ACTYPE " & ControlChars.CrLf _
        '            & "     AND ODT.ACTYPE = AFS.ACTYPE (+)" & ControlChars.CrLf _
        '            & "     AND ODT.CODEID = AFS.CODEID (+)" & ControlChars.CrLf _
        '            & "     AND SE.ACCTNO = OD.SEACCTNO (+)" & ControlChars.CrLf _
        '            & "     AND SE.AFACCTNO = '" & pv_strAFACCTNO & "'" & ControlChars.CrLf _
        '            & "     AND SYS.GRNAME = 'SYSTEM' AND SYS.VARNAME = 'ADVSELLDUTY'" & ControlChars.CrLf _
        '            & "     AND SE.TRADE + SE.MORTAGE - NVL(OD.SECUREAMT,0) >0" & ControlChars.CrLf _
        '            & " ORDER BY SEIF.SYMBOL"


        'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL)
        'v_ws.Message(v_strObjMsg)

        FillDataGrid(AvlSellSecGrid, v_strObjMsg, "")
    End Sub

#End Region

#Region " Event "
    Private Sub SellSecClickRowChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            'Hien thi gia CK
            If (AvlSellSecGrid.CurrentCell Is Nothing) Then
                Exit Sub
            End If
            If (AvlSellSecGrid.CurrentRow Is AvlSellSecGrid.HeaderRows) Then
                Exit Sub
            End If
            Dim v_CurrentDataRow As Xceed.Grid.DataRow = AvlSellSecGrid.CurrentRow
            lblCeilPriceVL.Text = FormatNumber(v_CurrentDataRow.Cells("CEILPRICE").Value, 0)
            lblRefPriceVL.Text = FormatNumber(v_CurrentDataRow.Cells("REFPRICE").Value, 0)
            lblFloorPriceVL.Text = FormatNumber(v_CurrentDataRow.Cells("FLOORPRICE").Value, 0)
            lblMRPriceVL.Text = FormatNumber(v_CurrentDataRow.Cells("MRPRICE").Value, 0)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SellSecSelectedRowChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim i, m As Integer
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_strValue, v_strFLDNAME, v_strTEXT As String
        Dim v_strCmdSQL As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_strObjMsg As String

        Try
            Dim v_dblPrice As Double
            If (AvlSellSecGrid.CurrentCell Is Nothing) Then
                Exit Sub
            End If
            If (AvlSellSecGrid.CurrentRow Is AvlSellSecGrid.HeaderRows) Then
                Exit Sub
            End If

            If Me.AvlSellSecGrid.DataRows.Count > 0 Then

                For i = 0 To Me.AvlSellSecGrid.DataRows.Count - 1
                    If (AvlSellSecGrid.CurrentCell Is AvlSellSecGrid.DataRows(i).Cells("TICK")) Then
                        'Chuyen trang thai select cho dong nay
                        If AvlSellSecGrid.DataRows(i).Cells("TICK").Value = Nothing Then
                            AvlSellSecGrid.DataRows(i).Cells("TICK").Value = "X"
                            AvlSellSecGrid.DataRows(i).Cells("SELLQTTY").ReadOnly = False
                            AvlSellSecGrid.DataRows(i).Cells("SELLPRICE").ReadOnly = False
                            'Tinh lai gia tri du tinh
                            SetSumAmount()
                        Else
                            AvlSellSecGrid.DataRows(i).Cells("TICK").Value = Nothing
                            AvlSellSecGrid.DataRows(i).Cells("SELLQTTY").ReadOnly = True
                            AvlSellSecGrid.DataRows(i).Cells("SELLPRICE").ReadOnly = True
                            'Tinh lai gia tri du tinh
                            SetSumAmount()
                        End If
                        Exit For
                    End If
                Next
            End If
            'SetLeftAmount()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub SetSumAmount()
        Try
            Dim V_ReturnAmount As Double = 0
            Dim v_dblReleaseAmount As Double = 0
            Dim v_dblSELLLOSTASS As Double = 0

            If (AvlSellSecGrid.CurrentCell Is Nothing) Then
                Exit Sub
            End If

            If (AvlSellSecGrid.CurrentRow Is AvlSellSecGrid.HeaderRows) Then
                Exit Sub
            End If

            Dim v_decSumSELLAMT, v_decSumSELLEXCAMT, v_decSumREMAINSELLAMT As Decimal
            v_decSumSELLAMT = 0
            v_decSumSELLEXCAMT = 0
            v_decSumREMAINSELLAMT = 0
            For j As Integer = 0 To Me.AvlSellSecGrid.DataRows.Count - 1
                If AvlSellSecGrid.DataRows(j).Cells("TICK").Value = "X" Then
                    v_decSumSELLAMT += AvlSellSecGrid.DataRows(j).Cells("SELLAMT").Value
                    v_decSumSELLEXCAMT += AvlSellSecGrid.DataRows(j).Cells("SELLEXCAMT").Value
                    v_decSumREMAINSELLAMT += AvlSellSecGrid.DataRows(j).Cells("REMAINSELLAMT").Value
                End If
            Next
            txtSumSell.Text = FormatNumber(CStr(v_decSumSELLAMT), 0)
            txtSumSell.TextAlign = HorizontalAlignment.Right
            txtSumSell.ReadOnly = True
            txtSumSellExc.Text = FormatNumber(CStr(v_decSumSELLEXCAMT), 0)
            txtSumSellExc.TextAlign = HorizontalAlignment.Right
            txtSumSellExc.ReadOnly = True
            txtSumSellRemain.Text = FormatNumber(CStr(v_decSumREMAINSELLAMT), 0)
            txtSumSellRemain.TextAlign = HorizontalAlignment.Right
            txtSumSellRemain.ReadOnly = True

            'Du tinh so tien rut sau khi ban
            Dim v_decCash, v_decRatWithdraw, v_decWithdrawLimit As Decimal
            'Dim v_decT2Cash, v_decT2RatWithdraw, v_decT2WithdrawLimit As Decimal
            If mv_strMRSTATUS = "Y" And mv_strAUTOADV = "Y" Then
                'Rut thuong
                v_decCash = CDec(txtCIDebt.Text) + CDec(txtSellNotMatchAMT.Text) + CDec(txtSumSell.Text)
                v_decRatWithdraw = CDec(txtRatWithdraw.Text) + CDec(txtSellNotMatchAMT.Text) - Math.Round(CDec(txtSellNotMatchExc.Text) / mv_decMRIRATE) + CDec(txtSumSellRemain.Text)
                v_decWithdrawLimit = CDec(txtWithdrawLimit.Text) + CDec(txtSellNotMatchAMT.Text) + CDec(txtSumSell.Text)
                'Set gia tri
                txtNMWithdrawAfter.Text = FormatNumber(CStr(Math.Min(Math.Min(v_decCash, v_decRatWithdraw), v_decWithdrawLimit)), 0)
                txtNMWithdrawAfter.TextAlign = HorizontalAlignment.Right
                txtNMWithdrawAfter.ForeColor = Color.Red

                'Rut tra cham
                'v_decT2Cash = CDec(txtT2CIDept.Text) + CDec(txtSellNotMatchAMT.Text) + CDec(txtSumSell.Text)
                'v_decT2RatWithdraw = CDec(txtT2RatWithdraw.Text) + CDec(txtSellNotMatchAMT.Text) - Math.Round(CDec(txtSellNotMatchExc.Text) / mv_decMRIRATE) + CDec(txtSumSellRemain.Text)
                'v_decT2WithdrawLimit = CDec(txtT2WithdrawLimit.Text) + CDec(txtSellNotMatchAMT.Text) + CDec(txtSumSell.Text)
                'Set gia tri
                'txtT2WithdrawAfter.Text = FormatNumber(CStr(Math.Min(Math.Min(v_decT2Cash, v_decT2RatWithdraw), v_decT2WithdrawLimit)), 0)
                'txtT2WithdrawAfter.TextAlign = HorizontalAlignment.Right
                'txtT2WithdrawAfter.ForeColor = Color.Red
            ElseIf mv_strMRSTATUS = "N" And mv_strAUTOADV = "Y" Then
                'Rut thuong
                v_decCash = CDec(txtCIDebt.Text) + CDec(txtSellNotMatchAMT.Text) + CDec(txtSumSell.Text)
                'Set gia tri
                txtNMWithdrawAfter.Text = FormatNumber(CStr(v_decCash), 0)
                txtNMWithdrawAfter.TextAlign = HorizontalAlignment.Right
                txtNMWithdrawAfter.ForeColor = Color.Red

                'Rut tra cham
                'v_decT2Cash = CDec(txtT2CIDept.Text) + CDec(txtSellNotMatchAMT.Text) + CDec(txtSumSell.Text)
                'Set gia tri
                'txtT2WithdrawAfter.Text = FormatNumber(CStr(v_decT2Cash), 0)
                'txtT2WithdrawAfter.TextAlign = HorizontalAlignment.Right
                'txtT2WithdrawAfter.ForeColor = Color.Red
            ElseIf mv_strMRSTATUS = "N" And mv_strAUTOADV = "N" Then
                'Rut thuong
                v_decCash = CDec(txtCIDebt.Text) + CDec(txtSellNotMatchAMT.Text) + CDec(txtSumSell.Text) + CDec(txtADVAMT.Text)
                'Set gia tri
                txtNMWithdrawAfter.Text = FormatNumber(CStr(v_decCash), 0)
                txtNMWithdrawAfter.TextAlign = HorizontalAlignment.Right
                txtNMWithdrawAfter.ForeColor = Color.Red

                'Rut tra cham
                'v_decT2Cash = CDec(txtT2CIDept.Text) + CDec(txtSellNotMatchAMT.Text) + CDec(txtSumSell.Text) + CDec(txtADVAMT.Text)
                'Set gia tri
                'txtT2WithdrawAfter.Text = FormatNumber(CStr(v_decT2Cash), 0)
                'txtT2WithdrawAfter.TextAlign = HorizontalAlignment.Right
                'txtT2WithdrawAfter.ForeColor = Color.Red
            End If
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            'MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Throw ex
        End Try
    End Sub

    Private Sub SellSecLeavingEdit(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If (AvlSellSecGrid.CurrentCell Is Nothing) Then
                Exit Sub
            End If
            If (AvlSellSecGrid.CurrentRow Is AvlSellSecGrid.HeaderRows) Then
                Exit Sub
            End If
            Dim v_CurrentDataRow As Xceed.Grid.DataRow = AvlSellSecGrid.CurrentRow
            If v_CurrentDataRow.Cells("TICK").Value <> "X" Then
                Exit Sub
            End If

            Dim i As Integer
            Dim v_dblPrice As Double
            Dim v_strTradePlace, v_strSYMBOL As String
            Dim v_decTradeLot, v_decTradeUnit, v_decTaxRate, v_decFeeRate, v_decMRRATE, v_decMRPRICE, v_decFLOORPRICE, v_decCEILPRICE, v_decADVRATE, v_decROOMREMAIN As Decimal
            Dim v_decSELLAMT, v_decSELLEXCAMT, v_decREMAINSELLAMT, v_decSELLPRICE, v_decSumSELLAMT, v_decSumSELLEXCAMT, v_decSumREMAINSELLAMT As Decimal
            'Dim v_CurrentDataRow As Xceed.Grid.DataRow = AvlSellSecGrid.CurrentRow

            If Me.AvlSellSecGrid.DataRows.Count > 0 Then
                For i = 0 To Me.AvlSellSecGrid.DataRows.Count - 1
                    If AvlSellSecGrid.DataRows(i) Is AvlSellSecGrid.CurrentRow Then
                        v_strTradePlace = CStr(AvlSellSecGrid.DataRows(i).Cells("TRADEPLACE").Value)
                        v_strSYMBOL = CStr(AvlSellSecGrid.DataRows(i).Cells("SYMBOL").Value)
                        v_decTradeLot = CDec(AvlSellSecGrid.DataRows(i).Cells("TRADELOT").Value)
                        v_decTradeUnit = CDec(AvlSellSecGrid.DataRows(i).Cells("TRADEUNIT").Value)
                        v_decTaxRate = CDec(AvlSellSecGrid.DataRows(i).Cells("TAXRATE").Value)
                        v_decFeeRate = CDec(AvlSellSecGrid.DataRows(i).Cells("FEERATE").Value)
                        v_decMRRATE = CDec(AvlSellSecGrid.DataRows(i).Cells("MRRATE").Value)
                        v_decMRPRICE = CDec(AvlSellSecGrid.DataRows(i).Cells("MRPRICE").Value)
                        v_decFLOORPRICE = CDec(AvlSellSecGrid.DataRows(i).Cells("FLOORPRICE").Value)
                        v_decCEILPRICE = CDec(AvlSellSecGrid.DataRows(i).Cells("CEILPRICE").Value)
                        v_decADVRATE = CDec(AvlSellSecGrid.DataRows(i).Cells("ADVRATE").Value)
                        v_decROOMREMAIN = CDec(AvlSellSecGrid.DataRows(i).Cells("ROOMREMAIN").Value)
                    End If

                    If (AvlSellSecGrid.DataRows(i).Cells("SELLQTTY") Is AvlSellSecGrid.CurrentCell) Then
                        'Chuyen trang thai select cho dong nay
                        If Not IsNumeric(AvlSellSecGrid.CurrentCell.Value) Then
                            MessageBox.Show(mv_ResourceManager.GetString("INVALID_NUMERIC"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            AvlSellSecGrid.DataRows(i).Cells("SELLQTTY").Value = Math.Floor(AvlSellSecGrid.DataRows(i).Cells("QUANTITY").Value / v_decTradeLot) * v_decTradeLot
                            'e.Cancel = True
                            'Exit Sub
                        Else
                            If CDbl(AvlSellSecGrid.CurrentCell.Value) Mod v_decTradeLot <> 0 Then
                                MessageBox.Show(mv_ResourceManager.GetString("INVALID_TRADELOT"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                AvlSellSecGrid.DataRows(i).Cells("SELLQTTY").Value = Math.Floor(AvlSellSecGrid.DataRows(i).Cells("QUANTITY").Value / v_decTradeLot) * v_decTradeLot
                                'e.Cancel = True
                                'Exit Sub
                            End If
                            If CDbl(AvlSellSecGrid.CurrentCell.Value) > AvlSellSecGrid.DataRows(i).Cells("QUANTITY").Value Then
                                MessageBox.Show(mv_ResourceManager.GetString("OVER_SELLQTTY"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                AvlSellSecGrid.DataRows(i).Cells("SELLQTTY").Value = Math.Floor(AvlSellSecGrid.DataRows(i).Cells("QUANTITY").Value / v_decTradeLot) * v_decTradeLot
                                'e.Cancel = True
                                'Exit Sub
                            End If
                            'Tinh toan lai gia tri ban
                            v_decSELLPRICE = IIf(InStr("ATO/ATC/MP", AvlSellSecGrid.DataRows(i).Cells("SELLPRICE").Value) > 0, v_decFLOORPRICE, CDec(AvlSellSecGrid.DataRows(i).Cells("SELLPRICE").Value))
                            v_decSELLAMT = Math.Round(CDec(AvlSellSecGrid.DataRows(i).Cells("SELLQTTY").Value) * v_decSELLPRICE * (1 - v_decFeeRate / 100 - v_decTaxRate / 100) * (1 - v_decADVRATE / 100))
                            v_decSELLEXCAMT = Math.Round(Math.Min(CDec(AvlSellSecGrid.DataRows(i).Cells("SELLQTTY").Value), v_decROOMREMAIN) * v_decMRRATE / 100 * v_decMRPRICE)
                            v_decREMAINSELLAMT = v_decSELLAMT - Math.Round(v_decSELLEXCAMT / mv_decMRIRATE)

                            'Set lai gia tri tren grid
                            AvlSellSecGrid.DataRows(i).Cells("SELLAMT").Value = v_decSELLAMT
                            AvlSellSecGrid.DataRows(i).Cells("SELLEXCAMT").Value = v_decSELLEXCAMT
                            AvlSellSecGrid.DataRows(i).Cells("REMAINSELLAMT").Value = v_decREMAINSELLAMT
                            'Tinh gia tri tong                       
                            SetSumAmount()
                        End If
                    ElseIf (AvlSellSecGrid.DataRows(i).Cells("SELLPRICE") Is AvlSellSecGrid.CurrentCell) Then
                        If Not IsNumeric(AvlSellSecGrid.CurrentCell.Value) Then
                            If v_strTradePlace = "001" Then
                                'San HOSE
                                If (UCase(CStr(AvlSellSecGrid.CurrentCell.Value)) <> "ATO" And UCase(CStr(AvlSellSecGrid.CurrentCell.Value)) <> "ATC" And UCase(CStr(AvlSellSecGrid.CurrentCell.Value)) <> "MP") Then
                                    MessageBox.Show(mv_ResourceManager.GetString("INVALID_LIMIT_PRICE_HO"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    AvlSellSecGrid.DataRows(i).Cells("SELLPRICE").Value = CStr(v_decFLOORPRICE)
                                    'e.Cancel = True
                                    'Exit Sub
                                Else
                                    AvlSellSecGrid.CurrentCell.Value = UCase(AvlSellSecGrid.CurrentCell.Value)
                                End If
                            ElseIf v_strTradePlace = "002" Then
                                'San HNX
                                MessageBox.Show(mv_ResourceManager.GetString("INVALID_LIMIT_PRICE"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                AvlSellSecGrid.DataRows(i).Cells("SELLPRICE").Value = CStr(v_decFLOORPRICE)
                                'e.Cancel = True
                                'Exit Sub
                            Else
                                MessageBox.Show(mv_ResourceManager.GetString("INVALID_LIMIT_PRICE"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                AvlSellSecGrid.DataRows(i).Cells("SELLPRICE").Value = CStr(v_decFLOORPRICE)
                                'e.Cancel = True
                                'Exit Sub
                            End If

                            'Tinh toan lai gia tri ban
                            v_decSELLPRICE = IIf(InStr("ATO/ATC/MP", AvlSellSecGrid.DataRows(i).Cells("SELLPRICE").Value) > 0, v_decFLOORPRICE, CDec(AvlSellSecGrid.DataRows(i).Cells("SELLPRICE").Value))
                            v_decSELLAMT = Math.Round(CDec(AvlSellSecGrid.DataRows(i).Cells("SELLQTTY").Value) * v_decSELLPRICE * (1 - v_decFeeRate / 100 - v_decTaxRate / 100) * (1 - v_decADVRATE / 100))
                            v_decSELLEXCAMT = Math.Round(Math.Min(CDec(AvlSellSecGrid.DataRows(i).Cells("SELLQTTY").Value), v_decROOMREMAIN) * v_decMRRATE / 100 * v_decMRPRICE)
                            v_decREMAINSELLAMT = v_decSELLAMT - Math.Round(v_decSELLEXCAMT / mv_decMRIRATE)
                            'Set lai gia tri tren grid
                            AvlSellSecGrid.DataRows(i).Cells("SELLAMT").Value = v_decSELLAMT
                            AvlSellSecGrid.DataRows(i).Cells("SELLEXCAMT").Value = v_decSELLEXCAMT
                            AvlSellSecGrid.DataRows(i).Cells("REMAINSELLAMT").Value = v_decREMAINSELLAMT
                            'Tinh gia tri tong                       
                            SetSumAmount()
                        Else
                            'Gia limit
                            'Kiem tra tran san
                            If CDbl(AvlSellSecGrid.CurrentCell.Value) > v_decCEILPRICE Or CDbl(AvlSellSecGrid.CurrentCell.Value) < v_decFLOORPRICE Then
                                MessageBox.Show(mv_ResourceManager.GetString("INVALID_FLOOR_CEILING_PRICE"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                AvlSellSecGrid.DataRows(i).Cells("SELLPRICE").Value = CStr(v_decFLOORPRICE)
                                'e.Cancel = True
                                'Exit Sub
                            End If
                            'Kiem tra ticksize
                            Dim v_nodeList As Xml.XmlNodeList
                            Dim v_xmlDocument As New Xml.XmlDocument
                            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                            Dim v_strSQL As String, v_strObjMsg As String
                            v_decSELLPRICE = CDec(AvlSellSecGrid.CurrentCell.Value)

                            v_strSQL = "SELECT FROMPRICE, TOPRICE, TICKSIZE FROM SECURITIES_TICKSIZE WHERE SYMBOL = '" & v_strSYMBOL & "' AND (FROMPRICE<=" & v_decSELLPRICE & " AND TOPRICE>=" & v_decSELLPRICE & " ) AND MOD(" & v_decSELLPRICE & ",TICKSIZE) = 0"
                            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
                            v_ws.Message(v_strObjMsg)
                            v_xmlDocument.LoadXml(v_strObjMsg)
                            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                            If v_nodeList.Count = 0 Then
                                MessageBox.Show(mv_ResourceManager.GetString("INVALID_TICKSIZE"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                AvlSellSecGrid.DataRows(i).Cells("SELLPRICE").Value = CStr(v_decFLOORPRICE)
                            End If

                            'Tinh toan lai gia tri ban
                            'v_decSELLPRICE = IIf(InStr("ATO/ATC/MP", AvlSellSecGrid.DataRows(i).Cells("SELLPRICE").Value) > 0, v_decFLOORPRICE, CDec(AvlSellSecGrid.DataRows(i).Cells("SELLPRICE").Value))
                            v_decSELLAMT = Math.Round(CDec(AvlSellSecGrid.DataRows(i).Cells("SELLQTTY").Value) * v_decSELLPRICE * (1 - v_decFeeRate / 100 - v_decTaxRate / 100) * (1 - v_decADVRATE / 100))
                            v_decSELLEXCAMT = Math.Round(Math.Min(CDec(AvlSellSecGrid.DataRows(i).Cells("SELLQTTY").Value), v_decROOMREMAIN) * v_decMRRATE / 100 * v_decMRPRICE)
                            v_decREMAINSELLAMT = v_decSELLAMT - Math.Round(v_decSELLEXCAMT / mv_decMRIRATE)
                            'Set lai gia tri tren grid
                            AvlSellSecGrid.DataRows(i).Cells("SELLAMT").Value = v_decSELLAMT
                            AvlSellSecGrid.DataRows(i).Cells("SELLEXCAMT").Value = v_decSELLEXCAMT
                            AvlSellSecGrid.DataRows(i).Cells("REMAINSELLAMT").Value = v_decREMAINSELLAMT
                            'Tinh gia tri tong                       
                            SetSumAmount()
                        End If
                    Else

                    End If
                Next
            End If
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            'MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Throw ex
        End Try
    End Sub

#End Region

#Region "Form events"
    Private Sub frmSellEstimate2CIWithdraw_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                OnClose()
            Case Keys.F5
                If Me.ActiveControl.Name = "txtCUSTODYCD" And Me.txtCUSTODYCD.ReadOnly = False Then
                    Dim frm As New frmSearch(Me.UserLanguage)
                    frm.TableName = "CUSTODYCD_CF"
                    frm.ModuleCode = "CF"
                    frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                    frm.IsLocalSearch = gc_IsNotLocalMsg
                    frm.IsLookup = "Y"
                    frm.SearchOnInit = False
                    frm.BranchId = Me.BranchId
                    frm.TellerId = Me.TellerId
                    frm.GroupCareBy = True
                    frm.CareByFilter = True
                    frm.ShowDialog()
                    Me.ActiveControl.Text = Trim(frm.ReturnValue)
                    frm.Dispose()
                End If
        End Select
    End Sub

    Private Sub txtCUSTODYCD_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCUSTODYCD.Validating
        Try
            Dim v_strCMDSQL, v_strObjMsg As String
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
            Me.txtCUSTODYCD.Text = Me.txtCUSTODYCD.Text.ToUpper()
            ResetScreen(Me)
            'Lay thong tin tieu khoan
            v_strCMDSQL = "SELECT FILTERCD, VALUE, VALUECD, DISPLAY || ' - ' || DESCRIPTION DISPLAY, EN_DISPLAY || ' - ' || DESCRIPTION EN_DISPLAY, DESCRIPTION " & ControlChars.CrLf _
                        & "FROM VW_CUSTODYCD_SUBACCOUNT_ACTIVE WHERE FILTERCD='" & Trim(Me.txtCUSTODYCD.Text) & "' ORDER BY VALUE"

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCMDSQL)
            v_ws.Message(v_strObjMsg)
            FillComboEx(v_strObjMsg, Me.cboAFACCTNO, "", Me.UserLanguage)
            If Me.cboAFACCTNO.Items.Count > 0 Then
                Me.cboAFACCTNO.SelectedIndex = 0
                'Lấy thông tin
                GetAFContractInfo(cboAFACCTNO.SelectedValue.ToString().Replace(".", ""))
            Else
                MsgBox(mv_ResourceManager.GetString("ERR_CF_CONTRACT_NOT_FOUND"), MsgBoxStyle.Information, Me.Text)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cboAFACCTNO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAFACCTNO.SelectedIndexChanged
        Try
            GetAFContractInfo(cboAFACCTNO.SelectedValue.ToString().Replace(".", ""))
        Catch ex As Exception

        End Try
    End Sub
#End Region

    
End Class
