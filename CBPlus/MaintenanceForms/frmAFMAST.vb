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


Public Class frmAFMAST
#Region " Properties and varialble "
    '---------------------------------------------------------------
    'C? d�ùng để xác định xem TabPage đã được tải thông tin chưa
    Private mv_blnRefreshTabPage_MainInfo As Boolean = False
    Private mv_blnRefreshTabPage_Txmap As Boolean = False
    Private mv_blnRefreshTabPage_Accounts As Boolean = False
    Private mv_blnRefreshTabPage_AFSERule As Boolean = False
    Private mv_blnRefreshTabPage_ODPROBRKMST As Boolean = False


    Public SUBACCOUNTGrid As GridEx
    Public AFTXMAPGrid As GridEx
    Public AFSERULEGrid As GridEx
    Public ODPROBRKMSTGrid As GridEx

    Private mv_strCareBy As String
    Private hAftype As New Hashtable
    Private mv_blnLookup As Boolean = False
    Private m_blnGridCI As Boolean = False
    Private pv_blnSaved As Boolean = False
    Private mv_blnIsLoading As Boolean = True

    Private mv_strBankAcctno As String = ""
    Private mv_strBankCode As String = ""
    Private v_strSender As String = ""
    Private mv_OLAUTOID As String = String.Empty
    Private mv_IsOnlineRegister As Boolean = False
    Private mv_cashinadvanceauto As String = String.Empty
    Private mv_placeorderphone As String = String.Empty
    Private mv_smsphonenumber As String = String.Empty
    Private mv_placeorderonline As String = String.Empty
    Private mv_cashinadvanceonline As String = String.Empty
    Private mv_cashtransferonline As String = String.Empty
    Private mv_additionalsharesonline As String = String.Empty
    Private mv_searchonline As String = String.Empty
    Private mv_bankaccountname1 As String = String.Empty
    Private mv_bankidcode1 As String = String.Empty
    Private mv_bankiddate1 As String = String.Empty
    Private mv_bankidplace1 As String = String.Empty
    Private mv_bankaccountnumber1 As String = String.Empty
    Private mv_bankname1 As String = String.Empty
    Private mv_branch1 As String = String.Empty
    Private mv_bankcity1 As String = String.Empty
    Private mv_bankaccountname2 As String = String.Empty
    Private mv_bankidcode2 As String = String.Empty
    Private mv_bankiddate2 As String = String.Empty
    Private mv_bankidplace2 As String = String.Empty
    Private mv_bankaccountnumber2 As String = String.Empty
    Private mv_bankname2 As String = String.Empty
    Private mv_branch2 As String = String.Empty
    Private mv_bankcity2 As String = String.Empty
    Private mv_bankaccountname3 As String = String.Empty
    Private mv_bankidcode3 As String = String.Empty
    Private mv_bankiddate3 As String = String.Empty
    Private mv_bankidplace3 As String = String.Empty
    Private mv_bankaccountnumber3 As String = String.Empty
    Private mv_bankname3 As String = String.Empty
    Private mv_branch3 As String = String.Empty
    Private mv_bankcity3 As String = String.Empty
    Private mv_IsCreatOtright_CfOtherAcc As Boolean = False
    Public mv_strCustomerStatus As String = String.Empty
    Public MessageData As String
    Private mv_blnAcctEntry As Boolean = False
    Private mv_strIpAddress As String
    Private mv_strWsName As String
    Private mv_strCustID As String
    Private mv_strCustAtCOM As String
    Private mv_strCustodyCD As String
    Private mv_arrObjFldVals() As CFieldVal
    Private mv_strReportDirectory As String
    Private mv_strReportTempDirectory As String
    Private mv_intNumOfParam As Integer
    Private mv_arrRptParam As ReportParameters()
    Private mv_strStoreName As String


    Private mv_strHeadOffice As String          'La Ten cty
    Private mv_strRPTTITLE As String            'Là tiêu đ? c�ủa báo cáo
    Private mv_strBRNAME As String              'Là tên chi nhánh/đại lý
    Private mv_strBranchAddress As String       '?�ịa chỉ chi nhánh/đại lý
    Private mv_strBranchPhoneFax As String      'Thông tin v? s�ố điện thoại, số fax, địa chỉ email,website,....
    Private mv_strTELLER As String              'Là tên ngư?i s�ử dụng
    Private mv_strCreatedDate As String
    Private mv_strCreatedDate_en As String
    Private mv_strBusDate As String
    Private mv_strExportDirectory As String
    Private mv_strRptAsynchrnousFile As String
    Private mv_strISEDIT As String
