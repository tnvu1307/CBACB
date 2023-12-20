Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports CommonLibrary
Imports System.Collections

Public Class frmPostmap
    Inherits System.Windows.Forms.Form

#Region " Declare constant and variables "
    Const POS_GLBANK = 7

    Const SYSVAR_GRPNAME = "SYSTEM"

    Const SYSVAR_VAT_ACCTNO_IN = "VATACCTIN"
    Const SYSVAR_VAT_ACCTNO_OUT = "VATACCTOUT"

    Public v_dtgPostmap, v_dtgVATVoucher, v_dtgFA As GridEx
    Private mv_strLanguage As String
    Public mv_blnGridReadOnly As Boolean = False
    Const c_ResourceManager = "AppCore.frmPostmap-"

    Private mv_ResourceManager As Resources.ResourceManager
    Public mv_arrObjAccounts() As CAccountEntry
    Public mv_arrObjVATVoucher() As CVATVoucher
    Public mv_arrObjMISEntry() As CIEFMISEntry

    Const ACCOUNTENTRY_EN = "Account entries"
    Const SUBTXNO_EN = "No"
    Const CCYCD_EN = "Currency"
    Const DORC_EN = "Debit/Credit"
    Const ACCOUNT_EN = "Account"
    Const AMOUNT_EN = "Amount"
    Const ACCOUNTENTRY_VN = "Hạch toán"
    Const SUBTXNO_VN = "STT"
    Const CCYCD_VN = "Loại tiền"
    Const DORC_VN = "Nợ/Có"
    Const ACCOUNT_VN = "Tài khoản"
    Const AMOUNT_VN = "Số tiền"

    Private mv_strBranchId As String
    Private mv_strTellerId As String
    Private mv_strBusDate As String = String.Empty
    Private mv_strDescription As String = String.Empty

    Public Property BranchId() As String
        Get
            Return mv_strBranchId
        End Get
        Set(ByVal Value As String)
            mv_strBranchId = Value
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

    Public Property TellerId() As String
        Get
            Return mv_strTellerId
        End Get
        Set(ByVal Value As String)
            mv_strTellerId = Value
        End Set
    End Property

    Public Property TxDesc() As String
        Get
            Return mv_strDescription
        End Get
        Set(ByVal Value As String)
            mv_strDescription = Value
        End Set
    End Property
#End Region

#Region " Properties "
    Public Property UserLanguage() As String
        Get
            Return mv_strLanguage
        End Get
        Set(ByVal Value As String)
            mv_strLanguage = Value
        End Set
    End Property
#End Region

