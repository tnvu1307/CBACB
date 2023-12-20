Imports System.Globalization
Imports System.IO
Imports CommonLibrary
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Windows.Forms
Imports DevExpress.Utils
Imports DevExpress.XtraBars
Imports DevExpress.XtraEditors
Imports DevExpress.XtraTab
Imports AppCore
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors.Repository
Imports System.Xml
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DataAccessLayer
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base


Public Class frmCAVOTING

#Region " Declare constant and variables "
    Const c_ResourceManager = "_DIRECT.frmCAVOTING-"

    Private mv_blnIsRiskManagement As Boolean = False
    Private v_CUSTID As String

    Private mv_blnIsReject As Boolean = False
    Private mv_intExecFlag As Integer = ExecuteFlag.AddNew
    Private mv_strLanguage As String
    Private mv_resourceManager As Resources.ResourceManager
    Private mv_strBranchId As String
    Private mv_strTellerId As String
    Private mv_strTxnum As String
    Private mv_strTxdate As String
    Private mv_arrObjFields() As CFieldMaster
    Private mv_arrObjFldVals() As CFieldVal
    Public mv_strBrid As String
    Protected mv_strTableName As String
    Protected mv_arrSrFieldSrch() As String
    Private mv_arrSrFieldDisp() As String
    Private mv_arrSrFieldType() As String
    Private mv_arrSrFieldMask() As String

    Public mv_strTLid As String
    Private mv_strObjectName As String
    Private mv_strModuleCode As String
    Private mv_strLocalObject As String
    Private mv_strBusDate As String
    Private mv_strWsName As String
    Private mv_strIpAddress As String

    Dim mv_blnIsRunningSendSMS As Boolean = False
#End Region


