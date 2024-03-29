Imports System.IO
Imports System.Text
Imports CommonLibrary
Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports System.Collections
Imports System.Xml.XmlReader
Imports CrystalDecisions.CrystalReports.Engine
Imports DevExpress.XtraReports.UI
Imports System.Xml


Partial Public Class frmReportParameter
    Inherits System.Windows.Forms.Form

#Region " Declare constant and variables "
    Const c_ResourceManager = "AppCore.frmReportParameter-"

    Const CONTROL_TOP = 10
    Const CONTROL_LEFT = 10
    Const CONTROL_GAP = 2
    Const CONTROL_HEIGHT = 23
    Const LBLCAPTION_WIDTH = 120
    Const ALL_WIDTH = 700
    Const WIDTH_PERCHAR = 10
    Const PREFIXED_MSKDATA = "mskData"
    Const PREFIXED_LBLDESC = "lblDesc"
    Const PREFIXED_LBLCAP = "lblCaption"

    Const POS_FLDNAME = 1
    Const POS_FLDTYPE = POS_FLDNAME + 2
    Const POS_LOOKUP = POS_FLDTYPE + 1
    Const POS_SQLLIST = POS_LOOKUP + 1

    Private mv_strIsFixPara As String = "N"
    Private mv_strInitPara As String = String.Empty
    Private mv_intReturnExecuted As Integer
    Private mv_strObjectName As String
    Private mv_strModuleCode As String
    Private mv_strLanguage As String
    Private mv_ResourceManager As Resources.ResourceManager
    Public mv_arrObjFields() As CFieldMaster
    Private mv_strCustName As String
    Private mv_blnOnDisplayScreen As Boolean = True

    Private mv_strLocalObject As String
    Private mv_strBranchId As String 'Là mã chi nhánh/đại lý
    Private mv_strTellerId As String
    Private mv_strIpAddress As String
    Private mv_strWsName As String
    Private mv_strStoredname As String
    Private mv_arrRptParam() As ReportParameters    'mang tham so bao cao
    Private mv_intNumOfParam As Integer     'So luong tham so cua bao cao

    Private mv_strReportDirectory As String
    Private mv_strReportTempDirectory As String
    Private mv_strReportArea As String
    Private mv_strRptAsynchrnousFile As String

    Private mv_strHeadOffice As String          'La Ten cty
    Private mv_strRPTTITLE As String            'Là tiêu đ? c�ủa báo cáo
    Private mv_strBRNAME As String              'Là tên chi nhánh/đại lý
    Private mv_strBranchAddress As String       '?�ịa chỉ chi nhánh/đại lý
    Private mv_strBranchPhoneFax As String      'Thông tin v? s�ố điện thoại, số fax, địa chỉ email,website,....
    Private mv_strIconFileName As String = String.Empty 'Logo bao cao
    Private mv_strTELLER As String              'Là tên ngư?i s�ử dụng
    Private mv_strCreatedDate As String
    Private mv_strCreatedDate_en As String
    Private mv_strCreatedDate_VN_EN As String
    Private mv_strBusDate As String
    Private mv_strIsCareBy As String
    Private mv_strGroupCareBy As String
    Private mv_strSubRPT As String              'BC co bao gom sub-report hay ko
    Private mv_strISCMP As String              'BC co bao gom doi chieu du lieu
    Private mv_strISADHOD As String

    Private mv_dtmDATETIME As Date              'Là ngày tạo báo cáo
    Private mv_strCMDID As String
    Private mv_strIsPublic As String
    Private mv_arrLookupData() As String
    Private mv_strExportDirectory As String
    Private mv_strExcycle As String
    Private mv_strFacctno As String
    Private mv_strTacctno As String
    Private mv_strRPTID As String
    Friend WithEvents btnCMP As System.Windows.Forms.Button
    Private mv_strADHOC As String = "Y"

    Private mv_strAddressCity As String
    Private mv_strAddressCity_En As String
    Private mv_strBranchPhoneFax_En As String
    Private mv_strBranchAddress_En As String
    Private mv_strHeadOffice_En As String
    Private mv_strBRNAME_En As String
    Private mv_strCompanyCD As String
    Private mv_strCreatedDateFull_VN_EN As String
    Private mv_strCompanyShortname As String
    Private mv_strDepositID As String
    Private mv_strWebsite As String
    Private mv_Keyvalue As String
#End Region

#Region " Properties "
    Public Property IsFixPara() As String
        Get
            Return mv_strIsFixPara
        End Get
        Set(ByVal Value As String)
            mv_strIsFixPara = Value
        End Set
    End Property

    Public Property InitPara() As String
        Get
            Return mv_strInitPara
        End Get
        Set(ByVal Value As String)
            mv_strInitPara = Value
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

    Public Property ReturnExecuted() As Integer
        Get
            Return mv_intReturnExecuted
        End Get
        Set(ByVal Value As Integer)
            mv_intReturnExecuted = Value
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

    Public Property Excycle() As String
        Get
            Return mv_strExcycle
        End Get
        Set(ByVal Value As String)
            mv_strExcycle = Value
        End Set
    End Property
    Public Property IsPublic() As String
        Get
            Return mv_strIsPublic
        End Get
        Set(ByVal Value As String)
            mv_strIsPublic = Value
        End Set
    End Property
    Public Property CMDID() As String
        Get
            Return mv_strCMDID
        End Get
        Set(ByVal Value As String)
            mv_strCMDID = Value
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

    Public Property ReportTimeCreated() As Date
        Get
            Return mv_dtmDATETIME
        End Get
        Set(ByVal Value As Date)
            mv_dtmDATETIME = Value
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

    Public Property HeadOffice_En() As String
        Get
            Return mv_strHeadOffice_En
        End Get
        Set(ByVal Value As String)
            mv_strHeadOffice_En = Value
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

    Public Property BusDate() As String
        Get
            Return mv_strBusDate
        End Get
        Set(ByVal Value As String)
            mv_strBusDate = Value
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

    Public Property LocalObject() As String
        Get
            Return mv_strLocalObject
        End Get
        Set(ByVal Value As String)
            mv_strLocalObject = Value
        End Set
    End Property

    Public Property StoredName() As String
        Get
            Return mv_strStoredname
        End Get
        Set(ByVal Value As String)
            mv_strStoredname = Value
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

    Public Property ReportArea() As String
        Get
            Return mv_strReportArea
        End Get
        Set(ByVal Value As String)
            mv_strReportArea = Value
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

    Public Property DepositID() As String
        Get
            Return mv_strDepositID
        End Get
        Set(ByVal Value As String)
            mv_strDepositID = Value
        End Set
    End Property

    Public Property Website() As String
        Get
            Return mv_strWebsite
        End Get
        Set(ByVal Value As String)
            mv_strWebsite = Value
        End Set
    End Property

    Public Property IsCareBy() As String
        Get
            Return mv_strIsCareBy
        End Get
        Set(ByVal Value As String)
            mv_strIsCareBy = Value
        End Set
    End Property

    Public Property GroupCareBy() As String
        Get
            Return mv_strGroupCareBy
        End Get
        Set(ByVal Value As String)
            mv_strGroupCareBy = Value
        End Set
    End Property
    Public Property IsSubRPT() As String
        Get
            Return mv_strSubRPT
        End Get
        Set(ByVal Value As String)
            mv_strSubRPT = Value
        End Set
    End Property
    Public Property ISCMP() As String
        Get
            Return mv_strISCMP
        End Get
        Set(ByVal Value As String)
            mv_strISCMP = Value
        End Set
    End Property

    Public Property ISADHOC As String
        Get
            Return mv_strISADHOD
        End Get
        Set(ByVal Value As String)
            mv_strISADHOD = Value
        End Set
    End Property


    Public Property BranchPhoneFax_en() As String
        Get
            Return mv_strBranchPhoneFax_En
        End Get
        Set(ByVal Value As String)
            mv_strBranchPhoneFax_En = Value
        End Set
    End Property


    Public Property BranchAddress_En() As String
        Get
            Return mv_strBranchAddress_En
        End Get
        Set(ByVal Value As String)
            mv_strBranchAddress_En = Value
        End Set
    End Property

    Public Property BranchName_En() As String
        Get
            Return mv_strBRNAME_En
        End Get
        Set(ByVal Value As String)
            mv_strBRNAME_En = Value
        End Set
    End Property

    Public Property CompanyCD() As String
        Get
            Return mv_strCompanyCD
        End Get
        Set(ByVal Value As String)
            mv_strCompanyCD = Value
        End Set
    End Property

    Public Property AddressCity_En() As String
        Get
            Return mv_strAddressCity_En
        End Get
        Set(ByVal Value As String)
            mv_strAddressCity_En = Value
        End Set
    End Property

    Public Property AddressCity() As String
        Get
            Return mv_strAddressCity
        End Get
        Set(ByVal Value As String)
            mv_strAddressCity = Value
        End Set
    End Property

    Public Property CompanyShortname() As String
        Get
            Return mv_strCompanyShortname
        End Get
        Set(ByVal Value As String)
            mv_strCompanyShortname = Value
        End Set
    End Property



    Public Property CreatedDate_VN_EN() As String
        Get
            Return mv_strCreatedDateFull_VN_EN
        End Get
        Set(ByVal Value As String)
            mv_strCreatedDateFull_VN_EN = Value
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

