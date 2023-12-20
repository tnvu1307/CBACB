
Imports System.IO
Imports System.Xml
Imports CommonLibrary.modCommond
Imports CommonLibrary
Imports DevExpress.Data.Filtering
Imports DevExpress.Utils
Imports DevExpress.XtraBars
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Windows.Forms
Imports System.Drawing
Imports AppCore
Imports DevExpress.XtraEditors
Imports DevExpress.XtraTab

Public Class frmSyncFIIN
    Inherits System.Windows.Forms.Form
#Region " Contructor "
    'Public Sub New()

    '    DevExpress.UserSkins.BonusSkins.Register()
    '    DevExpress.Skins.SkinManager.EnableFormSkins()

    '    ' This call is required by the designer.
    '    InitializeComponent()

    '    ' Add any initialization after the InitializeComponent() call.
    '    mv_strLanguage = gc_LANG_VIETNAMESE
    'End Sub

    'Public Sub New(ByVal pv_strLanguage As String)

    '    ' This call is required by the designer.
    '    InitializeComponent()

    '    ' Add any initialization after the InitializeComponent() call.
    '    mv_strLanguage = pv_strLanguage
    'End Sub
#End Region

#Region " Khai báo hằng, biến "
    Const c_ResourceManager = "_DIRECT.frmSyncFIIN-"
    'Const c_ResourceManager = "AppCore.frmSearch-"
    Dim mv_dblTR_QTTY As Double = 0
    Protected WithEvents SearchCell As Xceed.Grid.Cell
    Public mv_strSearchFilter As String
    Public mv_strSearchFilterStore As String
    Public hFilter As New Hashtable
    Public hFilterStore As New Hashtable
    Public mv_frmTransactScreen As frmXtraTransact

    Public mv_blnAutoSearch As Boolean = False
    Public mv_blSEQNUM As Boolean = False

    'Khai bao cac bien cho khop lenh bang tay
    Public mv_strCONFIRM_NO As String = String.Empty
    Public mv_strCUSTODYCD As String = String.Empty
    Public mv_strB_CUSTODYCD As String = String.Empty
    Public mv_strS_CUSTODYCD As String = String.Empty
    Public mv_strBORS As String = String.Empty
    Public mv_strSEC_CODE As String = String.Empty
    Public mv_intQUANTITY As Integer = 0
    Public mv_intB_QUANTITY As Integer = 0
    Public mv_intS_QUANTITY As Integer = 0
    Public mv_dblPRICE As Double = 0
    Public mv_strMATCH_DATE As String = String.Empty
    Public v_strS_ACCOUNT_NO As String = String.Empty
    Public v_strB_ACCOUNT_NO As String = String.Empty
    Public v_strS_ORDER_NO As String = String.Empty
    Public v_strB_ORDER_NO As String = String.Empty

    Private mv_strCommandType As String = gc_CommandText
    Private mv_strBANKINQ As String = ""
    Private mv_strBANKACCT As String = ""
    Private mv_strCondDefFld As String = ""
    Private mv_strStoreName As String = ""
    Private mv_strStoreParam As String = ""
    Private mv_blnLoadLastSearch As Boolean = True
    Private mv_strCMDTYPE As String
    Protected mv_strTableName As String
    Private mv_strCaption As String
    Private mv_strEnCaption As String
    Private mv_strKeyColumn As String
    Private mv_strKeyFieldType As String
    Private mv_strRefColumn As String
    Private mv_strRefFieldType As String
    Protected mv_strCmdSql As String
    Protected mv_ISFLTCODEID As String = "N"
    Protected mv_ISFLTMBCODE As String = "N"
    Protected mv_strCmdSqlTemp As String
    Private mv_strcmdMenu As String
    Private mv_strTLTXCD As String
    Protected mv_strSrOderByCmd As String
    Protected mv_strObjName As String
    Private mv_strSearchAuthCode As String = ""
    Private mv_strRowLimit As String
    Private mv_strMenuType As String
    Private mv_strFormName As String
    Private mv_intSearchNum As Integer
    Private mv_strModuleCode As String
    Private mv_strLocalObject As String
    Private mv_strIsLocalSearch As String
    Private mv_blnSearchOnInit As Boolean
    Private mv_strAuthCode As String
    Private mv_strAuthString As String
    Private mv_strSearchByTransact As Boolean = False
    Private mv_strIsLookup As String = "N"
    Private mv_strReturnValue As String
    Private mv_strRefValue As String
    Private mv_strReturnData As String
    Private mv_strXMLData As String
    Private mv_intDblGrid As Integer = 0
    Private mv_strIpAddress As String
    Private mv_strWsName As String
    Private mv_isAutoSubmitWhenExecue As Boolean = False
    Private mv_isQuickSearch As Boolean = False

    Private mv_arrSrFieldOperator() As String                   'Danh sách các toán tử đi?u kiện
    Private mv_arrSrOperator() As String                        'Mảng các toán tử đi?u kiện
    Private mv_arrSrSQLRef() As String                          'Câu lệnh SQL liên quan
    Private mv_arrSrFieldType() As String                       'Loại dữ liệu của trư?ng
    Protected mv_arrSrFieldSrch() As String                       'Tên các trư?ng làm tiêu chí để tìm kiếm
    Private mv_arrSrFieldDisp() As String                       'Tên các trư?ng sẽ hiển thị trên Combo
    Private mv_arrSrFieldMask() As String                       'Mặt nạ nhập dữ liệu
    Private mv_arrStFieldDefValue() As String                   'Giá trị mặc định
    Protected mv_arrSrFieldFormat() As String                     '?ịnh dạng dữ liệu
    Private mv_arrSrFieldDisplay() As String                    'Có hiển thị trên lưới không
    Private mv_arrSrFieldWidth() As Integer                     'Dộ rộng hiển thị trên lưới
    Private mv_arrStrTLTXCD() As String
    Private mv_arrStrTLTXNAME As Hashtable
    Private mv_arrStrTLTXMAPFLD As Hashtable                    'Mapping giao dich
    Private mv_arrStrTLTXNAMEREF As Hashtable                   'Cho filter
    Private mv_arrStrTLTXMAPFLDREF As Hashtable

    Private mv_arrStFieldMandartory() As String                  'Có bắt buộc nhập điều kiện tìm kiếm không M. Mandartory, Y. Yes but optional
    Private mv_arrStFieldMultiLang() As String                   'Có đa ngôn ngữ không
    Private mv_arrStFieldRefCDType() As String                   '
    Private mv_arrStFieldRefCDName() As String                   '
    Private mv_arrStQuickSearch() As String                   '
    Private mv_arrStSummaryCode() As String                   '

    Private mv_strLanguage As String
    Private mv_ResourceManager As Resources.ResourceManager

    Private mv_strBranchId As String
    Private mv_strTellerId As String
    Private mv_strTellerRight As String
    Protected mv_strGroupCareBy As String
    Protected mv_intpage As Int32 = 1
    Protected mv_rowpage As Int32 = 0
    Private mv_strBusDate As String
    Private mv_strTimesearch As String
    Private mv_strCUSTID As String
    Private mv_strAFACCTNO As String


    Private mv_SelectedRow As Xceed.Grid.Row

    Private mv_strEnableSearchFilter As Boolean = True
    Private mv_strLinkValue As String
    Private mv_strLinkFieldSrc As String
    Private mv_strLinkFieldDes As String
    Private mv_strNextDate As String
    Private mv_strCompanyCode As String
    Private mv_strCompanyName As String
    Private mv_strParentObjName As String
    Private mv_strParentClause As String

    Private mv_strDefaultSearchFilter As String = String.Empty

    Public mv_frmSearchScreen As frmSearch

    'Variables used for CareBy filter - Modified by TungNT
    Protected mv_isCareBy As Boolean = False
    'End Modified
    Protected mv_strSymbolList As String
    Protected mv_SymbolTable As New DataTable

    Private mv_strIsSMS As String
    Private mv_strIsEMAIL As String
    Private mv_SearchData As DataSet
    Private mv_intTotalRow As Integer
    Private mv_intTotalCountRow As Integer
    Private gvSearchSelection As GridCheckMarksSelection
    Public mv_strSearchClause As String = ""
    Public mv_strTellerName As String
    Private m_BusLayer As CBusLayer = Nothing

    'For Popup Menu
    Private mv_PopupMenuItem() As DevExpress.Utils.Menu.DXMenuItem

