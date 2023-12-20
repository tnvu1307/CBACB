Imports Xceed.SmartUI.Controls
Imports AppCore
Imports AppCore.modCoreLib
Imports CommonLibrary
Imports Xceed

Public Class frmDetailFixOD
#Region " Declare constant and variables "
    Dim ODDetailGrid As GridEx
    Private mv_ResourceManager As Resources.ResourceManager
    Private mv_OrderId As String
    Private mv_strLanguage As String
    Private mv_ModuleCode As String
    Private mv_BusDate As String
    Private mv_strORGORDERID As String
    Private mv_strAFACCTNO As String
    Private mv_strTXNUM As String
    Private mv_strCUSTODYCD As String
    Private mv_Qtty As Double
    Private mv_Price As Double
    Private mv_BranchId As String
    Private mv_TellerId As String
    Private mv_IpAddress As String
    Private mv_WsName As String
    Private mv_EditedQtty As Double
    Private mv_strDesc As String
    Private mv_RefConfirmNumber As String
    Private mv_strDesAcctno As String
    Private mv_strXmlMessageData As String
    Private mv_arrObjFields() As CFieldMaster
    Private mv_arrObjFldVals() As CFieldVal

    Const c_ResourceManager As String = "_DIRECT.frmDetailFixOD-"
#End Region
#Region "Properties"
    Public Property OrderId() As String
        Get
            Return mv_OrderId
        End Get
        Set(ByVal Value As String)
            mv_OrderId = Value
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
    Public Property UserLanguage() As String
        Get
            Return mv_strLanguage
        End Get
        Set(ByVal value As String)
            mv_strLanguage = value
        End Set
    End Property
    Public Property ModuleCode() As String
        Get
            Return mv_ModuleCode
        End Get
        Set(ByVal value As String)
            mv_ModuleCode = value
        End Set
    End Property
    Public Property BusDate()
        Get
            Return mv_BusDate
        End Get
        Set(ByVal value)
            mv_BusDate = value
        End Set
    End Property
    Public Property BranchId()
        Get
            Return mv_BranchId
        End Get
        Set(ByVal value)
            mv_BranchId = value
        End Set
    End Property

    Public Property TellerId()
        Get
            Return mv_TellerId
        End Get
        Set(ByVal value)
            mv_TellerId = value
        End Set
    End Property
    Public Property IpAddress()
        Get
            Return mv_IpAddress
        End Get
        Set(ByVal value)
            mv_IpAddress = value
        End Set
    End Property
    Public Property WsName()
        Get
            Return mv_WsName
        End Get
        Set(ByVal value)
            mv_WsName = value
        End Set
    End Property
#End Region