#End Region

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Protected WithEvents lblCaption As System.Windows.Forms.Label
    Friend WithEvents pnRptParaDetail As System.Windows.Forms.Panel
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCANCEL As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblCaption = New System.Windows.Forms.Label
        Me.pnRptParaDetail = New System.Windows.Forms.Panel
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCANCEL = New System.Windows.Forms.Button
        Me.btnCMP = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.lblCaption)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(737, 50)
        Me.Panel1.TabIndex = 3
        '
        'lblCaption
        '
        Me.lblCaption.AutoSize = True
        Me.lblCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaption.Location = New System.Drawing.Point(7, 16)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(63, 13)
        Me.lblCaption.TabIndex = 0
        Me.lblCaption.Tag = "lblCaption"
        Me.lblCaption.Text = "lblCaption"
        '
        'pnRptParaDetail
        '
        Me.pnRptParaDetail.AutoScroll = True
        Me.pnRptParaDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnRptParaDetail.Location = New System.Drawing.Point(5, 56)
        Me.pnRptParaDetail.Name = "pnRptParaDetail"
        Me.pnRptParaDetail.Size = New System.Drawing.Size(727, 326)
        Me.pnRptParaDetail.TabIndex = 0
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(564, 388)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(80, 24)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Tag = "OK"
        Me.btnOK.Text = "btnOK"
        '
        'btnCANCEL
        '
        Me.btnCANCEL.Location = New System.Drawing.Point(652, 388)
        Me.btnCANCEL.Name = "btnCANCEL"
        Me.btnCANCEL.Size = New System.Drawing.Size(80, 24)
        Me.btnCANCEL.TabIndex = 2
        Me.btnCANCEL.Tag = "CANCEL"
        Me.btnCANCEL.Text = "btnCANCEL"
        '
        'btnCMP
        '
        Me.btnCMP.Location = New System.Drawing.Point(476, 388)
        Me.btnCMP.Name = "btnCMP"
        Me.btnCMP.Size = New System.Drawing.Size(80, 24)
        Me.btnCMP.TabIndex = 4
        Me.btnCMP.Tag = "CMP"
        Me.btnCMP.Text = "btnCMP"
        '
        'frmReportParameter
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(737, 418)
        Me.Controls.Add(Me.btnCMP)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCANCEL)
        Me.Controls.Add(Me.pnRptParaDetail)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReportParameter"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmReportParameter"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Other methods "
    Protected Overridable Function InitDialog()
        'Khởi tạo kích thước form và load resource
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)
        mv_blnOnDisplayScreen = True
        'Get report fomulars' value
        GetReportFormularValue()

        'Load report's parameters input fields
        If Me.ObjectName.Length > 0 Then
            LoadScreen(Me.ObjectName.ToString)
        End If
        mv_blnOnDisplayScreen = False
        If ISCMP = "Y" Then
            Me.btnCMP.Visible = True
        Else
            Me.btnCMP.Visible = False
        End If

        LoadInitPara()
    End Function

    Private Sub LoadInitPara()
        Dim v_ctrl As Control
        If Me.IsFixPara = "Y" AndAlso Me.InitPara <> String.Empty Then
            Dim v_arrPara As String() = Me.InitPara.Split("^")
            For i As Integer = 0 To v_arrPara.Length - 1
                v_ctrl = GetControlByName(v_arrPara(i).Split("|")(0))
                Me.ActiveControl = v_ctrl
                If TypeOf (v_ctrl) Is ComboBoxEx Then
                    CType(v_ctrl, ComboBoxEx).SelectedValue = v_arrPara(i).Split("|")(1)
                ElseIf TypeOf (v_ctrl) Is ComboBox Then
                    CType(v_ctrl, ComboBox).SelectedValue = v_arrPara(i).Split("|")(1)
                ElseIf TypeOf (v_ctrl) Is DateTimePicker Then
                    CType(v_ctrl, DateTimePicker).Value = CDate(v_arrPara(i).Split("|")(1))
                Else
                    v_ctrl.Text = v_arrPara(i).Split("|")(1)
                End If
                If v_arrPara(i).Split("|")(2) = "Y" Then
                    v_ctrl.Enabled = False
                End If
                mskData_Validating(v_ctrl)
                ' Change de goi ham validate
            Next
        End If
    End Sub

    Private Sub FormatNumericTextbox(ByVal pv_ctrl As TextBox)
        Try
            Dim v_strFormat As String
            Dim v_intDecimal As String
            Dim v_intIndex As Integer
            v_intIndex = CType(pv_ctrl, TextBox).Tag
            v_strFormat = mv_arrObjFields(v_intIndex).FieldFormat
            If (v_strFormat.Length > 0) Then
                If (v_strFormat.IndexOf(".") <> -1) Then
                    v_intDecimal = Mid(v_strFormat, v_strFormat.IndexOf(".") + 2).Length()
                Else
                    v_intDecimal = 0
                End If
            Else
                v_intDecimal = 0
            End If

            If IsNumeric(pv_ctrl.Text) Then
                If FormatNumber(pv_ctrl.Text, v_intDecimal) = FRound(CDbl(pv_ctrl.Text)) Then
                    pv_ctrl.Text = FormatNumber(Math.Floor(CDbl(pv_ctrl.Text)), v_intDecimal)
                Else
                    pv_ctrl.Text = FormatNumber(pv_ctrl.Text, v_intDecimal)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cboData_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Create message to inquiry object fields
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Try
            'Neu dang nap du lieu cho combo thi bo qua
            If mv_blnOnDisplayScreen = True Then Exit Sub

            Dim strFLDNAME As String, v_intIndex As Integer
            Dim v_strSQLCMD, v_strFULLDATA As String
            Dim v_nodeList As Xml.XmlNodeList
            Dim v_strDataType, v_strValue, v_strDisplay, v_strFLDNAME As String
            Dim v_strFieldValue, v_strDay, v_strMonth, v_strYear As String
            Dim v_strModule, v_strFldSource, v_strFldDesc As String
            Dim v_strFULLNAME As String
            v_strFULLNAME = ""
            Dim v_xmlDocument As New Xml.XmlDocument, ctl As Control
            Dim v_strLookupName As String, i, j, v_intNodeIndex, v_intCount As Integer

            If InStr(CType(sender, Control).Name, PREFIXED_MSKDATA) > 0 And (TypeOf (sender) Is ComboBoxEx) And Not mv_blnOnDisplayScreen Then
                v_intIndex = CType(sender, Control).Tag
                If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                    v_strFieldValue = CType(sender, ComboBoxEx).SelectedValue
                    strFLDNAME = Mid(CType(sender, Control).Name, Len(PREFIXED_MSKDATA) + 1)
                    'Tra cuu thong tin
                    If mv_arrObjFields(v_intIndex).LookUp = "Y" And InStr(Me.ActiveControl.Name, PREFIXED_MSKDATA) > 0 Then
                        v_strSQLCMD = mv_arrObjFields(v_intIndex).LookupList
                        'Lay thong tin chung ve giao dich
                        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQLCMD, "")
                        v_ws.Message(v_strObjMsg)
                        'Luu tru danh sach ket qua tra ve
                        v_strFULLDATA = v_strObjMsg
                        'Hien thi du lieu tu Lookup data
                        FillLookupData(strFLDNAME, v_strFieldValue, v_strFULLDATA)
                    End If
                End If
            End If
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_ws = Nothing
        End Try
    End Sub

    Public Sub FillLookupData(ByVal v_strFLDNAME As String, ByVal v_strVALUE As String, ByVal v_strFULLDATA As String, Optional ByVal v_strFieldKey As String = "VALUE")
        Dim v_xmlDocument As New Xml.XmlDocument, v_nodeList As Xml.XmlNodeList, ctl As Control, v_cboData As ComboBoxEx
        Dim v_strLookupName, v_strCMDSQL, v_strObjMsg As String, i, j, v_intNodeIndex, v_intCount As Integer
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Try
            v_xmlDocument.LoadXml(v_strFULLDATA)
            v_intCount = mv_arrObjFields.GetLength(0)
            If v_intCount > 0 Then
                'Xac dinh node chua du lieu
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                For i = 0 To v_nodeList.Count - 1
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            If v_strFieldKey = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) _
                                And v_strVALUE = Trim(.InnerText.ToString) Then
                                v_intNodeIndex = i
                                Exit For
                            End If
                        End With
                    Next
                Next

                'Nap du lieu cho cac control duoc khai bao LookUpName/TagField
                For i = 0 To v_intCount - 1 Step 1
                    If Not mv_arrObjFields(i) Is Nothing Then
                        If Trim(mv_arrObjFields(i).LookupName).Length > 0 Then
                            'Náº¿u cÃ³ tham sá»‘ láº¥y giÃ¡ trá»‹
                            If Mid(Trim(mv_arrObjFields(i).LookupName), 1, 2) = v_strFLDNAME Then
                                'Vá»‹ trÃ­ tá»« thá»© 3 trá»Ÿ Ä‘i lÃ  tÃªn trÆ°á»?ng
                                v_strLookupName = Mid(Trim(mv_arrObjFields(i).LookupName), 3)
                                If Not v_nodeList.Item(v_intNodeIndex) Is Nothing Then
                                    For j = 0 To v_nodeList.Item(v_intNodeIndex).ChildNodes.Count - 1
                                        With v_nodeList.Item(v_intNodeIndex).ChildNodes(j)
                                            If v_strLookupName = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) Then
                                                'Gan gia tri cho control tim duoc
                                                ctl = Me.pnRptParaDetail.Controls(mv_arrObjFields(i).ControlIndex)
                                                If mv_arrObjFields(i).ControlType = "C" Then
                                                    CType(ctl, ComboBoxEx).SelectedValue = Trim(.InnerText.ToString)
                                                Else
                                                    ctl.Text = Trim(.InnerText.ToString)
                                                End If

                                                If mv_arrObjFields(i).DataType = "N" And Len(mv_arrObjFields(i).FieldFormat) > 0 Then
                                                    FormatNumericTextbox(CType(ctl, TextBox))
                                                End If
                                            End If
                                        End With
                                    Next
                                End If
                            End If
                        ElseIf Trim(mv_arrObjFields(i).TagList).Length > 0 Then
                            If String.Compare(mv_arrObjFields(i).TagField, v_strFLDNAME) = 0 Then
                                If mv_arrObjFields(i).ControlType = "C" Then
                                    v_strCMDSQL = mv_arrObjFields(i).TagList.Replace("<$TAGFIELD>", v_strVALUE)
                                    'Lay du lieu
                                    v_cboData = CType(Me.pnRptParaDetail.Controls(mv_arrObjFields(i).ControlIndex), ComboBoxEx)
                                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCMDSQL)
                                    v_ws.Message(v_strObjMsg)
                                    mv_blnOnDisplayScreen = True    'Disable selected index change
                                    FillComboEx(v_strObjMsg, v_cboData, "", Me.UserLanguage)
                                    mv_blnOnDisplayScreen = False
                                End If
                            End If
                        End If
                    End If
                Next
            End If

        Catch ex As Exception
            Throw ex
        Finally
            v_ws = Nothing
            v_xmlDocument = Nothing
        End Try

    End Sub

    Public Overridable Sub v_cboData_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim v_strObjMsg, v_strDATAObjMsg As String
        Dim v_strSEARCHSQL, v_strSEARCHCODE, v_strRefValue, v_strFIELDCODE, v_strKeyVal, v_strKeyName, v_strNum, v_strOBJNAME As String
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Dim v_xmlATXDocument As New Xml.XmlDocument

        Dim strFLDNAME As String, v_intIndex As Integer
        Dim v_strSQLCMD, v_strFULLDATA As String
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strDataType, v_strValue, v_strDisplay, v_strFLDNAME As String
        Dim v_strFieldValue, v_strDay, v_strMonth, v_strYear As String
        Dim v_strModule, v_strFldSource, v_strFldDesc As String
        Try

            Dim v_bolCheck As Boolean = False
            If InStr(CType(sender, Control).Name, PREFIXED_MSKDATA) > 0 Then
                v_intIndex = CType(sender, Control).Tag
                If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                    If mv_arrObjFields(v_intIndex).ControlType = "C" Then
                        v_strFieldValue = CType(sender, ComboBoxEx).SelectedValue
                    Else
                        v_strFieldValue = CType(sender, Control).Text
                    End If

                    strFLDNAME = Mid(CType(sender, Control).Name, Len(PREFIXED_MSKDATA) + 1)
                    If mv_arrObjFields(v_intIndex).Mandatory = True And Len(v_strFieldValue) = 0 And InStr(Me.ActiveControl.Name, PREFIXED_MSKDATA) > 0 Then
                        MessageBox.Show(mv_ResourceManager.GetString("ERR_NULL_VALUE"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        e.Cancel = True
                        Exit Sub
                    End If

                    'Fill du lieu lookup tá»« HOST (Fill dá»¯ liá»‡u cho Refvalue vÃ  cÃ¡c control khÃ¡c)
                    If Len(mv_arrObjFields(v_intIndex).SearchCode) > 0 Then
                        Dim ctlCheck As Control
                        ctlCheck = Me.pnRptParaDetail.Controls(mv_arrObjFields(v_intIndex).ControlIndex)
                        If Not (mv_arrObjFields(v_intIndex).Mandatory = False And ctlCheck.Text.Trim.Length = 0) Then
                            'Kiem tra du lieu nhap vao co dung khong
                            v_strSEARCHCODE = mv_arrObjFields(v_intIndex).SearchCode
                            v_strKeyVal = Replace(v_strFieldValue, ".", "")
                            'Lay KeyName
                            v_strSQLCMD = "SELECT SEARCHFLD.FIELDCODE KEYNAME,SEARCH.SEARCHCMDSQL FROM SEARCHFLD,SEARCH " & ControlChars.CrLf _
                                & " WHERE SEARCH.SEARCHCODE = SEARCHFLD.SEARCHCODE " & ControlChars.CrLf _
                                & " AND SEARCHFLD.KEY ='Y' AND SEARCHFLD.SEARCHCODE ='" & v_strSEARCHCODE & "'"
                            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQLCMD)
                            v_ws.Message(v_strObjMsg)
                            v_xmlDocument.LoadXml(v_strObjMsg)
                            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                            If v_nodeList.Count > 0 Then
                                For i As Integer = 0 To v_nodeList.Count - 1
                                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                                        With v_nodeList.Item(i).ChildNodes(j)
                                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                            v_strValue = Trim(.InnerText)
                                            Select Case v_strFLDNAME
                                                Case "KEYNAME"
                                                    v_strKeyName = Trim(v_strValue)
                                                Case "SEARCHCMDSQL"
                                                    v_strSEARCHSQL = Trim(v_strValue)
                                            End Select
                                        End With
                                    Next
                                Next
                                Dim v_strClause As String
                                v_strSQLCMD = "SELECT *  FROM  (" & v_strSEARCHSQL & ") WHERE REPLACE(" & v_strKeyName & ",'.','')='" & v_strKeyVal & "'"
                                v_strSQLCMD = v_strSQLCMD.Replace("<$BRID>", HO_BRID)
                                v_strSQLCMD = v_strSQLCMD.Replace("<$HO_BRID>", HO_BRID)
                                v_strSQLCMD = v_strSQLCMD.Replace("<$BUSDATE>", Me.BusDate)
                                v_strSQLCMD = v_strSQLCMD.Replace("<$TELLERID>", Me.TellerId)
                                v_strSQLCMD = v_strSQLCMD.Replace("<$AFACCTNO>", "")
                                v_strSQLCMD = v_strSQLCMD.Replace("<$CUSTID>", "")
                                v_strSQLCMD = v_strSQLCMD.Replace("<@KEYVALUE>", "")

                                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strSQLCMD)
                                v_ws.Message(v_strObjMsg)
                                FillLookupData(strFLDNAME, v_strFieldValue, v_strObjMsg, v_strKeyName)
                                'Fill Refval
                                v_strSQLCMD = "SELECT SEARCHCMDSQL,SE.SEARCHCODE,SEFLD.FIELDCODE, SEARCHFLD.FIELDCODE KEYNAME FROM SEARCH SE,SEARCHFLD SEFLD,SEARCHFLD WHERE SE.SEARCHCODE=SEFLD.SEARCHCODE" & ControlChars.CrLf _
                                            & "AND SE.SEARCHCODE=SEARCHFLD.SEARCHCODE AND SE.SEARCHCODE='" & v_strSEARCHCODE & "' AND SEFLD.REFVALUE='Y' AND SEARCHFLD.KEY='Y'"
                                v_strSQLCMD = v_strSQLCMD.Replace("<$BRID>", HO_BRID)
                                v_strSQLCMD = v_strSQLCMD.Replace("<$HO_BRID>", HO_BRID)
                                v_strSQLCMD = v_strSQLCMD.Replace("<$BUSDATE>", Me.BusDate)
                                v_strSQLCMD = v_strSQLCMD.Replace("<$BUSDATE>", Me.BusDate)
                                v_strSQLCMD = v_strSQLCMD.Replace("<$AFACCTNO>", "")
                                v_strSQLCMD = v_strSQLCMD.Replace("<$CUSTID>", "")
                                v_strSQLCMD = v_strSQLCMD.Replace("<@KEYVALUE>", "")


                                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQLCMD, "")
                                v_ws.Message(v_strObjMsg)
                                v_xmlDocument.LoadXml(v_strObjMsg)
                                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                                If v_nodeList.Count > 0 Then
                                    For i As Integer = 0 To v_nodeList.Count - 1
                                        For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                                            With v_nodeList.Item(i).ChildNodes(j)
                                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                                v_strValue = Trim(.InnerText)
                                                Select Case v_strFLDNAME
                                                    Case "FIELDCODE"
                                                        v_strFIELDCODE = Trim(v_strValue)
                                                End Select
                                            End With
                                        Next
                                    Next
                                    v_strSQLCMD = "SELECT " & v_strFIELDCODE & " FROM  (" & v_strSEARCHSQL & ") WHERE REPLACE(" & v_strKeyName & ",'.','')='" & v_strKeyVal & "'"
                                    v_strSQLCMD = v_strSQLCMD.Replace("<$BRID>", HO_BRID)
                                    v_strSQLCMD = v_strSQLCMD.Replace("<$HO_BRID>", HO_BRID)
                                    v_strSQLCMD = v_strSQLCMD.Replace("<$BUSDATE>", Me.BusDate)
                                    v_strSQLCMD = v_strSQLCMD.Replace("<$TELLERID>", Me.TellerId)
                                    v_strSQLCMD = v_strSQLCMD.Replace("<$AFACCTNO>", "")
                                    v_strSQLCMD = v_strSQLCMD.Replace("<$CUSTID>", "")
                                    v_strSQLCMD = v_strSQLCMD.Replace("<@KEYVALUE>", "")

                                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CA_CAMAST, gc_ActionInquiry, v_strSQLCMD, "")
                                    v_ws.Message(v_strObjMsg)
                                    v_xmlDocument.LoadXml(v_strObjMsg)
                                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                                    If v_nodeList.Count > 0 Then
                                        For i As Integer = 0 To v_nodeList.Count - 1
                                            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                                                With v_nodeList.Item(i).ChildNodes(j)
                                                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                                    v_strValue = Trim(.InnerText)
                                                    Select Case v_strFLDNAME
                                                        Case v_strFIELDCODE
                                                            v_strRefValue = v_strValue
                                                    End Select
                                                End With
                                            Next
                                        Next
                                        If Len(v_strRefValue) > 0 Then
                                            'Fill Refval 
                                            Dim ctl As Control
                                            ctl = Me.pnRptParaDetail.Controls(mv_arrObjFields(v_intIndex).LabelIndex)
                                            ctl.Top = sender.Top
                                            ctl.Text = v_strRefValue
                                            ctl.Visible = True
                                            mv_strCustName = v_strRefValue
                                        End If
                                    End If
                                End If
                            End If
                        End If

                    ElseIf mv_arrObjFields(v_intIndex).LookUp = "Y" Then

                    End If
                End If
            End If
            'TramNN 13/03/2020 lấy giá trị values cho searchcode
            If v_strFieldValue = "" Or v_strFieldValue = "ALL" Then
                mv_arrObjFields(v_intIndex).FieldValue = "%"
            Else
                mv_arrObjFields(v_intIndex).FieldValue = v_strFieldValue
            End If
            'End TramNN 13/03/2020
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
            v_xmlATXDocument = Nothing
        End Try
    End Sub

    Public Function GetFieldValueByName(ByVal pv_strFLDNAME As String) As String
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "AppCore.frmReportParameter.GetFieldValueByName"
        Dim i, v_count As Integer, v_strFLDVALUE As String
        Try
            v_strFLDVALUE = String.Empty
            v_count = UBound(mv_arrObjFields)
            For i = 0 To v_count - 1
                If String.Compare(mv_arrObjFields(i).FieldName, pv_strFLDNAME) = 0 Then
                    v_strFLDVALUE = mv_arrObjFields(i).FieldValue
                    Return v_strFLDVALUE
                End If
            Next
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Function

    Private Function GetControlByName(ByVal pv_strFLDNAME As String) As Control
        Dim v_lngError As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "AppCore.frmReportParameter.GetControlValueByName"
        Dim v_ctrl As Control, v_panel As Panel, v_strFLDNAME, v_strFLDVALUE As String
        Dim i, j, v_count, v_panelIndex, v_tabIndex, v_ControlIndex As Integer
        Try
            v_strFLDVALUE = String.Empty
            v_count = UBound(mv_arrObjFields)
            For i = 0 To v_count - 1
                If String.Compare(mv_arrObjFields(i).FieldName, pv_strFLDNAME) = 0 Then
                    'Scan all field in array
                    v_ctrl = Me.pnRptParaDetail.Controls(mv_arrObjFields(i).ControlIndex)
                    Return v_ctrl
                End If
            Next
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function

    Private Sub LoadObjectFields(ByVal strObjName As String)
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strValue, v_strFLDNAME, v_strTAGFIELD, v_strTAGVALUE, v_strTAGLIST, v_strISPARAM, v_strCTLTYPE As String
        Dim v_strFieldName, v_strDefName, v_strCaption, v_strFldType, v_strFldMask, v_strFldFormat, _
            v_strLList, v_strLChk, v_strDefVal, v_strAmtExp, v_strValidTag, v_strLookUp, v_strDataType, v_strSearchCode, v_strSrModCode As String
        Dim v_intOdrNum, v_intFldLen As Integer
        Dim v_blnVisible, v_blnEnabled, v_blnMandatory As Boolean
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_ws As New BDSRptDeliveryManagement
        Dim v_prevdate As String

        Try
            'Create message to inquiry object fields

            Dim v_strSQL, v_strObjMsg As String
            If IsPublic = "Y" Then
                v_strSQL = " select * from (SELECT '" & ModuleCode & "' MODCODE,  'FCUSTODYCD' FLDNAME, '" & strObjName & "' OBJNAME,'FCUSTODYCD'DEFNAME,'Từ Số LK'CAPTION,'F Custodycd' EN_CAPTION,0 ODRNUM,'M'FLDTYPE,'cccc.cccccc' FLDMASK," _
                  & " '_' FLDFORMAT, 10 FLDLEN,'a' LLIST, null  LCHK,'ALL' DEFVAL,'Y' VISIBLE,'N' DISABLE,'Y' MANDATORY,null AMTEXP,null VALIDTAG, '' TAGFIELD, '' TAGLIST, '' TAGVALUE, '' ISPARAM, '' CTLTYPE, " _
                  & " 'N' LOOKUP,'C' DATATYPE,null INVNAME,null FLDSOURCE,null FLDDESC, null CHAINNAME,null PRINTINFO,null LOOKUPNAME,'AFMAST' SEARCHCODE ,'CF'SRMODCODE,null INVFORMAT from dual union all " _
                  & " SELECT '" & ModuleCode & "' MODCODE,  'TCUSTODYCD' FLDNAME, '" & strObjName & "' OBJNAME,'TCUSTODYCD' DEFNAME,'Đến Số LK' CAPTION,'T Custodycd' EN_CAPTION,1 ODRNUM,'M'FLDTYPE,'cccc.cccccc' FLDMASK," _
                  & " '_' FLDFORMAT, 10 FLDLEN,'a' LLIST, null LCHK,'ALL' DEFVAL,'Y' VISIBLE,'N' DISABLE,'Y' MANDATORY,null AMTEXP,null VALIDTAG, '' TAGFIELD, '' TAGLIST, '' TAGVALUE, '' ISPARAM, '' CTLTYPE, " _
                  & " 'N' LOOKUP,'C' DATATYPE,null INVNAME,null FLDSOURCE,null FLDDESC, null CHAINNAME,null PRINTINFO, null LOOKUPNAME,'AFMAST' SEARCHCODE ,'CF'SRMODCODE,null INVFORMAT from dual  union all " _
                  & "SELECT MODCODE,FLDNAME,OBJNAME,DEFNAME,TO_CHAR(CAPTION),TO_CHAR(EN_CAPTION),ODRNUM +2 , FLDTYPE, FLDMASK," _
                  & " FLDFORMAT,FLDLEN, LLIST,LCHK,DEFVAL,VISIBLE,DISABLE,MANDATORY, AMTEXP, VALIDTAG, TAGFIELD, TAGLIST, TAGVALUE, ISPARAM, CTLTYPE, " _
                  & "  LOOKUP, DATATYPE, INVNAME, FLDSOURCE, FLDDESC, CHAINNAME, PRINTINFO, LOOKUPNAME, SEARCHCODE, SRMODCODE, INVFORMAT FROM RPTFIELDS WHERE UPPER(OBJNAME) = '" & strObjName & "')dt order by dt.ODRNUM "
            Else
                v_strSQL = "SELECT * FROM RPTFIELDS WHERE UPPER(OBJNAME) = '" & strObjName & "' ORDER BY ODRNUM"
            End If
            'trung.luu:     <$PREVDATE> => get prevdate
            Dim v_strCmdSQL As String
            v_strCmdSQL = "SELECT max(sbdate)PREDATE FROM sbcldr WHERE sbdate < to_date('" & Me.BusDate & "','dd/MM/RRRR') and holiday='N' and cldrtype='000'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeRpt, , gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            Dim i1, j1 As Integer
            If v_nodeList.Count > 0 Then
                For i1 = 0 To v_nodeList.Count - 1
                    For j1 = 0 To v_nodeList.Item(i1).ChildNodes.Count - 1
                        With v_nodeList.Item(i1).ChildNodes(j1)
                            'Ghi nhận thuật toán để kiểm tra và tính toán cho từng trư?ng c�ủa giao dịch
                            v_strValue = .InnerText.ToString
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "PREDATE"
                                    v_prevdate = Trim(v_strValue)
                            End Select
                        End With
                    Next
                Next
            End If

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeRpt, , gc_ActionInquiry, v_strSQL)
            v_ws.Message(v_strObjMsg)

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            ReDim mv_arrObjFields(v_nodeList.Count)

            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
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
                            Case "SEARCHCODE"
                                v_strSearchCode = Trim(v_strValue)
                            Case "SRMODCODE"
                                v_strSrModCode = Trim(v_strValue)
                            Case "TAGFIELD"
                                v_strTAGFIELD = Trim(v_strValue)
                            Case "TAGLIST"
                                v_strTAGLIST = Trim(v_strValue)
                            Case "TAGVALUE"
                                v_strTAGVALUE = Trim(v_strValue)
                            Case "ISPARAM"
                                v_strISPARAM = Trim(v_strValue)
                            Case "CTLTYPE"
                                v_strCTLTYPE = Trim(v_strValue)
                        End Select
                    End With
                Next

                

                'T11/2015 TTBT T+2. Begin
                'HaiLT them
                If v_strDefVal.IndexOf("<$SQL>") >= 0 Then
                    'Neu la tham chieu tu cau lenh SQL
                    Dim mv_strXMLFldMasterTmp, v_strObjMsgTmp As String
                    Dim v_nodeListTmp As Xml.XmlNodeList
                    Dim v_xmlDocumentTmp As New Xml.XmlDocument
                    Dim v_strClauseTmp, v_strValueTmp, v_strFLDNAMETmp As String
                    v_strDefVal = Replace(v_strDefVal, "<$SQL>", "")
                    v_strDefVal = Replace(v_strDefVal, "<$BRID>", Me.BranchId)
                    v_strDefVal = Replace(v_strDefVal, "<$TLID>", Me.TellerId)
                    v_strDefVal = Replace(v_strDefVal, "<$BUSDATE>", Me.BusDate)

                    'Doc thong tin cac truong cua object duoc dung de hien thi
                    v_strObjMsgTmp = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeRpt, , gc_ActionInquiry, v_strDefVal, )
                    v_ws.Message(v_strObjMsgTmp)
                    'mv_strXMLFldMasterTmp = v_strObjMsgTmp
                    v_xmlDocumentTmp.LoadXml(v_strObjMsgTmp)
                    v_nodeListTmp = v_xmlDocumentTmp.SelectNodes("/ObjectMessage/ObjData")
                    'ReDim mv_arrObjFields(v_nodeListTmp.Count)
                    For l As Integer = 0 To v_nodeListTmp.Count - 1
                        For m As Integer = 0 To v_nodeListTmp.Item(l).ChildNodes.Count - 1
                            With v_nodeListTmp.Item(l).ChildNodes(m)
                                v_strValueTmp = .InnerText.ToString
                                v_strFLDNAMETmp = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)

                                Select Case Trim(v_strFLDNAMETmp)
                                    Case "DEFNAME"
                                        v_strDefVal = Trim(v_strValueTmp)
                                End Select
                            End With
                        Next
                    Next

                End If
                'End of HaiLT them

                'T11/2015 TTBT T+2. End
                'Xử lý nếu biến lấy giá trị hệ thống
                v_strDefVal = v_strDefVal.Replace("<$TLID>", Me.TellerId)
                v_strDefVal = v_strDefVal.Replace("<$BRID>", Me.BranchId)
                v_strDefVal = v_strDefVal.Replace("<$BUSDATE>", Me.BusDate)
                v_strDefVal = v_strDefVal.Replace("<$PREVDATE>", v_prevdate)

                Dim v_objField As New CFieldMaster
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
                    .DefaultValue = v_strDefVal
                    .Visible = v_blnVisible
                    .Enabled = v_blnEnabled
                    .Mandatory = v_blnMandatory
                    .AmtExp = v_strAmtExp
                    .ValidTag = v_strValidTag
                    .LookUp = v_strLookUp
                    .DataType = v_strDataType
                    .SearchCode = v_strSearchCode
                    .SrModCode = v_strSrModCode
                    .TagField = v_strTAGFIELD
                    .TagList = v_strTAGLIST
                    .TagValue = v_strTAGVALUE
                    .IsParam = v_strISPARAM
                    .ControlType = v_strCTLTYPE
                    If IsPublic = "Y" And (v_strFieldName = "CIACCTNO" OrElse UCase(v_strFieldName) = "PV_CUSTODYCD" OrElse UCase(v_strFieldName) = "CUSTODYCD" OrElse UCase(v_strFieldName) = "PV_AFACCTNO") Then
                        'Khong can nhap so hop dong
                        .Enabled = False
                        .Mandatory = False
                    End If

                End With
                mv_arrObjFields(i) = v_objField
            Next

            ReDim Preserve mv_arrObjFields(v_nodeList.Count)

            'Load dữ liệu của các trư?ng lookup ph�ục vụ cho mục đích verify 
            'và hiển thị lên formular tiêu chí tạo báo cáo
            ReDim mv_arrLookupData(v_nodeList.Count)
            For i As Integer = 0 To v_nodeList.Count - 1
                If (mv_arrObjFields(i).LookUp = "Y") And (mv_arrObjFields(i).LookupList.Length() > 0) Then
                    v_strSQL = mv_arrObjFields(i).LookupList
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeRpt, , gc_ActionInquiry, v_strSQL)
                    v_ws.Message(v_strObjMsg)
                Else
                    v_strObjMsg = String.Empty
                End If
                mv_arrLookupData(i) = v_strObjMsg
            Next
            ReDim Preserve mv_arrLookupData(v_nodeList.Count)
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Sub

    Private Sub DisplayScreen()
        Dim v_intIndex, v_intCount, v_intPosition, v_intTop, v_intLeft, v_intWidth, v_intLastTop As Int16
        Dim v_lblCaption, v_lblDesc As Label, v_cboData As ComboBox, v_mskData As FlexMaskEditBox, v_txtData As TextBox
        Dim v_strCmdSQL, v_strObjMsg, v_strTmp As String
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Try
            'Xoá màn hình cũ
            Me.pnRptParaDetail.Controls.Clear()

            'Tạo màn hình mới
            v_intCount = mv_arrObjFields.GetLength(0)
            If v_intCount > 0 Then
                v_intPosition = 0
                For v_intIndex = 0 To v_intCount - 1 Step 1
                    If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                        v_lblCaption = New Label
                        v_lblDesc = New Label
                        v_lblCaption.Visible = mv_arrObjFields(v_intIndex).Visible
                        v_lblDesc.Visible = False

                        v_intTop = CONTROL_TOP + v_intPosition * (CONTROL_HEIGHT + CONTROL_GAP)
                        v_lblCaption.Top = v_intTop
                        v_lblCaption.Left = CONTROL_LEFT
                        v_lblCaption.Width = LBLCAPTION_WIDTH
                        If mv_arrObjFields(v_intIndex).Mandatory Then
                            v_lblCaption.ForeColor = System.Drawing.Color.Red
                        Else
                            v_lblCaption.ForeColor = System.Drawing.Color.Blue
                        End If
                        v_lblCaption.Tag = mv_arrObjFields(v_intIndex).ValidTag
                        v_lblCaption.Text = mv_arrObjFields(v_intIndex).Caption
                        v_lblCaption.RightToLeft = RightToLeft.Yes
                        v_lblCaption.Name = PREFIXED_LBLCAP & Trim(mv_arrObjFields(v_intIndex).FieldName)

                        If mv_arrObjFields(v_intIndex).ControlType = "C" Then
                            'control la ComboBox
                            v_cboData = New ComboBoxEx
                            v_cboData.Visible = mv_arrObjFields(v_intIndex).Visible
                            v_cboData.Top = v_intTop
                            v_intLeft = CONTROL_LEFT + LBLCAPTION_WIDTH + CONTROL_GAP
                            v_cboData.Left = v_intLeft
                            v_intWidth = mv_arrObjFields(v_intIndex).FieldLength * WIDTH_PERCHAR
                            If ALL_WIDTH < v_intLeft + v_intWidth Then
                                v_intWidth = ALL_WIDTH - v_intLeft
                            End If
                            v_cboData.Width = v_intWidth
                            v_cboData.Tag = v_intIndex  'Luu lai chi so mang
                            v_cboData.Enabled = mv_arrObjFields(v_intIndex).Enabled
                            v_cboData.Name = PREFIXED_MSKDATA & Trim(mv_arrObjFields(v_intIndex).FieldName)
                            v_cboData.DropDownStyle = ComboBoxStyle.DropDown
                            AddHandler v_cboData.SelectedIndexChanged, AddressOf cboData_SelectedIndexChanged
                            AddHandler v_cboData.Validating, AddressOf v_cboData_Validating

                            v_lblDesc.Top = v_intTop
                            v_intLeft = v_cboData.Left + v_cboData.Width + CONTROL_GAP
                            If v_intLeft >= ALL_WIDTH Then
                                v_intWidth = 0
                            Else
                                v_intWidth = ALL_WIDTH - v_intLeft
                            End If
                            'Nap du lieu cho ComboBox
                            If mv_arrObjFields(v_intIndex).LookupList.Length > 0 Then
                                v_strCmdSQL = mv_arrObjFields(v_intIndex).LookupList
                                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                                v_ws.Message(v_strObjMsg)
                                FillComboEx(v_strObjMsg, v_cboData, "", Me.UserLanguage)
                            ElseIf mv_arrObjFields(v_intIndex).TagList.Length > 0 Then
                                v_strTmp = GetFieldValueByName(mv_arrObjFields(v_intIndex).TagField)
                                If v_strTmp.Length > 0 Then
                                    v_strCmdSQL = mv_arrObjFields(v_intIndex).TagList.Replace("<$TAGFIELD>", v_strTmp)
                                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
                                    v_ws.Message(v_strObjMsg)
                                    FillComboEx(v_strObjMsg, v_cboData, "", Me.UserLanguage)
                                End If
                            End If
                        Else
                            If Len(Trim(mv_arrObjFields(v_intIndex).InputMask)) > 0 Then
                                If mv_arrObjFields(v_intIndex).DataType <> "N" Then
                                    'Nếu có Mask và không phải trường số thì sử dụng FlexMaskedEdit
                                    v_mskData = New FlexMaskEditBox
                                    v_mskData.Visible = mv_arrObjFields(v_intIndex).Visible
                                    v_mskData.Top = v_intTop
                                    v_intLeft = CONTROL_LEFT + LBLCAPTION_WIDTH + CONTROL_GAP
                                    v_mskData.Left = v_intLeft
                                    v_intWidth = mv_arrObjFields(v_intIndex).FieldLength * WIDTH_PERCHAR
                                    If ALL_WIDTH < v_intLeft + v_intWidth Then
                                        v_intWidth = ALL_WIDTH - v_intLeft
                                    End If
                                    v_mskData.Width = v_intWidth
                                    v_mskData.Tag = v_intIndex  'Lưu lại chỉ số của mảng để lấy các thông tin tương ứng đến trư?ng
                                    v_mskData.PromptChar = "_"

                                    If Trim(mv_arrObjFields(v_intIndex).DataType) = "N" Then
                                        v_mskData.MaskCharInclude = False
                                        v_mskData.FieldType = FlexMaskEditBox._FieldType.NUMERIC
                                    ElseIf Trim(mv_arrObjFields(v_intIndex).DataType) = "C" Then
                                        v_mskData.MaskCharInclude = False
                                        v_mskData.FieldType = FlexMaskEditBox._FieldType.ALFA
                                    Else
                                        v_mskData.MaskCharInclude = True
                                        v_mskData.FieldType = FlexMaskEditBox._FieldType.DATE_
                                    End If
                                    v_mskData.Mask = mv_arrObjFields(v_intIndex).InputMask
                                    v_mskData.MaxLength = mv_arrObjFields(v_intIndex).FieldLength
                                    v_mskData.Enabled = mv_arrObjFields(v_intIndex).Enabled
                                    v_mskData.Name = PREFIXED_MSKDATA & Trim(mv_arrObjFields(v_intIndex).FieldName)
                                    If Len(mv_arrObjFields(v_intIndex).SearchCode) > 0 Then
                                        v_mskData.BackColor = System.Drawing.Color.GreenYellow
                                    ElseIf Len(mv_arrObjFields(v_intIndex).LookupList) > 0 Then
                                        v_mskData.BackColor = System.Drawing.Color.Khaki
                                    End If

                                    If Len(Trim(mv_arrObjFields(v_intIndex).FieldValue)) > 0 Then
                                        v_mskData.Text = Trim(mv_arrObjFields(v_intIndex).FieldValue)
                                    Else
                                        If Trim(mv_arrObjFields(v_intIndex).DefaultValue) = "<$BUSDATE>" Then
                                            v_mskData.Text = Me.BusDate
                                        ElseIf Trim(mv_arrObjFields(v_intIndex).DefaultValue) = "<$TELLERID>" Then
                                            v_mskData.Text = Me.TellerId
                                        Else
                                            v_mskData.Text = Trim(mv_arrObjFields(v_intIndex).DefaultValue)
                                        End If
                                    End If
                                    AddHandler v_mskData.GotFocus, AddressOf mskData_GotFocus
                                    AddHandler v_mskData.Validating, AddressOf mskData_Validating

                                    v_lblDesc.Top = v_intTop
                                    v_intLeft = v_mskData.Left + v_mskData.Width + CONTROL_GAP
                                    If v_intLeft >= ALL_WIDTH Then
                                        v_intWidth = 0
                                    Else
                                        v_intWidth = ALL_WIDTH - v_intLeft
                                    End If
                                Else
                                    'Nếu có Mask và ko phải trường số thì sử dụng Textbox thông thường
                                    v_txtData = New TextBox
                                    v_txtData.Visible = mv_arrObjFields(v_intIndex).Visible
                                    v_txtData.Top = v_intTop
                                    v_intLeft = CONTROL_LEFT + LBLCAPTION_WIDTH + CONTROL_GAP
                                    v_txtData.Left = v_intLeft
                                    v_intWidth = mv_arrObjFields(v_intIndex).FieldLength * WIDTH_PERCHAR
                                    If ALL_WIDTH < v_intLeft + v_intWidth Then
                                        v_intWidth = ALL_WIDTH - v_intLeft
                                    End If
                                    v_txtData.Width = v_intWidth
                                    v_txtData.Tag = v_intIndex  'Lưu lại chỉ số của mảng để lấy các thông tin tương ứng đến trường
                                    v_txtData.Enabled = mv_arrObjFields(v_intIndex).Enabled
                                    v_txtData.Name = PREFIXED_MSKDATA & Trim(mv_arrObjFields(v_intIndex).FieldName)
                                    If Len(mv_arrObjFields(v_intIndex).LookupList) > 0 Then
                                        v_txtData.BackColor = System.Drawing.Color.Khaki
                                    End If
                                    If Len(Trim(mv_arrObjFields(v_intIndex).FieldValue)) > 0 Then
                                        v_txtData.Text = Trim(mv_arrObjFields(v_intIndex).FieldValue)
                                    Else
                                        v_txtData.Text = Trim(mv_arrObjFields(v_intIndex).DefaultValue)
                                    End If
                                    AddHandler v_txtData.GotFocus, AddressOf mskData_GotFocus
                                    AddHandler v_txtData.Validating, AddressOf mskData_Validating

                                    v_lblDesc.Top = v_intTop
                                    v_intLeft = v_txtData.Left + v_txtData.Width + CONTROL_GAP
                                    If v_intLeft >= ALL_WIDTH Then
                                        v_intWidth = 0
                                    Else
                                        v_intWidth = ALL_WIDTH - v_intLeft
                                    End If
                                End If

                            Else
                                'Nếu không có Masked thì sử dụng Textbox thông thường
                                v_txtData = New TextBox
                                v_txtData.Visible = mv_arrObjFields(v_intIndex).Visible
                                v_txtData.Top = v_intTop
                                v_intLeft = CONTROL_LEFT + LBLCAPTION_WIDTH + CONTROL_GAP
                                v_txtData.Left = v_intLeft
                                v_intWidth = mv_arrObjFields(v_intIndex).FieldLength * WIDTH_PERCHAR
                                If ALL_WIDTH < v_intLeft + v_intWidth Then
                                    v_intWidth = ALL_WIDTH - v_intLeft
                                End If
                                v_txtData.Width = v_intWidth
                                v_txtData.Tag = v_intIndex  'L�ưu lại chỉ số của mảng để lấy các thông tin tương ứng đến trư?ng
                                v_txtData.Enabled = mv_arrObjFields(v_intIndex).Enabled
                                v_txtData.Name = PREFIXED_MSKDATA & Trim(mv_arrObjFields(v_intIndex).FieldName)

                                If Len(mv_arrObjFields(v_intIndex).SearchCode) > 0 Then
                                    v_txtData.BackColor = System.Drawing.Color.GreenYellow
                                ElseIf Len(mv_arrObjFields(v_intIndex).LookupList) > 0 Then
                                    v_txtData.BackColor = System.Drawing.Color.Khaki
                                End If

                                If Len(Trim(mv_arrObjFields(v_intIndex).FieldValue)) > 0 Then
                                    v_txtData.Text = Trim(mv_arrObjFields(v_intIndex).FieldValue)
                                Else
                                    v_txtData.Text = Trim(mv_arrObjFields(v_intIndex).DefaultValue)
                                End If
                                AddHandler v_txtData.GotFocus, AddressOf mskData_GotFocus
                                AddHandler v_txtData.Validating, AddressOf mskData_Validating
                                v_lblDesc.Top = v_intTop
                                v_intLeft = v_txtData.Left + v_txtData.Width + CONTROL_GAP
                                If v_intLeft >= ALL_WIDTH Then
                                    v_intWidth = 0
                                Else
                                    v_intWidth = ALL_WIDTH - v_intLeft
                                End If
                            End If
                        End If

                        v_lblDesc.Tag = mv_arrObjFields(v_intIndex).LookupCheck
                        v_lblDesc.Left = v_intLeft
                        v_lblDesc.Width = v_intWidth
                        v_lblDesc.Text = ""
                        v_lblDesc.Name = PREFIXED_LBLDESC & Trim(mv_arrObjFields(v_intIndex).FieldName)

                        Me.pnRptParaDetail.Controls.Add(v_lblCaption)
                        If mv_arrObjFields(v_intIndex).ControlType = "C" Then
                            Me.pnRptParaDetail.Controls.Add(v_cboData)
                            'T07/2017 STP
                            If mv_arrObjFields(v_intIndex).DefaultValue.Trim.Length > 0 Then
                                v_cboData.SelectedValue = mv_arrObjFields(v_intIndex).DefaultValue
                            End If
                            'End T07/2017 STP
                        ElseIf Len(Trim(mv_arrObjFields(v_intIndex).InputMask)) > 0 And mv_arrObjFields(v_intIndex).DataType <> "N" Then
                            Me.pnRptParaDetail.Controls.Add(v_mskData)
                        Else
                            Me.pnRptParaDetail.Controls.Add(v_txtData)
                        End If
                        Me.pnRptParaDetail.Controls.Add(v_lblDesc)

                        'Lấy Control Index
                        If mv_arrObjFields(v_intIndex).ControlType = "C" Then
                            mv_arrObjFields(v_intIndex).ControlIndex = Me.pnRptParaDetail.Controls.IndexOf(v_cboData)
                        ElseIf Len(Trim(mv_arrObjFields(v_intIndex).InputMask)) > 0 And mv_arrObjFields(v_intIndex).DataType <> "N" Then
                            mv_arrObjFields(v_intIndex).ControlIndex = Me.pnRptParaDetail.Controls.IndexOf(v_mskData)
                        Else
                            mv_arrObjFields(v_intIndex).ControlIndex = Me.pnRptParaDetail.Controls.IndexOf(v_txtData)
                        End If
                        mv_arrObjFields(v_intIndex).LabelIndex = Me.pnRptParaDetail.Controls.IndexOf(v_lblDesc)

                        'Tính toán vị trí hiển thị nếu control là visible
                        If mv_arrObjFields(v_intIndex).Visible Then
                            v_intPosition = v_intPosition + 1
                            v_intLastTop = v_intTop
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_ws = Nothing
        End Try
    End Sub

    Private Sub LoadScreen(ByVal pv_strObjName As String)
        'Lấy tham số về báo cáo
        LoadObjectFields(pv_strObjName)

        'Hiển thị thông tin giao dịch lên màn hình
        DisplayScreen()
    End Sub

    Private Const colPictureName As String = "ReportIcon"
    Private Function getIconDirectory() As String
        Return ReportDirectory & mv_strIconFileName
    End Function
    Private Sub addIconColumn(ByRef pv_ds As DataSet)
        Try
            If Not pv_ds Is Nothing Then
                If Not mv_strIconFileName = String.Empty And File.Exists(getIconDirectory) Then
                    Dim v_iconTable As New DataTable(colPictureName)
                    v_iconTable.Columns.Add(colPictureName, GetType(System.Byte()))
                    v_iconTable.Rows.Add()

                    Dim fs As New FileStream(getIconDirectory, FileMode.Open)
                    Dim br As New BinaryReader(fs)
                    Dim imgbyte(fs.Length + 1) As Byte
                    imgbyte = br.ReadBytes(Convert.ToInt32((fs.Length)))
                    v_iconTable.Rows(0)(colPictureName) = imgbyte
                    br.Close()
                    fs.Close()

                    pv_ds.Tables.Add(v_iconTable)
                    'pv_ds.Tables(0).Columns.Add(colPictureName, GetType(System.Byte()))
                End If
                'If pv_ds.Tables(0).Rows.Count > 0 AndAlso pv_ds.Tables.Count > 0 Then
                '    addIconColumnValue(pv_ds)
                'End If

            End If
        Catch ex As Exception
            LogError.Write("ErrorSource: addCoumnPicture " & vbNewLine _
                           & "ErrorMessage: " & ex.ToString, EventLogEntryType.Error)
        End Try
    End Sub
    Private Sub addIconColumnValue(ByRef pv_ds As DataSet)
        Try
            If File.Exists(getIconDirectory) Then
                Dim fs As New FileStream(getIconDirectory, FileMode.Open)
                Dim br As New BinaryReader(fs)
                Dim imgbyte(fs.Length + 1) As Byte
                imgbyte = br.ReadBytes(Convert.ToInt32((fs.Length)))
                pv_ds.Tables(0).Rows(0)(colPictureName) = imgbyte
                br.Close()
                fs.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Function CreateReport(ByVal v_ds As DataSet, ByVal v_strAFACCTNO As String) As Boolean
        Try
            Dim v_rptDocument As New ReportDocument
            Dim v_strRptFilePath As String = GetRptTemplateFilePath(CMDID)
            Dim v_blnFileExists As Boolean = False

            'Modifier: Thanh.tran: check KH la nguoi nuoc ngoai hay trong nuoc
            Dim v_blnVietnamese As Boolean
            Dim v_strDValue As String
            Dim v_strMValue As String
            Dim v_strYValue As String
            Dim v_strTemp As String
            Dim d As New Date, i As Integer
            'Thanh.Tran end.

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
                v_ds.WriteXml(ReportDirectory & CMDID & ".xml", XmlWriteMode.WriteSchema)
                MessageBox.Show(mv_ResourceManager.GetString("frmReportParameter.FileNotExists"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If


            'Load the report, fill formulars and save it to disk
            v_rptDocument.Load(ReportDirectory & v_strRptFilePath, CrystalDecisions.Shared.OpenReportMethod.OpenReportByTempCopy)
            If Not v_ds Is Nothing Then
                If v_ds.Tables.Count = 0 Then
                    MessageBox.Show(mv_ResourceManager.GetString("frmReportParameter.Nodata"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
                '  Check if nodata  is exists
                Dim v_hasData As Boolean = True
                For Each v_dt As DataTable In v_ds.Tables
                    If v_dt.Rows.Count = 0 And v_dt.TableName <> colPictureName Then
                        v_hasData = False
                        Exit For
                    End If
                Next
                If Not v_hasData Then
                    MessageBox.Show(mv_ResourceManager.GetString("frmReportParameter.Nodata"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
                'If v_ds.Tables(0).Rows.Count = 0 Then
                '    MessageBox.Show(mv_ResourceManager.GetString("frmReportParameter.Nodata"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    Return False
                'End If

                'Modifier: Thanh.tran: check KH la nguoi nuoc ngoai hay trong nuoc
                If (CMDID = "CF0095") Or (CMDID = "CF0015") Or (CMDID = "SE0006") Then
                    If v_ds.Tables(0).Rows(0)("LG") = "C" Then
                        v_blnVietnamese = True
                        v_ExDirectoy = ExportDirectory & "VN\"
                    ElseIf v_ds.Tables(0).Rows(0)("LG") = "F" Then
                        v_blnVietnamese = False
                        v_ExDirectoy = ExportDirectory & "NN\"

                        v_strTemp = CreatedDate_En
                        d = CType(v_strTemp, Date)
                        CreatedDate = d.ToLongDateString
                    Else
                        v_blnVietnamese = True
                        v_ExDirectoy = ExportDirectory & "OTC\"
                    End If
                Else
                    v_ExDirectoy = ExportDirectory
                End If
                'Thanh.Tran end.

                v_rptDocument.SetDataSource(v_ds)
            End If

            Dim v_crFFieldDefinitions As FormulaFieldDefinitions
            Dim v_crFFieldDefinition As FormulaFieldDefinition
            Dim v_strFormulaName, v_strFormulaValue As String
            v_crFFieldDefinitions = v_rptDocument.DataDefinition.FormulaFields()
            For i = 0 To v_crFFieldDefinitions.Count - 1
                v_crFFieldDefinition = v_crFFieldDefinitions.Item(i)
                v_strFormulaName = v_crFFieldDefinition.Name

                Select Case v_strFormulaName.ToUpper()
                    Case gc_RPT_FORMULAR_HEADOFFICE
                        v_crFFieldDefinition.Text = "'" & HeadOffice & "'"
                    Case gc_RPT_FORMULAR_HEADOFFICE_EN
                        v_crFFieldDefinition.Text = "'" & HeadOffice_En & "'"
                    Case gc_RPT_FORMULAR_COMPANY_NAME
                        v_crFFieldDefinition.Text = "'" & BranchName & "'"
                    Case gc_RPT_FORMULAR_COMPANY_NAME_EN
                        v_crFFieldDefinition.Text = "'" & BranchName_En & "'"
                    Case gc_RPT_FORMULAR_ADDRESS
                        v_crFFieldDefinition.Text = "'" & BranchAddress & "'"
                    Case gc_RPT_FORMULAR_ADDRESS_EN
                        v_crFFieldDefinition.Text = "'" & BranchAddress_En & "'"
                    Case gc_RPT_FORMULAR_PHONE_FAX
                        v_crFFieldDefinition.Text = "'" & BranchPhoneFax & "'"
                    Case gc_RPT_FORMULAR_PHONE_FAX_EN
                        v_crFFieldDefinition.Text = "'" & BranchPhoneFax_en & "'"
                    Case gc_RPT_FORMULAR_REPORT_TITLE
                        v_crFFieldDefinition.Text = "'" & ReportTitle & "'"
                    Case gc_RPT_FORMULAR_CREATED_DATE
                        v_crFFieldDefinition.Text = "'" & CreatedDate & "'"
                    Case gc_RPT_FORMULAR_CREATED_DATE_EN
                        v_crFFieldDefinition.Text = "'" & CreatedDate_En & "'"
                    Case gc_RPT_FORMULAR_CREATED_DATE_VN_EN
                        v_crFFieldDefinition.Text = "'" & CreatedDate_VN_EN & "'"
                    Case gc_RPT_FORMULAR_COMPANYCD
                        v_crFFieldDefinition.Text = "'" & CompanyCD & "'"
                    Case gc_RPT_FORMULAR_COMPANY_SHORTNAME
                        v_crFFieldDefinition.Text = "'" & CompanyShortname & "'"
                    Case gc_RPT_FORMULAR_CITYADDRESS
                        v_crFFieldDefinition.Text = "'" & AddressCity & "'"
                    Case gc_RPT_FORMULAR_CITYADDRESS_EN
                        v_crFFieldDefinition.Text = "'" & AddressCity_En & "'"
                    Case gc_RPT_FORMULAR_CREATED_BY
                        v_crFFieldDefinition.Text = "'" & Teller & "'"
                    Case gc_RPT_FORMULAR_REPORT_CMDID
                        v_crFFieldDefinition.Text = "'" & CMDID & "'"
                    Case gc_RPT_FORMULAR_DEPOSITID
                        v_crFFieldDefinition.Text = "'" & DepositID & "'"
                    Case gc_RPT_FORMULAR_FROM_DATE
                        For j As Integer = 0 To mv_intNumOfParam - 1
                            If (mv_arrObjFields(j).FieldName = "F_DATE") Then
                                v_crFFieldDefinition.Text = "'" & mv_arrRptParam(j + IIf(IsPublic = "Y", 0, 2)).ParamValue & "'"
                                Exit For
                            End If
                        Next
                    Case gc_RPT_FORMULAR_TO_DATE
                        For j As Integer = 0 To mv_intNumOfParam - 1
                            If (mv_arrObjFields(j).FieldName = "T_DATE") Then
                                v_crFFieldDefinition.Text = "'" & mv_arrRptParam(j + IIf(IsPublic = "Y", 0, 2)).ParamValue & "'"
                                Exit For
                            End If
                        Next
                    Case gc_RPT_FORMULAR_REPORT_CRITERIAS
                        Dim v_strCriterias As String = String.Empty

                        v_strCriterias &= mv_arrRptParam(0).ParamCaption & ": " & mv_arrRptParam(0).ParamDescription
                        If (ReportArea <> gc_REPORT_AREA_ALL) Then
                            v_strCriterias &= "|" & mv_arrRptParam(1).ParamCaption & ": " & mv_arrRptParam(1).ParamDescription
                        End If

                        For j As Integer = 2 To mv_arrRptParam.Length - 1
                            If (mv_arrRptParam(j).ParamName <> "F_DATE") And (mv_arrRptParam(j).ParamName <> "T_DATE") Then
                                If (mv_arrRptParam(j).ParamName.Length() > 0) And (mv_arrRptParam(j).ParamDescription.Length > 0) Then
                                    v_strCriterias &= "|" & mv_arrRptParam(j).ParamCaption & ": " & mv_arrRptParam(j).ParamDescription
                                End If
                            End If
                        Next

                        v_crFFieldDefinition.Text = "'" & v_strCriterias & "'"
                End Select
            Next

            'The dataset is returned TRUE value when asynchronous mode
            If v_ds Is Nothing Then
                'Store v_rptDocument to the file
                'Delete old data
                Dim v_strFile As String = ReportTempDirectory & GetRptTempFilePath(CMDID)
                File.Delete(v_strFile)

                'Ghi ra file voi trang thai PENDING
                Dim v_strXMLBuilder As New StringBuilder
                v_crFFieldDefinitions = v_rptDocument.DataDefinition.FormulaFields()
                If v_crFFieldDefinitions.Count > 0 Then
                    v_strXMLBuilder.Append("<formula ")
                    For i = 0 To v_crFFieldDefinitions.Count - 1
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
                    If IsPublic = "Y" Then
                        'Export to PDF
                        v_rptDocument.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, v_ExDirectoy & GetBatchRptTempFilePath(CMDID, v_strAFACCTNO))
                    Else
                        'Export to Crystal report
                        v_rptDocument.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.CrystalReport, ReportTempDirectory & GetRptTempFilePath(CMDID))
                    End If
                End If
            End If
            Return True
        Catch ex As Exception

            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    Private Function CreateReport(ByVal v_ds As DataSet, ByVal v_strAFACCTNO As String, ByVal v_strCUSTODYCD As String) As Boolean
        Try
            Dim v_rptDocument As New ReportDocument
            Dim v_strRptFilePath As String = GetRptTemplateFilePath(CMDID)
            Dim v_blnFileExists As Boolean = False

            'Modifier: Thanh.tran: check KH la nguoi nuoc ngoai hay trong nuoc
            Dim v_blnVietnamese As Boolean
            Dim v_strDValue As String
            Dim v_strMValue As String
            Dim v_strYValue As String
            Dim v_strTemp As String
            Dim d As New Date, i As Integer
            'Thanh.Tran end.

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
                v_ds.WriteXml(ReportDirectory & CMDID & ".xml", XmlWriteMode.WriteSchema)
                MessageBox.Show(mv_ResourceManager.GetString("frmReportParameter.FileNotExists"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If


            'Load the report, fill formulars and save it to disk
            v_rptDocument.Load(ReportDirectory & v_strRptFilePath, CrystalDecisions.Shared.OpenReportMethod.OpenReportByTempCopy)
            If Not v_ds Is Nothing Then
                '  Check if nodata  is exists
                If v_ds.Tables(0).Rows.Count = 0 Then
                    MessageBox.Show(mv_ResourceManager.GetString("frmReportParameter.Nodata"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If

                'Modifier: Thanh.tran: check KH la nguoi nuoc ngoai hay trong nuoc
                If (CMDID = "CF0095") Or (CMDID = "CF0015") Or (CMDID = "SE0006") Then
                    If v_ds.Tables(0).Rows(0)("LG") = "C" Then
                        v_blnVietnamese = True
                        v_ExDirectoy = ExportDirectory & "VN\"
                    ElseIf v_ds.Tables(0).Rows(0)("LG") = "F" Then
                        v_blnVietnamese = False
                        v_ExDirectoy = ExportDirectory & "NN\"

                        v_strTemp = CreatedDate_En
                        d = CType(v_strTemp, Date)
                        CreatedDate = d.ToLongDateString
                    Else
                        v_blnVietnamese = True
                        v_ExDirectoy = ExportDirectory & "OTC\"
                    End If
                Else
                    v_ExDirectoy = ExportDirectory
                End If
                'Thanh.Tran end.

                v_rptDocument.SetDataSource(v_ds)
            End If

            Dim v_crFFieldDefinitions As FormulaFieldDefinitions
            Dim v_crFFieldDefinition As FormulaFieldDefinition
            Dim v_strFormulaName, v_strFormulaValue As String
            v_crFFieldDefinitions = v_rptDocument.DataDefinition.FormulaFields()

            For i = 0 To v_crFFieldDefinitions.Count - 1
                v_crFFieldDefinition = v_crFFieldDefinitions.Item(i)
                v_strFormulaName = v_crFFieldDefinition.Name

                Select Case v_strFormulaName.ToUpper()
                    Case gc_RPT_FORMULAR_HEADOFFICE
                        v_crFFieldDefinition.Text = "'" & HeadOffice & "'"
                    Case gc_RPT_FORMULAR_HEADOFFICE_EN
                        v_crFFieldDefinition.Text = "'" & HeadOffice_En & "'"
                    Case gc_RPT_FORMULAR_COMPANY_NAME
                        v_crFFieldDefinition.Text = "'" & BranchName & "'"
                    Case gc_RPT_FORMULAR_COMPANY_NAME_EN
                        v_crFFieldDefinition.Text = "'" & BranchName_En & "'"
                    Case gc_RPT_FORMULAR_ADDRESS
                        v_crFFieldDefinition.Text = "'" & BranchAddress & "'"
                    Case gc_RPT_FORMULAR_ADDRESS_EN
                        v_crFFieldDefinition.Text = "'" & BranchAddress_En & "'"
                    Case gc_RPT_FORMULAR_PHONE_FAX
                        v_crFFieldDefinition.Text = "'" & BranchPhoneFax & "'"
                    Case gc_RPT_FORMULAR_PHONE_FAX_EN
                        v_crFFieldDefinition.Text = "'" & BranchPhoneFax_en & "'"
                    Case gc_RPT_FORMULAR_REPORT_TITLE
                        v_crFFieldDefinition.Text = "'" & ReportTitle & "'"
                    Case gc_RPT_FORMULAR_CREATED_DATE
                        v_crFFieldDefinition.Text = "'" & CreatedDate & "'"
                    Case gc_RPT_FORMULAR_CREATED_DATE_EN
                        v_crFFieldDefinition.Text = "'" & CreatedDate_En & "'"
                    Case gc_RPT_FORMULAR_CREATED_DATE_VN_EN
                        v_crFFieldDefinition.Text = "'" & CreatedDate_VN_EN & "'"
                    Case gc_RPT_FORMULAR_COMPANYCD
                        v_crFFieldDefinition.Text = "'" & CompanyCD & "'"
                    Case gc_RPT_FORMULAR_COMPANY_SHORTNAME
                        v_crFFieldDefinition.Text = "'" & CompanyShortname & "'"
                    Case gc_RPT_FORMULAR_CITYADDRESS
                        v_crFFieldDefinition.Text = "'" & AddressCity & "'"
                    Case gc_RPT_FORMULAR_CITYADDRESS_EN
                        v_crFFieldDefinition.Text = "'" & AddressCity_En & "'"
                    Case gc_RPT_FORMULAR_CREATED_BY
                        v_crFFieldDefinition.Text = "'" & Teller & "'"
                    Case gc_RPT_FORMULAR_REPORT_CMDID
                        v_crFFieldDefinition.Text = "'" & CMDID & "'"
                    Case gc_RPT_FORMULAR_FROM_DATE
                        For j As Integer = 0 To mv_intNumOfParam - 1
                            If (mv_arrObjFields(j).FieldName = "F_DATE") Then
                                v_crFFieldDefinition.Text = "'" & mv_arrRptParam(j + IIf(IsPublic = "Y", 0, 2)).ParamValue & "'"
                                Exit For
                            End If
                        Next
                    Case gc_RPT_FORMULAR_TO_DATE
                        For j As Integer = 0 To mv_intNumOfParam - 1
                            If (mv_arrObjFields(j).FieldName = "T_DATE") Then
                                v_crFFieldDefinition.Text = "'" & mv_arrRptParam(j + IIf(IsPublic = "Y", 0, 2)).ParamValue & "'"
                                Exit For
                            End If
                        Next
                    Case gc_RPT_FORMULAR_REPORT_CRITERIAS
                        Dim v_strCriterias As String = String.Empty

                        v_strCriterias &= mv_arrRptParam(0).ParamCaption & ": " & mv_arrRptParam(0).ParamDescription
                        If (ReportArea <> gc_REPORT_AREA_ALL) Then
                            'v_strCriterias &= "|" & mv_arrRptParam(1).ParamCaption & ": " & mv_arrRptParam(1).ParamDescription
                            v_strCriterias &= mv_arrRptParam(1).ParamCaption & ": " & mv_arrRptParam(1).ParamDescription
                        End If

                        For j As Integer = 2 To mv_arrRptParam.Length - 1
                            If (mv_arrRptParam(j).ParamName <> "F_DATE") And (mv_arrRptParam(j).ParamName <> "T_DATE") Then
                                If (mv_arrRptParam(j).ParamName.Length() > 0) And (mv_arrRptParam(j).ParamDescription.Length > 0) Then
                                    v_strCriterias &= "|" & mv_arrRptParam(j).ParamCaption & ": " & mv_arrRptParam(j).ParamDescription
                                End If
                            End If
                        Next

                        v_crFFieldDefinition.Text = "'" & v_strCriterias & "'"
                End Select
            Next

            'The dataset is returned TRUE value when asynchronous mode
            If v_ds Is Nothing Then
                'Store v_rptDocument to the file
                'Delete old data
                Dim v_strFile As String = ReportTempDirectory & GetRptTempFilePath(CMDID)
                File.Delete(v_strFile)

                'Ghi ra file voi trang thai PENDING
                Dim v_strXMLBuilder As New StringBuilder
                v_crFFieldDefinitions = v_rptDocument.DataDefinition.FormulaFields()
                If v_crFFieldDefinitions.Count > 0 Then
                    v_strXMLBuilder.Append("<formula ")
                    For i = 0 To v_crFFieldDefinitions.Count - 1
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
                    If IsPublic = "Y" Then
                        'Export to PDF
                        v_rptDocument.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, v_ExDirectoy & GetBatchRptTempFilePath(CMDID, v_strAFACCTNO, v_strCUSTODYCD))
                    Else
                        'Export to Crystal report
                        v_rptDocument.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.CrystalReport, ReportTempDirectory & GetRptTempFilePath(CMDID))
                    End If
                End If
            End If
            v_rptDocument.Dispose()
            Return True
        Catch ex As Exception

            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    Public Overridable Sub OnView(Optional ByVal Row As String = "")
        'Try
        'TruongLD Add 14/09/2011
        'Neu dung Culture la "vi-VN" --> khong su dung duoc func Convert Number to Text --> Chuyen ve "en-US"
        'Chuyen doi cau hinh User Account Windows theo cau hinh cua Office
        Dim v_strOldCultureName As String = String.Empty
        v_strOldCultureName = SetCultureInfo("en-US")
        'End TruongLD
        Try
            If String.Compare(ISADHOC, "Y") = 0 Then
                'Báo cáo dưới dạng Crystal Report: Adhoc template theo mẫu
                ReportTimeCreated = GetReportDateCreated(GetReportFileName(CMDID))
                If ReportTimeCreated.Year > 1 Then
                    Dim v_frm As New frmReportView
                    Dim v_Path As String = Environment.CurrentDirectory
                    v_frm.RptFileName = ReportTempDirectory & GetReportFileName(CMDID)
                    v_frm.RptName = CMDID
                    v_frm.ShowDialog()
                    Environment.CurrentDirectory = v_Path
                Else
                    MessageBox.Show(mv_ResourceManager.GetString("frmReportParameter.ReportNotCreated"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                'Dieu kien hien thi loai bao cao
                Dim xtraReport As XtraReport = New XtraReport()
                xtraReport.PrintingSystem.LoadDocument(ReportTempDirectory & CMDID & TellerId & ".prnx")
                xtraReport.ShowPreviewMarginLines = False
                xtraReport.DisplayName = CMDID
                xtraReport.ShowPreview()
            End If

            'old
            'If String.Compare(mv_strADHOC, "Y") = 0 Then
            '    'Báo cáo dưới dạng Crystal Report: Adhoc template theo mẫu
            '    ReportTimeCreated = GetReportDateCreated(GetReportFileName(CMDID))
            '    If ReportTimeCreated.Year > 1 Then
            '        Dim v_frm As New frmReportView
            '        Dim v_Path As String = Environment.CurrentDirectory
            '        v_frm.RptFileName = ReportTempDirectory & GetReportFileName(CMDID)
            '        v_frm.RptName = CMDID
            '        v_frm.ShowDialog()
            '        Environment.CurrentDirectory = v_Path
            '    Else
            '        MessageBox.Show(mv_ResourceManager.GetString("frmReportParameter.ReportNotCreated"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    End If
            'Else
            '    'Báo cáo dưới dạng DevExpress Report
            '    ReportTimeCreated = GetReportDateCreated(GetReportFileNameStandard(CMDID))
            '    If ReportTimeCreated.Year > 1 Then
            '        Dim v_rptDocument As New BasedXtraReport
            '        v_rptDocument.PrintingSystem.LoadDocument(ReportTempDirectory & GetReportFileNameStandard(CMDID))
            '        v_rptDocument.ShowPreview()
            '    Else
            '        MessageBox.Show(mv_ResourceManager.GetString("frmReportParameter.ReportNotCreated"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    End If
            'End If

            'TruongLD Add 14/09/2011
            'Tra lai cau hinh User Account Windows theo mac dinh cua chuong trinh
            'v_strOldCultureName = SetCultureInfo(v_strOldCultureName)
            'End TruongLD

            'Me.Close()
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_strOldCultureName = SetCultureInfo(v_strOldCultureName)
        End Try
    End Sub

    Private Function GetReportFileName(ByVal pv_strCMDID As String) As String
        Return pv_strCMDID & TellerId & ".rpt"
    End Function

    Private Function GetReportFileNameStandard(ByVal pv_strCMDID As String) As String
        Return pv_strCMDID & TellerId & ".prnx"
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

    Private Sub LoadResource(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control

        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is Label Then
                CType(v_ctrl, Label).Text = mv_ResourceManager.GetString("frmReportParameter." & v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString("frmReportParameter." & v_ctrl.Name)
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Panel Then
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Button Then
                CType(v_ctrl, Button).Text = mv_ResourceManager.GetString("frmReportParameter." & v_ctrl.Name)
            End If
        Next

        Me.Text = mv_ResourceManager.GetString("frmReportParameter.frmReportParameter").Replace("$CMDID", Me.CMDID).Replace("$REPORTTITLE", Me.ReportTitle)
    End Sub

    Private Sub PrepareReportParams(ByVal vstrAFACCTNO As String)
        Dim v_xmlDocument As New XmlDocumentEx
        Dim v_xmlNodeList As Xml.XmlNodeList
        Try
            Dim v_obj As ReportParameters, i, v_intParams, v_intPublic, v_intOffset, v_intIndex As Integer, v_ctrl As Control
            Dim v_strLookupData, v_strFLDNAME, v_strVALUE, v_strParamValue, v_strParamDesc As String

            v_intPublic = IIf(IsPublic = "Y", 2, 0)
            v_intOffset = IIf(IsPublic = "Y", -1, 1)
            mv_intNumOfParam = mv_arrObjFields.GetLength(0) - 1
            ReDim mv_arrRptParam(mv_intNumOfParam + v_intOffset)    'Mac dinh la bao gom tat ca gia tri trong errObjFields la tham so

            'Bao gồm cả 02 tham số mặc định OPT và BRID: Chi su dung cho IsPublic=Y
            'OPT
            v_obj = New ReportParameters
            v_obj.ParamName = "OPT"
            v_obj.ParamCaption = mv_ResourceManager.GetString("frmReportParameter.ReportArea")
            v_obj.ParamValue = ReportArea
            Select Case ReportArea
                Case gc_REPORT_AREA_ALL
                    v_obj.ParamDescription = mv_ResourceManager.GetString("frmReportParameter.ReportArea.All")
                Case gc_REPORT_AREA_BRANCH
                    v_obj.ParamDescription = mv_ResourceManager.GetString("frmReportParameter.ReportArea.Branch")
                Case gc_REPORT_AREA_AGENT
                    v_obj.ParamDescription = mv_ResourceManager.GetString("frmReportParameter.ReportArea.Agent")
            End Select
            v_obj.ParamSize = ReportArea.Length()
            v_obj.ParamType = ReportArea.GetType().ToString()
            mv_arrRptParam(0) = v_obj

            'BRID
            v_obj = New ReportParameters
            v_obj.ParamName = "BRID"
            v_obj.ParamValue = BranchId
            v_obj.ParamSize = BranchId.Length()
            v_obj.ParamType = BranchId.GetType().ToString()
            mv_arrRptParam(1) = v_obj

            If mv_intNumOfParam > 0 Then
                v_intParams = 0 'Starting
                For i = v_intPublic To mv_intNumOfParam - 1
                    If mv_arrObjFields(i).IsParam = "Y" Then
                        v_obj = New ReportParameters
                        v_obj.ParamName = mv_arrObjFields(i).FieldName
                        v_obj.ParamCaption = mv_arrObjFields(i).Caption
                        v_obj.ParamValue = String.Empty
                        'Lay control tren man hinh & xac dinh value
                        v_intIndex = mv_arrObjFields(i).ControlIndex
                        v_ctrl = Me.pnRptParaDetail.Controls(v_intIndex)
                        If mv_arrObjFields(i).ControlType = "C" Then
                            v_obj.ParamValue = CType(v_ctrl, ComboBoxEx).SelectedValue
                        ElseIf IsPublic = "Y" And vstrAFACCTNO.Length > 0 _
                                    And (mv_arrObjFields(i).FieldName = "CIACCTNO" Or mv_arrObjFields(i).FieldName = "AFACCTNO") Then
                            v_obj.ParamValue = vstrAFACCTNO
                        Else
                            v_obj.ParamValue = Strings.UCase(v_ctrl.Text.Trim())
                        End If
                        'Dung gia tri tham so
                        v_strLookupData = mv_arrLookupData(i)
                        If (v_strLookupData.Length() > 0) Then
                            v_xmlDocument.LoadXml(v_strLookupData)
                            v_xmlNodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                            For j As Integer = 0 To v_xmlNodeList.Count - 1
                                For k As Integer = 0 To v_xmlNodeList.Item(j).ChildNodes.Count - 1
                                    With v_xmlNodeList.Item(j).ChildNodes(k)
                                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                        v_strVALUE = .InnerText.ToString

                                        Select Case v_strFLDNAME.Trim()
                                            Case "VALUE"
                                                v_strParamValue = v_strVALUE.Trim()
                                            Case "DISPLAY"
                                                v_strParamDesc = v_strVALUE.Trim()
                                        End Select
                                    End With
                                Next
                                If (v_strParamValue = v_obj.ParamValue.ToString()) Then
                                    v_obj.ParamDescription = v_strParamDesc
                                    Exit For
                                End If
                            Next
                        Else
                            v_obj.ParamDescription = v_obj.ParamValue.ToString()
                        End If

                        v_obj.ParamSize = mv_arrObjFields(i).FieldLength
                        Select Case mv_arrObjFields(i).FieldType
                            Case "M", "T", "C"
                                v_obj.ParamType = GetType(System.String).Name
                            Case "D"
                                v_obj.ParamType = GetType(System.DateTime).Name
                            Case "N"
                                v_obj.ParamType = GetType(Double).Name
                            Case Else
                                v_obj.ParamType = mv_arrObjFields(i).FieldType
                        End Select
                        mv_arrRptParam(v_intParams + v_intPublic + 2) = v_obj
                        v_intParams = v_intParams + 1
                    End If
                Next
            End If
            'Bao gồm cả 02 tham số mặc định OPT và BRID
            mv_intNumOfParam = v_intParams + 1 + v_intOffset
            ReDim Preserve mv_arrRptParam(mv_intNumOfParam - 1) 'Phan tu mang bat dau tu 0
        Catch ex As Exception
            Throw ex
        Finally
            v_xmlDocument = Nothing
        End Try
    End Sub

    'Ham nay dung de chay bao cao tu dong, truyen vao ca so tieu khoan lan so luu ky.
    Private Sub PrepareReportParams(ByVal vstrAFACCTNO As String, ByVal vstrCUSTODYCD As String)
        Dim v_xmlDocument As New XmlDocumentEx
        Dim v_xmlNodeList As Xml.XmlNodeList
        Try
            Dim v_obj As ReportParameters, i, l, v_intParams, v_intPublic, v_intOffset, v_intIndex As Integer, v_ctrl As Control
            Dim v_strLookupData, v_strFLDNAME, v_strVALUE, v_strParamValue, v_strParamDesc As String
            Dim v_intSlts As Integer = 0
            v_intPublic = IIf(IsPublic = "Y", 2, 0)
            v_intOffset = IIf(IsPublic = "Y", -1, 1)
            mv_intNumOfParam = mv_arrObjFields.GetLength(0) - 1
            ReDim mv_arrRptParam(mv_intNumOfParam + v_intOffset)    'Mac dinh la bao gom tat ca gia tri trong errObjFields la tham so

            For l = v_intPublic To mv_intNumOfParam - 1
                If mv_arrObjFields(l).IsParam <> "Y" Then
                    v_intSlts = v_intSlts + 1
                End If
            Next
            ReDim mv_arrRptParam(mv_arrRptParam.GetLength(0) - v_intSlts - 1)


            'Bao gồm cả 02 tham số mặc định OPT và BRID: Chi su dung cho IsPublic=Y
            'OPT
            v_obj = New ReportParameters
            v_obj.ParamName = "OPT"
            v_obj.ParamCaption = mv_ResourceManager.GetString("frmReportParameter.ReportArea")
            v_obj.ParamValue = ReportArea
            Select Case ReportArea
                Case gc_REPORT_AREA_ALL
                    v_obj.ParamDescription = mv_ResourceManager.GetString("frmReportParameter.ReportArea.All")
                Case gc_REPORT_AREA_BRANCH
                    v_obj.ParamDescription = mv_ResourceManager.GetString("frmReportParameter.ReportArea.Branch")
                Case gc_REPORT_AREA_AGENT
                    v_obj.ParamDescription = mv_ResourceManager.GetString("frmReportParameter.ReportArea.Agent")
            End Select
            v_obj.ParamSize = ReportArea.Length()
            v_obj.ParamType = ReportArea.GetType().ToString()
            mv_arrRptParam(0) = v_obj

            'BRID
            v_obj = New ReportParameters
            v_obj.ParamName = "BRID"
            v_obj.ParamValue = BranchId
            v_obj.ParamSize = BranchId.Length()
            v_obj.ParamType = BranchId.GetType().ToString()
            mv_arrRptParam(1) = v_obj


            If mv_intNumOfParam > 0 Then
                v_intParams = 0 'Starting
                For i = v_intPublic To mv_intNumOfParam - 1
                    If mv_arrObjFields(i).IsParam = "Y" Then
                        v_obj = New ReportParameters
                        v_obj.ParamName = mv_arrObjFields(i).FieldName
                        v_obj.ParamCaption = mv_arrObjFields(i).Caption
                        v_obj.ParamValue = String.Empty
                        'Lay control tren man hinh & xac dinh value
                        v_intIndex = mv_arrObjFields(i).ControlIndex
                        v_ctrl = Me.pnRptParaDetail.Controls(v_intIndex)
                        If IsPublic = "Y" And vstrAFACCTNO.Length > 0 _
                                    And (mv_arrObjFields(i).FieldName = "CIACCTNO" Or UCase(mv_arrObjFields(i).FieldName) = "AFACCTNO" _
                                         Or UCase(mv_arrObjFields(i).FieldName) = "PV_AFACCTNO") Then
                            v_obj.ParamValue = vstrAFACCTNO
                        ElseIf mv_arrObjFields(i).ControlType = "C" Then
                            v_obj.ParamValue = CType(v_ctrl, ComboBoxEx).SelectedValue
                        Else
                            v_obj.ParamValue = Strings.UCase(v_ctrl.Text.Trim())
                        End If

                        If IsPublic = "Y" And vstrCUSTODYCD.Length > 0 And (UCase(mv_arrObjFields(i).FieldName) = "PV_CUSTODYCD" _
                                                                            Or UCase(mv_arrObjFields(i).FieldName) = "CUSTODYCD") Then
                            v_obj.ParamValue = UCase(vstrCUSTODYCD)
                        End If

                        'Dung gia tri tham so
                        v_strLookupData = mv_arrLookupData(i)
                        If (v_strLookupData.Length() > 0) Then
                            v_xmlDocument.LoadXml(v_strLookupData)
                            v_xmlNodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                            For j As Integer = 0 To v_xmlNodeList.Count - 1
                                For k As Integer = 0 To v_xmlNodeList.Item(j).ChildNodes.Count - 1
                                    With v_xmlNodeList.Item(j).ChildNodes(k)
                                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                        v_strVALUE = .InnerText.ToString

                                        Select Case v_strFLDNAME.Trim()
                                            Case "VALUE"
                                                v_strParamValue = v_strVALUE.Trim()
                                            Case "DISPLAY"
                                                v_strParamDesc = v_strVALUE.Trim()
                                        End Select
                                    End With
                                Next
                                If (v_strParamValue = v_obj.ParamValue.ToString()) Then
                                    v_obj.ParamDescription = v_strParamDesc
                                    Exit For
                                End If
                            Next
                        Else
                            v_obj.ParamDescription = v_obj.ParamValue.ToString()
                        End If

                        v_obj.ParamSize = mv_arrObjFields(i).FieldLength
                        Select Case mv_arrObjFields(i).FieldType
                            Case "M", "T", "C"
                                v_obj.ParamType = GetType(System.String).Name
                            Case "D"
                                v_obj.ParamType = GetType(System.DateTime).Name
                            Case "N"
                                v_obj.ParamType = GetType(Double).Name
                            Case Else
                                v_obj.ParamType = mv_arrObjFields(i).FieldType
                        End Select
                        mv_arrRptParam(v_intParams + v_intPublic) = v_obj
                        v_intParams = v_intParams + 1
                    End If
                Next
            End If

            mv_intNumOfParam = mv_intNumOfParam - v_intSlts
            'Bao gồm cả 02 tham số mặc định OPT và BRID
            'mv_intNumOfParam = v_intParams + 1 + v_intOffset
            'ReDim Preserve mv_arrRptParam(mv_intNumOfParam - 1) 'Phan tu mang bat dau tu 0
        Catch ex As Exception
            Throw ex
        Finally
            v_xmlDocument = Nothing
        End Try
    End Sub

    Private Function VerifyRules() As Boolean
        Try
            Dim v_strFLDVALUE As String
            Dim v_blnValidData As Boolean = False
            Dim v_strF_DATE, v_strT_DATE As Date

            For i As Integer = 0 To mv_arrObjFields.Length - 1
                If Not (mv_arrObjFields(i) Is Nothing) Then
                    'Verify care by
                    If TellerId <> ADMIN_ID Then
                        If Trim(IsCareBy) = "Y" Then
                            If (mv_arrObjFields(i).FieldName = "CIACCTNO") Or (mv_arrObjFields(i).FieldName = "AFACCTNO") Or (mv_arrObjFields(i).FieldName = "ACCTNO") Then
                                Dim v_strAcctno, v_strSQL, v_strObjMsg, v_strCareBy As String
                                v_strAcctno = CStr(Me.pnRptParaDetail.Controls(mv_arrObjFields(i).ControlIndex).Text.Trim)
                                v_strSQL = "SELECT M.CAREBY CAREBY FROM CFMAST M, AFMAST N WHERE N.ACCTNO = '" & v_strAcctno & "' AND M.CUSTID = N.CUSTID"
                                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strSQL)
                                Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                                v_ws.Message(v_strObjMsg)

                                Dim v_xmlDocument As New XmlDocumentEx
                                v_xmlDocument.LoadXml(v_strObjMsg)
                                Dim v_nodeList As Xml.XmlNodeList
                                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                                Dim v_strFLDNAME, v_strValue As String

                                If v_nodeList.Count > 0 Then
                                    For j As Integer = 0 To v_nodeList.Count - 1
                                        For k As Integer = 0 To v_nodeList.Item(j).ChildNodes.Count - 1
                                            With v_nodeList.Item(j).ChildNodes(k)
                                                v_strValue = .InnerText.ToString
                                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                                Select Case Trim(v_strFLDNAME)
                                                    Case "CAREBY"
                                                        v_strCareBy = v_strValue.Trim
                                                End Select
                                            End With
                                        Next
                                    Next
                                End If

                                Dim v_arrCareBy(), v_arrGroup() As String
                                Dim v_blnOK As Boolean = False
                                If Trim(GroupCareBy) <> String.Empty Then
                                    v_arrCareBy = GroupCareBy.Split("#")
                                    If v_arrCareBy.Length > 1 Then
                                        For j As Integer = 0 To v_arrCareBy.Length - 2
                                            v_arrGroup = CStr(v_arrCareBy(j)).Split("|")
                                            If CStr(v_arrGroup(0)).Trim = v_strCareBy Then
                                                v_blnOK = True
                                                Exit For
                                            Else
                                                v_blnOK = False
                                            End If
                                        Next
                                        If v_blnOK = False Then
                                            MessageBox.Show(mv_ResourceManager.GetString("frmReportParameter.NotCareBy"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            Return False
                                        End If
                                    End If
                                Else
                                    MessageBox.Show(mv_ResourceManager.GetString("frmReportParameter.NotCareBy"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Return False
                                End If

                            End If
                        End If
                    End If



                    If ((mv_arrObjFields(i).FieldType = "T") Or (mv_arrObjFields(i).FieldType = "M")) _
                                        And (mv_arrObjFields(i).Mandatory) Then
                        v_strFLDVALUE = Strings.UCase(Me.pnRptParaDetail.Controls(mv_arrObjFields(i).ControlIndex).Text.Trim())
                        If (mv_arrObjFields(i).DataType = "D") Then
                            v_strFLDVALUE = v_strFLDVALUE.Replace("/", "").Trim()
                        End If
                        If IsPublic <> "Y" Then

                            If Not (v_strFLDVALUE.Length > 0) Then
                                MsgBox(Replace(mv_ResourceManager.GetString("Mandatory"), "@", mv_arrObjFields(i).Caption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                                Me.pnRptParaDetail.Controls(mv_arrObjFields(i).ControlIndex).Focus()
                                Return False
                            End If

                        End If
                    End If

                    'Kiểm tra trư?ng d�ữ liệu kiểu Date
                    If (mv_arrObjFields(i).DataType = "D") Then
                        v_strFLDVALUE = Me.pnRptParaDetail.Controls(mv_arrObjFields(i).ControlIndex).Text.Trim()

                        If Not IsDateValue(v_strFLDVALUE) Then
                            MsgBox(Replace(mv_ResourceManager.GetString("frmReportParameter.DateInvalid"), "@", mv_arrObjFields(i).Caption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            Me.pnRptParaDetail.Controls(mv_arrObjFields(i).ControlIndex).Focus()
                            Return False
                        End If
                    End If

                    If (mv_arrObjFields(i).FieldName = "F_DATE") Then
                        v_strF_DATE = Me.pnRptParaDetail.Controls(mv_arrObjFields(i).ControlIndex).Text.Trim()
                    End If
                    If (mv_arrObjFields(i).FieldName = "T_DATE") Then
                        v_strT_DATE = Me.pnRptParaDetail.Controls(mv_arrObjFields(i).ControlIndex).Text.Trim()
                    End If
                    ' Kiểm tra dữ liệu của trư?ng lookup
                    v_blnValidData = False
                    If (mv_arrObjFields(i).LookUp = "Y") And (mv_arrObjFields(i).LookupList.Length() > 0) Then
                        Dim v_strLookupData As String = mv_arrLookupData(i)
                        Dim v_xmlDocument As New XmlDocumentEx
                        Dim v_xmlNodeList As Xml.XmlNodeList
                        Dim v_strFLDNAME, v_strVALUE, v_strParamValue, v_strParamDesc As String

                        v_strFLDVALUE = Strings.UCase(Me.pnRptParaDetail.Controls(mv_arrObjFields(i).ControlIndex).Text.Trim())

                        If (v_strLookupData.Length() > 0) Then
                            v_xmlDocument.LoadXml(v_strLookupData)
                            v_xmlNodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                            For j As Integer = 0 To v_xmlNodeList.Count - 1
                                For k As Integer = 0 To v_xmlNodeList.Item(j).ChildNodes.Count - 1
                                    With v_xmlNodeList.Item(j).ChildNodes(k)
                                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                        v_strVALUE = .InnerText.ToString

                                        Select Case v_strFLDNAME.Trim()
                                            Case "VALUE"
                                                v_strParamValue = v_strVALUE.Trim()
                                            Case "DISPLAY"
                                                v_strParamDesc = v_strVALUE.Trim()
                                        End Select
                                    End With
                                Next
                                v_strFLDVALUE = v_strFLDVALUE.Replace(" ", "_")
                                If (v_strParamValue = v_strFLDVALUE) Then
                                    v_blnValidData = True
                                    Exit For
                                End If


                            Next
                        End If

                        If v_strFLDVALUE.Trim.Length = 0 And Not mv_arrObjFields(i).Mandatory Then
                            v_blnValidData = True
                        End If

                        If Not v_blnValidData Then
                            MsgBox(Replace(mv_ResourceManager.GetString("frmReportParameter.InvalidData"), "@", mv_arrObjFields(i).Caption), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            Me.pnRptParaDetail.Controls(mv_arrObjFields(i).ControlIndex).Focus()
                            Return False
                        End If
                    End If
                End If
            Next

            'Ki�ểm tra f_date<= t_date
            If v_strT_DATE < v_strF_DATE Then
                MessageBox.Show(mv_ResourceManager.GetString("frmReportParameter.date"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If



            Return True
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function

    Private Sub GetReportFormularValue()
        Try
            'Get common values from SYSVAR table
            Dim v_strSQL As String = "SELECT VARNAME, VARVALUE FROM SYSVAR WHERE GRNAME = 'SYSTEM' UNION ALL SELECT 'AD_HOC' VARNAME, AD_HOC VARVALUE FROM RPTMASTER WHERE RPTID='" & Me.CMDID & "'"
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
                        Case "AD_HOC"
                            mv_strADHOC = v_xmlNode.ChildNodes(i).ChildNodes(1).InnerText.Trim()
                        Case "HEADOFFICE"
                            HeadOffice = v_xmlNode.ChildNodes(i).ChildNodes(1).InnerText.Trim()
                        Case "HEADOFFICE_EN"
                            HeadOffice_En = v_xmlNode.ChildNodes(i).ChildNodes(1).InnerText.Trim()
                        Case "BRNAME"
                            BranchName = v_xmlNode.ChildNodes(i).ChildNodes(1).InnerText.Trim()
                        Case "BRNAME_EN"
                            BranchName_En = v_xmlNode.ChildNodes(i).ChildNodes(1).InnerText.Trim()
                        Case "BRADDRESS"
                            BranchAddress = v_xmlNode.ChildNodes(i).ChildNodes(1).InnerText.Trim()
                        Case "BRADDRESS_EN"
                            BranchAddress_En = v_xmlNode.ChildNodes(i).ChildNodes(1).InnerText.Trim()
                        Case "BRPHONEFAX"
                            BranchPhoneFax = v_xmlNode.ChildNodes(i).ChildNodes(1).InnerText.Trim()
                        Case "BRPHONEFAX_EN"
                            BranchPhoneFax_en = v_xmlNode.ChildNodes(i).ChildNodes(1).InnerText.Trim()
                        Case "COMPANYCD"
                            CompanyCD = v_xmlNode.ChildNodes(i).ChildNodes(1).InnerText.Trim()
                        Case "COMPANYSHORTNAME"
                            CompanyShortname = v_xmlNode.ChildNodes(i).ChildNodes(1).InnerText.Trim()
                        Case "BRCITYADDRESS"
                            AddressCity = v_xmlNode.ChildNodes(i).ChildNodes(1).InnerText.Trim()
                        Case "BRCITYADDRESS_EN"
                            AddressCity_En = v_xmlNode.ChildNodes(i).ChildNodes(1).InnerText.Trim()
                        Case "LOGOFILENAME"
                            mv_strIconFileName = v_xmlNode.ChildNodes(i).ChildNodes(1).InnerText.Trim()
                        Case "DEPOSITID"
                            DepositID = v_xmlNode.ChildNodes(i).ChildNodes(1).InnerText.Trim()
                        Case "WEBSITE"
                            Website = v_xmlNode.ChildNodes(i).ChildNodes(1).InnerText.Trim()
                        Case "BUSDATE"
                            v_strVarValue = v_xmlNode.ChildNodes(i).ChildNodes(1).InnerText.Trim()
                            CreatedDate = "Ngày " & v_strVarValue.Substring(0, 2) & " tháng " & v_strVarValue.Substring(3, 2) _
                                & " năm " & v_strVarValue.Substring(6)
                            CreatedDate_En = "Date " & v_strVarValue.Substring(0, 2) & " month " & v_strVarValue.Substring(3, 2) _
                                    & " year " & v_strVarValue.Substring(6)
                            If UserLanguage = "EN" Then
                                CreatedDate_VN_EN = "Date " & v_strVarValue.Substring(0, 2) & " month " & v_strVarValue.Substring(3, 2) _
                                    & " year " & v_strVarValue.Substring(6)
                            ElseIf UserLanguage = "VN" Then
                                CreatedDate_VN_EN = "Ngày " & v_strVarValue.Substring(0, 2) & " tháng " & v_strVarValue.Substring(3, 2) _
                                    & " năm " & v_strVarValue.Substring(6)
                            End If
                            mv_strCreatedDateFull_VN_EN = "Ngày/Day " & v_strVarValue.Substring(0, 2) & " Tháng/Month " & v_strVarValue.Substring(3, 2) _
                                    & " Năm/Year " & v_strVarValue.Substring(6)
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

    'Nếu là báo cáo sử dụng từ template sẽ dùng hàm này để khởi tạo
    Private Function CreateReportFromTemplate(ByVal v_ds As DataSet, Optional ByVal v_strTHEMECODE As String = "NORMAL") As Boolean
        Dim v_rptDocument As New BasedXtraReport
        Dim v_ws As New BDSRptDeliveryManagement
        Dim v_xmlDocument As New XmlDocumentEx, v_xmlNode As Xml.XmlNode, v_nodeList As Xml.XmlNodeList
        Dim v_strSQL, v_strObjMsg, v_strVarName, v_strVarValue As String, v_intRowCount, v_intCount, i, j As Integer
        Dim v_objReportMaster As New RptMaster, v_objReportSection As RptSection, v_objReportField As RptLayoutField
        Try
            'Nạp dữ liệu cho báo cáo từ dữ liệu trong dataset  
            v_objReportMaster.mv_ds = v_ds
            v_objReportMaster.mv_strReportDirectory = ReportDirectory

            'Nạp danh sách các biến hệ thống & tham số báo cáo
            v_intCount = mv_arrRptParam.GetLength(0) - 1
            ReDim v_objReportMaster.mv_arrRefFormulaName(v_intCount + 8)
            ReDim v_objReportMaster.mv_arrRefFormulaValue(v_intCount + 8)
            For i = 0 To v_intCount
                v_objReportMaster.mv_arrRefFormulaName(i) = mv_arrRptParam(i).ParamName
                v_objReportMaster.mv_arrRefFormulaValue(i) = mv_arrRptParam(i).ParamValue
            Next
            v_objReportMaster.mv_arrRefFormulaName(v_intCount + 1) = gc_RPT_FORMULAR_HEADOFFICE
            v_objReportMaster.mv_arrRefFormulaValue(v_intCount + 1) = HeadOffice
            v_objReportMaster.mv_arrRefFormulaName(v_intCount + 2) = gc_RPT_FORMULAR_COMPANY_NAME
            v_objReportMaster.mv_arrRefFormulaValue(v_intCount + 2) = BranchName
            v_objReportMaster.mv_arrRefFormulaName(v_intCount + 3) = gc_RPT_FORMULAR_ADDRESS
            v_objReportMaster.mv_arrRefFormulaValue(v_intCount + 3) = BranchAddress
            v_objReportMaster.mv_arrRefFormulaName(v_intCount + 4) = gc_RPT_FORMULAR_PHONE_FAX
            v_objReportMaster.mv_arrRefFormulaValue(v_intCount + 4) = BranchPhoneFax
            v_objReportMaster.mv_arrRefFormulaName(v_intCount + 5) = gc_RPT_FORMULAR_REPORT_TITLE
            v_objReportMaster.mv_arrRefFormulaValue(v_intCount + 5) = ReportTitle
            v_objReportMaster.mv_arrRefFormulaName(v_intCount + 6) = gc_RPT_FORMULAR_CREATED_DATE
            v_objReportMaster.mv_arrRefFormulaValue(v_intCount + 6) = CreatedDate
            v_objReportMaster.mv_arrRefFormulaName(v_intCount + 7) = gc_RPT_FORMULAR_CREATED_BY
            v_objReportMaster.mv_arrRefFormulaValue(v_intCount + 7) = Teller
            v_objReportMaster.mv_arrRefFormulaName(v_intCount + 8) = "F_BUSDATE"
            v_objReportMaster.mv_arrRefFormulaValue(v_intCount + 8) = Format(Now, gc_FORMAT_DATE)

            'Lấy tham số định nghĩa cho báo cáo
            v_objReportMaster.GetReportMasterDefinition(CMDID, v_strTHEMECODE)
            If v_objReportMaster.HASSUBREPORT = "N" Then
                'Nếu không có sub-report thì binding datasource vào file gốc
                v_rptDocument.DataSource = v_objReportMaster.mv_ds
            End If
            v_objReportMaster.UserLanguage = UserLanguage
            'Tạo Report Layout
            If Not v_objReportMaster.CreateReportLayout(v_rptDocument, UserLanguage) Then
                Return False
            End If

            'Lên trang báo cáo
            v_rptDocument.CreateDocument()
            Dim m As System.Drawing.Printing.Margins
            m = New System.Drawing.Printing.Margins(v_objReportMaster.LEFTMARGIN, v_objReportMaster.RIGHTMARGIN, v_objReportMaster.TOPMARGIN, v_objReportMaster.BOTTOMMARGIN)
            v_rptDocument.PrintingSystem.PageSettings.Assign(m, v_rptDocument.PaperKind, v_rptDocument.Landscape)
            'Kết xuất ra tệp tin theo định dạng của DevExpress Report            
            v_rptDocument.PrintingSystem.SaveDocument(ReportTempDirectory & GetRptTempFilePathStandard(CMDID))
            Return True
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_objReportMaster = Nothing
            v_rptDocument = Nothing
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Function

#End Region

#Region " Overridable Function "
    Public Overridable Sub OnSubmit()
        Dim v_frm As New frmProcessing
        Dim v_ws As New BDSRptDeliveryManagement
        Dim v_xmlDocumentMessage As New Xml.XmlDocument

        Dim v_wsObj As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Dim v_xmlDocument As New XmlDocumentEx
        Try
            'Change mouse's pointer
            Me.Cursor.Current = Cursors.WaitCursor

            If Not VerifyRules() Then
                'Change mouse's pointer
                Me.Cursor.Current = Cursors.Default
                Exit Sub
            End If
            Dim v_strObjMsg As String = String.Empty
            Dim v_ds As DataSet

            Dim dataElement As Xml.XmlElement, v_attrReport As Xml.XmlAttribute
            'Prepare parameters to create the report
            ReturnExecuted = 0
            If IsPublic <> "Y" Then
                'Show processing message
                v_frm.UserLanguage = UserLanguage
                v_frm.ProcessType = ProcessType.ReportProcess
                v_frm.InitDialog()
                v_frm.Show()
                'End of show processing message

                PrepareReportParams(String.Empty)

                'BuildReportCriteriasString()
                'Xu ly cho Sub Report
                If IsSubRPT = "Y" Then
                    Dim v_arrStoreName() As String
                    If StoredName <> String.Empty Then
                        v_arrStoreName = StoredName.Split("#")
                        If v_arrStoreName.Length > 1 Then
                            'Get data of main report
                            'Main report default is first report in this list
                            v_strObjMsg = BuildXMLRptMsg(LocalObject, v_arrStoreName(0), gc_MsgTypeProc, mv_arrRptParam, mv_intNumOfParam)
                            'Setup attributes
                            v_xmlDocumentMessage.LoadXml(v_strObjMsg)
                            v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeBRID).Value = Me.BranchId
                            v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeTLID).Value = Me.TellerId
                            v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeCMDID).Value = Me.CMDID
                            v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeREFERENCE).Value = Me.CMDID
                            v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeACTFLAG).Value = "M"
                            v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeFUNCNAME).Value = "N"
                            v_strObjMsg = v_xmlDocumentMessage.InnerXml
                            v_ws.Message(v_strObjMsg)

                            'Create report
                            v_xmlDocumentMessage.LoadXml(v_strObjMsg)
                            v_ds = ConvertXmlDocToDataSet(v_xmlDocumentMessage)
                            v_ds.Tables(0).TableName = v_arrStoreName(0)
                            'v_ds.WriteXml(ReportTempDirectory & CMDID & TellerId & ".xml")

                            For i As Integer = 1 To v_arrStoreName.Length - 1
                                Dim v_strSubObjMsg As String
                                Dim v_xmlSubDocumentMessage As New Xml.XmlDocument
                                Dim v_dsSub As DataSet
                                v_strSubObjMsg = BuildXMLRptMsg(LocalObject, v_arrStoreName(i), gc_MsgTypeProc, mv_arrRptParam, mv_intNumOfParam)
                                'Setup attributes
                                v_xmlSubDocumentMessage.LoadXml(v_strSubObjMsg)
                                v_xmlSubDocumentMessage.DocumentElement.Attributes(gc_AtributeBRID).Value = Me.BranchId
                                v_xmlSubDocumentMessage.DocumentElement.Attributes(gc_AtributeTLID).Value = Me.TellerId
                                v_xmlSubDocumentMessage.DocumentElement.Attributes(gc_AtributeCMDID).Value = Me.CMDID
                                v_xmlSubDocumentMessage.DocumentElement.Attributes(gc_AtributeREFERENCE).Value = Me.CMDID
                                v_xmlSubDocumentMessage.DocumentElement.Attributes(gc_AtributeACTFLAG).Value = "M"
                                v_xmlSubDocumentMessage.DocumentElement.Attributes(gc_AtributeFUNCNAME).Value = "N"
                                v_strSubObjMsg = v_xmlSubDocumentMessage.InnerXml

                                v_ws.Message(v_strSubObjMsg)
                                'Create report
                                v_xmlSubDocumentMessage.LoadXml(v_strSubObjMsg)
                                v_dsSub = ConvertXmlDocToDataSet(v_xmlSubDocumentMessage)
                                v_dsSub.Tables(0).TableName = v_arrStoreName(i)

                                'Merge 2 datasets to 1 dataset
                                v_ds.Merge(v_dsSub)
                            Next
                            addIconColumn(v_ds)
                            v_ds.WriteXml(ReportTempDirectory & CMDID & TellerId & ".xml")

                        Else
                            'Create message and send to web service to get data for the report
                            v_strObjMsg = BuildXMLRptMsg(LocalObject, StoredName, gc_MsgTypeProc, mv_arrRptParam, mv_intNumOfParam)

                            'Setup attributes
                            v_xmlDocumentMessage.LoadXml(v_strObjMsg)
                            v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeBRID).Value = Me.BranchId
                            v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeTLID).Value = Me.TellerId
                            v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeCMDID).Value = Me.CMDID
                            v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeREFERENCE).Value = Me.CMDID
                            v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeACTFLAG).Value = "M"
                            v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeFUNCNAME).Value = "N"
                            v_strObjMsg = v_xmlDocumentMessage.InnerXml

                            v_ws.Message(v_strObjMsg)

                            'Create report
                            v_xmlDocumentMessage.LoadXml(v_strObjMsg)
                            v_ds = ConvertXmlDocToDataSet(v_xmlDocumentMessage)
                            addIconColumn(v_ds)
                            v_ds.WriteXml(ReportTempDirectory & CMDID & TellerId & ".xml")

                        End If
                    End If
                Else
                    'Create message and send to web service to get data for the report
                    v_strObjMsg = BuildXMLRptMsg(LocalObject, StoredName, gc_MsgTypeProc, mv_arrRptParam, mv_intNumOfParam)

                    'Setup attributes
                    v_xmlDocumentMessage.LoadXml(v_strObjMsg)
                    v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeBRID).Value = Me.BranchId
                    v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeTLID).Value = Me.TellerId
                    v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeCMDID).Value = Me.CMDID
                    v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeREFERENCE).Value = Me.CMDID
                    v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeACTFLAG).Value = "M"
                    v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeFUNCNAME).Value = "N"
                    v_strObjMsg = v_xmlDocumentMessage.InnerXml

                    v_ws.Message(v_strObjMsg)

                    'Create report
                    v_xmlDocumentMessage.LoadXml(v_strObjMsg)
                    v_ds = ConvertXmlDocToDataSet(v_xmlDocumentMessage)

                    'T07/2017 STP: Them Try Ctch
                    Try
                        addIconColumn(v_ds)
                        v_ds.WriteXml(ReportTempDirectory & CMDID & TellerId & ".xml")
                    Catch ex As Exception
                    End Try
                    'End T07/2017 STP: Them Try Ctch
                End If

                'Close processing message window
                v_frm.Close()
                ' Change cursor pointer
                Me.Cursor.Current = Cursors.Default

                'If v_ds Is Nothing Then
                '    CreateReport(v_ds, String.Empty)
                '    ReturnExecuted = 2  'Pending
                '    'Me.Close()
                ' gan thong bao thanh cong voi bao cao tao dien
                'TanPN 18/2/2020 thong bao thanh cong
                If v_ds Is Nothing Then
                    MessageBox.Show(mv_ResourceManager.GetString("frmReportParameter.ReCreateSucessfully"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '                    CreateReport(v_ds, String.Empty)
                    ReturnExecuted = 2  'Pending
                    'Me.Close()
                Else
                    If CreateReportFactory(v_ds) Then
                        ReturnExecuted = 1
                    End If
                End If


                'Old
                'If v_ds Is Nothing Then
                '    MessageBox.Show(mv_ResourceManager.GetString("frmReportParameter.ReCreateSucessfully"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    '                    CreateReport(v_ds, String.Empty)
                '    ReturnExecuted = 2  'Pending
                '    'Me.Close()
                'Else
                '    If Me.mv_strADHOC = "N" Then
                '        If CreateReportFromTemplate(v_ds) Then
                '            MessageBox.Show(mv_ResourceManager.GetString("frmReportParameter.ReCreateSucessfully"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                '            ReturnExecuted = 1 'Ok
                '        End If
                '    Else
                '        If CreateReport(v_ds, String.Empty) Then
                '            'Show sucessful message
                '            MessageBox.Show(mv_ResourceManager.GetString("frmReportParameter.ReCreateSucessfully"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                '            ReturnExecuted = 1 'Ok
                '            'Me.Close()
                '        End If
                '    End If
                'End If
            Else
                'Show processing message
                v_frm.UserLanguage = UserLanguage
                v_frm.ProcessType = ProcessType.ReportProcess
                v_frm.InitDialog()
                v_frm.Show()
                'End of show processing message
                Me.Cursor.Current = Cursors.WaitCursor

                For Each v_ctrl As Control In pnRptParaDetail.Controls
                    If TypeOf (v_ctrl) Is FlexMaskEditBox Then
                        If v_ctrl.Name = "mskData" & "FCUSTODYCD" Then
                            mv_strFacctno = Strings.UCase(v_ctrl.Text.Trim())
                        End If
                        If v_ctrl.Name = "mskData" & "TCUSTODYCD" Then
                            mv_strTacctno = Strings.UCase(v_ctrl.Text.Trim())
                        End If
                    End If
                Next

                Dim v_strSQL As String
                'Doan nay tinh toan ra so trang de phan trang.
                If mv_strFacctno = "ALL" AndAlso mv_strTacctno = "ALL" Then
                    v_strSQL = "SELECT TRUNC(COUNT(1)/100) + 1 PHANTRANG FROM RPTAFMAST " _
                    & "WHERE STATUS='A' AND EXPDATE >= TO_DATE('" & Me.BusDate & "', 'DD/MM/RRRR') AND RPTID='" & Me.ObjectName & "' AND EXCYCLE = '" & Excycle & "'"
                End If

                If mv_strFacctno = "ALL" AndAlso mv_strTacctno <> "ALL" Then
                    v_strSQL = "SELECT TRUNC(COUNT(1)/100) + 1 PHANTRANG FROM RPTAFMAST " _
                    & "WHERE STATUS='A' AND EXPDATE >= TO_DATE('" & Me.BusDate & "', 'DD/MM/RRRR') AND RPTID='" & Me.ObjectName & "' AND EXCYCLE = '" & Excycle & "' AND CUSTODYCD <= '" & mv_strTacctno & "' ORDER BY AFACCTNO "
                End If

                If mv_strFacctno <> "ALL" AndAlso mv_strTacctno = "ALL" Then
                    v_strSQL = "SELECT TRUNC(COUNT(1)/100) + 1 PHANTRANG FROM RPTAFMAST " _
                    & "WHERE STATUS='A' AND EXPDATE >= TO_DATE('" & Me.BusDate & "', 'DD/MM/RRRR') AND RPTID='" & Me.ObjectName & "' AND EXCYCLE = '" & Excycle & "' AND CUSTODYCD >= '" & mv_strFacctno & "' ORDER BY AFACCTNO "
                End If

                If mv_strFacctno <> "ALL" AndAlso mv_strTacctno <> "ALL" Then
                    v_strSQL = "SELECT TRUNC(COUNT(1)/100) + 1 PHANTRANG FROM RPTAFMAST " _
                    & "WHERE STATUS='A' AND EXPDATE >= TO_DATE('" & Me.BusDate & "', 'DD/MM/RRRR') AND RPTID='" & Me.ObjectName & "' AND EXCYCLE = '" & Excycle & "' AND CUSTODYCD >= '" & mv_strFacctno & "' AND CUSTODYCD <= '" & mv_strTacctno & "' ORDER BY AFACCTNO "
                End If

                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_RPTMASTER, _
                                        gc_ActionInquiry, v_strSQL)
                v_wsObj.Message(v_strObjMsg)

                Dim v_xmlNodeList As Xml.XmlNodeList
                Dim v_intPages, v_intFront, v_intTail As Integer
                Dim v_strFLDNAME, v_strVALUE, v_strAFACCTNO, v_strEXCYCLE, v_strCUSTODYCD As String

                v_xmlDocument.LoadXml(v_strObjMsg)
                v_xmlNodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                If v_xmlNodeList.Count > 0 AndAlso v_xmlNodeList.Item(0).ChildNodes.Count Then
                    v_intPages = CInt(v_xmlNodeList.Item(0).ChildNodes(0).InnerText.ToString().Trim())
                End If

                For a As Integer = 0 To v_intPages - 1
                    v_intFront = a * 100
                    v_intTail = (a + 1) * 100

                    If mv_strFacctno = "ALL" AndAlso mv_strTacctno = "ALL" Then
                        v_strSQL = "SELECT RPTAF.* FROM (SELECT TEMP.*, ROWNUM ABC FROM (SELECT CUSTODYCD, AFACCTNO, EXCYCLE FROM RPTAFMAST " _
                        & "WHERE STATUS='A' AND EXPDATE >= TO_DATE('" & Me.BusDate & "', 'DD/MM/RRRR') AND RPTID='" & Me.ObjectName & "' AND EXCYCLE = '" & Excycle & "'  ORDER BY CUSTODYCD) TEMP) RPTAF " _
                        & "WHERE RPTAF.ABC > " & v_intFront.ToString() & " AND RPTAF.ABC <= " & v_intTail.ToString()
                    End If

                    If mv_strFacctno = "ALL" AndAlso mv_strTacctno <> "ALL" Then
                        v_strSQL = "SELECT RPTAF.* FROM (SELECT TEMP.*, ROWNUM ABC FROM (SELECT CUSTODYCD, AFACCTNO, EXCYCLE FROM RPTAFMAST " _
                        & "WHERE STATUS='A' AND EXPDATE >= TO_DATE('" & Me.BusDate & "', 'DD/MM/RRRR') AND RPTID='" & Me.ObjectName & "' AND EXCYCLE = '" & Excycle & "' AND CUSTODYCD <= '" & mv_strTacctno & "'  ORDER BY CUSTODYCD) TEMP) RPTAF " _
                        & "WHERE RPTAF.ABC > " & v_intFront.ToString() & " AND RPTAF.ABC <= " & v_intTail.ToString()
                    End If

                    If mv_strFacctno <> "ALL" AndAlso mv_strTacctno = "ALL" Then
                        v_strSQL = "SELECT RPTAF.* FROM (SELECT TEMP.*, ROWNUM ABC FROM (SELECT CUSTODYCD, AFACCTNO, EXCYCLE FROM RPTAFMAST " _
                        & "WHERE STATUS='A' AND EXPDATE >= TO_DATE('" & Me.BusDate & "', 'DD/MM/RRRR') AND RPTID='" & Me.ObjectName & "' AND EXCYCLE = '" & Excycle & "' AND CUSTODYCD >= '" & mv_strFacctno & "'  ORDER BY CUSTODYCD) TEMP) RPTAF " _
                        & "WHERE RPTAF.ABC > " & v_intFront.ToString() & " AND RPTAF.ABC <= " & v_intTail.ToString()
                    End If

                    If mv_strFacctno <> "ALL" AndAlso mv_strTacctno <> "ALL" Then
                        v_strSQL = "SELECT RPTAF.* FROM (SELECT TEMP.*, ROWNUM ABC FROM (SELECT CUSTODYCD, AFACCTNO, EXCYCLE FROM RPTAFMAST " _
                        & "WHERE STATUS='A' AND EXPDATE >= TO_DATE('" & Me.BusDate & "', 'DD/MM/RRRR') AND RPTID='" & Me.ObjectName & "' AND EXCYCLE = '" & Excycle & "' AND CUSTODYCD >= '" & mv_strFacctno & "' AND CUSTODYCD <= '" & mv_strTacctno & "'  ORDER BY CUSTODYCD) TEMP) RPTAF " _
                        & "WHERE RPTAF.ABC > " & v_intFront.ToString() & " AND RPTAF.ABC <= " & v_intTail.ToString()
                    End If

                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_RPTMASTER, _
                                        gc_ActionInquiry, v_strSQL)
                    v_wsObj.Message(v_strObjMsg)

                    'Lấy ra description của tiêu chí tạo báo cáo
                    v_xmlDocument.LoadXml(v_strObjMsg)
                    v_xmlNodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                    If v_intPages = 1 And v_xmlNodeList.Count = 0 Then
                        ReturnExecuted = 5
                    End If

                    For j As Integer = 0 To v_xmlNodeList.Count - 1
                        v_strAFACCTNO = String.Empty
                        v_strEXCYCLE = String.Empty
                        v_strCUSTODYCD = String.Empty
                        For k As Integer = 0 To v_xmlNodeList.Item(j).ChildNodes.Count - 1
                            With v_xmlNodeList.Item(j).ChildNodes(k)
                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                v_strVALUE = .InnerText.ToString
                                Select Case v_strFLDNAME.Trim()
                                    Case "CUSTODYCD"
                                        v_strCUSTODYCD = v_strVALUE.Trim()
                                    Case "AFACCTNO"
                                        v_strAFACCTNO = v_strVALUE.Trim()
                                    Case "EXCYCLE"
                                        v_strEXCYCLE = v_strVALUE.Trim()
                                End Select
                            End With
                        Next

                        If v_strAFACCTNO.Length > 0 And v_strCUSTODYCD.Length > 0 Then
                            'Prepare parameters to create the report
                            PrepareReportParams(v_strAFACCTNO, v_strCUSTODYCD)

                            If IsSubRPT = "Y" Then
                                Dim v_arrStoreName() As String
                                If StoredName <> String.Empty Then
                                    v_arrStoreName = StoredName.Split("#")
                                    If v_arrStoreName.Length > 1 Then
                                        'Get data of main report
                                        'Main report default is first report in this list
                                        v_strObjMsg = BuildXMLRptMsg(LocalObject, v_arrStoreName(0), gc_MsgTypeProc, mv_arrRptParam, mv_intNumOfParam)

                                        'Setup attributes
                                        v_xmlDocumentMessage.LoadXml(v_strObjMsg)
                                        v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeBRID).Value = Me.BranchId
                                        v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeTLID).Value = Me.TellerId
                                        v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeCMDID).Value = Me.CMDID
                                        v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeREFERENCE).Value = Me.CMDID
                                        v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeACTFLAG).Value = "M"
                                        v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeFUNCNAME).Value = "N"
                                        v_strObjMsg = v_xmlDocumentMessage.InnerXml

                                        v_ws.Message(v_strObjMsg)

                                        'Create report
                                        v_xmlDocumentMessage.LoadXml(v_strObjMsg)
                                        v_ds = ConvertXmlDocToDataSet(v_xmlDocumentMessage)
                                        v_ds.Tables(0).TableName = v_arrStoreName(0)
                                        'Get data of sub report
                                        For i As Integer = 1 To v_arrStoreName.Length - 1
                                            Dim v_strSubObjMsg As String
                                            Dim v_xmlSubDocumentMessage As New Xml.XmlDocument
                                            Dim v_dsSub As DataSet
                                            v_strSubObjMsg = BuildXMLRptMsg(LocalObject, v_arrStoreName(i), gc_MsgTypeProc, mv_arrRptParam, mv_intNumOfParam)
                                            'Setup attributes
                                            v_xmlSubDocumentMessage.LoadXml(v_strSubObjMsg)
                                            v_xmlSubDocumentMessage.DocumentElement.Attributes(gc_AtributeBRID).Value = Me.BranchId
                                            v_xmlSubDocumentMessage.DocumentElement.Attributes(gc_AtributeTLID).Value = Me.TellerId
                                            v_xmlSubDocumentMessage.DocumentElement.Attributes(gc_AtributeCMDID).Value = Me.CMDID
                                            v_xmlSubDocumentMessage.DocumentElement.Attributes(gc_AtributeREFERENCE).Value = Me.CMDID
                                            v_xmlSubDocumentMessage.DocumentElement.Attributes(gc_AtributeACTFLAG).Value = "M"
                                            v_xmlSubDocumentMessage.DocumentElement.Attributes(gc_AtributeFUNCNAME).Value = "N"
                                            v_strSubObjMsg = v_xmlSubDocumentMessage.InnerXml

                                            v_ws.Message(v_strSubObjMsg)
                                            'Create report
                                            v_xmlSubDocumentMessage.LoadXml(v_strSubObjMsg)
                                            v_dsSub = ConvertXmlDocToDataSet(v_xmlSubDocumentMessage)
                                            v_dsSub.Tables(0).TableName = v_arrStoreName(i)

                                            'Merge 2 datasets to 1 dataset
                                            v_ds.Merge(v_dsSub)
                                        Next
                                    Else
                                        'Create message and send to web service to get data for the report
                                        v_strObjMsg = BuildXMLRptMsg(LocalObject, StoredName, gc_MsgTypeProc, mv_arrRptParam, mv_intNumOfParam)

                                        'Setup attributes
                                        v_xmlDocumentMessage.LoadXml(v_strObjMsg)
                                        v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeBRID).Value = Me.BranchId
                                        v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeTLID).Value = Me.TellerId
                                        v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeCMDID).Value = Me.CMDID
                                        v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeREFERENCE).Value = Me.CMDID
                                        v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeACTFLAG).Value = "M"
                                        v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeFUNCNAME).Value = "N"
                                        v_strObjMsg = v_xmlDocumentMessage.InnerXml

                                        v_ws.Message(v_strObjMsg)

                                        'Create report
                                        v_xmlDocumentMessage.LoadXml(v_strObjMsg)
                                        v_ds = ConvertXmlDocToDataSet(v_xmlDocumentMessage)

                                    End If
                                End If
                            Else
                                'Create message and send to web service to get data for the report
                                v_strObjMsg = BuildXMLRptMsg(LocalObject, StoredName, gc_MsgTypeProc, mv_arrRptParam, mv_intNumOfParam)

                                'Setup attributes
                                v_xmlDocumentMessage.LoadXml(v_strObjMsg)
                                v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeBRID).Value = Me.BranchId
                                v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeTLID).Value = Me.TellerId
                                v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeCMDID).Value = Me.CMDID
                                v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeREFERENCE).Value = Me.CMDID
                                v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeACTFLAG).Value = "M"
                                v_xmlDocumentMessage.DocumentElement.Attributes(gc_AtributeFUNCNAME).Value = "N"
                                v_strObjMsg = v_xmlDocumentMessage.InnerXml

                                v_ws.Message(v_strObjMsg)

                                'Create report
                                v_xmlDocumentMessage.LoadXml(v_strObjMsg)
                                v_ds = ConvertXmlDocToDataSet(v_xmlDocumentMessage)
                            End If

                            If CreateReportFactory(v_ds, v_strAFACCTNO, v_strCUSTODYCD) Then
                                ReturnExecuted = 2
                            End If

                            'Old
                            'If v_ds Is Nothing Then
                            '    'Tao file temporary
                            '    CreateReport(v_ds, v_strAFACCTNO, v_strCUSTODYCD)
                            '    ReturnExecuted = 2
                            'Else
                            '    If v_ds.Tables(0).Rows.Count <> 0 Then
                            '        If Not CreateReport(v_ds, v_strAFACCTNO, v_strCUSTODYCD) Then
                            '            LogError.Write("Error source: frmReportParameter.OnSubmit" & vbNewLine _
                            '                         & "Error code: Batch report for " & v_strAFACCTNO & vbNewLine _
                            '                         & "Error message: " & Me.ObjectName & "." & v_strAFACCTNO, EventLogEntryType.Error)
                            '            'Close report parameters window
                            '            Exit Sub
                            '        Else
                            '            'ReturnExecuted = 1
                            '            'Tao bao cao tu dong nen khong can VIEW
                            '            ReturnExecuted = 2
                            '        End If
                            '    End If
                            'End If
                        End If
                    Next
                Next

                v_frm.Close()
                If ReturnExecuted = 2 Then
                    MessageBox.Show(mv_ResourceManager.GetString("frmReportParameter.ReCreateSucessfully"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf ReturnExecuted = 5 Then
                    MessageBox.Show(mv_ResourceManager.GetString("ERR001"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                ' Change cursor pointer
                Me.Cursor.Current = Cursors.Default
                'Me.Close()
            End If
            If ReturnExecuted = 1 Then
                OnView(CMDID)
            End If


        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            v_frm.Close()
            ' Change cursor pointer
            Me.Cursor.Current = Cursors.Default
            Me.Close()
        Finally
            v_wsObj = Nothing
            v_xmlDocument = Nothing
            v_frm = Nothing
            v_ws = Nothing
            v_xmlDocumentMessage = Nothing
        End Try
    End Sub

    Public Overridable Sub OnClose()
        Me.Close()
    End Sub

    Public Overridable Sub mskData_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim v_ctrl As Windows.Forms.Control
        Dim v_txtctrl As TextBox
        Dim v_strLBLNAME As String

        Try
            'Ch?n to�àn bộ phần dữ liệu đang có
            If (TypeOf (sender) Is FlexMaskEditBox) Then
                CType(sender, FlexMaskEditBox).SelectionStart = 0
                If InStr(CType(sender, Control).Name, "CUST") > 0 Or InStr(CType(sender, Control).Name, "ACCTNO") > 0 Then
                    CType(sender, FlexMaskEditBox).SelectionLength = Len(CType(sender, FlexMaskEditBox).Text) + 1
                Else
                    CType(sender, FlexMaskEditBox).SelectionLength = Len(CType(sender, FlexMaskEditBox).Text)
                End If
                'T10/2019 DieuNDA Fix loi nhap So trong bao cao
                'Lấy tên của Label Description tương ứng.
                v_strLBLNAME = PREFIXED_LBLDESC + Mid(CType(sender, FlexMaskEditBox).Name, Len(PREFIXED_MSKDATA) + 1)

            ElseIf (TypeOf (sender) Is TextBox) Then
                CType(sender, TextBox).SelectionStart = 0
                CType(sender, TextBox).SelectionLength = Len(CType(sender, TextBox).Text)
                'Lấy tên của Label Description tương ứng.
                v_strLBLNAME = PREFIXED_LBLDESC + Mid(CType(sender, TextBox).Name, Len(PREFIXED_MSKDATA) + 1)
            Else
                v_strLBLNAME = PREFIXED_LBLDESC + Mid(CType(sender, TextBox).Name, Len(PREFIXED_MSKDATA) + 1)
            End If

            ''Lấy tên của Label Description tương ứng.
            'v_strLBLNAME = PREFIXED_LBLDESC + Mid(CType(sender, FlexMaskEditBox).Name, Len(PREFIXED_MSKDATA) + 1)
            'End T10/2019 DieuNDA Fix loi nhap So trong bao cao

            For Each v_ctrl In Me.pnRptParaDetail.Controls
                If (TypeOf (v_ctrl) Is Label) Then
                    If CType(v_ctrl, Label).Name = v_strLBLNAME Then
                        'Me.lblHelper.Text = Trim(CType(v_ctrl, Label).Text)
                        Exit For
                    End If
                End If
            Next
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Public Overridable Sub mskData_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        If Me.ActiveControl Is Me.btnCANCEL Then
            OnClose()
            Exit Sub
        End If
        Try
            Dim v_strRefValue, v_strFieldValue, strFLDNAME, v_strSQLCMD, v_strFLDNAME, v_strValue, v_strFIELDCODE As String
            Dim v_intIndex As Integer, ctl As Control, v_bolCheck As Boolean
            Dim v_strObjMsg, v_strTempValue, v_strDEFNAME, v_strSEARCHCODE, v_strKeyVal, v_strKeyName, _
                v_strSEARCHSQL, v_strFULLDATA, v_strDisplay As String
            Dim v_nodeList As Xml.XmlNodeList

            v_intIndex = CType(sender, Control).Tag
            If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                v_strFieldValue = CType(sender, Control).Text
                strFLDNAME = Mid(CType(sender, Control).Name, Len(PREFIXED_MSKDATA) + 1)
            End If

            'Validate custody code     
            v_strDEFNAME = mv_arrObjFields(v_intIndex).ColumnName
            If String.Compare(v_strDEFNAME, "CUSTODYCD") = 0 Then
                v_strTempValue = v_strFieldValue.Replace(".", String.Empty).ToUpper
                If v_strTempValue.Length <> 10 Then
                    'MessageBox.Show(mv_ResourceManager.GetString("ERR_CUSTODYCD_INVALID_LENGTH"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    MsgBox(Replace(mv_ResourceManager.GetString("Mandatory"), "@", "CUSTODYCD"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    e.Cancel = True
                    Exit Sub
                Else
                    v_strFieldValue = v_strFieldValue.ToUpper
                    CType(sender, Control).Text = v_strFieldValue
                End If
            End If

            'Fill du lieu lookup tu HOST (Fill du lieu cho Refvalue va cac control khac)
            ''Sua lai loi LOOKUP data = 'ALL'
            If Len(mv_arrObjFields(v_intIndex).SearchCode) > 0 And v_strFieldValue <> "ALL" Then
                Dim ctlCheck As Control
                ctlCheck = Me.pnRptParaDetail.Controls(mv_arrObjFields(v_intIndex).ControlIndex)
                If Not (mv_arrObjFields(v_intIndex).Mandatory = False And ctlCheck.Text.Trim.Length = 0) Then
                    'Kiem tra du lieu nhap vao co dung khong
                    v_strSEARCHCODE = mv_arrObjFields(v_intIndex).SearchCode
                    v_strKeyVal = Replace(v_strFieldValue, ".", "")
                    'Lay KeyName
                    v_strSQLCMD = "SELECT SEARCHFLD.FIELDCODE KEYNAME,SEARCH.SEARCHCMDSQL FROM SEARCHFLD,SEARCH " & ControlChars.CrLf _
                        & " WHERE SEARCH.SEARCHCODE = SEARCHFLD.SEARCHCODE " & ControlChars.CrLf _
                        & " AND SEARCHFLD.KEY ='Y' AND SEARCHFLD.SEARCHCODE ='" & v_strSEARCHCODE & "'"
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQLCMD)
                    v_ws.Message(v_strObjMsg)
                    v_xmlDocument.LoadXml(v_strObjMsg)
                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                    If v_nodeList.Count > 0 Then
                        For i As Integer = 0 To v_nodeList.Count - 1
                            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                                With v_nodeList.Item(i).ChildNodes(j)
                                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                    v_strValue = Trim(.InnerText)
                                    Select Case v_strFLDNAME
                                        Case "KEYNAME"
                                            v_strKeyName = Trim(v_strValue)
                                        Case "SEARCHCMDSQL"
                                            v_strSEARCHSQL = Trim(v_strValue)
                                    End Select
                                End With
                            Next
                        Next
                        Dim v_strClause As String
                        v_strSQLCMD = "SELECT *  FROM  (" & v_strSEARCHSQL & ") WHERE REPLACE(" & v_strKeyName & ",'.','')='" & v_strKeyVal & "'"
                        v_strSQLCMD = v_strSQLCMD.Replace("<$BRID>", HO_BRID)
                        v_strSQLCMD = v_strSQLCMD.Replace("<$HO_BRID>", HO_BRID)
                        v_strSQLCMD = v_strSQLCMD.Replace("<$BUSDATE>", Me.BusDate)
                        v_strSQLCMD = v_strSQLCMD.Replace("<$TELLERID>", Me.TellerId)
                        v_strSQLCMD = v_strSQLCMD.Replace("<$AFACCTNO>", "")
                        v_strSQLCMD = v_strSQLCMD.Replace("<$CUSTID>", "")
                        v_strSQLCMD = v_strSQLCMD.Replace("<@KEYVALUE>", GetFieldValueByName(mv_arrObjFields(v_intIndex).TagField))

                        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strSQLCMD)
                        v_ws.Message(v_strObjMsg)
                        FillLookupData(strFLDNAME, v_strFieldValue, v_strObjMsg, v_strKeyName)
                        'Fill Refval
                        v_strSQLCMD = "SELECT SEARCHCMDSQL,SE.SEARCHCODE,SEFLD.FIELDCODE, SEARCHFLD.FIELDCODE KEYNAME FROM SEARCH SE,SEARCHFLD SEFLD,SEARCHFLD WHERE SE.SEARCHCODE=SEFLD.SEARCHCODE" & ControlChars.CrLf _
                                    & "AND SE.SEARCHCODE=SEARCHFLD.SEARCHCODE AND SE.SEARCHCODE='" & v_strSEARCHCODE & "' AND SEFLD.REFVALUE='Y' AND SEARCHFLD.KEY='Y'"
                        v_strSQLCMD = v_strSQLCMD.Replace("<$BRID>", HO_BRID)
                        v_strSQLCMD = v_strSQLCMD.Replace("<$HO_BRID>", HO_BRID)
                        v_strSQLCMD = v_strSQLCMD.Replace("<$BUSDATE>", Me.BusDate)
                        v_strSQLCMD = v_strSQLCMD.Replace("<$BUSDATE>", Me.BusDate)
                        v_strSQLCMD = v_strSQLCMD.Replace("<$AFACCTNO>", "")
                        v_strSQLCMD = v_strSQLCMD.Replace("<$CUSTID>", "")
                        v_strSQLCMD = v_strSQLCMD.Replace("<@KEYVALUE>", GetFieldValueByName(mv_arrObjFields(v_intIndex).TagField))


                        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQLCMD, "")
                        v_ws.Message(v_strObjMsg)
                        v_xmlDocument.LoadXml(v_strObjMsg)
                        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                        If v_nodeList.Count > 0 Then
                            For i As Integer = 0 To v_nodeList.Count - 1
                                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                                    With v_nodeList.Item(i).ChildNodes(j)
                                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                        v_strValue = Trim(.InnerText)
                                        Select Case v_strFLDNAME
                                            Case "FIELDCODE"
                                                v_strFIELDCODE = Trim(v_strValue)
                                        End Select
                                    End With
                                Next
                            Next
                            v_strSQLCMD = "SELECT " & v_strFIELDCODE & " FROM  (" & v_strSEARCHSQL & ") WHERE REPLACE(" & v_strKeyName & ",'.','')='" & v_strKeyVal & "'"
                            v_strSQLCMD = v_strSQLCMD.Replace("<$BRID>", HO_BRID)
                            v_strSQLCMD = v_strSQLCMD.Replace("<$HO_BRID>", HO_BRID)
                            v_strSQLCMD = v_strSQLCMD.Replace("<$BUSDATE>", Me.BusDate)
                            v_strSQLCMD = v_strSQLCMD.Replace("<$TELLERID>", Me.TellerId)
                            v_strSQLCMD = v_strSQLCMD.Replace("<$AFACCTNO>", "")
                            v_strSQLCMD = v_strSQLCMD.Replace("<$CUSTID>", "")
                            v_strSQLCMD = v_strSQLCMD.Replace("<@KEYVALUE>", GetFieldValueByName(mv_arrObjFields(v_intIndex).TagField))

                            If Me.UserLanguage = gc_LANG_ENGLISH Then
                                v_strSQLCMD = v_strSQLCMD.Replace("<@CDCONTENT>", "EN_CDCONTENT")
                                v_strSQLCMD = v_strSQLCMD.Replace("<@DESCRIPTION>", "EN_DESCRIPTION")
                            Else
                                v_strSQLCMD = v_strSQLCMD.Replace("<@CDCONTENT>", "CDCONTENT")
                                v_strSQLCMD = v_strSQLCMD.Replace("<@DESCRIPTION>", "DESCRIPTION")
                            End If

                            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CA_CAMAST, gc_ActionInquiry, v_strSQLCMD, "")
                            v_ws.Message(v_strObjMsg)
                            v_xmlDocument.LoadXml(v_strObjMsg)
                            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                            If v_nodeList.Count > 0 Then
                                For i As Integer = 0 To v_nodeList.Count - 1
                                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                                        With v_nodeList.Item(i).ChildNodes(j)
                                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                            v_strValue = Trim(.InnerText)
                                            Select Case v_strFLDNAME
                                                Case v_strFIELDCODE
                                                    v_strRefValue = v_strValue
                                            End Select
                                        End With
                                    Next
                                Next
                                If Len(v_strRefValue) > 0 Then
                                    'Fill Refval                                    
                                    ctl = Me.pnRptParaDetail.Controls(mv_arrObjFields(v_intIndex).LabelIndex)
                                    ctl.Top = sender.Top
                                    ctl.Text = v_strRefValue
                                    ctl.Visible = True
                                    mv_strCustName = v_strRefValue
                                End If
                            Else
                                If mv_arrObjFields(v_intIndex).Mandatory = True Then
                                    MessageBox.Show(Replace(mv_ResourceManager.GetString("ERR_DATA_NOTFOUND"), "[@]", mv_arrObjFields(v_intIndex).Caption), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    e.Cancel = True
                                    Exit Sub
                                End If
                            End If
                        End If
                    End If
                End If

            ElseIf mv_arrObjFields(v_intIndex).LookUp = "Y" Then
                Dim ctlCheck As Control
                ctlCheck = Me.pnRptParaDetail.Controls(mv_arrObjFields(v_intIndex).ControlIndex)
                If Not (mv_arrObjFields(v_intIndex).Mandatory = False And ctlCheck.Text.Trim.Length = 0) Then
                    'Fill DL lookup tu BDS 
                    v_strSQLCMD = mv_arrObjFields(v_intIndex).LookupList
                    v_strSQLCMD = v_strSQLCMD.Replace("<$BRID>", HO_BRID)
                    v_strSQLCMD = v_strSQLCMD.Replace("<$HO_BRID>", HO_BRID)
                    v_strSQLCMD = v_strSQLCMD.Replace("<$BUSDATE>", Me.BusDate)
                    v_strSQLCMD = v_strSQLCMD.Replace("<$TELLERID>", Me.TellerId)
                    v_strSQLCMD = v_strSQLCMD.Replace("<$AFACCTNO>", "")
                    v_strSQLCMD = v_strSQLCMD.Replace("<$CUSTID>", "")
                    v_strSQLCMD = v_strSQLCMD.Replace("<@KEYVALUE>", "")

                    If Me.UserLanguage = gc_LANG_ENGLISH Then
                        v_strSQLCMD = v_strSQLCMD.Replace("<@CDCONTENT>", "EN_CDCONTENT")
                        v_strSQLCMD = v_strSQLCMD.Replace("<@DESCRIPTION>", "EN_DESCRIPTION")
                    Else
                        v_strSQLCMD = v_strSQLCMD.Replace("<@CDCONTENT>", "CDCONTENT")
                        v_strSQLCMD = v_strSQLCMD.Replace("<@DESCRIPTION>", "DESCRIPTION")
                    End If

                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQLCMD, "")
                    v_ws.Message(v_strObjMsg)
                    v_strFULLDATA = v_strObjMsg
                    v_xmlDocument.LoadXml(v_strObjMsg)
                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                    For i As Integer = 0 To v_nodeList.Count - 1
                        For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                            With v_nodeList.Item(i).ChildNodes(j)
                                If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "VALUE" Then
                                    v_strValue = Trim(.InnerText.ToString)
                                    If v_strFieldValue = v_strValue Then
                                        For k As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                                            With v_nodeList.Item(i).ChildNodes(k)
                                                If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "DISPLAY" Then
                                                    v_strDisplay = Trim(.InnerText.ToString)
                                                End If
                                            End With
                                        Next
                                        ctl = Me.pnRptParaDetail.Controls(mv_arrObjFields(v_intIndex).LabelIndex)
                                        ctl.Top = sender.Top
                                        ctl.Text = v_strDisplay
                                        ctl.Visible = True
                                        v_bolCheck = True
                                        Exit For
                                    End If
                                End If
                            End With
                        Next
                    Next
                    If v_bolCheck = True Then
                        'Hien thi du lieu tu lookup
                        FillLookupData(strFLDNAME, v_strFieldValue, v_strFULLDATA)
                    Else
                        ''Thong bao loi
                        'MessageBox.Show(mv_ResourceManager.GetString("ERR_LOOKUP_VALUE"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'e.Cancel = True
                        'Exit Sub
                    End If
                End If

            End If
            '----------------------------------
            If (v_strFieldValue <> "" And (strFLDNAME = "CIACCTNO" Or strFLDNAME = "CFACCTNO")) Then
                v_strSQLCMD = "SELECT FULLNAME FROM CFMAST WHERE CUSTID=(SELECT CUSTID FROM AFMAST WHERE ACCTNO ='" & v_strFieldValue & "')"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CA_CAMAST, gc_ActionInquiry, v_strSQLCMD, "")
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                If v_nodeList.Count > 0 Then
                    For i As Integer = 0 To v_nodeList.Count - 1
                        For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                            With v_nodeList.Item(i).ChildNodes(j)
                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                v_strValue = Trim(.InnerText)
                                Select Case v_strFLDNAME
                                    Case "FULLNAME"
                                        v_strRefValue = v_strValue
                                End Select
                            End With
                        Next
                    Next
                    If Len(v_strRefValue) > 0 Then
                        ctl = Me.pnRptParaDetail.Controls(mv_arrObjFields(v_intIndex).LabelIndex)
                        ctl.Top = sender.Top
                        ctl.Text = v_strRefValue
                        ctl.Visible = True
                    End If
                End If
            End If
            'TramNN 13/03/2020 lấy giá trị values cho searchcode
            If v_strFieldValue = "" Or v_strFieldValue = "ALL" Then
                mv_arrObjFields(v_intIndex).FieldValue = "%"
            Else
                mv_arrObjFields(v_intIndex).FieldValue = v_strFieldValue
            End If
            'End TramNN 13/03/2020
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Sub

    Private Sub mskData_Validating(ByVal sender As Object)
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        If Me.ActiveControl Is Me.btnCANCEL Then
            OnClose()
            Exit Sub
        End If
        Try
            Dim v_strRefValue, v_strFieldValue, strFLDNAME, v_strSQLCMD, v_strFLDNAME, v_strValue, v_strFIELDCODE As String
            Dim v_intIndex As Integer, ctl As Control, v_bolCheck As Boolean
            Dim v_strObjMsg, v_strTempValue, v_strDEFNAME, v_strSEARCHCODE, v_strKeyVal, v_strKeyName, _
                v_strSEARCHSQL, v_strFULLDATA, v_strDisplay As String
            Dim v_nodeList As Xml.XmlNodeList

            v_intIndex = CType(sender, Control).Tag
            If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                v_strFieldValue = CType(sender, Control).Text
                strFLDNAME = Mid(CType(sender, Control).Name, Len(PREFIXED_MSKDATA) + 1)
            End If

            'Validate custody code     
            v_strDEFNAME = mv_arrObjFields(v_intIndex).ColumnName
            If String.Compare(v_strDEFNAME, "CUSTODYCD") = 0 Then
                v_strTempValue = v_strFieldValue.Replace(".", String.Empty).ToUpper
                If v_strTempValue.Length <> 10 Then
                    MsgBox(Replace(mv_ResourceManager.GetString("Mandatory"), "@", "CUSTODYCD"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Exit Sub
                Else
                    v_strFieldValue = v_strFieldValue.ToUpper
                    CType(sender, Control).Text = v_strFieldValue
                End If
            End If

            'Fill du lieu lookup tu HOST (Fill du lieu cho Refvalue va cac control khac)
            ''Sua lai loi LOOKUP data = 'ALL'
            If Len(mv_arrObjFields(v_intIndex).SearchCode) > 0 And v_strFieldValue <> "ALL" Then
                Dim ctlCheck As Control
                ctlCheck = Me.pnRptParaDetail.Controls(mv_arrObjFields(v_intIndex).ControlIndex)
                If Not (mv_arrObjFields(v_intIndex).Mandatory = False And ctlCheck.Text.Trim.Length = 0) Then
                    'Kiem tra du lieu nhap vao co dung khong
                    v_strSEARCHCODE = mv_arrObjFields(v_intIndex).SearchCode
                    v_strKeyVal = Replace(v_strFieldValue, ".", "")
                    'Lay KeyName
                    v_strSQLCMD = "SELECT SEARCHFLD.FIELDCODE KEYNAME,SEARCH.SEARCHCMDSQL FROM SEARCHFLD,SEARCH " & ControlChars.CrLf _
                        & " WHERE SEARCH.SEARCHCODE = SEARCHFLD.SEARCHCODE " & ControlChars.CrLf _
                        & " AND SEARCHFLD.KEY ='Y' AND SEARCHFLD.SEARCHCODE ='" & v_strSEARCHCODE & "'"
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQLCMD)
                    v_ws.Message(v_strObjMsg)
                    v_xmlDocument.LoadXml(v_strObjMsg)
                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                    If v_nodeList.Count > 0 Then
                        For i As Integer = 0 To v_nodeList.Count - 1
                            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                                With v_nodeList.Item(i).ChildNodes(j)
                                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                    v_strValue = Trim(.InnerText)
                                    Select Case v_strFLDNAME
                                        Case "KEYNAME"
                                            v_strKeyName = Trim(v_strValue)
                                        Case "SEARCHCMDSQL"
                                            v_strSEARCHSQL = Trim(v_strValue)
                                    End Select
                                End With
                            Next
                        Next
                        Dim v_strClause As String
                        v_strSQLCMD = "SELECT *  FROM  (" & v_strSEARCHSQL & ") WHERE REPLACE(" & v_strKeyName & ",'.','')='" & v_strKeyVal & "'"
                        v_strSQLCMD = v_strSQLCMD.Replace("<$BRID>", HO_BRID)
                        v_strSQLCMD = v_strSQLCMD.Replace("<$HO_BRID>", HO_BRID)
                        v_strSQLCMD = v_strSQLCMD.Replace("<$BUSDATE>", Me.BusDate)
                        v_strSQLCMD = v_strSQLCMD.Replace("<$TELLERID>", Me.TellerId)
                        v_strSQLCMD = v_strSQLCMD.Replace("<$AFACCTNO>", "")
                        v_strSQLCMD = v_strSQLCMD.Replace("<$CUSTID>", "")
                        v_strSQLCMD = v_strSQLCMD.Replace("<@KEYVALUE>", mv_Keyvalue)

                        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, gc_ActionInquiry, v_strSQLCMD)
                        v_ws.Message(v_strObjMsg)
                        FillLookupData(strFLDNAME, v_strFieldValue, v_strObjMsg, v_strKeyName)
                        'Fill Refval
                        v_strSQLCMD = "SELECT SEARCHCMDSQL,SE.SEARCHCODE,SEFLD.FIELDCODE, SEARCHFLD.FIELDCODE KEYNAME FROM SEARCH SE,SEARCHFLD SEFLD,SEARCHFLD WHERE SE.SEARCHCODE=SEFLD.SEARCHCODE" & ControlChars.CrLf _
                                    & "AND SE.SEARCHCODE=SEARCHFLD.SEARCHCODE AND SE.SEARCHCODE='" & v_strSEARCHCODE & "' AND SEFLD.REFVALUE='Y' AND SEARCHFLD.KEY='Y'"
                        v_strSQLCMD = v_strSQLCMD.Replace("<$BRID>", HO_BRID)
                        v_strSQLCMD = v_strSQLCMD.Replace("<$HO_BRID>", HO_BRID)
                        v_strSQLCMD = v_strSQLCMD.Replace("<$BUSDATE>", Me.BusDate)
                        v_strSQLCMD = v_strSQLCMD.Replace("<$BUSDATE>", Me.BusDate)
                        v_strSQLCMD = v_strSQLCMD.Replace("<$AFACCTNO>", "")
                        v_strSQLCMD = v_strSQLCMD.Replace("<$CUSTID>", mv_Keyvalue)
                        v_strSQLCMD = v_strSQLCMD.Replace("<@KEYVALUE>", mv_Keyvalue)


                        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQLCMD, "")
                        v_ws.Message(v_strObjMsg)
                        v_xmlDocument.LoadXml(v_strObjMsg)
                        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                        If v_nodeList.Count > 0 Then
                            For i As Integer = 0 To v_nodeList.Count - 1
                                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                                    With v_nodeList.Item(i).ChildNodes(j)
                                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                        v_strValue = Trim(.InnerText)
                                        Select Case v_strFLDNAME
                                            Case "FIELDCODE"
                                                v_strFIELDCODE = Trim(v_strValue)
                                        End Select
                                    End With
                                Next
                            Next
                            v_strSQLCMD = "SELECT " & v_strFIELDCODE & " FROM  (" & v_strSEARCHSQL & ") WHERE REPLACE(" & v_strKeyName & ",'.','')='" & v_strKeyVal & "'"
                            v_strSQLCMD = v_strSQLCMD.Replace("<$BRID>", HO_BRID)
                            v_strSQLCMD = v_strSQLCMD.Replace("<$HO_BRID>", HO_BRID)
                            v_strSQLCMD = v_strSQLCMD.Replace("<$BUSDATE>", Me.BusDate)
                            v_strSQLCMD = v_strSQLCMD.Replace("<$TELLERID>", Me.TellerId)
                            v_strSQLCMD = v_strSQLCMD.Replace("<$AFACCTNO>", "")
                            v_strSQLCMD = v_strSQLCMD.Replace("<$CUSTID>", "")
                            v_strSQLCMD = v_strSQLCMD.Replace("<@KEYVALUE>", mv_Keyvalue)

                            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CA_CAMAST, gc_ActionInquiry, v_strSQLCMD, "")
                            v_ws.Message(v_strObjMsg)
                            v_xmlDocument.LoadXml(v_strObjMsg)
                            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                            If v_nodeList.Count > 0 Then
                                For i As Integer = 0 To v_nodeList.Count - 1
                                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                                        With v_nodeList.Item(i).ChildNodes(j)
                                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                            v_strValue = Trim(.InnerText)
                                            Select Case v_strFLDNAME
                                                Case v_strFIELDCODE
                                                    v_strRefValue = v_strValue
                                            End Select
                                        End With
                                    Next
                                Next
                                If Len(v_strRefValue) > 0 Then
                                    'Fill Refval                                    
                                    ctl = Me.pnRptParaDetail.Controls(mv_arrObjFields(v_intIndex).LabelIndex)
                                    ctl.Top = sender.Top
                                    ctl.Text = v_strRefValue
                                    ctl.Visible = True
                                    mv_strCustName = v_strRefValue
                                End If
                            Else
                            End If
                        End If
                    End If
                End If

            ElseIf mv_arrObjFields(v_intIndex).LookUp = "Y" Then
                Dim ctlCheck As Control
                ctlCheck = Me.pnRptParaDetail.Controls(mv_arrObjFields(v_intIndex).ControlIndex)
                If Not (mv_arrObjFields(v_intIndex).Mandatory = False And ctlCheck.Text.Trim.Length = 0) Then
                    'Fill DL lookup tu BDS 
                    v_strSQLCMD = mv_arrObjFields(v_intIndex).LookupList
                    v_strSQLCMD = v_strSQLCMD.Replace("<$BRID>", HO_BRID)
                    v_strSQLCMD = v_strSQLCMD.Replace("<$HO_BRID>", HO_BRID)
                    v_strSQLCMD = v_strSQLCMD.Replace("<$BUSDATE>", Me.BusDate)
                    v_strSQLCMD = v_strSQLCMD.Replace("<$TELLERID>", Me.TellerId)
                    v_strSQLCMD = v_strSQLCMD.Replace("<$AFACCTNO>", "")
                    v_strSQLCMD = v_strSQLCMD.Replace("<$CUSTID>", "")
                    v_strSQLCMD = v_strSQLCMD.Replace("<@KEYVALUE>", "")

                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQLCMD, "")
                    v_ws.Message(v_strObjMsg)
                    v_strFULLDATA = v_strObjMsg
                    v_xmlDocument.LoadXml(v_strObjMsg)
                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                    For i As Integer = 0 To v_nodeList.Count - 1
                        For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                            With v_nodeList.Item(i).ChildNodes(j)
                                If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "VALUE" Then
                                    v_strValue = Trim(.InnerText.ToString)
                                    If v_strFieldValue = v_strValue Then
                                        For k As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                                            With v_nodeList.Item(i).ChildNodes(k)
                                                If CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value) = "DISPLAY" Then
                                                    v_strDisplay = Trim(.InnerText.ToString)
                                                End If
                                            End With
                                        Next
                                        ctl = Me.pnRptParaDetail.Controls(mv_arrObjFields(v_intIndex).LabelIndex)
                                        ctl.Top = sender.Top
                                        ctl.Text = v_strDisplay
                                        ctl.Visible = True
                                        v_bolCheck = True
                                        Exit For
                                    End If
                                End If
                            End With
                        Next
                    Next
                    If v_bolCheck = True Then
                        'Hien thi du lieu tu lookup
                        FillLookupData(strFLDNAME, v_strFieldValue, v_strFULLDATA)
                    Else
                        ''Thong bao loi
                        'MessageBox.Show(mv_ResourceManager.GetString("ERR_LOOKUP_VALUE"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'e.Cancel = True
                        'Exit Sub
                    End If
                End If

            End If
            '----------------------------------
            If (v_strFieldValue <> "" And (strFLDNAME = "CIACCTNO" Or strFLDNAME = "CFACCTNO")) Then
                v_strSQLCMD = "SELECT FULLNAME FROM CFMAST WHERE CUSTID=(SELECT CUSTID FROM AFMAST WHERE ACCTNO ='" & v_strFieldValue & "')"
                v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CA_CAMAST, gc_ActionInquiry, v_strSQLCMD, "")
                v_ws.Message(v_strObjMsg)
                v_xmlDocument.LoadXml(v_strObjMsg)
                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                If v_nodeList.Count > 0 Then
                    For i As Integer = 0 To v_nodeList.Count - 1
                        For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1 Step 1
                            With v_nodeList.Item(i).ChildNodes(j)
                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                v_strValue = Trim(.InnerText)
                                Select Case v_strFLDNAME
                                    Case "FULLNAME"
                                        v_strRefValue = v_strValue
                                End Select
                            End With
                        Next
                    Next
                    If Len(v_strRefValue) > 0 Then
                        ctl = Me.pnRptParaDetail.Controls(mv_arrObjFields(v_intIndex).LabelIndex)
                        ctl.Top = sender.Top
                        ctl.Text = v_strRefValue
                        ctl.Visible = True
                    End If
                End If
            End If
            'TramNN 13/03/2020 lấy giá trị values cho searchcode
            If v_strFieldValue = "" Or v_strFieldValue = "ALL" Then
                mv_arrObjFields(v_intIndex).FieldValue = "%"
            Else
                mv_arrObjFields(v_intIndex).FieldValue = v_strFieldValue
            End If
            'End TramNN 13/03/2020

        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        Finally
            v_xmlDocument = Nothing
            v_ws = Nothing
        End Try
    End Sub
