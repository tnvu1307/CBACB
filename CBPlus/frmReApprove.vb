Imports System.Windows.Forms
Imports CommonLibrary
Imports AppCore
Imports System.IO

Public Class frmReApprove
    Inherits System.Windows.Forms.Form
#Region " Constants and variables declaration "
    Const c_RESOURCE_MANAGER = "_DIRECT.frmReApprove-"

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
            AddHandler btnCancel.Click, AddressOf Button_Click
            AddHandler btnClose.Click, AddressOf Button_Click
            AddHandler btnChange.Click, AddressOf Button_Click
            AddHandler btnSearch.Click, AddressOf Button_Click

           
           


            'Load resource and user's interface
            ResourceManager = New Resources.ResourceManager(c_RESOURCE_MANAGER & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            LoadUserInterface(Me)
            InitReGrid()
            If Me.mv_gridRemiser.DataRowTemplate.Cells.Count >= 0 Then
                For i As Integer = 0 To Me.mv_gridRemiser.DataRowTemplate.Cells.Count - 1
                    AddHandler mv_gridRemiser.DataRowTemplate.Cells(i).Click, AddressOf Grid_Click
                    AddHandler mv_gridRemiser.DataRowTemplate.Cells(i).DoubleClick, AddressOf Grid_DblClick
                Next
            End If

            

            Me.ActiveControl = txtSearch
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
                .Add(New Xceed.Grid.Column("TXNUM", GetType(System.String)))
                .Add(New Xceed.Grid.Column("TXDATE", GetType(System.String)))
                .Add(New Xceed.Grid.Column("CUSTODYCD", GetType(System.String)))
                .Add(New Xceed.Grid.Column("ACCTNO", GetType(System.String)))
                .Add(New Xceed.Grid.Column("CFNAME", GetType(System.String)))
                .Add(New Xceed.Grid.Column("FRDATE", GetType(System.String)))
                .Add(New Xceed.Grid.Column("TODATE", GetType(System.String)))
                .Add(New Xceed.Grid.Column("REACCTNO", GetType(System.String)))
                .Add(New Xceed.Grid.Column("REMISERNAME", GetType(System.String)))
                .Add(New Xceed.Grid.Column("REROLE", GetType(System.String)))
                .Add(New Xceed.Grid.Column("TXDESC", GetType(System.String)))
                
            End With
            mv_gridRemiser.Columns("__TICK").Width = 20
            mv_gridRemiser.Columns("__TICK").ReadOnly = True

            mv_gridRemiser.Columns("TXNUM").ReadOnly = True
            mv_gridRemiser.Columns("TXDATE").ReadOnly = True
            mv_gridRemiser.Columns("CUSTODYCD").ReadOnly = True
            mv_gridRemiser.Columns("ACCTNO").ReadOnly = True
            mv_gridRemiser.Columns("CFNAME").ReadOnly = True
            mv_gridRemiser.Columns("CFNAME").Width = 200
            mv_gridRemiser.Columns("FRDATE").ReadOnly = True
            mv_gridRemiser.Columns("TODATE").ReadOnly = True
            mv_gridRemiser.Columns("REACCTNO").ReadOnly = True
            mv_gridRemiser.Columns("REMISERNAME").ReadOnly = True
            mv_gridRemiser.Columns("REMISERNAME").Width = 200
            mv_gridRemiser.Columns("REROLE").ReadOnly = True
            mv_gridRemiser.Columns("TXDESC").ReadOnly = True

            

            mv_gridRemiser.Columns("TXNUM").Title = mv_resourceManager.GetString("TXNUM")
            mv_gridRemiser.Columns("TXDATE").Title = mv_resourceManager.GetString("TXDATE")
            mv_gridRemiser.Columns("CUSTODYCD").Title = mv_resourceManager.GetString("CUSTODYCD")
            mv_gridRemiser.Columns("ACCTNO").Title = mv_resourceManager.GetString("ACCTNO")
            mv_gridRemiser.Columns("CFNAME").Title = mv_resourceManager.GetString("CFNAME")
            mv_gridRemiser.Columns("FRDATE").Title = mv_resourceManager.GetString("FRDATE")
            mv_gridRemiser.Columns("TODATE").Title = mv_resourceManager.GetString("TODATE")
            mv_gridRemiser.Columns("REACCTNO").Title = mv_resourceManager.GetString("REACCTNO")
            mv_gridRemiser.Columns("REMISERNAME").Title = mv_resourceManager.GetString("REMISERNAME")
            mv_gridRemiser.Columns("REROLE").Title = mv_resourceManager.GetString("REROLE")
            mv_gridRemiser.Columns("TXDESC").Title = mv_resourceManager.GetString("TXDESC")



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
            Dim v_where As String
            v_where = " "
            If txtSearch.Text.Length > 0 Then
                v_where = " and (tl.CFCUSTODYCD like '%" & txtSearch.Text & "%' or TL.MSGACCT like '%" & txtSearch.Text & "%' or upper(TLD.CFNAME) like upper('%" & txtSearch.Text & "%') or TLD.REACCTNO like '%" & txtSearch.Text & "%' or upper(TLD.REMISERNAME) like upper('%" & txtSearch.Text & "%')  ) "
            End If

            v_strSQL = " SELECT TL.TXNUM,TL.TXDATE,TL.CFCUSTODYCD CUSTODYCD,TL.MSGACCT ACCTNO, " _
                     & " TLD.CFNAME, TLD.FRDATE, TLD.TODATE,TLD.REACCTNO,TLD.REMISERNAME,A1.cdcontent REROLE,TLD.TXDESC " _
                     & "  FROM TLLOG TL, ALLCODE A1, " _
                        & " ( SELECT TXNUM,TXDATE, " _
                        & "        MAX(CFNAME) CFNAME,MAX(FRDATE) FRDATE,MAX(TODATE) TODATE,MAX(REACCTNO) REACCTNO, " _
                        & "       MAX(REMISERNAME) REMISERNAME,MAX(REROLE) REROLE, MAX(TXDESC) TXDESC " _
                        & "  FROM( " _
                        & "       SELECT TXNUM,TXDATE, " _
                        & "              DECODE(FLDCD,'90',CVALUE,'') CFNAME, " _
                        & "              DECODE(FLDCD,'05',CVALUE,'') FRDATE, " _
                        & "              DECODE(FLDCD,'06',CVALUE,'') TODATE, " _
                        & "              DECODE(FLDCD,'08',CVALUE,'') REACCTNO, " _
                        & "              DECODE(FLDCD,'91',CVALUE,'') REMISERNAME, " _
                        & "              DECODE(FLDCD,'09',CVALUE,'') REROLE, " _
                        & "              DECODE(FLDCD,'30',CVALUE,'') TXDESC " _
                        & "         FROM TLLOGFLD  " _
                        & "         WHERE FLDCD IN('90','05','06','08','91','09','30') " _
                        & "          ) " _
                        & " GROUP BY TXNUM,TXDATE)TLD  " _
                        & "  WHERE TL.TLTXCD in('0380','0381') AND TL.TXSTATUS='4' and tl.deltd<>'Y' " _
                        & "   AND TL.TXNUM=TLD.TXNUM   AND TL.TXDATE=TLD.TXDATE " _
                        & "   AND A1.CDTYPE='RE' AND A1.CDNAME='REROLE' AND A1.CDVAL=TLD.REROLE  " & v_where _
                        & "  order by tl.txnum"



            Dim v_strMsgObj As String = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_TLLOG, gc_ActionInquiry, v_strSQL)
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

    Private Sub frmReAddDG_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Select Case e.KeyCode
            Case Keys.Enter
                If Me.ActiveControl.Name = "txtSearch" Then
                    FillDataToGrid(mv_gridRemiser)
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
    Private Sub onchange()

        Dim v_intRow As Integer
        Dim v_strAccList As String
        Dim v_strTxnum, v_strTxdate As String
        Dim v_blProccess As Boolean = False
        v_strAccList = ""
        Me.Cursor = Cursors.WaitCursor
        For v_intRow = 0 To mv_gridRemiser.DataRows.Count - 1
            If mv_gridRemiser.DataRows(v_intRow).Cells("__TICK").Value = "X" Then
                v_strAccList = v_strAccList & mv_gridRemiser.DataRows(v_intRow).Cells("ACCTNO").Value & "|"
                v_strTxnum = Trim(mv_gridRemiser.DataRows(v_intRow).Cells("TXNUM").Value)
                v_strTxdate = Trim(mv_gridRemiser.DataRows(v_intRow).Cells("TXDATE").Value)
                v_blProccess = ApproveTran(v_strTxnum, v_strTxdate, v_blProccess)
                If v_blProccess = False Then
                    Me.Cursor = Cursors.Default
                    Return

                Else
                    mv_gridRemiser.DataRows(v_intRow).Cells("__TICK").Value = String.Empty
                End If
            End If
        Next
        FillDataToGrid(mv_gridRemiser)
        Me.Cursor = Cursors.Default

    End Sub
    Private Function RefuseTran(ByVal pv_strTxNum As String, ByVal pv_strTxDate As String, ByVal pv_strOffName As String) As Long
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
                'Chỉ cho phép duyệt đối với những giao dịch chưa hoàn tất và 
                If (Len(Trim(Replace(v_strOVRRQS, OVRRQS_CHECKER_CONTROL, vbNullString))) > 0 And Len(v_strCHKID) = 0) _
                    Or (InStr(v_strOVRRQS, OVRRQS_CHECKER_CONTROL) > 0 And Len(v_strOFFID) = 0) Then
                    v_strObjMsg = String.Empty
                    v_strObjMsg = BuildXMLObjMsg(v_strTXDATE, Me.BranchId, , Me.TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , TellerType, "RefuseMessage", , v_strTXNUM)
                    v_lngError = v_ws.Message(v_strObjMsg)
                    If v_lngError <> ERR_SYSTEM_OK Then
                        'Thông báo lỗi
                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Return False
                    Else
                        Return True
                    End If

                End If

            End If

            Return True
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Private Sub OnCancel()

        Dim v_intRow As Integer
        Dim v_strAccList As String
        Dim v_strTxnum, v_strTxdate As String
        Dim v_blProccess As Boolean = False
        v_strAccList = ""

        For v_intRow = 0 To mv_gridRemiser.DataRows.Count - 1
            If mv_gridRemiser.DataRows(v_intRow).Cells("__TICK").Value = "X" Then
                v_strAccList = v_strAccList & mv_gridRemiser.DataRows(v_intRow).Cells("ACCTNO").Value & "|"
                v_strTxnum = Trim(mv_gridRemiser.DataRows(v_intRow).Cells("TXNUM").Value)
                v_strTxdate = Trim(mv_gridRemiser.DataRows(v_intRow).Cells("TXDATE").Value)
                v_blProccess = RefuseTran(v_strTxnum, v_strTxdate, v_blProccess)
                If v_blProccess = False Then
                    Return

                Else
                    mv_gridRemiser.DataRows(v_intRow).Cells("__TICK").Value = String.Empty
                End If
            End If
        Next
        FillDataToGrid(mv_gridRemiser)

    End Sub
    Private Sub Button_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If (sender Is btnCancel) Then
            OnCancel()
        ElseIf (sender Is btnChange) Then
            onchange()
        ElseIf (sender Is btnClose) Then
            OnClose()
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
    Protected Overridable Function OnView() As Int32
        Try
            'Lấy TXDATE và TXNUM
            Dim v_strTXNUM, v_strTXDATE, v_strNextTXNUM, v_strNextTXDATE, v_strTLTXCD As String
            Dim v_strDeltd As String

            If Not (mv_gridRemiser.CurrentRow Is Nothing) Then
                v_strTXNUM = Trim(CType(mv_gridRemiser.CurrentRow, Xceed.Grid.DataRow).Cells("TXNUM").Value)
                v_strTXDATE = Trim(CType(mv_gridRemiser.CurrentRow, Xceed.Grid.DataRow).Cells("TXDATE").Value)
                v_strTLTXCD = "0380"

                'Hiển thị lên màn hình giao dịch
                Dim frm As New frmTransactMaster(UserLanguage)
                frm.LocalObject = gc_IsNotLocalMsg
                frm.ObjectName = ""
                frm.TxDate = v_strTXDATE
                frm.TxNum = v_strTXNUM
                frm.BusDate = Me.BusDate
                frm.TellerType = Me.TellerType
                frm.BranchId = Me.BranchId
                frm.TellerId = Me.TellerId
                frm.ShowDialog()

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Private Sub Grid_DblClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            OnView()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
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