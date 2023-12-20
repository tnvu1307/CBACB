Imports AppCore
Imports CommonLibrary
Imports Xceed.Grid.Collections
Imports Xceed.Grid.Editors
Imports System.Xml
Imports System.Configuration.ConfigurationSettings
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.IO.File
Imports System.IO.Path
Imports System.Windows.Forms.Application
Imports System.Text
Imports System.Text.RegularExpressions
Public Class frmCUWBIDDING
    Const c_ResourceManager As String = "_DIRECT.frmCUWBIDDING-"
    Private mv_strTltxcd As String
    Private mv_strObjectName As String
    Private mv_strModuleCode As String
    Private mv_strLanguage As String
    Private mv_ResourceManager As Resources.ResourceManager
    Private mv_strBusDate As String
    Private mv_strIpAddress As String
    Private mv_strWsName As String
    Private mv_strBranchId As String
    Private mv_strTellerName As String
    Private mv_strLocalObject As String
    Private mv_strTellerId As String
    Private CPSchdGrid As AppCore.GridEx
    Private mv_strOldSearchBy As String
    Private mv_strOldSearchValue As String
    Private mv_xmlCUSTOMER As XmlDocumentEx
    Private mv_strXmlMessageData As String
    Private mv_arrAFACCTNO() As String
    Private mv_arrObjFields() As CFieldMaster
    Private mv_arrObjFldVals() As CFieldVal
    Private mv_blnAcctEntry As Boolean
    Private mv_dblDEALPAIDAMT As Double
    Private mv_dblAVLADVANCE As Double

    Private mv_strAFACCTNO As String
    Private mv_strCUSTODYCD As String

    Private mv_intNumOfParam As Integer
    Private mv_arrRptParam As ReportParameters()
    Private mv_strStoreName As String
    Private ReportDirectory, ReportTempDirectory, ReportAsychronous As String
    Private HeadOffice, BranchName, BranchAddress, BranchPhoneFax, CreatedDate, CreatedDate_En, Teller, ReportTitle As String
    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mv_strLanguage = pv_strLanguage
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)
        InitExternal()
        Me.Tltxcd = gc_BO_COMPLETE_BOND_BIDDING_NBW
        Me.btnAdjust.Enabled = False

    End Sub

#Region "Properties "

    Public Property AFACCTNO() As String
        Get
            Return mv_strAFACCTNO
        End Get
        Set(ByVal Value As String)
            mv_strAFACCTNO = Value
        End Set
    End Property
    Public Property CUSTODYCD() As String
        Get
            Return mv_strCUSTODYCD
        End Get
        Set(ByVal Value As String)
            mv_strCUSTODYCD = Value
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
    Public Property Tltxcd() As String
        Get
            Return mv_strTltxcd
        End Get
        Set(ByVal Value As String)
            mv_strTltxcd = Value
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

    Public Property TellerName() As String
        Get
            Return mv_strTellerName
        End Get
        Set(ByVal Value As String)
            mv_strTellerName = Value
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

    Public Property ResourceManager() As Resources.ResourceManager
        Get
            Return mv_ResourceManager
        End Get
        Set(ByVal Value As Resources.ResourceManager)
            mv_ResourceManager = Value
        End Set
    End Property
#End Region

