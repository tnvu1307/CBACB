<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmESCROW
    Inherits AppCore.frmMaintenance

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmESCROW))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpESCROW = New System.Windows.Forms.TabPage()
        Me.lblSBANKID_REF = New System.Windows.Forms.Label()
        Me.txtSCUSTID = New System.Windows.Forms.TextBox()
        Me.txtBCUSTID = New System.Windows.Forms.TextBox()
        Me.txtCODEID = New System.Windows.Forms.TextBox()
        Me.txtAUTOID = New System.Windows.Forms.TextBox()
        Me.txtSYMBOL = New System.Windows.Forms.TextBox()
        Me.cboBDDACCTNO_IICA = New AppCore.ComboBoxEx()
        Me.cboBDDACCTNO_ESCROW = New AppCore.ComboBoxEx()
        Me.txtBCUSTODYCD = New System.Windows.Forms.TextBox()
        Me.txtSBANKID = New System.Windows.Forms.TextBox()
        Me.txtSCUSTODYCD = New System.Windows.Forms.TextBox()
        Me.txtDESCRIPTION = New System.Windows.Forms.TextBox()
        Me.lblDESCRIPTION = New System.Windows.Forms.Label()
        Me.txtSRCACCTNO = New System.Windows.Forms.TextBox()
        Me.lblSRCACCTNO = New System.Windows.Forms.Label()
        Me.txtBLKAMT = New System.Windows.Forms.TextBox()
        Me.lblBLKAMT = New System.Windows.Forms.Label()
        Me.txtBLKRATE = New System.Windows.Forms.TextBox()
        Me.txtESCROWID = New System.Windows.Forms.TextBox()
        Me.lblESCROWID = New System.Windows.Forms.Label()
        Me.lblBLKRATE = New System.Windows.Forms.Label()
        Me.txtAMT = New System.Windows.Forms.TextBox()
        Me.lblAMT = New System.Windows.Forms.Label()
        Me.txtQTTY = New System.Windows.Forms.TextBox()
        Me.lblQTTY = New System.Windows.Forms.Label()
        Me.lblSYMBOL = New System.Windows.Forms.Label()
        Me.lblBDDACCTNO_IICA = New System.Windows.Forms.Label()
        Me.lblBDDACCTNO_ESCROW = New System.Windows.Forms.Label()
        Me.txtBFULLNAME = New System.Windows.Forms.TextBox()
        Me.lblBFULLNAME = New System.Windows.Forms.Label()
        Me.lblBCUSTODYCD = New System.Windows.Forms.Label()
        Me.lblSBANKID = New System.Windows.Forms.Label()
        Me.txtSBANKACCOUNT = New System.Windows.Forms.TextBox()
        Me.lblSBANKACCOUNT = New System.Windows.Forms.Label()
        Me.txtSFULLNAME = New System.Windows.Forms.TextBox()
        Me.lblSFULLNAME = New System.Windows.Forms.Label()
        Me.lblSCUSTODYCD = New System.Windows.Forms.Label()
        Me.lblSIGNDATE = New System.Windows.Forms.Label()
        Me.dtpSIGNDATE = New System.Windows.Forms.DateTimePicker()
        Me.tpECROW_FILES = New System.Windows.Forms.TabPage()
        Me.DataTable8 = New System.Data.DataTable()
        Me.DataTable9 = New System.Data.DataTable()
        Me.DataTable10 = New System.Data.DataTable()
        Me.DataTable11 = New System.Data.DataTable()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tpESCROW.SuspendLayout()
        CType(Me.DataTable8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(692, 531)
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(852, 531)
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(772, 531)
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(931, 50)
        '
        'btnApprv
        '
        Me.btnApprv.Location = New System.Drawing.Point(611, 531)
        '
        'cboLink
        '
        Me.cboLink.Location = New System.Drawing.Point(6, 533)
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tpESCROW)
        Me.TabControl1.Controls.Add(Me.tpECROW_FILES)
        Me.TabControl1.Location = New System.Drawing.Point(6, 56)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(925, 471)
        Me.TabControl1.TabIndex = 9
        Me.TabControl1.Tag = "TabControl1"
        '
        'tpESCROW
        '
        Me.tpESCROW.AutoScroll = True
        Me.tpESCROW.BackColor = System.Drawing.SystemColors.Control
        Me.tpESCROW.Controls.Add(Me.lblSBANKID_REF)
        Me.tpESCROW.Controls.Add(Me.txtSCUSTID)
        Me.tpESCROW.Controls.Add(Me.txtBCUSTID)
        Me.tpESCROW.Controls.Add(Me.txtCODEID)
        Me.tpESCROW.Controls.Add(Me.txtAUTOID)
        Me.tpESCROW.Controls.Add(Me.txtSYMBOL)
        Me.tpESCROW.Controls.Add(Me.cboBDDACCTNO_IICA)
        Me.tpESCROW.Controls.Add(Me.cboBDDACCTNO_ESCROW)
        Me.tpESCROW.Controls.Add(Me.txtBCUSTODYCD)
        Me.tpESCROW.Controls.Add(Me.txtSBANKID)
        Me.tpESCROW.Controls.Add(Me.txtSCUSTODYCD)
        Me.tpESCROW.Controls.Add(Me.txtDESCRIPTION)
        Me.tpESCROW.Controls.Add(Me.lblDESCRIPTION)
        Me.tpESCROW.Controls.Add(Me.txtSRCACCTNO)
        Me.tpESCROW.Controls.Add(Me.lblSRCACCTNO)
        Me.tpESCROW.Controls.Add(Me.txtBLKAMT)
        Me.tpESCROW.Controls.Add(Me.lblBLKAMT)
        Me.tpESCROW.Controls.Add(Me.txtBLKRATE)
        Me.tpESCROW.Controls.Add(Me.txtESCROWID)
        Me.tpESCROW.Controls.Add(Me.lblESCROWID)
        Me.tpESCROW.Controls.Add(Me.lblBLKRATE)
        Me.tpESCROW.Controls.Add(Me.txtAMT)
        Me.tpESCROW.Controls.Add(Me.lblAMT)
        Me.tpESCROW.Controls.Add(Me.txtQTTY)
        Me.tpESCROW.Controls.Add(Me.lblQTTY)
        Me.tpESCROW.Controls.Add(Me.lblSYMBOL)
        Me.tpESCROW.Controls.Add(Me.lblBDDACCTNO_IICA)
        Me.tpESCROW.Controls.Add(Me.lblBDDACCTNO_ESCROW)
        Me.tpESCROW.Controls.Add(Me.txtBFULLNAME)
        Me.tpESCROW.Controls.Add(Me.lblBFULLNAME)
        Me.tpESCROW.Controls.Add(Me.lblBCUSTODYCD)
        Me.tpESCROW.Controls.Add(Me.lblSBANKID)
        Me.tpESCROW.Controls.Add(Me.txtSBANKACCOUNT)
        Me.tpESCROW.Controls.Add(Me.lblSBANKACCOUNT)
        Me.tpESCROW.Controls.Add(Me.txtSFULLNAME)
        Me.tpESCROW.Controls.Add(Me.lblSFULLNAME)
        Me.tpESCROW.Controls.Add(Me.lblSCUSTODYCD)
        Me.tpESCROW.Controls.Add(Me.lblSIGNDATE)
        Me.tpESCROW.Controls.Add(Me.dtpSIGNDATE)
        Me.tpESCROW.Location = New System.Drawing.Point(4, 22)
        Me.tpESCROW.Name = "tpESCROW"
        Me.tpESCROW.Padding = New System.Windows.Forms.Padding(3)
        Me.tpESCROW.Size = New System.Drawing.Size(917, 445)
        Me.tpESCROW.TabIndex = 0
        Me.tpESCROW.Tag = "MAIN"
        Me.tpESCROW.Text = "TT chung"
        '
        'lblSBANKID_REF
        '
        Me.lblSBANKID_REF.AutoSize = True
        Me.lblSBANKID_REF.Location = New System.Drawing.Point(488, 138)
        Me.lblSBANKID_REF.Name = "lblSBANKID_REF"
        Me.lblSBANKID_REF.Size = New System.Drawing.Size(85, 13)
        Me.lblSBANKID_REF.TabIndex = 41
        Me.lblSBANKID_REF.Tag = "lblSBANKID_REF"
        Me.lblSBANKID_REF.Text = "lblSBANKID_REF"
        '
        'txtSCUSTID
        '
        Me.txtSCUSTID.Location = New System.Drawing.Point(489, 61)
        Me.txtSCUSTID.Name = "txtSCUSTID"
        Me.txtSCUSTID.Size = New System.Drawing.Size(197, 21)
        Me.txtSCUSTID.TabIndex = 40
        Me.txtSCUSTID.Tag = "SCUSTID"
        Me.txtSCUSTID.Text = "txtSCUSTID"
        '
        'txtBCUSTID
        '
        Me.txtBCUSTID.Location = New System.Drawing.Point(489, 160)
        Me.txtBCUSTID.Name = "txtBCUSTID"
        Me.txtBCUSTID.Size = New System.Drawing.Size(197, 21)
        Me.txtBCUSTID.TabIndex = 39
        Me.txtBCUSTID.Tag = "BCUSTID"
        Me.txtBCUSTID.Text = "txtBCUSTID"
        '
        'txtCODEID
        '
        Me.txtCODEID.Location = New System.Drawing.Point(489, 262)
        Me.txtCODEID.Name = "txtCODEID"
        Me.txtCODEID.Size = New System.Drawing.Size(197, 21)
        Me.txtCODEID.TabIndex = 38
        Me.txtCODEID.Tag = "CODEID"
        Me.txtCODEID.Text = "txtCODEID"
        '
        'txtAUTOID
        '
        Me.txtAUTOID.Location = New System.Drawing.Point(762, 12)
        Me.txtAUTOID.Name = "txtAUTOID"
        Me.txtAUTOID.Size = New System.Drawing.Size(103, 21)
        Me.txtAUTOID.TabIndex = 37
        Me.txtAUTOID.Tag = "AUTOID"
        Me.txtAUTOID.Text = "txtAUTOID"
        '
        'txtSYMBOL
        '
        Me.txtSYMBOL.Location = New System.Drawing.Point(286, 260)
        Me.txtSYMBOL.Name = "txtSYMBOL"
        Me.txtSYMBOL.Size = New System.Drawing.Size(197, 21)
        Me.txtSYMBOL.TabIndex = 36
        Me.txtSYMBOL.Tag = "SYMBOL"
        '
        'cboBDDACCTNO_IICA
        '
        Me.cboBDDACCTNO_IICA.DisplayMember = "DISPLAY"
        Me.cboBDDACCTNO_IICA.FormattingEnabled = True
        Me.cboBDDACCTNO_IICA.Location = New System.Drawing.Point(285, 235)
        Me.cboBDDACCTNO_IICA.Name = "cboBDDACCTNO_IICA"
        Me.cboBDDACCTNO_IICA.Size = New System.Drawing.Size(288, 21)
        Me.cboBDDACCTNO_IICA.TabIndex = 34
        Me.cboBDDACCTNO_IICA.Tag = "BDDACCTNO_IICA"
        Me.cboBDDACCTNO_IICA.ValueMember = "VALUE"
        '
        'cboBDDACCTNO_ESCROW
        '
        Me.cboBDDACCTNO_ESCROW.DisplayMember = "DISPLAY"
        Me.cboBDDACCTNO_ESCROW.FormattingEnabled = True
        Me.cboBDDACCTNO_ESCROW.Location = New System.Drawing.Point(285, 210)
        Me.cboBDDACCTNO_ESCROW.Name = "cboBDDACCTNO_ESCROW"
        Me.cboBDDACCTNO_ESCROW.Size = New System.Drawing.Size(288, 21)
        Me.cboBDDACCTNO_ESCROW.TabIndex = 17
        Me.cboBDDACCTNO_ESCROW.Tag = "BDDACCTNO_ESCROW"
        Me.cboBDDACCTNO_ESCROW.ValueMember = "VALUE"
        '
        'txtBCUSTODYCD
        '
        Me.txtBCUSTODYCD.Location = New System.Drawing.Point(285, 159)
        Me.txtBCUSTODYCD.Name = "txtBCUSTODYCD"
        Me.txtBCUSTODYCD.Size = New System.Drawing.Size(197, 21)
        Me.txtBCUSTODYCD.TabIndex = 13
        Me.txtBCUSTODYCD.Tag = "BCUSTODYCD"
        '
        'txtSBANKID
        '
        Me.txtSBANKID.Location = New System.Drawing.Point(285, 135)
        Me.txtSBANKID.Name = "txtSBANKID"
        Me.txtSBANKID.Size = New System.Drawing.Size(197, 21)
        Me.txtSBANKID.TabIndex = 11
        Me.txtSBANKID.Tag = "SBANKID"
        '
        'txtSCUSTODYCD
        '
        Me.txtSCUSTODYCD.Location = New System.Drawing.Point(285, 61)
        Me.txtSCUSTODYCD.Name = "txtSCUSTODYCD"
        Me.txtSCUSTODYCD.Size = New System.Drawing.Size(197, 21)
        Me.txtSCUSTODYCD.TabIndex = 3
        Me.txtSCUSTODYCD.Tag = "SCUSTODYCD"
        '
        'txtDESCRIPTION
        '
        Me.txtDESCRIPTION.Location = New System.Drawing.Point(285, 410)
        Me.txtDESCRIPTION.Name = "txtDESCRIPTION"
        Me.txtDESCRIPTION.Size = New System.Drawing.Size(610, 21)
        Me.txtDESCRIPTION.TabIndex = 33
        Me.txtDESCRIPTION.Tag = "DESCRIPTION"
        '
        'lblDESCRIPTION
        '
        Me.lblDESCRIPTION.Location = New System.Drawing.Point(5, 410)
        Me.lblDESCRIPTION.Name = "lblDESCRIPTION"
        Me.lblDESCRIPTION.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDESCRIPTION.Size = New System.Drawing.Size(274, 18)
        Me.lblDESCRIPTION.TabIndex = 32
        Me.lblDESCRIPTION.Tag = "DESCRIPTION"
        Me.lblDESCRIPTION.Text = "lblDESCRIPTION"
        Me.lblDESCRIPTION.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSRCACCTNO
        '
        Me.txtSRCACCTNO.Location = New System.Drawing.Point(285, 385)
        Me.txtSRCACCTNO.Name = "txtSRCACCTNO"
        Me.txtSRCACCTNO.Size = New System.Drawing.Size(610, 21)
        Me.txtSRCACCTNO.TabIndex = 31
        Me.txtSRCACCTNO.Tag = "SRCACCTNO"
        '
        'lblSRCACCTNO
        '
        Me.lblSRCACCTNO.Location = New System.Drawing.Point(5, 385)
        Me.lblSRCACCTNO.Name = "lblSRCACCTNO"
        Me.lblSRCACCTNO.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblSRCACCTNO.Size = New System.Drawing.Size(274, 18)
        Me.lblSRCACCTNO.TabIndex = 30
        Me.lblSRCACCTNO.Tag = "SRCACCTNO"
        Me.lblSRCACCTNO.Text = "lblSRCACCTNO"
        Me.lblSRCACCTNO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBLKAMT
        '
        Me.txtBLKAMT.Location = New System.Drawing.Point(285, 360)
        Me.txtBLKAMT.Name = "txtBLKAMT"
        Me.txtBLKAMT.Size = New System.Drawing.Size(197, 21)
        Me.txtBLKAMT.TabIndex = 29
        Me.txtBLKAMT.Tag = "BLKAMT"
        '
        'lblBLKAMT
        '
        Me.lblBLKAMT.Location = New System.Drawing.Point(4, 360)
        Me.lblBLKAMT.Name = "lblBLKAMT"
        Me.lblBLKAMT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblBLKAMT.Size = New System.Drawing.Size(274, 18)
        Me.lblBLKAMT.TabIndex = 28
        Me.lblBLKAMT.Tag = "BLKAMT"
        Me.lblBLKAMT.Text = "lblBLKAMT"
        Me.lblBLKAMT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBLKRATE
        '
        Me.txtBLKRATE.Location = New System.Drawing.Point(285, 335)
        Me.txtBLKRATE.Name = "txtBLKRATE"
        Me.txtBLKRATE.Size = New System.Drawing.Size(197, 21)
        Me.txtBLKRATE.TabIndex = 27
        Me.txtBLKRATE.Tag = "BLKRATE"
        '
        'txtESCROWID
        '
        Me.txtESCROWID.Location = New System.Drawing.Point(286, 12)
        Me.txtESCROWID.Name = "txtESCROWID"
        Me.txtESCROWID.Size = New System.Drawing.Size(197, 21)
        Me.txtESCROWID.TabIndex = 1
        Me.txtESCROWID.Tag = "ESCROWID"
        '
        'lblESCROWID
        '
        Me.lblESCROWID.Location = New System.Drawing.Point(6, 12)
        Me.lblESCROWID.Name = "lblESCROWID"
        Me.lblESCROWID.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblESCROWID.Size = New System.Drawing.Size(274, 18)
        Me.lblESCROWID.TabIndex = 0
        Me.lblESCROWID.Tag = "ESCROWID"
        Me.lblESCROWID.Text = "lblESCROWID"
        Me.lblESCROWID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBLKRATE
        '
        Me.lblBLKRATE.Location = New System.Drawing.Point(5, 335)
        Me.lblBLKRATE.Name = "lblBLKRATE"
        Me.lblBLKRATE.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblBLKRATE.Size = New System.Drawing.Size(274, 18)
        Me.lblBLKRATE.TabIndex = 26
        Me.lblBLKRATE.Tag = "BLKRATE"
        Me.lblBLKRATE.Text = "lblBLKRATE"
        Me.lblBLKRATE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAMT
        '
        Me.txtAMT.Location = New System.Drawing.Point(286, 310)
        Me.txtAMT.Name = "txtAMT"
        Me.txtAMT.Size = New System.Drawing.Size(197, 21)
        Me.txtAMT.TabIndex = 25
        Me.txtAMT.Tag = "AMT"
        '
        'lblAMT
        '
        Me.lblAMT.Location = New System.Drawing.Point(5, 310)
        Me.lblAMT.Name = "lblAMT"
        Me.lblAMT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAMT.Size = New System.Drawing.Size(274, 18)
        Me.lblAMT.TabIndex = 24
        Me.lblAMT.Tag = "AMT"
        Me.lblAMT.Text = "lblAMT"
        Me.lblAMT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtQTTY
        '
        Me.txtQTTY.Location = New System.Drawing.Point(285, 285)
        Me.txtQTTY.Name = "txtQTTY"
        Me.txtQTTY.Size = New System.Drawing.Size(197, 21)
        Me.txtQTTY.TabIndex = 23
        Me.txtQTTY.Tag = "QTTY"
        '
        'lblQTTY
        '
        Me.lblQTTY.Location = New System.Drawing.Point(5, 285)
        Me.lblQTTY.Name = "lblQTTY"
        Me.lblQTTY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblQTTY.Size = New System.Drawing.Size(274, 18)
        Me.lblQTTY.TabIndex = 22
        Me.lblQTTY.Tag = "QTTY"
        Me.lblQTTY.Text = "lblQTTY"
        Me.lblQTTY.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSYMBOL
        '
        Me.lblSYMBOL.Location = New System.Drawing.Point(6, 260)
        Me.lblSYMBOL.Name = "lblSYMBOL"
        Me.lblSYMBOL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblSYMBOL.Size = New System.Drawing.Size(274, 18)
        Me.lblSYMBOL.TabIndex = 20
        Me.lblSYMBOL.Tag = "SYMBOL"
        Me.lblSYMBOL.Text = "lblSYMBOL"
        Me.lblSYMBOL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBDDACCTNO_IICA
        '
        Me.lblBDDACCTNO_IICA.Location = New System.Drawing.Point(6, 235)
        Me.lblBDDACCTNO_IICA.Name = "lblBDDACCTNO_IICA"
        Me.lblBDDACCTNO_IICA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblBDDACCTNO_IICA.Size = New System.Drawing.Size(274, 18)
        Me.lblBDDACCTNO_IICA.TabIndex = 18
        Me.lblBDDACCTNO_IICA.Tag = "BDDACCTNO_IICA"
        Me.lblBDDACCTNO_IICA.Text = "lblBDDACCTNO_IICA"
        Me.lblBDDACCTNO_IICA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBDDACCTNO_ESCROW
        '
        Me.lblBDDACCTNO_ESCROW.Location = New System.Drawing.Point(6, 210)
        Me.lblBDDACCTNO_ESCROW.Name = "lblBDDACCTNO_ESCROW"
        Me.lblBDDACCTNO_ESCROW.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblBDDACCTNO_ESCROW.Size = New System.Drawing.Size(274, 18)
        Me.lblBDDACCTNO_ESCROW.TabIndex = 16
        Me.lblBDDACCTNO_ESCROW.Tag = "BDDACCTNO_ESCROW"
        Me.lblBDDACCTNO_ESCROW.Text = "lblBDDACCTNO_ESCROW"
        Me.lblBDDACCTNO_ESCROW.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBFULLNAME
        '
        Me.txtBFULLNAME.Location = New System.Drawing.Point(285, 185)
        Me.txtBFULLNAME.Name = "txtBFULLNAME"
        Me.txtBFULLNAME.Size = New System.Drawing.Size(610, 21)
        Me.txtBFULLNAME.TabIndex = 15
        Me.txtBFULLNAME.Tag = "BFULLNAME"
        '
        'lblBFULLNAME
        '
        Me.lblBFULLNAME.Location = New System.Drawing.Point(5, 185)
        Me.lblBFULLNAME.Name = "lblBFULLNAME"
        Me.lblBFULLNAME.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblBFULLNAME.Size = New System.Drawing.Size(274, 18)
        Me.lblBFULLNAME.TabIndex = 14
        Me.lblBFULLNAME.Tag = "BFULLNAME"
        Me.lblBFULLNAME.Text = "lblBFULLNAME"
        Me.lblBFULLNAME.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBCUSTODYCD
        '
        Me.lblBCUSTODYCD.Location = New System.Drawing.Point(5, 160)
        Me.lblBCUSTODYCD.Name = "lblBCUSTODYCD"
        Me.lblBCUSTODYCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblBCUSTODYCD.Size = New System.Drawing.Size(274, 18)
        Me.lblBCUSTODYCD.TabIndex = 12
        Me.lblBCUSTODYCD.Tag = "BCUSTODYCD"
        Me.lblBCUSTODYCD.Text = "lblBCUSTODYCD"
        Me.lblBCUSTODYCD.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSBANKID
        '
        Me.lblSBANKID.Location = New System.Drawing.Point(5, 135)
        Me.lblSBANKID.Name = "lblSBANKID"
        Me.lblSBANKID.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblSBANKID.Size = New System.Drawing.Size(274, 18)
        Me.lblSBANKID.TabIndex = 10
        Me.lblSBANKID.Tag = "SBANKID"
        Me.lblSBANKID.Text = "lblSBANKID"
        Me.lblSBANKID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSBANKACCOUNT
        '
        Me.txtSBANKACCOUNT.Location = New System.Drawing.Point(285, 110)
        Me.txtSBANKACCOUNT.Name = "txtSBANKACCOUNT"
        Me.txtSBANKACCOUNT.Size = New System.Drawing.Size(197, 21)
        Me.txtSBANKACCOUNT.TabIndex = 9
        Me.txtSBANKACCOUNT.Tag = "SBANKACCOUNT"
        '
        'lblSBANKACCOUNT
        '
        Me.lblSBANKACCOUNT.Location = New System.Drawing.Point(5, 110)
        Me.lblSBANKACCOUNT.Name = "lblSBANKACCOUNT"
        Me.lblSBANKACCOUNT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblSBANKACCOUNT.Size = New System.Drawing.Size(274, 18)
        Me.lblSBANKACCOUNT.TabIndex = 8
        Me.lblSBANKACCOUNT.Tag = "SBANKACCOUNT"
        Me.lblSBANKACCOUNT.Text = "lblSBANKACCOUNT"
        Me.lblSBANKACCOUNT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSFULLNAME
        '
        Me.txtSFULLNAME.Location = New System.Drawing.Point(285, 85)
        Me.txtSFULLNAME.Name = "txtSFULLNAME"
        Me.txtSFULLNAME.Size = New System.Drawing.Size(610, 21)
        Me.txtSFULLNAME.TabIndex = 7
        Me.txtSFULLNAME.Tag = "SFULLNAME"
        '
        'lblSFULLNAME
        '
        Me.lblSFULLNAME.Location = New System.Drawing.Point(5, 85)
        Me.lblSFULLNAME.Name = "lblSFULLNAME"
        Me.lblSFULLNAME.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblSFULLNAME.Size = New System.Drawing.Size(274, 18)
        Me.lblSFULLNAME.TabIndex = 6
        Me.lblSFULLNAME.Tag = "SFULLNAME"
        Me.lblSFULLNAME.Text = "lblSFULLNAME"
        Me.lblSFULLNAME.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSCUSTODYCD
        '
        Me.lblSCUSTODYCD.Location = New System.Drawing.Point(6, 61)
        Me.lblSCUSTODYCD.Name = "lblSCUSTODYCD"
        Me.lblSCUSTODYCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblSCUSTODYCD.Size = New System.Drawing.Size(274, 18)
        Me.lblSCUSTODYCD.TabIndex = 4
        Me.lblSCUSTODYCD.Tag = "SCUSTODYCD"
        Me.lblSCUSTODYCD.Text = "lblSCUSTODYCD"
        Me.lblSCUSTODYCD.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSIGNDATE
        '
        Me.lblSIGNDATE.Location = New System.Drawing.Point(9, 42)
        Me.lblSIGNDATE.Name = "lblSIGNDATE"
        Me.lblSIGNDATE.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblSIGNDATE.Size = New System.Drawing.Size(271, 15)
        Me.lblSIGNDATE.TabIndex = 3
        Me.lblSIGNDATE.Tag = "SIGNDATE"
        Me.lblSIGNDATE.Text = "lblSIGNDATE"
        Me.lblSIGNDATE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpSIGNDATE
        '
        Me.dtpSIGNDATE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpSIGNDATE.Location = New System.Drawing.Point(286, 37)
        Me.dtpSIGNDATE.Name = "dtpSIGNDATE"
        Me.dtpSIGNDATE.Size = New System.Drawing.Size(196, 21)
        Me.dtpSIGNDATE.TabIndex = 2
        Me.dtpSIGNDATE.Tag = "SIGNDATE"
        '
        'tpECROW_FILES
        '
        Me.tpECROW_FILES.BackColor = System.Drawing.SystemColors.Control
        Me.tpECROW_FILES.Location = New System.Drawing.Point(4, 22)
        Me.tpECROW_FILES.Name = "tpECROW_FILES"
        Me.tpECROW_FILES.Padding = New System.Windows.Forms.Padding(3)
        Me.tpECROW_FILES.Size = New System.Drawing.Size(917, 445)
        Me.tpECROW_FILES.TabIndex = 1
        Me.tpECROW_FILES.Tag = "tpECROW_FILES"
        Me.tpECROW_FILES.Text = "Tài liệu"
        '
        'DataTable8
        '
        Me.DataTable8.Namespace = ""
        Me.DataTable8.TableName = "COMBOBOX"
        '
        'DataTable9
        '
        Me.DataTable9.Namespace = ""
        Me.DataTable9.TableName = "COMBOBOX"
        '
        'DataTable10
        '
        Me.DataTable10.Namespace = ""
        Me.DataTable10.TableName = "COMBOBOX"
        '
        'DataTable11
        '
        Me.DataTable11.Namespace = ""
        Me.DataTable11.TableName = "COMBOBOX"
        '
        'frmESCROW
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(931, 564)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmESCROW"
        Me.Tag = "frmESCROW"
        Me.Text = "frmESCROW"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnApply, 0)
        Me.Controls.SetChildIndex(Me.cboLink, 0)
        Me.Controls.SetChildIndex(Me.btnApprv, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tpESCROW.ResumeLayout(False)
        Me.tpESCROW.PerformLayout()
        CType(Me.DataTable8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpESCROW As System.Windows.Forms.TabPage
    Friend WithEvents tpECROW_FILES As System.Windows.Forms.TabPage
    Friend WithEvents txtESCROWID As System.Windows.Forms.TextBox
    Friend WithEvents lblESCROWID As System.Windows.Forms.Label
    Friend WithEvents DataTable8 As System.Data.DataTable
    Friend WithEvents lblSIGNDATE As System.Windows.Forms.Label
    Friend WithEvents dtpSIGNDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents DataTable9 As System.Data.DataTable
    Friend WithEvents txtSFULLNAME As System.Windows.Forms.TextBox
    Friend WithEvents lblSFULLNAME As System.Windows.Forms.Label
    Friend WithEvents lblSCUSTODYCD As System.Windows.Forms.Label
    Friend WithEvents lblBCUSTODYCD As System.Windows.Forms.Label
    Friend WithEvents lblSBANKID As System.Windows.Forms.Label
    Friend WithEvents txtSBANKACCOUNT As System.Windows.Forms.TextBox
    Friend WithEvents lblSBANKACCOUNT As System.Windows.Forms.Label
    Friend WithEvents txtBFULLNAME As System.Windows.Forms.TextBox
    Friend WithEvents lblBFULLNAME As System.Windows.Forms.Label
    Friend WithEvents txtDESCRIPTION As System.Windows.Forms.TextBox
    Friend WithEvents lblDESCRIPTION As System.Windows.Forms.Label
    Friend WithEvents txtSRCACCTNO As System.Windows.Forms.TextBox
    Friend WithEvents lblSRCACCTNO As System.Windows.Forms.Label
    Friend WithEvents txtBLKAMT As System.Windows.Forms.TextBox
    Friend WithEvents lblBLKAMT As System.Windows.Forms.Label
    Friend WithEvents txtBLKRATE As System.Windows.Forms.TextBox
    Friend WithEvents lblBLKRATE As System.Windows.Forms.Label
    Friend WithEvents txtAMT As System.Windows.Forms.TextBox
    Friend WithEvents lblAMT As System.Windows.Forms.Label
    Friend WithEvents txtQTTY As System.Windows.Forms.TextBox
    Friend WithEvents lblQTTY As System.Windows.Forms.Label
    Friend WithEvents lblSYMBOL As System.Windows.Forms.Label
    Friend WithEvents lblBDDACCTNO_IICA As System.Windows.Forms.Label
    Friend WithEvents lblBDDACCTNO_ESCROW As System.Windows.Forms.Label
    Friend WithEvents DataTable10 As System.Data.DataTable
    Friend WithEvents txtSCUSTODYCD As System.Windows.Forms.TextBox
    Friend WithEvents txtBCUSTODYCD As System.Windows.Forms.TextBox
    Friend WithEvents txtSBANKID As System.Windows.Forms.TextBox
    Friend WithEvents cboBDDACCTNO_ESCROW As AppCore.ComboBoxEx
    Friend WithEvents cboBDDACCTNO_IICA As AppCore.ComboBoxEx
    Friend WithEvents txtSYMBOL As System.Windows.Forms.TextBox
    Friend WithEvents txtAUTOID As System.Windows.Forms.TextBox
    Friend WithEvents DataTable11 As System.Data.DataTable
    Friend WithEvents txtCODEID As System.Windows.Forms.TextBox
    Friend WithEvents txtSCUSTID As System.Windows.Forms.TextBox
    Friend WithEvents txtBCUSTID As System.Windows.Forms.TextBox
    Friend WithEvents lblSBANKID_REF As System.Windows.Forms.Label
End Class
