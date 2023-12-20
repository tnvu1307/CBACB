<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDetailFixOD
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDetailFixOD))
        Me.pnlTitle = New System.Windows.Forms.Panel
        Me.pnOrder = New System.Windows.Forms.Panel
        Me.lblTradeLot = New System.Windows.Forms.Label
        Me.txtTradeLot = New System.Windows.Forms.TextBox
        Me.txtAFACCTNO = New System.Windows.Forms.TextBox
        Me.lblAFACCTNO = New System.Windows.Forms.Label
        Me.btnExecute = New System.Windows.Forms.Button
        Me.txtEditQuantity = New System.Windows.Forms.TextBox
        Me.lblEditQuantity = New System.Windows.Forms.Label
        Me.txtCUSTODYCD = New System.Windows.Forms.TextBox
        Me.lblCUSTODYCD = New System.Windows.Forms.Label
        Me.txtEXECQTTY = New System.Windows.Forms.TextBox
        Me.lblEXECQTTY = New System.Windows.Forms.Label
        Me.txtREMAINQTTY = New System.Windows.Forms.TextBox
        Me.lblREMAINQTTY = New System.Windows.Forms.Label
        Me.chkAORN = New System.Windows.Forms.CheckBox
        Me.txtClearDay = New System.Windows.Forms.TextBox
        Me.lblClearDay = New System.Windows.Forms.Label
        Me.cboClearCD = New AppCore.ComboBoxEx
        Me.lblClearCD = New System.Windows.Forms.Label
        Me.txtOrderID = New System.Windows.Forms.TextBox
        Me.lblOrderID = New System.Windows.Forms.Label
        Me.txtExPrice = New System.Windows.Forms.TextBox
        Me.lblExPrice = New System.Windows.Forms.Label
        Me.txtExQuantity = New System.Windows.Forms.TextBox
        Me.lblExQuantity = New System.Windows.Forms.Label
        Me.txtPrice = New System.Windows.Forms.TextBox
        Me.lblPrice = New System.Windows.Forms.Label
        Me.txtQuantity = New System.Windows.Forms.TextBox
        Me.lblQuantity = New System.Windows.Forms.Label
        Me.lblSymbol = New System.Windows.Forms.Label
        Me.cboNORP = New AppCore.ComboBoxEx
        Me.lblNORP = New System.Windows.Forms.Label
        Me.lblBORS = New System.Windows.Forms.Label
        Me.cboBORS = New AppCore.ComboBoxEx
        Me.pnODDeailInfo = New System.Windows.Forms.Panel
        Me.pnOrder.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTitle
        '
        Me.pnlTitle.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitle.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(878, 50)
        Me.pnlTitle.TabIndex = 1
        '
        'pnOrder
        '
        Me.pnOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnOrder.Controls.Add(Me.lblTradeLot)
        Me.pnOrder.Controls.Add(Me.txtTradeLot)
        Me.pnOrder.Controls.Add(Me.txtAFACCTNO)
        Me.pnOrder.Controls.Add(Me.lblAFACCTNO)
        Me.pnOrder.Controls.Add(Me.btnExecute)
        Me.pnOrder.Controls.Add(Me.txtEditQuantity)
        Me.pnOrder.Controls.Add(Me.lblEditQuantity)
        Me.pnOrder.Controls.Add(Me.txtCUSTODYCD)
        Me.pnOrder.Controls.Add(Me.lblCUSTODYCD)
        Me.pnOrder.Controls.Add(Me.txtEXECQTTY)
        Me.pnOrder.Controls.Add(Me.lblEXECQTTY)
        Me.pnOrder.Controls.Add(Me.txtREMAINQTTY)
        Me.pnOrder.Controls.Add(Me.lblREMAINQTTY)
        Me.pnOrder.Controls.Add(Me.chkAORN)
        Me.pnOrder.Controls.Add(Me.txtClearDay)
        Me.pnOrder.Controls.Add(Me.lblClearDay)
        Me.pnOrder.Controls.Add(Me.cboClearCD)
        Me.pnOrder.Controls.Add(Me.lblClearCD)
        Me.pnOrder.Controls.Add(Me.txtOrderID)
        Me.pnOrder.Controls.Add(Me.lblOrderID)
        Me.pnOrder.Controls.Add(Me.txtExPrice)
        Me.pnOrder.Controls.Add(Me.lblExPrice)
        Me.pnOrder.Controls.Add(Me.txtExQuantity)
        Me.pnOrder.Controls.Add(Me.lblExQuantity)
        Me.pnOrder.Controls.Add(Me.txtPrice)
        Me.pnOrder.Controls.Add(Me.lblPrice)
        Me.pnOrder.Controls.Add(Me.txtQuantity)
        Me.pnOrder.Controls.Add(Me.lblQuantity)
        Me.pnOrder.Controls.Add(Me.lblSymbol)
        Me.pnOrder.Controls.Add(Me.cboNORP)
        Me.pnOrder.Controls.Add(Me.lblNORP)
        Me.pnOrder.Controls.Add(Me.lblBORS)
        Me.pnOrder.Controls.Add(Me.cboBORS)
        Me.pnOrder.Location = New System.Drawing.Point(12, 56)
        Me.pnOrder.Name = "pnOrder"
        Me.pnOrder.Size = New System.Drawing.Size(854, 94)
        Me.pnOrder.TabIndex = 2
        '
        'lblTradeLot
        '
        Me.lblTradeLot.Location = New System.Drawing.Point(535, 7)
        Me.lblTradeLot.Name = "lblTradeLot"
        Me.lblTradeLot.Size = New System.Drawing.Size(88, 21)
        Me.lblTradeLot.TabIndex = 53
        Me.lblTradeLot.Text = "lblTradeLot"
        '
        'txtTradeLot
        '
        Me.txtTradeLot.Location = New System.Drawing.Point(624, 9)
        Me.txtTradeLot.Name = "txtTradeLot"
        Me.txtTradeLot.Size = New System.Drawing.Size(95, 20)
        Me.txtTradeLot.TabIndex = 52
        Me.txtTradeLot.Tag = "12"
        Me.txtTradeLot.Text = "txtTradeLot"
        '
        'txtAFACCTNO
        '
        Me.txtAFACCTNO.BackColor = System.Drawing.Color.Cyan
        Me.txtAFACCTNO.Location = New System.Drawing.Point(152, 60)
        Me.txtAFACCTNO.Name = "txtAFACCTNO"
        Me.txtAFACCTNO.Size = New System.Drawing.Size(128, 20)
        Me.txtAFACCTNO.TabIndex = 49
        Me.txtAFACCTNO.Tag = "12"
        Me.txtAFACCTNO.Text = "txtAFACCTNO"
        '
        'lblAFACCTNO
        '
        Me.lblAFACCTNO.Location = New System.Drawing.Point(9, 65)
        Me.lblAFACCTNO.Name = "lblAFACCTNO"
        Me.lblAFACCTNO.Size = New System.Drawing.Size(137, 21)
        Me.lblAFACCTNO.TabIndex = 48
        Me.lblAFACCTNO.Text = "lblAFACCTNO"
        '
        'btnExecute
        '
        Me.btnExecute.Location = New System.Drawing.Point(624, 53)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(95, 25)
        Me.btnExecute.TabIndex = 47
        Me.btnExecute.Text = "btnExecute"
        Me.btnExecute.UseVisualStyleBackColor = True
        '
        'txtEditQuantity
        '
        Me.txtEditQuantity.Location = New System.Drawing.Point(392, 58)
        Me.txtEditQuantity.Name = "txtEditQuantity"
        Me.txtEditQuantity.Size = New System.Drawing.Size(95, 20)
        Me.txtEditQuantity.TabIndex = 46
        Me.txtEditQuantity.Tag = "12"
        Me.txtEditQuantity.Text = "txtEditQuantity"
        '
        'lblEditQuantity
        '
        Me.lblEditQuantity.Location = New System.Drawing.Point(299, 64)
        Me.lblEditQuantity.Name = "lblEditQuantity"
        Me.lblEditQuantity.Size = New System.Drawing.Size(88, 21)
        Me.lblEditQuantity.TabIndex = 45
        Me.lblEditQuantity.Text = "lblEditQuantity"
        '
        'txtCUSTODYCD
        '
        Me.txtCUSTODYCD.Location = New System.Drawing.Point(152, 34)
        Me.txtCUSTODYCD.Name = "txtCUSTODYCD"
        Me.txtCUSTODYCD.Size = New System.Drawing.Size(128, 20)
        Me.txtCUSTODYCD.TabIndex = 44
        Me.txtCUSTODYCD.Tag = "12"
        Me.txtCUSTODYCD.Text = "txtCUSTODYCD"
        '
        'lblCUSTODYCD
        '
        Me.lblCUSTODYCD.Location = New System.Drawing.Point(9, 38)
        Me.lblCUSTODYCD.Name = "lblCUSTODYCD"
        Me.lblCUSTODYCD.Size = New System.Drawing.Size(137, 21)
        Me.lblCUSTODYCD.TabIndex = 43
        Me.lblCUSTODYCD.Text = "lblCUSTODYCD"
        '
        'txtEXECQTTY
        '
        Me.txtEXECQTTY.Location = New System.Drawing.Point(392, 296)
        Me.txtEXECQTTY.Name = "txtEXECQTTY"
        Me.txtEXECQTTY.Size = New System.Drawing.Size(128, 20)
        Me.txtEXECQTTY.TabIndex = 12
        Me.txtEXECQTTY.Tag = "12"
        Me.txtEXECQTTY.Text = "txtEXECQTTY"
        '
        'lblEXECQTTY
        '
        Me.lblEXECQTTY.Location = New System.Drawing.Point(288, 296)
        Me.lblEXECQTTY.Name = "lblEXECQTTY"
        Me.lblEXECQTTY.Size = New System.Drawing.Size(104, 21)
        Me.lblEXECQTTY.TabIndex = 42
        Me.lblEXECQTTY.Text = "lblEXECQTTY"
        '
        'txtREMAINQTTY
        '
        Me.txtREMAINQTTY.Location = New System.Drawing.Point(152, 136)
        Me.txtREMAINQTTY.Name = "txtREMAINQTTY"
        Me.txtREMAINQTTY.Size = New System.Drawing.Size(128, 20)
        Me.txtREMAINQTTY.TabIndex = 10
        Me.txtREMAINQTTY.Tag = "12"
        Me.txtREMAINQTTY.Text = "txtREMAINQTTY"
        '
        'lblREMAINQTTY
        '
        Me.lblREMAINQTTY.Location = New System.Drawing.Point(32, 136)
        Me.lblREMAINQTTY.Name = "lblREMAINQTTY"
        Me.lblREMAINQTTY.Size = New System.Drawing.Size(104, 21)
        Me.lblREMAINQTTY.TabIndex = 40
        Me.lblREMAINQTTY.Text = "lblREMAINQTTY"
        '
        'chkAORN
        '
        Me.chkAORN.Location = New System.Drawing.Point(536, 296)
        Me.chkAORN.Name = "chkAORN"
        Me.chkAORN.Size = New System.Drawing.Size(80, 24)
        Me.chkAORN.TabIndex = 39
        Me.chkAORN.Text = "chkAORN"
        '
        'txtClearDay
        '
        Me.txtClearDay.Location = New System.Drawing.Point(136, 296)
        Me.txtClearDay.Name = "txtClearDay"
        Me.txtClearDay.Size = New System.Drawing.Size(128, 20)
        Me.txtClearDay.TabIndex = 11
        Me.txtClearDay.Tag = "12"
        Me.txtClearDay.Text = "txtClearDay"
        '
        'lblClearDay
        '
        Me.lblClearDay.Location = New System.Drawing.Point(16, 296)
        Me.lblClearDay.Name = "lblClearDay"
        Me.lblClearDay.Size = New System.Drawing.Size(112, 21)
        Me.lblClearDay.TabIndex = 36
        Me.lblClearDay.Text = "lblClearDay"
        '
        'cboClearCD
        '
        Me.cboClearCD.DisplayMember = "DISPLAY"
        Me.cboClearCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboClearCD.Location = New System.Drawing.Point(136, 264)
        Me.cboClearCD.Name = "cboClearCD"
        Me.cboClearCD.Size = New System.Drawing.Size(128, 21)
        Me.cboClearCD.TabIndex = 9
        Me.cboClearCD.Tag = "01"
        Me.cboClearCD.ValueMember = "VALUE"
        '
        'lblClearCD
        '
        Me.lblClearCD.Location = New System.Drawing.Point(16, 264)
        Me.lblClearCD.Name = "lblClearCD"
        Me.lblClearCD.Size = New System.Drawing.Size(112, 21)
        Me.lblClearCD.TabIndex = 34
        Me.lblClearCD.Text = "lblClearCD"
        '
        'txtOrderID
        '
        Me.txtOrderID.Location = New System.Drawing.Point(152, 8)
        Me.txtOrderID.Name = "txtOrderID"
        Me.txtOrderID.Size = New System.Drawing.Size(128, 20)
        Me.txtOrderID.TabIndex = 1
        Me.txtOrderID.Tag = "12"
        Me.txtOrderID.Text = "txtOrderID"
        '
        'lblOrderID
        '
        Me.lblOrderID.Location = New System.Drawing.Point(10, 12)
        Me.lblOrderID.Name = "lblOrderID"
        Me.lblOrderID.Size = New System.Drawing.Size(136, 21)
        Me.lblOrderID.TabIndex = 30
        Me.lblOrderID.Text = "lblOrderID"
        '
        'txtExPrice
        '
        Me.txtExPrice.Location = New System.Drawing.Point(624, 232)
        Me.txtExPrice.Name = "txtExPrice"
        Me.txtExPrice.Size = New System.Drawing.Size(120, 20)
        Me.txtExPrice.TabIndex = 8
        Me.txtExPrice.Tag = "11"
        Me.txtExPrice.Text = "txtExPrice"
        '
        'lblExPrice
        '
        Me.lblExPrice.Location = New System.Drawing.Point(520, 232)
        Me.lblExPrice.Name = "lblExPrice"
        Me.lblExPrice.Size = New System.Drawing.Size(104, 21)
        Me.lblExPrice.TabIndex = 28
        Me.lblExPrice.Text = "lblExPrice"
        '
        'txtExQuantity
        '
        Me.txtExQuantity.Location = New System.Drawing.Point(376, 232)
        Me.txtExQuantity.Name = "txtExQuantity"
        Me.txtExQuantity.Size = New System.Drawing.Size(128, 20)
        Me.txtExQuantity.TabIndex = 7
        Me.txtExQuantity.Tag = "12"
        Me.txtExQuantity.Text = "txtExQuantity"
        '
        'lblExQuantity
        '
        Me.lblExQuantity.Location = New System.Drawing.Point(272, 232)
        Me.lblExQuantity.Name = "lblExQuantity"
        Me.lblExQuantity.Size = New System.Drawing.Size(104, 21)
        Me.lblExQuantity.TabIndex = 26
        Me.lblExQuantity.Text = "lblExQuantity"
        '
        'txtPrice
        '
        Me.txtPrice.Location = New System.Drawing.Point(392, 7)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(95, 20)
        Me.txtPrice.TabIndex = 5
        Me.txtPrice.Tag = "11"
        Me.txtPrice.Text = "txtPrice"
        '
        'lblPrice
        '
        Me.lblPrice.Location = New System.Drawing.Point(299, 11)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.Size = New System.Drawing.Size(88, 21)
        Me.lblPrice.TabIndex = 24
        Me.lblPrice.Text = "lblPrice"
        '
        'txtQuantity
        '
        Me.txtQuantity.Location = New System.Drawing.Point(392, 33)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(95, 20)
        Me.txtQuantity.TabIndex = 4
        Me.txtQuantity.Tag = "12"
        Me.txtQuantity.Text = "txtQuantity"
        '
        'lblQuantity
        '
        Me.lblQuantity.Location = New System.Drawing.Point(298, 33)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(88, 21)
        Me.lblQuantity.TabIndex = 19
        Me.lblQuantity.Text = "lblQuantity"
        '
        'lblSymbol
        '
        Me.lblSymbol.Location = New System.Drawing.Point(312, 136)
        Me.lblSymbol.Name = "lblSymbol"
        Me.lblSymbol.Size = New System.Drawing.Size(112, 21)
        Me.lblSymbol.TabIndex = 22
        Me.lblSymbol.Text = "lblSymbol"
        '
        'cboNORP
        '
        Me.cboNORP.DisplayMember = "DISPLAY"
        Me.cboNORP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNORP.Location = New System.Drawing.Point(400, 264)
        Me.cboNORP.Name = "cboNORP"
        Me.cboNORP.Size = New System.Drawing.Size(128, 21)
        Me.cboNORP.TabIndex = 3
        Me.cboNORP.Tag = "22"
        Me.cboNORP.ValueMember = "VALUE"
        '
        'lblNORP
        '
        Me.lblNORP.Location = New System.Drawing.Point(280, 264)
        Me.lblNORP.Name = "lblNORP"
        Me.lblNORP.Size = New System.Drawing.Size(112, 21)
        Me.lblNORP.TabIndex = 13
        Me.lblNORP.Tag = "EXECTYPE"
        Me.lblNORP.Text = "lblNORP"
        '
        'lblBORS
        '
        Me.lblBORS.Location = New System.Drawing.Point(16, 232)
        Me.lblBORS.Name = "lblBORS"
        Me.lblBORS.Size = New System.Drawing.Size(112, 21)
        Me.lblBORS.TabIndex = 17
        Me.lblBORS.Tag = "BORS"
        Me.lblBORS.Text = "lblBORS"
        '
        'cboBORS
        '
        Me.cboBORS.DisplayMember = "DISPLAY"
        Me.cboBORS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBORS.Location = New System.Drawing.Point(136, 232)
        Me.cboBORS.Name = "cboBORS"
        Me.cboBORS.Size = New System.Drawing.Size(128, 21)
        Me.cboBORS.TabIndex = 0
        Me.cboBORS.Tag = "24"
        Me.cboBORS.ValueMember = "VALUE"
        '
        'pnODDeailInfo
        '
        Me.pnODDeailInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnODDeailInfo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnODDeailInfo.Location = New System.Drawing.Point(0, 156)
        Me.pnODDeailInfo.Name = "pnODDeailInfo"
        Me.pnODDeailInfo.Size = New System.Drawing.Size(878, 227)
        Me.pnODDeailInfo.TabIndex = 3
        '
        'frmDetailFixOD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ClientSize = New System.Drawing.Size(878, 383)
        Me.Controls.Add(Me.pnODDeailInfo)
        Me.Controls.Add(Me.pnOrder)
        Me.Controls.Add(Me.pnlTitle)
        Me.Name = "frmDetailFixOD"
        Me.Text = "frmDetailFixOD"
        Me.pnOrder.ResumeLayout(False)
        Me.pnOrder.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlTitle As System.Windows.Forms.Panel
    Friend WithEvents pnOrder As System.Windows.Forms.Panel
    Friend WithEvents txtEXECQTTY As System.Windows.Forms.TextBox
    Friend WithEvents lblEXECQTTY As System.Windows.Forms.Label
    Friend WithEvents txtREMAINQTTY As System.Windows.Forms.TextBox
    Friend WithEvents lblREMAINQTTY As System.Windows.Forms.Label
    Friend WithEvents chkAORN As System.Windows.Forms.CheckBox
    Friend WithEvents txtClearDay As System.Windows.Forms.TextBox
    Friend WithEvents lblClearDay As System.Windows.Forms.Label
    Friend WithEvents cboClearCD As AppCore.ComboBoxEx
    Friend WithEvents lblClearCD As System.Windows.Forms.Label
    Friend WithEvents txtOrderID As System.Windows.Forms.TextBox
    Friend WithEvents lblOrderID As System.Windows.Forms.Label
    Friend WithEvents txtExPrice As System.Windows.Forms.TextBox
    Friend WithEvents lblExPrice As System.Windows.Forms.Label
    Friend WithEvents txtExQuantity As System.Windows.Forms.TextBox
    Friend WithEvents lblExQuantity As System.Windows.Forms.Label
    Friend WithEvents txtPrice As System.Windows.Forms.TextBox
    Friend WithEvents lblPrice As System.Windows.Forms.Label
    Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents lblQuantity As System.Windows.Forms.Label
    Friend WithEvents lblSymbol As System.Windows.Forms.Label
    Friend WithEvents cboNORP As AppCore.ComboBoxEx
    Friend WithEvents lblNORP As System.Windows.Forms.Label
    Friend WithEvents lblBORS As System.Windows.Forms.Label
    Friend WithEvents cboBORS As AppCore.ComboBoxEx
    Friend WithEvents pnODDeailInfo As System.Windows.Forms.Panel
    Friend WithEvents lblCUSTODYCD As System.Windows.Forms.Label
    Friend WithEvents txtCUSTODYCD As System.Windows.Forms.TextBox
    Friend WithEvents lblEditQuantity As System.Windows.Forms.Label
    Friend WithEvents txtEditQuantity As System.Windows.Forms.TextBox
    Friend WithEvents btnExecute As System.Windows.Forms.Button
    Friend WithEvents lblAFACCTNO As System.Windows.Forms.Label
    Friend WithEvents txtTradeLot As System.Windows.Forms.TextBox
    Friend WithEvents lblTradeLot As System.Windows.Forms.Label
    Friend WithEvents txtAFACCTNO As System.Windows.Forms.TextBox

End Class