#End Region

#Region " Form events "
    Private Sub frmReportParameter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitDialog()
    End Sub

    Private Sub btnCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCANCEL.Click
        OnClose()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        OnSubmit()
    End Sub
    Private Sub btnCMP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCMP.Click
        OnCompare()
    End Sub

    Private Sub frmReportParameter_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Dim v_intPos As Int16, ctl As Control, strFLDNAME As String, v_intIndex As Integer

        Select Case e.KeyCode
            Case Keys.Escape
                OnClose()
            Case Keys.F5
                If InStr(Me.ActiveControl.Name, PREFIXED_MSKDATA) > 0 Then
                    v_intIndex = Me.ActiveControl.Tag
                    'Tra cứu thông tin
                    If Len(mv_arrObjFields(v_intIndex).SearchCode) > 0 Then
                        'Dim frm As New frmSearch(Me.UserLanguage)
                        Dim frm As New frmXtraSearchLookup(Me.UserLanguage)
                        frm.TableName = mv_arrObjFields(v_intIndex).SearchCode
                        frm.ModuleCode = mv_arrObjFields(v_intIndex).SrModCode
                        frm.LinkValue = GetFieldValueByName(mv_arrObjFields(v_intIndex).TagField) 'mv_Keyvalue
                        frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                        frm.IsLocalSearch = gc_IsNotLocalMsg
                        frm.IsLookup = "Y"
                        frm.SearchOnInit = False
                        frm.BranchId = Me.BranchId
                        frm.TellerId = Me.TellerId
                        frm.ShowDialog()
                        Me.ActiveControl.Text = frm.ReturnValue
                        If Len(frm.RefValue) > 0 Then
                            ctl = Me.pnRptParaDetail.Controls(mv_arrObjFields(v_intIndex).LabelIndex)
                            ctl.Top = Me.ActiveControl.Top
                            ctl.Text = frm.RefValue
                            ctl.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                            ctl.ForeColor = System.Drawing.Color.Blue
                            ctl.Visible = True
                        End If
                        frm.Dispose()

                    ElseIf mv_arrObjFields(v_intIndex).LookUp = "Y" Then
                        Dim frm As New frmLookUp(UserLanguage)
                        frm.SQLCMD = mv_arrObjFields(v_intIndex).LookupList
                        frm.ShowDialog()
                        v_intPos = InStr(frm.RETURNDATA, vbTab)
                        If v_intPos > 0 Then
                            Me.ActiveControl.Text = Mid(frm.RETURNDATA, 1, v_intPos - 1)
                            ctl = Me.pnRptParaDetail.Controls(mv_arrObjFields(v_intIndex).LabelIndex)
                            ctl.Top = Me.ActiveControl.Top
                            ctl.Text = Mid(frm.RETURNDATA, v_intPos + 1)
                            ctl.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                            ctl.ForeColor = System.Drawing.Color.Blue
                            ctl.Visible = True

                            'Nạp các giá trị tương ứng cho các trư?ng kh�ác
                            strFLDNAME = Mid(ActiveControl.Name, Len(PREFIXED_MSKDATA) + 1)
                            '  FillLookupData(strFLDNAME, Mid(frm.RETURNDATA, 1, v_intPos - 1), frm.FULLDATA)
                        End If
                        frm.Dispose()
                    End If
                End If
            Case Keys.Enter
                If InStr(CType(Me.ActiveControl, Control).Name, PREFIXED_MSKDATA) > 0 Then
                    SendKeys.Send("{Tab}")
                    e.Handled = True
                End If
        End Select
    End Sub

