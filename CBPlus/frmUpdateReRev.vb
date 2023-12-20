Imports System.Windows.Forms
Imports CommonLibrary
Imports AppCore
Imports System.IO

Public Class frmUpdateReRev
    Inherits System.Windows.Forms.Form
#Region " Constants and variables declaration "
    Const c_RESOURCE_MANAGER = "_DIRECT.frmUpdateReRev-"

    Private mv_resourceManager As Resources.ResourceManager
    Private mv_strLanguage As String
    Private mv_gridRemiser As GridEx
    Private mv_strDBLinkName As String
    Private mv_strDBLinkDesc As String
    Private mv_strBranchId As String
    Private mv_strTellerId As String
    Private mv_strIpAddress As String
    Private mv_strWsName As String
#End Region

#Region " Properties "
    Public Property ResourceManager() As Resources.ResourceManager
        Get
            Return mv_resourceManager
        End Get
        Set(ByVal Value As Resources.ResourceManager)
            mv_resourceManager = Value
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
#End Region
    Private Sub InitDialog()
        Try
            AddHandler btnCancel.Click, AddressOf Button_Click

            AddHandler btnChange.Click, AddressOf Button_Click
            AddHandler btnSearch.Click, AddressOf Button_Click

            'Load resource and user's interface
            ResourceManager = New Resources.ResourceManager(c_RESOURCE_MANAGER & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            LoadUserInterface(Me)
            InitReGrid()
            If Me.mv_gridRemiser.DataRowTemplate.Cells.Count >= 0 Then
                For i As Integer = 0 To Me.mv_gridRemiser.DataRowTemplate.Cells.Count - 1
                    AddHandler mv_gridRemiser.DataRowTemplate.Cells(i).Click, AddressOf Grid_Click
                Next
            End If

        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmUpdateReRev.InitDialog" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub LoadUserInterface(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control

        Try
            For Each v_ctrl In pv_ctrl.Controls
                If TypeOf (v_ctrl) Is Label Then
                    CType(v_ctrl, Label).Text = ResourceManager.GetString(v_ctrl.Tag)
                ElseIf TypeOf (v_ctrl) Is Button Then
                    CType(v_ctrl, Button).Text = ResourceManager.GetString(v_ctrl.Tag)
                ElseIf TypeOf (v_ctrl) Is Panel Then
                    LoadUserInterface(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is GroupBox Then
                    CType(v_ctrl, GroupBox).Text = ResourceManager.GetString(v_ctrl.Tag)
                    LoadUserInterface(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is TabControl Then
                    For Each v_ctrlTmp As Control In CType(v_ctrl, TabControl).TabPages
                        CType(v_ctrlTmp, TabPage).Text = ResourceManager.GetString(v_ctrlTmp.Tag)
                    Next
                    LoadUserInterface(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is TabPage Then
                    v_ctrl.BackColor = System.Drawing.SystemColors.InactiveCaptionText
                    CType(v_ctrl, TabPage).Text = ResourceManager.GetString(v_ctrl.Tag)
                    LoadUserInterface(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is TextBox Then
                    CType(v_ctrl, TextBox).Text = vbNullString
                ElseIf TypeOf (v_ctrl) Is RadioButton Then
                    CType(v_ctrl, RadioButton).Text = ResourceManager.GetString(v_ctrl.Tag)
                End If
            Next
            'Load caption của form, label caption
            If (Me.Text.Trim() = String.Empty) Or (Me.Text.Trim() = Me.Name) Then
                Me.Text = ResourceManager.GetString(Me.Name)
            End If
            lblCaption.Text = ResourceManager.GetString(lblCaption.Tag)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub InitReGrid()
        Try
            'Create new instance of GridEx
            mv_gridRemiser = New GridEx
            mv_gridRemiser.Dock = DockStyle.Fill

            Dim v_cmrHeader As New Xceed.Grid.ColumnManagerRow
            v_cmrHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            v_cmrHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            v_cmrHeader.HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center

            mv_gridRemiser.FixedHeaderRows.Add(v_cmrHeader)

            'Add column for grid
            With mv_gridRemiser.Columns
                .Add(New Xceed.Grid.Column("__TICK", GetType(System.String)))
                .Add(New Xceed.Grid.Column("AUTOID", GetType(System.String)))
                .Add(New Xceed.Grid.Column("CUSTID", GetType(System.String)))
                .Add(New Xceed.Grid.Column("FULLNAME", GetType(System.String)))
                .Add(New Xceed.Grid.Column("GROUPNAME", GetType(System.String)))
                .Add(New Xceed.Grid.Column("REVAMT", GetType(System.String)))
                .Add(New Xceed.Grid.Column("RATE", GetType(System.Decimal)))
                .Add(New Xceed.Grid.Column("ADREVAMT", GetType(System.String)))

            End With
            mv_gridRemiser.Columns("__TICK").Width = 20
            mv_gridRemiser.Columns("__TICK").ReadOnly = True
            mv_gridRemiser.Columns("AUTOID").Visible = False
            mv_gridRemiser.Columns("CUSTID").ReadOnly = True
            mv_gridRemiser.Columns("FULLNAME").Width = 200
            mv_gridRemiser.Columns("FULLNAME").ReadOnly = True
            mv_gridRemiser.Columns("GROUPNAME").Width = 200
            mv_gridRemiser.Columns("REVAMT").FormatSpecifier = "###.###.####.###,##0"
            mv_gridRemiser.Columns("REVAMT").ReadOnly = True
            mv_gridRemiser.Columns("RATE").ReadOnly = True
            mv_gridRemiser.Columns("RATE").Width = 50
            mv_gridRemiser.Columns("ADREVAMT").FormatSpecifier = "###.###.####.###,##0"
            mv_gridRemiser.Columns("ADREVAMT").ReadOnly = True

            mv_gridRemiser.Columns("CUSTID").Title = mv_resourceManager.GetString("CUSTID")
            mv_gridRemiser.Columns("FULLNAME").Title = mv_resourceManager.GetString("FULLNAME")
            mv_gridRemiser.Columns("REVAMT").Title = mv_resourceManager.GetString("REVAMT")
            mv_gridRemiser.Columns("ADREVAMT").Title = mv_resourceManager.GetString("ADREVAMT")
            mv_gridRemiser.Columns("GROUPNAME").Title = mv_resourceManager.GetString("GROUPNAME")
            mv_gridRemiser.Columns("RATE").Title = mv_resourceManager.GetString("RATE")


            FillDataToGrid(mv_gridRemiser)
        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmUpdateReRev.InitSecInfoGrid" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub

    Private Sub FillDataToGrid(ByRef pv_gridRemiser As GridEx)
        Try
            Dim v_strSQL As String
            Dim v_where As String
            v_where = " "
            If rbRemiser.Checked Then
                If Not txtSearch.Text Is Nothing Then
                    v_where = " and (re.custid like '%" & txtSearch.Text & "%'  or upper(cf.fullname) like upper('%" & txtSearch.Text & "%') ) "
                End If
                v_strSQL = "SELECT RE.AUTOID,re.custid, cf.fullname,re.mindrevamt revamt, '' groupname," _
                          & " nvl(l.rate,0) rate, re.mindrevamt * (1 + nvl(l.rate,0)/100) ADrevamt  " _
                          & " FROM recflnk RE, cfmast cf, rerevlog l " _
                          & " where re.custid=cf.custid and re.AUTOID=l.AUTOID (+) and l.status(+)='A' and l.gor(+)='R' " & v_where _
                          & " order by re.custid"
                mv_gridRemiser.Columns("GROUPNAME").Visible = False
            Else
                If Not txtSearch.Text Is Nothing Then
                    v_where = " and (re.custid like '%" & txtSearch.Text & "%'  or upper(cf.fullname) like upper('%" & txtSearch.Text & "%') or upper(re.fullname) like upper('%" & txtSearch.Text & "%')) "
                End If
                mv_gridRemiser.Columns("GROUPNAME").Visible = True
                v_strSQL = "SELECT RE.AUTOID, re.custid, cf.fullname,re.minirevamt revamt, re.fullname groupname," _
                          & " nvl(l.rate,0) rate , re.minirevamt * (1 + nvl(l.rate,0)/100) ADrevamt " _
                          & " FROM regrp RE, cfmast cf, rerevlog l " _
                          & " where re.custid=cf.custid and re.AUTOID=l.AUTOID (+) and l.status(+)='A' and l.gor(+)='G'  " & v_where _
                          & " order by re.custid"
            End If

            Dim v_strMsgObj As String = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SE_SBSECURITIES, gc_ActionInquiry, v_strSQL)
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            'TruongLD Comment when convert
            'v_ws.Timeout = gc_WEB_SERVICE_TIMEOUT
            v_ws.Message(v_strMsgObj)
            'Fill data to grid
            Dim v_xmlDocument As New XmlDocumentEx
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strValue, v_strFLDNAME, v_strFLDTYPE As String

            v_xmlDocument.LoadXml(v_strMsgObj)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            pv_gridRemiser.DataRows.Clear()
            pv_gridRemiser.BeginInit()

            For i As Integer = 0 To v_nodeList.Count - 1
                Dim v_xDataRow As Xceed.Grid.DataRow = pv_gridRemiser.DataRows.AddNew()
                Dim v_xColumn As Xceed.Grid.Column
                For Each v_xColumn In pv_gridRemiser.Columns
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = .InnerText.ToString
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strFLDTYPE = CStr(CType(.Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)

                            If (v_strFLDNAME.ToUpper() = v_xColumn.FieldName.ToUpper()) Then
                                Select Case v_xColumn.DataType.Name
                                    Case GetType(System.String).Name
                                        v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, "", CStr(v_strValue))
                                    Case GetType(System.Decimal).Name
                                        If v_strValue = "" Then
                                            v_strValue = 0
                                        End If
                                        v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, 0, CDec(v_strValue))
                                    Case GetType(Integer).Name
                                        v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, 0, CInt(v_strValue))
                                    Case GetType(Long).Name
                                        v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, 0, CLng(v_strValue))
                                    Case GetType(System.DateTime).Name
                                        v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, "", CDate(v_strValue).ToShortDateString)
                                    Case Else
                                        v_xDataRow.Cells(v_xColumn.FieldName).Value = IIf(v_strValue Is DBNull.Value, "", v_strValue)
                                End Select

                                v_xDataRow.EndEdit()
                            End If
                        End With
                    Next
                Next
            Next
            pv_gridRemiser.EndInit()
            pnlRemiser.Controls.Add(pv_gridRemiser)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub frmUpdateReRev_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Select Case e.KeyCode

            Case Keys.Enter
                If Me.ActiveControl.Name = "txtSearch" Then
                    FillDataToGrid(mv_gridRemiser)
                End If
        End Select
    End Sub

    
   

    Private Sub frmUpdateReRev_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InitDialog()
    End Sub
    Private Sub OnClose()
        Me.Close()
    End Sub
    Private Sub onchange()

        Dim v_intRow As Integer
        Dim v_strAccList, V_AUTOID As String
        v_strAccList = ""
        V_AUTOID = "|"
        For v_intRow = 0 To mv_gridRemiser.DataRows.Count - 1
            If mv_gridRemiser.DataRows(v_intRow).Cells("__TICK").Value = "X" Then
                v_strAccList = v_strAccList & mv_gridRemiser.DataRows(v_intRow).Cells("CUSTID").Value & "|"
                V_AUTOID = V_AUTOID & mv_gridRemiser.DataRows(v_intRow).Cells("AUTOID").Value & "|"

            End If
        Next

        If MsgBox(mv_resourceManager.GetString("CONFIRM") & v_strAccList & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
            Dim v_strGrouporRemiser As String
            If rbRemiser.Checked Then
                v_strGrouporRemiser = "REMISER"
            Else
                v_strGrouporRemiser = "GROUP"
            End If
            Dim v_strMsgObj As String = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "RE.RECFLNK", gc_ActionAdhoc, , V_AUTOID, "CHANGEREV", , , txtRate.Text.ToString, v_strGrouporRemiser, Me.IpAddress)
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            'TruongLD Comment when convert
            'v_ws.Timeout = gc_WEB_SERVICE_TIMEOUT
            v_ws.Message(v_strMsgObj)
            FillDataToGrid(mv_gridRemiser)
            ckAll.Checked = False
        End If
    End Sub
    Private Sub Button_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If (sender Is btnCancel) Then
            OnClose()
        ElseIf (sender Is btnSearch) Then
            FillDataToGrid(mv_gridRemiser)
        ElseIf (sender Is btnChange) Then
            If Not IsNumeric(txtRate.Text) Then
                MsgBox(mv_resourceManager.GetString("RATEISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)

                Return
            ElseIf CDbl(txtRate.Text) <= -100 Or CDbl(txtRate.Text) > 100 Then
                MsgBox(mv_resourceManager.GetString("RATEISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)

                Return
            End If
            onchange()
       
        End If
    End Sub

    Protected Overridable Sub Grid_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not mv_gridRemiser.CurrentColumn Is Nothing Then
            If mv_gridRemiser.CurrentColumn.FieldName = "__TICK" Then
                If mv_gridRemiser.CurrentCell.Value = "X" Then
                    mv_gridRemiser.CurrentCell.Value = String.Empty
                Else
                    mv_gridRemiser.CurrentCell.Value = "X"
                End If
            End If
        End If
    End Sub

   
    Private Sub txtRate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtRate.Validating
        If Not IsNumeric(txtRate.Text) Then
            MsgBox(mv_resourceManager.GetString("RATEISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)

            Return
        ElseIf CDbl(txtRate.Text) <= -100 Or CDbl(txtRate.Text) > 100 Then
            MsgBox(mv_resourceManager.GetString("RATEISNOTNUMBER"), MsgBoxStyle.Information, Me.Text)

            Return
        End If

    End Sub

    Private Sub rbGroup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbGroup.CheckedChanged
        ' FillDataToGrid(mv_gridRemiser)
    End Sub

    Private Sub rbRemiser_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbRemiser.CheckedChanged
        'FillDataToGrid(mv_gridRemiser)
    End Sub

    Private Sub rbGroup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbGroup.Click
        FillDataToGrid(mv_gridRemiser)
    End Sub

    Private Sub rbremiser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbRemiser.Click
        FillDataToGrid(mv_gridRemiser)
    End Sub
    
    Private Sub ckAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckAll.CheckedChanged
        Dim v_intRow As Integer
        If ckAll.Checked Then
            For v_intRow = 0 To mv_gridRemiser.DataRows.Count - 1
                mv_gridRemiser.DataRows(v_intRow).Cells("__TICK").Value = "X"
            Next
        Else
            For v_intRow = 0 To mv_gridRemiser.DataRows.Count - 1
                mv_gridRemiser.DataRows(v_intRow).Cells("__TICK").Value = String.Empty
            Next
        End If
    End Sub
End Class