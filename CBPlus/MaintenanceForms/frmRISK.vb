Imports AppCore
Imports CommonLibrary

Public Class frmRISK
    Inherits AppCore.frmMaintenance

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    'Friend WithEvents txtOPENPRICE As FlexMaskEditBox
    'Friend WithEvents txtCURRPRICE As FlexMaskEditBox
    'Friend WithEvents txtPREVCLOSEPRICE As FlexMaskEditBox
    'Friend WithEvents txtCEILINGPRICE As FlexMaskEditBox
    'Friend WithEvents txtAVGPRICE As FlexMaskEditBox
    'Friend WithEvents txtFLOORPRICE As FlexMaskEditBox
    'Friend WithEvents txtMTMPRICE As FlexMaskEditBox
    'Friend WithEvents txtDAYRANGE As FlexMaskEditBox
    'Friend WithEvents txtINTERNALASKPRICE As FlexMaskEditBox
    'Friend WithEvents txtINTERNALBIDPRICE As FlexMaskEditBox
    'Friend WithEvents txtPE As FlexMaskEditBox
    'Friend WithEvents txtEPS As FlexMaskEditBox

    'Friend WithEvents txtYEARRANGE As FlexMaskEditBox
    'Friend WithEvents txtLISTINGQTTY As FlexMaskEditBox
    'Friend WithEvents txtADJUSTQTTY As FlexMaskEditBox
    'Friend WithEvents txtADJUSTRATE As FlexMaskEditBox
    'Friend WithEvents txtREFERENCERATE As FlexMaskEditBox
    'Friend WithEvents txtBASICPRICE As FlexMaskEditBox
    'Friend WithEvents txtDIVYEILD As FlexMaskEditBox


    Friend WithEvents txtTELELIMITMIN As System.Windows.Forms.TextBox

    Friend WithEvents lblTELELIMITMIN As System.Windows.Forms.Label
    Friend WithEvents lblTELELIMITMAX As System.Windows.Forms.Label
    Friend WithEvents txtTELELIMITMAX As System.Windows.Forms.TextBox

    Friend WithEvents lblONLINELIMITMIN As System.Windows.Forms.Label
    Friend WithEvents txtONLINELIMITMIN As System.Windows.Forms.TextBox
    Friend WithEvents lblONLINELIMITMAX As System.Windows.Forms.Label
    Friend WithEvents txtONLINELIMITMAX As System.Windows.Forms.TextBox
    Friend WithEvents lblREPOLIMITMIN As System.Windows.Forms.Label
    Friend WithEvents txtREPOLIMITMIN As System.Windows.Forms.TextBox
    Friend WithEvents lblREPOLIMITMAX As System.Windows.Forms.Label
    Friend WithEvents txtREPOLIMITMAX As System.Windows.Forms.TextBox
    Friend WithEvents lblADVANCEDLIMITMIN As System.Windows.Forms.Label
    Friend WithEvents txtADVANCEDLIMITMIN As System.Windows.Forms.TextBox
    Friend WithEvents lblADVANCEDLIMITMAX As System.Windows.Forms.Label
    Friend WithEvents txtADVANCEDLIMITMAX As System.Windows.Forms.TextBox
    Friend WithEvents lblMARGINLIMITMIN As System.Windows.Forms.Label
    Friend WithEvents txtMARGINLIMITMIN As System.Windows.Forms.TextBox
    Friend WithEvents lblMARGINLIMITMAX As System.Windows.Forms.Label
    Friend WithEvents txtMARGINLIMITMAX As System.Windows.Forms.TextBox
    Friend WithEvents RELATION As System.Windows.Forms.TabControl
    Friend WithEvents tabRisk As System.Windows.Forms.TabPage
    Friend WithEvents lblMORTAGERATIOMIN As System.Windows.Forms.Label
    Friend WithEvents lblMORTAGERATIOMAX As System.Windows.Forms.Label
    Friend WithEvents txtMORTAGERATIOMIN As System.Windows.Forms.TextBox
    Friend WithEvents txtMORTAGERATIOMAX As System.Windows.Forms.TextBox
    Friend WithEvents lblSECUREDRATIOMIN As System.Windows.Forms.Label
    Friend WithEvents txtSECUREDRATIOMIN As System.Windows.Forms.TextBox
    Friend WithEvents lblSECUREDRATIOMAX As System.Windows.Forms.Label
    Friend WithEvents txtSECUREDRATIOMAX As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.RELATION = New System.Windows.Forms.TabControl
        Me.tabRisk = New System.Windows.Forms.TabPage
        Me.txtMORTAGERATIOMAX = New System.Windows.Forms.TextBox
        Me.txtMORTAGERATIOMIN = New System.Windows.Forms.TextBox
        Me.lblMORTAGERATIOMAX = New System.Windows.Forms.Label
        Me.lblMORTAGERATIOMIN = New System.Windows.Forms.Label
        Me.lblSECUREDRATIOMAX = New System.Windows.Forms.Label
        Me.txtSECUREDRATIOMAX = New System.Windows.Forms.TextBox
        Me.lblSECUREDRATIOMIN = New System.Windows.Forms.Label
        Me.txtSECUREDRATIOMIN = New System.Windows.Forms.TextBox
        Me.lblMARGINLIMITMAX = New System.Windows.Forms.Label
        Me.txtMARGINLIMITMAX = New System.Windows.Forms.TextBox
        Me.lblMARGINLIMITMIN = New System.Windows.Forms.Label
        Me.txtMARGINLIMITMIN = New System.Windows.Forms.TextBox
        Me.lblADVANCEDLIMITMAX = New System.Windows.Forms.Label
        Me.txtADVANCEDLIMITMAX = New System.Windows.Forms.TextBox
        Me.lblADVANCEDLIMITMIN = New System.Windows.Forms.Label
        Me.txtADVANCEDLIMITMIN = New System.Windows.Forms.TextBox
        Me.lblREPOLIMITMAX = New System.Windows.Forms.Label
        Me.txtREPOLIMITMAX = New System.Windows.Forms.TextBox
        Me.lblREPOLIMITMIN = New System.Windows.Forms.Label
        Me.txtREPOLIMITMIN = New System.Windows.Forms.TextBox
        Me.lblONLINELIMITMAX = New System.Windows.Forms.Label
        Me.txtONLINELIMITMAX = New System.Windows.Forms.TextBox
        Me.lblONLINELIMITMIN = New System.Windows.Forms.Label
        Me.txtONLINELIMITMIN = New System.Windows.Forms.TextBox
        Me.lblTELELIMITMAX = New System.Windows.Forms.Label
        Me.txtTELELIMITMAX = New System.Windows.Forms.TextBox
        Me.lblTELELIMITMIN = New System.Windows.Forms.Label
        Me.txtTELELIMITMIN = New System.Windows.Forms.TextBox
        Me.RELATION.SuspendLayout()
        Me.tabRisk.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(428, 326)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 24)
        Me.btnOK.TabIndex = 1
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(588, 326)
        Me.btnApply.Name = "btnApply"
        '
        'lblCaption
        '
        Me.lblCaption.Location = New System.Drawing.Point(7, 17)
        Me.lblCaption.Name = "lblCaption"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(508, 326)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 24)
        Me.btnCancel.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(666, 50)
        '
        'RELATION
        '
        Me.RELATION.Controls.Add(Me.tabRisk)
        Me.RELATION.Location = New System.Drawing.Point(6, 56)
        Me.RELATION.Name = "RELATION"
        Me.RELATION.SelectedIndex = 0
        Me.RELATION.Size = New System.Drawing.Size(658, 264)
        Me.RELATION.TabIndex = 0
        Me.RELATION.Tag = "RELATION"
        '
        'tabRisk
        '
        Me.tabRisk.Controls.Add(Me.txtMORTAGERATIOMAX)
        Me.tabRisk.Controls.Add(Me.txtMORTAGERATIOMIN)
        Me.tabRisk.Controls.Add(Me.lblMORTAGERATIOMAX)
        Me.tabRisk.Controls.Add(Me.lblMORTAGERATIOMIN)
        Me.tabRisk.Controls.Add(Me.lblSECUREDRATIOMAX)
        Me.tabRisk.Controls.Add(Me.txtSECUREDRATIOMAX)
        Me.tabRisk.Controls.Add(Me.lblSECUREDRATIOMIN)
        Me.tabRisk.Controls.Add(Me.txtSECUREDRATIOMIN)
        Me.tabRisk.Controls.Add(Me.lblMARGINLIMITMAX)
        Me.tabRisk.Controls.Add(Me.txtMARGINLIMITMAX)
        Me.tabRisk.Controls.Add(Me.lblMARGINLIMITMIN)
        Me.tabRisk.Controls.Add(Me.txtMARGINLIMITMIN)
        Me.tabRisk.Controls.Add(Me.lblADVANCEDLIMITMAX)
        Me.tabRisk.Controls.Add(Me.txtADVANCEDLIMITMAX)
        Me.tabRisk.Controls.Add(Me.lblADVANCEDLIMITMIN)
        Me.tabRisk.Controls.Add(Me.txtADVANCEDLIMITMIN)
        Me.tabRisk.Controls.Add(Me.lblREPOLIMITMAX)
        Me.tabRisk.Controls.Add(Me.txtREPOLIMITMAX)
        Me.tabRisk.Controls.Add(Me.lblREPOLIMITMIN)
        Me.tabRisk.Controls.Add(Me.txtREPOLIMITMIN)
        Me.tabRisk.Controls.Add(Me.lblONLINELIMITMAX)
        Me.tabRisk.Controls.Add(Me.txtONLINELIMITMAX)
        Me.tabRisk.Controls.Add(Me.lblONLINELIMITMIN)
        Me.tabRisk.Controls.Add(Me.txtONLINELIMITMIN)
        Me.tabRisk.Controls.Add(Me.lblTELELIMITMAX)
        Me.tabRisk.Controls.Add(Me.txtTELELIMITMAX)
        Me.tabRisk.Controls.Add(Me.lblTELELIMITMIN)
        Me.tabRisk.Controls.Add(Me.txtTELELIMITMIN)
        Me.tabRisk.Location = New System.Drawing.Point(4, 22)
        Me.tabRisk.Name = "tabRisk"
        Me.tabRisk.Size = New System.Drawing.Size(650, 238)
        Me.tabRisk.TabIndex = 1
        Me.tabRisk.Tag = "tabRisk"
        Me.tabRisk.Text = "tabRisk"
        '
        'txtMORTAGERATIOMAX
        '
        Me.txtMORTAGERATIOMAX.Location = New System.Drawing.Point(488, 188)
        Me.txtMORTAGERATIOMAX.Name = "txtMORTAGERATIOMAX"
        Me.txtMORTAGERATIOMAX.Size = New System.Drawing.Size(152, 21)
        Me.txtMORTAGERATIOMAX.TabIndex = 13
        Me.txtMORTAGERATIOMAX.Tag = "MORTAGERATIOMAX"
        Me.txtMORTAGERATIOMAX.Text = "txtMORTAGERATIOMAX"
        '
        'txtMORTAGERATIOMIN
        '
        Me.txtMORTAGERATIOMIN.Location = New System.Drawing.Point(168, 188)
        Me.txtMORTAGERATIOMIN.Name = "txtMORTAGERATIOMIN"
        Me.txtMORTAGERATIOMIN.Size = New System.Drawing.Size(152, 21)
        Me.txtMORTAGERATIOMIN.TabIndex = 12
        Me.txtMORTAGERATIOMIN.Tag = "MORTAGERATIOMIN"
        Me.txtMORTAGERATIOMIN.Text = "txtMORTAGERATIOMIN"
        '
        'lblMORTAGERATIOMAX
        '
        Me.lblMORTAGERATIOMAX.Location = New System.Drawing.Point(336, 188)
        Me.lblMORTAGERATIOMAX.Name = "lblMORTAGERATIOMAX"
        Me.lblMORTAGERATIOMAX.Size = New System.Drawing.Size(144, 21)
        Me.lblMORTAGERATIOMAX.TabIndex = 25
        Me.lblMORTAGERATIOMAX.Tag = "MORTAGERATIOMAX"
        Me.lblMORTAGERATIOMAX.Text = "lblMORTAGERATIOMAX"
        '
        'lblMORTAGERATIOMIN
        '
        Me.lblMORTAGERATIOMIN.Location = New System.Drawing.Point(18, 188)
        Me.lblMORTAGERATIOMIN.Name = "lblMORTAGERATIOMIN"
        Me.lblMORTAGERATIOMIN.Size = New System.Drawing.Size(144, 21)
        Me.lblMORTAGERATIOMIN.TabIndex = 24
        Me.lblMORTAGERATIOMIN.Tag = "MORTAGERATIOMIN"
        Me.lblMORTAGERATIOMIN.Text = "lblMORTAGERATIOMIN"
        '
        'lblSECUREDRATIOMAX
        '
        Me.lblSECUREDRATIOMAX.Location = New System.Drawing.Point(336, 159)
        Me.lblSECUREDRATIOMAX.Name = "lblSECUREDRATIOMAX"
        Me.lblSECUREDRATIOMAX.Size = New System.Drawing.Size(144, 21)
        Me.lblSECUREDRATIOMAX.TabIndex = 23
        Me.lblSECUREDRATIOMAX.Tag = "SECUREDRATIOMAX"
        Me.lblSECUREDRATIOMAX.Text = "lblSECUREDRATIOMAX"
        '
        'txtSECUREDRATIOMAX
        '
        Me.txtSECUREDRATIOMAX.Location = New System.Drawing.Point(488, 159)
        Me.txtSECUREDRATIOMAX.Name = "txtSECUREDRATIOMAX"
        Me.txtSECUREDRATIOMAX.Size = New System.Drawing.Size(152, 21)
        Me.txtSECUREDRATIOMAX.TabIndex = 11
        Me.txtSECUREDRATIOMAX.Tag = "SECUREDRATIOMAX"
        Me.txtSECUREDRATIOMAX.Text = "txtSECUREDRATIOMAX"
        '
        'lblSECUREDRATIOMIN
        '
        Me.lblSECUREDRATIOMIN.Location = New System.Drawing.Point(18, 159)
        Me.lblSECUREDRATIOMIN.Name = "lblSECUREDRATIOMIN"
        Me.lblSECUREDRATIOMIN.Size = New System.Drawing.Size(144, 21)
        Me.lblSECUREDRATIOMIN.TabIndex = 21
        Me.lblSECUREDRATIOMIN.Tag = "SECUREDRATIOMIN"
        Me.lblSECUREDRATIOMIN.Text = "lblSECUREDRATIOMIN"
        '
        'txtSECUREDRATIOMIN
        '
        Me.txtSECUREDRATIOMIN.Location = New System.Drawing.Point(168, 159)
        Me.txtSECUREDRATIOMIN.Name = "txtSECUREDRATIOMIN"
        Me.txtSECUREDRATIOMIN.Size = New System.Drawing.Size(152, 21)
        Me.txtSECUREDRATIOMIN.TabIndex = 10
        Me.txtSECUREDRATIOMIN.Tag = "SECUREDRATIOMIN"
        Me.txtSECUREDRATIOMIN.Text = "txtSECUREDRATIOMIN"
        '
        'lblMARGINLIMITMAX
        '
        Me.lblMARGINLIMITMAX.Location = New System.Drawing.Point(336, 130)
        Me.lblMARGINLIMITMAX.Name = "lblMARGINLIMITMAX"
        Me.lblMARGINLIMITMAX.Size = New System.Drawing.Size(144, 21)
        Me.lblMARGINLIMITMAX.TabIndex = 19
        Me.lblMARGINLIMITMAX.Tag = "MARGINLIMITMAX"
        Me.lblMARGINLIMITMAX.Text = "lblMARGINLIMITMAX"
        '
        'txtMARGINLIMITMAX
        '
        Me.txtMARGINLIMITMAX.Location = New System.Drawing.Point(488, 130)
        Me.txtMARGINLIMITMAX.Name = "txtMARGINLIMITMAX"
        Me.txtMARGINLIMITMAX.Size = New System.Drawing.Size(152, 21)
        Me.txtMARGINLIMITMAX.TabIndex = 9
        Me.txtMARGINLIMITMAX.Tag = "MARGINLIMITMAX"
        Me.txtMARGINLIMITMAX.Text = "txtMARGINLIMITMAX"
        '
        'lblMARGINLIMITMIN
        '
        Me.lblMARGINLIMITMIN.Location = New System.Drawing.Point(18, 130)
        Me.lblMARGINLIMITMIN.Name = "lblMARGINLIMITMIN"
        Me.lblMARGINLIMITMIN.Size = New System.Drawing.Size(144, 21)
        Me.lblMARGINLIMITMIN.TabIndex = 17
        Me.lblMARGINLIMITMIN.Tag = "MARGINLIMITMIN"
        Me.lblMARGINLIMITMIN.Text = "lblMARGINLIMITMIN"
        '
        'txtMARGINLIMITMIN
        '
        Me.txtMARGINLIMITMIN.Location = New System.Drawing.Point(168, 130)
        Me.txtMARGINLIMITMIN.Name = "txtMARGINLIMITMIN"
        Me.txtMARGINLIMITMIN.Size = New System.Drawing.Size(152, 21)
        Me.txtMARGINLIMITMIN.TabIndex = 8
        Me.txtMARGINLIMITMIN.Tag = "MARGINLIMITMIN"
        Me.txtMARGINLIMITMIN.Text = "txtMARGINLIMITMIN"
        '
        'lblADVANCEDLIMITMAX
        '
        Me.lblADVANCEDLIMITMAX.Location = New System.Drawing.Point(336, 101)
        Me.lblADVANCEDLIMITMAX.Name = "lblADVANCEDLIMITMAX"
        Me.lblADVANCEDLIMITMAX.Size = New System.Drawing.Size(144, 21)
        Me.lblADVANCEDLIMITMAX.TabIndex = 15
        Me.lblADVANCEDLIMITMAX.Tag = "ADVANCEDLIMITMAX"
        Me.lblADVANCEDLIMITMAX.Text = "lblADVANCEDLIMITMAX"
        '
        'txtADVANCEDLIMITMAX
        '
        Me.txtADVANCEDLIMITMAX.Location = New System.Drawing.Point(488, 101)
        Me.txtADVANCEDLIMITMAX.Name = "txtADVANCEDLIMITMAX"
        Me.txtADVANCEDLIMITMAX.Size = New System.Drawing.Size(152, 21)
        Me.txtADVANCEDLIMITMAX.TabIndex = 7
        Me.txtADVANCEDLIMITMAX.Tag = "ADVANCEDLIMITMAX"
        Me.txtADVANCEDLIMITMAX.Text = "txtADVANCEDLIMITMAX"
        '
        'lblADVANCEDLIMITMIN
        '
        Me.lblADVANCEDLIMITMIN.Location = New System.Drawing.Point(18, 101)
        Me.lblADVANCEDLIMITMIN.Name = "lblADVANCEDLIMITMIN"
        Me.lblADVANCEDLIMITMIN.Size = New System.Drawing.Size(144, 21)
        Me.lblADVANCEDLIMITMIN.TabIndex = 13
        Me.lblADVANCEDLIMITMIN.Tag = "ADVANCEDLIMITMIN"
        Me.lblADVANCEDLIMITMIN.Text = "lblADVANCEDLIMITMIN"
        '
        'txtADVANCEDLIMITMIN
        '
        Me.txtADVANCEDLIMITMIN.Location = New System.Drawing.Point(168, 101)
        Me.txtADVANCEDLIMITMIN.Name = "txtADVANCEDLIMITMIN"
        Me.txtADVANCEDLIMITMIN.Size = New System.Drawing.Size(152, 21)
        Me.txtADVANCEDLIMITMIN.TabIndex = 6
        Me.txtADVANCEDLIMITMIN.Tag = "ADVANCEDLIMITMIN"
        Me.txtADVANCEDLIMITMIN.Text = "txtADVANCEDLIMITMIN"
        '
        'lblREPOLIMITMAX
        '
        Me.lblREPOLIMITMAX.Location = New System.Drawing.Point(336, 72)
        Me.lblREPOLIMITMAX.Name = "lblREPOLIMITMAX"
        Me.lblREPOLIMITMAX.Size = New System.Drawing.Size(144, 21)
        Me.lblREPOLIMITMAX.TabIndex = 11
        Me.lblREPOLIMITMAX.Tag = "REPOLIMITMAX"
        Me.lblREPOLIMITMAX.Text = "lblREPOLIMITMAX"
        '
        'txtREPOLIMITMAX
        '
        Me.txtREPOLIMITMAX.Location = New System.Drawing.Point(488, 72)
        Me.txtREPOLIMITMAX.Name = "txtREPOLIMITMAX"
        Me.txtREPOLIMITMAX.Size = New System.Drawing.Size(152, 21)
        Me.txtREPOLIMITMAX.TabIndex = 5
        Me.txtREPOLIMITMAX.Tag = "REPOLIMITMAX"
        Me.txtREPOLIMITMAX.Text = "txtREPOLIMITMAX"
        '
        'lblREPOLIMITMIN
        '
        Me.lblREPOLIMITMIN.Location = New System.Drawing.Point(18, 72)
        Me.lblREPOLIMITMIN.Name = "lblREPOLIMITMIN"
        Me.lblREPOLIMITMIN.Size = New System.Drawing.Size(144, 21)
        Me.lblREPOLIMITMIN.TabIndex = 9
        Me.lblREPOLIMITMIN.Tag = "REPOLIMITMIN"
        Me.lblREPOLIMITMIN.Text = "lblREPOLIMITMIN"
        '
        'txtREPOLIMITMIN
        '
        Me.txtREPOLIMITMIN.Location = New System.Drawing.Point(168, 72)
        Me.txtREPOLIMITMIN.Name = "txtREPOLIMITMIN"
        Me.txtREPOLIMITMIN.Size = New System.Drawing.Size(152, 21)
        Me.txtREPOLIMITMIN.TabIndex = 4
        Me.txtREPOLIMITMIN.Tag = "REPOLIMITMIN"
        Me.txtREPOLIMITMIN.Text = "txtREPOLIMITMIN"
        '
        'lblONLINELIMITMAX
        '
        Me.lblONLINELIMITMAX.Location = New System.Drawing.Point(336, 43)
        Me.lblONLINELIMITMAX.Name = "lblONLINELIMITMAX"
        Me.lblONLINELIMITMAX.Size = New System.Drawing.Size(144, 21)
        Me.lblONLINELIMITMAX.TabIndex = 7
        Me.lblONLINELIMITMAX.Tag = "ONLINELIMITMAX"
        Me.lblONLINELIMITMAX.Text = "lblONLINELIMITMAX"
        '
        'txtONLINELIMITMAX
        '
        Me.txtONLINELIMITMAX.Location = New System.Drawing.Point(488, 43)
        Me.txtONLINELIMITMAX.Name = "txtONLINELIMITMAX"
        Me.txtONLINELIMITMAX.Size = New System.Drawing.Size(152, 21)
        Me.txtONLINELIMITMAX.TabIndex = 3
        Me.txtONLINELIMITMAX.Tag = "ONLINELIMITMAX"
        Me.txtONLINELIMITMAX.Text = "txtONLINELIMITMAX"
        '
        'lblONLINELIMITMIN
        '
        Me.lblONLINELIMITMIN.Location = New System.Drawing.Point(18, 43)
        Me.lblONLINELIMITMIN.Name = "lblONLINELIMITMIN"
        Me.lblONLINELIMITMIN.Size = New System.Drawing.Size(144, 21)
        Me.lblONLINELIMITMIN.TabIndex = 5
        Me.lblONLINELIMITMIN.Tag = "ONLINELIMITMIN"
        Me.lblONLINELIMITMIN.Text = "lblONLINELIMITMIN"
        '
        'txtONLINELIMITMIN
        '
        Me.txtONLINELIMITMIN.Location = New System.Drawing.Point(168, 43)
        Me.txtONLINELIMITMIN.Name = "txtONLINELIMITMIN"
        Me.txtONLINELIMITMIN.Size = New System.Drawing.Size(152, 21)
        Me.txtONLINELIMITMIN.TabIndex = 2
        Me.txtONLINELIMITMIN.Tag = "ONLINELIMITMIN"
        Me.txtONLINELIMITMIN.Text = "txtONLINELIMITMIN"
        '
        'lblTELELIMITMAX
        '
        Me.lblTELELIMITMAX.Location = New System.Drawing.Point(336, 14)
        Me.lblTELELIMITMAX.Name = "lblTELELIMITMAX"
        Me.lblTELELIMITMAX.Size = New System.Drawing.Size(144, 21)
        Me.lblTELELIMITMAX.TabIndex = 3
        Me.lblTELELIMITMAX.Tag = "TELELIMITMAX"
        Me.lblTELELIMITMAX.Text = "lblTELELIMITMAX"
        '
        'txtTELELIMITMAX
        '
        Me.txtTELELIMITMAX.Location = New System.Drawing.Point(488, 14)
        Me.txtTELELIMITMAX.Name = "txtTELELIMITMAX"
        Me.txtTELELIMITMAX.Size = New System.Drawing.Size(152, 21)
        Me.txtTELELIMITMAX.TabIndex = 1
        Me.txtTELELIMITMAX.Tag = "TELELIMITMAX"
        Me.txtTELELIMITMAX.Text = "txtTELELIMITMAX"
        '
        'lblTELELIMITMIN
        '
        Me.lblTELELIMITMIN.Location = New System.Drawing.Point(18, 14)
        Me.lblTELELIMITMIN.Name = "lblTELELIMITMIN"
        Me.lblTELELIMITMIN.Size = New System.Drawing.Size(144, 21)
        Me.lblTELELIMITMIN.TabIndex = 1
        Me.lblTELELIMITMIN.Tag = "TELELIMITMIN"
        Me.lblTELELIMITMIN.Text = "lblTELELIMITMIN"
        '
        'txtTELELIMITMIN
        '
        Me.txtTELELIMITMIN.Location = New System.Drawing.Point(168, 14)
        Me.txtTELELIMITMIN.Name = "txtTELELIMITMIN"
        Me.txtTELELIMITMIN.Size = New System.Drawing.Size(152, 21)
        Me.txtTELELIMITMIN.TabIndex = 0
        Me.txtTELELIMITMIN.Tag = "TELELIMITMIN"
        Me.txtTELELIMITMIN.Text = "txtTELELIMITMIN"
        '
        'frmRISK
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(666, 351)
        Me.Controls.Add(Me.RELATION)
        Me.Name = "frmRISK"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "RISK"
        Me.Text = "frmRISK"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnApply, 0)
        Me.Controls.SetChildIndex(Me.RELATION, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.RELATION.ResumeLayout(False)
        Me.tabRisk.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Overrides Methods "
    Public Overrides Sub OnInit()
        Dim v_ctrl As Windows.Forms.Control

        Try
            MyBase.OnInit()


            'Load Resource Manager
            ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & Me.Name & "-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            LoadUserInterface(Me)

            'Me.tabGeneral.Dispose()
            '  Me.TabPage1.Dispose()
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("InitDialogFailed"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Public Overrides Sub OnSave()
        Dim v_strObjMsg As String

        Try
            'Update mouse pointer
            Cursor.Current = Cursors.WaitCursor

            MyBase.OnSave()
            If Not DoDataExchange(True) Then
                Exit Sub
            End If

            Select Case ExeFlag
                Case ExecuteFlag.AddNew
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdd, , , , gc_AutoIdUsed)
                    BuildXMLObjData(mv_dsInput, v_strObjMsg)

                    Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                    Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                    'Kiểm tra thông tin và xử lý lỗi (nếu có) từ message trả về
                    Dim v_strErrorSource, v_strErrorMessage As String                    

                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text)
                        Exit Sub
                    End If

                    MsgBox(ResourceManager.GetString("AddnewSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
                    Me.DialogResult = DialogResult.OK
                    MyBase.OnClose()
                Case ExecuteFlag.Edit
                    Dim v_strClause As String

                    Select Case KeyFieldType
                        Case "C"
                            v_strClause = KeyFieldName & " = '" & KeyFieldValue & "'"
                        Case "D"
                            v_strClause = KeyFieldName & " = TO_DATE('" & KeyFieldValue & "', '" & gc_FORMAT_DATE & "')"
                        Case "N"
                            v_strClause = KeyFieldName & " = " & KeyFieldValue.ToString()
                    End Select

                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionEdit, , v_strClause)
                    BuildXMLObjData(mv_dsInput, v_strObjMsg, mv_dsOldInput, ExecuteFlag.Edit)

                    Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                    Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                    'Kiểm tra thông tin và xử lý lỗi (nếu có) từ message trả về
                    Dim v_strErrorSource, v_strErrorMessage As String                    

                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text)
                        Exit Sub
                    End If

                    MsgBox(ResourceManager.GetString("EditSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
                    Me.DialogResult = DialogResult.OK
                    MyBase.OnClose()
            End Select

            'Update mouse pointer
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("SavingFailed"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Public Overrides Function DoDataExchange(Optional ByVal pv_blnSaved As Boolean = False) As Boolean
        Try
            If Not ControlValidation(pv_blnSaved) Then
                Return False
            End If

            Return MyBase.DoDataExchange(pv_blnSaved)
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function

    Overrides Sub LoadUserInterface(ByRef pv_ctrl As Windows.Forms.Control)
        MyBase.LoadUserInterface(pv_ctrl)

        'Sửa chỗ này cho từng form maintenance khác nhau
        If (ExeFlag = ExecuteFlag.Edit) Then
            ' Me.txtCODEID.Enabled = False
        End If
    End Sub
#End Region

#Region " Control validations "
    Private Function ControlValidation(Optional ByVal pv_blnSaved As Boolean = False) As Boolean
        Try
            If pv_blnSaved Then
                Return MyBase.VerifyRules()
            End If

            Return True
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function
#End Region


End Class
