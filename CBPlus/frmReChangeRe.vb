Imports System.Windows.Forms
Imports CommonLibrary
Imports AppCore
Imports System.IO

Public Class frmReChangeRe
    Inherits System.Windows.Forms.Form
#Region " Constants and variables declaration "
    Const c_RESOURCE_MANAGER = "_DIRECT.frmReChangeRe-"

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
            Me.mskReAcctno.Mask = "9999.999999.9999"
            Me.mskReDG.BackColor = System.Drawing.Color.GreenYellow
            Me.mskReDG.Mask = "9999.999999.9999"
            Me.mskFUTREACCTNO.BackColor = System.Drawing.Color.GreenYellow
            Me.mskFUTREACCTNO.Mask = "9999.999999.9999"
            Me.mskFUTREACCTNONEW.BackColor = System.Drawing.Color.GreenYellow
            Me.mskFUTREACCTNONEW.Mask = "9999.999999.9999"

            Me.mskCBNew.BackColor = System.Drawing.Color.GreenYellow
            Me.mskCBNew.Mask = "9999"

            Me.mskTCBNew.BackColor = System.Drawing.Color.GreenYellow
            Me.mskTCBNew.Mask = "9999"
            'Me.mskFuReacctno.BackColor = System.Drawing.Color.GreenYellow
            'Me.mskFuReacctno.Mask = "9999.999999.9999"


            'Load resource and user's interface
            ResourceManager = New Resources.ResourceManager(c_RESOURCE_MANAGER & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            LoadUserInterface(Me)
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strCmdSQL As String, v_strObjMsg As String
            v_strCmdSQL = " SELECT grpid VALUE, grpname DISPLAY, grpname EN_DISPLAY, grpid LSTODR FROM tlgroups WHERE grptype ='2' " _
                        & " UNION ALL SELECT '%' VALUE, 'ALL' DISPLAY, 'ALL' EN_DISPLAY, '0000' LSTODR FROM dual ORDER BY LSTODR "



            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            FillComboEx(v_strObjMsg, cboCareby, "", Me.UserLanguage)


            InitReGrid()
            If Me.mv_gridRemiser.DataRowTemplate.Cells.Count >= 0 Then
                For i As Integer = 0 To Me.mv_gridRemiser.DataRowTemplate.Cells.Count - 1
                    AddHandler mv_gridRemiser.DataRowTemplate.Cells(i).Click, AddressOf Grid_Click
                Next
            End If

            dtpFromDate.Value = Me.BusDate
            'Vutn 14/11/2016
            'Truong “So ngay chuyen” mac dinh = “10000” => dtpToDate
            dtpToDate.Value = Me.dtpFromDate.Value.AddDays(10000)
            'End Vutn
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
                '.Add(New Xceed.Grid.Column("FUREACCTNO", GetType(System.String)))
                .Add(New Xceed.Grid.Column("FRDATE", GetType(System.String)))
                .Add(New Xceed.Grid.Column("TODATE", GetType(System.String)))
                .Add(New Xceed.Grid.Column("CAREBY", GetType(System.String)))
            End With
            mv_gridRemiser.Columns("AUTOID").Visible = False
            mv_gridRemiser.Columns("ACCTNO").Visible = True
            mv_gridRemiser.Columns("__TICK").Width = 20
            mv_gridRemiser.Columns("__TICK").ReadOnly = True

            mv_gridRemiser.Columns("CUSTODYCD").ReadOnly = True
            mv_gridRemiser.Columns("ACCTNO").ReadOnly = True
            mv_gridRemiser.Columns("FULLNAME").Width = 200
            mv_gridRemiser.Columns("FULLNAME").ReadOnly = True
            'mv_gridRemiser.Columns("FUREACCTNO").ReadOnly = True
            mv_gridRemiser.Columns("FRDATE").ReadOnly = True
            mv_gridRemiser.Columns("TODATE").ReadOnly = True
            mv_gridRemiser.Columns("CAREBY").ReadOnly = True
            mv_gridRemiser.Columns("CAREBY").Width = 200

            mv_gridRemiser.Columns("CUSTODYCD").Title = mv_resourceManager.GetString("CUSTODYCD")
            mv_gridRemiser.Columns("FULLNAME").Title = mv_resourceManager.GetString("FULLNAME")
            mv_gridRemiser.Columns("ACCTNO").Title = mv_resourceManager.GetString("ACCTNO")
            'mv_gridRemiser.Columns("FUREACCTNO").Title = mv_resourceManager.GetString("FUREACCTNO")
            mv_gridRemiser.Columns("FRDATE").Title = mv_resourceManager.GetString("FRDATE")
            mv_gridRemiser.Columns("TODATE").Title = mv_resourceManager.GetString("TODATE")
            mv_gridRemiser.Columns("CAREBY").Title = mv_resourceManager.GetString("CAREBY")

            'FillDataToGrid(mv_gridRemiser)
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

            If cboCareby.Text <> "ALL" Then
                v_where = " AND cf.careby like '%" & Me.cboCareby.SelectedValue.ToString() & "%' "
            End If

            If Not txtSearch.Text Is Nothing Then

                v_where = v_where + " and (cf.custodycd like '%" & txtSearch.Text & "%' or upper(cf.fullname) like upper('%" & txtSearch.Text & "%') ) "
            End If

            If Len(mskReAcctno.Text.Replace(".", "").Trim()) > 0 Then
                v_where = v_where + "  and ra.reacctno= '" & mskReAcctno.Text.Replace(".", "") & "'"
            End If

            If Len(mskFUTREACCTNO.Text.Replace(".", "").Trim()) > 0 Then
                v_where = v_where + "  and ra.futreacctno= '" & mskFUTREACCTNO.Text.Replace(".", "") & "'"
            End If

           




            v_strSQL = "select RA.AUTOID, ra.afacctno acctno, cf.custodycd,cf.fullname,tlg.grpname careby,TO_CHAR(ra.frdate,'DD/MM/YYYY') FRDATE, TO_CHAR(ra.todate,'DD/MM/YYYY') TODATE " _
                              & " from reaflnk ra, cfmast cf,retype tpy ,tlgroups tlg " _
                               & " where cf.custid = ra.afacctno and ra.status='A' and tlg.grpid =cf.careby  " _
                               & " and tpy.actype = substr(ra.reacctno,11,4) and tpy.rerole<>'DG' " & v_where _
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

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function GetDescType(ByVal thisMsK As System.Windows.Forms.MaskedTextBox, ByVal pv_strREACCTNO As String, ByVal pv_strCheckAcct As String) As String
        Try
            Dim v_strSQL As String
            Dim v_strCDCONTENT, v_strFLDNAME, v_strVALUE, v_strCmdInquiry, v_strObjMsg As String
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_intCount, v_int As Integer
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strDescType As String
            Dim v_strREAcctno As String
            v_strREAcctno = Replace(pv_strREACCTNO, ".", "").Trim()
            v_strSQL = "SELECT (CFMAST.FULLNAME) DESC_TYPE" _
                        & " FROM RECFDEF RF, RETYPE TYP, ALLCODE A0, ALLCODE A1, ALLCODE A2, RECFLNK CF, CFMAST" _
                        & " WHERE A0.CDTYPE='RE' AND A0.CDNAME='REROLE' AND A0.CDVAL=TYP.REROLE" _
                        & " AND A2.CDTYPE = 'RE' AND A2.CDNAME = 'AFSTATUS' AND A2.CDVAL = TYP.AFSTATUS" _
                        & " AND A1.CDTYPE='RE' AND A1.CDNAME='RETYPE' AND A1.CDVAL=TYP.RETYPE" _
                        & " AND nvl(RF.STATUS,'A')='A' AND RF.REACTYPE=TYP.ACTYPE" _
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

    Private Function GetCarebyDescType(ByVal thisMsK As System.Windows.Forms.MaskedTextBox, ByVal pv_strCarby As String, ByVal pv_strCheckAcct As String) As String
        Try
            Dim v_strSQL As String
            Dim v_strCDCONTENT, v_strFLDNAME, v_strVALUE, v_strCmdInquiry, v_strObjMsg As String
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_intCount, v_int As Integer
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strDescType As String
            Dim v_strCareby As String
            v_strCareby = pv_strCarby.Trim()
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
                    frm.TableName = "RE0381_112707"
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
                    'lblDGname.Text = GetDescType(Me.ActiveControl.Text)
                    frm.Dispose()
                    FillDataToGrid(mv_gridRemiser)

                ElseIf Me.ActiveControl.Name = "mskReDG" Then
                    Dim frm As New frmSearch(Me.UserLanguage)
                    frm.TableName = "RECF_0381"
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

                    ' 19/05/2015 locpt add them careby
                ElseIf Me.ActiveControl.Name = "mskCBNew" Then
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
                        lblCBNew.Text = Trim(frm.RefValue)
                    End If
                    frm.Dispose()

                ElseIf Me.ActiveControl.Name = "mskTCBNew" Then
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
                        lblTCBNew.Text = Trim(frm.RefValue)
                    End If
                    frm.Dispose()
                    'longnh
                ElseIf Me.ActiveControl.Name = "mskFUTREACCTNO" Then
                    Dim frm As New frmSearch(Me.UserLanguage)
                    frm.TableName = "RECF_OLDNOTDG"
                    frm.ModuleCode = "RE"
                    frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                    frm.IsLocalSearch = gc_IsNotLocalMsg
                    frm.IsLookup = "Y"
                    frm.SearchOnInit = False
                    frm.BranchId = Me.BranchId
                    frm.TellerId = Me.TellerId
                    frm.ShowDialog()

                    'Me.ActiveControl.Text = Trim(frm.ReturnValue)
                    'If Len(frm.RefValue) > 0 Then
                    '    lblToDate.Text = Trim(frm.RefValue)
                    'End If
                    'frm.Dispose()

                    Me.ActiveControl.Text = Trim(frm.ReturnValue)
                    If Len(frm.RefValue) > 0 Then
                        lblREFTNAME.Text = Trim(frm.RefValue)
                    End If
                    'lblDGname.Text = GetDescType(Me.ActiveControl.Text)
                    frm.Dispose()
                    FillDataToGrid(mv_gridRemiser)
                ElseIf Me.ActiveControl.Name = "mskFUTREACCTNONEW" Then
                    Dim frm As New frmSearch(Me.UserLanguage)
                    frm.TableName = "RECF_OLDNOTDG"
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
                        lblREFTNAMENEW.Text = Trim(frm.RefValue)
                    End If
                    frm.Dispose()

                    'ElseIf Me.ActiveControl.Name = "mskFuReacctno" Then
                    'Dim frm As New frmSearch(Me.UserLanguage)
                    'frm.TableName = "RECFDEF_01"
                    'frm.ModuleCode = "RE"
                    'frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                    'frm.IsLocalSearch = gc_IsNotLocalMsg
                    'frm.IsLookup = "Y"
                    'frm.SearchOnInit = False
                    'frm.BranchId = Me.BranchId
                    'frm.TellerId = Me.TellerId
                    'frm.ShowDialog()

                    'Me.ActiveControl.Text = Trim(frm.ReturnValue)
                    'If Len(frm.RefValue) > 0 Then
                    'lblFuReName.Text = Trim(frm.RefValue)
                    'End If
                    'frm.Dispose()
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
        Dim V_AutoIdList, v_strAccList, v_strAccDone, v_strAcctno As String
        Dim v_strSQL As String
        Dim v_strTxMsg As String
        Dim v_where As String = ""
        v_strAccList = ""
        v_strAccDone = ""
        V_AutoIdList = ""

        For v_intRow = 0 To mv_gridRemiser.DataRows.Count - 1
            If mv_gridRemiser.DataRows(v_intRow).Cells("__TICK").Value = "X" Then
                v_strAccList = v_strAccList & mv_gridRemiser.DataRows(v_intRow).Cells("ACCTNO").Value & "|"
                V_AutoIdList = V_AutoIdList & mv_gridRemiser.DataRows(v_intRow).Cells("AUTOID").Value & "|"
            End If
        Next
        If Len(v_strAccList) > 0 Then
            If MsgBox(mv_resourceManager.GetString("CONFIRM") & v_strAccList & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) = MsgBoxResult.Yes Then
                Me.Cursor = Cursors.WaitCursor

                If Not cboCareby.Text <> "ALL" Then
                    v_where = " AND cf.careby like '%" & Me.cboCareby.SelectedValue.ToString() & "%' "
                End If

                If Not txtSearch.Text Is Nothing Then

                    v_where = v_where + " and (cf.custodycd like '%" & txtSearch.Text & "%' or upper(cf.fullname) like upper('%" & txtSearch.Text & "%') ) "
                End If

                If Len(mskReAcctno.Text.Replace(".", "").Trim()) > 0 Then
                    v_where = v_where + "  and ra.reacctno= '" & mskReAcctno.Text.Replace(".", "") & "'"
                End If

                If Len(mskFUTREACCTNO.Text.Replace(".", "").Trim()) > 0 Then
                    v_where = v_where + "  and ra.futreacctno= '" & mskFUTREACCTNO.Text.Replace(".", "") & "'"
                End If

                


                v_strSQL = " select '' FUTODATE,'' CAREBY,'' FCAREBY,'' FUTREACCTNONEW,RA.futreacctno,360 furdays,cf.custodycd, cf.custid ACCTNO,cf.fullname CUSTNAME, " _
                          & " substr(ra.reacctno,1,10) REOLDCUSTID,ra.reacctno REOLDACCTNO, '' ORADESC , " _
                          & " '' RECUSTNAME, '' RECUSTID,'' REACTYPE,'' REACCTNO , '' RADESC, " _
                          & " ''FRDATE, " _
                          & " tpy.rerole REROLE , '' TODATE  , 0 AMT, '' T_DESC " _
                          & " from reaflnk ra,cfmast cf , retype tpy, (select custid, max(acctno) acctno from afmast group by custid) af " _
                          & " where cf.custid = ra.afacctno and cf.custid = af.custid and ra.status='A'   " _
                          & " and tpy.actype = '" & mskReDG.Text.Replace(".", "").Replace(" ", "").Substring(10, 4) & "' " _
                          & v_where & " and instr('" & V_AutoIdList & "', ra.autoid) >0 " _
                          & " and instr('" & v_strAccList & "', ra.afacctno) >0 " _
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
                Dim v_orgrename As String = lblReName.Text()
                Dim v_rename As String = lblDGname.Text()
                'Dim v_furename As String = lblFuReName.Text()


                v_xmlDocument.LoadXml(v_strMsgObj)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                For i As Integer = 0 To v_nodeList.Count - 1
                    'Duyet tung dong, moi dong build mot giao dich

                    v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, "0381", Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)
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
                                    v_strAcctno = v_strValue
                                Case "ACCTNO"
                                    v_strFLDNAME = "03"
                                    v_strFLDTYPE = "C"
                                    v_strAcctno = v_strValue
                                Case "CUSTNAME"
                                    v_strFLDNAME = "90"
                                    v_strFLDTYPE = "C"
                                    v_strAcctno = v_strValue
                                Case "REOLDCUSTID"
                                    v_strFLDNAME = "20"
                                    v_strFLDTYPE = "C"
                                Case "REOLDACCTNO"
                                    v_strFLDNAME = "21"
                                    v_strFLDTYPE = "C"
                                    v_strAcctno = v_strValue
                                Case "ORADESC"
                                    v_strFLDNAME = "92"
                                    v_strFLDTYPE = "C"
                                    v_strValue = v_strValue
                                Case "RECUSTNAME"
                                    v_strFLDNAME = "91"
                                    v_strFLDTYPE = "C"
                                    v_strValue = v_rename
                                Case "RECUSTID"
                                    v_strFLDNAME = "02"
                                    v_strFLDTYPE = "C"
                                    v_strValue = mskReDG.Text.Replace(".", "").Replace(" ", "").Substring(0, 10)
                                Case "REACTYPE"
                                    v_strFLDNAME = "07"
                                    v_strFLDTYPE = "C"
                                    v_strValue = mskReDG.Text.Replace(".", "").Replace(" ", "").Substring(10, 4)
                                Case "REACCTNO"
                                    v_strFLDNAME = "08"
                                    v_strFLDTYPE = "C"
                                    v_strValue = mskReDG.Text.Replace(".", "").Replace(" ", "")
                                Case "RADESC"
                                    v_strFLDNAME = "94"
                                    v_strFLDTYPE = "C"
                                    v_strValue = mskReDG.Text.Replace(".", "").Replace(" ", "").Substring(10, 4)
                                Case "FURDAYS"
                                    v_strFLDNAME = "24"
                                    v_strFLDTYPE = "N"
                                    v_strValue = mskFURDAYS.Text.Replace(".", "").Replace(" ", "")
                                Case "FRDATE"
                                    v_strFLDNAME = "05"
                                    v_strFLDTYPE = "C"
                                    v_strValue = dtpFromDate.Text.Replace(".", "").Replace(" ", "")
                                Case "TODATE"
                                    v_strFLDNAME = "06"
                                    v_strFLDTYPE = "C"
                                    v_strValue = dtpToDate.Text.Replace(".", "").Replace(" ", "")
                                Case "FUTREACCTNO"
                                    v_strFLDNAME = "22"
                                    v_strFLDTYPE = "C"
                                    v_strAcctno = v_strValue
                                Case "FUTREACCTNONEW"
                                    v_strFLDNAME = "23"
                                    v_strFLDTYPE = "C"
                                    v_strValue = mskFUTREACCTNONEW.Text.Replace(".", "").Replace(" ", "")

                                Case "FUTODATE"
                                    v_strFLDNAME = "26"
                                    v_strFLDTYPE = "C"
                                    v_strValue = dtpFUTODATE.Text.Replace(".", "").Replace(" ", "")
                                Case "REROLE"
                                    v_strFLDNAME = "09"
                                    v_strFLDTYPE = "C"
                                Case "AMT"
                                    v_strFLDNAME = "10"
                                    v_strFLDTYPE = "N"
                                Case "T_DESC"
                                    v_strFLDNAME = "30"
                                    v_strFLDTYPE = "C"
                                    v_strValue = "Chuyển môi giới"
                                Case "CAREBY"
                                    v_strFLDNAME = "95"
                                    v_strFLDTYPE = "C"
                                    v_strValue = mskCBNew.Text.Replace(".", "").Replace(" ", "")
                                Case "FCAREBY"
                                    v_strFLDNAME = "96"
                                    v_strFLDTYPE = "C"
                                    v_strValue = mskTCBNew.Text.Replace(".", "").Replace(" ", "")
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
                    If mv_gridRemiser.DataRows(v_intRow).Cells("__TICK").Value = "X" _
                     And v_strAccDone.IndexOf(mv_gridRemiser.DataRows(v_intRow).Cells("ACCTNO").Value) > 0 Then
                        mv_gridRemiser.DataRows(v_intRow).Cells("__TICK").Value = "V"

                    End If
                Next
                Me.Cursor = Cursors.Default
            End If ' Confirm thuc hien
        End If 'Len(v_strAccList) > 0

    End Sub
    Private Sub Button_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If (sender Is btnCancel) Then
            OnClose()
        ElseIf (sender Is btnChange) Then
            If Len(mskReDG.Text.Replace(".", "").Trim) = 0 Then
                MsgBox(mv_resourceManager.GetString("REISNOTNULL"), MsgBoxStyle.Information, Me.Text)
                Return
            End If

            If dtpFromDate.Value >= dtpToDate.Value Then
                MsgBox(mv_resourceManager.GetString("INVALIDDATE"), MsgBoxStyle.Information, Me.Text)
                Return
            End If

            If dtpFromDate.Value < Me.BusDate Then
                MsgBox(mv_resourceManager.GetString("INVALIDFRDATE"), MsgBoxStyle.Information, Me.Text)
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







    'Private Sub mskReAcctno_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskReAcctno.Leave
    'Dim v_strsql As String
    'FillDataToGrid(mv_gridRemiser)
    'mskFuReacctno.Enabled = False
    'Me.mskFuReacctno.BackColor = System.Drawing.Color.White
    'If mskReAcctno.Text.Replace(".", "").Replace(" ", "").Length = 14 Then
    'v_strsql = " select rerole from retype where actype = '" & mskReAcctno.Text.Replace(".", "").Replace(" ", "").Substring(10, 4) & "' "
    'Dim v_strMsgObj As String = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SE_SBSECURITIES, gc_ActionInquiry, v_strsql)
    'Dim v_ws As New BDSDeliveryManagement
    'v_ws.Message(v_strMsgObj)
    'Dim v_xmlDocument As New XmlDocumentEx
    'Dim v_nodeList As Xml.XmlNodeList

    'v_xmlDocument.LoadXml(v_strMsgObj)
    'v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
    'If v_nodeList.Count > 0 Then
    'If v_nodeList.Item(0).ChildNodes(0).InnerText.ToString() = "BM" Then
    'mskFuReacctno.Enabled = True
    'Me.mskFuReacctno.BackColor = System.Drawing.Color.GreenYellow
    'End If
    'End If
    'lblReName.Text = GetDescType(mskReAcctno.Text)
    'End If
    'End Sub

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

    'Private Sub mskFuReacctno_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskFuReacctno.Leave
    'lblFuReName.Text = GetDescType(mskFuReacctno.Text)
    'End Sub

    Private Sub mskReDG_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskReDG.Leave
        lblDGname.Text = GetDescType(mskReDG, mskReDG.Text, "Y")
    End Sub

    
    Private Sub mskReAcctno_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mskReAcctno.Leave, mskFURDAYS.Leave
        'LONGNH 2014-11-01 PHS_P1_RE0008
        lblReName.Text = GetDescType(mskReAcctno, mskReAcctno.Text, "N")
        GetFUTREACCTNO(mskReAcctno.Text)
        'lblREFTNAME.Text = GetDescType(mskFUTREACCTNO, mskFUTREACCTNO.Text)

    End Sub

    Private Sub mskFUTREACCTNO_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mskFUTREACCTNO.Leave
        lblREFTNAME.Text = GetDescType(mskFUTREACCTNO, mskFUTREACCTNO.Text, "N")
    End Sub

    Private Sub mskFUTREACCTNONEW_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mskFUTREACCTNONEW.Leave
        lblREFTNAMENEW.Text = GetDescType(mskFUTREACCTNONEW, mskFUTREACCTNONEW.Text, "Y")
    End Sub
    Private Sub mskCBNew_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mskCBNew.Leave
        lblCBNew.Text = GetCarebyDescType(mskCBNew, mskCBNew.Text, "Y")
    End Sub

    Private Sub mskTCBNew_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mskTCBNew.Leave
        lblTCBNew.Text = GetCarebyDescType(mskTCBNew, mskTCBNew.Text, "Y")
    End Sub

    Private Sub GetFUTREACCTNO(ByVal pv_strREACCTNO As String)
        'LONGNH 2014-11-01 PHS_P1_RE0008

        Try
            Dim v_strSQL As String
            Dim v_strCDCONTENT, v_strFLDNAME, v_strVALUE, v_strCmdInquiry, v_strObjMsg As String
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_intCount, v_int As Integer
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strFUTREACCTNO, V_strFURDAYS As String
            Dim v_strREAcctno As String
            v_strREAcctno = Replace(pv_strREACCTNO, ".", "")
            v_strSQL = "SELECT FUTREACCTNO FUTREACCTNO, FURDAYS" _
                        & " FROM REAFLNK " _
                        & " WHERE  REACCTNO = '" & v_strREAcctno & "' "

            v_strObjMsg = BuildXMLObjMsg(, Me.BranchId, , Me.TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For v_intCount = 0 To v_nodeList.Count - 1
                For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                    With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                        v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                        v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()
                        Select Case v_strFLDNAME
                            Case "FUTREACCTNO"
                                v_strFUTREACCTNO = v_strVALUE
                            Case "FURDAYS"
                                V_strFURDAYS = v_strVALUE
                        End Select
                    End With
                Next
            Next
            'mskFUTREACCTNO.Text = v_strFUTREACCTNO
            '   mskFURDAYS.Text = V_strFURDAYS
            'dtpFURDATE.Value = DateAdd()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub dtpFromDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFromDate.ValueChanged
        ChangeDay()
    End Sub

    Private Sub dtpToDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpToDate.ValueChanged
        ChangeDay()
    End Sub

    Public Sub ChangeDay()
        mskFURDAYS.Text = DateDiff(DateInterval.Day, dtpFromDate.Value, dtpToDate.Value).ToString()
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class