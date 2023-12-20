Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports CommonLibrary
Imports System.Collections
Imports AppCore.modCoreLib
Imports AppCore
Public Class frmRPTransact
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

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
    Friend WithEvents lblSymbol As System.Windows.Forms.Label
    Friend WithEvents lblQuantity As System.Windows.Forms.Label
    Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCANCEL As System.Windows.Forms.Button
    Friend WithEvents lblAFACCTNO As System.Windows.Forms.Label
    Friend WithEvents lblExecType As System.Windows.Forms.Label
    Friend WithEvents lblMatchType As System.Windows.Forms.Label
    Friend WithEvents mskAFACCTNO As System.Windows.Forms.TextBox
    Friend WithEvents cboExecType As ComboBoxEx
    Friend WithEvents cboMatchType As ComboBoxEx
    Friend WithEvents cboCODEID As ComboBoxEx
    Friend WithEvents lblAFNAME As System.Windows.Forms.Label
    Friend WithEvents txtContractRate As System.Windows.Forms.TextBox
    Friend WithEvents lblContractRate As System.Windows.Forms.Label
    Friend WithEvents cboCARight As AppCore.ComboBoxEx
    Friend WithEvents lblCARight As System.Windows.Forms.Label
    Friend WithEvents txtBreakTerm As System.Windows.Forms.TextBox
    Friend WithEvents lblBreakTerm As System.Windows.Forms.Label
    Friend WithEvents lblTPRRate As System.Windows.Forms.Label
    Friend WithEvents txtTPRRate As System.Windows.Forms.TextBox
    Friend WithEvents lblRPDate As System.Windows.Forms.Label
    Friend WithEvents lblPenanty As System.Windows.Forms.Label
    Friend WithEvents txtPenanty As System.Windows.Forms.TextBox
    Friend WithEvents dtpRPDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblRPACCTNO As System.Windows.Forms.Label
    Friend WithEvents pnSpot As System.Windows.Forms.Panel
    Friend WithEvents pnForward As System.Windows.Forms.Panel
    Friend WithEvents txtSpotValue As System.Windows.Forms.TextBox
    Friend WithEvents lblSpotValue As System.Windows.Forms.Label
    Friend WithEvents dtpSpotDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblSpot As System.Windows.Forms.Label
    Friend WithEvents txtForwardPrice As System.Windows.Forms.TextBox
    Friend WithEvents lblForwardPrice As System.Windows.Forms.Label
    Friend WithEvents lblForwardValue As System.Windows.Forms.Label
    Friend WithEvents txtForwardValue As System.Windows.Forms.TextBox
    Friend WithEvents lblForwardDate As System.Windows.Forms.Label
    Friend WithEvents lblForward As System.Windows.Forms.Label
    Friend WithEvents lblSpotPrice As System.Windows.Forms.Label
    Friend WithEvents lblSpotDate As System.Windows.Forms.Label
    Friend WithEvents txtSpotPrice As System.Windows.Forms.TextBox
    Friend WithEvents cboYearDay As AppCore.ComboBoxEx
    Friend WithEvents lblYearDay As System.Windows.Forms.Label
    Friend WithEvents dtpForwardDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents pnRepo As System.Windows.Forms.Panel
    Friend WithEvents lblACCTNO As System.Windows.Forms.Label
    Friend WithEvents txtSECUREDRATIO As System.Windows.Forms.TextBox
    Friend WithEvents lblSECUREDRATIO As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.pnlTitle = New System.Windows.Forms.Panel
        Me.lblAFNAME = New System.Windows.Forms.Label
        Me.mskAFACCTNO = New System.Windows.Forms.TextBox
        Me.lblAFACCTNO = New System.Windows.Forms.Label
        Me.pnRepo = New System.Windows.Forms.Panel
        Me.txtSECUREDRATIO = New System.Windows.Forms.TextBox
        Me.lblSECUREDRATIO = New System.Windows.Forms.Label
        Me.cboYearDay = New AppCore.ComboBoxEx
        Me.lblYearDay = New System.Windows.Forms.Label
        Me.cboCODEID = New AppCore.ComboBoxEx
        Me.txtContractRate = New System.Windows.Forms.TextBox
        Me.lblContractRate = New System.Windows.Forms.Label
        Me.cboCARight = New AppCore.ComboBoxEx
        Me.lblCARight = New System.Windows.Forms.Label
        Me.txtQuantity = New System.Windows.Forms.TextBox
        Me.lblQuantity = New System.Windows.Forms.Label
        Me.lblSymbol = New System.Windows.Forms.Label
        Me.cboExecType = New AppCore.ComboBoxEx
        Me.lblExecType = New System.Windows.Forms.Label
        Me.lblMatchType = New System.Windows.Forms.Label
        Me.cboMatchType = New AppCore.ComboBoxEx
        Me.txtBreakTerm = New System.Windows.Forms.TextBox
        Me.lblBreakTerm = New System.Windows.Forms.Label
        Me.lblTPRRate = New System.Windows.Forms.Label
        Me.txtTPRRate = New System.Windows.Forms.TextBox
        Me.lblRPDate = New System.Windows.Forms.Label
        Me.lblPenanty = New System.Windows.Forms.Label
        Me.txtPenanty = New System.Windows.Forms.TextBox
        Me.dtpRPDate = New System.Windows.Forms.DateTimePicker
        Me.lblRPACCTNO = New System.Windows.Forms.Label
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCANCEL = New System.Windows.Forms.Button
        Me.pnSpot = New System.Windows.Forms.Panel
        Me.lblSpot = New System.Windows.Forms.Label
        Me.lblSpotPrice = New System.Windows.Forms.Label
        Me.txtSpotPrice = New System.Windows.Forms.TextBox
        Me.txtSpotValue = New System.Windows.Forms.TextBox
        Me.lblSpotValue = New System.Windows.Forms.Label
        Me.lblSpotDate = New System.Windows.Forms.Label
        Me.dtpSpotDate = New System.Windows.Forms.DateTimePicker
        Me.pnForward = New System.Windows.Forms.Panel
        Me.txtForwardPrice = New System.Windows.Forms.TextBox
        Me.lblForwardPrice = New System.Windows.Forms.Label
        Me.lblForwardValue = New System.Windows.Forms.Label
        Me.txtForwardValue = New System.Windows.Forms.TextBox
        Me.dtpForwardDate = New System.Windows.Forms.DateTimePicker
        Me.lblForwardDate = New System.Windows.Forms.Label
        Me.lblForward = New System.Windows.Forms.Label
        Me.lblACCTNO = New System.Windows.Forms.Label
        Me.pnlTitle.SuspendLayout()
        Me.pnRepo.SuspendLayout()
        Me.pnSpot.SuspendLayout()
        Me.pnForward.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTitle
        '
        Me.pnlTitle.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlTitle.Controls.Add(Me.lblAFNAME)
        Me.pnlTitle.Controls.Add(Me.mskAFACCTNO)
        Me.pnlTitle.Controls.Add(Me.lblAFACCTNO)
        Me.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlTitle.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitle.Name = "pnlTitle"
        Me.pnlTitle.Size = New System.Drawing.Size(632, 50)
        Me.pnlTitle.TabIndex = 0
        '
        'lblAFNAME
        '
        Me.lblAFNAME.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAFNAME.Location = New System.Drawing.Point(232, 16)
        Me.lblAFNAME.Name = "lblAFNAME"
        Me.lblAFNAME.Size = New System.Drawing.Size(392, 23)
        Me.lblAFNAME.TabIndex = 2
        Me.lblAFNAME.Text = "lblAFNAME"
        '
        'mskAFACCTNO
        '
        Me.mskAFACCTNO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskAFACCTNO.Location = New System.Drawing.Point(105, 16)
        Me.mskAFACCTNO.MaxLength = 10
        Me.mskAFACCTNO.Name = "mskAFACCTNO"
        Me.mskAFACCTNO.Size = New System.Drawing.Size(119, 20)
        Me.mskAFACCTNO.TabIndex = 0
        Me.mskAFACCTNO.Tag = "01"
        Me.mskAFACCTNO.Text = "mskAFACCTNO"
        '
        'lblAFACCTNO
        '
        Me.lblAFACCTNO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAFACCTNO.Location = New System.Drawing.Point(8, 16)
        Me.lblAFACCTNO.Name = "lblAFACCTNO"
        Me.lblAFACCTNO.Size = New System.Drawing.Size(80, 23)
        Me.lblAFACCTNO.TabIndex = 0
        Me.lblAFACCTNO.Tag = "AFACCTNO"
        Me.lblAFACCTNO.Text = "lblAFACCTNO"
        '
        'pnRepo
        '
        Me.pnRepo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnRepo.Controls.Add(Me.txtSECUREDRATIO)
        Me.pnRepo.Controls.Add(Me.lblSECUREDRATIO)
        Me.pnRepo.Controls.Add(Me.cboYearDay)
        Me.pnRepo.Controls.Add(Me.lblYearDay)
        Me.pnRepo.Controls.Add(Me.cboCODEID)
        Me.pnRepo.Controls.Add(Me.txtContractRate)
        Me.pnRepo.Controls.Add(Me.lblContractRate)
        Me.pnRepo.Controls.Add(Me.cboCARight)
        Me.pnRepo.Controls.Add(Me.lblCARight)
        Me.pnRepo.Controls.Add(Me.txtQuantity)
        Me.pnRepo.Controls.Add(Me.lblQuantity)
        Me.pnRepo.Controls.Add(Me.lblSymbol)
        Me.pnRepo.Controls.Add(Me.cboExecType)
        Me.pnRepo.Controls.Add(Me.lblExecType)
        Me.pnRepo.Controls.Add(Me.lblMatchType)
        Me.pnRepo.Controls.Add(Me.cboMatchType)
        Me.pnRepo.Controls.Add(Me.txtBreakTerm)
        Me.pnRepo.Controls.Add(Me.lblBreakTerm)
        Me.pnRepo.Controls.Add(Me.lblTPRRate)
        Me.pnRepo.Controls.Add(Me.txtTPRRate)
        Me.pnRepo.Controls.Add(Me.lblRPDate)
        Me.pnRepo.Controls.Add(Me.lblPenanty)
        Me.pnRepo.Controls.Add(Me.txtPenanty)
        Me.pnRepo.Controls.Add(Me.dtpRPDate)
        Me.pnRepo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnRepo.Location = New System.Drawing.Point(8, 58)
        Me.pnRepo.Name = "pnRepo"
        Me.pnRepo.Size = New System.Drawing.Size(616, 126)
        Me.pnRepo.TabIndex = 1
        '
        'txtSECUREDRATIO
        '
        Me.txtSECUREDRATIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSECUREDRATIO.Location = New System.Drawing.Point(504, 86)
        Me.txtSECUREDRATIO.MaxLength = 5
        Me.txtSECUREDRATIO.Name = "txtSECUREDRATIO"
        Me.txtSECUREDRATIO.TabIndex = 24
        Me.txtSECUREDRATIO.Tag = "18"
        Me.txtSECUREDRATIO.Text = "txtSECUREDRATIO"
        '
        'lblSECUREDRATIO
        '
        Me.lblSECUREDRATIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSECUREDRATIO.Location = New System.Drawing.Point(408, 86)
        Me.lblSECUREDRATIO.Name = "lblSECUREDRATIO"
        Me.lblSECUREDRATIO.Size = New System.Drawing.Size(88, 21)
        Me.lblSECUREDRATIO.TabIndex = 25
        Me.lblSECUREDRATIO.Tag = "BreakTerm"
        Me.lblSECUREDRATIO.Text = "lblSECUREDRATIO"
        '
        'cboYearDay
        '
        Me.cboYearDay.DisplayMember = "DISPLAY"
        Me.cboYearDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboYearDay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboYearDay.Location = New System.Drawing.Point(104, 60)
        Me.cboYearDay.Name = "cboYearDay"
        Me.cboYearDay.Size = New System.Drawing.Size(100, 21)
        Me.cboYearDay.TabIndex = 6
        Me.cboYearDay.Tag = "02"
        Me.cboYearDay.ValueMember = "VALUE"
        '
        'lblYearDay
        '
        Me.lblYearDay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYearDay.Location = New System.Drawing.Point(8, 60)
        Me.lblYearDay.Name = "lblYearDay"
        Me.lblYearDay.Size = New System.Drawing.Size(96, 21)
        Me.lblYearDay.TabIndex = 23
        Me.lblYearDay.Tag = "YearDay"
        Me.lblYearDay.Text = "lblYearDay"
        '
        'cboCODEID
        '
        Me.cboCODEID.DisplayMember = "DISPLAY"
        Me.cboCODEID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCODEID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCODEID.Location = New System.Drawing.Point(104, 34)
        Me.cboCODEID.Name = "cboCODEID"
        Me.cboCODEID.Size = New System.Drawing.Size(100, 21)
        Me.cboCODEID.TabIndex = 3
        Me.cboCODEID.Tag = "10"
        Me.cboCODEID.ValueMember = "VALUE"
        '
        'txtContractRate
        '
        Me.txtContractRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContractRate.Location = New System.Drawing.Point(302, 60)
        Me.txtContractRate.MaxLength = 5
        Me.txtContractRate.Name = "txtContractRate"
        Me.txtContractRate.TabIndex = 7
        Me.txtContractRate.Tag = "16"
        Me.txtContractRate.Text = "txtContractRate"
        '
        'lblContractRate
        '
        Me.lblContractRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContractRate.Location = New System.Drawing.Point(208, 60)
        Me.lblContractRate.Name = "lblContractRate"
        Me.lblContractRate.Size = New System.Drawing.Size(88, 21)
        Me.lblContractRate.TabIndex = 12
        Me.lblContractRate.Tag = "ContractRate"
        Me.lblContractRate.Text = "lblContractRate"
        '
        'cboCARight
        '
        Me.cboCARight.DisplayMember = "DISPLAY"
        Me.cboCARight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCARight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCARight.Location = New System.Drawing.Point(504, 8)
        Me.cboCARight.Name = "cboCARight"
        Me.cboCARight.Size = New System.Drawing.Size(100, 21)
        Me.cboCARight.TabIndex = 2
        Me.cboCARight.Tag = "21"
        Me.cboCARight.ValueMember = "VALUE"
        '
        'lblCARight
        '
        Me.lblCARight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCARight.Location = New System.Drawing.Point(408, 8)
        Me.lblCARight.Name = "lblCARight"
        Me.lblCARight.Size = New System.Drawing.Size(88, 21)
        Me.lblCARight.TabIndex = 10
        Me.lblCARight.Tag = "CARight"
        Me.lblCARight.Text = "lblCARight"
        '
        'txtQuantity
        '
        Me.txtQuantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuantity.Location = New System.Drawing.Point(302, 34)
        Me.txtQuantity.MaxLength = 15
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.TabIndex = 4
        Me.txtQuantity.Tag = "12"
        Me.txtQuantity.Text = "txtQuantity"
        '
        'lblQuantity
        '
        Me.lblQuantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuantity.Location = New System.Drawing.Point(208, 34)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(88, 21)
        Me.lblQuantity.TabIndex = 4
        Me.lblQuantity.Tag = "Quantity"
        Me.lblQuantity.Text = "lblQuantity"
        '
        'lblSymbol
        '
        Me.lblSymbol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSymbol.Location = New System.Drawing.Point(8, 34)
        Me.lblSymbol.Name = "lblSymbol"
        Me.lblSymbol.Size = New System.Drawing.Size(96, 21)
        Me.lblSymbol.TabIndex = 6
        Me.lblSymbol.Tag = "Symbol"
        Me.lblSymbol.Text = "lblSymbol"
        '
        'cboExecType
        '
        Me.cboExecType.DisplayMember = "DISPLAY"
        Me.cboExecType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboExecType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboExecType.Location = New System.Drawing.Point(104, 8)
        Me.cboExecType.Name = "cboExecType"
        Me.cboExecType.Size = New System.Drawing.Size(100, 21)
        Me.cboExecType.TabIndex = 0
        Me.cboExecType.Tag = "04"
        Me.cboExecType.ValueMember = "VALUE"
        '
        'lblExecType
        '
        Me.lblExecType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExecType.Location = New System.Drawing.Point(8, 8)
        Me.lblExecType.Name = "lblExecType"
        Me.lblExecType.Size = New System.Drawing.Size(96, 21)
        Me.lblExecType.TabIndex = 0
        Me.lblExecType.Tag = "EXECTYPE"
        Me.lblExecType.Text = "lblExecType"
        '
        'lblMatchType
        '
        Me.lblMatchType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMatchType.Location = New System.Drawing.Point(208, 8)
        Me.lblMatchType.Name = "lblMatchType"
        Me.lblMatchType.Size = New System.Drawing.Size(88, 21)
        Me.lblMatchType.TabIndex = 2
        Me.lblMatchType.Tag = "MATCHTYPE"
        Me.lblMatchType.Text = "lblMatchType"
        '
        'cboMatchType
        '
        Me.cboMatchType.DisplayMember = "DISPLAY"
        Me.cboMatchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMatchType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMatchType.Location = New System.Drawing.Point(302, 8)
        Me.cboMatchType.Name = "cboMatchType"
        Me.cboMatchType.Size = New System.Drawing.Size(100, 21)
        Me.cboMatchType.TabIndex = 1
        Me.cboMatchType.Tag = "06"
        Me.cboMatchType.ValueMember = "VALUE"
        '
        'txtBreakTerm
        '
        Me.txtBreakTerm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBreakTerm.Location = New System.Drawing.Point(504, 60)
        Me.txtBreakTerm.MaxLength = 10
        Me.txtBreakTerm.Name = "txtBreakTerm"
        Me.txtBreakTerm.TabIndex = 8
        Me.txtBreakTerm.Tag = "18"
        Me.txtBreakTerm.Text = "txtBreakTerm"
        '
        'lblBreakTerm
        '
        Me.lblBreakTerm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBreakTerm.Location = New System.Drawing.Point(408, 60)
        Me.lblBreakTerm.Name = "lblBreakTerm"
        Me.lblBreakTerm.Size = New System.Drawing.Size(88, 21)
        Me.lblBreakTerm.TabIndex = 20
        Me.lblBreakTerm.Tag = "BreakTerm"
        Me.lblBreakTerm.Text = "lblBreakTerm"
        '
        'lblTPRRate
        '
        Me.lblTPRRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTPRRate.Location = New System.Drawing.Point(208, 86)
        Me.lblTPRRate.Name = "lblTPRRate"
        Me.lblTPRRate.Size = New System.Drawing.Size(88, 21)
        Me.lblTPRRate.TabIndex = 14
        Me.lblTPRRate.Tag = "TPRRate"
        Me.lblTPRRate.Text = "lblTPRRate"
        '
        'txtTPRRate
        '
        Me.txtTPRRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTPRRate.Location = New System.Drawing.Point(302, 86)
        Me.txtTPRRate.MaxLength = 5
        Me.txtTPRRate.Name = "txtTPRRate"
        Me.txtTPRRate.TabIndex = 10
        Me.txtTPRRate.Tag = "19"
        Me.txtTPRRate.Text = "txtTPRRate"
        '
        'lblRPDate
        '
        Me.lblRPDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRPDate.Location = New System.Drawing.Point(8, 86)
        Me.lblRPDate.Name = "lblRPDate"
        Me.lblRPDate.Size = New System.Drawing.Size(96, 21)
        Me.lblRPDate.TabIndex = 16
        Me.lblRPDate.Tag = "RPDate"
        Me.lblRPDate.Text = "lblRPDate"
        '
        'lblPenanty
        '
        Me.lblPenanty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPenanty.Location = New System.Drawing.Point(408, 34)
        Me.lblPenanty.Name = "lblPenanty"
        Me.lblPenanty.Size = New System.Drawing.Size(88, 21)
        Me.lblPenanty.TabIndex = 14
        Me.lblPenanty.Tag = "Penanty"
        Me.lblPenanty.Text = "lblPenanty"
        '
        'txtPenanty
        '
        Me.txtPenanty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPenanty.Location = New System.Drawing.Point(504, 34)
        Me.txtPenanty.MaxLength = 5
        Me.txtPenanty.Name = "txtPenanty"
        Me.txtPenanty.TabIndex = 5
        Me.txtPenanty.Tag = "17"
        Me.txtPenanty.Text = "txtPenanty"
        '
        'dtpRPDate
        '
        Me.dtpRPDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpRPDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpRPDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpRPDate.Location = New System.Drawing.Point(104, 86)
        Me.dtpRPDate.Name = "dtpRPDate"
        Me.dtpRPDate.Size = New System.Drawing.Size(100, 20)
        Me.dtpRPDate.TabIndex = 9
        Me.dtpRPDate.Tag = "07"
        Me.dtpRPDate.Value = New Date(2006, 10, 30, 0, 0, 0, 0)
        '
        'lblRPACCTNO
        '
        Me.lblRPACCTNO.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.lblRPACCTNO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRPACCTNO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRPACCTNO.ForeColor = System.Drawing.Color.Red
        Me.lblRPACCTNO.Location = New System.Drawing.Point(112, 328)
        Me.lblRPACCTNO.Name = "lblRPACCTNO"
        Me.lblRPACCTNO.Size = New System.Drawing.Size(192, 24)
        Me.lblRPACCTNO.TabIndex = 3
        Me.lblRPACCTNO.Text = "lblRPACCTNO"
        Me.lblRPACCTNO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnOK
        '
        Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Location = New System.Drawing.Point(456, 328)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(80, 24)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Tag = "OK"
        Me.btnOK.Text = "btnOK"
        '
        'btnCANCEL
        '
        Me.btnCANCEL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCANCEL.Location = New System.Drawing.Point(544, 328)
        Me.btnCANCEL.Name = "btnCANCEL"
        Me.btnCANCEL.Size = New System.Drawing.Size(80, 24)
        Me.btnCANCEL.TabIndex = 5
        Me.btnCANCEL.Tag = "CANCEL"
        Me.btnCANCEL.Text = "btnCANCEL"
        '
        'pnSpot
        '
        Me.pnSpot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnSpot.Controls.Add(Me.lblSpot)
        Me.pnSpot.Controls.Add(Me.lblSpotPrice)
        Me.pnSpot.Controls.Add(Me.txtSpotPrice)
        Me.pnSpot.Controls.Add(Me.txtSpotValue)
        Me.pnSpot.Controls.Add(Me.lblSpotValue)
        Me.pnSpot.Controls.Add(Me.lblSpotDate)
        Me.pnSpot.Controls.Add(Me.dtpSpotDate)
        Me.pnSpot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnSpot.Location = New System.Drawing.Point(8, 192)
        Me.pnSpot.Name = "pnSpot"
        Me.pnSpot.Size = New System.Drawing.Size(304, 128)
        Me.pnSpot.TabIndex = 2
        '
        'lblSpot
        '
        Me.lblSpot.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(255, Byte), CType(255, Byte))
        Me.lblSpot.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSpot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSpot.Location = New System.Drawing.Point(8, 8)
        Me.lblSpot.Name = "lblSpot"
        Me.lblSpot.Size = New System.Drawing.Size(288, 23)
        Me.lblSpot.TabIndex = 20
        Me.lblSpot.Tag = "Spot"
        Me.lblSpot.Text = "lblSpot"
        Me.lblSpot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSpotPrice
        '
        Me.lblSpotPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSpotPrice.Location = New System.Drawing.Point(8, 40)
        Me.lblSpotPrice.Name = "lblSpotPrice"
        Me.lblSpotPrice.Size = New System.Drawing.Size(96, 21)
        Me.lblSpotPrice.TabIndex = 14
        Me.lblSpotPrice.Tag = "SpotPrice"
        Me.lblSpotPrice.Text = "lblSpotPrice"
        '
        'txtSpotPrice
        '
        Me.txtSpotPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSpotPrice.Location = New System.Drawing.Point(112, 40)
        Me.txtSpotPrice.MaxLength = 20
        Me.txtSpotPrice.Name = "txtSpotPrice"
        Me.txtSpotPrice.Size = New System.Drawing.Size(136, 20)
        Me.txtSpotPrice.TabIndex = 0
        Me.txtSpotPrice.Tag = "11"
        Me.txtSpotPrice.Text = "txtSpotPrice"
        '
        'txtSpotValue
        '
        Me.txtSpotValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSpotValue.Location = New System.Drawing.Point(112, 69)
        Me.txtSpotValue.MaxLength = 20
        Me.txtSpotValue.Name = "txtSpotValue"
        Me.txtSpotValue.Size = New System.Drawing.Size(168, 20)
        Me.txtSpotValue.TabIndex = 1
        Me.txtSpotValue.Tag = "14"
        Me.txtSpotValue.Text = "txtSpotValue"
        '
        'lblSpotValue
        '
        Me.lblSpotValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSpotValue.Location = New System.Drawing.Point(8, 69)
        Me.lblSpotValue.Name = "lblSpotValue"
        Me.lblSpotValue.Size = New System.Drawing.Size(96, 21)
        Me.lblSpotValue.TabIndex = 14
        Me.lblSpotValue.Tag = "SpotValue"
        Me.lblSpotValue.Text = "lblSpotValue"
        '
        'lblSpotDate
        '
        Me.lblSpotDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSpotDate.Location = New System.Drawing.Point(8, 96)
        Me.lblSpotDate.Name = "lblSpotDate"
        Me.lblSpotDate.Size = New System.Drawing.Size(96, 21)
        Me.lblSpotDate.TabIndex = 16
        Me.lblSpotDate.Tag = "SpotDate"
        Me.lblSpotDate.Text = "lblSpotDate"
        '
        'dtpSpotDate
        '
        Me.dtpSpotDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpSpotDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpSpotDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSpotDate.Location = New System.Drawing.Point(112, 96)
        Me.dtpSpotDate.Name = "dtpSpotDate"
        Me.dtpSpotDate.Size = New System.Drawing.Size(100, 20)
        Me.dtpSpotDate.TabIndex = 2
        Me.dtpSpotDate.Tag = "21"
        Me.dtpSpotDate.Value = New Date(2006, 10, 30, 0, 0, 0, 0)
        '
        'pnForward
        '
        Me.pnForward.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnForward.Controls.Add(Me.txtForwardPrice)
        Me.pnForward.Controls.Add(Me.lblForwardPrice)
        Me.pnForward.Controls.Add(Me.lblForwardValue)
        Me.pnForward.Controls.Add(Me.txtForwardValue)
        Me.pnForward.Controls.Add(Me.dtpForwardDate)
        Me.pnForward.Controls.Add(Me.lblForwardDate)
        Me.pnForward.Controls.Add(Me.lblForward)
        Me.pnForward.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnForward.Location = New System.Drawing.Point(320, 192)
        Me.pnForward.Name = "pnForward"
        Me.pnForward.Size = New System.Drawing.Size(304, 128)
        Me.pnForward.TabIndex = 3
        '
        'txtForwardPrice
        '
        Me.txtForwardPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtForwardPrice.Location = New System.Drawing.Point(112, 40)
        Me.txtForwardPrice.MaxLength = 20
        Me.txtForwardPrice.Name = "txtForwardPrice"
        Me.txtForwardPrice.Size = New System.Drawing.Size(136, 20)
        Me.txtForwardPrice.TabIndex = 0
        Me.txtForwardPrice.Tag = "14"
        Me.txtForwardPrice.Text = "txtForwardPrice"
        '
        'lblForwardPrice
        '
        Me.lblForwardPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblForwardPrice.Location = New System.Drawing.Point(8, 40)
        Me.lblForwardPrice.Name = "lblForwardPrice"
        Me.lblForwardPrice.Size = New System.Drawing.Size(96, 21)
        Me.lblForwardPrice.TabIndex = 14
        Me.lblForwardPrice.Tag = "ForwardPrice"
        Me.lblForwardPrice.Text = "lblForwardPrice"
        '
        'lblForwardValue
        '
        Me.lblForwardValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblForwardValue.Location = New System.Drawing.Point(8, 69)
        Me.lblForwardValue.Name = "lblForwardValue"
        Me.lblForwardValue.Size = New System.Drawing.Size(96, 21)
        Me.lblForwardValue.TabIndex = 14
        Me.lblForwardValue.Tag = "ForwardValue"
        Me.lblForwardValue.Text = "lblForwardValue"
        '
        'txtForwardValue
        '
        Me.txtForwardValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtForwardValue.Location = New System.Drawing.Point(112, 69)
        Me.txtForwardValue.MaxLength = 20
        Me.txtForwardValue.Name = "txtForwardValue"
        Me.txtForwardValue.Size = New System.Drawing.Size(168, 20)
        Me.txtForwardValue.TabIndex = 1
        Me.txtForwardValue.Tag = "14"
        Me.txtForwardValue.Text = "txtForwardValue"
        '
        'dtpForwardDate
        '
        Me.dtpForwardDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpForwardDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpForwardDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpForwardDate.Location = New System.Drawing.Point(112, 96)
        Me.dtpForwardDate.Name = "dtpForwardDate"
        Me.dtpForwardDate.Size = New System.Drawing.Size(100, 20)
        Me.dtpForwardDate.TabIndex = 2
        Me.dtpForwardDate.Tag = "22"
        Me.dtpForwardDate.Value = New Date(2006, 10, 30, 0, 0, 0, 0)
        '
        'lblForwardDate
        '
        Me.lblForwardDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblForwardDate.Location = New System.Drawing.Point(8, 96)
        Me.lblForwardDate.Name = "lblForwardDate"
        Me.lblForwardDate.Size = New System.Drawing.Size(96, 21)
        Me.lblForwardDate.TabIndex = 16
        Me.lblForwardDate.Tag = "ForwardDate"
        Me.lblForwardDate.Text = "lblForwardDate"
        '
        'lblForward
        '
        Me.lblForward.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte))
        Me.lblForward.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblForward.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblForward.Location = New System.Drawing.Point(8, 8)
        Me.lblForward.Name = "lblForward"
        Me.lblForward.Size = New System.Drawing.Size(288, 23)
        Me.lblForward.TabIndex = 20
        Me.lblForward.Tag = "Forward"
        Me.lblForward.Text = "lblForward"
        Me.lblForward.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblACCTNO
        '
        Me.lblACCTNO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblACCTNO.Location = New System.Drawing.Point(8, 331)
        Me.lblACCTNO.Name = "lblACCTNO"
        Me.lblACCTNO.Size = New System.Drawing.Size(96, 16)
        Me.lblACCTNO.TabIndex = 17
        Me.lblACCTNO.Tag = "ACCTNO"
        Me.lblACCTNO.Text = "lblACCTNO"
        '
        'frmRPTransact
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 13)
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ClientSize = New System.Drawing.Size(632, 359)
        Me.Controls.Add(Me.lblACCTNO)
        Me.Controls.Add(Me.pnSpot)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCANCEL)
        Me.Controls.Add(Me.pnRepo)
        Me.Controls.Add(Me.pnlTitle)
        Me.Controls.Add(Me.pnForward)
        Me.Controls.Add(Me.lblRPACCTNO)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Name = "frmRPTransact"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmRPTransact"
        Me.pnlTitle.ResumeLayout(False)
        Me.pnRepo.ResumeLayout(False)
        Me.pnSpot.ResumeLayout(False)
        Me.pnForward.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Declare constant and variables "
    Const c_ResourceManager = "_DIRECT.frmRPTransact-"
    Dim mv_strLastAFACCTNO As String = String.Empty
    Dim mv_dblFloorPrice As Double
    Dim mv_dblCeilingPrice As Double
    Dim mv_dblTradeLot As Double

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
    Private mv_xmlDocumentInquiryData As Xml.XmlDocument
    Private mv_strRPAccount As String
    Private mv_strXmlMessageData As String
    Private mv_strLocalObject As String
    Private mv_strBranchId As String
    Private mv_strTellerId As String
    Private mv_strIpAddress As String
    Private mv_strWsName As String
    Private mv_strBusDate As String = String.Empty
    Private mv_strTxDate As String = String.Empty
    Private mv_strTxNum As String = String.Empty

    Private Const CONTROL_PNL_CONTRACT_TOP = 200
    Private Const CONTROL_BUTTON_TOP = 400
    Private Const FRM_DEFAULT_HEIGHT = 260
    Private Const FRM_EXTEND_HEIGHT = 460
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
#End Region