#End Region

#Region " Các thuộc tính của form "

    Public Property CompanyCode() As String
        Get
            Return mv_strCompanyCode
        End Get
        Set(ByVal Value As String)
            mv_strCompanyCode = Value
        End Set
    End Property
    Public Property CompanyName() As String
        Get
            Return mv_strCompanyName
        End Get
        Set(ByVal Value As String)
            mv_strCompanyName = Value
        End Set
    End Property
    Public Property StoreName() As String
        Get
            Return mv_strStoreName
        End Get
        Set(ByVal Value As String)
            mv_strStoreName = Value
        End Set
    End Property
    Public Property StoreParam() As String
        Get
            Return mv_strStoreParam
        End Get
        Set(ByVal Value As String)
            mv_strStoreParam = Value
        End Set
    End Property
    Public Property CommandType() As String
        Get
            Return mv_strCommandType
        End Get
        Set(ByVal Value As String)
            mv_strCommandType = Value
        End Set
    End Property

    Public Property LoadLastFilter() As Boolean
        Get
            Return mv_blnLoadLastSearch
        End Get
        Set(ByVal Value As Boolean)
            mv_blnLoadLastSearch = Value
        End Set
    End Property

    Public Property DefaultSearchFilter() As String
        Get
            Return mv_strDefaultSearchFilter
        End Get
        Set(ByVal Value As String)
            mv_strDefaultSearchFilter = Value
        End Set
    End Property

    Public Property CUSTID() As String
        Get
            Return mv_strCUSTID
        End Get
        Set(ByVal Value As String)
            mv_strCUSTID = Value
        End Set
    End Property

    Public Property AFACCTNO() As String
        Get
            Return mv_strAFACCTNO
        End Get
        Set(ByVal Value As String)
            mv_strAFACCTNO = Value
        End Set
    End Property
    Public Property isAutoSearch() As Boolean
        Get
            Return mv_blnAutoSearch
        End Get
        Set(ByVal Value As Boolean)
            mv_blnAutoSearch = Value
        End Set
    End Property

    Public Property AutoSubmitWhenExecute() As Boolean
        Get
            Return mv_isAutoSubmitWhenExecue
        End Get
        Set(ByVal Value As Boolean)
            mv_isAutoSubmitWhenExecue = Value
        End Set
    End Property

    Public Property CMDMenu() As String
        Get
            Return mv_strcmdMenu
        End Get
        Set(ByVal Value As String)
            mv_strcmdMenu = Value
        End Set
    End Property


    Public Property Timesearch() As String
        Get
            Return mv_strTimesearch
        End Get
        Set(ByVal Value As String)
            mv_strTimesearch = Value
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

    Public Property LinkValue() As String
        Get
            Return mv_strLinkValue
        End Get
        Set(ByVal Value As String)
            mv_strLinkValue = Value
        End Set
    End Property

    Public Property LinkFieldSrc() As String
        Get
            Return mv_strLinkFieldSrc
        End Get
        Set(ByVal Value As String)
            mv_strLinkFieldSrc = Value
        End Set
    End Property

    Public Property LinkFieldDes() As String
        Get
            Return mv_strLinkFieldDes
        End Get
        Set(ByVal Value As String)
            mv_strLinkFieldDes = Value
        End Set
    End Property

    Public Property EnableSearchFilter() As Boolean
        Get
            Return mv_strEnableSearchFilter
        End Get
        Set(ByVal Value As Boolean)
            mv_strEnableSearchFilter = Value
        End Set
    End Property

    Public Property NextDate() As String
        Get
            Return mv_strNextDate
        End Get
        Set(ByVal Value As String)
            mv_strNextDate = Value
        End Set
    End Property

    Public Property FULLDATA() As String
        Get
            Return mv_strXMLData
        End Get
        Set(ByVal Value As String)
            mv_strXMLData = Value
        End Set
    End Property

    Public Property RETURNDATA() As String
        Get
            Return mv_strReturnData
        End Get
        Set(ByVal Value As String)
            mv_strReturnData = Value
        End Set
    End Property

    Public Property ReturnValue() As String
        Get
            Return mv_strReturnValue
        End Get
        Set(ByVal Value As String)
            mv_strReturnValue = Value
        End Set
    End Property

    Public Property RefValue() As String
        Get
            Return mv_strRefValue
        End Get
        Set(ByVal Value As String)
            mv_strRefValue = Value
        End Set
    End Property

    Public Property IsLookup() As String
        Get
            Return mv_strIsLookup
        End Get
        Set(ByVal Value As String)
            mv_strIsLookup = Value
        End Set
    End Property

    Public Property TableName() As String
        Get
            Return mv_strTableName
        End Get
        Set(ByVal Value As String)
            mv_strTableName = Value
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

    Public Property FormCaption() As String
        Get
            Return mv_strCaption
        End Get
        Set(ByVal Value As String)
            mv_strCaption = Value
        End Set
    End Property

    Public Property KeyColumn() As String
        Get
            Return mv_strKeyColumn
        End Get
        Set(ByVal Value As String)
            mv_strKeyColumn = Value
        End Set
    End Property

    Public Property KeyFieldType() As String
        Get
            Return mv_strKeyFieldType
        End Get
        Set(ByVal Value As String)
            mv_strKeyFieldType = Value
        End Set
    End Property

    Public Property ObjectName() As String
        Get
            Return mv_strObjName
        End Get
        Set(value As String)
            mv_strObjName = value
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

    Public ReadOnly Property MaintenanceFormName() As String
        Get
            Return mv_strFormName
        End Get
    End Property

    Public Property MenuType() As String
        Get
            Return mv_strMenuType
        End Get
        Set(ByVal Value As String)
            mv_strMenuType = Value
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

    Public Property IsLocalSearch() As String
        Get
            Return mv_strIsLocalSearch
        End Get
        Set(ByVal Value As String)
            mv_strIsLocalSearch = Value
        End Set
    End Property

    Public Property SearchOnInit() As Boolean
        Get
            Return mv_blnSearchOnInit
        End Get
        Set(ByVal Value As Boolean)
            mv_blnSearchOnInit = Value
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

    Public Property TellerRight() As String
        Get
            Return mv_strTellerRight
        End Get
        Set(ByVal Value As String)
            mv_strTellerRight = Value
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

    Public ReadOnly Property ResourceManager() As Resources.ResourceManager
        Get
            Return mv_ResourceManager
        End Get
    End Property

    'Visible button
    Public Property AuthCode() As String
        Get
            Return mv_strAuthCode
        End Get
        Set(ByVal Value As String)
            mv_strAuthCode = Value
        End Set
    End Property

    'Enable button
    Public Property AuthString() As String
        Get
            Return mv_strAuthString
        End Get
        Set(ByVal Value As String)
            mv_strAuthString = Value
        End Set
    End Property
    Public Property SearchByTransact() As Boolean
        Get
            Return mv_strSearchByTransact
        End Get
        Set(ByVal Value As Boolean)
            mv_strSearchByTransact = Value
        End Set
    End Property
    Public Property SEQNUM() As Boolean
        Get
            Return mv_blSEQNUM
        End Get
        Set(ByVal Value As Boolean)
            mv_blSEQNUM = Value
        End Set
    End Property

    Public Property CMDTYPE() As String
        Get
            Return mv_strCMDTYPE
        End Get
        Set(ByVal Value As String)
            mv_strCMDTYPE = Value
        End Set
    End Property


    'Modified by TungNT
    Public Property CareByFilter() As Boolean
        Get
            Return mv_isCareBy
        End Get
        Set(ByVal Value As Boolean)
            mv_isCareBy = Value
        End Set
    End Property
    'End Modified
    Public Property SymbolList() As String
        Get
            Return mv_strSymbolList
        End Get
        Set(ByVal Value As String)
            mv_strSymbolList = Value
        End Set
    End Property

    Public Property SymbolTable() As DataTable
        Get
            Return mv_SymbolTable
        End Get
        Set(ByVal Value As DataTable)
            mv_SymbolTable = Value
        End Set
    End Property

    Public Property ParentObjName() As String
        Get
            Return mv_strParentObjName
        End Get
        Set(ByVal Value As String)
            mv_strParentObjName = Value
        End Set
    End Property

    Public Property ParentClause() As String
        Get
            Return mv_strParentClause
        End Get
        Set(ByVal Value As String)
            mv_strParentClause = Value
        End Set
    End Property


