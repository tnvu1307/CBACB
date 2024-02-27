Imports CommonLibrary
Imports System.Xml.XmlNode
Imports System.Xml
Imports TestBase64
Imports ZetaCompressionLibrary
Imports System.IO
Imports AppCore
Imports System.Configuration.ConfigurationSettings
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO.File
Imports System.IO.Path
Imports System.Windows.Forms.Application
Imports System.Text

         
Public Class frmCFMAST

#Region " Declare constants and variables "

    Const STAFF_ISSUER_EMPLOYEE = "004"
    Const IDTYPE_CMND = "001"
    Const IDTYPE_GPKD = "005"
    Const IDTYPE_TRADINGCODE = "009"
    Const VIETNAMEESE_CODE = "234"

    Private mv_arrAUTOID As String()
    Private mv_arrSIGNATURE As String()
    Private mv_arrCUSTID As String()
    Private mv_arrVALDATE As String()
    Private mv_arrEXPDATE As String()

    Private mv_intCurrImageIndex As Integer = 0
    Public v_strBranchID As String
    Private v_strSender As String
    Private mv_COUNTRYTable As New DataTable
    Private mv_PROVINCETable As New DataTable

    Public mv_OLAUTOID As String = String.Empty
    Public mv_CustomerType As String = String.Empty
    Public mv_CustomerName As String = String.Empty
    Public mv_CustomerBirth As String = String.Empty
    Public mv_IDType As String = String.Empty
    Public mv_IDCode As String = String.Empty
    Public mv_Iddate As String = String.Empty
    Public mv_Idplace As String = String.Empty
    Public mv_Expiredate As String = String.Empty
    Public mv_Address As String = String.Empty
    Public mv_Taxcode As String = String.Empty
    Public mv_PrivatePhone As String = String.Empty
    Public mv_Mobile As String = String.Empty
    Public mv_Fax As String = String.Empty
    Public mv_Email As String = String.Empty
    Public mv_Office As String = String.Empty
    Public mv_Position As String = String.Empty
    Public mv_Country As String = String.Empty
    Public mv_CustomerCity As String = String.Empty
    Public mv_SHORTNAME As String = String.Empty
    Public mv_TKTGTT As String = String.Empty
    Public IsOnlineRegister As Boolean = False


    Public WithEvents AFMASTGrid As GridEx
    Public WithEvents CFRELATIONGrid As GridEx
    Public WithEvents CURRENTACCGrid As GridEx
    Public WithEvents CFCONTACTGrid As GridEx
    Public WithEvents ISSUERGrid As GridEx
    Public WithEvents EMAILREPORTGrid As GridEx
    Public WithEvents CFAUTHGrid As GridEx
    Public WithEvents FABROKERAGEGrid As GridEx
    Public WithEvents FAAPGrid As GridEx
    Public WithEvents FAMEMBERSEXTRAGrid As GridEx
    ' Public WithEvents CORPORATEGrid As GridEx
    Public WithEvents CFOTHERACCGrid As GridEx
    Public WithEvents OTRIGTGrid As GridEx
    Public WithEvents AFTEMPLATESGrid As GridEx
    Public WithEvents CFRPTAFMASTGrid As GridEx
    Public WithEvents REAFLNKGrid As GridEx
    Public WithEvents CFDOMAINGrid As GridEx

    Public MessageData As String
    Private mv_blnAcctEntry As Boolean = False
    Private mv_arrObjFldVals() As CFieldVal
    Private mv_strIpAddress As String
    Private mv_strWsName As String
    Private mv_blnComboCountryLoad As Boolean = False
    Private mv_blnIsLoading As Boolean = True

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
    Private mv_strCustTypeVSD As String
    Private mv_strFullNameVSD As String
    Private mv_strAddressVSD As String
    Private mv_strIDCODEVSD As String
    Private mv_strIDDATEVSD As String
    Private mv_strTRADINGCODEVSD As String
    Private mv_strTRADINGCODEDTVSD As String
    Private mv_strIDEXPIREDVSD As String
    Private mv_strIDPLACEVSD As String
    Private mv_TRUADDRESS As String
    Private mv_content As String
    Private mv_PrefixCustodyCD As String = AppSettings.Get("PrefixedCustodyCode")
    'DieuNDA 28/12/2016 Revert phan cua Vu
    'Private mv_strISEDIT As String
    'End DieuNDA 28/12/2016 Revert phan cua Vu

#End Region

#Region "Properties"
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

    Public Property COUNTRYTable() As DataTable
        Get
            Return mv_COUNTRYTable
        End Get
        Set(ByVal Value As DataTable)
            mv_COUNTRYTable = Value
        End Set
    End Property
    Public Property PROVINCETable() As DataTable
        Get
            Return mv_PROVINCETable
        End Get
        Set(ByVal Value As DataTable)
            mv_PROVINCETable = Value
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
    Public Property v_strTRUADDRESS() As String
        Get
            Return v_strTRUADDRESS
        End Get
        Set(ByVal Value As String)
            v_strTRUADDRESS = Value
        End Set
    End Property

