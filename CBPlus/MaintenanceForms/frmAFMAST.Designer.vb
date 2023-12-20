<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAFMAST
    Inherits AppCore.frmMaintenance

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAFMAST))
        Me.grbCommon = New System.Windows.Forms.GroupBox()
        Me.btnGenCheckAFACCTNO = New System.Windows.Forms.Button()
        Me.txtACCTNO = New System.Windows.Forms.TextBox()
        Me.lblACCTNO = New System.Windows.Forms.Label()
        Me.cboSTATUS = New AppCore.ComboBoxEx()
        Me.lblSTATUS = New System.Windows.Forms.Label()
        Me.tbcAFMAST = New System.Windows.Forms.TabControl()
        Me.tpAFMAST = New System.Windows.Forms.TabPage()
        Me.grbAFMAST = New System.Windows.Forms.GroupBox()
        Me.txtDESCRIPTION = New System.Windows.Forms.TextBox()
        Me.lblDESCRIPTION = New System.Windows.Forms.Label()
        Me.cboCAREBY = New AppCore.ComboBoxEx()
        Me.lblCAREBY = New System.Windows.Forms.Label()
        Me.tpHiddenTab = New System.Windows.Forms.TabPage()
        Me.txtBANKNAME = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtBANKACCTNO = New System.Windows.Forms.TextBox()
        Me.lblBANKACCTNO = New System.Windows.Forms.Label()
        Me.grbAFMASTISCOREBANK = New System.Windows.Forms.GroupBox()
        Me.cboAUTOTRF = New AppCore.ComboBoxEx()
        Me.lblAUTOTRF = New System.Windows.Forms.Label()
        Me.cboALTERNATEACCT = New AppCore.ComboBoxEx()
        Me.lblALTERNATEACCT = New System.Windows.Forms.Label()
        Me.cboCOREBANK = New AppCore.ComboBoxEx()
        Me.cboBANKNAME = New AppCore.ComboBoxEx()
        Me.lblCOREBANK = New System.Windows.Forms.Label()
        Me.lblBANKNAME = New System.Windows.Forms.Label()
        Me.txtMRSRATIO = New System.Windows.Forms.TextBox()
        Me.txtMBSRATE = New System.Windows.Forms.TextBox()
        Me.txtMRIRATIO = New System.Windows.Forms.TextBox()
        Me.txtMBIRATE = New System.Windows.Forms.TextBox()
        Me.lblMRSRATIO = New System.Windows.Forms.Label()
        Me.lblMBSRATE = New System.Windows.Forms.Label()
        Me.lblMRIRATIO = New System.Windows.Forms.Label()
        Me.txtMRLRATIO = New System.Windows.Forms.TextBox()
        Me.lblMBIRATE = New System.Windows.Forms.Label()
        Me.lblMRLRATIO = New System.Windows.Forms.Label()
        Me.txtMBLRATE = New System.Windows.Forms.TextBox()
        Me.txtMRMRATIO = New System.Windows.Forms.TextBox()
        Me.lblMBLRATE = New System.Windows.Forms.Label()
        Me.lblMRMRATIO = New System.Windows.Forms.Label()
        Me.txtMBMRATE = New System.Windows.Forms.TextBox()
        Me.lblMBMRATE = New System.Windows.Forms.Label()
        Me.cboAFTYPE = New AppCore.ComboBoxEx()
        Me.lblAFTYPE = New System.Windows.Forms.Label()
        Me.dtpOPNDATE = New System.Windows.Forms.DateTimePicker()
        Me.lblOPNDATE = New System.Windows.Forms.Label()
        Me.dtpLASTDATE = New System.Windows.Forms.DateTimePicker()
        Me.lblLASTDATE = New System.Windows.Forms.Label()
        Me.cboBRID = New AppCore.ComboBoxEx()
        Me.lblBRID = New System.Windows.Forms.Label()
        Me.cboTLID = New AppCore.ComboBoxEx()
        Me.lblTLID = New System.Windows.Forms.Label()
        Me.txtMRCRLIMIT = New System.Windows.Forms.TextBox()
        Me.lblMRCRLIMIT = New System.Windows.Forms.Label()
        Me.cboISOTC = New AppCore.ComboBoxEx()
        Me.lblISOTC = New System.Windows.Forms.Label()
        Me.cboTERMOFUSE = New AppCore.ComboBoxEx()
        Me.lblTERMOFUSE = New System.Windows.Forms.Label()
        Me.cboBRKFEETYPE = New AppCore.ComboBoxEx()
        Me.lblBRKFEETYPE = New System.Windows.Forms.Label()
        Me.txtCUSTID = New System.Windows.Forms.TextBox()
        Me.lblCUSTID = New System.Windows.Forms.Label()
        Me.txtBRATIO = New System.Windows.Forms.TextBox()
        Me.lblBRATIO = New System.Windows.Forms.Label()
        Me.txtSWIFTCODE = New System.Windows.Forms.TextBox()
        Me.lblSWIFTCODE = New System.Windows.Forms.Label()
        Me.tpSUBACCOUNT = New System.Windows.Forms.TabPage()
        Me.pnSUBSCCOUNT = New System.Windows.Forms.Panel()
        Me.tpAFTXMAP = New System.Windows.Forms.TabPage()
        Me.spcAFTXMAP = New System.Windows.Forms.SplitContainer()
        Me.btnAFTXMAP_DELETE = New System.Windows.Forms.Button()
        Me.btnAFTXMAP_EDIT = New System.Windows.Forms.Button()
        Me.btnAFTXMAP_VIEW = New System.Windows.Forms.Button()
        Me.btnAFTXMAP_ADD = New System.Windows.Forms.Button()
        Me.TabControlHide = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnPRINT = New System.Windows.Forms.Button()
        Me.DataTable6 = New System.Data.DataTable()
        Me.Panel1.SuspendLayout()
        Me.grbCommon.SuspendLayout()
        Me.tbcAFMAST.SuspendLayout()
        Me.tpAFMAST.SuspendLayout()
        Me.grbAFMAST.SuspendLayout()
        Me.tpHiddenTab.SuspendLayout()
        Me.grbAFMASTISCOREBANK.SuspendLayout()
        Me.tpSUBACCOUNT.SuspendLayout()
        Me.tpAFTXMAP.SuspendLayout()
        CType(Me.spcAFTXMAP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spcAFTXMAP.Panel1.SuspendLayout()
        Me.spcAFTXMAP.SuspendLayout()
        Me.TabControlHide.SuspendLayout()
        CType(Me.DataTable6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(629, 352)
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(789, 352)
        '
        'lblCaption
        '
        Me.lblCaption.Location = New System.Drawing.Point(12, 9)
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(709, 352)
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(871, 33)
        Me.Panel1.Tag = "Panel1"
        '
        'btnApprv
        '
        Me.btnApprv.Location = New System.Drawing.Point(548, 352)
        '
        'cboLink
        '
        Me.cboLink.Location = New System.Drawing.Point(15, 355)
        '
        'grbCommon
        '
        Me.grbCommon.Controls.Add(Me.btnGenCheckAFACCTNO)
        Me.grbCommon.Controls.Add(Me.txtACCTNO)
        Me.grbCommon.Controls.Add(Me.lblACCTNO)
        Me.grbCommon.Controls.Add(Me.cboSTATUS)
        Me.grbCommon.Controls.Add(Me.lblSTATUS)
        Me.grbCommon.Location = New System.Drawing.Point(3, 39)
        Me.grbCommon.Name = "grbCommon"
        Me.grbCommon.Size = New System.Drawing.Size(865, 44)
        Me.grbCommon.TabIndex = 15
        Me.grbCommon.TabStop = False
        Me.grbCommon.Tag = "grbCommon"
        Me.grbCommon.Text = "Thông tin chung"
        '
        'btnGenCheckAFACCTNO
        '
        Me.btnGenCheckAFACCTNO.Location = New System.Drawing.Point(207, 15)
        Me.btnGenCheckAFACCTNO.Name = "btnGenCheckAFACCTNO"
        Me.btnGenCheckAFACCTNO.Size = New System.Drawing.Size(29, 23)
        Me.btnGenCheckAFACCTNO.TabIndex = 1
        Me.btnGenCheckAFACCTNO.Tag = "btnGenCheckAFACCTNO"
        Me.btnGenCheckAFACCTNO.Text = "..."
        Me.btnGenCheckAFACCTNO.UseVisualStyleBackColor = True
        '
        'txtACCTNO
        '
        Me.txtACCTNO.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtACCTNO.Location = New System.Drawing.Point(121, 16)
        Me.txtACCTNO.Name = "txtACCTNO"
        Me.txtACCTNO.Size = New System.Drawing.Size(80, 21)
        Me.txtACCTNO.TabIndex = 0
        Me.txtACCTNO.Tag = "ACCTNO"
        '
        'lblACCTNO
        '
        Me.lblACCTNO.AutoSize = True
        Me.lblACCTNO.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblACCTNO.Location = New System.Drawing.Point(9, 21)
        Me.lblACCTNO.Name = "lblACCTNO"
        Me.lblACCTNO.Size = New System.Drawing.Size(76, 13)
        Me.lblACCTNO.TabIndex = 100
        Me.lblACCTNO.Tag = "ACCTNO"
        Me.lblACCTNO.Text = "Số tiểu khoản:"
        '
        'cboSTATUS
        '
        Me.cboSTATUS.DisplayMember = "DISPLAY"
        Me.cboSTATUS.FormattingEnabled = True
        Me.cboSTATUS.Location = New System.Drawing.Point(323, 17)
        Me.cboSTATUS.Name = "cboSTATUS"
        Me.cboSTATUS.Size = New System.Drawing.Size(124, 21)
        Me.cboSTATUS.TabIndex = 6
        Me.cboSTATUS.Tag = "STATUS"
        Me.cboSTATUS.ValueMember = "VALUE"
        '
        'lblSTATUS
        '
        Me.lblSTATUS.AutoSize = True
        Me.lblSTATUS.Location = New System.Drawing.Point(254, 21)
        Me.lblSTATUS.Name = "lblSTATUS"
        Me.lblSTATUS.Size = New System.Drawing.Size(63, 13)
        Me.lblSTATUS.TabIndex = 16
        Me.lblSTATUS.Tag = "STATUS"
        Me.lblSTATUS.Text = "Trạng thái: "
        '
        'tbcAFMAST
        '
        Me.tbcAFMAST.Controls.Add(Me.tpAFMAST)
        Me.tbcAFMAST.Controls.Add(Me.tpHiddenTab)
        Me.tbcAFMAST.Controls.Add(Me.tpSUBACCOUNT)
        Me.tbcAFMAST.Controls.Add(Me.tpAFTXMAP)
        Me.tbcAFMAST.Location = New System.Drawing.Point(3, 89)
        Me.tbcAFMAST.Name = "tbcAFMAST"
        Me.tbcAFMAST.SelectedIndex = 0
        Me.tbcAFMAST.Size = New System.Drawing.Size(865, 226)
        Me.tbcAFMAST.TabIndex = 16
        Me.tbcAFMAST.Tag = "tbcAFMAST"
        '
        'tpAFMAST
        '
        Me.tpAFMAST.BackColor = System.Drawing.SystemColors.Control
        Me.tpAFMAST.Controls.Add(Me.grbAFMAST)
        Me.tpAFMAST.Location = New System.Drawing.Point(4, 22)
        Me.tpAFMAST.Name = "tpAFMAST"
        Me.tpAFMAST.Padding = New System.Windows.Forms.Padding(3)
        Me.tpAFMAST.Size = New System.Drawing.Size(857, 200)
        Me.tpAFMAST.TabIndex = 0
        Me.tpAFMAST.Tag = "tpAFMAST"
        Me.tpAFMAST.Text = "TT tiểu khoản"
        '
        'grbAFMAST
        '
        Me.grbAFMAST.Controls.Add(Me.txtDESCRIPTION)
        Me.grbAFMAST.Controls.Add(Me.lblDESCRIPTION)
        Me.grbAFMAST.Controls.Add(Me.cboCAREBY)
        Me.grbAFMAST.Controls.Add(Me.lblCAREBY)
        Me.grbAFMAST.Location = New System.Drawing.Point(3, 3)
        Me.grbAFMAST.Name = "grbAFMAST"
        Me.grbAFMAST.Size = New System.Drawing.Size(849, 194)
        Me.grbAFMAST.TabIndex = 0
        Me.grbAFMAST.TabStop = False
        Me.grbAFMAST.Tag = "grbAFMAST"
        Me.grbAFMAST.Text = "TT tiểu khoản"
        '
        'txtDESCRIPTION
        '
        Me.txtDESCRIPTION.Location = New System.Drawing.Point(143, 45)
        Me.txtDESCRIPTION.Name = "txtDESCRIPTION"
        Me.txtDESCRIPTION.Size = New System.Drawing.Size(700, 21)
        Me.txtDESCRIPTION.TabIndex = 7
        Me.txtDESCRIPTION.Tag = "DESCRIPTION"
        '
        'lblDESCRIPTION
        '
        Me.lblDESCRIPTION.AutoSize = True
        Me.lblDESCRIPTION.Location = New System.Drawing.Point(8, 48)
        Me.lblDESCRIPTION.Name = "lblDESCRIPTION"
        Me.lblDESCRIPTION.Size = New System.Drawing.Size(38, 13)
        Me.lblDESCRIPTION.TabIndex = 38
        Me.lblDESCRIPTION.Tag = "DESCRIPTION"
        Me.lblDESCRIPTION.Text = "Mô tả:"
        '
        'cboCAREBY
        '
        Me.cboCAREBY.DisplayMember = "DISPLAY"
        Me.cboCAREBY.FormattingEnabled = True
        Me.cboCAREBY.Location = New System.Drawing.Point(143, 18)
        Me.cboCAREBY.Name = "cboCAREBY"
        Me.cboCAREBY.Size = New System.Drawing.Size(295, 21)
        Me.cboCAREBY.TabIndex = 1
        Me.cboCAREBY.Tag = "CAREBY"
        Me.cboCAREBY.ValueMember = "VALUE"
        '
        'lblCAREBY
        '
        Me.lblCAREBY.AutoSize = True
        Me.lblCAREBY.Location = New System.Drawing.Point(8, 21)
        Me.lblCAREBY.Name = "lblCAREBY"
        Me.lblCAREBY.Size = New System.Drawing.Size(129, 13)
        Me.lblCAREBY.TabIndex = 36
        Me.lblCAREBY.Tag = "CAREBY"
        Me.lblCAREBY.Text = "Nhóm quản lý tiểu khoản:"
        '
        'tpHiddenTab
        '
        Me.tpHiddenTab.Controls.Add(Me.txtBANKNAME)
        Me.tpHiddenTab.Controls.Add(Me.Label1)
        Me.tpHiddenTab.Controls.Add(Me.txtBANKACCTNO)
        Me.tpHiddenTab.Controls.Add(Me.lblBANKACCTNO)
        Me.tpHiddenTab.Controls.Add(Me.grbAFMASTISCOREBANK)
        Me.tpHiddenTab.Controls.Add(Me.txtMRSRATIO)
        Me.tpHiddenTab.Controls.Add(Me.txtMBSRATE)
        Me.tpHiddenTab.Controls.Add(Me.txtMRIRATIO)
        Me.tpHiddenTab.Controls.Add(Me.txtMBIRATE)
        Me.tpHiddenTab.Controls.Add(Me.lblMRSRATIO)
        Me.tpHiddenTab.Controls.Add(Me.lblMBSRATE)
        Me.tpHiddenTab.Controls.Add(Me.lblMRIRATIO)
        Me.tpHiddenTab.Controls.Add(Me.txtMRLRATIO)
        Me.tpHiddenTab.Controls.Add(Me.lblMBIRATE)
        Me.tpHiddenTab.Controls.Add(Me.lblMRLRATIO)
        Me.tpHiddenTab.Controls.Add(Me.txtMBLRATE)
        Me.tpHiddenTab.Controls.Add(Me.txtMRMRATIO)
        Me.tpHiddenTab.Controls.Add(Me.lblMBLRATE)
        Me.tpHiddenTab.Controls.Add(Me.lblMRMRATIO)
        Me.tpHiddenTab.Controls.Add(Me.txtMBMRATE)
        Me.tpHiddenTab.Controls.Add(Me.lblMBMRATE)
        Me.tpHiddenTab.Controls.Add(Me.cboAFTYPE)
        Me.tpHiddenTab.Controls.Add(Me.lblAFTYPE)
        Me.tpHiddenTab.Controls.Add(Me.dtpOPNDATE)
        Me.tpHiddenTab.Controls.Add(Me.lblOPNDATE)
        Me.tpHiddenTab.Controls.Add(Me.dtpLASTDATE)
        Me.tpHiddenTab.Controls.Add(Me.lblLASTDATE)
        Me.tpHiddenTab.Controls.Add(Me.cboBRID)
        Me.tpHiddenTab.Controls.Add(Me.lblBRID)
        Me.tpHiddenTab.Controls.Add(Me.cboTLID)
        Me.tpHiddenTab.Controls.Add(Me.lblTLID)
        Me.tpHiddenTab.Controls.Add(Me.txtMRCRLIMIT)
        Me.tpHiddenTab.Controls.Add(Me.lblMRCRLIMIT)
        Me.tpHiddenTab.Controls.Add(Me.cboISOTC)
        Me.tpHiddenTab.Controls.Add(Me.lblISOTC)
        Me.tpHiddenTab.Controls.Add(Me.cboTERMOFUSE)
        Me.tpHiddenTab.Controls.Add(Me.lblTERMOFUSE)
        Me.tpHiddenTab.Controls.Add(Me.cboBRKFEETYPE)
        Me.tpHiddenTab.Controls.Add(Me.lblBRKFEETYPE)
        Me.tpHiddenTab.Controls.Add(Me.txtCUSTID)
        Me.tpHiddenTab.Controls.Add(Me.lblCUSTID)
        Me.tpHiddenTab.Controls.Add(Me.txtBRATIO)
        Me.tpHiddenTab.Controls.Add(Me.lblBRATIO)
        Me.tpHiddenTab.Controls.Add(Me.txtSWIFTCODE)
        Me.tpHiddenTab.Controls.Add(Me.lblSWIFTCODE)
        Me.tpHiddenTab.Location = New System.Drawing.Point(4, 22)
        Me.tpHiddenTab.Name = "tpHiddenTab"
        Me.tpHiddenTab.Size = New System.Drawing.Size(857, 200)
        Me.tpHiddenTab.TabIndex = 10
        Me.tpHiddenTab.Tag = "tpHiddenTab"
        Me.tpHiddenTab.Text = "Hidden Tab"
        Me.tpHiddenTab.UseVisualStyleBackColor = True
        '
        'txtBANKNAME
        '
        Me.txtBANKNAME.Location = New System.Drawing.Point(770, 8)
        Me.txtBANKNAME.Name = "txtBANKNAME"
        Me.txtBANKNAME.Size = New System.Drawing.Size(80, 21)
        Me.txtBANKNAME.TabIndex = 160
        Me.txtBANKNAME.Tag = "BANKNAME"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(690, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 159
        Me.Label1.Tag = "BANKNAME"
        Me.Label1.Text = "Ngân hàng:"
        '
        'txtBANKACCTNO
        '
        Me.txtBANKACCTNO.Location = New System.Drawing.Point(770, 33)
        Me.txtBANKACCTNO.Name = "txtBANKACCTNO"
        Me.txtBANKACCTNO.Size = New System.Drawing.Size(80, 21)
        Me.txtBANKACCTNO.TabIndex = 157
        Me.txtBANKACCTNO.Tag = "BANKACCTNO"
        '
        'lblBANKACCTNO
        '
        Me.lblBANKACCTNO.AutoSize = True
        Me.lblBANKACCTNO.Location = New System.Drawing.Point(671, 38)
        Me.lblBANKACCTNO.Name = "lblBANKACCTNO"
        Me.lblBANKACCTNO.Size = New System.Drawing.Size(92, 13)
        Me.lblBANKACCTNO.TabIndex = 158
        Me.lblBANKACCTNO.Tag = "BANKACCTNO"
        Me.lblBANKACCTNO.Text = "Số TK ngân hàng:"
        '
        'grbAFMASTISCOREBANK
        '
        Me.grbAFMASTISCOREBANK.Controls.Add(Me.cboAUTOTRF)
        Me.grbAFMASTISCOREBANK.Controls.Add(Me.lblAUTOTRF)
        Me.grbAFMASTISCOREBANK.Controls.Add(Me.cboALTERNATEACCT)
        Me.grbAFMASTISCOREBANK.Controls.Add(Me.lblALTERNATEACCT)
        Me.grbAFMASTISCOREBANK.Controls.Add(Me.cboCOREBANK)
        Me.grbAFMASTISCOREBANK.Controls.Add(Me.cboBANKNAME)
        Me.grbAFMASTISCOREBANK.Controls.Add(Me.lblCOREBANK)
        Me.grbAFMASTISCOREBANK.Controls.Add(Me.lblBANKNAME)
        Me.grbAFMASTISCOREBANK.Location = New System.Drawing.Point(5, 101)
        Me.grbAFMASTISCOREBANK.Name = "grbAFMASTISCOREBANK"
        Me.grbAFMASTISCOREBANK.Size = New System.Drawing.Size(849, 77)
        Me.grbAFMASTISCOREBANK.TabIndex = 156
        Me.grbAFMASTISCOREBANK.TabStop = False
        Me.grbAFMASTISCOREBANK.Tag = "grbAFMASTISCOREBANK"
        Me.grbAFMASTISCOREBANK.Text = "Thông tin ngân hàng"
        '
        'cboAUTOTRF
        '
        Me.cboAUTOTRF.DisplayMember = "DISPLAY"
        Me.cboAUTOTRF.FormattingEnabled = True
        Me.cboAUTOTRF.Location = New System.Drawing.Point(614, 20)
        Me.cboAUTOTRF.Name = "cboAUTOTRF"
        Me.cboAUTOTRF.Size = New System.Drawing.Size(91, 21)
        Me.cboAUTOTRF.TabIndex = 37
        Me.cboAUTOTRF.Tag = "AUTOTRF"
        Me.cboAUTOTRF.ValueMember = "VALUE"
        '
        'lblAUTOTRF
        '
        Me.lblAUTOTRF.AutoSize = True
        Me.lblAUTOTRF.Location = New System.Drawing.Point(437, 57)
        Me.lblAUTOTRF.Name = "lblAUTOTRF"
        Me.lblAUTOTRF.Size = New System.Drawing.Size(186, 13)
        Me.lblAUTOTRF.TabIndex = 38
        Me.lblAUTOTRF.Tag = "AUTOTRF"
        Me.lblAUTOTRF.Text = "Có tự động chuyển tiền sang TK phụ:"
        Me.lblAUTOTRF.Visible = False
        '
        'cboALTERNATEACCT
        '
        Me.cboALTERNATEACCT.DisplayMember = "DISPLAY"
        Me.cboALTERNATEACCT.FormattingEnabled = True
        Me.cboALTERNATEACCT.Location = New System.Drawing.Point(146, 20)
        Me.cboALTERNATEACCT.Name = "cboALTERNATEACCT"
        Me.cboALTERNATEACCT.Size = New System.Drawing.Size(91, 21)
        Me.cboALTERNATEACCT.TabIndex = 0
        Me.cboALTERNATEACCT.Tag = "ALTERNATEACCT"
        Me.cboALTERNATEACCT.ValueMember = "VALUE"
        '
        'lblALTERNATEACCT
        '
        Me.lblALTERNATEACCT.AutoSize = True
        Me.lblALTERNATEACCT.Location = New System.Drawing.Point(6, 23)
        Me.lblALTERNATEACCT.Name = "lblALTERNATEACCT"
        Me.lblALTERNATEACCT.Size = New System.Drawing.Size(109, 13)
        Me.lblALTERNATEACCT.TabIndex = 36
        Me.lblALTERNATEACCT.Tag = "ALTERNATEACCT"
        Me.lblALTERNATEACCT.Text = "Có tài khoản phụ NH:"
        Me.lblALTERNATEACCT.Visible = False
        '
        'cboCOREBANK
        '
        Me.cboCOREBANK.DisplayMember = "DISPLAY"
        Me.cboCOREBANK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCOREBANK.FormattingEnabled = True
        Me.cboCOREBANK.Location = New System.Drawing.Point(541, 14)
        Me.cboCOREBANK.Name = "cboCOREBANK"
        Me.cboCOREBANK.Size = New System.Drawing.Size(100, 21)
        Me.cboCOREBANK.TabIndex = 3
        Me.cboCOREBANK.Tag = "COREBANK"
        Me.cboCOREBANK.ValueMember = "VALUE"
        '
        'cboBANKNAME
        '
        Me.cboBANKNAME.DisplayMember = "DISPLAY"
        Me.cboBANKNAME.FormattingEnabled = True
        Me.cboBANKNAME.Location = New System.Drawing.Point(146, 33)
        Me.cboBANKNAME.Name = "cboBANKNAME"
        Me.cboBANKNAME.Size = New System.Drawing.Size(241, 21)
        Me.cboBANKNAME.TabIndex = 1
        Me.cboBANKNAME.Tag = ""
        Me.cboBANKNAME.ValueMember = "VALUE"
        '
        'lblCOREBANK
        '
        Me.lblCOREBANK.AutoSize = True
        Me.lblCOREBANK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCOREBANK.Location = New System.Drawing.Point(425, 17)
        Me.lblCOREBANK.Name = "lblCOREBANK"
        Me.lblCOREBANK.Size = New System.Drawing.Size(81, 13)
        Me.lblCOREBANK.TabIndex = 6
        Me.lblCOREBANK.Tag = "COREBANK"
        Me.lblCOREBANK.Text = "Tiền gửi tại NH:"
        '
        'lblBANKNAME
        '
        Me.lblBANKNAME.AutoSize = True
        Me.lblBANKNAME.Location = New System.Drawing.Point(7, 36)
        Me.lblBANKNAME.Name = "lblBANKNAME"
        Me.lblBANKNAME.Size = New System.Drawing.Size(63, 13)
        Me.lblBANKNAME.TabIndex = 30
        Me.lblBANKNAME.Tag = ""
        Me.lblBANKNAME.Text = "Ngân hàng:"
        '
        'txtMRSRATIO
        '
        Me.txtMRSRATIO.Location = New System.Drawing.Point(365, 255)
        Me.txtMRSRATIO.Name = "txtMRSRATIO"
        Me.txtMRSRATIO.Size = New System.Drawing.Size(91, 21)
        Me.txtMRSRATIO.TabIndex = 142
        Me.txtMRSRATIO.Tag = "MRSRATIO"
        Me.txtMRSRATIO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMBSRATE
        '
        Me.txtMBSRATE.Location = New System.Drawing.Point(365, 228)
        Me.txtMBSRATE.Name = "txtMBSRATE"
        Me.txtMBSRATE.Size = New System.Drawing.Size(91, 21)
        Me.txtMBSRATE.TabIndex = 143
        Me.txtMBSRATE.Tag = "MBSRATE"
        Me.txtMBSRATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMRIRATIO
        '
        Me.txtMRIRATIO.Location = New System.Drawing.Point(130, 255)
        Me.txtMRIRATIO.Name = "txtMRIRATIO"
        Me.txtMRIRATIO.Size = New System.Drawing.Size(91, 21)
        Me.txtMRIRATIO.TabIndex = 140
        Me.txtMRIRATIO.Tag = "MRIRATIO"
        Me.txtMRIRATIO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMBIRATE
        '
        Me.txtMBIRATE.Location = New System.Drawing.Point(130, 228)
        Me.txtMBIRATE.Name = "txtMBIRATE"
        Me.txtMBIRATE.Size = New System.Drawing.Size(91, 21)
        Me.txtMBIRATE.TabIndex = 141
        Me.txtMBIRATE.Tag = "MBIRATE"
        Me.txtMBIRATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMRSRATIO
        '
        Me.lblMRSRATIO.AutoSize = True
        Me.lblMRSRATIO.Location = New System.Drawing.Point(279, 258)
        Me.lblMRSRATIO.Name = "lblMRSRATIO"
        Me.lblMRSRATIO.Size = New System.Drawing.Size(78, 13)
        Me.lblMRSRATIO.TabIndex = 153
        Me.lblMRSRATIO.Tag = "MRSRATIO"
        Me.lblMRSRATIO.Text = "TL TC an toàn:"
        '
        'lblMBSRATE
        '
        Me.lblMBSRATE.AutoSize = True
        Me.lblMBSRATE.Location = New System.Drawing.Point(279, 231)
        Me.lblMBSRATE.Name = "lblMBSRATE"
        Me.lblMBSRATE.Size = New System.Drawing.Size(79, 13)
        Me.lblMBSRATE.TabIndex = 155
        Me.lblMBSRATE.Tag = "MBSRATE"
        Me.lblMBSRATE.Text = "TL MB an toàn:"
        '
        'lblMRIRATIO
        '
        Me.lblMRIRATIO.AutoSize = True
        Me.lblMRIRATIO.Location = New System.Drawing.Point(15, 258)
        Me.lblMRIRATIO.Name = "lblMRIRATIO"
        Me.lblMRIRATIO.Size = New System.Drawing.Size(80, 13)
        Me.lblMRIRATIO.TabIndex = 154
        Me.lblMRIRATIO.Tag = "MRIRATIO"
        Me.lblMRIRATIO.Text = "TL TC ban đầu:"
        '
        'txtMRLRATIO
        '
        Me.txtMRLRATIO.Location = New System.Drawing.Point(759, 255)
        Me.txtMRLRATIO.Name = "txtMRLRATIO"
        Me.txtMRLRATIO.Size = New System.Drawing.Size(91, 21)
        Me.txtMRLRATIO.TabIndex = 147
        Me.txtMRLRATIO.Tag = "MRLRATIO"
        Me.txtMRLRATIO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMBIRATE
        '
        Me.lblMBIRATE.AutoSize = True
        Me.lblMBIRATE.Location = New System.Drawing.Point(15, 231)
        Me.lblMBIRATE.Name = "lblMBIRATE"
        Me.lblMBIRATE.Size = New System.Drawing.Size(81, 13)
        Me.lblMBIRATE.TabIndex = 152
        Me.lblMBIRATE.Tag = "MBIRATE"
        Me.lblMBIRATE.Text = "TL MB ban đầu:"
        '
        'lblMRLRATIO
        '
        Me.lblMRLRATIO.AutoSize = True
        Me.lblMRLRATIO.Location = New System.Drawing.Point(671, 258)
        Me.lblMRLRATIO.Name = "lblMRLRATIO"
        Me.lblMRLRATIO.Size = New System.Drawing.Size(80, 13)
        Me.lblMRLRATIO.TabIndex = 151
        Me.lblMRLRATIO.Tag = "MRLRATIO"
        Me.lblMRLRATIO.Text = "TL TC thanh lý:"
        '
        'txtMBLRATE
        '
        Me.txtMBLRATE.Location = New System.Drawing.Point(759, 228)
        Me.txtMBLRATE.Name = "txtMBLRATE"
        Me.txtMBLRATE.Size = New System.Drawing.Size(91, 21)
        Me.txtMBLRATE.TabIndex = 146
        Me.txtMBLRATE.Tag = "MBLRATE"
        Me.txtMBLRATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMRMRATIO
        '
        Me.txtMRMRATIO.Location = New System.Drawing.Point(571, 255)
        Me.txtMRMRATIO.Name = "txtMRMRATIO"
        Me.txtMRMRATIO.Size = New System.Drawing.Size(91, 21)
        Me.txtMRMRATIO.TabIndex = 144
        Me.txtMRMRATIO.Tag = "MRMRATIO"
        Me.txtMRMRATIO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMBLRATE
        '
        Me.lblMBLRATE.AutoSize = True
        Me.lblMBLRATE.Location = New System.Drawing.Point(671, 231)
        Me.lblMBLRATE.Name = "lblMBLRATE"
        Me.lblMBLRATE.Size = New System.Drawing.Size(82, 13)
        Me.lblMBLRATE.TabIndex = 150
        Me.lblMBLRATE.Tag = "MBLRATE"
        Me.lblMBLRATE.Text = "TL MR thanh lý:"
        '
        'lblMRMRATIO
        '
        Me.lblMRMRATIO.AutoSize = True
        Me.lblMRMRATIO.Location = New System.Drawing.Point(478, 258)
        Me.lblMRMRATIO.Name = "lblMRMRATIO"
        Me.lblMRMRATIO.Size = New System.Drawing.Size(85, 13)
        Me.lblMRMRATIO.TabIndex = 148
        Me.lblMRMRATIO.Tag = "MRMRATIO"
        Me.lblMRMRATIO.Text = "TL TC cảnh báo:"
        '
        'txtMBMRATE
        '
        Me.txtMBMRATE.Location = New System.Drawing.Point(571, 228)
        Me.txtMBMRATE.Name = "txtMBMRATE"
        Me.txtMBMRATE.Size = New System.Drawing.Size(91, 21)
        Me.txtMBMRATE.TabIndex = 145
        Me.txtMBMRATE.Tag = "MBMRATE"
        Me.txtMBMRATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMBMRATE
        '
        Me.lblMBMRATE.AutoSize = True
        Me.lblMBMRATE.Location = New System.Drawing.Point(478, 231)
        Me.lblMBMRATE.Name = "lblMBMRATE"
        Me.lblMBMRATE.Size = New System.Drawing.Size(87, 13)
        Me.lblMBMRATE.TabIndex = 149
        Me.lblMBMRATE.Tag = "MBMRATE"
        Me.lblMBMRATE.Text = "TL MR cảnh báo:"
        '
        'cboAFTYPE
        '
        Me.cboAFTYPE.DisplayMember = "DISPLAY"
        Me.cboAFTYPE.FormattingEnabled = True
        Me.cboAFTYPE.Location = New System.Drawing.Point(365, 111)
        Me.cboAFTYPE.Name = "cboAFTYPE"
        Me.cboAFTYPE.Size = New System.Drawing.Size(91, 21)
        Me.cboAFTYPE.TabIndex = 139
        Me.cboAFTYPE.Tag = "AFTYPE"
        Me.cboAFTYPE.ValueMember = "VALUE"
        '
        'lblAFTYPE
        '
        Me.lblAFTYPE.AutoSize = True
        Me.lblAFTYPE.Location = New System.Drawing.Point(271, 114)
        Me.lblAFTYPE.Name = "lblAFTYPE"
        Me.lblAFTYPE.Size = New System.Drawing.Size(83, 13)
        Me.lblAFTYPE.TabIndex = 138
        Me.lblAFTYPE.Tag = "AFTYPE"
        Me.lblAFTYPE.Text = "Loại tiểu khoản:"
        '
        'dtpOPNDATE
        '
        Me.dtpOPNDATE.CustomFormat = "dd/MM/yyyy"
        Me.dtpOPNDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpOPNDATE.Location = New System.Drawing.Point(190, 63)
        Me.dtpOPNDATE.Name = "dtpOPNDATE"
        Me.dtpOPNDATE.Size = New System.Drawing.Size(100, 21)
        Me.dtpOPNDATE.TabIndex = 136
        Me.dtpOPNDATE.Tag = "OPNDATE"
        '
        'lblOPNDATE
        '
        Me.lblOPNDATE.AutoSize = True
        Me.lblOPNDATE.Location = New System.Drawing.Point(18, 68)
        Me.lblOPNDATE.Name = "lblOPNDATE"
        Me.lblOPNDATE.Size = New System.Drawing.Size(106, 13)
        Me.lblOPNDATE.TabIndex = 137
        Me.lblOPNDATE.Tag = "OPNDATE"
        Me.lblOPNDATE.Text = "Ngày mở tiểu khoản:"
        '
        'dtpLASTDATE
        '
        Me.dtpLASTDATE.CustomFormat = "dd/MM/yyyy"
        Me.dtpLASTDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpLASTDATE.Location = New System.Drawing.Point(368, 57)
        Me.dtpLASTDATE.Name = "dtpLASTDATE"
        Me.dtpLASTDATE.Size = New System.Drawing.Size(100, 21)
        Me.dtpLASTDATE.TabIndex = 135
        Me.dtpLASTDATE.Tag = "LASTDATE"
        '
        'lblLASTDATE
        '
        Me.lblLASTDATE.AutoSize = True
        Me.lblLASTDATE.Location = New System.Drawing.Point(252, 60)
        Me.lblLASTDATE.Name = "lblLASTDATE"
        Me.lblLASTDATE.Size = New System.Drawing.Size(99, 13)
        Me.lblLASTDATE.TabIndex = 134
        Me.lblLASTDATE.Tag = "LASTDATE"
        Me.lblLASTDATE.Text = "Ngày GD gần nhất:"
        '
        'cboBRID
        '
        Me.cboBRID.DisplayMember = "DISPLAY"
        Me.cboBRID.FormattingEnabled = True
        Me.cboBRID.Location = New System.Drawing.Point(352, 84)
        Me.cboBRID.Name = "cboBRID"
        Me.cboBRID.Size = New System.Drawing.Size(91, 21)
        Me.cboBRID.TabIndex = 133
        Me.cboBRID.Tag = "BRID"
        Me.cboBRID.ValueMember = "VALUE"
        '
        'lblBRID
        '
        Me.lblBRID.AutoSize = True
        Me.lblBRID.Location = New System.Drawing.Point(125, 107)
        Me.lblBRID.Name = "lblBRID"
        Me.lblBRID.Size = New System.Drawing.Size(59, 13)
        Me.lblBRID.TabIndex = 132
        Me.lblBRID.Tag = "BRID"
        Me.lblBRID.Text = "Chi nhánh:"
        '
        'cboTLID
        '
        Me.cboTLID.DisplayMember = "DISPLAY"
        Me.cboTLID.FormattingEnabled = True
        Me.cboTLID.Location = New System.Drawing.Point(644, 100)
        Me.cboTLID.Name = "cboTLID"
        Me.cboTLID.Size = New System.Drawing.Size(91, 21)
        Me.cboTLID.TabIndex = 131
        Me.cboTLID.Tag = "TLID"
        Me.cboTLID.ValueMember = "VALUE"
        '
        'lblTLID
        '
        Me.lblTLID.AutoSize = True
        Me.lblTLID.Location = New System.Drawing.Point(476, 103)
        Me.lblTLID.Name = "lblTLID"
        Me.lblTLID.Size = New System.Drawing.Size(66, 13)
        Me.lblTLID.TabIndex = 130
        Me.lblTLID.Tag = "TLID"
        Me.lblTLID.Text = "Người dùng:"
        '
        'txtMRCRLIMIT
        '
        Me.txtMRCRLIMIT.Location = New System.Drawing.Point(365, 174)
        Me.txtMRCRLIMIT.Name = "txtMRCRLIMIT"
        Me.txtMRCRLIMIT.Size = New System.Drawing.Size(100, 21)
        Me.txtMRCRLIMIT.TabIndex = 121
        Me.txtMRCRLIMIT.Tag = "MRCRLIMIT"
        Me.txtMRCRLIMIT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMRCRLIMIT
        '
        Me.lblMRCRLIMIT.AutoSize = True
        Me.lblMRCRLIMIT.Location = New System.Drawing.Point(206, 177)
        Me.lblMRCRLIMIT.Name = "lblMRCRLIMIT"
        Me.lblMRCRLIMIT.Size = New System.Drawing.Size(97, 13)
        Me.lblMRCRLIMIT.TabIndex = 120
        Me.lblMRCRLIMIT.Tag = "MRCRLIMIT"
        Me.lblMRCRLIMIT.Text = "Hạn mức đảm bảo:"
        '
        'cboISOTC
        '
        Me.cboISOTC.DisplayMember = "DISPLAY"
        Me.cboISOTC.FormattingEnabled = True
        Me.cboISOTC.Location = New System.Drawing.Point(100, 174)
        Me.cboISOTC.Name = "cboISOTC"
        Me.cboISOTC.Size = New System.Drawing.Size(91, 21)
        Me.cboISOTC.TabIndex = 111
        Me.cboISOTC.Tag = "ISOTC"
        Me.cboISOTC.ValueMember = "VALUE"
        '
        'lblISOTC
        '
        Me.lblISOTC.AutoSize = True
        Me.lblISOTC.Location = New System.Drawing.Point(6, 177)
        Me.lblISOTC.Name = "lblISOTC"
        Me.lblISOTC.Size = New System.Drawing.Size(98, 13)
        Me.lblISOTC.TabIndex = 110
        Me.lblISOTC.Tag = "ISOTC"
        Me.lblISOTC.Text = "Cho phép GD OTC:"
        '
        'cboTERMOFUSE
        '
        Me.cboTERMOFUSE.DisplayMember = "DISPLAY"
        Me.cboTERMOFUSE.FormattingEnabled = True
        Me.cboTERMOFUSE.Location = New System.Drawing.Point(301, 141)
        Me.cboTERMOFUSE.Name = "cboTERMOFUSE"
        Me.cboTERMOFUSE.Size = New System.Drawing.Size(91, 21)
        Me.cboTERMOFUSE.TabIndex = 107
        Me.cboTERMOFUSE.Tag = "TERMOFUSE"
        Me.cboTERMOFUSE.ValueMember = "VALUE"
        '
        'lblTERMOFUSE
        '
        Me.lblTERMOFUSE.AutoSize = True
        Me.lblTERMOFUSE.Location = New System.Drawing.Point(207, 144)
        Me.lblTERMOFUSE.Name = "lblTERMOFUSE"
        Me.lblTERMOFUSE.Size = New System.Drawing.Size(83, 13)
        Me.lblTERMOFUSE.TabIndex = 106
        Me.lblTERMOFUSE.Tag = "TERMOFUSE"
        Me.lblTERMOFUSE.Text = "Điều khoản HĐ:"
        '
        'cboBRKFEETYPE
        '
        Me.cboBRKFEETYPE.DisplayMember = "DISPLAY"
        Me.cboBRKFEETYPE.FormattingEnabled = True
        Me.cboBRKFEETYPE.Location = New System.Drawing.Point(122, 111)
        Me.cboBRKFEETYPE.Name = "cboBRKFEETYPE"
        Me.cboBRKFEETYPE.Size = New System.Drawing.Size(91, 21)
        Me.cboBRKFEETYPE.TabIndex = 103
        Me.cboBRKFEETYPE.Tag = "BRKFEETYPE"
        Me.cboBRKFEETYPE.ValueMember = "VALUE"
        '
        'lblBRKFEETYPE
        '
        Me.lblBRKFEETYPE.AutoSize = True
        Me.lblBRKFEETYPE.Location = New System.Drawing.Point(28, 114)
        Me.lblBRKFEETYPE.Name = "lblBRKFEETYPE"
        Me.lblBRKFEETYPE.Size = New System.Drawing.Size(69, 13)
        Me.lblBRKFEETYPE.TabIndex = 102
        Me.lblBRKFEETYPE.Tag = "BRKFEETYPE"
        Me.lblBRKFEETYPE.Text = "Kiểu tính phí:"
        '
        'txtCUSTID
        '
        Me.txtCUSTID.Location = New System.Drawing.Point(122, 3)
        Me.txtCUSTID.Name = "txtCUSTID"
        Me.txtCUSTID.Size = New System.Drawing.Size(100, 21)
        Me.txtCUSTID.TabIndex = 97
        Me.txtCUSTID.Tag = "CUSTID"
        '
        'lblCUSTID
        '
        Me.lblCUSTID.AutoSize = True
        Me.lblCUSTID.Location = New System.Drawing.Point(6, 6)
        Me.lblCUSTID.Name = "lblCUSTID"
        Me.lblCUSTID.Size = New System.Drawing.Size(83, 13)
        Me.lblCUSTID.TabIndex = 96
        Me.lblCUSTID.Tag = "CUSTID"
        Me.lblCUSTID.Text = "Mã khách hàng:"
        '
        'txtBRATIO
        '
        Me.txtBRATIO.Location = New System.Drawing.Point(190, 91)
        Me.txtBRATIO.Name = "txtBRATIO"
        Me.txtBRATIO.Size = New System.Drawing.Size(100, 21)
        Me.txtBRATIO.TabIndex = 83
        Me.txtBRATIO.Tag = "BRATIO"
        '
        'lblBRATIO
        '
        Me.lblBRATIO.AutoSize = True
        Me.lblBRATIO.Location = New System.Drawing.Point(279, 11)
        Me.lblBRATIO.Name = "lblBRATIO"
        Me.lblBRATIO.Size = New System.Drawing.Size(92, 13)
        Me.lblBRATIO.TabIndex = 82
        Me.lblBRATIO.Tag = "BRATIO"
        Me.lblBRATIO.Text = "Tỷ lệ ký quỹ mua:"
        '
        'txtSWIFTCODE
        '
        Me.txtSWIFTCODE.Location = New System.Drawing.Point(162, 30)
        Me.txtSWIFTCODE.Name = "txtSWIFTCODE"
        Me.txtSWIFTCODE.Size = New System.Drawing.Size(100, 21)
        Me.txtSWIFTCODE.TabIndex = 27
        Me.txtSWIFTCODE.Tag = "SWIFTCODE"
        '
        'lblSWIFTCODE
        '
        Me.lblSWIFTCODE.AutoSize = True
        Me.lblSWIFTCODE.Location = New System.Drawing.Point(3, 33)
        Me.lblSWIFTCODE.Name = "lblSWIFTCODE"
        Me.lblSWIFTCODE.Size = New System.Drawing.Size(97, 13)
        Me.lblSWIFTCODE.TabIndex = 26
        Me.lblSWIFTCODE.Tag = "SWIFTCODE"
        Me.lblSWIFTCODE.Text = "SwiftCode của NH:"
        '
        'tpSUBACCOUNT
        '
        Me.tpSUBACCOUNT.BackColor = System.Drawing.SystemColors.Control
        Me.tpSUBACCOUNT.Controls.Add(Me.pnSUBSCCOUNT)
        Me.tpSUBACCOUNT.Location = New System.Drawing.Point(4, 22)
        Me.tpSUBACCOUNT.Name = "tpSUBACCOUNT"
        Me.tpSUBACCOUNT.Size = New System.Drawing.Size(857, 200)
        Me.tpSUBACCOUNT.TabIndex = 2
        Me.tpSUBACCOUNT.Tag = "tpSUBACCOUNT"
        Me.tpSUBACCOUNT.Text = "DS tiểu khoản"
        '
        'pnSUBSCCOUNT
        '
        Me.pnSUBSCCOUNT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnSUBSCCOUNT.Location = New System.Drawing.Point(0, 0)
        Me.pnSUBSCCOUNT.Name = "pnSUBSCCOUNT"
        Me.pnSUBSCCOUNT.Size = New System.Drawing.Size(857, 200)
        Me.pnSUBSCCOUNT.TabIndex = 0
        Me.pnSUBSCCOUNT.Tag = "pnSUBSCCOUNT"
        '
        'tpAFTXMAP
        '
        Me.tpAFTXMAP.BackColor = System.Drawing.SystemColors.Control
        Me.tpAFTXMAP.Controls.Add(Me.spcAFTXMAP)
        Me.tpAFTXMAP.Location = New System.Drawing.Point(4, 22)
        Me.tpAFTXMAP.Name = "tpAFTXMAP"
        Me.tpAFTXMAP.Size = New System.Drawing.Size(857, 200)
        Me.tpAFTXMAP.TabIndex = 6
        Me.tpAFTXMAP.Tag = "tpAFTXMAP"
        Me.tpAFTXMAP.Text = "Giới hạn GD"
        '
        'spcAFTXMAP
        '
        Me.spcAFTXMAP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spcAFTXMAP.Location = New System.Drawing.Point(0, 0)
        Me.spcAFTXMAP.Name = "spcAFTXMAP"
        Me.spcAFTXMAP.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'spcAFTXMAP.Panel1
        '
        Me.spcAFTXMAP.Panel1.Controls.Add(Me.btnAFTXMAP_DELETE)
        Me.spcAFTXMAP.Panel1.Controls.Add(Me.btnAFTXMAP_EDIT)
        Me.spcAFTXMAP.Panel1.Controls.Add(Me.btnAFTXMAP_VIEW)
        Me.spcAFTXMAP.Panel1.Controls.Add(Me.btnAFTXMAP_ADD)
        Me.spcAFTXMAP.Size = New System.Drawing.Size(857, 200)
        Me.spcAFTXMAP.SplitterDistance = 25
        Me.spcAFTXMAP.TabIndex = 0
        Me.spcAFTXMAP.Tag = "spcAFTXMAP"
        '
        'btnAFTXMAP_DELETE
        '
        Me.btnAFTXMAP_DELETE.Location = New System.Drawing.Point(251, 2)
        Me.btnAFTXMAP_DELETE.Name = "btnAFTXMAP_DELETE"
        Me.btnAFTXMAP_DELETE.Size = New System.Drawing.Size(75, 23)
        Me.btnAFTXMAP_DELETE.TabIndex = 3
        Me.btnAFTXMAP_DELETE.Tag = "btnAFTXMAP_DELETE"
        Me.btnAFTXMAP_DELETE.Text = "Xóa"
        Me.btnAFTXMAP_DELETE.UseVisualStyleBackColor = True
        '
        'btnAFTXMAP_EDIT
        '
        Me.btnAFTXMAP_EDIT.Location = New System.Drawing.Point(170, 2)
        Me.btnAFTXMAP_EDIT.Name = "btnAFTXMAP_EDIT"
        Me.btnAFTXMAP_EDIT.Size = New System.Drawing.Size(75, 23)
        Me.btnAFTXMAP_EDIT.TabIndex = 2
        Me.btnAFTXMAP_EDIT.Tag = "btnAFTXMAP_EDIT"
        Me.btnAFTXMAP_EDIT.Text = "Sửa"
        Me.btnAFTXMAP_EDIT.UseVisualStyleBackColor = True
        '
        'btnAFTXMAP_VIEW
        '
        Me.btnAFTXMAP_VIEW.Location = New System.Drawing.Point(89, 2)
        Me.btnAFTXMAP_VIEW.Name = "btnAFTXMAP_VIEW"
        Me.btnAFTXMAP_VIEW.Size = New System.Drawing.Size(75, 23)
        Me.btnAFTXMAP_VIEW.TabIndex = 1
        Me.btnAFTXMAP_VIEW.Tag = "btnAFTXMAP_VIEW"
        Me.btnAFTXMAP_VIEW.Text = "Xem"
        Me.btnAFTXMAP_VIEW.UseVisualStyleBackColor = True
        '
        'btnAFTXMAP_ADD
        '
        Me.btnAFTXMAP_ADD.Location = New System.Drawing.Point(8, 2)
        Me.btnAFTXMAP_ADD.Name = "btnAFTXMAP_ADD"
        Me.btnAFTXMAP_ADD.Size = New System.Drawing.Size(75, 23)
        Me.btnAFTXMAP_ADD.TabIndex = 0
        Me.btnAFTXMAP_ADD.Tag = "btnAFTXMAP_ADD"
        Me.btnAFTXMAP_ADD.Text = "Thêm mới"
        Me.btnAFTXMAP_ADD.UseVisualStyleBackColor = True
        '
        'TabControlHide
        '
        Me.TabControlHide.Controls.Add(Me.TabPage1)
        Me.TabControlHide.Controls.Add(Me.TabPage2)
        Me.TabControlHide.Location = New System.Drawing.Point(208, 352)
        Me.TabControlHide.Name = "TabControlHide"
        Me.TabControlHide.SelectedIndex = 0
        Me.TabControlHide.Size = New System.Drawing.Size(200, 24)
        Me.TabControlHide.TabIndex = 17
        Me.TabControlHide.Visible = False
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(192, 0)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(192, 0)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnPRINT
        '
        Me.btnPRINT.Location = New System.Drawing.Point(467, 352)
        Me.btnPRINT.Name = "btnPRINT"
        Me.btnPRINT.Size = New System.Drawing.Size(75, 23)
        Me.btnPRINT.TabIndex = 18
        Me.btnPRINT.Tag = "btnPRINT"
        Me.btnPRINT.Text = "In"
        Me.btnPRINT.UseVisualStyleBackColor = True
        '
        'DataTable6
        '
        Me.DataTable6.Namespace = ""
        Me.DataTable6.TableName = "COMBOBOX"
        '
        'frmAFMAST
        '
        Me.ClientSize = New System.Drawing.Size(871, 382)
        Me.Controls.Add(Me.grbCommon)
        Me.Controls.Add(Me.tbcAFMAST)
        Me.Controls.Add(Me.btnPRINT)
        Me.Controls.Add(Me.TabControlHide)
        Me.Name = "frmAFMAST"
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.TabControlHide, 0)
        Me.Controls.SetChildIndex(Me.btnApprv, 0)
        Me.Controls.SetChildIndex(Me.btnApply, 0)
        Me.Controls.SetChildIndex(Me.btnPRINT, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.cboLink, 0)
        Me.Controls.SetChildIndex(Me.tbcAFMAST, 0)
        Me.Controls.SetChildIndex(Me.grbCommon, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grbCommon.ResumeLayout(False)
        Me.grbCommon.PerformLayout()
        Me.tbcAFMAST.ResumeLayout(False)
        Me.tpAFMAST.ResumeLayout(False)
        Me.grbAFMAST.ResumeLayout(False)
        Me.grbAFMAST.PerformLayout()
        Me.tpHiddenTab.ResumeLayout(False)
        Me.tpHiddenTab.PerformLayout()
        Me.grbAFMASTISCOREBANK.ResumeLayout(False)
        Me.grbAFMASTISCOREBANK.PerformLayout()
        Me.tpSUBACCOUNT.ResumeLayout(False)
        Me.tpAFTXMAP.ResumeLayout(False)
        Me.spcAFTXMAP.Panel1.ResumeLayout(False)
        CType(Me.spcAFTXMAP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spcAFTXMAP.ResumeLayout(False)
        Me.TabControlHide.ResumeLayout(False)
        CType(Me.DataTable6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grbCommon As System.Windows.Forms.GroupBox
    Friend WithEvents tbcAFMAST As System.Windows.Forms.TabControl
    Friend WithEvents tpAFMAST As System.Windows.Forms.TabPage
    Friend WithEvents tpSUBACCOUNT As System.Windows.Forms.TabPage
    Friend WithEvents tpAFTXMAP As System.Windows.Forms.TabPage

    Friend WithEvents grbAFMAST As System.Windows.Forms.GroupBox
    Friend WithEvents cboSTATUS As AppCore.ComboBoxEx
    Friend WithEvents lblSTATUS As System.Windows.Forms.Label
    Friend WithEvents cboCAREBY As AppCore.ComboBoxEx
    Friend WithEvents lblCAREBY As System.Windows.Forms.Label
    Friend WithEvents tpHiddenTab As System.Windows.Forms.TabPage
    Friend WithEvents TabControlHide As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents txtSWIFTCODE As System.Windows.Forms.TextBox
    Friend WithEvents lblSWIFTCODE As System.Windows.Forms.Label
    Friend WithEvents txtBRATIO As System.Windows.Forms.TextBox
    Friend WithEvents lblBRATIO As System.Windows.Forms.Label
    Friend WithEvents txtCUSTID As System.Windows.Forms.TextBox
    Friend WithEvents lblCUSTID As System.Windows.Forms.Label
    Friend WithEvents btnGenCheckAFACCTNO As System.Windows.Forms.Button
    Friend WithEvents txtACCTNO As System.Windows.Forms.TextBox
    Friend WithEvents lblACCTNO As System.Windows.Forms.Label
    Friend WithEvents cboTERMOFUSE As AppCore.ComboBoxEx
    Friend WithEvents lblTERMOFUSE As System.Windows.Forms.Label
    Friend WithEvents cboBRKFEETYPE As AppCore.ComboBoxEx
    Friend WithEvents lblBRKFEETYPE As System.Windows.Forms.Label
    Friend WithEvents txtDESCRIPTION As System.Windows.Forms.TextBox
    Friend WithEvents lblDESCRIPTION As System.Windows.Forms.Label
    Friend WithEvents cboISOTC As AppCore.ComboBoxEx
    Friend WithEvents lblISOTC As System.Windows.Forms.Label
    Friend WithEvents cboBRID As AppCore.ComboBoxEx
    Friend WithEvents lblBRID As System.Windows.Forms.Label
    Friend WithEvents cboTLID As AppCore.ComboBoxEx
    Friend WithEvents lblTLID As System.Windows.Forms.Label
    Friend WithEvents txtMRCRLIMIT As System.Windows.Forms.TextBox
    Friend WithEvents lblMRCRLIMIT As System.Windows.Forms.Label
    Friend WithEvents dtpLASTDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblLASTDATE As System.Windows.Forms.Label
    Friend WithEvents spcAFTXMAP As System.Windows.Forms.SplitContainer
    Friend WithEvents btnAFTXMAP_DELETE As System.Windows.Forms.Button
    Friend WithEvents btnAFTXMAP_EDIT As System.Windows.Forms.Button
    Friend WithEvents btnAFTXMAP_VIEW As System.Windows.Forms.Button
    Friend WithEvents btnAFTXMAP_ADD As System.Windows.Forms.Button
    Friend WithEvents pnSUBSCCOUNT As System.Windows.Forms.Panel
    Friend WithEvents dtpOPNDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblOPNDATE As System.Windows.Forms.Label
    Friend WithEvents btnPRINT As System.Windows.Forms.Button
    Friend WithEvents cboAFTYPE As AppCore.ComboBoxEx
    Friend WithEvents lblAFTYPE As System.Windows.Forms.Label
    Friend WithEvents lblLIMITDAILY As System.Windows.Forms.Label
    Friend WithEvents txtMRSRATIO As System.Windows.Forms.TextBox
    Friend WithEvents txtMBSRATE As System.Windows.Forms.TextBox
    Friend WithEvents txtMRIRATIO As System.Windows.Forms.TextBox
    Friend WithEvents txtMBIRATE As System.Windows.Forms.TextBox
    Friend WithEvents lblMRSRATIO As System.Windows.Forms.Label
    Friend WithEvents lblMBSRATE As System.Windows.Forms.Label
    Friend WithEvents lblMRIRATIO As System.Windows.Forms.Label
    Friend WithEvents txtMRLRATIO As System.Windows.Forms.TextBox
    Friend WithEvents lblMBIRATE As System.Windows.Forms.Label
    Friend WithEvents lblMRLRATIO As System.Windows.Forms.Label
    Friend WithEvents txtMBLRATE As System.Windows.Forms.TextBox
    Friend WithEvents txtMRMRATIO As System.Windows.Forms.TextBox
    Friend WithEvents lblMBLRATE As System.Windows.Forms.Label
    Friend WithEvents lblMRMRATIO As System.Windows.Forms.Label
    Friend WithEvents txtMBMRATE As System.Windows.Forms.TextBox
    Friend WithEvents lblMBMRATE As System.Windows.Forms.Label
    Friend WithEvents grbAFMASTISCOREBANK As System.Windows.Forms.GroupBox
    Friend WithEvents cboAUTOTRF As AppCore.ComboBoxEx
    Friend WithEvents lblAUTOTRF As System.Windows.Forms.Label
    Friend WithEvents cboALTERNATEACCT As AppCore.ComboBoxEx
    Friend WithEvents lblALTERNATEACCT As System.Windows.Forms.Label
    Friend WithEvents cboCOREBANK As AppCore.ComboBoxEx
    Friend WithEvents cboBANKNAME As AppCore.ComboBoxEx
    Friend WithEvents lblCOREBANK As System.Windows.Forms.Label
    Friend WithEvents lblBANKNAME As System.Windows.Forms.Label
    Friend WithEvents DataTable6 As System.Data.DataTable
    Friend WithEvents txtBANKNAME As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBANKACCTNO As System.Windows.Forms.TextBox
    Friend WithEvents lblBANKACCTNO As System.Windows.Forms.Label

End Class