#Region " Other method "
    '---------------------------------------------------------------------------------------------------------
    'Hàm này được sử dụng để nạp màn hình.
    'Biến vào 
    '   strTLTXCD là mã giao dịch, dùng để xác định các trường trong giao dịch
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

            'Lấy thông tin chung về giao dịch
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
                                If v_strValue = "Y" Then
                                    mv_blnAcctEntry = True
                                Else
                                    mv_blnAcctEntry = False
                                End If
                            Case "BGCOLOR"

                        End Select

                    End With
                Next
            Next

            'Lấy thông tin chi tiết các trường của giao dịch
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
                        'Xử lý cho trường Description
                        v_strDefVal = Me.Text
                    ElseIf v_strDefVal = "<$BUSDATE>" Then
                        'Lấy ngày làm việc hiện tại
                        v_strDefVal = Me.BusDate
                    End If
                    If v_blnChain Then
                        'Nếu giao dịch được nạp qua giao dịch tra cứu
                        If Len(v_strChainName) > 0 Then
                            'Nếu trường này có sử dụng CHAINNAME để lấy giá trị từ màn hình tra cứu
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

            'Lấy các luật kiểm tra của các trường giao dịch
            v_strClause = "SELECT FLDNAME, VALTYPE, OPERATOR, VALEXP, VALEXP2, ERRMSG, EN_ERRMSG FROM FLDVAL " & _
                "WHERE upper(OBJNAME) = '" & strTLTXCD & "' ORDER BY VALTYPE, FLDNAME, ODRNUM" 'Thứ tự order by là quan trọng không sửa
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
                        'Ghi nhận thuật toán để kiểm tra và tính toán cho từng trường của giao dịch
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

                'Điều kiện xử lý
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
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub
    'Verify rules của giao dịch, trả về điện giao dịch đã được tạo
    Private Function VerifyRules(ByRef v_strTxMsg As String) As Boolean
        Try
            Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
            Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode, v_intIndex As Long, i, v_intCount As Integer
            Dim v_strFLDNAME As String, v_strFLDDEFNAME As String, v_strDATATYPE As String, v_strFLDVALUE As String
            Dim v_strERRMSG, v_strENERRMSG, v_strOPERATOR, v_strVALEXP, v_strVALEXP2 As String, v_strACTYPE, v_strDESC As String
            Dim v_dtVALEXP, v_dtVALEXP2, v_dtFLDVALUE As Date, v_strCMDSQL As String
            Dim v_ctl As Control, v_attrFLDNAME As Xml.XmlAttribute, v_attrDATATYPE As Xml.XmlAttribute, v_objEval As New Evaluator
            Dim v_strTLTXCD As String
            'Xác định mã loại hình của hợp đồng: Hiển thị form lookup để chọn
            v_strCMDSQL = "SELECT ACTYPE VALUE, ACNAME DISPLAY,ACNAME EN_DISPLAY,ACNAME DESCRIPTION FROM RPTYPE " & ControlChars.CrLf _
                & "WHERE STATUS='Y' " & ControlChars.CrLf _
                & "AND RPCLASS='" & cboExecType.SelectedValue & "' " & ControlChars.CrLf _
                & "AND TRTYPE='" & cboMatchType.SelectedValue & "'"
            Dim frm As New frmLookUp(UserLanguage)
            frm.SQLCMD = v_strCMDSQL
            frm.ShowDialog()
            v_intIndex = InStr(frm.RETURNDATA, vbTab)
            If v_intIndex > 0 Then
                v_strACTYPE = Mid(frm.RETURNDATA, 1, v_intIndex - 1)
                v_strDESC = Mid(frm.RETURNDATA, v_intIndex + 1)
            End If
            frm.Dispose()

            If Len(v_strACTYPE) = 0 Then
                'Không lựa chọn loại hình nào
                Return False
            End If
            'Tạo điện giao dịch
            Select Case cboExecType.SelectedValue
                Case "001" 'Repo
                    v_strTLTXCD = gc_RP_REPO_OPENACCOUNT
                Case "002" 'Rerepo
                    v_strTLTXCD = gc_RP_REREPO_OPENACCOUNT
                Case "003" 'Forward
                    v_strTLTXCD = gc_RP_FORWARD_OPENACCOUNT
                Case Else
                    MessageBox.Show("Now only support for Repo and Rerepo transact!")
                    Return False
            End Select
            LoadScreen(v_strTLTXCD)
            v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, v_strTLTXCD, Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)
            v_xmlDocument.LoadXml(v_strTxMsg)
            v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")
            If mv_arrObjFields.GetLength(0) > 0 Then
                For v_intIndex = 0 To mv_arrObjFields.GetLength(0) - 1 Step 1
                    If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                        v_strFLDNAME = mv_arrObjFields(v_intIndex).FieldName
                        v_strDATATYPE = mv_arrObjFields(v_intIndex).DataType
                        Select Case Trim(v_strFLDNAME)
                            Case "01" 'AFACCTNO
                                v_strFLDVALUE = mskAFACCTNO.Text
                            Case "02" 'ACTYPE
                                v_strFLDVALUE = v_strACTYPE
                            Case "03" 'ACCTNO
                                v_strFLDVALUE = getRepoAccount(mskAFACCTNO.Text)
                                mv_strRPAccount = v_strFLDVALUE
                            Case "04" 'RPCLASS
                                v_strFLDVALUE = cboExecType.SelectedValue
                            Case "05" 'RPTYPE
                                v_strFLDVALUE = v_strACTYPE
                            Case "06" 'TRTYPE
                                v_strFLDVALUE = cboMatchType.SelectedValue
                            Case "07" 'TXDATE
                                v_strFLDVALUE = dtpRPDate.Value
                            Case "08" 'SPOTDATE
                                v_strFLDVALUE = dtpSpotDate.Value
                            Case "09" 'FORWARDDATE
                                v_strFLDVALUE = dtpForwardDate.Value
                            Case "10" 'SPOTID      
                                Select Case v_strTLTXCD
                                    Case gc_RP_REPO_OPENACCOUNT
                                        v_strFLDVALUE = cboCODEID.SelectedValue
                                    Case gc_RP_REREPO_OPENACCOUNT
                                        v_strFLDVALUE = "00"
                                    Case gc_RP_FORWARD_OPENACCOUNT
                                        v_strFLDVALUE = cboCODEID.SelectedValue
                                End Select
                            Case "11" 'SPOTPRICE                                       
                                v_strFLDVALUE = txtSpotPrice.Text
                            Case "12" 'SPOTQTTY
                                v_strFLDVALUE = txtQuantity.Text
                            Case "13" 'FORWARDID                                         
                                Select Case v_strTLTXCD
                                    Case gc_RP_REPO_OPENACCOUNT
                                        v_strFLDVALUE = "00"
                                    Case gc_RP_REREPO_OPENACCOUNT
                                        v_strFLDVALUE = cboCODEID.SelectedValue
                                    Case gc_RP_FORWARD_OPENACCOUNT
                                        v_strFLDVALUE = cboCODEID.SelectedValue
                                End Select

                            Case "14" 'FORWARDPRICE                                      
                                v_strFLDVALUE = txtForwardPrice.Text
                            Case "15" 'FORWARDQTTY                                      
                                v_strFLDVALUE = txtQuantity.Text
                            Case "16" 'CONTRACTRATE
                                v_strFLDVALUE = txtContractRate.Text
                            Case "17" 'PENANTY
                                v_strFLDVALUE = txtPenanty.Text
                            Case "18" 'BREAKTERM
                                v_strFLDVALUE = txtBreakTerm.Text
                            Case "19" 'TPRRATE
                                v_strFLDVALUE = txtTPRRate.Text
                            Case "20" 'ICCFCD
                                v_strFLDVALUE = ""
                            Case "21" 'CAOWNER
                                v_strFLDVALUE = cboCARight.SelectedValue
                            Case "22" 'SECUREDRATIO cho forward
                                v_strFLDVALUE = txtSECUREDRATIO.Text
                            Case "30" 'DESC                                              
                                v_strFLDVALUE = v_strDESC
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

                        'Remember account field
                        If UCase(v_strFLDNAME) = "03" Then
                            Clipboard.SetDataObject(v_strFLDVALUE)
                        End If
                        v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                    End If
                Next
            End If
            v_strTxMsg = v_xmlDocument.InnerXml
            Return True
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Function

    'Hàm này được dùng để hiển thị lại điện giao dịch trả về từ trên HOST đối với giao dịch Submit 02 lần
    Private Function DisplayConfirm(ByVal v_xmlDocument As Xml.XmlDocument) As Boolean
        Try
            Dim v_dataElement As Xml.XmlElement, v_nodetxData As Xml.XmlNode, v_ctl As Control, v_objAccount As CAccountEntry
            Dim v_strPRINTINFO, v_strPRINTNAME, v_strPRINTVALUE, v_strFLDNAME As String, i, j, v_intIndex As Integer
            'Hiển thị lại màn hình
            Me.mskAFACCTNO.Enabled = False
            Me.pnRepo.Enabled = False
            Me.pnSpot.Enabled = False
            Me.pnForward.Enabled = False
            Me.lblRPACCTNO.Text = mv_strRPAccount
            Return True
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Function

    Private Function ResetDisplayConfirm(ByVal v_xmlDocument As Xml.XmlDocument) As Boolean
        Try
            Dim v_dataElement As Xml.XmlElement, v_nodetxData As Xml.XmlNode, v_ctl As Control, v_objAccount As CAccountEntry
            Dim v_strPRINTINFO, v_strPRINTNAME, v_strPRINTVALUE, v_strFLDNAME As String, i, j, v_intIndex As Integer
            'Hiển thị lại màn hình
            Me.mskAFACCTNO.Enabled = True
            Me.pnRepo.Enabled = True
            Me.pnSpot.Enabled = True
            Me.pnForward.Enabled = True
            Me.lblRPACCTNO.Text = ""
            Me.ActiveControl = mskAFACCTNO
            Return True
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Function

    Protected Overridable Function InitDialog()
        'Khởi tạo kích thước form và load resource
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)
        DoResizeForm()
        ResetScreen(Me)
        'LoadScreen(gc_RP_REPO_OPENACCOUNT)
        Me.mskAFACCTNO.BackColor = System.Drawing.Color.GreenYellow

        'Thiết lập các thuộc tính ban đầu cho form
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL As String, v_strObjMsg As String

        v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='RP' AND TRIM(CDNAME)='RPCLASS'"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        FillComboEx(v_strObjMsg, cboExecType, "", Me.UserLanguage)

        v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='RP' AND TRIM(CDNAME)='TRTYPE'"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        FillComboEx(v_strObjMsg, cboMatchType, "", Me.UserLanguage)

        v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='IC' AND TRIM(CDNAME)='YEARDAY'"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        FillComboEx(v_strObjMsg, cboYearDay, "", Me.UserLanguage)

        v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE CDTYPE='RP' AND TRIM(CDNAME)='CAOWNER'"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        FillComboEx(v_strObjMsg, cboCARight, "", Me.UserLanguage)

        v_strCmdSQL = "SELECT CODEID VALUE, SYMBOL DISPLAY, SYMBOL EN_DISPLAY FROM SBSECURITIES ORDER BY DISPLAY"
        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        FillComboEx(v_strObjMsg, cboCODEID, "", Me.UserLanguage)

        If cboExecType.Items.Count > 0 Then cboExecType.SelectedIndex = 0
        If cboMatchType.Items.Count > 0 Then cboMatchType.SelectedIndex = 0
        If cboCARight.Items.Count > 0 Then cboCARight.SelectedIndex = 0
        If cboCODEID.Items.Count > 0 Then cboCODEID.SelectedIndex = 0
        If cboYearDay.Items.Count > 0 Then cboYearDay.SelectedIndex = 0
    End Function

    Private Sub ResetScreen(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control
        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is TextBox Then
                CType(v_ctrl, TextBox).Text = String.Empty
                CType(v_ctrl, TextBox).Enabled = True
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                ResetScreen(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Button Then
            ElseIf TypeOf (v_ctrl) Is Panel Then
                v_ctrl.Enabled = True
                ResetScreen(v_ctrl)
            End If
        Next
        Me.mskAFACCTNO.Enabled = True
        Me.ActiveControl = mskAFACCTNO
        Me.lblRPACCTNO.Text = String.Empty
    End Sub

    Public Overridable Sub OnSubmit()
        Dim v_strTxMsg As String, v_xmlDocument As New Xml.XmlDocument, v_attrColl As Xml.XmlAttributeCollection
        Dim v_intNOSUBMIT As Integer, v_strNEXTTX As String = String.Empty
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            'Control Validate
            If Not ControlValidation() Then
                Exit Sub
            End If
            'Đã nhập thông tin trên màn hình và submit gửi lên APP-SERVER để xử lý
            If mskAFACCTNO.Enabled Then
                'Khởi tạo điện giao dịch
                MessageData = vbNullString
                '1. Verify và tạo điện giao dịch
                If Not VerifyRules(v_strTxMsg) Then
                    Exit Sub
                End If

                MessageData = v_strTxMsg
                v_xmlDocument.LoadXml(v_strTxMsg)
                DisplayConfirm(v_xmlDocument)

            Else 'Confirm
                v_strTxMsg = Me.MessageData
                v_lngError = v_ws.Message(v_strTxMsg)
                If v_lngError <> ERR_SYSTEM_OK Then
                    'Thông báo lỗi
                    GetErrorFromMessage(v_strTxMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                    Cursor.Current = Cursors.Default
                    If v_lngError <> ERR_SA_CHECKER1_OVR And v_lngError <> ERR_SA_CHECKER2_OVR Then
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text)
                        ResetDisplayConfirm(v_xmlDocument)
                        Exit Sub
                    Else
                        'Lấy thêm nguyên nhân duyệt
                        GetReasonFromMessage(v_strTxMsg, v_strErrorMessage, Me.UserLanguage)
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text)
                    End If
                End If
                ResetScreen(Me)
            End If

        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub OnClose()
        Me.Dispose()
    End Sub

    Private Sub DoResizeForm()

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

    Private Function getTransBGColor(ByVal pv_intColor As Integer) As System.Drawing.Color
        Dim v_color As New System.Drawing.Color
        Select Case pv_intColor
            Case 0 'Default color
                v_color = System.Drawing.SystemColors.InactiveCaptionText
            Case 1 'Honeydew
                v_color = System.Drawing.Color.Honeydew
            Case 2 'LightGreen
                v_color = System.Drawing.Color.LightGreen
            Case 3 'DarkKhaki
                v_color = System.Drawing.Color.DarkKhaki
            Case 4 'Aquamarine
                v_color = System.Drawing.Color.Aquamarine
            Case 5 'Skyblue
                v_color = System.Drawing.Color.SkyBlue
            Case 6 'Violet
                v_color = System.Drawing.Color.Violet
            Case 7 'Lightpink
                v_color = System.Drawing.Color.LightPink
            Case 8 'LightSalomon
                v_color = System.Drawing.Color.LightSalmon
        End Select
        Return v_color
    End Function

    Private Function getForwardPrice() As Double
        Dim v_intYearDay, v_intNumDay As Integer
        Dim v_dblContractRate As Double
        Dim v_dblSpotPrice, v_dblForwardPrice As Double
        Dim v_strYearDay As String
        Dim v_dtRPDate As Date
        Dim v_strSpotDate, v_strForwardDate, v_strRPDate As String
        v_strYearDay = Me.cboYearDay.SelectedValue
        v_strSpotDate = Me.dtpSpotDate.Value
        v_strForwardDate = Me.dtpForwardDate.Value
        v_strRPDate = Me.dtpRPDate.Value
        v_dblSpotPrice = CDbl(Me.txtSpotPrice.Text)
        v_dblContractRate = CDbl(Me.txtContractRate.Text)
        GetYEAR_DAYS(v_strSpotDate, v_strForwardDate, v_strYearDay, v_intNumDay)
        v_dtRPDate = DDMMYYYY_SystemDate(v_strRPDate)
        GetYEAR_DAYS("01/01/" & v_dtRPDate.Year, "1/1/" & v_dtRPDate.Year + 1, v_strYearDay, v_intYearDay)
        Select Case cboExecType.SelectedValue
            Case "001" 'Repo
                v_dblForwardPrice = v_dblSpotPrice * (v_dblContractRate / 100 / v_intYearDay * v_intNumDay + 1)
            Case "002" 'Rerepo
                v_dblForwardPrice = v_dblSpotPrice * (1 - v_dblContractRate / 100 / v_intYearDay * v_intNumDay)
        End Select
        Return v_dblForwardPrice
    End Function

    Private Function getSpotPrice() As Double
        Dim v_intYearDay, v_intNumDay As Integer
        Dim v_dblContractRate As Double
        Dim v_dblSpotPrice, v_dblForwardPrice As Double
        Dim v_strYearDay As String
        Dim v_dtRPDate As Date
        Dim v_strSpotDate, v_strFowardDate, v_strRPDate As String
        v_strYearDay = Me.cboYearDay.SelectedValue
        v_strSpotDate = Me.dtpSpotDate.Value
        v_strFowardDate = Me.dtpForwardDate.Value
        v_strRPDate = Me.dtpRPDate.Value
        v_dblForwardPrice = CDbl(Me.txtForwardPrice.Text)
        v_dblContractRate = CDbl(Me.txtContractRate.Text)
        GetYEAR_DAYS(v_strSpotDate, v_strFowardDate, v_strYearDay, v_intNumDay)
        v_dtRPDate = DDMMYYYY_SystemDate(v_strRPDate)
        GetYEAR_DAYS("01/01/" & v_dtRPDate.Year, "31/12/" & v_dtRPDate.Year, v_strYearDay, v_intYearDay)
        Select Case cboExecType.SelectedValue
            Case "001" 'Repo
                v_dblSpotPrice = v_dblForwardPrice / (v_dblContractRate / 100 / v_intYearDay * v_intNumDay + 1)
            Case "002" 'Rerepo
                v_dblSpotPrice = v_dblForwardPrice / (1 - v_dblContractRate / 100 / v_intYearDay * v_intNumDay)
        End Select
        Return v_dblSpotPrice
    End Function

    Public Function GetYEAR_DAYS(ByVal pv_strFromDate As String, ByVal pv_strToDate As String, ByVal pv_strYEARDAY As String, ByRef pv_intDAYS As Integer) As Long
        Try
            Dim v_dtTODATE, v_dtFROMDATE, v_dtBOMDATE As Date, v_intCMPDAY, v_intCURRDAY As Integer
            v_dtTODATE = DDMMYYYY_SystemDate(pv_strToDate)
            v_dtFROMDATE = DDMMYYYY_SystemDate(pv_strFromDate)
            v_dtBOMDATE = DDMMYYYY_SystemDate("01/" & v_dtFROMDATE.Month & "/" & v_dtFROMDATE.Year)
            Select Case pv_strYEARDAY
                Case "A"
                    'Số ngày thực tế
                    pv_intDAYS = DateDiff(DateInterval.Day, v_dtFROMDATE, v_dtTODATE)
                Case "M"
                    'Làm tròn tháng 30 ngày
                    If DateDiff(DateInterval.Month, v_dtFROMDATE, v_dtTODATE) > 0 Then
                        'Nếu khác tháng. Lấy số ngày trong các tháng nằm giữa CMPDATE và CURRDATE
                        pv_intDAYS = (DateDiff(DateInterval.Month, v_dtFROMDATE, v_dtTODATE) - 1) * 30
                        'Làm tròn tháng chỉ có 30 ngày
                        v_intCMPDAY = IIf(30 - v_dtFROMDATE.Day > 0, 30 - v_dtFROMDATE.Day, 0)
                        v_intCURRDAY = IIf(v_dtTODATE.Day > 30, 30, v_dtTODATE.Day)
                        pv_intDAYS = pv_intDAYS + v_intCMPDAY + v_intCURRDAY
                    Else
                        pv_intDAYS = DateDiff(DateInterval.Day, v_dtFROMDATE, v_dtTODATE)
                        If pv_intDAYS > 30 Then pv_intDAYS = 30
                    End If
                Case "E"
                    'Làm tròn tháng 30 ngày, nhưng nếu có tháng 2 thì phải xác định chính xác số ngày của tháng 2 đó. 
                    'Giải thuật là nếu có tháng 2 nằm trong khoảng thời gian xử lý thì xác định số ngày của tháng 2 đó

                    'Làm tròn tháng 30 ngày (giống với MONTHDAY=M)
                    If DateDiff(DateInterval.Month, v_dtFROMDATE, v_dtTODATE) > 0 Then
                        'Nếu khác tháng. Lấy số ngày trong các tháng nằm giữa CMPDATE và CURRDATE
                        pv_intDAYS = (DateDiff(DateInterval.Month, v_dtFROMDATE, v_dtTODATE) - 1) * 30
                        'Làm tròn tháng chỉ có 30 ngày
                        v_intCMPDAY = IIf(30 - v_dtFROMDATE.Day > 0, 30 - v_dtFROMDATE.Day, 0)
                        v_intCURRDAY = IIf(v_dtTODATE.Day > 30, 30, v_dtTODATE.Day)
                        pv_intDAYS = pv_intDAYS + v_intCMPDAY + v_intCURRDAY
                    Else
                        pv_intDAYS = DateDiff(DateInterval.Day, v_dtFROMDATE, v_dtTODATE)
                        If pv_intDAYS > 30 Then pv_intDAYS = 30
                    End If

                    'Duyệt từ v_dtCMPDATE đến v_dtCURRDATE có bao nhiêu tháng 2
                    v_intCMPDAY = 0
                    While v_dtFROMDATE < v_dtTODATE
                        If v_dtFROMDATE.Month = 2 Then
                            v_intCMPDAY = v_intCMPDAY + 30 - v_dtFROMDATE.DaysInMonth(v_dtFROMDATE.Year, 2)
                        End If
                        v_dtFROMDATE = DateAdd(DateInterval.Month, 1, v_dtFROMDATE)
                    End While
                    'Xử lý nếu ngày hiện tại là cuối tháng 2
                    If v_dtTODATE.Month = 2 And v_dtTODATE.Day >= v_dtTODATE.DaysInMonth(v_dtTODATE.Year, 2) Then
                        v_intCMPDAY = v_intCMPDAY + 30 - v_dtTODATE.DaysInMonth(v_dtTODATE.Year, 2)
                    End If
                    'Số ngày tính được sẽ bằng số tròn 30 ngày trừ đi số ngày tháng 2 bị bù
                    pv_intDAYS = pv_intDAYS - v_intCMPDAY
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getRepoAccount(ByVal v_strAFACCOUNT As String) As String
        Dim v_strClause, v_strAutoID As String
        Dim v_int, v_intCount As Integer
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strVALUE As String
        'Lấy ra số tự tăng
        v_strClause = "SEQ_RPMAST"
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_wsBDS As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strClause, "GetInventory")
        v_wsBDS.Message(v_strObjMsg)
        v_xmlDocument.LoadXml(v_strObjMsg)
        v_strAutoID = v_xmlDocument.DocumentElement.Attributes("CLAUSE").Value
        'Tạo số hiệu lệnh = Số hợp đồng  + Số tự tăng
        Dim v_strRPAcount As String
        v_strRPAcount = v_strAFACCOUNT & Strings.Right(gc_FORMAT_RPAUTOID & CStr(v_strAutoID), Len(gc_FORMAT_RPAUTOID))
        Return v_strRPAcount
    End Function

    Private Function ControlValidation() As Boolean
        If Len(Me.mskAFACCTNO.Text) = 0 Then
            MsgBox(mv_ResourceManager.GetString("ERR_FIELD_NULL"), MsgBoxStyle.Information, Me.Text)
            Me.ActiveControl = mskAFACCTNO
            Return False
        End If
        If Len(Me.txtQuantity.Text) = 0 Then
            MsgBox(mv_ResourceManager.GetString("ERR_FIELD_NULL"), MsgBoxStyle.Information, Me.Text)
            Me.ActiveControl = txtQuantity
            Return False
        End If
        If cboExecType.SelectedValue <> "003" Then
            If Len(Me.txtContractRate.Text) = 0 Then
                MsgBox(mv_ResourceManager.GetString("ERR_FIELD_NULL"), MsgBoxStyle.Information, Me.Text)
                Me.ActiveControl = txtContractRate
                Return False
            End If
            If Len(Me.txtTPRRate.Text) = 0 Then
                MsgBox(mv_ResourceManager.GetString("ERR_FIELD_NULL"), MsgBoxStyle.Information, Me.Text)
                Me.ActiveControl = txtTPRRate
                Return False
            End If
            If Len(Me.txtBreakTerm.Text) = 0 Then
                MsgBox(mv_ResourceManager.GetString("ERR_FIELD_NULL"), MsgBoxStyle.Information, Me.Text)
                Me.ActiveControl = txtBreakTerm
                Return False
            End If
            If Len(Me.txtSpotPrice.Text) = 0 Then
                MsgBox(mv_ResourceManager.GetString("ERR_FIELD_NULL"), MsgBoxStyle.Information, Me.Text)
                Me.ActiveControl = txtSpotPrice
                Return False
            End If
            If Len(Me.txtSpotValue.Text) = 0 Then
                MsgBox(mv_ResourceManager.GetString("ERR_FIELD_NULL"), MsgBoxStyle.Information, Me.Text)
                Me.ActiveControl = txtSpotValue
                Return False
            End If
            If DDMMYYYY_SystemDate(Me.dtpForwardDate.Value) < DDMMYYYY_SystemDate(Me.dtpSpotDate.Value) Then
                MsgBox(mv_ResourceManager.GetString("FORWARDDATEISSMALLERTHANSPOTDATE"), MsgBoxStyle.Information, Me.Text)
                Me.ActiveControl = dtpForwardDate
                Return False
            End If
            If DDMMYYYY_SystemDate(Me.dtpSpotDate.Value) < DDMMYYYY_SystemDate(Me.dtpRPDate.Value) Then
                MsgBox(mv_ResourceManager.GetString("SPOTDATEISSMALLERTHANCONTRACTDATE"), MsgBoxStyle.Information, Me.Text)
                Me.ActiveControl = dtpSpotDate
                Return False
            End If
        Else
            If Len(Me.txtSECUREDRATIO.Text) = 0 Then
                MsgBox(mv_ResourceManager.GetString("ERR_FIELD_NULL"), MsgBoxStyle.Information, Me.Text)
                Me.ActiveControl = txtSECUREDRATIO
                Return False
            End If
            If DDMMYYYY_SystemDate(Me.dtpForwardDate.Value) < DDMMYYYY_SystemDate(Me.dtpRPDate.Value) Then
                MsgBox(mv_ResourceManager.GetString("FORWARDDATEISSMALLERTHANRPDATE"), MsgBoxStyle.Information, Me.Text)
                Me.ActiveControl = dtpForwardDate
                Return False
            End If
        End If
        If Len(Me.txtForwardPrice.Text) = 0 Then
            MsgBox(mv_ResourceManager.GetString("ERR_FIELD_NULL"), MsgBoxStyle.Information, Me.Text)
            Me.ActiveControl = txtForwardPrice
            Return False
        End If
        If Len(Me.txtForwardValue.Text) = 0 Then
            MsgBox(mv_ResourceManager.GetString("ERR_FIELD_NULL"), MsgBoxStyle.Information, Me.Text)
            Me.ActiveControl = txtForwardValue
            Return False
        End If
        Return True
    End Function

