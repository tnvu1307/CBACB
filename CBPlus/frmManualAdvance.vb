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

Public Class frmManualAdvance


    Const c_ResourceManager As String = "_DIRECT.frmManualAdvance-"
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
    Private ADVSchdGrid As AppCore.GridEx
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
    Private mv_strFEEONDAY As String

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
        Me.Tltxcd = gc_CI_DAY_ORDERADVANCEDPAYMENT
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
                CType(v_ctrl, DateTimePicker).Value = CDate(Me.BusDate)
            End If
        Next
        Me.Text = mv_ResourceManager.GetString("frmManualAdvance")

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
            Me.cboADTYPE.Clears()
            Me.txtACTYPE.Text = String.Empty
            Me.txtADDRESS.Text = String.Empty
            Me.txtADVAMT.Text = "0"
            Me.txtAVLADVAMT.Text = "0"
            Me.txtBANKACCT.Text = ""
            Me.txtBANKCODE.Text = ""
            Me.txtBALDEFOVD.Text = "0"
            Me.txtBNKMINBAL.Text = "0"
            Me.txtBNKRATE.Text = "0"
            Me.txtCMPMAXBAL.Text = "0"
            Me.txtCMPMINBAL.Text = "0"
            Me.txtCOREBANK.Text = ""
            Me.txtIDCODE.Text = ""
            Me.txtFULLNAME.Text = ""
            Me.txtIDDATE.Text = ""
            Me.txtIDPLACE.Text = ""
            Me.txtINTRATE.Text = "0"
            Me.txtMINADVAMT.Text = "0"
            Me.txtRCVADVAMT.Text = "0"
            Me.txtVAT.Text = "0"
            Me.ADVSchdGrid.DataRows.Clear()
            Me.btnPRINT.Visible = False
            If Me.CUSTODYCD Is Nothing Then
                Me.txtCUSTODYCD.Text = gc_COMPANY_CODE
                Me.txtCUSTODYCD.Focus()
            Else
                Me.txtCUSTODYCD.Text = Me.CUSTODYCD
                getAccountInfo()
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub InitExternal()
        ADVSchdGrid = New GridEx

        Dim v_cmrMemberHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrMemberHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrMemberHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        v_cmrMemberHeader.Height = 45

        ADVSchdGrid.FixedHeaderRows.Add(v_cmrMemberHeader)
        ADVSchdGrid.Columns.Add(New Xceed.Grid.Column("X", GetType(System.String)))
        ADVSchdGrid.Columns.Add(New Xceed.Grid.Column("ISVSD", GetType(System.String)))
        ADVSchdGrid.Columns.Add(New Xceed.Grid.Column("MATCHDATE", GetType(System.String)))
        ADVSchdGrid.Columns.Add(New Xceed.Grid.Column("DUEDATE", GetType(System.String)))
        ADVSchdGrid.Columns.Add(New Xceed.Grid.Column("DAYS", GetType(System.String)))
        ADVSchdGrid.Columns.Add(New Xceed.Grid.Column("AVLADVAMT", GetType(System.Double)))
        ADVSchdGrid.Columns.Add(New Xceed.Grid.Column("RCVADVAMT", GetType(System.Double)))
        ADVSchdGrid.Columns.Add(New Xceed.Grid.Column("ADVAMT", GetType(System.Double)))
        ADVSchdGrid.Columns.Add(New Xceed.Grid.Column("FEEAMT", GetType(System.Double)))
        ADVSchdGrid.Columns.Add(New Xceed.Grid.Column("BNKFEEAMT", GetType(System.Double)))
        ADVSchdGrid.Columns.Add(New Xceed.Grid.Column("VATAMT", GetType(System.Double)))
        ADVSchdGrid.Columns.Add(New Xceed.Grid.Column("TXDESC", GetType(System.String)))
        ADVSchdGrid.Columns.Add(New Xceed.Grid.Column("TXNUM", GetType(System.String)))
        ADVSchdGrid.Columns.Add(New Xceed.Grid.Column("FEEONDAY", GetType(System.String)))

        ADVSchdGrid.Columns("RCVADVAMT").Visible = False
        ADVSchdGrid.Columns("TXNUM").Visible = False
        ADVSchdGrid.Columns("VATAMT").Visible = False
        ADVSchdGrid.Columns("BNKFEEAMT").Visible = False
        ADVSchdGrid.Columns("X").Title = "X"
        ADVSchdGrid.Columns("ISVSD").Title = mv_ResourceManager.GetString("ADVSCHD_ISVSD")
        ADVSchdGrid.Columns("MATCHDATE").Title = mv_ResourceManager.GetString("ADVSCHD_MATCHDATE")
        ADVSchdGrid.Columns("DUEDATE").Title = mv_ResourceManager.GetString("ADVSCHD_DUEDATE")
        ADVSchdGrid.Columns("DAYS").Title = mv_ResourceManager.GetString("ADVSCHD_DAYS")
        ADVSchdGrid.Columns("AVLADVAMT").Title = mv_ResourceManager.GetString("ADVSCHD_AVLADVAMT")
        ADVSchdGrid.Columns("RCVADVAMT").Title = mv_ResourceManager.GetString("ADVSCHD_RCVADVAMT")
        ADVSchdGrid.Columns("ADVAMT").Title = mv_ResourceManager.GetString("ADVSCHD_ADVAMT")
        ADVSchdGrid.Columns("FEEAMT").Title = mv_ResourceManager.GetString("ADVSCHD_FEEAMT")
        ADVSchdGrid.Columns("BNKFEEAMT").Title = mv_ResourceManager.GetString("ADVSCHD_BNKFEEAMT")
        ADVSchdGrid.Columns("VATAMT").Title = mv_ResourceManager.GetString("ADVSCHD_VATAMT")
        ADVSchdGrid.Columns("TXDESC").Title = mv_ResourceManager.GetString("ADVSCHD_DESC")
        ADVSchdGrid.Columns("TXNUM").Title = "TXNUM"
        ADVSchdGrid.Columns("FEEONDAY").Title = "FEEONDAY"


        ADVSchdGrid.Columns("X").Width = 20
        ADVSchdGrid.Columns("ISVSD").Width = 20
        ADVSchdGrid.Columns("MATCHDATE").Width = 65
        ADVSchdGrid.Columns("DUEDATE").Width = 65
        ADVSchdGrid.Columns("DAYS").Width = 50
        ADVSchdGrid.Columns("AVLADVAMT").Width = 80
        ADVSchdGrid.Columns("RCVADVAMT").Width = 80
        ADVSchdGrid.Columns("ADVAMT").Width = 80
        ADVSchdGrid.Columns("FEEAMT").Width = 80
        ADVSchdGrid.Columns("BNKFEEAMT").Width = 80
        ADVSchdGrid.Columns("VATAMT").Width = 80
        ADVSchdGrid.Columns("TXDESC").Width = 350
        ADVSchdGrid.Columns("TXNUM").Width = 0
        ADVSchdGrid.Columns("FEEONDAY").Width = 0


        ADVSchdGrid.Columns("AVLADVAMT").FormatSpecifier = "#,##0"
        ADVSchdGrid.Columns("RCVADVAMT").FormatSpecifier = "#,##0"
        ADVSchdGrid.Columns("ADVAMT").FormatSpecifier = "#,##0"
        ADVSchdGrid.Columns("FEEAMT").FormatSpecifier = "#,##0"
        ADVSchdGrid.Columns("BNKFEEAMT").FormatSpecifier = "#,##0"
        ADVSchdGrid.Columns("VATAMT").FormatSpecifier = "#,##0"

        ADVSchdGrid.Columns("TXDESC").ReadOnly = False

        ADVSchdGrid.Columns("ISVSD").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        ADVSchdGrid.Columns("MATCHDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        ADVSchdGrid.Columns("DUEDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        ADVSchdGrid.Columns("DAYS").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        ADVSchdGrid.Columns("AVLADVAMT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        ADVSchdGrid.Columns("RCVADVAMT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        ADVSchdGrid.Columns("ADVAMT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        ADVSchdGrid.Columns("FEEAMT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        ADVSchdGrid.Columns("BNKFEEAMT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        ADVSchdGrid.Columns("VATAMT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
        ADVSchdGrid.Columns("TXDESC").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ADVSchdGrid.Columns("TXNUM").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ADVSchdGrid.Columns("FEEONDAY").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left

        ADVSchdGrid.Columns("DAYS").SortDirection = Xceed.Grid.SortDirection.Ascending

        'Bat su kien Click va double click
        If Me.ADVSchdGrid.DataRowTemplate.Cells.Count >= 0 Then
            For i As Integer = 0 To Me.ADVSchdGrid.DataRowTemplate.Cells.Count - 1
                AddHandler ADVSchdGrid.DataRowTemplate.Cells(i).DoubleClick, AddressOf Grid_DblClick
                AddHandler ADVSchdGrid.DataRowTemplate.Cells(i).Click, AddressOf Grid_Click
            Next
        End If
        Me.Panel1.Controls.Clear()
        Me.Panel1.Controls.Add(ADVSchdGrid)
        ADVSchdGrid.Dock = Windows.Forms.DockStyle.Fill
        btnPRINT.Visible = False
    End Sub


    Private Function ControlValidation() As Boolean
        If Me.txtCUSTODYCD.TextLength = 0 OrElse ADVSchdGrid.DataRows.Count = 0 Then
            MessageBox.Show(mv_ResourceManager.GetString("INVALIDCUSTINFO"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.txtCUSTODYCD.Focus()
            Return False
        End If
        If Me.txtADVAMT.Text.Trim.Length = 0 OrElse CDbl(Me.txtADVAMT.Text) = 0 Then
            MessageBox.Show(mv_ResourceManager.GetString("INVALIDADVAMT"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.txtADVAMT.Focus()
            Return False
        End If
        Me.cboADTYPE.Focus()
        allocAdvSchd()

        Return True
    End Function


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

            'Láº¥y thÃ´ng tin chung vá»? giao dá»‹ch
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
                'Náº¿u khÃ´ng tá»“n táº¡i mÃ£ giao dá»‹ch
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

            'Láº¥y thÃ´ng tin chi tiáº¿t cÃ¡c trÆ°á»?ng cá»§a giao dá»‹ch
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
                        'Láº¥y ngÃ y lÃ m viá»‡c hiá»‡n táº¡i
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
                        'Náº¿u giao dá»‹ch cÃ³ dá»¯ liá»‡u (xem chi tiáº¿t)
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

            'Láº¥y cÃ¡c luáº­t kiá»ƒm tra cá»§a cÃ¡c trÆ°á»?ng giao dá»‹ch
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
                        'Ghi nháº­n thuáº­t toÃ¡n Ä‘á»ƒ kiá»ƒm tra vÃ  tÃ­nh toÃ¡n cho tá»«ng trÆ°á»?ng cá»§a giao dá»‹ch
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
            If mv_arrObjFields.GetLength(0) > 0 Then

                For v_intIndex = 0 To mv_arrObjFields.GetLength(0) - 1 Step 1
                    If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                        v_strFLDNAME = mv_arrObjFields(v_intIndex).FieldName
                        v_strDATATYPE = mv_arrObjFields(v_intIndex).DataType
                        Select Case Trim(v_strFLDNAME)
                            Case "03" 'ACCTNO,C
                                v_strFLDVALUE = Me.cboAFACCTNO.SelectedValue
                            Case "06" 'ADTYPE,C
                                v_strFLDVALUE = Me.cboADTYPE.SelectedValue
                            Case "08" 'DUEDATE,D
                                v_strFLDVALUE = ADVSchdGrid.DataRows(v_intRow).Cells("DUEDATE").Value
                            Case "09" 'ADVAMT,N
                                v_strFLDVALUE = CDbl(ADVSchdGrid.DataRows(v_intRow).Cells("ADVAMT").Value) + CDbl(ADVSchdGrid.DataRows(v_intRow).Cells("FEEAMT").Value)
                            Case "10" 'AMT,N
                                v_strFLDVALUE = CDbl(ADVSchdGrid.DataRows(v_intRow).Cells("ADVAMT").Value)
                            Case "11" 'FEEAMT,N
                                v_strFLDVALUE = ADVSchdGrid.DataRows(v_intRow).Cells("FEEAMT").Value
                            Case "12" 'INTRATE,N
                                v_strFLDVALUE = Me.txtINTRATE.Text
                            Case "13" 'DAYS,N
                                v_strFLDVALUE = ADVSchdGrid.DataRows(v_intRow).Cells("DAYS").Value
                            Case "14" 'BNKFEEAMT,N
                                v_strFLDVALUE = ADVSchdGrid.DataRows(v_intRow).Cells("BNKFEEAMT").Value
                            Case "15" 'BNKRATE,N
                                v_strFLDVALUE = Me.txtBNKRATE.Text
                            Case "16" 'CMPMINBAL,N
                                v_strFLDVALUE = Me.txtCMPMINBAL.Text
                            Case "17" 'BNKMINBAL,N
                                v_strFLDVALUE = Me.txtBNKMINBAL.Text
                            Case "18" 'VATAMT,N
                                v_strFLDVALUE = ADVSchdGrid.DataRows(v_intRow).Cells("VATAMT").Value
                            Case "19" 'VAT,N
                                v_strFLDVALUE = Me.txtVAT.Text
                            Case "20" 'MAXAMT,N
                                v_strFLDVALUE = ADVSchdGrid.DataRows(v_intRow).Cells("AVLADVAMT").Value
                            Case "21" 'AMINBAL,N
                                v_strFLDVALUE = CDbl(Me.txtMINADVAMT.Text) - CDbl(Me.txtCMPMINBAL.Text)
                            Case "22" 'CMPMAXBAL,N
                                v_strFLDVALUE = Me.txtCMPMAXBAL.Text
                            Case "30" 'DESC,C
                                If Me.CUSTODYCD Is Nothing Then
                                    v_strFLDVALUE = ADVSchdGrid.DataRows(v_intRow).Cells("TXDESC").Value
                                Else
                                    v_strFLDVALUE = ADVSchdGrid.DataRows(v_intRow).Cells("TXDESC").Value & " (Tele)"
                                End If

                            Case "40" '36000,C
                                v_strFLDVALUE = "36500"
                            Case "41" '100,C
                                v_strFLDVALUE = "100"
                            Case "42" 'MATCHDATE,D
                                v_strFLDVALUE = ADVSchdGrid.DataRows(v_intRow).Cells("MATCHDATE").Value
                            Case "88" 'CUSTODYCD,C
                                v_strFLDVALUE = Me.txtCUSTODYCD.Text.Replace(".", "").ToUpper
                            Case "89" 'ACTYPE,C
                                v_strFLDVALUE = Me.txtACTYPE.Text
                            Case "90" 'CUSTNAME,C
                                v_strFLDVALUE = Me.txtFULLNAME.Text
                            Case "91" 'ADDRESS,C
                                v_strFLDVALUE = Me.txtADDRESS.Text
                            Case "92" 'LICENSE,C
                                v_strFLDVALUE = Me.txtIDCODE.Text
                            Case "93" 'BANKACCT,C
                                v_strFLDVALUE = Me.txtBANKACCT.Text
                            Case "94" 'COREBANK,C
                                v_strFLDVALUE = Me.txtCOREBANK.Text
                            Case "95" 'BANKCODE,C
                                v_strFLDVALUE = Me.txtBANKCODE.Text
                            Case "96" 'IDDATE,D
                                v_strFLDVALUE = Me.txtIDDATE.Text
                            Case "97" 'IDPLACE,C
                                v_strFLDVALUE = Me.txtIDPLACE.Text
                            Case "60" 'ISVSD
                                v_strFLDVALUE = IIf(ADVSchdGrid.DataRows(v_intRow).Cells("ISVSD").Value = "N", 0, 1)
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
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    Private Sub allocAdvSchd()
        Dim v_dblCMPFEE, v_dblMaxFee, v_dblMinFee, v_dblAddFee, v_dblBNKFEE, v_dblVAT, v_dblADVAMT, v_dblSUMRCVADVAMT, v_dblREMAIN_DEALPAIDAMT As Double
        v_dblREMAIN_DEALPAIDAMT = mv_dblDEALPAIDAMT
        Dim v_dblToTalCMPFEE, v_dblRealToTalCMPFEE, v_dblGAPCMPFEE As Double
        Dim v_intMaxIndex As Integer
        Try
            v_dblADVAMT = CDbl(Me.txtADVAMT.Text)
            ADVSchdGrid.Columns("DAYS").SortDirection = Xceed.Grid.SortDirection.Ascending
            ADVSchdGrid.Refresh()
            v_dblSUMRCVADVAMT = 0
            'For i As Integer = ADVSchdGrid.DataRows.Count - 1 To 0 Step -1
            '    If ADVSchdGrid.DataRows(i).Cells("X").Value = "X" Then
            '        'Set RCVADVAMT
            '        v_dblCMPFEE = Math.Ceiling(Math.Max(CDbl(ADVSchdGrid.DataRows(i).Cells("AVLADVAMT").Value) * CDbl(ADVSchdGrid.DataRows(i).Cells("DAYS").Value) * CDbl(Me.txtINTRATE.Text) / 360 / 100, CDbl(Me.txtMINADVAMT.Text)))
            '        ADVSchdGrid.DataRows(i).Cells("RCVADVAMT").Value = Math.Max(CDbl(ADVSchdGrid.DataRows(i).Cells("AVLADVAMT").Value) - v_dblCMPFEE, 0)
            '        'v_dblREMAIN_DEALPAIDAMT = Math.Max(v_dblREMAIN_DEALPAIDAMT - (CDbl(ADVSchdGrid.DataRows(i).Cells("AVLADVAMT").Value) - v_dblCMPFEE, 0)
            '        'End set RCVADVAMT
            '        v_dblSUMRCVADVAMT = v_dblSUMRCVADVAMT + CDbl(ADVSchdGrid.DataRows(i).Cells("RCVADVAMT").Value)
            '    End If
            'Next
            For i As Integer = ADVSchdGrid.DataRows.Count - 1 To 0 Step -1
                If ADVSchdGrid.DataRows(i).Cells("X").Value = "X" Then
                    v_intMaxIndex = i
                    Exit For
                End If
            Next
            v_dblCMPFEE = 0
            For i As Integer = ADVSchdGrid.DataRows.Count - 1 To 0 Step -1
                If ADVSchdGrid.DataRows(i).Cells("X").Value = "X" Then
                    'v_dblCMPFEE = v_dblCMPFEE + Math.Ceiling(CDbl(ADVSchdGrid.DataRows(i).Cells("AVLADVAMT").Value) * CDbl(ADVSchdGrid.DataRows(i).Cells("DAYS").Value) * CDbl(Me.txtINTRATE.Text) / 360 / 100 / (1 + CDbl(ADVSchdGrid.DataRows(i).Cells("DAYS").Value) * CDbl(Me.txtINTRATE.Text) / 360 / 100))
                    v_dblCMPFEE = v_dblCMPFEE + Math.Ceiling(CDbl(ADVSchdGrid.DataRows(i).Cells("AVLADVAMT").Value) * CDbl(ADVSchdGrid.DataRows(i).Cells("DAYS").Value) * CDbl(Me.txtINTRATE.Text) / 360 / 100)
                End If
            Next
            v_dblToTalCMPFEE = v_dblCMPFEE
            v_dblRealToTalCMPFEE = Math.Max(v_dblCMPFEE, CDbl(Me.txtCMPMINBAL.Text))
            v_dblGAPCMPFEE = v_dblRealToTalCMPFEE - v_dblToTalCMPFEE
            For i As Integer = ADVSchdGrid.DataRows.Count - 1 To 0 Step -1
                If ADVSchdGrid.DataRows(i).Cells("X").Value = "X" Then
                    'v_dblCMPFEE = Math.Ceiling(CDbl(ADVSchdGrid.DataRows(i).Cells("AVLADVAMT").Value) * CDbl(ADVSchdGrid.DataRows(i).Cells("DAYS").Value) * CDbl(Me.txtINTRATE.Text) / 360 / 100 / (1 + CDbl(ADVSchdGrid.DataRows(i).Cells("DAYS").Value) * CDbl(Me.txtINTRATE.Text) / 360 / 100))
                    ''T11/2015 TTBT T+2. Begin
                    ''04/11/2015 TruongLD Add: Neu FEEONDAY ='Y' 
                    'If mv_strFEEONDAY = "N" And ADVSchdGrid.DataRows(i).Cells("DUEDATE").Value = Me.BusDate Then
                    '    ADVSchdGrid.DataRows(i).Cells("DAYS").Value = "0"
                    'ElseIf mv_strFEEONDAY <> "N" And ADVSchdGrid.DataRows(i).Cells("DUEDATE").Value = Me.BusDate Then
                    '    If ADVSchdGrid.DataRows(i).Cells("DAYS").Value = "0" Then
                    '        ADVSchdGrid.DataRows(i).Cells("DAYS").Value = "1"
                    '    End If
                    'End If
                    ''End TruongLD

                    v_dblCMPFEE = Math.Ceiling(CDbl(ADVSchdGrid.DataRows(i).Cells("AVLADVAMT").Value) * CDbl(ADVSchdGrid.DataRows(i).Cells("DAYS").Value) * CDbl(Me.txtINTRATE.Text) / 360 / 100)
                    If i = v_intMaxIndex Then
                        v_dblCMPFEE = Math.Min(v_dblCMPFEE + v_dblGAPCMPFEE, v_dblRealToTalCMPFEE)
                    Else
                        v_dblCMPFEE = Math.Min(v_dblCMPFEE, v_dblRealToTalCMPFEE)
                    End If

                    v_dblRealToTalCMPFEE = v_dblRealToTalCMPFEE - v_dblCMPFEE
                    'T11/2015 TTBT T+2. Begin
                    '02/11/2015 DieuNDA: TH so ngay ung = 0 thi khong tru phi Min
                    'ADVSchdGrid.DataRows(i).Cells("RCVADVAMT").Value = Math.Max(CDbl(ADVSchdGrid.DataRows(i).Cells("AVLADVAMT").Value) - v_dblCMPFEE, 0)
                    If CDbl(ADVSchdGrid.DataRows(i).Cells("DAYS").Value) <> 0 Then
                        ADVSchdGrid.DataRows(i).Cells("RCVADVAMT").Value = Math.Max(CDbl(ADVSchdGrid.DataRows(i).Cells("AVLADVAMT").Value) - v_dblCMPFEE, 0)
                    Else
                        ADVSchdGrid.DataRows(i).Cells("RCVADVAMT").Value = CDbl(ADVSchdGrid.DataRows(i).Cells("AVLADVAMT").Value)
                    End If
                    'T11/2015 TTBT T+2. End
                    v_dblSUMRCVADVAMT = v_dblSUMRCVADVAMT + CDbl(ADVSchdGrid.DataRows(i).Cells("RCVADVAMT").Value)
                Else
                    ADVSchdGrid.DataRows(i).Cells("RCVADVAMT").Value = CDbl("0")
                    ADVSchdGrid.DataRows(i).Cells("FEEAMT").Value = CDbl("0")
                    ADVSchdGrid.DataRows(i).Cells("BNKFEEAMT").Value = CDbl("0")
                    ADVSchdGrid.DataRows(i).Cells("VATAMT").Value = CDbl("0")
                    ADVSchdGrid.DataRows(i).Cells("ADVAMT").Value = CDbl("0")
                End If
            Next

            Me.txtRCVADVAMT.Text = Format(v_dblSUMRCVADVAMT, "#,##0")
            Me.txtADVAMT.Text = Format(Math.Min(v_dblSUMRCVADVAMT, CDbl(Me.txtADVAMT.Text)), "#,##0")
            v_dblADVAMT = CDbl(Me.txtADVAMT.Text)
            v_dblCMPFEE = 0
            v_dblMinFee = CDbl(Me.txtCMPMINBAL.Text)
            v_dblToTalCMPFEE = 0
            v_dblRealToTalCMPFEE = 0
            'If CDbl(Me.txtADVAMT.Text) <> 0 Then
            For i As Integer = 0 To ADVSchdGrid.DataRows.Count - 1
                If ADVSchdGrid.DataRows(i).Cells("X").Value = "X" And CDbl(Me.txtADVAMT.Text) <> 0 Then
                    If v_dblADVAMT > CDbl(ADVSchdGrid.DataRows(i).Cells("RCVADVAMT").Value) Then
                        ADVSchdGrid.DataRows(i).Cells("ADVAMT").Value = CDbl(ADVSchdGrid.DataRows(i).Cells("RCVADVAMT").Value)
                        'v_dblADVAMT = v_dblADVAMT - CDbl(ADVSchdGrid.DataRows(i).Cells("RCVADVAMT").Value)
                    Else
                        ADVSchdGrid.DataRows(i).Cells("ADVAMT").Value = v_dblADVAMT
                        'v_dblADVAMT = 0
                    End If
                    If CDbl(ADVSchdGrid.DataRows(i).Cells("ADVAMT").Value) <> 0 Then
                        'v_dblCMPFEE = Math.Ceiling(CDbl(ADVSchdGrid.DataRows(i).Cells("ADVAMT").Value) * CDbl(ADVSchdGrid.DataRows(i).Cells("DAYS").Value) * CDbl(Me.txtINTRATE.Text) / 365 / 100)
                        'longnh sua lai cong thuc tinh phi ung
                        'v_dblCMPFEE = Math.Ceiling((CDbl(ADVSchdGrid.DataRows(i).Cells("ADVAMT").Value) * CDbl(ADVSchdGrid.DataRows(i).Cells("DAYS").Value) * CDbl(Me.txtINTRATE.Text) / 360 / 100) / (1 - CDbl(ADVSchdGrid.DataRows(i).Cells("DAYS").Value) * CDbl(Me.txtINTRATE.Text) / 360 / 100))
                        Dim v_dblRATE As Double
                        v_dblRATE = CDbl(ADVSchdGrid.DataRows(i).Cells("DAYS").Value) * CDbl(Me.txtINTRATE.Text) / 360 / 100 'tỷ lệ phí 
                        v_dblCMPFEE = Math.Ceiling((CDbl(ADVSchdGrid.DataRows(i).Cells("ADVAMT").Value) * v_dblRATE) / (1 - v_dblRATE))
                        v_dblToTalCMPFEE = v_dblToTalCMPFEE + v_dblCMPFEE
                        'T10/2015 TTBT T+2. Begin
                        '29/10/2015 DieuNDA: TH So ngay ung = 0 thi khong tinh phi
                        If CDbl(ADVSchdGrid.DataRows(i).Cells("DAYS").Value) <> 0 Then
                            ADVSchdGrid.DataRows(i).Cells("FEEAMT").Value = v_dblCMPFEE
                        Else
                            ADVSchdGrid.DataRows(i).Cells("FEEAMT").Value = CDbl("0")
                        End If
                        'T10/2015 TTBT T+2. End

                        ADVSchdGrid.DataRows(i).Cells("BNKFEEAMT").Value = CDbl("0")
                        ADVSchdGrid.DataRows(i).Cells("VATAMT").Value = CDbl("0")
                        ADVSchdGrid.DataRows(i).Cells("ADVAMT").Value = Math.Min(Math.Max(Math.Min(CDbl(ADVSchdGrid.DataRows(i).Cells("ADVAMT").Value), CDbl(ADVSchdGrid.DataRows(i).Cells("AVLADVAMT").Value) - CDbl(ADVSchdGrid.DataRows(i).Cells("FEEAMT").Value)), 0), v_dblADVAMT)
                    Else
                        ADVSchdGrid.DataRows(i).Cells("FEEAMT").Value = CDbl("0")
                        ADVSchdGrid.DataRows(i).Cells("BNKFEEAMT").Value = CDbl("0")
                        ADVSchdGrid.DataRows(i).Cells("VATAMT").Value = CDbl("0")
                    End If
                    v_dblADVAMT = v_dblADVAMT - CDbl(ADVSchdGrid.DataRows(i).Cells("ADVAMT").Value)
                Else
                    ADVSchdGrid.DataRows(i).Cells("RCVADVAMT").Value = CDbl("0")
                    ADVSchdGrid.DataRows(i).Cells("FEEAMT").Value = CDbl("0")
                    ADVSchdGrid.DataRows(i).Cells("BNKFEEAMT").Value = CDbl("0")
                    ADVSchdGrid.DataRows(i).Cells("VATAMT").Value = CDbl("0")
                    ADVSchdGrid.DataRows(i).Cells("ADVAMT").Value = CDbl("0")
                End If
            Next
            ' Phân bổ phần chênh lệch phí Min cho các dòng còn dư tiền
            If v_dblToTalCMPFEE < v_dblMinFee And CDbl(Me.txtADVAMT.Text) <> 0 Then
                Dim v_realFee = Math.Max(v_dblGAPCMPFEE, v_dblMinFee)
                v_dblGAPCMPFEE = v_dblMinFee - v_dblToTalCMPFEE
                For i As Integer = 0 To ADVSchdGrid.DataRows.Count - 1
                    If ADVSchdGrid.DataRows(i).Cells("X").Value = "X" And CDbl(ADVSchdGrid.DataRows(i).Cells("DAYS").Value) <> 0 And CDbl(ADVSchdGrid.DataRows(i).Cells("ADVAMT").Value) <> 0 Then
                        'If CDbl(ADVSchdGrid.DataRows(i).Cells("ADVAMT").Value) = 0 Then
                        '    ADVSchdGrid.DataRows(i).Cells("FEEAMT").Value = "0"
                        'Else
                        If (CDbl(ADVSchdGrid.DataRows(i).Cells("AVLADVAMT").Value) - CDbl(ADVSchdGrid.DataRows(i).Cells("ADVAMT").Value) - CDbl(ADVSchdGrid.DataRows(i).Cells("FEEAMT").Value) > 1 And CDbl(ADVSchdGrid.DataRows(i).Cells("ADVAMT").Value) <> 0) Then
                            ADVSchdGrid.DataRows(i).Cells("FEEAMT").Value = CDbl(ADVSchdGrid.DataRows(i).Cells("FEEAMT").Value) + Math.Min(v_dblGAPCMPFEE, CDbl(ADVSchdGrid.DataRows(i).Cells("AVLADVAMT").Value) - CDbl(ADVSchdGrid.DataRows(i).Cells("ADVAMT").Value) - CDbl(ADVSchdGrid.DataRows(i).Cells("FEEAMT").Value))
                            v_realFee = v_realFee - CDbl(ADVSchdGrid.DataRows(i).Cells("FEEAMT").Value)
                            v_dblGAPCMPFEE = v_dblGAPCMPFEE - Math.Min(v_dblGAPCMPFEE, CDbl(ADVSchdGrid.DataRows(i).Cells("AVLADVAMT").Value) - CDbl(ADVSchdGrid.DataRows(i).Cells("ADVAMT").Value) - CDbl(ADVSchdGrid.DataRows(i).Cells("FEEAMT").Value))
                            If v_dblGAPCMPFEE <= 0 Then
                                Exit For
                            End If
                        ElseIf v_dblGAPCMPFEE > 0 Then
                            ADVSchdGrid.DataRows(i).Cells("FEEAMT").Value = CDbl(ADVSchdGrid.DataRows(i).Cells("FEEAMT").Value) + Math.Min(v_realFee, CDbl(ADVSchdGrid.DataRows(i).Cells("AVLADVAMT").Value) - CDbl(ADVSchdGrid.DataRows(i).Cells("ADVAMT").Value) - CDbl(ADVSchdGrid.DataRows(i).Cells("FEEAMT").Value))
                        End If
                        'End If
                    End If
                Next
            End If

            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LoadADVSchdGrid()
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL As String
        Try
            If Me.cboADTYPE.Items.Count > 0 Then
                v_strCmdSQL = "select X, ISVSD, MATCHDATE, DUEDATE, days, " & ControlChars.CrLf _
                    & " GREATEST(maxavlamt - round(case when to_date(varvalue,'DD/MM/RRRR') = MATCHDATE AND ISVSD='N'" & ControlChars.CrLf _
                    & " then fn_getdealgrppaid(ACCTNO) * (1+ADVRATE/100/360*days) else 0 end,0),0) AVLADVAMT," & ControlChars.CrLf _
                    & " RCVADVAMT, ADVAMT, FEEAMT, BNKFEEAMT, VATAMT, TXDESC, TXNUM" & ControlChars.CrLf _
                    & " from(" & ControlChars.CrLf _
                    & " select 'X' X,ISVSD, txdate MATCHDATE, cleardate DUEDATE,adv.acctno," & ControlChars.CrLf _
                    & " case when adv.cleardate = adv.currdate then decode(adt.feeonday,'Y',1,0) else adv.cleardate - adv.currdate end days, " & ControlChars.CrLf _
                    & " maxavlamt, sys.varvalue,  fn_getdealgrppaid(adv.ACCTNO),adt.ADVRATE, " & ControlChars.CrLf _
                    & " 0 RCVADVAMT, 0 ADVAMT, 0 FEEAMT, 0 BNKFEEAMT, 0 VATAMT, 'Ứng trước tiền lệnh bán ngày: ' || to_char(txdate,'DD/MM/RRRR') TXDESC, '' TXNUM   " & ControlChars.CrLf _
                    & " from vw_advanceschedule adv, SYSVAR SYS, aftype aft, adtype adt, VW_AF_ADTYPE_INFO adf  " & ControlChars.CrLf _
                    & " where acctno = '" & cboAFACCTNO.SelectedValue & "' and sys.varname = 'CURRDATE' and sys.grname = 'SYSTEM'  " & ControlChars.CrLf _
                    & " and adv.actype = aft.actype" & ControlChars.CrLf _
                    & " and aft.actype = ADF.FILTERCD and ADF.VALUE = ADT.ACTYPE and adf.value = '" & cboADTYPE.SelectedValue & "'" & ControlChars.CrLf _
                    & " ) order by days asc, DUEDATE asc, MATCHDATE asc "   'T11/2015 TTBT T+2: Order by Theo so ngay ung va Ngay thanh toan
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)
            Else
                v_strCmdSQL = "select 'X' X,ISVSD, txdate MATCHDATE, cleardate DUEDATE, days,  " & ControlChars.CrLf _
                    & " GREATEST(maxavlamt - round(case when to_date(sys.varvalue,'DD/MM/RRRR') = txdate AND ISVSD='N'  " & ControlChars.CrLf _
                    & " then fn_getdealgrppaid(adv.ACCTNO) * (1+adt.ADVRATE/100/360*days) else 0 end,0),0) AVLADVAMT,  " & ControlChars.CrLf _
                    & " 0 RCVADVAMT, 0 ADVAMT, 0 FEEAMT, 0 BNKFEEAMT, 0 VATAMT, 'Ứng trước tiền lệnh bán ngày: ' || to_char(txdate,'DD/MM/RRRR') TXDESC, '' TXNUM   " & ControlChars.CrLf _
                    & " from vw_advanceschedule adv, SYSVAR SYS, aftype aft, adtype adt  " & ControlChars.CrLf _
                    & " where acctno = '" & cboAFACCTNO.SelectedValue & "' and sys.varname = 'CURRDATE' and sys.grname = 'SYSTEM'  " & ControlChars.CrLf _
                    & " and adv.actype = aft.actype" & ControlChars.CrLf _
                    & " and aft.adtype = adt.actype " & ControlChars.CrLf _
                    & " order by days  asc, cleardate asc, txdate asc"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)
            End If


            ADVSchdGrid.DataRows.Clear()
            FillDataGrid(ADVSchdGrid, v_strObjMsg, "")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_ws = Nothing
        End Try
    End Sub
#End Region

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        Dim v_strTxMsg As String, v_xmlDocument As New Xml.XmlDocument, v_attrColl As Xml.XmlAttributeCollection
        Dim v_intNOSUBMIT As Integer, v_strNEXTTX As String = String.Empty
        Dim v_strErrorSource, v_strErrorMessage, v_strTXDESC As String, v_lngError As Long
        Dim v_ws As New BDSDeliveryManagement
        Dim v_strLate As String
        Dim v_blnSuccess As Boolean = False
        Try
            If Me.txtCUSTODYCD.Text.Trim = String.Empty OrElse ADVSchdGrid.DataRows.Count = 0 Then
                Exit Sub
            End If
            'Me.cboADTYPE.Focus()
            allocAdvSchd()

            If Me.txtCUSTODYCD.Enabled = True Then
                EnableResource(Me, False)
                btnPRINT.Visible = False
            Else

                If Not ControlValidation() Then
                    Exit Sub
                End If
                For k As Integer = 0 To ADVSchdGrid.DataRows.Count - 1
                    If Not (ADVSchdGrid.DataRows(k).Cells("ADVAMT").Value <= 0 Or ADVSchdGrid.DataRows(k).Cells("FEEAMT").Value < 0) Then

                        'Verify và tạo điện giao dịch
                        If Not VerifyRules(v_strTxMsg, k) Then
                            Exit Sub
                        Else
                            v_lngError = v_ws.Message(v_strTxMsg)
                            If v_lngError <> ERR_SYSTEM_OK Then
                                'Thông báo lỗi
                                GetErrorFromMessage(v_strTxMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                                Cursor.Current = Cursors.Default
                                If v_lngError <> ERR_SA_CHECKER1_OVR And v_lngError <> ERR_SA_CHECKER2_OVR Then
                                    MessageBox.Show(v_strErrorMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Exit Sub
                                End If
                            Else

                                '27-Dec-2012, TheNN them de show thong tin warning
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
                                'Ket thuc: 27-Dec-2012, TheNN them de show thong tin warning

                                v_xmlDocument.LoadXml(v_strTxMsg)
                                If v_xmlDocument.SelectSingleNode("TransactMessage").Attributes(gc_AtributeNOSUBMIT).InnerText = "2" AndAlso _
                                        v_xmlDocument.SelectSingleNode("TransactMessage").Attributes(gc_AtributePRETRAN).InnerText = "Y" Then
                                    v_lngError = v_ws.Message(v_strTxMsg)
                                    If v_lngError <> ERR_SYSTEM_OK Then
                                        'Thông báo lỗi
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
                                        ADVSchdGrid.DataRows(k).Cells("TXNUM").Value = v_xmlDocument.SelectSingleNode("TransactMessage").Attributes("TXNUM").InnerText
                                        MsgBox(ADVSchdGrid.DataRows(k).Cells("TXDESC").Value & ". " & mv_ResourceManager.GetString("TransactionSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                                    End If
                                Else
                                    v_blnSuccess = True
                                    MessageData = v_xmlDocument.InnerXml
                                    ADVSchdGrid.DataRows(k).Cells("TXNUM").Value = v_xmlDocument.SelectSingleNode("TransactMessage").Attributes("TXNUM").InnerText
                                    MsgBox(ADVSchdGrid.DataRows(k).Cells("TXDESC").Value & ". " & mv_ResourceManager.GetString("TransactionSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                                End If
                            End If
                        End If

                    End If
                Next
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

    Private Sub btnAdjust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdjust.Click
        Try
            EnableResource(Me, True)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub frmManualAdvance_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Me.CUSTODYCD Is Nothing Then
                Me.txtCUSTODYCD.Text = gc_COMPANY_CODE
                Me.txtCUSTODYCD.SelectionStart = Me.txtCUSTODYCD.Text.Trim.Length
                Me.txtCUSTODYCD.Focus()
            Else
                Me.txtCUSTODYCD.Text = Me.CUSTODYCD
                Me.txtCUSTODYCD.Enabled = False
                getAccountInfo()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtCUSTODYCD_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCUSTODYCD.KeyUp
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

    Private Sub txtCUSTODYCD_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCUSTODYCD.Validating
        getAccountInfo()
        'Me.txtCUSTODYCD.Text = Me.txtCUSTODYCD.Text.ToUpper
        'Dim v_strObjMsg As String
        'Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        'Try
        '    Dim v_nodeList As Xml.XmlNodeList
        '    Dim v_strFULLNAME, v_strADDRESS, v_strIDDATE, v_strIDPLACE, _
        '        v_strIDCODE, v_strSQLString As String
        '    Dim v_lngCount As Long
        '    'Cache thong tin ve cac tieu khoan giao dich cua khach hang
        '    v_strSQLString = "select cf.fullname, cf.address, cf.idcode, to_char(cf.iddate, 'DD/MM/RRRR') iddate, cf.idplace " & ControlChars.CrLf _
        '                & " from cfmast cf " & ControlChars.CrLf _
        '                & " where cf.custodycd = '" & Me.txtCUSTODYCD.Text.ToUpper & "' "

        '    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString)
        '    v_ws.Message(v_strObjMsg)

        '    mv_xmlCUSTOMER = New XmlDocumentEx
        '    mv_xmlCUSTOMER.LoadXml(v_strObjMsg)
        '    If Not mv_xmlCUSTOMER Is Nothing Then
        '        v_nodeList = mv_xmlCUSTOMER.SelectNodes("/ObjectMessage/ObjData")
        '        v_lngCount = v_nodeList.Count
        '        If v_lngCount = 0 Then
        '            Me.txtFULLNAME.Text = String.Empty
        '            Me.txtADDRESS.Text = String.Empty
        '            Me.txtIDCODE.Text = String.Empty
        '            Me.txtIDDATE.Text = String.Empty
        '            Me.txtIDPLACE.Text = String.Empty

        '            MessageBox.Show(mv_ResourceManager.GetString("INVALIDCUSTODYCD"), Me.Text, MessageBoxButtons.OK)
        '            Exit Sub
        '        End If
        '        For i As Integer = 0 To v_lngCount - 1
        '            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
        '                With v_nodeList.Item(i).ChildNodes(j)
        '                    If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "FULLNAME" Then
        '                        v_strFULLNAME = .InnerText.ToString
        '                    ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "ADDRESS" Then
        '                        v_strADDRESS = .InnerText.ToString
        '                    ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "IDCODE" Then
        '                        v_strIDCODE = .InnerText.ToString
        '                    ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "IDDATE" Then
        '                        v_strIDDATE = .InnerText.ToString
        '                    ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "IDPLACE" Then
        '                        v_strIDPLACE = .InnerText.ToString
        '                    End If
        '                End With
        '            Next
        '            Me.txtFULLNAME.Text = v_strFULLNAME
        '            Me.txtADDRESS.Text = v_strADDRESS
        '            Me.txtIDCODE.Text = v_strIDCODE
        '            Me.txtIDDATE.Text = v_strIDDATE
        '            Me.txtIDPLACE.Text = v_strIDPLACE
        '            Exit For
        '        Next

        '        'Lay Thong tin AFACCTNO cho combobox.
        '        Dim v_strCmdSQL As String = "SELECT FILTERCD, VALUE, VALUECD, DISPLAY, EN_DISPLAY, DESCRIPTION FROM VW_CUSTODYCD_SUBACCOUNT WHERE FILTERCD='" & Me.txtCUSTODYCD.Text.ToUpper & "' AND VALUE LIKE '%" & Me.AFACCTNO & "%'"
        '        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        '        v_ws.Message(v_strObjMsg)
        '        FillComboEx(v_strObjMsg, cboAFACCTNO, "", Me.UserLanguage)
        '        If Me.cboAFACCTNO.Items.Count > 0 Then
        '            Me.cboAFACCTNO.SelectedIndex = 0
        '        End If
        '    Else
        '        MessageBox.Show(mv_ResourceManager.GetString("INVALIDCUSTODYCD"), Me.Text, MessageBoxButtons.OK)
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'Finally
        '    v_ws = Nothing
        'End Try
    End Sub

    Private Sub cboAFACCTNO_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAFACCTNO.TextChanged
        
    End Sub

    Private Sub cboAFACCTNO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboAFACCTNO.Validating
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
                    Me.ADVSchdGrid.DataRows.Clear()
                    Me.txtACTYPE.Text = String.Empty
                    Me.txtCOREBANK.Text = "0"
                    Me.txtBANKACCT.Text = String.Empty
                    Me.txtBANKCODE.Text = String.Empty
                    Me.txtAVLADVAMT.Text = "0"
                    Me.txtRCVADVAMT.Text = "0"
                    Me.txtBALDEFOVD.Text = "0"
                    Exit Sub
                End If
                For i As Integer = 0 To v_lngCount - 1
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "ACTYPE" Then
                                v_strACTYPE = .InnerText.ToString
                            End If
                            If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "COREBANK" Then
                                v_strCOREBANK = .InnerText.ToString
                            End If
                            If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "BANKACCT" Then
                                v_strBANKACCT = .InnerText.ToString
                            End If
                            If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "BANKCODE" Then
                                v_strBANKCODE = .InnerText.ToString
                            End If
                            If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "MAXAVLAMT" Then
                                v_strMAXAVLAMT = .InnerText.ToString
                            End If
                            If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "AVLADVANCE" Then
                                v_strAVLADVANCE = .InnerText.ToString
                                mv_dblAVLADVANCE = CDbl(.InnerText.ToString)
                            End If
                            If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "DEALPAIDAMT" Then
                                mv_dblDEALPAIDAMT = CDbl(.InnerText.ToString)
                            End If
                            If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "BALDEFOVD" Then
                                v_dblBALDEFOVD = CDbl(.InnerText.ToString)
                            End If

                        End With
                    Next
                    Me.txtACTYPE.Text = v_strACTYPE
                    Me.txtCOREBANK.Text = v_strCOREBANK
                    Me.txtBANKACCT.Text = v_strBANKACCT
                    Me.txtBANKCODE.Text = v_strBANKCODE
                    Me.txtAVLADVAMT.Text = Format(CDbl(v_strMAXAVLAMT), "#,##0")
                    Me.txtRCVADVAMT.Text = Format(CDbl(v_strAVLADVANCE), "#,##0")
                    Me.txtBALDEFOVD.Text = Format(CDbl(v_dblBALDEFOVD), "#,##0")

                    Exit For
                Next

                'Lay Thong tin AFACCTNO cho combobox.
                '02/06/2017 DieuNDA Chinh sua CR Thang 05/2017: Chi load moi loai hinh AD cua tieu khoan k load all
                'Dim v_strCmdSQL As String = "SELECT DISTINCT FILTERCD, VALUE, VALUECD, DISPLAY, EN_DISPLAY, DESCRIPTION, ODRPRIO FROM VW_AF_ADTYPE_INFO WHERE FILTERCD = '" & Me.txtACTYPE.Text & "'  ORDER BY ODRPRIO"
                Dim v_strCmdSQL As String = "SELECT DISTINCT FILTERCD, VALUE, VALUECD, DISPLAY, EN_DISPLAY, DESCRIPTION, ODRPRIO FROM VW_AF_ADTYPE_INFO WHERE FILTERCD = '" & Me.txtACTYPE.Text & "' AND ODRPRIO = '1' ORDER BY ODRPRIO"
                'End 02/06/2017 DieuNDA Chinh sua CR Thang 05/2017
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)
                FillComboEx(v_strObjMsg, cboADTYPE, "", Me.UserLanguage)
                If Me.cboADTYPE.Items.Count > 0 Then
                    Me.cboADTYPE.SelectedIndex = 0
                End If
                'v_strCmdSQL = "select 'X' X,ISVSD, txdate MATCHDATE, cleardate DUEDATE, days,  " & ControlChars.CrLf _
                '        & " GREATEST(maxavlamt - round(case when to_date(sys.varvalue,'DD/MM/RRRR') = txdate AND ISVSD='N'  " & ControlChars.CrLf _
                '        & " then fn_getdealgrppaid(adv.ACCTNO) / (1-adt.ADVRATE/100/360*days) else 0 end,0),0) AVLADVAMT,  " & ControlChars.CrLf _
                '        & " 0 RCVADVAMT, 0 ADVAMT, 0 FEEAMT, 0 BNKFEEAMT, 0 VATAMT, 'Ung truoc tien lenh ban ngay:' || txdate TXDESC, '' TXNUM   " & ControlChars.CrLf _
                '        & " from vw_advanceschedule adv, SYSVAR SYS, aftype aft, adtype adt  " & ControlChars.CrLf _
                '        & " where acctno = '" & cboAFACCTNO.SelectedValue & "' and sys.varname = 'CURRDATE' and sys.grname = 'SYSTEM'  " & ControlChars.CrLf _
                '        & " and adv.actype = aft.actype and aft.adtype = adt.actype  and adv.ISVSD='N'" & ControlChars.CrLf
                '        & " order by days "

                'v_strCmdSQL = "select 'X' X,ISVSD, txdate MATCHDATE, cleardate DUEDATE, days,  " & ControlChars.CrLf _
                '        & " GREATEST(maxavlamt - round(case when to_date(sys.varvalue,'DD/MM/RRRR') = txdate AND ISVSD='N'  " & ControlChars.CrLf _
                '        & " then fn_getdealgrppaid(adv.ACCTNO) * (1+adt.ADVRATE/100/360*days) else 0 end,0),0) AVLADVAMT,  " & ControlChars.CrLf _
                '        & " 0 RCVADVAMT, 0 ADVAMT, 0 FEEAMT, 0 BNKFEEAMT, 0 VATAMT, 'Ứng trước tiền lệnh bán ngày: ' || to_char(txdate,'DD/MM/RRRR') TXDESC, '' TXNUM, adt.FEEONDAY   " & ControlChars.CrLf _
                '        & " from vw_advanceschedule adv, SYSVAR SYS, aftype aft, adtype adt  " & ControlChars.CrLf _
                '        & " where acctno = '" & cboAFACCTNO.SelectedValue & "' and sys.varname = 'CURRDATE' and sys.grname = 'SYSTEM'  " & ControlChars.CrLf _
                '        & " and adv.actype = aft.actype and aft.adtype = adt.actype " & ControlChars.CrLf _
                '        & " order by days asc, adv.cleardate asc "
                'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                'v_ws.Message(v_strObjMsg)

                'ADVSchdGrid.DataRows.Clear()
                'FillDataGrid(ADVSchdGrid, v_strObjMsg, "")

                LoadADVSchdGrid()

                ''reload 
                loadADTYPE()
            Else
                MessageBox.Show(mv_ResourceManager.GetString("INVALIDCUSTODYCD"), Me.Text, MessageBoxButtons.OK)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_ws = Nothing
        End Try
    End Sub

    Private Sub cboADTYPE_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboADTYPE.TextChanged
        LoadADVSchdGrid()
        loadADTYPE()
    End Sub

    Private Sub cboADTYPE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboADTYPE.Validating
        
    End Sub
    Private Sub getAccountInfo()
        Me.txtCUSTODYCD.Text = Me.txtCUSTODYCD.Text.ToUpper
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strFULLNAME, v_strADDRESS, v_strIDDATE, v_strIDPLACE, _
                v_strIDCODE, v_strSQLString As String
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
                    Me.txtFULLNAME.Text = String.Empty
                    Me.txtADDRESS.Text = String.Empty
                    Me.txtIDCODE.Text = String.Empty
                    Me.txtIDDATE.Text = String.Empty
                    Me.txtIDPLACE.Text = String.Empty

                    MessageBox.Show(mv_ResourceManager.GetString("INVALIDCUSTODYCD"), Me.Text, MessageBoxButtons.OK)
                    Exit Sub
                End If
                For i As Integer = 0 To v_lngCount - 1
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "FULLNAME" Then
                                v_strFULLNAME = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "ADDRESS" Then
                                v_strADDRESS = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "IDCODE" Then
                                v_strIDCODE = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "IDDATE" Then
                                v_strIDDATE = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "IDPLACE" Then
                                v_strIDPLACE = .InnerText.ToString
                            End If
                        End With
                    Next
                    Me.txtFULLNAME.Text = v_strFULLNAME
                    Me.txtADDRESS.Text = v_strADDRESS
                    Me.txtIDCODE.Text = v_strIDCODE
                    Me.txtIDDATE.Text = v_strIDDATE
                    Me.txtIDPLACE.Text = v_strIDPLACE
                    Exit For
                Next

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
    Private Sub loadADTYPE()
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strVATRATE, v_strAINTRATE, v_strAMINBAL, v_strAFEEBANK, v_strAMINFEEBANK, v_strAMINFEE, v_strAMAXFEE, _
                v_strIDCODE, v_strSQLString, v_strFEEONDAY As String
            Dim v_strPromAFACCTNO, v_strPromOPERANDAPPLY, v_strClause As String
            Dim v_strPROMFEERATE, v_strPROMMINAMT, v_strPROMMAXAMT, v_strREMAINADV_SYS, v_strREMAINADV As String
            Dim v_lngCount As Long
            'Cache thong tin ve cac tieu khoan giao dich cua kh ach hang
            'v_strSQLString = "SELECT DISTINCT VATRATE,AINTRATE,AMINBAL,AFEEBANK,AMINFEEBANK,AMINFEE,AMAXFEE, " _
            '                 & "AFACCTNO, OPERANDAPPLY, PROMFEERATE, PROMMINAMT,  PROMMAXAMT " _
            '                 & "FROM VW_AF_ADTYPE_INFO " _
            '                 & "WHERE '" & Me.cboAFACCTNO.SelectedValue & "' LIKE (CASE WHEN AFACCTNO='ALL' THEN '%' ELSE AFACCTNO END) " _
            '                 & "AND FLDKEY = '" & Me.txtACTYPE.Text.ToUpper & Me.cboADTYPE.SelectedValue & "'"

            'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString)
            'v_ws.Message(v_strObjMsg)

            v_strSQLString = "SP_BD_GETAF_ADTYPE_INFO"
            v_strClause = "pv_FLDKEY!" & Me.txtACTYPE.Text.ToUpper & Me.cboADTYPE.SelectedValue & "!varchar2!20" & _
                          "^pv_AFACCTNO!" & Me.cboAFACCTNO.SelectedValue & "!varchar2!20"

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString, v_strClause, , , , , , , gc_CommandProcedure)
            v_ws.Message(v_strObjMsg)

            mv_xmlCUSTOMER = New XmlDocumentEx
            mv_xmlCUSTOMER.LoadXml(v_strObjMsg)
            If Not mv_xmlCUSTOMER Is Nothing Then
                v_nodeList = mv_xmlCUSTOMER.SelectNodes("/ObjectMessage/ObjData")
                v_lngCount = v_nodeList.Count
                If v_lngCount = 0 Then
                    Me.ADVSchdGrid.DataRows.Clear()

                    Me.txtFULLNAME.Text = String.Empty
                    Me.txtADDRESS.Text = String.Empty
                    Me.txtIDCODE.Text = String.Empty
                    Me.txtIDDATE.Text = String.Empty
                    Me.txtIDPLACE.Text = String.Empty

                    MessageBox.Show(mv_ResourceManager.GetString("INVALIDCUSTODYCD"), Me.Text, MessageBoxButtons.OK)
                    Exit Sub
                End If
                'VATRATE,AINTRATE,AMINBAL,AFEEBANK,AMINFEEBANK,AMINFEE,AMAXFEE
                For i As Integer = 0 To v_lngCount - 1
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "VATRATE" Then
                                v_strVATRATE = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "AINTRATE" Then
                                v_strAINTRATE = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "AMINBAL" Then
                                v_strAMINBAL = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "AFEEBANK" Then
                                v_strAFEEBANK = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "AMINFEEBANK" Then
                                v_strAMINFEEBANK = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "AMINFEE" Then
                                v_strAMINFEE = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "AMAXFEE" Then
                                v_strAMAXFEE = .InnerText.ToString
                                '</TruongLD Add 30/10/2014
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "AFACCTNO" Then
                                v_strPromAFACCTNO = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "OPERANDAPPLY" Then
                                v_strPromOPERANDAPPLY = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "PROMFEERATE" Then
                                v_strPROMFEERATE = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "PROMMINAMT" Then
                                v_strPROMMINAMT = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "PROMMAXAMT" Then
                                v_strPROMMAXAMT = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "FEEONDAY" Then
                                v_strFEEONDAY = .InnerText.ToString
                                mv_strFEEONDAY = v_strFEEONDAY
                                '24/07/2018 DieuNDA: The, 2 HM UTTB da su dung trong ngay
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "REMAINADV_SYS" Then
                                v_strREMAINADV_SYS = .InnerText.ToString
                            ElseIf CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "REMAINADV" Then
                                v_strREMAINADV = .InnerText.ToString
                                'End 24/07/2018 DieuNDA: The, 2 HM UTTB da su dung trong ngay
                            End If
                            'End TruongLD/>
                        End With
                    Next
                    '</TruongLD Add 30/10/2014
                    'Xy ly doi voi nhung TK co thiet lap, khuyen mai 
                    'Neu tieu khoan co khai bao chinh sach uu dai lai suat --> 
                    '-- F: Lay theo lai uu dai
                    '-- I: Lay min giua uu dai va loai hinh
                    '-- A: Lay max giua uu dai va loai hinh
                    If v_strPromAFACCTNO = cboAFACCTNO.SelectedValue Then
                        If v_strPromOPERANDAPPLY = "F" Then
                            v_strAINTRATE = v_strPROMFEERATE
                            v_strAMINFEE = v_strPROMMINAMT
                            v_strAMAXFEE = v_strPROMMAXAMT
                        ElseIf v_strPromOPERANDAPPLY = "I" Then
                            v_strAINTRATE = Math.Min(CDbl(v_strPROMFEERATE), CDbl(v_strAINTRATE))
                            v_strAMINFEE = Math.Min(CDbl(v_strPROMMINAMT), CDbl(v_strAMINFEE))
                            v_strAMAXFEE = Math.Min(CDbl(v_strPROMMAXAMT), CDbl(v_strAMAXFEE))
                        ElseIf v_strPromOPERANDAPPLY = "A" Then
                            v_strAINTRATE = Math.Max(CDbl(v_strPROMFEERATE), CDbl(v_strAINTRATE))
                            v_strAMINFEE = Math.Max(CDbl(v_strPROMMINAMT), CDbl(v_strAMINFEE))
                            v_strAMAXFEE = Math.Max(CDbl(v_strPROMMAXAMT), CDbl(v_strAMAXFEE))
                        End If
                    End If
                    'End TruongLD/>

                    Me.txtVAT.Text = Format(CDbl(v_strVATRATE), "#,##0.####")
                    Me.txtINTRATE.Text = Format(CDbl(v_strAINTRATE), "#,##0.####")
                    Me.txtMINADVAMT.Text = Format(CDbl(v_strAMINBAL), "#,##0")
                    Me.txtBNKRATE.Text = Format(CDbl(v_strAFEEBANK), "#,##0.####")
                    Me.txtBNKMINBAL.Text = Format(CDbl(v_strAMINFEEBANK), "#,##0")
                    Me.txtCMPMINBAL.Text = Format(CDbl(v_strAMINFEE), "#,##0")
                    Me.txtCMPMAXBAL.Text = Format(CDbl(v_strAMAXFEE), "#,##0")
                    '24/07/2018 DieuNDA: The, 2 HM UTTB da su dung trong ngay
                    Me.txtREMAINADV_SYS.Text = Format(CDbl(v_strREMAINADV_SYS), "#,##0")
                    Me.txtREMAINADV.Text = Format(CDbl(v_strREMAINADV), "#,##0")
                    'End 24/07/2018 DieuNDA: The, 2 HM UTTB da su dung trong ngay
                    Exit For
                Next

                ''reload
                allocAdvSchd()
            Else
                MessageBox.Show(mv_ResourceManager.GetString("INVALIDAFTYPEADTYPE"), Me.Text, MessageBoxButtons.OK)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_ws = Nothing
        End Try
    End Sub

    Private Sub txtADVAMT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtADVAMT.Validating
        Try

            If Me.txtADVAMT.Text.Trim.Length > 0 Then
                If (Char.IsLetter(Me.txtADVAMT.Text) Or CheckSpecial(Me.txtADVAMT.Text) = 1) Then
                    MessageBox.Show(ResourceManager.GetString("msgtxtADVAMTERROR"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtADVAMT.Focus()
                ElseIf (CDbl(Me.txtADVAMT.Text) < (CDbl(Me.txtMINADVAMT.Text))) Then
                    MessageBox.Show(ResourceManager.GetString("msgtxtADVAMTNOTVALID"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtADVAMT.Focus()
                Else

                    If (CDbl(Me.txtADVAMT.Text) < 0) Then
                        MessageBox.Show(ResourceManager.GetString("msgtxtADVAMTERROR"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txtADVAMT.Focus()
                    Else
                        If CDbl(Me.txtADVAMT.Text) > CDbl(Me.txtRCVADVAMT.Text) And Char.IsDigit(Me.txtADVAMT.Text) Then
                            Me.txtADVAMT.Text = Format(Math.Max(CDbl(Me.txtRCVADVAMT.Text), 0), "#,##0")
                        End If
                        Me.txtADVAMT.Text = Format(CDbl(Me.txtADVAMT.Text), "#,##0")
                    End If

                End If
            Else
                Me.txtADVAMT.Text = 0
            End If


            ''reload
            If (Char.IsDigit(Me.txtADVAMT.Text)) Then
                allocAdvSchd()
            Else
                Me.txtADVAMT.Text = 0
                For i As Integer = ADVSchdGrid.DataRows.Count - 1 To 0 Step -1
                    ADVSchdGrid.DataRows(i).Cells("RCVADVAMT").Value = CDbl("0")
                    ADVSchdGrid.DataRows(i).Cells("FEEAMT").Value = CDbl("0")
                    ADVSchdGrid.DataRows(i).Cells("BNKFEEAMT").Value = CDbl("0")
                    ADVSchdGrid.DataRows(i).Cells("VATAMT").Value = CDbl("0")
                    ADVSchdGrid.DataRows(i).Cells("ADVAMT").Value = CDbl("0")
                Next
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function CheckSpecial(ByVal des As String)
        Dim illegalChars As Char() = "~!@#$%^&*(){}[]""_+<>?/".ToCharArray()
        Dim str As String = des

        For Each ch As Char In str
            If Not Array.IndexOf(illegalChars, ch) = -1 Then
                Return 1
            End If
        Next
        Return 0

    End Function
    Protected Overridable Sub Grid_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not ADVSchdGrid.CurrentColumn Is Nothing Then
            If ADVSchdGrid.CurrentColumn.FieldName = "X" Then
                If ADVSchdGrid.CurrentCell.Value = "X" Then
                    ADVSchdGrid.CurrentCell.Value = String.Empty
                Else
                    ADVSchdGrid.CurrentCell.Value = "X"
                End If
            End If
        End If
        allocAdvSchd()
    End Sub

    Private Sub Grid_DblClick(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not ADVSchdGrid.CurrentColumn Is Nothing Then
            Dim frm As New frmODDetail(Me.UserLanguage)
            frm.TellerName = Me.TellerName
            frm.LocalObject = gc_IsNotLocalMsg
            frm.BranchId = Me.BranchId
            frm.TellerId = Me.TellerId
            frm.TellerName = Me.TellerName
            frm.IpAddress = Me.IpAddress
            frm.WsName = Me.WsName
            frm.BusDate = Me.BusDate
            frm.AccountInquiry = Me.cboAFACCTNO.SelectedValue
            frm.OrderDate = CType(ADVSchdGrid.CurrentRow, Xceed.Grid.DataRow).Cells("MATCHDATE").Value
            frm.SettlementDate = CType(ADVSchdGrid.CurrentRow, Xceed.Grid.DataRow).Cells("DUEDATE").Value
            frm.VSD = CType(ADVSchdGrid.CurrentRow, Xceed.Grid.DataRow).Cells("ISVSD").Value
            frm.ShowDialog()
            frm.Dispose()
        End If
        'Show thong tin chi tiet tung ngay khop lenh

    End Sub

    Private Sub btnPRINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPRINT.Click
        GenAFReport()
    End Sub

    Private Sub GenAFReport()
        Dim v_frm As New frmProcessing
        Dim v_ws As New BDSRptDeliveryManagement
        Dim v_xmlDocumentMessage As New Xml.XmlDocument

        Dim v_wsObj As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Dim v_xmlDocument As New XmlDocumentEx
        Dim v_nodeList As Xml.XmlNodeList
        Dim intReturnExecuted As Integer = 0
        Dim v_strSQL, v_strFLDNAME, v_strVALUE, v_strRPTNAME As String
        Try
            ReportDirectory = GetDirectoryName(ExecutablePath) & "\REPORTS\"
            ReportTempDirectory = ReportDirectory & "TEMP\"

            'Change mouse's pointer

            Cursor.Current = Cursors.WaitCursor
            Dim v_strObjMsg As String = String.Empty
            Dim v_ds As DataSet
            Dim k As Integer
            Dim dataElement As Xml.XmlElement, v_attrReport As Xml.XmlAttribute
            'Prepare parameters to create the report

            'Show processing message
            v_frm.UserLanguage = UserLanguage
            v_frm.ProcessType = ProcessType.ReportProcess
            v_frm.InitDialog()
            v_frm.Show()
            'End of show processing message

            'Get Report file name from server.
            v_strSQL = "select fn_get1153rptname('" & Me.cboAFACCTNO.SelectedValue & "') RPTNAME from dual"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strSQL)
            v_wsObj.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(j).ChildNodes.Count - 1
                    With v_nodeList.Item(j).ChildNodes(i)
                        v_strFLDNAME = v_nodeList.Item(j).ChildNodes(i).Attributes.GetNamedItem("fldname").Value.Trim()
                        v_strVALUE = v_nodeList.Item(j).ChildNodes(i).Attributes.GetNamedItem("oldval").Value.Trim()
                        Select Case v_strFLDNAME
                            Case "RPTNAME"
                                v_strRPTNAME = Trim(v_strVALUE)
                        End Select
                    End With
                Next
            Next


            'PrepareReportParams(Me.cboAFACCTNO.SelectedValue)
            'Xu ly cho Sub Report


            Dim v_obj As ReportParameters ', v_intParams As Integer, v_ctrl As Control
            'Dim v_strLookupData, v_strFLDNAME, v_strVALUE, v_strParamValue, v_strParamDesc As String

            ReDim mv_arrRptParam(5)    'Mac dinh la bao gom tat ca gia tri trong errObjFields la tham so



            For k = ADVSchdGrid.DataRows.Count - 1 To 0 Step -1
                If ADVSchdGrid.DataRows(k).Cells("X").Value = "X" Then
                    ' v_dblCMPFEE = v_dblCMPFEE + Math.Ceiling(CDbl(ADVSchdGrid.DataRows(k).Cells("AVLADVAMT").Value) * CDbl(ADVSchdGrid.DataRows(k).Cells("DAYS").Value) * CDbl(Me.txtINTRATE.Text) / 360 / 100)

                    v_obj = New ReportParameters
                    v_obj.ParamName = "p_afacctno"
                    v_obj.ParamCaption = "afacctno"
                    v_obj.ParamValue = String.Empty
                    v_obj.ParamValue = Me.cboAFACCTNO.SelectedValue
                    v_obj.ParamDescription = Me.cboAFACCTNO.SelectedValue
                    v_obj.ParamType = GetType(System.String).Name
                    v_obj.ParamSize = 10

                    mv_arrRptParam(0) = v_obj


                    v_obj = New ReportParameters
                    v_obj.ParamName = "p_MATCHDATE"
                    v_obj.ParamCaption = "MATCHDATE"
                    v_obj.ParamValue = String.Empty
                    v_obj.ParamValue = ADVSchdGrid.DataRows(k).Cells("MATCHDATE").Value
                    v_obj.ParamDescription = ADVSchdGrid.DataRows(k).Cells("MATCHDATE").Value
                    v_obj.ParamType = GetType(System.String).Name
                    v_obj.ParamSize = 10

                    mv_arrRptParam(1) = v_obj


                    v_obj = New ReportParameters
                    v_obj.ParamName = "p_DUEDATE"
                    v_obj.ParamCaption = "DUEDATE"
                    v_obj.ParamValue = String.Empty
                    v_obj.ParamValue = ADVSchdGrid.DataRows(k).Cells("DUEDATE").Value
                    v_obj.ParamDescription = ADVSchdGrid.DataRows(k).Cells("DUEDATE").Value
                    v_obj.ParamType = GetType(System.String).Name
                    v_obj.ParamSize = 10

                    mv_arrRptParam(2) = v_obj

                    v_obj = New ReportParameters
                    v_obj.ParamName = "p_ADVAMT"
                    v_obj.ParamCaption = "ADVAMT"
                    v_obj.ParamValue = String.Empty
                    v_obj.ParamValue = CDbl(ADVSchdGrid.DataRows(k).Cells("ADVAMT").Value)
                    v_obj.ParamDescription = CDbl(ADVSchdGrid.DataRows(k).Cells("ADVAMT").Value)
                    v_obj.ParamType = "Double"
                    v_obj.ParamSize = 100

                    mv_arrRptParam(3) = v_obj


                    v_obj = New ReportParameters
                    v_obj.ParamName = "p_BUSDATE"
                    v_obj.ParamCaption = "BUSDATE"
                    v_obj.ParamValue = String.Empty
                    v_obj.ParamValue = Me.BusDate
                    v_obj.ParamDescription = Me.BusDate
                    v_obj.ParamType = GetType(System.String).Name
                    v_obj.ParamSize = 10

                    mv_arrRptParam(4) = v_obj


                    v_obj = New ReportParameters
                    v_obj.ParamName = "p_FEEAMT"
                    v_obj.ParamCaption = "FEEAMT"
                    v_obj.ParamValue = String.Empty
                    v_obj.ParamValue = CDbl(ADVSchdGrid.DataRows(k).Cells("FEEAMT").Value)
                    v_obj.ParamDescription = CDbl(ADVSchdGrid.DataRows(k).Cells("FEEAMT").Value)
                    v_obj.ParamType = "Double"
                    v_obj.ParamSize = 100
                    mv_arrRptParam(5) = v_obj


                    mv_intNumOfParam = 6

                    'Create message and send to web service to get data for the report
                    mv_strStoreName = "CI1153MANUAL" ' hardcode
                    v_strObjMsg = BuildXMLRptMsg(LocalObject, mv_strStoreName, gc_MsgTypeProc, mv_arrRptParam, mv_intNumOfParam)

                    'Setup attributes
                    v_xmlDocumentMessage.LoadXml(v_strObjMsg)
                    v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeBRID).Value = Me.BranchId
                    v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeTLID).Value = Me.TellerId
                    v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeCMDID).Value = mv_strStoreName
                    v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeREFERENCE).Value = mv_strStoreName
                    v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeACTFLAG).Value = "M"
                    v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeFUNCNAME).Value = "N"
                    v_strObjMsg = v_xmlDocumentMessage.InnerXml

                    v_ws.Message(v_strObjMsg)

                    'Create report
                    v_xmlDocumentMessage.LoadXml(v_strObjMsg)
                    v_ds = ConvertXmlDocToDataSet(v_xmlDocumentMessage)
                    v_ds.WriteXml(ReportTempDirectory & mv_strStoreName & TellerId & ".xml")


                    'Close processing message window
                    v_frm.Close()
                    ' Change cursor pointer
                    Cursor.Current = Cursors.Default

                    If v_ds Is Nothing Then
                        For i As Integer = 0 To v_strRPTNAME.Split("|").Length - 1
                            CreateReport(v_ds, v_strRPTNAME.Split("|")(i))
                        Next
                        intReturnExecuted = 2  'Pending
                        'Me.Close()
                    Else
                        For i As Integer = 0 To v_strRPTNAME.Split("|").Length - 1
                            If CreateReport(v_ds, v_strRPTNAME.Split("|")(i)) Then
                                'Show sucessful message
                                'MessageBox.Show(ResourceManager.GetString("frmAFMAST.ReportCreateSucessfully"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                intReturnExecuted = 1 'Ok
                                'Me.Close()
                            End If
                        Next
                    End If

                    If intReturnExecuted = 1 Then
                        For i As Integer = 0 To v_strRPTNAME.Split("|").Length - 1
                            OnViewRpt(v_strRPTNAME.Split("|")(i))
                        Next
                        'MessageBox.Show(ResourceManager.GetString("ReportCreateSucessfully"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            Next

            If intReturnExecuted = 1 Then
                MessageBox.Show(ResourceManager.GetString("ReportCreateSucessfully"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            v_frm.Close()
            ' Change cursor pointer
            Cursor.Current = Cursors.Default
        Finally
            v_wsObj = Nothing
            v_xmlDocument = Nothing
            v_frm = Nothing
            v_ws = Nothing
            v_xmlDocumentMessage = Nothing
        End Try
    End Sub

    Private Sub GetReportFormularValue()
        Try
            'Get common values from SYSVAR table
            Dim v_strSQL As String = "SELECT VARNAME, VARVALUE FROM SYSVAR WHERE GRNAME = 'SYSTEM'"
            Dim v_strObjMsg As String = String.Empty
            'TruongLD Comment when convert
            'Dim v_ws As New BDSRptDelivery.BDSRptDelivery
            'TruongLD Add when convert
            Dim v_ws As New BDSRptDeliveryManagement
            'End TruongLD
            Dim v_intRowCount As Integer
            Dim v_strVarName, v_strVarValue As String

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeRpt, , gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)

            Dim v_xmlDocument As New XmlDocumentEx
            Dim v_xmlNode As Xml.XmlNode

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_intRowCount = v_xmlDocument.FirstChild.ChildNodes.Count

            If (v_intRowCount > 0) Then
                v_xmlNode = v_xmlDocument.FirstChild

                For i As Integer = 0 To v_intRowCount - 1
                    v_strVarName = v_xmlNode.ChildNodes(i).ChildNodes(0).InnerText.Trim().ToUpper()

                    Select Case v_strVarName
                        Case "HEADOFFICE"
                            HeadOffice = v_xmlNode.ChildNodes(i).ChildNodes(1).InnerText.Trim()
                        Case "BRNAME"
                            BranchName = v_xmlNode.ChildNodes(i).ChildNodes(1).InnerText.Trim()
                        Case "BRADDRESS"
                            BranchAddress = v_xmlNode.ChildNodes(i).ChildNodes(1).InnerText.Trim()
                        Case "BRPHONEFAX"
                            BranchPhoneFax = v_xmlNode.ChildNodes(i).ChildNodes(1).InnerText.Trim()
                        Case "BUSDATE"
                            v_strVarValue = v_xmlNode.ChildNodes(i).ChildNodes(1).InnerText.Trim()
                            CreatedDate = "Ngày " & v_strVarValue.Substring(0, 2) & " tháng " & v_strVarValue.Substring(3, 2) _
                                & " năm " & v_strVarValue.Substring(6)
                            CreatedDate_En = v_strVarValue.Substring(0, 2) & " / " & v_strVarValue.Substring(3, 2) _
                                & " / " & v_strVarValue.Substring(6)
                    End Select
                Next
            Else
                BranchName = String.Empty
                BranchAddress = String.Empty
                BranchPhoneFax = String.Empty
            End If

            'Get teller fullname from TLPROFILES table
            v_strSQL = "SELECT TLFULLNAME FROM TLPROFILES WHERE TLID = '" & TellerId & "'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeRpt, , gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_intRowCount = v_xmlDocument.FirstChild.ChildNodes.Count

            If (v_intRowCount = 1) Then
                v_xmlNode = v_xmlDocument.FirstChild
                Teller = v_xmlNode.ChildNodes(0).ChildNodes(0).InnerText.Trim()
            Else
                Teller = String.Empty
            End If

            'Lấy thuộc tính cài đặt cho báo cáo
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Function GetReportDateCreated(ByVal pv_strReportFileName As String, Optional ByRef v_strAdhoc As String = "") As Date
        Try
            Dim v_dirInfo As New DirectoryInfo(ReportTempDirectory)
            Dim v_fileInfo As FileInfo
            Dim v_arrReportFiles() As FileInfo = v_dirInfo.GetFiles(pv_strReportFileName)
            For Each v_fileInfo In v_arrReportFiles
                If v_fileInfo.Name = pv_strReportFileName Then
                    'File ton tai
                    v_strAdhoc = "Y"
                    Return v_fileInfo.LastWriteTime
                End If
            Next

            'Xu ly doc file tu template
            pv_strReportFileName = pv_strReportFileName.Replace(".rpt", ".prnx")
            v_arrReportFiles = v_dirInfo.GetFiles(pv_strReportFileName)
            For Each v_fileInfo In v_arrReportFiles
                If v_fileInfo.Name = pv_strReportFileName Then
                    'File ton tai
                    v_strAdhoc = "N"
                    Return v_fileInfo.LastWriteTime
                End If
            Next

            Return Nothing
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function
    Public Sub OnViewRpt(Optional ByVal pv_strReportFileName As String = "")
        Dim v_strOldCultureName As String = String.Empty
        Try

            v_strOldCultureName = SetCultureInfo("en-US")

            'Báo cáo dưới dạng Crystal Report: Adhoc template theo mẫu
            Dim ReportTimeCreated As Date = GetReportDateCreated(GetReportFileName(pv_strReportFileName))
            If ReportTimeCreated.Year > 1 Then
                Dim v_frm As New frmReportView
                Dim v_Path As String = Environment.CurrentDirectory
                v_frm.RptFileName = ReportTempDirectory & GetReportFileName(pv_strReportFileName)
                v_frm.RptName = pv_strReportFileName
                v_frm.ShowDialog()
                Environment.CurrentDirectory = v_Path
            Else
                MessageBox.Show(ResourceManager.GetString("frmAFMAST.ReportNotCreated"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            'v_strOldCultureName = SetCultureInfo(v_strOldCultureName)

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            If Len(v_strOldCultureName) > 0 Then
                v_strOldCultureName = SetCultureInfo(v_strOldCultureName)
            End If
        End Try
    End Sub

    Private Function CreateReport(ByVal v_ds As DataSet, ByVal pv_strReportFileName As String) As Boolean
        Try
            Dim v_rptDocument As New ReportDocument
            Dim v_strRptFilePath As String = GetRptTemplateFilePath(pv_strReportFileName)
            Dim v_blnFileExists As Boolean = False

            Dim v_dirInfo As New DirectoryInfo(ReportDirectory)
            Dim v_fileInfo() As FileInfo = v_dirInfo.GetFiles("*.rpt")
            Dim v_file As FileInfo
            Dim v_ExDirectoy As String

            ' Check if report template is exists
            For Each v_file In v_fileInfo
                If v_file.Name = v_strRptFilePath Then
                    v_blnFileExists = True
                    Exit For
                End If
            Next
            If Not v_blnFileExists Then
                v_ds.WriteXml(ReportDirectory & mv_strStoreName & ".xml", XmlWriteMode.WriteSchema)
                MessageBox.Show(ResourceManager.GetString("frmAFMAST.FileNotExists"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If


            'Load the report, fill formulars and save it to disk
            v_rptDocument.Load(ReportDirectory & v_strRptFilePath, CrystalDecisions.Shared.OpenReportMethod.OpenReportByTempCopy)
            If Not v_ds Is Nothing Then
                '  Check if nodata  is exists
                If v_ds.Tables(0).Rows.Count = 0 Then
                    MessageBox.Show(ResourceManager.GetString("frmAFMAST.Nodata"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If

                'v_ExDirectoy = ExportDirectory
                v_ExDirectoy = ReportDirectory & v_strRptFilePath
                v_rptDocument.SetDataSource(v_ds)
            End If

            Dim v_crFFieldDefinitions As FormulaFieldDefinitions
            Dim v_crFFieldDefinition As FormulaFieldDefinition
            Dim v_strFormulaName, v_strFormulaValue As String
            v_crFFieldDefinitions = v_rptDocument.DataDefinition.FormulaFields()
            For i As Integer = 0 To v_crFFieldDefinitions.Count - 1
                v_crFFieldDefinition = v_crFFieldDefinitions.Item(i)
                v_strFormulaName = v_crFFieldDefinition.Name

                Select Case v_strFormulaName.ToUpper()
                    Case gc_RPT_FORMULAR_HEADOFFICE
                        v_crFFieldDefinition.Text = "'" & HeadOffice & "'"
                    Case gc_RPT_FORMULAR_COMPANY_NAME
                        v_crFFieldDefinition.Text = "'" & BranchName & "'"
                    Case gc_RPT_FORMULAR_ADDRESS
                        v_crFFieldDefinition.Text = "'" & BranchAddress & "'"
                    Case gc_RPT_FORMULAR_PHONE_FAX
                        v_crFFieldDefinition.Text = "'" & BranchPhoneFax & "'"
                    Case gc_RPT_FORMULAR_REPORT_TITLE
                        v_crFFieldDefinition.Text = "'" & ReportTitle & "'"
                    Case gc_RPT_FORMULAR_CREATED_DATE
                        v_crFFieldDefinition.Text = "'" & CreatedDate & "'"
                    Case gc_RPT_FORMULAR_CREATED_BY
                        v_crFFieldDefinition.Text = "'" & Teller & "'"
                End Select
            Next

            'The dataset is returned TRUE value when asynchronous mode
            If v_ds Is Nothing Then
                'Store v_rptDocument to the file
                'Delete old data
                Dim v_strFile As String = ReportTempDirectory & GetRptTempFilePath(pv_strReportFileName)
                File.Delete(v_strFile)

                'Ghi ra file voi trang thai PENDING
                Dim v_strXMLBuilder As New StringBuilder
                v_crFFieldDefinitions = v_rptDocument.DataDefinition.FormulaFields()
                If v_crFFieldDefinitions.Count > 0 Then
                    v_strXMLBuilder.Append("<formula ")
                    For i As Integer = 0 To v_crFFieldDefinitions.Count - 1
                        v_crFFieldDefinition = v_crFFieldDefinitions.Item(i)
                        v_strFormulaName = v_crFFieldDefinition.Name
                        v_strFormulaValue = v_crFFieldDefinition.Text
                        v_strFormulaValue = v_strFormulaValue.Replace("&", "&amp;")
                        v_strFormulaValue = v_strFormulaValue.Replace("'", "&apos;")
                        v_strFormulaValue = v_strFormulaValue.Replace("""", "&quot;")
                        v_strFormulaValue = v_strFormulaValue.Replace("<", "&lt;")
                        v_strFormulaValue = v_strFormulaValue.Replace(">", "&gt;")

                        v_strXMLBuilder.Append(" ")
                        v_strXMLBuilder.Append(v_strFormulaName)
                        v_strXMLBuilder.Append("='")
                        v_strXMLBuilder.Append(v_strFormulaValue)
                        v_strXMLBuilder.Append("'")
                    Next
                    v_strXMLBuilder.Append("></formula>")
                Else
                    v_strXMLBuilder.Append("EMPTY")
                End If

                Dim v_streamWriter As New StreamWriter(ReportTempDirectory & ReportAsychronous)
                v_streamWriter.Write(v_strXMLBuilder.ToString)
                v_streamWriter.Flush()
                v_streamWriter.Close()
            Else
                If v_rptDocument.IsLoaded Then
                    'Export to Crystal report
                    v_rptDocument.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.CrystalReport, ReportTempDirectory & GetRptTempFilePath(pv_strReportFileName))
                End If
            End If
            Return True
        Catch ex As Exception

            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            'MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Function

    Private Function GetRptTempFilePath(ByVal pv_strRptID As String) As String
        Return pv_strRptID & TellerId & ".rpt"
    End Function

    Private Function GetRptTemplateFilePath(ByVal pv_strRptID As String) As String
        Return pv_strRptID & ".rpt"
    End Function

    Private Function ConvertXmlDocToDataSet(ByVal pv_xmlDoc As Xml.XmlDocument) As DataSet
        Try
            Dim v_ds As New DataSet("Object")
            Dim v_dr As DataRow
            Dim v_dc As DataColumn
            Dim v_intCountRow, v_intCountCol As Integer
            Dim v_XmlNode As Xml.XmlNode

            Dim v_nodeXSD, v_nodeXML As Xml.XmlNode
            Dim v_strDataXSD, v_strDataXML, v_strBuilder As String
            Dim v_arrXSDByteMessage(), v_arrXMLByteMessage() As Byte
            Dim v_Encoded As Char()

            ReportAsychronous = String.Empty
            v_nodeXSD = pv_xmlDoc.SelectSingleNode("/ObjectMessage/RptDataXSD")
            v_nodeXML = pv_xmlDoc.SelectSingleNode("/ObjectMessage/RptDataXML")
            If Not (v_nodeXSD Is Nothing And v_nodeXML Is Nothing) Then
                'The return data is compressed
                v_strDataXSD = v_nodeXSD.InnerText
                v_strDataXML = v_nodeXML.InnerText
                If v_strDataXSD <> "PENDING" Then   'Synchronous report
                    'Get schema
                    Dim v_XSD As New TestBase64.Base64Decoder(v_strDataXSD)
                    v_arrXSDByteMessage = v_XSD.GetDecoded()
                    v_strDataXSD = ZetaCompressionLibrary.CompressionHelper.DecompressString(v_arrXSDByteMessage)
                    'Get data
                    Dim v_XML As New TestBase64.Base64Decoder(v_strDataXML)
                    v_arrXMLByteMessage = v_XML.GetDecoded()
                    v_strDataXML = ZetaCompressionLibrary.CompressionHelper.DecompressString(v_arrXMLByteMessage)
                    'Create dataset
                    Dim v_XMLREADER, v_XSDREADER As System.IO.StringReader
                    v_XMLREADER = New System.IO.StringReader(v_strDataXML)
                    v_XSDREADER = New System.IO.StringReader(v_strDataXSD)
                    If v_ds Is Nothing Then v_ds = New DataSet
                    v_ds.Tables.Clear()
                    v_ds.ReadXmlSchema(v_XSDREADER)
                    v_ds.ReadXml(v_XMLREADER)
                    v_ds.Tables(0).TableName = "RptData"
                    Return v_ds
                Else    'Asynchronous report

                    'Ghi nhan lai ten file dang pending cho xu ly tren host
                    ReportAsychronous = v_strDataXML
                    Return Nothing
                End If
            Else
                'Normal way: the return data is not compressed
                v_ds.Tables.Add("RptData")
                v_intCountRow = pv_xmlDoc.FirstChild.ChildNodes.Count
                If (v_intCountRow > 0) Then
                    v_intCountCol = pv_xmlDoc.FirstChild.FirstChild.ChildNodes.Count

                    For i As Integer = 0 To v_intCountCol - 1
                        v_dc = New DataColumn(pv_xmlDoc.FirstChild.FirstChild.ChildNodes(i).Attributes("fldname").InnerText)
                        v_dc.ColumnName = pv_xmlDoc.FirstChild.FirstChild.ChildNodes(i).Attributes("fldname").InnerText

                        Select Case pv_xmlDoc.FirstChild.FirstChild.ChildNodes(i).Attributes("fldtype").InnerText
                            Case "System.Decimal"
                                v_dc.DataType = GetType(System.Decimal)
                            Case "System.String"
                                v_dc.DataType = GetType(System.String)
                            Case "System.Double"
                                v_dc.DataType = GetType(System.Double)
                            Case "System.DateTime"
                                v_dc.DataType = GetType(System.DateTime)
                            Case Else
                                v_dc.DataType = GetType(System.String)
                        End Select

                        v_ds.Tables(0).Columns.Add(v_dc)
                    Next

                    v_XmlNode = pv_xmlDoc.FirstChild
                    For j As Integer = 0 To v_intCountRow - 1
                        v_dr = v_ds.Tables(0).NewRow()
                        For i As Integer = 0 To v_intCountCol - 1
                            v_dr(i) = Trim(v_XmlNode.ChildNodes(j).ChildNodes(i).InnerText)
                        Next
                        v_ds.Tables(0).Rows.Add(v_dr)
                    Next
                End If
                Return v_ds
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub PrepareReportParams(ByVal v_strAFACCTNO As String)
        'Dim v_xmlDocument As New XmlDocumentEx
        'Dim v_xmlNodeList As Xml.XmlNodeList
        Dim i As Integer
        Try
            Dim v_obj As ReportParameters ', v_intParams As Integer, v_ctrl As Control
            'Dim v_strLookupData, v_strFLDNAME, v_strVALUE, v_strParamValue, v_strParamDesc As String

            ReDim mv_arrRptParam(10)    'Mac dinh la bao gom tat ca gia tri trong errObjFields la tham so



            For i = ADVSchdGrid.DataRows.Count - 1 To 0 Step -1
                If ADVSchdGrid.DataRows(i).Cells("X").Value = "X" Then
                    ' v_dblCMPFEE = v_dblCMPFEE + Math.Ceiling(CDbl(ADVSchdGrid.DataRows(i).Cells("AVLADVAMT").Value) * CDbl(ADVSchdGrid.DataRows(i).Cells("DAYS").Value) * CDbl(Me.txtINTRATE.Text) / 360 / 100)

                    v_obj = New ReportParameters
                    v_obj.ParamName = "p_afacctno"
                    v_obj.ParamCaption = "afacctno"
                    v_obj.ParamValue = String.Empty
                    v_obj.ParamValue = v_strAFACCTNO
                    v_obj.ParamDescription = v_strAFACCTNO
                    v_obj.ParamType = GetType(System.String).Name
                    v_obj.ParamSize = 10

                    mv_arrRptParam(0) = v_obj


                    v_obj = New ReportParameters
                    v_obj.ParamName = "p_MATCHDATE"
                    v_obj.ParamCaption = "MATCHDATE"
                    v_obj.ParamValue = String.Empty
                    v_obj.ParamValue = ADVSchdGrid.DataRows(i).Cells("MATCHDATE").Value
                    v_obj.ParamDescription = ADVSchdGrid.DataRows(i).Cells("MATCHDATE").Value
                    v_obj.ParamType = GetType(System.String).Name
                    v_obj.ParamSize = 10

                    mv_arrRptParam(1) = v_obj


                    v_obj = New ReportParameters
                    v_obj.ParamName = "p_DUEDATE"
                    v_obj.ParamCaption = "DUEDATE"
                    v_obj.ParamValue = String.Empty
                    v_obj.ParamValue = ADVSchdGrid.DataRows(i).Cells("DUEDATE").Value
                    v_obj.ParamDescription = ADVSchdGrid.DataRows(i).Cells("DUEDATE").Value
                    v_obj.ParamType = GetType(System.String).Name
                    v_obj.ParamSize = 10

                    mv_arrRptParam(2) = v_obj

                    v_obj = New ReportParameters
                    v_obj.ParamName = "p_ADVAMT"
                    v_obj.ParamCaption = "ADVAMT"
                    v_obj.ParamValue = String.Empty
                    v_obj.ParamValue = CDbl(ADVSchdGrid.DataRows(i).Cells("ADVAMT").Value)
                    v_obj.ParamDescription = CDbl(ADVSchdGrid.DataRows(i).Cells("ADVAMT").Value)
                    v_obj.ParamType = "Double"
                    v_obj.ParamSize = 100

                    mv_arrRptParam(3) = v_obj


                    v_obj = New ReportParameters
                    v_obj.ParamName = "p_BUSDATE"
                    v_obj.ParamCaption = "BUSDATE"
                    v_obj.ParamValue = String.Empty
                    v_obj.ParamValue = Me.BusDate
                    v_obj.ParamDescription = Me.BusDate
                    v_obj.ParamType = GetType(System.String).Name
                    v_obj.ParamSize = 10

                    mv_arrRptParam(4) = v_obj


                    v_obj = New ReportParameters
                    v_obj.ParamName = "p_FEEAMT"
                    v_obj.ParamCaption = "FEEAMT"
                    v_obj.ParamValue = String.Empty
                    v_obj.ParamValue = CDbl(ADVSchdGrid.DataRows(i).Cells("FEEAMT").Value)
                    v_obj.ParamDescription = CDbl(ADVSchdGrid.DataRows(i).Cells("FEEAMT").Value)
                    v_obj.ParamType = "Double"
                    v_obj.ParamSize = 100
                    mv_arrRptParam(5) = v_obj

                End If
            Next

            'Bao gồm cả 02 tham số mặc định OPT và BRID
            mv_intNumOfParam = 6
            ReDim Preserve mv_arrRptParam(mv_intNumOfParam - 1) 'Phan tu mang bat dau tu 0
        Catch ex As Exception
            Throw ex
        Finally
            'v_xmlDocument = Nothing
        End Try
    End Sub

    Private Function GetReportFileName(ByVal pv_strCMDID As String) As String
        Return pv_strCMDID & TellerId & ".rpt"
    End Function
End Class