#Region " Windows Form Designer generated code "


    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mv_strLanguage = pv_strLanguage
        mv_arrObjAccounts = Nothing
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
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCANCEL As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Protected WithEvents lblCaption As System.Windows.Forms.Label
    Friend WithEvents tpgAccountEntries As System.Windows.Forms.TabPage
    Friend WithEvents tpgVATVoucher As System.Windows.Forms.TabPage
    Friend WithEvents pnAcctEntry As System.Windows.Forms.Panel
    Friend WithEvents pnVATVoucher As System.Windows.Forms.Panel
    Friend WithEvents lblFunction As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCANCEL = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tpgAccountEntries = New System.Windows.Forms.TabPage
        Me.pnAcctEntry = New System.Windows.Forms.Panel
        Me.tpgVATVoucher = New System.Windows.Forms.TabPage
        Me.pnVATVoucher = New System.Windows.Forms.Panel
        Me.lblFunction = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblCaption = New System.Windows.Forms.Label
        Me.TabControl1.SuspendLayout()
        Me.tpgAccountEntries.SuspendLayout()
        Me.tpgVATVoucher.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(424, 316)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(80, 24)
        Me.btnOK.TabIndex = 10
        Me.btnOK.Text = "btnOK"
        '
        'btnCANCEL
        '
        Me.btnCANCEL.Location = New System.Drawing.Point(508, 316)
        Me.btnCANCEL.Name = "btnCANCEL"
        Me.btnCANCEL.Size = New System.Drawing.Size(80, 24)
        Me.btnCANCEL.TabIndex = 11
        Me.btnCANCEL.Text = "btnCANCEL"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tpgAccountEntries)
        Me.TabControl1.Controls.Add(Me.tpgVATVoucher)
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(6, 56)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(582, 250)
        Me.TabControl1.TabIndex = 0
        '
        'tpgAccountEntries
        '
        Me.tpgAccountEntries.Controls.Add(Me.pnAcctEntry)
        Me.tpgAccountEntries.Location = New System.Drawing.Point(4, 22)
        Me.tpgAccountEntries.Name = "tpgAccountEntries"
        Me.tpgAccountEntries.Size = New System.Drawing.Size(574, 224)
        Me.tpgAccountEntries.TabIndex = 0
        Me.tpgAccountEntries.Text = "tpgAccountEntries"
        '
        'pnAcctEntry
        '
        Me.pnAcctEntry.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnAcctEntry.Location = New System.Drawing.Point(0, 0)
        Me.pnAcctEntry.Name = "pnAcctEntry"
        Me.pnAcctEntry.Size = New System.Drawing.Size(574, 224)
        Me.pnAcctEntry.TabIndex = 0
        '
        'tpgVATVoucher
        '
        Me.tpgVATVoucher.Controls.Add(Me.pnVATVoucher)
        Me.tpgVATVoucher.Location = New System.Drawing.Point(4, 22)
        Me.tpgVATVoucher.Name = "tpgVATVoucher"
        Me.tpgVATVoucher.Size = New System.Drawing.Size(574, 224)
        Me.tpgVATVoucher.TabIndex = 2
        Me.tpgVATVoucher.Text = "tpgVATVoucher"
        '
        'pnVATVoucher
        '
        Me.pnVATVoucher.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnVATVoucher.Location = New System.Drawing.Point(0, 0)
        Me.pnVATVoucher.Name = "pnVATVoucher"
        Me.pnVATVoucher.Size = New System.Drawing.Size(574, 224)
        Me.pnVATVoucher.TabIndex = 3
        Me.pnVATVoucher.Tag = "pnVATVoucher"
        '
        'lblFunction
        '
        Me.lblFunction.Location = New System.Drawing.Point(6, 316)
        Me.lblFunction.Name = "lblFunction"
        Me.lblFunction.Size = New System.Drawing.Size(410, 21)
        Me.lblFunction.TabIndex = 1
        Me.lblFunction.Tag = "lblFunction"
        Me.lblFunction.Text = "lblFunction"
        Me.lblFunction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.lblCaption)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(594, 50)
        Me.Panel1.TabIndex = 13
        '
        'lblCaption
        '
        Me.lblCaption.AutoSize = True
        Me.lblCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaption.Location = New System.Drawing.Point(7, 16)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(62, 17)
        Me.lblCaption.TabIndex = 0
        Me.lblCaption.Tag = "lblCaption"
        Me.lblCaption.Text = "lblCaption"
        '
        'frmPostmap
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ClientSize = New System.Drawing.Size(594, 345)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCANCEL)
        Me.Controls.Add(Me.lblFunction)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPostmap"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmPostmap"
        Me.TabControl1.ResumeLayout(False)
        Me.tpgAccountEntries.ResumeLayout(False)
        Me.tpgVATVoucher.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Other method "
    Protected Overridable Function InitDialog()
        'Khởi tạo kích thước form và load resource
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)

        'Init data grids
        InitGridPOSTMAP()
        'InitGridFixedAssest()
        InitGridVATVoucher()

        'Set focus in POSTMAP grid
        Me.ActiveControl = v_dtgPostmap
    End Function

    Private Sub InitGridPOSTMAP()
        Try
            'Khởi tạo Grid chứa thông tin định khoản
            Dim i, j As Integer
            'Nạp POSTMAP cho DataGrid
            v_dtgPostmap = New GridEx
            v_dtgPostmap.Dock = DockStyle.Fill
            Dim v_cmrHeader As New Xceed.Grid.ColumnManagerRow
            v_cmrHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            v_cmrHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            v_cmrHeader.HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
            v_dtgPostmap.FixedHeaderRows.Add(v_cmrHeader)

            v_dtgPostmap.Columns.Add(New Xceed.Grid.Column("SUBTXNO", GetType(Integer)))
            v_dtgPostmap.Columns.Add(New Xceed.Grid.Column("DORC", GetType(System.String)))
            v_dtgPostmap.Columns.Add(New Xceed.Grid.Column("ACCTNO", GetType(System.String)))
            v_dtgPostmap.Columns.Add(New Xceed.Grid.Column("ACCTNAME", GetType(System.String)))
            v_dtgPostmap.Columns.Add(New Xceed.Grid.Column("CCYCD", GetType(System.String)))
            v_dtgPostmap.Columns.Add(New Xceed.Grid.Column("CUSTID", GetType(System.String)))
            v_dtgPostmap.Columns.Add(New Xceed.Grid.Column("CUSTNAME", GetType(System.String)))
            v_dtgPostmap.Columns.Add(New Xceed.Grid.Column("DAMOUNT", GetType(System.Double)))
            v_dtgPostmap.Columns.Add(New Xceed.Grid.Column("CAMOUNT", GetType(System.Double)))
            v_dtgPostmap.Columns.Add(New Xceed.Grid.Column("DESC", GetType(System.String)))
            v_dtgPostmap.Columns.Add(New Xceed.Grid.Column("TASK", GetType(System.String)))
            v_dtgPostmap.Columns.Add(New Xceed.Grid.Column("FEEID", GetType(System.String)))
            v_dtgPostmap.Columns.Add(New Xceed.Grid.Column("DEPARTMENT", GetType(System.String)))

            v_dtgPostmap.Columns("SUBTXNO").ReadOnly = False
            v_dtgPostmap.Columns("DORC").ReadOnly = True
            v_dtgPostmap.Columns("ACCTNO").ReadOnly = False
            v_dtgPostmap.Columns("DAMOUNT").ReadOnly = False
            v_dtgPostmap.Columns("ACCTNAME").ReadOnly = True
            v_dtgPostmap.Columns("CCYCD").ReadOnly = True
            v_dtgPostmap.Columns("CUSTID").ReadOnly = False
            v_dtgPostmap.Columns("CUSTNAME").ReadOnly = False
            v_dtgPostmap.Columns("CAMOUNT").ReadOnly = False
            v_dtgPostmap.Columns("DESC").ReadOnly = False
            v_dtgPostmap.Columns("TASK").ReadOnly = False
            v_dtgPostmap.Columns("FEEID").ReadOnly = False
            v_dtgPostmap.Columns("DEPARTMENT").ReadOnly = False

            For i = 0 To v_dtgPostmap.Columns.Count - 1 Step 1
                v_dtgPostmap.Columns(i).Title = mv_ResourceManager.GetString("frmPostmap." & v_dtgPostmap.Columns(i).FieldName)
            Next
            v_dtgPostmap.Columns("SUBTXNO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
            v_dtgPostmap.Columns("SUBTXNO").Width = 40
            v_dtgPostmap.Columns("CCYCD").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
            v_dtgPostmap.Columns("CCYCD").Width = 60
            v_dtgPostmap.Columns("DORC").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
            v_dtgPostmap.Columns("DORC").Width = 80
            v_dtgPostmap.Columns("DORC").Visible = False
            v_dtgPostmap.Columns("ACCTNO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            v_dtgPostmap.Columns("ACCTNO").Width = 150
            v_dtgPostmap.Columns("ACCTNAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            v_dtgPostmap.Columns("ACCTNAME").Width = 150
            v_dtgPostmap.Columns("DAMOUNT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
            v_dtgPostmap.Columns("DAMOUNT").Width = 110
            v_dtgPostmap.Columns("DAMOUNT").FormatSpecifier = "#,##0.00"
            v_dtgPostmap.Columns("CAMOUNT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
            v_dtgPostmap.Columns("CAMOUNT").Width = 110
            v_dtgPostmap.Columns("CAMOUNT").FormatSpecifier = "#,##0.00"
            v_dtgPostmap.Columns("CUSTID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            v_dtgPostmap.Columns("CUSTID").Width = 100
            v_dtgPostmap.Columns("CUSTNAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            v_dtgPostmap.Columns("CUSTNAME").Width = 150
            v_dtgPostmap.Columns("DESC").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            v_dtgPostmap.Columns("DESC").Width = 100
            v_dtgPostmap.Columns("TASK").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            v_dtgPostmap.Columns("TASK").Width = 100
            v_dtgPostmap.Columns("FEEID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            v_dtgPostmap.Columns("FEEID").Width = 100
            v_dtgPostmap.Columns("DEPARTMENT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            v_dtgPostmap.Columns("DEPARTMENT").Width = 100

            'Định nghĩa các sự kiện của grid ở đây
            If v_dtgPostmap.DataRowTemplate.Cells.Count >= 0 Then
                AddHandler v_dtgPostmap.DataRowTemplate.Cells("DORC").DoubleClick, AddressOf Grid_DORCDoubleClick
                AddHandler v_dtgPostmap.DataRowTemplate.Cells("DORC").KeyUp, AddressOf Grid_DORCKeyUp
                AddHandler v_dtgPostmap.DataRowTemplate.Cells("DAMOUNT").ValueChanged, AddressOf Grid_AMOUNTValueChanged
                AddHandler v_dtgPostmap.DataRowTemplate.Cells("CAMOUNT").ValueChanged, AddressOf Grid_AMOUNTValueChanged
                AddHandler v_dtgPostmap.DataRowTemplate.Cells("ACCTNO").KeyUp, AddressOf Grid_DATACELLKeyUp
                AddHandler v_dtgPostmap.DataRowTemplate.Cells("TASK").KeyUp, AddressOf Grid_DATACELLKeyUp
                AddHandler v_dtgPostmap.DataRowTemplate.Cells("CUSTID").KeyUp, AddressOf Grid_DATACELLKeyUp
                AddHandler v_dtgPostmap.DataRowTemplate.Cells("FEEID").KeyUp, AddressOf Grid_DATACELLKeyUp
                AddHandler v_dtgPostmap.DataRowTemplate.Cells("DEPARTMENT").KeyUp, AddressOf Grid_DATACELLKeyUp
                AddHandler v_dtgPostmap.DataRowTemplate.Cells("ACCTNO").ValueChanged, AddressOf Grid_DATACELLLeavingEdit
                AddHandler v_dtgPostmap.DataRowTemplate.Cells("TASK").ValueChanged, AddressOf Grid_DATACELLLeavingEdit
                AddHandler v_dtgPostmap.DataRowTemplate.Cells("CUSTID").ValueChanged, AddressOf Grid_DATACELLLeavingEdit
                AddHandler v_dtgPostmap.DataRowTemplate.Cells("FEEID").ValueChanged, AddressOf Grid_DATACELLLeavingEdit
                AddHandler v_dtgPostmap.DataRowTemplate.Cells("DEPARTMENT").ValueChanged, AddressOf Grid_DATACELLLeavingEdit

                AddHandler v_dtgPostmap.DataRowTemplate.KeyUp, AddressOf Grid_KeyUp
                AddHandler v_dtgPostmap.DataRowTemplate.KeyDown, AddressOf GridPOSTMAP_KeyDown
            End If

            'Hiện bộ định khoản nếu có
            If Not mv_arrObjAccounts Is Nothing Then
                Dim v_intCount As Integer = mv_arrObjAccounts.GetLength(0)
                If v_intCount > 0 Then
                    v_dtgPostmap.BeginInit()
                    For v_intIndex As Integer = 0 To v_intCount - 1 Step 1
                        If Not mv_arrObjAccounts(v_intIndex) Is Nothing Then
                            Dim v_xDataRow As Xceed.Grid.DataRow = v_dtgPostmap.DataRows.AddNew()
                            v_xDataRow.Cells("SUBTXNO").Value = mv_arrObjAccounts(v_intIndex).SUBTXNO
                            v_xDataRow.Cells("CCYCD").Value = mv_arrObjAccounts(v_intIndex).CCYCD
                            v_xDataRow.Cells("DORC").Value = mv_arrObjAccounts(v_intIndex).DORC
                            If Trim(mv_arrObjAccounts(v_intIndex).DORC) = "C" Then
                                v_xDataRow.Cells("CAMOUNT").Value = mv_arrObjAccounts(v_intIndex).AMOUNT
                                v_xDataRow.Cells("DAMOUNT").Value = CDbl(0)
                            Else
                                v_xDataRow.Cells("DAMOUNT").Value = mv_arrObjAccounts(v_intIndex).AMOUNT
                                v_xDataRow.Cells("CAMOUNT").Value = CDbl(0)
                            End If
                            v_xDataRow.Cells("ACCTNO").Value = mv_arrObjAccounts(v_intIndex).ACCTNO
                            If Not mv_arrObjMISEntry Is Nothing Then
                                For j = 0 To v_intCount - 1 Step 1
                                    If mv_arrObjMISEntry(j).ACCTNO = mv_arrObjAccounts(v_intIndex).ACCTNO And mv_arrObjMISEntry(j).DORC = mv_arrObjAccounts(v_intIndex).DORC And mv_arrObjMISEntry(j).SUBTXNO = mv_arrObjAccounts(v_intIndex).SUBTXNO Then
                                        v_xdataRow.Cells("CUSTID").Value = mv_arrObjMISEntry(j).CUSTID
                                        v_xDataRow.Cells("CUSTNAME").Value = mv_arrObjMISEntry(j).CUSTNAME
                                        v_xDataRow.Cells("DEPARTMENT").Value = mv_arrObjMISEntry(j).DEPTCD
                                        v_xDataRow.Cells("DESC").Value = mv_arrObjMISEntry(j).DESCRIPTION
                                        v_xDataRow.Cells("DORC").Value = mv_arrObjMISEntry(j).DORC
                                        v_xDataRow.Cells("FEEID").Value = mv_arrObjMISEntry(j).MICD
                                        v_xDataRow.Cells("SUBTXNO").Value = mv_arrObjMISEntry(j).SUBTXNO
                                        v_xDataRow.Cells("TASK").Value = mv_arrObjMISEntry(j).TASKCD
                                        Exit For
                                    End If
                                Next
                            End If
                            
                            v_xDataRow.EndEdit()
                        End If
                    Next
                    v_dtgPostmap.EndInit()
                End If
            End If
            If Not mv_blnGridReadOnly Then
                For i = 1 To 2 Step 1
                    Dim v_xDataRow As Xceed.Grid.DataRow = v_dtgPostmap.DataRows.AddNew()
                    v_xDataRow.Cells("DAMOUNT").Value = CDbl(0)
                    v_xDataRow.Cells("CAMOUNT").Value = CDbl(0)
                    v_xDataRow.Cells("DESC").Value = TxDesc
                    v_xDataRow.Cells("TASK").Value = "MIS"
                    v_xDataRow.Cells("FEEID").Value = "MIS"
                    v_xDataRow.Cells("DEPARTMENT").Value = "MIS"
                    v_xDataRow.EndEdit()
                Next
            End If

            'Nạp vào Panel
            v_dtgPostmap.ReadOnly = mv_blnGridReadOnly
            Me.pnAcctEntry.Controls.Add(v_dtgPostmap)
        Catch ex As Exception
            MessageBox.Show("Can not itinial postmap grid!")
        End Try
    End Sub
    'Private Sub InitGridFixedAssest()
    '    'Khởi tạo Grid chứa thông tin định khoản
    '    Dim i As Integer
    '    'Nạp Fixed Assest cho DataGrid
    '    v_dtgFA = New GridEx
    '    v_dtgFA.Dock = DockStyle.Fill
    '    Dim v_cmrHeader As New Xceed.Grid.ColumnManagerRow
    '    v_cmrHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
    '    v_cmrHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
    '    v_dtgFA.FixedHeaderRows.Add(v_cmrHeader)
    '    v_dtgFA.Columns.Add(New Xceed.Grid.Column("ACNAME", GetType(System.String)))
    '    v_dtgFA.Columns("ACNAME").ReadOnly = False
    '    v_dtgFA.Columns.Add(New Xceed.Grid.Column("CCYCD", GetType(System.String)))
    '    v_dtgFA.Columns("CCYCD").ReadOnly = False
    '    v_dtgFA.Columns.Add(New Xceed.Grid.Column("PRICE", GetType(System.Double)))
    '    v_dtgFA.Columns("PRICE").ReadOnly = False
    '    v_dtgFA.Columns.Add(New Xceed.Grid.Column("MIGROUP", GetType(System.String)))
    '    v_dtgFA.Columns("MIGROUP").ReadOnly = True
    '    v_dtgFA.Columns.Add(New Xceed.Grid.Column("DEPTYPE", GetType(System.String)))
    '    v_dtgFA.Columns("DEPTYPE").ReadOnly = True
    '    v_dtgFA.Columns.Add(New Xceed.Grid.Column("DEPTIME", GetType(System.Double)))
    '    v_dtgFA.Columns("DEPTIME").ReadOnly = False
    '    v_dtgFA.Columns.Add(New Xceed.Grid.Column("PERCENTAGE", GetType(System.Double)))
    '    v_dtgFA.Columns("PERCENTAGE").ReadOnly = False
    '    v_dtgFA.Columns.Add(New Xceed.Grid.Column("ACCUMULATE", GetType(System.Double)))
    '    v_dtgFA.Columns("ACCUMULATE").ReadOnly = False
    '    v_dtgFA.Columns.Add(New Xceed.Grid.Column("DRGLEXPAC", GetType(System.String)))
    '    v_dtgFA.Columns("DRGLEXPAC").ReadOnly = False
    '    v_dtgFA.Columns.Add(New Xceed.Grid.Column("CRGLDEPRAC", GetType(System.String)))
    '    v_dtgFA.Columns("CRGLDEPRAC").ReadOnly = False
    '    v_dtgFA.Columns.Add(New Xceed.Grid.Column("DESCRIPTION", GetType(System.String)))
    '    v_dtgFA.Columns("DESCRIPTION").ReadOnly = False

    '    For i = 0 To v_dtgFA.Columns.Count - 1 Step 1
    '        v_dtgFA.Columns(i).Title = mv_ResourceManager.GetString("frmPostmap." & v_dtgFA.Columns(i).FieldName)
    '    Next

    '    v_dtgFA.Columns("ACNAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
    '    v_dtgFA.Columns("ACNAME").Width = 70
    '    v_dtgFA.Columns("CCYCD").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
    '    v_dtgFA.Columns("CCYCD").Width = 60
    '    v_dtgFA.Columns("PRICE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
    '    v_dtgFA.Columns("PRICE").Width = 100
    '    v_dtgFA.Columns("PRICE").FormatSpecifier = "#,##0.00"
    '    v_dtgFA.Columns("MIGROUP").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
    '    v_dtgFA.Columns("MIGROUP").Width = 100
    '    v_dtgFA.Columns("DEPTYPE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
    '    v_dtgFA.Columns("DEPTYPE").Width = 70
    '    v_dtgFA.Columns("DEPTIME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
    '    v_dtgFA.Columns("DEPTIME").Width = 100
    '    v_dtgFA.Columns("DEPTIME").FormatSpecifier = "#,##0"
    '    v_dtgFA.Columns("PERCENTAGE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
    '    v_dtgFA.Columns("PERCENTAGE").Width = 100
    '    v_dtgFA.Columns("PERCENTAGE").FormatSpecifier = "#,##0.00"
    '    v_dtgFA.Columns("ACCUMULATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
    '    v_dtgFA.Columns("ACCUMULATE").Width = 100
    '    v_dtgFA.Columns("ACCUMULATE").FormatSpecifier = "#,##0.00"
    '    v_dtgFA.Columns("DRGLEXPAC").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
    '    v_dtgFA.Columns("DRGLEXPAC").Width = 100
    '    v_dtgFA.Columns("CRGLDEPRAC").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
    '    v_dtgFA.Columns("CRGLDEPRAC").Width = 100
    '    v_dtgFA.Columns("DESCRIPTION").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
    '    v_dtgFA.Columns("DESCRIPTION").Width = 150


    '    'Định nghĩa các sự kiện của grid ở đây
    '    If v_dtgFA.DataRowTemplate.Cells.Count >= 0 Then
    '        AddHandler v_dtgFA.DataRowTemplate.Cells("MIGROUP").DoubleClick, AddressOf Grid_MIGROUPDoubleClick
    '        AddHandler v_dtgFA.DataRowTemplate.Cells("CCYCD").KeyUp, AddressOf Grid_CCYCDKeyUp
    '        AddHandler v_dtgFA.DataRowTemplate.Cells("MIGROUP").KeyUp, AddressOf Grid_MIGROUPKeyUp
    '        AddHandler v_dtgFA.DataRowTemplate.Cells("DEPTYPE").DoubleClick, AddressOf Grid_DEPTYPEDoubleClick
    '        AddHandler v_dtgFA.DataRowTemplate.Cells("DEPTYPE").KeyUp, AddressOf Grid_DEPTYPEKeyUp
    '        ''    AddHandler v_dtgFA.DataRowTemplate.Cells("ACCTNO").KeyUp, AddressOf Grid_ACCTNOKeyUp
    '        AddHandler v_dtgFA.DataRowTemplate.KeyUp, AddressOf GridFA_KeyUp
    '        AddHandler v_dtgFA.DataRowTemplate.Cells("CCYCD").ValueChanged, AddressOf Grid_CCYCDLeavingEdit
    '    End If

    '    'Hiện bộ định khoản nếu có
    '    If Not mv_arrObjMISEntry Is Nothing Then
    '        Dim v_intCount As Integer = mv_arrObjMISEntry.GetLength(0)
    '        If v_intCount > 0 Then
    '            v_dtgFA.BeginInit()
    '            For v_intIndex As Integer = 0 To v_intCount - 1 Step 1
    '                If Not mv_arrObjMISEntry(v_intIndex) Is Nothing Then
    '                    Dim v_xDataRow As Xceed.Grid.DataRow = v_dtgFA.DataRows.AddNew()
    '                    v_xDataRow.Cells("ACNAME").Value = mv_arrObjMISEntry(v_intIndex).ACNAME
    '                    v_xDataRow.Cells("CCYCD").Value = mv_arrObjMISEntry(v_intIndex).CCYCD
    '                    v_xDataRow.Cells("PRICE").Value = mv_arrObjMISEntry(v_intIndex).PRICE
    '                    v_xDataRow.Cells("MIGROUP").Value = mv_arrObjMISEntry(v_intIndex).MIGROUP
    '                    v_xDataRow.Cells("DEPTYPE").Value = mv_arrObjMISEntry(v_intIndex).DEPTYPE
    '                    v_xDataRow.Cells("DEPTIME").Value = mv_arrObjMISEntry(v_intIndex).DEPTIME
    '                    v_xDataRow.Cells("PERCENTAGE").Value = mv_arrObjMISEntry(v_intIndex).PERCENTAGE
    '                    v_xDataRow.Cells("ACCUMULATE").Value = mv_arrObjMISEntry(v_intIndex).ACCUMULATE
    '                    v_xDataRow.Cells("DRGLEXPAC").Value = mv_arrObjMISEntry(v_intIndex).DRGLEXPAC
    '                    v_xDataRow.Cells("CRGLDEPRAC").Value = mv_arrObjMISEntry(v_intIndex).CRGLDEPRAC
    '                    v_xDataRow.Cells("DESCRIPTION").Value = mv_arrObjMISEntry(v_intIndex).DESCRIPTION
    '                    v_xDataRow.EndEdit()
    '                End If
    '            Next
    '            v_dtgFA.EndInit()
    '        End If
    '    End If
    '    For i = 1 To 3 Step 1
    '        Dim v_dtRow As New Xceed.Grid.DataRow
    '        v_dtRow = v_dtgFA.DataRows.AddNew()
    '    Next

    '    'Nạp vào Panel
    '    Me.pnFA.Controls.Add(v_dtgFA)
    'End Sub

    Private Sub InitGridVATVoucher()
        Try
            'Khởi tạo Grid chứa thông tin định khoản
            Dim i As Integer

            'Nạp VATVoucher cho DataGrid
            v_dtgVATVoucher = New GridEx
            v_dtgVATVoucher.Dock = DockStyle.Fill
            Dim v_cmrHeader As New Xceed.Grid.ColumnManagerRow

            v_cmrHeader.HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
            v_cmrHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            v_cmrHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            v_dtgVATVoucher.FixedHeaderRows.Add(v_cmrHeader)

            With v_dtgVATVoucher
                'Add columns into VAT voucher grid
                .Columns.Add(New Xceed.Grid.Column("VOUCHERNO", GetType(System.String)))
                .Columns("VOUCHERNO").Width = 50

                .Columns.Add(New Xceed.Grid.Column("VOUCHERTYPE", GetType(System.String)))
                .Columns("VOUCHERTYPE").Width = 50

                .Columns.Add(New Xceed.Grid.Column("SERIENO", GetType(System.String)))
                .Columns("SERIENO").Width = 100

                .Columns.Add(New Xceed.Grid.Column("VOUCHERDATE", GetType(System.String)))
                .Columns("VOUCHERDATE").FormatSpecifier = "dd/MM/yyyy"
                .Columns("VOUCHERDATE").Width = 80

                .Columns.Add(New Xceed.Grid.Column("CUSTID", GetType(System.String)))
                .Columns("CUSTID").FormatSpecifier = "####.######"
                .Columns("CUSTID").Width = 100

                .Columns.Add(New Xceed.Grid.Column("CUSTNAME", GetType(System.String)))
                .Columns("CUSTNAME").Width = 300

                .Columns.Add(New Xceed.Grid.Column("ADDRESS", GetType(System.String)))
                .Columns("ADDRESS").Width = 300

                .Columns.Add(New Xceed.Grid.Column("TAXCODE", GetType(System.String)))
                .Columns("TAXCODE").Width = 100

                .Columns.Add(New Xceed.Grid.Column("CONTENTS", GetType(System.String)))
                .Columns("CONTENTS").Width = 200

                .Columns.Add(New Xceed.Grid.Column("QTTY", GetType(System.Double)))
                .Columns("QTTY").FormatSpecifier = "#,##0"
                .Columns("QTTY").Width = 100

                .Columns.Add(New Xceed.Grid.Column("PRICE", GetType(System.Double)))
                .Columns("PRICE").FormatSpecifier = "#,##0.00"
                .Columns("PRICE").Width = 100

                .Columns.Add(New Xceed.Grid.Column("AMT", GetType(System.Double)))
                .Columns("AMT").FormatSpecifier = "#,##0.00"
                .Columns("AMT").Width = 150

                .Columns.Add(New Xceed.Grid.Column("VATRATE", GetType(System.Double)))
                .Columns("VATRATE").FormatSpecifier = "#,##0.00"
                .Columns("VATRATE").Width = 100

                .Columns.Add(New Xceed.Grid.Column("VATAMT", GetType(System.Double)))
                .Columns("VATAMT").FormatSpecifier = "#,##0.00"
                .Columns("VATAMT").Width = 100

                .Columns.Add(New Xceed.Grid.Column("DESCRIPTION", GetType(System.String)))
                .Columns("DESCRIPTION").Width = 300
                'End of add columns into VAT voucher grid

                For i = 0 To v_dtgVATVoucher.Columns.Count - 1 Step 1
                    .Columns(i).Title = mv_ResourceManager.GetString("frmPostmap." & .Columns(i).FieldName)
                    .Columns(i).HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
                    .Columns(i).ReadOnly = False
                Next
            End With

            'Định nghĩa các sự kiện của grid ở đây
            If v_dtgVATVoucher.DataRowTemplate.Cells.Count >= 0 Then
                AddHandler v_dtgVATVoucher.DataRowTemplate.KeyUp, AddressOf GridVAT_KeyUp
                AddHandler v_dtgVATVoucher.DataRowTemplate.KeyDown, AddressOf GridVAT_KeyDown

                AddHandler v_dtgVATVoucher.DataRowTemplate.Cells("VOUCHERTYPE").ValueChanged, AddressOf GridVAT_DataCellLeavingEdit
                AddHandler v_dtgVATVoucher.DataRowTemplate.Cells("VOUCHERDATE").ValueChanged, AddressOf GridVAT_DataCellLeavingEdit
                AddHandler v_dtgVATVoucher.DataRowTemplate.Cells("CUSTID").ValueChanged, AddressOf GridVAT_DataCellLeavingEdit
                AddHandler v_dtgVATVoucher.DataRowTemplate.Cells("QTTY").ValueChanged, AddressOf GridVAT_DataCellLeavingEdit
                AddHandler v_dtgVATVoucher.DataRowTemplate.Cells("PRICE").ValueChanged, AddressOf GridVAT_DataCellLeavingEdit
                AddHandler v_dtgVATVoucher.DataRowTemplate.Cells("VATRATE").ValueChanged, AddressOf GridVAT_DataCellLeavingEdit
            End If

            'Hiện bộ định khoản nếu có
            If Not mv_arrObjVATVoucher Is Nothing Then
                Dim v_intCount As Integer = mv_arrObjVATVoucher.GetLength(0)
                If v_intCount > 0 Then
                    v_dtgVATVoucher.BeginInit()
                    For v_intIndex As Integer = 0 To v_intCount - 1 Step 1
                        If Not mv_arrObjVATVoucher(v_intIndex) Is Nothing Then
                            Dim v_xDataRow As Xceed.Grid.DataRow = v_dtgVATVoucher.DataRows.AddNew()
                            v_xDataRow.Cells("VOUCHERNO").Value = mv_arrObjVATVoucher(v_intIndex).VOUCHERNO
                            v_xDataRow.Cells("VOUCHERTYPE").Value = mv_arrObjVATVoucher(v_intIndex).VOUCHERTYPE
                            v_xDataRow.Cells("SERIENO").Value = mv_arrObjVATVoucher(v_intIndex).SERIENO
                            v_xDataRow.Cells("VOUCHERDATE").Value = mv_arrObjVATVoucher(v_intIndex).VOUCHERDATE
                            v_xDataRow.Cells("CUSTID").Value = mv_arrObjVATVoucher(v_intIndex).CUSTID
                            v_xDataRow.Cells("TAXCODE").Value = mv_arrObjVATVoucher(v_intIndex).TAXCODE
                            v_xDataRow.Cells("CUSTNAME").Value = mv_arrObjVATVoucher(v_intIndex).CUSTNAME
                            v_xDataRow.Cells("ADDRESS").Value = mv_arrObjVATVoucher(v_intIndex).ADDRESS
                            v_xDataRow.Cells("CONTENTS").Value = mv_arrObjVATVoucher(v_intIndex).CONTENTS
                            v_xDataRow.Cells("QTTY").Value = mv_arrObjVATVoucher(v_intIndex).QTTY
                            v_xDataRow.Cells("PRICE").Value = mv_arrObjVATVoucher(v_intIndex).PRICE
                            v_xDataRow.Cells("AMT").Value = mv_arrObjVATVoucher(v_intIndex).AMT
                            v_xDataRow.Cells("VATRATE").Value = mv_arrObjVATVoucher(v_intIndex).VATRATE
                            v_xDataRow.Cells("VATAMT").Value = mv_arrObjVATVoucher(v_intIndex).VATAMT
                            v_xDataRow.Cells("DESCRIPTION").Value = mv_arrObjVATVoucher(v_intIndex).DESCRIPTION
                            v_xDataRow.EndEdit()
                        End If
                    Next
                    v_dtgVATVoucher.EndInit()
                End If
            End If
            If Not mv_blnGridReadOnly Then
                For i = 1 To 1 Step 1
                    Dim v_xDataRow As Xceed.Grid.DataRow = v_dtgVATVoucher.DataRows.AddNew()
                    v_xDataRow.Cells("VOUCHERDATE").Value = BusDate
                    v_xDataRow.EndEdit()
                Next
            End If

            'Nạp vào Panel
            v_dtgVATVoucher.ReadOnly = mv_blnGridReadOnly
            Me.pnVATVoucher.Controls.Add(v_dtgVATVoucher)
        Catch ex As Exception
            LogError.Write("Error source: AppCore.frmPostmap.InitGridVATVoucher" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(mv_ResourceManager.GetString("INIT_VAT_POSTMAP_FAILED"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub DoResizeForm()

    End Sub

    Private Sub DoClose()
        Me.mv_arrObjVATVoucher = Nothing
        Me.mv_arrObjAccounts = Nothing
        Me.mv_arrObjMISEntry = Nothing
        Me.Close()
    End Sub

    Private Function CheckPostMapBeforeOK() As Boolean
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "GL.frmPOSTMAP.CheckPostMapBeforeOK", v_strErrorMessage As String = String.Empty

        Try
            Dim v_strSQL As String
            Dim v_strListGLAccount As String = String.Empty, v_blnOnBalanceSheet As Boolean = True
            Dim v_strOldSUBTXNO As String, v_strOldCCYCD As String, v_dblDrAmt As Double, v_dblCrAmt As Double
            Dim v_strSUBTXNO, v_strDORC, v_strCCYCD, v_strACCTNO As String, v_dblAMT As Double, i, j, k, v_intCount As Integer
            If mv_arrObjAccounts Is Nothing Then
                Return True
            End If
            If mv_arrObjAccounts.Length > 0 Then
                v_intCount = 0
                v_strOldSUBTXNO = vbNullString
                v_strOldCCYCD = vbNullString
                v_dblDrAmt = 0
                v_dblCrAmt = 0
                For i = 0 To mv_arrObjAccounts.Length - 1 Step 1
                    If Len(mv_arrObjAccounts(i).SUBTXNO) > 0 And Len(mv_arrObjAccounts(i).DORC) > 0 And Len(mv_arrObjAccounts(i).ACCTNO) > 7 And mv_arrObjAccounts(i).AMOUNT > 0 Then
                        'Lấy tham số hạch toán
                        With mv_arrObjAccounts(i)
                            v_strSUBTXNO = mv_arrObjAccounts(i).SUBTXNO
                            v_strDORC = mv_arrObjAccounts(i).DORC
                            v_strCCYCD = mv_arrObjAccounts(i).CCYCD
                            v_strACCTNO = mv_arrObjAccounts(i).ACCTNO
                            v_dblAMT = mv_arrObjAccounts(i).AMOUNT
                            If Mid(v_strACCTNO, POS_GLBANK, 1) = "0" Then
                                'Tài khoản ngoại bảng
                                v_blnOnBalanceSheet = False
                            Else
                                'Tài khoản nội bảng
                                v_blnOnBalanceSheet = True
                            End If
                        End With
                        If v_blnOnBalanceSheet Then
                            'Nếu là nội bảng thì kiểm tra xem bút toán này có tổng nợ bằng tổng có không
                            For j = 0 To mv_arrObjAccounts.Length - 1 Step 1
                                If Len(mv_arrObjAccounts(j).SUBTXNO) > 0 And Len(mv_arrObjAccounts(j).DORC) > 0 And Len(mv_arrObjAccounts(j).ACCTNO) > 7 And mv_arrObjAccounts(j).AMOUNT > 0 Then
                                    If mv_arrObjAccounts(j).SUBTXNO = v_strSUBTXNO And Mid(mv_arrObjAccounts(j).ACCTNO, POS_GLBANK, 1) <> "0" Then
                                        If mv_arrObjAccounts(j).DORC = "D" Then
                                            v_dblDrAmt = v_dblDrAmt + mv_arrObjAccounts(j).AMOUNT
                                        Else
                                            v_dblCrAmt = v_dblCrAmt + mv_arrObjAccounts(j).AMOUNT
                                        End If
                                    End If
                                End If
                            Next
                            If v_dblDrAmt <> v_dblCrAmt Then
                                MessageBox.Show("ERRCODE_GL_ACCTENTRY_DOESNOTBALANCE")
                                Return False
                            End If
                        Else
                            'Kiểm tra trong cùng một bút toán ngoại bảng không thể vừa ghi nợ vừa ghi có
                            For j = 0 To mv_arrObjAccounts.Length - 1 Step 1
                                If Len(mv_arrObjAccounts(j).SUBTXNO) > 0 And Len(mv_arrObjAccounts(j).DORC) > 0 And Len(mv_arrObjAccounts(j).ACCTNO) > 7 And mv_arrObjAccounts(j).AMOUNT > 0 Then
                                    If mv_arrObjAccounts(j).SUBTXNO = v_strSUBTXNO And Mid(mv_arrObjAccounts(j).ACCTNO, POS_GLBANK, 1) = "0" Then
                                        If mv_arrObjAccounts(j).DORC <> v_strDORC Then
                                            MessageBox.Show("ERRCODE_GL_ACCTENTRY_OFFBALANCESHEET")
                                            Return False
                                        End If
                                    End If
                                End If
                            Next
                        End If
                        'Kiểm tra trong cùng 01 bút toán không được phép có 02 loại tiền
                        For j = 0 To mv_arrObjAccounts.Length - 1 Step 1
                            If Len(mv_arrObjAccounts(j).SUBTXNO) > 0 And Len(mv_arrObjAccounts(j).DORC) > 0 And Len(mv_arrObjAccounts(j).ACCTNO) > 7 And mv_arrObjAccounts(j).AMOUNT > 0 Then
                                If mv_arrObjAccounts(j).SUBTXNO = v_strSUBTXNO And Mid(mv_arrObjAccounts(j).ACCTNO, POS_GLBANK, 1) = Mid(v_strACCTNO, POS_GLBANK, 1) = "0" Then
                                    If mv_arrObjAccounts(j).CCYCD <> v_strCCYCD Then
                                        MessageBox.Show("ERRCODE_GL_ACCTENTRY_NOTSAMECCYCD")
                                        Return False
                                    End If
                                End If
                            End If
                        Next
                    End If
                Next
            End If
            Return True
        Catch ex As Exception
            LogError.Write("Error source: AppCore.frmPostmap.CheckPostMapBeforeOK" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Return False
        End Try
    End Function

    Private Function CheckVATVoucherBeforeOK() As Boolean
        Try
            Dim v_decVATAMTIN, v_decVATAMTOUT As Decimal
            Dim v_decGLAMTIN, v_decGLAMTOUT As Decimal
            Dim v_strVATACCTNOIN, v_strVATACCTNOOUT As String

            v_decVATAMTIN = 0
            v_decVATAMTOUT = 0
            v_decGLAMTIN = 0
            v_decGLAMTOUT = 0

            'Get input and output VAT accounts from SYSVAR





            Return True
        Catch ex As Exception
            LogError.Write("Error source: AppCore.frmPostmap.CheckVATVoucherBeforeOK" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Return False
        End Try
    End Function

    Private Sub DoOk()
        Try
            getPostMapInfo()
            getVATVoucherInfo()
            If Not CheckPostMapBeforeOK() Then
                Exit Sub
            End If
            If Not CheckVATVoucherBeforeOK() Then
                Exit Sub
            End If
            Me.Close()
        Catch ex As Exception
            LogError.Write("Error source: AppCore.frmPostmap.DoOk" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub getPostMapInfo()
        Try
            'Lấy lại thông tin định khoản
            Dim v_dtgPostmap As GridEx, v_intIndex As Integer, v_objAccount As CAccountEntry, v_objMIAccount As CIEFMISEntry
            v_dtgPostmap = CType(Me.pnAcctEntry.Controls(0), GridEx)
            Dim v_xDataRow As Xceed.Grid.DataRow
            v_intIndex = 0
            'Lấy ra số dòng thoả mãn
            For Each v_xDataRow In v_dtgPostmap.DataRows
                'Bút toán kế toán
                v_objAccount = New CAccountEntry
                If Len(v_xDataRow.Cells("ACCTNO").Value) > 0 And (Len(v_xDataRow.Cells("DAMOUNT").Value) > 0 Or Len(v_xDataRow.Cells("CAMOUNT").Value) > 0) And Len(v_xDataRow.Cells("SUBTXNO").Value) > 0 Then
                    v_intIndex = v_intIndex + 1
                End If
            Next
            If v_intIndex = 0 Then
                Exit Sub
            End If
            ReDim mv_arrObjAccounts(v_intIndex - 1)
            ReDim mv_arrObjMISEntry(v_intIndex - 1)
            'Kiểm tra tính hợp lệ của bộ định khoản
            'Lấy dữ liệu
            v_intIndex = 0
            For Each v_xDataRow In v_dtgPostmap.DataRows
                'Bút toán kế toán
                v_objAccount = New CAccountEntry
                v_objMIAccount = New CIEFMISEntry

                If Len(v_xDataRow.Cells("ACCTNO").Value) > 0 And (Len(v_xDataRow.Cells("DAMOUNT").Value) > 0 Or Len(v_xDataRow.Cells("CAMOUNT").Value) > 0) And Len(v_xDataRow.Cells("SUBTXNO").Value) > 0 Then
                    With v_objAccount
                        .SUBTXNO = v_xDataRow.Cells("SUBTXNO").Value
                        .CCYCD = v_xDataRow.Cells("CCYCD").Value
                        If v_xDataRow.Cells("DAMOUNT").Value > v_xDataRow.Cells("CAMOUNT").Value Then
                            .DORC = "D"
                        Else
                            .DORC = "C"
                        End If
                        If .DORC = "D" Then
                            .AMOUNT = v_xDataRow.Cells("DAMOUNT").Value
                        Else
                            .AMOUNT = v_xDataRow.Cells("CAMOUNT").Value
                        End If
                        .ACCTNO = Strings.Replace(v_xDataRow.Cells("ACCTNO").Value, ".", String.Empty)
                    End With
                    With v_objMIAccount
                        .ACCTNO = v_xDataRow.Cells("ACCTNO").Value
                        .CUSTID = Strings.Replace(v_xDataRow.Cells("CUSTID").Value, ".", String.Empty)
                        .CUSTNAME = v_xDataRow.Cells("CUSTNAME").Value
                        .DEPTCD = v_xDataRow.Cells("DEPARTMENT").Value
                        .DESCRIPTION = v_xDataRow.Cells("DESC").Value
                        If v_xDataRow.Cells("DAMOUNT").Value > v_xDataRow.Cells("CAMOUNT").Value Then
                            .DORC = "D"
                        Else
                            .DORC = "C"
                        End If
                        '.DORC = v_xDataRow.Cells("DORC").Value
                        .MICD = v_xDataRow.Cells("FEEID").Value
                        .SUBTXNO = v_xDataRow.Cells("SUBTXNO").Value
                        .TASKCD = v_xDataRow.Cells("TASK").Value
                    End With
                    mv_arrObjAccounts(v_intIndex) = v_objAccount
                    mv_arrObjMISEntry(v_intIndex) = v_objMIAccount
                    v_intIndex = v_intIndex + 1
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub getVATVoucherInfo()
        Try
            'Lấy lại thông tin định khoản
            Dim v_dtgVATVoucher As GridEx, v_intIndex As Integer, v_objVATVoucher As CVATVoucher
            v_dtgVATVoucher = CType(Me.pnVATVoucher.Controls(0), GridEx)
            Dim v_xDataRow As Xceed.Grid.DataRow
            v_intIndex = 0
            'Lấy ra số dòng thoả mãn
            For Each v_xDataRow In v_dtgVATVoucher.DataRows
                'Bút toán kế toán
                v_objVATVoucher = New CVATVoucher
                If Len(v_xDataRow.Cells("CUSTID").Value) > 0 And Len(v_xDataRow.Cells("TAXCODE").Value) > 0 And v_xDataRow.Cells("QTTY").Value > 0 And v_xDataRow.Cells("PRICE").Value > 0 And v_xDataRow.Cells("VATRATE").Value > 0 Then
                    v_intIndex = v_intIndex + 1
                End If
            Next
            If v_intIndex = 0 Then
                Exit Sub
            End If
            ReDim mv_arrObjVATVoucher(v_intIndex - 1)
            'Kiểm tra tính hợp lệ của bộ định khoản
            'Lấy dữ liệu
            v_intIndex = 0
            For Each v_xDataRow In v_dtgVATVoucher.DataRows
                'Bút toán kế toán
                v_objVATVoucher = New CVATVoucher
                If Len(v_xDataRow.Cells("CUSTID").Value) > 0 And Len(v_xDataRow.Cells("TAXCODE").Value) > 0 And v_xDataRow.Cells("QTTY").Value > 0 And v_xDataRow.Cells("PRICE").Value > 0 And v_xDataRow.Cells("VATRATE").Value > 0 Then
                    With v_objVATVoucher
                        .VOUCHERNO = Strings.Replace(v_xDataRow.Cells("VOUCHERNO").Value, ".", String.Empty)
                        .VOUCHERTYPE = v_xDataRow.Cells("VOUCHERTYPE").Value
                        .SERIENO = v_xDataRow.Cells("SERIENO").Value
                        .VOUCHERDATE = Format(v_xDataRow.Cells("VOUCHERDATE").Value, gc_FORMAT_DATE)
                        .CUSTID = Strings.Replace(v_xDataRow.Cells("CUSTID").Value, ".", String.Empty)
                        .TAXCODE = v_xDataRow.Cells("TAXCODE").Value
                        .CUSTNAME = v_xDataRow.Cells("CUSTNAME").Value
                        .ADDRESS = v_xDataRow.Cells("ADDRESS").Value
                        .CONTENTS = v_xDataRow.Cells("CONTENTS").Value
                        .QTTY = v_xDataRow.Cells("QTTY").Value
                        .PRICE = v_xDataRow.Cells("PRICE").Value
                        .AMT = v_xDataRow.Cells("AMT").Value
                        .VATRATE = v_xDataRow.Cells("VATRATE").Value
                        .VATAMT = v_xDataRow.Cells("VATAMT").Value
                        .DESCRIPTION = v_xDataRow.Cells("DESCRIPTION").Value
                    End With
                    mv_arrObjVATVoucher(v_intIndex) = v_objVATVoucher
                    v_intIndex = v_intIndex + 1
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LoadResource(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control

        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is Label Then
                CType(v_ctrl, Label).Text = mv_ResourceManager.GetString("frmPostmap." & v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString("frmPostmap." & v_ctrl.Name)
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Button Then
                CType(v_ctrl, Button).Text = mv_ResourceManager.GetString("frmPostmap." & v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is RadioButton Then
                CType(v_ctrl, RadioButton).Text = mv_ResourceManager.GetString("frmPostmap." & v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is TabControl Then
                For Each v_ctrlTmp As Control In CType(v_ctrl, TabControl).TabPages
                    CType(v_ctrlTmp, TabPage).Text = mv_ResourceManager.GetString("frmPostmap." & v_ctrlTmp.Name)
                Next
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Panel Then
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is TabPage Then
                CType(v_ctrl, TabPage).Text = mv_ResourceManager.GetString("frmPostmap." & v_ctrl.Name)
                LoadResource(v_ctrl)
            End If
        Next

        Me.Text = mv_ResourceManager.GetString("frmPostmap")
    End Sub
#End Region

#Region " Form events "
    Private Sub frmPostmap_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitDialog()
    End Sub

    Private Sub frmPostmap_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        DoResizeForm()
    End Sub

    Private Sub frmPostmap_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Dim v_intPos As Int16, ctl As Control, strFLDNAME As String, v_intIndex As Integer
        Select Case e.KeyCode
            Case Keys.Escape
                DoClose()
            Case Keys.F5
            Case Keys.Enter
                If InStr(CType(Me.ActiveControl, Control).Name, "msk") > 0 _
                    Or InStr(CType(Me.ActiveControl, Control).Name, "rb") > 0 Then
                    'Nếu là các trường của giao dịch thì chuyển đến control kế tiếp
                    SendKeys.Send("{Tab}")
                    e.Handled = True
                Else
                End If
            Case Keys.F6
                Me.ActiveControl = v_dtgVATVoucher
        End Select
    End Sub

    Private Sub btnCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCANCEL.Click
        DoClose()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        DoOk()
    End Sub
#End Region

#Region " Grid POSTMAP events "
    Private Sub Grid_DORCDoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        If v_dtgPostmap.CurrentCell.Value = "D" Or v_dtgPostmap.CurrentCell.Value = "" Then
            v_dtgPostmap.CurrentCell.Value = "C"
        Else
            v_dtgPostmap.CurrentCell.Value = "D"
        End If
    End Sub

    Private Sub Grid_DORCKeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.C
                v_dtgPostmap.CurrentCell.Value = "C"
            Case Keys.D
                v_dtgPostmap.CurrentCell.Value = "D"
            Case Keys.Space
                If v_dtgPostmap.CurrentCell.Value = "D" Or v_dtgPostmap.CurrentCell.Value = "" Then
                    v_dtgPostmap.CurrentCell.Value = "C"
                Else
                    v_dtgPostmap.CurrentCell.Value = "D"
                End If
            Case Keys.Enter
                If v_dtgPostmap.CurrentCell.Value = "D" Or v_dtgPostmap.CurrentCell.Value = "" Then
                    v_dtgPostmap.CurrentCell.Value = "C"
                Else
                    v_dtgPostmap.CurrentCell.Value = "D"
                End If
            Case Else

        End Select

    End Sub

    Private Sub Grid_AMOUNTValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim v_bln As Boolean = False
        Dim i, j, v_intPos, v_IntIntdex As Integer
        For i = 0 To v_dtgPostmap.DataRows.Count - 1
            If v_dtgPostmap.DataRows(i) Is v_dtgPostmap.CurrentRow Then
                v_IntIntdex = i
                Exit For
            End If
        Next
        Select Case CType(sender, Xceed.Grid.DataCell).ParentColumn.FieldName
            Case "DAMOUNT"
                If Len(v_dtgPostmap.DataRows(v_IntIntdex).Cells("DAMOUNT").Value) = 0 Then
                    Exit Sub
                End If
                If v_dtgPostmap.DataRows(v_IntIntdex).Cells("DAMOUNT").Value > 0 Then
                    v_dtgPostmap.DataRows(v_IntIntdex).Cells("DORC").Value = "D"
                    v_dtgPostmap.DataRows(v_IntIntdex).Cells("CAMOUNT").Value = CDbl(0)
                    v_dtgPostmap.DataRows(v_IntIntdex).EndEdit()
                End If
            Case "CAMOUNT"
                If Len(v_dtgPostmap.DataRows(v_IntIntdex).Cells("CAMOUNT").Value) = 0 Then
                    Exit Sub
                End If
                If v_dtgPostmap.DataRows(v_IntIntdex).Cells("CAMOUNT").Value > 0 Then
                    v_dtgPostmap.DataRows(v_IntIntdex).Cells("DORC").Value = "C"
                    v_dtgPostmap.DataRows(v_IntIntdex).Cells("DAMOUNT").Value = CDbl(0)
                    v_dtgPostmap.DataRows(v_IntIntdex).EndEdit()
                End If
        End Select

    End Sub

    Private Sub Grid_DATACELLKeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim v_bln As Boolean = False
        Dim i, j, v_intPos, v_IntIntdex As Integer

        For i = 0 To v_dtgPostmap.DataRows.Count - 1
            If v_dtgPostmap.DataRows(i) Is v_dtgPostmap.CurrentRow Then
                v_IntIntdex = i
                Exit For
            End If
        Next

        Select Case e.KeyCode
            Case Keys.F5
                Select Case CType(sender, Xceed.Grid.DataCell).ParentColumn.FieldName
                    Case "ACCTNO"
                        'Hiển thị danh sách các tài khoản kế toán
                        Dim frm As New frmLookUp(UserLanguage)
                        frm.SQLCMD = "SELECT DISTINCT ACCTNO VALUE, SUBSTR(ACCTNO,7,5) || '.' || SUBSTR(ACCTNO,12,4) VALUECD, ACNAME DISPLAY, ACNAME EN_DISPLAY, ACNAME DESCRIPTION FROM GLMAST,SBCURRENCY WHERE GLMAST.CCYCD = SBCURRENCY.CCYCD ORDER BY ACCTNO "
                        frm.ShowDialog()
                        v_intPos = InStr(frm.RETURNDATA, vbTab)
                        If v_intPos > 0 Then
                            v_dtgPostmap.CurrentCell.Value = Mid(frm.RETURNDATA, 1, v_intPos - 1)
                            v_dtgPostmap.DataRows(v_IntIntdex).Cells("CCYCD").Value = Mid(frm.RETURNDATA, 5, 2)
                            v_dtgPostmap.DataRows(v_IntIntdex).Cells("ACCTNAME").Value = Mid(frm.RETURNDATA, v_intPos + 1)

                            'Chuyển đến ô kế tiếp
                            SendKeys.Send("{Right}")
                            SendKeys.Send("{Right}")
                            SendKeys.Send("{Right}")
                        End If
                        frm.Dispose()
                    Case "TASK"
                        'Hiển thị danh sách các vụ việc
                        Dim frm As New frmLookUp(UserLanguage)
                        frm.SQLCMD = "SELECT CDVAL VALUE, CDVAL VALUECD, CDCONTENT DISPLAY, CDCONTENT EN_DISPLAY, CDCONTENT DESCRIPTION FROM ALLCODE WHERE CDTYPE='SA' AND CDNAME='TASKCD' Order by LSTODR "
                        frm.ShowDialog()
                        v_intPos = InStr(frm.RETURNDATA, vbTab)
                        If v_intPos > 0 Then
                            v_dtgPostmap.CurrentCell.Value = Mid(frm.RETURNDATA, 1, v_intPos - 1)
                            'Chuyển đến ô kế tiếp
                            SendKeys.Send("{Right}")
                        End If
                        frm.Dispose()
                    Case "FEEID"
                        'Hiển thị danh sách các fee
                        Dim frm As New frmLookUp(UserLanguage)
                        frm.SQLCMD = "SELECT CDVAL VALUE, CDVAL VALUECD, CDCONTENT DISPLAY, CDCONTENT EN_DISPLAY, CDCONTENT DESCRIPTION FROM ALLCODE WHERE CDTYPE='SA' AND CDNAME='IECD' Order by LSTODR "
                        frm.ShowDialog()
                        v_intPos = InStr(frm.RETURNDATA, vbTab)
                        If v_intPos > 0 Then
                            v_dtgPostmap.CurrentCell.Value = Mid(frm.RETURNDATA, 1, v_intPos - 1)
                            'Chuyển đến ô kế tiếp
                            SendKeys.Send("{Right}")
                        End If
                        frm.Dispose()
                    Case "DEPARTMENT"
                        'Hiển thị danh sách các bộ phận
                        Dim frm As New frmLookUp(UserLanguage)
                        frm.SQLCMD = "SELECT CDVAL VALUE, CDVAL VALUECD, CDCONTENT DISPLAY, CDCONTENT EN_DISPLAY, CDCONTENT DESCRIPTION FROM ALLCODE WHERE CDTYPE='SA' AND CDNAME='DEPTCD' Order by LSTODR "
                        frm.ShowDialog()
                        v_intPos = InStr(frm.RETURNDATA, vbTab)
                        If v_intPos > 0 Then
                            v_dtgPostmap.CurrentCell.Value = Mid(frm.RETURNDATA, 1, v_intPos - 1)
                            'Chuyển đến ô kế tiếp
                            SendKeys.Send("{Right}")
                        End If
                        frm.Dispose()
                    Case "CUSTID"
                        'Hiển thị danh sách các khách hàng
                        'Tra cứu thông tin
                        Dim frm As New frmSearch(Me.UserLanguage)
                        frm.TableName = "CFMAST"
                        frm.ModuleCode = "CF"
                        frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                        frm.IsLocalSearch = gc_IsNotLocalMsg
                        frm.IsLookup = "Y"
                        frm.SearchOnInit = False
                        frm.BranchId = Me.BranchId
                        frm.TellerId = Me.TellerId
                        frm.ShowDialog()

                        If (Not frm.ReturnValue Is Nothing) Then
                            v_dtgPostmap.CurrentCell.Value = frm.ReturnValue

                            Dim v_nodeList As Xml.XmlNodeList
                            Dim v_xmlDocument As New Xml.XmlDocument
                            Dim v_strValue, v_strFLDNAME, v_strTEXT As String
                            Dim v_strObjMsg, v_strFULLNAME, v_strADDRESS, v_strTAXCODE, v_strCUSTID As String

                            v_strFULLNAME = ""
                            v_strCUSTID = ""

                            'Lấy thông tin về khách hàng
                            v_xmlDocument.LoadXml(frm.FULLDATA)
                            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                            If v_nodeList.Count < 1 Then
                                Exit Sub
                            End If

                            For i = 0 To v_nodeList.Count - 1
                                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                                    With v_nodeList.Item(i).ChildNodes(j)
                                        v_strValue = Trim(.InnerText.ToString)
                                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                        Select Case Trim(v_strFLDNAME)
                                            Case "FULLNAME"
                                                v_strFULLNAME = v_strValue
                                            Case "CUSTID"
                                                v_strCUSTID = v_strValue
                                        End Select
                                    End With
                                Next
                                If v_strCUSTID = frm.ReturnValue Then
                                    v_dtgPostmap.DataRows(v_IntIntdex).Cells("CUSTNAME").Value = v_strFULLNAME
                                    'Chuyển đến ô kế tiếp
                                    SendKeys.Send("{Right}")
                                    SendKeys.Send("{Right}")
                                    Exit For
                                End If
                            Next
                        End If

                        'Nạp các giá trị tương ứng cho các trường khác
                        frm.Dispose()
                End Select
            Case Keys.Enter

        End Select

    End Sub

    Private Sub Grid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.Delete
                'Xoá dòng hiện tại
                If v_dtgPostmap.DataRows.Count > 1 Then
                    v_dtgPostmap.DataRows.Remove(v_dtgPostmap.CurrentRow)
                End If
        End Select
    End Sub

    Private Sub GridPOSTMAP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.Enter
                If (v_dtgPostmap.CurrentColumn.Index = v_dtgPostmap.Columns.Count - 1) Then
                    If (v_dtgPostmap.DataRows.IndexOf(v_dtgPostmap.CurrentRow) = v_dtgPostmap.DataRows.Count - 1) Then
                        'Create new row
                        Dim v_xDataRow As Xceed.Grid.DataRow = v_dtgPostmap.DataRows.AddNew()
                        v_xDataRow.Cells("DAMOUNT").Value = CDbl(0)
                        v_xDataRow.Cells("CAMOUNT").Value = CDbl(0)
                        v_xDataRow.Cells("TASK").Value = "MIS"
                        v_xDataRow.Cells("FEEID").Value = "MIS"
                        v_xDataRow.Cells("DEPARTMENT").Value = "MIS"
                        v_xDataRow.EndEdit()

                        'Move cursor to the beginning of new row
                        v_dtgPostmap.CurrentRow = v_dtgPostmap.DataRows.Item(v_dtgPostmap.DataRows.Count - 1)
                        v_dtgPostmap.SelectedRows.Clear()
                        v_dtgPostmap.SelectedRows.Add(v_dtgPostmap.CurrentRow)
                        v_dtgPostmap.CurrentColumn = v_dtgPostmap.Columns("SUBTXNO")
                        For i As Integer = 0 To 20
                            v_dtgPostmap.Scroll(Xceed.Grid.ScrollDirection.Left)
                        Next i
                    Else
                        'Move cursor to the beginning of next row
                        v_dtgPostmap.CurrentRow = v_dtgPostmap.DataRows.Item(v_dtgPostmap.DataRows.IndexOf(v_dtgPostmap.CurrentRow) + 1)
                        v_dtgPostmap.SelectedRows.Clear()
                        v_dtgPostmap.SelectedRows.Add(v_dtgPostmap.CurrentRow)
                        v_dtgPostmap.CurrentColumn = v_dtgPostmap.Columns("SUBTXNO")
                        For i As Integer = 0 To 20
                            v_dtgPostmap.Scroll(Xceed.Grid.ScrollDirection.Left)
                        Next i
                    End If
                Else
                    SendKeys.Send("{Right}")
                    SendKeys.Flush()
                End If
        End Select
    End Sub

    Private Sub Grid_DATACELLLeavingEdit(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim v_bln As Boolean = False
            Dim i, j, v_IntIntdex As Integer
            Dim strFLDNAME As String, v_intIndex As Integer
            Dim v_strSQLCMD, v_strFULLDATA As String
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strDataType, v_strValue, v_strDisplay, v_strFLDNAME As String
            Dim v_strFieldValue, v_strDay, v_strMonth, v_strYear As String
            Dim v_strModule, v_strFldSource, v_strFldDesc As String
            Dim v_bolCheck As Boolean = False

            Select Case CType(sender, Xceed.Grid.DataCell).ParentColumn.FieldName
                Case "ACCTNO"
                    'Lấy ra số hiệu dòng hiện tại
                    For i = 0 To v_dtgPostmap.DataRows.Count - 1
                        If v_dtgPostmap.DataRows(i) Is CType(sender, Xceed.Grid.DataCell).ParentRow Then
                            v_IntIntdex = i
                            Exit For
                        End If
                    Next
                    If Len(v_dtgPostmap.DataRows(v_IntIntdex).Cells("ACCTNO").Value) = 0 Then
                        Exit Sub
                    End If
                    Dim v_strAcctno As String = v_dtgPostmap.DataRows(v_IntIntdex).Cells("ACCTNO").Value
                    v_strSQLCMD = "SELECT DISTINCT ACCTNO VALUE, GLMAST.CCYCD||':'||SBCURRENCY.shortcd||'-'||ACNAME DISPLAY, GLMAST.CCYCD||':'||SBCURRENCY.shortcd||'-'||ACNAME EN_DISPLAY FROM GLMAST,SBCURRENCY WHERE GLMAST.CCYCD=SBCURRENCY.CCYCD AND GLMAST.ACCTNO='" & v_strAcctno & "'  ORDER BY ACCTNO"
                    'Create message to inquiry object fields
                    Dim v_strObjMsg As String
                    Dim v_xmlDocument As New Xml.XmlDocument
                    Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                    'Lấy thông tin chung về giao dịch
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQLCMD, "")
                    v_ws.Message(v_strObjMsg)
                    'Lưu trữ danh sách tìm kiếm trả về
                    v_strFULLDATA = v_strObjMsg
                    v_xmlDocument.LoadXml(v_strObjMsg)
                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                    'Kiểm tra xem giá trị co hợp lệ không
                    For i = 0 To v_nodeList.Count - 1
                        For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                            With v_nodeList.Item(i).ChildNodes(j)
                                If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "VALUE" Then
                                    v_strValue = Trim(.InnerText.ToString)
                                    If Trim(v_dtgPostmap.DataRows(v_IntIntdex).Cells("ACCTNO").Value) = v_strValue Then
                                        For k As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                                            With v_nodeList.Item(i).ChildNodes(k)
                                                If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "DISPLAY" Then
                                                    v_strDisplay = Trim(.InnerText.ToString)
                                                End If
                                            End With
                                        Next
                                        Dim ctl As Control
                                        v_dtgPostmap.DataRows(v_IntIntdex).Cells("CCYCD").Value = Mid(v_strDisplay, 1, 2)
                                        v_dtgPostmap.DataRows(v_IntIntdex).Cells("ACCTNAME").Value = Mid(v_strDisplay, 8)
                                        v_bolCheck = True
                                        Exit For
                                    End If
                                End If
                            End With
                        Next
                        If v_bolCheck = True Then
                            Exit For
                        End If
                    Next
                    If v_bolCheck = True Then
                        'Giá trị nhập vào chính xác
                    Else
                        'Thông báo lỗi
                        MessageBox.Show("Invalid Account!")
                        v_dtgPostmap.DataRows(v_IntIntdex).Cells("CCYCD").Value = ""
                        v_dtgPostmap.DataRows(v_IntIntdex).Cells("ACCTNAME").Value = ""
                        v_dtgPostmap.DataRows(v_IntIntdex).Cells("ACCTNO").Value = ""
                        Exit Sub
                    End If
                Case "CUSTID"   'Added by MinhTK, 31-Jan-2007: Cho phep NSD go dung ma khach hang trong man hinh POSTMAP
                    'Lay thong tin trong cell CUSTID
                    v_IntIntdex = v_dtgPostmap.DataRows.IndexOf(v_dtgPostmap.CurrentRow)
                    Dim v_strCustId As String = v_dtgPostmap.DataRows(v_IntIntdex).Cells("CUSTID").Value.ToString().Trim()

                    If (v_strCustId.Length > 0) Then
                        'Loai bo dau "." trong chuoi tra ve
                        v_strCustId = v_strCustId.Replace(".", "")

                        'Build SQL statement and check on HOST side for this customer id information
                        v_strSQLCMD = "SELECT CUSTID, FULLNAME FROM CFMAST WHERE CUSTID = '" & v_strCustId & "' " _
                            & "AND STATUS = 'A'"

                        Dim v_strObjMsg As String
                        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                        Dim v_xmlDocument As New Xml.XmlDocument

                        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strSQLCMD, "")
                        v_ws.Message(v_strObjMsg)

                        v_xmlDocument.LoadXml(v_strObjMsg)
                        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                        If (v_nodeList.Count = 1) Then      'Thong tin khach hang da ton tai trong he thong va hop le
                            v_dtgPostmap.DataRows(v_IntIntdex).Cells("CUSTID").Value = v_nodeList.Item(0).ChildNodes(0).InnerText.ToString().Trim()
                            v_dtgPostmap.DataRows(v_IntIntdex).Cells("CUSTNAME").Value = v_nodeList.Item(0).ChildNodes(1).InnerText.ToString().Trim()
                        Else
                            MessageBox.Show(mv_ResourceManager.GetString("CUSTID_INVALID"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    End If
                Case "TASK"
                    'Lấy ra số hiệu dòng hiện tại
                    For i = 0 To v_dtgPostmap.DataRows.Count - 1
                        If v_dtgPostmap.DataRows(i) Is CType(sender, Xceed.Grid.DataCell).ParentRow Then
                            v_IntIntdex = i
                            Exit For
                        End If
                    Next
                    Dim v_strTASK As String = v_dtgPostmap.DataRows(v_IntIntdex).Cells("TASK").Value
                    If Len(v_strTASK) = 0 Then
                        Exit Sub
                    End If
                    v_strSQLCMD = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, CDCONTENT EN_DISPLAY FROM ALLCODE WHERE CDTYPE='SA' AND CDNAME='TASKCD' AND CDVAL='" & v_strTASK & "' Order by LSTODR "
                    'Create message to inquiry object fields
                    Dim v_strObjMsg As String
                    Dim v_xmlDocument As New Xml.XmlDocument
                    Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                    'Lấy thông tin chung về giao dịch
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQLCMD, "")
                    v_ws.Message(v_strObjMsg)
                    'Lưu trữ danh sách tìm kiếm trả về
                    v_strFULLDATA = v_strObjMsg
                    v_xmlDocument.LoadXml(v_strObjMsg)
                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                    'Kiểm tra xem giá trị co hợp lệ không
                    For i = 0 To v_nodeList.Count - 1
                        For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                            With v_nodeList.Item(i).ChildNodes(j)
                                If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "VALUE" Then
                                    v_strValue = Trim(.InnerText.ToString)
                                    If Trim(v_dtgPostmap.DataRows(v_IntIntdex).Cells("TASK").Value) = v_strValue Then
                                        For k As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                                            With v_nodeList.Item(i).ChildNodes(k)
                                                If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "DISPLAY" Then
                                                    v_strDisplay = Trim(.InnerText.ToString)
                                                End If
                                            End With
                                        Next
                                        v_bolCheck = True
                                        Exit For
                                    End If
                                End If
                            End With
                        Next
                        If v_bolCheck = True Then
                            Exit For
                        End If
                    Next
                    If v_bolCheck = True Then
                        'Giá trị nhập vào chính xác
                    Else
                        'Thông báo lỗi
                        MessageBox.Show("Invalid task code!")
                        v_dtgPostmap.DataRows(v_IntIntdex).Cells("TASK").Value = ""
                        Exit Sub
                    End If
                Case "FEEID"
                    'Lấy ra số hiệu dòng hiện tại
                    For i = 0 To v_dtgPostmap.DataRows.Count - 1
                        If v_dtgPostmap.DataRows(i) Is CType(sender, Xceed.Grid.DataCell).ParentRow Then
                            v_IntIntdex = i
                            Exit For
                        End If
                    Next
                    Dim v_strFEEID As String = v_dtgPostmap.DataRows(v_IntIntdex).Cells("FEEID").Value
                    If Len(v_dtgPostmap.DataRows(v_IntIntdex).Cells("FEEID").Value) = 0 Then
                        Exit Sub
                    End If
                    v_strSQLCMD = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, CDCONTENT EN_DISPLAY FROM ALLCODE WHERE CDTYPE='SA' AND CDNAME='IECD' AND CDVAL='" & v_strFEEID & "' Order by LSTODR "
                    'Create message to inquiry object fields
                    Dim v_strObjMsg As String
                    Dim v_xmlDocument As New Xml.XmlDocument
                    Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                    'Lấy thông tin chung về giao dịch
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQLCMD, "")
                    v_ws.Message(v_strObjMsg)
                    'Lưu trữ danh sách tìm kiếm trả về
                    v_strFULLDATA = v_strObjMsg
                    v_xmlDocument.LoadXml(v_strObjMsg)
                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                    'Kiểm tra xem giá trị co hợp lệ không
                    For i = 0 To v_nodeList.Count - 1
                        For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                            With v_nodeList.Item(i).ChildNodes(j)
                                If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "VALUE" Then
                                    v_strValue = Trim(.InnerText.ToString)
                                    If Trim(v_dtgPostmap.DataRows(v_IntIntdex).Cells("FEEID").Value) = v_strValue Then
                                        For k As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                                            With v_nodeList.Item(i).ChildNodes(k)
                                                If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "DISPLAY" Then
                                                    v_strDisplay = Trim(.InnerText.ToString)
                                                End If
                                            End With
                                        Next
                                        v_bolCheck = True
                                        Exit For
                                    End If
                                End If
                            End With
                        Next
                        If v_bolCheck = True Then
                            Exit For
                        End If
                    Next
                    If v_bolCheck = True Then
                        'Giá trị nhập vào chính xác
                    Else
                        'Thông báo lỗi
                        MessageBox.Show("Invalid task code!")
                        v_dtgPostmap.DataRows(v_IntIntdex).Cells("FEEID").Value = ""
                        Exit Sub
                    End If
                Case "DEPARTMENT"
                    'Lấy ra số hiệu dòng hiện tại
                    For i = 0 To v_dtgPostmap.DataRows.Count - 1
                        If v_dtgPostmap.DataRows(i) Is CType(sender, Xceed.Grid.DataCell).ParentRow Then
                            v_IntIntdex = i
                            Exit For
                        End If
                    Next
                    Dim v_strDEPARTMENT As String = v_dtgPostmap.DataRows(v_IntIntdex).Cells("DEPARTMENT").Value
                    If Len(v_dtgPostmap.DataRows(v_IntIntdex).Cells("DEPARTMENT").Value) = 0 Then
                        Exit Sub
                    End If
                    v_strSQLCMD = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, CDCONTENT EN_DISPLAY FROM ALLCODE WHERE CDTYPE='SA' AND CDNAME='DEPTCD' AND CDVAL='" & v_strDEPARTMENT & "' Order by LSTODR "
                    'Create message to inquiry object fields
                    Dim v_strObjMsg As String
                    Dim v_xmlDocument As New Xml.XmlDocument
                    Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                    'Lấy thông tin chung về giao dịch
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQLCMD, "")
                    v_ws.Message(v_strObjMsg)
                    'Lưu trữ danh sách tìm kiếm trả về
                    v_strFULLDATA = v_strObjMsg
                    v_xmlDocument.LoadXml(v_strObjMsg)
                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                    'Kiểm tra xem giá trị co hợp lệ không
                    For i = 0 To v_nodeList.Count - 1
                        For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                            With v_nodeList.Item(i).ChildNodes(j)
                                If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "VALUE" Then
                                    v_strValue = Trim(.InnerText.ToString)
                                    If Trim(v_dtgPostmap.DataRows(v_IntIntdex).Cells("DEPARTMENT").Value) = v_strValue Then
                                        For k As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                                            With v_nodeList.Item(i).ChildNodes(k)
                                                If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "DISPLAY" Then
                                                    v_strDisplay = Trim(.InnerText.ToString)
                                                End If
                                            End With
                                        Next
                                        v_bolCheck = True
                                        Exit For
                                    End If
                                End If
                            End With
                        Next
                        If v_bolCheck = True Then
                            Exit For
                        End If
                    Next
                    If v_bolCheck = True Then
                        'Giá trị nhập vào chính xác
                    Else
                        'Thông báo lỗi
                        MessageBox.Show("Invalid task code!")
                        v_dtgPostmap.DataRows(v_IntIntdex).Cells("DEPARTMENT").Value = ""
                        Exit Sub
                    End If
            End Select
        Catch ex As Exception
            LogError.Write("Error source: AppCore.frmPostmap.Grid_DATACELLLeavingEdit" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub

#End Region

#Region " Grid VATVOUCHER events "
    Private Sub GridVAT_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Dim v_intColumnIdx, v_intPos As Integer

            Select Case e.KeyCode
                Case Keys.Delete
                    'Xoá dòng hiện tại
                    If v_dtgVATVoucher.DataRows.Count > 1 Then
                        v_dtgVATVoucher.DataRows.Remove(v_dtgVATVoucher.CurrentRow)
                    End If
                Case Keys.F5
                    'Lấy index của column hiện tại
                    v_intColumnIdx = v_dtgVATVoucher.Columns.IndexOf(v_dtgVATVoucher.CurrentColumn)

                    'Hiển thị form lookup tương ứng đối với từng ô dữ liệu
                    With v_dtgVATVoucher
                        Select Case v_intColumnIdx
                            Case .Columns.IndexOf(.Columns("VOUCHERTYPE"))
                                'Hiển thị danh sách các loại chứng từ
                                Dim frm As New frmLookUp(UserLanguage)
                                frm.SQLCMD = "SELECT CDVAL VALUE, CDVAL VALUECD, CDCONTENT DISPLAY, CDCONTENT EN_DISPLAY, CDCONTENT DESCRIPTION FROM ALLCODE WHERE CDTYPE='GL' AND CDNAME='VOUCHERTYPE' Order by LSTODR "
                                frm.ShowDialog()
                                v_intPos = InStr(frm.RETURNDATA, vbTab)
                                If v_intPos > 0 Then
                                    .CurrentCell.Value = Mid(frm.RETURNDATA, 1, v_intPos - 1)
                                End If
                                frm.Dispose()
                            Case .Columns.IndexOf(.Columns("CUSTID"))
                                'Hiển thị danh sách các khách hàng
                                'Tra cứu thông tin
                                Dim frm As New frmSearch(Me.UserLanguage)
                                frm.TableName = "CFMAST"
                                frm.ModuleCode = "CF"
                                frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                                frm.IsLocalSearch = gc_IsNotLocalMsg
                                frm.IsLookup = "Y"
                                frm.SearchOnInit = False
                                frm.BranchId = Me.BranchId
                                frm.TellerId = Me.TellerId
                                frm.ShowDialog()

                                If Not (frm.ReturnValue Is Nothing) Then
                                    .CurrentCell.Value = frm.ReturnValue

                                    Dim v_nodeList As Xml.XmlNodeList
                                    Dim v_xmlDocument As New Xml.XmlDocument
                                    Dim v_strValue, v_strFLDNAME, v_strTEXT As String
                                    Dim v_strObjMsg, v_strFULLNAME, v_strADDRESS, v_strTAXCODE, v_strCUSTID As String

                                    v_strFULLNAME = String.Empty
                                    v_strADDRESS = String.Empty
                                    v_strTAXCODE = String.Empty
                                    v_strCUSTID = String.Empty

                                    'Lấy thông tin về khách hàng
                                    v_xmlDocument.LoadXml(frm.FULLDATA)
                                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                                    If v_nodeList.Count < 1 Then
                                        Exit Sub
                                    End If
                                    For i As Integer = 0 To v_nodeList.Count - 1
                                        For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                                            With v_nodeList.Item(i).ChildNodes(j)
                                                v_strValue = Trim(.InnerText.ToString)
                                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                                Select Case Trim(v_strFLDNAME)
                                                    Case "FULLNAME"
                                                        v_strFULLNAME = v_strValue
                                                    Case "ADDRESS"
                                                        v_strADDRESS = v_strValue
                                                    Case "TAXCODE"
                                                        v_strTAXCODE = v_strValue
                                                    Case "CUSTID"
                                                        v_strCUSTID = v_strValue
                                                End Select
                                            End With
                                        Next
                                        If v_strCUSTID = frm.ReturnValue Then
                                            .DataRows(.DataRows.IndexOf(.CurrentRow)).Cells("TAXCODE").Value = v_strTAXCODE
                                            .DataRows(.DataRows.IndexOf(.CurrentRow)).Cells("CUSTNAME").Value = v_strFULLNAME
                                            .DataRows(.DataRows.IndexOf(.CurrentRow)).Cells("ADDRESS").Value = v_strADDRESS
                                            Exit For
                                        End If
                                    Next
                                End If
                                'Nạp các giá trị tương ứng cho các trường khác
                                frm.Dispose()
                        End Select
                    End With

            End Select
        Catch ex As Exception
            LogError.Write("Error source: AppCore.frmPostmap.GridVAT_KeyUp" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub

    Private Sub GridVAT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.Enter
                If (v_dtgVATVoucher.CurrentColumn.Index = v_dtgVATVoucher.Columns.Count - 1) Then
                    If (v_dtgVATVoucher.DataRows.IndexOf(v_dtgVATVoucher.CurrentRow) = v_dtgVATVoucher.DataRows.Count - 1) Then
                        'Create new row
                        Dim v_dtRow As New Xceed.Grid.DataRow
                        v_dtRow = v_dtgVATVoucher.DataRows.AddNew()
                        v_dtRow.Cells("VOUCHERDATE").Value = BusDate
                        v_dtRow.EndEdit()

                        'Move cursor to the beginning of new row
                        v_dtgVATVoucher.CurrentRow = v_dtgVATVoucher.DataRows.Item(v_dtgVATVoucher.DataRows.Count - 1)
                        v_dtgVATVoucher.SelectedRows.Clear()
                        v_dtgVATVoucher.SelectedRows.Add(v_dtgVATVoucher.CurrentRow)
                        v_dtgVATVoucher.CurrentColumn = v_dtgVATVoucher.Columns("VOUCHERNO")
                        For i As Integer = 0 To 20
                            v_dtgVATVoucher.Scroll(Xceed.Grid.ScrollDirection.Left)
                        Next i
                    Else
                        'Move cursor to the beginning of next row
                        v_dtgVATVoucher.CurrentRow = v_dtgVATVoucher.DataRows.Item(v_dtgVATVoucher.DataRows.IndexOf(v_dtgVATVoucher.CurrentRow) + 1)
                        v_dtgVATVoucher.SelectedRows.Clear()
                        v_dtgVATVoucher.SelectedRows.Add(v_dtgVATVoucher.CurrentRow)
                        v_dtgVATVoucher.CurrentColumn = v_dtgVATVoucher.Columns("VOUCHERNO")
                        For i As Integer = 0 To 20
                            v_dtgVATVoucher.Scroll(Xceed.Grid.ScrollDirection.Left)
                        Next i
                    End If
                Else
                    SendKeys.Send("{Right}")
                    SendKeys.Flush()
                End If
        End Select
    End Sub

    Private Sub GridVAT_DataCellLeavingEdit(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim v_intColumnIdx As Integer
            Dim v_strSQL As String
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strCellValue As String

            With v_dtgVATVoucher
                'Get the index of current column
                v_intColumnIdx = .Columns.IndexOf(.CurrentColumn)

                'Check whether data is valid or not depending data column
                Select Case v_intColumnIdx
                    Case .Columns.IndexOf(.Columns("VOUCHERTYPE"))
                        Dim v_strVoucherType As String = .DataRows(.DataRows.IndexOf(.CurrentRow)).Cells(v_intColumnIdx).Value.ToString().Trim()

                        If (v_strVoucherType.Length > 0) Then
                            'Build SQL statement
                            v_strSQL = "SELECT CDVAL, CDCONTENT FROM ALLCODE WHERE CDTYPE = 'GL' AND CDNAME = 'VOUCHERTYPE' AND CDVAL = '" & v_strVoucherType & "'"

                            Dim v_strObjMsg As String
                            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                            Dim v_xmlDocument As New Xml.XmlDocument

                            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL, "")
                            v_ws.Message(v_strObjMsg)

                            v_xmlDocument.LoadXml(v_strObjMsg)
                            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                            If (v_nodeList.Count = 1) Then
                                .DataRows(.DataRows.IndexOf(.CurrentRow)).Cells(v_intColumnIdx).Value = v_nodeList.Item(0).ChildNodes(0).InnerText.ToString().Trim()
                            Else
                                MessageBox.Show(mv_ResourceManager.GetString("VOUCHERTYPE_INVALID"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Exit Sub
                            End If
                        End If
                    Case .Columns.IndexOf(.Columns("VOUCHERDATE"))
                        Dim v_strVoucherDate As String = .DataRows(.DataRows.IndexOf(.CurrentRow)).Cells(v_intColumnIdx).Value.ToString().Trim()

                        If (v_strVoucherDate.Length = 10) Then
                            If IsDateValue(v_strVoucherDate) Then
                                .DataRows(.DataRows.IndexOf(.CurrentRow)).Cells(v_intColumnIdx).Value = v_strVoucherDate
                            Else
                                MessageBox.Show(mv_ResourceManager.GetString("VOUCHERDATE_INVALID"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Exit Sub
                            End If
                        ElseIf (v_strVoucherDate.Length > 0) Then
                            MessageBox.Show(mv_ResourceManager.GetString("VOUCHERDATE_INVALID"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    Case .Columns.IndexOf(.Columns("CUSTID"))
                        'Lay thong tin trong cell CUSTID
                        Dim v_strCustId As String = .DataRows(.DataRows.IndexOf(.CurrentRow)).Cells(v_intColumnIdx).Value.ToString().Trim()

                        If (v_strCustId.Length > 0) Then
                            'Loai bo dau "." trong chuoi tra ve
                            v_strCustId = v_strCustId.Replace(".", "")

                            'Build SQL statement and check on HOST side for this customer id information
                            v_strSQL = "SELECT CUSTID, FULLNAME, TAXCODE FROM CFMAST WHERE CUSTID = '" & v_strCustId & "' " _
                                & "AND STATUS = 'A'"

                            Dim v_strObjMsg As String
                            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                            Dim v_xmlDocument As New Xml.XmlDocument

                            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strSQL, "")
                            v_ws.Message(v_strObjMsg)

                            v_xmlDocument.LoadXml(v_strObjMsg)
                            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                            If (v_nodeList.Count = 1) Then      'Thong tin khach hang da ton tai trong he thong va hop le
                                .DataRows(.DataRows.IndexOf(.CurrentRow)).Cells("CUSTID").Value = v_nodeList.Item(0).ChildNodes(0).InnerText.ToString().Trim()
                                .DataRows(.DataRows.IndexOf(.CurrentRow)).Cells("CUSTNAME").Value = v_nodeList.Item(0).ChildNodes(1).InnerText.ToString().Trim()
                                .DataRows(.DataRows.IndexOf(.CurrentRow)).Cells("TAXCODE").Value = v_nodeList.Item(0).ChildNodes(2).InnerText.ToString().Trim()
                            Else
                                MessageBox.Show(mv_ResourceManager.GetString("CUSTID_INVALID"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Exit Sub
                            End If
                        End If
                    Case .Columns.IndexOf(.Columns("QTTY"))
                        Dim v_dblQtty, v_dblPrice As Double

                        v_strCellValue = .DataRows(.DataRows.IndexOf(.CurrentRow)).Cells(v_intColumnIdx).Value.ToString().Trim()
                        If (v_strCellValue.Length > 0) Then
                            If (IsNumeric(v_strCellValue)) Then
                                v_dblQtty = CDbl(v_strCellValue)
                                v_strCellValue = .DataRows(.DataRows.IndexOf(.CurrentRow)).Cells("PRICE").Value.ToString().Trim()
                                If (v_strCellValue.Length > 0) And (IsNumeric(v_strCellValue)) Then
                                    v_dblPrice = CDbl(v_strCellValue)
                                End If
                                .DataRows(.DataRows.IndexOf(.CurrentRow)).Cells("AMT").Value = v_dblQtty * v_dblPrice
                            Else
                                MessageBox.Show(mv_ResourceManager.GetString("QTTY_INVALID"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Exit Sub
                            End If
                        End If
                    Case .Columns.IndexOf(.Columns("PRICE"))
                        Dim v_dblQtty, v_dblPrice As Double

                        v_strCellValue = .DataRows(.DataRows.IndexOf(.CurrentRow)).Cells(v_intColumnIdx).Value.ToString().Trim()
                        If (v_strCellValue.Length > 0) Then
                            If (IsNumeric(v_strCellValue)) Then
                                v_dblPrice = CDbl(v_strCellValue)
                                v_strCellValue = .DataRows(.DataRows.IndexOf(.CurrentRow)).Cells("QTTY").Value.ToString().Trim()
                                If (v_strCellValue.Length > 0) And (IsNumeric(v_strCellValue)) Then
                                    v_dblQtty = CDbl(v_strCellValue)
                                End If
                                .DataRows(.DataRows.IndexOf(.CurrentRow)).Cells("AMT").Value = v_dblQtty * v_dblPrice
                            Else
                                MessageBox.Show(mv_ResourceManager.GetString("PRICE_INVALID"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Exit Sub
                            End If
                        End If
                    Case .Columns.IndexOf(.Columns("VATRATE"))
                        Dim v_dblVATRATE, v_dblAMT As Double

                        v_strCellValue = .DataRows(.DataRows.IndexOf(.CurrentRow)).Cells(v_intColumnIdx).Value.ToString().Trim()
                        If (v_strCellValue.Length > 0) Then
                            If (IsNumeric(v_strCellValue)) Then
                                v_dblVATRATE = CDbl(v_strCellValue)
                                v_strCellValue = .DataRows(.DataRows.IndexOf(.CurrentRow)).Cells("AMT").Value.ToString().Trim()
                                If (v_strCellValue.Length > 0) And (IsNumeric(v_strCellValue)) Then
                                    v_dblAMT = CDbl(v_strCellValue)
                                Else
                                    v_dblAMT = 0
                                End If
                                .DataRows(.DataRows.IndexOf(.CurrentRow)).Cells("VATAMT").Value = v_dblAMT * v_dblVATRATE / 100
                            Else
                                MessageBox.Show(mv_ResourceManager.GetString("VATRATE_INVALID"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                .DataRows(.DataRows.IndexOf(.CurrentRow)).Cells("VATAMT").Value = 0
                                Exit Sub
                            End If
                        Else
                            .DataRows(.DataRows.IndexOf(.CurrentRow)).Cells("VATAMT").Value = 0
                        End If
                End Select
            End With
        Catch ex As Exception
            LogError.Write("Error source: AppCore.frmPostmap.GridVAT_DataCellLeavingEdit" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub
#End Region

#Region " Grid FIXEDASSEST events "
    Private Sub Grid_CCYCDKeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Dim v_bln As Boolean = False
            Dim i, j, v_intPos, v_IntIntdex As Integer
            For i = 0 To v_dtgFA.DataRows.Count - 1
                If v_dtgFA.DataRows(i) Is v_dtgFA.CurrentRow Then
                    v_IntIntdex = i
                    Exit For
                End If
            Next
            Select Case e.KeyCode
                Case Keys.F5
                    'Hiển thị danh sách các loại tiền
                    Dim frm As New frmLookUp(UserLanguage)
                    frm.SQLCMD = "SELECT DISTINCT CCYCD VALUE, CCYNAME DISPLAY, CCYNAME EN_DISPLAY FROM SBCURRENCY ORDER BY CCYCD"
                    frm.ShowDialog()
                    v_intPos = InStr(frm.RETURNDATA, vbTab)
                    If v_intPos > 0 Then
                        v_dtgFA.CurrentCell.Value = Mid(frm.RETURNDATA, 1, v_intPos - 1)
                        'Chuyển đến ô kế tiếp
                        SendKeys.Send("{Right}")
                    End If
                    frm.Dispose()
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Grid_MIGROUPDoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        If v_dtgFA.CurrentCell.Value = "E" Or Len(Trim(v_dtgFA.CurrentCell.Value)) = 0 Then
            v_dtgFA.CurrentCell.Value = "F"
        ElseIf v_dtgFA.CurrentCell.Value = "F" Then
            v_dtgFA.CurrentCell.Value = "I"
        ElseIf v_dtgFA.CurrentCell.Value = "I" Then
            v_dtgFA.CurrentCell.Value = "E"
        End If
    End Sub

    Private Sub Grid_MIGROUPKeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F
                v_dtgFA.CurrentCell.Value = "F"
            Case Keys.I
                v_dtgFA.CurrentCell.Value = "I"
            Case Keys.E
                v_dtgFA.CurrentCell.Value = "E"
            Case Keys.Space
                If v_dtgFA.CurrentCell.Value = "E" Or Len(Trim(v_dtgFA.CurrentCell.Value)) = 0 Then
                    v_dtgFA.CurrentCell.Value = "F"
                ElseIf v_dtgFA.CurrentCell.Value = "F" Then
                    v_dtgFA.CurrentCell.Value = "I"
                ElseIf v_dtgFA.CurrentCell.Value = "I" Then
                    v_dtgFA.CurrentCell.Value = "E"
                End If
            Case Keys.Enter
                If v_dtgFA.CurrentCell.Value = "E" Or Len(Trim(v_dtgFA.CurrentCell.Value)) = 0 Then
                    v_dtgFA.CurrentCell.Value = "F"
                ElseIf v_dtgFA.CurrentCell.Value = "F" Then
                    v_dtgFA.CurrentCell.Value = "I"
                ElseIf v_dtgFA.CurrentCell.Value = "I" Then
                    v_dtgFA.CurrentCell.Value = "E"
                End If
            Case Else

        End Select
    End Sub

    Private Sub Grid_DEPTYPEDoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        If v_dtgFA.CurrentCell.Value = "P" Or Len(Trim(v_dtgFA.CurrentCell.Value)) = 0 Then
            v_dtgFA.CurrentCell.Value = "F"
        Else
            v_dtgFA.CurrentCell.Value = "P"
        End If
    End Sub

    Private Sub Grid_DEPTYPEKeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.F
                v_dtgFA.CurrentCell.Value = "F"
            Case Keys.P
                v_dtgFA.CurrentCell.Value = "P"
            Case Keys.Space
                If v_dtgFA.CurrentCell.Value = "P" Or Len(Trim(v_dtgFA.CurrentCell.Value)) = 0 Then
                    v_dtgFA.CurrentCell.Value = "F"
                Else
                    v_dtgFA.CurrentCell.Value = "P"
                End If
            Case Keys.Enter
                If v_dtgFA.CurrentCell.Value = "P" Or Len(Trim(v_dtgFA.CurrentCell.Value)) = 0 Then
                    v_dtgFA.CurrentCell.Value = "F"
                Else
                    v_dtgFA.CurrentCell.Value = "P"
                End If
            Case Else

        End Select
    End Sub

    Private Sub Grid_CCYCDLeavingEdit(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim v_bln As Boolean = False
            Dim i, j, v_IntIntdex As Integer
            Dim strFLDNAME As String, v_intIndex As Integer
            Dim v_strSQLCMD, v_strFULLDATA As String
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strDataType, v_strValue, v_strDisplay, v_strFLDNAME As String
            Dim v_strFieldValue, v_strDay, v_strMonth, v_strYear As String
            Dim v_strModule, v_strFldSource, v_strFldDesc As String
            Dim v_bolCheck As Boolean = False
            'Lấy ra số hiệu dòng hiện tại
            For i = 0 To v_dtgFA.DataRows.Count - 1
                If v_dtgFA.DataRows(i) Is CType(sender, Xceed.Grid.DataCell).ParentRow Then
                    v_IntIntdex = i
                    Exit For
                End If
            Next
            If Len(v_dtgFA.DataRows(v_IntIntdex).Cells("CCYCD").Value) = 0 Then
                Exit Sub
            End If
            v_strSQLCMD = "SELECT DISTINCT CCYCD VALUE, CCYNAME DISPLAY, CCYNAME EN_DISPLAY FROM SBCURRENCY ORDER BY CCYCD "
            'Create message to inquiry object fields
            Dim v_strObjMsg As String
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
            'Lấy thông tin chung về giao dịch
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQLCMD, "")
            v_ws.Message(v_strObjMsg)
            'Lưu trữ danh sách tìm kiếm trả về
            v_strFULLDATA = v_strObjMsg
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            'Kiểm tra xem giá trị co hợp lệ không
            For i = 0 To v_nodeList.Count - 1
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "VALUE" Then
                            v_strValue = Trim(.InnerText.ToString)
                            If Trim(v_dtgFA.DataRows(v_IntIntdex).Cells("CCYCD").Value) = v_strValue Then
                                v_bolCheck = True
                                Exit For
                            End If
                        End If
                    End With
                Next
                If v_bolCheck = True Then
                    Exit For
                End If
            Next
            If v_bolCheck = True Then
                'Giá trị nhập vào chính xác
            Else
                'Thông báo lỗi
                MessageBox.Show("Invalid currency code !")
                v_dtgFA.DataRows(v_IntIntdex).Cells("CCYCD").Value = ""
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub GridFA_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Dim v_bln As Boolean = False
            Dim i, j As Integer
            Select Case e.KeyCode
                Case Keys.F4
                    'Xoá dòng hiện tại
                    If v_dtgFA.DataRows.Count > 2 Then
                        v_dtgFA.DataRows.Remove(v_dtgFA.CurrentRow)
                    End If
                Case Keys.F8
                    'Thêm một dòng mới
                    Dim v_dtRow As New Xceed.Grid.DataRow
                    v_dtgFA.DataRows.AddNew()
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region

End Class