#End Region

#Region " Form events "
    Private Sub frmODTransact_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitDialog()
    End Sub

    Private Sub frmODTransact_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        DoResizeForm()
    End Sub

    Private Sub frmODTransact_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Dim v_intPos As Int16, ctl As Control, strFLDNAME As String, v_intIndex As Integer
        Select Case e.KeyCode
            Case Keys.Escape
                OnClose()
            Case Keys.F5
                If Me.ActiveControl.Name = "mskAFACCTNO" Then
                    Dim frm As New frmSearch(Me.UserLanguage)
                    frm.TableName = "AFMAST"
                    frm.ModuleCode = "CF"
                    frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                    frm.IsLocalSearch = gc_IsNotLocalMsg
                    frm.IsLookup = "Y"
                    frm.SearchOnInit = False
                    frm.BranchId = Me.BranchId
                    frm.TellerId = Me.TellerId
                    frm.ShowDialog()
                    Me.ActiveControl.Text = Trim(frm.ReturnValue)
                    If Len(frm.RefValue) > 0 Then
                        lblAFNAME.Text = Trim(frm.RefValue)
                    End If
                    frm.Dispose()
                End If
            Case Keys.Enter
                If Not TypeOf (Me.ActiveControl) Is Button Then
                    'Nếu là các trường của giao dịch thì chuyển đến control kế tiếp
                    SendKeys.Send("{Tab}")
                    e.Handled = True
                Else
                End If
        End Select
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        OnSubmit()
    End Sub

    Private Sub btnCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCANCEL.Click
        If Me.mskAFACCTNO.Enabled Then
            OnClose()
        Else
            ResetScreen(Me)
        End If
    End Sub

    Private Sub cboCODEID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCODEID.SelectedIndexChanged
        Try
            'Lấy thông tin về giá chứng khoán
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_strValue, v_strFLDNAME, v_strTEXT As String

            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strCmdSQL As String, v_strObjMsg As String
            v_strCmdSQL = "SELECT FLOORPRICE, CEILINGPRICE, TRADELOT FROM SECURITIES_INFO WHERE CODEID='" & cboCODEID.SelectedValue & "'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i As Integer = 0 To v_nodeList.Count - 1
                v_strTEXT = String.Empty
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = Trim(.InnerText.ToString)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "FLOORPRICE"
                                v_strTEXT = v_strTEXT & " [" & mv_ResourceManager.GetString("FLOORPRICE") & v_strValue & "] "
                                mv_dblFloorPrice = CDbl(v_strValue)
                            Case "CEILINGPRICE"
                                v_strTEXT = v_strTEXT & " [" & mv_ResourceManager.GetString("CEILINGPRICE") & v_strValue & "] "
                                mv_dblCeilingPrice = CDbl(v_strValue)
                            Case "TRADELOT"
                                v_strTEXT = v_strTEXT & " [" & mv_ResourceManager.GetString("TRADELOT") & v_strValue & "] "
                                mv_dblTradeLot = CDbl(v_strValue)
                        End Select
                    End With
                Next
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, Me.Text)
        End Try
    End Sub

    Private Sub cboExecType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboExecType.SelectedIndexChanged
        Try
            If cboExecType.SelectedIndex <> -1 Then
                Me.pnRepo.BackColor = getTransBGColor(cboExecType.SelectedIndex)
            End If
            If cboExecType.SelectedValue Is System.DBNull.Value Then
                Exit Sub
            End If
            Select Case cboExecType.SelectedValue
                Case "001", "002" 'Repo
                    If IsNumeric(txtSpotPrice.Text) And IsNumeric(txtContractRate.Text) And IsNumeric(txtQuantity.Text) Then
                        Me.txtForwardPrice.Text = getForwardPrice.ToString
                        Me.txtForwardValue.Text = getForwardPrice() * CDbl(txtQuantity.Text)
                    End If
                    Me.pnSpot.Enabled = True
                    Me.txtSECUREDRATIO.Enabled = False
                Case "003" 'Rerepo
                    Me.pnSpot.Enabled = False
                    Me.txtSECUREDRATIO.Enabled = True
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub mskAFACCTNO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mskAFACCTNO.Validating
        Try
            'If Len(mskAFACCTNO.Text) < 10 Then
            '    'Không nhập đủ độ dài
            '    MsgBox(mv_ResourceManager.GetString("CONTRACTINVALID"), MsgBoxStyle.Information, Me.Text)
            '    e.Cancel = True
            'End If
        Catch ex As Exception

        End Try
    End Sub



    Private Sub txtQuantity_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtQuantity.Validating
        If Not IsNumeric(txtQuantity.Text) Then
            MsgBox(mv_ResourceManager.GetString("QTTYISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
        ElseIf CDbl(txtQuantity.Text) < 0 Then
            MsgBox(mv_ResourceManager.GetString("QTTYSHOULDBEPOSITIVENUMBER"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
        Else
            If mv_dblTradeLot > 0 Then
                If CDbl(txtQuantity.Text) Mod mv_dblTradeLot > 0 Then
                    MsgBox(mv_ResourceManager.GetString("TRADELOTINVALID"), MsgBoxStyle.Information, Me.Text)
                    e.Cancel = True
                End If
            End If
            If cboExecType.SelectedValue <> "003" Then
                If IsNumeric(txtSpotPrice.Text) Then
                    txtSpotValue.Text = (CDbl(txtSpotPrice.Text) * CDbl(txtQuantity.Text)).ToString
                    If IsNumeric(txtSpotPrice.Text) And IsNumeric(txtContractRate.Text) And IsNumeric(txtQuantity.Text) Then
                        Me.txtForwardPrice.Text = getForwardPrice.ToString
                        Me.txtForwardValue.Text = getForwardPrice() * CDbl(txtQuantity.Text)
                    End If
                Else
                    txtSpotValue.Text = ""
                End If
            Else
                If IsNumeric(txtForwardPrice.Text) Then
                    txtForwardValue.Text = (CDbl(txtForwardPrice.Text) * CDbl(txtQuantity.Text)).ToString
                Else
                    txtForwardValue.Text = ""
                End If
            End If

        End If
    End Sub


    Private Sub txtQuantity_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQuantity.GotFocus
        With txtQuantity
            .SelectionStart = 0
            .SelectionLength = Len(.Text)
        End With
    End Sub

    Private Sub txtSpotPrice_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSpotPrice.Validating
        If Not IsNumeric(txtSpotPrice.Text) Then
            MsgBox(mv_ResourceManager.GetString("SPOTPRICEISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
        ElseIf CDbl(txtSpotPrice.Text) < 0 Then
            MsgBox(mv_ResourceManager.GetString("SPOTPRICESHOULDBEPOSITIVENUMBER"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
        Else
            If IsNumeric(txtQuantity.Text) Then
                txtSpotValue.Text = (CDbl(txtSpotPrice.Text) * CDbl(txtQuantity.Text)).ToString
                If IsNumeric(txtSpotPrice.Text) And IsNumeric(txtContractRate.Text) And IsNumeric(txtQuantity.Text) Then
                    Me.txtForwardPrice.Text = getForwardPrice.ToString
                    Me.txtForwardValue.Text = getForwardPrice() * CDbl(txtQuantity.Text)
                End If
            Else
                txtSpotValue.Text = ""
            End If
        End If
    End Sub

    Private Sub txtSpotPrice_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSpotPrice.GotFocus
        With txtSpotPrice
            .SelectionStart = 0
            .SelectionLength = Len(.Text)
        End With
    End Sub
    Private Sub txtSpotValue_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSpotValue.Validating
        If Not IsNumeric(txtSpotValue.Text) Then
            MsgBox(mv_ResourceManager.GetString("SPOTVALUEISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
        ElseIf CDbl(txtSpotPrice.Text) < 0 Then
            MsgBox(mv_ResourceManager.GetString("SPOTVALUESHOULDBEPOSITIVENUMBER"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
        Else
            If IsNumeric(txtQuantity.Text) And CDbl(txtQuantity.Text) > 0 Then
                txtSpotPrice.Text = ((CDbl(txtSpotValue.Text) / CDbl(txtQuantity.Text))).ToString
                If IsNumeric(txtSpotPrice.Text) And IsNumeric(txtContractRate.Text) And IsNumeric(txtQuantity.Text) Then
                    Me.txtForwardPrice.Text = getForwardPrice.ToString
                    Me.txtForwardValue.Text = getForwardPrice() * CDbl(txtQuantity.Text)
                End If
            Else
                txtSpotValue.Text = ""
            End If
        End If
    End Sub
    Private Sub txtSpotValue_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSpotValue.GotFocus
        With txtSpotValue
            .SelectionStart = 0
            .SelectionLength = Len(.Text)
        End With
    End Sub
    Private Sub txtPenanty_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPenanty.Validating
        If Len(txtPenanty.Text) = 0 Then
            txtPenanty.Text = "0"
        Else
            If Not IsNumeric(txtPenanty.Text) Then
                MsgBox(mv_ResourceManager.GetString("PenantyVALUEISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
                txtPenanty.Text = "0"
                e.Cancel = True
            ElseIf CDbl(txtPenanty.Text) < 0 Then
                MsgBox(mv_ResourceManager.GetString("PenantySHOULDBEPOSITIVENUMBER"), MsgBoxStyle.Information, Me.Text)
                txtPenanty.Text = "0"
                e.Cancel = True
            End If
        End If
    End Sub
    Private Sub txtPenanty_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPenanty.GotFocus
        If Not IsNumeric(txtPenanty.Text) Then
            txtPenanty.Text = "0"
        End If
        With txtPenanty
            .SelectionStart = 0
            .SelectionLength = Len(.Text)
        End With
    End Sub

    Private Sub txtContractRate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtContractRate.Validating
        If Not IsNumeric(txtContractRate.Text) Then
            MsgBox(mv_ResourceManager.GetString("ContractRateISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
        ElseIf CDbl(txtContractRate.Text) < 0 Then
            MsgBox(mv_ResourceManager.GetString("ContractRateSHOULDBEPOSITIVENUMBER"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
        ElseIf cboExecType.SelectedValue <> "003" Then
            If IsNumeric(txtSpotPrice.Text) And IsNumeric(txtContractRate.Text) And IsNumeric(txtQuantity.Text) Then
                Me.txtForwardPrice.Text = getForwardPrice.ToString
                Me.txtForwardValue.Text = getForwardPrice() * CDbl(txtQuantity.Text)
            End If
        End If
    End Sub

    Private Sub txtContractRate_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtContractRate.GotFocus
        With txtContractRate
            .SelectionStart = 0
            .SelectionLength = Len(.Text)
        End With
    End Sub

    Private Sub txtSECUREDRATIO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSECUREDRATIO.Validating
        If cboExecType.SelectedValue = "003" Then
            If Not IsNumeric(txtSECUREDRATIO.Text) Then
                MsgBox(mv_ResourceManager.GetString("SECUREDRATIOISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
                e.Cancel = True
            ElseIf CDbl(txtSECUREDRATIO.Text) < 0 Or CDbl(txtSECUREDRATIO.Text) > 100 Then
                MsgBox(mv_ResourceManager.GetString("SECUREDRATIOSHOULDBEINRANGENUMBER"), MsgBoxStyle.Information, Me.Text)
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub txtSECUREDRATIO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSECUREDRATIO.GotFocus
        With txtContractRate
            .SelectionStart = 0
            .SelectionLength = Len(.Text)
        End With
    End Sub
    Private Sub txtTPRRate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTPRRate.Validating
        If Not IsNumeric(txtTPRRate.Text) Then
            MsgBox(mv_ResourceManager.GetString("TPRRateISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
        ElseIf CDbl(txtTPRRate.Text) < 0 Then
            MsgBox(mv_ResourceManager.GetString("TPRRateSHOULDBEPOSITIVENUMBER"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
        End If
    End Sub

    Private Sub txtTPRRate_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTPRRate.GotFocus
        With txtTPRRate
            .SelectionStart = 0
            .SelectionLength = Len(.Text)
        End With
    End Sub
    Private Sub txtBreakTerm_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtBreakTerm.Validating
        If Not IsNumeric(txtBreakTerm.Text) Then
            MsgBox(mv_ResourceManager.GetString("BreakTermISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
        ElseIf CDbl(txtBreakTerm.Text) < 0 Then
            MsgBox(mv_ResourceManager.GetString("BreakTermSHOULDBEPOSITIVENUMBER"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
        Else
            txtBreakTerm.Text = (CInt(txtBreakTerm.Text)).ToString
        End If
    End Sub

    Private Sub txtBreakTerm_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBreakTerm.GotFocus
        With txtBreakTerm
            .SelectionStart = 0
            .SelectionLength = Len(.Text)
        End With
    End Sub

    Private Sub cboYearDay_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboYearDay.SelectedIndexChanged
        If cboExecType.SelectedValue <> "003" Then
            If IsNumeric(txtSpotPrice.Text) And IsNumeric(txtContractRate.Text) And IsNumeric(txtQuantity.Text) Then
                Me.txtForwardPrice.Text = getForwardPrice.ToString
                Me.txtForwardValue.Text = getForwardPrice() * CDbl(txtQuantity.Text)
            End If
        End If
    End Sub

    Private Sub txtForwardPrice_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtForwardPrice.Validating
        If Not IsNumeric(txtForwardPrice.Text) Then
            MsgBox(mv_ResourceManager.GetString("ForwardPRICEISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
        ElseIf CDbl(txtForwardPrice.Text) < 0 Then
            MsgBox(mv_ResourceManager.GetString("ForwardPRICESHOULDBEPOSITIVENUMBER"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
        Else
            If IsNumeric(txtQuantity.Text) Then
                If IsNumeric(txtQuantity.Text) Then
                    txtForwardValue.Text = (CDbl(txtForwardPrice.Text) * CDbl(txtQuantity.Text)).ToString
                End If
                If IsNumeric(txtForwardPrice.Text) And IsNumeric(txtContractRate.Text) And IsNumeric(txtQuantity.Text) Then
                    Me.txtSpotPrice.Text = getSpotPrice.ToString
                    Me.txtSpotValue.Text = getSpotPrice() * CDbl(txtQuantity.Text)
                End If
            Else
                txtForwardValue.Text = ""
            End If
        End If
    End Sub

    Private Sub txtForwardPrice_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtForwardPrice.GotFocus
        With txtForwardPrice
            .SelectionStart = 0
            .SelectionLength = Len(.Text)
        End With
    End Sub
    Private Sub txtForwardValue_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtForwardValue.Validating
        If Not IsNumeric(txtForwardValue.Text) Then
            MsgBox(mv_ResourceManager.GetString("ForwardVALUEISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
        ElseIf CDbl(txtForwardPrice.Text) < 0 Then
            MsgBox(mv_ResourceManager.GetString("ForwardVALUESHOULDBEPOSITIVENUMBER"), MsgBoxStyle.Information, Me.Text)
            e.Cancel = True
        Else
            If IsNumeric(txtQuantity.Text) Then
                txtForwardPrice.Text = ((CDbl(txtForwardValue.Text) / CDbl(txtQuantity.Text))).ToString
                If IsNumeric(txtForwardPrice.Text) And IsNumeric(txtContractRate.Text) And IsNumeric(txtQuantity.Text) Then
                    Me.txtSpotPrice.Text = getSpotPrice.ToString
                    Me.txtSpotValue.Text = getSpotPrice() * CDbl(txtQuantity.Text)
                End If
            Else
                txtForwardValue.Text = ""
            End If
        End If
    End Sub
    Private Sub txtForwardValue_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtForwardValue.GotFocus
        With txtSpotValue
            .SelectionStart = 0
            .SelectionLength = Len(.Text)
        End With
    End Sub

    Private Sub dtpRPDate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpRPDate.Validating
        If cboExecType.SelectedValue <> "003" Then
            If IsNumeric(txtSpotPrice.Text) And IsNumeric(txtContractRate.Text) And IsNumeric(txtQuantity.Text) Then
                Me.txtForwardPrice.Text = getForwardPrice.ToString
                Me.txtForwardValue.Text = getForwardPrice() * CDbl(txtQuantity.Text)
            End If
        End If
    End Sub

    Private Sub dtpSpotDate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpSpotDate.Validating
        Dim v_dtSpotDate, v_dtForwardDate As Date
        If cboExecType.SelectedValue <> "003" Then
            v_dtSpotDate = DDMMYYYY_SystemDate(Me.dtpSpotDate.Value)
            v_dtForwardDate = DDMMYYYY_SystemDate(Me.dtpForwardDate.Value)
            If v_dtSpotDate > v_dtForwardDate Then
                'bao loi
                MsgBox(mv_ResourceManager.GetString("FORWARDDATEISSMALLERTHANSPOTDATE"), MsgBoxStyle.Information, Me.Text)
                e.Cancel = True
            Else
                If IsNumeric(txtSpotPrice.Text) And IsNumeric(txtContractRate.Text) And IsNumeric(txtQuantity.Text) Then
                    Me.txtForwardPrice.Text = getForwardPrice.ToString
                    Me.txtForwardValue.Text = getForwardPrice() * CDbl(txtQuantity.Text)
                End If
            End If
        End If
    End Sub

    Private Sub dtpFowardDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpForwardDate.Validating
        Dim v_dtSpotDate, v_dtForwardDate As Date
        If cboExecType.SelectedValue <> "003" Then
            v_dtSpotDate = DDMMYYYY_SystemDate(Me.dtpSpotDate.Value)
            v_dtForwardDate = DDMMYYYY_SystemDate(Me.dtpForwardDate.Value)
            If v_dtSpotDate > v_dtForwardDate Then
                'bao loi
                MsgBox(mv_ResourceManager.GetString("FORWARDDATEISSMALLERTHANSPOTDATE"), MsgBoxStyle.Information, Me.Text)
                e.Cancel = True
            Else
                If IsNumeric(txtSpotPrice.Text) And IsNumeric(txtContractRate.Text) And IsNumeric(txtQuantity.Text) Then
                    Me.txtForwardPrice.Text = getForwardPrice.ToString
                    Me.txtForwardValue.Text = getForwardPrice() * CDbl(txtQuantity.Text)
                End If
            End If
        End If
    End Sub
#End Region

End Class