#End Region


    Public Overrides Sub OnInit()
        Dim v_strCmdSQL, v_strObjMsg, v_strFLDNAME, v_strVALUE, v_strMARGINTYPE, v_strCOREBANK, v_strACTYPE, v_strISTRFBUY As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strCheck As Integer
        'Tab default. No Load        

        'Load Resource Manager
        ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & Me.Name & "-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())

        Me.cboLink.Visible = False
        Me.TabControlHide.TabPages.Add(tpHiddenTab)
        Me.TabControlHide.TabPages.Add(tpCFRPTAFMAST)
        Me.TabControlHide.TabPages.Add(tpREAFLNK)
        Me.TabControlHide.TabPages.Add(tpAFMAST)
        Me.TabControlHide.TabPages.Add(tpOTRIGHT)




        'Fill du lieu vao combobox Country va Province. Cai thien toc do load du lieu vao combobox
        cboCOUNTRY.DataSource = mv_COUNTRYTable
        cboCOUNTRY.DisplayMember = "DISPLAY"
        cboCOUNTRY.ValueMember = "VALUE"

        Me.lblCOUNTRY.ForeColor = Color.Blue
        Me.lblAMC.ForeColor = Color.Blue
        Me.lblTRUSTEE.ForeColor = Color.Blue
        Me.lblSWIFTCODE.ForeColor = Color.Blue
        Me.lblGCB.ForeColor = Color.Blue
        Me.lblCCYBANK.ForeColor = Color.Blue
        Me.lblACCOUNTTYPE.ForeColor = Color.Blue
        Me.lblACCOUNTBANK.ForeColor = Color.Red
        Me.lblACCSETTLEMENT.ForeColor = Color.Blue
        Me.lblDATEOPEN.ForeColor = Color.Blue
        Me.lblACTIVESTS.ForeColor = Color.Blue
        Me.lblMotherFund.ForeColor = Color.Blue

        'lblFULLCTCK.ForeColor = Color.Blue
        'lblSHORTCKCT.ForeColor = Color.Blue
        '----
        Me.lblPIN.Visible = False
        Me.lblTRADETELEPHONE.Visible = False
        Me.lblCONTRACTNO.Visible = False
        Me.txtCONTRACTNO.Visible = False
        Me.cboTRADETELEPHONE.Visible = False
        Me.txtPIN.Visible = False

        Me.cboPROVINCE.DataSource = mv_PROVINCETable
        Me.cboPROVINCE.DisplayMember = "DISPLAY"
        Me.cboPROVINCE.ValueMember = "VALUE"
        Me.lblPROVINCE.ForeColor = Color.Red
        Me.dtpOPNDATE.Value = CDate(Me.BusDate)

        'lblISCHKONLIMIT.ForeColor = Color.Blue
        Me.LblOlLimit.ForeColor = Color.Red

        MyBase.OnInit()

        LogError.Write("CFMAST.OnInit 1", EventLogEntryType.Information)

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

        'Load interface
        LoadUserInterface(Me)
        'thunt
        LogError.Write("CFMAST.OnInit 2", EventLogEntryType.Information)
        LoadUserInterface(Me.spcAFMAST.Panel1)
        LoadUserInterface(Me.grbCFSIGNinfo)

        LoadUsernameCareby()
        LogError.Write("CFMAST.OnInit 3", EventLogEntryType.Information)
        ' Init Default
        If ExeFlag = ExecuteFlag.AddNew Then

            Me.cboBRID.SelectedValue = BranchId
            Me.btnCURRENTACC_ADD.Enabled = False

            'v_strCmdSQL = "SELECT CDVAL VALUECD, CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY FROM ALLCODE WHERE CDTYPE = 'SY' AND CDNAME = 'YESNO' ORDER BY LSTODR DESC"

            'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            'v_ws.Message(v_strObjMsg)
            'Me.cboISCHKONLIMIT.Clears()
            'FillComboEx(v_strObjMsg, Me.cboISCHKONLIMIT, "", Me.UserLanguage)
            'cboISCHKONLIMIT.SelectedValue = "Y"
            InitDefaultValue()
            'DieuNDA 28/12/2016 Revert phan cua Vu
            'If mv_strISEDIT = "N" Then
            '    txtCUSTID.Enabled = False
            'End If
            'End 
            '21/05/2018 DieuNDA:Them doan tu field so luu ky
            Me.txtCUSTODYCD.Text = getCustodyCD(BranchId)
            Me.txtADDRESS.Text = mv_TRUADDRESS
            'thunt-2019-14-11:thêm tự sinh mã khách hàng
            Dim v_strCustIDTemp As String
            'Kiem tra xem ma tu sinh
            While (1 = 1)
                If Me.txtCUSTID.Text.Length <> 10 Then
                    v_strCustIDTemp = getCustID(BranchId)
                Else
                    v_strCustIDTemp = Me.txtCUSTID.Text
                End If
                If CheckCustID(v_strCustIDTemp) Then
                    Me.txtCUSTID.Text = v_strCustIDTemp
                    Exit While
                Else
                    Me.txtCUSTID.Text = getCustID(BranchId)
                    'MsgBox(ResourceManager.GetString("MsgINVALIDCUSTID"), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)
                    Exit While
                End If
            End While
        End If

        LogError.Write("CFMAST.OnInit Before InitExternal", EventLogEntryType.Information)
        InitExternal()
        LogError.Write("CFMAST.OnInit After InitExternal", EventLogEntryType.Information)

        If ExeFlag <> ExecuteFlag.AddNew Then
            mv_strFullNameVSD = txtFULLNAME.Text
            mv_strAddressVSD = txtADDRESS.Text
            mv_strIDCODEVSD = txtIDCODE.Text
            mv_strIDPLACEVSD = txtIDPLACE.Text
            mv_strIDDATEVSD = dtpIDDATE.Text
            mv_strIDEXPIREDVSD = dtpIDEXPIRED.Text
            mv_strTRADINGCODEDTVSD = dtpTRADINGCODEDT.Text
            mv_strTRADINGCODEVSD = txtTRADINGCODE.Text
            mv_strCustTypeVSD = cboCUSTTYPE.SelectedValue
            'txtTAXCODE.Text = mv_strIDCODEVSD 'thunt : taxcode = idcode

            txtCONTRACTNO.Visible = False
            cboTRADETELEPHONE.Visible = False
            txtPIN.Visible = False
            'cboISCHKONLIMIT.Enabled = False
            TxtOnlineLimit.Enabled = False
            txtCUSTID.Enabled = False
            btnGenCheckCustID.Enabled = False
            'DieuNDA 28/12/2016 Revert lai phan cua Vu
            ''tnVu 11/11/2016
            ''neu la to chuc thi ngay sinh la ngay cap giay phep kinh doanh
            'Dim dt = DateTime.ParseExact(mv_strIDDATEVSD, "dd/MM/yyyy", Nothing)

            'If cboCUSTTYPE.SelectedValue <> "I" Then
            '    If dt <> Nothing Then
            '        dtpDATEOFBIRTH.Value = dt
            '    End If
            'End If
            ''end vu 11/11/2016
            'End DieuNDA 28/12/2016 Revert lai phan cua Vu
            'If txtCUSTODYCD.Text.Length = 10 Then
            '    txtCUSTODYCD.Enabled = False
            '    btnGenCheckCUSTODYCD.Enabled = False
            'Else
            '    If ExeFlag = ExecuteFlag.Edit Then
            '        txtCUSTODYCD.Enabled = True
            '        btnGenCheckCUSTODYCD.Enabled = True
            '    Else
            '        txtCUSTODYCD.Enabled = False
            '        btnGenCheckCUSTODYCD.Enabled = False
            '    End If
            'End If
            'Thoai 13/01/2020
            Try
                v_strCmdSQL = "select check_custodycd('" & txtCUSTODYCD.Text & "') STATUS from dual"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                For v_intCount As Integer = 0 To v_nodeList.Count - 1
                    For v_int As Integer = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                        With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                            Dim v_strfld As String = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                            Dim v_strval As String = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()
                            'DieuNDA 28/12/2016 Revert lai phan cua Vu
                            'If v_strFLDNAME = "ISEDIT" Then
                            '    mv_strISEDIT = v_strVALUE
                            'End If
                            'End DieuNDA 28/12/2016 Revert lai phan cua Vu
                            If v_strfld = "STATUS" Then
                                v_strCheck = v_strval
                            End If
                        End With
                    Next
                Next
                'TanPN 21/2/2020 bỏ And cboACTIVESTS.SelectedValue <> "Y"
                If v_strCheck <> 0 Then
                    txtCUSTODYCD.Enabled = True
                Else
                    txtCUSTODYCD.Enabled = False
                End If
            Catch ex As Exception
                Throw ex
            End Try
            'If Not cboISBANKING.SelectedValue Is DBNull.Value Then
            '    If cboISBANKING.SelectedValue = "Y" Then ' Neu khach hang la ngan hang.
            '        cboCUSTTYPE.SelectedValue = "B"
            '        cboCUSTTYPE.Enabled = False
            '        cboIDTYPE.Enabled = False
            '        txtTRADINGCODE.Enabled = False
            '        lblTRADINGCODE.ForeColor = Color.Blue
            '        dtpTRADINGCODEDT.Enabled = False
            '        lblTRADINGCODEDT.ForeColor = Color.Blue
            '        txtIDCODE.Enabled = False
            '        lblIDCODE.ForeColor = Color.Blue
            '        dtpIDDATE.Enabled = False
            '        lblIDDATE.ForeColor = Color.Blue
            '        dtpIDEXPIRED.Enabled = False
            '        lblIDEXPIRED.ForeColor = Color.Blue
            '        txtIDPLACE.Enabled = False
            '        lblIDPLACE.ForeColor = Color.Blue
            '        txtADDRESS.Enabled = False
            '        lblADDRESS.ForeColor = Color.Blue

            '        'txtSHORTNAME.Enabled = True
            '        lblSHORTNAME.ForeColor = Color.Red


            '        btnAFMAST_ADD.Enabled = False
            '        btnAFMAST_EDIT.Enabled = False
            '        btnAFMAST_VIEW.Enabled = False
            '        btnAFMAST_DELETE.Enabled = False
            '    Else
            '        cboCUSTTYPE.Enabled = True
            '        cboIDTYPE.Enabled = True
            '        If cboIDTYPE.SelectedValue = IDTYPE_TRADINGCODE Then
            '            txtTRADINGCODE.Enabled = True
            '            lblTRADINGCODE.ForeColor = Color.Red
            '            dtpTRADINGCODEDT.Enabled = True
            '            lblTRADINGCODEDT.ForeColor = Color.Red
            '        Else
            '            txtTRADINGCODE.Enabled = False
            '            lblTRADINGCODE.ForeColor = Color.Blue
            '            dtpTRADINGCODEDT.Enabled = False
            '            lblTRADINGCODEDT.ForeColor = Color.Blue
            '        End If
            '        txtIDCODE.Enabled = True
            '        lblIDCODE.ForeColor = Color.Red
            '        dtpIDDATE.Enabled = True
            '        lblIDDATE.ForeColor = Color.Red
            '        dtpIDEXPIRED.Enabled = True
            '        lblIDEXPIRED.ForeColor = Color.Red
            '        txtIDPLACE.Enabled = True
            '        lblIDPLACE.ForeColor = Color.Red
            '        txtADDRESS.Enabled = True
            '        lblADDRESS.ForeColor = Color.Red

            '        'txtSHORTNAME.Enabled = False
            '        lblSHORTNAME.ForeColor = Color.Blue


            '        btnAFMAST_ADD.Enabled = True
            '        btnAFMAST_EDIT.Enabled = True
            '        btnAFMAST_VIEW.Enabled = True
            '        btnAFMAST_DELETE.Enabled = True

            '    End If
            'End If
            If ExeFlag = ExecuteFlag.Edit Then
                btnAFMAST_ADD.Enabled = True
                btnAFMAST_DELETE.Visible = True
                btnAFMAST_EDIT.Enabled = True
                btnAFMAST_VIEW.Enabled = True

                btnCFSIGN_DELETE.Enabled = True
                btnCFSIGN_EDIT.Enabled = True
                btnCFSIGN_VIEW.Enabled = True
                btnCFSIGN_ADD.Enabled = True

                btnCFCONTACT_ADD.Enabled = True
                btnCFCONTACT_DELETE.Enabled = True
                btnCFCONTACT_EDIT.Enabled = True
                btnCFCONTACT_VIEW.Enabled = True

                btnCFRELATION_ADD.Enabled = True
                btnCFRELATION_DELETE.Enabled = True
                btnCFRELATION_EDIT.Enabled = True
                btnCFRELATION_VIEW.Enabled = True

                btnISSUER_ADD.Enabled = True
                btnISSUER_DELETE.Enabled = True
                btnISSUER_EDIT.Enabled = True
                btnISSUER_VIEW.Enabled = True

                btnCFAUTH_ADD.Enabled = True
                btnCFAUTH_DELETE.Enabled = True
                btnCFAUTH_EDIT.Enabled = True
                btnCFAUTH_VIEW.Enabled = True

                btnAP_ADD.Enabled = True
                btnAP_DELETE.Enabled = True
                'btnAP_EDIT.Enabled = True
                'btnAP_VIEW.Enabled = True

                'AnTB 11/02/2015 disable cac nut them, xoa, sua cua man hinh chuyen tien truc tuyen
                '===>> do PHS yeu cau tach rieng man hinh nay thanh GD rieng
                'man hinh tren tab thong tin khach hang chi de xem
                btnCFOTHERACC_ADD.Enabled = True 'True
                btnCFOTHERACC_DELETE.Enabled = True 'True
                btnCFOTHERACC_EDIT.Enabled = True 'True
                btnCFOTHERACC_VIEW.Enabled = True

                btnOTRIGHT_ADD.Enabled = True
                btnOTRIGHT_DELETE.Enabled = True
                btnOTRIGHT_EDIT.Enabled = True
                btnOTRIGHT_VIEW.Enabled = True

                btnEMAILREPORT_ADD.Enabled = True
                btnEMAILREPORT_DELETE.Enabled = True
                btnEMAILREPORT_EDIT.Enabled = True
                btnEMAILREPORT_VIEW.Enabled = True

                btnTEMPLATE_ADD.Enabled = True
                btnTEMPLATE_DELETE.Enabled = True
                btnTEMPLATE_EDIT.Enabled = False
                btnTEMPLATE_VIEW.Enabled = False

                btnCFRPTAFMAST_ADD.Enabled = True
                btnCFRPTAFMAST_DELETE.Enabled = True
                btnCFRPTAFMAST_EDIT.Enabled = True
                btnCFRPTAFMAST_VIEW.Enabled = True

                btnREAFLNK_ADD.Enabled = True
                'btnREAFLNK_DELETE.Enabled = False
                btnREAFLNK_EDIT.Enabled = True
                btnREAFLNK_VIEW.Enabled = True

                dtpVALDATE.Enabled = False
                dtpEXPDATE.Enabled = False
                cboCOUNTRY.Enabled = True
                cboMANAGETYPE.Enabled = True
                cboPROVINCE.Enabled = True
                'cboISBANKING.Enabled = False
                'cboISCHKONLIMIT.Enabled = True
                TxtOnlineLimit.Enabled = True

                btnFABROKERAGE_ADD.Enabled = True
                btnFABROKERAGE_EDIT.Enabled = True
                btnFABROKERAGE_DELETE.Enabled = True
                btnFABROKERAGE_VIEW.Enabled = True

            ElseIf ExeFlag = ExecuteFlag.View OrElse ExeFlag = ExecuteFlag.Approve Then

                btnAFMAST_ADD.Enabled = False
                btnAFMAST_DELETE.Visible = False
                btnAFMAST_EDIT.Enabled = False
                'btnAFMAST_VIEW.Enabled = False

                btnCFSIGN_DELETE.Enabled = False
                btnCFSIGN_EDIT.Enabled = False
                'btnCFSIGN_VIEW.Enabled = False
                btnCFSIGN_ADD.Enabled = False

                btnCFCONTACT_ADD.Enabled = False
                btnCFCONTACT_DELETE.Enabled = False
                btnCFCONTACT_EDIT.Enabled = False
                'btnCFCONTACT_VIEW.Enabled = False

                btnCFRELATION_ADD.Enabled = False
                btnCFRELATION_DELETE.Enabled = False
                btnCFRELATION_EDIT.Enabled = False
                'btnCFRELATION_VIEW.Enabled = False

                btnISSUER_ADD.Enabled = False
                btnISSUER_DELETE.Enabled = False
                btnISSUER_EDIT.Enabled = False
                'btnISSUER_VIEW.Enabled = False

                btnCFAUTH_ADD.Enabled = False
                btnCFAUTH_DELETE.Enabled = False
                btnCFAUTH_EDIT.Enabled = False
                'btnCFAUTH_VIEW.Enabled = True

                btnAP_ADD.Enabled = False
                btnAP_DELETE.Enabled = False
                btnAP_EDIT.Enabled = False

                btnCFOTHERACC_ADD.Enabled = False
                btnCFOTHERACC_DELETE.Enabled = False
                btnCFOTHERACC_EDIT.Enabled = False
                'btnCFOTHERACC_VIEW.Enabled = True

                btnOTRIGHT_ADD.Enabled = False
                btnOTRIGHT_DELETE.Enabled = False
                btnOTRIGHT_EDIT.Enabled = False
                'btnOTRIGHT_VIEW.Enabled = True



                btnTEMPLATE_ADD.Enabled = False
                btnTEMPLATE_DELETE.Enabled = False
                btnTEMPLATE_EDIT.Enabled = False
                'btnTEMPLATE_VIEW.Enabled = True

                btnCFRPTAFMAST_ADD.Enabled = False
                btnCFRPTAFMAST_DELETE.Enabled = False
                btnCFRPTAFMAST_EDIT.Enabled = False
                'btnCFRPTAFMAST_VIEW.Enabled = True

                btnREAFLNK_ADD.Enabled = False
                'btnREAFLNK_DELETE.Enabled = False
                btnREAFLNK_EDIT.Enabled = False
                'btnREAFLNK_VIEW.Enabled = False

                dtpVALDATE.Enabled = False
                dtpEXPDATE.Enabled = False
                cboCOUNTRY.Enabled = False
                cboPROVINCE.Enabled = False
                cboCUSTTYPE.Enabled = False
                cboMANAGETYPE.Enabled = False
                dtpIDDATE.Enabled = False
                dtpIDEXPIRED.Enabled = False
                'cboISBANKING.Enabled = False
                cboIDTYPE.Enabled = False
                'cboISCHKONLIMIT.Enabled = False
                TxtOnlineLimit.Enabled = False
                cboVAT.Enabled = False

                btnFABROKERAGE_ADD.Enabled = False
                btnFABROKERAGE_EDIT.Enabled = False
                btnFABROKERAGE_DELETE.Enabled = False
                btnFABROKERAGE_VIEW.Enabled = True

                btnEMAILREPORT_ADD.Enabled = False
                btnEMAILREPORT_DELETE.Enabled = False
                btnEMAILREPORT_EDIT.Enabled = False
                btnEMAILREPORT_VIEW.Enabled = True
            End If

        Else
            cboTLID.SelectedValue = Me.TellerId
            btnAFMAST_DELETE.Visible = False
            dtpVALDATE.Enabled = False
            dtpEXPDATE.Enabled = False
            txtCONTRACTNO.Visible = False
            cboTRADETELEPHONE.Visible = False
            txtPIN.Visible = False
            'cboISBANKING.Enabled = True
        End If
        mv_blnIsLoading = False

        'If Me.cboISCHKONLIMIT.SelectedValue = "Y" Then
        '    Me.TxtOnlineLimit.Enabled = False
        '    Me.LblOlLimit.Enabled = False
        '    Me.TxtOnlineLimit.Hide()
        '    Me.LblOlLimit.Hide()
        'Else
        '    Me.TxtOnlineLimit.Show()
        '    Me.LblOlLimit.Show()
        '    Me.TxtOnlineLimit.Enabled = True
        '    Me.LblOlLimit.Enabled = True
        'End If
        'Me.txtTAXCODE.Text = Me.txtIDCODE.Text
        'If Me.cboTRADETELEPHONE.SelectedValue = "Y" Then
        '    Me.lblMOBILESMS.ForeColor = Color.Red
        'Else
        '    Me.lblMOBILESMS.ForeColor = Color.Blue


        'End If

        'TanPN 02/03/2020
        If cboCUSTTYPE.SelectedValue = "B" Then
            lblIDCODE.Text = ResourceManager.GetString("BUSINESS_REGISTRATION")
            lblDATEOFBIRTH.Text = ResourceManager.GetString("FOUNDINGDATE")
        Else
            If cboCOUNTRY.SelectedValue = VIETNAMEESE_CODE Then
                lblIDCODE.Text = ResourceManager.GetString("IDCODE")
            Else
                lblIDCODE.Text = ResourceManager.GetString("PASSPORT_IDCODE")
            End If
            lblDATEOFBIRTH.Text = ResourceManager.GetString("DATEOFBIRTH")
        End If

    End Sub

    Private Sub InitDefaultValue()
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strVALUE, v_strCmdSQL As String
        Dim v_strObjMsg As String = String.Empty
        Dim v_strMaxNumber As String = String.Empty
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Try
            txtCUSTID.Text = BranchId

            cboBRID.SelectedValue = BranchId
            'longnh: Khong cho phep nhap them thong tin khi khoi tao
            btnAFMAST_ADD.Enabled = False
            btnCFAUTH_ADD.Enabled = False
            btnAP_ADD.Enabled = False
            btnCFSIGN_ADD.Enabled = False
            btnCFRELATION_ADD.Enabled = False
            btnCFCONTACT_ADD.Enabled = False
            btnISSUER_ADD.Enabled = False
            btnCFOTHERACC_ADD.Enabled = False
            btnOTRIGHT_ADD.Enabled = False
            btnREAFLNK_ADD.Enabled = False
            btnTEMPLATE_ADD.Enabled = False
            btnCFRPTAFMAST_ADD.Enabled = False
            btnFABROKERAGE_ADD.Enabled = False
        Catch ex As Exception
            Throw ex
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

    Private Function LoadUsernameCareby()
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_strCMDSQL, v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Dim v_nodeList As Xml.XmlNodeList
        Try
            If Me.TellerId.Length < 1 Then
                Exit Function
            End If
            'DieuNDA 28/12/2016 Revert lai phan cua Vu
            'v_strCMDSQL = "select br.isedit ISEDIT, tlp.tlname USERNAME from tlprofiles tlp, brgrp br where tlp.brid=br.brid and tlp.tlid = '" & Me.TellerId & "'"
            v_strCMDSQL = "select tlp.tlname USERNAME from tlprofiles tlp where tlp.tlid = '" & Me.TellerId & "'"
            'End DieuNDA 28/12/2016 Revert lai phan cua Vu
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCMDSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For v_intCount As Integer = 0 To v_nodeList.Count - 1
                For v_int As Integer = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                    With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                        Dim v_strFLDNAME As String = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                        Dim v_strVALUE As String = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()
                        'DieuNDA 28/12/2016 Revert lai phan cua Vu
                        'If v_strFLDNAME = "ISEDIT" Then
                        '    mv_strISEDIT = v_strVALUE
                        'End If
                        'End DieuNDA 28/12/2016 Revert lai phan cua Vu
                        If v_strFLDNAME = "USERNAME" Then
                            Me.lblUSERNAME.Text = v_strVALUE
                            Exit Function
                        End If
                    End With
                Next
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub OnSubmit()
        Dim v_strTxMsg As String, v_xmlDocument As New Xml.XmlDocument, v_attrColl As Xml.XmlAttributeCollection
        Dim v_intNOSUBMIT As Integer, v_strNEXTTX As String = String.Empty
        Dim v_strErrorSource, v_strErrorMessage As String, v_lngError As Long
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Try
            'Control Validate
            If Not ControlValidation() Then
                Exit Sub
            End If
            'Ä?Ã£ nháº­p thÃ´ng tin trÃªn mÃ n hÃ¬nh vÃ  submit gá»­i lÃªn APP-SERVER Ä‘á»ƒ xá»­ lÃ½
            'Khá»Ÿi táº¡o Ä‘iá»‡n giao dá»‹ch
            MessageData = vbNullString
            'Verify vÃ  táº¡o Ä‘iá»‡n giao dá»‹ch

            If Not VerifyCFRules(v_strTxMsg) Then
                Exit Sub
            Else
                MessageData = v_strTxMsg
            End If
            'Ä?áº©y Ä‘iá»‡n giao dá»‹ch lÃªn APP-SERVER
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
                'Thong bao approve thanh cong
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
        End Try
    End Sub

    Private Function VerifyCFRules(ByRef v_strTxMsg As String) As Boolean
        Try
            Dim v_strMessage As String = String.Empty
            Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
            Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode, v_intIndex As Long, i, v_intCount As Integer
            Dim v_strFLDNAME As String, v_strFLDDEFNAME As String, v_strDATATYPE As String, v_strFLDVALUE As String
            Dim v_strERRMSG, v_strENERRMSG, v_strOPERATOR, v_strVALEXP, v_strVALEXP2 As String, v_strACTYPE, v_strDESC As String
            Dim v_dtVALEXP, v_dtVALEXP2, v_dtFLDVALUE As Date, v_strCMDSQL As String
            Dim v_ctl As Control, v_attrFLDNAME As Xml.XmlAttribute, v_attrDATATYPE As Xml.XmlAttribute, v_objEval As New Evaluator

            'Táº¡o Ä‘iá»‡n giao dá»‹ch

            'Tạo điện giao dịch
            Select Case v_strSender
                Case "btnREFUSE"
                    v_strMessage = "Refuse customer profile:"
                    LoadScreen(gc_CF_REFUSEPROFILE)
                    v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, gc_CF_REFUSEPROFILE, Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)
                Case "btnREJECT"
                    v_strMessage = "Reject customer profile:"
                    LoadScreen(gc_CF_REJECTPROFILE)
                    v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, gc_CF_REJECTPROFILE, Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)
                Case "btnAPPROVE"
                    v_strMessage = "Approve customer profile:"
                    LoadScreen(gc_CF_APPROVEPROFILE)
                    v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, gc_CF_APPROVEPROFILE, Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)
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
                                v_strFLDVALUE = Trim(Strings.Replace(Me.txtCUSTID.Text, ".", String.Empty))
                            Case "30" 'DESC                                              
                                v_strFLDVALUE = v_strMessage & Me.txtCUSTID.Text & ":" & Me.txtFULLNAME.Text
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
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
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

    Public Overrides Sub OnSave()
        Dim v_strObjMsg As String
        Dim v_strSQL As String
        Dim v_wa As New BDSDeliveryManagement
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Dim v_tradingcode As String
        Try
            Select Case ExeFlag
                Case ExecuteFlag.Edit
                    If Me.cboSTATUS.SelectedValue = "E" Then
                        Me.cboSTATUS.SelectedValue = "P"
                    End If
            End Select

            'Update mouse pointer
            Cursor.Current = Cursors.WaitCursor
            If Not ControlValidation(True) Then
                Exit Sub
            End If

            If cboCUSTATCOM.SelectedValue = "Y" Then
                'HaiLT Bo check VSD voi Noi cap CMND (Or (mv_strIDPLACEVSD <> txtIDPLACE.Text) )
                'SonLT Bo check VSD voi ngay cap va thoi gian het han Or (mv_strIDEXPIREDVSD <> dtpIDEXPIRED.Text) Or (mv_strIDDATEVSD <> dtpIDDATE.Text)
                If ExeFlag <> ExecuteFlag.AddNew And cboACTIVESTS.SelectedValue = "Y" And ((mv_strFullNameVSD <> txtFULLNAME.Text) Or (mv_strAddressVSD <> txtADDRESS.Text) Or (mv_strIDCODEVSD <> txtIDCODE.Text) Or (mv_strTRADINGCODEDTVSD <> dtpTRADINGCODEDT.Text) Or (mv_strTRADINGCODEVSD <> txtTRADINGCODE.Text) Or (mv_strCustTypeVSD <> cboCUSTTYPE.SelectedValue)) Then
                    MsgBox(ResourceManager.GetString("msgCHECKVSDRULE"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    'Me.txtFULLNAME.Focus()
                    Exit Sub
                End If
            End If

            ' dia chi do dai phai hon 15
            'longnh
            'SHBVNEX-2289
            'Select Case ExeFlag
            '    Case ExecuteFlag.AddNew
            '        If Not (Len(Me.txtADDRESS.Text.Trim) >= 15) Then
            '            MsgBox(ResourceManager.GetString("msgCHECKADDRESS"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
            '            Me.txtADDRESS.Focus()
            '            Exit Sub
            '        End If
            'End Select


            'Neu loai khach hang la To chuc thi bat buoc phai nhap ma so thue
            'If cboCUSTTYPE.SelectedValue = "B" And txtTAXCODE.TextLength = 0 Then
            '    MsgBox(ResourceManager.GetString("msgTAXCODE"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
            '    Me.txtTAXCODE.Focus()
            '    Exit Sub
            'End If
            If cboCUSTTYPE.SelectedValue = "B" And txtTAXCODE.TextLength = 0 Then
                Dim result As DialogResult = MessageBox.Show(ResourceManager.GetString("msgTAXCODE"), gc_ApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If result = DialogResult.No Then
                    Me.txtTAXCODE.Focus()
                    Exit Sub
                End If
            End If

            'Check 6 ky tu dau tien cua Trading code phai tuong tu nhu 6 ky tu cuoi cua so luu ky.
            'txtTRADINGCODE.Text = v_tradingcode
            If Len(Me.txtTRADINGCODE.Text.Trim) > 0 And Len(Me.txtCUSTODYCD.Text.Trim) > 0 Then
                If Not (Len(Me.txtCUSTODYCD.Text.Trim) >= 6 AndAlso Len(Me.txtTRADINGCODE.Text.Trim) >= 6 AndAlso Me.txtTRADINGCODE.Text.ToUpper.Substring(0, 6) = Me.txtCUSTODYCD.Text.ToUpper.Substring(Len(Me.txtCUSTODYCD.Text.Trim) - 6, 6)) Then
                    MsgBox(ResourceManager.GetString("msgCHECKTRADINGCODE"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Me.txtTRADINGCODE.Focus()
                    Exit Sub
                End If
                If ExecuteFlag.AddNew Then
                    If Me.txtCUSTODYCD.Text.Trim.Substring(1, 3) = mv_PrefixCustodyCD And Not txtTRADINGCODE.Text Is DBNull.Value Then
                        If cboCOUNTRY.SelectedValue = VIETNAMEESE_CODE Then
                            MsgBox(ResourceManager.GetString("MsgSUBACCOUNTISFOREIGN"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Me.cboCOUNTRY.Focus()
                            Exit Sub
                        End If
                        If cboIDTYPE.SelectedValue = IDTYPE_CMND Then
                            MsgBox(ResourceManager.GetString("MsgTRADINGCODEISFOREIGN"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            Exit Sub
                        End If
                    End If
                End If
            End If



            'Kiem tra dinh dang Email phai hop le
            'If(LoadOTRIGHT(Me.txtCUSTID.Text) <> 

            If Trim(Me.txtEMAIL.Text).Length > 0 Then
                If InStr(Trim(Me.txtEMAIL.Text), " ") > 0 Or InStr(Trim(Me.txtEMAIL.Text), "@") <= 0 Or InStr(Mid(Trim(Me.txtEMAIL.Text), InStr(Trim(Me.txtEMAIL.Text), "@") + 1), ".") <= 0 Then
                    MsgBox(ResourceManager.GetString("msgINVALIDEMAILFORMAT"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Me.txtEMAIL.Focus()
                    Exit Sub
                End If
            End If

            Select Case ExeFlag
                Case ExecuteFlag.AddNew
                    Me.txtEXPERIENCECD.Text = GetExperiencecd()
                Case ExecuteFlag.Edit
                    Me.txtEXPERIENCECD.Text = GetExperiencecd()
            End Select
            MyBase.OnSave()
            If Not DoDataExchange(True) Then
                Exit Sub
            End If

            If (Trim(txtCUSTODYCD.Text) <> "") Then
                If Not VerifyCustodyCodeBeforeAdd() Then
                    Exit Sub
                End If
            End If

            Select Case ExeFlag
                Case ExecuteFlag.AddNew
                    Dim v_strClause As String = KeyFieldName & " = '" & txtCUSTID.Text & "'"
                    v_strObjMsg = BuildXMLObjMsg(Me.BusDate, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdd, , v_strClause, , gc_AutoIdUnused)
                    BuildXMLObjData(mv_dsInput, v_strObjMsg)
                    Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                    Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                    'Kiá»ƒm tra thÃ´ng tin vÃ  xá»­ lÃ½ lá»—i (náº¿u cÃ³) tá»« message tráº£ vá»?
                    Dim v_strErrorSource, v_strErrorMessage As String

                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Sub
                    End If
                    MsgBox(ResourceManager.GetString("AddnewSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    If v_strSender <> "btnApply" Then
                        Me.DialogResult = DialogResult.OK
                        MyBase.OnClose()
                    Else
                        v_strSender = ""
                        KeyFieldValue = GetControlValueByName(KeyFieldName, Me)
                        ExeFlag = ExecuteFlag.Edit
                        LoadUserInterface(Me)
                        mv_dsOldInput = mv_dsInput
                    End If

                Case ExecuteFlag.Edit
                    Dim v_strClause As String

                    Select Case KeyFieldType
                        Case "C"
                            v_strClause = KeyFieldName & " = '" & KeyFieldValue & "'"
                        Case "D"
                            v_strClause = KeyFieldName & " = TO_DATE('" & KeyFieldValue & "', '" & gc_FORMAT_DATE & "')"
                        Case "N"
                            v_strClause = KeyFieldName & " = " & KeyFieldValue.ToString()
                    End Select

                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionEdit, , v_strClause)
                    BuildXMLObjData(mv_dsInput, v_strObjMsg, mv_dsOldInput, ExecuteFlag.Edit)

                    Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                    Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                    'Kiá»ƒm tra thÃ´ng tin vÃ  xá»­ lÃ½ lá»—i (náº¿u cÃ³) tá»« message tráº£ vá»?
                    Dim v_strErrorSource, v_strErrorMessage As String

                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Sub
                    End If

                    MsgBox(ResourceManager.GetString("EditSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    'Me.DialogResult = DialogResult.OK
                    'MyBase.OnClose()
                    If v_strSender <> "btnApply" Then
                        Me.DialogResult = DialogResult.OK
                        MyBase.OnClose()
                    Else
                        v_strSender = ""
                        LoadUserInterface(Me)
                    End If
            End Select

            'Update mouse pointer
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("SavingFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Public Overrides Function DoDataExchange(Optional ByVal pv_blnSaved As Boolean = False) As Boolean
        Try
            Return MyBase.DoDataExchange(pv_blnSaved)
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function

    Private Function VerifyCustodyCodeBeforeAdd() As Boolean
        Dim v_blnDORF, v_blnIOC As Boolean
        Dim v_strReturn As String = String.Empty
        Dim v_strCustAtCom As String
        Dim v_strSQL As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strVALUE As String
        Try

            'If v_strCOUNTRY.Trim() <> "VNM" Then
            If cboCOUNTRY.SelectedValue <> VIETNAMEESE_CODE Then
                v_blnDORF = True
            Else
                v_blnDORF = False
            End If

            If cboCUSTTYPE.SelectedValue = "I" Then
                v_blnIOC = True
            Else
                v_blnIOC = False
            End If

            Dim v_strPrefixCustodyCD As String = AppSettings.Get("PrefixedCustodyCode")
            v_strCustAtCom = Me.cboCUSTATCOM.SelectedValue

            v_strReturn = VerifyCustodyCode(Me.txtCUSTODYCD.Text.Replace(".", ""), v_blnDORF, v_blnIOC, v_strCustAtCom, v_strPrefixCustodyCD, ExeFlag)

            If Not v_strReturn Is Nothing Then
                If v_strReturn = "CUSTODYCD_FOREIGN_CHARACTER" Then
                    Dim result As DialogResult = MessageBox.Show(ResourceManager.GetString(v_strReturn), gc_ApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    If result = DialogResult.Yes Then
                        Return True
                    Else
                        Me.txtCUSTODYCD.Focus()
                        Return False
                    End If
                Else
                    MsgBox(ResourceManager.GetString(v_strReturn), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Return False
                End If
            End If

            Dim v_strCount As String
            Dim v_lngError As Long = ERR_SYSTEM_OK

            Try
                If txtCUSTODYCD.Text.Length > 4 Then
                    'TanPN 05/03/2020 kiem tra xem so luu ky da ton tai hay chua
                    v_strSQL = "SELECT count(1) COUNT FROM CFMAST WHERE  CUSTODYCD='" & Me.txtCUSTODYCD.Text.Replace(".", "") & "'"
                    If ExeFlag <> ExecuteFlag.AddNew Then
                        v_strSQL = v_strSQL + " and CUSTID <>'" + Me.txtCUSTID.Text.Trim + "'"
                    End If
                    Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strSQL)
                    v_lngError = v_ws.Message(v_strObjMsg)
                    If v_lngError = ERR_SYSTEM_OK Then
                        v_xmlDocument.LoadXml(v_strObjMsg)
                        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                        If v_nodeList.Count = 1 Then
                            v_strCount = v_nodeList.Item(0).ChildNodes(0).InnerText.ToString
                        End If
                    End If

                    If CDbl(v_strCount) <> 0 Then
                        MsgBox(ResourceManager.GetString("MsgINVALIDCUSTODYCD"), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)
                        txtCUSTODYCD.Focus()
                        Return False
                    End If
                End If

            Catch ex As Exception
                LogError.Write("Error source: " & ex.Source & vbNewLine _
                            & "Error code: System error!" & vbNewLine _
                            & "Error message: " & ex.Message, EventLogEntryType.Error)
                MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            End Try

            Return True

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                        & "Error code: System error!" & vbNewLine _
                        & "Error message: " & ex.Message, EventLogEntryType.Error)
            Return False
        End Try
    End Function

    Private Sub InitExternal()
        'Khoi tao Grid AFMAST
        AFMASTGrid = New GridEx
        Dim v_cmrMemberHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrMemberHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrMemberHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        AFMASTGrid.FixedHeaderRows.Add(v_cmrMemberHeader)
        v_cmrMemberHeader.Height = 32

        AFMASTGrid.Columns.Add(New Xceed.Grid.Column("AFACCTNO", GetType(System.String)))
        'AFMASTGrid.Columns.Add(New Xceed.Grid.Column("ACTYPE", GetType(System.String)))
        'AFMASTGrid.Columns.Add(New Xceed.Grid.Column("TYPENAME", GetType(System.String)))
        AFMASTGrid.Columns.Add(New Xceed.Grid.Column("STATUS", GetType(System.String)))
        AFMASTGrid.Columns.Add(New Xceed.Grid.Column("COREBANK", GetType(System.String)))
        AFMASTGrid.Columns.Add(New Xceed.Grid.Column("AUTOADV", GetType(System.String)))
        'AFMASTGrid.Columns.Add(New Xceed.Grid.Column("MRTYPE", GetType(System.String)))

        'AFMASTGrid.Columns.Add(New Xceed.Grid.Column("CITYPE", GetType(System.String)))
        AFMASTGrid.Columns.Add(New Xceed.Grid.Column("BANKNAME", GetType(System.String)))
        AFMASTGrid.Columns.Add(New Xceed.Grid.Column("BANKACCTNO", GetType(System.String)))
        'AFMASTGrid.Columns.Add(New Xceed.Grid.Column("AUTOTRF", GetType(System.String)))

        AFMASTGrid.Columns("AFACCTNO").Title = ResourceManager.GetString("AFMASTgrid.AFACCTNO")
        'AFMASTGrid.Columns("ACTYPE").Title = ResourceManager.GetString("AFMASTgrid.ACTYPE")
        'AFMASTGrid.Columns("TYPENAME").Title = ResourceManager.GetString("AFMASTgrid.TYPENAME")
        AFMASTGrid.Columns("STATUS").Title = ResourceManager.GetString("AFMASTgrid.STATUS")
        AFMASTGrid.Columns("COREBANK").Title = ResourceManager.GetString("AFMASTgrid.COREBANK")
        AFMASTGrid.Columns("AUTOADV").Title = ResourceManager.GetString("AFMASTgrid.AUTOADV")
        'AFMASTGrid.Columns("MRTYPE").Title = ResourceManager.GetString("AFMASTgrid.MRTYPE")
        'AFMASTGrid.Columns("CITYPE").Title = ResourceManager.GetString("AFMASTgrid.CITYPE")
        AFMASTGrid.Columns("BANKNAME").Title = ResourceManager.GetString("AFMASTgrid.BANKNAME")
        AFMASTGrid.Columns("BANKACCTNO").Title = ResourceManager.GetString("AFMASTgrid.BANKACCTNO")
        'AFMASTGrid.Columns("AUTOTRF").Title = ResourceManager.GetString("AFMASTgrid.AUTOTRF")

        AFMASTGrid.Columns("AFACCTNO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        'AFMASTGrid.Columns("ACTYPE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        'AFMASTGrid.Columns("TYPENAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        AFMASTGrid.Columns("STATUS").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        AFMASTGrid.Columns("COREBANK").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        AFMASTGrid.Columns("AUTOADV").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        'AFMASTGrid.Columns("MRTYPE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        'AFMASTGrid.Columns("CITYPE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        AFMASTGrid.Columns("BANKNAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        AFMASTGrid.Columns("BANKACCTNO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        'AFMASTGrid.Columns("AUTOTRF").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left

        Me.spcAFMAST.Panel2.Controls.Clear()
        Me.spcAFMAST.Panel2.Controls.Add(AFMASTGrid)
        AFMASTGrid.Dock = Windows.Forms.DockStyle.Fill

        AddHandler AFMASTGrid.DoubleClick, AddressOf AFMASTGrid_Click
        If Me.AFMASTGrid.DataRowTemplate.Cells.Count >= 0 Then
            For i As Integer = 0 To Me.AFMASTGrid.DataRowTemplate.Cells.Count - 1
                AddHandler AFMASTGrid.DataRowTemplate.Cells(i).DoubleClick, AddressOf AFMASTGrid_Click
            Next
        End If


        'Khoi tao Grid CFRELATION
        CFRELATIONGrid = New GridEx
        Dim v_cmrCFRELATIONHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrCFRELATIONHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrCFRELATIONHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        v_cmrCFRELATIONHeader.Height = 32
        CFRELATIONGrid.FixedHeaderRows.Add(v_cmrCFRELATIONHeader)

        CFRELATIONGrid.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(Integer)))
        CFRELATIONGrid.Columns.Add(New Xceed.Grid.Column("ACTIVES", GetType(System.String))) 'thunt-2019-25-09
        CFRELATIONGrid.Columns.Add(New Xceed.Grid.Column("TITLECFRELATION", GetType(System.String)))
        CFRELATIONGrid.Columns.Add(New Xceed.Grid.Column("RETYPE", GetType(System.String)))
        CFRELATIONGrid.Columns.Add(New Xceed.Grid.Column("RECUSTID", GetType(System.String)))
        CFRELATIONGrid.Columns.Add(New Xceed.Grid.Column("FULLNAME", GetType(System.String)))
        CFRELATIONGrid.Columns.Add(New Xceed.Grid.Column("LICENSENO", GetType(System.String)))
        CFRELATIONGrid.Columns.Add(New Xceed.Grid.Column("ADDRESS", GetType(System.String)))
        CFRELATIONGrid.Columns.Add(New Xceed.Grid.Column("TELEPHONE", GetType(System.String)))
        CFRELATIONGrid.Columns.Add(New Xceed.Grid.Column("LNPLACE", GetType(System.String)))
        CFRELATIONGrid.Columns.Add(New Xceed.Grid.Column("LNIDDATE", GetType(System.String)))
        CFRELATIONGrid.Columns.Add(New Xceed.Grid.Column("ACDATE", GetType(System.String)))
        CFRELATIONGrid.Columns.Add(New Xceed.Grid.Column("DESCRIPTION", GetType(System.String)))


        CFRELATIONGrid.Columns("AUTOID").Title = ResourceManager.GetString("CFRELATIONGrid.AUTOID")
        CFRELATIONGrid.Columns("ACTIVES").Title = ResourceManager.GetString("CFRELATIONGrid.ACTIVES") 'thunt-2019-25-09
        CFRELATIONGrid.Columns("TITLECFRELATION").Title = ResourceManager.GetString("CFRELATIONGrid.TITLECFRELATION")
        CFRELATIONGrid.Columns("RETYPE").Title = ResourceManager.GetString("CFRELATIONGrid.RETYPE")
        CFRELATIONGrid.Columns("RECUSTID").Title = ResourceManager.GetString("CFRELATIONGrid.RECUSTID")
        CFRELATIONGrid.Columns("DESCRIPTION").Title = ResourceManager.GetString("CFRELATIONGrid.DESCRIPTION")
        CFRELATIONGrid.Columns("FULLNAME").Title = ResourceManager.GetString("CFRELATIONGrid.FULLNAME")
        CFRELATIONGrid.Columns("LICENSENO").Title = ResourceManager.GetString("CFRELATIONGrid.LICENSENO")
        CFRELATIONGrid.Columns("ADDRESS").Title = ResourceManager.GetString("CFRELATIONGrid.ADDRESS")
        CFRELATIONGrid.Columns("TELEPHONE").Title = ResourceManager.GetString("CFRELATIONGrid.TELEPHONE")
        CFRELATIONGrid.Columns("LNPLACE").Title = ResourceManager.GetString("CFRELATIONGrid.LNPLACE")
        CFRELATIONGrid.Columns("LNIDDATE").Title = ResourceManager.GetString("CFRELATIONGrid.LNIDDATE")
        CFRELATIONGrid.Columns("ACDATE").Title = ResourceManager.GetString("CFRELATIONGrid.ACDATE")


        CFRELATIONGrid.Columns("AUTOID").Width = 0
        CFRELATIONGrid.Columns("RETYPE").Width = 300
        CFRELATIONGrid.Columns("TITLECFRELATION").Width = 150
        CFRELATIONGrid.Columns("FULLNAME").Width = 300
        CFRELATIONGrid.Columns("DESCRIPTION").Width = 300
        CFRELATIONGrid.Columns("ADDRESS").Width = 300

        CFRELATIONGrid.Columns("AUTOID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        CFRELATIONGrid.Columns("ACTIVES").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left 'thunt-2019-25-09
        CFRELATIONGrid.Columns("TITLECFRELATION").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        CFRELATIONGrid.Columns("RETYPE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        CFRELATIONGrid.Columns("RECUSTID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        CFRELATIONGrid.Columns("DESCRIPTION").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        CFRELATIONGrid.Columns("FULLNAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        CFRELATIONGrid.Columns("LICENSENO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        CFRELATIONGrid.Columns("ADDRESS").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        CFRELATIONGrid.Columns("TELEPHONE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        CFRELATIONGrid.Columns("LNIDDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        CFRELATIONGrid.Columns("LNPLACE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        CFRELATIONGrid.Columns("ACDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left

        Me.spcCFRELATION.Panel2.Controls.Clear()
        Me.spcCFRELATION.Panel2.Controls.Add(CFRELATIONGrid)
        CFRELATIONGrid.Dock = Windows.Forms.DockStyle.Fill

        'Khoi tao Grid AFMAST
        CFCONTACTGrid = New GridEx
        Dim v_cmrCFCONTACTHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrCFCONTACTHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrCFCONTACTHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        v_cmrCFCONTACTHeader.Height = 32
        CFCONTACTGrid.FixedHeaderRows.Add(v_cmrCFCONTACTHeader)

        CFCONTACTGrid.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(Integer)))
        CFCONTACTGrid.Columns.Add(New Xceed.Grid.Column("TITLECONTACT", GetType(System.String)))
        CFCONTACTGrid.Columns.Add(New Xceed.Grid.Column("CONTACTTYPE", GetType(System.String)))
        CFCONTACTGrid.Columns.Add(New Xceed.Grid.Column("PERSON", GetType(System.String)))
        CFCONTACTGrid.Columns.Add(New Xceed.Grid.Column("ADDRESS", GetType(System.String)))
        CFCONTACTGrid.Columns.Add(New Xceed.Grid.Column("PHONE", GetType(System.String)))
        CFCONTACTGrid.Columns.Add(New Xceed.Grid.Column("FAX", GetType(System.String)))
        CFCONTACTGrid.Columns.Add(New Xceed.Grid.Column("EMAIL", GetType(System.String)))
        CFCONTACTGrid.Columns.Add(New Xceed.Grid.Column("DESCRIPTION", GetType(System.String)))

        CFCONTACTGrid.Columns("AUTOID").Title = ResourceManager.GetString("CFCONTACTGrid.AUTOID")
        CFCONTACTGrid.Columns("TITLECONTACT").Title = ResourceManager.GetString("CFCONTACTGrid.TITLECONTACT")
        CFCONTACTGrid.Columns("CONTACTTYPE").Title = ResourceManager.GetString("CFCONTACTGrid.CONTACTTYPE")
        CFCONTACTGrid.Columns("PERSON").Title = ResourceManager.GetString("CFCONTACTGrid.PERSON")
        CFCONTACTGrid.Columns("ADDRESS").Title = ResourceManager.GetString("CFCONTACTGrid.ADDRESS")
        CFCONTACTGrid.Columns("PHONE").Title = ResourceManager.GetString("CFCONTACTGrid.PHONE")
        CFCONTACTGrid.Columns("FAX").Title = ResourceManager.GetString("CFCONTACTGrid.FAX")
        CFCONTACTGrid.Columns("EMAIL").Title = ResourceManager.GetString("CFCONTACTGrid.EMAIL")
        CFCONTACTGrid.Columns("DESCRIPTION").Title = ResourceManager.GetString("CFCONTACTGrid.DESCRIPTION")

        CFCONTACTGrid.Columns("AUTOID").Width = 0
        CFCONTACTGrid.Columns("TITLECONTACT").Width = 150
        CFCONTACTGrid.Columns("ADDRESS").Width = 300
        CFCONTACTGrid.Columns("PERSON").Width = 300
        CFCONTACTGrid.Columns("DESCRIPTION").Width = 300
        CFCONTACTGrid.Columns("EMAIL").Width = 150
        CFCONTACTGrid.Columns("AUTOID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        CFCONTACTGrid.Columns("TITLECONTACT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        CFCONTACTGrid.Columns("CONTACTTYPE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        CFCONTACTGrid.Columns("PERSON").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        CFCONTACTGrid.Columns("ADDRESS").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        CFCONTACTGrid.Columns("PHONE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        CFCONTACTGrid.Columns("FAX").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        CFCONTACTGrid.Columns("EMAIL").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        CFCONTACTGrid.Columns("DESCRIPTION").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left

        Me.spcCFCONTACT.Panel2.Controls.Clear()
        Me.spcCFCONTACT.Panel2.Controls.Add(CFCONTACTGrid)
        CFCONTACTGrid.Dock = Windows.Forms.DockStyle.Fill

        'Khoi tao Grid AFMAST
        ISSUERGrid = New GridEx
        Dim v_cmrISSUERHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrISSUERHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrISSUERHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        v_cmrISSUERHeader.Height = 32
        ISSUERGrid.FixedHeaderRows.Add(v_cmrISSUERHeader)


        ISSUERGrid.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(Integer)))
        ISSUERGrid.Columns.Add(New Xceed.Grid.Column("CUSTID", GetType(System.String)))
        ISSUERGrid.Columns.Add(New Xceed.Grid.Column("FULLNAME", GetType(System.String)))
        ISSUERGrid.Columns.Add(New Xceed.Grid.Column("ROLECD", GetType(System.String)))
        ISSUERGrid.Columns.Add(New Xceed.Grid.Column("LICENSENO", GetType(System.String)))
        ISSUERGrid.Columns.Add(New Xceed.Grid.Column("IDDATE", GetType(System.String)))
        ISSUERGrid.Columns.Add(New Xceed.Grid.Column("IDEXPIRED", GetType(System.String)))
        ISSUERGrid.Columns.Add(New Xceed.Grid.Column("IDPLACE", GetType(System.String)))
        ISSUERGrid.Columns.Add(New Xceed.Grid.Column("DESCRIPTION", GetType(System.String)))



        ISSUERGrid.Columns("AUTOID").Title = ResourceManager.GetString("ISSUERGrid.AUTOID")
        ISSUERGrid.Columns("CUSTID").Title = ResourceManager.GetString("ISSUERGrid.CUSTID")
        ISSUERGrid.Columns("FULLNAME").Title = ResourceManager.GetString("ISSUERGrid.ISS_FULLNAME")
        ISSUERGrid.Columns("ROLECD").Title = ResourceManager.GetString("ISSUERGrid.ROLECD")
        ISSUERGrid.Columns("LICENSENO").Title = ResourceManager.GetString("ISSUERGrid.LICENSENO")
        ISSUERGrid.Columns("IDDATE").Title = ResourceManager.GetString("ISSUERGrid.IDDATE")
        ISSUERGrid.Columns("IDEXPIRED").Title = ResourceManager.GetString("ISSUERGrid.IDEXPIRED")
        ISSUERGrid.Columns("IDPLACE").Title = ResourceManager.GetString("ISSUERGrid.IDPLACE")
        ISSUERGrid.Columns("DESCRIPTION").Title = ResourceManager.GetString("ISSUERGrid.DESCRIPTION")


        ISSUERGrid.Columns("AUTOID").Width = 0
        ISSUERGrid.Columns("FULLNAME").Width = 300
        ISSUERGrid.Columns("DESCRIPTION").Width = 300

        ISSUERGrid.Columns("CUSTID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        ISSUERGrid.Columns("FULLNAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ISSUERGrid.Columns("ROLECD").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ISSUERGrid.Columns("LICENSENO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ISSUERGrid.Columns("IDDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ISSUERGrid.Columns("IDEXPIRED").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ISSUERGrid.Columns("IDPLACE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        ISSUERGrid.Columns("DESCRIPTION").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left

        Me.spcISSUER.Panel2.Controls.Clear()
        Me.spcISSUER.Panel2.Controls.Add(ISSUERGrid)
        ISSUERGrid.Dock = Windows.Forms.DockStyle.Fill


        CFAUTHGrid = New GridEx
        Dim v_cmrCFAUTHHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrCFAUTHHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrCFAUTHHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        v_cmrCFAUTHHeader.Height = 32
        'Loại UQ – Tên – Địa chỉ - Email – Ngày hiệu lực – Trạng thái (Hoạt động/ Đóng) 
        'Tương tự ở bản tiếng Anh:
        'Authorized type – Name – Address – Email – Effective date – Status (Active/ Inactive)
        CFAUTHGrid.FixedHeaderRows.Add(v_cmrCFAUTHHeader)
        CFAUTHGrid.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(Integer)))
        CFAUTHGrid.Columns.Add(New Xceed.Grid.Column("AUTHTYPE", GetType(System.String)))
        'CFAUTHGrid.Columns.Add(New Xceed.Grid.Column("CUSTID", GetType(System.String)))
        CFAUTHGrid.Columns.Add(New Xceed.Grid.Column("TITLE", GetType(System.String)))
        CFAUTHGrid.Columns.Add(New Xceed.Grid.Column("FULLNAME", GetType(System.String)))
        'CFAUTHGrid.Columns.Add(New Xceed.Grid.Column("LICENSENO", GetType(System.String)))
        CFAUTHGrid.Columns.Add(New Xceed.Grid.Column("ADDRESS", GetType(System.String)))
        'CFAUTHGrid.Columns.Add(New Xceed.Grid.Column("TELEPHONE", GetType(System.String)))
        CFAUTHGrid.Columns.Add(New Xceed.Grid.Column("EMAIL", GetType(System.String)))
        CFAUTHGrid.Columns.Add(New Xceed.Grid.Column("VALDATE", GetType(System.String)))
        'CFAUTHGrid.Columns.Add(New Xceed.Grid.Column("EXPDATE", GetType(System.String)))
        'CFAUTHGrid.Columns.Add(New Xceed.Grid.Column("LNPLACE", GetType(System.String)))
        'CFAUTHGrid.Columns.Add(New Xceed.Grid.Column("LNIDDATE", GetType(System.String)))
        CFAUTHGrid.Columns.Add(New Xceed.Grid.Column("DELTD", GetType(System.String)))
        CFAUTHGrid.Columns.Add(New Xceed.Grid.Column("DELTDDESC", GetType(System.String)))
        'CFAUTHGrid.Columns.Add(New Xceed.Grid.Column("SHV", GetType(System.String)))
        'Tantv thêm trường trạng thái

        CFAUTHGrid.Columns("AUTOID").Title = ResourceManager.GetString("CFAUTHGrid.AUTOID")
        CFAUTHGrid.Columns("AUTHTYPE").Title = ResourceManager.GetString("CFAUTHGrid.AUTHTYPE")
        'CFAUTHGrid.Columns("CUSTID").Title = ResourceManager.GetString("CFAUTHGrid.CUSTID")
        CFAUTHGrid.Columns("TITLE").Title = ResourceManager.GetString("CFAUTHGrid.TITLE")
        CFAUTHGrid.Columns("FULLNAME").Title = ResourceManager.GetString("CFAUTHGrid.FULLNAME")
        'CFAUTHGrid.Columns("LICENSENO").Title = ResourceManager.GetString("CFAUTHGrid.LICENSENO")
        CFAUTHGrid.Columns("ADDRESS").Title = ResourceManager.GetString("CFAUTHGrid.ADDRESS")
        'CFAUTHGrid.Columns("TELEPHONE").Title = ResourceManager.GetString("CFAUTHGrid.TELEPHONE")
        CFAUTHGrid.Columns("EMAIL").Title = ResourceManager.GetString("CFAUTHGrid.EMAIL")
        CFAUTHGrid.Columns("VALDATE").Title = ResourceManager.GetString("CFAUTHGrid.VALDATE")
        'CFAUTHGrid.Columns("EXPDATE").Title = ResourceManager.GetString("CFAUTHGrid.EXPDATE")
        'CFAUTHGrid.Columns("LNPLACE").Title = ResourceManager.GetString("CFAUTHGrid.LNPLACE")
        'CFAUTHGrid.Columns("LNIDDATE").Title = ResourceManager.GetString("CFAUTHGrid.LNIDDATE")
        CFAUTHGrid.Columns("DELTDDESC").Title = ResourceManager.GetString("CFAUTHGrid.DELTD")
        'CFAUTHGrid.Columns("SHV").Title = ResourceManager.GetString("CFAUTHGrid.SHV")

        CFAUTHGrid.Columns("AUTOID").Width = 0
        CFAUTHGrid.Columns("TITLE").Width = 150
        CFAUTHGrid.Columns("FULLNAME").Width = 300
        CFAUTHGrid.Columns("ADDRESS").Width = 300
        'CFAUTHGrid.Columns("CUSTID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        CFAUTHGrid.Columns("TITLE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        CFAUTHGrid.Columns("FULLNAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        'CFAUTHGrid.Columns("LICENSENO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        CFAUTHGrid.Columns("ADDRESS").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        'CFAUTHGrid.Columns("TELEPHONE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        CFAUTHGrid.Columns("EMAIL").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        CFAUTHGrid.Columns("VALDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        'CFAUTHGrid.Columns("EXPDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        'CFAUTHGrid.Columns("LNPLACE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        CFAUTHGrid.Columns("DELTD").Visible = False

        Me.spcCFAUTH.Panel2.Controls.Clear()
        Me.spcCFAUTH.Panel2.Controls.Add(CFAUTHGrid)
        CFAUTHGrid.Dock = Windows.Forms.DockStyle.Fill
        If Me.CFAUTHGrid.DataRowTemplate.Cells.Count >= 0 Then
            For i As Integer = 0 To Me.CFAUTHGrid.DataRowTemplate.Cells.Count - 1
                AddHandler CFAUTHGrid.DataRowTemplate.Cells(i).Click, AddressOf CFAUTHGrid_Click
            Next
        End If

        'thunt:insert into broker 
        FABROKERAGEGrid = New GridEx
        Dim v_cmrFABROKERAGEHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrFABROKERAGEHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrFABROKERAGEHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        v_cmrFABROKERAGEHeader.Height = 32
        FABROKERAGEGrid.FixedHeaderRows.Add(v_cmrFABROKERAGEHeader)
        FABROKERAGEGrid.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(Integer)))
        FABROKERAGEGrid.Columns.Add(New Xceed.Grid.Column("BRKID", GetType(System.String)))
        FABROKERAGEGrid.Columns.Add(New Xceed.Grid.Column("BRKNAME", GetType(System.String)))
        'Thêm trường trạng thái
        FABROKERAGEGrid.Columns("AUTOID").Title = ResourceManager.GetString("FABROKERAGEGrid.AUTOID")
        FABROKERAGEGrid.Columns("BRKNAME").Title = ResourceManager.GetString("FABROKERAGEGrid.BRKNAME")
        FABROKERAGEGrid.Columns("BRKID").Title = ResourceManager.GetString("FABROKERAGEGrid.BRKID")

        FABROKERAGEGrid.Columns("AUTOID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        FABROKERAGEGrid.Columns("BRKNAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        FABROKERAGEGrid.Columns("BRKID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left

        FABROKERAGEGrid.Columns("AUTOID").Visible = False
        FABROKERAGEGrid.Columns("BRKNAME").Width = 300
        Me.spcBROKER.Panel2.Controls.Clear()
        Me.spcBROKER.Panel2.Controls.Add(FABROKERAGEGrid)
        FABROKERAGEGrid.Dock = Windows.Forms.DockStyle.Fill

        'TanPN 07/02/2020 khoi tao Grid AP
        FAAPGrid = New GridEx
        Dim v_cmrFAAPHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrFAAPHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrFAAPHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        v_cmrFAAPHeader.Height = 32
        FAAPGrid.FixedHeaderRows.Add(v_cmrFAAPHeader)
        FAAPGrid.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(Integer)))
        FAAPGrid.Columns.Add(New Xceed.Grid.Column("BRKID", GetType(System.String)))
        FAAPGrid.Columns.Add(New Xceed.Grid.Column("BRKNAME", GetType(System.String)))


        'Thêm trường trạng thái
        FAAPGrid.Columns("AUTOID").Title = ResourceManager.GetString("FAAPGrid.AUTOID")
        FAAPGrid.Columns("BRKNAME").Title = ResourceManager.GetString("FAAPGrid.BRKNAME")
        FAAPGrid.Columns("BRKID").Title = ResourceManager.GetString("FAAPGrid.BRKID")

        FAAPGrid.Columns("AUTOID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        FAAPGrid.Columns("BRKNAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        FAAPGrid.Columns("BRKID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left

        FAAPGrid.Columns("AUTOID").Visible = False
        FAAPGrid.Columns("BRKNAME").Width = 300
        Me.spcAP.Panel2.Controls.Clear()
        Me.spcAP.Panel2.Controls.Add(FAAPGrid)
        FAAPGrid.Dock = Windows.Forms.DockStyle.Fill

        'ngan hang
        'Khoi tao Grid AFMAST
        CURRENTACCGrid = New GridEx
        Dim v_cmrCURRENTACCHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrCURRENTACCHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrCURRENTACCHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        v_cmrCURRENTACCHeader.Height = 32
        CURRENTACCGrid.FixedHeaderRows.Add(v_cmrCURRENTACCHeader)

        CURRENTACCGrid.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(Integer)))
        'CURRENTACCGrid.Columns.Add(New Xceed.Grid.Column("CUSTID", GetType(System.String)))
        CURRENTACCGrid.Columns.Add(New Xceed.Grid.Column("ACCOUNTTYPE", GetType(System.String)))
        CURRENTACCGrid.Columns.Add(New Xceed.Grid.Column("REFCASAACCT", GetType(System.String)))
        CURRENTACCGrid.Columns.Add(New Xceed.Grid.Column("CCYCD", GetType(System.String)))
        CURRENTACCGrid.Columns.Add(New Xceed.Grid.Column("ISDEFAULT", GetType(System.String)))
        CURRENTACCGrid.Columns.Add(New Xceed.Grid.Column("OPNDATE", GetType(System.String)))
        CURRENTACCGrid.Columns.Add(New Xceed.Grid.Column("STATUS", GetType(System.String)))
        CURRENTACCGrid.Columns.Add(New Xceed.Grid.Column("STATUSCD", GetType(System.String)))
        CURRENTACCGrid.Columns.Add(New Xceed.Grid.Column("AUTOTRANSFER", GetType(System.String)))
        CURRENTACCGrid.Columns.Add(New Xceed.Grid.Column("PAYMENTFEE", GetType(System.String)))

        CURRENTACCGrid.Columns("AUTOID").Title = ResourceManager.GetString("CURRENTACCGrid.AUTOID")
        'CURRENTACCGrid.Columns("CUSTID").Title = ResourceManager.GetString("CURRENTACCGrid.CUSTID")
        CURRENTACCGrid.Columns("ACCOUNTTYPE").Title = ResourceManager.GetString("CURRENTACCGrid.ACCOUNTTYPE")
        CURRENTACCGrid.Columns("REFCASAACCT").Title = ResourceManager.GetString("CURRENTACCGrid.ACCOUNTBANK")
        CURRENTACCGrid.Columns("CCYCD").Title = ResourceManager.GetString("CURRENTACCGrid.CCYBANK")
        CURRENTACCGrid.Columns("ISDEFAULT").Title = ResourceManager.GetString("CURRENTACCGrid.ACCSETTLEMENT")
        CURRENTACCGrid.Columns("OPNDATE").Title = ResourceManager.GetString("CURRENTACCGrid.DATEOPEN")
        CURRENTACCGrid.Columns("STATUS").Title = ResourceManager.GetString("CURRENTACCGrid.STATUS")
        CURRENTACCGrid.Columns("STATUSCD").Title = ResourceManager.GetString("CURRENTACCGrid.STATUS")
        CURRENTACCGrid.Columns("AUTOTRANSFER").Title = ResourceManager.GetString("CURRENTACCGrid.AUTOTRANSFER")
        CURRENTACCGrid.Columns("PAYMENTFEE").Title = ResourceManager.GetString("CURRENTACCGrid.PAYMENTFEE")

        CURRENTACCGrid.Columns("AUTOID").Width = 0
        CURRENTACCGrid.Columns("ACCOUNTTYPE").Width = 350
        'CURRENTACCGrid.Columns("CUSTID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        CURRENTACCGrid.Columns("ACCOUNTTYPE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        CURRENTACCGrid.Columns("REFCASAACCT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        CURRENTACCGrid.Columns("CCYCD").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        CURRENTACCGrid.Columns("ISDEFAULT").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        CURRENTACCGrid.Columns("OPNDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        CURRENTACCGrid.Columns("STATUS").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        CURRENTACCGrid.Columns("AUTOTRANSFER").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        CURRENTACCGrid.Columns("PAYMENTFEE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center

        Me.spcCURRENTACC.Panel2.Controls.Clear()
        Me.spcCURRENTACC.Panel2.Controls.Add(CURRENTACCGrid)
        CURRENTACCGrid.Dock = Windows.Forms.DockStyle.Fill
        CURRENTACCGrid.Columns("ACCOUNTTYPE").Width = 200
        CURRENTACCGrid.Columns("REFCASAACCT").Width = 200
        CURRENTACCGrid.Columns("STATUSCD").Visible = False
        'Khoi tao CFOTHERACCGrid
        CFOTHERACCGrid = New GridEx
        Dim v_cmrCFOTHERACCHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrCFOTHERACCHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrCFOTHERACCHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        v_cmrCFOTHERACCHeader.Height = 32
        CFOTHERACCGrid.FixedHeaderRows.Add(v_cmrCFOTHERACCHeader)

        CFOTHERACCGrid.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(Integer)))
        CFOTHERACCGrid.Columns("AUTOID").Width = 0
        CFOTHERACCGrid.Columns.Add(New Xceed.Grid.Column("TRFTYPE", GetType(System.String)))
        CFOTHERACCGrid.Columns.Add(New Xceed.Grid.Column("CIACCOUNT", GetType(System.String)))
        CFOTHERACCGrid.Columns.Add(New Xceed.Grid.Column("CINAME", GetType(System.String)))
        CFOTHERACCGrid.Columns.Add(New Xceed.Grid.Column("CUSTID", GetType(System.String)))
        CFOTHERACCGrid.Columns.Add(New Xceed.Grid.Column("BANKACC", GetType(System.String)))
        CFOTHERACCGrid.Columns.Add(New Xceed.Grid.Column("BANKACNAME", GetType(System.String)))
        CFOTHERACCGrid.Columns.Add(New Xceed.Grid.Column("BANKNAME", GetType(System.String)))
        CFOTHERACCGrid.Columns.Add(New Xceed.Grid.Column("ACNIDCODE", GetType(System.String)))
        CFOTHERACCGrid.Columns.Add(New Xceed.Grid.Column("ACNIDDATE", GetType(System.String)))
        CFOTHERACCGrid.Columns.Add(New Xceed.Grid.Column("ACNIDPLACE", GetType(System.String)))
        CFOTHERACCGrid.Columns.Add(New Xceed.Grid.Column("CITYEF", GetType(System.String)))
        CFOTHERACCGrid.Columns.Add(New Xceed.Grid.Column("CITYBANK", GetType(System.String)))

        'AnTB 27/02/2015 add thong tin nguoi tao, nguoi duyet, trang thai
        CFOTHERACCGrid.Columns.Add(New Xceed.Grid.Column("TLNAME", GetType(System.String)))
        CFOTHERACCGrid.Columns.Add(New Xceed.Grid.Column("CREATEDDT", GetType(System.String)))
        CFOTHERACCGrid.Columns.Add(New Xceed.Grid.Column("OFFNAME", GetType(System.String)))
        CFOTHERACCGrid.Columns.Add(New Xceed.Grid.Column("APPRVDT", GetType(System.String)))
        CFOTHERACCGrid.Columns.Add(New Xceed.Grid.Column("STATUS_DESC", GetType(System.String)))
        'End AnTB add

        CFOTHERACCGrid.Columns("TRFTYPE").Width = 150
        CFOTHERACCGrid.Columns("BANKACNAME").Width = 300
        CFOTHERACCGrid.Columns("BANKNAME").Width = 300


        CFOTHERACCGrid.Columns("TRFTYPE").Title = ResourceManager.GetString("CFOTHERACCGrid.TRFTYPE")
        CFOTHERACCGrid.Columns("CIACCOUNT").Title = ResourceManager.GetString("CFOTHERACCGrid.CIACCOUNT")
        CFOTHERACCGrid.Columns("CINAME").Title = ResourceManager.GetString("CFOTHERACCGrid.CINAME")
        CFOTHERACCGrid.Columns("CUSTID").Title = ResourceManager.GetString("CFOTHERACCGrid.CUSTID")
        CFOTHERACCGrid.Columns("BANKACC").Title = ResourceManager.GetString("CFOTHERACCGrid.BANKACC")
        CFOTHERACCGrid.Columns("BANKACNAME").Title = ResourceManager.GetString("CFOTHERACCGrid.BANKACNAME")
        CFOTHERACCGrid.Columns("BANKNAME").Title = ResourceManager.GetString("CFOTHERACCGrid.BANKNAME")
        CFOTHERACCGrid.Columns("ACNIDCODE").Title = ResourceManager.GetString("CFOTHERACCGrid.ACNIDCODE")
        CFOTHERACCGrid.Columns("ACNIDDATE").Title = ResourceManager.GetString("CFOTHERACCGrid.ACNIDDATE")
        CFOTHERACCGrid.Columns("ACNIDPLACE").Title = ResourceManager.GetString("CFOTHERACCGrid.ACNIDPLACE")
        CFOTHERACCGrid.Columns("CITYEF").Title = ResourceManager.GetString("CFOTHERACCGrid.CITYEF")
        CFOTHERACCGrid.Columns("CITYBANK").Title = ResourceManager.GetString("CFOTHERACCGrid.CITYBANK")

        'AnTB 27/02/2015 add thong tin nguoi tao, nguoi duyet, trang thai
        CFOTHERACCGrid.Columns("TLNAME").Title = ResourceManager.GetString("CFOTHERACCGrid.TLNAME")
        CFOTHERACCGrid.Columns("CREATEDDT").Title = ResourceManager.GetString("CFOTHERACCGrid.CREATEDDT")
        CFOTHERACCGrid.Columns("OFFNAME").Title = ResourceManager.GetString("CFOTHERACCGrid.OFFNAME")
        CFOTHERACCGrid.Columns("APPRVDT").Title = ResourceManager.GetString("CFOTHERACCGrid.APPRVDT")
        CFOTHERACCGrid.Columns("STATUS_DESC").Title = ResourceManager.GetString("CFOTHERACCGrid.STATUS_DESC")
        'AnTB End

        CFOTHERACCGrid.Columns("TRFTYPE").Width = 150

        spcCFOTHERACC.Panel2.Controls.Clear()
        spcCFOTHERACC.Panel2.Controls.Add(CFOTHERACCGrid)
        CFOTHERACCGrid.Dock = Windows.Forms.DockStyle.Fill

        AddHandler CFOTHERACCGrid.DoubleClick, AddressOf CFOTHERACCGrid_Click
        If Me.CFOTHERACCGrid.DataRowTemplate.Cells.Count >= 0 Then
            For i As Integer = 0 To Me.CFOTHERACCGrid.DataRowTemplate.Cells.Count - 1
                AddHandler CFOTHERACCGrid.DataRowTemplate.Cells(i).DoubleClick, AddressOf CFOTHERACCGrid_Click
            Next
        End If


        OTRIGTGrid = New GridEx
        Dim v_cmrOTRIGTGridHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrOTRIGTGridHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrOTRIGTGridHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        v_cmrOTRIGTGridHeader.Height = 32
        v_cmrOTRIGTGridHeader.HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        OTRIGTGrid.FixedHeaderRows.Add(v_cmrOTRIGTGridHeader)
        OTRIGTGrid.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(Integer)))
        OTRIGTGrid.Columns.Add(New Xceed.Grid.Column("AUTHTYPE", GetType(System.String)))
        OTRIGTGrid.Columns.Add(New Xceed.Grid.Column("AUTHCUSTID", GetType(System.String)))
        OTRIGTGrid.Columns.Add(New Xceed.Grid.Column("FULLNAME", GetType(System.String)))
        OTRIGTGrid.Columns.Add(New Xceed.Grid.Column("IDCODE", GetType(System.String)))
        OTRIGTGrid.Columns.Add(New Xceed.Grid.Column("ADDRESS", GetType(System.String)))
        OTRIGTGrid.Columns.Add(New Xceed.Grid.Column("MOBILESMS", GetType(System.String)))
        OTRIGTGrid.Columns.Add(New Xceed.Grid.Column("VALDATE", GetType(System.String)))
        OTRIGTGrid.Columns.Add(New Xceed.Grid.Column("OTAUTHTYPE", GetType(System.String))) 'thunt thêm loại xác thực
        OTRIGTGrid.Columns.Add(New Xceed.Grid.Column("VIA", GetType(System.String))) 'thunt them kênh giao dịch
        OTRIGTGrid.Columns.Add(New Xceed.Grid.Column("SERIALTOKEN", GetType(System.String)))

        OTRIGTGrid.Columns("AUTOID").Title = ResourceManager.GetString("OTRIGTGrid.AUTOID")
        OTRIGTGrid.Columns("AUTHTYPE").Title = ResourceManager.GetString("OTRIGTGrid.AUTHTYPE")
        OTRIGTGrid.Columns("AUTHCUSTID").Title = ResourceManager.GetString("OTRIGTGrid.CUSTID")
        OTRIGTGrid.Columns("FULLNAME").Title = ResourceManager.GetString("OTRIGTGrid.FULLNAME")
        OTRIGTGrid.Columns("IDCODE").Title = ResourceManager.GetString("OTRIGTGrid.LICENSENO")
        OTRIGTGrid.Columns("ADDRESS").Title = ResourceManager.GetString("OTRIGTGrid.ADDRESS")
        OTRIGTGrid.Columns("MOBILESMS").Title = ResourceManager.GetString("OTRIGTGrid.TELEPHONE")
        OTRIGTGrid.Columns("VALDATE").Title = ResourceManager.GetString("OTRIGTGrid.VALDATE")
        OTRIGTGrid.Columns("OTAUTHTYPE").Title = ResourceManager.GetString("OTRIGTGrid.OTAUTHTYPE") 'thunt thêm loại xác thực
        OTRIGTGrid.Columns("VIA").Title = ResourceManager.GetString("OTRIGTGrid.VIA") 'thunt them kênh giao dịch
        OTRIGTGrid.Columns("SERIALTOKEN").Title = ResourceManager.GetString("OTRIGTGrid.SERIALTOKEN")


        OTRIGTGrid.Columns("AUTOID").Visible = False

        Me.spcOTRIGHT.Panel2.Controls.Clear()
        Me.spcOTRIGHT.Panel2.Controls.Add(OTRIGTGrid)
        OTRIGTGrid.Dock = Windows.Forms.DockStyle.Fill


        AFTEMPLATESGrid = New GridEx
        Dim cmrAFTEMPLATESGridHeader As New Xceed.Grid.ColumnManagerRow
        cmrAFTEMPLATESGridHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        cmrAFTEMPLATESGridHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        cmrAFTEMPLATESGridHeader.HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        cmrAFTEMPLATESGridHeader.Height = 32

        AFTEMPLATESGrid.FixedHeaderRows.Add(cmrAFTEMPLATESGridHeader)
        AFTEMPLATESGrid.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(Integer)))
        AFTEMPLATESGrid.Columns.Add(New Xceed.Grid.Column("NAME", GetType(System.String)))
        AFTEMPLATESGrid.Columns.Add(New Xceed.Grid.Column("SUBJECT", GetType(System.String)))

        AFTEMPLATESGrid.Columns("AUTOID").Title = ResourceManager.GetString("AFTEMPLATESGrid.TEMPLATE_AUTOID")
        AFTEMPLATESGrid.Columns("NAME").Title = ResourceManager.GetString("AFTEMPLATESGrid.TEMPLATE_ID")
        AFTEMPLATESGrid.Columns("SUBJECT").Title = ResourceManager.GetString("AFTEMPLATESGrid.TEMPLATE_DESCRIPTION")

        AFTEMPLATESGrid.Columns("AUTOID").Visible = False

        AFTEMPLATESGrid.Columns("SUBJECT").Width = 500

        Me.spcTEMPLATE.Panel2.Controls.Clear()
        Me.spcTEMPLATE.Panel2.Controls.Add(AFTEMPLATESGrid)
        AFTEMPLATESGrid.Dock = Windows.Forms.DockStyle.Fill


        CFRPTAFMASTGrid = New GridEx
        Dim v_cmrCFRPTAFMASTHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrCFRPTAFMASTHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrCFRPTAFMASTHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        v_cmrCFRPTAFMASTHeader.Height = 32
        CFRPTAFMASTGrid.FixedHeaderRows.Add(v_cmrCFRPTAFMASTHeader)
        CFRPTAFMASTGrid.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(Integer)))
        CFRPTAFMASTGrid.Columns.Add(New Xceed.Grid.Column("CMDCODE", GetType(System.String)))
        CFRPTAFMASTGrid.Columns.Add(New Xceed.Grid.Column("CMDTITLE", GetType(System.String)))
        CFRPTAFMASTGrid.Columns.Add(New Xceed.Grid.Column("EXCYCLE", GetType(System.String)))
        CFRPTAFMASTGrid.Columns.Add(New Xceed.Grid.Column("EXPDATE", GetType(System.String)))
        CFRPTAFMASTGrid.Columns.Add(New Xceed.Grid.Column("STATUS", GetType(System.String)))

        CFRPTAFMASTGrid.Columns("AUTOID").Title = ResourceManager.GetString("CFRPTAFMASTGrid.AUTOID")
        CFRPTAFMASTGrid.Columns("CMDCODE").Title = ResourceManager.GetString("CFRPTAFMASTGrid.CMDCODE")
        CFRPTAFMASTGrid.Columns("CMDTITLE").Title = ResourceManager.GetString("CFRPTAFMASTGrid.CMDTITLE")
        CFRPTAFMASTGrid.Columns("EXCYCLE").Title = ResourceManager.GetString("CFRPTAFMASTGrid.EXCYCLE")
        CFRPTAFMASTGrid.Columns("EXPDATE").Title = ResourceManager.GetString("CFRPTAFMASTGrid.EXPDATE")
        CFRPTAFMASTGrid.Columns("STATUS").Title = ResourceManager.GetString("CFRPTAFMASTGrid.STATUS")

        CFRPTAFMASTGrid.Columns("AUTOID").Width = 0
        CFRPTAFMASTGrid.Columns("CMDTITLE").Width = 250
        CFRPTAFMASTGrid.Columns("CMDCODE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        CFRPTAFMASTGrid.Columns("CMDTITLE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        CFRPTAFMASTGrid.Columns("EXCYCLE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        CFRPTAFMASTGrid.Columns("EXPDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        CFRPTAFMASTGrid.Columns("STATUS").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left

        Me.spcCFRPTAFMAST.Panel2.Controls.Clear()
        Me.spcCFRPTAFMAST.Panel2.Controls.Add(CFRPTAFMASTGrid)
        CFRPTAFMASTGrid.Dock = Windows.Forms.DockStyle.Fill


        REAFLNKGrid = New GridEx
        Dim v_cmrREAFLNKHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrREAFLNKHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrREAFLNKHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        v_cmrREAFLNKHeader.Height = 32
        REAFLNKGrid.FixedHeaderRows.Add(v_cmrREAFLNKHeader)
        REAFLNKGrid.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(Integer)))
        REAFLNKGrid.Columns.Add(New Xceed.Grid.Column("FRDATE", GetType(System.String)))
        REAFLNKGrid.Columns.Add(New Xceed.Grid.Column("TODATE", GetType(System.String)))
        REAFLNKGrid.Columns.Add(New Xceed.Grid.Column("REACCTNO", GetType(System.String)))
        REAFLNKGrid.Columns.Add(New Xceed.Grid.Column("REFULLNAME", GetType(System.String)))
        REAFLNKGrid.Columns.Add(New Xceed.Grid.Column("REROLE", GetType(System.String)))
        REAFLNKGrid.Columns.Add(New Xceed.Grid.Column("TYPENAME", GetType(System.String)))
        REAFLNKGrid.Columns.Add(New Xceed.Grid.Column("STATUS", GetType(System.String)))

        REAFLNKGrid.Columns("AUTOID").Title = ResourceManager.GetString("REAFLNKGrid.AUTOID")
        REAFLNKGrid.Columns("FRDATE").Title = ResourceManager.GetString("REAFLNKGrid.FRDATE")
        REAFLNKGrid.Columns("TODATE").Title = ResourceManager.GetString("REAFLNKGrid.TODATE")
        REAFLNKGrid.Columns("REACCTNO").Title = ResourceManager.GetString("REAFLNKGrid.REACCTNO")
        REAFLNKGrid.Columns("REFULLNAME").Title = ResourceManager.GetString("REAFLNKGrid.REFULLNAME")
        REAFLNKGrid.Columns("REROLE").Title = ResourceManager.GetString("REAFLNKGrid.REROLE")
        REAFLNKGrid.Columns("TYPENAME").Title = ResourceManager.GetString("REAFLNKGrid.TYPENAME")
        REAFLNKGrid.Columns("STATUS").Title = ResourceManager.GetString("REAFLNKGrid.STATUS")

        REAFLNKGrid.Columns("AUTOID").Width = 0
        REAFLNKGrid.Columns("FRDATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        REAFLNKGrid.Columns("TODATE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        REAFLNKGrid.Columns("REACCTNO").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        REAFLNKGrid.Columns("REFULLNAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        REAFLNKGrid.Columns("REFULLNAME").Width = 350
        REAFLNKGrid.Columns("REROLE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        REAFLNKGrid.Columns("TYPENAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        REAFLNKGrid.Columns("STATUS").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left

        Me.spcREAFLNK.Panel2.Controls.Clear()
        Me.spcREAFLNK.Panel2.Controls.Add(REAFLNKGrid)
        REAFLNKGrid.Dock = Windows.Forms.DockStyle.Fill


        'Me.pnPicture.Controls.Clear()
        'Me.pnPicture.Controls.Add(imageViewer)


        EMAILREPORTGrid = New GridEx
        Dim v_cmrEMAILREPORTHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrEMAILREPORTHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrEMAILREPORTHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        v_cmrEMAILREPORTHeader.Height = 32
        EMAILREPORTGrid.FixedHeaderRows.Add(v_cmrEMAILREPORTHeader)


        EMAILREPORTGrid.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(Integer)))
        EMAILREPORTGrid.Columns.Add(New Xceed.Grid.Column("REGISTTYPE", GetType(System.String)))
        EMAILREPORTGrid.Columns.Add(New Xceed.Grid.Column("CUSTID", GetType(System.String)))
        EMAILREPORTGrid.Columns.Add(New Xceed.Grid.Column("EMAIL", GetType(System.String)))


        EMAILREPORTGrid.Columns("REGISTTYPE").Title = ResourceManager.GetString("EMAILREPORTGrid.REGISTTYPE")
        EMAILREPORTGrid.Columns("CUSTID").Title = ResourceManager.GetString("EMAILREPORTGrid.CUSTID")
        EMAILREPORTGrid.Columns("EMAIL").Title = ResourceManager.GetString("EMAILREPORTGrid.EMAIL")



        EMAILREPORTGrid.Columns("AUTOID").Visible = False
        EMAILREPORTGrid.Columns("REGISTTYPE").Width = 150
        EMAILREPORTGrid.Columns("CUSTID").Width = 150
        EMAILREPORTGrid.Columns("EMAIL").Width = 600

        EMAILREPORTGrid.Columns("REGISTTYPE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        EMAILREPORTGrid.Columns("CUSTID").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Center
        EMAILREPORTGrid.Columns("EMAIL").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left


        Me.spEMAILREPORT.Panel2.Controls.Clear()
        Me.spEMAILREPORT.Panel2.Controls.Add(EMAILREPORTGrid)
        spEMAILREPORT.Dock = Windows.Forms.DockStyle.Fill

        CFDOMAINGrid = New GridEx
        Dim v_cmrCFDomainHeader As New Xceed.Grid.ColumnManagerRow
        v_cmrEMAILREPORTHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
        v_cmrEMAILREPORTHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        v_cmrEMAILREPORTHeader.Height = 32
        CFDOMAINGrid.FixedHeaderRows.Add(v_cmrCFDomainHeader)

        CFDOMAINGrid.Columns.Add(New Xceed.Grid.Column("AUTOID", GetType(Integer)))
        CFDOMAINGrid.Columns.Add(New Xceed.Grid.Column("DOMAINCODE", GetType(System.String)))
        CFDOMAINGrid.Columns.Add(New Xceed.Grid.Column("DOMAINNAME", GetType(System.String)))
        CFDOMAINGrid.Columns.Add(New Xceed.Grid.Column("CVSDSTATUS", GetType(System.String)))

        CFDOMAINGrid.Columns("DOMAINCODE").Title = ResourceManager.GetString("CFDOMAINGrid.DOMAINCODE")
        CFDOMAINGrid.Columns("DOMAINNAME").Title = ResourceManager.GetString("CFDOMAINGrid.DOMAINNAME")
        CFDOMAINGrid.Columns("CVSDSTATUS").Title = ResourceManager.GetString("CFDOMAINGrid.CVSDSTATUS")

        CFDOMAINGrid.Columns("AUTOID").Visible = False
        CFDOMAINGrid.Columns("DOMAINCODE").Width = 150
        CFDOMAINGrid.Columns("DOMAINNAME").Width = 300
        CFDOMAINGrid.Columns("CVSDSTATUS").Width = 300

        CFDOMAINGrid.Columns("DOMAINCODE").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        CFDOMAINGrid.Columns("DOMAINNAME").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        CFDOMAINGrid.Columns("CVSDSTATUS").HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left


        Me.spCFDOMAIN.Panel2.Controls.Clear()
        Me.spCFDOMAIN.Panel2.Controls.Add(CFDOMAINGrid)
        CFDOMAINGrid.Dock = Windows.Forms.DockStyle.Fill
    End Sub

    Private Function ControlValidation(Optional ByVal pv_blnSaved As Boolean = False) As Boolean

        Try
            If pv_blnSaved Then

                Dim dblAge As Double
                Try

                    Dim v_xmlDocument As New Xml.XmlDocument
                    Dim v_strCmdSQL, v_strObjMsg As String
                    Dim v_nodeList As Xml.XmlNodeList
                    Dim v_ws As New BDSDeliveryManagement 'BD
                    v_strCmdSQL = "Select varvalue VARVALUE from sysvar where varname = 'CUSTOMERAGE'"
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                    v_ws.Message(v_strObjMsg)
                    v_xmlDocument.LoadXml(v_strObjMsg)
                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                    For v_intCount As Integer = 0 To v_nodeList.Count - 1
                        For v_int As Integer = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                            With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                                Dim v_strFLDNAME As String = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                                Dim v_strVALUE As String = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()
                                If v_strFLDNAME = "VARVALUE" Then
                                    dblAge = Convert.ToDouble(v_strVALUE)

                                End If
                            End With
                        Next
                    Next

                Catch
                    dblAge = 18
                End Try

                If (cboCUSTTYPE.SelectedValue = "I") Then
                    If dtpDATEOFBIRTH.Text = "" Then
                        MsgBox(ResourceManager.GetString("msg_INVALID_AGE"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        dtpDATEOFBIRTH.Focus()
                        Return False
                    End If
                    If dtpDATEOFBIRTH.Text > Now.AddYears(-dblAge) Then
                        MsgBox(ResourceManager.GetString("msg_INVALID_AGE"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        dtpDATEOFBIRTH.Focus()
                        Return False
                    End If
                End If

                If Me.cboIDTYPE.SelectedValue = IDTYPE_TRADINGCODE Then
                    'If (txtTRADINGCODE.Text.Trim().Length = 0) AndAlso cboISBANKING.SelectedValue = "N" Then
                    '    MessageBox.Show(ResourceManager.GetString("MsgTRADINGCODEISEMPTY"))
                    '    txtTRADINGCODE.Focus()
                    '    Return False
                    'End If
                Else
                    'If (txtIDCODE.Text.Trim().Length = 0) Then 'AndAlso cboISBANKING.SelectedValue = "N" 
                    '    MessageBox.Show(ResourceManager.GetString("MsgIDCODEISEMPTY"))
                    '    txtIDCODE.Focus()
                    '    Return False
                    'End If

                    If cboCAREBY.Text.Trim().Length = 0 Then
                        MessageBox.Show(ResourceManager.GetString("msgCareBy"))
                        cboCAREBY.Focus()
                        Return False
                    End If

                    'If DDMMYYYY_SystemDate(Me.dtpIDDATE.Text.Trim) > DDMMYYYY_SystemDate(BusDate) Then 'AndAlso cboISBANKING.SelectedValue = "N" 
                    '    MessageBox.Show(ResourceManager.GetString("MsgIDDATEOVERBUSDATE"))
                    '    dtpIDDATE.Focus()
                    '    Return False
                    'End If

                    'If DDMMYYYY_SystemDate(Me.dtpIDEXPIRED.Text.Trim) <= DDMMYYYY_SystemDate(BusDate) AndAlso cboCUSTTYPE.SelectedValue <> "B" Then 'AndAlso cboISBANKING.SelectedValue = "N" 
                    '    If MessageBox.Show(ResourceManager.GetString("MsgIDEXPIREDLESSTHANBUSDATE"), Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) <> Windows.Forms.DialogResult.OK Then
                    '        dtpIDEXPIRED.Focus()
                    '        Return False
                    '    End If
                    'End If
                End If
                'If txtSHORTNAME.Text.Length <> 4 Then 'AndAlso cboISBANKING.SelectedValue = "N" 
                '    MsgBox(ResourceManager.GetString("MsgISBANKING_SHORTNAME_INVALID"), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)
                '    txtSHORTNAME.Focus()
                '    Return False
                'End If
                'If Me.cboTRADETELEPHONE.SelectedValue = "Y" AndAlso Me.txtPIN.Text.Length = 0 Then 'AndAlso cboISBANKING.SelectedValue = "N" 
                '    MessageBox.Show(ResourceManager.GetString("MsgPINISEMPTY"))
                '    txtPIN.Focus()
                '    Return False
                'End If
                'If Me.cboTRADETELEPHONE.SelectedValue = "Y" AndAlso Me.txtMOBILESMS.Text.Length = 0 Then 'AndAlso cboISBANKING.SelectedValue = "N" 
                '    MessageBox.Show(ResourceManager.GetString("MsgMOBILEISEMPTY"))
                '    txtMOBILESMS.Focus()
                '    Return False
                'End If

                If ExeFlag = ExecuteFlag.AddNew Then
                    If (cboCOUNTRY.SelectedValue <> VIETNAMEESE_CODE) Then

                        If txtTRADINGCODE.Text.Length = 0 And Me.txtCUSTODYCD.Text.Trim.Substring(0, 4) <> "OTCF" Then
                            MsgBox(ResourceManager.GetString("msgNULLCHECKTRADINGCODE"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Me.txtTRADINGCODE.Focus()
                            Exit Function
                        End If
                        MsgBox(ResourceManager.GetString("MsgREMINDFEE"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Else
                        'thunt - ACBF đi với 234
                        Dim v_PROVINCE As String
                        v_PROVINCE = cboPROVINCE.SelectedValue.ToString
                        If cboPROVINCE.SelectedValue.ToString = "--" Then
                            MsgBox(ResourceManager.GetString("msgNULLCHECKPROVINCE"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Me.cboPROVINCE.Focus()
                            Exit Function
                        End If

                        Dim v_split As String
                        v_split = Mid(Me.txtCUSTODYCD.Text.ToString, 4, 1)
                        If v_split = "F" Then
                            MsgBox(ResourceManager.GetString("MsgSUBACCOUNTISFOREIGN"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Me.cboPROVINCE.Focus()
                            Exit Function
                        End If

                    End If

                End If
                'Check 6 ky tu dau tien cua Trading code phai tuong tu nhu 6 ky tu cuoi cua so luu ky.
                If Len(Me.txtTRADINGCODE.Text.Trim) > 0 And Len(Me.txtCUSTODYCD.Text.Trim) > 0 Then
                    If Not (Len(Me.txtCUSTODYCD.Text.Trim) >= 6 AndAlso Len(Me.txtTRADINGCODE.Text.Trim) >= 6 AndAlso Me.txtTRADINGCODE.Text.ToUpper.Substring(0, 6) = Me.txtCUSTODYCD.Text.ToUpper.Substring(Len(Me.txtCUSTODYCD.Text.Trim) - 6, 6)) Then
                        MsgBox(ResourceManager.GetString("msgCHECKTRADINGCODE"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Me.txtTRADINGCODE.Focus()
                        Exit Function
                    End If
                End If
                'Kiem tra dinh dang Email phai hop le
                'v_strSQL = "SELECT COUNT(1) AUTOID" & ControlChars.CrLf _
                '& " FROM OTRIGHT OT, CFMAST CF, ALLCODE A1" & ControlChars.CrLf _
                '& " WHERE CF.CUSTID = OT.AUTHCUSTID" & ControlChars.CrLf _
                '& "     AND OT.DELTD = 'N' " & ControlChars.CrLf _
                '& "     AND A1.CDTYPE = 'CF' AND A1.CDNAME = 'AUTHTYPE' AND A1.CDVAL = CASE WHEN OT.AUTHCUSTID = '" & txtCUSTID.Text & "' THEN 'OWNER' ELSE 'AUTHORIZED' END " & ControlChars.CrLf _
                '& "     AND CF.CUSTID='" & Me.txtCUSTID.Text & "'"
                'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId , MyBase.LocalObject, gc_MsgTypeObj, "CF.AUTOID", _
                'gc_ActionInquiry, v_strSQL)
                'v_wa.Message(v_strObjMsg)
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
                'If v_strCCUSTID > 0 And Trim(Me.txtEMAIL.Text).Length = 0 And Trim(Me.txtMOBILESMS.Text).Length = 0 And Trim(Me.txtMOBILE.Text).Length = 0 Then
                '    lblEMAIL.ForeColor = Color.Red
                '    MsgBox(ResourceManager.GetString("msgREGEMAIL"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                '    Me.txtEMAIL.Focus()
                '    Exit Function
                'End If

                If Trim(Me.txtEMAIL.Text).Length > 0 Then
                    If InStr(Trim(Me.txtEMAIL.Text), " ") > 0 Or InStr(Trim(Me.txtEMAIL.Text), "@") <= 0 Or InStr(Mid(Trim(Me.txtEMAIL.Text), InStr(Trim(Me.txtEMAIL.Text), "@") + 1), ".") <= 0 Then
                        MsgBox(ResourceManager.GetString("msgINVALIDEMAILFORMAT"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Me.txtEMAIL.Focus()
                        Exit Function
                    End If
                End If
                If Me.cboSEX.SelectedValue Is Nothing Then
                    MsgBox(ResourceManager.GetString("msgSEXISNOTHING"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Me.cboSEX.Focus()
                    Exit Function
                End If

                'longnh 2014-11-17 check margin allow = N thi ko cap han muc va hien canh bao
                'If Me.cboMARGINALLOW.SelectedValue = "N" Is Nothing Then
                '    MsgBox(ResourceManager.GetString("msgNOT_ALLOW_MARGIN"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)

                'End If

                'If cboISBANKING.SelectedValue <> "Y" Then
                '    Return MyBase.VerifyRules
                'End If

                If cboISBANKING.SelectedValue <> "Y" Then
                    Return MyBase.VerifyRules
                End If


            End If

            Return True
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function

    Private Function getCustID(ByVal BranchID As String) As String
        Dim v_strClause, v_strAutoID As String
        Dim v_int, v_intCount As Integer
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strVALUE As String
        v_strClause = "CUSTID"
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_wsBDS As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchID, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strClause, "GetInventory")
        v_wsBDS.Message(v_strObjMsg)
        v_xmlDocument.LoadXml(v_strObjMsg)
        v_strAutoID = v_xmlDocument.DocumentElement.Attributes("CLAUSE").Value
        v_strAutoID = Me.BranchId & Strings.Right("000000" & CStr(v_strAutoID), Len("000000"))
        Return v_strAutoID
    End Function

    Private Function CheckCustID(ByVal strCustID As String) As Boolean
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_int, v_intCount As Integer
        Dim v_strCDCONTENT, v_strCCUSTID As String
        Dim v_strFLDNAME, v_strVALUE As String
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        If strCustID.Substring(0, 4) <> Me.BranchId Then
            Return False
        End If
        Try
            Dim v_strCmdInquiry As String = "Select count(CUSTID) CCUSTID  from CFMAST where CUSTID = '" & strCustID & "'"
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

    Private Function CheckCustToDyCD(ByVal strCusToDyCD As String) As Boolean
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_int, v_intCount As Integer
        Dim v_strCDCONTENT, v_strCCUSTID As String
        Dim v_strFLDNAME, v_strVALUE As String
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Try
            Dim v_strCmdInquiry As String = "Select count(1) CCUSTID  from CFMAST where CusToDyCD = '" & strCusToDyCD & "'"
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

    Function GetExperiencecd() As String
        Dim str_Experiencecd As String

        If Me.chkEQUITIES.Checked = True Then
            str_Experiencecd &= 1
        Else
            str_Experiencecd &= 0
        End If

        If Me.chkBOND.Checked = True Then
            str_Experiencecd &= 1
        Else
            str_Experiencecd &= 0
        End If

        If Me.chkFOREX.Checked = True Then
            str_Experiencecd &= 1
        Else
            str_Experiencecd &= 0
        End If

        If Me.chkOTHERS.Checked = True Then
            str_Experiencecd &= 1
        Else
            str_Experiencecd &= 0
        End If

        If Me.chkREALESTATE.Checked = True Then
            str_Experiencecd &= 1
        Else
            str_Experiencecd &= 0
        End If
        Return str_Experiencecd
    End Function

    Private Sub SetExperiencecd(ByVal strExperiencecd As String)
        If strExperiencecd = "" Then
            Exit Sub
        Else
            If strExperiencecd.Length <> 5 Then
                Exit Sub
            Else
                If (Strings.Mid(strExperiencecd, 1, 1)) = 1 Then
                    Me.chkEQUITIES.Checked = True
                Else
                    Me.chkEQUITIES.Checked = False
                End If
                If (Strings.Mid(strExperiencecd, 2, 1)) = 1 Then
                    Me.chkBOND.Checked = True
                Else
                    Me.chkBOND.Checked = False
                End If
                If (Strings.Mid(strExperiencecd, 3, 1)) = 1 Then
                    Me.chkFOREX.Checked = True
                Else
                    Me.chkFOREX.Checked = False
                End If
                If (Strings.Mid(strExperiencecd, 4, 1)) = 1 Then
                    Me.chkOTHERS.Checked = True
                Else
                    Me.chkOTHERS.Checked = False
                End If
                If (Strings.Mid(strExperiencecd, 5, 1)) = 1 Then
                    Me.chkREALESTATE.Checked = True
                Else
                    Me.chkREALESTATE.Checked = False
                End If
            End If
        End If
    End Sub

    Public Overrides Sub LoadUserInterface(ByRef pv_ctrl As System.Windows.Forms.Control)
        MyBase.LoadUserInterface(pv_ctrl)
        Dim v_ws As New BDSDeliveryManagement
        Dim v_strOldVal As String = ""
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_strCmdSQL, v_strObjMsg, v_strSQL As String
        Dim v_strTRUADDRESS, v_strSHORTNAME As String
        Dim v_nodeList As Xml.XmlNodeList

        SetExperiencecd(Me.txtEXPERIENCECD.Text)
        ' Me.btnCORPORATE_ADD.Enabled = False
        ' Me.btnCORPORATE_VIEW.Enabled = False
        ' Me.btnCORPORATE_EDIT.Enabled = False
        ' Me.btnCORPORATE_DELETE.Enabled = False

        'If cboISBANKING.SelectedValue = "Y" Then
        '    txtSHORTNAME.Enabled = True
        'Else
        '    txtSHORTNAME.Enabled = False
        'End If
        '----------
        'txtTRUADRESS.Enabled = False
        '----------
        If cboIDTYPE.SelectedValue <> IDTYPE_TRADINGCODE Then
            'txtTRADINGCODE.Enabled = False
            dtpTRADINGCODEDT.Enabled = False
        Else
            txtTRADINGCODE.Enabled = True
            dtpTRADINGCODEDT.Enabled = True
        End If

        If ExeFlag <> ExecuteFlag.AddNew Then
            txtCUSTID.Enabled = False
            cboACTIVESTS.Enabled = False
            btnGenCheckCustID.Enabled = False
            Me.btnFABROKERAGE_VIEW.Enabled = False
            Me.btnFABROKERAGE_EDIT.Enabled = False


            If txtCUSTODYCD.Text.Length = 10 Then
                txtCUSTODYCD.Enabled = False
                btnGenCheckCUSTODYCD.Enabled = False
            Else
                If ExeFlag = ExecuteFlag.Edit Then
                    txtCUSTODYCD.Enabled = True
                    btnGenCheckCUSTODYCD.Enabled = True

                Else
                    txtCUSTODYCD.Enabled = False
                    btnGenCheckCUSTODYCD.Enabled = False
                    '---------
                    cboAMC.Enabled = False
                    cboGCB.Enabled = False
                    cboTRUSTEE.Enabled = False
                    '---------
                End If
            End If
        Else
            Me.txtMRLOANLIMIT.Text = 0
            Me.txtT0LOANLIMIT.Text = 0

            Try
                If cboCUSTTYPE.SelectedValue = "B" Then
                    If cboCOUNTRY.SelectedValue = VIETNAMEESE_CODE Then
                        v_strCmdSQL = "SELECT  CDVAL VALUECD, CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY FROM ALLCODE WHERE CDTYPE = 'CF' AND CDNAME = 'IDTYPE' AND CDVAL in ('005','009') order by LSTODR "
                    Else
                        v_strCmdSQL = "SELECT  CDVAL VALUECD, CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY FROM ALLCODE WHERE CDTYPE = 'CF' AND CDNAME = 'IDTYPE' AND CDVAL in ('009') order by LSTODR "
                    End If
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                    v_ws.Message(v_strObjMsg)
                    FillComboEx(v_strObjMsg, Me.cboIDTYPE, "", Me.UserLanguage)
                Else
                    If cboCOUNTRY.SelectedValue = VIETNAMEESE_CODE Then
                        v_strCmdSQL = "SELECT  CDVAL VALUECD, CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY FROM ALLCODE WHERE CDTYPE = 'CF' AND CDNAME = 'IDTYPE' AND CDVAL in ('001') order by LSTODR "
                    Else
                        v_strCmdSQL = "SELECT  CDVAL VALUECD, CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY FROM ALLCODE WHERE CDTYPE = 'CF' AND CDNAME = 'IDTYPE' AND CDVAL in ('009') order by LSTODR "
                    End If
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                    v_ws.Message(v_strObjMsg)
                    FillComboEx(v_strObjMsg, Me.cboIDTYPE, "", Me.UserLanguage)
                End If
            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Function getCustodyCD(ByVal BranchID As String) As String
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            Dim v_strClause, v_strAutoID, v_strREFERENCE As String
            Dim v_int, v_intCount As Integer
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strFLDNAME, v_strVALUE As String
            v_strClause = "CUSTODYCD"
            If cboCOUNTRY.SelectedValue = VIETNAMEESE_CODE Then
                v_strREFERENCE = "B"
            Else
                v_strREFERENCE = "F"
            End If

            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchID, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , v_strClause, "GetInventory", , , v_strREFERENCE)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_strAutoID = v_xmlDocument.DocumentElement.Attributes("CLAUSE").Value

            Dim v_strPrefixCustodyCD As String = AppSettings.Get("PrefixedCustodyCode")

            ''longnh PHS_P1_CF0001: NEU KH NGUOI NUOC NGOAI  SE LAY CUSTODYCD THEO TRADEDINGCODE
            If cboCOUNTRY.SelectedValue = VIETNAMEESE_CODE Then
                v_strAutoID = v_strPrefixCustodyCD & "B" & Strings.Right("000000" & CStr(v_strAutoID), Len("000000"))
            Else
                v_strAutoID = v_strPrefixCustodyCD & "F" & Strings.Right("000000" & CStr(v_strAutoID), Len("000000"))
            End If

            Return v_strAutoID
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                                    & "Error code: System error!" & vbNewLine _
                                    & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("SavingFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Function

    Private Sub ShowSignEvent(ByVal pv_intExecFlag As Integer)
        Try
            Dim v_objCustSign As New frmCFSIGN
            v_objCustSign.TableName = "CFSIGN"
            v_objCustSign.ObjectName = OBJNAME_CF_CFSIGN
            v_objCustSign.TellerId = TellerId
            v_objCustSign.BranchId = BranchId
            v_objCustSign.LocalObject = MyBase.LocalObject
            v_objCustSign.UserLanguage = UserLanguage
            v_objCustSign.ModuleCode = ModuleCode
            v_objCustSign.BusDate = Me.BusDate
            v_objCustSign.CustID = txtCUSTID.Text
            v_objCustSign.ParentObjName = Me.ObjectName
            v_objCustSign.ParentClause = KeyFieldName & " = '" & txtCUSTID.Text & "'"
            v_objCustSign.TellerId = TellerId
            v_objCustSign.SignCount = mv_arrSIGNATURE.Length

            If Not (pv_intExecFlag = ExecuteFlag.AddNew) Then
                v_objCustSign.KeyFieldName = "AUTOID"
                v_objCustSign.KeyFieldType = "N"
                v_objCustSign.KeyFieldValue = mv_arrAUTOID(mv_intCurrImageIndex)
                v_objCustSign.AUTOID = mv_arrAUTOID(mv_intCurrImageIndex)
                v_objCustSign.txtBROWSER.Enabled = False
                v_objCustSign.btnBROWSER.Enabled = False
            End If

            If (pv_intExecFlag = ExecuteFlag.AddNew) Then
                v_objCustSign.ExeFlag = ExecuteFlag.AddNew
            ElseIf (pv_intExecFlag = ExecuteFlag.View) Then
                v_objCustSign.ExeFlag = ExecuteFlag.View
            ElseIf (pv_intExecFlag = ExecuteFlag.Edit) Then
                v_objCustSign.ExeFlag = ExecuteFlag.Edit
            ElseIf (pv_intExecFlag = ExecuteFlag.Delete) Then
                v_objCustSign.ExeFlag = ExecuteFlag.Delete
            End If


            v_objCustSign.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadCFSIGN(ByVal pv_strCUSTID As String)
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim v_strSQL As String = "SELECT SIG.AUTOID,SIG.CUSTID,SIG.SIGNATURE,SIG.VALDATE,SIG.EXPDATE FROM CFSIGN SIG, SYSVAR SYS WHERE TRIM(SIG.CUSTID)='" & pv_strCUSTID & "'" _
            & " AND sys.varname = 'CURRDATE' AND grname = 'SYSTEM' " _
            & "  order by autoid desc"
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "CF.CFSIGN", _
                gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)

            Dim v_xmlDoc As New XmlDocument
            v_xmlDoc.LoadXml(v_strObjMsg)
            Dim v_xmlNodeList As XmlNodeList = v_xmlDoc.SelectNodes("/ObjectMessage/ObjData")
            Dim v_xmlEntry As XmlNode

            ReDim mv_arrAUTOID(v_xmlNodeList.Count - 1)
            ReDim mv_arrSIGNATURE(v_xmlNodeList.Count - 1)
            ReDim mv_arrCUSTID(v_xmlNodeList.Count - 1)
            ReDim mv_arrVALDATE(v_xmlNodeList.Count - 1)
            ReDim mv_arrEXPDATE(v_xmlNodeList.Count - 1)

            Dim v_strFLDNAME As String = String.Empty
            Dim v_strValue As String = String.Empty

            For i As Integer = 0 To v_xmlNodeList.Count - 1
                For j As Integer = 0 To v_xmlNodeList.Item(i).ChildNodes.Count - 1
                    With v_xmlNodeList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString
                        Select Case Trim(v_strFLDNAME)
                            Case "AUTOID"
                                mv_arrAUTOID(i) = Trim(v_strValue)
                            Case "CUSTID"
                                mv_arrCUSTID(i) = Trim(v_strValue)
                            Case "SIGNATURE"
                                mv_arrSIGNATURE(i) = Trim(v_strValue)
                            Case "VALDATE"
                                mv_arrVALDATE(i) = Trim(v_strValue)
                            Case "EXPDATE"
                                mv_arrEXPDATE(i) = Trim(v_strValue)
                        End Select
                    End With
                Next
            Next

            If mv_arrSIGNATURE.Length > 0 Then
                CType(dtpVALDATE, DateTimePicker).Checked = True
                CType(dtpVALDATE, DateTimePicker).Value = mv_arrVALDATE(mv_intCurrImageIndex)
                CType(dtpVALDATE, DateTimePicker).Text = mv_arrVALDATE(mv_intCurrImageIndex)

                CType(dtpEXPDATE, DateTimePicker).Visible = True
                lblEXPDATE.Visible = True
                CType(dtpEXPDATE, DateTimePicker).Checked = True
                CType(dtpEXPDATE, DateTimePicker).Value = mv_arrEXPDATE(mv_intCurrImageIndex)
                CType(dtpEXPDATE, DateTimePicker).Text = mv_arrEXPDATE(mv_intCurrImageIndex)

                'ImageViewer.Image = GetImageFromString(mv_arrSIGNATURE(mv_intCurrImageIndex))
                pbxSIGNATURE.Image = GetImageFromString(mv_arrSIGNATURE(mv_intCurrImageIndex))
            Else
                CType(dtpEXPDATE, DateTimePicker).Visible = False
                lblEXPDATE.Visible = False
                CType(dtpVALDATE, DateTimePicker).Value = CDate(Me.BusDate)
                CType(dtpVALDATE, DateTimePicker).Text = CDate(Me.BusDate)
                CType(dtpEXPDATE, DateTimePicker).Value = CDate(Me.BusDate)
                CType(dtpEXPDATE, DateTimePicker).Text = CDate(Me.BusDate)
                'imageViewer.Image = Nothing
                'imageViewer.Refresh()
                pbxSIGNATURE.Image = Nothing
                pbxSIGNATURE.Refresh()
            End If
            Cursor.Current = Cursors.Default

        Catch ex As Exception
        End Try
    End Sub

    Protected Overridable Function OnDeleteSignature(Optional ByVal pv_strIsLocal As String = "", Optional ByVal pv_strModule As String = "") As Int32
        Dim v_strKeyFieldName, v_strKeyFieldValue As String
        Dim v_strClause As String

        Dim ParentObjName As String = Me.ObjectName
        Dim ParentClause As String = KeyFieldName & " = '" & txtCUSTID.Text & "'"

        Try
            If MsgBox(ResourceManager.GetString("DelConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                'Update mouse pointer
                Cursor.Current = Cursors.WaitCursor

                If (pv_strIsLocal <> "") And (pv_strModule <> "") Then
                    If (mv_arrAUTOID.Length > 0) Then

                        v_strKeyFieldName = "AUTOID"
                        v_strKeyFieldValue = mv_arrAUTOID(mv_intCurrImageIndex)
                        v_strClause = v_strKeyFieldName & " = " & v_strKeyFieldValue

                        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, pv_strIsLocal, gc_MsgTypeObj, pv_strModule, gc_ActionDelete, , v_strClause, , , , , , , , ParentObjName, ParentClause)
                        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                        Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                        Dim v_strErrorSource, v_strErrorMessage As String

                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                        If v_lngErrorCode <> 0 Then
                            Cursor.Current = Cursors.Default
                            MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Exit Function
                        End If
                        mv_intCurrImageIndex = 0 'Tro ve ban dau
                    End If
                End If
                Cursor.Current = Cursors.Default
                MsgBox(ResourceManager.GetString("DelSuccess"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function


    Private Sub OnDeleteOTRIGHT()
        Try
            If Not OTRIGTGrid.CurrentRow Is Nothing Then
                If MessageBox.Show(ResourceManager.GetString("DelConfirm"), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Dim v_strCUSTID, v_strAUTHCUSTID As String
                    v_strCUSTID = txtCUSTID.Text.Replace(".", "").Trim
                    v_strAUTHCUSTID = Trim(CType(OTRIGTGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTHCUSTID").Value)

                    Dim v_strClause As String
                    v_strClause = "AUTOID" & " = '" & Trim(CType(OTRIGTGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value) & "'"



                    'Call to delete OTRIGHT
                    Dim v_ws As New BDSDeliveryManagement
                    Dim v_strObjMsg As String
                    Dim v_strErrorSource, v_strErrorMessage As String

                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_OTRIGHT, gc_ActionAdhoc, , v_strClause, "OTRIGHT_Delete", , , , , , , ParentObjName, ParentClause)

                    Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)
                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)

                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Sub
                    End If
                    MsgBox(ResourceManager.GetString("DelSuccess"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    LoadOTRIGHT(txtCUSTID.Text)
                End If
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                        & "Error code: System error!" & vbNewLine _
                        & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub LoadCFAUTH(ByVal pv_strCUSTAUTHID As String)
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            If Me.UserLanguage = "VN" Then
                mv_content = "CDCONTENT"
            Else
                mv_content = "EN_CDCONTENT"
            End If
            If Not CFAUTHGrid Is Nothing And Len(pv_strCUSTAUTHID) > 0 Then
                'Clear old data
                'thunt-2019-25-09: thêm SHV

                CFAUTHGrid.DataRows.Clear()
                Dim v_strSQL As String = "SELECT AU.AUTOID,AU.CUSTID,AU.TITLE, AU.CFCUSTID, " & ControlChars.CrLf _
                                    & "case when nvl(AU.CUSTID,'XXX') <> 'XXX' then CF.FULLNAME else AU.FULLNAME end FULLNAME, " & ControlChars.CrLf _
                                    & "case when nvl(AU.CUSTID,'XXX') <> 'XXX' then CF.IDCODE else AU.licenseno end LICENSENO, " & ControlChars.CrLf _
                                    & "case when nvl(AU.CUSTID,'XXX') <> 'XXX' then CF.ADDRESS else AU.ADDRESS end ADDRESS, " & ControlChars.CrLf _
                                    & "case when nvl(AU.CUSTID,'XXX') <> 'XXX' then CF.MOBILESMS else AU.telephone end TELEPHONE, " & ControlChars.CrLf _
                                    & "case when nvl(AU.CUSTID,'XXX') <> 'XXX' then CF.EMAIL else AU.EMAIL end EMAIL, " & ControlChars.CrLf _
                                    & "case when nvl(AU.CUSTID,'XXX') <> 'XXX' then CF.IDPLACE else AU.lnplace end LNPLACE, " & ControlChars.CrLf _
                                    & "case when nvl(AU.CUSTID,'XXX') <> 'XXX' then CF.IDDATE else AU.lniddate end LNIDDATE, " & ControlChars.CrLf _
                                    & "AU.VALDATE,AU.EXPDATE,CD1." & mv_content & " DELTDDESC, AU.DELTD,CD2." & mv_content & "  AUTHTYPE,CD3." & mv_content & "  SHV " & ControlChars.CrLf _
                                    & "FROM CFAUTH AU, CFMAST CF, " & ControlChars.CrLf _
                                    & "(select * from ALLCODE where cdname = 'ACTIVESTS' AND cdtype = 'CF' ) CD1, " & ControlChars.CrLf _
                                    & "(select * from ALLCODE where cdname = 'AUTHTYPE' AND cdtype = 'SA' ) CD2, " & ControlChars.CrLf _
                                    & "(select * from ALLCODE where cdname = 'YESNO' AND cdtype = 'SY' ) CD3 " & ControlChars.CrLf _
                                    & "WHERE AU.CUSTID = CF.CUSTID(+) AND AU.CFCUSTID='" & pv_strCUSTAUTHID & "' " & ControlChars.CrLf _
                                    & "AND AU.STATUS = CD1.CDVAL " & ControlChars.CrLf _
                                    & "AND AU.AUTHTYPE = CD2.CDVAL " & ControlChars.CrLf _
                                    & "AND AU.DELTD = 'N' " & ControlChars.CrLf _
                                    & "AND AU.SHV = CD3.CDVAL "

                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "CF.CFAUTH", _
                    gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                FillDataGrid(CFAUTHGrid, v_strObjMsg, "")
            End If
        Catch ex As Exception
            Throw ex
        Finally
            v_ws = Nothing
        End Try
    End Sub

    Public Sub showFormCFAUTH(ByVal pv_intExecFlag As Integer)
        Dim v_frm As New frmCFAUTH
        Try
            v_frm.ExeFlag = pv_intExecFlag
            v_frm.UserLanguage = UserLanguage
            v_frm.BranchId = BranchId
            v_frm.TellerId = TellerId
            v_frm.TellerRight = TellerRight
            v_frm.GroupCareBy = GroupCareBy
            v_frm.ModuleCode = ModuleCode
            v_frm.ObjectName = "CF.CFAUTH"
            v_frm.TableName = "CFAUTH"
            v_frm.LocalObject = "N"
            v_frm.BusDate = Me.BusDate
            v_frm.Text = String.Empty
            v_frm.CustAUTHID = Me.txtCUSTID.Text
            v_frm.orgcustid = Me.txtCUSTID.Text
            v_frm.ParentObjName = Me.ObjectName
            v_frm.ParentClause = KeyFieldName & " = '" & Me.txtCUSTID.Text & "'"
            v_frm.TellerId = TellerId

            If Not (CFAUTHGrid.CurrentRow Is Nothing) Then
                If Not (pv_intExecFlag = ExecuteFlag.AddNew) Then
                    v_frm.KeyFieldName = "AUTOID"
                    v_frm.KeyFieldType = "N"
                    v_frm.KeyFieldValue = Trim(CType(CFAUTHGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
                End If
                If (pv_intExecFlag = ExecuteFlag.View) Then
                    v_frm.ExeFlag = ExecuteFlag.View
                ElseIf (pv_intExecFlag = ExecuteFlag.Edit) Then
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
                LoadCFAUTH(Me.txtCUSTID.Text)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_frm.Dispose()
        End Try
    End Sub
    Public Sub showFormINFORBANK(ByVal pv_intExecFlag As Integer)
        Dim v_frm As New frmDDMAST
        Dim v_ws As New BDSDeliveryManagement
        Dim v_strOldVal As String = ""
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_strCmdSQL, v_strObjMsg, v_strSQL As String
        Dim v_strTRUADDRESS, v_strAfacctno, v_stracctno As String
        Dim v_nodeList As Xml.XmlNodeList
        Try
            v_strCmdSQL = "Select ACCTNO from AFMAST where CUSTID = '" & Trim(txtCUSTID.Text) & "'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For v_intCount As Integer = 0 To v_nodeList.Count - 1
                For v_int As Integer = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                    With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                        Dim v_strFLDNAME As String = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                        Dim v_strVALUE As String = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()
                        If v_strFLDNAME = "ACCTNO" Then
                            v_strAfacctno = v_strVALUE
                        End If
                    End With
                Next
            Next
            Try
                v_stracctno = Trim(CType(CURRENTACCGrid.CurrentRow, Xceed.Grid.DataRow).Cells("REFCASAACCT").Value)
            Catch ex As Exception

            End Try
            If v_stracctno Is Nothing Then
                v_stracctno = String.Empty
            Else
                v_stracctno = Trim(CType(CURRENTACCGrid.CurrentRow, Xceed.Grid.DataRow).Cells("REFCASAACCT").Value)
            End If
            Me.txtT0LOANLIMIT.Text = 0
            v_frm.ExeFlag = pv_intExecFlag
            v_frm.UserLanguage = UserLanguage
            v_frm.BranchId = BranchId
            v_frm.TellerId = TellerId
            v_frm.CustomerId = Trim(txtCUSTID.Text)
            v_frm.Custodycd = Trim(txtCUSTODYCD.Text)
            v_frm.Afacctno = v_strAfacctno
            v_frm.acctno = v_stracctno
            v_frm.TellerRight = TellerRight
            v_frm.GroupCareBy = GroupCareBy
            v_frm.ModuleCode = "DD"
            v_frm.ObjectName = "DD.DDMAST"
            v_frm.TableName = "DDMAST"
            v_frm.LocalObject = "N"
            v_frm.BusDate = Me.BusDate
            If Not (pv_intExecFlag = ExecuteFlag.AddNew) Then
                v_frm.KeyFieldName = "AUTOID"
                v_frm.KeyFieldType = "N"
                v_frm.KeyFieldValue = Trim(CType(CURRENTACCGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
            End If

            If (pv_intExecFlag = ExecuteFlag.AddNew) Then
                v_frm.ExeFlag = ExecuteFlag.AddNew
            ElseIf (pv_intExecFlag = ExecuteFlag.View) Then
                v_frm.ExeFlag = ExecuteFlag.View

            ElseIf (pv_intExecFlag = ExecuteFlag.Edit) Then
                v_frm.ExeFlag = ExecuteFlag.Edit

            ElseIf (pv_intExecFlag = ExecuteFlag.Delete) Then
                v_frm.ExeFlag = ExecuteFlag.Delete
            End If
            v_frm.ParentObjName = Me.ObjectName
            v_frm.ParentClause = KeyFieldName & " = '" & Trim(txtCUSTID.Text) & "'"
            v_frm.TellerId = TellerId
            v_frm.ShowDialog()
            If (pv_intExecFlag <> ExecuteFlag.View) Then
                LoadCURRENTACC(Me.txtCUSTID.Text)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_frm.Dispose()
        End Try
    End Sub
    Public Sub showFormFABROKERAGE(ByVal pv_intExecFlag As Integer)
        Dim v_frm As New frmSearch(UserLanguage)
        Dim v_dtrCustodycdname As String = "CUSTODYCD"
        Try

            v_frm.BusDate = Me.BusDate
            v_frm.TableName = "CFFABROKERAGE"
            v_frm.ModuleCode = "CF"
            v_frm.AuthCode = "NYNNYYYNNN" 'NYNNYYYNNN
            v_frm.CMDTYPE = "V"
            v_frm.IsLocalSearch = gc_IsNotLocalMsg
            v_frm.SearchOnInit = False
            v_frm.BranchId = Me.BranchId
            v_frm.TellerId = Me.TellerId
            v_frm.LinkValue = Me.txtCUSTODYCD.Text
            v_frm.ParentObjName = Me.ObjectName
            'v_frm.ParentClause = v_dtrCustodycdname & "='" & Me.txtCUSTODYCD.Text & "'"
            v_frm.ParentClause = "CUSTID " & "= '" & Me.txtCUSTID.Text.Trim & "'"
            v_frm.ShowDialog()
            If (pv_intExecFlag <> ExecuteFlag.View) Then
                LoadFABROKERAGE(Me.txtCUSTODYCD.Text)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_frm.Dispose()
        End Try
    End Sub

    'TanPN 07/02/2020 
    Public Sub showFormFAAP(ByVal pv_intExecFlag As Integer)
        Dim v_frm As New frmSearch(UserLanguage)
        Dim v_dtrCustodycdname As String = "CUSTODYCD"
        Try

            v_frm.BusDate = Me.BusDate
            v_frm.TableName = "CFCFLNKAP"
            v_frm.ModuleCode = "CF"
            v_frm.AuthCode = "NYNNYYYNNN" 'NYNNYYYNNN
            v_frm.CMDTYPE = "V"
            v_frm.IsLocalSearch = gc_IsNotLocalMsg
            v_frm.SearchOnInit = False
            v_frm.BranchId = Me.BranchId
            v_frm.TellerId = Me.TellerId
            v_frm.LinkValue = Me.txtCUSTID.Text
            v_frm.ParentObjName = Me.ObjectName
            v_frm.ParentClause = "CUSTID " & "= '" & Me.txtCUSTID.Text.Trim & "'"
            v_frm.ShowDialog()
            If (pv_intExecFlag <> ExecuteFlag.View) Then
                LoadFAAP(Me.txtCUSTID.Text)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_frm.Dispose()
        End Try
    End Sub

    Public Sub showFormFAMEMBERSEXTRA(ByVal pv_intExecFlag As Integer)
        Try
            Dim v_frm As frmFAMEMBERSEXTRA
            v_frm = New frmFAMEMBERSEXTRA
            v_frm.ExeFlag = pv_intExecFlag
            v_frm.UserLanguage = UserLanguage
            v_frm.ModuleCode = "CF"
            v_frm.ObjectName = Me.ObjectName '"FA.FAMEMBERSEXTRA"
            v_frm.TableName = "FABROKERAGEXTRA" '"FAMEMBERSEXTRA"
            v_frm.LocalObject = "N"
            v_frm.BusDate = Me.BusDate
            v_frm.Text = ""
            v_frm.CUSTID = Trim(Me.txtCUSTID.Text)
            v_frm.CUSTODYCD = Trim(Me.txtCUSTODYCD.Text)
            v_frm.MEMBERID = Trim(CType(FABROKERAGEGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)

            'If Not (pv_intExecFlag = ExecuteFlag.AddNew) Then
            '    v_frm.KeyFieldName = "AUTOID"
            '    v_frm.KeyFieldType = "N"
            '    v_frm.KeyFieldValue = Trim(CType(ISSUERGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
            'End If

            If (pv_intExecFlag = ExecuteFlag.AddNew) Then
                v_frm.ExeFlag = ExecuteFlag.AddNew
            ElseIf (pv_intExecFlag = ExecuteFlag.View) Then
                v_frm.ExeFlag = ExecuteFlag.View
            ElseIf (pv_intExecFlag = ExecuteFlag.Edit) Then
                v_frm.ExeFlag = ExecuteFlag.Edit
            ElseIf (pv_intExecFlag = ExecuteFlag.Delete) Then
                v_frm.ExeFlag = ExecuteFlag.Delete
            End If

            v_frm.ParentObjName = Me.ObjectName
            v_frm.ParentClause = KeyFieldName & " = '" & txtCUSTID.Text & "'"
            v_frm.TellerId = TellerId
            v_frm.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadCFRELATION(ByVal pv_strCUSTID As String)
        Try
            Dim v_strSQL As String
            If Not CFRELATIONGrid Is Nothing And Len(pv_strCUSTID) > 0 Then
                'Remove cÃ¡c báº£n ghi cÅ©
                CFRELATIONGrid.DataRows.Clear()
                If UserLanguage = "VN" Then
                    v_strSQL = "SELECT RE.AUTOID,CD2.CDCONTENT ACTIVES,RE.CUSTID,RE.RECUSTID, CD.CDCONTENT RETYPE, RE.DESCRIPTION,RE.TITLECFRELATION,  RE.FULLNAME,RE.LICENSENO ,  " & _
                        " RE.ADDRESS,RE.TELEPHONE,RE.LNPLACE , RE.LNIDDATE,RE.ACDATE FROM CFRELATION RE, ALLCODE CD, ALLCODE CD2 WHERE CD.CDTYPE='CF'  " & _
                        " AND CD.CDNAME='RETYPE' AND trim(CD.CDVAL)=trim(RE.RETYPE) AND RE.ACTIVES=CD2.CDVAL AND CD2.CDTYPE = 'CF' AND CD2.CDNAME = 'ACTIVESTS' AND TRIM(RE.CUSTID)='" & pv_strCUSTID & "'"
                Else
                    v_strSQL = "SELECT RE.AUTOID,CD2.EN_CDCONTENT ACTIVES,RE.CUSTID,RE.RECUSTID, CD.EN_CDCONTENT RETYPE, RE.DESCRIPTION,RE.TITLECFRELATION,  RE.FULLNAME,RE.LICENSENO ,  " & _
                        " RE.ADDRESS,RE.TELEPHONE,RE.LNPLACE , RE.LNIDDATE,RE.ACDATE FROM CFRELATION RE, ALLCODE CD, ALLCODE CD2 WHERE CD.CDTYPE='CF'  " & _
                        " AND CD.CDNAME='RETYPE' AND trim(CD.CDVAL)=trim(RE.RETYPE) AND RE.ACTIVES=CD2.CDVAL AND CD2.CDTYPE = 'CF' AND CD2.CDNAME = 'ACTIVESTS' AND TRIM(RE.CUSTID)='" & pv_strCUSTID & "'"
                End If
                Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "CF.CFRELATION", _
                    gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                FillDataGrid(CFRELATIONGrid, v_strObjMsg, "")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadCFCONTACT(ByVal pv_strCUSTID As String)
        Try
            If UserLanguage = "VN" Then
                mv_content = "CDCONTENT"
            Else
                mv_content = "EN_CDCONTENT"
            End If
            If Not CFCONTACTGrid Is Nothing And Len(pv_strCUSTID) > 0 Then
                CFCONTACTGrid.DataRows.Clear()
                Dim v_strSQL As String = "SELECT MST.AUTOID, CD." & mv_content & " CONTACTTYPE, MST.PERSON, MST.ADDRESS, MST.PHONE, MST.FAX,MST.TITLECONTACT, MST.EMAIL, MST.DESCRIPTION " & _
                    "FROM CFCONTACT MST, ALLCODE CD WHERE " & _
                    "CD.CDTYPE='CF' AND CD.CDNAME='CONTACTTYPE' AND CD.CDVAL=MST.TYPE AND TRIM(MST.CUSTID)='" & pv_strCUSTID & "'"
                Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "CF.CFCONTACT", _
                    gc_ActionInquiry, v_strSQL, , , , , , , , , , , UserLanguage) 'thunt-2019-27-09
                v_ws.Message(v_strObjMsg)
                Dim v_strResourceManager As String
                v_strResourceManager = gc_RootNamespace & "." & Me.Name & "-" & UserLanguage
                FillDataGrid(CFCONTACTGrid, v_strObjMsg, v_strResourceManager)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadISSUER(ByVal pv_strCUSTID As String)
        Try
            If UserLanguage = "VN" Then
                mv_content = "CDCONTENT"
            Else
                mv_content = "EN_CDCONTENT"
            End If
            If Not ISSUERGrid Is Nothing And Len(pv_strCUSTID) > 0 Then
                ISSUERGrid.DataRows.Clear()
                Dim v_strSQL As String = "SELECT I.AUTOID,I.ISSUERID ,I.CUSTID ,ISS.FULLNAME,A0." & mv_content & " ROLECD,I.IDPLACE ,I.IDDATE ,I.IDEXPIRED ,I.LICENSENO,I.DESCRIPTION   FROM ISSUER_MEMBER I ,ALLCODE A0 ,ISSUERS ISS WHERE ISS.ISSUERID =I.ISSUERID AND A0.CDTYPE = 'SA' AND A0.CDNAME = 'ROLECD' AND A0.CDVAL= ROLECD and I.CUSTID = '" & pv_strCUSTID & "'"
                Dim v_ws As New BDSDeliveryManagement
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "CF.CFMAST", _
                    gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                FillDataGrid(ISSUERGrid, v_strObjMsg, "")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadAFMAST(ByVal pv_strCUSTID As String)
        Try
            If Me.UserLanguage = "VN" Then
                mv_content = "CDCONTENT"
            Else
                mv_content = "EN_CDCONTENT"
            End If
            If Not AFMASTGrid Is Nothing And Len(pv_strCUSTID) > 0 Then
                AFMASTGrid.DataRows.Clear()
                'Dim v_strSQL As String = "select AF.bankname,AF.bankacctno,af.acctno afacctno, aft.actype, aft.typename, c1.cdcontent status,c4.cdcontent AUTOTRF, c2.cdcontent corebank, c3.cdcontent autoadv, mrt.actype || ' : ' || mrt.typename mrtype, cit.actype || ' : ' || cit.typename citype  " & ControlChars.CrLf _
                '                    & "from cfmast cf, afmast af, aftype aft, mrtype mrt, citype cit, allcode c1, allcode c2,allcode c4, allcode c3    " & ControlChars.CrLf _
                '                    & "where cf.custid = af.custid and af.actype = aft.actype and aft.mrtype = mrt.actype and aft.citype = cit.actype and cf.custid = '" & pv_strCUSTID & "' " & ControlChars.CrLf _
                '                    & "and c1.cdtype = 'CF' and c1.cdname = 'STATUS' and c1.cdval = af.status   " & ControlChars.CrLf _
                '                    & "and c2.cdtype = 'SY' and c2.cdname = 'YESNO' and c2.cdval = af.corebank   " & ControlChars.CrLf _
                '                    & "and c3.cdtype = 'SY' and c3.cdname = 'YESNO' and c3.cdval = af.autoadv   " & ControlChars.CrLf _
                '                    & "and c4.cdtype = 'SY' and c4.cdname = 'YESNO' and c4.cdval = af.autotrf   " & ControlChars.CrLf _
                '                    & "order by af.acctno"
                Dim v_strSQL As String = "select AF.bankname,AF.bankacctno,af.acctno afacctno, c1." & mv_content & " status,c4." & mv_content & " AUTOTRF, c2." & mv_content & " corebank, c3." & mv_content & " autoadv " _
                                    & "from cfmast cf, afmast af, allcode c1, allcode c2,allcode c4, allcode c3    " & ControlChars.CrLf _
                                    & "where cf.custid = af.custid and cf.custid = '" & pv_strCUSTID & "' " & ControlChars.CrLf _
                                    & "and c1.cdtype = 'CF' and c1.cdname = 'STATUS' and c1.cdval = af.status   " & ControlChars.CrLf _
                                    & "and c2.cdtype = 'SY' and c2.cdname = 'YESNO' and c2.cdval = af.corebank   " & ControlChars.CrLf _
                                    & "and c3.cdtype = 'SY' and c3.cdname = 'YESNO' and c3.cdval = af.autoadv   " & ControlChars.CrLf _
                                    & "and c4.cdtype = 'SY' and c4.cdname = 'YESNO' and c4.cdval = af.autotrf   " & ControlChars.CrLf _
                                    & "order by af.acctno"
                Dim v_ws As New BDSDeliveryManagement
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "CF.CFMAST", _
                    gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                FillDataGrid(AFMASTGrid, v_strObjMsg, "")
            End If
        Catch ex As Exception
        End Try
    End Sub


    Public Sub showFormCFOTHERACC(ByVal pv_intExecFlag As Integer)
        Dim v_frm As New frmCFOTHERACC
        Try
            v_frm.ExeFlag = pv_intExecFlag
            v_frm.UserLanguage = UserLanguage
            v_frm.BranchId = BranchId
            v_frm.ModuleCode = "SA"
            v_frm.ObjectName = "SA.CFOTHERACC"
            v_frm.TableName = "CFOTHERACC"
            v_frm.LocalObject = "N"
            v_frm.BusDate = Me.BusDate
            v_frm.Text = String.Empty
            v_frm.CustomerId = Me.txtCUSTID.Text
            v_frm.ParentObjName = Me.ObjectName
            v_frm.ParentClause = KeyFieldName & " = '" & Me.txtCUSTID.Text & "'"
            v_frm.TellerId = TellerId
            If Not (pv_intExecFlag = ExecuteFlag.AddNew) Then
                v_frm.KeyFieldName = "AUTOID"
                v_frm.KeyFieldType = "N"
                v_frm.KeyFieldValue = Trim(CType(CFOTHERACCGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
            End If
            v_frm.ShowDialog()

            If (pv_intExecFlag <> ExecuteFlag.View) Then
                LoadCFOTHERACC(Me.txtCUSTID.Text)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_frm.Dispose()
        End Try
    End Sub

    Private Sub LoadCFOTHERACC(ByVal pv_strCUSTID As String)
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            If UserLanguage = "VN" Then
                mv_content = "CDCONTENT"
            Else
                mv_content = "EN_CDCONTENT"
            End If
            If Len(pv_strCUSTID) > 0 Then
                CFOTHERACCGrid.DataRows.Clear()
                Dim v_strSQL As String = "select CF.AUTOID, c1." & mv_content & " TRFTYPE, case when cf.type = 0 then cf.ciaccount else '---' end ciaccount, " & ControlChars.CrLf _
                                & " case when cf.type = 0 then cf.ciname else '---' end ciname, " & ControlChars.CrLf _
                                & " case when cf.type = 1 then cf.custid else '---' end custid,  " & ControlChars.CrLf _
                                & " case when cf.type = 1 then cf.bankacc else '---' end bankacc,  " & ControlChars.CrLf _
                                & " case when cf.type = 1 then cf.bankacname else '---' end bankacname, " & ControlChars.CrLf _
                                & " case when cf.type = 1 then cf.bankname else '---' end  bankname,  " & ControlChars.CrLf _
                                & " case when cf.type = 1 then cf.acnidcode else '---' end acnidcode,  " & ControlChars.CrLf _
                                & " case when cf.type = 1 then cf.acniddate else null end acniddate,  " & ControlChars.CrLf _
                                & " case when cf.type = 1 then cf.acnidplace else '---' end acnidplace,  " & ControlChars.CrLf _
                                & " case when cf.type = 1 then cf.feecd else '---' end feecd,  " & ControlChars.CrLf _
                                & " case when cf.type = 1 then cf.citybank else '---' end citybank,  " & ControlChars.CrLf _
                                & " case when cf.type = 1 then cf.cityef else '---' end cityef,  " & ControlChars.CrLf _
                                & " nvl(cf.tlid,'---') tlid, nvl(tl1.tlname,'---') tlname,  " & ControlChars.CrLf _
                                & " cf.createddt, nvl(cf.LAST_OFFID,cf.offid) offid, nvl(tl2.tlname,'---') offname, nvl(cf.LAST_APPRVDT,cf.apprvdt) apprvdt,  " & ControlChars.CrLf _
                                & " cf.status  " & ControlChars.CrLf _
                                & "from cfotheracc cf, allcode c1,  tlprofiles tl1, tlprofiles tl2  " & ControlChars.CrLf _
                                & "where cf.deltd='N' and c1.cdname = 'TYPE' and c1.cdtype = 'AF' and cf.type = c1.cdval " & ControlChars.CrLf _
                                & " --and c2.cdname = 'STATUS' and c2.cdtype = 'CF' and cf.status = c2.cdval " & ControlChars.CrLf _
                                & " and cf.tlid = tl1.tlid(+) and nvl(cf.LAST_OFFID,cf.offid) = tl2.tlid(+) and cf.cfcustid = '" & pv_strCUSTID & "'"
                'AnTB add them thong tin nguoi tao, nguoi duyet, trang thai
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "CF.CFMAST", _
                    gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                FillDataGrid(CFOTHERACCGrid, v_strObjMsg, "")
            End If
        Catch ex As Exception
            Throw ex
        Finally
            v_ws = Nothing
        End Try
    End Sub


    Private Sub LoadTemplates(ByVal pv_strCUSTID As String)
        Dim v_xmlDocument As New XmlDocument
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            Dim v_strCmdInquiry, v_strObjMsg As String

            If Not AFTEMPLATESGrid Is Nothing And Len(pv_strCUSTID) > 0 Then
                'Clear old data
                AFTEMPLATESGrid.DataRows.Clear()

                v_strCmdInquiry = "SELECT AUTOID AUTOID, NAME, SUBJECT" & ControlChars.CrLf & _
                "FROM (SELECT A.AUTOID, T.NAME, T.SUBJECT FROM AFTEMPLATES A, TEMPLATES T WHERE A.TEMPLATE_CODE = T.CODE AND ISACTIVE = 'Y' AND A.CUSTID = '{0}') "

                v_strCmdInquiry = String.Format(v_strCmdInquiry, pv_strCUSTID)

                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strCmdInquiry)
                v_ws.Message(v_strObjMsg)
                FillDataGrid(AFTEMPLATESGrid, v_strObjMsg, "")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Sub


    Public Sub showFormRELATION(ByVal pv_intExecFlag As Integer)
        Try
            Dim v_frm As Object
            v_frm = New frmCFRELATION
            v_frm.BranchId = BranchId
            v_frm.ExeFlag = pv_intExecFlag
            v_frm.UserLanguage = UserLanguage
            v_frm.ModuleCode = ModuleCode
            v_frm.ObjectName = "CF.CFRELATION"
            v_frm.TableName = "CFRELATION"
            v_frm.LocalObject = "N"
            v_frm.Text = ""
            v_frm.CustomerId = Trim(Me.txtCUSTID.Text)
            v_frm.busdate = Me.BusDate
            If Not (pv_intExecFlag = ExecuteFlag.AddNew) Then
                v_frm.KeyFieldName = "AUTOID"
                v_frm.KeyFieldType = "N"
                v_frm.KeyFieldValue = Trim(CType(CFRELATIONGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
            End If

            If (pv_intExecFlag = ExecuteFlag.AddNew) Then
                v_frm.ExeFlag = ExecuteFlag.AddNew
            ElseIf (pv_intExecFlag = ExecuteFlag.View) Then
                v_frm.ExeFlag = ExecuteFlag.View

            ElseIf (pv_intExecFlag = ExecuteFlag.Edit) Then
                v_frm.ExeFlag = ExecuteFlag.Edit

            ElseIf (pv_intExecFlag = ExecuteFlag.Delete) Then
                v_frm.ExeFlag = ExecuteFlag.Delete
            End If
            v_frm.ParentObjName = Me.ObjectName
            v_frm.ParentClause = KeyFieldName & " = '" & txtCUSTID.Text & "'"
            v_frm.TellerId = TellerId
            v_frm.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Protected Overridable Function OnDeleterelation(Optional ByVal pv_strIsLocal As String = "", Optional ByVal pv_strModule As String = "") As Int32
        Dim v_strKeyFieldName, v_strKeyFieldValue As String
        Dim v_strClause As String
        Dim ParentObjName As String = Me.ObjectName
        Dim ParentClause As String = KeyFieldName & " = '" & txtCUSTID.Text & "'"

        Try
            If MsgBox(ResourceManager.GetString("DelConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                'Update mouse pointer
                Cursor.Current = Cursors.WaitCursor

                If (pv_strIsLocal <> "") And (pv_strModule <> "") Then
                    If Not (CFRELATIONGrid.CurrentRow Is Nothing) Then
                        v_strKeyFieldName = CType(CFRELATIONGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").FieldName
                        v_strKeyFieldValue = CType(CFRELATIONGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value

                        v_strClause = v_strKeyFieldName & " = " & v_strKeyFieldValue

                        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, pv_strIsLocal, gc_MsgTypeObj, pv_strModule, gc_ActionDelete, , v_strClause, , , , , , , , ParentObjName, ParentClause)
                        Dim v_ws As New BDSDeliveryManagement
                        Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                        Dim v_strErrorSource, v_strErrorMessage As String

                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                        If v_lngErrorCode <> 0 Then
                            'Update mouse pointer
                            Cursor.Current = Cursors.Default
                            MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Exit Function
                        End If
                        CFRELATIONGrid.CurrentRow.Remove()
                    Else
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(ResourceManager.GetString("frmSearch.NotSelected"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
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
        End Try
    End Function

    Private Sub ShowContactEvent(ByVal sender As System.Object)

        Try
            Dim v_objCFCONTACT As New frmCFCONTACT
            'Assign properties to CFCONTACT form
            v_objCFCONTACT.ObjectName = OBJNAME_CF_CFCONTACT
            v_objCFCONTACT.TellerId = TellerId
            v_objCFCONTACT.BranchId = BranchId
            v_objCFCONTACT.CustomerId = Trim(txtCUSTID.Text)
            v_objCFCONTACT.LocalObject = LocalObject
            v_objCFCONTACT.UserLanguage = UserLanguage
            v_objCFCONTACT.ModuleCode = ModuleCode

            If Not (sender Is btnCFCONTACT_ADD) Then
                v_objCFCONTACT.KeyFieldName = "AUTOID"
                v_objCFCONTACT.KeyFieldType = "N"
                v_objCFCONTACT.KeyFieldValue = Trim(CType(CFCONTACTGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
                v_objCFCONTACT.TableName = "CFCONTACT"
            End If

            If (sender Is btnCFCONTACT_ADD) Then
                v_objCFCONTACT.ExeFlag = ExecuteFlag.AddNew
            ElseIf (sender Is btnCFCONTACT_VIEW) Then
                v_objCFCONTACT.ExeFlag = ExecuteFlag.View
            ElseIf (sender Is btnCFCONTACT_EDIT) Then
                v_objCFCONTACT.ExeFlag = ExecuteFlag.Edit
            ElseIf (sender Is btnCFCONTACT_DELETE) Then
                v_objCFCONTACT.ExeFlag = ExecuteFlag.Delete
            End If

            v_objCFCONTACT.ParentObjName = Me.ObjectName
            v_objCFCONTACT.ParentClause = KeyFieldName & " = '" & txtCUSTID.Text & "'"
            v_objCFCONTACT.TellerId = TellerId
            v_objCFCONTACT.ShowDialog()

        Catch ex As Exception

        End Try
    End Sub
    Protected Overridable Function OnDeleteinforbank(Optional ByVal pv_strIsLocal As String = "", Optional ByVal pv_strModule As String = "") As Int32
        Dim v_strKeyFieldName, v_strKeyFieldValue, v_strObjMsg, v_strCmdInquiry As String
        Dim v_strClause As String
        Dim ParentObjName As String = Me.ObjectName
        Dim ParentClause As String = KeyFieldName & " = '" & txtCUSTID.Text & "'"
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strErrorSource, v_strErrorMessage As String
        Dim v_lngErrorCode As Long
        Try

            If MsgBox(ResourceManager.GetString("DelConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                'Update mouse pointer
                Cursor.Current = Cursors.WaitCursor

                If (pv_strIsLocal <> "") And (pv_strModule <> "") Then
                    If Not (CURRENTACCGrid.CurrentRow Is Nothing) Then
                        v_strKeyFieldName = CType(CURRENTACCGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").FieldName
                        v_strKeyFieldValue = CType(CURRENTACCGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value

                        v_strClause = v_strKeyFieldName & " = " & v_strKeyFieldValue

                        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, pv_strIsLocal, gc_MsgTypeObj, pv_strModule, gc_ActionDelete, , v_strClause, , , , , , , , ParentObjName, ParentClause)
                        v_lngErrorCode = v_ws.Message(v_strObjMsg)
                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                        If v_lngErrorCode <> 0 Then
                            'Update mouse pointer
                            Cursor.Current = Cursors.Default
                            MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Exit Function
                        End If

                        CURRENTACCGrid.CurrentRow.Remove()
                    Else
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default

                        MsgBox(ResourceManager.GetString("frmSearch.NotSelected"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)

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
        End Try
    End Function
    Protected Overridable Function OnDeleteContact(Optional ByVal pv_strIsLocal As String = "", Optional ByVal pv_strModule As String = "") As Int32
        Dim v_strKeyFieldName, v_strKeyFieldValue As String
        Dim v_strClause As String
        Dim ParentObjName As String = Me.ObjectName
        Dim ParentClause As String = KeyFieldName & " = '" & txtCUSTID.Text & "'"

        Try
            If MsgBox(ResourceManager.GetString("DelConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                'Update mouse pointer
                Cursor.Current = Cursors.WaitCursor

                If (pv_strIsLocal <> "") And (pv_strModule <> "") Then
                    If Not (CFCONTACTGrid.CurrentRow Is Nothing) Then
                        v_strKeyFieldName = CType(CFCONTACTGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").FieldName
                        v_strKeyFieldValue = CType(CFCONTACTGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value

                        v_strClause = v_strKeyFieldName & " = " & v_strKeyFieldValue

                        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, pv_strIsLocal, gc_MsgTypeObj, pv_strModule, gc_ActionDelete, , v_strClause, , , , , , , , ParentObjName, ParentClause)
                        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                        Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                        Dim v_strErrorSource, v_strErrorMessage As String

                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                        If v_lngErrorCode <> 0 Then
                            'Update mouse pointer
                            Cursor.Current = Cursors.Default
                            MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Exit Function
                        End If

                        CFCONTACTGrid.CurrentRow.Remove()
                    Else
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(ResourceManager.GetString("frmSearch.NotSelected"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
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
        End Try
    End Function

    Public Sub showFormISSUER(ByVal pv_intExecFlag As Integer)
        Try
            Dim v_frm As frmISSUER_MEMBER
            v_frm = New frmISSUER_MEMBER
            v_frm.ExeFlag = pv_intExecFlag
            v_frm.UserLanguage = UserLanguage
            v_frm.ModuleCode = "SA"
            v_frm.ObjectName = "SA.ISSUER_MEMBER"
            v_frm.TableName = "ISSUER_MEMBER"
            v_frm.LocalObject = "N"
            v_frm.BusDate = Me.BusDate
            v_frm.Text = ""
            v_frm.CUSTID = Trim(Me.txtCUSTID.Text)
            If Not (pv_intExecFlag = ExecuteFlag.AddNew) Then
                v_frm.KeyFieldName = "AUTOID"
                v_frm.KeyFieldType = "N"
                v_frm.KeyFieldValue = Trim(CType(ISSUERGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
            End If

            If (pv_intExecFlag = ExecuteFlag.AddNew) Then
                v_frm.ExeFlag = ExecuteFlag.AddNew
            ElseIf (pv_intExecFlag = ExecuteFlag.View) Then
                v_frm.ExeFlag = ExecuteFlag.View
            ElseIf (pv_intExecFlag = ExecuteFlag.Edit) Then
                v_frm.ExeFlag = ExecuteFlag.Edit
            ElseIf (pv_intExecFlag = ExecuteFlag.Delete) Then
                v_frm.ExeFlag = ExecuteFlag.Delete
            End If

            v_frm.ParentObjName = Me.ObjectName
            v_frm.ParentClause = KeyFieldName & " = '" & txtCUSTID.Text & "'"
            v_frm.TellerId = TellerId
            v_frm.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Protected Overridable Function OnDeleteIssuer(Optional ByVal pv_strIsLocal As String = "", Optional ByVal pv_strModule As String = "") As Int32
        Dim v_strKeyFieldName, v_strKeyFieldValue As String
        Dim v_strClause As String
        Dim ParentObjName As String = Me.ObjectName
        Dim ParentClause As String = KeyFieldName & " = '" & txtCUSTID.Text & "'"

        Try
            If MsgBox(ResourceManager.GetString("DelConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                'Update mouse pointer
                Cursor.Current = Cursors.WaitCursor

                If (pv_strIsLocal <> "") And (pv_strModule <> "") Then
                    If Not (ISSUERGrid.CurrentRow Is Nothing) Then
                        v_strKeyFieldName = CType(ISSUERGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").FieldName
                        v_strKeyFieldValue = CType(ISSUERGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value

                        v_strClause = v_strKeyFieldName & " = " & v_strKeyFieldValue

                        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, pv_strIsLocal, gc_MsgTypeObj, pv_strModule, gc_ActionDelete, , v_strClause, , , , , , , , ParentObjName, ParentClause)
                        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                        Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                        Dim v_strErrorSource, v_strErrorMessage As String

                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                        If v_lngErrorCode <> 0 Then
                            'Update mouse pointer
                            Cursor.Current = Cursors.Default
                            MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Exit Function
                        End If

                        ISSUERGrid.CurrentRow.Remove()
                    Else
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
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
        End Try
    End Function

    Public Sub showFormAFMAST(ByVal pv_intExecFlag As Integer)
        Try
            Dim v_frm As frmAFMAST
            v_frm = New frmAFMAST

            v_frm.ExeFlag = pv_intExecFlag
            v_frm.UserLanguage = UserLanguage
            v_frm.ModuleCode = "CF"
            v_frm.ObjectName = "CF.AFMAST"
            v_frm.TableName = "AFMAST"
            v_frm.LocalObject = "N"

            v_frm.Text = ""
            v_frm.TellerId = TellerId
            v_frm.TellerRight = TellerRight
            v_frm.GroupCareBy = GroupCareBy
            v_frm.AuthString = AuthString
            v_frm.BranchId = BranchId
            v_frm.BusDate = Me.BusDate
            v_frm.ParentObjName = Me.ObjectName
            v_frm.ParentClause = KeyFieldName & " = '" & txtCUSTID.Text & "'"
            v_frm.TellerId = TellerId
            v_frm.CustID = txtCUSTID.Text
            v_frm.CustAtCOM = cboCUSTATCOM.SelectedValue
            v_frm.CustodyCD = txtCUSTODYCD.Text
            v_frm.KeyFieldName = "ACCTNO"
            v_frm.KeyFieldType = "C"
            v_frm.CareBy = cboCAREBY.SelectedValue
            'DieuNDA 28/12/2016 Revert phan cua Vu
            'v_frm.ISEDIT = mv_strISEDIT
            'End DieuNDA 28/12/2016 Revert phan cua Vu

            If pv_intExecFlag <> ExecuteFlag.AddNew Then
                v_frm.KeyFieldValue = Trim(CType(AFMASTGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AFACCTNO").Value)
            End If

            If (pv_intExecFlag = ExecuteFlag.AddNew) Then
                v_frm.ExeFlag = ExecuteFlag.AddNew
            ElseIf (pv_intExecFlag = ExecuteFlag.View) Then
                v_frm.ExeFlag = ExecuteFlag.View
            ElseIf (pv_intExecFlag = ExecuteFlag.Edit) Then
                v_frm.ExeFlag = ExecuteFlag.Edit
            ElseIf (pv_intExecFlag = ExecuteFlag.Delete) Then
                v_frm.ExeFlag = ExecuteFlag.Delete
            End If

            v_frm.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub


    Public Sub showFormREAFLNK(ByVal pv_intExecFlag As Integer)
        Try
            Dim v_frm As frmREAFLNK
            v_frm = New frmREAFLNK

            v_frm.ExeFlag = pv_intExecFlag
            v_frm.UserLanguage = UserLanguage
            v_frm.ModuleCode = "RE"
            v_frm.ObjectName = "RE.REAFLNK"
            v_frm.TableName = "REAFLNK"
            v_frm.LocalObject = "N"

            v_frm.Text = ""
            v_frm.TellerId = TellerId
            v_frm.TellerRight = TellerRight
            v_frm.GroupCareBy = GroupCareBy
            v_frm.AuthString = AuthString
            v_frm.BranchId = BranchId
            v_frm.BusDate = Me.BusDate
            v_frm.ParentObjName = Me.ObjectName
            v_frm.ParentClause = KeyFieldName & " = '" & Me.txtCUSTID.Text & "'"
            v_frm.TellerId = TellerId
            v_frm.CustID = Me.txtCUSTID.Text
            v_frm.KeyFieldName = "AUTOID"
            v_frm.KeyFieldType = "N"

            If pv_intExecFlag <> ExecuteFlag.AddNew Then
                v_frm.KeyFieldValue = Trim(CType(REAFLNKGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
            End If

            If (pv_intExecFlag = ExecuteFlag.AddNew) Then
                v_frm.ExeFlag = ExecuteFlag.AddNew
            ElseIf (pv_intExecFlag = ExecuteFlag.View) Then
                v_frm.ExeFlag = ExecuteFlag.View
            ElseIf (pv_intExecFlag = ExecuteFlag.Edit) Then
                v_frm.ExeFlag = ExecuteFlag.Edit
            ElseIf (pv_intExecFlag = ExecuteFlag.Delete) Then
                v_frm.ExeFlag = ExecuteFlag.Delete
            End If

            v_frm.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub


    'Public Sub showFormRPTAFMAST(ByVal pv_intExecFlag As Integer)
    '    Dim v_frm As New frmRPTAFMAST
    '    Try
    '        v_frm.ExeFlag = pv_intExecFlag
    '        v_frm.UserLanguage = UserLanguage
    '        v_frm.BranchId = BranchId
    '        v_frm.TellerId = TellerId
    '        v_frm.ModuleCode = ModuleCode
    '        v_frm.ObjectName = "CF.RPTAFMAST"
    '        v_frm.TableName = "RPTAFMAST"
    '        v_frm.LocalObject = "N"
    '        v_frm.BusDate = Me.BusDate
    '        v_frm.Text = String.Empty
    '        v_frm.CustID = Me.txtCUSTID.Text
    '        v_frm.ParentObjName = Me.ObjectName
    '        v_frm.ParentClause = KeyFieldName & " = '" & txtCUSTID.Text & "'"
    '        v_frm.TellerId = TellerId
    '        If Not (CFRPTAFMASTGrid.CurrentRow Is Nothing) Then
    '            If Not (pv_intExecFlag = ExecuteFlag.AddNew) Then
    '                v_frm.KeyFieldName = "AUTOID"
    '                v_frm.KeyFieldType = "N"
    '                v_frm.KeyFieldValue = Trim(CType(CFRPTAFMASTGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
    '            End If
    '            If (pv_intExecFlag = ExecuteFlag.View) Then
    '                v_frm.ExeFlag = ExecuteFlag.View
    '            ElseIf (pv_intExecFlag = ExecuteFlag.Edit) Then
    '                v_frm.ExeFlag = ExecuteFlag.Edit
    '            ElseIf (pv_intExecFlag = ExecuteFlag.Delete) Then
    '                v_frm.ExeFlag = ExecuteFlag.Delete
    '            End If
    '            v_frm.ShowDialog()

    '        Else
    '            If (pv_intExecFlag = ExecuteFlag.AddNew) Then
    '                v_frm.ExeFlag = ExecuteFlag.AddNew
    '                v_frm.ShowDialog()
    '            End If
    '        End If
    '        If (pv_intExecFlag <> ExecuteFlag.View) Then
    '            LoadCFRPTAFMAST(Me.txtCUSTID.Text)
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
    '    Finally
    '        v_frm = Nothing
    '    End Try
    'End Sub

    Private Sub LoadCFRPTAFMAST(ByVal pv_strCUSTID As String)
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            If UserLanguage = "VN" Then
                mv_content = "CDCONTENT"
            Else
                mv_content = "EN_CDCONTENT"
            End If
            If Not CFRPTAFMASTGrid Is Nothing And Len(pv_strCUSTID) > 0 Then
                'Clear data
                CFRPTAFMASTGrid.DataRows.Clear()
                Dim v_strSQL As String = "SELECT RAF.AUTOID, RAF.RPTID CMDCODE,RPT.DESCRIPTION CMDTITLE, c1." & mv_content & " EXCYCLE , RAF.EXPDATE EXPDATE, c2." & mv_content & " STATUS " _
                & " FROM RPTAFMAST RAF , RPTMASTER RPT, ALLCODE C1, ALLCODE C2  " _
                & " WHERE RPT.RPTID=RAF.RPTID AND TRIM(RAF.CUSTID)='" & pv_strCUSTID & "'" _
                & " and c1.cdtype = 'CF' and c1.cdname = 'EXCYCLE' and c1.cdval = RAF.EXCYCLE " _
                & " and c2.cdtype = 'CF' and c2.cdname = 'STATUSRPT' and c2.cdval = RAF.STATUS "

                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "CF.RPTAFMAST", _
                    gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                FillDataGrid(CFRPTAFMASTGrid, v_strObjMsg, "")
            End If
        Catch ex As Exception
            Throw ex
        Finally
            v_ws = Nothing
        End Try
    End Sub
    'thunt-add tabpage-2019-20-09
    Private Sub LoadCURRENTACC(ByVal pv_strCUSTID As String)
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_content As String
        Try
            If UserLanguage = "VN" Then
                v_content = "CDCONTENT"
            Else
                v_content = "EN_CDCONTENT"
            End If
            If Not CURRENTACCGrid Is Nothing And Len(pv_strCUSTID) > 4 Then
                'Clear data
                CURRENTACCGrid.DataRows.Clear()
                Dim v_strSQL As String = "SELECT AUTOID ,AL." & v_content & " ACCOUNTTYPE,REFCASAACCT, CCYCD, AL2." & v_content & " ISDEFAULT,OPNDATE, al3." & v_content & " status, AL4." & v_content & " AUTOTRANSFER, AL5." & v_content & " PAYMENTFEE, dd.status statuscd " _
                                       & "FROM DDMAST DD, ALLCODE AL, ALLCODE AL2, ALLCODE AL3, ALLCODE AL4, ALLCODE AL5 " _
                                       & "WHERE DD.ISDEFAULT=AL2.CDVAL AND AL2.CDNAME ='YESNO' AND AL2.CDTYPE='SY' " _
                                       & "AND DD.AUTOTRANSFER=AL4.CDVAL AND AL4.CDNAME = 'YESNO' AND AL4.CDTYPE = 'SY' " _
                                       & "AND DD.STATUS=AL3.CDVAL AND AL3.CDNAME='STATUS' AND AL3.CDTYPE='CF' " _
                                       & "AND DD.PAYMENTFEE=AL5.CDVAL AND AL5.CDNAME='YESNO' AND AL5.CDTYPE='SY' " _
                                       & "AND DD.ACCOUNTTYPE=AL.CDVAL AND AL.CDNAME='ACCOUNTTYPE' AND AL.CDTYPE='DD' AND DD.CUSTID= '" & pv_strCUSTID & "' "

                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "DD.DDMAST", _
                    gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                FillDataGrid(CURRENTACCGrid, v_strObjMsg, "")
            End If
        Catch ex As Exception
            Throw ex
        Finally
            v_ws = Nothing
        End Try
    End Sub
    Private Sub LoadFABROKERAGE(ByVal pv_strCUSTODYCD As String)
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            If Not FABROKERAGEGrid Is Nothing And Len(pv_strCUSTODYCD) > 0 Then
                'Clear data
                FABROKERAGEGrid.DataRows.Clear()
                Dim v_strSQL As String = "select  VALUE AUTOID , DISPLAY BRKID,EN_DISPLAY BRKID,DESCRIPTION BRKNAME From vw_custodycd_member_cf WHERE FILTERCD='" & pv_strCUSTODYCD & "'"

                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "FA.FABROKERAGE", gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                FillDataGrid(FABROKERAGEGrid, v_strObjMsg, "")
            End If
        Catch ex As Exception
            Throw ex
        Finally
            v_ws = Nothing
        End Try
    End Sub
    Private Sub LoadFAMEMBERSEXTRA(ByVal pv_strCUSTODYCD As String)
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            If Not FABROKERAGEGrid Is Nothing And Len(pv_strCUSTODYCD) > 0 Then
                'Clear data
                FAMEMBERSEXTRAGrid.DataRows.Clear()
                Dim v_strSQL As String = "select fa.autoid 1, fa.email  2, fa.phone 3, fa.brokername 4 from FAMEMBERSEXTRA fa, CFMAST cf where fa.custodycd = cf.custodycd(+) and fa.custodycd = '" & pv_strCUSTODYCD & "'"
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "FA.FAMEMBERSEXTRA", gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                FillDataGrid(FABROKERAGEGrid, v_strObjMsg, "")
            End If
        Catch ex As Exception
            Throw ex
        Finally
            v_ws = Nothing
        End Try
    End Sub

    'TanPN 07/02/2020  Dữ liệu AP
    Private Sub LoadFAAP(ByVal pv_strCUSTODYCD As String)
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            If Not FAAPGrid Is Nothing And Len(pv_strCUSTODYCD) > 0 Then
                'Clear data
                FAAPGrid.DataRows.Clear()
                Dim v_strSQL As String = "select  VALUE AUTOID , DISPLAY BRKID,EN_DISPLAY BRKID,DESCRIPTION BRKNAME From vw_custodycd_memberap_cf WHERE FILTERCD='" & pv_strCUSTODYCD & "'"

                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "FA.CFLNKAP", gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                FillDataGrid(FAAPGrid, v_strObjMsg, "")
            End If
        Catch ex As Exception
            Throw ex
        Finally
            v_ws = Nothing
        End Try
    End Sub

    'Private Sub LoadCORPORATE(ByVal pv_strCUSTID As String)
    '    Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
    '    Try
    '        If Not CFRPTAFMASTGrid Is Nothing And Len(pv_strCUSTID) > 0 Then
    '            'Clear data
    '            CFRPTAFMASTGrid.DataRows.Clear()
    '            Dim v_strSQL As String = ""

    '            Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "CF.CFMAST", _
    '            gc_ActionInquiry, v_strSQL)
    '            v_ws.Message(v_strObjMsg)
    '            FillDataGrid(CFRPTAFMASTGrid, v_strObjMsg, "")
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        v_ws = Nothing
    '    End Try
    'End Sub
    'end--------------------------------------
    Protected Overridable Function OnDeleteAFMAST(Optional ByVal pv_strIsLocal As String = "", Optional ByVal pv_strModule As String = "") As Int32
        Dim v_strKeyFieldName, v_strKeyFieldValue As String
        Dim v_strClause As String
        Dim ParentObjName As String = Me.ObjectName
        Dim ParentClause As String = KeyFieldName & " = '" & txtCUSTID.Text & "'"

        Try
            If MsgBox(ResourceManager.GetString("DelConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                'Update mouse pointer
                Cursor.Current = Cursors.WaitCursor

                If (pv_strIsLocal <> "") And (pv_strModule <> "") Then
                    If Not (AFMASTGrid.CurrentRow Is Nothing) Then
                        v_strKeyFieldName = "ACCTNO"
                        v_strKeyFieldValue = CType(AFMASTGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AFACCTNO").Value

                        v_strClause = v_strKeyFieldName & " = '" & v_strKeyFieldValue & "'"

                        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, pv_strIsLocal, gc_MsgTypeObj, pv_strModule, gc_ActionAdhoc, , v_strClause, "AFMAST_Delete", , , , v_strKeyFieldValue, , , ParentObjName, ParentClause)
                        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                        Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                        Dim v_strErrorSource, v_strErrorMessage As String

                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                        If v_lngErrorCode <> 0 Then
                            'Update mouse pointer
                            Cursor.Current = Cursors.Default
                            MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Exit Function
                        End If

                        AFMASTGrid.CurrentRow.Remove()
                    Else
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
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
        End Try
    End Function


    'Xoa mot dong trong grid
    Private Function Delete_TabPage_Row(Optional ByVal pv_strIsLocal As String = "", Optional ByVal pv_strModule As String = "") As Int32
        Dim v_ws As New BDSDeliveryManagement
        Dim v_strKeyFieldName, v_strKeyFieldValue As String
        Dim v_strClause, v_strObjMsg As String
        Dim v_strErrorSource, v_strErrorMessage As String
        Dim v_lngErrorCode As Long

        Dim ParentObjName As String = Me.ObjectName
        Dim ParentClause As String = KeyFieldName & " = '" & Me.txtCUSTID.Text & "'"

        Try
            If MsgBox(ResourceManager.GetString("DelConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                'Update mouse pointer
                Cursor.Current = Cursors.WaitCursor

                If (pv_strIsLocal.Length <> 0) And (pv_strModule.Length <> 0) AndAlso pv_strModule = "CF.CFAUTH" Then

                    If (Not (CFAUTHGrid.CurrentRow Is Nothing)) Then
                        v_strKeyFieldName = CType(CFAUTHGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").FieldName
                        v_strKeyFieldValue = CType(CFAUTHGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value
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

                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Function
                    End If
                End If


                If (Not (CFOTHERACCGrid.CurrentRow Is Nothing) AndAlso pv_strModule = "SA.CFOTHERACC") Then
                    v_strKeyFieldName = CType(CFOTHERACCGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").FieldName
                    v_strKeyFieldValue = CType(CFOTHERACCGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value

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


                If (Not (REAFLNKGrid.CurrentRow Is Nothing) AndAlso pv_strModule = "RE.REAFLNK") Then
                    v_strKeyFieldName = CType(REAFLNKGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").FieldName
                    v_strKeyFieldValue = CType(REAFLNKGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value

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

                If (Not (OTRIGTGrid.CurrentRow Is Nothing) AndAlso pv_strModule = "CF.OTRIGHT") Then
                    v_strKeyFieldName = CType(OTRIGTGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").FieldName
                    v_strKeyFieldValue = CType(OTRIGTGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value

                    Select Case KeyFieldType
                        Case "D"
                            v_strClause = v_strKeyFieldName & " = TO_DATE('" & v_strKeyFieldValue & "', '" & gc_FORMAT_DATE & "')"
                        Case "N"
                            v_strClause = v_strKeyFieldName & " = " & v_strKeyFieldValue
                        Case "C"
                            v_strClause = v_strKeyFieldName & " = '" & v_strKeyFieldValue & "'"
                    End Select
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_OTRIGHT, gc_ActionAdhoc, , v_strClause, "OTRIGHT_Delete", , , , , , , ParentObjName, ParentClause)
                    'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, pv_strIsLocal, gc_MsgTypeObj, pv_strModule, gc_ActionDelete, , v_strClause, , , , , , , , ParentObjName, ParentClause)
                    v_ws.Message(v_strObjMsg)
                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                End If

                If (Not (CFRPTAFMASTGrid.CurrentRow Is Nothing) AndAlso pv_strModule = "CF.RPTAFMAST") Then
                    v_strKeyFieldName = CType(CFRPTAFMASTGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").FieldName
                    v_strKeyFieldValue = CType(CFRPTAFMASTGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value

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

                If (Not (EMAILREPORTGrid.CurrentRow Is Nothing) AndAlso pv_strModule = "CF.EMAILREPORT") Then
                    v_strKeyFieldName = CType(EMAILREPORTGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").FieldName
                    v_strKeyFieldValue = CType(EMAILREPORTGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value

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

    Public Sub ShowFormOTRIGHT(ByVal pv_intExecFlag As Integer)
        Dim v_frm As New frmOTRIGHT
        Try
            v_frm.ExeFlag = pv_intExecFlag
            v_frm.UserLanguage = UserLanguage
            v_frm.BranchId = BranchId
            v_frm.TellerId = TellerId
            v_frm.TellerRight = TellerRight
            v_frm.GroupCareBy = GroupCareBy
            v_frm.ModuleCode = ModuleCode
            v_frm.ObjectName = "CF.OTRIGHT"
            v_frm.TableName = "OTRIGHT"
            v_frm.LocalObject = "N"
            v_frm.BusDate = Me.BusDate
            v_frm.Text = String.Empty
            v_frm.CustID = Me.txtCUSTID.Text
            v_frm.Custodycd = Me.txtCUSTODYCD.Text
            v_frm.email = Me.txtEMAIL.Text
            v_frm.mobilesms = Me.txtMOBILESMS.Text
            v_frm.fullname = Me.txtFULLNAME.Text
            v_frm.orgcustid = Me.txtCUSTID.Text.Trim
            v_frm.ParentObjName = Me.ObjectName
            v_frm.ParentClause = KeyFieldName & " = '" & txtCUSTID.Text & "'"
            v_frm.TellerId = TellerId

            If Not (OTRIGTGrid.CurrentRow Is Nothing) Then
                If Not (pv_intExecFlag = ExecuteFlag.AddNew) Then
                    v_frm.KeyFieldName = "AUTOID"
                    v_frm.KeyFieldType = "N"
                    v_frm.KeyFieldValue = Trim(CType(OTRIGTGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
                    v_frm.AuthCustid = Trim(CType(OTRIGTGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTHCUSTID").Value)
                End If
                If (pv_intExecFlag = ExecuteFlag.View) Then
                    v_frm.ExeFlag = ExecuteFlag.View
                ElseIf (pv_intExecFlag = ExecuteFlag.Edit) Then
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
                LoadOTRIGHT(Me.txtCUSTID.Text)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_frm.Dispose()
        End Try
    End Sub

    Private Sub LoadOTRIGHT(ByVal pv_strCUSTID As String)
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            If UserLanguage = "VN" Then
                mv_content = "CDCONTENT"
            Else
                mv_content = "EN_CDCONTENT"
            End If
            If Not OTRIGTGrid Is Nothing And Len(pv_strCUSTID) > 0 Then
                'Clear old data

                OTRIGTGrid.DataRows.Clear()
                Dim v_strSQL As String
                v_strSQL = "SELECT * FROM (" & ControlChars.CrLf _
                        & " SELECT OT.AUTOID, OT.CFCUSTID, OT.AUTHCUSTID, CF.FULLNAME, CF.IDCODE, CF.ADDRESS, CF.MOBILESMS," & ControlChars.CrLf _
                        & "     TO_CHAR(OT.VALDATE,'DD/MM/YYYY') VALDATE, TO_CHAR(OT.EXPDATE,'DD/MM/YYYY') EXPDATE, A1." & mv_content & " AUTHTYPE, OT.SERIALTOKEN, " & ControlChars.CrLf _
                        & "     A3." & mv_content & " VIA, A2." & mv_content & " OTAUTHTYPE " & ControlChars.CrLf _
                        & " FROM OTRIGHT OT, CFMAST CF, ALLCODE A1, ALLCODE A2, ALLCODE A3" & ControlChars.CrLf _
                        & " WHERE CF.CUSTID = OT.AUTHCUSTID" & ControlChars.CrLf _
                        & "     AND OT.DELTD = 'N' " & ControlChars.CrLf _
                        & "     AND A1.CDTYPE = 'CF' AND A1.CDNAME = 'AUTHTYPE' AND A1.CDVAL = CASE WHEN OT.AUTHCUSTID = '" & txtCUSTID.Text & "' THEN 'OWNER' ELSE 'AUTHORIZED' END " & ControlChars.CrLf _
                        & "     AND A2.CDTYPE = 'CF' AND A2.CDNAME = 'OTAUTHTYPE' AND A2.CDVAL = OT.AUTHTYPE " & ControlChars.CrLf _
                        & "     AND A3.CDTYPE = 'OD' AND A3.CDNAME = 'VIA' AND A3.CDVAL = OT.VIA " & ControlChars.CrLf _
                        & "     AND CF.CUSTID='" & pv_strCUSTID & "' ) AU " & ControlChars.CrLf _
                        & " ORDER BY AU.AUTOID"
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "CF.CFCONTACT", _
                    gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                FillDataGrid(OTRIGTGrid, v_strObjMsg, "")
            End If
        Catch ex As Exception
            Throw ex
        Finally
            v_ws = Nothing
        End Try
    End Sub


    Private Sub LoadREAFLNK(ByVal pv_strCUSTID As String)
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            If UserLanguage = "VN" Then
                mv_content = "CDCONTENT"
            Else
                mv_content = "EN_CDCONTENT"
            End If
            If Not REAFLNKGrid Is Nothing And Len(pv_strCUSTID) > 0 Then
                'Clear old data
                REAFLNKGrid.DataRows.Clear()
                Dim v_strSQL As String
                v_strSQL = "SELECT LNK.AUTOID,  " & ControlChars.CrLf _
                            & "LNK.REACCTNO, LNK.FRDATE, LNK.TODATE, A0." & mv_content & " STATUS, MST.REROLE,   " & ControlChars.CrLf _
                            & "MST.FULLNAME REFULLNAME, MST.TYPENAME  " & ControlChars.CrLf _
                            & "FROM REAFLNK LNK, ALLCODE A0,  " & ControlChars.CrLf _
                            & "    (select RE.ACCTNO, REP.TYPENAME, CF.FULLNAME, C1." & mv_content & " REROLE " & ControlChars.CrLf _
                            & "        from REMAST RE, RETYPE REP, CFMAST CF, ALLCODE C1  " & ControlChars.CrLf _
                            & "        where RE.ACTYPE = REP.ACTYPE AND CF.CUSTID=RE.CUSTID and C1.CDTYPE='RE' AND C1.CDNAME='REROLE' AND C1.CDVAL=REP.REROLE " & ControlChars.CrLf _
                            & "        ) MST  " & ControlChars.CrLf _
                            & "WHERE A0.CDTYPE='RE' AND A0.CDNAME='STATUS' AND A0.CDVAL=LNK.STATUS  " & ControlChars.CrLf _
                            & "AND LNK.REACCTNO=MST.ACCTNO  " & ControlChars.CrLf _
                            & "AND LNK.AFACCTNO = '" & pv_strCUSTID & "'  " & ControlChars.CrLf _
                            & "ORDER BY LNK.AUTOID"
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "RE.REAFLNK", _
                    gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                FillDataGrid(REAFLNKGrid, v_strObjMsg, "")
            End If
        Catch ex As Exception
            Throw ex
        Finally
            v_ws = Nothing
        End Try
    End Sub

    Public Sub ShowTemplate(ByVal pv_intExecFlag As Integer)
        Dim v_strKeyValue As String = String.Empty
        Dim v_strModuleCode, v_strObjName, v_strTableName, v_strKeyField, v_strKeyFieldType, v_strParentValue As String
        Try
            'Insert
            If (pv_intExecFlag = ExecuteFlag.AddNew) Then
                v_strKeyValue = String.Empty
            ElseIf (pv_intExecFlag = ExecuteFlag.Edit Or pv_intExecFlag = ExecuteFlag.View) Then
                v_strKeyValue = Trim(CType(AFTEMPLATESGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
            End If

            If v_strKeyValue.Equals("-1") Then
                Return
            End If

            v_strModuleCode = "SA"
            v_strObjName = "SA.AFTEMPLATES"
            v_strTableName = "AFTEMPLATES"
            v_strKeyField = "AUTOID"
            v_strKeyFieldType = "N"
            v_strParentValue = Me.txtCUSTID.Text.Replace(".", "")

            Dim v_frm As New frmMaster(v_strTableName, pv_intExecFlag, UserLanguage, v_strModuleCode, v_strObjName, gc_IsNotLocalMsg, _
                                        Me.tpTemplates.Text, TellerId, TellerRight, GroupCareBy, AuthString, BranchId, BusDate, v_strKeyField, _
                                        v_strKeyFieldType, v_strKeyValue, LinkValue, Me.LinkField, v_strParentValue, Me.ObjectName, Me.ModuleCode, Me.mv_arrObjFields)
            Dim frmResult As DialogResult = v_frm.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
#Region "Events"

    Private Sub btnApprv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprv.Click
        v_strSender = "btnApprv"

        'If DDMMYYYY_SystemDate(Me.dtpIDEXPIRED.Text.Trim) <= DDMMYYYY_SystemDate(BusDate) AndAlso cboCUSTTYPE.SelectedValue <> "B" Then 'AndAlso cboISBANKING.SelectedValue = "N" 
        '    If MessageBox.Show(ResourceManager.GetString("MsgIDEXPIREDLESSTHANBUSDATE"), Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) <> Windows.Forms.DialogResult.OK Then
        '        Exit Sub
        '    End If
        'End If

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

    Private Sub btnCFRELATION_ADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCFRELATION_ADD.Click
        showFormRELATION(ExecuteFlag.AddNew)
        LoadCFRELATION(CStr(txtCUSTID.Text))
    End Sub

    Private Sub btnCFRELATION_VIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCFRELATION_VIEW.Click
        showFormRELATION(ExecuteFlag.View)
        'LoadCFRELATION(CStr(txtCUSTID.Text))
    End Sub

    Private Sub btnCFRELATION_EDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCFRELATION_EDIT.Click


        showFormRELATION(ExecuteFlag.Edit)
        LoadCFRELATION(CStr(txtCUSTID.Text))


    End Sub

    Private Sub btnCFRELATION_DELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCFRELATION_DELETE.Click
        OnDeleterelation(gc_IsNotLocalMsg, ModuleCode & ".CFRELATION")
        LoadCFRELATION(CStr(txtCUSTID.Text))
    End Sub

    Private Sub btnCFCONTACT_ADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCFCONTACT_ADD.Click
        ShowContactEvent(btnCFCONTACT_ADD)
        LoadCFCONTACT(CStr(txtCUSTID.Text))
    End Sub

    Private Sub btnCFCONTACT_VIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCFCONTACT_VIEW.Click
        ShowContactEvent(btnCFCONTACT_VIEW)
        LoadCFCONTACT(CStr(txtCUSTID.Text))
    End Sub

    Private Sub btnCFCONTACT_EDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCFCONTACT_EDIT.Click
        ShowContactEvent(btnCFCONTACT_EDIT)
        LoadCFCONTACT(CStr(txtCUSTID.Text))
    End Sub

    Private Sub btnCFCONTACT_DELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCFCONTACT_DELETE.Click
        OnDeleteContact(gc_IsNotLocalMsg, ModuleCode & ".CFCONTACT")
    End Sub

    Private Sub btnISSUER_ADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnISSUER_ADD.Click
        showFormISSUER(ExecuteFlag.AddNew)
        LoadISSUER(Me.txtCUSTID.Text)
    End Sub

    Private Sub btnISSUER_VIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnISSUER_VIEW.Click
        showFormISSUER(ExecuteFlag.View)
        LoadISSUER(Me.txtCUSTID.Text)
    End Sub

    Private Sub btnISSUER_EDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnISSUER_EDIT.Click
        showFormISSUER(ExecuteFlag.Edit)
        LoadISSUER(Me.txtCUSTID.Text)
    End Sub

    Private Sub btnISSUER_DELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnISSUER_DELETE.Click
        OnDeleteIssuer(gc_IsNotLocalMsg, "SA.ISSUER_MEMBER")
        LoadISSUER(Me.txtCUSTID.Text)
    End Sub


    Private Sub btnAFMAST_ADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAFMAST_ADD.Click
        Dim v_ws As New BDSDeliveryManagement
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strVALUE As String
        Dim v_dblCount As Double = 0
        Dim v_strSQL, v_strObjMsg As String
        Try


            If Me.txtCUSTID.Enabled = False AndAlso Me.txtCUSTID.Text.Length = 10 _
                AndAlso Me.txtCUSTODYCD.Enabled = False AndAlso Me.txtCUSTODYCD.Text.Length = 10 Then 'Not cboISBANKING.SelectedValue Is Nothing AndAlso cboISBANKING.SelectedValue <> "Y" 

                'v_strSQL = "SELECT count(1) AFCNT FROM REAFLNK WHERE AFACCTNO = '" & Me.txtCUSTID.Text & "' AND STATUS <> 'C' AND DELTD <> 'Y'"
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
                '                Case "AFCNT"
                '                    v_dblCount = CDbl(v_strVALUE)
                '            End Select
                '        End With
                '    Next
                'Next
                'If Not v_dblCount > 0 Then
                '    If MsgBox(ResourceManager.GetString("REAFLNK_NOT_EXISTS"), MsgBoxStyle.Information + MsgBoxStyle.OkCancel, gc_ApplicationTitle) <> MsgBoxResult.Ok Then
                '        Exit Sub
                '    End If
                'End If
                showFormAFMAST(ExecuteFlag.AddNew)
                LoadAFMAST(Me.txtCUSTID.Text)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnAFMAST_VIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAFMAST_VIEW.Click
        showFormAFMAST(ExecuteFlag.View)
        LoadAFMAST(Me.txtCUSTID.Text)
    End Sub

    Private Sub btnAFMAST_EDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAFMAST_EDIT.Click
        showFormAFMAST(ExecuteFlag.Edit)
        LoadAFMAST(Me.txtCUSTID.Text)
    End Sub

    Private Sub btnAFMAST_DELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAFMAST_DELETE.Click
        OnDeleteAFMAST(gc_IsNotLocalMsg, "CF.AFMAST")
        LoadAFMAST(Me.txtCUSTID.Text)
    End Sub

    Private Sub btnCFSIGN_BACK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCFSIGN_BACK.Click
        If mv_intCurrImageIndex > 0 Then
            mv_intCurrImageIndex -= 1
            LoadCFSIGN(CStr(txtCUSTID.Text))
        End If
    End Sub

    Private Sub btnCFSIGN_NEXT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCFSIGN_NEXT.Click
        If mv_intCurrImageIndex < mv_arrSIGNATURE.Length - 1 Then
            mv_intCurrImageIndex += 1
            LoadCFSIGN(CStr(txtCUSTID.Text))
        End If
    End Sub

    'Private Sub imageViewer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles imageViewer.Click
    '    imageViewer.ZoomFactor = imageViewer.ZoomFactor * 0.9 'ZommOut
    '    'imageViewer.ZoomFactor = imageViewer.ZoomFactor * 1.1 'Zomm in
    'End Sub

    'Private Sub dtpIDDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpIDDATE.Validating, dtpTAXCODEDATE.Validating, dtpTAXCODEEXPIRYDATE.Validating

    '    Dim aDate As Date
    '    If cboIDTYPE.SelectedValue = IDTYPE_TRADINGCODE Then
    '        aDate = (Me.dtpIDDATE.Value.AddYears(10))
    '    Else
    '        aDate = (Me.dtpIDDATE.Value.AddYears(15))
    '    End If

    '    Me.dtpIDEXPIRED.Value = aDate
    'End Sub

    Private Sub txtEMAIL_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs, ByVal pv_strCUSTID As String)
        'Kiem tra dinh dang Email phai hop le
        If Trim(Me.txtEMAIL.Text).Length > 0 Then
            If InStr(Trim(Me.txtEMAIL.Text), " ") > 0 Or InStr(Trim(Me.txtEMAIL.Text), "@") <= 0 Or InStr(Mid(Trim(Me.txtEMAIL.Text), InStr(Trim(Me.txtEMAIL.Text), "@") + 1), ".") <= 0 Then
                MsgBox(ResourceManager.GetString("msgINVALIDEMAILFORMAT"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Me.txtEMAIL.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub btnGenCheckCustID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenCheckCustID.Click
        Dim v_strCustIDTemp As String
        Select Case ExeFlag
            Case ExecuteFlag.AddNew
                'Kiem tra xem ma tu sinh
                While (1 = 1)
                    If Me.txtCUSTID.Text.Length <> 10 Then
                        v_strCustIDTemp = getCustID(BranchId)
                    Else
                        v_strCustIDTemp = Me.txtCUSTID.Text
                    End If
                    If CheckCustID(v_strCustIDTemp) Then
                        Me.txtCUSTID.Text = v_strCustIDTemp
                        Exit While
                    Else
                        Me.txtCUSTID.Text = getCustID(BranchId)
                        'MsgBox(ResourceManager.GetString("MsgINVALIDCUSTID"), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)
                        Exit While
                    End If
                End While
        End Select
    End Sub

    Private Sub txtCUSTID_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCUSTID.Validating
        If Me.txtCUSTID.Text.Length > 4 Then
            If Me.txtCUSTID.Text.Length <= 4 _
            OrElse Me.txtCUSTID.Text.Substring(0, 4) <> Me.BranchId _
            OrElse Me.txtCUSTID.Text.Length <> 10 _
            OrElse Not IsNumeric(Me.txtCUSTID.Text) Then
                MsgBox(ResourceManager.GetString("MsgINVALIDCUSTID"), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)
                txtCUSTID.Focus()
            End If
        End If
    End Sub

    Private Sub btnGenCheckCUSTODYCD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenCheckCUSTODYCD.Click
        Dim v_strCustIDTemp As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strVALUE As String
        Dim v_dblCUSTODYCDTO As Double = 0
        Dim v_strSQL, v_strObjMsg As String
        Dim v_dblCUSTODYCDFROM As Double = 0
        Dim v_strPrefixCustodyCD As String = AppSettings.Get("PrefixedCustodyCode")

        'If txtTRADINGCODE.Text.Length = 6 Then
        '    Me.txtCUSTODYCD.Text = v_strPrefixCustodyCD & "F" & txtTRADINGCODE.Text
        '    Exit While
        'End If

        'If Me.txtCUSTODYCD.Text.Length <> 10 Then
        '    v_strCustIDTemp = getCustodyCD(BranchId)
        'Else
        '    v_strCustIDTemp = Me.txtCUSTODYCD.Text
        'End If

        v_strCustIDTemp = getCustodyCD(BranchId)
        Me.txtCUSTODYCD.Text = v_strCustIDTemp

        'While (1 = 1)
        '    If txtTRADINGCODE.Text.Length = 6 Then
        '        Me.txtCUSTODYCD.Text = v_strPrefixCustodyCD & "F" & txtTRADINGCODE.Text
        '        Exit While
        '    End If
        '    If Me.txtCUSTODYCD.Text.Length <> 10 Then
        '        v_strCustIDTemp = getCustodyCD(BranchId)
        '    Else
        '        v_strCustIDTemp = Me.txtCUSTODYCD.Text
        '    End If

        '    Me.txtCUSTODYCD.Text = v_strCustIDTemp

        '    'v_strSQL = "select CUSTODYCDFROM from brgrp where brid = '" & BranchId & "'"
        '    'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_BRGRP, gc_ActionInquiry, v_strSQL)
        '    'v_ws.Message(v_strObjMsg)
        '    'v_xmlDocument.LoadXml(v_strObjMsg)
        '    'v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
        '    'For i As Integer = 0 To v_nodeList.Count - 1
        '    '    For j As Integer = 0 To v_nodeList.Item(j).ChildNodes.Count - 1
        '    '        With v_nodeList.Item(j).ChildNodes(i)
        '    '            v_strFLDNAME = v_nodeList.Item(j).ChildNodes(i).Attributes.GetNamedItem("fldname").Value.Trim()
        '    '            v_strVALUE = v_nodeList.Item(j).ChildNodes(i).Attributes.GetNamedItem("oldval").Value.Trim()
        '    '            Select Case v_strFLDNAME
        '    '                Case "CUSTODYCDFROM"
        '    '                    v_dblCUSTODYCDFROM = CDbl(v_strVALUE)

        '    '            End Select
        '    '        End With
        '    '    Next
        '    'Next

        '    'TruongLD bỏ ko dung tinh nang nay nữa.
        '    'v_strSQL = "select CUSTODYCDTO from brgrp where brid = '" & BranchId & "'"
        '    'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_BRGRP, gc_ActionInquiry, v_strSQL)
        '    'v_ws.Message(v_strObjMsg)
        '    'v_xmlDocument.LoadXml(v_strObjMsg)
        '    'v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
        '    'For i As Integer = 0 To v_nodeList.Count - 1
        '    '    For j As Integer = 0 To v_nodeList.Item(j).ChildNodes.Count - 1
        '    '        With v_nodeList.Item(j).ChildNodes(i)
        '    '            v_strFLDNAME = v_nodeList.Item(j).ChildNodes(i).Attributes.GetNamedItem("fldname").Value.Trim()
        '    '            v_strVALUE = v_nodeList.Item(j).ChildNodes(i).Attributes.GetNamedItem("oldval").Value.Trim()
        '    '            Select Case v_strFLDNAME
        '    '                Case "CUSTODYCDTO"
        '    '                    v_dblCUSTODYCDTO = CDbl(v_strVALUE)

        '    '            End Select
        '    '        End With
        '    '    Next
        '    'Next

        '    'If CheckCustToDyCD(v_strCustIDTemp) Then
        '    '    If (CDbl(v_strCustIDTemp.Substring(4, 6)) > CDbl(v_dblCUSTODYCDTO)) Then
        '    '        Me.txtCUSTODYCD.Text = v_strCustIDTemp
        '    '        MsgBox(ResourceManager.GetString("MsgOVERCUSTODYCD"), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)
        '    '        Me.txtCUSTODYCD.Text = 0
        '    '    End If
        '    '        If (CDbl(v_strCustIDTemp.Substring(4, 6)) < CDbl(v_dblCUSTODYCDFROM)) Then
        '    '            Me.txtCUSTODYCD.Text = v_strCustIDTemp
        '    '            MsgBox(ResourceManager.GetString("MsgLESSCUSTODYCD"), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)
        '    '            Me.txtCUSTODYCD.Text = 0
        '    '        End If
        '    '        Me.txtCUSTODYCD.Text = String.Empty
        '    '        'MsgBox(ResourceManager.GetString("MsgLIMITCUSTODYCD"), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)
        '    '        Exit While
        '    'Else

        '    '    Me.txtCUSTODYCD.Text = getCustodyCD(BranchId)
        '    '    'MsgBox(ResourceManager.GetString("MsgINVALIDCUSTODYCD"), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)
        '    '    Exit While
        '    'End If
        'End While
    End Sub

    Private Sub txtCUSTODYCD_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCUSTODYCD.Validated
        Dim v_strCount As String
        Dim v_strSQL As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Dim v_strFLDNAME, v_strVALUE As String

        Try

            If cboCOUNTRY.SelectedValue <> VIETNAMEESE_CODE And ExeFlag = ExecuteFlag.AddNew Then
                txtTRADINGCODE.Text = txtCUSTODYCD.Text.Substring(4, 6)
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                        & "Error code: System error!" & vbNewLine _
                        & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
    'DieuNDA 28/12/2016 Revert phan cua Vu
    'Private Sub txtCUSTODYCD_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCUSTODYCD.LostFocus
    '    If CheckCustToDyCD(txtCUSTODYCD.Text) = False Then
    '        'MessageBox.Show(ResourceManager.GetString("ErrorMessage"), ResourceManager.GetString("ErrorTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        MsgBox(ResourceManager.GetString("CUSTODYCDERROR"), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)
    '        'txtCUSTODYCD.Focus()
    '    End If
    'End Sub
    'End DieuNDA 28/12/2016 Revert phan cua Vu

    Private Sub txtFULLNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtFULLNAME.Validating
        Try
            txtMNEMONIC.Text = CutMark(txtFULLNAME.Text)
        Catch ex As Exception
            txtMNEMONIC.Text = txtFULLNAME.Text
        End Try
    End Sub

    Private Sub cboISBANKING_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If mv_blnIsLoading Then Return
        Try
            If Not cboISBANKING.SelectedValue Is DBNull.Value Then
                If cboISBANKING.SelectedValue = "Y" Then ' Neu khach hang la ngan hang.
                    cboCUSTTYPE.SelectedValue = "B"
                    cboCUSTTYPE.Enabled = False
                    cboIDTYPE.Enabled = False
                    'txtTRADINGCODE.Enabled = False
                    lblTRADINGCODE.ForeColor = Color.Blue
                    dtpTRADINGCODEDT.Enabled = False
                    lblTRADINGCODEDT.ForeColor = Color.Blue
                    txtIDCODE.Enabled = False
                    lblIDCODE.ForeColor = Color.Blue
                    dtpIDDATE.Enabled = False
                    lblIDDATE.ForeColor = Color.Blue
                    'dtpIDEXPIRED.Enabled = False
                    lblIDEXPIRED.ForeColor = Color.Blue
                    txtIDPLACE.Enabled = False
                    lblIDPLACE.ForeColor = Color.Blue
                    txtADDRESS.Enabled = True
                    lblADDRESS.ForeColor = Color.Blue

                    'txtSHORTNAME.Enabled = True
                    lblSHORTNAME.ForeColor = Color.Red

                    btnAFMAST_ADD.Enabled = False
                    btnAFMAST_EDIT.Enabled = False
                    btnAFMAST_VIEW.Enabled = False
                    btnAFMAST_DELETE.Enabled = False
                Else
                    cboCUSTTYPE.Enabled = True
                    cboIDTYPE.Enabled = True
                    If cboIDTYPE.SelectedValue = IDTYPE_TRADINGCODE Then
                        'txtTRADINGCODE.Enabled = True
                        lblTRADINGCODE.ForeColor = Color.Red
                        dtpTRADINGCODEDT.Enabled = True
                        lblTRADINGCODEDT.ForeColor = Color.Red
                    Else
                        'txtTRADINGCODE.Enabled = False
                        lblTRADINGCODE.ForeColor = Color.Blue
                        dtpTRADINGCODEDT.Enabled = False
                        lblTRADINGCODEDT.ForeColor = Color.Blue
                    End If
                    txtIDCODE.Enabled = True
                    txtTAXCODE.Enabled = True
                    lblIDCODE.ForeColor = Color.Red
                    dtpIDDATE.Enabled = True
                    lblIDDATE.ForeColor = Color.Red
                    dtpIDEXPIRED.Enabled = True
                    lblIDEXPIRED.ForeColor = Color.Red
                    txtIDPLACE.Enabled = True
                    lblIDPLACE.ForeColor = Color.Red
                    txtADDRESS.Enabled = True
                    lblADDRESS.ForeColor = Color.Red

                    'txtSHORTNAME.Enabled = False
                    'txtSHORTNAME.Enabled = True
                    lblSHORTNAME.ForeColor = Color.Red

                    btnAFMAST_ADD.Enabled = True
                    btnAFMAST_EDIT.Enabled = True
                    btnAFMAST_VIEW.Enabled = True
                    btnAFMAST_DELETE.Enabled = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Private Sub cboIDTYPE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIDTYPE.SelectedIndexChanged
        If mv_blnIsLoading Then Return
        Try
            If Not cboIDTYPE.SelectedValue Is DBNull.Value Then

                If cboIDTYPE.SelectedValue = IDTYPE_TRADINGCODE Then
                    'txtTRADINGCODE.Enabled = True
                    'lblTRADINGCODE.ForeColor = Color.Red
                    lblTRADINGCODE.ForeColor = Color.Blue
                    dtpTRADINGCODEDT.Enabled = True
                    'lblTRADINGCODEDT.ForeColor = Color.Red
                    lblTRADINGCODEDT.ForeColor = Color.Blue

                    txtIDCODE.Enabled = True
                    lblIDCODE.ForeColor = Color.Red
                    'TanPN 21/2/2020
                    If cboCUSTTYPE.SelectedValue = "B" Then
                        lblIDCODE.Text = ResourceManager.GetString("BUSINESS_REGISTRATION")
                    Else
                        lblIDCODE.Text = ResourceManager.GetString("PASSPORT_IDCODE")
                    End If
                    txtIDPLACE.Enabled = True
                    lblIDPLACE.ForeColor = Color.Red
                    dtpIDDATE.Enabled = True
                    lblIDDATE.ForeColor = Color.Red
                    dtpIDEXPIRED.Enabled = True
                    lblIDEXPIRED.ForeColor = Color.Blue
                Else
                    'txtTRADINGCODE.Enabled = False
                    lblTRADINGCODE.ForeColor = Color.Blue
                    dtpTRADINGCODEDT.Enabled = False
                    lblTRADINGCODEDT.ForeColor = Color.Blue

                    txtIDCODE.Enabled = True
                    txtTAXCODE.Enabled = True
                    lblIDCODE.ForeColor = Color.Red
                    'TanPN 21/2/2020
                    If cboCUSTTYPE.SelectedValue = "B" Then
                        lblIDCODE.Text = ResourceManager.GetString("BUSINESS_REGISTRATION")
                    Else
                        lblIDCODE.Text = ResourceManager.GetString("IDCODE")
                    End If
                    'lblIDCODE.Text = ResourceManager.GetString("IDCODE")
                    txtIDPLACE.Enabled = True
                    lblIDPLACE.ForeColor = Color.Red
                    dtpIDDATE.Enabled = True
                    lblIDDATE.ForeColor = Color.Red
                    'If cboIDTYPE.SelectedValue = IDTYPE_GPKD Then
                    '    'dtpIDEXPIRED.Enabled = False
                    '    'Else
                    '    dtpIDEXPIRED.Enabled = True
                    'End If
                    lblIDEXPIRED.ForeColor = Color.Red
                End If
            End If
            If Not cboIDTYPE.SelectedValue Is DBNull.Value AndAlso cboIDTYPE.SelectedValue = IDTYPE_TRADINGCODE AndAlso txtCUSTODYCD.Text.Length = 10 Then
                txtTRADINGCODE.Text = txtCUSTODYCD.Text.Substring(4)
            Else
                txtTRADINGCODE.Text = String.Empty
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtCOMMRATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Try
            If Not IsNumeric(txtCOMMRATE.Text.Trim) Then
                MsgBox(ResourceManager.GetString("MsgCOMMRATE_FORMAT_INVALID"), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)
                txtCOMMRATE.Focus()
                txtCOMMRATE.Text = "0"
                Exit Sub
            End If
            If txtCOMMRATE.Text.Trim.Length <> 0 Then
                If Not (CDbl(txtCOMMRATE.Text.Trim) >= 0 AndAlso CDbl(txtCOMMRATE.Text.Trim) <= 100) Then
                    MsgBox(ResourceManager.GetString("MsgCOMMRATE_FORMAT_INVALID"), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)
                    txtCOMMRATE.Focus()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cboTRADETELEPHONE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If Not cboTRADETELEPHONE.SelectedValue Is DBNull.Value Then
                If cboTRADETELEPHONE.SelectedValue = "N" Then
                    txtPIN.Enabled = False

                    txtPIN.Text = ""
                    lblPIN.ForeColor = Color.Blue
                    'lblMOBILE.ForeColor = Color.Blue
                    lblMOBILESMS.ForeColor = Color.Blue
                Else
                    txtPIN.Enabled = True
                    lblPIN.ForeColor = Color.Red
                    'lblMOBILE.ForeColor = Color.Red
                    txtMOBILESMS.Enabled = True
                    'lblMOBILESMS.ForeColor = Color.Red
                    lblMOBILESMS.ForeColor = Color.Blue
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtSHORTNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If txtSHORTNAME.Text.Length <> 4 Then
            MsgBox(ResourceManager.GetString("MsgISBANKING_SHORTNAME_INVALID"), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Me.Text)
            txtSHORTNAME.Focus()
        End If
    End Sub
    Private Sub txtMOBILESMS_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtMOBILESMS.Validating, txtFAXNO.Validating
        If Not cboTRADETELEPHONE.SelectedValue Is DBNull.Value Then
            If cboTRADETELEPHONE.SelectedValue = "Y" Then

                'lblMOBILESMS.ForeColor = Color.Red
                lblMOBILESMS.ForeColor = Color.Blue
            Else

                lblMOBILESMS.ForeColor = Color.Blue
            End If
        End If
    End Sub
    Private Sub btnCFSIGN_ADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCFSIGN_ADD.Click
        ' Neu thong tin khach hang da duoc ghi vao CFMAST thi moi cho phep them chu ky.
        If Not (CheckCustID(Me.txtCUSTID.Text.Trim)) Then
            ShowSignEvent(ExecuteFlag.AddNew)
            LoadCFSIGN(CStr(txtCUSTID.Text))
        Else
            MsgBox(ResourceManager.GetString("MsgCANNOTADDSIGN"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
            Exit Sub
        End If
    End Sub

    Private Sub btnCFSIGN_VIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCFSIGN_VIEW.Click
        ShowSignEvent(ExecuteFlag.View)
    End Sub

    Private Sub btnCFSIGN_DELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCFSIGN_DELETE.Click
        OnDeleteSignature(gc_IsNotLocalMsg, ModuleCode & ".CFSIGN")
        LoadCFSIGN(CStr(txtCUSTID.Text))
    End Sub

    Private Sub btnCFSIGN_EDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCFSIGN_EDIT.Click
        ShowSignEvent(ExecuteFlag.Edit)
        LoadCFSIGN(CStr(txtCUSTID.Text))
    End Sub

    Private Sub cboCUSTATCOM_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCUSTATCOM.SelectedIndexChanged
        If Not cboCUSTATCOM.SelectedValue Is DBNull.Value Then
            If cboCUSTATCOM.SelectedValue = "Y" Then
                txtCOMMRATE.Text = "100"
                txtCOMMRATE.Enabled = False
                lblCOMMRATE.ForeColor = Color.Blue
                'cboACTIVESTS.SelectedValue = "N"
                'cboLCB.SelectedValue = "0"
                'cboLCB.Enabled = False
            Else
                txtCOMMRATE.Enabled = True
                lblCOMMRATE.ForeColor = Color.Red
                cboACTIVESTS.SelectedValue = "N"
                'cboLCB.Enabled = True
            End If
        End If
    End Sub

    Private Sub btnAFMAST_APPROVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        showFormAFMAST(ExecuteFlag.Approve)
        LoadAFMAST(Me.txtCUSTID.Text)
    End Sub

#End Region

    Private Sub btnCFAUTH_ADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCFAUTH_ADD.Click
        If Me.txtCUSTID.Text.Length = 10 Then
            showFormCFAUTH(ExecuteFlag.AddNew)
        Else
            MsgBox(ResourceManager.GetString("MsgCUSTID_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Me.txtCUSTID.Focus()
        End If
    End Sub

    Private Sub btnCFAUTH_VIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCFAUTH_VIEW.Click
        showFormCFAUTH(ExecuteFlag.View)
    End Sub

    Private Sub btnCFAUTH_EDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCFAUTH_EDIT.Click
        showFormCFAUTH(ExecuteFlag.Edit)
    End Sub

    Private Sub btnCFAUTH_DELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCFAUTH_DELETE.Click
        Delete_TabPage_Row("N", ModuleCode & ".CFAUTH")
        LoadCFAUTH(Me.txtCUSTID.Text)
    End Sub

    Private Sub btnCFOTHERACC_ADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCFOTHERACC_ADD.Click
        If Me.txtCUSTID.Text.Length = 10 Then
            showFormCFOTHERACC(ExecuteFlag.AddNew)
        Else
            MsgBox(ResourceManager.GetString("MsgCUSTID_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Me.txtCUSTID.Focus()
        End If
    End Sub

    Private Sub btnCFOTHERACC_VIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCFOTHERACC_VIEW.Click
        If (CFOTHERACCGrid.CurrentGrid.DataRows.Count > 0) Then
            showFormCFOTHERACC(ExecuteFlag.View)
        End If
    End Sub

    Private Sub btnCFOTHERACC_EDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCFOTHERACC_EDIT.Click
        If (CFOTHERACCGrid.CurrentGrid.DataRows.Count > 0) Then
            showFormCFOTHERACC(ExecuteFlag.Edit)
        End If
    End Sub

    Private Sub btnCFOTHERACC_DELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCFOTHERACC_DELETE.Click
        If (CFOTHERACCGrid.CurrentGrid.DataRows.Count > 0) Then
            Delete_TabPage_Row(gc_IsNotLocalMsg, "SA.CFOTHERACC")
            LoadCFOTHERACC(Me.txtCUSTID.Text)
        End If
    End Sub

    Private Sub btnOTRIGHT_ADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOTRIGHT_ADD.Click
        If Me.txtCUSTID.Text.Length = 10 Then
            ShowFormOTRIGHT(ExecuteFlag.AddNew)
        Else
            MsgBox(ResourceManager.GetString("MsgCUSTID_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Me.txtCUSTID.Focus()
        End If
    End Sub

    Private Sub btnOTRIGHT_VIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOTRIGHT_VIEW.Click
        If Me.txtCUSTID.Text.Length = 10 Then
            ShowFormOTRIGHT(ExecuteFlag.View)
        Else
            MsgBox(ResourceManager.GetString("MsgCUSTID_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Me.txtCUSTID.Focus()
        End If
    End Sub

    Private Sub btnOTRIGHT_EDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOTRIGHT_EDIT.Click
        If Me.txtCUSTID.Text.Length = 10 Then
            ShowFormOTRIGHT(ExecuteFlag.Edit)
        Else
            MsgBox(ResourceManager.GetString("MsgCUSTID_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Me.txtCUSTID.Focus()
        End If
    End Sub

    Private Sub btnOTRIGHT_DELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOTRIGHT_DELETE.Click
        'OnDeleteOTRIGHT()
        Delete_TabPage_Row(gc_IsNotLocalMsg, "CF.OTRIGHT")
        LoadOTRIGHT(Me.txtCUSTID.Text)

    End Sub

    Private Sub btnTEMPLATE_ADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTEMPLATE_ADD.Click
        If Me.txtCUSTID.Text.Length = 10 Then
            'ShowTemplate(ExecuteFlag.AddNew)
            Dim frmSearch As New frmSearch(UserLanguage)
            frmSearch.BusDate = Me.BusDate
            frmSearch.TableName = "ADDTEMPLATES"
            frmSearch.ModuleCode = Me.ModuleCode
            frmSearch.AuthCode = "NYNNYYYNNN"
            frmSearch.CMDTYPE = "V"
            frmSearch.IsLocalSearch = gc_IsNotLocalMsg
            frmSearch.SearchOnInit = False
            frmSearch.BranchId = Me.BranchId
            frmSearch.TellerId = Me.TellerId
            frmSearch.LinkValue = Me.txtCUSTID.Text
            frmSearch.ParentObjName = Me.ObjectName
            frmSearch.ParentClause = KeyFieldName & " = '" & Me.txtCUSTID.Text & "'"
            frmSearch.ShowDialog()
            'LoadDetailData(Me.tabMaster.TabPages(v_idx).Name)
            LoadTemplates(Me.txtCUSTID.Text)
        Else
            MsgBox(ResourceManager.GetString("MsgCUSTID_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Me.txtCUSTID.Focus()
        End If
    End Sub

    Private Sub btnTEMPLATE_VIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTEMPLATE_VIEW.Click
        If Me.txtCUSTID.Text.Length = 10 Then
            ShowTemplate(ExecuteFlag.View)
        Else
            MsgBox(ResourceManager.GetString("MsgCUSTID_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Me.txtCUSTID.Focus()
        End If
    End Sub

    Private Sub btnTEMPLATE_EDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTEMPLATE_EDIT.Click
        If CType(AFTEMPLATESGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value = -1 Then
            MsgBox(ResourceManager.GetString("TEMPLATE_AUTOID_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Else
            If Me.txtCUSTID.Text.Length = 10 Then
                ShowTemplate(ExecuteFlag.Edit)
                LoadTemplates(Me.txtCUSTID.Text)
            Else
                MsgBox(ResourceManager.GetString("MsgCUSTID_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Me.txtCUSTID.Focus()
            End If
        End If
    End Sub

    Private Sub btnTEMPLATE_DELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTEMPLATE_DELETE.Click
        Dim v_strObjMsg, v_strErrorSource, v_strErrorMessage, v_strClause As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_lngErrorCode As Long = ERR_SYSTEM_OK
        Try
            If CType(AFTEMPLATESGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value = -1 Then
                MsgBox(ResourceManager.GetString("TEMPLATE_AUTOID_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Else
                'frmSearch.ParentObjName = Me.ObjectName
                ' frmSearch.ParentClause = KeyFieldName & " = '" & Me.txtCUSTID.Text & "'"

                v_strClause = " AUTOID = " & Trim(CType(AFTEMPLATESGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.AFTEMPLATES", gc_ActionDelete, , v_strClause, , , , , , , , Me.ObjectName, KeyFieldName & " = '" & Me.txtCUSTID.Text & "'")
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
                    LoadTemplates(Me.txtCUSTID.Text)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub btnCFRPTAFMAST_ADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCFRPTAFMAST_ADD.Click
    '    If Me.txtCUSTID.Text.Length = 10 Then
    '        showFormRPTAFMAST(ExecuteFlag.AddNew)
    '    Else
    '        MsgBox(ResourceManager.GetString("MsgCUSTID_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
    '        Me.txtCUSTID.Focus()
    '    End If
    'End Sub

    'Private Sub btnCFRPTAFMAST_VIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCFRPTAFMAST_VIEW.Click
    '    showFormRPTAFMAST(ExecuteFlag.View)
    'End Sub

    'Private Sub btnCFRPTAFMAST_EDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCFRPTAFMAST_EDIT.Click
    '    showFormRPTAFMAST(ExecuteFlag.Edit)
    'End Sub

    'Private Sub btnCFRPTAFMAST_DELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCFRPTAFMAST_DELETE.Click
    '    If CFRPTAFMASTGrid.CurrentGrid.DataRows.Count > 0 Then
    '        Delete_TabPage_Row(gc_IsNotLocalMsg, ModuleCode & ".RPTAFMAST")
    '        LoadCFRPTAFMAST(Me.txtCUSTID.Text)
    '    End If
    'End Sub

    Private Sub CFAUTHGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CFAUTHGrid.Click
        If CType(CFAUTHGrid.CurrentRow, Xceed.Grid.DataRow).Cells("DELTD").Value = "Y" Then
            btnCFAUTH_EDIT.Enabled = False
            btnCFAUTH_DELETE.Enabled = False
        Else
            btnCFAUTH_EDIT.Enabled = True
            btnCFAUTH_DELETE.Enabled = True
        End If
    End Sub

    Private Sub CFOTHERACCGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CFOTHERACCGrid.Click
        If Not (CFOTHERACCGrid.CurrentRow Is Nothing) Then
            showFormCFOTHERACC(ExecuteFlag.View)
        End If
    End Sub

    Private Sub AFMASTGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AFMASTGrid.Click
        If Not (AFMASTGrid.CurrentRow Is Nothing) Then
            showFormAFMAST(ExecuteFlag.View)
        End If
    End Sub

    Private Sub REAFLNKGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles REAFLNKGrid.Click
        If Not (REAFLNKGrid.CurrentRow Is Nothing) Then
            showFormREAFLNK(ExecuteFlag.View)
        End If
    End Sub

    Private Sub tbcCFMAST_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbcINCORPORATION.SelectedIndexChanged
        If Me.txtCUSTID.Text.Length > 0 Then
            Dim v_strTabPageName = tbcINCORPORATION.TabPages(tbcINCORPORATION.SelectedIndex).Name.ToLower
            If String.Compare(v_strTabPageName, tpAFMAST.Name.ToLower) = 0 Then
                LoadAFMAST(Me.txtCUSTID.Text)
            ElseIf String.Compare(v_strTabPageName, tpCFAUTH.Name.ToLower) = 0 Then
                LoadCFAUTH(Me.txtCUSTID.Text)
            ElseIf String.Compare(v_strTabPageName, tpCFCONTACT.Name.ToLower) = 0 Then
                LoadCFCONTACT(Me.txtCUSTID.Text)
            ElseIf String.Compare(v_strTabPageName, tpCFOTHERACC.Name.ToLower) = 0 Then
                LoadCFOTHERACC(Me.txtCUSTID.Text)
            ElseIf String.Compare(v_strTabPageName, spcEmailReport.Name.ToLower) = 0 Then
                LoadEMAILREPORT(Me.txtCUSTID.Text)
            ElseIf String.Compare(v_strTabPageName, tpCFRELATION.Name.ToLower) = 0 Then
                LoadCFRELATION(Me.txtCUSTID.Text)
            ElseIf String.Compare(v_strTabPageName, tpCFRPTAFMAST.Name.ToLower) = 0 Then
                LoadCFRPTAFMAST(Me.txtCUSTID.Text)
            ElseIf String.Compare(v_strTabPageName, tpCFSIGN.Name.ToLower) = 0 Then
                LoadCFSIGN(Me.txtCUSTID.Text)
            ElseIf String.Compare(v_strTabPageName, tpISSUER.Name.ToLower) = 0 Then
                LoadISSUER(Me.txtCUSTID.Text)
            ElseIf String.Compare(v_strTabPageName, tpOTRIGHT.Name.ToLower) = 0 Then
                LoadOTRIGHT(Me.txtCUSTID.Text)
            ElseIf String.Compare(v_strTabPageName, tpREAFLNK.Name.ToLower) = 0 Then
                LoadREAFLNK(Me.txtCUSTID.Text)
            ElseIf String.Compare(v_strTabPageName, tpTemplates.Name.ToLower) = 0 Then
                LoadTemplates(Me.txtCUSTID.Text)
            ElseIf String.Compare(v_strTabPageName, tpCFRPTAFMAST.Name.ToLower) = 0 Then
                LoadCFRPTAFMAST(Me.txtCUSTID.Text)
            ElseIf String.Compare(v_strTabPageName, tpCURRENTACC.Name.ToLower) = 0 Then 'thunt
                LoadCURRENTACC(Me.txtCUSTID.Text)
            ElseIf String.Compare(v_strTabPageName, tpBROKER.Name.ToLower) = 0 Then
                LoadFABROKERAGE(Me.txtCUSTODYCD.Text)
                'TanPN 07/02/2020 
            ElseIf String.Compare(v_strTabPageName, tpAP.Name.ToLower) = 0 Then
                LoadFAAP(Me.txtCUSTID.Text)
            ElseIf String.Compare(v_strTabPageName, tpCFDomain.Name.ToLower) = 0 Then
                LoadCFDOMAIN(Me.txtCUSTID.Text)
                'ElseIf String.Compare(v_strTabPageName, tgCORPORATE.Name.ToLower) = 0 Then
                '    LoadCORPORATE(Me.txtCUSTID.Text)
            End If
        End If
    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        Dim v_ws As New BDSDeliveryManagement
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strVALUE As String
        Dim v_dblCount As Double = 0
        Dim v_strSQL, v_strObjMsg As String
        Dim v_result As String
        v_strSender = "btnApply"
        If ExeFlag = ExecuteFlag.AddNew Then
            If txtTRADINGCODE.Text Is DBNull.Value Then
                MessageBox.Show("MsgTRADINGCODEISEMPTY", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub btnREAFLNK_ADD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnREAFLNK_ADD.Click
        If Me.txtCUSTID.Text.Length = 10 Then
            showFormREAFLNK(ExecuteFlag.AddNew)
            LoadREAFLNK(Me.txtCUSTID.Text)
        Else
            MsgBox(ResourceManager.GetString("MsgCUSTID_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Me.txtCUSTID.Focus()
        End If
    End Sub

    'Private Sub btnREAFLNK_DELETE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnREAFLNK_DELETE.Click
    'Delete_TabPage_Row("N", "RE.REAFLNK")
    'LoadREAFLNK(Me.txtCUSTID.Text)
    'End Sub

    Private Sub btnREAFLNK_EDIT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnREAFLNK_EDIT.Click
        Dim v_ws As New BDSDeliveryManagement
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strVALUE As String
        Dim v_dblCount As Double = 0
        Dim v_strSQL, v_strObjMsg As String
        Try

            v_strSQL = "SELECT count(1) AFCNT FROM AFMAST WHERE CUSTID = '" & Me.txtCUSTID.Text & "'"
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
                            Case "AFCNT"
                                v_dblCount = CDbl(v_strVALUE)
                        End Select
                    End With
                Next
            Next
            If v_dblCount > 0 Then
                MsgBox(ResourceManager.GetString("AFMAST_EXISTS"), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Exit Sub
            End If
            showFormREAFLNK(ExecuteFlag.Edit)
            LoadREAFLNK(Me.txtCUSTID.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnREAFLNK_VIEW_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnREAFLNK_VIEW.Click
        showFormREAFLNK(ExecuteFlag.View)
    End Sub

    Private Sub btnPRINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPRINT.Click
        GenAFReport()

    End Sub


    Private Sub PrepareReportParams(ByVal v_strAFACCTNO As String)
        Dim v_xmlDocument As New XmlDocumentEx
        Dim v_xmlNodeList As Xml.XmlNodeList
        Try
            Dim v_obj As ReportParameters, i, v_intParams As Integer, v_ctrl As Control
            Dim v_strLookupData, v_strFLDNAME, v_strVALUE, v_strParamValue, v_strParamDesc As String

            ReDim mv_arrRptParam(0)    'Mac dinh la bao gom tat ca gia tri trong errObjFields la tham so

            v_obj = New ReportParameters
            v_obj.ParamName = "p_afacctno"
            v_obj.ParamCaption = "afacctno"
            v_obj.ParamValue = String.Empty
            v_obj.ParamValue = v_strAFACCTNO
            v_obj.ParamDescription = v_strAFACCTNO
            v_obj.ParamType = GetType(System.String).Name
            v_obj.ParamSize = 10
            mv_arrRptParam(0) = v_obj

            'Bao gồm cả 02 tham số mặc định OPT và BRID
            mv_intNumOfParam = 1
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
            ' v_strSQL = "select fn_getafrptname('" & Me.txtACCTNO.Text.Trim & "') RPTNAME from dual"
            v_strSQL = "select fn_getcfrptname('" & Me.txtCUSTID.Text.Trim & "') RPTNAME from dual"
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


            PrepareReportParams(Me.txtCUSTID.Text.Replace(".", ""))
            'Xu ly cho Sub Report

            'Create message and send to web service to get data for the report
            mv_strStoreName = "CFAFRPT" ' hardcode
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
                MessageBox.Show("ReportCreateSucessfully", gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
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


    Private Sub txtEMAIL_Validating1(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtEMAIL.Validating

    End Sub

    Private Sub txtMOBILE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtMOBILE.Validating

    End Sub

    'Private Sub CBoOnline_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboISCHKONLIMIT.SelectedIndexChanged
    '    Try
    '        If Me.cboISCHKONLIMIT.SelectedValue = "Y" Then
    '            Me.TxtOnlineLimit.Enabled = False
    '            Me.LblOlLimit.Enabled = False
    '            Me.TxtOnlineLimit.Hide()
    '            Me.LblOlLimit.Hide()
    '        Else
    '            Me.TxtOnlineLimit.Show()
    '            Me.LblOlLimit.Show()
    '            Me.TxtOnlineLimit.Enabled = True
    '            Me.LblOlLimit.Enabled = True
    '        End If
    '    Catch ex As Exception
    '        Me.cboISCHKONLIMIT.SelectedValue = "Y"
    '        Me.TxtOnlineLimit.Enabled = False
    '        Me.LblOlLimit.Enabled = False
    '        Me.TxtOnlineLimit.Hide()
    '        Me.LblOlLimit.Hide()
    '    End Try
    'End Sub

    Private Sub TxtOnlineLimit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtIDCODE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtIDCODE.Validating
        Dim v_ws As New BDSDeliveryManagement
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strVALUE As String
        Dim v_dblCount As Double = 0
        Dim v_strSQL, v_strObjMsg As String
        Dim v_strIDCode As String
        Try
            If cboIDTYPE.SelectedValue = IDTYPE_TRADINGCODE Then
                v_strIDCode = txtTRADINGCODE.Text
            Else

            End If
            'TanPN 5/2/2020 edit: kiểm tra trùng trusteeid => cho phép trùng idcode 
            If (ExeFlag = ExecuteFlag.AddNew) Then
                If cboIDTYPE.SelectedValue = IDTYPE_TRADINGCODE Then
                    v_strSQL = "SELECT count(*) CINT FROM cfmast WHERE TRADINGCODE = '" & UCase(txtTRADINGCODE.Text) & "' and status <> 'C' and substr(CUSTODYCD,1,4) = substr('" & txtCUSTODYCD.Text & "',1,4)"
                Else
                    v_strSQL = "SELECT count(*) CINT FROM cfmast WHERE idcode = '" & UCase(txtIDCODE.Text) & "' and status <> 'C'  and TRUSTEEID <> " + cboTRUSTEE.SelectedValue + "  and substr(CUSTODYCD,1,4) = substr('" & txtCUSTODYCD.Text & "',1,4)"

                End If
            Else
                If cboIDTYPE.SelectedValue = IDTYPE_TRADINGCODE Then
                    v_strSQL = "SELECT count(*) CINT FROM cfmast WHERE TRADINGCODE = '" & UCase(txtTRADINGCODE.Text) & "' and status <> 'C' and substr(CUSTODYCD,1,4) = substr('" & txtCUSTODYCD.Text & "',1,4) and custid <> " & Me.txtCUSTID.Text
                Else
                    v_strSQL = "SELECT count(*) CINT FROM cfmast WHERE idcode = '" & UCase(txtIDCODE.Text) & "' and status <> 'C'  and TRUSTEEID <> " + cboTRUSTEE.SelectedValue + " and substr(CUSTODYCD,1,4) = substr('" & txtCUSTODYCD.Text & "',1,4) and custid <> " & Me.txtCUSTID.Text
                End If
            End If

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
                            Case "CINT"
                                v_dblCount = CDbl(v_strVALUE)
                        End Select
                    End With
                Next
            Next
            If v_dblCount > 0 Then
                MsgBox(ResourceManager.GetString("IDCODE_EXISTS"), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                txtIDCODE.Focus()
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub cboMARGINALLOW_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMARGINALLOW.SelectedValueChanged
    '    Dim v_ws As New BDSDeliveryManagement
    '    If cboMARGINALLOW.SelectedValue.ToString = "Y" Then

    '        Dim v_xmlDocument As New Xml.XmlDocument
    '        Dim v_strCmdSQL, v_strObjMsg As String
    '        Dim v_nodeList As Xml.XmlNodeList
    '        v_strCmdSQL = "Select varvalue VARVALUE from sysvar where varname = 'MRLOANLIMIT'"
    '        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
    '        v_ws.Message(v_strObjMsg)
    '        v_xmlDocument.LoadXml(v_strObjMsg)
    '        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
    '        For v_intCount As Integer = 0 To v_nodeList.Count - 1
    '            For v_int As Integer = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
    '                With v_nodeList.Item(v_intCount).ChildNodes(v_int)
    '                    Dim v_strFLDNAME As String = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
    '                    Dim v_strVALUE As String = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()
    '                    If v_strFLDNAME = "VARVALUE" Then
    '                        Me.txtMRLOANLIMIT.Text = FormatNumber(CDbl(v_strVALUE), 0)

    '                    End If
    '                End With
    '            Next
    '        Next
    '    Else
    '        Me.txtMRLOANLIMIT.Text = 0
    '    End If
    'End Sub
    'DieuNDA 28/12/2016 Revert phan cua Vu
    'Private Sub txtCUSTODYCD_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    MessageBox.Show("Load Focus")
    'End Sub
    'End DieuNDA 28/12/2016 Revert phan cua Vu

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub dtpTAXCODEDATE_ValueChanged(sender As Object, e As EventArgs) Handles dtpTAXCODEDATE.EditValueChanged
        If Not (Me.dtpTAXCODEDATE.EditValue Is Nothing) Then
            Dim aDate As Date
            aDate = (Me.dtpTAXCODEDATE.EditValue.AddYears(50))
            Me.dtpTAXCODEEXPIRYDATE.EditValue = aDate
        End If
    End Sub
    Private Sub dtpIDDATE_ValueChanged(sender As Object, e As EventArgs) Handles dtpIDDATE.EditValueChanged
        If Not (dtpIDDATE.EditValue Is Nothing) Then
            Dim aDate As Date
            aDate = (Me.dtpIDDATE.EditValue.AddYears(50))
            Me.dtpIDEXPIRED.EditValue = aDate
        End If
    End Sub

    Private Sub frmCFMAST_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub txtSHORTCKCT_KeyUp(sender As Object, e As KeyEventArgs)
        Dim v_ws As New BDSDeliveryManagement
        Dim v_strOldVal As String = ""
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_strCmdSQL, v_strObjMsg, v_strSQL, v_strSHORTCTCK, v_strFULLCTCK As String
        Dim v_strTRUADDRESS, v_strSHORTNAME As String
        Dim v_nodeList As Xml.XmlNodeList
        Select Case e.KeyCode
            Case Keys.F5
                Dim frm As New frmSearch(Me.UserLanguage)
                frm.TableName = "FAMEMBERS"
                frm.ModuleCode = "FA"
                frm.KeyFieldType = "C"
                frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                frm.IsLocalSearch = gc_IsNotLocalMsg
                frm.IsLookup = "Y"
                frm.SearchOnInit = False
                frm.BranchId = "9999"
                frm.TellerId = Me.TellerId
                frm.ShowDialog()
                'Me.ActiveControl.Text = Trim(frm.ReturnValue)
                v_strCmdSQL = "Select SHORTNAME , FULLNAME from FAMEMBERS where AUTOID = '" & Trim(frm.ReturnValue) & "'"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                For v_intCount As Integer = 0 To v_nodeList.Count - 1
                    For v_int As Integer = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                        With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                            Dim v_strFLDNAME As String = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                            Dim v_strVALUE As String = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()
                            Select Case Trim(v_strFLDNAME)
                                Case "SHORTNAME"
                                    v_strSHORTCTCK = Trim(v_strVALUE)
                                Case "FULLNAME"
                                    v_strFULLCTCK = Trim(v_strVALUE)
                            End Select
                        End With
                    Next
                Next
                'Me.txtSHORTCKCT.Text = v_strSHORTCTCK
                ' Me.txtFULLCTCK.Text = v_strFULLCTCK
        End Select
    End Sub

    Private Sub cboTRUSTEE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTRUSTEE.SelectedIndexChanged
        Dim v_ws As New BDSDeliveryManagement
        Dim v_strOldVal As String = ""
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_strCmdSQL, v_strObjMsg, v_strSQL, v_strSHORTCTCK, v_strFULLCTCK As String
        Dim v_strTRUADDRESS, v_strSHORTNAME, v_strRoles As String
        Dim v_nodeList As Xml.XmlNodeList
        Try
            v_strCmdSQL = "select ADDRESS, ROLES from FAMEMBERS where AUTOID='" & cboTRUSTEE.SelectedValue & "'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For v_intCount As Integer = 0 To v_nodeList.Count - 1
                For v_int As Integer = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                    With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                        Dim v_strFLDNAME As String = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                        Dim v_strVALUE As String = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()
                        Select Case v_strFLDNAME
                            Case "ADDRESS"
                                v_strTRUADDRESS = v_strVALUE
                            Case "ROLES"
                                v_strRoles = v_strVALUE
                        End Select
                    End With
                Next
            Next

            Me.txtADDRESS.Text = ""
            Me.txtADDRESS.Enabled = True
            If v_strRoles = "TRU" Then
                Me.txtADDRESS.Text = v_strTRUADDRESS
                Me.txtADDRESS.Enabled = False
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnFABROKERAGE_ADD_Click(sender As Object, e As EventArgs) Handles btnFABROKERAGE_ADD.Click
        If Me.txtCUSTID.Text.Length = 10 Then
            showFormFABROKERAGE(ExecuteFlag.AddNew)
        Else
            MsgBox(ResourceManager.GetString("MsgCUSTID_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Me.txtCUSTID.Focus()
        End If
    End Sub

    Private Sub btnFABROKERAGE_VIEW_Click(sender As Object, e As EventArgs) Handles btnFABROKERAGE_VIEW.Click
        Dim v_strMemberid As Long
        v_strMemberid = Trim(CType(FABROKERAGEGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
        showFormFAMEMBERSEXTRA(ExecuteFlag.View)
    End Sub

    Private Sub btnFABROKERAGE_EDIT_Click(sender As Object, e As EventArgs) Handles btnFABROKERAGE_EDIT.Click
        Dim v_strMemberid As Long
        'showFormFABROKERAGE(ExecuteFlag.Edit)
        v_strMemberid = Trim(CType(FABROKERAGEGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
        showFormFAMEMBERSEXTRA(ExecuteFlag.Edit)
    End Sub
    Private Sub btnFABROKERAGE_DELETE_Click(sender As Object, e As EventArgs) Handles btnFABROKERAGE_DELETE.Click
        Dim v_strObjMsg, v_strErrorSource, v_strErrorMessage, v_strClause, v_strSQL As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_lngErrorCode As Long = ERR_SYSTEM_OK
        Dim v_frm As New frmSearch(UserLanguage)
        Dim v_dtrCustodycdname As String = "CUSTODYCD"
        Try

            If CType(FABROKERAGEGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value = -1 Then
                'MsgBox(ResourceManager.GetString("TEMPLATE_AUTOID_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Else

                v_strClause = "CUSTODYCD='" & Me.txtCUSTODYCD.Text & "' and BRKID = " & Trim(CType(FABROKERAGEGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
                'v_strSQL = "UPDATE FABROKERAGE SET STATUS='C' WHERE " & v_strClause & ""
                'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "FA.FABROKERAGE", gc_ActionInquiry, v_strSQL)

                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "FA.FABROKERAGE", gc_ActionDelete, , v_strClause, , , , , , , , Me.ObjectName, KeyFieldName & " = '" & Me.txtCUSTID.Text & "'")
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
                    LoadTemplates(Me.txtCUSTID.Text)
                End If
            End If
            LoadFABROKERAGE(Me.txtCUSTODYCD.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboACCOUNTTYPE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboACCOUNTTYPE.SelectedIndexChanged
        cboCCYBANK.SelectedValue = "VND"
        If Me.cboACCOUNTTYPE.SelectedValue = "002" Or Me.cboACCOUNTTYPE.SelectedValue = "004" Then
            Me.cboCCYBANK.Enabled = True
            cboCCYBANK.SelectedValue = "VND"
        Else
            cboCCYBANK.SelectedValue = "VND"
            Me.cboCCYBANK.Enabled = False
        End If
    End Sub

    Private Sub cboCCYBANK_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCCYBANK.SelectedIndexChanged

    End Sub


    Private Sub txtACCOUNTBANK_TextChanged(sender As Object, e As EventArgs) Handles txtACCOUNTBANK.TextChanged
        If Me.txtACCOUNTBANK.Text = "" And lblACCOUNTBANK.ForeColor = Color.Red Then
            MsgBox(ResourceManager.GetString("NULLTEXT"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Me.txtACCOUNTBANK.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub btnCURRENTACC_ADD_Click(sender As Object, e As EventArgs) Handles btnCURRENTACC_ADD.Click
        showFormINFORBANK(ExecuteFlag.AddNew)
    End Sub

    Private Sub btnCURRENTACC_VIEW_Click(sender As Object, e As EventArgs) Handles btnCURRENTACC_VIEW.Click
        showFormINFORBANK(ExecuteFlag.View)
    End Sub

    Private Sub btnCURRENTACC_EDIT_Click(sender As Object, e As EventArgs) Handles btnCURRENTACC_EDIT.Click
        If Me.txtCUSTID.Text.Length = 10 Then
            Dim status = Trim(CType(CURRENTACCGrid.CurrentRow, Xceed.Grid.DataRow).Cells("STATUSCD").Value)
            If status = "C" Then
                MsgBox(ResourceManager.GetString("MsgEDIT_StatusInvalid"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Exit Sub
            End If
            showFormINFORBANK(ExecuteFlag.Edit)
            LoadCURRENTACC(Me.txtCUSTID.Text)
        Else
            MsgBox(ResourceManager.GetString("MsgCUSTID_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Me.txtCUSTID.Focus()
        End If
    End Sub

    Private Sub btnCURRENTACC_DELETE_Click(sender As Object, e As EventArgs) Handles btnCURRENTACC_DELETE.Click

        OnDeleteinforbank(gc_IsNotLocalMsg, "DD.DDMAST")
    End Sub

    Private Sub txtIDCODE_TextChanged(sender As Object, e As EventArgs) Handles txtIDCODE.TextChanged
        txtTAXCODE.Text = txtIDCODE.Text
    End Sub

    Private Sub cboCOUNTRY_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCOUNTRY.SelectedIndexChanged
        Dim v_strCmdSQL As String, v_strObjMsg As String
        Dim v_strOLDIDTYPE As String = String.Empty
        Dim v_ws As New BDSDeliveryManagement
        Try
            If Not cboCOUNTRY.SelectedValue Is DBNull.Value Then
                If cboCOUNTRY.SelectedValue = VIETNAMEESE_CODE Then
                    If Not cboCUSTTYPE.SelectedValue Is DBNull.Value Then
                        If cboCUSTTYPE.SelectedValue = "B" Then
                            v_strCmdSQL = "SELECT  CDVAL VALUECD, CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY FROM ALLCODE WHERE CDTYPE = 'CF' AND CDNAME = 'IDTYPE' AND CDVAL in ('005','009') ORDER BY LSTODR"
                        Else
                            v_strCmdSQL = "SELECT  CDVAL VALUECD, CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY FROM ALLCODE WHERE CDTYPE = 'CF' AND CDNAME = 'IDTYPE' AND CDVAL in ('001') ORDER BY LSTODR"
                        End If
                    Else
                        v_strCmdSQL = "SELECT  CDVAL VALUECD, CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY FROM ALLCODE WHERE CDTYPE = 'CF' AND CDNAME = 'IDTYPE' AND CDVAL in ('001') ORDER BY LSTODR"
                    End If

                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                    v_ws.Message(v_strObjMsg)
                    If Not (cboIDTYPE.SelectedValue Is Nothing) And ExeFlag <> ExecuteFlag.AddNew Then
                        v_strOLDIDTYPE = cboIDTYPE.SelectedValue
                    End If
                    FillComboEx(v_strObjMsg, Me.cboIDTYPE, "", Me.UserLanguage)
                    If Not (v_strOLDIDTYPE Is Nothing) And ExeFlag <> ExecuteFlag.AddNew Then
                        cboIDTYPE.SelectedValue = v_strOLDIDTYPE
                    End If

                    lblPROVINCE.ForeColor = Color.Red
                    If ExeFlag = ExecuteFlag.AddNew Then 'longnh
                        'txtCUSTODYCD.Text = mv_PrefixCustodyCD & "C"
                        If cboCUSTTYPE.SelectedValue = "B" Then
                            cboIDTYPE.SelectedValue = IDTYPE_GPKD 'SONLT 20150122
                        Else
                            cboIDTYPE.SelectedValue = IDTYPE_CMND 'SONLT 20150122
                        End If
                    End If
                Else
                    If Not cboCUSTTYPE.SelectedValue Is DBNull.Value Then
                        v_strCmdSQL = "SELECT  CDVAL VALUECD, CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY FROM ALLCODE WHERE CDTYPE = 'CF' AND CDNAME = 'IDTYPE' AND CDVAL in ('009') ORDER BY LSTODR"
                        'If cboCUSTTYPE.SelectedValue = "B" Then
                        '    v_strCmdSQL = "SELECT  CDVAL VALUECD, CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY FROM ALLCODE WHERE CDTYPE = 'CF' AND CDNAME = 'IDTYPE' AND CDVAL in ('001','009') ORDER BY LSTODR"
                        'Else
                        '    v_strCmdSQL = "SELECT  CDVAL VALUECD, CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY FROM ALLCODE WHERE CDTYPE = 'CF' AND CDNAME = 'IDTYPE' AND CDVAL in ('009') ORDER BY LSTODR"
                        'End If
                        'v_strCmdSQL = "SELECT  CDVAL VALUECD, CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY FROM ALLCODE WHERE CDTYPE = 'CF' AND CDNAME = 'IDTYPE' AND CDVAL in ('001','009') ORDER BY LSTODR"
                    End If
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                    v_ws.Message(v_strObjMsg)
                    If Not (cboIDTYPE.SelectedValue Is Nothing) And ExeFlag <> ExecuteFlag.AddNew Then
                        v_strOLDIDTYPE = cboIDTYPE.SelectedValue
                    End If
                    FillComboEx(v_strObjMsg, Me.cboIDTYPE, "", Me.UserLanguage)
                    If Not (v_strOLDIDTYPE Is Nothing) And ExeFlag <> ExecuteFlag.AddNew Then
                        cboIDTYPE.SelectedValue = v_strOLDIDTYPE
                    End If

                    lblPROVINCE.ForeColor = Color.Blue
                    If ExeFlag = ExecuteFlag.AddNew Then 'longnh
                        Dim v_strTradingcode As String
                        v_strTradingcode = txtTRADINGCODE.Text
                        'txtCUSTODYCD.Text = mv_PrefixCustodyCD & "F" & v_strTradingcode
                        cboIDTYPE.SelectedValue = IDTYPE_TRADINGCODE
                        lblTRADINGCODE.ForeColor = Color.Red
                    End If
                End If
                cbo_VAT_setvalue(cboCOUNTRY.SelectedValue, cboCUSTTYPE.SelectedValue)

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private v_strOLDIDTYPE As String = ""

    Private Sub cboCUSTTYPE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCUSTTYPE.SelectedIndexChanged
        Dim v_strCmdSQL As String, v_strObjMsg As String
        'Dim v_strOLDIDTYPE As String = String.Empty
        Dim v_ws As New BDSDeliveryManagement
        Try
            If Not cboCUSTTYPE.SelectedValue Is DBNull.Value Then

                If cboCUSTTYPE.SelectedValue = "B" Then
                    'TanPN 21/2/2020
                    lblIDCODE.Text = ResourceManager.GetString("BUSINESS_REGISTRATION")
                    lblDATEOFBIRTH.Text = ResourceManager.GetString("FOUNDINGDATE")
                    If Not cboCOUNTRY.SelectedValue Is DBNull.Value Then
                        If cboCOUNTRY.SelectedValue = VIETNAMEESE_CODE Then
                            v_strCmdSQL = "SELECT  CDVAL VALUECD, CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY FROM ALLCODE WHERE CDTYPE = 'CF' AND CDNAME = 'IDTYPE' AND CDVAL in ('005','009') ORDER BY LSTODR"
                        Else
                            v_strCmdSQL = "SELECT  CDVAL VALUECD, CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY FROM ALLCODE WHERE CDTYPE = 'CF' AND CDNAME = 'IDTYPE' AND CDVAL in ('009') ORDER BY LSTODR"
                        End If
                    Else
                        v_strCmdSQL = "SELECT  CDVAL VALUECD, CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY FROM ALLCODE WHERE CDTYPE = 'CF' AND CDNAME = 'IDTYPE' AND CDVAL in ('005') ORDER BY LSTODR"
                    End If

                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                    v_ws.Message(v_strObjMsg)
                    If Not (cboIDTYPE.SelectedValue Is Nothing) And v_strOLDIDTYPE = "" And ExeFlag <> ExecuteFlag.AddNew Then
                        v_strOLDIDTYPE = cboIDTYPE.SelectedValue
                    End If
                    FillComboEx(v_strObjMsg, Me.cboIDTYPE, "", Me.UserLanguage)

                    If ExeFlag = ExecuteFlag.AddNew Then
                        cboVAT.SelectedValue = "N"
                    ElseIf v_strOLDIDTYPE <> "" Then
                        cboIDTYPE.SelectedValue = v_strOLDIDTYPE
                    End If
                    cboVAT.Enabled = True
                    'End If
                    If ExeFlag = ExecuteFlag.AddNew OrElse ExeFlag = ExecuteFlag.Edit Then
                        cboMARRIED.Enabled = False
                        'dtpDATEOFBIRTH.Enabled = False
                        cboSEX.Enabled = False
                        cboEDUCATION.Enabled = False
                        cboOCCUPATION.Enabled = False
                        cboPOSITION.Enabled = False
                        lblPROVINCE.ForeColor = Color.Red
                    End If

                    Dim mv_arrObjFields() As CFieldMaster = Me.getMv_arrObjFields()
                    For i As Integer = 0 To UBound(mv_arrObjFields) - 1
                        If mv_arrObjFields(i).FieldName = Trim("DATEOFBIRTH") Then
                            mv_arrObjFields(i).Mandatory = False
                            Exit For
                        End If
                    Next
                    Me.setMv_arrObjFields(mv_arrObjFields, Me)

                Else
                    'TanPN 21/2/2020
                    If cboCOUNTRY.SelectedValue = VIETNAMEESE_CODE Then
                        lblIDCODE.Text = ResourceManager.GetString("IDCODE")
                    Else
                        lblIDCODE.Text = ResourceManager.GetString("PASSPORT_IDCODE")
                    End If
                    lblDATEOFBIRTH.Text = ResourceManager.GetString("DATEOFBIRTH")
                    If Not cboCOUNTRY.SelectedValue Is DBNull.Value Then
                        If cboCOUNTRY.SelectedValue = VIETNAMEESE_CODE Then
                            v_strCmdSQL = "SELECT  CDVAL VALUECD, CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY FROM ALLCODE WHERE CDTYPE = 'CF' AND CDNAME = 'IDTYPE' AND CDVAL in ('001') ORDER BY LSTODR"
                        Else
                            v_strCmdSQL = "SELECT  CDVAL VALUECD, CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY FROM ALLCODE WHERE CDTYPE = 'CF' AND CDNAME = 'IDTYPE' AND CDVAL in ('009') ORDER BY LSTODR"
                        End If
                    Else
                        v_strCmdSQL = "SELECT  CDVAL VALUECD, CDVAL VALUE, CDCONTENT DISPLAY, EN_CDCONTENT EN_DISPLAY FROM ALLCODE WHERE CDTYPE = 'CF' AND CDNAME = 'IDTYPE' AND CDVAL in ('001') ORDER BY LSTODR"
                    End If
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                    v_ws.Message(v_strObjMsg)
                    If Not (cboIDTYPE.SelectedValue Is Nothing) And v_strOLDIDTYPE = "" And ExeFlag <> ExecuteFlag.AddNew Then
                        v_strOLDIDTYPE = cboIDTYPE.SelectedValue
                    End If
                    FillComboEx(v_strObjMsg, Me.cboIDTYPE, "", Me.UserLanguage)

                    If ExeFlag = ExecuteFlag.AddNew Then

                    ElseIf v_strOLDIDTYPE <> "" Then
                        cboIDTYPE.SelectedValue = v_strOLDIDTYPE
                    End If

                    cboVAT.SelectedValue = "Y"
                    cboVAT.Enabled = False
                    If ExeFlag = ExecuteFlag.AddNew OrElse ExeFlag = ExecuteFlag.Edit Then
                        cboMARRIED.Enabled = True
                        dtpDATEOFBIRTH.Enabled = True

                        cboSEX.Enabled = True
                        'lblSEX.ForeColor = Color.Red

                        cboEDUCATION.Enabled = True
                        cboOCCUPATION.Enabled = True
                        cboPOSITION.Enabled = True
                        'lblPROVINCE.ForeColor = Color.Red
                    End If
                    Dim mv_arrObjFields() As CFieldMaster = Me.getMv_arrObjFields()
                    For i As Integer = 0 To UBound(mv_arrObjFields) - 1
                        If mv_arrObjFields(i).FieldName = Trim("DATEOFBIRTH") Then
                            mv_arrObjFields(i).Mandatory = True
                            Exit For
                        End If
                    Next
                    Me.setMv_arrObjFields(mv_arrObjFields, Me)
                End If
                cbo_VAT_setvalue(cboCOUNTRY.SelectedValue, cboCUSTTYPE.SelectedValue)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    'trung.luu: 20-05-2021 SHBVNEX-1503 quoc tich khac viet nam => VAT = Y
    Private Sub cbo_VAT_setvalue(ByVal pv_cboCountry As String, ByVal pv_cboCusttype As String)
        If pv_cboCountry = VIETNAMEESE_CODE Then
            If pv_cboCusttype = "I" Then
                cboVAT.SelectedValue = "Y"
            Else
                cboVAT.SelectedValue = "N"
            End If
        Else
            cboVAT.SelectedValue = "Y"
        End If
    End Sub

    'TanPN 07/02/2020 
    Private Sub btnAP_ADD_Click(sender As Object, e As EventArgs) Handles btnAP_ADD.Click
        If Me.txtCUSTID.Text.Length = 10 Then
            showFormFAAP(ExecuteFlag.AddNew)
        Else
            MsgBox(ResourceManager.GetString("MsgCUSTID_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Me.txtCUSTID.Focus()
        End If
    End Sub
    'TanPN 07/02/2020 

    'thangpv 07/07/2022
    Private Sub btnFAMEMBERSEXTRA_ADD_Click(sender As Object, e As EventArgs)
        showFormFAMEMBERSEXTRA(ExecuteFlag.AddNew)
        LoadFABROKERAGE(Me.txtCUSTID.Text)
    End Sub

    Private Sub btnAP_DELETE_Click(sender As Object, e As EventArgs) Handles btnAP_DELETE.Click
        Dim v_strObjMsg, v_strErrorSource, v_strErrorMessage, v_strClause, v_strSQL As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_lngErrorCode As Long = ERR_SYSTEM_OK
        Dim v_frm As New frmSearch(UserLanguage)
        Dim v_dtrCustodycdname As String = "CUSTID"
        Try

            If CType(FAAPGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value = -1 Then
            Else

                v_strClause = "CUSTID='" & Me.txtCUSTID.Text & "' and REFID = " & Trim(CType(FAAPGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)

                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "FA.CFLNKAP", gc_ActionDelete, , v_strClause, , , , , , , , Me.ObjectName, KeyFieldName & " = '" & Me.txtCUSTID.Text & "'")
                v_ws.Message(v_strObjMsg)
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)

                If v_lngErrorCode <> 0 Then
                    Cursor.Current = Cursors.Default
                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Exit Sub
                Else
                    Cursor.Current = Cursors.Default
                    MsgBox(ResourceManager.GetString("DelSuccess"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    LoadTemplates(Me.txtCUSTID.Text)
                End If
            End If
            LoadFAAP(Me.txtCUSTID.Text)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub LoadEMAILREPORT(ByVal pv_strCUSTID As String)
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            If UserLanguage = "VN" Then
                mv_content = "CDCONTENT"
            Else
                mv_content = "EN_CDCONTENT"
            End If
            If Len(pv_strCUSTID) > 0 Then
                EMAILREPORTGrid.DataRows.Clear()
                Dim v_strSQL As String = "select e.AUTOID,a." & mv_content & " REGISTTYPE ,e.CUSTID ,e.EMAIL from EMAILREPORT e,(select * from allcode where cdtype = 'CF' and cdname = 'REGISTTYPE') a where  custid = '" & pv_strCUSTID & "' and a.cdval = e.REGISTTYPE and deltd <> 'Y' "
                'AnTB add them thong tin nguoi tao, nguoi duyet, trang thai
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "CF.CFMAST", _
                    gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                FillDataGrid(EMAILREPORTGrid, v_strObjMsg, "")
            End If
        Catch ex As Exception
            Throw ex
        Finally
            v_ws = Nothing
        End Try
    End Sub

    Public Sub showFormEMAILREPORT(ByVal pv_intExecFlag As Integer)
        Dim v_frm As New frmEMAILREPORT
        Dim v_ws As New BDSDeliveryManagement
        Dim v_strOldVal As String = ""
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_strCmdSQL, v_strObjMsg, v_strSQL As String
        Dim v_strTRUADDRESS, v_strAfacctno, v_stracctno As String
        Dim v_nodeList As Xml.XmlNodeList
        Try
            v_strCmdSQL = "Select ACCTNO from AFMAST where CUSTID = '" & Trim(txtCUSTID.Text) & "'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For v_intCount As Integer = 0 To v_nodeList.Count - 1
                For v_int As Integer = 0 To v_nodeList.Item(v_intCount).ChildNodes.Count - 1
                    With v_nodeList.Item(v_intCount).ChildNodes(v_int)
                        Dim v_strFLDNAME As String = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("fldname").Value.Trim()
                        Dim v_strVALUE As String = v_nodeList.Item(v_intCount).ChildNodes(v_int).Attributes.GetNamedItem("oldval").Value.Trim()
                        If v_strFLDNAME = "ACCTNO" Then
                            v_strAfacctno = v_strVALUE
                        End If
                    End With
                Next
            Next
            Me.txtT0LOANLIMIT.Text = 0
            v_frm.ExeFlag = pv_intExecFlag
            v_frm.UserLanguage = UserLanguage
            v_frm.BranchId = BranchId
            v_frm.TellerId = TellerId
            v_frm.CustomerId = Trim(txtCUSTID.Text)
            v_frm.Custodycd = Trim(txtCUSTODYCD.Text)
            v_frm.Afacctno = v_strAfacctno
            v_frm.acctno = v_strAfacctno
            v_frm.TellerRight = TellerRight
            v_frm.GroupCareBy = GroupCareBy
            v_frm.ModuleCode = "CF"
            v_frm.ObjectName = "CF.EMAILREPORT"
            v_frm.TableName = "EMAILREPORT"
            v_frm.LocalObject = "N"
            v_frm.BusDate = Me.BusDate
            If Not (pv_intExecFlag = ExecuteFlag.AddNew) Then
                v_frm.KeyFieldName = "AUTOID"
                v_frm.KeyFieldType = "N"
                v_frm.KeyFieldValue = Trim(CType(EMAILREPORTGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
            End If

            If (pv_intExecFlag = ExecuteFlag.AddNew) Then
                v_frm.ExeFlag = ExecuteFlag.AddNew
            ElseIf (pv_intExecFlag = ExecuteFlag.View) Then
                v_frm.ExeFlag = ExecuteFlag.View

            ElseIf (pv_intExecFlag = ExecuteFlag.Edit) Then
                v_frm.ExeFlag = ExecuteFlag.Edit

            ElseIf (pv_intExecFlag = ExecuteFlag.Delete) Then
                v_frm.ExeFlag = ExecuteFlag.Delete
            End If
            v_frm.ParentObjName = Me.ObjectName
            v_frm.ParentClause = KeyFieldName & " = '" & Trim(txtCUSTID.Text) & "'"
            v_frm.TellerId = TellerId
            v_frm.ShowDialog()
            If (pv_intExecFlag <> ExecuteFlag.View) Then
                LoadEMAILREPORT(Me.txtCUSTID.Text)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_frm.Dispose()
        End Try
    End Sub

    Private Sub btnEMAILREPORT_ADD_Click(sender As Object, e As EventArgs) Handles btnEMAILREPORT_ADD.Click
        showFormEMAILREPORT(ExecuteFlag.AddNew)
    End Sub

    Private Sub btnEMAILREPORT_VIEW_Click(sender As Object, e As EventArgs) Handles btnEMAILREPORT_VIEW.Click
        If (EMAILREPORTGrid.CurrentGrid.DataRows.Count > 0) Then
            showFormEMAILREPORT(ExecuteFlag.View)
        End If
    End Sub

    Private Sub btnEMAILREPORT_EDIT_Click(sender As Object, e As EventArgs) Handles btnEMAILREPORT_EDIT.Click
        If Me.txtCUSTID.Text.Length = 10 Then
            showFormEMAILREPORT(ExecuteFlag.Edit)
        Else
            MsgBox(ResourceManager.GetString("MsgCUSTID_INVALID"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Me.txtCUSTID.Focus()
        End If
    End Sub

    Private Sub btnEMAILREPORT_DELETE_Click(sender As Object, e As EventArgs) Handles btnEMAILREPORT_DELETE.Click
        If (EMAILREPORTGrid.CurrentGrid.DataRows.Count > 0) Then
            Delete_TabPage_Row(gc_IsNotLocalMsg, "CF.EMAILREPORT")
            LoadEMAILREPORT(Me.txtCUSTID.Text)
        End If
    End Sub

    Public Sub showFormCFDOMAIN(ByVal pv_intExecFlag As Integer)
        'Dim v_frm As New frmCFDOMAIN
        'Dim v_ws As New BDSDeliveryManagement
        'Dim v_strOldVal As String = ""
        'Dim v_xmlDocument As New Xml.XmlDocument
        'Dim v_strCmdSQL, v_strObjMsg, v_strSQL As String
        'Dim v_nodeList As Xml.XmlNodeList
        'Try
        '    v_frm.ExeFlag = pv_intExecFlag
        '    v_frm.UserLanguage = UserLanguage
        '    v_frm.BranchId = BranchId
        '    v_frm.TellerId = TellerId
        '    v_frm.CustomerId = Trim(txtCUSTID.Text)
        '    v_frm.Custodycd = Trim(txtCUSTODYCD.Text)
        '    v_frm.TellerRight = TellerRight
        '    v_frm.GroupCareBy = GroupCareBy
        '    v_frm.ModuleCode = "CF"
        '    v_frm.ObjectName = "CF.CFDOMAIN"
        '    v_frm.TableName = "CFDOMAIN"
        '    v_frm.LocalObject = "N"
        '    v_frm.BusDate = Me.BusDate
        '    If Not (pv_intExecFlag = ExecuteFlag.AddNew) Then
        '        v_frm.KeyFieldName = "AUTOID"
        '        v_frm.KeyFieldType = "N"
        '        v_frm.KeyFieldValue = Trim(CType(CFDOMAINGrid.CurrentRow, Xceed.Grid.DataRow).Cells("AUTOID").Value)
        '    End If

        '    If (pv_intExecFlag = ExecuteFlag.AddNew) Then
        '        v_frm.ExeFlag = ExecuteFlag.AddNew
        '    ElseIf (pv_intExecFlag = ExecuteFlag.View) Then
        '        v_frm.ExeFlag = ExecuteFlag.View

        '    ElseIf (pv_intExecFlag = ExecuteFlag.Edit) Then
        '        v_frm.ExeFlag = ExecuteFlag.Edit

        '    ElseIf (pv_intExecFlag = ExecuteFlag.Delete) Then
        '        v_frm.ExeFlag = ExecuteFlag.Delete
        '    End If
        '    v_frm.ParentObjName = Me.ObjectName
        '    v_frm.ParentClause = KeyFieldName & " = '" & Trim(txtCUSTID.Text) & "'"
        '    v_frm.TellerId = TellerId
        '    v_frm.ShowDialog()
        '    If (pv_intExecFlag <> ExecuteFlag.View) Then
        '        LoadCFDOMAIN(Me.txtCUSTID.Text)
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        'Finally
        '    v_frm.Dispose()
        'End Try
    End Sub

    Private Sub LoadCFDOMAIN(ByVal pv_strCUSTID As String)
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Try
            If UserLanguage = "VN" Then
                mv_content = "CDCONTENT"
            Else
                mv_content = "EN_CDCONTENT"
            End If
            If Len(pv_strCUSTID) > 0 Then
                CFDOMAINGrid.DataRows.Clear()
                Dim v_strSQL As String = "SELECT C.*, A1." & mv_content & " CVSDSTATUS, A2.DOMAINNAME " _
                         & " FROM CFDOMAIN C," _
                         & " (SELECT * FROM ALLCODE WHERE CDNAME = 'CFDOMAINSTS' AND CDTYPE = 'CF') A1," _
                         & " (SELECT * FROM DOMAIN) A2 " _
                         & " WHERE C.VSDSTATUS = A1.CDVAL " _
                         & " AND C.DOMAINCODE = A2.DOMAINCODE " _
                         & " AND C.CUSTID = '" & pv_strCUSTID & "' " _
                         & " AND C.DELTD NOT IN ('Y') "

                'AnTB add them thong tin nguoi tao, nguoi duyet, trang thai
                Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, MyBase.LocalObject, gc_MsgTypeObj, "CF.CFMAST", _
                    gc_ActionInquiry, v_strSQL)
                v_ws.Message(v_strObjMsg)
                FillDataGrid(CFDOMAINGrid, v_strObjMsg, "")
            End If
        Catch ex As Exception
            Throw ex
        Finally
            v_ws = Nothing
        End Try
    End Sub

    Protected Overridable Function OnDeleteCFDmain(Optional ByVal pv_strIsLocal As String = "", Optional ByVal pv_strModule As String = "") As Int32
        Dim v_strKeyFieldName, v_strKeyFieldValue As String
        Dim v_strClause As String

        Dim ParentObjName As String = Me.ObjectName
        Dim ParentClause As String = KeyFieldName & " = '" & txtCUSTID.Text & "'"

        Try
            If MsgBox(ResourceManager.GetString("DelConfirm"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
                'Update mouse pointer
                Cursor.Current = Cursors.WaitCursor

                If (pv_strIsLocal <> "") And (pv_strModule <> "") Then
                    If (mv_arrAUTOID.Length > 0) Then

                        v_strKeyFieldName = "AUTOID"
                        v_strKeyFieldValue = mv_arrAUTOID(mv_intCurrImageIndex)
                        v_strClause = v_strKeyFieldName & " = " & v_strKeyFieldValue

                        Dim v_strObjMsg As String = BuildXMLObjMsg(, BranchId, , TellerId, pv_strIsLocal, gc_MsgTypeObj, pv_strModule, gc_ActionDelete, , v_strClause, , , , , , , , ParentObjName, ParentClause)
                        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                        Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                        Dim v_strErrorSource, v_strErrorMessage As String

                        GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                        If v_lngErrorCode <> 0 Then
                            Cursor.Current = Cursors.Default
                            MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                            Exit Function
                        End If
                        mv_intCurrImageIndex = 0 'Tro ve ban dau
                    End If
                End If
                Cursor.Current = Cursors.Default
                MsgBox(ResourceManager.GetString("DelSuccess"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    Private Sub btnDOMAIL_ADD_Click(sender As Object, e As EventArgs) Handles btnCFDOMAIN_ADD.Click
        showFormCFDOMAIN(ExecuteFlag.AddNew)
        LoadCFDOMAIN(Me.txtCUSTID.Text)
    End Sub

    Private Sub btnCFDOMAIN_VIEW_Click(sender As Object, e As EventArgs) Handles btnCFDOMAIN_VIEW.Click
        showFormCFDOMAIN(ExecuteFlag.View)
    End Sub

    Private Sub btnCFDOMAIN_EDIT_Click(sender As Object, e As EventArgs) Handles btnCFDOMAIN_EDIT.Click
        showFormCFDOMAIN(ExecuteFlag.Edit)
        LoadCFDOMAIN(Me.txtCUSTID.Text)
    End Sub

    Private Sub btnCFDOMAIN_DELETE_Click(sender As Object, e As EventArgs) Handles btnCFDOMAIN_DELETE.Click
        OnDeleteCFDmain("N", ModuleCode & ".CFDOMAIN")
        LoadCFAUTH(Me.txtCUSTID.Text)
    End Sub
End Class