#End Region

    Public Property ReportDirectory() As String
        Get
            Return mv_strReportDirectory
        End Get
        Set(ByVal Value As String)
            mv_strReportDirectory = Value
        End Set
    End Property

    Public Property ReportTempDirectory() As String
        Get
            Return mv_strReportTempDirectory
        End Get
        Set(ByVal Value As String)
            mv_strReportTempDirectory = Value
        End Set
    End Property

    Public Property CustID() As String
        Get
            Return mv_strCustID
        End Get
        Set(ByVal Value As String)
            mv_strCustID = Value
        End Set
    End Property

    Public Property CustAtCOM() As String
        Get
            Return mv_strCustAtCOM
        End Get
        Set(ByVal Value As String)
            mv_strCustAtCOM = Value
        End Set
    End Property

    Public Property CustodyCD() As String
        Get
            Return mv_strCustodyCD
        End Get
        Set(ByVal Value As String)
            mv_strCustodyCD = Value
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
    Public Property CareBy() As String
        Get
            Return mv_strCareBy
        End Get
        Set(ByVal value As String)
            mv_strCareBy = value
        End Set
    End Property

    Public Property ReportTitle() As String
        Get
            Return mv_strRPTTITLE
        End Get
        Set(ByVal Value As String)
            mv_strRPTTITLE = Value
        End Set
    End Property

    Public Property HeadOffice() As String
        Get
            Return mv_strHeadOffice
        End Get
        Set(ByVal Value As String)
            mv_strHeadOffice = Value
        End Set
    End Property

    Public Property BranchName() As String
        Get
            Return mv_strBRNAME
        End Get
        Set(ByVal Value As String)
            mv_strBRNAME = Value
        End Set
    End Property

    Public Property Teller() As String
        Get
            Return mv_strTELLER
        End Get
        Set(ByVal Value As String)
            mv_strTELLER = Value
        End Set
    End Property


    Public Property BranchAddress() As String
        Get
            Return mv_strBranchAddress
        End Get
        Set(ByVal Value As String)
            mv_strBranchAddress = Value
        End Set
    End Property

    Public Property BranchPhoneFax() As String
        Get
            Return mv_strBranchPhoneFax
        End Get
        Set(ByVal Value As String)
            mv_strBranchPhoneFax = Value
        End Set
    End Property

    Public Property CreatedDate() As String
        Get
            Return mv_strCreatedDate
        End Get
        Set(ByVal Value As String)
            mv_strCreatedDate = Value
        End Set
    End Property
    Public Property CreatedDate_En() As String
        Get
            Return mv_strCreatedDate_en
        End Get
        Set(ByVal Value As String)
            mv_strCreatedDate_en = Value
        End Set
    End Property

    Public Property ExportDirectory() As String
        Get
            Return mv_strExportDirectory
        End Get
        Set(ByVal Value As String)
            mv_strExportDirectory = Value
        End Set
    End Property
    Public Property ReportAsychronous() As String
        Get
            Return mv_strRptAsynchrnousFile
        End Get
        Set(ByVal Value As String)
            mv_strRptAsynchrnousFile = Value
        End Set
    End Property
    'DieuNDA 28/12/2016 Revert phan cua Vu
    'Public Property ISEDIT() As String
    '    Get
    '        Return mv_strISEDIT
    '    End Get
    '    Set(ByVal Value As String)
    '        mv_strISEDIT = Value
    '    End Set
    'End Property
    'End DieuNDA 28/12/2016 Revert phan cua Vu


    Public Overrides Sub OnInit()
        Dim v_strCmdSQL, v_strObjMsg, v_strFLDNAME, v_strVALUE, v_strMARGINTYPE, v_strCOREBANK, v_strACTYPE, v_strISTRFBUY, v_strAUTOADV As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList

        If ExeFlag = ExecuteFlag.AddNew Then
            'Them dieu kien khong cho mo moi tai khoan corebank. Chi mo moi tai khoan cong ty co phu ngan hang
            'v_strCmdSQL = "SELECT  CDVAL VALUECD, CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY FROM ALLCODE WHERE CDTYPE = 'SY' AND CDNAME = 'YESNO' AND CDVAL ='N' ORDER BY LSTODR DESC"
            v_strCmdSQL = "SELECT  CDVAL VALUECD, CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY FROM ALLCODE WHERE CDTYPE = 'SY' AND CDNAME = 'YESNO'  ORDER BY LSTODR DESC"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            Me.cboCOREBANK.Clears()
            FillComboEx(v_strObjMsg, Me.cboCOREBANK, "", Me.UserLanguage)
            
        Else
            v_strCmdSQL = "SELECT  CDVAL VALUECD, CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY FROM ALLCODE WHERE CDTYPE = 'SY' AND CDNAME = 'YESNO' ORDER BY LSTODR DESC"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            Me.cboCOREBANK.Clears()
            FillComboEx(v_strObjMsg, Me.cboCOREBANK, "", Me.UserLanguage)
        End If

        'Lay thong tin của ACTYPE hien tai. -> MARGINTYPE va COREBANK.
        If ExeFlag <> ExecuteFlag.AddNew Then
            v_strCmdSQL = "select AF.AUTOADV, AF.COREBANK " & ControlChars.CrLf _
                        & "from afmast af " & ControlChars.CrLf _
                        & "where af.acctno = '" & KeyFieldValue & "' "
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)


            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            'Lay thong tin ve loai hinh
            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(j).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strFLDNAME = v_nodeList.Item(i).ChildNodes(j).Attributes.GetNamedItem("fldname").Value.Trim()
                        v_strVALUE = v_nodeList.Item(i).ChildNodes(j).Attributes.GetNamedItem("oldval").Value.Trim()
                        Select Case v_strFLDNAME
                            Case "MARGINTYPE"
                                v_strMARGINTYPE = v_strVALUE
                            Case "COREBANK"
                                v_strCOREBANK = v_strVALUE
                            Case "ACTYPE"
                                v_strACTYPE = v_strVALUE
                            Case "ISTRFBUY"
                                v_strISTRFBUY = v_strVALUE
                            Case "AUTOADV"
                                v_strAUTOADV = v_strVALUE
                        End Select
                    End With
                Next
            Next
            Me.cboCOREBANK.SelectedValue = v_strCOREBANK
        End If

        MyBase.OnInit()
        txtCUSTID.Text = Me.CustID



        mv_blnIsLoading = False
        If ExeFlag <> ExecuteFlag.AddNew Then
            cboCOREBANK.SelectedValue = v_strCOREBANK
        End If
        'LoadACTYPEDetail()
        mv_blnIsLoading = True

        ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & Me.Name & "-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())

        Me.cboLink.Visible = False
        Me.TabControlHide.TabPages.Add(tpHiddenTab)
        Me.tbcAFMAST.TabPages.Remove(tpHiddenTab)



        If Not FillGroupCareBy() Then
            If ExeFlag = ExecuteFlag.AddNew Then
                MsgBox(ResourceManager.GetString("NotCareByGroup"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                OnClose()
                Exit Sub
            ElseIf ExeFlag = ExecuteFlag.Edit Then
                MsgBox(ResourceManager.GetString("NotCareBy"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                OnClose()
                Exit Sub
            End If
        End If

        If ExeFlag = ExecuteFlag.AddNew Then
            If TellerId <> ADMIN_ID Then
                If Not GroupCareBy Is Nothing Then
                    If Trim(GroupCareBy) = String.Empty Then
                        MsgBox(ResourceManager.GetString("NotCareByGroup"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        OnClose()
                        Exit Sub
                    End If
                End If
            End If
            Me.dtpOPNDATE.Value = CDate(Me.BusDate)
            Me.cboBRID.SelectedValue = Me.BranchId

        End If
        LoadUserInterface(Me)
        LoadUserInterface(Me.tbcAFMAST)
        LoadUserInterface(Me.grbAFMAST)
        LoadUserInterface(Me.spcAFTXMAP.Panel1)
        If ExeFlag = ExecuteFlag.AddNew Then
            'DieuNDA 28/12/2016: Revert phan cua Vu
            'If mv_strISEDIT = "N" Then
            '    txtACCTNO.Enabled = False
            'End If
            'End 'DieuNDA 28/12/2016: Revert phan cua Vu
            '21/05/2018 DieuNDA: Tu gen so tieu khoan va khong cho phep sua
            Me.txtACCTNO.Text = getContract(Me.BranchId)
            Me.txtACCTNO.Enabled = False
            Me.txtBANKNAME.Enabled = False
            'End 21/05/2018 DieuNDA
        ElseIf ExeFlag = ExecuteFlag.View OrElse ExeFlag = ExecuteFlag.Approve Then
            txtACCTNO.Enabled = False
            btnGenCheckAFACCTNO.Enabled = False
            Me.txtBANKNAME.Enabled = False
            btnAFTXMAP_ADD.Enabled = False
            btnAFTXMAP_DELETE.Enabled = False
            btnAFTXMAP_EDIT.Enabled = False
            'btnAFTXMAP_VIEW.Enabled = False

            btnGenCheckAFACCTNO.Enabled = False

        ElseIf ExeFlag = ExecuteFlag.Edit Then
            txtACCTNO.Enabled = False
            btnGenCheckAFACCTNO.Enabled = False
            Me.txtBANKNAME.Enabled = False
            btnAFTXMAP_ADD.Enabled = True
            btnAFTXMAP_DELETE.Enabled = True
            btnAFTXMAP_EDIT.Enabled = True
            btnAFTXMAP_VIEW.Enabled = True

            'txtMRCRLIMITMAX.Enabled = False
        End If
        InitExternal()
        mv_blnIsLoading = False
        'Me.dtpOPNDATE.Value = CDate(Me.BusDate)

        Try
            If ExeFlag = ExecuteFlag.AddNew Then
                cboCAREBY.SelectedValue = CareBy
            End If
        Catch ex As Exception
            cboCAREBY.SelectedIndex = 1
        End Try

        If ExeFlag = ExecuteFlag.Edit Then
            'Khi edit neu la tai khoan corebank thi cho phep thay doi thanh tai khoan cong ty
            'Nguoc lai khong cho phep doi tu tai khoan cong ty sang tai khoan corebank
            If Me.cboCOREBANK.SelectedValue = "N" Then
                Me.cboCOREBANK.Enabled = False
            End If
        End If
        'longnh 2014-11-10 _phs_p1_cf0020
        If cboCOREBANK.SelectedValue = "Y" Then
            cboBANKNAME.Enabled = True

            'txtBANKACCTNO.Enabled = True

        Else
            cboBANKNAME.Enabled = False
            'cboBANKNAME.SelectedValue = "---"
            'txtBANKACCTNO.Enabled = False
            'txtBANKACCTNO.Text = ""
        End If

    End Sub


    Overrides Sub LoadUserInterface(ByRef pv_ctrl As Windows.Forms.Control)
        MyBase.LoadUserInterface(pv_ctrl)

        Dim v_strCmdSQL, v_strObjMsg As String
        Dim v_intIndex As Integer
        Dim v_ws As New BDSDeliveryManagement       

        If (ExeFlag = ExecuteFlag.AddNew) Then
            Me.cboLink.Enabled = False
            Me.txtACCTNO.Text = Me.BranchId

        ElseIf ExeFlag = ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve Then
            If TellerId <> ADMIN_ID Then
                If ExeFlag = ExecuteFlag.View Or ExeFlag = ExecuteFlag.Approve Then
                    Dim v_strCareBy, v_arrGroupCareBy(), v_arrGroup(), v_strGroupId As String
                    If Trim(GroupCareBy) <> String.Empty Then
                        v_arrGroupCareBy = GroupCareBy.Split("#")
                        If v_arrGroupCareBy.Length > 1 Then
                            Dim v_blnOK As Boolean = False
                            For i As Integer = 0 To v_arrGroupCareBy.Length - 2
                                v_arrGroup = CStr(v_arrGroupCareBy(i)).Split("|")
                                v_strGroupId = v_arrGroup(0)
                                If Trim(mv_strCareBy) <> Trim(v_strGroupId) Then
                                    v_blnOK = False
                                Else
                                    v_blnOK = True
                                    Exit For
                                End If
                            Next
                        End If
                    End If
                End If
            End If

            cboTERMOFUSE.Enabled = False      
        ElseIf ExeFlag = ExecuteFlag.Edit Then
            Me.cboISOTC.Enabled = False
            If Me.cboSTATUS.SelectedValue = "R" Then
                Me.btnOK.Enabled = False
                Me.btnApply.Enabled = False
            End If
        End If

        'LoadBankScreen()
        LoadAUTOTRF()
    End Sub

    Private Sub InitExternal()
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            'Khoi tao cho grid txmap
            AFTXMAPGrid = New GridEx
            Dim v_cmrTxmapHeader As New Xceed.Grid.ColumnManagerRow
            v_cmrTxmapHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            v_cmrTxmapHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            AFTXMAPGrid.FixedHeaderRows.Add(v_cmrTxmapHeader)
            AFTXMAPGrid.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(Integer)))
            AFTXMAPGrid.Columns.Add(New Xceed.Grid.Column("AFACCTNO", GetType(System.String)))
            AFTXMAPGrid.Columns.Add(New Xceed.Grid.Column("TLTXCD", GetType(System.String)))
            AFTXMAPGrid.Columns.Add(New Xceed.Grid.Column("TXDESC", GetType(System.String)))
            AFTXMAPGrid.Columns.Add(New Xceed.Grid.Column("EFFDATE", GetType(System.String)))
            AFTXMAPGrid.Columns.Add(New Xceed.Grid.Column("EXPDATE", GetType(System.String)))
            AFTXMAPGrid.Columns.Add(New Xceed.Grid.Column("TLID", GetType(System.String)))
            AFTXMAPGrid.Columns.Add(New Xceed.Grid.Column("ACTYPE", GetType(System.String)))
            AFTXMAPGrid.Columns.Add(New Xceed.Grid.Column("TYPENAME", GetType(System.String)))

            AFTXMAPGrid.Columns("AUTOID").Title = ResourceManager.GetString("AFTXMAPGrid.AUTOID")
            AFTXMAPGrid.Columns("AFACCTNO").Title = ResourceManager.GetString("AFTXMAPGrid.AFACCTNO")
            AFTXMAPGrid.Columns("TLTXCD").Title = ResourceManager.GetString("AFTXMAPGrid.TLTXCD")
            AFTXMAPGrid.Columns("TXDESC").Title = ResourceManager.GetString("AFTXMAPGrid.TXDESC")
            AFTXMAPGrid.Columns("EFFDATE").Title = ResourceManager.GetString("AFTXMAPGrid.EFFDATE")
            AFTXMAPGrid.Columns("EXPDATE").Title = ResourceManager.GetString("AFTXMAPGrid.EXPDATE")
            AFTXMAPGrid.Columns("TLID").Title = ResourceManager.GetString("AFTXMAPGrid.TLID")
            AFTXMAPGrid.Columns("ACTYPE").Title = ResourceManager.GetString("AFTXMAPGrid.ACTYPE")
            AFTXMAPGrid.Columns("TYPENAME").Title = ResourceManager.GetString("AFTXMAPGrid.TYPENAME")

            AFTXMAPGrid.Columns("AUTOID").Width = 0
            AFTXMAPGrid.Columns("TXDESC").Width = 250
            AFTXMAPGrid.Columns("TLTXCD").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            AFTXMAPGrid.Columns("AFACCTNO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            AFTXMAPGrid.Columns("TXDESC").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            AFTXMAPGrid.Columns("EFFDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            AFTXMAPGrid.Columns("EXPDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            AFTXMAPGrid.Columns("TLID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            AFTXMAPGrid.Columns("ACTYPE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            AFTXMAPGrid.Columns("TYPENAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left

            Me.spcAFTXMAP.Panel2.Controls.Clear()
            Me.spcAFTXMAP.Panel2.Controls.Add(AFTXMAPGrid)
            AFTXMAPGrid.Dock = Windows.Forms.DockStyle.Fill

            'Khoi tao cho grid ODPROBRKMST
            ODPROBRKMSTGrid = New GridEx
            Dim v_cmrODPROBRKMSTHeader As New Xceed.Grid.ColumnManagerRow
            v_cmrODPROBRKMSTHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            v_cmrODPROBRKMSTHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            ODPROBRKMSTGrid.FixedHeaderRows.Add(v_cmrODPROBRKMSTHeader)
            ODPROBRKMSTGrid.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(Integer)))
            ODPROBRKMSTGrid.Columns.Add(New Xceed.Grid.Column("FULLNAME", GetType(System.String)))
            ODPROBRKMSTGrid.Columns.Add(New Xceed.Grid.Column("PROBRKMSTTYPE", GetType(System.String)))
            ODPROBRKMSTGrid.Columns.Add(New Xceed.Grid.Column("LOANTYPE", GetType(System.String)))
            ODPROBRKMSTGrid.Columns.Add(New Xceed.Grid.Column("FEERATE", GetType(System.String)))
            ODPROBRKMSTGrid.Columns.Add(New Xceed.Grid.Column("MINAMT", GetType(System.String)))
            ODPROBRKMSTGrid.Columns.Add(New Xceed.Grid.Column("MAXAMT", GetType(System.String)))
            ODPROBRKMSTGrid.Columns.Add(New Xceed.Grid.Column("VALDATE", GetType(System.String)))
            ODPROBRKMSTGrid.Columns.Add(New Xceed.Grid.Column("EXPDATE", GetType(System.String)))
            ODPROBRKMSTGrid.Columns.Add(New Xceed.Grid.Column("STATUS", GetType(System.String)))

            ODPROBRKMSTGrid.Columns("AUTOID").Title = ResourceManager.GetString("ODPROBRKMSTGrid.AUTOID")
            ODPROBRKMSTGrid.Columns("FULLNAME").Title = ResourceManager.GetString("ODPROBRKMSTGrid.FULLNAME")
            ODPROBRKMSTGrid.Columns("PROBRKMSTTYPE").Title = ResourceManager.GetString("ODPROBRKMSTGrid.PROBRKMSTTYPE")
            ODPROBRKMSTGrid.Columns("LOANTYPE").Title = ResourceManager.GetString("ODPROBRKMSTGrid.LOANTYPE")
            ODPROBRKMSTGrid.Columns("FEERATE").Title = ResourceManager.GetString("ODPROBRKMSTGrid.FEERATE")
            ODPROBRKMSTGrid.Columns("MINAMT").Title = ResourceManager.GetString("ODPROBRKMSTGrid.MINAMT")
            ODPROBRKMSTGrid.Columns("MAXAMT").Title = ResourceManager.GetString("ODPROBRKMSTGrid.MAXAMT")
            ODPROBRKMSTGrid.Columns("VALDATE").Title = ResourceManager.GetString("ODPROBRKMSTGrid.VALDATE")
            ODPROBRKMSTGrid.Columns("EXPDATE").Title = ResourceManager.GetString("ODPROBRKMSTGrid.EXPDATE")
            ODPROBRKMSTGrid.Columns("STATUS").Title = ResourceManager.GetString("ODPROBRKMSTGrid.STATUS")

            ODPROBRKMSTGrid.Columns("AUTOID").Width = 0
            ODPROBRKMSTGrid.Columns("PROBRKMSTTYPE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            ODPROBRKMSTGrid.Columns("LOANTYPE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            ODPROBRKMSTGrid.Columns("FULLNAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            ODPROBRKMSTGrid.Columns("FEERATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            ODPROBRKMSTGrid.Columns("MINAMT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            ODPROBRKMSTGrid.Columns("MAXAMT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            ODPROBRKMSTGrid.Columns("VALDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            ODPROBRKMSTGrid.Columns("EXPDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            ODPROBRKMSTGrid.Columns("STATUS").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left

            SUBACCOUNTGrid = New GridEx
            Dim v_cmrAccountsHeader As New Xceed.Grid.ColumnManagerRow
            v_cmrAccountsHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            v_cmrAccountsHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            SUBACCOUNTGrid.FixedHeaderRows.Add(v_cmrAccountsHeader)

            SUBACCOUNTGrid.Columns.Add(New Xceed.Grid.Column("ACCTNO", GetType(System.String)))
            SUBACCOUNTGrid.Columns.Add(New Xceed.Grid.Column("MODCODE", GetType(System.String)))
            SUBACCOUNTGrid.Columns.Add(New Xceed.Grid.Column("SYMBOL", GetType(System.String)))
            SUBACCOUNTGrid.Columns.Add(New Xceed.Grid.Column("AVLBAL", GetType(System.Double)))
            SUBACCOUNTGrid.Columns("AVLBAL").FormatSpecifier = "#,##0"


            SUBACCOUNTGrid.Columns("ACCTNO").Title = ResourceManager.GetString("SUBACCOUNTGrid.ACCTNO")
            SUBACCOUNTGrid.Columns("MODCODE").Title = ResourceManager.GetString("SUBACCOUNTGrid.MODCODE")
            SUBACCOUNTGrid.Columns("SYMBOL").Title = ResourceManager.GetString("SUBACCOUNTGrid.SYMBOL")
            SUBACCOUNTGrid.Columns("AVLBAL").Title = ResourceManager.GetString("SUBACCOUNTGrid.AVLBAL")


            pnSUBSCCOUNT.Controls.Clear()
            pnSUBSCCOUNT.Controls.Add(SUBACCOUNTGrid)
            SUBACCOUNTGrid.Dock = Windows.Forms.DockStyle.Fill


            AFSERuleGrid = New GridEx

            Dim v_cmrAFSERuleHeader As New Xceed.Grid.ColumnManagerRow
            v_cmrAFSERuleHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            v_cmrAFSERuleHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            AFSERuleGrid.FixedHeaderRows.Add(v_cmrAFSERuleHeader)
            AFSERuleGrid.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(Integer)))
            AFSERuleGrid.Columns.Add(New Xceed.Grid.Column("TYPORMST", GetType(System.String)))
            AFSERuleGrid.Columns.Add(New Xceed.Grid.Column("TYPORMSTCD", GetType(System.String)))
            AFSERuleGrid.Columns.Add(New Xceed.Grid.Column("REFID", GetType(System.String)))
            AFSERuleGrid.Columns.Add(New Xceed.Grid.Column("CODEID", GetType(System.String)))
            AFSERuleGrid.Columns.Add(New Xceed.Grid.Column("POLICYCD", GetType(System.String)))
            AFSERuleGrid.Columns.Add(New Xceed.Grid.Column("BORS", GetType(System.String)))
            AFSERuleGrid.Columns.Add(New Xceed.Grid.Column("EFFDATE", GetType(System.String)))
            AFSERuleGrid.Columns.Add(New Xceed.Grid.Column("EXPDATE", GetType(System.String)))

            AFSERuleGrid.Columns("AUTOID").Title = ResourceManager.GetString("AFSERULEGrid.AUTOID")
            AFSERuleGrid.Columns("TYPORMST").Title = ResourceManager.GetString("AFSERULEGrid.TYPORMST")
            AFSERuleGrid.Columns("REFID").Title = ResourceManager.GetString("AFSERULEGrid.REFID")
            AFSERuleGrid.Columns("CODEID").Title = ResourceManager.GetString("AFSERULEGrid.CODEID")
            AFSERuleGrid.Columns("POLICYCD").Title = ResourceManager.GetString("AFSERULEGrid.FOA")
            AFSERuleGrid.Columns("BORS").Title = ResourceManager.GetString("AFSERULEGrid.BORS")
            AFSERuleGrid.Columns("EFFDATE").Title = ResourceManager.GetString("AFSERULEGrid.EFFDATE")
            AFSERuleGrid.Columns("EXPDATE").Title = ResourceManager.GetString("AFSERULEGrid.EXPDATE")

            AFSERuleGrid.Columns("AUTOID").Width = 0
            AFSERuleGrid.Columns("TYPORMSTCD").Visible = False
            AFSERuleGrid.Columns("AUTOID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
            AFSERuleGrid.Columns("TYPORMST").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            AFSERuleGrid.Columns("REFID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            AFSERuleGrid.Columns("CODEID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            AFSERuleGrid.Columns("POLICYCD").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            AFSERuleGrid.Columns("BORS").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
            AFSERuleGrid.Columns("EFFDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
            AFSERuleGrid.Columns("EXPDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center

        Catch ex As Exception
            Throw ex
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Sub


    Private Function FillGroupCareBy() As Boolean
        Try
            Dim v_strGroupId, v_strGroupName, v_arrGroupCareBy(), v_arrGroup() As String
            Dim v_strCareBy As String
            Dim v_strCareByText As String = ""
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery

            If Trim(GroupCareBy) <> String.Empty Then
                v_arrGroupCareBy = GroupCareBy.Split("#")
                If (ExeFlag = ExecuteFlag.AddNew) Then
                    cboCAREBY.Clears()
                    If v_arrGroupCareBy.Length > 1 Then
                        For i As Integer = 0 To v_arrGroupCareBy.Length - 2
                            v_arrGroup = CStr(v_arrGroupCareBy(i)).Split("|")
                            v_strGroupId = v_arrGroup(0)
                            v_strGroupName = v_arrGroup(1)
                            cboCAREBY.AddItems(v_strGroupName, v_strGroupId)
                        Next
                    End If
                ElseIf (ExeFlag = ExecuteFlag.View) Then
                    If (Not cboCAREBY.SelectedValue Is Nothing) And (Not cboCAREBY.SelectedValue Is DBNull.Value) Then
                        v_strCareBy = CStr(cboCAREBY.SelectedValue).Trim
                    End If
                    cboCAREBY.Enabled = False

                ElseIf (ExeFlag = ExecuteFlag.Edit) Then
                    If (Not cboCAREBY.SelectedValue Is Nothing) And (Not cboCAREBY.SelectedValue Is DBNull.Value) Then
                        v_strCareBy = CStr(cboCAREBY.SelectedValue).Trim
                        v_strCareByText = CStr(cboCAREBY.Text).Trim
                    End If
                    cboCAREBY.Clears()
                    cboCAREBY.Enabled = True
                    If v_arrGroupCareBy.Length > 1 Then

                        Dim v_blnOk As Boolean = False
                        For i As Integer = 0 To v_arrGroupCareBy.Length - 2
                            v_arrGroup = CStr(v_arrGroupCareBy(i)).Split("|")
                            v_strGroupId = v_arrGroup(0)
                            v_strGroupName = v_arrGroup(1)
                            cboCAREBY.AddItems(v_strGroupName, v_strGroupId)
                            If Trim(v_strCareBy) = Trim(v_strGroupId) Then
                                v_blnOk = True
                            End If
                        Next
                        If v_blnOk Then
                            cboCAREBY.SelectedValue = v_strCareBy
                            Return True
                        Else
                            'User khong co quyen careby - disable combo
                            cboCAREBY.AddItems(v_strCareByText, v_strCareBy)
                            cboCAREBY.SelectedValue = v_strCareBy
                            cboCAREBY.Enabled = False
                            Return True
                        End If
                    Else
                        Return False
                    End If
                End If
                Return True
            Else
                If (ExeFlag = ExecuteFlag.AddNew) Then
                    Return False
                ElseIf (ExeFlag = ExecuteFlag.View) Then
                    If (Not cboCAREBY.SelectedValue Is Nothing) And (Not cboCAREBY.SelectedValue Is DBNull.Value) Then
                        v_strCareBy = CStr(cboCAREBY.SelectedValue).Trim
                    End If
                    cboCAREBY.Enabled = False
                    Return True
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub btnApprv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprv.Click
        v_strSender = "btnApprv"
        Dim v_frm As New frmApprove
        v_frm.ExeFlag = ExeFlag
        v_frm.UserLanguage = UserLanguage
        v_frm.ModuleCode = ModuleCode
        v_frm.ObjectName = ObjectName
        v_frm.TableName = Mid(ObjectName, 4)
        v_frm.LocalObject = LocalObject
        v_frm.Text = Text
        v_frm.TellerId = TellerId
        v_frm.TellerRight = TellerRight
        v_frm.GroupCareBy = GroupCareBy
        v_frm.AuthString = AuthString
        v_frm.BranchId = BranchId
        v_frm.BusDate = Me.BusDate
        v_frm.KeyFieldName = KeyFieldName
        v_frm.KeyFieldType = KeyFieldType
        v_frm.KeyFieldValue = KeyFieldValue

        v_frm.LinkValue = LinkValue
        v_frm.LinkField = LinkField
        v_frm.ShowDialog()
        Me.DialogResult = DialogResult.OK
        MyBase.OnClose()
        v_strSender = String.Empty
    End Sub


    Private Sub LoadAFTXMAP(ByVal pv_strACCTNO As String, ByVal pv_strACTYPE As String)
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            If Not AFTXMAPGrid Is Nothing And Len(pv_strACCTNO) > 0 Then
                'Clear data
                AFTXMAPGrid.DataRows.Clear()

                Dim v_strSQL As String = "Select af.AFACCTNO, af.autoid,af.tltxcd, tx.txdesc, effdate, expdate, tlname tlid, af.actype, null typename " _
                & " from aftxmap af, tltx tx, tlprofiles tl where af.tltxcd= tx.tltxcd and af.deltd='N' " _
                & " and af.tlid= tl.tlid AND TRIM(AF.AFACCTNO)='" & pv_strACCTNO & "' " _
                & " UNION ALL " _
                & " Select af.AFACCTNO, af.autoid,af.tltxcd, tx.txdesc, effdate, expdate, tlname tlid, af.actype, typ.typename " _
                & " from aftxmap af, tltx tx, tlprofiles tl, aftype typ where af.tltxcd= tx.tltxcd and af.deltd='N' " _
                & " and af.tlid= tl.tlid AND af.actype = typ.actype AND TRIM(UPPER(AF.AFACCTNO))='ALL' AND af.actype ='" & pv_strACTYPE & "' AND EXPDATE>to_date('" & Me.BusDate & "','DD/MM/RRRR')"

                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "CF.AFTXMAP", _
                    gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                FillDataGrid(AFTXMAPGrid, v_strObjMsg, "")
                mv_blnRefreshTabPage_Txmap = True
            End If
        Catch ex As Exception
            Throw ex
        Finally
            v_ws = Nothing
        End Try
    End Sub
    Public Sub showFormAFTXMAP(ByVal pv_intExecFlag As Integer)
        Dim v_frm As New frmAFTXMAP
        Try
            Dim v_strAFACCTNO As String
            v_strAFACCTNO = Me.txtACCTNO.Text.Trim
            v_frm.ExeFlag = pv_intExecFlag
            v_frm.UserLanguage = UserLanguage
            v_frm.BranchId = BranchId
            v_frm.TellerId = TellerId
            v_frm.ModuleCode = ModuleCode
            v_frm.ObjectName = "CF.AFTXMAP"
            v_frm.TableName = "AFTXMAP"
            v_frm.LocalObject = "N"
            v_frm.BusDate = Me.BusDate
            v_frm.Text = String.Empty
            v_frm.acctno = v_strAFACCTNO
            v_frm.custodycd = Me.CustodyCD
            'AnhVT Added - Maintenance Retroed
            v_frm.ParentObjName = Me.ObjectName
            v_frm.ParentClause = KeyFieldName & " = '" & txtACCTNO.Text & "'"
            v_frm.TellerId = TellerId
            'AnhVT Ended
            If Not (AFTXMAPGrid.CurrentRow Is Nothing) Then
                If Not (pv_intExecFlag = ExecuteFlag.AddNew) Then
                    v_frm.KeyFieldName = "AUTOID"
                    v_frm.KeyFieldType = "N"
                    v_frm.KeyFieldValue = Trim(CType(AFTXMAPGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
                End If
                If (pv_intExecFlag = ExecuteFlag.View) Then
                    v_frm.ExeFlag = ExecuteFlag.View
                ElseIf (pv_intExecFlag = ExecuteFlag.Edit) Then
                    If Trim(CType(AFTXMAPGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AFACCTNO").Value) = "ALL" Then
                        MsgBox(ResourceManager.GetString("AUTHNOTALLOW"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        Exit Sub
                    End If
                    v_frm.ExeFlag = ExecuteFlag.Edit
                ElseIf (pv_intExecFlag = ExecuteFlag.Delete) Then
                    v_frm.ExeFlag = ExecuteFlag.Delete
                End If
                v_frm.ShowDialog()

            Else
                If (pv_intExecFlag = ExecuteFlag.AddNew) Then
                    v_frm.ExeFlag = ExecuteFlag.AddNew
                    v_frm.ShowDialog()
                End If
            End If
            If (pv_intExecFlag <> ExecuteFlag.View) Then
                LoadAFTXMAP(v_strAFACCTNO, "")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_frm = Nothing
        End Try
    End Sub

    Public Overrides Function DoDataExchange(Optional ByVal pv_blnSaved As Boolean = False) As Boolean
        Try
            If Not ControlValidation(pv_blnSaved) Then
                Return False
            End If
            Return MyBase.DoDataExchange(pv_blnSaved)
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function


    Public Overrides Sub OnSave()
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCustAtCom As String
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strClause As String
            Dim v_strErrorSource, v_strErrorMessage As String
            Dim v_lngErrorCode As Long
            Dim v_strObjMsg, v_strSQL, v_strFLDNAME, v_strVALUE, v_strNUM As String
            v_strNUM = "0"
            Dim v_strCUSTID, v_strCCUSTID As String
            Dim v_int, v_intCount As Integer
            v_strCUSTID = Me.CustID
            Select Case ExeFlag
                Case ExecuteFlag.Edit
                    If Me.cboSTATUS.SelectedValue = "E" Then
                        Me.cboSTATUS.SelectedValue = "P"
                    End If
                Case ExecuteFlag.AddNew
                    preSaveCheck()
            End Select
            Cursor.Current = Cursors.WaitCursor
            MyBase.OnSave()

            'Kiem tra du lieu
            If Not DoDataExchange(True) Then
                Exit Sub
            End If

            'CF0009 PHS-P1 LONGNH: -	Đối với khách hàng có cờ Cho phép margin = No thì khi mở tiểu khoản chọn loại hình sản phẩm có trả chậm thì cảnh báo nhưng vẫn cho phép tạo.
            'v_strSQL = "select count (1) AUTOID from (" _
            '        & " SELECT custid AUTOID FROM CFMAST CF WHERE  CF.MARGINALLOW <> 'Y' AND CF.CUSTID = '" & v_strCUSTID & "'" _
            '        & " union all" _
            '        & " SELECT actype AUTOID FROM aftype aft WHERE  ISTRFBUY = 'Y' AND actype = '" & cboACTYPE.SelectedValue & "' )"
            'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "CF.AUTOID", _
            '    gc_ActionInquiry, v_strSQL)
            'v_ws.Message(v_strObjMsg)
            'v_xmlDocument.LoadXml(v_strObjMsg)
            'v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            'For v_intCount = 0 To v_nodeList.Count - 1
            '    For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
            '        With v_nodeList.Item(v_intCount).ChildNodes(v_int)
            '            v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
            '            v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()

            '            Select Case v_strFLDNAME
            '                Case "AUTOID"
            '                    v_strCCUSTID = v_strVALUE


            '            End Select
            '        End With
            '    Next
            'Next
            'If v_strCCUSTID = 2 Then
            '    If MsgBox(ResourceManager.GetString("ACCEPTISTRFBUY"), MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) <> MsgBoxResult.Yes Then
            '        Exit Sub
            '    End If
            'End If

            Select Case ExeFlag
                Case ExecuteFlag.AddNew
                    'LONGNH 2014-11-10 PHS_P1_CF0020
                    'If Me.cboCOREBANK.SelectedValue = "Y" Then
                    '    MsgBox(ResourceManager.GetString("frmAFMAST.ADD_COREBANK_NOTALLOW"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    '    Exit Sub
                    'End If
                    v_strClause = KeyFieldName & " = '" & txtACCTNO.Text & "'"
                    v_strObjMsg = BuildXMLObjMsg(Me.BusDate, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdd, , v_strClause, , gc_AutoIdUnused, , , , , , Me.ParentObjName, Me.ParentClause)
                    BuildXMLObjData(mv_dsInput, v_strObjMsg)
                    v_lngErrorCode = v_ws.Message(v_strObjMsg)

                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Sub
                    End If
                    MsgBox(ResourceManager.GetString("AddnewSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)

                    Select Case MyBase.SaveButtonType
                        Case SaveButtonType.ApplyButton
                            KeyFieldValue = GetControlValueByName(KeyFieldName, Me)
                            'HaiLT bo doan nay vi khi them moi chua thuc su insert vao db nen neu chuyen sang mode EDIT se gay loi khi an Chap nhan lan nua
                            'ExeFlag = ExecuteFlag.Edit
                            LoadUserInterface(Me)
                            mv_dsOldInput = mv_dsInput
                        Case SaveButtonType.OKButton
                            Me.DialogResult = DialogResult.OK
                            MyBase.OnClose()
                    End Select
                Case ExecuteFlag.Edit
                    Select Case KeyFieldType
                        Case "C"
                            v_strClause = KeyFieldName & " = '" & KeyFieldValue & "'"
                        Case "D"
                            v_strClause = KeyFieldName & " = TO_DATE('" & KeyFieldValue & "', '" & gc_FORMAT_DATE & "')"
                        Case "N"
                            v_strClause = KeyFieldName & " = " & KeyFieldValue.ToString()
                    End Select

                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionEdit, , v_strClause, , , , , , , , Me.ParentObjName, Me.ParentClause)
                    BuildXMLObjData(mv_dsInput, v_strObjMsg, mv_dsOldInput, ExecuteFlag.Edit)
                    v_lngErrorCode = v_ws.Message(v_strObjMsg)
                    'Update truong CUSTODYCD vao CFMAST
                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Sub
                    End If

                    MsgBox(ResourceManager.GetString("EditSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Select Case MyBase.SaveButtonType
                        Case SaveButtonType.ApplyButton
                            KeyFieldValue = GetControlValueByName(KeyFieldName, Me)
                            ExeFlag = ExecuteFlag.Edit
                            LoadUserInterface(Me)
                        Case SaveButtonType.OKButton
                            Me.DialogResult = DialogResult.OK
                            MyBase.OnClose()
                    End Select
            End Select

            'Update mouse pointer
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("SavingFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Sub

    Private Function preSaveCheck()
        Dim v_ws
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strSQL As String
        Dim v_dblMRCRLIMITMAX As Double
        If cboCOREBANK.SelectedValue.ToString() = "Y" Then
            If txtBANKACCTNO.Text.Trim().Length <= 0 Then
                MsgBox(ResourceManager.GetString("BankAcctNoCannotNull"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Return -1
            End If

            If txtBANKACCTNO.Text.Trim().ToUpper() <> mv_strBankAcctno Or cboBANKNAME.SelectedValue.ToString().Trim.ToUpper() <> mv_strBankCode Then
                Dim v_strObjMsg As String = BuildXMLObjMsg(Me.BusDate, BranchId, , TellerId, gc_IsNotLocalMsg, _
                                                           gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionAdhoc, , _
                                                           Me.txtCUSTID.Text, "CheckBankAcctAuthorize", , , _
                                                           Me.CustodyCD & "|" & _
                                                           Me.txtBANKACCTNO.Text.Trim() & "|" & _
                                                           Me.cboBANKNAME.SelectedValue.ToString().Trim())
                v_ws = New BDSDeliveryManagement
                Dim v_strErrorSource, v_strErrorMessage As String
                Dim v_lngError As Long = v_ws.Message(v_strObjMsg)
                If v_lngError <> ERR_SYSTEM_OK Then
                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage)
                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Return -1
                End If
            End If
        End If
    End Function


    'Kiem tra thong tin truoc khi ghi
    Private Function VerifyCFRules(ByRef v_strTxMsg As String) As Boolean
        Dim v_xmlDocument As New Xml.XmlDocument
        Try
            Dim v_strMessage As String = String.Empty
            Dim v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
            Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode, v_intIndex As Long, i, v_intCount As Integer
            Dim v_strFLDNAME As String, v_strFLDDEFNAME As String, v_strDATATYPE As String, v_strFLDVALUE As String
            Dim v_strERRMSG, v_strENERRMSG, v_strOPERATOR, v_strVALEXP, v_strVALEXP2 As String, v_strACTYPE, v_strDESC As String
            Dim v_dtVALEXP, v_dtVALEXP2, v_dtFLDVALUE As Date, v_strCMDSQL As String
            Dim v_ctl As Control, v_attrFLDNAME As Xml.XmlAttribute, v_attrDATATYPE As Xml.XmlAttribute, v_objEval As New Evaluator


            'Táº¡o Ä‘iá»‡n giao dá»‹ch
            Select Case v_strSender
                Case "btnREFUSE"
                    v_strMessage = "Refuse contract:"
                    LoadScreen(gc_CF_REFUSECONTRACT)
                    v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, gc_CF_REFUSECONTRACT, Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)
                Case "btnREJECT"
                    v_strMessage = "Reject contract:"
                    LoadScreen(gc_CF_REJECTCONTRACT)
                    v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, gc_CF_REJECTCONTRACT, Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)
                Case "btnAPPROVE"
                    v_strMessage = "Approve contract:"
                    LoadScreen(gc_CF_APPROVECONTRACT)
                    v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, gc_CF_APPROVECONTRACT, Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)
            End Select
            v_xmlDocument.LoadXml(v_strTxMsg)
            v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")
            If mv_arrObjFields.GetLength(0) > 0 Then
                For v_intIndex = 0 To mv_arrObjFields.GetLength(0) - 1 Step 1
                    If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                        v_strFLDNAME = mv_arrObjFields(v_intIndex).FieldName
                        v_strDATATYPE = mv_arrObjFields(v_intIndex).DataType
                        Select Case Trim(v_strFLDNAME)

                            Case "03" 'AFACCTNO
                                v_strFLDVALUE = Trim(Strings.Replace(Me.txtACCTNO.Text, ".", String.Empty))               
                            Case "01" ' CUSTID
                                v_strFLDVALUE = Trim(Strings.Replace(Me.txtCUSTID.Text, ".", String.Empty))
                            Case "30" 'DESC                                              
                                v_strFLDVALUE = v_strMessage & Me.txtACCTNO.Text & ":" & Me.txtDESCRIPTION.Text
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
        Finally
            v_xmlDocument = Nothing
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
        Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            'Create message to inquiry object fields
            Dim v_strSQL, v_strClause, v_strObjMsg As String
            If Len(v_strXML) > 0 Then
                v_xmlDocumentData.LoadXml(v_strXML)
            End If
            'Lay thong tin chung ve giao dich
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
                'Neu khong ton tai ma giao dich
                MessageBox.Show(ResourceManager.GetString("ERR_TLTXCD_NOTFOUND"))
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

            'Láº¥y thÃ´ng tin chi tiáº¿t cÃ¡c trÆ°?ng cï¿½á»§a giao dá»‹ch
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
                        'Xá»­ lÃ½ cho trÆ°?ng Description
                        v_strDefVal = Me.Text
                    ElseIf v_strDefVal = "<$BUSDATE>" Then
                        'Lï¿½áº¥y ngÃ y lÃ m viá»‡c hiá»‡n táº¡i
                        v_strDefVal = Me.BusDate
                    End If
                    If v_blnChain Then
                        'Náº¿u giao dá»‹ch Ä‘Æ°á»£c náº¡p qua giao dá»‹ch tra cá»©u
                        If Len(v_strChainName) > 0 Then
                            'Náº¿u trÆ°?ng nï¿½Ã y cÃ³ sá»­ dá»¥ng CHAINNAME Ä‘á»ƒ láº¥y giÃ¡ trá»‹ tá»« mÃ n hÃ¬nh tra cá»©u
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

            'Láº¥y cÃ¡c luáº­t kiá»ƒm tra cá»§a cÃ¡c trÆ°?ng giao dï¿½á»‹ch
            v_strClause = "SELECT FLDNAME, VALTYPE, OPERATOR, VALEXP, VALEXP2, ERRMSG, EN_ERRMSG FROM FLDVAL " & _
                "WHERE upper(OBJNAME) = '" & strTLTXCD & "' ORDER BY VALTYPE, FLDNAME, ODRNUM" 'Thá»© tá»± order by lÃ  quan tr?ng khï¿½Ã´ng sá»­a
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
                        'Ghi nháº­n thuáº­t toÃ¡n Ä‘á»ƒ kiá»ƒm tra vÃ  tÃ­nh toÃ¡n cho tá»«ng trÆ°?ng cï¿½á»§a giao dá»‹ch
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
                '?iï¿½?u kiï¿½á»‡n xá»­ lÃ½
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
        Finally
            v_xmlDocument = Nothing
            v_xmlDocumentData = Nothing
            v_ws = Nothing
        End Try
    End Sub

    Public Sub OnSubmit()
        Dim v_strTxMsg As String, v_xmlDocument As New Xml.XmlDocument, v_attrColl As Xml.XmlAttributeCollection
        Dim v_intNOSUBMIT As Integer, v_strNEXTTX As String = String.Empty
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            'Control Validate
            If Not ControlValidation() Then
                Exit Sub
            End If
            MessageData = String.Empty
            If Not VerifyCFRules(v_strTxMsg) Then
                Exit Sub
            Else
                MessageData = v_strTxMsg
            End If

            If preSaveCheck() = -1 Then
                Exit Sub
            End If

            '?ï¿½áº©y Ä‘iá»‡n giao dá»‹ch lÃªn APP-SERVER
            v_strTxMsg = MessageData
            v_lngError = v_ws.Message(v_strTxMsg)
            If v_lngError <> ERR_SYSTEM_OK Then
                'ThÃ´ng bÃ¡o lá»—i
                GetErrorFromMessage(v_strTxMsg, v_strErrorSource, v_lngError, v_strErrorMessage)
                Cursor.Current = Cursors.Default
                If v_lngError <> ERR_SA_CHECKER1_OVR And v_lngError <> ERR_SA_CHECKER2_OVR Then
                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Exit Sub
                Else
                    'Láº¥y thÃªm nguyÃªn nhÃ¢n duyá»‡t
                    GetReasonFromMessage(v_strTxMsg, v_strErrorMessage, Me.UserLanguage)
                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                End If
            Else
                Select Case v_strSender
                    Case "btnREFUSE"
                        MsgBox(ResourceManager.GetString("RefuseSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        Me.DialogResult = DialogResult.OK
                        MyBase.OnClose()
                    Case "btnREJECT"
                        MsgBox(ResourceManager.GetString("RejectSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        Me.DialogResult = DialogResult.OK
                        MyBase.OnClose()
                    Case "btnAPPROVE"
                        MsgBox(ResourceManager.GetString("ApproveSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        Me.DialogResult = DialogResult.OK
                        MyBase.OnClose()
                End Select
            End If
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Sub


    'Xoa mot dong trong grid
    Private Function Delete_TabPage_Row(Optional ByVal pv_strIsLocal As String = "", Optional ByVal pv_strModule As String = "") As Int32
        Dim v_ws As New BDSDeliveryManagement
        Dim v_strKeyFieldName, v_strKeyFieldValue As String
        Dim v_strClause, v_strObjMsg As String
        Dim v_strErrorSource, v_strErrorMessage As String
        Dim v_lngErrorCode As Long
        Dim ParentObjName As String = Me.ObjectName
        Dim ParentClause As String = KeyFieldName & " = '" & txtACCTNO.Text & "'"

        Try

            If MsgBox(ResourceManager.GetString("DelConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                'Update mouse pointer
                Cursor.Current = Cursors.WaitCursor

                If (pv_strIsLocal.Length <> 0) And (pv_strModule.Length <> 0) Then
                    If pv_strModule = "CF.AFTXMAP" Then
                        If (Not (AFTXMAPGrid.CurrentRow Is Nothing)) Then
                            If Trim(CType(AFTXMAPGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AFACCTNO").Value) = "ALL" Then
                                MsgBox(ResourceManager.GetString("AUTHNOTALLOW"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                Exit Function
                            End If

                            v_strKeyFieldName = CType(AFTXMAPGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").FieldName
                            v_strKeyFieldValue = CType(AFTXMAPGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value

                            Select Case KeyFieldType
                                Case "D"
                                    v_strClause = v_strKeyFieldName & " = TO_DATE('" & v_strKeyFieldValue & "', '" & gc_FORMAT_DATE & "')"
                                Case "N"
                                    v_strClause = v_strKeyFieldName & " = " & v_strKeyFieldValue
                                Case "C"
                                    v_strClause = v_strKeyFieldName & " = '" & v_strKeyFieldValue & "'"
                            End Select

                            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, pv_strIsLocal, gc_MsgTypeObj, pv_strModule, gc_ActionDelete, , v_strClause, , , , , , , , ParentObjName, ParentClause)
                            v_ws.Message(v_strObjMsg)
                            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                        End If
                    End If


                    If pv_strModule = "CF.AFSERULE" Then
                        If (Not (AFSERULEGrid.CurrentRow Is Nothing)) Then
                            v_strKeyFieldName = CType(AFSERULEGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").FieldName
                            v_strKeyFieldValue = CType(AFSERULEGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value

                            Select Case KeyFieldType
                                Case "D"
                                    v_strClause = v_strKeyFieldName & " = TO_DATE('" & v_strKeyFieldValue & "', '" & gc_FORMAT_DATE & "')"
                                Case "N"
                                    v_strClause = v_strKeyFieldName & " = " & v_strKeyFieldValue
                                Case "C"
                                    v_strClause = v_strKeyFieldName & " = '" & v_strKeyFieldValue & "'"
                            End Select

                            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, pv_strIsLocal, gc_MsgTypeObj, pv_strModule, gc_ActionDelete, , v_strClause, , , , , , , , ParentObjName, ParentClause)
                            v_ws.Message(v_strObjMsg)
                            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                        End If
                    End If

                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Function
                    End If
                End If
                'Update mouse pointer
                Cursor.Current = Cursors.Default
                MsgBox(ResourceManager.GetString("DelSuccess"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_ws = Nothing
        End Try
    End Function


    Private Function VerifyCareBy() As Boolean
        Try
            Dim v_strCareBy, v_strGroupId, v_strGroupName, v_arrGroupCareBy(), v_arrGroup() As String
            v_strCareBy = String.Empty
            v_strGroupId = String.Empty
            v_strGroupName = String.Empty

            If GroupCareBy <> String.Empty Then
                v_arrGroupCareBy = GroupCareBy.Split("#")

                If (ExeFlag = ExecuteFlag.AddNew) Then
                    If Not v_arrGroupCareBy Is Nothing Then
                        For i As Integer = 0 To v_arrGroupCareBy.Length - 2
                            v_arrGroup = CStr(v_arrGroupCareBy(i)).Split("|")
                            v_strGroupId = v_arrGroup(0)
                            If Trim(mv_strCareBy) = Trim(v_strGroupId) Then
                                Return True
                            End If
                        Next
                        Return False
                    Else
                        Return False
                    End If
                ElseIf (ExeFlag = ExecuteFlag.Edit) Then
                    'IIf(IsDBNull(Len(v_strPostingDate)), 0, Len(v_strPostingDate)) > 0
                    If Not v_arrGroupCareBy Is Nothing Then
                        For i As Integer = 0 To v_arrGroupCareBy.Length - 2
                            v_arrGroup = CStr(v_arrGroupCareBy(i)).Split("|")
                            v_strGroupId = v_arrGroup(0)
                            If Trim(mv_strCareBy) = Trim(v_strGroupId) Then
                                Return True
                            End If
                        Next
                        Return False
                    Else
                        Return False
                    End If
                End If
            ElseIf (ExeFlag = ExecuteFlag.View) Or (ExeFlag = ExecuteFlag.Edit) Then
                If Not v_arrGroupCareBy Is Nothing Then
                    For i As Integer = 0 To v_arrGroupCareBy.Length - 2
                        v_arrGroup = CStr(v_arrGroupCareBy(i)).Split("|")
                        v_strGroupId = v_arrGroup(0)
                        If Trim(mv_strCareBy) = Trim(v_strGroupId) Then
                            Return True
                        End If
                    Next
                    Return False
                Else
                    Return False
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub LoadAFSERULE(ByVal pv_strAFACCTNO As String, ByVal pv_strACTYPE As String)
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_int, v_intCount As Integer
            Dim v_strCDCONTENT, v_strFLDNAME, v_strVALUE, v_strCmdInquiry, v_strObjMsg As String

            If Not AFSERuleGrid Is Nothing And Len(pv_strAFACCTNO) > 0 Then
                'Clear old data
                AFSERuleGrid.DataRows.Clear()
                v_strCmdInquiry = "SELECT a.autoid, c1.cdcontent bors, c3.cdcontent typormst, a.typormst typormstcd, a.refid, sb.symbol codeid, c2.cdcontent POLICYCD, a.termval, a.termratio, a.effdate, a.expdate " & ControlChars.CrLf _
                                & "FROM aftype aft, afserule a, allcode c1, allcode c2, allcode c3, sbsecurities sb " & ControlChars.CrLf _
                                & "where aft.actype = '" & pv_strACTYPE & "' and a.codeid = sb.codeid and c1.cdtype = 'SA' and c1.cdname = 'BORS' and c1.cdval = a.bors " & ControlChars.CrLf _
                                & "and c2.cdtype = 'CF' and c2.cdname = 'REFPOLICYCD' and c2.cdval = aft.POLICYCD " & ControlChars.CrLf _
                                & "and c3.cdtype = 'SY' and c3.cdname = 'TYPORMST' and c3.cdval = a.typormst and ((a.refid = '" & pv_strAFACCTNO & "' and a.typormst = 'M') or (a.refid = '" & pv_strACTYPE & "' and a.typormst = 'T'))"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "CF.AFSERULE", gc_ActionInquiry, v_strCmdInquiry)
                v_ws.Message(v_strObjMsg)
                FillDataGrid(AFSERULEGrid, v_strObjMsg, "")
                mv_blnRefreshTabPage_AFSERule = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Sub

    Private Sub LoadSubAccount(ByVal pv_strACCTNO As String)
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            If Not SUBACCOUNTGrid Is Nothing And Len(pv_strACCTNO) > 0 Then
                SUBACCOUNTGrid.DataRows.Clear()
                Dim v_strSQL As String = "SELECT DISTINCT AFACCTNO,  MST.MODCODE, MST.SYMBOL, MST.ACCTNO, MST.AVLBAL " & _
                    "FROM V_CFCONTRACT MST, ALLCODE CD WHERE " & _
                    " ((MST.MODCODE = 'SE' AND MST.AVLBAL > 0) OR (MST.MODCODE = 'CI')) AND CD.CDTYPE='CF' AND CD.CDNAME='LINKTYPE' AND CD.CDVAL=MST.LINKTYPE AND TRIM(MST.AFACCTNO)='" & pv_strACCTNO & "' " & _
                    "ORDER BY AFACCTNO, MODCODE "

                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "CF.CFMAST", _
                    gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                FillDataGrid(SUBACCOUNTGrid, v_strObjMsg, "")
                mv_blnRefreshTabPage_Accounts = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_ws = Nothing
        End Try
    End Sub

    Private Function ControlValidation(Optional ByVal pv_blnSaved As Boolean = False) As Boolean
        Dim v_ws As New BDSDeliveryManagement
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strVALUE, v_strNum, v_strIDEXPIRED As String
        Dim v_dblCount As Double = 0
        Dim v_strSQL, v_strObjMsg As String
        Dim v_dblMRCRLIMITMAX, v_dblMRLOANLIMIT As Double

        Try
            If ExeFlag = ExecuteFlag.Edit Then
                Me.cboTERMOFUSE.Enabled = False
            End If


            If pv_blnSaved Then
                'v_strSQL = "SELECT nvl(max(mrloanlimit),0) mrloanlimit, nvl(sum(mrcrlimitmax),0) mrcrlimitmax FROM CFMAST CF, (select * from AFMAST AF where AF.ACCTNO <> '" & Me.txtACCTNO.Text & "' and AF.status <> 'C' AND AF.CUSTID ='" & Me.txtCUSTID.Text & "') AF WHERE CF.CUSTID = AF.CUSTID(+) AND CF.CUSTID ='" & Me.txtCUSTID.Text & "'"
                'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strSQL)
                'v_ws.Message(v_strObjMsg)
                'v_xmlDocument.LoadXml(v_strObjMsg)
                'v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                'For i As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                '    With v_nodeList.Item(0).ChildNodes(i)
                '        v_strFLDNAME = .Attributes.GetNamedItem("fldname").Value.Trim()
                '        v_strVALUE = .Attributes.GetNamedItem("oldval").Value.Trim()
                '        Select Case v_strFLDNAME
                '            Case "MRCRLIMITMAX"
                '                v_dblMRCRLIMITMAX = CDbl(v_strVALUE)
                '            Case "MRLOANLIMIT"
                '                v_dblMRLOANLIMIT = CDbl(v_strVALUE)
                '        End Select
                '    End With
                'Next
                'If Not CDbl(Me.txtMRCRLIMITMAX.Text) >= 0 Then
                '    MsgBox(ResourceManager.GetString("MRCRLIMITMAX_LARGER_ZERO"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                '    Return False
                'End If
                'If Not v_dblMRLOANLIMIT >= v_dblMRCRLIMITMAX + CDbl(Me.txtMRCRLIMITMAX.Text) Then
                '    MsgBox(ResourceManager.GetString("MRCRLIMITMAX_OVER_MRLOANLIMIT"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                '    Return False
                'End If
                'v_strSQL = "SELECT count(1) AFTYPECNT FROM AFMAST WHERE ACCTNO <> '" & Me.txtACCTNO.Text & "' and status <> 'C' AND CUSTID ='" & Me.txtCUSTID.Text & "' AND ACTYPE = '" & Me.cboACTYPE.SelectedValue & "'"
                'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strSQL)
                'v_ws.Message(v_strObjMsg)
                'v_xmlDocument.LoadXml(v_strObjMsg)
                'v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                'For i As Integer = 0 To v_nodeList.Count - 1
                '    For j As Integer = 0 To v_nodeList.Item(j).ChildNodes.Count - 1
                '        With v_nodeList.Item(j).ChildNodes(i)
                '            v_strFLDNAME = v_nodeList.Item(j).ChildNodes(i).Attributes.GetNamedItem("fldname").Value.Trim()
                '            v_strVALUE = v_nodeList.Item(j).ChildNodes(i).Attributes.GetNamedItem("oldval").Value.Trim()
                '            Select Case v_strFLDNAME
                '                Case "AFTYPECNT"
                '                    v_dblCount = CDbl(v_strVALUE)
                '            End Select
                '        End With
                '    Next
                'Next
                'If v_dblCount > 0 Then
                '    If MsgBox(ResourceManager.GetString("ACTYPE_EXISTS"), MsgBoxStyle.Information + MsgBoxStyle.OkCancel, gc_ApplicationTitle) <> MsgBoxResult.Ok Then
                '        Return False
                '    End If
                'End If

                If Me.txtACCTNO.Text.Replace(".", "").Length <> 10 Then
                    MsgBox(ResourceManager.GetString("ACCTNO_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Me.txtACCTNO.Focus()
                    Return False
                End If
                If (Me.cboCOREBANK.SelectedValue = "Y" Or (cboCOREBANK.SelectedValue = "N" And cboALTERNATEACCT.SelectedValue = "Y")) _
                        And Me.txtBANKACCTNO.Text.Length <> 0 Then
                    Dim v_dblBANKACCTNOCNT As Double = 0
                    v_strSQL = "SELECT count(1) BANKACCTNOCNT FROM AFMAST WHERE ACCTNO <> '" & Me.txtACCTNO.Text & "' and status <> 'C' AND BANKNAME = '" & Me.cboBANKNAME.SelectedValue & "' AND BANKACCTNO ='" & Me.txtBANKACCTNO.Text & "'"
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strSQL)
                    v_ws.Message(v_strObjMsg)
                    v_xmlDocument.LoadXml(v_strObjMsg)
                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                    For i As Integer = 0 To v_nodeList.Count - 1
                        For j As Integer = 0 To v_nodeList.Item(j).ChildNodes.Count - 1
                            With v_nodeList.Item(j).ChildNodes(i)
                                v_strFLDNAME = v_nodeList.Item(j).ChildNodes(i).Attributes.GetNamedItem("fldname").Value.Trim()
                                v_strVALUE = v_nodeList.Item(j).ChildNodes(i).Attributes.GetNamedItem("oldval").Value.Trim()
                                Select Case v_strFLDNAME
                                    Case "BANKACCTNOCNT"
                                        v_dblBANKACCTNOCNT = CDbl(v_strVALUE)
                                End Select
                            End With
                        Next
                    Next
                    If v_dblBANKACCTNOCNT > 0 Then
                        If MsgBox(ResourceManager.GetString("BANKACCTNO_EXISTS"), MsgBoxStyle.Information + MsgBoxStyle.OkCancel, gc_ApplicationTitle) <> MsgBoxResult.Ok Then
                            Return False
                        End If
                    End If
                End If
                If (Me.cboCOREBANK.SelectedValue = "Y" Or (cboCOREBANK.SelectedValue = "N" And cboALTERNATEACCT.SelectedValue = "Y")) _
                            And Me.txtBANKACCTNO.Text.Length = 0 Then
                    MsgBox(ResourceManager.GetString("BANKACCTNO_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Me.txtBANKACCTNO.Focus()
                    Return False
                End If
                If ExeFlag = ExecuteFlag.AddNew Or ExeFlag = ExecuteFlag.Edit Then
                    If Me.cboCAREBY.SelectedValue Is Nothing Then
                        MsgBox(ResourceManager.GetString("CAREBY_IS_NULL"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        Me.cboCAREBY.Focus()
                        Return False
                    End If
                    If (Me.cboISOTC.SelectedValue = "N" Or (Me.cboISOTC.SelectedValue = "Y" And Trim(Me.CustodyCD) <> "")) Then
                        If Len(Me.CustodyCD) = 10 Then
                            v_strSQL = "SELECT to_char(IDEXPIRED,'DD/MM/RRRR') IDEXPIRED FROM CFMAST WHERE CUSTID ='" & Me.CustID & "'"
                            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strSQL)
                            v_ws.Message(v_strObjMsg)
                            v_xmlDocument.LoadXml(v_strObjMsg)
                            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                            For i As Integer = 0 To v_nodeList.Count - 1


                                For j As Integer = 0 To v_nodeList.Item(j).ChildNodes.Count - 1
                                    With v_nodeList.Item(j).ChildNodes(i)
                                        v_strFLDNAME = v_nodeList.Item(j).ChildNodes(i).Attributes.GetNamedItem("fldname").Value.Trim()
                                        v_strVALUE = v_nodeList.Item(j).ChildNodes(i).Attributes.GetNamedItem("oldval").Value.Trim()
                                        Select Case v_strFLDNAME
                                            Case "IDEXPIRED"
                                                v_strIDEXPIRED = v_strVALUE
                                        End Select
                                    End With
                                Next
                            Next
                            If DDMMYYYY_SystemDate(v_strIDEXPIRED) <= DDMMYYYY_SystemDate(BusDate) Then
                                If MessageBox.Show(ResourceManager.GetString("IDEXPIREDLESSTHANBUSDATE"), Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) <> Windows.Forms.DialogResult.OK Then
                                    Return False
                                End If
                            End If

                        End If
                    End If
                End If 
                Return MyBase.VerifyRules
            End If

            Return True
        Catch ex As Exception
            Throw ex
            Return False
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Function

    Private Sub btnAFTXMAP_ADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAFTXMAP_ADD.Click
        If Me.txtACCTNO.Text.Length = 10 Then
            showFormAFTXMAP(ExecuteFlag.AddNew)
        Else
            MsgBox(ResourceManager.GetString("ACCTNO_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Me.txtACCTNO.Focus()
        End If
    End Sub

    Private Sub btnAFTXMAP_VIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAFTXMAP_VIEW.Click
        showFormAFTXMAP(ExecuteFlag.View)
    End Sub

    Private Sub btnAFTXMAP_EDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAFTXMAP_EDIT.Click
        showFormAFTXMAP(ExecuteFlag.Edit)
    End Sub

    Private Sub btnAFTXMAP_DELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAFTXMAP_DELETE.Click
        If AFTXMAPGrid.CurrentGrid.DataRows.Count > 0 Then
            Delete_TabPage_Row(gc_IsNotLocalMsg, ModuleCode & ".AFTXMAP")
            LoadAFTXMAP(Me.txtACCTNO.Text, "")
        End If
    End Sub

    Private Sub btnAFSERULE_DELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim v_strObjMsg, v_strErrorSource, v_strErrorMessage, v_strClause As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_lngErrorCode As Long = ERR_SYSTEM_OK
        Try
            If AFSERULEGrid.CurrentRow Is Nothing Then
                Exit Sub
            End If
            If Trim(CType(AFSERULEGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TYPORMSTCD").Value) <> "M" Then
                MsgBox(ResourceManager.GetString("TYPORMSTCD_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Else
                v_strClause = " AUTOID = " & Trim(CType(AFSERULEGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "CF.AFSERULE", gc_ActionDelete, , v_strClause, , , , , , , , ParentObjName, ParentClause)
                v_ws.Message(v_strObjMsg)
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)


                If v_lngErrorCode <> 0 Then
                    'Update mouse pointer
                    Cursor.Current = Cursors.Default
                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Exit Sub
                Else
                    Cursor.Current = Cursors.Default
                    MsgBox(ResourceManager.GetString("DelSuccess"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    LoadAFSERULE(Me.txtACCTNO.Text, "")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function getContract(ByVal BranchID As String) As String
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_wsBDS As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            Dim v_strClause, v_strAutoID As String
            Dim v_int, v_intCount As Integer
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strFLDNAME, v_strVALUE As String
            v_strClause = "AFACCTNO"
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchID, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strClause, "GetInventory")
            v_wsBDS.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_strAutoID = v_xmlDocument.DocumentElement.Attributes("CLAUSE").Value
            v_strAutoID = Me.BranchId & Strings.Right("000000" & CStr(v_strAutoID), Len("000000"))
            Return v_strAutoID
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                    & "Error code: System error!" & vbNewLine _
                                    & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("SavingFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_xmlDocument = Nothing
            v_wsBDS = Nothing
        End Try
    End Function

    Private Sub btnGenCheckAFACCTNO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenCheckAFACCTNO.Click
        Dim v_strCheckAFACCTNO As String
        If ExeFlag = ExecuteFlag.AddNew Then
            If Me.txtACCTNO.Text.Length <> 10 Then
                v_strCheckAFACCTNO = getContract(Me.BranchId)
            Else
                v_strCheckAFACCTNO = Me.txtACCTNO.Text
            End If
            If CheckAFACCTNO(v_strCheckAFACCTNO) Then
                Me.txtACCTNO.Text = v_strCheckAFACCTNO
            Else
                Me.txtACCTNO.Text = getContract(Me.BranchId)
                'MsgBox(ResourceManager.GetString("INVALIDAFACCTNO"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            End If
        End If
    End Sub


    Private Function CheckAFACCTNO(ByVal strAFACCTNO As String) As Boolean
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_int, v_intCount As Integer
        Dim v_strCDCONTENT, v_strCCUSTID As String
        Dim v_strFLDNAME, v_strVALUE As String
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        If strAFACCTNO.Substring(0, 4) <> Me.BranchId Then
            Return False
        End If
        Try
            Dim v_strCmdInquiry As String = "Select count(1) CCUSTID  from AFMAST where ACCTNO = '" & strAFACCTNO & "'"
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.ALLCODE", gc_ActionInquiry, v_strCmdInquiry)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For v_intCount = 0 To v_nodeList.Count - 1
                For v_int = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                    With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                        v_strFLDNAME = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                        v_strVALUE = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()

                        Select Case v_strFLDNAME
                            Case "CCUSTID"
                                v_strCCUSTID = v_strVALUE
                        End Select
                    End With
                Next
            Next
            If CDbl(v_strCCUSTID) > 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    'Private Sub LoadACTYPEDetail()
    '    If mv_blnIsLoading Then Return
    '    Dim v_strCmdSQL, v_strObjMsg, v_strFLDNAME, v_strVALUE As String
    '    Dim v_ws As New BDSDeliveryManagement
    '    Dim v_xmlDocument As New Xml.XmlDocument
    '    Dim v_nodeList As Xml.XmlNodeList
    '    Dim V_STRCUSTID, V_STRMARGINALLOW As String
    '    Dim V_DBDPCRLIMITMAX, V_DBMRCRLIMITMAX As Double

    '    V_STRCUSTID = Me.CustID

    '    Try
    '        If cboACTYPE.SelectedValue Is Nothing Then
    '            Return
    '        End If

    '        v_strCmdSQL = "SELECT CF.MARGINALLOW, aft.corebank, case when aft.corebank = 'Y' then 'N' else AFT.AUTOADV end AUTOADV, MRT.MRIRATE, MRT.MRSRATE ,MRT.MRMRATE, MRT.MRLRATE, AFT.AUTOADV, " & _
    '                     "MRT.MCIRATE, MRT.MCSRATE ,MRT.MCMRATE, MRT.MCLRATE , AFT.BASECALLDAY, " & _
    '                     "MRT.MBIRATE, MRT.MBSRATE ,MRT.MBMRATE, MRT.MBLRATE ,MRT.MRIRATIO, MRT.MRSRATIO ,MRT.MRMRATIO, MRT.MRLRATIO,aft.mrcrlimitmax ,aft.dpcrlimitmax " & _
    '                     "FROM AFTYPE AFT, MRTYPE MRT, CFMAST CF " & _
    '                     "WHERE AFT.MRTYPE= MRT.ACTYPE and aft.status = 'Y' and aft.actype = '" & cboACTYPE.SelectedValue & "' " & _
    '                     "AND CF.CUSTID = '" & V_STRCUSTID & "'"
    '        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
    '        v_ws.Message(v_strObjMsg)


    '        v_xmlDocument.LoadXml(v_strObjMsg)
    '        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
    '        'Lay thong tin ve loai hinh
    '        For i As Integer = 0 To v_nodeList.Count - 1
    '            For j As Integer = 0 To v_nodeList.Item(j).ChildNodes.Count - 1
    '                With v_nodeList.Item(i).ChildNodes(j)
    '                    v_strFLDNAME = v_nodeList.Item(i).ChildNodes(j).Attributes.GetNamedItem("fldname").Value.Trim()
    '                    v_strVALUE = v_nodeList.Item(i).ChildNodes(j).Attributes.GetNamedItem("oldval").Value.Trim()
    '                    Select Case v_strFLDNAME
    '                        Case "AUTOADV"
    '                            If ExeFlag = ExecuteFlag.AddNew Then
    '                                Me.cboAUTOADV.SelectedValue = v_strVALUE
    '                            End If
    '                        Case "COREBANK"
    '                            If v_strVALUE = "Y" Then
    '                                Me.cboAUTOADV.SelectedValue = "N"
    '                                Me.cboAUTOADV.Enabled = False

    '                            End If
    '                        Case "MRIRATE"
    '                            Me.txtMRIRATE.Text = CDbl(v_strVALUE)
    '                        Case "MRMRATE"
    '                            Me.txtMRMRATE.Text = CDbl(v_strVALUE)
    '                        Case "MRLRATE"
    '                            Me.txtMRLRATE.Text = CDbl(v_strVALUE)
    '                        Case "MRSRATE"
    '                            Me.txtMRSRATE.Text = CDbl(v_strVALUE)
    '                        Case "MCIRATE"
    '                            Me.txtMCIRATE.Text = CDbl(v_strVALUE)
    '                        Case "MCMRATE"
    '                            Me.txtMCMRATE.Text = CDbl(v_strVALUE)
    '                        Case "MCLRATE"
    '                            Me.txtMCLRATE.Text = CDbl(v_strVALUE)
    '                        Case "MCSRATE"
    '                            Me.txtMCSRATE.Text = CDbl(v_strVALUE)
    '                            'MRT.MBIRATE, MRT.MBSRATE ,MRT.MBMRATE, MRT.MBLRATE ,MRT.MRIRATIO, MRT.MRSRATIO ,MRT.MRMRATIO, MRT.MRLRATIO
    '                        Case "MBIRATE"
    '                            Me.txtMBIRATE.Text = CDbl(v_strVALUE)
    '                        Case "MBSRATE"
    '                            Me.txtMBSRATE.Text = CDbl(v_strVALUE)
    '                        Case "MBMRATE"
    '                            Me.txtMBMRATE.Text = CDbl(v_strVALUE)
    '                        Case "MBLRATE"
    '                            Me.txtMBLRATE.Text = CDbl(v_strVALUE)
    '                        Case "MRIRATIO"
    '                            Me.txtMRIRATIO.Text = CDbl(v_strVALUE)
    '                        Case "MRSRATIO"
    '                            Me.txtMRSRATIO.Text = CDbl(v_strVALUE)
    '                        Case "MRMRATIO"
    '                            Me.txtMRMRATIO.Text = CDbl(v_strVALUE)
    '                        Case "MRLRATIO"
    '                            Me.txtMRLRATIO.Text = CDbl(v_strVALUE)
    '                        Case "BASECALLDAY"
    '                            Me.TXTBASECALLDAY.Text = CDbl(v_strVALUE)
    '                        Case "DPCRLIMITMAX"
    '                            V_DBDPCRLIMITMAX = CDbl(v_strVALUE)
    '                        Case "MRCRLIMITMAX"
    '                            V_DBMRCRLIMITMAX = CDbl(v_strVALUE)
    '                        Case "MARGINALLOW"
    '                            V_STRMARGINALLOW = v_strVALUE
    '                    End Select
    '                End With
    '            Next
    '        Next
    '        'LONGNH NEU CF.MARGINALLOW =N THI KO CAP HAN MUC
    '        If ExeFlag = ExecuteFlag.AddNew Then
    '            If V_STRMARGINALLOW = "N" Then
    '                Me.txtMRCRLIMITMAX.Text = "0"
    '                Me.txtDPCRLIMITMAX.Text = "0"
    '            Else
    '                Me.txtMRCRLIMITMAX.Text = V_DBMRCRLIMITMAX
    '                Me.txtDPCRLIMITMAX.Text = V_DBDPCRLIMITMAX

    '            End If
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub LoadBankScreen()
        Dim v_strCmdSQL, v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_strBankName As String = ""
        If Not Me.cboBANKNAME.SelectedValue Is Nothing And Me.cboBANKNAME.SelectedValue <> "---" Then
            v_strBankName = Me.cboBANKNAME.SelectedValue
        End If

        If Not cboALTERNATEACCT.SelectedValue Is DBNull.Value _
            AndAlso Not cboCOREBANK.SelectedValue Is DBNull.Value Then
            If cboALTERNATEACCT.SelectedValue = "N" AndAlso cboCOREBANK.SelectedValue = "N" Then
                lblBANKNAME.ForeColor = Color.Blue
                cboBANKNAME.Enabled = False
                lblBANKACCTNO.ForeColor = Color.Blue
                'txtBANKACCTNO.Enabled = False
                txtBANKACCTNO.Text = String.Empty

                v_strCmdSQL = "SELECT  CDVAL VALUECD, CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY FROM ALLCODE WHERE CDTYPE = 'CF' AND CDNAME = 'BANKNAME' and CDVAL = '---' ORDER BY LSTODR"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)
                Me.cboBANKNAME.Clears()
                FillComboEx(v_strObjMsg, Me.cboBANKNAME, "", Me.UserLanguage)

            Else
                If ExeFlag = ExecuteFlag.View OrElse ExeFlag = ExecuteFlag.Approve Then
                    lblBANKNAME.ForeColor = Color.Red
                    cboBANKNAME.Enabled = False
                    lblBANKACCTNO.ForeColor = Color.Red
                    'txtBANKACCTNO.Enabled = False
                Else
                    lblBANKNAME.ForeColor = Color.Red
                    cboBANKNAME.Enabled = True
                    lblBANKACCTNO.ForeColor = Color.Red
                    'txtBANKACCTNO.Enabled = True
                End If

                v_strCmdSQL = "SELECT  CDVAL VALUECD, CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY FROM ALLCODE WHERE CDTYPE = 'CF' AND CDNAME = 'BANKNAME' and CDVAL <> '---' ORDER BY LSTODR"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)
                Me.cboBANKNAME.Clears()
                FillComboEx(v_strObjMsg, Me.cboBANKNAME, "", Me.UserLanguage)
                If Me.BranchId = "0101" Then
                    Me.cboBANKNAME.SelectedValue = "BIDVHCM"
                    Me.cboBANKNAME.Enabled = False
                ElseIf Me.BranchId = "0001" Then
                    Me.cboBANKNAME.SelectedValue = "BIDVHN"
                    Me.cboBANKNAME.Enabled = False
                End If

            End If
        End If
        If v_strBankName.Length > 0 Then
            Try
                Me.cboBANKNAME.SelectedValue = v_strBankName
            Catch ex As Exception
            End Try
            If Me.cboBANKNAME.SelectedValue Is Nothing Then
                Me.cboBANKNAME.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub LoadAUTOTRF()
        Dim v_strCmdSQL, v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_strBankName As String = ""

        If Not cboALTERNATEACCT.SelectedValue Is DBNull.Value Then

            If ExeFlag = ExecuteFlag.View OrElse ExeFlag = ExecuteFlag.Approve Then
                cboAUTOTRF.Enabled = False
            Else
                If cboALTERNATEACCT.SelectedValue = "N" Then
                    cboAUTOTRF.SelectedValue = "N"
                    cboAUTOTRF.Enabled = False
                Else
                    cboAUTOTRF.Enabled = True
                    'cboAUTOTRF.SelectedValue = "N"
                End If
            End If

        End If

    End Sub


    Private Sub cboCOREBANK_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'longnh 2014-11-10 _phs_p1_cf0020
        'If mv_blnIsLoading Then Return
        'If ExeFlag <> ExecuteFlag.Approve AndAlso ExeFlag <> ExecuteFlag.View Then
        '    If cboCOREBANK.SelectedValue = "Y" Then
        '        cboALTERNATEACCT.SelectedValue = "N"
        '        cboALTERNATEACCT.Enabled = False

        '        cboAUTOADV.Enabled = False
        '    Else
        '        cboALTERNATEACCT.Enabled = True
        '        cboAUTOADV.Enabled = True
        '    End If
        'End If
        If mv_blnIsLoading Then Return
        If ExeFlag <> ExecuteFlag.Approve AndAlso ExeFlag <> ExecuteFlag.View Then
            If (cboCOREBANK.Text.Length > 0 And cboCOREBANK.SelectedValue = "Y") Then
                cboBANKNAME.Enabled = True

                'txtBANKACCTNO.Enabled = True

            Else
                cboBANKNAME.Enabled = False

                'txtBANKACCTNO.Enabled = False

            End If
            'LoadBankScreen()
        End If
    End Sub

    Private Sub cboALTERNATEACCT_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'LoadBankScreen()
        'LoadAUTOTRF()
    End Sub

    'Private Sub tbcAFMAST_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbcAFMAST.SelectedIndexChanged
    '    If Me.txtACCTNO.Text.Length > 0 Then
    '        Dim v_strTabPageName = tbcAFMAST.TabPages(tbcAFMAST.SelectedIndex).Name.ToLower
    '        If String.Compare(v_strTabPageName, tpAFSERULE.Name.ToLower) = 0 Then
    '            LoadAFSERULE(Me.txtACCTNO.Text, cboACTYPE.SelectedValue)
    '        ElseIf String.Compare(v_strTabPageName, tpAFTXMAP.Name.ToLower) = 0 Then
    '            LoadAFTXMAP(Me.txtACCTNO.Text, cboACTYPE.SelectedValue)
    '        ElseIf String.Compare(v_strTabPageName, tpSUBACCOUNT.Name.ToLower) = 0 Then
    '            LoadSubAccount(Me.txtACCTNO.Text)
    '        ElseIf String.Compare(v_strTabPageName, tpODPROBRKMST.Name.ToLower) = 0 Then
    '            LoadODPROBRKMST(Me.txtACCTNO.Text, cboACTYPE.SelectedValue)
    '        End If
    '    End If
    'End Sub


    Private Sub PrepareReportParams(ByVal v_strAFACCTNO As String)
        Dim v_xmlDocument As New XmlDocumentEx
        Dim v_xmlNodeList As Xml.XmlNodeList
        Try
            Dim v_obj As ReportParameters, i, v_intParams As Integer, v_ctrl As Control
            Dim v_strLookupData, v_strFLDNAME, v_strVALUE, v_strParamValue, v_strParamDesc As String

            ReDim mv_arrRptParam(2)    'Mac dinh la bao gom tat ca gia tri trong errObjFields la tham so
            'PV_CUSTODYCD     IN       VARCHAR2,
            'PV_AFACCTNO      IN       VARCHAR2,
            'I_BRID           IN       VARCHAR2
            v_obj = New ReportParameters
            v_obj.ParamName = "PV_CUSTODYCD"
            v_obj.ParamCaption = "CUSTODYCD"
            v_obj.ParamValue = String.Empty
            v_obj.ParamValue = Me.CustodyCD.Replace(".", "")
            v_obj.ParamDescription = Me.CustodyCD.Replace(".", "")
            v_obj.ParamType = GetType(System.String).Name
            v_obj.ParamSize = 10
            mv_arrRptParam(0) = v_obj

            v_obj = New ReportParameters
            v_obj.ParamName = "PV_AFACCTNO"
            v_obj.ParamCaption = "AFACCTNO"
            v_obj.ParamValue = String.Empty
            v_obj.ParamValue = v_strAFACCTNO
            v_obj.ParamDescription = v_strAFACCTNO
            v_obj.ParamType = GetType(System.String).Name
            v_obj.ParamSize = 10
            mv_arrRptParam(1) = v_obj

            v_obj = New ReportParameters
            v_obj.ParamName = "I_BRID"
            v_obj.ParamCaption = "BRID"
            v_obj.ParamValue = String.Empty
            v_obj.ParamValue = Me.BranchId
            v_obj.ParamDescription = Me.BranchId
            v_obj.ParamType = GetType(System.String).Name
            v_obj.ParamSize = 10
            mv_arrRptParam(2) = v_obj
            'Bao gồm cả 02 tham số mặc định OPT và BRID
            mv_intNumOfParam = 3
            ReDim Preserve mv_arrRptParam(mv_intNumOfParam - 1) 'Phan tu mang bat dau tu 0
        Catch ex As Exception
            Throw ex
        Finally
            v_xmlDocument = Nothing
        End Try
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
            Me.Cursor.Current = Cursors.WaitCursor
            Dim v_strObjMsg As String = String.Empty
            Dim v_ds As DataSet

            Dim dataElement As Xml.XmlElement, v_attrReport As Xml.XmlAttribute
            'Prepare parameters to create the report

            'Show processing message
            v_frm.UserLanguage = UserLanguage
            v_frm.ProcessType = ProcessType.ReportProcess
            v_frm.InitDialog()
            v_frm.Show()
            'End of show processing message

            'Get Report file name from server.
            v_strSQL = "select fn_getafrptname('" & Me.txtACCTNO.Text.Trim & "') RPTNAME from dual"
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

            PrepareReportParams(Me.txtACCTNO.Text.Replace(".", ""))

            'Get Store name from server.
            v_strSQL = "select fn_getStorename('" & Me.txtACCTNO.Text.Trim & "') STORENAME from dual"
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
                            Case "STORENAME"
                                mv_strStoreName = Trim(v_strVALUE)
                        End Select
                    End With
                Next
            Next
            'mv_strStoreName = "CFAF10" ' hardcode
            'Xu ly cho Sub Report

            'Create message and send to web service to get data for the report

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
            Me.Cursor.Current = Cursors.Default

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
                MessageBox.Show(ResourceManager.GetString("frmAFMAST.ReportCreateSucessfully"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            v_frm.Close()
            ' Change cursor pointer
            Me.Cursor.Current = Cursors.Default
        Finally
            v_wsObj = Nothing
            v_xmlDocument = Nothing
            v_frm = Nothing
            v_ws = Nothing
            v_xmlDocumentMessage = Nothing
        End Try
    End Sub


    Private Function GetReportFileName(ByVal pv_strCMDID As String) As String
        Return pv_strCMDID & TellerId & ".rpt"
    End Function

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
            'Dim v_strOldCultureName As String = String.Empty
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
            v_strOldCultureName = SetCultureInfo(v_strOldCultureName)

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


    Private Function GetRptTempFilePath(ByVal pv_strRptID As String) As String
        Return pv_strRptID & TellerId & ".rpt"
    End Function

    Private Function GetRptTemplateFilePath(ByVal pv_strRptID As String) As String
        Return pv_strRptID & ".rpt"
    End Function

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

                v_ExDirectoy = ExportDirectory
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

    Private Sub btnPRINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPRINT.Click
        GenAFReport()
    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        v_strSender = "btnApply"
    End Sub

    Private Sub txtBANKACCTNO_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If Not Me.txtBANKACCTNO.Text Is Nothing Then
            If Me.txtBANKACCTNO.Text.Trim.Length <> 14 Then
                If MsgBox(ResourceManager.GetString("frmAFMAST.BankAccount_Length_Invalid"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                    Me.ActiveControl = Me.txtBANKACCTNO
                End If
            End If
        End If
    End Sub

    Private Sub LoadODPROBRKMST(ByVal pv_strACCTNO As String, ByVal pv_strACTYPE As String)
        'longnh PHS_P1_RCF0003: Thêm tab Chính sách ưu đãi trên màn hình quản lý tiểu khoản, chỉ cho phép hiển thị, căn theo màn hình 020008 lấy các chính sách gắn với tiểu khoản đó
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            If Not ODPROBRKMSTGrid Is Nothing And Len(pv_strACCTNO) > 0 Then
                'Clear data
                ODPROBRKMSTGrid.DataRows.Clear()

                Dim v_strSQL As String = " SELECT MST.AUTOID, MST.FULLNAME," _
                                        & " MST.VALDATE, MST.EXPDATE, MST.FEERATE, MST.MINAMT, MST.MAXAMT, A0.CDCONTENT PROBRKMSTTYPE, A1.CDCONTENT STATUS," _
                                        & "(CASE WHEN MST.STATUS IN ('B','C','N') THEN 'N' ELSE 'Y' END) EDITALLOW," _
                                        & "(CASE WHEN MST.STATUS IN ('P') THEN 'Y' ELSE 'N' END) APRALLOW, 'Y' AS DELALLOW," _
                                        & " CASE WHEN MST.PROBRKMSTTYPE = 'LNINT' THEN (SELECT CDCONTENT FROM ALLCODE WHERE CDTYPE = 'LN' AND CDNAME = 'LOANTYPE' AND CDVAL = LNT.LOANTYPE ) ELSE '' END LOANTYPE " _
                                        & " FROM ODPROBRKMST MST, ALLCODE A0, ALLCODE A1,ODPROBRKAF kaf, afmast af ,AFTYPE AFT, LNTYPE LNT" _
                                        & " WHERE A0.CDTYPE='SA'" _
                                        & " AND A0.CDNAME='PROBRKMSTTYPE'" _
                                        & " And A0.CDVAL = MST.PROBRKMSTTYPE" _
                                        & " AND A1.CDTYPE='SY'" _
                                        & " AND A1.CDNAME='APPRV_STS'" _
                                        & " AND A1.CDVAL=MST.STATUS " _
                                        & " AND AF.ACTYPE = AFT.actype AND AFT.LNTYPE = LNT.ACTYPE(+) and af.acctno = kaf.afacctno" _
                                        & " And kaf.refautoid = mst.autoid" _
                                        & " and af.acctno = '" & pv_strACCTNO & "' "

                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "CF.ODPROBRKMST", _
                    gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                FillDataGrid(ODPROBRKMSTGrid, v_strObjMsg, "")
                mv_blnRefreshTabPage_ODPROBRKMST = True
            End If
        Catch ex As Exception
            Throw ex
        Finally
            v_ws = Nothing
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub txtACCTNO_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtACCTNO.Leave
        'longnh tu gen acctno khi leave txtAcctno

        'Me.txtACCTNO.Text = Me.BranchId & LSet(Me.txtACCTNO.Text.PadLeft(6, "0"), 6)
        Me.txtACCTNO.Text = Me.BranchId & Strings.Right(Me.txtACCTNO.Text.PadLeft(6, "0"), 6)
    End Sub
    'DieuNDA 28/12/2016: Revert phan cua Vu
    'Private Sub txtACCTNO_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtACCTNO.LostFocus
    '    If CheckAFACCTNO(txtACCTNO.Text) = False Then
    '        MsgBox(ResourceManager.GetString("ACCTNOERROR"), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)
    '    End If
    'End Sub
    'End DieuNDA 28/12/2016: Revert phan cua Vu

End Class
