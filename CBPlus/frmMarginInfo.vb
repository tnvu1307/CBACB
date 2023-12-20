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
Public Class frmMarginInfo
    Inherits System.Windows.Forms.Form
    Const c_ResourceManager As String = "_DIRECT.frmMarginInfo-"
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
    Private mv_strTellerId, mv_strKeyFieldType, mv_strLinkValue, mv_strLinkFIeld As String
    Private mv_strTableName, mv_strAuthString, mv_intExecFlag, mv_strTellerRight, mv_strGroupCareBy, mv_strKeyFieldValue, mv_strKeyFieldName As String
    Private GR1Grid As AppCore.GridEx
    Private GR2Grid As AppCore.GridEx
    Private mv_xmlCUSTOMER As XmlDocumentEx
    Private mv_strXmlMessageData As String
    Private mv_arrObjFields() As CFieldMaster
    Private mv_arrObjFldVals() As CFieldVal
    Private mv_blnAcctEntry As Boolean
    Private mv_dblDEALPAIDAMT As Double
    Private mv_strAFACCTNO As String
    Private mv_strCUSTODYCD As String


    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mv_strLanguage = pv_strLanguage
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)




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
    Public Property TableName() As String
        Get
            Return mv_strTableName
        End Get
        Set(ByVal Value As String)
            mv_strTableName = Value
        End Set
    End Property
    Public Property ExeFlag() As Integer
        Get
            Return mv_intExecFlag
        End Get
        Set(ByVal Value As Integer)
            mv_intExecFlag = Value
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
    Public Property AuthString() As String
        Get
            Return mv_strAuthString
        End Get
        Set(ByVal Value As String)
            mv_strAuthString = Value
        End Set
    End Property

    Public Property KeyFieldName() As String
        Get
            Return mv_strKeyFieldName
        End Get
        Set(ByVal Value As String)
            mv_strKeyFieldName = Value
        End Set
    End Property
    Public Property KeyFieldValue() As String
        Get
            Return mv_strKeyFieldValue
        End Get
        Set(ByVal Value As String)
            mv_strKeyFieldValue = Value
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
    Public Property LinkValue() As String
        Get
            Return mv_strLinkValue
        End Get
        Set(ByVal Value As String)
            mv_strLinkValue = Value
        End Set
    End Property

    Public Property LinkFIeld() As String
        Get
            Return mv_strLinkFIeld
        End Get
        Set(ByVal Value As String)
            mv_strLinkFIeld = Value
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
                If (Me.BusDate <> String.Empty) Then
                    CType(v_ctrl, DateTimePicker).Value = CDate(Me.BusDate)
                Else
                    CType(v_ctrl, DateTimePicker).Text = ""
                End If
            End If

        Next
        Me.Text = mv_ResourceManager.GetString("frmMarginInfo")

    End Sub



    Private Sub InitData()
        Dim v_strCmdSQL, v_strObjMsg, v_strFLDNAME, v_strVALUE As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strClause As String
        Dim v_strCUSTODYCD, v_strACCTNO, v_strRTT_MR, v_strRTT_TC, v_strBRID, v_strCUSTLIMIT, v_strMRLIMIT As String
        Dim v_strBROKER, v_strGBROKER, v_strNETASS, v_strTCLIMIT, v_strBLLIMIT As String
        Dim v_strBALDEFOVD, v_strBALDEFAVL, v_strAVLWITHDRAW As String

        Dim v_strGR1_R1_MARKET, v_strGR1_R2_MARKET, v_strGR1_R3_MARKET, v_strGR1_R4_MARKET, v_strGR1_R5_MARKET, v_strGR1_R6_MARKET As String
        Dim v_strGR1_R1_CONVERT, v_strGR1_R2_CONVERT, v_strGR1_R3_CONVERT, v_strGR1_R4_CONVERT, v_strGR1_R5_CONVERT, v_strGR1_R6_CONVERT As String
        Dim v_strGR2_R1_ORIGIN, v_strGR2_R2_ORIGIN, v_strGR2_R3_ORIGIN, v_strGR2_R4_ORIGIN, v_strGR2_R5_ORIGIN, v_strGR2_R6_ORIGIN, v_strGR2_R7_ORIGIN, v_strGR2_R8_ORIGIN As String
        Dim v_strGR2_R1_INSTFEE, v_strGR2_R2_INSTFEE, v_strGR2_R3_INSTFEE, v_strGR2_R4_INSTFEE, v_strGR2_R5_INSTFEE, v_strGR2_R6_INSTFEE, v_strGR2_R7_INSTFEE, v_strGR2_R8_INSTFEE As String
        Dim v_strGR2_R1_OVDUE, v_strGR2_R2_OVDUE, v_strGR2_R3_OVDUE, v_strGR2_R4_OVDUE, v_strGR2_R5_OVDUE, v_strGR2_R6_OVDUE, v_strGR2_R7_OVDUE, v_strGR2_R8_OVDUE As String
        Try
            'Load TT Khach hang
            v_strCmdSQL = "SP_MR_MR0001DETAIL1"
            v_strClause = "AFACCTNO!" & KeyFieldValue & "!varchar2!20^ACCVIEW!" & TableName & "!varchar2!20"
            'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strCmdSQL)
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strCmdSQL, v_strClause, , , , , , , gc_CommandProcedure)

            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count > 0 Then
                For i As Integer = 0 To v_nodeList.Count - 1
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            'Ghi nhận thuật toán để kiểm tra và tính toán cho từng truong cua giao dịch
                            v_strVALUE = .InnerText.ToString
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                'Lay thong tin chung
                                Case "CUSTODYCD"
                                    v_strCUSTODYCD = Trim(v_strVALUE)
                                Case "ACCTNO"
                                    v_strACCTNO = Trim(v_strVALUE)
                                Case "RTT_MR"
                                    v_strRTT_MR = Trim(v_strVALUE)
                                Case "RTT_TC"
                                    v_strRTT_TC = Trim(v_strVALUE)
                                Case "BRID"
                                    v_strBRID = Trim(v_strVALUE)
                                Case "BROKER"
                                    v_strBROKER = Trim(v_strVALUE)
                                Case "GBROKER"
                                    v_strGBROKER = Trim(v_strVALUE)
                                Case "NETASS"
                                    v_strNETASS = Trim(v_strVALUE)
                                Case "CUSTLIMIT"
                                    v_strCUSTLIMIT = Trim(v_strVALUE)
                                Case "MRLIMIT"
                                    v_strMRLIMIT = Trim(v_strVALUE)
                                Case "TCLIMIT"
                                    v_strTCLIMIT = Trim(v_strVALUE)
                                Case "BLLIMIT"
                                    v_strBLLIMIT = Trim(v_strVALUE)

                                Case "BALDEFOVD"
                                    v_strBALDEFOVD = Trim(v_strVALUE)
                                Case "BALDEFAVL"
                                    v_strBALDEFAVL = Trim(v_strVALUE)
                                Case "AVLWITHDRAW"
                                    v_strAVLWITHDRAW = Trim(v_strVALUE)
                                    'Lay cac truong cua tai san
                                Case "GR1_R1_MARKET"
                                    v_strGR1_R1_MARKET = Trim(v_strVALUE)
                                Case "GR1_R1_CONVERT"
                                    v_strGR1_R1_CONVERT = Trim(v_strVALUE)

                                Case "GR1_R2_MARKET"
                                    v_strGR1_R2_MARKET = Trim(v_strVALUE)
                                Case "GR1_R2_CONVERT"
                                    v_strGR1_R2_CONVERT = Trim(v_strVALUE)

                                Case "GR1_R3_MARKET"
                                    v_strGR1_R3_MARKET = Trim(v_strVALUE)
                                Case "GR1_R3_CONVERT"
                                    v_strGR1_R3_CONVERT = Trim(v_strVALUE)

                                Case "GR1_R4_MARKET"
                                    v_strGR1_R4_MARKET = Trim(v_strVALUE)
                                Case "GR1_R4_CONVERT"
                                    v_strGR1_R4_CONVERT = Trim(v_strVALUE)

                                Case "GR1_R5_MARKET"
                                    v_strGR1_R5_MARKET = Trim(v_strVALUE)
                                Case "GR1_R5_CONVERT"
                                    v_strGR1_R5_CONVERT = Trim(v_strVALUE)

                                Case "GR1_R6_MARKET"
                                    v_strGR1_R6_MARKET = Trim(v_strVALUE)
                                Case "GR1_R6_CONVERT"
                                    v_strGR1_R6_CONVERT = Trim(v_strVALUE)


                                    'Lay cac truong cua cac loai no
                                Case "GR2_R1_ORIGIN"
                                    v_strGR2_R1_ORIGIN = Trim(v_strVALUE)
                                Case "GR2_R1_INSTFEE"
                                    v_strGR2_R1_INSTFEE = Trim(v_strVALUE)
                                Case "GR2_R1_OVDUE"
                                    v_strGR2_R1_OVDUE = Trim(v_strVALUE)

                                Case "GR2_R2_ORIGIN"
                                    v_strGR2_R2_ORIGIN = Trim(v_strVALUE)
                                Case "GR2_R2_INSTFEE"
                                    v_strGR2_R2_INSTFEE = Trim(v_strVALUE)
                                Case "GR2_R2_OVDUE"
                                    v_strGR2_R2_OVDUE = Trim(v_strVALUE)

                                Case "GR2_R3_ORIGIN"
                                    v_strGR2_R3_ORIGIN = Trim(v_strVALUE)
                                Case "GR2_R3_INSTFEE"
                                    v_strGR2_R3_INSTFEE = Trim(v_strVALUE)
                                Case "GR2_R3_OVDUE"
                                    v_strGR2_R3_OVDUE = Trim(v_strVALUE)

                                Case "GR2_R4_ORIGIN"
                                    v_strGR2_R4_ORIGIN = Trim(v_strVALUE)
                                Case "GR2_R4_INSTFEE"
                                    v_strGR2_R4_INSTFEE = Trim(v_strVALUE)
                                Case "GR2_R4_OVDUE"
                                    v_strGR2_R4_OVDUE = Trim(v_strVALUE)

                                Case "GR2_R5_ORIGIN"
                                    v_strGR2_R5_ORIGIN = Trim(v_strVALUE)
                                Case "GR2_R5_INSTFEE"
                                    v_strGR2_R5_INSTFEE = Trim(v_strVALUE)
                                Case "GR2_R5_OVDUE"
                                    v_strGR2_R5_OVDUE = Trim(v_strVALUE)

                                Case "GR2_R6_ORIGIN"
                                    v_strGR2_R6_ORIGIN = Trim(v_strVALUE)
                                Case "GR2_R6_INSTFEE"
                                    v_strGR2_R6_INSTFEE = Trim(v_strVALUE)
                                Case "GR2_R6_OVDUE"
                                    v_strGR2_R6_OVDUE = Trim(v_strVALUE)

                                Case "GR2_R7_ORIGIN"
                                    v_strGR2_R7_ORIGIN = Trim(v_strVALUE)
                                Case "GR2_R7_INSTFEE"
                                    v_strGR2_R7_INSTFEE = Trim(v_strVALUE)
                                Case "GR2_R7_OVDUE"
                                    v_strGR2_R7_OVDUE = Trim(v_strVALUE)

                                Case "GR2_R8_ORIGIN"
                                    v_strGR2_R8_ORIGIN = Trim(v_strVALUE)
                                Case "GR2_R8_INSTFEE"
                                    v_strGR2_R8_INSTFEE = Trim(v_strVALUE)
                                Case "GR2_R8_OVDUE"
                                    v_strGR2_R8_OVDUE = Trim(v_strVALUE)




                            End Select
                        End With
                    Next
                Next
            End If
            If v_strACCTNO <> String.Empty Then
                'Load thong tin chung
                lblvAcctno.Text = v_strACCTNO
                lblvCustodycd.Text = v_strCUSTODYCD
                lblvRtt_MR.Text = Format(CDbl(v_strRTT_MR), "#,##0.###0")
                lblvRtt_TC.Text = Format(CDbl(v_strRTT_TC), "#,##0.###0")
                lblvBRID.Text = v_strBRID
                lblvBroker.Text = v_strBROKER
                lblvGBroker.Text = v_strGBROKER
                lblvCustLimit.Text = Format(CDbl(v_strCUSTLIMIT), "#,##0")
                lblvMRLimit.Text = Format(CDbl(v_strMRLIMIT), "#,##0")
                lblvTCLimit.Text = Format(CDbl(v_strTCLIMIT), "#,##0")
                lblvBLLimit.Text = Format(CDbl(v_strBLLIMIT), "#,##0")
                lblvNetAssets.Text = Format(CDbl(v_strNETASS), "#,##0")
                lblvBALDEFOVD.Text = Format(CDbl(v_strBALDEFOVD), "#,##0")
                lblvBALDEFAVL.Text = Format(CDbl(v_strBALDEFAVL), "#,##0")
                lblvAVLWITHDRAW.Text = Format(CDbl(v_strAVLWITHDRAW), "#,##0")

                'Load thong tin tai san
                lblvGR1_R1_MARKET.Text = Format(CDbl(v_strGR1_R1_MARKET), "#,##0")
                lblvGR1_R2_MARKET.Text = Format(CDbl(v_strGR1_R2_MARKET), "#,##0")
                lblvGR1_R3_MARKET.Text = Format(CDbl(v_strGR1_R3_MARKET), "#,##0")
                lblvGR1_R4_MARKET.Text = Format(CDbl(v_strGR1_R4_MARKET), "#,##0")
                lblvGR1_R5_MARKET.Text = Format(CDbl(v_strGR1_R5_MARKET), "#,##0")
                lblvGR1_R6_MARKET.Text = Format(CDbl(v_strGR1_R6_MARKET), "#,##0")

                lblvGR1_R1_CONVERT.Text = Format(CDbl(v_strGR1_R1_CONVERT), "#,##0")
                lblvGR1_R2_CONVERT.Text = Format(CDbl(v_strGR1_R2_CONVERT), "#,##0")
                lblvGR1_R3_CONVERT.Text = Format(CDbl(v_strGR1_R3_CONVERT), "#,##0")
                lblvGR1_R4_CONVERT.Text = Format(CDbl(v_strGR1_R4_CONVERT), "#,##0")
                lblvGR1_R5_CONVERT.Text = Format(CDbl(v_strGR1_R5_CONVERT), "#,##0")
                lblvGR1_R6_CONVERT.Text = Format(CDbl(v_strGR1_R6_CONVERT), "#,##0")

                'Load thong tin cac loai no
                lblvGR2_R1_ORIGIN.Text = Format(CDbl(v_strGR2_R1_ORIGIN), "#,##0")
                lblvGR2_R2_ORIGIN.Text = Format(CDbl(v_strGR2_R2_ORIGIN), "#,##0")
                lblvGR2_R3_ORIGIN.Text = Format(CDbl(v_strGR2_R3_ORIGIN), "#,##0")
                lblvGR2_R4_ORIGIN.Text = Format(CDbl(v_strGR2_R4_ORIGIN), "#,##0")
                lblvGR2_R5_ORIGIN.Text = Format(CDbl(v_strGR2_R5_ORIGIN), "#,##0")
                lblvGR2_R6_ORIGIN.Text = Format(CDbl(v_strGR2_R6_ORIGIN), "#,##0")
                lblvGR2_R7_ORIGIN.Text = Format(CDbl(v_strGR2_R7_ORIGIN), "#,##0")
                lblvGR2_R8_ORIGIN.Text = Format(CDbl(v_strGR2_R8_ORIGIN), "#,##0")

                lblvGR2_R1_INSTFEE.Text = Format(CDbl(v_strGR2_R1_INSTFEE), "#,##0")
                lblvGR2_R2_INSTFEE.Text = Format(CDbl(v_strGR2_R2_INSTFEE), "#,##0")
                lblvGR2_R3_INSTFEE.Text = Format(CDbl(v_strGR2_R3_INSTFEE), "#,##0")
                lblvGR2_R4_INSTFEE.Text = Format(CDbl(v_strGR2_R4_INSTFEE), "#,##0")
                lblvGR2_R5_INSTFEE.Text = Format(CDbl(v_strGR2_R5_INSTFEE), "#,##0")
                lblvGR2_R6_INSTFEE.Text = Format(CDbl(v_strGR2_R6_INSTFEE), "#,##0")
                lblvGR2_R7_INSTFEE.Text = Format(CDbl(v_strGR2_R7_INSTFEE), "#,##0")
                lblvGR2_R8_INSTFEE.Text = Format(CDbl(v_strGR2_R8_INSTFEE), "#,##0")

                lblvGR2_R1_OVDUE.Text = Format(CDbl(v_strGR2_R1_OVDUE), "#,##0")
                lblvGR2_R2_OVDUE.Text = Format(CDbl(v_strGR2_R2_OVDUE), "#,##0")
                lblvGR2_R3_OVDUE.Text = Format(CDbl(v_strGR2_R3_OVDUE), "#,##0")
                lblvGR2_R4_OVDUE.Text = Format(CDbl(v_strGR2_R4_OVDUE), "#,##0")
                lblvGR2_R5_OVDUE.Text = Format(CDbl(v_strGR2_R5_OVDUE), "#,##0")
                lblvGR2_R6_OVDUE.Text = Format(CDbl(v_strGR2_R6_OVDUE), "#,##0")
                lblvGR2_R7_OVDUE.Text = Format(CDbl(v_strGR2_R7_OVDUE), "#,##0")
                lblvGR2_R8_OVDUE.Text = Format(CDbl(v_strGR2_R8_OVDUE), "#,##0")
            End If




        Catch ex As Exception
            MsgBox(ResourceManager.GetString("INVALID_INFO"), MsgBoxStyle.Information)
            'ResetScreen()
        End Try
    End Sub

    Private Sub InitData2()
        Dim v_strCmdSQL, v_strObjMsg, v_strFLDNAME, v_strVALUE As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strClause As String
        Dim v_strCUSTODYCD, v_strACCTNO, v_strRTT_MR, v_strRTT_TC, v_strBRID, v_strNUMSPCLCALL, v_strNUMCALL As String
        Dim v_strBROKER, v_strGBROKER, v_strPAYVAL, v_strSALEVAL, v_strBRKRGRPID As String

        Dim v_strGR1_R1_RM, v_strGR1_R2_RM, v_strGR1_R3_RM, v_strGR1_R4_RM, v_strGR1_R5_RM, v_strGR1_R6_RM As String
        Dim v_strGR1_R1_RB, v_strGR1_R2_RB, v_strGR1_R3_RB, v_strGR1_R4_RB, v_strGR1_R5_RB, v_strGR1_R6_RB As String
        Dim v_strGR1_R1_RC, v_strGR1_R2_RC, v_strGR1_R3_RC, v_strGR1_R4_RC, v_strGR1_R5_RC, v_strGR1_R6_RC As String
        Dim v_strGR2_R1_ADDVAL, v_strGR2_R2_ADDVAL, v_strGR2_R3_ADDVAL, v_strGR2_R4_ADDVAL As String
        Dim v_strGR2_R1_ADDDAY, v_strGR2_R2_ADDDAY, v_strGR2_R3_ADDDAY, v_strGR2_R4_ADDDAY As String
        Dim v_strGR2_R1_FACTORVAL, v_strGR2_R2_FACTORVAL, v_strGR2_R3_FACTORVAL, v_strGR2_R4_FACTORVAL As String
        Dim v_strGR2_R1_VIOLATIONID, v_strGR2_R2_VIOLATIONID, v_strGR2_R3_VIOLATIONID, v_strGR2_R4_VIOLATIONID As String
        Try
            'Load TT Khach hang
            v_strCmdSQL = "SP_MR_MR0001DETAIL2"
            v_strClause = "AFACCTNO!" & KeyFieldValue & "!varchar2!20^ACCVIEW!" & TableName & "!varchar2!20"
            'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_AFMAST, gc_ActionInquiry, v_strCmdSQL)
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strCmdSQL, v_strClause, , , , , , , gc_CommandProcedure)

            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count > 0 Then
                For i As Integer = 0 To v_nodeList.Count - 1
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            'Ghi nhận thuật toán để kiểm tra và tính toán cho tung truong cua giao dich
                            v_strVALUE = .InnerText.ToString
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                'Lay thong tin chung
                                Case "CUSTODYCD"
                                    v_strCUSTODYCD = Trim(v_strVALUE)
                                Case "ACCTNO"
                                    v_strACCTNO = Trim(v_strVALUE)
                                Case "RTT_MR"
                                    v_strRTT_MR = Trim(v_strVALUE)
                                Case "RTT_TC"
                                    v_strRTT_TC = Trim(v_strVALUE)
                                Case "BRID"
                                    v_strBRID = Trim(v_strVALUE)
                                Case "BROKER"
                                    v_strBROKER = Trim(v_strVALUE)
                                Case "GBROKER"
                                    v_strGBROKER = Trim(v_strVALUE)
                                Case "PAYVAL"
                                    v_strPAYVAL = Trim(v_strVALUE)
                                Case "NUMSPCLCALL"
                                    v_strNUMSPCLCALL = Trim(v_strVALUE)
                                Case "NUMCALL"
                                    v_strNUMCALL = Trim(v_strVALUE)
                                Case "SALEVAL"
                                    v_strSALEVAL = Trim(v_strVALUE)
                                Case "BRKRGRPID"
                                    v_strBRKRGRPID = Trim(v_strVALUE)
                                    'Lay cac truong bo cong thuc goc cua loai hinh
                                Case "GR1_R1_RM"
                                    v_strGR1_R1_RM = Trim(v_strVALUE)
                                Case "GR1_R1_RB"
                                    v_strGR1_R1_RB = Trim(v_strVALUE)
                                Case "GR1_R1_RC"
                                    v_strGR1_R1_RC = Trim(v_strVALUE)

                                Case "GR1_R2_RM"
                                    v_strGR1_R2_RM = Trim(v_strVALUE)
                                Case "GR1_R2_RB"
                                    v_strGR1_R2_RB = Trim(v_strVALUE)
                                Case "GR1_R2_RC"
                                    v_strGR1_R2_RC = Trim(v_strVALUE)

                                Case "GR1_R3_RM"
                                    v_strGR1_R3_RM = Trim(v_strVALUE)
                                Case "GR1_R3_RB"
                                    v_strGR1_R3_RB = Trim(v_strVALUE)
                                Case "GR1_R3_RC"
                                    v_strGR1_R3_RC = Trim(v_strVALUE)

                                Case "GR1_R4_RM"
                                    v_strGR1_R4_RM = Trim(v_strVALUE)
                                Case "GR1_R4_RB"
                                    v_strGR1_R4_RB = Trim(v_strVALUE)
                                Case "GR1_R4_RC"
                                    v_strGR1_R4_RC = Trim(v_strVALUE)

                                Case "GR1_R5_RM"
                                    v_strGR1_R5_RM = Trim(v_strVALUE)
                                Case "GR1_R5_RB"
                                    v_strGR1_R5_RB = Trim(v_strVALUE)
                                Case "GR1_R5_RC"
                                    v_strGR1_R5_RC = Trim(v_strVALUE)

                                Case "GR1_R6_RM"
                                    v_strGR1_R6_RM = Trim(v_strVALUE)
                                Case "GR1_R6_RB"
                                    v_strGR1_R6_RB = Trim(v_strVALUE)
                                Case "GR1_R6_RC"
                                    v_strGR1_R6_RC = Trim(v_strVALUE)


                                    'Lay cac truong cua gia tri cong bo sung
                                Case "GR2_R1_ADDVAL"
                                    v_strGR2_R1_ADDVAL = Trim(v_strVALUE)
                                Case "GR2_R1_ADDDAY"
                                    v_strGR2_R1_ADDDAY = Trim(v_strVALUE)
                                Case "GR2_R1_FACTORVAL"
                                    v_strGR2_R1_FACTORVAL = Trim(v_strVALUE)
                                Case "GR2_R1_VIOLATIONID"
                                    v_strGR2_R1_VIOLATIONID = Trim(v_strVALUE)

                                Case "GR2_R2_ADDVAL"
                                    v_strGR2_R2_ADDVAL = Trim(v_strVALUE)
                                Case "GR2_R2_ADDDAY"
                                    v_strGR2_R2_ADDDAY = Trim(v_strVALUE)
                                Case "GR2_R2_FACTORVAL"
                                    v_strGR2_R2_FACTORVAL = Trim(v_strVALUE)
                                Case "GR2_R2_VIOLATIONID"
                                    v_strGR2_R2_VIOLATIONID = Trim(v_strVALUE)

                                Case "GR2_R3_ADDVAL"
                                    v_strGR2_R3_ADDVAL = Trim(v_strVALUE)
                                Case "GR2_R3_ADDDAY"
                                    v_strGR2_R3_ADDDAY = Trim(v_strVALUE)
                                Case "GR2_R3_FACTORVAL"
                                    v_strGR2_R3_FACTORVAL = Trim(v_strVALUE)
                                Case "GR2_R3_VIOLATIONID"
                                    v_strGR2_R3_VIOLATIONID = Trim(v_strVALUE)

                                Case "GR2_R4_ADDVAL"
                                    v_strGR2_R4_ADDVAL = Trim(v_strVALUE)
                                Case "GR2_R4_ADDDAY"
                                    v_strGR2_R4_ADDDAY = Trim(v_strVALUE)
                                Case "GR2_R4_FACTORVAL"
                                    v_strGR2_R4_FACTORVAL = Trim(v_strVALUE)
                                Case "GR2_R4_VIOLATIONID"
                                    v_strGR2_R4_VIOLATIONID = Trim(v_strVALUE)


                            End Select
                        End With
                    Next
                Next
            End If
            If v_strACCTNO <> String.Empty Then
                'Load thong tin chung
                lblvAcctno2.Text = v_strACCTNO
                lblvCustodycd2.Text = v_strCUSTODYCD
                lblvRtt_MR2.Text = Format(CDbl(v_strRTT_MR), "#,##0.###0")
                lblvRtt_TC2.Text = Format(CDbl(v_strRTT_TC), "#,##0.###0")
                lblvBRID2.Text = v_strBRID
                lblvBroker2.Text = v_strBROKER
                lblvGBroker2.Text = v_strGBROKER
                lblvNumSpclCall.Text = Format(CDbl(v_strNUMSPCLCALL), "#,##0")
                lblvNumCall.Text = Format(CDbl(v_strNUMCALL), "#,##0")
                lblvPayVal.Text = Format(CDbl(v_strPAYVAL), "#,##0")
                lblvSaleVal.Text = Format(CDbl(v_strSALEVAL), "#,##0")
                lblvBrokerGrpID.Text = v_strBRKRGRPID

                'Load thong tin Bo cong thuc goc cua loai hinh
                lblvGR1_R1_RM.Text = Format(CDbl(v_strGR1_R1_RM), "#,##0")
                lblvGR1_R2_RM.Text = Format(CDbl(v_strGR1_R2_RM), "#,##0")
                lblvGR1_R3_RM.Text = Format(CDbl(v_strGR1_R3_RM), "#,##0")
                lblvGR1_R4_RM.Text = Format(CDbl(v_strGR1_R4_RM), "#,##0")
                lblvGR1_R5_RM.Text = Format(CDbl(v_strGR1_R5_RM), "#,##0")
                lblvGR1_R6_RM.Text = Format(CDbl(v_strGR1_R6_RM), "#,##0")

                lblvGR1_R1_RB.Text = Format(CDbl(v_strGR1_R1_RB), "#,##0")
                lblvGR1_R2_RB.Text = Format(CDbl(v_strGR1_R2_RB), "#,##0")
                lblvGR1_R3_RB.Text = Format(CDbl(v_strGR1_R3_RB), "#,##0")
                lblvGR1_R4_RB.Text = Format(CDbl(v_strGR1_R4_RB), "#,##0")
                lblvGR1_R5_RB.Text = Format(CDbl(v_strGR1_R5_RB), "#,##0")
                lblvGR1_R6_RB.Text = Format(CDbl(v_strGR1_R6_RB), "#,##0")

                lblvGR1_R1_RC.Text = Format(CDbl(v_strGR1_R1_RC), "#,##0")
                lblvGR1_R2_RC.Text = Format(CDbl(v_strGR1_R2_RC), "#,##0")
                lblvGR1_R3_RC.Text = Format(CDbl(v_strGR1_R3_RC), "#,##0")
                lblvGR1_R4_RC.Text = Format(CDbl(v_strGR1_R4_RC), "#,##0")
                lblvGR1_R5_RC.Text = Format(CDbl(v_strGR1_R5_RC), "#,##0")
                lblvGR1_R6_RC.Text = Format(CDbl(v_strGR1_R6_RC), "#,##0")

                'Load thong tin gia tri cong bo sung
                lblvGR2_R1_ADDVAL.Text = Format(CDbl(v_strGR2_R1_ADDVAL), "#,##0")
                lblvGR2_R2_ADDVAL.Text = Format(CDbl(v_strGR2_R2_ADDVAL), "#,##0")
                lblvGR2_R3_ADDVAL.Text = Format(CDbl(v_strGR2_R3_ADDVAL), "#,##0")
                lblvGR2_R4_ADDVAL.Text = Format(CDbl(v_strGR2_R4_ADDVAL), "#,##0")

                lblvGR2_R1_ADDDAY.Text = Format(CDbl(v_strGR2_R1_ADDDAY), "#,##0")
                lblvGR2_R2_ADDDAY.Text = Format(CDbl(v_strGR2_R2_ADDDAY), "#,##0")
                lblvGR2_R3_ADDDAY.Text = Format(CDbl(v_strGR2_R3_ADDDAY), "#,##0")
                lblvGR2_R4_ADDDAY.Text = Format(CDbl(v_strGR2_R4_ADDDAY), "#,##0")

                lblvGR2_R1_FACTORVAL.Text = Format(CDbl(v_strGR2_R1_FACTORVAL), "#,##0.#") + "%"
                lblvGR2_R2_FACTORVAL.Text = Format(CDbl(v_strGR2_R2_FACTORVAL), "#,##0.#####")
                lblvGR2_R3_FACTORVAL.Text = Format(CDbl(v_strGR2_R3_FACTORVAL), "#,##0.#####")
                lblvGR2_R4_FACTORVAL.Text = String.Empty
                'lblvGR2_R4_FACTORVAL.Text = Format(CDbl(v_strGR2_R4_FACTORVAL), "#,##0.#")

                lblvGR2_R1_VIOLATIONID.Text = v_strGR2_R1_VIOLATIONID
                lblvGR2_R2_VIOLATIONID.Text = v_strGR2_R2_VIOLATIONID
                lblvGR2_R3_VIOLATIONID.Text = v_strGR2_R3_VIOLATIONID
                lblvGR2_R4_VIOLATIONID.Text = v_strGR2_R4_VIOLATIONID

            End If




        Catch ex As Exception
            MsgBox(ResourceManager.GetString("INVALID_INFO"), MsgBoxStyle.Information)
            'ResetScreen()
        End Try
    End Sub

    Private Sub OnClose()
        Me.Dispose()
    End Sub
#End Region

#Region "Form event"

#End Region

    Private Sub frmMarginInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mv_strLanguage = UserLanguage
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)
        LoadResource(Me.tpGroupInfo1)
        LoadResource(Me.tpGroupInfo2)
        LoadResource(Me.tcMarginInfo)
        tpGroupInfo1.Text = mv_ResourceManager.GetString("tpGroupInfo1")
        tpGroupInfo2.Text = mv_ResourceManager.GetString("tpGroupInfo2")

        InitData()
        InitData2()
    End Sub

    Private Sub frmMarginInfo_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                OnClose()
            
        End Select
    End Sub

  
End Class