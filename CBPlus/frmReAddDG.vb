Imports System.Windows.Forms
Imports CommonLibrary
Imports AppCore
Imports System.IO

Public Class frmReAddDG
    Inherits System.Windows.Forms.Form
#Region " Constants and variables declaration "
    Const c_RESOURCE_MANAGER = "_DIRECT.frmReAddDG-"

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

            AddHandler btnChange.Click, AddressOf Button_Click
            Me.mskReAcctno.BackColor = System.Drawing.Color.GreenYellow
            Me.mskReAcctno.Mask = "9999.999999"
            Me.mskReDG.BackColor = System.Drawing.Color.GreenYellow
            Me.mskReDG.Mask = "9999.999999.9999"

            Me.mskReCarebyDG.BackColor = System.Drawing.Color.GreenYellow
            Me.mskReCarebyDG.Mask = "9999"
            'Load resource and user's interface
            ResourceManager = New Resources.ResourceManager(c_RESOURCE_MANAGER & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            LoadUserInterface(Me)
            InitReGrid()
            If Me.mv_gridRemiser.DataRowTemplate.Cells.Count >= 0 Then
                For i As Integer = 0 To Me.mv_gridRemiser.DataRowTemplate.Cells.Count - 1
                    AddHandler mv_gridRemiser.DataRowTemplate.Cells(i).Click, AddressOf Grid_Click
                Next
            End If

            dtpFromDate.Value = Me.BusDate
            dtpToDate.Value = Me.BusDate
            Me.ActiveControl = mskReAcctno
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
                .Add(New Xceed.Grid.Column("AUTOID", GetType(System.String)))
                .Add(New Xceed.Grid.Column("__TICK", GetType(System.String)))
                .Add(New Xceed.Grid.Column("CUSTODYCD", GetType(System.String)))
                .Add(New Xceed.Grid.Column("ACCTNO", GetType(System.String)))
                .Add(New Xceed.Grid.Column("FULLNAME", GetType(System.String)))
                .Add(New Xceed.Grid.Column("REACCTNO", GetType(System.String)))
                .Add(New Xceed.Grid.Column("FRDATE", GetType(System.String)))
                .Add(New Xceed.Grid.Column("TODATE", GetType(System.String)))
            End With
            mv_gridRemiser.Columns("AUTOID").Visible = False
            mv_gridRemiser.Columns("ACCTNO").Visible = False
            mv_gridRemiser.Columns("__TICK").Width = 20
            mv_gridRemiser.Columns("__TICK").ReadOnly = True

            mv_gridRemiser.Columns("CUSTODYCD").ReadOnly = True
            mv_gridRemiser.Columns("ACCTNO").ReadOnly = True
            mv_gridRemiser.Columns("FULLNAME").Width = 200
            mv_gridRemiser.Columns("FULLNAME").ReadOnly = True
            mv_gridRemiser.Columns("REACCTNO").ReadOnly = True
            mv_gridRemiser.Columns("FRDATE").ReadOnly = True
            mv_gridRemiser.Columns("TODATE").ReadOnly = True



            mv_gridRemiser.Columns("CUSTODYCD").Title = mv_resourceManager.GetString("CUSTODYCD")
            mv_gridRemiser.Columns("FULLNAME").Title = mv_resourceManager.GetString("FULLNAME")
            mv_gridRemiser.Columns("ACCTNO").Title = mv_resourceManager.GetString("ACCTNO")
            mv_gridRemiser.Columns("REACCTNO").Title = mv_resourceManager.GetString("REACCTNO")
            mv_gridRemiser.Columns("FRDATE").Title = mv_resourceManager.GetString("FRDATE")
            mv_gridRemiser.Columns("TODATE").Title = mv_resourceManager.GetString("TODATE")

            pnlRemiser.Controls.Add(mv_gridRemiser)

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
            If Not txtSearch.Text Is Nothing Then
                v_where = " and (cf.custodycd like '%" & txtSearch.Text & "%' or upper(cf.fullname) like upper('%" & txtSearch.Text & "%') ) "
            End If

            If Len(mskReAcctno.Text) > 0 Then
                v_strSQL = "select RA.AUTOID, cf.custodycd, cf.custid, cf.fullname,ra.reacctno ,TO_CHAR(ra.frdate,'DD/MM/YYYY') FRDATE, TO_CHAR(ra.todate,'DD/MM/YYYY') TODATE " _
                           & " from reaflnk ra, cfmast cf , RETYPE RTY" _
                            & " where cf.custid=ra.afacctno and ra.status='A' AND SUBSTR(ra.reacctno,11,4) = RTY.actype AND RTY.RETYPE='D'  " _
                            & " and substr(ra.reacctno,1,10) like '" & mskReAcctno.Text.Replace(".", "").Trim & "'" & v_where _
                            & "and not  exists (select afacctno from reaflnk r, retype tpy where r.afacctno=cf.custid " _
                            & "and r.status='A'and SUBSTR (r.reacctno, 11, 4) = tpy.actype and tpy.rerole='DG' and tpy.retype='D') " _
                            & " order by cf.custodycd "



                Dim v_strMsgObj As String = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
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
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function GetDescType(ByVal thisMsK As System.Windows.Forms.MaskedTextBox, ByVal pv_strCheckAcct As String) As String
        Try
            Dim v_strSQL As String
            Dim v_strCDCONTENT, v_strFLDNAME, v_strVALUE, v_strCmdInquiry, v_strObjMsg As String
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_intCount, v_int As Integer
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strDescType As String
            Dim v_strREAcctno As String
            v_strREAcctno = Replace(thisMsK.Text, ".", "").Trim()
            v_strSQL = "SELECT max(CFMAST.FULLNAME) DESC_TYPE" _
                        & " FROM RECFDEF RF, RETYPE TYP, ALLCODE A0, ALLCODE A1, ALLCODE A2, RECFLNK CF, CFMAST" _
                        & " WHERE A0.CDTYPE='RE' AND A0.CDNAME='REROLE' AND A0.CDVAL=TYP.REROLE" _
                        & " AND A2.CDTYPE = 'RE' AND A2.CDNAME = 'AFSTATUS' AND A2.CDVAL = TYP.AFSTATUS" _
                        & " AND A1.CDTYPE='RE' AND A1.CDNAME='RETYPE' AND A1.CDVAL=TYP.RETYPE" _
                        & " AND nvl(RF.STATUS,'A') = 'A' AND RF.REACTYPE=TYP.ACTYPE" _
                        & " AND RF.REFRECFLNKID = CF.AUTOID" _
                        & " AND CF.CUSTID = CFMAST.CUSTID" _
                        & " AND CF.CUSTID = '" & v_strREAcctno & "' "

            v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")


            If v_nodeList.Count = 0 And pv_strCheckAcct = "Y" And v_strREAcctno <> "" Then
                MsgBox(mv_resourceManager.GetString("INVALREACCOUNT"), MsgBoxStyle.Information, Me.Text)
                thisMsK.Focus()
                Return ""
            Else


                For v_intCount = 0 To v_nodeList.Count - 1
                    For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                        With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                            v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                            v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()
                            Select Case v_strFLDNAME
                                Case "DESC_TYPE"
                                    v_strDescType = v_strVALUE
                            End Select
                        End With
                    Next
                Next
            End If
            Return v_strDescType
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GetDGDescType(ByVal thisMsK As System.Windows.Forms.MaskedTextBox, ByVal pv_strCheckAcct As String) As String
        Try
            Dim v_strSQL As String
            Dim v_strCDCONTENT, v_strFLDNAME, v_strVALUE, v_strCmdInquiry, v_strObjMsg As String
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_intCount, v_int As Integer
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strDescType As String
            Dim v_strREAcctno As String
            v_strREAcctno = Replace(thisMsK.Text, ".", "").Trim()
            v_strSQL = "SELECT (CFMAST.FULLNAME) DESC_TYPE" _
                        & " FROM RECFDEF RF, RETYPE TYP, ALLCODE A0, ALLCODE A1, ALLCODE A2, RECFLNK CF, CFMAST" _
                        & " WHERE A0.CDTYPE='RE' AND A0.CDNAME='REROLE' AND A0.CDVAL=TYP.REROLE" _
                        & " AND A2.CDTYPE = 'RE' AND A2.CDNAME = 'AFSTATUS' AND A2.CDVAL = TYP.AFSTATUS" _
                        & " AND A1.CDTYPE='RE' AND A1.CDNAME='RETYPE' AND A1.CDVAL=TYP.RETYPE" _
                        & " AND nvl(RF.STATUS,'A')='A' AND TYP.REROLE='DG' AND RF.REACTYPE=TYP.ACTYPE" _
                        & " AND RF.REFRECFLNKID = CF.AUTOID" _
                        & " AND CF.CUSTID = CFMAST.CUSTID" _
                        & " AND CF.CUSTID||RF.REACTYPE = '" & v_strREAcctno & "' "

            v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")


            If v_nodeList.Count = 0 And pv_strCheckAcct = "Y" And v_strREAcctno <> "" Then
                MsgBox(mv_resourceManager.GetString("INVALREACCOUNT"), MsgBoxStyle.Information, Me.Text)
                thisMsK.Focus()
                Return ""
            Else


                For v_intCount = 0 To v_nodeList.Count - 1
                    For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                        With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                            v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                            v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()
                            Select Case v_strFLDNAME
                                Case "DESC_TYPE"
                                    v_strDescType = v_strVALUE
                            End Select
                        End With
                    Next
                Next
            End If
            Return v_strDescType
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GetCarebyDescType(ByVal thisMsK As System.Windows.Forms.MaskedTextBox, ByVal pv_strCheckAcct As String) As String
        Try
            Dim v_strSQL As String
            Dim v_strCDCONTENT, v_strFLDNAME, v_strVALUE, v_strCmdInquiry, v_strObjMsg As String
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_intCount, v_int As Integer
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strDescType As String
            Dim v_strCareby As String
            v_strCareby = thisMsK.Text.Trim()
            v_strSQL = "SELECT GRPID, GRPNAME, DESCRIPTION FROM TLGROUPS WHERE GRPID =  '" & v_strCareby & "' "

            v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")


            If v_nodeList.Count = 0 And pv_strCheckAcct = "Y" And v_strCareby <> "" Then
                MsgBox(mv_resourceManager.GetString("INVALCAREBY"), MsgBoxStyle.Information, Me.Text)
                thisMsK.Focus()
                Return ""
            Else


                For v_intCount = 0 To v_nodeList.Count - 1
                    For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                        With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                            v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                            v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()
                            Select Case v_strFLDNAME
                                Case "GRPNAME"
                                    v_strDescType = v_strVALUE
                            End Select
                        End With
                    Next
                Next
            End If
            Return v_strDescType
        Catch ex As Exception
            Throw ex
        End Try
    End Function

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

                ElseIf Me.ActiveControl.Name = "mskReDG" Then
                    Dim frm As New frmSearch(Me.UserLanguage)
                    frm.TableName = "RECFDEF_DG"
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
                        lblDGname.Text = Trim(frm.RefValue)
                    End If
                    frm.Dispose()

                    '19/08/2015 DieuNDA: Them truong care by cho cham soc ho
                ElseIf Me.ActiveControl.Name = "mskReCarebyDG" Then
                    Dim frm As New frmSearch(Me.UserLanguage)
                    frm.TableName = "TLGROUPS"
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
                        lblDGCarebyname.Text = Trim(frm.RefValue)
                    End If
                    frm.Dispose()
                End If
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
    Private Sub onchange()

        Dim v_intRow As Integer
        Dim V_AutoIdList, v_strAccList, v_strAccDone, v_strAcctno, v_accdone_str As String
        Dim v_strCUSTODYCD, v_strCUSTNAME, v_strDAYSFUTURE, v_strAMT, v_strREROLE, v_strEXPDATE, v_strREACCTNONEW As String
        Dim v_strSQL As String
        Dim v_strTxMsg As String
        v_strAccList = ""
        v_strAccDone = ""
        V_AutoIdList = ""

        For v_intRow = 0 To mv_gridRemiser.DataRows.Count - 1
            If mv_gridRemiser.DataRows(v_intRow).Cells("__TICK").Value = "X" Then
                v_strAccList = v_strAccList & mv_gridRemiser.DataRows(v_intRow).Cells("CUSTODYCD").Value & "|"
                V_AutoIdList = V_AutoIdList & mv_gridRemiser.DataRows(v_intRow).Cells("AUTOID").Value & "|"
            End If
        Next
        If Len(v_strAccList) > 0 Then
            If MsgBox(mv_resourceManager.GetString("CONFIRM") & v_strAccList & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                v_strSQL = "select NULL REACCTNONEW,to_date('01/01/2099','DD/MM/RRRR') EXPDATE,0 DAYSFUTURE,cf.CUSTODYCD, af.ACCTNO,cf.fullname CUSTNAME, " _
                        & " GREATEST(RA.FRDATE, TO_DATE('" & dtpFromDate.Value & "','DD/MM/YYYY')) FRDATE, " _
                        & " LEAST(RA.TODATE,TO_DATE('" & dtpToDate.Value & "','DD/MM/YYYY')) TODATE, " _
                        & " 0 AMT , '' REACCTNO ,'' RECUSTNAME,'DG' REROLE, '' REACTYPE, '' RECUSTID, " _
                        & " '' T_DESC, RA.reacctno ORGREACCTNO, '' CAREBY" _
                           & " from reaflnk ra,cfmast cf , RETYPE RTY, (select custid, max(acctno) acctno from afmast group by custid) af " _
                            & " where cf.custid = ra.afacctno and cf.custid = af.custid and ra.status='A' AND SUBSTR(ra.reacctno,11,4) = RTY.actype AND RTY.RETYPE='D' AND RTY.REROLE IN('BM','RM') " _
                            & " and substr(ra.reacctno,1,10)= '" & mskReAcctno.Text.Replace(".", "") & "'" _
                            & " and instr('" & V_AutoIdList & "',ra.AUTOID) >0 " _
                            & " order by cf.custodycd "



                Dim v_strMsgObj As String = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SE_SBSECURITIES, gc_ActionInquiry, v_strSQL)
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                'TruongLD Comment when convert
                'v_ws.Timeout = gc_WEB_SERVICE_TIMEOUT
                v_ws.Message(v_strMsgObj)
                'Fill data to grid
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


                v_xmlDocument.LoadXml(v_strMsgObj)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                For i As Integer = 0 To v_nodeList.Count - 1
                    'Duyet tung dong, moi dong build mot giao dich

                    v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, "0380", Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)
                    v_xmlTxDocument.LoadXml(v_strTxMsg)
                    v_dataElement = v_xmlTxDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")
                    ' Duyet tung column 
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = .InnerText.ToString
                            v_strDEFname = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strFLDTYPE = CStr(CType(.Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)

                            v_strFLDNAME = ""
                            Select Case Trim(v_strDEFname)
                                Case "CUSTODYCD"
                                    v_strFLDNAME = "88"
                                    v_strFLDTYPE = "C"
                                    v_strCUSTODYCD = v_strValue
                                Case "ACCTNO"
                                    v_strFLDNAME = "03"
                                    v_strFLDTYPE = "C"
                                    v_strAcctno = v_strValue
                                Case "CUSTNAME"
                                    v_strFLDNAME = "90"
                                    v_strFLDTYPE = "C"
                                    v_strCUSTNAME = v_strValue
                                Case "DAYSFUTURE"
                                    v_strFLDNAME = "12"
                                    v_strFLDTYPE = "N"
                                    v_strDAYSFUTURE = v_strValue
                                Case "FRDATE"
                                    v_strFLDNAME = "05"
                                    v_strFLDTYPE = "D"
                                    v_strValue = dtpFromDate.Value
                                Case "TODATE"
                                    v_strFLDNAME = "06"
                                    v_strFLDTYPE = "D"
                                    v_strValue = dtpToDate.Value
                                Case "AMT"
                                    v_strFLDNAME = "10"
                                    v_strFLDTYPE = "N"
                                    v_strAMT = v_strValue
                                Case "REACCTNO"
                                    v_strFLDNAME = "08"
                                    v_strFLDTYPE = "C"
                                    v_strValue = mskReDG.Text.Replace(".", "").Replace(" ", "")
                                Case "RECUSTNAME"
                                    v_strFLDNAME = "91"
                                    v_strFLDTYPE = "C"
                                    v_strValue = lblDGname.Text
                                Case "REROLE"
                                    v_strFLDNAME = "09"
                                    v_strFLDTYPE = "C"
                                    v_strREROLE = v_strValue
                                Case "EXPDATE"
                                    v_strFLDNAME = "13"
                                    v_strFLDTYPE = "D"
                                    v_strEXPDATE = v_strValue
                                Case "REACCTNONEW"
                                    v_strFLDNAME = "11"
                                    v_strFLDTYPE = "C"
                                    v_strREACCTNONEW = v_strValue
                                Case "REACTYPE"
                                    v_strFLDNAME = "07"
                                    v_strFLDTYPE = "C"
                                    v_strValue = mskReDG.Text.Replace(".", "").Replace(" ", "").Substring(10, 4)
                                Case "RECUSTID"
                                    v_strFLDNAME = "02"
                                    v_strFLDTYPE = "C"
                                    v_strValue = mskReDG.Text.Replace(".", "").Replace(" ", "").Substring(0, 10)
                                Case "T_DESC"
                                    v_strFLDNAME = "30"
                                    v_strFLDTYPE = "C"
                                    v_strValue = "Gán môi giới chăm sóc hộ "
                                Case "ORGREACCTNO"
                                    v_strFLDNAME = "31"
                                    v_strFLDTYPE = "C"
                                Case "CAREBY"
                                    v_strFLDNAME = "95"
                                    v_strFLDTYPE = "C"
                                    v_strValue = mskReCarebyDG.Text.Trim

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
                        End With

                    Next ' Build xong 1 giao dich
                    v_strTxMsg = v_xmlTxDocument.InnerXml

                    v_lngError = v_ws.Message(v_strTxMsg)
                    If v_lngError <> ERR_SYSTEM_OK And v_lngError <> ERR_SA_CHECKER1_OVR And v_lngError <> ERR_SA_CHECKER2_OVR Then
                        'Thông báo lỗi
                        GetErrorFromMessage(v_strTxMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                        Cursor.Current = Cursors.Default
                        MessageBox.Show(v_strErrorMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        For v_intRow = 0 To mv_gridRemiser.DataRows.Count - 1
                            If mv_gridRemiser.DataRows(v_intRow).Cells("__TICK").Value = "X" _
                             And v_strAccDone.IndexOf(mv_gridRemiser.DataRows(v_intRow).Cells("ACCTNO").Value) > 0 Then
                                mv_gridRemiser.DataRows(v_intRow).Cells("__TICK").Value = "V"

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
                            For v_intRow = 0 To mv_gridRemiser.DataRows.Count - 1
                                If mv_gridRemiser.DataRows(v_intRow).Cells("__TICK").Value = "X" _
                                 And v_strAccDone.IndexOf(mv_gridRemiser.DataRows(v_intRow).Cells("ACCTNO").Value) > 0 Then
                                    mv_gridRemiser.DataRows(v_intRow).Cells("__TICK").Value = "V"

                                End If
                            Next
                            Me.Cursor = Cursors.Default
                            Return
                        Else
                            v_strAccDone = v_strAccDone & "|" & v_strAcctno
                        End If

                    End If
                Next
                MsgBox(mv_resourceManager.GetString("DONE"), MsgBoxStyle.Information, Me.Text)

                For v_intRow = 0 To mv_gridRemiser.DataRows.Count - 1
                    v_accdone_str = v_strAccDone.IndexOf(mv_gridRemiser.DataRows(v_intRow).Cells("ACCTNO").Value)
                    If mv_gridRemiser.DataRows(v_intRow).Cells("__TICK").Value = "X" _
                     And v_strAccDone.IndexOf(mv_gridRemiser.DataRows(v_intRow).Cells("ACCTNO").Value) > 0 Then
                        mv_gridRemiser.DataRows(v_intRow).Cells("__TICK").Value = "V"

                    End If
                Next
                Me.Cursor = Cursors.Default
            End If ' Confirm thuc hien
        Else

            MsgBox(mv_resourceManager.GetString("NOT_CHOOSE_AFACCTNO"), MsgBoxStyle.Information, Me.Text)
            ckAll.Focus()
            Return
        End If 'Len(v_strAccList) > 0

    End Sub
    Private Sub Button_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If (sender Is btnCancel) Then
            OnClose()
        ElseIf (sender Is btnChange) Then
            If Len(mskReAcctno.Text.Replace(".", "").Replace(" ", "")) = 0 Or Len(mskReDG.Text.Replace(".", "").Replace(" ", "")) = 0 Then
                MsgBox(mv_resourceManager.GetString("REISNOTNULL"), MsgBoxStyle.Information, Me.Text)
                mskReAcctno.Focus()
                Return
            End If
            If Len(mskReCarebyDG.Text.Trim) = 0 Or Len(mskReCarebyDG.Text.Trim) = 0 Then
                MsgBox(mv_resourceManager.GetString("CAREBYISNOTNULL"), MsgBoxStyle.Information, Me.Text)
                mskReCarebyDG.Focus()
                Return
            End If
            If dtpFromDate.Value >= dtpToDate.Value Then
                MsgBox(mv_resourceManager.GetString("INVALIDDATE"), MsgBoxStyle.Information, Me.Text)
                dtpToDate.Focus()
                Return
            End If
            If dtpFromDate.Value < Me.BusDate Then
                MsgBox(mv_resourceManager.GetString("INVALIDFRDATE"), MsgBoxStyle.Information, Me.Text)
                dtpFromDate.Focus()
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


    

   

 
    Private Sub mskReAcctno_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskReAcctno.Leave
        FillDataToGrid(mv_gridRemiser)
        lblReName.Text = GetDescType(mskReAcctno, "N")
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
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

    Private Sub mskReCarebyDG_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mskReCarebyDG.Leave
        lblDGCarebyname.Text = GetCarebyDescType(mskReCarebyDG, "Y")
    End Sub

    Private Sub mskReDG_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskReDG.Leave
        lblDGname.Text = GetDGDescType(mskReDG, "Y")
    End Sub
End Class