#Region " Properties "




    Public Property IpAddress() As String
        Get
            Return mv_strIpAddress
        End Get
        Set(ByVal Value As String)
            mv_strIpAddress = Value
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

    Public Property LocalObject() As String
        Get
            Return mv_strLocalObject
        End Get
        Set(ByVal Value As String)
            mv_strLocalObject = Value
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
            Return mv_resourceManager
        End Get
        Set(ByVal Value As Resources.ResourceManager)
            mv_resourceManager = Value
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

    Public Property Txnum() As String
        Get
            Return mv_strTxnum
        End Get
        Set(ByVal Value As String)
            mv_strTxnum = Value
        End Set
    End Property

    Public Property Txdate() As String
        Get
            Return mv_strTxdate
        End Get
        Set(ByVal Value As String)
            mv_strTxdate = Value
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
#End Region
    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        UserLanguage = pv_strLanguage
        mv_resourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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

            'Lấy thông tin chung v? giao d�ịch
            v_strClause = "upper(TLTXCD) = '" & strTLTXCD & "'"
            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_TLTX, gc_ActionInquiry, , v_strClause)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i = 0 To v_nodeList.Count - 1
                For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = .InnerText.ToString
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "TXDESC"
                                'Me.Text = Trim(v_strValue)
                                Me.Text = ResourceManager.GetString(Me.Name)
                        End Select
                    End With
                Next
            Next

            'Lấy thông tin chi tiết các trư?ng c�ủa giao dịch
            v_strClause = "upper(OBJNAME) = '" & strTLTXCD & "' ORDER BY ODRNUM"
            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_FLDMASTER, gc_ActionInquiry, , v_strClause)
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
                                v_strCaption = Trim(v_strValue)
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
                        'v_strDefVal = Me.mv_strBusdate
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
            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_FLDVAL, gc_ActionInquiry, v_strClause)
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


    Public Sub OnInit()
        Dim v_strCmdSQL, v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_strSQL, V_strdt As String
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


        Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
        txtCA.Focus()
        Me.txtCA.BackColor = System.Drawing.Color.GreenYellow





        Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode
        Dim v_strcvalue, v_strnvalue, v_strfldcd, v_strFLDNAME, v_strValue, mv_strCmdSql As String
        ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & Me.Name & "-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadUserInterface(Me)



        Me.btnApprove.Visible = False
        Me.btnconfirm.Visible = True
        'Me.btnreject.Visible = False
        Me.btnADD.Visible = True
        Me.btnDEL.Visible = True



        lblCA.ForeColor = Color.Red


        mv_strTableName = "CAVOTING"


        'InitGridFromSearchCode("CAVOTING", Me.gridsbfundetf, Me.grvsbfundetf, , "Y", "Y", UserLanguage)
        'InitGridFromSearchCode("CAVOTING", Me.gridsbfundetf, Me.grvsbfundetf, , "Y", txtCA.Text, UserLanguage)

        Dim v_strCmdInquiry As String = "SELECT * FROM V_SEARCHCD WHERE 0=0 "
        Dim v_strClause As String = " UPPER(SEARCHCODE) = '" & mv_strTableName & "' ORDER BY POSITION"
        v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_SEARCHFLD, gc_ActionInquiry, v_strCmdInquiry, v_strClause, )
        v_ws.Message(v_strObjMsg)

        PrepareSearchParams(UserLanguage, v_strObjMsg, mv_strCaption, mv_strEnCaption, mv_strCmdSql, mv_strObjName, _
                mv_strFormName, mv_arrSrFieldSrch, mv_arrSrFieldDisp, mv_arrSrFieldType, mv_arrSrFieldMask, _
                mv_arrStFieldDefValue, mv_arrSrFieldOperator, mv_arrSrFieldFormat, mv_arrSrFieldDisplay, mv_arrSrFieldWidth, _
                mv_arrSrSQLRef, mv_arrStFieldMultiLang, mv_arrStFieldMandartory, mv_arrStFieldRefCDType, mv_arrStFieldRefCDName, _
                mv_strKeyColumn, mv_strKeyFieldType, mv_intSearchNum, mv_strRefColumn, mv_strRefFieldType, _
                mv_strSrOderByCmd, mv_strTLTXCD, mv_strIsSMS, mv_strIsEMAIL, mv_rowpage, mv_strSearchAuthCode, _
                mv_strRowLimit, mv_strCommandType, mv_strCondDefFld, mv_strBANKINQ, mv_strBANKACCT)

        gridsbfundetf.DataSource = InitGridSearchFields(mv_strTableName, mv_arrSrFieldSrch, mv_arrSrFieldDisp, mv_arrSrFieldType)
        grvsbfundetf.Columns("AUTOID").Visible = False
        grvsbfundetf.Columns("CAMASTID").Visible = False
        grvsbfundetf.Columns("VOTECODE").OptionsColumn.ReadOnly = True
        grvsbfundetf.Columns("VOTING").OptionsColumn.ReadOnly = True
        grvsbfundetf.Columns("RATE").OptionsColumn.ReadOnly = True
        'grvsbfundetf.Columns("RATE").DisplayFormat.FormatString = "n2"
        'grvsbfundetf.Columns("RATE").DisplayFormat.FormatType = FormatType.Numeric
    End Sub

    Private Sub PrepareDataSet(ByRef pv_ds As DataSet)
        Dim v_dc As DataColumn

        Try
            If Not (pv_ds Is Nothing) Then
                pv_ds.Dispose()
            End If

            pv_ds = New DataSet("INPUT")
            pv_ds.Tables.Add(TableName)

            For i As Integer = 0 To UBound(mv_arrObjFields) - 1
                v_dc = New DataColumn(mv_arrObjFields(i).FieldName)
                Select Case mv_arrObjFields(i).DataType
                    Case "C"
                        v_dc.DataType = GetType(String)
                    Case "D"
                        v_dc.DataType = GetType(System.DateTime)
                    Case "N"
                        v_dc.DataType = GetType(Double)
                    Case Else
                        v_dc.DataType = GetType(String)
                End Select

                pv_ds.Tables(0).Columns.Add(v_dc)
            Next
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub Onsave()
        Try

            Dim v_strTxMsg, str_data As String
            Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
            Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode, v_intIndex As Long, v_intCount As Integer
            Dim v_strFLDNAME As String, v_strFLDDEFNAME As String, v_strDATATYPE As String, v_strFLDVALUE As String
            Dim v_ctl As Control, v_attrFLDNAME As Xml.XmlAttribute, v_attrDATATYPE As Xml.XmlAttribute, v_objEval As New Evaluator
            Dim v_strErrorSource, v_strErrorMessage, v_strWarningMessage, v_strInfoMessage As String, v_lngError As Long
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery

            For i As Integer = 0 To grvsbfundetf.DataRowCount - 1
                str_data = str_data & grvsbfundetf.GetRowCellValue(i, "AUTOID") & "|" & grvsbfundetf.GetRowCellValue(i, "VOTECODE") & "|" & grvsbfundetf.GetRowCellValue(i, "RATE") & "#"
                If grvsbfundetf.GetRowCellValue(i, "RATE").ToString = "" Then
                    MsgBox(mv_resourceManager.GetString("valueRATEEMPTY"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Exit Sub
                End If
            Next
            LoadScreen("3349")
            v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, "3349", Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , Me.BusDate)
            v_xmlDocument.LoadXml(v_strTxMsg)
            v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")
            If mv_arrObjFields.GetLength(0) > 0 Then
                For v_intIndex = 0 To mv_arrObjFields.GetLength(0) - 1 Step 1
                    If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                        v_strFLDNAME = mv_arrObjFields(v_intIndex).FieldName
                        v_strDATATYPE = mv_arrObjFields(v_intIndex).DataType
                        Select Case Trim(v_strFLDNAME)
                            Case "03"
                                v_strFLDVALUE = txtCA.Text
                            Case "31"
                                v_strFLDVALUE = str_data
                            Case Else
                                v_strFLDVALUE = ""
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


                        v_xmlDocument.DocumentElement.AppendChild(v_dataElement)
                    End If
                Next
            End If
            v_strTxMsg = v_xmlDocument.InnerXml
            v_lngError = v_ws.Message(v_strTxMsg)


            If v_lngError <> ERR_SYSTEM_OK Then
                'Thông báo lỗi
                GetErrorFromMessage(v_strTxMsg, v_strErrorSource, v_lngError, v_strErrorMessage)
                Cursor.Current = Cursors.Default
                If v_lngError <> ERR_SA_CHECKER1_OVR And v_lngError <> ERR_SA_CHECKER2_OVR Then
                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, mv_resourceManager.GetString("frmCA"))
                    Exit Sub
                End If
            End If

            'submit 2
            v_lngError = v_ws.Message(v_strTxMsg)
            If v_lngError <> ERR_SYSTEM_OK Then
                GetErrorFromMessage(v_strTxMsg, v_strErrorSource, v_lngError, v_strErrorMessage)
                Cursor.Current = Cursors.Default
                MsgBox(mv_resourceManager.GetString("EMPTYVOTING"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            End If
            MsgBox(mv_resourceManager.GetString("TRANSSUCCESS") & vbCrLf & mv_resourceManager.GetString("TRANSSUCCESS1"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, mv_resourceManager.GetString("frmCA"))

            Me.Close()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LoadResource(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control

        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is Label Then
                CType(v_ctrl, Label).Text = mv_resourceManager.GetString(v_ctrl.Tag)
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                CType(v_ctrl, GroupBox).Text = mv_resourceManager.GetString(v_ctrl.Tag)
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Button Then
                CType(v_ctrl, Button).Text = mv_resourceManager.GetString(v_ctrl.Tag)
            ElseIf TypeOf (v_ctrl) Is CheckBox Then
                CType(v_ctrl, CheckBox).Text = mv_resourceManager.GetString(v_ctrl.Tag)
            End If
        Next


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

    Private Sub InitExternal()
        'Khoi tao grid

    End Sub
    Private Sub frmCA_Load(sender As Object, e As EventArgs) Handles Me.Load
        OnInit()
    End Sub

    Private Sub btnADD_Click(sender As Object, e As EventArgs) Handles btnADD.Click

        'Dim v_strCmdSQL, v_strObjMsg As String
        'Dim v_ws As New BDSDeliveryManagement
        'Dim v_strSQL, V_strdt As String
        'Dim v_ds As New DataSet
        'Dim tb As New DataTable


        'v_strCmdSQL = "SELECT sb.codeid VALUE , sb.symbol DISPLAY from  sbsecurities sb"

        'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        'v_ws.Message(v_strObjMsg)

        ''format column => comobox
        'CreateColumnLookupEdit(gridsbfundetf, v_strObjMsg, "CODEID", UserLanguage)


    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles btnconfirm.Click
        Onsave()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)
        Close()
    End Sub

    Private Sub btnexit_Click(sender As Object, e As EventArgs) Handles btnexit.Click
        Close()
    End Sub

    Private Sub btnDEL_Click(sender As Object, e As EventArgs) Handles btnDEL.Click
        grvsbfundetf.DeleteRow(grvsbfundetf.FocusedRowHandle)
    End Sub

    Private Sub OnClose()
        Me.Dispose()
    End Sub

    Private Sub frmCA_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Dim v_intPos As Int16, ctl As Control, strFLDNAME As String, v_intIndex As Integer
        Dim frm As New frmSearch(Me.UserLanguage)
        Select Case e.KeyCode
            Case Keys.Escape
                OnClose()
            Case Keys.Enter
                If Not TypeOf (Me.ActiveControl) Is Button Then
                    SendKeys.Send("{Tab}")
                    e.Handled = True

                End If
            Case Keys.F5
                If Me.ActiveControl.Name = "txtCA" Then
                    'ResetScreen(Me)
                    frm.TableName = "CAMAST"
                    frm.ModuleCode = "CA"
                    frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                    frm.IsLocalSearch = gc_IsNotLocalMsg
                    frm.IsLookup = "Y"
                    frm.SearchOnInit = False
                    frm.BranchId = Me.BranchId
                    frm.TellerId = Me.TellerId
                    frm.ShowDialog()
                    If Len(frm.ReturnValue) > 0 Then
                        Me.txtCA.Text = Trim(frm.ReturnValue)
                    End If
                    frm.Dispose()
                End If
        End Select
    End Sub

    Private Sub txtCA_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCA.KeyUp
        Dim frm As New frmSearch(Me.UserLanguage)
        Select Case e.KeyCode
            Case Keys.F5
                'ResetScreen(Me)
                frm.TableName = "CAMAST_VOTING"
                frm.ModuleCode = "CA"
                frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                frm.IsLocalSearch = gc_IsNotLocalMsg
                frm.IsLookup = "Y"
                frm.SearchOnInit = False
                frm.BranchId = Me.BranchId
                frm.TellerId = Me.TellerId
                frm.ShowDialog()
                If Len(frm.RefValue) > 0 Then
                    Me.txtCA.Text = Trim(frm.ReturnValue)
                End If
                frm.Dispose()
        End Select

    End Sub
    Private Sub txtCA_EditValueChanged(sender As Object, e As EventArgs) Handles txtCA.EditValueChanged
        InitGridFromSearchCode("CAVOTING", Me.gridsbfundetf, Me.grvsbfundetf, , "Y", txtCA.Text.Replace(".", ""), UserLanguage)

        grvsbfundetf.OptionsBehavior.Editable = True

        grvsbfundetf.OptionsBehavior.ReadOnly = False
        grvsbfundetf.Columns("AUTOID").Visible = False
        grvsbfundetf.Columns("CAMASTID").Visible = False
        grvsbfundetf.Columns("VOTECODE").OptionsColumn.ReadOnly = True
        grvsbfundetf.Columns("VOTING").OptionsColumn.ReadOnly = True
        grvsbfundetf.Columns("RATE").OptionsColumn.ReadOnly = False


    End Sub
    Private Sub txtCA_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtCA.Validating
        If txtCA.Text = "" Then
            txtCA.Focus()
            txtCA.ErrorText = mv_resourceManager.GetString("txtCAID")
            e.Cancel = True
        End If
    End Sub

    Private Sub grvsbfundetf_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles grvsbfundetf.ValidatingEditor
        Dim selectedRows() As Integer = grvsbfundetf.GetSelectedRows()
        For Each rowHandle As Integer In selectedRows
            If grvsbfundetf.FocusedColumn.FieldName = "RATE" Then
                If IsNumeric(grvsbfundetf.EditingValue) = True Then
                    If grvsbfundetf.EditingValue < 0 Then
                        e.Valid = False
                        e.ErrorText = mv_resourceManager.GetString("valueRATE")
                    Else
                        grvsbfundetf.ClearColumnErrors()
                    End If
                End If
                If IsNumeric(grvsbfundetf.EditingValue) = False Then
                    e.Valid = False
                    e.ErrorText = mv_resourceManager.GetString("valueRATE1")
                Else
                    grvsbfundetf.ClearColumnErrors()
                End If
                'If grvsbfundetf.EditingValue = "" Then
                '    e.Valid = False
                '    e.ErrorText = mv_resourceManager.GetString("valueRATEEMPTY")
                'Else
                '    grvsbfundetf.ClearColumnErrors()
                'End If
                'grvsbfundetf.Columns("AUTOID").
                'Dim view As GridView = TryCast(sender, GridView)
                'If view.ActiveEditor.IsModified = False Then
                '    e.Valid = False
                '    e.ErrorText = mv_resourceManager.GetString("valueRATEEMPTY")
                'End If
            End If
        Next
    End Sub

    Private Sub grvsbfundetf_BeforeLeaveRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles grvsbfundetf.BeforeLeaveRow
        Dim selectedRows() As Integer = grvsbfundetf.GetSelectedRows()
        For Each rowHandle As Integer In selectedRows
            If grvsbfundetf.GetRowCellValue(e.RowHandle, "RATE") Is System.DBNull.Value Then
                grvsbfundetf.SetRowCellValue(rowHandle, "RATE", 1)
            End If
        Next
    End Sub


    'Private Sub grvsbfundetf_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles grvsbfundetf.CustomDrawCell
    '    Dim view = TryCast(sender, GridView)

    '    Dim listSourceRowIndex = view.GetDataSourceRowIndex(e.RowHandle)

    '    Dim changedCell = New GridChangedCellInfo(listSourceRowIndex, e.Column)
    'End Sub
End Class