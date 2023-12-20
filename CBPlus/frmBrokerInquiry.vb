Imports AppCore
Imports CommonLibrary
Imports Xceed.Grid.Collections
Imports Xceed.Grid.Editors
Imports System.Xml
Imports System.Configuration.ConfigurationSettings
Imports System.Windows.Forms.Application
Imports System.Text

Public Class frmBrokerInquiry

    Private mv_strIpAddress As String
    Private mv_strWsName As String

    Public SEMASTGrid As GridEx
    Public ODHISTGrid As GridEx

    Private mv_blnAFLoading As String = False

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



    Public Overrides Sub OnInit()
        ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & Me.Name & "-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        MyBase.OnInit()

        LoadUserInterface(Me)
        InitExternal()
        Me.txtCUSTODYCD.Focus()
        Me.txtCUSTODYCD.SelectionStart = (Me.txtCUSTODYCD.Text.Length)
        Me.txtCUSTODYCD.BackColor = System.Drawing.Color.GreenYellow
    End Sub


    Private Sub InitExternal()
        Try
            'Khoi tao cho grid SEMASTGrid
            SEMASTGrid = New GridEx
            Dim v_cmrSEMASTGridHeader As New Xceed.Grid.ColumnManagerRow
            v_cmrSEMASTGridHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            v_cmrSEMASTGridHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            v_cmrSEMASTGridHeader.Height = 32
            SEMASTGrid.FixedHeaderRows.Add(v_cmrSEMASTGridHeader)
            SEMASTGrid.Columns.Add(New Xceed.Grid.Column("SYMBOL", GetType(System.String)))
            SEMASTGrid.Columns.Add(New Xceed.Grid.Column("TOTALQTTY", GetType(Double)))
            SEMASTGrid.Columns.Add(New Xceed.Grid.Column("TRADE", GetType(Double)))
            SEMASTGrid.Columns.Add(New Xceed.Grid.Column("DFTRADING", GetType(Double)))
            SEMASTGrid.Columns.Add(New Xceed.Grid.Column("ABSTANDING", GetType(Double)))
            SEMASTGrid.Columns.Add(New Xceed.Grid.Column("RESTRICTQTTY", GetType(Double)))
            SEMASTGrid.Columns.Add(New Xceed.Grid.Column("BLOCKED", GetType(Double)))
            SEMASTGrid.Columns.Add(New Xceed.Grid.Column("CARECEIVING", GetType(Double)))
            SEMASTGrid.Columns.Add(New Xceed.Grid.Column("SECURITIES_RECEIVING_T0", GetType(Double)))
            SEMASTGrid.Columns.Add(New Xceed.Grid.Column("SECURITIES_RECEIVING_T1", GetType(Double)))
            SEMASTGrid.Columns.Add(New Xceed.Grid.Column("SECURITIES_RECEIVING_T2", GetType(Double)))
            SEMASTGrid.Columns.Add(New Xceed.Grid.Column("MATCHINGAMT", GetType(Double)))
            SEMASTGrid.Columns.Add(New Xceed.Grid.Column("FIFOCOSTPRICE", GetType(Double)))
            SEMASTGrid.Columns.Add(New Xceed.Grid.Column("FIFOAMT", GetType(Double)))
            SEMASTGrid.Columns.Add(New Xceed.Grid.Column("BASICPRICE", GetType(Double)))
            SEMASTGrid.Columns.Add(New Xceed.Grid.Column("MKTAMT", GetType(Double)))
            SEMASTGrid.Columns.Add(New Xceed.Grid.Column("PNLAMT", GetType(Double)))
            SEMASTGrid.Columns.Add(New Xceed.Grid.Column("PNLRATE", GetType(System.String)))

            SEMASTGrid.Columns("SYMBOL").Title = ResourceManager.GetString("SEMASTGrid.SYMBOL")
            SEMASTGrid.Columns("TOTALQTTY").Title = ResourceManager.GetString("SEMASTGrid.TOTALQTTY")
            SEMASTGrid.Columns("TRADE").Title = ResourceManager.GetString("SEMASTGrid.TRADE")
            SEMASTGrid.Columns("DFTRADING").Title = ResourceManager.GetString("SEMASTGrid.DFTRADING")
            SEMASTGrid.Columns("ABSTANDING").Title = ResourceManager.GetString("SEMASTGrid.ABSTANDING")
            SEMASTGrid.Columns("RESTRICTQTTY").Title = ResourceManager.GetString("SEMASTGrid.RESTRICTQTTY")
            SEMASTGrid.Columns("BLOCKED").Title = ResourceManager.GetString("SEMASTGrid.BLOCKED")
            SEMASTGrid.Columns("CARECEIVING").Title = ResourceManager.GetString("SEMASTGrid.CARECEIVING")
            SEMASTGrid.Columns("SECURITIES_RECEIVING_T0").Title = ResourceManager.GetString("SEMASTGrid.SECURITIES_RECEIVING_T0")
            SEMASTGrid.Columns("SECURITIES_RECEIVING_T1").Title = ResourceManager.GetString("SEMASTGrid.SECURITIES_RECEIVING_T1")
            SEMASTGrid.Columns("SECURITIES_RECEIVING_T2").Title = ResourceManager.GetString("SEMASTGrid.SECURITIES_RECEIVING_T2")
            SEMASTGrid.Columns("MATCHINGAMT").Title = ResourceManager.GetString("SEMASTGrid.MATCHINGAMT")
            SEMASTGrid.Columns("FIFOCOSTPRICE").Title = ResourceManager.GetString("SEMASTGrid.FIFOCOSTPRICE")
            SEMASTGrid.Columns("FIFOAMT").Title = ResourceManager.GetString("SEMASTGrid.FIFOAMT")
            SEMASTGrid.Columns("BASICPRICE").Title = ResourceManager.GetString("SEMASTGrid.BASICPRICE")
            SEMASTGrid.Columns("MKTAMT").Title = ResourceManager.GetString("SEMASTGrid.MKTAMT")
            SEMASTGrid.Columns("PNLAMT").Title = ResourceManager.GetString("SEMASTGrid.PNLAMT")
            SEMASTGrid.Columns("PNLRATE").Title = ResourceManager.GetString("SEMASTGrid.PNLRATE")


            SEMASTGrid.Columns("SYMBOL").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
            SEMASTGrid.Columns("TOTALQTTY").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
            SEMASTGrid.Columns("TRADE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
            SEMASTGrid.Columns("DFTRADING").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
            SEMASTGrid.Columns("RESTRICTQTTY").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
            SEMASTGrid.Columns("ABSTANDING").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
            SEMASTGrid.Columns("BLOCKED").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
            SEMASTGrid.Columns("SECURITIES_RECEIVING_T0").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
            SEMASTGrid.Columns("SECURITIES_RECEIVING_T1").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
            SEMASTGrid.Columns("SECURITIES_RECEIVING_T2").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
            SEMASTGrid.Columns("CARECEIVING").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
            SEMASTGrid.Columns("MATCHINGAMT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
            SEMASTGrid.Columns("FIFOCOSTPRICE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
            SEMASTGrid.Columns("BASICPRICE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
            SEMASTGrid.Columns("FIFOAMT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
            SEMASTGrid.Columns("MKTAMT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
            SEMASTGrid.Columns("PNLAMT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right
            SEMASTGrid.Columns("PNLRATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Right

            SEMASTGrid.Columns("SYMBOL").Width = 60
            SEMASTGrid.Columns("TOTALQTTY").Width = 100
            SEMASTGrid.Columns("TRADE").Width = 100
            SEMASTGrid.Columns("DFTRADING").Width = 100
            SEMASTGrid.Columns("RESTRICTQTTY").Width = 100
            SEMASTGrid.Columns("ABSTANDING").Width = 100
            SEMASTGrid.Columns("BLOCKED").Width = 100
            SEMASTGrid.Columns("SECURITIES_RECEIVING_T0").Width = 100
            SEMASTGrid.Columns("SECURITIES_RECEIVING_T1").Width = 100
            SEMASTGrid.Columns("SECURITIES_RECEIVING_T2").Width = 100
            SEMASTGrid.Columns("CARECEIVING").Width = 100
            SEMASTGrid.Columns("FIFOCOSTPRICE").Width = 100
            SEMASTGrid.Columns("BASICPRICE").Width = 100
            SEMASTGrid.Columns("FIFOAMT").Width = 100
            SEMASTGrid.Columns("MATCHINGAMT").Width = 100
            SEMASTGrid.Columns("MKTAMT").Width = 100
            SEMASTGrid.Columns("PNLAMT").Width = 100
            SEMASTGrid.Columns("PNLRATE").Width = 100

            SEMASTGrid.Columns("TOTALQTTY").FormatSpecifier = gc_FORMAT_NUMBER_0
            SEMASTGrid.Columns("TRADE").FormatSpecifier = gc_FORMAT_NUMBER_0
            SEMASTGrid.Columns("DFTRADING").FormatSpecifier = gc_FORMAT_NUMBER_0
            SEMASTGrid.Columns("RESTRICTQTTY").FormatSpecifier = gc_FORMAT_NUMBER_0
            SEMASTGrid.Columns("ABSTANDING").FormatSpecifier = gc_FORMAT_NUMBER_0
            SEMASTGrid.Columns("BLOCKED").FormatSpecifier = gc_FORMAT_NUMBER_0
            SEMASTGrid.Columns("SECURITIES_RECEIVING_T0").FormatSpecifier = gc_FORMAT_NUMBER_0
            SEMASTGrid.Columns("SECURITIES_RECEIVING_T1").FormatSpecifier = gc_FORMAT_NUMBER_0
            SEMASTGrid.Columns("SECURITIES_RECEIVING_T2").FormatSpecifier = gc_FORMAT_NUMBER_0
            SEMASTGrid.Columns("CARECEIVING").FormatSpecifier = gc_FORMAT_NUMBER_0
            SEMASTGrid.Columns("MATCHINGAMT").FormatSpecifier = gc_FORMAT_NUMBER_0
            SEMASTGrid.Columns("FIFOCOSTPRICE").FormatSpecifier = gc_FORMAT_NUMBER_0
            SEMASTGrid.Columns("BASICPRICE").FormatSpecifier = gc_FORMAT_NUMBER_0
            SEMASTGrid.Columns("FIFOAMT").FormatSpecifier = gc_FORMAT_NUMBER_0
            SEMASTGrid.Columns("MATCHINGAMT").FormatSpecifier = gc_FORMAT_NUMBER_0
            SEMASTGrid.Columns("MKTAMT").FormatSpecifier = gc_FORMAT_NUMBER_0
            SEMASTGrid.Columns("PNLAMT").FormatSpecifier = gc_FORMAT_NUMBER_0

            Me.grbSE.Controls.Clear()
            Me.grbSE.Controls.Add(SEMASTGrid)
            SEMASTGrid.Dock = Windows.Forms.DockStyle.Fill


            AddHandler SEMASTGrid.DoubleClick, AddressOf SEMASTGrid_Click
            If Me.SEMASTGrid.DataRowTemplate.Cells.Count >= 0 Then
                For i As Integer = 0 To Me.SEMASTGrid.DataRowTemplate.Cells.Count - 1
                    AddHandler SEMASTGrid.DataRowTemplate.Cells(i).DoubleClick, AddressOf SEMASTGrid_Click
                Next
            End If

        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Sub


    Private Sub SEMASTGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not (SEMASTGrid.CurrentRow Is Nothing) Then
            Me.txtSYMBOL.Text = CType(SEMASTGrid.CurrentRow, Xceed.Grid.DataRow).Cells("SYMBOL").Value
        End If
    End Sub

    Overrides Sub LoadUserInterface(ByRef pv_ctrl As Windows.Forms.Control)
        MyBase.LoadUserInterface(pv_ctrl)

        Me.cboLink.Visible = False
        Me.btnApply.Visible = False
        Me.btnApprv.Visible = False
        Me.btnOK.Visible = False
       
        Me.txtCUSTODYCD.Text = System.Configuration.ConfigurationSettings.AppSettings("PrefixedCustodyCode") & "C"
        Me.Text = ResourceManager.GetString("frmBrokerInquiry")
    End Sub

    Private Sub LoadCFInfo(ByVal pv_Custodycd As String)
        Dim v_strCmdSQL, v_strObjMsg, v_strFLDNAME, v_strVALUE As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFULLNAME, v_strADDRESS, v_strIDCODE, v_strIDDATE, v_strIDPLACE As String
        Dim v_strMOBILE, v_strEMAIL, v_strTRADETELEPHONE, v_strTRADEONLINE As String
        Try
            'Load Tieu khoan

            v_strCmdSQL = "SELECT V.FILTERCD, V.VALUE, V.VALUECD, V.DISPLAY, V.EN_DISPLAY, V.DESCRIPTION FROM VW_CUSTODYCD_SUBACCOUNT_ACTIVE V, CIMAST CI WHERE V.VALUE= CI.ACCTNO AND CAREBY IN (SELECT TLGRP.GRPID FROM TLGRPUSERS TLGRP WHERE TLID = '" & Me.TellerId & "') AND FILTERCD='" & pv_Custodycd.ToUpper & "'"

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            mv_blnAFLoading = True
            Me.cboAFACCTNO.Clears()
            FillComboEx(v_strObjMsg, Me.cboAFACCTNO, "", Me.UserLanguage)
            mv_blnAFLoading = False
            If Not Me.cboAFACCTNO.SelectedValue Is Nothing Then
                LoadAFInfo(Me.cboAFACCTNO.SelectedValue)
            Else
                MsgBox(ResourceManager.GetString("INVALID_CUSTODYCD"), MsgBoxStyle.Information)
                ResetScreen
            End If

            'Load TT Khach hang
            v_strCmdSQL = "select fullname, address, idcode, to_char(iddate,'DD/MM/RRRR') iddate, idplace,nvl(MobileSMS,'KXĐ') || '-' || nvl(Mobile,'KXĐ') mobile, nvl(email,'KXĐ') email,case when tradetelephone ='Y' then 'Có' else 'Không' end tradetelephone,case when tradeonline ='Y' then 'Có' else 'Không' end tradeonline from cfmast where custodycd = '" & pv_Custodycd.ToUpper & "' "
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count > 0 Then
                For i As Integer = 0 To v_nodeList.Count - 1
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            'Ghi nhận thuật toán để kiểm tra và tính toán cho từng trư?ng c�ủa giao dịch
                            v_strVALUE = .InnerText.ToString
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "FULLNAME"
                                    v_strFULLNAME = Trim(v_strVALUE)
                                Case "ADDRESS"
                                    v_strADDRESS = Trim(v_strVALUE)
                                Case "IDCODE"
                                    v_strIDCODE = Trim(v_strVALUE)
                                Case "IDDATE"
                                    v_strIDDATE = Trim(v_strVALUE)
                                Case "IDPLACE"
                                    v_strIDPLACE = Trim(v_strVALUE)
                                Case "MOBILE"
                                    v_strMOBILE = Trim(v_strVALUE)
                                Case "EMAIL"
                                    v_strEMAIL = Trim(v_strVALUE)
                                Case "TRADETELEPHONE"
                                    v_strTRADETELEPHONE = Trim(v_strVALUE)
                                Case "TRADEONLINE"
                                    v_strTRADEONLINE = Trim(v_strVALUE)
                            End Select
                        End With
                    Next
                Next
            End If
            If v_strFULLNAME <> String.Empty Then
                lblCaption.Text = ResourceManager.GetString("FULLNAME") & " " & v_strFULLNAME & "  --  " & ResourceManager.GetString("EMAIL") & " " & v_strEMAIL & ControlChars.CrLf _
                    & ResourceManager.GetString("ADDRESS") & " " & v_strADDRESS & "  --  " & ResourceManager.GetString("MOBILE") & " " & v_strMOBILE & ControlChars.CrLf _
                    & ResourceManager.GetString("IDCODE") & " " & v_strIDCODE & ", " & ResourceManager.GetString("IDDATE") & " " & v_strIDDATE & ", " & ResourceManager.GetString("IDPLACE") & " " & v_strIDPLACE _
                    & "  --  " & ResourceManager.GetString("TRADETELEPHONE") & " " & v_strTRADETELEPHONE & ", " & ResourceManager.GetString("TRADEONLINE") & " " & v_strTRADEONLINE
            End If

        Catch ex As Exception
            MsgBox(ResourceManager.GetString("INVALID_CUSTODYCD"), MsgBoxStyle.Information)
            ResetScreen()
        End Try
    End Sub

    Private Sub LoadAccountBankInfo(ByVal pv_Afacctno As String)
        Dim v_strCmdSQL, v_strObjMsg, v_strFLDNAME, v_strVALUE As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strAlternateAcct, v_strCorebank, v_strBankName, v_strBankAcctno, v_strAutoTrf As String
        Try
            'Load TT Khach hang
            v_strCmdSQL = "select case when alternateacct='Y' then 'Có' else 'Không' end alternateacct,case when corebank='Y' then 'Có' else 'Không' end corebank, case when bankname='---' then 'Không có' else bankname end bankname, nvl(bankacctno,'Không có') bankacctno, case when autotrf='Y' then 'Có' else 'Không' end autotrf  from afmast where acctno='" & pv_Afacctno.ToUpper & "' "
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count > 0 Then
                For i As Integer = 0 To v_nodeList.Count - 1
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            'Ghi nhận thuật toán để kiểm tra và tính toán cho từng trư?ng c�ủa giao dịch
                            v_strVALUE = .InnerText.ToString
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "ALTERNATEACCT"
                                    v_strAlternateAcct = Trim(v_strVALUE)
                                Case "COREBANK"
                                    v_strCorebank = Trim(v_strVALUE)
                                Case "BANKNAME"
                                    v_strBankName = Trim(v_strVALUE)
                                Case "BANKACCTNO"
                                    v_strBankAcctno = Trim(v_strVALUE)
                                Case "AUTOTRF"
                                    v_strAutoTrf = Trim(v_strVALUE)
                            End Select
                        End With
                    Next
                Next
            End If
            If v_strCorebank <> String.Empty Then
                lblBankInfo.Text = ResourceManager.GetString("COREBANK") & " " & v_strCorebank & "  --  " & ResourceManager.GetString("ALTERNATEACCT") & " " & v_strAlternateAcct & "  --  " & ResourceManager.GetString("AUTOTRF") & " " & v_strAutoTrf & "  --  " _
                    & ResourceManager.GetString("BANKNAME") & " " & v_strBankName & "  --  " & ResourceManager.GetString("BANKACCTNO") & " " & v_strBankAcctno
            End If

        Catch ex As Exception
            MsgBox(ResourceManager.GetString("INVALID_CUSTODYCD"), MsgBoxStyle.Information)
            ResetScreen()
        End Try
    End Sub

    Private Sub txtCUSTODYCD_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCUSTODYCD.KeyUp
        Select e.KeyCode
            Case Keys.F5
                Dim frm As New frmSearch(Me.UserLanguage)
                frm.TableName = "CUSTODYCD_CF"
                frm.ModuleCode = "CF"
                frm.KeyFieldType = "C"
                frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                frm.IsLocalSearch = gc_IsNotLocalMsg
                frm.IsLookup = "Y"
                frm.SearchOnInit = False
                frm.BranchId = "9999"
                frm.TellerId = Me.TellerId
                frm.ShowDialog()
                Me.ActiveControl.Text = Trim(frm.ReturnValue)
        End Select

    End Sub

    Private Sub txtCUSTODYCD_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCUSTODYCD.Leave
        If Me.txtCUSTODYCD.Text.Trim.Length = 10 Then
            LoadCFInfo(Me.txtCUSTODYCD.Text.Trim)

            If Not Me.cboAFACCTNO.SelectedValue Is Nothing Then
                Me.btnODHISTORY.Enabled = True
                Me.btnSEREPORT.Enabled = True
                Me.btnCIREPORT.Enabled = True
                Me.btnAFREPORT.Enabled = True
                Me.btnCAREPORT.Enabled = True
                Me.btnODADV.Enabled = True
                Me.btnTRFBUY.Enabled = True
                Me.btnAFCALL.Enabled = True
                Me.btnMRCALL.Enabled = True
                Me.btnLNREPORT.Enabled = True
            Else
                Me.btnODHISTORY.Enabled = False
                Me.btnSEREPORT.Enabled = False
                Me.btnCIREPORT.Enabled = False
                Me.btnAFREPORT.Enabled = False
                Me.btnCAREPORT.Enabled = False
                Me.btnODADV.Enabled = False
                Me.btnTRFBUY.Enabled = False
                Me.btnAFCALL.Enabled = False
                Me.btnLNREPORT.Enabled = False
                Me.btnMRCALL.Enabled = False
            End If
        End If
    End Sub

    Private Sub ResetScreen()

        Me.txtCUSTODYCD.Text = System.Configuration.ConfigurationSettings.AppSettings("PrefixedCustodyCode") & "C"
        Me.cboAFACCTNO.Clears()
        Me.SEMASTGrid.DataRows.Clear()
        
        Me.txtPPSE.Text = "0"
        Me.txtPRICE.Text = "0"
        Me.txtSYMBOL.Text = String.Empty
       

        If Not Me.cboAFACCTNO.SelectedValue Is Nothing Then
            Me.btnODHISTORY.Enabled = True
            Me.btnSEREPORT.Enabled = True
            Me.btnCIREPORT.Enabled = True
            Me.btnAFREPORT.Enabled = True
            Me.btnCAREPORT.Enabled = True
            Me.btnODADV.Enabled = True
            Me.btnTRFBUY.Enabled = True
            Me.btnAFCALL.Enabled = True
            Me.btnLNREPORT.Enabled = True
        Else
            Me.btnODHISTORY.Enabled = False
            Me.btnSEREPORT.Enabled = False
            Me.btnCIREPORT.Enabled = False
            Me.btnAFREPORT.Enabled = False
            Me.btnCAREPORT.Enabled = False
            Me.btnODADV.Enabled = False
            Me.btnTRFBUY.Enabled = False
            Me.btnAFCALL.Enabled = False
            Me.btnLNREPORT.Enabled = False
        End If
        Me.lblCaption.Text = ResourceManager.GetString("lblCaption0")
        Me.txtCUSTODYCD.Focus()
        Me.txtCUSTODYCD.SelectionStart = (Me.txtCUSTODYCD.Text.Length)
    End Sub

    Public Function GetBankBalance(ByVal pv_strACCTNO As String) As String
        Try
            Dim v_strClause, v_strObjMsg, v_strValue As String
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_ws As New BDSDeliveryManagement
            'Tao message gui len HOST de xu ly
            v_strClause = v_strValue
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetBankBalance", , , , pv_strACCTNO)
            v_ws.Message(v_strObjMsg)
            'Lay gia tri tra ve
            v_xmlDocument.LoadXml(v_strObjMsg)
            Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocument.DocumentElement.Attributes
            v_strValue = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeREFERENCE), Xml.XmlAttribute).Value)

            Return v_strValue
        Catch ex As Exception
            'Throw ex
            Return "0"
        End Try
    End Function

    Private Sub LoadAFInfo(ByVal pv_AFACCTNO As String)
        Dim v_dblMKVal, v_dblDFMKVal As Double
        Dim v_strCmdSQL, v_strObjMsg, v_strClause As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_dec As Decimal
        v_dblMKVal = 0
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strValue, v_strFLDNAME As String, i, j As Integer

        Dim v_dbl1_1Cibalance, v_dbl1_2rcvamt, v_dbl2_1tradeseamt, v_dbl2_2rcvseamt, v_dbl3_1dfamt, v_dbl3_2t0amt, v_dbl3_3mramt, v_dbl3_4depofeeamt, v_dbl3_5trfbuyamt, _
            v_dbl3_6securedamt, v_dbl3_7rcvadv, v_dbl1_1Tdbalance, v_dbl1_1Intbalance, v_dbl1_1Mrqqtyamt, v_dbl1_1Nonmrqttyamt, v_dbl2_3dfqttyamt, v_dbl3_1Secureamt, _
            v_dbl3_5Dfodamt, v_dbl3_4Rcvadvamt, v_dbl3_6Tdodamt, v_dbl6_1Qttyamt, v_dbl6_2Cibalance, v_dbl6_3Mrcrlimit, v_dbl6_4Bankavlbal, v_dbl6_5Totalodamt, v_dbl5_1Sesecured, v_dbl5_2Sesecured, v_dbl3_5dpamt As Double
        Dim v_dblTOTALSEAMT As Double
        Try
            'Lay thong tin ket noi ngan hang
            LoadAccountBankInfo(pv_AFACCTNO)
            'Goi thong tin sang ngan hang de cap nhat so tien ngan hang
            Try
                GetBankBalance(pv_AFACCTNO)
            Catch ex As Exception
                v_dblMKVal = 0
            End Try


            v_strCmdSQL = "cspks_brokerinquiry.pr_getSubAccountInfonew"
            v_strClause = "p_afacctno!" & pv_AFACCTNO & "!varchar2!20"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL, v_strClause, , , , , , , gc_CommandProcedure)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i = 0 To v_nodeList.Count - 1
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = Trim(.InnerText.ToString)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "BALANCE"
                                Me.lblBALANCEV.Text = Format(Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_0)
                            Case "TOTALODAMT"
                                Me.lblTOTALODAMTV.Text = Format(Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_0)
                            Case "TOTALSEAMT"
                                Me.lblTOTALSEAMTV.Text = Format(Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_0)
                                v_dblTOTALSEAMT = Math.Round(CDbl(v_strValue))
                            Case "NETASSVAL"
                                Me.lblNETASSVALUEV.Text = Format(Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_0)
                            Case "BUYINGSEAMT"
                                Me.lblACCOUNTVALUEV.Text = Format(Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_0)
                            Case "SESECURED"
                                Me.lblSESECUREDV.Text = Format(Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_0)
                            Case "ACCOUNTVALUE"
                                Me.lblACCOUNTVALUEV.Text = Format(Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_0)
                            Case "PP0"
                                Me.lblPP0V.Text = Format(Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_0)
                                'Case "BANKAVLBAL"
                                '    Me.lblBANKAVLBALV.Text = Format(Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_0)
                            Case "MRRATE"
                                Me.lblMARGINRATEV.Text = Format(Math.Round(CDbl(v_strValue), 2), gc_FORMAT_NUMBER_2)
                            Case "MRCRLIMITMAX"
                                Me.txtMRCRLIMITMAX.Text = Format(Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_0)
                            Case "ADVANCELINE"
                                Me.txtADVANCELINE.Text = Format(Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_0)
                            Case "AVLLIMIT"
                                Me.txtAVLLIMIT.Text = Format(Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_0)
                            Case "CIBALANCE"
                                v_dbl1_1Cibalance = Math.Round(CDbl(v_strValue))
                            Case "TDBALANCE"
                                v_dbl1_1Tdbalance = Math.Round(CDbl(v_strValue))
                            Case "INTBALANCE"
                                v_dbl1_1Intbalance = Math.Round(CDbl(v_strValue))
                            Case "MRQTTYAMT"
                                v_dbl1_1Mrqqtyamt = Math.Round(CDbl(v_strValue))
                            Case "NONMRQTTYAMT"
                                v_dbl1_1Nonmrqttyamt = Math.Round(CDbl(v_strValue))
                            Case "RCVAMT"
                                v_dbl1_2rcvamt = Math.Round(CDbl(v_strValue))
                            Case "TRADESEAMT"
                                v_dbl2_1tradeseamt = Math.Round(CDbl(v_strValue))
                            Case "RCVSEAMT"
                                v_dbl2_2rcvseamt = Math.Round(CDbl(v_strValue))
                            Case "DFAMT"
                                v_dbl3_1dfamt = Math.Round(CDbl(v_strValue))
                            Case "DFQTTYAMT"
                                v_dbl2_3dfqttyamt = Math.Round(CDbl(v_strValue))
                            Case "T0AMT"
                                v_dbl3_2t0amt = Math.Round(CDbl(v_strValue))
                            Case "MRAMT"
                                v_dbl3_3mramt = Math.Round(CDbl(v_strValue))
                            Case "DEPOFEEAMT"
                                v_dbl3_4depofeeamt = Math.Round(CDbl(v_strValue))
                            Case "TRFBUYAMT"
                                v_dbl3_5trfbuyamt = Math.Round(CDbl(v_strValue))
                            Case "DPAMT"
                                v_dbl3_5dpamt = Math.Round(CDbl(v_strValue))
                            Case "SECUREDAMT"
                                v_dbl3_6securedamt = Math.Round(CDbl(v_strValue))
                            Case "RCVADV"
                                v_dbl3_7rcvadv = Math.Round(CDbl(v_strValue))
                            Case "SECUREAMT"
                                v_dbl3_1Secureamt = Math.Round(CDbl(v_strValue))
                            Case "RCVADVAMT"
                                v_dbl3_4Rcvadvamt = Math.Round(CDbl(v_strValue))
                            Case "DFODAMT"
                                v_dbl3_5Dfodamt = Math.Round(CDbl(v_strValue))
                            Case "TDODAMT"
                                v_dbl3_6Tdodamt = Math.Round(CDbl(v_strValue))
                            Case "QTTYAMT"
                                v_dbl6_1Qttyamt = Math.Round(CDbl(v_strValue))
                            Case "CIBALANCE2"
                                v_dbl6_2Cibalance = Math.Round(CDbl(v_strValue))
                            Case "MRCRLIMIT"
                                v_dbl6_3Mrcrlimit = Math.Round(CDbl(v_strValue))
                            Case "BANKAVLBAL"
                                v_dbl6_4Bankavlbal = Math.Round(CDbl(v_strValue))
                            Case "TOTALODAMT2"
                                v_dbl6_5Totalodamt = Math.Round(CDbl(v_strValue))
                            Case "SESECURED_AVL"
                                v_dbl5_1Sesecured = Math.Round(CDbl(v_strValue))
                            Case "SESECURED_BUY"
                                v_dbl5_2Sesecured = Math.Round(CDbl(v_strValue))

                        End Select
                    End With
                Next
            Next

            Dim v_strTooltipCaption As String = ""

            'Add lblBALANCEV tooltip
            v_strTooltipCaption = "Tiền không kỳ hạn: " & Format(v_dbl1_1Cibalance, gc_FORMAT_NUMBER_0) & ControlChars.CrLf & _
                                  "Tiền gửi có kỳ hạn: " & Format(v_dbl1_1Tdbalance, gc_FORMAT_NUMBER_0) & ControlChars.CrLf & _
                                  "Tiền bán chờ về: " & Format(v_dbl1_2rcvamt, gc_FORMAT_NUMBER_0) & ControlChars.CrLf & _
                                  "Lãi tiền gửi chưa thanh toán: " & Format(v_dbl1_1Intbalance, gc_FORMAT_NUMBER_0)
            ToolTip1.SetToolTip(lblBALANCEV, v_strTooltipCaption)

            'Add lblTOTALSEAMTV tooltip
            v_strTooltipCaption = "Chứng khoán được phép Ký quỹ: " & Format(v_dbl1_1Mrqqtyamt, gc_FORMAT_NUMBER_0) & ControlChars.CrLf & _
                                  "Chứng khoán không được Ký quỹ: " & Format(v_dbl1_1Nonmrqttyamt, gc_FORMAT_NUMBER_0) & ControlChars.CrLf & _
                                  "Chứng khoán vay cầm cố: " & Format(v_dbl2_3dfqttyamt, gc_FORMAT_NUMBER_0)
            ToolTip1.SetToolTip(lblTOTALSEAMTV, v_strTooltipCaption)

            'Add lblTOTALODAMTV tooltip
            v_strTooltipCaption = "Nợ trả chậm: " & Format(v_dbl3_5dpamt, gc_FORMAT_NUMBER_0) & ControlChars.CrLf & _
                                  "Nợ ký quỹ: " & Format(v_dbl3_1Secureamt, gc_FORMAT_NUMBER_0) & ControlChars.CrLf & _
                                  "Nợ vay bảo lãnh: " & Format(v_dbl3_2t0amt, gc_FORMAT_NUMBER_0) & ControlChars.CrLf & _
                                  "Nợ vay Ký quỹ: " & Format(v_dbl3_3mramt, gc_FORMAT_NUMBER_0) & ControlChars.CrLf & _
                                  "Nợ vay ứng trước: " & Format(v_dbl3_4Rcvadvamt, gc_FORMAT_NUMBER_0) & ControlChars.CrLf & _
                                  "Nợ vay cầm cố tiền gửi: " & Format(v_dbl3_6Tdodamt, gc_FORMAT_NUMBER_0) & ControlChars.CrLf & _
                                  "Vay cầm cố chứng khoán: " & Format(v_dbl3_5Dfodamt, gc_FORMAT_NUMBER_0) & ControlChars.CrLf & _
                                  "Nợ phí lưu ký: " & Format(v_dbl3_4depofeeamt, gc_FORMAT_NUMBER_0)
            ToolTip1.SetToolTip(lblTOTALODAMTV, v_strTooltipCaption)

            'Add lblNETASSVALUE tooltip
            v_strTooltipCaption = "Tiền tại PHS + Chứng khoán - Phải trả"
            ToolTip1.SetToolTip(lblNETASSVALUEV, v_strTooltipCaption)

            'Add lblBALANCEV tooltip
            v_strTooltipCaption = "Chứng khoán được phép ký quỹ: " & Format(v_dbl6_1Qttyamt, gc_FORMAT_NUMBER_0) & ControlChars.CrLf & _
                                  "Tiền không kỳ hạn: " & Format(v_dbl6_2Cibalance, gc_FORMAT_NUMBER_0) & ControlChars.CrLf & _
                                  "Tiền gửi có kỳ hạn ký quỹ: " & Format(v_dbl6_3Mrcrlimit, gc_FORMAT_NUMBER_0) & ControlChars.CrLf & _
                                  "Số dư khả dụng tại ngân hàng: " & Format(v_dbl6_4Bankavlbal, gc_FORMAT_NUMBER_0) & ControlChars.CrLf & _
                                  "Nợ phải trả: " & Format(v_dbl6_5Totalodamt, gc_FORMAT_NUMBER_0) & ControlChars.CrLf & _
                                  "Tiền chờ về: " & Format(v_dbl1_2rcvamt, gc_FORMAT_NUMBER_0)

            ToolTip1.SetToolTip(lblACCOUNTVALUEV, v_strTooltipCaption)
            ''Add lblPP0 tooltip
            'v_strTooltipCaption = "Tài sản thực có + Tiền tại ngân hàng - Ký quỹ yêu cầu"
            'ToolTip1.SetToolTip(lblPP0, v_strTooltipCaption)

            'Add lblMARGINRATE tooltip
            v_strTooltipCaption = "(Tổng giá trị CK được phép ký quỹ + Tiền tại PHS + Tiền ngân tại NH - Vay)/Tổng giá trị CK được phép ký quỹ"
            ToolTip1.SetToolTip(lblMARGINRATE, v_strTooltipCaption)

            'Add lblPP0v tooltip
            v_strTooltipCaption = "Thặng dư tài sản = Ký quỹ hiện có - Ký quỹ yêu cầu"
            ToolTip1.SetToolTip(lblPP0V, v_strTooltipCaption)


            'Add lblSESECURED tooltip
            v_strTooltipCaption = "Chứng khoán hiện có: " & Format(v_dbl5_1Sesecured, gc_FORMAT_NUMBER_0) & ControlChars.CrLf & _
                                  "Lệnh mua chờ khớp: " & Format(v_dbl5_2Sesecured, gc_FORMAT_NUMBER_0)
            ToolTip1.SetToolTip(lblSESECUREDV, v_strTooltipCaption)

            LoadSEGrid(pv_AFACCTNO)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cboAFACCTNO_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAFACCTNO.Leave
        If mv_blnAFLoading <> True Then
            If Not Me.cboAFACCTNO.SelectedValue Is Nothing Then
                LoadAFInfo(Me.cboAFACCTNO.SelectedValue)
            End If
        End If
    End Sub

    Private Sub LoadPPse()
        If cboAFACCTNO.SelectedValue Is Nothing OrElse Me.txtSYMBOL.Text.Trim.Length = 0 Then Return

        Dim v_strCmdSQL, v_strObjMsg, v_strClause As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_dec As Decimal
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strValue, v_strFLDNAME As String, i, j As Integer
        Try

            v_strCmdSQL = "pr_getppse"
            v_strClause = "p_afacctno!" & Me.cboAFACCTNO.SelectedValue & "!varchar2!10^p_symbol!" & Me.txtSYMBOL.Text.ToUpper & "!varchar2!30^p_price!" & Format(Math.Round(CDbl(Me.txtPRICE.Text), 0), "###0") & "!number!20"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL, v_strClause, , , , , , , gc_CommandProcedure)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i = 0 To v_nodeList.Count - 1
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = Trim(.InnerText.ToString)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "PPSE"
                                Me.txtPPSE.Text = Format(Math.Round(CDbl(v_strValue)), gc_FORMAT_NUMBER_0)
                        End Select
                    End With
                Next
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtSYMBOL_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSYMBOL.Leave
        LoadPPse()
    End Sub

    Private Sub txtPRICE_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPRICE.Leave
        If Not IsNumeric(Me.txtPRICE.Text.Trim) Then
            Me.txtPRICE.Text = "0"
        End If
        Me.txtPRICE.Text = Format(Math.Round(CDbl(Me.txtPRICE.Text)), gc_FORMAT_NUMBER_0)
        LoadPPse()
    End Sub

    Private Sub LoadSEGrid(ByVal pv_AFACCTNO As String)
        Dim v_strCmdSQL, v_strObjMsg, v_strClause As String
        Dim v_ws As New BDSDeliveryManagement
        Try

            v_strCmdSQL = "cspks_brokerinquiry.pr_getSEAccountInfo"
            v_strClause = "p_afacctno!" & pv_AFACCTNO & "!varchar2!10"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strCmdSQL, v_strClause, , , , , , , gc_CommandProcedure)
            v_ws.Message(v_strObjMsg)
            FillDataGrid(SEMASTGrid, v_strObjMsg, "")
            'Dim v_dblMKVal, v_dblDFMKVal As Double
            'v_dblMKVal = 0
            'v_dblDFMKVal = 0
            'For v_intRow As Integer = 0 To SEMASTGrid.DataRows.Count - 1 Step 1
            '    v_dblMKVal = v_dblMKVal + CDbl(SEMASTGrid.DataRows(v_intRow).Cells("MKVAL").Value)
            'Next
            'Me.lblMKVALValue.Text = FormatNumber(v_dblMKVal.ToString, 0)


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnODHISTORY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnODHISTORY.Click
        Try
            If Me.txtCUSTODYCD.Text.Length = 10 Then
                Dim frm As New frmReportMaster(UserLanguage)
                frm.ModuleCode = "OD"
                frm.LocalObject = gc_IsLocalMsg
                frm.BranchId = Me.BranchId
                frm.TellerId = Me.TellerId
                frm.BusDate = Me.BusDate
                frm.AutoClose = True    ' Dong form hien thi danh sach bao cao sau khi tao bao cao
                frm.GroupCareBy = Me.GroupCareBy
                frm.RPTID = "OD0072"
                frm.IsFixPara = "Y"
                frm.InitPara = "CUSTODYCD|" & Me.txtCUSTODYCD.Text.Trim & "|Y^PV_ACCTNO|" & Me.cboAFACCTNO.SelectedValue & "|N^EXECTYPE|ALL|N^VIA|ALL|N"

                'frm.RPTID = "OD0040"
                'frm.IsFixPara = "Y"
                'frm.InitPara = "PV_CUSTODYCD|" & Me.txtCUSTODYCD.Text.Trim & "|Y^PV_AFACCTNO|" & Me.cboAFACCTNO.SelectedValue & "|Y^PV_ACCTYPE|ALL|N^PV_CUSTODYPLACE|ALL|N^PV_EXECTYPE|ALL|N^PV_MATCHTYPE|ALL|N^PV_TRADEPLACE|ALL|N^CASHPLACE|ALL|N^BRGID|ALL|N^CAREBY|ALL|N^DATE_T|3|N^TLID|" & Me.TellerId & "|N^PV_SYMBOL|ALL|N"


                frm.ShowDialog()
                frm.Dispose()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnSEREPORT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSEREPORT.Click
        Try
            Dim frm As New frmReportMaster(UserLanguage)
            frm.ModuleCode = "SE"
            frm.LocalObject = gc_IsLocalMsg
            frm.BranchId = Me.BranchId
            frm.TellerId = Me.TellerId
            frm.BusDate = Me.BusDate
            frm.GroupCareBy = Me.GroupCareBy
            frm.AutoClose = True    ' Dong form hien thi danh sach bao cao sau khi tao bao cao
            frm.RPTID = "SE1000"
            frm.IsFixPara = "Y"
            frm.InitPara = "pv_CUSTODYCD|" & Me.txtCUSTODYCD.Text.Trim & "|Y^PV_AFACCTNO|" & Me.cboAFACCTNO.SelectedValue & "|N"
            frm.ShowDialog()
            frm.Dispose()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnCIREPORT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCIREPORT.Click
        Try
            Dim frm As New frmReportMaster(UserLanguage)
            frm.ModuleCode = "CF"
            frm.LocalObject = gc_IsLocalMsg
            frm.BranchId = Me.BranchId
            frm.TellerId = Me.TellerId
            frm.BusDate = Me.BusDate
            frm.GroupCareBy = Me.GroupCareBy
            frm.AutoClose = True    ' Dong form hien thi danh sach bao cao sau khi tao bao cao
            frm.RPTID = "CF1008"
            frm.IsFixPara = "Y"
            frm.InitPara = "pv_CUSTODYCD|" & Me.txtCUSTODYCD.Text.Trim & "|Y^PV_AFACCTNO|" & Me.cboAFACCTNO.SelectedValue & "|N"
            frm.ShowDialog()
            frm.Dispose()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnAFREPORT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAFREPORT.Click
        Try
            Dim frm As New frmReportMaster(UserLanguage)
            frm.ModuleCode = "CF"
            frm.LocalObject = gc_IsLocalMsg
            frm.BranchId = Me.BranchId
            frm.TellerId = Me.TellerId
            frm.BusDate = Me.BusDate
            frm.GroupCareBy = Me.GroupCareBy
            frm.AutoClose = True    ' Dong form hien thi danh sach bao cao sau khi tao bao cao
            frm.RPTID = "CF0008"
            frm.IsFixPara = "Y"
            frm.InitPara = "I_DATE|" & Me.BusDate & "|Y^CUSTODYCD|" & Me.txtCUSTODYCD.Text.Trim & "|Y"
            frm.ShowDialog()
            frm.Dispose()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnODADV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnODADV.Click
        Try
            If Me.txtCUSTODYCD.Text.Length = 10 Then
                Dim frm As New frmReportMaster(UserLanguage)
                frm.ModuleCode = "CI"
                frm.LocalObject = gc_IsLocalMsg
                frm.BranchId = Me.BranchId
                frm.TellerId = Me.TellerId
                frm.BusDate = Me.BusDate
                frm.GroupCareBy = Me.GroupCareBy
                frm.RPTID = "CI0065"
                frm.AutoClose = True    ' Dong form hien thi danh sach bao cao sau khi tao bao cao
                frm.IsFixPara = "Y"
                frm.InitPara = "CUSTODYCD|" & Me.txtCUSTODYCD.Text.Trim & "|Y^AFACCTNO|" & Me.cboAFACCTNO.SelectedValue & "|N"
                frm.ShowDialog()
                frm.Dispose()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnTRFBUY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTRFBUY.Click
        Try
            Dim frmSearch As New frmSearch(UserLanguage)
            frmSearch.BusDate = Me.BusDate
            frmSearch.TableName = "MR0007"
            frmSearch.ModuleCode = Me.ModuleCode
            frmSearch.AuthCode = "NYNNYYYYYN" 'Chỉ cho phép g?i chức năng tạo giao dịch kế tiếp (Choose)
            frmSearch.CMDTYPE = "V"
            frmSearch.IsLocalSearch = gc_IsNotLocalMsg
            frmSearch.SearchOnInit = True            
            frmSearch.BranchId = Me.BranchId
            frmSearch.TellerId = Me.TellerId
            frmSearch.DefaultSearchFilter = "CUSTODYCD|=|" & Me.txtCUSTODYCD.Text.Trim & "|C^AFACCTNO|=|" & Me.cboAFACCTNO.SelectedValue & "|C"
            frmSearch.LoadLastFilter = True

            frmSearch.ShowDialog()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnCAREPORT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCAREPORT.Click
        Try
            Dim frmSearch As New frmSearch(UserLanguage)
            frmSearch.BusDate = Me.BusDate
            frmSearch.TableName = "CA1012"
            frmSearch.ModuleCode = Me.ModuleCode
            frmSearch.AuthCode = "NYNNYYYYNN" 'Chỉ cho phép g?i chức năng tạo giao dịch kế tiếp (Choose)
            frmSearch.CMDTYPE = "V"
            frmSearch.IsLocalSearch = gc_IsNotLocalMsg
            frmSearch.SearchOnInit = True            
            frmSearch.BranchId = Me.BranchId
            frmSearch.TellerId = Me.TellerId
            frmSearch.AFACCTNO = Me.cboAFACCTNO.SelectedValue
            'frmSearch.DefaultSearchFilter = "CUSTODYCD|=|" & Me.txtCUSTODYCD.Text.Trim & "|C^ACCTNO|=|" & Me.cboAFACCTNO.SelectedValue & "|C"
            'frmSearch.LoadLastFilter = True

            frmSearch.ShowDialog()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnAFCALL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAFCALL.Click
        Try
            Dim frmSearch As New frmSearch(UserLanguage)
            frmSearch.BusDate = Me.BusDate
            frmSearch.TableName = "MR0002"
            frmSearch.ModuleCode = Me.ModuleCode
            frmSearch.AuthCode = "NYNNYYYYYN" 'Chỉ cho phép g?i chức năng tạo giao dịch kế tiếp (Choose)
            frmSearch.CMDTYPE = "V"
            frmSearch.IsLocalSearch = gc_IsNotLocalMsg
            frmSearch.SearchOnInit = True            
            frmSearch.BranchId = Me.BranchId
            frmSearch.TellerId = Me.TellerId
            frmSearch.DefaultSearchFilter = "CUSTODYCD|=|" & Me.txtCUSTODYCD.Text.Trim & "|C^ACCTNO|=|" & Me.cboAFACCTNO.SelectedValue & "|C"
            'frmSearch.LoadLastFilter = True

            frmSearch.ShowDialog()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnLNREPORT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLNREPORT.Click
        Try
            Dim frmSearch As New frmSearch(UserLanguage)
            frmSearch.BusDate = Me.BusDate
            frmSearch.TableName = "LN0001"
            frmSearch.ModuleCode = Me.ModuleCode
            frmSearch.AuthCode = "NYNNYYYYNN" 'Chỉ cho phép g?i chức năng tạo giao dịch kế tiếp (Choose)
            frmSearch.CMDTYPE = "V"            
            frmSearch.IsLocalSearch = gc_IsNotLocalMsg
            frmSearch.SearchOnInit = True
            frmSearch.BranchId = Me.BranchId
            frmSearch.TellerId = Me.TellerId
            frmSearch.DefaultSearchFilter = "CUSTODYCD|=|" & Me.txtCUSTODYCD.Text.Trim & "|C^AFACCTNO|=|" & Me.cboAFACCTNO.SelectedValue & "|C"
            'frmSearch.LoadLastFilter = True

            frmSearch.ShowDialog()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub frmBrokerInquiry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnMRCALL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMRCALL.Click
        Dim frmSearch As New frmSearch(UserLanguage)
        frmSearch.BusDate = Me.BusDate
        frmSearch.TableName = "MR0003VIEW"
        frmSearch.ModuleCode = Me.ModuleCode        
        frmSearch.CMDTYPE = "V"
        frmSearch.IsLocalSearch = gc_IsNotLocalMsg
        frmSearch.SearchOnInit = True
        frmSearch.BranchId = Me.BranchId
        frmSearch.TellerId = Me.TellerId
        frmSearch.DefaultSearchFilter = "CUSTODYCD|=|" & Me.txtCUSTODYCD.Text.Trim & "|C^ACCTNO|=|" & Me.cboAFACCTNO.SelectedValue & "|C"
        'frmSearch.LoadLastFilter = True

        frmSearch.ShowDialog()
    End Sub
   
    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        If mv_blnAFLoading <> True Then
            If Not Me.cboAFACCTNO.SelectedValue Is Nothing Then
                LoadAFInfo(Me.cboAFACCTNO.SelectedValue)
            End If
        End If
    End Sub

    Private Sub cboAFACCTNO_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAFACCTNO.SelectedValueChanged
        If mv_blnAFLoading <> True Then
            If Not Me.cboAFACCTNO.SelectedValue Is Nothing Then
                LoadAFInfo(Me.cboAFACCTNO.SelectedValue)
            End If
        End If
    End Sub
End Class
