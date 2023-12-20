<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBrokerDesk
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.cboAFAcctno = New System.Windows.Forms.ComboBox
        Me.lblCustomerInfo = New System.Windows.Forms.Label
        Me.txtFeedback = New System.Windows.Forms.TextBox
        Me.lblLinkType = New System.Windows.Forms.Label
        Me.pnODFixedArea = New System.Windows.Forms.Panel
        Me.btnOrder = New System.Windows.Forms.Button
        Me.lblBorrowCustodycd = New System.Windows.Forms.Label
        Me.cboBorrowAFAcctno = New System.Windows.Forms.ComboBox
        Me.mskBorrowCustodycd = New System.Windows.Forms.MaskedTextBox
        Me.btnGetDeal = New System.Windows.Forms.Button
        Me.lblDeal = New System.Windows.Forms.Label
        Me.lblOrderType = New System.Windows.Forms.Label
        Me.cboExecType = New System.Windows.Forms.ComboBox
        Me.cboPriceType = New System.Windows.Forms.ComboBox
        Me.mskDFNo = New System.Windows.Forms.MaskedTextBox
        Me.pnODWorkingArea = New System.Windows.Forms.Panel
        Me.lblPrice = New System.Windows.Forms.Label
        Me.lblSplitValue = New System.Windows.Forms.Label
        Me.mskSplitValue = New System.Windows.Forms.MaskedTextBox
        Me.lblCustodyCD = New System.Windows.Forms.Label
        Me.mskCriteriaValue = New System.Windows.Forms.MaskedTextBox
        Me.lblQtty = New System.Windows.Forms.Label
        Me.lblSymbol = New System.Windows.Forms.Label
        Me.mskQtty = New System.Windows.Forms.MaskedTextBox
        Me.mskPrice = New System.Windows.Forms.MaskedTextBox
        Me.mskSymbol = New System.Windows.Forms.MaskedTextBox
        Me.tabCtrlAccount = New System.Windows.Forms.TabControl
        Me.tabPageAccount = New System.Windows.Forms.TabPage
        Me.ChkByUser = New System.Windows.Forms.CheckBox
        Me.pnSYMINFO = New System.Windows.Forms.Panel
        Me.dgSYMINFO = New System.Windows.Forms.DataGridView
        Me.SymFldName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SymFldValue = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pbSYMMKTDEEP = New System.Windows.Forms.Panel
        Me.dgSYMMKTDEEP = New System.Windows.Forms.DataGridView
        Me.lblSYM = New System.Windows.Forms.Label
        Me.lblExchangeName = New System.Windows.Forms.Label
        Me.pnSYMBIDASK = New System.Windows.Forms.Panel
        Me.dgSYMBIDOFFER = New System.Windows.Forms.DataGridView
        Me.pnSYMTRADELOG = New System.Windows.Forms.Panel
        Me.dgSYMTRADELOG = New System.Windows.Forms.DataGridView
        Me.pnSecuritiesInfo = New System.Windows.Forms.Panel
        Me.dgStocks = New System.Windows.Forms.DataGridView
        Me.pnOrders = New System.Windows.Forms.Panel
        Me.dgOrderBook = New System.Windows.Forms.DataGridView
        Me.pnOption = New System.Windows.Forms.Panel
        Me.cboCFSrchCriteria = New System.Windows.Forms.ComboBox
        Me.lblParameter = New System.Windows.Forms.Label
        Me.cboSplitOption = New System.Windows.Forms.ComboBox
        Me.cboOption = New System.Windows.Forms.ComboBox
        Me.lblOption = New System.Windows.Forms.Label
        Me.pnCashInfo = New System.Windows.Forms.Panel
        Me.dgCash = New System.Windows.Forms.DataGridView
        Me.CashFldName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CashFldValue = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tabPageSecurities = New System.Windows.Forms.TabPage
        Me.dgSecurities = New System.Windows.Forms.DataGridView
        Me.tabPageLoan = New System.Windows.Forms.TabPage
        Me.dgLoan = New System.Windows.Forms.DataGridView
        Me.tabPageDeal = New System.Windows.Forms.TabPage
        Me.dgTrades = New System.Windows.Forms.DataGridView
        Me.tabPageMoveDeal = New System.Windows.Forms.TabPage
        Me.pnCurrentDeal = New System.Windows.Forms.Panel
        Me.dgMoveDeal = New System.Windows.Forms.DataGridView
        Me.pnDealArea = New System.Windows.Forms.Panel
        Me.lblTotalDealMoving = New System.Windows.Forms.Label
        Me.btnMoveDeal = New System.Windows.Forms.Button
        Me.lblDealType = New System.Windows.Forms.Label
        Me.cboDealType = New System.Windows.Forms.ComboBox
        Me.mskDealSymbol = New System.Windows.Forms.MaskedTextBox
        Me.cboDealAFAcctno = New System.Windows.Forms.ComboBox
        Me.lblDealAFACCTNO = New System.Windows.Forms.Label
        Me.lblDealSymbol = New System.Windows.Forms.Label
        Me.tabPageCustomer = New System.Windows.Forms.TabPage
        Me.dgAssets = New System.Windows.Forms.DataGridView
        Me.tabPageOrders = New System.Windows.Forms.TabPage
        Me.dgRemainOrder = New System.Windows.Forms.DataGridView
        Me.ctxDataGrid = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Export2ExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ctxSelectAll = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SelectedAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NoSelectedAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.btnUserOrder = New System.Windows.Forms.Button
        Me.ctxMoveOrder = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.pnStatus = New System.Windows.Forms.Panel
        Me.lblHelp = New System.Windows.Forms.Label
        Me.lblSystemParameters = New System.Windows.Forms.Label
        Me.lblSymbolInfo = New System.Windows.Forms.RichTextBox
        Me.RadioCustodyCd = New System.Windows.Forms.RadioButton
        Me.RadioSubAcctno = New System.Windows.Forms.RadioButton
        Me.chkAutoRefresh = New System.Windows.Forms.CheckBox
        Me.pnODFixedArea.SuspendLayout()
        Me.pnODWorkingArea.SuspendLayout()
        Me.tabCtrlAccount.SuspendLayout()
        Me.tabPageAccount.SuspendLayout()
        Me.pnSYMINFO.SuspendLayout()
        CType(Me.dgSYMINFO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pbSYMMKTDEEP.SuspendLayout()
        CType(Me.dgSYMMKTDEEP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnSYMBIDASK.SuspendLayout()
        CType(Me.dgSYMBIDOFFER, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnSYMTRADELOG.SuspendLayout()
        CType(Me.dgSYMTRADELOG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnSecuritiesInfo.SuspendLayout()
        CType(Me.dgStocks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnOrders.SuspendLayout()
        CType(Me.dgOrderBook, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnOption.SuspendLayout()
        Me.pnCashInfo.SuspendLayout()
        CType(Me.dgCash, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPageSecurities.SuspendLayout()
        CType(Me.dgSecurities, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPageLoan.SuspendLayout()
        CType(Me.dgLoan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPageDeal.SuspendLayout()
        CType(Me.dgTrades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPageMoveDeal.SuspendLayout()
        Me.pnCurrentDeal.SuspendLayout()
        CType(Me.dgMoveDeal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnDealArea.SuspendLayout()
        Me.tabPageCustomer.SuspendLayout()
        CType(Me.dgAssets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPageOrders.SuspendLayout()
        CType(Me.dgRemainOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxDataGrid.SuspendLayout()
        Me.ctxSelectAll.SuspendLayout()
        Me.pnStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboAFAcctno
        '
        Me.cboAFAcctno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAFAcctno.FormattingEnabled = True
        Me.cboAFAcctno.Location = New System.Drawing.Point(580, 84)
        Me.cboAFAcctno.Name = "cboAFAcctno"
        Me.cboAFAcctno.Size = New System.Drawing.Size(438, 21)
        Me.cboAFAcctno.TabIndex = 5
        '
        'lblCustomerInfo
        '
        Me.lblCustomerInfo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblCustomerInfo.BackColor = System.Drawing.Color.Black
        Me.lblCustomerInfo.ForeColor = System.Drawing.Color.White
        Me.lblCustomerInfo.Location = New System.Drawing.Point(1, 84)
        Me.lblCustomerInfo.Name = "lblCustomerInfo"
        Me.lblCustomerInfo.Size = New System.Drawing.Size(1017, 28)
        Me.lblCustomerInfo.TabIndex = 4
        Me.lblCustomerInfo.Text = "lblCustomerInfo"
        Me.lblCustomerInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFeedback
        '
        Me.txtFeedback.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtFeedback.BackColor = System.Drawing.Color.Black
        Me.txtFeedback.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFeedback.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFeedback.ForeColor = System.Drawing.Color.Yellow
        Me.txtFeedback.Location = New System.Drawing.Point(1, 109)
        Me.txtFeedback.Multiline = True
        Me.txtFeedback.Name = "txtFeedback"
        Me.txtFeedback.ReadOnly = True
        Me.txtFeedback.Size = New System.Drawing.Size(1017, 26)
        Me.txtFeedback.TabIndex = 6
        Me.txtFeedback.Text = "Thông báo từ máy chủ"
        '
        'lblLinkType
        '
        Me.lblLinkType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLinkType.ForeColor = System.Drawing.Color.Black
        Me.lblLinkType.Location = New System.Drawing.Point(476, 1)
        Me.lblLinkType.Name = "lblLinkType"
        Me.lblLinkType.Size = New System.Drawing.Size(178, 56)
        Me.lblLinkType.TabIndex = 3
        Me.lblLinkType.Text = "lblLinkType"
        Me.lblLinkType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnODFixedArea
        '
        Me.pnODFixedArea.Controls.Add(Me.btnOrder)
        Me.pnODFixedArea.Controls.Add(Me.lblBorrowCustodycd)
        Me.pnODFixedArea.Controls.Add(Me.cboBorrowAFAcctno)
        Me.pnODFixedArea.Controls.Add(Me.mskBorrowCustodycd)
        Me.pnODFixedArea.Controls.Add(Me.btnGetDeal)
        Me.pnODFixedArea.Controls.Add(Me.lblDeal)
        Me.pnODFixedArea.Controls.Add(Me.lblOrderType)
        Me.pnODFixedArea.Controls.Add(Me.cboExecType)
        Me.pnODFixedArea.Controls.Add(Me.cboPriceType)
        Me.pnODFixedArea.Controls.Add(Me.mskDFNo)
        Me.pnODFixedArea.Controls.Add(Me.lblLinkType)
        Me.pnODFixedArea.Location = New System.Drawing.Point(364, 24)
        Me.pnODFixedArea.Name = "pnODFixedArea"
        Me.pnODFixedArea.Size = New System.Drawing.Size(654, 57)
        Me.pnODFixedArea.TabIndex = 2
        '
        'btnOrder
        '
        Me.btnOrder.Location = New System.Drawing.Point(202, 26)
        Me.btnOrder.Name = "btnOrder"
        Me.btnOrder.Size = New System.Drawing.Size(75, 23)
        Me.btnOrder.TabIndex = 12
        Me.btnOrder.Text = "Đặt"
        Me.btnOrder.UseVisualStyleBackColor = True
        '
        'lblBorrowCustodycd
        '
        Me.lblBorrowCustodycd.AutoSize = True
        Me.lblBorrowCustodycd.Location = New System.Drawing.Point(116, 9)
        Me.lblBorrowCustodycd.Name = "lblBorrowCustodycd"
        Me.lblBorrowCustodycd.Size = New System.Drawing.Size(90, 13)
        Me.lblBorrowCustodycd.TabIndex = 11
        Me.lblBorrowCustodycd.Text = "BorrowCustodycd"
        '
        'cboBorrowAFAcctno
        '
        Me.cboBorrowAFAcctno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBorrowAFAcctno.FormattingEnabled = True
        Me.cboBorrowAFAcctno.Location = New System.Drawing.Point(206, 26)
        Me.cboBorrowAFAcctno.Name = "cboBorrowAFAcctno"
        Me.cboBorrowAFAcctno.Size = New System.Drawing.Size(438, 21)
        Me.cboBorrowAFAcctno.TabIndex = 10
        '
        'mskBorrowCustodycd
        '
        Me.mskBorrowCustodycd.Location = New System.Drawing.Point(113, 27)
        Me.mskBorrowCustodycd.Name = "mskBorrowCustodycd"
        Me.mskBorrowCustodycd.Size = New System.Drawing.Size(87, 20)
        Me.mskBorrowCustodycd.TabIndex = 9
        Me.mskBorrowCustodycd.Text = "017C"
        '
        'btnGetDeal
        '
        Me.btnGetDeal.Location = New System.Drawing.Point(233, 25)
        Me.btnGetDeal.Name = "btnGetDeal"
        Me.btnGetDeal.Size = New System.Drawing.Size(18, 23)
        Me.btnGetDeal.TabIndex = 4
        Me.btnGetDeal.Text = "?"
        Me.btnGetDeal.UseVisualStyleBackColor = True
        '
        'lblDeal
        '
        Me.lblDeal.AutoSize = True
        Me.lblDeal.Location = New System.Drawing.Point(121, 9)
        Me.lblDeal.Name = "lblDeal"
        Me.lblDeal.Size = New System.Drawing.Size(39, 13)
        Me.lblDeal.TabIndex = 3
        Me.lblDeal.Text = "Label1"
        '
        'lblOrderType
        '
        Me.lblOrderType.AutoSize = True
        Me.lblOrderType.Location = New System.Drawing.Point(8, 8)
        Me.lblOrderType.Name = "lblOrderType"
        Me.lblOrderType.Size = New System.Drawing.Size(39, 13)
        Me.lblOrderType.TabIndex = 0
        Me.lblOrderType.Text = "Label1"
        '
        'cboExecType
        '
        Me.cboExecType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboExecType.FormattingEnabled = True
        Me.cboExecType.Location = New System.Drawing.Point(2, 27)
        Me.cboExecType.Name = "cboExecType"
        Me.cboExecType.Size = New System.Drawing.Size(109, 21)
        Me.cboExecType.TabIndex = 2
        '
        'cboPriceType
        '
        Me.cboPriceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPriceType.FormattingEnabled = True
        Me.cboPriceType.Location = New System.Drawing.Point(8, 28)
        Me.cboPriceType.Name = "cboPriceType"
        Me.cboPriceType.Size = New System.Drawing.Size(58, 21)
        Me.cboPriceType.TabIndex = 1
        Me.cboPriceType.Visible = False
        '
        'mskDFNo
        '
        Me.mskDFNo.Location = New System.Drawing.Point(112, 27)
        Me.mskDFNo.Name = "mskDFNo"
        Me.mskDFNo.Size = New System.Drawing.Size(122, 20)
        Me.mskDFNo.TabIndex = 3
        '
        'pnODWorkingArea
        '
        Me.pnODWorkingArea.Controls.Add(Me.lblPrice)
        Me.pnODWorkingArea.Controls.Add(Me.lblSplitValue)
        Me.pnODWorkingArea.Controls.Add(Me.mskSplitValue)
        Me.pnODWorkingArea.Controls.Add(Me.lblCustodyCD)
        Me.pnODWorkingArea.Controls.Add(Me.mskCriteriaValue)
        Me.pnODWorkingArea.Controls.Add(Me.lblQtty)
        Me.pnODWorkingArea.Controls.Add(Me.lblSymbol)
        Me.pnODWorkingArea.Controls.Add(Me.mskQtty)
        Me.pnODWorkingArea.Controls.Add(Me.mskPrice)
        Me.pnODWorkingArea.Controls.Add(Me.mskSymbol)
        Me.pnODWorkingArea.Location = New System.Drawing.Point(-1, 24)
        Me.pnODWorkingArea.Name = "pnODWorkingArea"
        Me.pnODWorkingArea.Size = New System.Drawing.Size(366, 57)
        Me.pnODWorkingArea.TabIndex = 1
        '
        'lblPrice
        '
        Me.lblPrice.AutoSize = True
        Me.lblPrice.Location = New System.Drawing.Point(304, 9)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.Size = New System.Drawing.Size(39, 13)
        Me.lblPrice.TabIndex = 8
        Me.lblPrice.Text = "Label2"
        '
        'lblSplitValue
        '
        Me.lblSplitValue.AutoSize = True
        Me.lblSplitValue.Location = New System.Drawing.Point(236, 9)
        Me.lblSplitValue.Name = "lblSplitValue"
        Me.lblSplitValue.Size = New System.Drawing.Size(39, 13)
        Me.lblSplitValue.TabIndex = 6
        Me.lblSplitValue.Text = "Label2"
        '
        'mskSplitValue
        '
        Me.mskSplitValue.Location = New System.Drawing.Point(236, 28)
        Me.mskSplitValue.Name = "mskSplitValue"
        Me.mskSplitValue.Size = New System.Drawing.Size(64, 20)
        Me.mskSplitValue.TabIndex = 11
        '
        'lblCustodyCD
        '
        Me.lblCustodyCD.AutoSize = True
        Me.lblCustodyCD.Location = New System.Drawing.Point(8, 9)
        Me.lblCustodyCD.Name = "lblCustodyCD"
        Me.lblCustodyCD.Size = New System.Drawing.Size(39, 13)
        Me.lblCustodyCD.TabIndex = 0
        Me.lblCustodyCD.Text = "Label1"
        '
        'mskCriteriaValue
        '
        Me.mskCriteriaValue.Location = New System.Drawing.Point(8, 28)
        Me.mskCriteriaValue.Name = "mskCriteriaValue"
        Me.mskCriteriaValue.Size = New System.Drawing.Size(87, 20)
        Me.mskCriteriaValue.TabIndex = 1
        '
        'lblQtty
        '
        Me.lblQtty.AutoSize = True
        Me.lblQtty.Location = New System.Drawing.Point(166, 9)
        Me.lblQtty.Name = "lblQtty"
        Me.lblQtty.Size = New System.Drawing.Size(39, 13)
        Me.lblQtty.TabIndex = 4
        Me.lblQtty.Text = "Label1"
        '
        'lblSymbol
        '
        Me.lblSymbol.AutoSize = True
        Me.lblSymbol.Location = New System.Drawing.Point(98, 9)
        Me.lblSymbol.Name = "lblSymbol"
        Me.lblSymbol.Size = New System.Drawing.Size(39, 13)
        Me.lblSymbol.TabIndex = 2
        Me.lblSymbol.Text = "Label1"
        '
        'mskQtty
        '
        Me.mskQtty.Location = New System.Drawing.Point(166, 28)
        Me.mskQtty.Name = "mskQtty"
        Me.mskQtty.Size = New System.Drawing.Size(66, 20)
        Me.mskQtty.TabIndex = 9
        '
        'mskPrice
        '
        Me.mskPrice.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt
        Me.mskPrice.Location = New System.Drawing.Point(304, 28)
        Me.mskPrice.Name = "mskPrice"
        Me.mskPrice.Size = New System.Drawing.Size(54, 20)
        Me.mskPrice.TabIndex = 13
        Me.mskPrice.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'mskSymbol
        '
        Me.mskSymbol.Location = New System.Drawing.Point(98, 28)
        Me.mskSymbol.Name = "mskSymbol"
        Me.mskSymbol.Size = New System.Drawing.Size(64, 20)
        Me.mskSymbol.TabIndex = 7
        '
        'tabCtrlAccount
        '
        Me.tabCtrlAccount.Controls.Add(Me.tabPageAccount)
        Me.tabCtrlAccount.Controls.Add(Me.tabPageSecurities)
        Me.tabCtrlAccount.Controls.Add(Me.tabPageLoan)
        Me.tabCtrlAccount.Controls.Add(Me.tabPageDeal)
        Me.tabCtrlAccount.Controls.Add(Me.tabPageMoveDeal)
        Me.tabCtrlAccount.Controls.Add(Me.tabPageCustomer)
        Me.tabCtrlAccount.Controls.Add(Me.tabPageOrders)
        Me.tabCtrlAccount.Location = New System.Drawing.Point(0, 142)
        Me.tabCtrlAccount.Name = "tabCtrlAccount"
        Me.tabCtrlAccount.SelectedIndex = 0
        Me.tabCtrlAccount.Size = New System.Drawing.Size(1018, 564)
        Me.tabCtrlAccount.TabIndex = 7
        '
        'tabPageAccount
        '
        Me.tabPageAccount.Controls.Add(Me.ChkByUser)
        Me.tabPageAccount.Controls.Add(Me.pnSYMINFO)
        Me.tabPageAccount.Controls.Add(Me.pbSYMMKTDEEP)
        Me.tabPageAccount.Controls.Add(Me.lblSYM)
        Me.tabPageAccount.Controls.Add(Me.lblExchangeName)
        Me.tabPageAccount.Controls.Add(Me.pnSYMBIDASK)
        Me.tabPageAccount.Controls.Add(Me.pnSYMTRADELOG)
        Me.tabPageAccount.Controls.Add(Me.pnSecuritiesInfo)
        Me.tabPageAccount.Controls.Add(Me.pnOrders)
        Me.tabPageAccount.Controls.Add(Me.pnCashInfo)
        Me.tabPageAccount.Location = New System.Drawing.Point(4, 22)
        Me.tabPageAccount.Name = "tabPageAccount"
        Me.tabPageAccount.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPageAccount.Size = New System.Drawing.Size(1010, 538)
        Me.tabPageAccount.TabIndex = 0
        Me.tabPageAccount.Text = "Số dư"
        Me.tabPageAccount.UseVisualStyleBackColor = True
        '
        'ChkByUser
        '
        Me.ChkByUser.BackColor = System.Drawing.Color.Black
        Me.ChkByUser.ForeColor = System.Drawing.Color.White
        Me.ChkByUser.Location = New System.Drawing.Point(474, 303)
        Me.ChkByUser.Name = "ChkByUser"
        Me.ChkByUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkByUser.Size = New System.Drawing.Size(126, 20)
        Me.ChkByUser.TabIndex = 9
        Me.ChkByUser.Text = "Theo user đặt lệnh"
        Me.ChkByUser.UseVisualStyleBackColor = False
        '
        'pnSYMINFO
        '
        Me.pnSYMINFO.Controls.Add(Me.dgSYMINFO)
        Me.pnSYMINFO.Location = New System.Drawing.Point(472, 33)
        Me.pnSYMINFO.Name = "pnSYMINFO"
        Me.pnSYMINFO.Size = New System.Drawing.Size(196, 265)
        Me.pnSYMINFO.TabIndex = 4
        '
        'dgSYMINFO
        '
        Me.dgSYMINFO.BackgroundColor = System.Drawing.Color.Black
        Me.dgSYMINFO.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgSYMINFO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSYMINFO.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SymFldName, Me.SymFldValue})
        Me.dgSYMINFO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgSYMINFO.Location = New System.Drawing.Point(0, 0)
        Me.dgSYMINFO.Name = "dgSYMINFO"
        Me.dgSYMINFO.RowHeadersVisible = False
        Me.dgSYMINFO.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgSYMINFO.Size = New System.Drawing.Size(196, 265)
        Me.dgSYMINFO.TabIndex = 2
        '
        'SymFldName
        '
        Me.SymFldName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Black
        Me.SymFldName.DefaultCellStyle = DataGridViewCellStyle1
        Me.SymFldName.HeaderText = "FieldName"
        Me.SymFldName.Name = "SymFldName"
        Me.SymFldName.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.SymFldName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.SymFldName.Width = 63
        '
        'SymFldValue
        '
        Me.SymFldValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Black
        Me.SymFldValue.DefaultCellStyle = DataGridViewCellStyle2
        Me.SymFldValue.HeaderText = "FieldValue"
        Me.SymFldValue.Name = "SymFldValue"
        Me.SymFldValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.SymFldValue.Width = 62
        '
        'pbSYMMKTDEEP
        '
        Me.pbSYMMKTDEEP.Controls.Add(Me.dgSYMMKTDEEP)
        Me.pbSYMMKTDEEP.Location = New System.Drawing.Point(674, 61)
        Me.pbSYMMKTDEEP.Name = "pbSYMMKTDEEP"
        Me.pbSYMMKTDEEP.Size = New System.Drawing.Size(330, 97)
        Me.pbSYMMKTDEEP.TabIndex = 9
        '
        'dgSYMMKTDEEP
        '
        Me.dgSYMMKTDEEP.BackgroundColor = System.Drawing.Color.Black
        Me.dgSYMMKTDEEP.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgSYMMKTDEEP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSYMMKTDEEP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgSYMMKTDEEP.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgSYMMKTDEEP.Location = New System.Drawing.Point(0, 0)
        Me.dgSYMMKTDEEP.Name = "dgSYMMKTDEEP"
        Me.dgSYMMKTDEEP.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgSYMMKTDEEP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgSYMMKTDEEP.Size = New System.Drawing.Size(330, 97)
        Me.dgSYMMKTDEEP.TabIndex = 0
        '
        'lblSYM
        '
        Me.lblSYM.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblSYM.BackColor = System.Drawing.Color.Black
        Me.lblSYM.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSYM.ForeColor = System.Drawing.Color.Violet
        Me.lblSYM.Location = New System.Drawing.Point(472, 2)
        Me.lblSYM.Name = "lblSYM"
        Me.lblSYM.Size = New System.Drawing.Size(196, 28)
        Me.lblSYM.TabIndex = 8
        Me.lblSYM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblExchangeName
        '
        Me.lblExchangeName.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblExchangeName.BackColor = System.Drawing.Color.Black
        Me.lblExchangeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExchangeName.ForeColor = System.Drawing.Color.Lime
        Me.lblExchangeName.Location = New System.Drawing.Point(472, 30)
        Me.lblExchangeName.Name = "lblExchangeName"
        Me.lblExchangeName.Size = New System.Drawing.Size(196, 31)
        Me.lblExchangeName.TabIndex = 8
        Me.lblExchangeName.Text = "HNX +1.2 +3.2% 188.68"
        Me.lblExchangeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnSYMBIDASK
        '
        Me.pnSYMBIDASK.Controls.Add(Me.dgSYMBIDOFFER)
        Me.pnSYMBIDASK.Location = New System.Drawing.Point(674, 3)
        Me.pnSYMBIDASK.Name = "pnSYMBIDASK"
        Me.pnSYMBIDASK.Size = New System.Drawing.Size(330, 52)
        Me.pnSYMBIDASK.TabIndex = 7
        '
        'dgSYMBIDOFFER
        '
        Me.dgSYMBIDOFFER.BackgroundColor = System.Drawing.Color.Black
        Me.dgSYMBIDOFFER.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgSYMBIDOFFER.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSYMBIDOFFER.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgSYMBIDOFFER.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgSYMBIDOFFER.Location = New System.Drawing.Point(0, 0)
        Me.dgSYMBIDOFFER.Name = "dgSYMBIDOFFER"
        Me.dgSYMBIDOFFER.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgSYMBIDOFFER.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgSYMBIDOFFER.Size = New System.Drawing.Size(330, 52)
        Me.dgSYMBIDOFFER.TabIndex = 0
        '
        'pnSYMTRADELOG
        '
        Me.pnSYMTRADELOG.Controls.Add(Me.dgSYMTRADELOG)
        Me.pnSYMTRADELOG.Location = New System.Drawing.Point(674, 164)
        Me.pnSYMTRADELOG.Name = "pnSYMTRADELOG"
        Me.pnSYMTRADELOG.Size = New System.Drawing.Size(330, 134)
        Me.pnSYMTRADELOG.TabIndex = 6
        '
        'dgSYMTRADELOG
        '
        Me.dgSYMTRADELOG.BackgroundColor = System.Drawing.Color.Black
        Me.dgSYMTRADELOG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSYMTRADELOG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgSYMTRADELOG.Location = New System.Drawing.Point(0, 0)
        Me.dgSYMTRADELOG.Name = "dgSYMTRADELOG"
        Me.dgSYMTRADELOG.Size = New System.Drawing.Size(330, 134)
        Me.dgSYMTRADELOG.TabIndex = 1
        '
        'pnSecuritiesInfo
        '
        Me.pnSecuritiesInfo.Controls.Add(Me.dgStocks)
        Me.pnSecuritiesInfo.Location = New System.Drawing.Point(251, 3)
        Me.pnSecuritiesInfo.Name = "pnSecuritiesInfo"
        Me.pnSecuritiesInfo.Size = New System.Drawing.Size(220, 295)
        Me.pnSecuritiesInfo.TabIndex = 3
        '
        'dgStocks
        '
        Me.dgStocks.BackgroundColor = System.Drawing.Color.Black
        Me.dgStocks.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgStocks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgStocks.Location = New System.Drawing.Point(3, 0)
        Me.dgStocks.Name = "dgStocks"
        Me.dgStocks.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgStocks.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgStocks.Size = New System.Drawing.Size(212, 295)
        Me.dgStocks.TabIndex = 3
        '
        'pnOrders
        '
        Me.pnOrders.Controls.Add(Me.dgOrderBook)
        Me.pnOrders.Controls.Add(Me.pnOption)
        Me.pnOrders.Location = New System.Drawing.Point(4, 328)
        Me.pnOrders.Name = "pnOrders"
        Me.pnOrders.Size = New System.Drawing.Size(1000, 207)
        Me.pnOrders.TabIndex = 1
        '
        'dgOrderBook
        '
        Me.dgOrderBook.BackgroundColor = System.Drawing.Color.Black
        Me.dgOrderBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgOrderBook.Location = New System.Drawing.Point(0, 26)
        Me.dgOrderBook.Name = "dgOrderBook"
        Me.dgOrderBook.ReadOnly = True
        Me.dgOrderBook.Size = New System.Drawing.Size(1000, 208)
        Me.dgOrderBook.TabIndex = 3
        '
        'pnOption
        '
        Me.pnOption.Controls.Add(Me.cboCFSrchCriteria)
        Me.pnOption.Controls.Add(Me.lblParameter)
        Me.pnOption.Controls.Add(Me.cboSplitOption)
        Me.pnOption.Controls.Add(Me.cboOption)
        Me.pnOption.Controls.Add(Me.lblOption)
        Me.pnOption.Location = New System.Drawing.Point(4, 208)
        Me.pnOption.Name = "pnOption"
        Me.pnOption.Size = New System.Drawing.Size(367, 57)
        Me.pnOption.TabIndex = 1
        Me.pnOption.Visible = False
        '
        'cboCFSrchCriteria
        '
        Me.cboCFSrchCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCFSrchCriteria.FormattingEnabled = True
        Me.cboCFSrchCriteria.Location = New System.Drawing.Point(214, 28)
        Me.cboCFSrchCriteria.Name = "cboCFSrchCriteria"
        Me.cboCFSrchCriteria.Size = New System.Drawing.Size(142, 21)
        Me.cboCFSrchCriteria.TabIndex = 4
        Me.cboCFSrchCriteria.Visible = False
        '
        'lblParameter
        '
        Me.lblParameter.AutoSize = True
        Me.lblParameter.Location = New System.Drawing.Point(106, 8)
        Me.lblParameter.Name = "lblParameter"
        Me.lblParameter.Size = New System.Drawing.Size(39, 13)
        Me.lblParameter.TabIndex = 2
        Me.lblParameter.Text = "Label2"
        '
        'cboSplitOption
        '
        Me.cboSplitOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSplitOption.FormattingEnabled = True
        Me.cboSplitOption.Location = New System.Drawing.Point(106, 28)
        Me.cboSplitOption.Name = "cboSplitOption"
        Me.cboSplitOption.Size = New System.Drawing.Size(104, 21)
        Me.cboSplitOption.TabIndex = 3
        '
        'cboOption
        '
        Me.cboOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOption.FormattingEnabled = True
        Me.cboOption.Location = New System.Drawing.Point(6, 28)
        Me.cboOption.Name = "cboOption"
        Me.cboOption.Size = New System.Drawing.Size(96, 21)
        Me.cboOption.TabIndex = 1
        '
        'lblOption
        '
        Me.lblOption.AutoSize = True
        Me.lblOption.Location = New System.Drawing.Point(6, 8)
        Me.lblOption.Name = "lblOption"
        Me.lblOption.Size = New System.Drawing.Size(39, 13)
        Me.lblOption.TabIndex = 0
        Me.lblOption.Text = "Label1"
        '
        'pnCashInfo
        '
        Me.pnCashInfo.Controls.Add(Me.dgCash)
        Me.pnCashInfo.Location = New System.Drawing.Point(6, 3)
        Me.pnCashInfo.Name = "pnCashInfo"
        Me.pnCashInfo.Size = New System.Drawing.Size(248, 295)
        Me.pnCashInfo.TabIndex = 1
        '
        'dgCash
        '
        Me.dgCash.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgCash.BackgroundColor = System.Drawing.Color.Black
        Me.dgCash.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgCash.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCash.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CashFldName, Me.CashFldValue})
        Me.dgCash.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgCash.Location = New System.Drawing.Point(0, 0)
        Me.dgCash.Name = "dgCash"
        Me.dgCash.ReadOnly = True
        Me.dgCash.RowHeadersVisible = False
        Me.dgCash.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgCash.Size = New System.Drawing.Size(248, 295)
        Me.dgCash.TabIndex = 3
        '
        'CashFldName
        '
        Me.CashFldName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Black
        Me.CashFldName.DefaultCellStyle = DataGridViewCellStyle3
        Me.CashFldName.HeaderText = "FieldName"
        Me.CashFldName.Name = "CashFldName"
        Me.CashFldName.ReadOnly = True
        Me.CashFldName.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CashFldName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CashFldName.Width = 63
        '
        'CashFldValue
        '
        Me.CashFldValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        Me.CashFldValue.DefaultCellStyle = DataGridViewCellStyle4
        Me.CashFldValue.HeaderText = "FieldValue"
        Me.CashFldValue.Name = "CashFldValue"
        Me.CashFldValue.ReadOnly = True
        Me.CashFldValue.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CashFldValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CashFldValue.Width = 62
        '
        'tabPageSecurities
        '
        Me.tabPageSecurities.Controls.Add(Me.dgSecurities)
        Me.tabPageSecurities.Location = New System.Drawing.Point(4, 22)
        Me.tabPageSecurities.Name = "tabPageSecurities"
        Me.tabPageSecurities.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPageSecurities.Size = New System.Drawing.Size(1010, 538)
        Me.tabPageSecurities.TabIndex = 7
        Me.tabPageSecurities.Text = "Securities"
        Me.tabPageSecurities.UseVisualStyleBackColor = True
        '
        'dgSecurities
        '
        Me.dgSecurities.BackgroundColor = System.Drawing.Color.Black
        Me.dgSecurities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSecurities.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgSecurities.Location = New System.Drawing.Point(3, 3)
        Me.dgSecurities.Name = "dgSecurities"
        Me.dgSecurities.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgSecurities.Size = New System.Drawing.Size(1004, 532)
        Me.dgSecurities.TabIndex = 4
        '
        'tabPageLoan
        '
        Me.tabPageLoan.Controls.Add(Me.dgLoan)
        Me.tabPageLoan.Location = New System.Drawing.Point(4, 22)
        Me.tabPageLoan.Name = "tabPageLoan"
        Me.tabPageLoan.Size = New System.Drawing.Size(1010, 538)
        Me.tabPageLoan.TabIndex = 2
        Me.tabPageLoan.Text = "Dư nợ"
        Me.tabPageLoan.UseVisualStyleBackColor = True
        '
        'dgLoan
        '
        Me.dgLoan.BackgroundColor = System.Drawing.Color.Black
        Me.dgLoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgLoan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgLoan.Location = New System.Drawing.Point(0, 0)
        Me.dgLoan.Name = "dgLoan"
        Me.dgLoan.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgLoan.Size = New System.Drawing.Size(1010, 538)
        Me.dgLoan.TabIndex = 5
        '
        'tabPageDeal
        '
        Me.tabPageDeal.Controls.Add(Me.dgTrades)
        Me.tabPageDeal.Location = New System.Drawing.Point(4, 22)
        Me.tabPageDeal.Name = "tabPageDeal"
        Me.tabPageDeal.Size = New System.Drawing.Size(1010, 538)
        Me.tabPageDeal.TabIndex = 3
        Me.tabPageDeal.Text = "KQ khớp lệnh"
        Me.tabPageDeal.UseVisualStyleBackColor = True
        '
        'dgTrades
        '
        Me.dgTrades.BackgroundColor = System.Drawing.Color.Black
        Me.dgTrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgTrades.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgTrades.Location = New System.Drawing.Point(0, 0)
        Me.dgTrades.Name = "dgTrades"
        Me.dgTrades.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgTrades.Size = New System.Drawing.Size(1010, 538)
        Me.dgTrades.TabIndex = 6
        '
        'tabPageMoveDeal
        '
        Me.tabPageMoveDeal.Controls.Add(Me.pnCurrentDeal)
        Me.tabPageMoveDeal.Controls.Add(Me.pnDealArea)
        Me.tabPageMoveDeal.Location = New System.Drawing.Point(4, 22)
        Me.tabPageMoveDeal.Name = "tabPageMoveDeal"
        Me.tabPageMoveDeal.Size = New System.Drawing.Size(1010, 538)
        Me.tabPageMoveDeal.TabIndex = 4
        Me.tabPageMoveDeal.Text = "Ghép lệnh"
        Me.tabPageMoveDeal.UseVisualStyleBackColor = True
        '
        'pnCurrentDeal
        '
        Me.pnCurrentDeal.Controls.Add(Me.dgMoveDeal)
        Me.pnCurrentDeal.Location = New System.Drawing.Point(4, 68)
        Me.pnCurrentDeal.Name = "pnCurrentDeal"
        Me.pnCurrentDeal.Size = New System.Drawing.Size(1003, 450)
        Me.pnCurrentDeal.TabIndex = 1
        '
        'dgMoveDeal
        '
        Me.dgMoveDeal.BackgroundColor = System.Drawing.Color.Black
        Me.dgMoveDeal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgMoveDeal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgMoveDeal.Location = New System.Drawing.Point(0, 0)
        Me.dgMoveDeal.Name = "dgMoveDeal"
        Me.dgMoveDeal.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgMoveDeal.Size = New System.Drawing.Size(1003, 450)
        Me.dgMoveDeal.TabIndex = 9
        '
        'pnDealArea
        '
        Me.pnDealArea.Controls.Add(Me.lblTotalDealMoving)
        Me.pnDealArea.Controls.Add(Me.btnMoveDeal)
        Me.pnDealArea.Controls.Add(Me.lblDealType)
        Me.pnDealArea.Controls.Add(Me.cboDealType)
        Me.pnDealArea.Controls.Add(Me.mskDealSymbol)
        Me.pnDealArea.Controls.Add(Me.cboDealAFAcctno)
        Me.pnDealArea.Controls.Add(Me.lblDealAFACCTNO)
        Me.pnDealArea.Controls.Add(Me.lblDealSymbol)
        Me.pnDealArea.Location = New System.Drawing.Point(4, 4)
        Me.pnDealArea.Name = "pnDealArea"
        Me.pnDealArea.Size = New System.Drawing.Size(1003, 60)
        Me.pnDealArea.TabIndex = 0
        '
        'lblTotalDealMoving
        '
        Me.lblTotalDealMoving.AutoSize = True
        Me.lblTotalDealMoving.ForeColor = System.Drawing.Color.Red
        Me.lblTotalDealMoving.Location = New System.Drawing.Point(5, 36)
        Me.lblTotalDealMoving.Name = "lblTotalDealMoving"
        Me.lblTotalDealMoving.Size = New System.Drawing.Size(0, 13)
        Me.lblTotalDealMoving.TabIndex = 4
        '
        'btnMoveDeal
        '
        Me.btnMoveDeal.Location = New System.Drawing.Point(934, 6)
        Me.btnMoveDeal.Name = "btnMoveDeal"
        Me.btnMoveDeal.Size = New System.Drawing.Size(57, 23)
        Me.btnMoveDeal.TabIndex = 3
        Me.btnMoveDeal.Text = "Ghép"
        Me.btnMoveDeal.UseVisualStyleBackColor = True
        '
        'lblDealType
        '
        Me.lblDealType.AutoSize = True
        Me.lblDealType.Location = New System.Drawing.Point(111, 11)
        Me.lblDealType.Name = "lblDealType"
        Me.lblDealType.Size = New System.Drawing.Size(53, 13)
        Me.lblDealType.TabIndex = 0
        Me.lblDealType.Text = "Loại lệnh:"
        '
        'cboDealType
        '
        Me.cboDealType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDealType.FormattingEnabled = True
        Me.cboDealType.Location = New System.Drawing.Point(185, 7)
        Me.cboDealType.Name = "cboDealType"
        Me.cboDealType.Size = New System.Drawing.Size(96, 21)
        Me.cboDealType.TabIndex = 2
        '
        'mskDealSymbol
        '
        Me.mskDealSymbol.Location = New System.Drawing.Point(36, 7)
        Me.mskDealSymbol.Name = "mskDealSymbol"
        Me.mskDealSymbol.Size = New System.Drawing.Size(59, 20)
        Me.mskDealSymbol.TabIndex = 1
        '
        'cboDealAFAcctno
        '
        Me.cboDealAFAcctno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDealAFAcctno.FormattingEnabled = True
        Me.cboDealAFAcctno.Location = New System.Drawing.Point(345, 7)
        Me.cboDealAFAcctno.Name = "cboDealAFAcctno"
        Me.cboDealAFAcctno.Size = New System.Drawing.Size(583, 21)
        Me.cboDealAFAcctno.TabIndex = 2
        '
        'lblDealAFACCTNO
        '
        Me.lblDealAFACCTNO.AutoSize = True
        Me.lblDealAFACCTNO.Location = New System.Drawing.Point(309, 11)
        Me.lblDealAFACCTNO.Name = "lblDealAFACCTNO"
        Me.lblDealAFACCTNO.Size = New System.Drawing.Size(30, 13)
        Me.lblDealAFACCTNO.TabIndex = 0
        Me.lblDealAFACCTNO.Text = "Đến:"
        '
        'lblDealSymbol
        '
        Me.lblDealSymbol.AutoSize = True
        Me.lblDealSymbol.Location = New System.Drawing.Point(6, 11)
        Me.lblDealSymbol.Name = "lblDealSymbol"
        Me.lblDealSymbol.Size = New System.Drawing.Size(25, 13)
        Me.lblDealSymbol.TabIndex = 0
        Me.lblDealSymbol.Text = "Mã:"
        '
        'tabPageCustomer
        '
        Me.tabPageCustomer.Controls.Add(Me.dgAssets)
        Me.tabPageCustomer.Location = New System.Drawing.Point(4, 22)
        Me.tabPageCustomer.Name = "tabPageCustomer"
        Me.tabPageCustomer.Size = New System.Drawing.Size(1010, 538)
        Me.tabPageCustomer.TabIndex = 5
        Me.tabPageCustomer.Text = "Assets"
        Me.tabPageCustomer.UseVisualStyleBackColor = True
        '
        'dgAssets
        '
        Me.dgAssets.BackgroundColor = System.Drawing.Color.Black
        Me.dgAssets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgAssets.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgAssets.Location = New System.Drawing.Point(0, 0)
        Me.dgAssets.Name = "dgAssets"
        Me.dgAssets.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgAssets.Size = New System.Drawing.Size(1010, 538)
        Me.dgAssets.TabIndex = 8
        '
        'tabPageOrders
        '
        Me.tabPageOrders.Controls.Add(Me.dgRemainOrder)
        Me.tabPageOrders.Location = New System.Drawing.Point(4, 22)
        Me.tabPageOrders.Name = "tabPageOrders"
        Me.tabPageOrders.Size = New System.Drawing.Size(1010, 538)
        Me.tabPageOrders.TabIndex = 6
        Me.tabPageOrders.Text = "Orders"
        Me.tabPageOrders.UseVisualStyleBackColor = True
        '
        'dgRemainOrder
        '
        Me.dgRemainOrder.BackgroundColor = System.Drawing.Color.Black
        Me.dgRemainOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgRemainOrder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgRemainOrder.Location = New System.Drawing.Point(0, 0)
        Me.dgRemainOrder.Name = "dgRemainOrder"
        Me.dgRemainOrder.Size = New System.Drawing.Size(1010, 538)
        Me.dgRemainOrder.TabIndex = 7
        '
        'ctxDataGrid
        '
        Me.ctxDataGrid.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Export2ExcelToolStripMenuItem})
        Me.ctxDataGrid.Name = "ctxDataGrid"
        Me.ctxDataGrid.Size = New System.Drawing.Size(140, 26)
        '
        'Export2ExcelToolStripMenuItem
        '
        Me.Export2ExcelToolStripMenuItem.Name = "Export2ExcelToolStripMenuItem"
        Me.Export2ExcelToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.Export2ExcelToolStripMenuItem.Text = "Export2Excel"
        '
        'ctxSelectAll
        '
        Me.ctxSelectAll.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectedAllToolStripMenuItem, Me.NoSelectedAllToolStripMenuItem})
        Me.ctxSelectAll.Name = "ctxSelectAll"
        Me.ctxSelectAll.Size = New System.Drawing.Size(139, 48)
        '
        'SelectedAllToolStripMenuItem
        '
        Me.SelectedAllToolStripMenuItem.Name = "SelectedAllToolStripMenuItem"
        Me.SelectedAllToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.SelectedAllToolStripMenuItem.Text = "Chọn hết"
        '
        'NoSelectedAllToolStripMenuItem
        '
        Me.NoSelectedAllToolStripMenuItem.Name = "NoSelectedAllToolStripMenuItem"
        Me.NoSelectedAllToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.NoSelectedAllToolStripMenuItem.Text = "Bỏ chọn hết"
        '
        'btnUserOrder
        '
        Me.btnUserOrder.Location = New System.Drawing.Point(900, 109)
        Me.btnUserOrder.Name = "btnUserOrder"
        Me.btnUserOrder.Size = New System.Drawing.Size(118, 26)
        Me.btnUserOrder.TabIndex = 9
        Me.btnUserOrder.Text = "Sổ lệnh của User"
        Me.btnUserOrder.UseVisualStyleBackColor = True
        '
        'ctxMoveOrder
        '
        Me.ctxMoveOrder.Name = "ctxMoveOrder"
        Me.ctxMoveOrder.Size = New System.Drawing.Size(61, 4)
        '
        'pnStatus
        '
        Me.pnStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnStatus.Controls.Add(Me.lblHelp)
        Me.pnStatus.Location = New System.Drawing.Point(0, 709)
        Me.pnStatus.Name = "pnStatus"
        Me.pnStatus.Size = New System.Drawing.Size(1018, 27)
        Me.pnStatus.TabIndex = 10
        '
        'lblHelp
        '
        Me.lblHelp.BackColor = System.Drawing.Color.Black
        Me.lblHelp.ForeColor = System.Drawing.Color.White
        Me.lblHelp.Location = New System.Drawing.Point(0, 0)
        Me.lblHelp.Name = "lblHelp"
        Me.lblHelp.Size = New System.Drawing.Size(1018, 30)
        Me.lblHelp.TabIndex = 2
        Me.lblHelp.Text = "lblHelp"
        Me.lblHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSystemParameters
        '
        Me.lblSystemParameters.BackColor = System.Drawing.Color.Black
        Me.lblSystemParameters.ForeColor = System.Drawing.Color.Yellow
        Me.lblSystemParameters.Location = New System.Drawing.Point(0, 0)
        Me.lblSystemParameters.Name = "lblSystemParameters"
        Me.lblSystemParameters.Size = New System.Drawing.Size(1018, 26)
        Me.lblSystemParameters.TabIndex = 4
        Me.lblSystemParameters.Text = "lblSystemParameters"
        Me.lblSystemParameters.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSymbolInfo
        '
        Me.lblSymbolInfo.BackColor = System.Drawing.Color.Black
        Me.lblSymbolInfo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblSymbolInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSymbolInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSymbolInfo.ForeColor = System.Drawing.Color.White
        Me.lblSymbolInfo.Location = New System.Drawing.Point(0, 0)
        Me.lblSymbolInfo.Multiline = False
        Me.lblSymbolInfo.Name = "lblSymbolInfo"
        Me.lblSymbolInfo.ReadOnly = True
        Me.lblSymbolInfo.Size = New System.Drawing.Size(1018, 22)
        Me.lblSymbolInfo.TabIndex = 11
        Me.lblSymbolInfo.Text = "FSS"
        '
        'RadioCustodyCd
        '
        Me.RadioCustodyCd.AutoSize = True
        Me.RadioCustodyCd.BackColor = System.Drawing.Color.Black
        Me.RadioCustodyCd.Checked = True
        Me.RadioCustodyCd.ForeColor = System.Drawing.Color.White
        Me.RadioCustodyCd.Location = New System.Drawing.Point(546, 114)
        Me.RadioCustodyCd.Name = "RadioCustodyCd"
        Me.RadioCustodyCd.Size = New System.Drawing.Size(95, 17)
        Me.RadioCustodyCd.TabIndex = 12
        Me.RadioCustodyCd.TabStop = True
        Me.RadioCustodyCd.Text = "Theo số lưu ký"
        Me.RadioCustodyCd.UseVisualStyleBackColor = False
        '
        'RadioSubAcctno
        '
        Me.RadioSubAcctno.AutoSize = True
        Me.RadioSubAcctno.BackColor = System.Drawing.Color.Black
        Me.RadioSubAcctno.ForeColor = System.Drawing.Color.White
        Me.RadioSubAcctno.Location = New System.Drawing.Point(662, 113)
        Me.RadioSubAcctno.Name = "RadioSubAcctno"
        Me.RadioSubAcctno.Size = New System.Drawing.Size(103, 17)
        Me.RadioSubAcctno.TabIndex = 13
        Me.RadioSubAcctno.Text = "Theo tiểu khoản"
        Me.RadioSubAcctno.UseVisualStyleBackColor = False
        '
        'chkAutoRefresh
        '
        Me.chkAutoRefresh.BackColor = System.Drawing.Color.Black
        Me.chkAutoRefresh.Checked = True
        Me.chkAutoRefresh.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAutoRefresh.ForeColor = System.Drawing.Color.White
        Me.chkAutoRefresh.Location = New System.Drawing.Point(769, 109)
        Me.chkAutoRefresh.Name = "chkAutoRefresh"
        Me.chkAutoRefresh.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkAutoRefresh.Size = New System.Drawing.Size(126, 26)
        Me.chkAutoRefresh.TabIndex = 8
        Me.chkAutoRefresh.Text = "Tự động cập nhật"
        Me.chkAutoRefresh.UseVisualStyleBackColor = False
        '
        'frmBrokerDesk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 736)
        Me.Controls.Add(Me.RadioSubAcctno)
        Me.Controls.Add(Me.RadioCustodyCd)
        Me.Controls.Add(Me.lblSymbolInfo)
        Me.Controls.Add(Me.lblSystemParameters)
        Me.Controls.Add(Me.pnStatus)
        Me.Controls.Add(Me.pnODWorkingArea)
        Me.Controls.Add(Me.chkAutoRefresh)
        Me.Controls.Add(Me.pnODFixedArea)
        Me.Controls.Add(Me.btnUserOrder)
        Me.Controls.Add(Me.cboAFAcctno)
        Me.Controls.Add(Me.lblCustomerInfo)
        Me.Controls.Add(Me.txtFeedback)
        Me.Controls.Add(Me.tabCtrlAccount)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBrokerDesk"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmBrokerDesk"
        Me.pnODFixedArea.ResumeLayout(False)
        Me.pnODFixedArea.PerformLayout()
        Me.pnODWorkingArea.ResumeLayout(False)
        Me.pnODWorkingArea.PerformLayout()
        Me.tabCtrlAccount.ResumeLayout(False)
        Me.tabPageAccount.ResumeLayout(False)
        Me.pnSYMINFO.ResumeLayout(False)
        CType(Me.dgSYMINFO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pbSYMMKTDEEP.ResumeLayout(False)
        CType(Me.dgSYMMKTDEEP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnSYMBIDASK.ResumeLayout(False)
        CType(Me.dgSYMBIDOFFER, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnSYMTRADELOG.ResumeLayout(False)
        CType(Me.dgSYMTRADELOG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnSecuritiesInfo.ResumeLayout(False)
        CType(Me.dgStocks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnOrders.ResumeLayout(False)
        CType(Me.dgOrderBook, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnOption.ResumeLayout(False)
        Me.pnOption.PerformLayout()
        Me.pnCashInfo.ResumeLayout(False)
        CType(Me.dgCash, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPageSecurities.ResumeLayout(False)
        CType(Me.dgSecurities, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPageLoan.ResumeLayout(False)
        CType(Me.dgLoan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPageDeal.ResumeLayout(False)
        CType(Me.dgTrades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPageMoveDeal.ResumeLayout(False)
        Me.pnCurrentDeal.ResumeLayout(False)
        CType(Me.dgMoveDeal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnDealArea.ResumeLayout(False)
        Me.pnDealArea.PerformLayout()
        Me.tabPageCustomer.ResumeLayout(False)
        CType(Me.dgAssets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPageOrders.ResumeLayout(False)
        CType(Me.dgRemainOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxDataGrid.ResumeLayout(False)
        Me.ctxSelectAll.ResumeLayout(False)
        Me.pnStatus.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboAFAcctno As System.Windows.Forms.ComboBox
    Friend WithEvents pnODFixedArea As System.Windows.Forms.Panel
    Friend WithEvents cboExecType As System.Windows.Forms.ComboBox
    Friend WithEvents cboPriceType As System.Windows.Forms.ComboBox
    Friend WithEvents mskDFNo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents pnODWorkingArea As System.Windows.Forms.Panel
    Friend WithEvents mskQtty As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mskPrice As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mskSymbol As System.Windows.Forms.MaskedTextBox
    Friend WithEvents tabCtrlAccount As System.Windows.Forms.TabControl
    Friend WithEvents tabPageAccount As System.Windows.Forms.TabPage
    Friend WithEvents tabPageLoan As System.Windows.Forms.TabPage
    Friend WithEvents pnSecuritiesInfo As System.Windows.Forms.Panel
    Friend WithEvents pnCashInfo As System.Windows.Forms.Panel
    Friend WithEvents txtFeedback As System.Windows.Forms.TextBox
    Friend WithEvents lblLinkType As System.Windows.Forms.Label
    Friend WithEvents tabPageDeal As System.Windows.Forms.TabPage
    Friend WithEvents lblCustomerInfo As System.Windows.Forms.Label
    Friend WithEvents lblOrderType As System.Windows.Forms.Label
    Friend WithEvents lblDeal As System.Windows.Forms.Label
    Friend WithEvents lblQtty As System.Windows.Forms.Label
    Friend WithEvents lblSymbol As System.Windows.Forms.Label
    Friend WithEvents tabPageMoveDeal As System.Windows.Forms.TabPage
    Friend WithEvents pnCurrentDeal As System.Windows.Forms.Panel
    Friend WithEvents pnDealArea As System.Windows.Forms.Panel
    Friend WithEvents lblDealType As System.Windows.Forms.Label
    Friend WithEvents cboDealType As System.Windows.Forms.ComboBox
    Friend WithEvents mskDealSymbol As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cboDealAFAcctno As System.Windows.Forms.ComboBox
    Friend WithEvents lblDealAFACCTNO As System.Windows.Forms.Label
    Friend WithEvents lblDealSymbol As System.Windows.Forms.Label
    Friend WithEvents lblTotalDealMoving As System.Windows.Forms.Label
    Friend WithEvents btnMoveDeal As System.Windows.Forms.Button
    Friend WithEvents pnOrders As System.Windows.Forms.Panel
    Friend WithEvents pnOption As System.Windows.Forms.Panel
    Friend WithEvents lblOption As System.Windows.Forms.Label
    Friend WithEvents lblParameter As System.Windows.Forms.Label
    Friend WithEvents cboSplitOption As System.Windows.Forms.ComboBox
    Friend WithEvents cboOption As System.Windows.Forms.ComboBox
    Friend WithEvents lblSplitValue As System.Windows.Forms.Label
    Friend WithEvents mskSplitValue As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblCustodyCD As System.Windows.Forms.Label
    Friend WithEvents mskCriteriaValue As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cboCFSrchCriteria As System.Windows.Forms.ComboBox
    Friend WithEvents lblPrice As System.Windows.Forms.Label
    Friend WithEvents btnGetDeal As System.Windows.Forms.Button
    Friend WithEvents tabPageCustomer As System.Windows.Forms.TabPage
    Friend WithEvents ctxDataGrid As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Export2ExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tabPageOrders As System.Windows.Forms.TabPage
    Friend WithEvents ctxSelectAll As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SelectedAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NoSelectedAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mskBorrowCustodycd As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cboBorrowAFAcctno As System.Windows.Forms.ComboBox
    Friend WithEvents lblBorrowCustodycd As System.Windows.Forms.Label
    Friend WithEvents btnUserOrder As System.Windows.Forms.Button
    Friend WithEvents ctxMoveOrder As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tabPageSecurities As System.Windows.Forms.TabPage
    Friend WithEvents pnSYMINFO As System.Windows.Forms.Panel
    Friend WithEvents pnSYMTRADELOG As System.Windows.Forms.Panel
    Friend WithEvents pnSYMBIDASK As System.Windows.Forms.Panel
    Friend WithEvents dgSYMBIDOFFER As System.Windows.Forms.DataGridView
    Friend WithEvents dgSYMTRADELOG As System.Windows.Forms.DataGridView
    Friend WithEvents dgOrderBook As System.Windows.Forms.DataGridView
    Friend WithEvents dgCash As System.Windows.Forms.DataGridView
    Friend WithEvents dgSecurities As System.Windows.Forms.DataGridView
    Friend WithEvents dgLoan As System.Windows.Forms.DataGridView
    Friend WithEvents dgTrades As System.Windows.Forms.DataGridView
    Friend WithEvents dgMoveDeal As System.Windows.Forms.DataGridView
    Friend WithEvents dgAssets As System.Windows.Forms.DataGridView
    Friend WithEvents dgRemainOrder As System.Windows.Forms.DataGridView
    Friend WithEvents pnStatus As System.Windows.Forms.Panel
    Friend WithEvents lblSystemParameters As System.Windows.Forms.Label
    Friend WithEvents lblSYM As System.Windows.Forms.Label
    Friend WithEvents lblHelp As System.Windows.Forms.Label
    Friend WithEvents lblSymbolInfo As System.Windows.Forms.RichTextBox
    Friend WithEvents pbSYMMKTDEEP As System.Windows.Forms.Panel
    Friend WithEvents dgSYMMKTDEEP As System.Windows.Forms.DataGridView
    Friend WithEvents CashFldName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CashFldValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblExchangeName As System.Windows.Forms.Label
    Friend WithEvents dgSYMINFO As System.Windows.Forms.DataGridView
    Friend WithEvents SymFldName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SymFldValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgStocks As System.Windows.Forms.DataGridView
    Friend WithEvents RadioCustodyCd As System.Windows.Forms.RadioButton
    Friend WithEvents RadioSubAcctno As System.Windows.Forms.RadioButton
    Friend WithEvents ChkByUser As System.Windows.Forms.CheckBox
    Friend WithEvents chkAutoRefresh As System.Windows.Forms.CheckBox
    Friend WithEvents btnOrder As System.Windows.Forms.Button
End Class