#Region "Private Functions"
    Private Sub OnClose()
        Me.Dispose()
    End Sub
    Private Sub LoadResource(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control

        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is Label Then
                CType(v_ctrl, Label).Text = mv_ResourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is RichTextBox Then
                CType(v_ctrl, RichTextBox).Text = mv_ResourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is CheckBox Then
                CType(v_ctrl, CheckBox).Text = mv_ResourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString(v_ctrl.Name)
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is SplitContainer Then
                CType(v_ctrl, SplitContainer).Text = mv_ResourceManager.GetString(v_ctrl.Name)
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Button Then
                CType(v_ctrl, Button).Text = mv_ResourceManager.GetString(v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is Panel Then
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is DateTimePicker Then
                If (Me.BusDate <> String.Empty) Then
                    CType(v_ctrl, DateTimePicker).Value = CDate(Me.BusDate)
                Else
                    CType(v_ctrl, DateTimePicker).Text = ""
                End If
            End If

        Next
        Me.Text = mv_ResourceManager.GetString("frmCUWBIDDING")
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            'Lay thong so cho Loai hinh dau thau
            Me.cboBIDTYPE.Clears()
            Dim v_strCmdSQL As String = "SELECT CDVAL FILTERCD, CDVAL VALUE, CDVAL VALUECD, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY, CDCONTENT DESCRIPTION FROM ALLCODE WHERE cdname='BIDTYPE' and cdtype='BO' "
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            FillComboEx(v_strObjMsg, cboBIDTYPE, "", Me.UserLanguage)
            'If Me.cboBIDTYPE.Items.Count > 0 Then
            'Me.cboBIDTYPE.SelectedIndex = 0
            'End If

            'Lay Thong tin Symbol cho combobox.
            Me.cboCODEID.Clears()
            v_strCmdSQL = "SELECT CODEID FILTERCD, CODEID VALUE, CODEID VALUECD, SYMBOL DISPLAY, SYMBOL EN_DISPLAY, SYMBOL DESCRIPTION FROM SBSECURITIES WHERE SECTYPE IN ('003','006','222') ORDER BY SYMBOL"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            FillComboEx(v_strObjMsg, cboCODEID, "", Me.UserLanguage)

            If Me.cboCODEID.Items.Count > 0 Then
                Me.cboCODEID.SelectedIndex = 0
            End If
            Me.cboBIDTYPE.Focus()
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InitExternal()
        CPSchdGrid = New GridEx

        Dim v_cmrMemberHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrMemberHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrMemberHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        v_cmrMemberHeader.Height = 25

        CPSchdGrid.FixedHeaderRows.Add(v_cmrMemberHeader)
        CPSchdGrid.Columns.Add(New Xceed.Grid.Column("X", GetType(System.String)))
        CPSchdGrid.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(System.String)))
        CPSchdGrid.Columns.Add(New Xceed.Grid.Column("TXDATE", GetType(System.String)))
        CPSchdGrid.Columns.Add(New Xceed.Grid.Column("AMT", GetType(System.String)))
        CPSchdGrid.Columns.Add(New Xceed.Grid.Column("TXDESC", GetType(System.String)))

        CPSchdGrid.Columns("AUTOID").Visible = False
        CPSchdGrid.Columns("TXDATE").Visible = True
        CPSchdGrid.Columns("AMT").Visible = True
        CPSchdGrid.Columns("TXDESC").Visible = True

        CPSchdGrid.Columns("X").Title = "X"
        CPSchdGrid.Columns("AUTOID").Title = mv_ResourceManager.GetString("SchdAUTOID")
        CPSchdGrid.Columns("TXDATE").Title = mv_ResourceManager.GetString("SchdTXDATE")
        CPSchdGrid.Columns("AMT").Title = mv_ResourceManager.GetString("SchdAMT")
        CPSchdGrid.Columns("TXDESC").Title = mv_ResourceManager.GetString("SchdDESCRIPTION")

        CPSchdGrid.Columns("X").Width = 40
        CPSchdGrid.Columns("AUTOID").Width = 30
        CPSchdGrid.Columns("TXDATE").Width = 115
        CPSchdGrid.Columns("AMT").Width = 130
        CPSchdGrid.Columns("TXDESC").Width = 340

        CPSchdGrid.Columns("AMT").FormatSpecifier = "#,##0"
        CPSchdGrid.Columns("TXDATE").FormatSpecifier = "dd/MM/yyyy"

        CPSchdGrid.Columns("TXDESC").ReadOnly = False

        CPSchdGrid.Columns("X").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        CPSchdGrid.Columns("AUTOID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        CPSchdGrid.Columns("TXDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        CPSchdGrid.Columns("AMT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        CPSchdGrid.Columns("TXDESC").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left

        CPSchdGrid.Columns("X").VerticalAlignment = Xceed.Grid.VerticalAlignment.Center
        CPSchdGrid.Columns("AUTOID").VerticalAlignment = Xceed.Grid.VerticalAlignment.Center
        CPSchdGrid.Columns("TXDATE").VerticalAlignment = Xceed.Grid.VerticalAlignment.Center
        CPSchdGrid.Columns("AMT").VerticalAlignment = Xceed.Grid.VerticalAlignment.Center
        CPSchdGrid.Columns("TXDESC").VerticalAlignment = Xceed.Grid.VerticalAlignment.Center

        CPSchdGrid.Columns("TXDATE").SortDirection = Xceed.Grid.SortDirection.Ascending

        'Bat su kien Click va double click
        If Me.CPSchdGrid.DataRowTemplate.Cells.Count >= 0 Then
            For i As Integer = 0 To Me.CPSchdGrid.DataRowTemplate.Cells.Count - 1
                AddHandler CPSchdGrid.DataRowTemplate.Cells(i).DoubleClick, AddressOf Grid_DblClick
                AddHandler CPSchdGrid.DataRowTemplate.Cells(i).Click, AddressOf Grid_Click
            Next
        End If
        Me.Panel1.Controls.Clear()
        Me.Panel1.Controls.Add(CPSchdGrid)
        CPSchdGrid.Dock = Windows.Forms.DockStyle.Fill

    End Sub

    Private Sub Grid_DblClick(ByVal sender As Object, ByVal e As System.EventArgs)
        'If Not CPSchdGrid.CurrentColumn Is Nothing Then
        'Dim frm As New frmODDetail(Me.UserLanguage)
        'frm.TellerName = Me.TellerName
        'frm.LocalObject = gc_IsNotLocalMsg
        'frm.BranchId = Me.BranchId
        'frm.TellerId = Me.TellerId
        'frm.TellerName = Me.TellerName
        'frm.IpAddress = Me.IpAddress
        'frm.WsName = Me.WsName
        'frm.BusDate = Me.BusDate
        'frm.AccountInquiry = Me.cboAFACCTNO.SelectedValue
        'frm.OrderDate = CType(CPSchdGrid.CurrentRow, Xceed.Grid.DataRow).Cells("MATCHDATE").Value
        'frm.SettlementDate = CType(CPSchdGrid.CurrentRow, Xceed.Grid.DataRow).Cells("DUEDATE").Value
        'frm.VSD = CType(CPSchdGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ISVSD").Value
        'frm.ShowDialog()
        'frm.Dispose()
        'End If

    End Sub

    Protected Overridable Sub Grid_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not CPSchdGrid.CurrentColumn Is Nothing Then
            If CPSchdGrid.CurrentColumn.FieldName = "X" Then
                If CPSchdGrid.CurrentCell.Value = "X" Then
                    CPSchdGrid.CurrentCell.Value = String.Empty
                Else
                    CPSchdGrid.CurrentCell.Value = "X"
                End If
            End If
        End If
        allocCPSchd()
    End Sub

    Private Sub allocCPSchd()
        Dim v_dblCMPFEE, v_dblCASHFEE, v_dblMinFee, v_dblCUTEDAMT, v_dblSUMRCAMT, v_dblREMAIN_DEALPAIDAMT As Double
        v_dblREMAIN_DEALPAIDAMT = mv_dblDEALPAIDAMT
        Dim v_intMaxIndex As Integer
        Try

            v_dblCASHFEE = CDbl(Me.txtCASHFEE.Text)
            v_dblCUTEDAMT = CDbl(Me.txtCUTEDAMT.Text)

            CPSchdGrid.Columns("TXDATE").SortDirection = Xceed.Grid.SortDirection.Ascending
            CPSchdGrid.Refresh()
            v_dblSUMRCAMT = 0
            'For i As Integer = CPSchdGrid.DataRows.Count - 1 To 0 Step -1
            '    If CPSchdGrid.DataRows(i).Cells("X").Value = "X" Then
            '        'Set RCVADVAMT
            '        v_dblCMPFEE = Math.Ceiling(Math.Max(CDbl(CPSchdGrid.DataRows(i).Cells("AVLADVAMT").Value) * CDbl(CPSchdGrid.DataRows(i).Cells("DAYS").Value) * CDbl(Me.txtINTRATE.Text) / 360 / 100, CDbl(Me.txtMINADVAMT.Text)))
            '        CPSchdGrid.DataRows(i).Cells("RCVADVAMT").Value = Math.Max(CDbl(CPSchdGrid.DataRows(i).Cells("AVLADVAMT").Value) - v_dblCMPFEE, 0)
            '        'v_dblREMAIN_DEALPAIDAMT = Math.Max(v_dblREMAIN_DEALPAIDAMT - (CDbl(CPSchdGrid.DataRows(i).Cells("AVLADVAMT").Value) - v_dblCMPFEE, 0)
            '        'End set RCVADVAMT
            '        v_dblSUMRCVADVAMT = v_dblSUMRCVADVAMT + CDbl(CPSchdGrid.DataRows(i).Cells("RCVADVAMT").Value)
            '    End If
            'Next
            For i As Integer = CPSchdGrid.DataRows.Count - 1 To 0 Step -1
                If CPSchdGrid.DataRows(i).Cells("X").Value = "X" Then
                    v_intMaxIndex = i
                    Exit For
                End If
            Next

            REM v_dblCMPFEE = 0
            v_dblSUMRCAMT = 0
            For i As Integer = CPSchdGrid.DataRows.Count - 1 To 0 Step -1
                If CPSchdGrid.DataRows(i).Cells("X").Value = "X" Then
                    v_dblSUMRCAMT = v_dblSUMRCAMT + CDbl(CPSchdGrid.DataRows(i).Cells("AMT").Value)
                End If
            Next
            v_dblCUTEDAMT = v_dblSUMRCAMT
            Me.txtCASHFEE.Text = Format(v_dblCASHFEE, "#,##0")
            Me.txtCUTEDAMT.Text = Format(v_dblCUTEDAMT, "#,##0")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

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

            'Lay thong tin chung va giao dich
            If Len(Me.ModuleCode) > 0 Then
                v_strSQL = "SELECT TX.* FROM TLTX TX, APPMODULES APP WHERE SUBSTR(TX.TLTXCD,1,2)=APP.TXCODE " _
                    & "AND UPPER(TX.TLTXCD) = '" & strTLTXCD & "' " _
                    & "AND UPPER(APP.MODCODE) = 'CI' "
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLTX, gc_ActionInquiry, v_strSQL)
            Else
                v_strClause = "upper(TLTXCD) = '" & strTLTXCD & "'"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLTX, gc_ActionInquiry, , v_strClause)
            End If
            v_ws.Message(v_strObjMsg)

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count = 0 Then
                'Neu khong ton tai ma giao dich
                MessageBox.Show(mv_ResourceManager.GetString("ERR_TLTXCD_NOTFOUND"))
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

            'Lay thong tin chi tiet cac truong cua giao dich
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
                                v_strPrintInfo = v_strValue 'KhÃ´ng Ä‘Æ°á»£c trim vÃ¬ Ä‘á»™ dÃ i báº¯t buá»™c 10 kÃ½ tá»±
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
                        'Xá»­ lÃ½ cho trÆ°á»?ng Description
                        v_strDefVal = Me.Text
                    ElseIf v_strDefVal = "<$BUSDATE>" Then
                        'Lay ngay lam viec hien tai
                        v_strDefVal = Me.BusDate
                    End If
                    If v_blnChain Then
                        'Náº¿u giao dá»‹ch Ä‘Æ°á»£c náº¡p qua giao dá»‹ch tra cá»©u
                        If Len(v_strChainName) > 0 Then
                            'Náº¿u trÆ°á»?ng nÃ y cÃ³ sá»­ dá»¥ng CHAINNAME Ä‘á»ƒ láº¥y giÃ¡ trá»‹ tá»« mÃ n hÃ¬nh tra cá»©u
                            v_nodetxData = v_xmlDocumentData.SelectSingleNode("TransactMessage/ObjData/entry[@fldname='" & v_strChainName & "']")
                            If Not v_nodetxData Is Nothing Then
                                v_strDefVal = Trim(v_nodetxData.InnerText)
                            End If
                        End If
                    ElseIf v_blnData Then
                        'Náº¿u giao dá»‹ch cÃ³ dá»¯ liá»‡u (xem chi tiet)
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

            'Lay cac luat kiem tra cua cac truong trong giao dich
            v_strClause = "SELECT FLDNAME, VALTYPE, OPERATOR, VALEXP, VALEXP2, ERRMSG, EN_ERRMSG FROM FLDVAL " & _
                "WHERE upper(OBJNAME) = '" & strTLTXCD & "' ORDER BY VALTYPE, FLDNAME, ODRNUM" 'Thá»© tá»± order by lÃ  quan trá»?ng khÃ´ng sá»­a
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
                        'Ghi nhan thuat toan kiem tra va tinh toan cho tung truong cac giao dich
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

                'XÃ¡c Ä‘á»‹nh index cá»§a máº£ng FldMaster
                For j = 0 To mv_arrObjFields.GetLength(0) - 1 Step 1
                    If Not mv_arrObjFields(j) Is Nothing Then
                        If Trim(mv_arrObjFields(j).FieldName) = Trim(v_strFieldVal_FldName) Then
                            v_intIndex = j
                        End If
                    End If
                Next

                'Ä?iá»?u kiá»‡n xá»­ lÃ½
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
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub EnableResource(ByRef pv_ctrl As Windows.Forms.Control, ByRef pv_Enabled As Boolean)
        Dim v_ctrl As Windows.Forms.Control

        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is GroupBox Then
                'CType(v_ctrl, GroupBox).Enabled = pv_Enabled
                EnableResource(v_ctrl, pv_Enabled)
            ElseIf TypeOf (v_ctrl) Is SplitContainer Then
                'CType(v_ctrl, SplitContainer).Enabled = pv_Enabled
                EnableResource(v_ctrl, pv_Enabled)
            ElseIf TypeOf (v_ctrl) Is Panel Then
                'CType(v_ctrl, Panel).Enabled = pv_Enabled
                EnableResource(v_ctrl, pv_Enabled)
            ElseIf TypeOf (v_ctrl) Is Label Then
                CType(v_ctrl, Label).Enabled = pv_Enabled
            ElseIf TypeOf (v_ctrl) Is RichTextBox Then
                CType(v_ctrl, RichTextBox).Enabled = pv_Enabled
            ElseIf TypeOf (v_ctrl) Is CheckBox Then
                CType(v_ctrl, CheckBox).Enabled = pv_Enabled
            ElseIf TypeOf (v_ctrl) Is DateTimePicker Then
                CType(v_ctrl, DateTimePicker).Enabled = pv_Enabled
            ElseIf TypeOf (v_ctrl) Is Button Then
                'CType(v_ctrl, Button).Enabled = pv_Enabled
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                CType(v_ctrl, GroupBox).Enabled = pv_Enabled
            ElseIf TypeOf (v_ctrl) Is AppCore.ComboBoxEx Then
                CType(v_ctrl, AppCore.ComboBoxEx).Enabled = pv_Enabled
            ElseIf TypeOf (v_ctrl) Is ComboBox Then
                CType(v_ctrl, ComboBox).Enabled = pv_Enabled
            ElseIf TypeOf (v_ctrl) Is TextBox Then
                CType(v_ctrl, TextBox).Enabled = pv_Enabled
            ElseIf TypeOf (v_ctrl) Is MaskedTextBox Then
                CType(v_ctrl, MaskedTextBox).Enabled = pv_Enabled
            End If
        Next
        Panel1.Enabled = pv_Enabled
        If pv_Enabled = False Then
            Me.btnAdjust.Enabled = True
        Else
            Me.btnAdjust.Enabled = False
        End If
    End Sub

    Private Sub ResetScreen()
        Try
            Me.cboAFACCTNO.Clears()
            If Me.cboCODEID.Items.Count > 0 Then
                Me.cboCODEID.SelectedIndex = 0
            End If
            'If Me.cboBIDTYPE.Items.Count > 0 Then
            'Me.cboBIDTYPE.SelectedIndex = 0
            'End If
            Me.txtCUSTODYCD.Text = gc_COMPANY_CODE
            Me.txtCUSTODYCD.SelectionStart = Me.txtCUSTODYCD.Text.Trim.Length
            Me.txtCUTEDAMT.Text = "0"
            Me.txtCASHFEE.Text = "0"
            Me.CPSchdGrid.DataRows.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function VerifyRules(ByRef v_strTxMsg As String, ByVal v_intRow As Integer) As Boolean
        Try
            Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
            Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode, v_intIndex As Long, i, v_intCount As Integer
            Dim v_strFLDNAME As String, v_strFLDDEFNAME As String, v_strDATATYPE As String, v_strFLDVALUE As String
            Dim v_strERRMSG, v_strENERRMSG, v_strOPERATOR, v_strVALEXP, v_strVALEXP2 As String, v_strACTYPE, v_strDESC As String
            Dim v_dtVALEXP, v_dtVALEXP2, v_dtFLDVALUE As Date, v_strCMDSQL As String
            Dim v_ctl As Control, v_attrFLDNAME As Xml.XmlAttribute, v_attrDATATYPE As Xml.XmlAttribute, v_objEval As New Evaluator

            LoadScreen(Me.Tltxcd)
            v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, Me.Tltxcd, Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)
            v_xmlDocument.LoadXml(v_strTxMsg)
            v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")

            Dim v_LOGAUTOID As String
            v_LOGAUTOID = String.Empty
            For J As Integer = CPSchdGrid.DataRows.Count - 1 To 0 Step -1
                If CPSchdGrid.DataRows(J).Cells("X").Value = "X" Then
                    v_LOGAUTOID = v_LOGAUTOID & "<" & CPSchdGrid.DataRows(J).Cells("AUTOID").Value & ">"

                End If
            Next

            If mv_arrObjFields.GetLength(0) > 0 Then

                For v_intIndex = 0 To mv_arrObjFields.GetLength(0) - 1 Step 1
                    If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                        v_strFLDNAME = mv_arrObjFields(v_intIndex).FieldName
                        v_strDATATYPE = mv_arrObjFields(v_intIndex).DataType
                        Dim v_strFLDDesc As String
                        v_strFLDDesc = String.Empty
                        If Me.cboBIDTYPE.SelectedValue = "001" Then
                            v_strFLDDesc = mv_ResourceManager.GetString("frmCUWBIDDING_bidding")
                        Else
                            v_strFLDDesc = mv_ResourceManager.GetString("frmCUWBIDDING_auction")
                        End If

                        Select Case Trim(v_strFLDNAME)
                            Case "03" 'AFACCTNO,C
                                v_strFLDVALUE = Me.cboAFACCTNO.SelectedValue
                            Case "01" 'CODEID,C
                                v_strFLDVALUE = Me.cboCODEID.SelectedValue
                            Case "02" 'ISSUEDATE,D
                                v_strFLDVALUE = Me.dptISSUEDATE.Value
                            Case "05" 'TOTALAMT,N
                                v_strFLDVALUE = CDbl(Me.txtCUTEDAMT.Text) - CDbl(Me.txtCASHFEE.Text)
                            Case "10" 'CUTEDAMT,N
                                v_strFLDVALUE = CDbl(Me.txtCUTEDAMT.Text)
                            Case "04" 'CASHFEE,N
                                v_strFLDVALUE = CDbl(Me.txtCASHFEE.Text)
                            Case "88" 'CUSTODYCD,C
                                v_strFLDVALUE = Me.txtCUSTODYCD.Text.Replace(".", "").ToUpper
                            Case "06" 'LOGAUTOID,N
                                v_strFLDVALUE = v_LOGAUTOID
                            Case "07" 'BIDTYPE,C
                                v_strFLDVALUE = Me.cboBIDTYPE.SelectedValue
                            Case "30" 'DESC,C
                                v_strFLDVALUE = v_strFLDDesc 'String.Empty
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

                'v_LOGAUTOID = v_LOGAUTOID & ") "
            End If

            v_strTxMsg = v_xmlDocument.InnerXml
            Return True
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