#End Region





    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        UserLanguage = pv_strLanguage
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub
    Protected Overridable Function ShowForm(ByVal pv_intExecFlag As Integer) As DialogResult
        'Select Case pv_intExecFlag
        '    Case ExecuteFlag.AddNew
        '        bbiNew.Caption = mv_ResourceManager.GetString("ExecuteFlag.AddNew")
        '    Case ExecuteFlag.View
        '        bbiView.Caption = mv_ResourceManager.GetString("ExecuteFlag.View")
        '    Case ExecuteFlag.Edit
        '        bbiEdit.Caption = mv_ResourceManager.GetString("ExecuteFlag.Edit")
        '    Case ExecuteFlag.Delete
        '        bbiDelete.Caption = mv_ResourceManager.GetString("ExecuteFlag.Delete")
        '    Case ExecuteFlag.SendSMS
        '        ' = mv_ResourceManager.GetString("ExecuteFlag.SendSMS")
        '    Case ExecuteFlag.Email
        '        'ssbPanelExecFlag.Text = mv_ResourceManager.GetString("ExecuteFlag.Email")
        'End Select
    End Function



    Protected Function BuildSearchMessage(v_intFrom As Integer, v_intTo As Integer, pv_strModule As String) As String
        Dim i As Integer
        'If mv_isQuickSearch And grpQuickSearch.Visible Then
        '    BuildQuickCriterial()
        'Else
        '    BuildCriterial()
        'End If


        mv_strSearchFilterStore &= "||" & "<$MBID>" & ":" & Me.BranchId
        mv_strSearchFilterStore &= "||" & "<$HO_MBID>" & ":" & HO_MBID
        mv_strSearchFilterStore &= "||" & "<$BUSDATE>" & ":" & Me.BusDate
        mv_strSearchFilterStore &= "||" & "<$AFACCTNO>" & ":" & Me.AFACCTNO
        mv_strSearchFilterStore &= "||" & "<$CUSTID>" & ":" & Me.CUSTID
        mv_strSearchFilterStore &= "||" & "<@KEYVALUE>" & ":" & LinkValue
        mv_strSearchFilterStore &= "||" & "<$TELLERID>" & ":" & Me.TellerId

        If Me.UserLanguage = gc_LANG_ENGLISH Then
            mv_strSearchFilterStore = mv_strSearchFilterStore.Replace("<@CDCONTENT>", "EN_CDCONTENT")
            mv_strSearchFilterStore = mv_strSearchFilterStore.Replace("<@DESCRIPTION>", "EN_DESCRIPTION")
        Else
            mv_strSearchFilterStore = mv_strSearchFilterStore.Replace("<@CDCONTENT>", "CDCONTENT")
            mv_strSearchFilterStore = mv_strSearchFilterStore.Replace("<@DESCRIPTION>", "DESCRIPTION")
        End If

        StoreParam = "p_GET_TOTAL_ROW!0!Double!20" & _
                     "^p_FROM_ROW!" & v_intFrom & "!Double!20" & _
                     "^p_TO_ROW!" & v_intTo & "!Double!20" & _
                     "^p_PARA_STRING!" & mv_strSearchFilterStore & "!String!4000"

        Return BuildXMLObjMsg(, , , , IsLocalSearch, gc_MsgTypeObj, pv_strModule, _
                              gc_ActionInquiry, StoreName, StoreParam, , , , "L", , , CommandType)
    End Function

    Private Sub BuildCriterial()
        'TODO: build criterial from filter control
    End Sub


    Protected Overridable Function GetRowPage() As Int32
        Dim v_strCmdInquiry As String
        Dim v_strRowPage As String = String.Empty
        v_strCmdInquiry = "select VARVALUE from SYSVAR where VARNAME='ROWPERPAGE'"
        Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_SEARCHFLD, gc_ActionInquiry, v_strCmdInquiry, , )
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        v_ws.Message(v_strObjMsg)
        Dim v_xmlDocument As New System.Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_nodeEntry As Xml.XmlNode
        Dim v_strFLDNAME As String
        Dim v_strValue As String
        Dim RowPage As Int32
        Try
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString
                        Select Case Trim(v_strFLDNAME)
                            Case "VARVALUE"
                                v_strRowPage = Trim(v_strValue)
                                Exit For
                        End Select
                    End With
                Next
            Next
            RowPage = CInt(v_strRowPage)
            Return RowPage
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return 0
        End Try
    End Function

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub


    Protected Overridable Sub ExecuteCA(ByVal v_strKeyColumn As String)

    End Sub

    Protected Overridable Sub ExecuteCA_Money(ByVal v_strKeyColumn As String)

    End Sub

    Protected Overridable Sub ExecuteCA_Securities(ByVal v_strKeyColumn As String)

    End Sub

    Protected Overridable Sub ExecuteOD9996(ByVal v_strKeyColumn As String)

    End Sub

    Protected Overridable Sub ConfirmCA(ByVal v_strKeyColumn As String)

    End Sub

    Protected Overridable Sub ProcessOrder(ByVal pv_TableName As String, ByVal pv_GridRow As Xceed.Grid.DataRow)

    End Sub

    Protected Overridable Function SetPaymentOrderList(ByRef v_strObjMsg As String) As Int32

    End Function

    Protected Overridable Sub PrintPaymentOrder(ByVal pv_strVoucherID As String, Optional ByVal blnPrePrint As Double = False)

    End Sub

    Protected Overridable Function OnExecute(ByRef v_strObjMsg As String, ByVal pv_intRow As Integer, ByRef blnFlag As Boolean) As Int32

    End Function

    Protected Overridable Sub RegisterOnline(ByRef pv_AUTOID As String, ByRef pv_CustomerType As String, ByRef pv_CustomerName As String, _
                                             ByRef pv_CustomerBirth As String, ByRef pv_IDType As String, ByRef pv_IDCode As String, _
                                             ByRef pv_Iddate As String, ByRef pv_Idplace As String, ByRef pv_Expiredate As String, _
                                             ByRef pv_Address As String, ByRef pv_Taxcode As String, ByRef pv_PrivatePhone As String, _
                                             ByRef pv_Mobile As String, ByRef pv_Fax As String, ByRef pv_Email As String, _
                                             ByRef pv_Office As String, ByRef pv_Position As String, ByRef pv_Country As String, _
                                             ByRef pv_CustomerCity As String, ByRef pv_TKTGTT As String)

    End Sub



    'Get TLTXCD for Execute button

    'On press TLTXCD



