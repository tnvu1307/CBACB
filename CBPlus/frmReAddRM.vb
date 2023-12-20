Imports System.Windows.Forms
Imports CommonLibrary
Imports AppCore
Imports System.IO
Imports System.Configuration
Imports System.Configuration.ConfigurationSettings

Public Class frmReAddRM
    Inherits System.Windows.Forms.Form
#Region " Constants and variables declaration "
    Const c_RESOURCE_MANAGER = "_DIRECT.frmReAddRM-"

    Private mv_resourceManager As Resources.ResourceManager
    Private mv_strLanguage As String
    Private mv_gridRemiser As GridEx
    Private mv_strDBLinkName As String
    Private mv_strDBLinkDesc As String
    Private mv_strBranchId As String
    Private mv_strTellerId As String
    Private mv_strIpAddress As String
    Private mv_strWsName As String
    Private mv_strBusDate As String = String.Empty
    Private mv_strTellerType As String
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
    Public Property TellerType() As String
        Get
            Return mv_strTellerType
        End Get
        Set(ByVal Value As String)
            mv_strTellerType = Value
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
    Public Property BusDate() As String
        Get
            Return mv_strBusDate
        End Get
        Set(ByVal Value As String)
            mv_strBusDate = Value
        End Set
    End Property
#End Region
    Private Sub InitDialog()
        Try

            AddHandler btnClose.Click, AddressOf Button_Click
            AddHandler btnChange.Click, AddressOf Button_Click
            AddHandler btnSearch.Click, AddressOf Button_Click

            Me.mskReAcctno.BackColor = System.Drawing.Color.GreenYellow
            Me.txbCustodycd.BackColor = System.Drawing.Color.GreenYellow
            'Load resource and user's interface
            ResourceManager = New Resources.ResourceManager(c_RESOURCE_MANAGER & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            LoadUserInterface(Me)
            InitReGrid()
            If Me.mv_gridRemiser.DataRowTemplate.Cells.Count >= 0 Then
                For i As Integer = 0 To Me.mv_gridRemiser.DataRowTemplate.Cells.Count - 1
                    AddHandler mv_gridRemiser.DataRowTemplate.Cells(i).Click, AddressOf Grid_Click
                Next
            End If
            Me.txbCustodycd.Text = AppSettings.Get("PrefixedCustodyCode") & "C"
            Me.ActiveControl = txbCustodycd
        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmReApprove.InitDialog" & vbNewLine _
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
                .Add(New Xceed.Grid.Column("REACCTNO", GetType(System.String)))
                .Add(New Xceed.Grid.Column("REACTYPE", GetType(System.String)))
                .Add(New Xceed.Grid.Column("REROLE", GetType(System.String)))
                .Add(New Xceed.Grid.Column("REROLEDESC", GetType(System.String)))
                .Add(New Xceed.Grid.Column("TYPENAME", GetType(System.String)))
                .Add(New Xceed.Grid.Column("EFFORD", GetType(System.String)))
                .Add(New Xceed.Grid.Column("EFFDAYS", GetType(System.String)))
                .Add(New Xceed.Grid.Column("FRDATE", GetType(System.String)))
                .Add(New Xceed.Grid.Column("TODATE", GetType(System.String)))
            End With
            mv_gridRemiser.Columns("__TICK").Width = 20
            mv_gridRemiser.Columns("__TICK").ReadOnly = True
            mv_gridRemiser.Columns("REACCTNO").ReadOnly = True
            mv_gridRemiser.Columns("REROLE").ReadOnly = True
            mv_gridRemiser.Columns("TYPENAME").ReadOnly = True
            mv_gridRemiser.Columns("EFFORD").ReadOnly = True
            mv_gridRemiser.Columns("EFFDAYS").ReadOnly = True

            mv_gridRemiser.Columns("FRDATE").ReadOnly = False
            mv_gridRemiser.Columns("TODATE").ReadOnly = False

            mv_gridRemiser.Columns("REACTYPE").Visible = False
            mv_gridRemiser.Columns("REROLEDESC").Visible = False


            mv_gridRemiser.Columns("REACCTNO").Title = mv_resourceManager.GetString("REACCTNO")
            mv_gridRemiser.Columns("REROLE").Title = mv_resourceManager.GetString("REROLE")
            mv_gridRemiser.Columns("TYPENAME").Title = mv_resourceManager.GetString("TYPENAME")
            mv_gridRemiser.Columns("EFFORD").Title = mv_resourceManager.GetString("EFFORD")
            mv_gridRemiser.Columns("EFFDAYS").Title = mv_resourceManager.GetString("EFFDAYS")
            mv_gridRemiser.Columns("FRDATE").Title = mv_resourceManager.GetString("FRDATE")
            mv_gridRemiser.Columns("TODATE").Title = mv_resourceManager.GetString("TODATE")


            FillDataToGrid(mv_gridRemiser)
        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmReApprove.InitSecInfoGrid" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub

    Private Sub FillDataToGrid(ByRef pv_gridRemiser As GridEx)
        Try
            Dim v_strSQL As String


            v_strSQL = " Select rl.custid||rd.reactype reacctno,rd.reactype ,  tpy.rerole, a.cdcontent REROLEDESC, tpy.typename, " _
                        & "     rd.efford, rd.effdays, trunc(sysdate) frdate, trunc(sysdate) + rd.effdays todate " _
                        & " From recflnk rl, recfdef rd, retype tpy, allcode a " _
                        & " where rl.autoid = rd.refrecflnkid and rd.reactype=tpy.actype " _
                        & " and a.cdtype='RE' and a.cdname='REROLE' and a.cdval=tpy.rerole and tpy.rerole IN('RM','RD','AE')" _
                        & " and rl.custid = '" & Trim(mskReAcctno.Text) & "'" _
                        & " order by tpy.rerole, rd.efford "



            Dim v_strMsgObj As String = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            'TruongLD Comment when convert
            'v_ws.Timeout = gc_WEB_SERVICE_TIMEOUT
            v_ws.Message(v_strMsgObj)
            'Fill data to grid
            Dim v_xmlDocument As New XmlDocumentEx
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strValue, v_strFLDNAME, v_strFLDTYPE As String
            Dim v_lgDays As Long
            Dim v_frdate, v_todate As Date
            Dim v_role As String = "XXX"

            v_xmlDocument.LoadXml(v_strMsgObj)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            pv_gridRemiser.DataRows.Clear()
            pv_gridRemiser.BeginInit()

            v_frdate = Me.BusDate
            v_lgDays = 0
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

                                If v_strFLDNAME = "REROLE" Then
                                    If v_role <> v_strValue Then
                                        v_role = v_strValue
                                        v_frdate = Me.BusDate
                                        v_lgDays = 0
                                    End If
                                End If

                                If v_strFLDNAME = "EFFDAYS" Then
                                    v_lgDays = CDec(v_strValue)
                                End If
                                If v_strFLDNAME = "FRDATE" Then
                                    v_xDataRow.Cells(v_xColumn.FieldName).Value = v_frdate.ToShortDateString
                                End If
                                If v_strFLDNAME = "TODATE" Then
                                    v_todate = v_frdate.AddDays(v_lgDays)
                                    v_xDataRow.Cells(v_xColumn.FieldName).Value = v_todate.ToShortDateString
                                End If

                                v_xDataRow.EndEdit()
                            End If
                        End With
                    Next ' Duyet tung column cua du lieu
                Next ' duyet tung column cua grid
                v_frdate = v_todate.AddDays(1)
            Next ' duyet tung row cua du lieu
            pv_gridRemiser.EndInit()
            pnlRemiser.Controls.Add(pv_gridRemiser)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub frmReAddDG_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Select Case e.KeyCode
            Case Keys.F5
                If Me.ActiveControl.Name = "mskReAcctno" Then
                    Dim frm As New frmSearch(Me.UserLanguage)
                    frm.TableName = "RECFLNK_RF"
                    frm.ModuleCode = "RE"
                    frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                    frm.IsLocalSearch = gc_IsNotLocalMsg
                    frm.IsLookup = "Y"
                    frm.SearchOnInit = False
                    frm.BranchId = Me.BranchId
                    frm.TellerId = Me.TellerId
                    frm.ShowDialog()
                    Me.ActiveControl.Text = Trim(frm.ReturnValue)
                    If Len(frm.RefValue) > 0 Then
                        lblReName.Text = Trim(frm.RefValue)
                    End If
                    frm.Dispose()
                    FillDataToGrid(mv_gridRemiser)

                ElseIf Me.ActiveControl.Name = "txbCustodycd" Then
                    Dim frm As New frmSearch(Me.UserLanguage)
                    frm.TableName = "CUSTODYCD_CF"
                    frm.ModuleCode = "RE"
                    frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                    frm.IsLocalSearch = gc_IsNotLocalMsg
                    frm.IsLookup = "Y"
                    frm.SearchOnInit = False
                    frm.BranchId = Me.BranchId
                    frm.TellerId = Me.TellerId
                    frm.ShowDialog()
                    Me.ActiveControl.Text = Trim(frm.ReturnValue)
                    If Len(frm.RefValue) > 0 Then
                        lblFullname.Text = Trim(frm.RefValue)
                    End If
                    frm.Dispose()

                End If

        End Select
    End Sub


    Private Sub frmReAddDG_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InitDialog()
    End Sub
    Private Sub OnClose()
        Me.Close()
    End Sub
    Private Function ApproveTran(ByVal pv_strTxNum As String, ByVal pv_strTxDate As String, ByVal pv_strOffName As String) As Long
        Dim v_strTXNUM, v_strTXDATE, v_strTxMsg As String, v_intSTATUS As Integer, v_strOVRRQS, v_strTLTXCD, v_strCHKID, v_strOFFID, v_strDELTD, v_strTLID, v_strOFFNAME As String
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long

        v_strTXNUM = pv_strTxNum 'Trim(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TXNUM").Value)
        v_strTXDATE = pv_strTxDate 'Trim(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TXDATE").Value)
        v_strOFFNAME = pv_strOffName 'Trim(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("OFFNAME").Value)
        'Lấy thông tin chi tiết v? �điện giao dịch
        Dim v_strClause, v_strObjMsg As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery

        Try
            'Lấy thông tin chung v? giao d�ịch. Message trả v? s�ẽ là TxMessage
            v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetMessage", , v_strTXNUM)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            v_intSTATUS = CInt(CType(v_attrColl.GetNamedItem(gc_AtributeSTATUS), Xml.XmlAttribute).Value)
            v_strOVRRQS = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOVRRQS), Xml.XmlAttribute).Value)
            v_strTLTXCD = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLTXCD), Xml.XmlAttribute).Value)
            v_strCHKID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeCHKID), Xml.XmlAttribute).Value)
            v_strOFFID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOFFID), Xml.XmlAttribute).Value)
            v_strDELTD = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeDELTD), Xml.XmlAttribute).Value)
            v_strTLID = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeTLID), Xml.XmlAttribute).Value)
            If v_intSTATUS = TransactStatus.Pending And Trim(v_strDELTD) <> "Y" Then
                'Chỉ cho phép duyệt đối với những giao dịch chưa hoàn tất và 
                If (Len(Trim(Replace(v_strOVRRQS, OVRRQS_CHECKER_CONTROL, vbNullString))) > 0 And Len(v_strCHKID) = 0) _
                    Or (InStr(v_strOVRRQS, OVRRQS_CHECKER_CONTROL) > 0 And Len(v_strOFFID) = 0) Then
                    v_strObjMsg = String.Empty
                    v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , TellerType, "ApproveMessage", , v_strTXNUM)
                    v_lngError = v_ws.Message(v_strObjMsg)
                    If v_lngError <> ERR_SYSTEM_OK Then
                        'Thông báo lỗi
                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Return False
                    End If
                    ' MessageBox.Show(mv_resourceManager.GetString("ApprovedSuccessful"))
                    Return True
                End If

            End If

            Return True
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Private Sub OnChange()

        Dim v_intRow As Integer
        Dim v_strAccList, v_strReAccDone, v_strReAcctno As String
        Dim v_strSQL As String
        Dim v_strTxMsg As String
        v_strAccList = ""
        v_strReAccDone = ""

        For v_intRow = 0 To mv_gridRemiser.DataRows.Count - 1
            If mv_gridRemiser.DataRows(v_intRow).Cells("__TICK").Value = "X" Then
                v_strAccList = v_strAccList & mv_gridRemiser.DataRows(v_intRow).Cells("REACCTNO").Value & "|"
            End If
        Next
        If Len(v_strAccList) > 0 Then
            If MsgBox(mv_resourceManager.GetString("CONFIRM") & v_strAccList & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                Dim v_xmlTxDocument As New XmlDocumentEx
                Dim v_dataElement As Xml.XmlElement
                Dim v_entryNode As Xml.XmlNode
                Dim v_attrFLDNAME As Xml.XmlAttribute, v_attrDATATYPE, v_attrDEFname As Xml.XmlAttribute

                Dim v_xmlDocument As New XmlDocumentEx
                Dim v_nodeList As Xml.XmlNodeList
                Dim v_strValue, v_strFLDNAME, v_strFLDTYPE, v_strDEFname As String
                Dim v_strFIELD As String
                Dim v_lngError As Long
                Dim v_strErrorSource, v_strErrorMessage As String


                v_strSQL = "Select fldname, defname, fldtype from fldmaster where objname='0380' "
                Dim v_strMsgObj As String = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                'TruongLD Comment when convert
                'v_ws.Timeout = gc_WEB_SERVICE_TIMEOUT
                v_ws.Message(v_strMsgObj)

                v_xmlDocument.LoadXml(v_strMsgObj)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                For v_intRow = 0 To mv_gridRemiser.DataRows.Count - 1
                    If mv_gridRemiser.DataRows(v_intRow).Cells("__TICK").Value = "X" Then
                        'Duyet tung dong grid, moi dong build mot giao dich

                        v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, "0380", Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)
                        v_xmlTxDocument.LoadXml(v_strTxMsg)
                        v_dataElement = v_xmlTxDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")
                        ' Duyet tung truong cua giao dich 0380 
                        For i As Integer = 0 To v_nodeList.Count - 1
                            v_strFLDNAME = v_nodeList.Item(i).ChildNodes(0).InnerText.ToString
                            v_strDEFname = v_nodeList.Item(i).ChildNodes(1).InnerText.ToString
                            v_strFLDTYPE = v_nodeList.Item(i).ChildNodes(2).InnerText.ToString
                            v_strValue = ""
                            Select Case Trim(v_strDEFname)
                                Case "CUSTODYCD"
                                    v_strValue = txbCustodycd.Text
                                Case "ACCTNO"
                                    v_strValue = cboAFACCTNO.SelectedValue 'cboAFACCTNO.Text.Substring(0, 10)
                                Case "CUSTNAME"
                                    v_strValue = lblFullname.Text
                                Case "FRDATE"
                                    v_strValue = mv_gridRemiser.DataRows(v_intRow).Cells("FRDATE").Value
                                Case "TODATE"
                                    v_strValue = mv_gridRemiser.DataRows(v_intRow).Cells("TODATE").Value
                                Case "AMT"
                                    v_strValue = 0
                                Case "REACCTNO"
                                    v_strValue = mv_gridRemiser.DataRows(v_intRow).Cells("REACCTNO").Value
                                    v_strReAcctno = v_strValue
                                Case "RECUSTNAME"
                                    v_strValue = lblReName.Text
                                Case "REROLE"
                                    v_strValue = mv_gridRemiser.DataRows(v_intRow).Cells("REROLE").Value
                                Case "FUREACCTNO"
                                    v_strValue = ""
                                Case "REACTYPE"
                                    v_strValue = mv_gridRemiser.DataRows(v_intRow).Cells("REACTYPE").Value
                                Case "RECUSTID"
                                    v_strValue = Trim(mskReAcctno.Text.Replace(".", ""))
                                Case "FURECUSTID"
                                    v_strValue = ""
                                Case "FUREACTYPE"
                                    v_strValue = ""
                                Case "T_DESC"
                                    v_strValue = "Gán môi giới " & mv_gridRemiser.DataRows(v_intRow).Cells("REROLEDESC").Value
                            End Select
                            'Append entry to data node
                            v_entryNode = v_xmlTxDocument.CreateNode(Xml.XmlNodeType.Element, "entry", "")

                            'Add field name
                            v_attrFLDNAME = v_xmlTxDocument.CreateAttribute(gc_AtributeFLDNAME)
                            v_attrFLDNAME.Value = v_strFLDNAME
                            v_entryNode.Attributes.Append(v_attrFLDNAME)

                            'Add field type
                            v_attrDATATYPE = v_xmlTxDocument.CreateAttribute(gc_AtributeFLDTYPE)
                            v_attrDATATYPE.Value = v_strFLDTYPE
                            v_entryNode.Attributes.Append(v_attrDATATYPE)

                            'Add defname
                            v_attrDEFname = v_xmlTxDocument.CreateAttribute(gc_AtributeDEFNAME)
                            v_attrDEFname.Value = v_strDEFname
                            v_entryNode.Attributes.Append(v_attrDEFname)


                            'Set value
                            v_entryNode.InnerText = v_strValue

                            v_dataElement.AppendChild(v_entryNode)

                            v_xmlTxDocument.DocumentElement.AppendChild(v_dataElement)

                        Next ' For i
                        v_strTxMsg = v_xmlTxDocument.InnerXml

                        v_lngError = v_ws.Message(v_strTxMsg)
                        If v_lngError <> ERR_SYSTEM_OK And v_lngError <> ERR_SA_CHECKER1_OVR And v_lngError <> ERR_SA_CHECKER2_OVR Then
                            'Thông báo lỗi
                            GetErrorFromMessage(v_strTxMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                            Cursor.Current = Cursors.Default
                            MessageBox.Show(v_strErrorMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            For J As Integer = 0 To mv_gridRemiser.DataRows.Count - 1
                                If mv_gridRemiser.DataRows(J).Cells("__TICK").Value = "X" _
                                 And v_strReAccDone.IndexOf(mv_gridRemiser.DataRows(J).Cells("REACCTNO").Value) > 0 Then
                                    mv_gridRemiser.DataRows(J).Cells("__TICK").Value = "V"

                                End If
                            Next
                            Me.Cursor = Cursors.Default
                            Return
                        ElseIf v_lngError = ERR_SA_CHECKER1_OVR Or v_lngError = ERR_SA_CHECKER2_OVR Then
                            v_lngError = v_ws.Message(v_strTxMsg)
                            If v_lngError <> ERR_SYSTEM_OK And v_lngError <> ERR_SA_CHECKER1_OVR And v_lngError <> ERR_SA_CHECKER2_OVR Then
                                'Thông báo lỗi
                                GetErrorFromMessage(v_strTxMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                                Cursor.Current = Cursors.Default
                                MessageBox.Show(v_strErrorMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                For J As Integer = 0 To mv_gridRemiser.DataRows.Count - 1
                                    If mv_gridRemiser.DataRows(J).Cells("__TICK").Value = "X" _
                                     And v_strReAccDone.IndexOf(mv_gridRemiser.DataRows(J).Cells("REACCTNO").Value) > 0 Then
                                        mv_gridRemiser.DataRows(J).Cells("__TICK").Value = "V"

                                    End If
                                Next
                                Me.Cursor = Cursors.Default
                                Return
                            Else
                                v_strReAccDone = v_strReAccDone & "|" & v_strReAcctno
                            End If
                        End If

                    End If ' if ("__TICK").Value = "X" _
                Next ' Duyet tung dong  v_intRow = 0 To mv_gridRemiser.DataRows.Count - 1
                MsgBox(mv_resourceManager.GetString("DONE"), MsgBoxStyle.Information, Me.Text)
                For J As Integer = 0 To mv_gridRemiser.DataRows.Count - 1
                    If mv_gridRemiser.DataRows(J).Cells("__TICK").Value = "X" _
                     And v_strReAccDone.IndexOf(mv_gridRemiser.DataRows(J).Cells("REACCTNO").Value) > 0 Then
                        mv_gridRemiser.DataRows(J).Cells("__TICK").Value = "V"

                    End If
                Next
                Me.Cursor = Cursors.Default
            End If ' Confirm thuc hien
        End If 'Len(v_strAccList) > 0

    End Sub
    Private Sub Button_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If (sender Is btnClose) Then
            OnClose()
        ElseIf (sender Is btnChange) Then
            onchange()
        ElseIf (sender Is btnSearch) Then
            FillDataToGrid(mv_gridRemiser)
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







    Private Sub txbCustodycd_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txbCustodycd.Validating
        Try
            Dim v_strCMDSQL, v_strObjMsg As String
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
            Me.txbCustodycd.Text = Me.txbCustodycd.Text.ToUpper()

            'Lay thong tin tieu khoan
            v_strCMDSQL = "SELECT FILTERCD, VALUE, VALUECD, DISPLAY || ' - ' || DESCRIPTION DISPLAY, EN_DISPLAY || ' - ' || DESCRIPTION EN_DISPLAY, DESCRIPTION " & ControlChars.CrLf _
                        & "FROM VW_CUSTODYCD_SUBACCOUNT_ACTIVE WHERE FILTERCD='" & Trim(Me.txbCustodycd.Text) & "' ORDER BY VALUE"

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCMDSQL)
            v_ws.Message(v_strObjMsg)
            FillComboEx(v_strObjMsg, Me.cboAFACCTNO, "", Me.UserLanguage)
            If Me.cboAFACCTNO.Items.Count > 0 Then
                Me.cboAFACCTNO.SelectedIndex = 0
                'Lấy thông tin
            Else
                MsgBox(mv_resourceManager.GetString("ERR_CF_CONTRACT_NOT_FOUND"), MsgBoxStyle.Information, Me.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub

   
    Private Sub mskReAcctno_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskReAcctno.Leave
        FillDataToGrid(mv_gridRemiser)
    End Sub
End Class