#End Region

#Region "Control event"
    Private Sub txtCUSTODYCD_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCUSTODYCD.KeyUp
        Try
            If e.KeyCode = Keys.F5 Then
                Dim frm As New frmSearch(Me.UserLanguage)
                frm.TableName = "CUSTODYCD_TX"
                frm.ModuleCode = "CF"
                frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                frm.IsLocalSearch = gc_IsNotLocalMsg
                frm.IsLookup = "Y"
                frm.SearchOnInit = False
                frm.BranchId = Me.BranchId
                frm.TellerId = Me.TellerId
                frm.GroupCareBy = True
                frm.CareByFilter = True
                frm.ShowDialog()
                Me.txtCUSTODYCD.Text = Trim(frm.ReturnValue)
                frm.Dispose()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub getAccountInfo()
        Me.txtCUSTODYCD.Text = Me.txtCUSTODYCD.Text.ToUpper
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLString As String
            Dim v_lngCount As Long
            'Cache thong tin ve cac tieu khoan giao dich cua khach hang
            v_strSQLString = "select cf.fullname, cf.address, cf.idcode, to_char(cf.iddate, 'DD/MM/RRRR') iddate, cf.idplace " & ControlChars.CrLf _
                        & " from cfmast cf " & ControlChars.CrLf _
                        & " where cf.custodycd = '" & Me.txtCUSTODYCD.Text.ToUpper & "' "

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString)
            v_ws.Message(v_strObjMsg)

            mv_xmlCUSTOMER = New XmlDocumentEx
            mv_xmlCUSTOMER.LoadXml(v_strObjMsg)
            If Not mv_xmlCUSTOMER Is Nothing Then
                v_nodeList = mv_xmlCUSTOMER.SelectNodes("/ObjectMessage/ObjData")
                v_lngCount = v_nodeList.Count
                If v_lngCount = 0 Then

                    MessageBox.Show(mv_ResourceManager.GetString("INVALIDCUSTODYCD"), Me.Text, MessageBoxButtons.OK)
                    Exit Sub
                End If

                'Lay Thong tin AFACCTNO cho combobox.
                Dim v_strCmdSQL As String = "SELECT FILTERCD, VALUE, VALUECD, DISPLAY, EN_DISPLAY, DESCRIPTION FROM VW_CUSTODYCD_SUBACCOUNT_ACTIVE WHERE FILTERCD='" & Me.txtCUSTODYCD.Text.ToUpper & "' AND VALUE LIKE '%" & Me.AFACCTNO & "%'"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)
                FillComboEx(v_strObjMsg, cboAFACCTNO, "", Me.UserLanguage)
                If Me.cboAFACCTNO.Items.Count > 0 Then
                    Me.cboAFACCTNO.SelectedIndex = 0
                End If
            Else
                MessageBox.Show(mv_ResourceManager.GetString("INVALIDCUSTODYCD"), Me.Text, MessageBoxButtons.OK)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_ws = Nothing
        End Try
    End Sub

    Private Sub txtCUSTODYCD_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCUSTODYCD.Validating
        getAccountInfo()
    End Sub

    Private Sub cboAFACCTNO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboAFACCTNO.Validating
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strACTYPE, v_strSQLString, v_strCOREBANK, v_strBANKACCT, v_strBANKCODE, v_strMAXAVLAMT, v_strAVLADVANCE As String
            Dim v_dblBALDEFOVD As Long
            Dim v_lngCount As Long
            'Cache thong tin ve cac tieu khoan giao dich cua khach hang
            v_strSQLString = "select af.actype, af.acctno afacctno, (CASE WHEN CI.COREBANK='Y' THEN 1 ELSE 0 END) COREBANK, " & ControlChars.CrLf _
                        & " (CASE WHEN CI.COREBANK='Y' or AF.ALTERNATEACCT ='Y' THEN AF.BANKACCTNO ELSE NULL END) BANKACCT, " & ControlChars.CrLf _
                        & " (CASE WHEN CI.COREBANK='Y' or AF.ALTERNATEACCT ='Y' THEN AF.BANKNAME ELSE NULL END) BANKCODE, " & ControlChars.CrLf _
                        & " nvl(maxavlamt,0) maxavlamt, nvl(adv.advamt,0) - nvl(adv.paidamt,0) avladvance, nvl(adv.paidamt,0) dealpaidamt, " & ControlChars.CrLf _
                        & " nvl(maxavlamt,0) - (nvl(adv.advamt,0) - nvl(adv.paidamt,0)) feeadv, getbaldefovd(af.acctno) baldefovd " & ControlChars.CrLf _
                        & " from afmast af, cimast ci, (select ACCTNO, sum(maxavlamt) maxavlamt from vw_advanceschedule group by ACCTNO) sadv, v_getaccountavladvance adv  " & ControlChars.CrLf _
                        & " where af.acctno = ci.acctno and af.acctno = sadv.ACCTNO(+) " & ControlChars.CrLf _
                        & " and af.acctno = adv.afacctno(+) " & ControlChars.CrLf _
                        & " and af.acctno = '" & Me.cboAFACCTNO.SelectedValue & "'"


            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString)
            v_ws.Message(v_strObjMsg)

            mv_xmlCUSTOMER = New XmlDocumentEx
            mv_xmlCUSTOMER.LoadXml(v_strObjMsg)
            If Not mv_xmlCUSTOMER Is Nothing Then
                v_nodeList = mv_xmlCUSTOMER.SelectNodes("/ObjectMessage/ObjData")
                v_lngCount = v_nodeList.Count
                If v_lngCount = 0 Then
                    Me.CPSchdGrid.DataRows.Clear()
                    Exit Sub
                End If


                'Lay Thong tin AFACCTNO cho gridview.
                Dim v_strCmdSQL As String = "select '' X, lg.autoid, lg.afacctno, lg.txdate, LTRIM(TO_CHAR(lg.amt,'9,999,999,999')) amt, lg.txdesc " & ControlChars.CrLf _
                        & " from bidding1190log lg where lg.bdstatus='N' and lg.afacctno = '" & cboAFACCTNO.SelectedValue & "' and txtype='" & Me.cboBIDTYPE.SelectedValue & "' order by lg.txdate"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)

                CPSchdGrid.DataRows.Clear()
                FillDataGrid(CPSchdGrid, v_strObjMsg, "")

            Else
                MessageBox.Show(mv_ResourceManager.GetString("INVALIDACCTNO"), Me.Text, MessageBoxButtons.OK)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_ws = Nothing
        End Try
    End Sub

    

    

    Private Sub cboAFACCTNO_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAFACCTNO.SelectedValueChanged
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strACTYPE, v_strSQLString, v_strCOREBANK, v_strBANKACCT, v_strBANKCODE, v_strMAXAVLAMT, v_strAVLADVANCE As String
            Dim v_dblBALDEFOVD As Long
            Dim v_lngCount As Long
            'Cache thong tin ve cac tieu khoan giao dich cua khach hang
            v_strSQLString = "select af.actype, af.acctno afacctno, (CASE WHEN CI.COREBANK='Y' THEN 1 ELSE 0 END) COREBANK, " & ControlChars.CrLf _
                        & " (CASE WHEN CI.COREBANK='Y' or AF.ALTERNATEACCT ='Y' THEN AF.BANKACCTNO ELSE NULL END) BANKACCT, " & ControlChars.CrLf _
                        & " (CASE WHEN CI.COREBANK='Y' or AF.ALTERNATEACCT ='Y' THEN AF.BANKNAME ELSE NULL END) BANKCODE, " & ControlChars.CrLf _
                        & " nvl(maxavlamt,0) maxavlamt, nvl(adv.advamt,0) - nvl(adv.paidamt,0) avladvance, nvl(adv.paidamt,0) dealpaidamt, " & ControlChars.CrLf _
                        & " nvl(maxavlamt,0) - (nvl(adv.advamt,0) - nvl(adv.paidamt,0)) feeadv, getbaldefovd(af.acctno) baldefovd " & ControlChars.CrLf _
                        & " from afmast af, cimast ci, (select ACCTNO, sum(maxavlamt) maxavlamt from vw_advanceschedule group by ACCTNO) sadv, v_getaccountavladvance adv  " & ControlChars.CrLf _
                        & " where af.acctno = ci.acctno and af.acctno = sadv.ACCTNO(+) " & ControlChars.CrLf _
                        & " and af.acctno = adv.afacctno(+) " & ControlChars.CrLf _
                        & " and af.acctno = '" & Me.cboAFACCTNO.SelectedValue & "'"


            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString)
            v_ws.Message(v_strObjMsg)

            mv_xmlCUSTOMER = New XmlDocumentEx
            mv_xmlCUSTOMER.LoadXml(v_strObjMsg)
            If Not mv_xmlCUSTOMER Is Nothing Then
                v_nodeList = mv_xmlCUSTOMER.SelectNodes("/ObjectMessage/ObjData")
                v_lngCount = v_nodeList.Count
                If v_lngCount = 0 Then
                    Me.CPSchdGrid.DataRows.Clear()
                    Exit Sub
                End If


                'Lay Thong tin AFACCTNO cho gridview.
                Dim v_strCmdSQL As String = "select '' X, lg.autoid, lg.afacctno, lg.txdate, LTRIM(TO_CHAR(lg.amt,'9,999,999,999')) amt, lg.txdesc " & ControlChars.CrLf _
                        & " from bidding1190log lg where lg.bdstatus='N' and lg.afacctno = '" & cboAFACCTNO.SelectedValue & "' and txtype='" & Me.cboBIDTYPE.SelectedValue & "'  order by lg.txdate"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)

                CPSchdGrid.DataRows.Clear()
                FillDataGrid(CPSchdGrid, v_strObjMsg, "")

            Else
                MessageBox.Show(mv_ResourceManager.GetString("INVALIDACCTNO"), Me.Text, MessageBoxButtons.OK)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_ws = Nothing
        End Try
    End Sub

    Private Sub cboBIDTYPE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBIDTYPE.SelectedIndexChanged
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strACTYPE, v_strSQLString As String

            Dim v_lngCount As Long
            'Cache thong tin ve cac tieu khoan giao dich cua khach hang
            v_strSQLString = "select af.actype, af.acctno afacctno, (CASE WHEN CI.COREBANK='Y' THEN 1 ELSE 0 END) COREBANK, " & ControlChars.CrLf _
                        & " (CASE WHEN CI.COREBANK='Y' or AF.ALTERNATEACCT ='Y' THEN AF.BANKACCTNO ELSE NULL END) BANKACCT, " & ControlChars.CrLf _
                        & " (CASE WHEN CI.COREBANK='Y' or AF.ALTERNATEACCT ='Y' THEN AF.BANKNAME ELSE NULL END) BANKCODE, " & ControlChars.CrLf _
                        & " nvl(maxavlamt,0) maxavlamt, nvl(adv.advamt,0) - nvl(adv.paidamt,0) avladvance, nvl(adv.paidamt,0) dealpaidamt, " & ControlChars.CrLf _
                        & " nvl(maxavlamt,0) - (nvl(adv.advamt,0) - nvl(adv.paidamt,0)) feeadv, getbaldefovd(af.acctno) baldefovd " & ControlChars.CrLf _
                        & " from afmast af, cimast ci, (select ACCTNO, sum(maxavlamt) maxavlamt from vw_advanceschedule group by ACCTNO) sadv, v_getaccountavladvance adv  " & ControlChars.CrLf _
                        & " where af.acctno = ci.acctno and af.acctno = sadv.ACCTNO(+) " & ControlChars.CrLf _
                        & " and af.acctno = adv.afacctno(+) " & ControlChars.CrLf _
                        & " and af.acctno = '" & Me.cboAFACCTNO.SelectedValue & "'"


            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString)
            v_ws.Message(v_strObjMsg)

            mv_xmlCUSTOMER = New XmlDocumentEx
            mv_xmlCUSTOMER.LoadXml(v_strObjMsg)
            If Not mv_xmlCUSTOMER Is Nothing Then
                v_nodeList = mv_xmlCUSTOMER.SelectNodes("/ObjectMessage/ObjData")
                v_lngCount = v_nodeList.Count
                If v_lngCount = 0 Then
                    Me.CPSchdGrid.DataRows.Clear()
                    Exit Sub
                End If


                'Lay Thong tin AFACCTNO cho gridview.
                Dim v_strCmdSQL As String = "select '' X, lg.autoid, lg.afacctno, lg.txdate, LTRIM(TO_CHAR(lg.amt,'9,999,999,999')) amt, lg.txdesc " & ControlChars.CrLf _
                        & " from bidding1190log lg where lg.bdstatus='N' and lg.afacctno = '" & cboAFACCTNO.SelectedValue & "' and txtype='" & Me.cboBIDTYPE.SelectedValue & "'  order by lg.txdate"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)

                CPSchdGrid.DataRows.Clear()
                FillDataGrid(CPSchdGrid, v_strObjMsg, "")
                Me.txtCASHFEE.Text = 0
                Me.txtCUTEDAMT.Text = 0
            Else
                MessageBox.Show(mv_ResourceManager.GetString("INVALIDACCTNO"), Me.Text, MessageBoxButtons.OK)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_ws = Nothing
        End Try

    End Sub


    Private Sub cboBIDTYPE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboBIDTYPE.Validating
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strACTYPE, v_strSQLString As String
            Dim v_dblBALDEFOVD As Long
            Dim v_lngCount As Long
            'Cache thong tin ve cac tieu khoan giao dich cua khach hang
            v_strSQLString = "select af.actype, af.acctno afacctno, (CASE WHEN CI.COREBANK='Y' THEN 1 ELSE 0 END) COREBANK, " & ControlChars.CrLf _
                        & " (CASE WHEN CI.COREBANK='Y' or AF.ALTERNATEACCT ='Y' THEN AF.BANKACCTNO ELSE NULL END) BANKACCT, " & ControlChars.CrLf _
                        & " (CASE WHEN CI.COREBANK='Y' or AF.ALTERNATEACCT ='Y' THEN AF.BANKNAME ELSE NULL END) BANKCODE, " & ControlChars.CrLf _
                        & " nvl(maxavlamt,0) maxavlamt, nvl(adv.advamt,0) - nvl(adv.paidamt,0) avladvance, nvl(adv.paidamt,0) dealpaidamt, " & ControlChars.CrLf _
                        & " nvl(maxavlamt,0) - (nvl(adv.advamt,0) - nvl(adv.paidamt,0)) feeadv, getbaldefovd(af.acctno) baldefovd " & ControlChars.CrLf _
                        & " from afmast af, cimast ci, (select ACCTNO, sum(maxavlamt) maxavlamt from vw_advanceschedule group by ACCTNO) sadv, v_getaccountavladvance adv  " & ControlChars.CrLf _
                        & " where af.acctno = ci.acctno and af.acctno = sadv.ACCTNO(+) " & ControlChars.CrLf _
                        & " and af.acctno = adv.afacctno(+) " & ControlChars.CrLf _
                        & " and af.acctno = '" & Me.cboAFACCTNO.SelectedValue & "'"


            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString)
            v_ws.Message(v_strObjMsg)

            mv_xmlCUSTOMER = New XmlDocumentEx
            mv_xmlCUSTOMER.LoadXml(v_strObjMsg)
            If Not mv_xmlCUSTOMER Is Nothing Then
                v_nodeList = mv_xmlCUSTOMER.SelectNodes("/ObjectMessage/ObjData")
                v_lngCount = v_nodeList.Count
                If v_lngCount = 0 Then
                    Me.CPSchdGrid.DataRows.Clear()
                    Exit Sub
                End If


                'Lay Thong tin AFACCTNO cho gridview.
                Dim v_strCmdSQL As String = "select '' X, lg.autoid, lg.afacctno, lg.txdate, LTRIM(TO_CHAR(lg.amt,'9,999,999,999')) amt, lg.txdesc " & ControlChars.CrLf _
                        & " from bidding1190log lg where lg.bdstatus='N' and lg.afacctno = '" & cboAFACCTNO.SelectedValue & "' and txtype='" & Me.cboBIDTYPE.SelectedValue & "'  order by lg.txdate"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)

                CPSchdGrid.DataRows.Clear()
                FillDataGrid(CPSchdGrid, v_strObjMsg, "")
                Me.txtCASHFEE.Text = 0
                Me.txtCUTEDAMT.Text = 0
            Else
                MessageBox.Show(mv_ResourceManager.GetString("INVALIDACCTNO"), Me.Text, MessageBoxButtons.OK)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_ws = Nothing
        End Try
    End Sub

    Private Sub cboCODEID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCODEID.SelectedValueChanged
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strSQLString As String
            Dim v_lngCount As Long
            Dim v_ISSUEDATE As String
            'Cache thong tin chung khoan
            v_strSQLString = "select * from sbsecurities where codeid = '" & Me.cboCODEID.SelectedValue & "'"

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString)
            v_ws.Message(v_strObjMsg)

            mv_xmlCUSTOMER = New XmlDocumentEx
            mv_xmlCUSTOMER.LoadXml(v_strObjMsg)
            If Not mv_xmlCUSTOMER Is Nothing Then
                v_nodeList = mv_xmlCUSTOMER.SelectNodes("/ObjectMessage/ObjData")
                v_lngCount = v_nodeList.Count
                If v_lngCount = 0 Then
                    Me.CPSchdGrid.DataRows.Clear()
                    Exit Sub
                End If

                For i As Integer = 0 To v_lngCount - 1
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "ISSUEDATE" Then
                                v_ISSUEDATE = .InnerText.ToString
                            End If
                        End With
                    Next
                    If v_ISSUEDATE = String.Empty Then
                        Me.dptISSUEDATE.Text = ""
                    Else
                        Me.dptISSUEDATE.Value = CDate(v_ISSUEDATE)
                    End If

                    Exit For
                Next


            Else
                MessageBox.Show(mv_ResourceManager.GetString("INVALIDSYMBOL"), Me.Text, MessageBoxButtons.OK)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_ws = Nothing
        End Try
    End Sub

    Private Sub txtCASHFEE_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCASHFEE.Leave
        Try
            Me.txtCASHFEE.Text = Format(CDbl(Me.txtCASHFEE.Text), "#,##0")
        Catch ex As Exception
            MessageBox.Show(mv_ResourceManager.GetString("ERR_NUMBER_TYPE"), Me.Text, MessageBoxButtons.OK)
            Me.txtCASHFEE.Focus()
        End Try

    End Sub
   


    Private Sub txtCUTEDAMT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCUTEDAMT.TextChanged
        
        If CDbl(txtCUTEDAMT.Text) > 0 Then
            Me.btnApply.Enabled = True
        Else
            Me.btnApply.Enabled = False
        End If
    End Sub

