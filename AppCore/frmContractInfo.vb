Imports AppCore
Imports CommonLibrary
Imports System.Xml.XmlNode
Imports System.Xml
Imports TestBase64
Imports ZetaCompressionLibrary
Imports System.IO
Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports System.Collections

Public Class frmContractInfo
    Inherits System.Windows.Forms.Form

#Region " Declare constant and variables "
    Const c_ResourceManager = "AppCore.frmContractInfo-"
    Const WIDTH_GRID_LOOKUP = 550

    Private mv_strCaption As String
    Private mv_strLanguage As String
    Private mv_strAFACCTNO As String
    Private mv_strTLTXCD As String
    Private mv_strFULLNAME As String = String.Empty
    Private mv_strCONFIRMNAME As String = String.Empty
    Private mv_strCUSTID As String = String.Empty
    Private mv_ResourceManager As Resources.ResourceManager
    Public mv_blnBUYSELL As Boolean = False
    Private mv_strXmlMessageData As String
    Private mv_strLocalObject As String
    Private mv_strBranchId As String
    Private mv_strTellerId As String
    Private mv_strIpAddress As String
    Private mv_strWsName As String
    Private mv_strBusDate As String = String.Empty
    Private mv_strTxDate As String = String.Empty
    Private mv_strTxNum As String = String.Empty
    Private mv_strTellerType As String
    Public v_frmCFMAST As frmMaintenance  'frmCFMAST
    Public v_frmCFAUTH As frmMaintenance  'frmCFAUTH
    Public v_frmCFRELATION As frmMaintenance  'frmCFRELATION


    Friend WithEvents MemberGrid As New GridEx
    Friend WithEvents RelationGrid As New GridEx


    Private mv_intCurrImageIndex As Integer = 0
    Private mv_arrSIGNATURE As String()
    Private mv_arrAUTOID As String()
    Private mv_arrCUSTID As String()

    Public mv_retROLETYPE As String
    Public mv_retCUSTID As String
    Public mv_retCUSTNAME As String
    Public mv_retIDNUMBER As String
    Public mv_retIDDATE As String
    Public mv_retIDPLACE As String
    Friend WithEvents tbSign As System.Windows.Forms.TabControl
    Friend WithEvents tpSignAuth As System.Windows.Forms.TabPage
    Friend WithEvents tpSignRela As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlCFRELATION As System.Windows.Forms.Panel
    Friend WithEvents VScrollBar1 As System.Windows.Forms.VScrollBar
    Public mv_retADDRESS As String
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

    Public Property UserLanguage() As String
        Get
            Return mv_strLanguage
        End Get
        Set(ByVal Value As String)
            mv_strLanguage = Value
        End Set
    End Property

    Public Property CAPTION() As String
        Get
            Return mv_strCaption
        End Get
        Set(ByVal Value As String)
            mv_strCaption = Value
        End Set
    End Property

    Public Property AFACCTNO() As String
        Get
            Return mv_strAFACCTNO
        End Get
        Set(ByVal Value As String)
            mv_strAFACCTNO = Value
        End Set
    End Property

    Public Property TLTXCD() As String
        Get
            Return mv_strTLTXCD
        End Get
        Set(ByVal Value As String)
            mv_strTLTXCD = Value
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
    Friend WithEvents pnContractInfo As System.Windows.Forms.Panel
    Friend WithEvents pnlMember As System.Windows.Forms.Panel
    Friend WithEvents picSignature As System.Windows.Forms.PictureBox
    Friend WithEvents VScrollBarSign As System.Windows.Forms.VScrollBar
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCANCEL As System.Windows.Forms.Button
    Friend WithEvents lblAFINFO As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.pnContractInfo = New System.Windows.Forms.Panel
        Me.pnlMember = New System.Windows.Forms.Panel
        Me.picSignature = New System.Windows.Forms.PictureBox
        Me.VScrollBarSign = New System.Windows.Forms.VScrollBar
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCANCEL = New System.Windows.Forms.Button
        Me.lblAFINFO = New System.Windows.Forms.Label
        Me.tbSign = New System.Windows.Forms.TabControl
        Me.tpSignAuth = New System.Windows.Forms.TabPage
        Me.tpSignRela = New System.Windows.Forms.TabPage
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.pnlCFRELATION = New System.Windows.Forms.Panel
        Me.VScrollBar1 = New System.Windows.Forms.VScrollBar
        Me.pnContractInfo.SuspendLayout()
        CType(Me.picSignature, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbSign.SuspendLayout()
        Me.tpSignAuth.SuspendLayout()
        Me.tpSignRela.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnContractInfo
        '
        Me.pnContractInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnContractInfo.Controls.Add(Me.pnlMember)
        Me.pnContractInfo.Controls.Add(Me.picSignature)
        Me.pnContractInfo.Controls.Add(Me.VScrollBarSign)
        Me.pnContractInfo.Location = New System.Drawing.Point(6, 6)
        Me.pnContractInfo.Name = "pnContractInfo"
        Me.pnContractInfo.Size = New System.Drawing.Size(616, 130)
        Me.pnContractInfo.TabIndex = 4
        '
        'pnlMember
        '
        Me.pnlMember.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMember.Location = New System.Drawing.Point(8, 4)
        Me.pnlMember.Name = "pnlMember"
        Me.pnlMember.Size = New System.Drawing.Size(432, 120)
        Me.pnlMember.TabIndex = 8
        Me.pnlMember.Tag = "Member"
        '
        'picSignature
        '
        Me.picSignature.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picSignature.Location = New System.Drawing.Point(446, 3)
        Me.picSignature.Name = "picSignature"
        Me.picSignature.Size = New System.Drawing.Size(146, 120)
        Me.picSignature.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picSignature.TabIndex = 5
        Me.picSignature.TabStop = False
        Me.picSignature.Tag = "Signature"
        '
        'VScrollBarSign
        '
        Me.VScrollBarSign.LargeChange = 1
        Me.VScrollBarSign.Location = New System.Drawing.Point(592, 3)
        Me.VScrollBarSign.Name = "VScrollBarSign"
        Me.VScrollBarSign.Size = New System.Drawing.Size(17, 120)
        Me.VScrollBarSign.TabIndex = 6
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(418, 216)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(80, 23)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "btnOK"
        '
        'btnCANCEL
        '
        Me.btnCANCEL.Location = New System.Drawing.Point(506, 216)
        Me.btnCANCEL.Name = "btnCANCEL"
        Me.btnCANCEL.Size = New System.Drawing.Size(80, 23)
        Me.btnCANCEL.TabIndex = 6
        Me.btnCANCEL.Text = "btnCANCEL"
        '
        'lblAFINFO
        '
        Me.lblAFINFO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAFINFO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAFINFO.ForeColor = System.Drawing.Color.Black
        Me.lblAFINFO.Location = New System.Drawing.Point(8, 8)
        Me.lblAFINFO.Name = "lblAFINFO"
        Me.lblAFINFO.Size = New System.Drawing.Size(608, 20)
        Me.lblAFINFO.TabIndex = 7
        Me.lblAFINFO.Text = "lblAFINFO"
        '
        'tbSign
        '
        Me.tbSign.Controls.Add(Me.tpSignAuth)
        Me.tbSign.Controls.Add(Me.tpSignRela)
        Me.tbSign.Location = New System.Drawing.Point(10, 44)
        Me.tbSign.Name = "tbSign"
        Me.tbSign.SelectedIndex = 0
        Me.tbSign.Size = New System.Drawing.Size(629, 166)
        Me.tbSign.TabIndex = 8
        '
        'tpSignAuth
        '
        Me.tpSignAuth.Controls.Add(Me.pnContractInfo)
        Me.tpSignAuth.Location = New System.Drawing.Point(4, 22)
        Me.tpSignAuth.Name = "tpSignAuth"
        Me.tpSignAuth.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSignAuth.Size = New System.Drawing.Size(621, 140)
        Me.tpSignAuth.TabIndex = 0
        Me.tpSignAuth.Text = "Ủy quyền"
        Me.tpSignAuth.UseVisualStyleBackColor = True
        '
        'tpSignRela
        '
        Me.tpSignRela.Controls.Add(Me.Panel1)
        Me.tpSignRela.Location = New System.Drawing.Point(4, 22)
        Me.tpSignRela.Name = "tpSignRela"
        Me.tpSignRela.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSignRela.Size = New System.Drawing.Size(621, 140)
        Me.tpSignRela.TabIndex = 1
        Me.tpSignRela.Text = "Thành viên"
        Me.tpSignRela.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.pnlCFRELATION)
        Me.Panel1.Controls.Add(Me.VScrollBar1)
        Me.Panel1.Location = New System.Drawing.Point(3, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(616, 130)
        Me.Panel1.TabIndex = 5
        '
        'pnlCFRELATION
        '
        Me.pnlCFRELATION.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCFRELATION.Location = New System.Drawing.Point(8, 4)
        Me.pnlCFRELATION.Name = "pnlCFRELATION"
        Me.pnlCFRELATION.Size = New System.Drawing.Size(581, 120)
        Me.pnlCFRELATION.TabIndex = 8
        Me.pnlCFRELATION.Tag = "Member"
        '
        'VScrollBar1
        '
        Me.VScrollBar1.LargeChange = 1
        Me.VScrollBar1.Location = New System.Drawing.Point(592, 3)
        Me.VScrollBar1.Name = "VScrollBar1"
        Me.VScrollBar1.Size = New System.Drawing.Size(17, 120)
        Me.VScrollBar1.TabIndex = 6
        '
        'frmContractInfo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(640, 251)
        Me.Controls.Add(Me.tbSign)
        Me.Controls.Add(Me.lblAFINFO)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCANCEL)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmContractInfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmContractInfo"
        Me.pnContractInfo.ResumeLayout(False)
        CType(Me.picSignature, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbSign.ResumeLayout(False)
        Me.tpSignAuth.ResumeLayout(False)
        Me.tpSignRela.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " InitExternal"
    Private Sub InitExternal()
        'Khởi tạo Grid MemberGrid
        MemberGrid = New GridEx

        Dim v_cmrMemberHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrMemberHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrMemberHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)

        MemberGrid.FixedHeaderRows.Add(v_cmrMemberHeader)
        MemberGrid.Columns.Add(New Xceed.Grid.Column("__TICK", GetType(System.String)))
        MemberGrid.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(System.String)))
        MemberGrid.Columns.Add(New Xceed.Grid.Column("REF", GetType(System.String)))
        MemberGrid.Columns.Add(New Xceed.Grid.Column("CUSTID", GetType(System.String)))
        MemberGrid.Columns.Add(New Xceed.Grid.Column("IDCODE", GetType(System.String)))
        MemberGrid.Columns.Add(New Xceed.Grid.Column("FULLNAME", GetType(System.String)))
        MemberGrid.Columns.Add(New Xceed.Grid.Column("EFFDATE", GetType(System.String)))
        MemberGrid.Columns.Add(New Xceed.Grid.Column("EXPDATE", GetType(System.String)))
        MemberGrid.Columns.Add(New Xceed.Grid.Column("ADDRESS", GetType(System.String)))
        MemberGrid.Columns.Add(New Xceed.Grid.Column("IDDATE", GetType(System.String)))
        MemberGrid.Columns.Add(New Xceed.Grid.Column("IDPLACE", GetType(System.String)))
        MemberGrid.Columns.Add(New Xceed.Grid.Column("TYP", GetType(System.String)))

        MemberGrid.Columns("__TICK").Title = "X"
        MemberGrid.Columns("TYP").Title = mv_ResourceManager.GetString("MEMBER_TYP")
        MemberGrid.Columns("CUSTID").Title = mv_ResourceManager.GetString("MEMBER_CUSTID")
        MemberGrid.Columns("IDCODE").Title = mv_ResourceManager.GetString("MEMBER_IDCODE")
        MemberGrid.Columns("FULLNAME").Title = mv_ResourceManager.GetString("MEMBER_FULLNAME")
        MemberGrid.Columns("EFFDATE").Title = mv_ResourceManager.GetString("MEMBER_EFFDATE")
        MemberGrid.Columns("EXPDATE").Title = mv_ResourceManager.GetString("MEMBER_EXPDATE")
        MemberGrid.Columns("REF").Title = mv_ResourceManager.GetString("MEMBER_REF")
        MemberGrid.Columns("ADDRESS").Title = mv_ResourceManager.GetString("MEMBER_ADDRESS")
        MemberGrid.Columns("IDDATE").Title = mv_ResourceManager.GetString("MEMBER_IDDATE")
        MemberGrid.Columns("IDPLACE").Title = mv_ResourceManager.GetString("MEMBER_IDPLACE")

        MemberGrid.Columns("AUTOID").Width = 0
        MemberGrid.Columns("TYP").Width = 0
        MemberGrid.Columns("__TICK").Width = 20
        MemberGrid.Columns("TYP").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        MemberGrid.Columns("__TICK").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        MemberGrid.Columns("CUSTID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        MemberGrid.Columns("IDCODE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        MemberGrid.Columns("FULLNAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        MemberGrid.Columns("EFFDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        MemberGrid.Columns("EXPDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        MemberGrid.Columns("REF").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        MemberGrid.Columns("ADDRESS").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        MemberGrid.Columns("IDDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        MemberGrid.Columns("IDPLACE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left

        Me.pnlMember.Controls.Clear()
        Me.pnlMember.Controls.Add(MemberGrid)
        MemberGrid.Dock = Windows.Forms.DockStyle.Fill
        AddHandler MemberGrid.DoubleClick, AddressOf Me.MemberGrid_DoubleClick
        If Me.MemberGrid.DataRowTemplate.Cells.Count >= 0 Then
            For i As Integer = 0 To Me.MemberGrid.DataRowTemplate.Cells.Count - 1
                AddHandler MemberGrid.DataRowTemplate.Cells(i).DoubleClick, AddressOf MemberGrid_DoubleClick
                AddHandler MemberGrid.DataRowTemplate.Cells(i).Click, AddressOf MemberGrid_Click
            Next
        End If
        AddHandler MemberGrid.DataRowTemplate.KeyUp, AddressOf MemberGrid_KeyUp




        RelationGrid = New GridEx

        Dim v_cmrRelationHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrRelationHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrRelationHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)

        RelationGrid.FixedHeaderRows.Add(v_cmrRelationHeader)
        RelationGrid.Columns.Add(New Xceed.Grid.Column("__TICK", GetType(System.String)))
        RelationGrid.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(System.String)))
        RelationGrid.Columns.Add(New Xceed.Grid.Column("REF", GetType(System.String)))
        RelationGrid.Columns.Add(New Xceed.Grid.Column("CUSTID", GetType(System.String)))
        RelationGrid.Columns.Add(New Xceed.Grid.Column("IDCODE", GetType(System.String)))
        RelationGrid.Columns.Add(New Xceed.Grid.Column("FULLNAME", GetType(System.String)))
        RelationGrid.Columns.Add(New Xceed.Grid.Column("ACDATE", GetType(System.String)))
        RelationGrid.Columns.Add(New Xceed.Grid.Column("ADDRESS", GetType(System.String)))
        RelationGrid.Columns.Add(New Xceed.Grid.Column("IDDATE", GetType(System.String)))
        RelationGrid.Columns.Add(New Xceed.Grid.Column("IDPLACE", GetType(System.String)))
        RelationGrid.Columns.Add(New Xceed.Grid.Column("TYP", GetType(System.String)))

        RelationGrid.Columns("__TICK").Title = "X"
        RelationGrid.Columns("TYP").Title = mv_ResourceManager.GetString("MEMBER_TYP")
        RelationGrid.Columns("CUSTID").Title = mv_ResourceManager.GetString("MEMBER_CUSTID")
        RelationGrid.Columns("IDCODE").Title = mv_ResourceManager.GetString("MEMBER_IDCODE")
        RelationGrid.Columns("FULLNAME").Title = mv_ResourceManager.GetString("MEMBER_FULLNAME")
        RelationGrid.Columns("ACDATE").Title = mv_ResourceManager.GetString("MEMBER_ACDATE")
        RelationGrid.Columns("REF").Title = mv_ResourceManager.GetString("MEMBER_REF")
        RelationGrid.Columns("ADDRESS").Title = mv_ResourceManager.GetString("MEMBER_ADDRESS")
        RelationGrid.Columns("IDDATE").Title = mv_ResourceManager.GetString("MEMBER_IDDATE")
        RelationGrid.Columns("IDPLACE").Title = mv_ResourceManager.GetString("MEMBER_IDPLACE")

        RelationGrid.Columns("AUTOID").Width = 0
        RelationGrid.Columns("TYP").Width = 0
        RelationGrid.Columns("__TICK").Width = 20
        RelationGrid.Columns("TYP").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        RelationGrid.Columns("__TICK").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        RelationGrid.Columns("CUSTID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        RelationGrid.Columns("IDCODE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        RelationGrid.Columns("FULLNAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        RelationGrid.Columns("ACDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        RelationGrid.Columns("REF").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        RelationGrid.Columns("ADDRESS").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        RelationGrid.Columns("IDDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        RelationGrid.Columns("IDPLACE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left

        Me.pnlCFRELATION.Controls.Clear()
        Me.pnlCFRELATION.Controls.Add(RelationGrid)
        RelationGrid.Dock = Windows.Forms.DockStyle.Fill
        AddHandler RelationGrid.DoubleClick, AddressOf Me.RelationGrid_DoubleClick
        If Me.RelationGrid.DataRowTemplate.Cells.Count >= 0 Then
            For i As Integer = 0 To Me.RelationGrid.DataRowTemplate.Cells.Count - 1
                AddHandler RelationGrid.DataRowTemplate.Cells(i).DoubleClick, AddressOf RelationGrid_DoubleClick
                AddHandler RelationGrid.DataRowTemplate.Cells(i).Click, AddressOf RelationGrid_Click
            Next
        End If
        AddHandler RelationGrid.DataRowTemplate.KeyUp, AddressOf RelationGrid_KeyUp


    End Sub
#End Region

#Region " Other methods "
    Private Sub ShowCF()
        'Hiển thị thông tin người được uỷ quyền
        Dim v_strTYP, v_strCUSTID, v_strAUTOID As String
        If Not (MemberGrid.CurrentRow Is Nothing) Then
            v_strTYP = Trim(CType(MemberGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TYP").Value)
            If v_strTYP = "M" Then 'Hiển thị thông tin trong CFMAST
                v_strCUSTID = Trim(CType(MemberGrid.CurrentRow, Xceed.Grid.DataRow).Cells("CUSTID").Value)
                v_frmCFMAST.ExeFlag = ExecuteFlag.View
                v_frmCFMAST.UserLanguage = UserLanguage
                v_frmCFMAST.ModuleCode = "CF"
                v_frmCFMAST.ObjectName = "CF.CFMAST"
                v_frmCFMAST.TableName = "CFMAST"
                v_frmCFMAST.LocalObject = "N"
                v_frmCFMAST.Text = mv_ResourceManager.GetString("frm_CFMAST")
                v_frmCFMAST.KeyFieldName = "CUSTID"
                v_frmCFMAST.KeyFieldType = "C"
                v_frmCFMAST.KeyFieldValue = Trim(CType(MemberGrid.CurrentRow, Xceed.Grid.DataRow).Cells("CUSTID").Value)
                Dim frmResult As DialogResult = v_frmCFMAST.ShowDialog()
            Else
                If v_strTYP = "A" Then 'Hiển thị thông tin trong CFAUTH                     
                    v_strAUTOID = Trim(CType(MemberGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
                    v_frmCFAUTH.ExeFlag = ExecuteFlag.View
                    v_frmCFAUTH.UserLanguage = UserLanguage
                    v_frmCFAUTH.ModuleCode = "CF"
                    v_frmCFAUTH.ObjectName = "CF.CFAUTH"
                    v_frmCFAUTH.TableName = "CFAUTH"
                    v_frmCFAUTH.LocalObject = "N"
                    v_frmCFAUTH.Text = mv_ResourceManager.GetString("frm_CFAUTH") 'Lay tu resource
                    v_frmCFAUTH.KeyFieldName = "AUTOID"
                    v_frmCFAUTH.KeyFieldType = "C"
                    v_frmCFAUTH.KeyFieldValue = Trim(CType(MemberGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
                    Dim frmResult As DialogResult = v_frmCFAUTH.ShowDialog()
                End If
            End If
        End If
    End Sub

    Private Sub ShowRELA()
        'Hiển thị thông tin thành viên
        Dim v_strTYP, v_strCUSTID, v_strAUTOID As String
        If Not (RelationGrid.CurrentRow Is Nothing) Then
            v_strTYP = Trim(CType(RelationGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TYP").Value)
            If v_strTYP = "A" Then 'Hiển thị thông tin trong CFAUTH                     
                v_strAUTOID = Trim(CType(RelationGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
                v_frmCFRELATION.ExeFlag = ExecuteFlag.View
                v_frmCFRELATION.UserLanguage = UserLanguage
                v_frmCFRELATION.ModuleCode = "CF"
                v_frmCFRELATION.ObjectName = "CF.CFRELATION"
                v_frmCFRELATION.TableName = "CFRELATION"
                v_frmCFRELATION.LocalObject = "N"
                v_frmCFRELATION.Text = mv_ResourceManager.GetString("frmCFRELATION") 'Lay tu resource
                v_frmCFRELATION.KeyFieldName = "AUTOID"
                v_frmCFRELATION.KeyFieldType = "C"
                v_frmCFRELATION.KeyFieldValue = Trim(CType(RelationGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
                Dim frmResult As DialogResult = v_frmCFRELATION.ShowDialog()
            End If
        End If
    End Sub

    Private Sub GetAFContractInfo(ByVal v_strAFACCTNO As String)
        Try
            If v_strAFACCTNO.Length > 0 Then
                Dim v_nodeList As Xml.XmlNodeList
                Dim v_xmlDocument As New Xml.XmlDocument
                Dim v_strValue, v_strFLDNAME, v_strTEXT, v_strClause, v_strTERMOFUSE As String, i, j As Integer
                Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                Dim v_strCmdSQL As String, v_strObjMsg As String

                'Lấy thông tin về khách hàng 
                v_strCmdSQL = "SELECT CF.IDDATE, CF.IDPLACE, CF.IDCODE LICENSE,CF.CUSTID, CF.CUSTODYCD, CF.FULLNAME, AF.TERMOFUSE, CD.CDCONTENT TERM, CI.BALANCE, AF.BRATIO, NVL(AP.AAMT,0) AAMT , CI.BALANCE + NVL(AP.AAMT,0) TOTAL" & ControlChars.CrLf _
                    & "FROM CFMAST CF INNER JOIN AFMAST AF ON TRIM(CF.CUSTID)=TRIM(AF.CUSTID) " & ControlChars.CrLf _
                    & " INNER JOIN CIMAST CI ON TRIM(AF.ACCTNO)=TRIM(CI.AFACCTNO) " & ControlChars.CrLf _
                    & " INNER JOIN ALLCODE CD ON TRIM(CD.CDVAL)=TRIM(AF.TERMOFUSE) AND TRIM(CD.CDTYPE)='CF' AND TRIM(CD.CDNAME)='TERMOFUSE'" & ControlChars.CrLf _
                    & " LEFT JOIN (SELECT AFACCTNO ACCTNO, SUM(AMT) AAMT FROM STSCHD WHERE DUETYPE = 'RM' AND AFACCTNO = '" & v_strAFACCTNO & "' GROUP BY AFACCTNO) AP ON TRIM(AF.ACCTNO) = TRIM(AP.ACCTNO) " & ControlChars.CrLf _
                    & "WHERE TRIM(AF.ACCTNO)='" & v_strAFACCTNO & "'"

                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL)
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
                                Case "LICENSE"
                                    If Len(v_strTEXT) = 0 Then
                                        v_strTEXT = v_strValue
                                    Else
                                        v_strTEXT = v_strTEXT & ", " & v_strValue
                                    End If
                                Case "FULLNAME"
                                    If Len(v_strTEXT) = 0 Then
                                        v_strTEXT = v_strValue
                                    Else
                                        v_strTEXT = v_strTEXT & ", " & v_strValue
                                    End If
                                    mv_strFULLNAME = v_strValue
                                Case "CUSTODYCD"
                                    v_strTEXT = v_strTEXT & " [" & mv_ResourceManager.GetString("CUSTODYCD") & v_strValue & "] "
                                    mv_strCONFIRMNAME = "Contract no: " & Strings.Left(v_strAFACCTNO, 4) & "." & Strings.Mid(v_strAFACCTNO, 5, 3) & "." & Strings.Right(v_strAFACCTNO, 3) & _
                                         " | Custody: " & Strings.Left(v_strValue, 4) & "." & Strings.Mid(v_strValue, 5, 3) & "." & Strings.Right(v_strValue, 3)
                                Case "TERM"
                                    If Len(v_strTEXT) = 0 Then
                                        v_strTEXT = v_strValue
                                    Else
                                        v_strTEXT = v_strTEXT & ", " & v_strValue
                                    End If
                                Case "CUSTID"
                                    mv_strCUSTID = v_strValue
                                Case "TERMOFUSE"
                                    v_strTERMOFUSE = v_strValue
                            End Select
                        End With
                    Next
                Next

                lblAFINFO.Text = v_strTEXT
                If v_strTERMOFUSE = "003" Then
                    lblAFINFO.ForeColor = Drawing.Color.Red
                Else
                    lblAFINFO.ForeColor = Drawing.Color.Black
                End If

                'Fill dữ liệu vào Grid
                If Len(v_strAFACCTNO) > 0 Then
                    'Lấy thông tin chữ ký
                    LoadCFSign(mv_strCUSTID)

                    'Remove các bản ghi cũ
                    MemberGrid.DataRows.Clear()


                    'Lấy thông tin về thành viên hợp đồng va thông tin về người được ủy quyền
                    'If mv_blnBUYSELL Then
                    '    v_strCmdSQL = "SELECT 0 AUTOID, 'M' TYP, CF.CUSTID, CF.IDCODE, CF.FULLNAME, CD.CDCONTENT REF, LNK.ACCTNO,'------' EFFDATE,'------' EXPDATE " & ControlChars.CrLf _
                    '   & "FROM CFMAST CF, CFLINK LNK, ALLCODE CD " & ControlChars.CrLf _
                    '   & "WHERE TRIM(CF.CUSTID)=TRIM(LNK.CUSTID) AND TRIM(LNK.LINKTYPE)=CD.CDVAL AND CD.CDTYPE='CF' AND CD.CDNAME='LINKTYPE' AND SUBSTR(LNK.LINKAUTH,4,2) IN ('YN','NY','YY') " & ControlChars.CrLf _
                    '   & "AND TRIM(LNK.ACCTNO)='" & v_strAFACCTNO & "' UNION ALL " & "SELECT CFAUTH.AUTOID, 'A' TYP, CUSTID, LICENSENO IDCODE, FULLNAME, ADDRESS REF, ACCTNO,TO_CHAR(VALDATE,'DD/MM/YYYY') EFFDATE ,TO_CHAR(EXPDATE,'DD/MM/YYYY') EXPDATE FROM CFAUTH " & ControlChars.CrLf _
                    '& "WHERE TRIM(ACCTNO)='" & v_strAFACCTNO & "' AND substr(linkauth,4,2) IN ('YN','NY','YY')  and  cfauth.deltd='N' and expdate >= (SELECT TO_DATE (VARVALUE,'DD/MM/YYYY') FROM SYSVAR  WHERE VARNAME = 'CURRDATE' ) and valdate <= (SELECT TO_DATE (VARVALUE,'DD/MM/YYYY') FROM SYSVAR  WHERE VARNAME = 'CURRDATE' )  "
                    'Else
                    '    v_strCmdSQL = "SELECT 0 AUTOID, 'M' TYP, CF.CUSTID, CF.IDCODE, CF.FULLNAME, CD.CDCONTENT REF, LNK.ACCTNO,'------' EFFDATE,'------' EXPDATE " & ControlChars.CrLf _
                    '   & "FROM CFMAST CF, CFLINK LNK, ALLCODE CD " & ControlChars.CrLf _
                    '   & "WHERE TRIM(CF.CUSTID)=TRIM(LNK.CUSTID) AND TRIM(LNK.LINKTYPE)=CD.CDVAL AND CD.CDTYPE='CF' AND CD.CDNAME='LINKTYPE' AND substr(linkauth,3,1)='Y' " & ControlChars.CrLf _
                    '   & "AND TRIM(LNK.ACCTNO)='" & v_strAFACCTNO & "' UNION ALL " & "SELECT CFAUTH.AUTOID, 'A' TYP, CUSTID, LICENSENO IDCODE, FULLNAME, ADDRESS REF, ACCTNO,TO_CHAR(VALDATE,'DD/MM/YYYY') EFFDATE ,TO_CHAR(EXPDATE,'DD/MM/YYYY') EXPDATE FROM CFAUTH " & ControlChars.CrLf _
                    '& "WHERE TRIM(ACCTNO)='" & v_strAFACCTNO & "' AND substr(linkauth,3,1)='Y'  and  cfauth.deltd='N' and expdate >= (SELECT TO_DATE (VARVALUE,'DD/MM/YYYY') FROM SYSVAR  WHERE VARNAME = 'CURRDATE' ) and valdate <= (SELECT TO_DATE (VARVALUE,'DD/MM/YYYY') FROM SYSVAR  WHERE VARNAME = 'CURRDATE' ) "

                    'End If

                    'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL)
                    'v_ws.Message(v_strObjMsg)


                    ''TruongLD Add 12/10/2011
                    v_strCmdSQL = "SP_DB_GETAUTHCONTRACTINFO"
                    'v_strClause = "PV_AFACCTNO!" & v_strAFACCTNO & "!varchar2!20" & _
                    '                "^pv_EXECTYPE!" & mv_blnBUYSELL & "!varchar2!20"

                    v_strClause = "PV_AFACCTNO!" & v_strAFACCTNO & "!varchar2!20" & _
                                    "^pv_EXECTYPE!" & mv_blnBUYSELL & "!varchar2!20" & _
                                    "^pv_TLTXCD!" & TLTXCD & "!varchar2!20"

                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL, v_strClause, , , , , , , gc_CommandProcedure)
                    v_ws.Message(v_strObjMsg)
                    FillDataGrid(MemberGrid, v_strObjMsg, "")

                    'Nếu không có thông tin người uỷ quyền thì disable pnMemberGrid
                    If MemberGrid.DataRows.Count > 0 Then
                        pnlMember.Enabled = True
                    Else
                        pnlMember.Enabled = False
                    End If


                    v_strCmdSQL = "SP_DB_GETRELATIONINFO"
                   
                    v_strClause = "PV_AFACCTNO!" & v_strAFACCTNO & "!varchar2!20"
                                  
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL, v_strClause, , , , , , , gc_CommandProcedure)
                    v_ws.Message(v_strObjMsg)
                    FillDataGrid(RelationGrid, v_strObjMsg, "")




                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, Me.Text)
        End Try
    End Sub

    Private Function GetImageFromString(ByVal pv_strFLDVAL) As System.Drawing.Bitmap
        Dim v_strCompress As String = Trim(pv_strFLDVAL)
        Dim v_Compression As Byte()
        Dim v_Base64Decoder As New Base64Decoder(v_strCompress)
        v_Compression = v_Base64Decoder.GetDecoded()
        Dim v_arrActualSignImage As Byte()
        v_arrActualSignImage = CompressionHelper.DecompressBytes(v_Compression)
        Dim tmpImage As System.Drawing.Bitmap = New System.Drawing.Bitmap(New MemoryStream(v_arrActualSignImage))
        Return tmpImage
    End Function

    Private Sub LoadCFSign(ByVal pv_strCUSTID As String)
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim v_strSQL As String = "SELECT SIG.AUTOID,SIG.CUSTID,SIG.SIGNATURE, sys.varvalue FROM CFSIGN SIG, sysvar sys " & ControlChars.CrLf _
            & "WHERE TRIM(SIG.CUSTID)='" & pv_strCUSTID & "' AND sys.varname = 'CURRDATE' AND grname = 'SYSTEM' AND to_date(sys.varvalue,'DD/MM/RRRR') >= valdate AND to_date(sys.varvalue,'DD/MM/RRRR') <= expdate order by autoid desc"
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "CF.CFSIGN", _
                gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)

            Dim v_xmlDoc As New XmlDocument
            v_xmlDoc.LoadXml(v_strObjMsg)
            Dim v_xmlNodeList As XmlNodeList = v_xmlDoc.SelectNodes("/ObjectMessage/ObjData")
            Dim v_xmlEntry As XmlNode

            ReDim mv_arrAUTOID(v_xmlNodeList.Count - 1)
            ReDim mv_arrSIGNATURE(v_xmlNodeList.Count - 1)
            ReDim mv_arrCUSTID(v_xmlNodeList.Count - 1)

            Dim v_strFLDNAME As String = String.Empty
            Dim v_strValue As String = String.Empty

            For i As Integer = 0 To v_xmlNodeList.Count - 1
                For j As Integer = 0 To v_xmlNodeList.Item(i).ChildNodes.Count - 1
                    With v_xmlNodeList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString
                        Select Case Trim(v_strFLDNAME)
                            Case "AUTOID"
                                mv_arrAUTOID(i) = Trim(v_strValue)
                            Case "CUSTID"
                                mv_arrCUSTID(i) = Trim(v_strValue)
                            Case "SIGNATURE"
                                mv_arrSIGNATURE(i) = Trim(v_strValue)
                        End Select
                    End With
                Next
            Next
            Me.VScrollBarSign.Minimum = 0
            Me.VScrollBarSign.Maximum = mv_arrSIGNATURE.Length - 1
            Me.VScrollBarSign.Value = 0
            If mv_arrSIGNATURE.Length > 0 Then
                picSignature.Image = GetImageFromString(mv_arrSIGNATURE(Me.VScrollBarSign.Value))
            Else
                picSignature.Image = Nothing
                picSignature.Refresh()
            End If
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub
    Protected Overridable Function InitDialog()
        'Khởi tạo kích thước form và load resource
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)

        'Khởi tạo Grid Member
        InitExternal()

        'Thiết lập các thuộc tính ban đầu cho form
        DoResizeForm()

        'Nạp màn hình
        GetAFContractInfo(Me.AFACCTNO)
    End Function


    Private Sub DoResizeForm()

    End Sub

    Private Sub Grid_DblClick(ByVal sender As Object, ByVal e As System.EventArgs)
        OnAccept()
    End Sub

    Private Sub Grid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    OnAccept()
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub OnClose()
        mv_retCUSTNAME = String.Empty
        mv_retIDNUMBER = String.Empty
        mv_retIDDATE = String.Empty
        mv_retIDPLACE = String.Empty
        mv_retADDRESS = String.Empty
        Me.Close()
    End Sub

    Private Sub OnAccept()
        'Hiển thị thông tin người được uỷ quyền
        If Not (MemberGrid.CurrentRow Is Nothing) AndAlso Trim(CType(MemberGrid.CurrentRow, Xceed.Grid.DataRow).Cells("__TICK").Value) = "X" Then
            mv_retROLETYPE = Trim(CType(MemberGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TYP").Value)
            mv_retCUSTID = Trim(CType(MemberGrid.CurrentRow, Xceed.Grid.DataRow).Cells("CUSTID").Value)
            mv_retCUSTNAME = Trim(CType(MemberGrid.CurrentRow, Xceed.Grid.DataRow).Cells("FULLNAME").Value)
            mv_retIDNUMBER = Trim(CType(MemberGrid.CurrentRow, Xceed.Grid.DataRow).Cells("IDCODE").Value)
            mv_retIDDATE = Trim(CType(MemberGrid.CurrentRow, Xceed.Grid.DataRow).Cells("IDDATE").Value)
            mv_retIDPLACE = Trim(CType(MemberGrid.CurrentRow, Xceed.Grid.DataRow).Cells("IDPLACE").Value)
            mv_retADDRESS = Trim(CType(MemberGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ADDRESS").Value)
        End If
        Me.Close()
    End Sub

    Private Sub LoadResource(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control

        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is Label Then
                CType(v_ctrl, Label).Text = mv_ResourceManager.GetString("frmContractInfo." & v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString("frmContractInfo." & v_ctrl.Name)
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Button Then
                CType(v_ctrl, Button).Text = mv_ResourceManager.GetString("frmContractInfo." & v_ctrl.Name)
            End If
        Next

        Me.Text = mv_ResourceManager.GetString("frmContractInfo")
    End Sub
#End Region

#Region " Form events "
    Private Sub frmContractInfo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitDialog()
    End Sub

    Private Sub frmContractInfo_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        DoResizeForm()
    End Sub

    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        OnAccept()
    End Sub

    Private Sub btnCANCEL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCANCEL.Click
        OnClose()
    End Sub

    Private Sub frmContractInfo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                OnClose()
            Case Keys.Enter
                OnAccept()
        End Select
    End Sub

    Private Sub VScrollBarSign_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles VScrollBarSign.Scroll
        'If Not mv_arrSIGNATURE Is Nothing Then
        '    If mv_arrSIGNATURE.Length > 0 Then
        '        picSignature.Image = GetImageFromString(mv_arrSIGNATURE(Me.VScrollBarSign.Value))
        '    Else
        '        picSignature.Image = Nothing
        '        picSignature.Refresh()
        '    End If
        'End If
    End Sub


    Private Sub VScrollBarSign_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles VScrollBarSign.ValueChanged
        If Not mv_arrSIGNATURE Is Nothing Then
            If mv_arrSIGNATURE.Length > 0 Then
                picSignature.Image = GetImageFromString(mv_arrSIGNATURE(Me.VScrollBarSign.Value))
            Else
                picSignature.Image = Nothing
                picSignature.Refresh()
            End If
        End If
    End Sub

    Private Sub MemberGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MemberGrid.DoubleClick
        Try
            Call ShowCF()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub MemberGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MemberGrid.Click
        Try
            For i As Integer = 0 To MemberGrid.DataRows.Count - 1
                If Trim(CType(MemberGrid.DataRows(i), Xceed.Grid.DataRow).Cells("__TICK").Value) = "X" AndAlso Not MemberGrid.DataRows(i) Is MemberGrid.CurrentRow Then
                    CType(MemberGrid.DataRows(i), Xceed.Grid.DataRow).Cells("__TICK").Value = String.Empty
                End If
            Next
            If Trim(CType(MemberGrid.CurrentRow, Xceed.Grid.DataRow).Cells("__TICK").Value) = String.Empty Then
                CType(MemberGrid.CurrentRow, Xceed.Grid.DataRow).Cells("__TICK").Value = "X"
            Else
                CType(MemberGrid.CurrentRow, Xceed.Grid.DataRow).Cells("__TICK").Value = String.Empty
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub MemberGrid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MemberGrid.KeyUp
        Try
            Select Case e.KeyCode
                Case Keys.Alt.V
                    Call ShowCF()
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RelationGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles RelationGrid.DoubleClick
        Try
            Call ShowRELA()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RelationGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RelationGrid.Click
        Try
            For i As Integer = 0 To RelationGrid.DataRows.Count - 1
                If Trim(CType(RelationGrid.DataRows(i), Xceed.Grid.DataRow).Cells("__TICK").Value) = "X" AndAlso Not RelationGrid.DataRows(i) Is RelationGrid.CurrentRow Then
                    CType(RelationGrid.DataRows(i), Xceed.Grid.DataRow).Cells("__TICK").Value = String.Empty
                End If
            Next
            If Trim(CType(RelationGrid.CurrentRow, Xceed.Grid.DataRow).Cells("__TICK").Value) = String.Empty Then
                CType(RelationGrid.CurrentRow, Xceed.Grid.DataRow).Cells("__TICK").Value = "X"
            Else
                CType(RelationGrid.CurrentRow, Xceed.Grid.DataRow).Cells("__TICK").Value = String.Empty
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RelationGrid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RelationGrid.KeyUp
        Try
            Select Case e.KeyCode
                Case Keys.Alt.V
                    Call ShowRELA()
            End Select
        Catch ex As Exception
        End Try
    End Sub


    Private Sub picSignature_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles picSignature.Click
        Dim frm As New frmSignature

        If Not picSignature.Image Is Nothing Then

            frm.Size = picSignature.Image.Size

            frm.ImageSign = picSignature.Image

            frm.ShowDialog()
        End If

    End Sub
#End Region

End Class