#Region " Other methods "
    Public Sub PrepareArrayOfALLCODE(ByVal pv_strUserLanguage As String, ByVal pv_strObjMsg As String, _
                                     ByRef pv_arrALLCODE As Hashtable, ByRef pv_arrALLCODEREF As Hashtable)
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strValue, v_strCDVAL, v_strCDVALREF, v_strDISPLAY, v_strENDISPLAY As String
        Dim v_intFieldCount As Integer
        Try
            v_xmlDocument.LoadXml(pv_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            v_intFieldCount = v_nodeList.Count
            pv_arrALLCODE = New Hashtable()
            pv_arrALLCODEREF = New Hashtable()
            For i As Integer = 0 To v_intFieldCount - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString
                        Select Case Trim(v_strFLDNAME)
                            Case "VALUE"
                                v_strCDVAL = Trim(v_strValue)
                            Case "VALUECD"
                                v_strCDVALREF = Trim(v_strValue)
                            Case "DISPLAY"
                                v_strDISPLAY = Trim(v_strValue)
                            Case "EN_DISPLAY"
                                v_strENDISPLAY = Trim(v_strValue)
                        End Select
                    End With
                Next
                If Not pv_arrALLCODE.ContainsKey(v_strCDVAL) Then
                    If pv_strUserLanguage = "EN" Then
                        pv_arrALLCODE.Add(v_strCDVAL, v_strENDISPLAY)
                    Else
                        pv_arrALLCODE.Add(v_strCDVAL, v_strDISPLAY)
                    End If
                    pv_arrALLCODEREF.Add(v_strCDVAL, v_strCDVALREF)
                End If
            Next
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub

    Public Sub PrepareSearchParamsAdv(ByVal pv_strUserLanguage As String, ByVal pv_strObjMsg As String, ByRef pv_strSrTitle As String, ByRef pv_strSrEnTitle As String, _
                                   ByRef pv_strSrCmd As String, ByRef pv_strSrObjName As String, _
                                   ByRef pv_strFrmName As String, ByRef pv_arrSrFieldCode() As String, _
                                   ByRef pv_arrSrFieldName() As String, ByRef pv_arrSrFieldType() As String, _
                                   ByRef pv_arrSrFieldMask() As String, ByRef pv_arrSrFieldDefValue() As String, ByRef pv_arrSrFieldOperator() As String, _
                                   ByRef pv_arrSrFieldFormat() As String, ByRef pv_arrSrFieldDisplay() As String, _
                                   ByRef pv_arrSrFieldWidth() As Integer, ByRef pv_arrSrLookupSql() As String, ByRef pv_arrSrFieldMultiLang() As String, _
                                   ByRef pv_arrSrFieldMandatory() As String, ByRef pv_arrSrRefCDType() As String, ByRef pv_arrSrRefCDName() As String, _
                                   ByRef pv_arrSrQuickSearch() As String, ByRef pv_arrSrSummaryCode() As String, _
                                   ByRef pv_strKeyColumn As String, ByRef pv_strKeyFieldType As String, ByRef pv_intSearchNum As Integer, _
                                   ByRef pv_strRefColumn As String, ByRef pv_strRefFieldType As String, Optional ByRef pv_strSrOderByCmd As String = "", _
                                   Optional ByRef pv_strTLTXCD As String = "", Optional ByRef pv_strISSMS As String = "N", _
                                   Optional ByRef pv_strISEMAIL As String = "N", Optional ByRef pv_intRowPerPage As Integer = 0, Optional ByRef pv_strAUTHCODE As String = "", _
                                   Optional ByRef pv_strROWLIMIT As String = "Y", Optional ByRef pv_strCMDTYPE As String = "T", Optional ByRef pv_strCondDefFld As String = "", _
                                   Optional ByRef pv_strBANKINQ As String = "N", Optional ByRef pv_strBANKACCT As String = "",
                                   Optional ByRef pv_ISFLTCODEID As String = "N", Optional ByRef pv_ISFLTMBCODE As String = "N",
                                   Optional ByRef pv_QUICKSRCH As String = "N", Optional ByRef pv_SUMMARYCD As String = "")

        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strValue As String
        Dim v_strKeyValue, v_strSrch, v_strRefValue As String
        Dim v_strOderbycmdsql, v_strSrTitle, v_strSrEnTitle, v_strSrCmd, v_strSrObjName, v_strFrmName, v_strSrFieldCode, v_strSrFieldMultiLang, _
            v_strSrFieldName, v_strSrEnFieldName, v_strSrFieldType, v_strSrFieldMask, v_strSrFieldDefValue, v_strSrFieldOperator, v_strSrFieldFormat As String
        Dim v_strSrFieldDisplay, v_strSrLookupSql, v_strSrRefACDType, v_strSrRefACDName, v_strSrQuickSearch, v_strSrSummaryCode As String
        Dim v_intSrFieldWidth, v_intFieldCount As Integer

        Try
            pv_intSearchNum = 0

            v_xmlDocument.LoadXml(pv_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            v_intFieldCount = v_nodeList.Count
            ReDim pv_arrSrFieldCode(v_intFieldCount)
            ReDim pv_arrSrFieldName(v_intFieldCount)
            ReDim pv_arrSrFieldType(v_intFieldCount)
            ReDim pv_arrSrFieldMask(v_intFieldCount)
            ReDim pv_arrSrFieldDefValue(v_intFieldCount)
            ReDim pv_arrSrFieldOperator(v_intFieldCount)
            ReDim pv_arrSrFieldFormat(v_intFieldCount)
            ReDim pv_arrSrFieldDisplay(v_intFieldCount)
            ReDim pv_arrSrFieldWidth(v_intFieldCount)
            ReDim pv_arrSrLookupSql(v_intFieldCount)
            ReDim pv_arrSrFieldMultiLang(v_intFieldCount)
            ReDim pv_arrSrFieldMandatory(v_intFieldCount)
            ReDim pv_arrSrRefCDType(v_intFieldCount)
            ReDim pv_arrSrRefCDName(v_intFieldCount)
            ReDim pv_arrSrQuickSearch(v_intFieldCount)
            ReDim pv_arrSrSummaryCode(v_intFieldCount)

            For i As Integer = 0 To v_intFieldCount - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString

                        Select Case Trim(v_strFLDNAME)
                            Case "ROWPERPAGE"
                                If IsNumeric(v_strValue) Then
                                    pv_intRowPerPage = CInt(v_strValue)
                                Else
                                    pv_intRowPerPage = 0
                                End If
                            Case "SRCH"
                                v_strSrch = Trim(v_strValue)
                            Case "AUTHCODE"
                                pv_strAUTHCODE = Trim(v_strValue)
                            Case "ROWLIMIT"
                                pv_strROWLIMIT = Trim(v_strValue)
                            Case "CMDTYPE"
                                pv_strCMDTYPE = Trim(v_strValue)
                            Case "SEARCHTITLE"
                                v_strSrTitle = Trim(v_strValue)
                            Case "EN_SEARCHTITLE"
                                v_strSrEnTitle = Trim(v_strValue)
                            Case "SEARCHCMDSQL"
                                v_strSrCmd = Trim(v_strValue)
                            Case "OBJNAME"
                                v_strSrObjName = Trim(v_strValue)
                            Case "FRMNAME"
                                v_strFrmName = Trim(v_strValue)
                            Case "FIELDCODE"
                                v_strSrFieldCode = Trim(v_strValue)
                            Case "FIELDNAME"
                                v_strSrFieldName = Trim(v_strValue)
                            Case "EN_FIELDNAME"
                                v_strSrEnFieldName = Trim(v_strValue)
                            Case "FIELDTYPE"
                                v_strSrFieldType = Trim(v_strValue)
                            Case "MASK"
                                v_strSrFieldMask = Trim(v_strValue)
                            Case "DEFVALUE"
                                v_strSrFieldDefValue = Trim(v_strValue)
                            Case "ORDERBYCMDSQL"
                                v_strOderbycmdsql = Trim(v_strValue)
                            Case "OPERATOR"
                                v_strSrFieldOperator = Trim(v_strValue)
                            Case "FORMAT"
                                v_strSrFieldFormat = Trim(v_strValue)
                            Case "DISPLAY"
                                v_strSrFieldDisplay = Trim(v_strValue)
                            Case "KEY"
                                v_strKeyValue = Trim(v_strValue)
                                If v_strKeyValue = "Y" Then
                                    pv_strKeyColumn = v_strSrFieldCode
                                    pv_strKeyFieldType = v_strSrFieldType
                                End If
                            Case "REFVALUE"
                                v_strRefValue = Trim(v_strValue)

                                If v_strRefValue = "Y" Then
                                    pv_strRefColumn = v_strSrFieldCode
                                    pv_strRefFieldType = v_strSrFieldType
                                End If
                            Case "WIDTH"
                                v_intSrFieldWidth = CInt(Trim(v_strValue))
                            Case "TLTXCD"
                                pv_strTLTXCD = Trim(v_strValue)
                            Case "LOOKUPCMDSQL"
                                v_strSrLookupSql = Trim(v_strValue)
                            Case "ISSMS"
                                pv_strISSMS = Trim(v_strValue)
                            Case "ISEMAIL"
                                pv_strISEMAIL = Trim(v_strValue)
                            Case "MULTILANG"
                                v_strSrFieldMultiLang = Trim(v_strValue)
                            Case "ACDTYPE"
                                v_strSrRefACDType = Trim(v_strValue)
                            Case "ACDNAME"
                                v_strSrRefACDName = Trim(v_strValue)
                            Case "CONDDEFFLD"
                                pv_strCondDefFld = Trim(v_strValue)
                            Case "BANKINQ"
                                pv_strBANKINQ = Trim(v_strValue)
                            Case "BANKACCT"
                                pv_strBANKACCT = Trim(v_strValue)
                            Case "ISFLTCODEID"
                                pv_ISFLTCODEID = Trim(v_strValue)
                            Case "ISFLTMBCODE"
                                pv_ISFLTMBCODE = Trim(v_strValue)
                            Case "QUICKSRCH"
                                v_strSrQuickSearch = Trim(v_strValue)
                            Case "SUMMARYCD"
                                v_strSrSummaryCode = Trim(v_strValue)
                        End Select
                    End With
                Next

                If v_strSrch = "Y" Or v_strSrch = "M" Then  'M là bắt buộc phải nhập giá trị tìm kiếm
                    pv_intSearchNum += 1

                    If pv_intSearchNum = 1 Then
                        pv_strSrTitle = v_strSrTitle
                        pv_strSrEnTitle = v_strSrEnTitle
                        pv_strSrCmd = v_strSrCmd
                        pv_strSrOderByCmd = v_strOderbycmdsql
                        pv_strSrObjName = v_strSrObjName
                        pv_strFrmName = v_strFrmName
                    End If
                    pv_arrSrFieldCode(pv_intSearchNum) = v_strSrFieldCode
                    pv_arrSrFieldName(pv_intSearchNum) = IIf(pv_strUserLanguage = gc_LANG_VIETNAMESE, v_strSrFieldName, v_strSrEnFieldName)
                    pv_arrSrFieldType(pv_intSearchNum) = v_strSrFieldType
                    pv_arrSrFieldMask(pv_intSearchNum) = v_strSrFieldMask
                    pv_arrSrFieldDefValue(pv_intSearchNum) = v_strSrFieldDefValue
                    pv_arrSrFieldOperator(pv_intSearchNum) = v_strSrFieldOperator
                    pv_arrSrFieldFormat(pv_intSearchNum) = v_strSrFieldFormat
                    pv_arrSrFieldDisplay(pv_intSearchNum) = v_strSrFieldDisplay
                    pv_arrSrFieldWidth(pv_intSearchNum) = v_intSrFieldWidth
                    pv_arrSrLookupSql(pv_intSearchNum) = v_strSrLookupSql
                    pv_arrSrFieldMandatory(pv_intSearchNum) = v_strSrch
                    'pv_arrSrFieldName(pv_intSearchNum) = v_strSrFieldName
                    pv_arrSrQuickSearch(pv_intSearchNum) = v_strSrQuickSearch
                    pv_arrSrSummaryCode(pv_intSearchNum) = v_strSrSummaryCode
                    pv_arrSrRefCDType(v_intFieldCount) = v_strSrRefACDType
                    pv_arrSrRefCDName(v_intFieldCount) = v_strSrRefACDName
                End If
            Next
            If pv_intSearchNum > 0 Then
                ReDim Preserve pv_arrSrFieldCode(pv_intSearchNum)
                ReDim Preserve pv_arrSrFieldName(pv_intSearchNum)
                ReDim Preserve pv_arrSrFieldType(pv_intSearchNum)
                ReDim Preserve pv_arrSrFieldMask(pv_intSearchNum)
                ReDim Preserve pv_arrSrFieldDefValue(pv_intSearchNum)
                ReDim Preserve pv_arrSrFieldOperator(pv_intSearchNum)
                ReDim Preserve pv_arrSrFieldFormat(pv_intSearchNum)
                ReDim Preserve pv_arrSrFieldDisplay(pv_intSearchNum)
                ReDim Preserve pv_arrSrFieldWidth(pv_intSearchNum)
                ReDim Preserve pv_arrSrLookupSql(pv_intSearchNum)
                ReDim Preserve pv_arrSrFieldMultiLang(pv_intSearchNum)
                ReDim Preserve pv_arrSrFieldMandatory(pv_intSearchNum)
                ReDim Preserve pv_arrSrQuickSearch(pv_intSearchNum)
                ReDim Preserve pv_arrSrSummaryCode(pv_intSearchNum)
                ReDim Preserve pv_arrSrRefCDType(v_intFieldCount)
                ReDim Preserve pv_arrSrRefCDName(v_intFieldCount)
            End If
        Catch ex As Exception
            LogError.Write(ex.Message & vbNewLine & ex.StackTrace, EventLogEntryType.Error)
            Throw ex
        End Try
    End Sub


    Protected Overridable Sub SetTransactForm()

    End Sub

    'Hàm này dùng de gui email canh bao Trigger
    Protected Overridable Sub SendEmailCall(ByVal v_strObjMsg As String, ByRef v_strEmaillogmessage As String)
    End Sub
    Protected Overridable Sub SendEmailTrigger(ByVal v_strObjMsg As String, ByRef v_strEmaillogmessage As String)
    End Sub
    Protected Overridable Sub SendEmailTodue(ByVal v_strObjMsg As String, ByRef v_strEmaillogmessage As String)
    End Sub
    Protected Overridable Sub SendEmailOVD(ByVal v_strObjMsg As String, ByRef v_strEmaillogmessage As String)
    End Sub
    Protected Overridable Sub SendNotification(ByVal v_strSENDVIA As String)
    End Sub

    Protected Overridable Sub InitDialog()

        Dim v_strCmdSQL, v_strObjMsg As String

        Dim v_strSQL, V_strdt As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_ds As New DataSet
        Dim tb As New DataTable
        Dim mv_strFormName, mv_arrSrFieldSrch(), mv_arrSrFieldDisp(), mv_arrSrFieldType(), mv_arrSrFieldMask() As String
        Dim mv_arrStFieldDefValue(), mv_arrSrFieldOperator(), mv_arrSrFieldFormat(), mv_arrSrFieldDisplay() As String
        Dim mv_arrSrSQLRef(), mv_arrStFieldMultiLang(), mv_arrStFieldMandartory(), mv_arrStFieldRefCDType(), mv_arrStFieldRefCDName() As String
        Dim mv_strKeyColumn, mv_strKeyFieldType, mv_intSearchNum, mv_strRefColumn, mv_strRefFieldType As String
        Dim mv_strSrOderByCmd, mv_strTLTXCD, mv_strIsSMS, mv_strIsEMAIL, mv_rowpage, mv_strSearchAuthCode As String
        Dim mv_strRowLimit, mv_strCommandType, mv_strCondDefFld, mv_strBANKINQ, mv_strBANKACCT As String
        Dim mv_strCaption, mv_strEnCaption, mv_strObjName As String
        Dim mv_arrSrFieldWidth() As Integer
        'Khởi tạo kích thước form và load resource
        If DesignMode Then
            Return
        End If
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())



        LoadUserInterface(Me)
        Me.Text = ResourceManager.GetString(Me.Name)
        lblType.Text = ResourceManager.GetString(lblType.Tag)
        cboType.Properties.NullText = ""






        'loai 
        v_strCmdSQL = "SELECT CDVAL VALUECD,CDVAL VALUE,CDCONTENT DISPLAY , EN_CDCONTENT EN_DISPLAY,LSTODR FROM ALLCODE WHERE CDNAME = 'FIIN' AND CDTYPE = 'SE'  ORDER BY LSTODR"
        v_strObjMsg = BuildXMLObjMsg(, "000001", , "0001", gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        cboType.Refresh()
        FillXtraLookUpEdit(v_strObjMsg, cboType, "", Me.UserLanguage)
        cboType.EditValue = "STOCK_INFO"
        dtFr.EditValue = Me.BusDate
        dtTo.EditValue = Me.BusDate

    End Sub




    ''' <summary>
    ''' Save citerial
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SaveLastSearch()

        Try
            'TODO: Save last criterial
        Catch ex As Exception
            LogError.Write("Error source: AppCore.frmSearch.SaveLastSearch" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            'MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub LoadLastSearch()

        Try
            'TODO: Load last criterial
        Catch ex As Exception
            LogError.Write("Error source: AppCore.frmSearch.LoadLastSearch" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
        End Try

    End Sub

    Public Sub LoadUserInterface(ByRef pv_ctrl As Windows.Forms.Control)
        'Load rieng cho form
        Dim v_ctrl As Windows.Forms.Control
        Dim v_strControlTag, v_strControlType As String, v_cboEX As ComboBoxEx
        Try
            pv_ctrl.BackColor = System.Drawing.SystemColors.Control

            For Each v_ctrl In pv_ctrl.Controls
                If Not v_ctrl.Tag Is Nothing Then
                    v_strControlTag = v_ctrl.Tag.ToString
                    If v_strControlTag.Trim.Length > 0 Then
                        If TypeOf (v_ctrl) Is Label Or TypeOf (v_ctrl) Is LabelControl Then
                            v_ctrl.Text = ResourceManager.GetString(v_strControlTag)
                        ElseIf TypeOf (v_ctrl) Is Button Or TypeOf (v_ctrl) Is SimpleButton Then
                            v_ctrl.Text = ResourceManager.GetString(v_strControlTag)
                        ElseIf TypeOf (v_ctrl) Is Panel Then
                            LoadUserInterface(v_ctrl)
                        ElseIf TypeOf (v_ctrl) Is SplitContainer Then
                            LoadUserInterface(v_ctrl)
                        ElseIf TypeOf (v_ctrl) Is GroupBox Or TypeOf (v_ctrl) Is GroupControl Then
                            v_ctrl.Text = ResourceManager.GetString(v_strControlTag)
                            LoadUserInterface(v_ctrl)
                        ElseIf TypeOf (v_ctrl) Is TabControl Then
                            For Each v_ctrlTmp As System.Windows.Forms.Control In CType(v_ctrl, TabControl).TabPages
                                v_strControlTag = v_ctrlTmp.Tag
                                v_ctrlTmp.Text = ResourceManager.GetString(v_strControlTag)
                            Next
                            LoadUserInterface(v_ctrl)
                        ElseIf TypeOf (v_ctrl) Is XtraTabControl Then
                            For Each v_ctrlTmp As System.Windows.Forms.Control In CType(v_ctrl, XtraTabControl).TabPages
                                v_strControlTag = v_ctrlTmp.Tag
                                v_ctrlTmp.Text = ResourceManager.GetString(v_strControlTag)
                            Next
                            LoadUserInterface(v_ctrl)
                        ElseIf TypeOf (v_ctrl) Is TabPage Then
                            v_ctrl.BackColor = System.Drawing.SystemColors.InactiveCaptionText
                            v_ctrl.Text = ResourceManager.GetString(v_strControlTag)
                            LoadUserInterface(v_ctrl)
                        ElseIf TypeOf (v_ctrl) Is XtraTabPage Then
                            CType(v_ctrl, XtraTabPage).BackColor = System.Drawing.SystemColors.InactiveCaptionText
                            CType(v_ctrl, XtraTabPage).Text = ResourceManager.GetString(v_strControlTag)
                            LoadUserInterface(v_ctrl)
                            'TheNN add: Load text label for checkbox control                            
                        ElseIf TypeOf (v_ctrl) Is TableLayoutPanel Then
                            LoadUserInterface(v_ctrl)
                        ElseIf TypeOf (v_ctrl) Is CheckBox Then
                            v_ctrl.Text = ResourceManager.GetString(v_strControlTag)
                            'TheNN ended. 09-Jan-2012
                        ElseIf TypeOf (v_ctrl) Is CheckEdit Then
                            CType(v_ctrl, CheckEdit).Text = ResourceManager.GetString(v_strControlTag)
                        ElseIf TypeOf (v_ctrl) Is PanelControl Then
                            LoadUserInterface(v_ctrl)
                        End If
                    End If
                End If

            Next
            'Load caption của form, label caption
            Me.Text = ResourceManager.GetString(Me.Name)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub LoadResource(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control

        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is Label Then
                CType(v_ctrl, Label).Text = mv_ResourceManager.GetString(v_ctrl.Tag)
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString(v_ctrl.Tag)
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Button Then
                CType(v_ctrl, Button).Text = mv_ResourceManager.GetString(v_ctrl.Tag)
            ElseIf TypeOf (v_ctrl) Is CheckBox Then
                CType(v_ctrl, CheckBox).Text = mv_ResourceManager.GetString(v_ctrl.Tag)
            End If
        Next

    End Sub

    Private Function ConvertXmlDocToDataSet(ByVal pv_xmlDoc As Xml.XmlDocument) As DataSet
        Try
            Dim v_ds As New DataSet("Object")
            Dim v_dr As DataRow
            Dim v_dc As DataColumn
            Dim v_intCountCol As Integer

            Dim v_nodeXSD, v_nodeXML As Xml.XmlNode
            Dim v_strDataXSD, v_strDataXML, v_strBuilder As String
            Dim v_arrXSDByteMessage(), v_arrXMLByteMessage() As Byte
            Dim v_Encoded As Char()

            v_nodeXSD = pv_xmlDoc.SelectSingleNode("/ObjectMessage/ObjDataXSD")
            v_nodeXML = pv_xmlDoc.SelectSingleNode("/ObjectMessage/ObjDataXML")
            v_strDataXSD = v_nodeXSD.InnerText
            v_strDataXML = v_nodeXML.InnerText
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
            v_ds.Tables(0).TableName = "ObjData"
            Return v_ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region " Các sự kiện của form "

    Private Sub frmSearch_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Close()
    End Sub

    Private Sub frmSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If DesignMode Then
            Return
        End If
        InitDialog()

        RefreshToolBar()
    End Sub



    Private Sub RefreshToolBar()
        If DesignMode Then
            Return
        End If
        Dim addAuth As Boolean = (Mid(AuthCode, 1, 1) = "Y")
        Dim editAuth As Boolean = (Mid(AuthCode, 3, 1) = "Y")
        Dim viewAuth As Boolean = (Mid(AuthCode, 2, 1) = "Y")
        Dim delAuth As Boolean = (Mid(AuthCode, 4, 1) = "Y")
        Dim apprAuth As Boolean = (Mid(AuthCode, 11, 1) = "Y")


        Dim editAuthString As Boolean = (Mid(AuthString, 3, 1) = "Y")
        Dim delAuthString As Boolean = (Mid(AuthString, 4, 1) = "Y")
        Dim apprAuthString As Boolean = (Mid(AuthString, 5, 1) = "Y")
    End Sub

   

#End Region


    Private Function objKey() As Object
        Throw New NotImplementedException
    End Function


    Private Sub btnsync_Click(sender As Object, e As EventArgs) Handles btnsync.Click
        Dim v_strErrorSource, v_strErrorMessage, v_lngError, v_strClauseParam As String
        Dim v_strSQL, v_strObjMsg, v_strValue As String
        Dim v_strBuffer, v_strBufferTemp As New System.Text.StringBuilder
        Dim v_ws As New BDSDeliveryManagement
        Dim v_strStoreName As String

        Try
            v_strStoreName = "SP_SYNC_FIIN"
            Const str_sync_fiin_param As String = "v_type!{0}!varchar2!100" & _
                                                    "^v_fr_date!{1}!varchar2!100" & _
                                                    "^v_to_date!{2}!varchar2!100" & _
                                                 "^P_ERR_CODE!{3}!VARCHAR2!30"


            'v_strClauseParam = String.Format(str_sync_fiin_param, cboType.EditValue, dtFr.Text, dtTo.Text, "")
            v_strClauseParam = String.Format(str_sync_fiin_param, cboType.EditValue, dtFr.DateTime.ToString("dd/MM/yyyy HH:mm:ss"), dtTo.DateTime.ToString("dd/MM/yyyy HH:mm:ss"), "")
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionExec, v_strStoreName, v_strClauseParam, , , , , , , gc_CommandProcedure)
            v_lngError = v_ws.Message(v_strObjMsg)
            If v_lngError <> ERR_SYSTEM_OK Then
                MessageBox.Show(String.Format(mv_ResourceManager.GetString("SyncFail")), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                MessageBox.Show(String.Format(mv_ResourceManager.GetString("SyncSuccessful")), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmSyncFIIN" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(mv_ResourceManager.GetString("msgInvalidInputFile"), gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmSyncFIIN_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Escape
                    Me.Dispose()
            End Select
        Catch ex As Exception

        End Try
    End Sub
End Class