#End Region

#Region "Button click"
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        Dim v_strTxMsg As String, v_xmlDocument As New Xml.XmlDocument, v_attrColl As Xml.XmlAttributeCollection
        Dim v_intNOSUBMIT As Integer, v_strNEXTTX As String = String.Empty
        Dim v_strErrorSource, v_strErrorMessage, v_strTXDESC As String, v_lngError As Long
        Dim v_ws As New BDSDeliveryManagement

        Dim v_blnSuccess As Boolean = False
        Try
            If Me.txtCUSTODYCD.Text.Trim = String.Empty OrElse CPSchdGrid.DataRows.Count = 0 OrElse Me.cboCODEID.Text.Trim = String.Empty Then
                Exit Sub
            End If
            'Me.cboADTYPE.Focus()
            allocCPSchd()

            If Me.txtCUSTODYCD.Enabled = True Then
                EnableResource(Me, False)
                'btnPRINT.Visible = False
            Else

                If Not ControlValidation() Then
                    Exit Sub
                End If
                'For k As Integer = 0 To CPSchdGrid.DataRows.Count - 1
                If CDbl(txtCUTEDAMT.Text) > 0 Then


                    'Verify và tạo điện giao dịch
                    If Not VerifyRules(v_strTxMsg, 0) Then
                        Exit Sub
                    Else
                        v_lngError = v_ws.Message(v_strTxMsg)
                        If v_lngError <> ERR_SYSTEM_OK And v_lngError <> ERR_SA_CHECKER1_OVR And v_lngError <> ERR_SA_CHECKER2_OVR Then
                            'Thong bao loi
                            GetErrorFromMessage(v_strTxMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                            Cursor.Current = Cursors.Default
                            Exit Sub

                        Else
                            'check duyet
                            If v_lngError = ERR_SA_CHECKER1_OVR Or v_lngError = ERR_SA_CHECKER2_OVR Then
                                'GetErrorFromMessage(v_strTxMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                                'Cursor.Current = Cursors.Default
                                'MessageBox.Show(v_strErrorMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                MessageBox.Show(mv_ResourceManager.GetString("ERR_SA_CHECKER_OVR"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If

                            'get Warning Message
                            Dim v_strWarningMessage, v_strInfoMessage As String
                            GetWarningFromMessage(v_strTxMsg, v_strWarningMessage, v_strInfoMessage)
                            Cursor.Current = Cursors.Default
                            If v_strInfoMessage <> String.Empty Then
                                MsgBox(v_strInfoMessage, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, Me.Text)
                            End If
                            If v_strWarningMessage <> String.Empty Then
                                If MsgBox(v_strWarningMessage, MsgBoxStyle.Critical + MsgBoxStyle.OkCancel, Me.Text) = MsgBoxResult.Cancel Then
                                    Exit Sub
                                End If
                            End If

                            v_xmlDocument.LoadXml(v_strTxMsg)
                            If v_xmlDocument.SelectSingleNode("TransactMessage").Attributes(gc_AtributeNOSUBMIT).InnerText = "2" AndAlso _
                                    v_xmlDocument.SelectSingleNode("TransactMessage").Attributes(gc_AtributePRETRAN).InnerText = "Y" Then
                                v_lngError = v_ws.Message(v_strTxMsg)
                                If v_lngError <> ERR_SYSTEM_OK Then
                                    'TThong bao loi
                                    GetErrorFromMessage(v_strTxMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                                    Cursor.Current = Cursors.Default
                                    If v_lngError <> ERR_SA_CHECKER1_OVR And v_lngError <> ERR_SA_CHECKER2_OVR Then
                                        MessageBox.Show(v_strErrorMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        Exit Sub
                                    End If
                                Else
                                    v_blnSuccess = True
                                    v_xmlDocument.LoadXml(v_strTxMsg)
                                    MessageData = v_xmlDocument.InnerXml

                                End If
                            Else
                                v_blnSuccess = True
                                MessageData = v_xmlDocument.InnerXml

                                MsgBox(cboAFACCTNO.SelectedValue & ". " & mv_ResourceManager.GetString("TransactionSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            End If
                        End If
                    End If

                End If

                If v_blnSuccess Then
                    MsgBox(mv_ResourceManager.GetString("TransactionSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    EnableResource(Me, True)
                    ResetScreen()
                    Me.btnCancel.Enabled = True
                End If
            End If
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function ControlValidation() As Boolean
        If Me.txtCUSTODYCD.TextLength = 0 OrElse CPSchdGrid.DataRows.Count = 0 Then
            MessageBox.Show(mv_ResourceManager.GetString("INVALIDCUSTINFO"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.cboCODEID.Focus()
            Return False
        End If

        allocCPSchd()

        Return True
    End Function

    Private Sub btnAdjust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdjust.Click
        Try
            EnableResource(Me, True)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

    Private Sub frmCUWBIDDING_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            If Me.CUSTODYCD Is Nothing Then
                Me.txtCUSTODYCD.Text = gc_COMPANY_CODE
                Me.txtCUSTODYCD.SelectionStart = Me.txtCUSTODYCD.Text.Trim.Length
                'Me.txtCUSTODYCD.Focus()

            Else
                Me.txtCUSTODYCD.Text = Me.CUSTODYCD
                Me.txtCUSTODYCD.Enabled = False
                getAccountInfo()
            End If



        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmCUWBIDDING_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                OnClose()
        End Select
    End Sub
End Class