#Region " Other methods"
    Public Sub New()
        MyBase.New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & "VN", System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)
        InitializeGrid()
    End Sub

    Private Sub InitializeGrid()
        ODDetailGrid = New GridEx

        Dim v_grODDetailGrid As Xceed.Grid.GroupByRow
        v_grODDetailGrid = New Xceed.Grid.GroupByRow
        v_grODDetailGrid.NoGroupText = mv_ResourceManager.GetString("GridEx.GroupByRow")

        v_grODDetailGrid.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(127, Byte), CType(123, Byte), CType(122, Byte))
        v_grODDetailGrid.CellBackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_grODDetailGrid.CellFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)

        Dim v_cmrODDetailGrid As New Xceed.Grid.ColumnManagerRow
        v_cmrODDetailGrid.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrODDetailGrid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)


        ODDetailGrid.FixedHeaderRows.Add(v_grODDetailGrid)
        ODDetailGrid.FixedHeaderRows.Add(v_cmrODDetailGrid)

        Dim v_frODDetailGrid As Xceed.Grid.TextRow
        v_frODDetailGrid = New Xceed.Grid.TextRow(mv_ResourceManager.GetString("GridEx.FooterRow"))
        v_frODDetailGrid.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_frODDetailGrid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic)

        ODDetailGrid.FixedFooterRows.Clear()
        ODDetailGrid.FixedFooterRows.Add(v_frODDetailGrid)

        ODDetailGrid.Columns.Add(New Xceed.Grid.Column("CUSTODYCD", GetType(System.String)))
        ODDetailGrid.Columns.Add(New Xceed.Grid.Column("ORGORDERID", GetType(System.String)))
        ODDetailGrid.Columns.Add(New Xceed.Grid.Column("SYMBOL", GetType(System.String)))
        ODDetailGrid.Columns.Add(New Xceed.Grid.Column("BORS", GetType(System.String)))        
        ODDetailGrid.Columns.Add(New Xceed.Grid.Column("PRICE", GetType(System.Double)))
        ODDetailGrid.Columns.Add(New Xceed.Grid.Column("QTTY", GetType(System.Double)))        
        ODDetailGrid.Columns.Add(New Xceed.Grid.Column("MATCHPRICE", GetType(System.Double)))
        ODDetailGrid.Columns.Add(New Xceed.Grid.Column("MATCHQTTY", GetType(System.Double)))
        'Khoi luong dieu chinh        
        ODDetailGrid.Columns.Add(New Xceed.Grid.Column("EDITEDQTTY", GetType(System.Double)))        
        ODDetailGrid.Columns.Add(New Xceed.Grid.Column("AFACCTNO", GetType(System.String)))
        ODDetailGrid.Columns.Add(New Xceed.Grid.Column("TRADELOT", GetType(System.String)))
        ODDetailGrid.Columns.Add(New Xceed.Grid.Column("REFCONFIRMNUMBER", GetType(System.String)))        


        
        ODDetailGrid.Columns("ORGORDERID").Title = mv_ResourceManager.GetString("ORGORDERID")
        ODDetailGrid.Columns("SYMBOL").Title = mv_ResourceManager.GetString("SYMBOL")
        ODDetailGrid.Columns("BORS").Title = mv_ResourceManager.GetString("BORS")
        ODDetailGrid.Columns("CUSTODYCD").Title = mv_ResourceManager.GetString("CUSTODYCD")
        ODDetailGrid.Columns("PRICE").Title = mv_ResourceManager.GetString("PRICE")
        ODDetailGrid.Columns("PRICE").FormatSpecifier = "#,##0"
        ODDetailGrid.Columns("QTTY").Title = mv_ResourceManager.GetString("QTTY")
        ODDetailGrid.Columns("QTTY").FormatSpecifier = "#,##0"        
        ODDetailGrid.Columns("MATCHPRICE").Title = mv_ResourceManager.GetString("MATCHPRICE")
        ODDetailGrid.Columns("MATCHPRICE").FormatSpecifier = "#,##0"
        ODDetailGrid.Columns("MATCHQTTY").Title = mv_ResourceManager.GetString("MATCHQTTY")
        ODDetailGrid.Columns("MATCHQTTY").FormatSpecifier = "#,##0"
        'Khoi luong dieu chinh
        ODDetailGrid.Columns("EDITEDQTTY").Title = mv_ResourceManager.GetString("EDITEDQTTY")
        ODDetailGrid.Columns("EDITEDQTTY").FormatSpecifier = "#,##0"
        ODDetailGrid.Columns("AFACCTNO").Title = mv_ResourceManager.GetString("AFACCTNO")        
        ODDetailGrid.Columns("TRADELOT").Title = mv_ResourceManager.GetString("TRADELOT")
        ODDetailGrid.Columns("REFCONFIRMNUMBER").Title = mv_ResourceManager.GetString("REFCONFIRMNUMBER")
        ODDetailGrid.Columns("ORGORDERID").Width = 120

        ODDetailGrid.Columns("ORGORDERID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left        
        ODDetailGrid.Columns("SYMBOL").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left        
        ODDetailGrid.Columns("CUSTODYCD").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODDetailGrid.Columns("BORS").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODDetailGrid.Columns("PRICE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODDetailGrid.Columns("QTTY").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left        
        ODDetailGrid.Columns("MATCHPRICE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODDetailGrid.Columns("MATCHQTTY").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODDetailGrid.Columns("EDITEDQTTY").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODDetailGrid.Columns("AFACCTNO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left    
        ODDetailGrid.Columns("TRADELOT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODDetailGrid.Columns("TRADELOT").Width = 0
        ODDetailGrid.Columns("REFCONFIRMNUMBER").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ODDetailGrid.Columns("REFCONFIRMNUMBER").Width = 120

        Me.pnODDeailInfo.Controls.Clear()
        Me.pnODDeailInfo.Controls.Add(ODDetailGrid)
        ODDetailGrid.Dock = Windows.Forms.DockStyle.Fill
        AddHandler ODDetailGrid.SelectedRowsChanged, AddressOf Me.DeailSelectedRowChanged
    End Sub
    Private Sub InitDataGrid()
        Dim v_strSQL As String
        Dim v_ws As New BDSDeliveryManagement        
        v_strSQL = " SELECT OD.ORDERID orgorderid,SEC.SYMBOL,B.CUSTODYCD, OD.AFACCTNO, B.BSCA BORS," _
            & " OD.QUOTEPRICE PRICE,  OD.ORDERQTTY QTTY , A.VOLUME MATCHQTTY, A.PRICE MATCHPRICE, SF.TRADELOT , A.REFCONFIRMNUMBER " _
            & " FROM ODMAST OD,SBSECURITIES SEC, securities_info SF ,STCTRADEBOOK A,STCORDERBOOK B " _
            & " WHERE(OD.ORDERID = B.ORDERID And A.ORDERNUMBER = B.ORDERNUMBER) " _
            & " AND OD.CODEID=SEC.CODEID AND SEC.TRADEPLACE<>'005' AND SF.CODEID = SEC.CODEID " _
            & " and OD.ORDERID = '" & mv_OrderId & "'"
        Try
            Me.ODDetailGrid.DataRows.Clear()
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_OD_ODMAST, gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)
            FillDataGrid(ODDetailGrid, v_strObjMsg, "")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, gc_ApplicationTitle)
        End Try
    End Sub
    Private Sub setGridRowValue(ByVal row As Grid.DataRow)
        Me.txtCUSTODYCD.Text = row.Cells("CUSTODYCD").Value
        Me.txtQuantity.Text = row.Cells("MATCHQTTY").Value
        Me.txtPrice.Text = row.Cells("MATCHPRICE").Value
        Me.txtOrderID.Text = row.Cells("ORGORDERID").Value
        Me.txtTradeLot.Text = row.Cells("TRADELOT").Value
        Me.txtEditQuantity.Text = row.Cells("EDITEDQTTY").Value
    End Sub
    Private Sub InitControlValue()
        'Set value control
        Me.txtCUSTODYCD.Enabled = False
        Me.txtQuantity.Enabled = False
        Me.txtPrice.Enabled = False
        Me.txtOrderID.Enabled = False
        Me.txtTradeLot.Enabled = False
        Me.txtAFACCTNO.Text = String.Empty
        For i As Integer = 0 To ODDetailGrid.DataRows.Count - 1
            Me.ODDetailGrid.DataRows(i).BeginEdit()
            Me.ODDetailGrid.DataRows(i).Cells("EDITEDQTTY").Value = CDbl(0)
            Me.ODDetailGrid.DataRows(i).EndEdit()
        Next
    End Sub
#End Region
#Region "Event"
    Private Sub DeailSelectedRowChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If (ODDetailGrid.CurrentRow Is Nothing) Then
            Exit Sub
        End If
        setGridRowValue(CType(ODDetailGrid.CurrentRow, Xceed.Grid.DataRow))
    End Sub
#End Region


    Private Sub frmDetailFixOD_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InitDataGrid()
        InitControlValue()
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
            End If
        Next
        Me.Text = mv_ResourceManager.GetString(Me.Name)
    End Sub
    Private Sub txtEditQuantity_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEditQuantity.LostFocus
        Dim v_dblEditedQtty As Double, v_dblQtty As Double, v_dblTradeLot As Double
        If Me.txtEditQuantity.Text = "" Then
            Me.txtEditQuantity.Text = "0"
        End If
        If Not IsNumeric(Me.txtEditQuantity.Text) Then
            MsgBox(mv_ResourceManager.GetString("Number_is_required"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Me.txtEditQuantity.Focus()
            Exit Sub
        End If
        v_dblEditedQtty = Double.Parse(Me.txtEditQuantity.Text)
        v_dblQtty = Double.Parse(Me.txtQuantity.Text)
        v_dblTradeLot = Double.Parse(Me.txtTradeLot.Text)
        If v_dblEditedQtty >= v_dblQtty Then
            MsgBox(mv_ResourceManager.GetString("EditedQtty_mustbe_smaller"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Exit Sub
        End If
        If Me.txtTradeLot.Text <> "0" Or Me.txtTradeLot.Text <> "" Then
            If (v_dblEditedQtty Mod v_dblTradeLot) <> 0 Then
                MsgBox(mv_ResourceManager.GetString("Lot_is_invalid"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            End If
        End If
        If Me.ODDetailGrid.DataRows.Count > 0 Then
            If Not Me.ODDetailGrid.CurrentRow Is Nothing Then
                Dim row As Grid.DataRow
                'ODDetailGrid.BeginInit()
                row = CType(ODDetailGrid.CurrentRow, Xceed.Grid.DataRow)
                row.BeginEdit()
                row.Cells("EDITEDQTTY").Value = CDbl(Me.txtEditQuantity.Text)
                row.EndEdit()
                'ODDetailGrid.EndInit()
            End If
        End If
    End Sub

    Private Sub btnExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecute.Click
        OnSubmit()
    End Sub
    Private Sub OnSubmit()
        Dim v_strTxMsg As String, v_xmlDocument As New Xml.XmlDocument, v_attrColl As Xml.XmlAttributeCollection
        Dim v_intNOSUBMIT As Integer, v_strNEXTTX As String = String.Empty
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError, v_lngErr As Long
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            If Not Control_Validate() Then
                Exit Sub
            End If
            If ODDetailGrid.DataRows.Count > 0 Then
                For i As Integer = 0 To Me.ODDetailGrid.DataRows.Count - 1
                    MessageData = vbNullString
                    mv_strORGORDERID = CStr(ODDetailGrid.DataRows(i).Cells("ORGORDERID").Value)
                    mv_strAFACCTNO = CStr(ODDetailGrid.DataRows(i).Cells("AFACCTNO").Value)
                    mv_Price = ODDetailGrid.DataRows(i).Cells("MATCHPRICE").Value
                    mv_Qtty = ODDetailGrid.DataRows(i).Cells("MATCHQTTY").Value
                    mv_EditedQtty = ODDetailGrid.DataRows(i).Cells("EDITEDQTTY").Value
                    mv_strDesAcctno = Replace(Me.txtAFACCTNO.Text, ".", "")
                    mv_RefConfirmNumber = CStr(ODDetailGrid.DataRows(i).Cells("REFCONFIRMNUMBER").Value)
                    mv_strDesc = mv_ResourceManager.GetString("DESC")
                    If mv_EditedQtty > 0 And mv_EditedQtty < mv_Qtty Then
                        If Not VerifyRules(v_strTxMsg) Then
                            Exit Sub
                        End If
                        v_lngError = v_ws.Message(v_strTxMsg)
                        If v_lngError <> ERR_SYSTEM_OK Then
                            'Thông báo lỗi
                            GetErrorFromMessage(v_strTxMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                            Cursor.Current = Cursors.Default
                            If v_lngError <> ERR_SA_CHECKER1_OVR And v_lngError <> ERR_SA_CHECKER2_OVR Then
                                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                                Exit Sub
                            End If
                        End If
                    End If
                Next i
                MsgBox(mv_ResourceManager.GetString("Approve_message"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, gc_ApplicationTitle)
        End Try
    End Sub
    Private Function VerifyRules(ByRef v_strTxMsg) As Boolean
        Try
            Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
            Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode, v_intIndex As Long, i, v_intCount As Integer
            Dim v_strFLDNAME As String, v_strFLDDEFNAME As String, v_strDATATYPE As String, v_strFLDVALUE As String
            Dim v_strERRMSG, v_strENERRMSG, v_strOPERATOR, v_strVALEXP, v_strVALEXP2 As String, v_strACTYPE, v_strDESC As String
            Dim v_dtVALEXP, v_dtVALEXP2, v_dtFLDVALUE As Date, v_strCMDSQL As String
            Dim v_ctl As Control, v_attrFLDNAME As Xml.XmlAttribute, v_attrDATATYPE As Xml.XmlAttribute, v_objEval As New Evaluator
            Dim v_strTLTXCD As String

            'Tạo điện giao dịch
            v_strTLTXCD = "8833"

            LoadScreen(v_strTLTXCD)
            v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, v_strTLTXCD, Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName)
            v_xmlDocument.LoadXml(v_strTxMsg)
            v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")
            If mv_arrObjFields.GetLength(0) > 0 Then
                For v_intIndex = 0 To mv_arrObjFields.GetLength(0) - 1 Step 1
                    If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                        v_strFLDNAME = mv_arrObjFields(v_intIndex).FieldName
                        v_strDATATYPE = mv_arrObjFields(v_intIndex).DataType
                        Select Case Trim(v_strFLDNAME)
                            Case "01" 'TXNUM
                                v_strFLDVALUE = mv_strTXNUM
                            Case "02" 'AFACCTNO
                                v_strFLDVALUE = mv_strAFACCTNO
                            Case "03" 'ORGORDERID
                                v_strFLDVALUE = mv_strORGORDERID
                            Case "04" 'PRICE
                                v_strFLDVALUE = CStr(mv_Price)
                            Case "05" 'QTTY
                                v_strFLDVALUE = CStr(mv_Qtty)
                            Case "06" 'EDITEDQTTY
                                v_strFLDVALUE = CStr(mv_EditedQtty)
                            Case "07" 'DESACCTNO
                                v_strFLDVALUE = mv_strDesAcctno
                            Case "08" 'REFCONFIRMNUMBER
                                v_strFLDVALUE = mv_RefConfirmNumber
                            Case "30"
                                v_strFLDVALUE = mv_strDesc
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

            'Lấy thông tin chung v? giao d�ịch
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
                'ResetScreen(Me)
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
                                'If v_strValue = "Y" Then
                                '    mv_blnAcctEntry = True
                                'Else
                                '    mv_blnAcctEntry = False
                                'End If
                            Case "BGCOLOR"

                        End Select

                    End With
                Next
            Next

            'Lấy thông tin chi tiết các trư?ng c�ủa giao dịch
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
                        'Xử lý cho trư?ng Description
                        v_strDefVal = Me.Text
                    ElseIf v_strDefVal = "<$BUSDATE>" Then
                        'L�ấy ngày làm việc hiện tại
                        v_strDefVal = Me.BusDate
                    End If
                    If v_blnChain Then
                        'Nếu giao dịch được nạp qua giao dịch tra cứu
                        If Len(v_strChainName) > 0 Then
                            'Nếu trư?ng n�ày có sử dụng CHAINNAME để lấy giá trị từ màn hình tra cứu
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

            'Lấy các luật kiểm tra của các trư?ng giao d�ịch
            v_strClause = "SELECT FLDNAME, VALTYPE, OPERATOR, VALEXP, VALEXP2, ERRMSG, EN_ERRMSG FROM FLDVAL " & _
                "WHERE upper(OBJNAME) = '" & strTLTXCD & "' ORDER BY VALTYPE, FLDNAME, ODRNUM" 'Thứ tự order by là quan tr?ng kh�ông sửa
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
                        'Ghi nhận thuật toán để kiểm tra và tính toán cho từng trư?ng c�ủa giao dịch
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

                '?i�?u ki�ện xử lý
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

    Private Sub txtAFACCTNO_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAFACCTNO.KeyUp
        If e.KeyCode = Keys.F5 Then
            Dim frm As New frmSearch(Me.UserLanguage)
            frm.TableName = "P_ACCTNO"
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
                Me.ActiveControl.Text = Trim(frm.RefValue)
            End If
            frm.Dispose()
        End If
    End Sub
    Private Function Control_Validate() As Boolean
        Dim v_ws As New BDSDeliveryManagement
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim result As Boolean = True
        Dim v_strAfacctno As String
        'Check AFACCTNO
        Try
            If Me.txtAFACCTNO.Text <> String.Empty Then
                Dim v_strSQL As String
                v_strAfacctno = Me.txtAFACCTNO.Text.Trim.Replace(".", "")
                v_strSQL = "select FULLNAME, ACCTNO  " _
                        & " from cfmast cf, afmast af where af.custid = cf.custid and af.acctno = '" & v_strAfacctno & "'"
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                If v_nodeList.Count = 0 Then
                    MsgBox(mv_ResourceManager.GetString("Afacctno_is_invalid"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    result = False
                End If
            Else
                result = False
            End If
            Return result
        Catch ex As Exception
            v_xmlDocument = Nothing
            v_ws = Nothing
            MsgBox(ex.Message, MsgBoxStyle.Critical, gc_ApplicationTitle)
        End Try

    End Function

End Class