#End Region

#Region "Other method"
    Private Function GetRptPendingFilePath(ByVal pv_strRptID As String) As String
        Return "_REQUEST" & "_" & BranchId & "_" & TellerId & "_" & pv_strRptID & "_.xml"
    End Function

    Private Function GetRptTempFilePathStandard(ByVal pv_strRptID As String) As String
        Return pv_strRptID & TellerId & ".prnx"
    End Function

    Private Function GetRptTemplateFilePath(ByVal pv_strRptID As String) As String
        Return pv_strRptID & ".rpt"
    End Function

    Private Function GetRptTempFilePath(ByVal pv_strRptID As String) As String
        Return pv_strRptID & TellerId & ".rpt"
    End Function

    Private Function GetBatchRptTempFilePath(ByVal pv_strRptID As String, ByVal pv_strAFACCTNO As String) As String
        Return pv_strAFACCTNO & pv_strRptID & ".pdf"
    End Function
    Private Function GetBatchRptTempFilePath(ByVal pv_strRptID As String, ByVal pv_strAFACCTNO As String, ByVal pv_strCUSTODYCD As String) As String
        Return pv_strCUSTODYCD & pv_strAFACCTNO & pv_strRptID & ".pdf"
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
                    If v_ds.Tables.Count > 0 Then
                        v_ds.Tables(0).TableName = "RptData"
                    End If
                    Return v_ds
                Else    'Asynchronous report
                    ''Delete old data
                    'Dim v_strFile As String = ReportTempDirectory & GetRptTempFilePath(CMDID)
                    'File.Delete(v_strFile)

                    ''Ghi ra file voi trang thai PENDING
                    ''Dim v_streamWriter As New StreamWriter(ReportTempDirectory & GetRptPendingFilePath(CMDID))
                    'Dim v_streamWriter As New StreamWriter(ReportTempDirectory & v_strDataXML)
                    'v_streamWriter.Write(v_strDataXSD)
                    'v_streamWriter.Flush()
                    'v_streamWriter.Close()

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
    Private Sub OnCompare()
        Try

            'Change mouse's pointer
            Me.Cursor.Current = Cursors.WaitCursor

            If Not VerifyRules() Then
                'Change mouse's pointer
                Me.Cursor.Current = Cursors.Default
                Exit Sub
            End If
            ''Khoi tao ReportParam
            PrepareReportParams(String.Empty)
            ''Tao form đoi chieu
            Dim v_frm As New frmSearchCMP2FILE(Me.UserLanguage)
            v_frm.FULLDATA = "RPT"
            v_frm.Searchcode = Me.StoredName
            v_frm.ModuleCode = Me.ModuleCode
            v_frm.BranchId = Me.BranchId
            v_frm.TellerId = Me.TellerId
            v_frm.IpAddress = Me.IpAddress
            v_frm.WsName = Me.WsName
            v_frm.BusDate = Me.BusDate
            v_frm.Desc = Me.ReportTitle
            v_frm.ISRPT = "Y"
            v_frm.mv_strStoredname = Me.StoredName
            v_frm.mv_intNumOfParam = mv_intNumOfParam
            v_frm.mv_arrRptParam = mv_arrRptParam
            v_frm.ShowDialog()
            'Change mouse's pointer
            Me.Cursor.Current = Cursors.WaitCursor
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

    Public Function CreateReportFactory(ByVal v_ds As DataSet, Optional ByVal acctNo As String = "", Optional ByVal custodyCd As String = "") As Boolean
        Dim result As Boolean = False
        Try
            If Me.ISADHOC = "N" Then
                result = CreateReportXtraReport(v_ds, acctNo, custodyCd)
            Else
                result = IIf(String.IsNullOrEmpty(acctNo) Or String.IsNullOrEmpty(custodyCd), CreateReport(v_ds, String.Empty), CreateReport(v_ds, acctNo, custodyCd))
            End If

            If result Then
                MessageBox.Show(mv_ResourceManager.GetString("frmReportParameter.ReCreateSucessfully"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            result = False
        End Try
        Return result

    End Function

    Public Function GetPnRptParaDetail() As Panel
        Return Me.pnRptParaDetail
    End Function

    Public Sub PrepareReportParams2(ByVal vstrAFACCTNO As String)
        Dim v_xmlDocument As New XmlDocumentEx
        Dim v_xmlNodeList As Xml.XmlNodeList
        Try
            Dim v_obj As ReportParameters, i, v_intParams, v_intPublic, v_intOffset, v_intIndex As Integer, v_ctrl As Control
            Dim v_strLookupData, v_strFLDNAME, v_strVALUE, v_strParamValue, v_strParamDesc As String

            v_intPublic = IIf(IsPublic = "Y", 2, 0)
            v_intOffset = IIf(IsPublic = "Y", -1, 1)
            mv_intNumOfParam = mv_arrObjFields.GetLength(0) - 1
            ReDim mv_arrRptParam(mv_intNumOfParam + v_intOffset)    'Mac dinh la bao gom tat ca gia tri trong errObjFields la tham so

            'Bao gồm cả 02 tham số mặc định OPT và BRID: Chi su dung cho IsPublic=Y
            'OPT
            v_obj = New ReportParameters
            v_obj.ParamName = "OPT"
            v_obj.ParamCaption = mv_ResourceManager.GetString("frmReportParameter.ReportArea")
            v_obj.ParamValue = ReportArea
            Select Case ReportArea
                Case gc_REPORT_AREA_ALL
                    v_obj.ParamDescription = mv_ResourceManager.GetString("frmReportParameter.ReportArea.All")
                Case gc_REPORT_AREA_BRANCH
                    v_obj.ParamDescription = mv_ResourceManager.GetString("frmReportParameter.ReportArea.Branch")
                Case gc_REPORT_AREA_AGENT
                    v_obj.ParamDescription = mv_ResourceManager.GetString("frmReportParameter.ReportArea.Agent")
            End Select
            v_obj.ParamSize = ReportArea.Length()
            v_obj.ParamType = ReportArea.GetType().ToString()
            mv_arrRptParam(0) = v_obj

            'BRID
            v_obj = New ReportParameters
            v_obj.ParamName = "BRID"
            v_obj.ParamValue = BranchId
            v_obj.ParamSize = BranchId.Length()
            v_obj.ParamType = BranchId.GetType().ToString()
            mv_arrRptParam(1) = v_obj

            If mv_intNumOfParam > 0 Then
                v_intParams = 0 'Starting
                For i = v_intPublic To mv_intNumOfParam - 1
                    If mv_arrObjFields(i).IsParam = "Y" Then
                        v_obj = New ReportParameters
                        v_obj.ParamName = mv_arrObjFields(i).FieldName
                        v_obj.ParamCaption = mv_arrObjFields(i).Caption
                        v_obj.ParamValue = String.Empty
                        'Lay control tren man hinh & xac dinh value
                        v_intIndex = mv_arrObjFields(i).ControlIndex
                        v_ctrl = Me.pnRptParaDetail.Controls(v_intIndex)
                        If mv_arrObjFields(i).ControlType = "C" Then
                            v_obj.ParamValue = CType(v_ctrl, ComboBoxEx).SelectedValue
                        ElseIf IsPublic = "Y" And vstrAFACCTNO.Length > 0 _
                                    And (mv_arrObjFields(i).FieldName = "CIACCTNO" Or mv_arrObjFields(i).FieldName = "AFACCTNO") Then
                            v_obj.ParamValue = vstrAFACCTNO
                        Else
                            v_obj.ParamValue = Strings.UCase(v_ctrl.Text.Trim())
                        End If
                        'Dung gia tri tham so
                        v_strLookupData = mv_arrLookupData(i)
                        If (v_strLookupData.Length() > 0) Then
                            v_xmlDocument.LoadXml(v_strLookupData)
                            v_xmlNodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                            For j As Integer = 0 To v_xmlNodeList.Count - 1
                                For k As Integer = 0 To v_xmlNodeList.Item(j).ChildNodes.Count - 1
                                    With v_xmlNodeList.Item(j).ChildNodes(k)
                                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                        v_strVALUE = .InnerText.ToString

                                        Select Case v_strFLDNAME.Trim()
                                            Case "VALUE"
                                                v_strParamValue = v_strVALUE.Trim()
                                            Case "DISPLAY"
                                                v_strParamDesc = v_strVALUE.Trim()
                                        End Select
                                    End With
                                Next
                                If (v_strParamValue = v_obj.ParamValue.ToString()) Then
                                    v_obj.ParamDescription = v_strParamDesc
                                    Exit For
                                End If
                            Next
                        Else
                            v_obj.ParamDescription = v_obj.ParamValue.ToString()
                        End If

                        v_obj.ParamSize = mv_arrObjFields(i).FieldLength
                        Select Case mv_arrObjFields(i).FieldType
                            Case "M", "T", "C"
                                v_obj.ParamType = GetType(System.String).Name
                            Case "D"
                                v_obj.ParamType = GetType(System.DateTime).Name
                            Case "N"
                                v_obj.ParamType = GetType(Double).Name
                            Case Else
                                v_obj.ParamType = mv_arrObjFields(i).FieldType
                        End Select
                        mv_arrRptParam(v_intParams + v_intPublic + 2) = v_obj
                        v_intParams = v_intParams + 1
                    End If
                Next
            End If
            'Bao gồm cả 02 tham số mặc định OPT và BRID
            mv_intNumOfParam = v_intParams + 1 + v_intOffset
            ReDim Preserve mv_arrRptParam(mv_intNumOfParam - 1) 'Phan tu mang bat dau tu 0
        Catch ex As Exception
            Throw ex
        Finally
            v_xmlDocument = Nothing
        End Try
    End Sub

    Public Function getIntNumOfParam() As Integer
        Return mv_intNumOfParam
    End Function

    Public Function getArrRptParam() As ReportParameters()
        Return mv_arrRptParam
    End Function

End Class
