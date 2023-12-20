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
Imports DevExpress.Data


Public Class frmSBETF

#Region " Declare constant and variables "
    Const c_ResourceManager = "_DIRECT.frmSBETF-"

    Private mv_blnIsRiskManagement As Boolean = False
    Private v_CUSTID As String
    Public Const gc_COMPANY_CODE = "SHVF"
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
    Private mv_strNextDate As String
    Dim mv_blnIsRunningSendSMS As Boolean = False
#End Region


#Region " Properties "

    Public Property NextDate() As String
        Get
            Return mv_strNextDate
        End Get
        Set(ByVal Value As String)
            mv_strNextDate = Value
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
        txtCustodycd.Focus()
        Me.txtCustodycd.BackColor = System.Drawing.Color.GreenYellow
        txtCustodycd.Text = gc_COMPANY_CODE

        txtdesc.Text = mv_resourceManager.GetString("DESCETF")
        
        'AddColumnExtGridControl()
        Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode
        Dim v_strcvalue, v_strnvalue, v_strfldcd, v_strFLDNAME, v_strValue, mv_strCmdSql As String
        ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & Me.Name & "-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadUserInterface(Me)
        InitVisibleColumnGrid(cbotype.EditValue)
        'loai giao dich
        v_strCmdSQL = "SELECT CDVAL VALUECD,CDVAL VALUE,CDCONTENT DISPLAY , EN_CDCONTENT EN_DISPLAY FROM ALLCODE WHERE CDNAME = 'TYPEETF'  ORDER BY CDVAL"
        v_strObjMsg = BuildXMLObjMsg(, "000001", , "0001", gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        cbotype.Refresh()
        FillXtraLookUpEdit(v_strObjMsg, cbotype, "", Me.UserLanguage)
        ''chung chi quy
        v_strCmdSQL = "SELECT CODEID VALUE,SYMBOL DISPLAY , SYMBOL EN_DISPLAY FROM SBSECURITIES WHERE SECTYPE = '008' AND tradeplace <> '006'  AND STATUS = 'Y' ORDER BY SYMBOL"
        v_strObjMsg = BuildXMLObjMsg(, "000001", , "0001", gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)
        FillXtraLookUpEdit(v_strObjMsg, cboETFID, "", Me.UserLanguage)
        Dim v_sts As String = "select to_char(getcurrdate,'dd/MM/rrrr')  DATEVALUE from dual"
        'Dim v_ws As New BDSDeliveryManagement
        Dim v_strObjMsgdate As String = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CF_CFMAST, _
            gc_ActionInquiry, v_sts)
        v_ws.Message(v_strObjMsgdate)
        'Dim v_nodeList As Xml.XmlNodeList
        Dim XmlDocument As New Xml.XmlDocument
        Dim v_strValuedate As String
        XmlDocument.LoadXml(v_strObjMsgdate)
        v_nodeList = XmlDocument.SelectNodes("/ObjectMessage/ObjData")
        For i As Integer = 0 To v_nodeList.Count - 1
            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                With v_nodeList.Item(i).ChildNodes(j)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strValue = .InnerText.ToString
                    Select Case Trim(v_strFLDNAME)
                        Case "DATEVALUE"
                            dtpmsktxdate.EditValue = gf_Cdate(v_strValue)
                            'dtpmsksetdate.EditValue = gf_Cdate(v_strValue).AddDays(1)
                            dtpmsksetdate.EditValue = mv_strNextDate
                    End Select
                End With
            Next
        Next
        format_lbl()
        If ExeFlag <> ExecuteFlag.Edit Then
            Me.btnApprove.Visible = False
            Me.btnconfirm.Visible = True
            'Me.btnreject.Visible = False
            Me.btnADD.Visible = True
            Me.btnDEL.Visible = True
            mv_strTableName = "ETFSWAP"
            cboCTCK.Properties.NullText = ""
            cbbTVLQ.Properties.NullText = ""
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

            'InitGridFromSearchCode("ETFSWAP", Me.gridsbfundetf, Me.grvsbfundetf, , "Y", "Y", UserLanguage)
            gridsbfundetf.DataSource = InitGridSearchFields(mv_strTableName, mv_arrSrFieldSrch, mv_arrSrFieldDisp, mv_arrSrFieldType)
            grvsbfundetf.OptionsBehavior.ReadOnly = False
            grvsbfundetf.Columns("AMT").OptionsColumn.ReadOnly = True
            grvsbfundetf.Columns("PRICE").DisplayFormat.FormatString = "n2"
            grvsbfundetf.Columns("PRICE").DisplayFormat.FormatType = FormatType.Numeric
            grvsbfundetf.Columns("AMT").DisplayFormat.FormatString = "n2"
            grvsbfundetf.Columns("AMT").DisplayFormat.FormatType = FormatType.Numeric
            grvsbfundetf.Columns("QTTY").DisplayFormat.FormatString = "n2"
            grvsbfundetf.Columns("QTTY").DisplayFormat.FormatType = FormatType.Numeric
            'v_strCmdSQL = "SELECT SB.CODEID VALUE , SB.SYMBOL DISPLAY,SB.SYMBOL EN_DISPLAY FROM  SBSECURITIES SB where sb.tradeplace <> '006' and sb.sectype <> '004'"
            'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            'v_ws.Message(v_strObjMsg)
            'format column => comobox
            'CreateColumnLookupEdit(gridsbfundetf, v_strObjMsg, "CODEID", Me.UserLanguage)
            LoadComboSymbol()
            AddColumnExtGridControl()
        End If
        cbotype.EditValue = "NS"

        If ExeFlag <> ExecuteFlag.AddNew Then
            Me.btnApprove.Visible = False
            Me.btnconfirm.Visible = False
            'Me.btnreject.Visible = False
            Me.btnADD.Visible = False
            Me.btnDEL.Visible = False

            Dim text As String
            v_strCmdSQL = "SELECT fldcd,cvalue,nvalue FROM tllogfld WHERE  txdate = to_date('" & Txdate & "','DD/MM/RRRR')  AND txnum = '" & Txnum & "' order by fldcd"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            Dim cbCTCK_Text, cbbAP_Text As String

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Count - 1
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strValue = .InnerText.ToString
                        Select Case Trim(v_strFLDNAME)
                            Case "FLDCD"
                                v_strfldcd = v_strValue
                            Case "CVALUE"
                                v_strcvalue = v_strValue
                            Case "NVALUE"
                                v_strnvalue = v_strValue
                        End Select
                        Select Case v_strfldcd
                            Case "03"
                                cboETFID.EditValue = v_strcvalue
                                cboETFID.Enabled = False
                            Case "05"
                                cboCTCK.EditValue = v_strcvalue
                                cbCTCK_Text = v_strcvalue
                                cboCTCK.Enabled = False
                            Case "06"
                                txtETXQUANTITY.Text = v_strnvalue
                                txtETXQUANTITY.Enabled = False
                            Case "07"
                                txtFullname.Text = v_strcvalue
                                txtFullname.Enabled = False
                            Case "08"
                                txtmsknavccq.Text = v_strnvalue
                                txtmsknavccq.EditValue = v_strnvalue
                                txtmsknavccq.Enabled = False
                            Case "09"
                                txtmskamount.Text = v_strnvalue
                                txtmskamount.Enabled = False
                            Case "10"
                                txtFEE.Text = v_strnvalue
                                txtFEE.Enabled = False
                            Case "11"
                                txtTAX.Text = v_strnvalue
                                txtTAX.Enabled = False
                            Case "12"
                                cbotype.EditValue = v_strcvalue
                                cbotype.Enabled = False
                            Case "20"
                                If IsDate(v_strcvalue) = True Then
                                    dtpmsktxdate.EditValue = v_strcvalue
                                    dtpmsktxdate.Enabled = False
                                End If
                            Case "30"
                                txtdesc.Text = v_strcvalue
                                txtdesc.Enabled = False
                            Case "40"
                                If IsDate(v_strcvalue) = True Then
                                    dtpmsksetdate.EditValue = v_strcvalue
                                    dtpmsksetdate.Enabled = False
                                End If
                            Case "41"
                                txtmskdiffe_db.Text = v_strnvalue
                                txtmskdiffe.Enabled = False
                                txtmskdiffe_db.Enabled = False
                            Case "50"
                                V_strdt = v_strcvalue
                            Case "82"
                                txtETFNAME.Text = v_strcvalue
                                txtETFNAME.Enabled = False
                            Case "83"
                                cbbTVLQ.EditValue = v_strcvalue
                                cbbAP_Text = v_strcvalue
                                cbbTVLQ.Enabled = False
                            Case "88"
                                txtCustodycd.Text = v_strcvalue
                                If txtCustodycd.Text.Length = 10 Then
                                    GetMEMBERInfo_Edit(txtCustodycd.Text, cbCTCK_Text)
                                    GetAPInfo_Edit(txtCustodycd.Text, cbbAP_Text)
                                    txtCustodycd.Enabled = False
                                End If
                        End Select

                    End With
                Next
            Next

            If Not String.IsNullOrEmpty(V_strdt) Then
                InitGridFromSearchCode("ETFSWAP_GRID", Me.gridsbfundetf, Me.grvsbfundetf, "", "Y", V_strdt)
            End If
            InitVisibleColumnGrid(cbotype.EditValue)
            format_column()
            CalDifAndValue()
        End If

    End Sub
    Private Sub format_lbl()
        lblCustodycd.ForeColor = Color.Red
        lblCTCK.ForeColor = Color.Blue
        tblETFID.ForeColor = Color.Red
        lblETXQUANTITY.ForeColor = Color.Red
        lblFEE.ForeColor = Color.Red
        lblTAX.ForeColor = Color.Red
        tblmskdiffe.ForeColor = Color.Red
        tblmskdiffe_db.ForeColor = Color.Red
        tblmskamount.ForeColor = Color.Red

        tblFullname.ForeColor = Color.Blue
        lblETFNAME.ForeColor = Color.Blue
        lblTVLQ.ForeColor = Color.Blue
        tbltype.ForeColor = Color.Red
        tblmsknavccq.ForeColor = Color.Red

        tbldesc.ForeColor = Color.Blue
        lblmsknavdate.ForeColor = Color.Red
        lblmsksetdate.ForeColor = Color.Red

    End Sub
    Private Sub format_column()
        grvsbfundetf.Columns("PRICE").DisplayFormat.FormatString = "n2"
        grvsbfundetf.Columns("PRICE").DisplayFormat.FormatType = FormatType.Numeric
        grvsbfundetf.Columns("AMT").DisplayFormat.FormatString = "n2"
        grvsbfundetf.Columns("AMT").DisplayFormat.FormatType = FormatType.Numeric
        grvsbfundetf.Columns("QTTY").DisplayFormat.FormatString = "n2"
        grvsbfundetf.Columns("QTTY").DisplayFormat.FormatType = FormatType.Numeric
        grvsbfundetf.Columns("APQTTY").DisplayFormat.FormatString = "n2"
        grvsbfundetf.Columns("APQTTY").DisplayFormat.FormatType = FormatType.Numeric
        grvsbfundetf.Columns("HOLD").DisplayFormat.FormatString = "n2"
        grvsbfundetf.Columns("HOLD").DisplayFormat.FormatType = FormatType.Numeric

        '-------
        grvsbfundetf.OptionsBehavior.ReadOnly = True
        grvsbfundetf.OptionsView.ColumnAutoWidth = True
        grvsbfundetf.OptionsBehavior.ReadOnly = True
        grvsbfundetf.OptionsView.NewItemRowPosition = NewItemRowPosition.None
        grvsbfundetf.OptionsBehavior.AllowAddRows = DefaultBoolean.False
        grvsbfundetf.OptionsBehavior.AllowDeleteRows = DefaultBoolean.False
    End Sub

    Private Sub LoadComboSymbol()

        Dim colList As GridColumn = Me.grvsbfundetf.Columns("CODEID")

        If (colList Is Nothing) Then
            Return
        End If

        ' Init control
        Dim repositoryItemGridLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit()
        Dim repositoryItemGridLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView = New DevExpress.XtraGrid.Views.Grid.GridView()

        repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View"
        repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = False
        repositoryItemGridLookUpEdit.NullText = ""
        repositoryItemGridLookUpEdit.AutoHeight = False

        repositoryItemGridLookUpEdit.Name = "repositoryItemGridLookUpEdit"
        repositoryItemGridLookUpEdit.View = repositoryItemGridLookUpEdit1View
        '

        Dim v_strSQLCMD, v_strObjMsg, v_strClause As String
        Dim v_ws As New BDSDeliveryManagement

        v_strSQLCMD = "SELECT SB.CODEID VALUE , SB.SYMBOL DISPLAY,SB.SYMBOL EN_DISPLAY FROM  SBSECURITIES SB where sb.tradeplace <> '006' and sb.sectype <> '004'"
        'Lay thong tin chung ve giao dich   
        v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strSQLCMD, "")
        v_ws.Message(v_strObjMsg)

        Dim dt As New DataTable
        XmlStringToDataTable(v_strObjMsg, dt)


        repositoryItemGridLookUpEdit.DataSource = dt
        repositoryItemGridLookUpEdit.DisplayMember = "DISPLAY"
        repositoryItemGridLookUpEdit.ValueMember = "VALUE"

        repositoryItemGridLookUpEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        repositoryItemGridLookUpEdit.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains
        repositoryItemGridLookUpEdit.ImmediatePopup = True
        repositoryItemGridLookUpEdit.View.Columns.Clear()

        Dim aColumnCode1 As GridColumn = repositoryItemGridLookUpEdit.View.Columns.AddField("VALUE")
        'aColumnCode1.Caption = ""
        'aColumnCode1.Visible = False
        'aColumnCode1.VisibleIndex = 1
        'aColumnCode1.Width = 300

        Dim aColumnCode As GridColumn = repositoryItemGridLookUpEdit.View.Columns.AddField("DISPLAY")
        aColumnCode.Caption = "Symbol"
        aColumnCode.Visible = True
        aColumnCode.VisibleIndex = 2
        aColumnCode.Width = 100


        colList.ColumnEdit = Nothing
        colList.ColumnEdit = repositoryItemGridLookUpEdit

    End Sub

    Public Shared Sub XmlStringToDataTable(ByVal xmlStr As String, ByRef dt As DataTable)
        Try
            Dim xml As XmlDocument = New XmlDocument()
            xml.LoadXml(xmlStr)
            Dim xmlNodeList As XmlNodeList = xml.SelectNodes("/ObjectMessage/ObjData")
            If xmlNodeList IsNot Nothing Then
                If dt Is Nothing Then
                    dt = New DataTable
                End If
                For Each nodeObject As XmlNode In xmlNodeList

                    Dim row As DataRow = dt.NewRow()
                    For Each node As XmlNode In nodeObject.ChildNodes
                        If node.FirstChild Is Nothing Then
                            Continue For
                        End If
                        Dim col As DataColumn = New DataColumn()
                        If node.Attributes("fldname") IsNot Nothing Then
                            col.ColumnName = node.Attributes("fldname").Value
                        End If
                        col.DataType = Type.GetType(node.Attributes("fldtype").Value)
                        If (Not dt.Columns.Contains(col.ColumnName)) Then
                            dt.Columns.Add(col)
                        End If
                        row(col.ColumnName) = node.FirstChild.Value
                    Next
                    dt.Rows.Add(row)
                Next
            End If
        Catch ex As Exception
            dt = Nothing
        End Try
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

            If Not VerifyRules() Then
                Exit Sub
            End If

            Dim qtt_all_gr As Double


            Dim v_strTxMsg, str_data As String
            Dim v_xmlDocument As New Xml.XmlDocument, v_dataElement As Xml.XmlElement, v_entryNode As Xml.XmlNode
            Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode, v_intIndex As Long, v_intCount As Integer
            Dim v_strFLDNAME As String, v_strFLDDEFNAME As String, v_strDATATYPE As String, v_strFLDVALUE As String
            Dim v_ctl As Control, v_attrFLDNAME As Xml.XmlAttribute, v_attrDATATYPE As Xml.XmlAttribute, v_objEval As New Evaluator
            Dim v_strErrorSource, v_strErrorMessage, v_strWarningMessage, v_strInfoMessage As String, v_lngError As Long
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery

            CalDifAndValue()
            For i As Integer = 0 To grvsbfundetf.DataRowCount - 1
                str_data = str_data & grvsbfundetf.GetRowCellValue(i, "CODEID") & "|" & grvsbfundetf.GetRowCellValue(i, "QTTY") & "|" & grvsbfundetf.GetRowCellValue(i, "APQTTY") & "|" & grvsbfundetf.GetRowCellValue(i, "HOLD") & "|" & grvsbfundetf.GetRowCellValue(i, "PRICE") & "|" & grvsbfundetf.GetRowCellValue(i, "AMT") & "|" & grvsbfundetf.GetRowCellValue(i, "APACCOUNT") & "#"
            Next
            If txtmskdiffe.Text <> 0 Then
                If MsgBox(mv_resourceManager.GetString("DIFFE"), MsgBoxStyle.Critical + MsgBoxStyle.YesNo, gc_ApplicationTitle) = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
            LoadScreen("8894")
            'v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, "8894", Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , dtpmsktxdate.EditValue.ToString(), , , , , , , )
            v_strTxMsg = BuildXMLTxMsg(gc_MsgTypeTrans, gc_IsLocalMsg, "8894", Me.BranchId, Me.TellerId, Me.IpAddress, Me.WsName, , , , , , , , , , , , , , , , , dtpmsktxdate.EditValue, )
            v_xmlDocument.LoadXml(v_strTxMsg)
            v_dataElement = v_xmlDocument.CreateElement(Xml.XmlNodeType.Element, "fields", "")
            If mv_arrObjFields.GetLength(0) > 0 Then
                For v_intIndex = 0 To mv_arrObjFields.GetLength(0) - 1 Step 1
                    If Not mv_arrObjFields(v_intIndex) Is Nothing Then
                        v_strFLDNAME = mv_arrObjFields(v_intIndex).FieldName
                        v_strDATATYPE = mv_arrObjFields(v_intIndex).DataType
                        Select Case Trim(v_strFLDNAME)
                            Case "88"
                                v_strFLDVALUE = txtCustodycd.Text
                            Case "82"
                                v_strFLDVALUE = txtETFNAME.Text
                            Case "83"
                                v_strFLDVALUE = cbbTVLQ.EditValue
                            Case "03"
                                v_strFLDVALUE = cboETFID.EditValue
                            Case "05"
                                v_strFLDVALUE = cboCTCK.EditValue
                            Case "06"
                                v_strFLDVALUE = txtETXQUANTITY.Text
                            Case "07"
                                v_strFLDVALUE = txtFullname.Text
                            Case "08"
                                v_strFLDVALUE = txtmsknavccq.Text
                            Case "09"
                                v_strFLDVALUE = txtmskamount.Text
                            Case "10"
                                v_strFLDVALUE = txtFEE.Text
                            Case "11"
                                v_strFLDVALUE = txtTAX.Text
                            Case "12"
                                v_strFLDVALUE = cbotype.EditValue
                            Case "50"
                                v_strFLDVALUE = str_data
                            Case "20"
                                v_strFLDVALUE = dtpmsktxdate.EditValue
                            Case "40"
                                v_strFLDVALUE = dtpmsksetdate.EditValue
                            Case "41"
                                'v_strFLDVALUE = txtmskdiffe.Text
                                v_strFLDVALUE = txtmskdiffe_db.Text
                            Case "30"
                                v_strFLDVALUE = txtdesc.Text
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
                    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, mv_resourceManager.GetString("frmSBETF"))
                    Exit Sub
                End If
            End If

            'submit 2
            v_lngError = v_ws.Message(v_strTxMsg)
            If v_lngError <> ERR_SYSTEM_OK Then
                GetErrorFromMessage(v_strTxMsg, v_strErrorSource, v_lngError, v_strErrorMessage)
                Cursor.Current = Cursors.Default
                MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
            End If
            MsgBox(mv_resourceManager.GetString("TRANSSUCCESS") & vbCrLf & mv_resourceManager.GetString("TRANSSUCCESS1"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, mv_resourceManager.GetString("frmSBETF"))
            ResetScreen()
            'Me.Close()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ResetScreen()
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
        Dim mv_strCaption, mv_strEnCaption, mv_strObjName, mv_strCmdSql As String
        Dim mv_arrSrFieldWidth() As Integer

        txtCustodycd.Text = "SHVF"
        txtETFNAME.Text = ""
        txtETXQUANTITY.Text = "0"
        txtFEE.Text = "0"
        txtFullname.Text = ""
        txtmskamount.Text = "0"
        txtmsknavccq.Text = "0"
        txtTAX.Text = "0"

        cboCTCK.EditValue = vbNullString
        cbotype.EditValue = vbNullString
        cboETFID.EditValue = vbNullString


        mv_strTableName = "ETFSWAP"


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
        grvsbfundetf.OptionsBehavior.ReadOnly = False
        grvsbfundetf.Columns("PRICE").OptionsColumn.ReadOnly = True
        grvsbfundetf.Columns("AMT").OptionsColumn.ReadOnly = True

        grvsbfundetf.Columns("PRICE").DisplayFormat.FormatString = "n2"
        grvsbfundetf.Columns("PRICE").DisplayFormat.FormatType = FormatType.Numeric
        grvsbfundetf.Columns("AMT").DisplayFormat.FormatString = "n2"
        grvsbfundetf.Columns("AMT").DisplayFormat.FormatType = FormatType.Numeric
        grvsbfundetf.Columns("QTTY").DisplayFormat.FormatString = "n2"
        grvsbfundetf.Columns("QTTY").DisplayFormat.FormatType = FormatType.Numeric
        grvsbfundetf.Columns("APQTTY").DisplayFormat.FormatString = "n2"
        grvsbfundetf.Columns("APQTTY").DisplayFormat.FormatType = FormatType.Numeric
        grvsbfundetf.Columns("HOLD").DisplayFormat.FormatString = "n2"
        grvsbfundetf.Columns("HOLD").DisplayFormat.FormatType = FormatType.Numeric



        v_strCmdSQL = "SELECT SB.CODEID VALUE , SB.SYMBOL DISPLAY,SB.SYMBOL EN_DISPLAY FROM  SBSECURITIES SB"

        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)

        'format column => comobox
        CreateColumnLookupEdit(gridsbfundetf, v_strObjMsg, "CODEID", Me.UserLanguage)
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
    Private Sub frmSBETF_Load(sender As Object, e As EventArgs) Handles Me.Load
        OnInit()
    End Sub

    Private Sub btnADD_Click(sender As Object, e As EventArgs) Handles btnADD.Click

        Dim v_strCmdSQL, v_strObjMsg As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_strSQL, V_strdt As String
        Dim v_ds As New DataSet
        Dim tb As New DataTable


        v_strCmdSQL = "SELECT sb.codeid VALUE , sb.symbol DISPLAY from  sbsecurities sb"

        v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
        v_ws.Message(v_strObjMsg)

        'format column => comobox
        CreateColumnLookupEdit(gridsbfundetf, v_strObjMsg, "CODEID", UserLanguage)


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


    Private Sub txtCustodycd_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCustodycd.KeyUp
        'Dim frm As New frmSearch(Me.UserLanguage)
        Dim frm As New frmXtraSearchLookup(Me.UserLanguage)
        Select Case e.KeyCode
            Case Keys.F5
                'ResetScreen(Me)
                frm.TableName = "CUSTODYCD_CF"
                frm.ModuleCode = "CF"
                frm.AuthCode = "NNNNYYNNNN" 'Không cho phép thực hiện chức năng nào 
                frm.IsLocalSearch = gc_IsNotLocalMsg
                frm.IsLookup = "Y"
                frm.SearchOnInit = False
                frm.BranchId = Me.BranchId
                frm.TellerId = Me.TellerId

                frm.ShowDialog()


                If Len(frm.RefValue) > 0 Then
                    txtFullname.Text = frm.RefValue
                End If
                If Len(frm.RefValue) > 0 Then
                    Me.txtCustodycd.Text = Trim(frm.ReturnValue)
                End If

                frm.Dispose()
        End Select

    End Sub

    Protected Function VerifyRules() As Boolean

        If grvsbfundetf.DataRowCount = 0 Then
            MsgBox(mv_resourceManager.GetString("GridEmpty"), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            grvsbfundetf.Focus()
            Return False
        End If
        If Me.cboETFID.EditValue = "" Then
            MsgBox(mv_resourceManager.GetString("ETFNewEmptyMsg"), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            cboETFID.Focus()
            Return False
        End If

        'If Me.cboCTCK.EditValue = "" Then
        '    MsgBox(mv_resourceManager.GetString("CTCKEmptyMsg"), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        '    cboCTCK.Focus()
        '    Return False
        'End If
        If Val(txtETXQUANTITY.Text) <= 0 Then
            MsgBox(mv_resourceManager.GetString("QTTYERR"), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            txtETXQUANTITY.Focus()
            Return False
        End If
        If Me.cbotype.EditValue = "" Then
            MsgBox(mv_resourceManager.GetString("TypeEmptyMsg"), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            cbotype.Focus()
            Return False
        End If
        If Val(Me.txtmsknavccq.Text) <= 0 Then
            MsgBox(mv_resourceManager.GetString("MSKRRR"), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            txtmsknavccq.Focus()
            Return False
        End If

        If Val(txtmskamount.Text) <= 0 Then
            MsgBox(mv_resourceManager.GetString("AMOUNTERR"), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            txtmskamount.Focus()
            Return False
        End If

        If Val(txtFEE.Text) < 0 Then
            MsgBox(mv_resourceManager.GetString("FEEERR"), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            txtFEE.Focus()
            Return False
        End If

        If Val(txtTAX.Text) < 0 Then
            MsgBox(mv_resourceManager.GetString("TAXERR"), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            txtTAX.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub GetMEMBERInfo(ByVal v_strSTC As String)
        Try
            Dim v_strCmdSQL As String, v_strObjMsg As String
            Dim v_ws As New BDSDeliveryManagement
            v_strCmdSQL = "SELECT FILTERCD, VALUE, VALUECD, DISPLAY, EN_DISPLAY, DESCRIPTION FROM VW_CUSTODYCD_MEMBER WHERE FILTERCD='" & v_strSTC & "' ORDER BY VALUE"

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            FillXtraLookUpEdit(v_strObjMsg, cboCTCK, "", Me.UserLanguage)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GetMEMBERInfo_Edit(ByVal v_strSTC As String, ByVal v_value As String)
        Try
            Dim v_strCmdSQL As String, v_strObjMsg As String
            Dim v_ws As New BDSDeliveryManagement
            v_strCmdSQL = "SELECT FILTERCD, VALUE, VALUECD, DISPLAY, EN_DISPLAY, DESCRIPTION FROM VW_CUSTODYCD_MEMBER WHERE FILTERCD='" & v_strSTC & "' and value= '" & v_value & "' "

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            FillXtraLookUpEdit(v_strObjMsg, cboCTCK, "", Me.UserLanguage)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GetAPInfo(ByVal v_strSTC As String)
        Try
            Dim v_strCmdSQL As String, v_strObjMsg As String
            Dim v_ws As New BDSDeliveryManagement
            v_strCmdSQL = "SELECT FILTERCD,VALUE,VALUECD,DISPLAY ,EN_DISPLAY FROM VW_CUSTODYCD_MEMBERAP_CF vw, cfmast cf where vw.filtercd = cf.custid and cf.custodycd = '" & v_strSTC & "' and cf.status <> 'C'"

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            FillXtraLookUpEdit(v_strObjMsg, cbbTVLQ, "", Me.UserLanguage)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GetAPInfo_Edit(ByVal v_strSTC As String, ByVal v_value As String)
        Try
            Dim v_strCmdSQL As String, v_strObjMsg As String
            Dim v_ws As New BDSDeliveryManagement
            v_strCmdSQL = "SELECT FILTERCD,VALUE,VALUECD,DISPLAY ,EN_DISPLAY FROM VW_CUSTODYCD_MEMBERAP_CF vw, cfmast cf where vw.filtercd = cf.custid and cf.custodycd ='" & v_strSTC & "' and VALUE= '" & v_value & "' "

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            FillXtraLookUpEdit(v_strObjMsg, cbbTVLQ, "", Me.UserLanguage)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GetNAME(ByVal v_strSTC As String)
        Try
            Dim v_strCmdSQL As String, v_strObjMsg As String
            Dim v_ws As New BDSDeliveryManagement
            Dim v_nodeList As XmlNodeList
            Dim v_xmlDocument As New XmlDocument
            v_strCmdSQL = "SELECT FULLNAME,CUSTID from cfmast WHERE CUSTODYCD='" & v_strSTC & "'"

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            Dim v_strValue, v_strFLDNAME, v_strTEXT, v_strMINBRATIO, v_strMAXBRATIO As String, i, j As Integer

            If v_nodeList.Count > 0 Then
                For i = 0 To v_nodeList.Count - 1
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            'Ghi nhận thuật toán để kiểm tra và tính toán cho từng trư?ng c�ủa giao dịch
                            v_strValue = .InnerText.ToString
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "FULLNAME"
                                    txtFullname.Text = Trim(v_strValue)
                                Case "CUSTID"
                                    v_CUSTID = Trim(v_strValue)
                            End Select
                        End With
                    Next
                Next
            Else
                txtFullname.Text = ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function GetETFNAME(ByVal v_strSTC As String) As String
        Try
            Dim v_strCmdSQL As String, v_strObjMsg As String
            Dim v_ws As New BDSDeliveryManagement
            Dim v_nodeList As XmlNodeList
            Dim v_xmlDocument As New XmlDocument
            Dim v_strValue, v_strFLDNAME, v_strTEXT, v_strMINBRATIO, v_strMAXBRATIO As String, i, j As Integer
            Dim name, en_name As String


            v_strCmdSQL = "SELECT ISS.FULLNAME DISPLAY,ISS.EN_FULLNAME EN_DISPLAY  FROM SBSECURITIES SB, ISSUERS ISS WHERE SB.ISSUERID = ISS.ISSUERID  and sb.codeid='" & v_strSTC & "'"

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count > 0 Then
                For i = 0 To v_nodeList.Count - 1
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            'Ghi nhận thuật toán để kiểm tra và tính toán cho từng trư?ng c�ủa giao dịch
                            v_strValue = .InnerText.ToString
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "DISPLAY"
                                    name = Trim(v_strValue)
                                Case "EN_DISPLAY"
                                    en_name = Trim(v_strValue)
                            End Select
                        End With
                    Next
                Next
            End If
            If Me.UserLanguage = "VN" Then
                txtETFNAME.Text = name
            ElseIf Me.UserLanguage = "EN" Then
                txtETFNAME.Text = en_name
            Else
                txtETFNAME.Text = ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    'Private Sub cboETFID_Leave(sender As Object, e As EventArgs) Handles cboETFID.Leave
    '    GetETFNAME(Trim(Me.cboETFID.EditValue))
    'End Sub

    Public Function VerifyCustodyCode(ByVal v_strCustodyCode As String) As Boolean
        Dim v_strErrorMessage As String = String.Empty
        Dim v_strPREFIXED, v_strPCFLAG, v_strRUNNINGNUMBER, v_strIORC, v_strPrefixedStandard As String
        'Dộ dài phải là 10 ký tự
        If v_strCustodyCode.Length <> 10 Then
            v_strErrorMessage = "CUSTODYCD_INVALID_LENGTH"

            MsgBox(mv_resourceManager.GetString(v_strErrorMessage), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            Me.txtCustodycd.Focus()
            Return False
        End If
        Return True

    End Function

    Private Sub txtCustodycd_Leave(sender As Object, e As EventArgs) Handles txtCustodycd.Leave
        txtCustodycd.Text = txtCustodycd.Text.ToUpper()
        If VerifyCustodyCode(txtCustodycd.Text) Then
            GetMEMBERInfo(txtCustodycd.Text)
            GetAPInfo(txtCustodycd.Text)
            GetNAME(txtCustodycd.Text)
        End If
    End Sub

    Private Sub grvsbfundetf_BeforeLeaveRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles grvsbfundetf.BeforeLeaveRow
        CalDifAndValue()
    End Sub

    Private Sub grvsbfundetf_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grvsbfundetf.CellValueChanged
        Dim cellValue As Double
        Dim codeid, v_strCmdSQL, v_strObjMsg, v_strFLDNAME, v_strValue As String
        Dim v_ws As New BDSDeliveryManagement
        Dim v_nodeList As XmlNodeList
        Dim v_xmlDocument As New XmlDocument
        If grvsbfundetf.GetRowCellValue(e.RowHandle, "CODEID") Is DBNull.Value = False Then
            codeid = grvsbfundetf.GetRowCellValue(e.RowHandle, "CODEID")

            v_strCmdSQL = "select BASICPRICE VALUE  from SECURITIES_INFO WHERE CODEID = '" & codeid & "'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count > 0 Then
                If e.Column.FieldName = "CODEID" Then
                    For i = 0 To v_nodeList.Count - 1
                        For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                            With v_nodeList.Item(i).ChildNodes(j)
                                'Ghi nhận thuật toán để kiểm tra và tính toán cho từng trư?ng c�ủa giao dịch
                                v_strValue = .InnerText.ToString
                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), XmlAttribute).Value)
                                Select Case Trim(v_strFLDNAME)
                                    Case "VALUE"
                                        cellValue = Trim(v_strValue)
                                        grvsbfundetf.Columns("PRICE").DisplayFormat.FormatString = "n2"
                                        grvsbfundetf.Columns("PRICE").DisplayFormat.FormatType = FormatType.Numeric

                                        grvsbfundetf.Columns("QTTY").DisplayFormat.FormatString = "n2"
                                        grvsbfundetf.Columns("QTTY").DisplayFormat.FormatType = FormatType.Numeric
                                        grvsbfundetf.SetRowCellValue(e.RowHandle, "PRICE", cellValue)
                                        grvsbfundetf.Columns("APQTTY").DisplayFormat.FormatString = "n2"
                                        grvsbfundetf.Columns("APQTTY").DisplayFormat.FormatType = FormatType.Numeric
                                        grvsbfundetf.Columns("HOLD").DisplayFormat.FormatString = "n2"
                                        grvsbfundetf.Columns("HOLD").DisplayFormat.FormatType = FormatType.Numeric
                                End Select
                            End With
                        Next
                    Next
                    grvsbfundetf.SetRowCellValue(e.RowHandle, grvsbfundetf.Columns("QTTY"), 0)
                    grvsbfundetf.SetRowCellValue(e.RowHandle, grvsbfundetf.Columns("APQTTY"), 0)
                    grvsbfundetf.SetRowCellValue(e.RowHandle, grvsbfundetf.Columns("HOLD"), 0)
                End If
            Else
                grvsbfundetf.SetRowCellValue(e.RowHandle, "PRICE", 1)
            End If
        End If
        If e.Column.FieldName = "QTTY" Or e.Column.FieldName = "PRICE" Or e.Column.FieldName = "APQTTY" Or e.Column.FieldName = "HOLD" Then
            Dim diffe, qtty_all As Double
            'If grvsbfundetf.GetRowCellValue(e.RowHandle, "QTTY") Is DBNull.Value = False Then
            grvsbfundetf.Columns("AMT").DisplayFormat.FormatString = "n2"
            grvsbfundetf.Columns("AMT").DisplayFormat.FormatType = FormatType.Numeric
            If grvsbfundetf.GetRowCellValue(e.RowHandle, grvsbfundetf.Columns("QTTY")) Is DBNull.Value = False And grvsbfundetf.GetRowCellValue(e.RowHandle, grvsbfundetf.Columns("APQTTY")) Is DBNull.Value = False And grvsbfundetf.GetRowCellValue(e.RowHandle, grvsbfundetf.Columns("HOLD")) Is DBNull.Value = False Then
                cellValue = (grvsbfundetf.GetRowCellValue(e.RowHandle, grvsbfundetf.Columns("QTTY")) + grvsbfundetf.GetRowCellValue(e.RowHandle, grvsbfundetf.Columns("APQTTY")) + grvsbfundetf.GetRowCellValue(e.RowHandle, grvsbfundetf.Columns("HOLD"))) * grvsbfundetf.GetRowCellValue(e.RowHandle, grvsbfundetf.Columns("PRICE"))
                grvsbfundetf.SetRowCellValue(e.RowHandle, grvsbfundetf.Columns("AMT"), cellValue)
                CalDifAndValue()
            End If
        End If
        If e.Column.FieldName = "PRICE" And grvsbfundetf.GetRowCellValue(e.RowHandle, grvsbfundetf.Columns("PRICE")) Is DBNull.Value = False And grvsbfundetf.GetRowCellValue(e.RowHandle, grvsbfundetf.Columns("QTTY")) Is DBNull.Value = False And grvsbfundetf.GetRowCellValue(e.RowHandle, grvsbfundetf.Columns("APQTTY")) Is DBNull.Value = False And grvsbfundetf.GetRowCellValue(e.RowHandle, grvsbfundetf.Columns("HOLD")) Is DBNull.Value = False Then
            grvsbfundetf.Columns("AMT").DisplayFormat.FormatString = "n2"
            grvsbfundetf.Columns("AMT").DisplayFormat.FormatType = FormatType.Numeric
            cellValue = (grvsbfundetf.GetRowCellValue(e.RowHandle, grvsbfundetf.Columns("QTTY")) + grvsbfundetf.GetRowCellValue(e.RowHandle, grvsbfundetf.Columns("APQTTY")) + grvsbfundetf.GetRowCellValue(e.RowHandle, grvsbfundetf.Columns("HOLD"))) * grvsbfundetf.GetRowCellValue(e.RowHandle, grvsbfundetf.Columns("PRICE"))
            grvsbfundetf.SetRowCellValue(e.RowHandle, grvsbfundetf.Columns("AMT"), 0)
            grvsbfundetf.SetRowCellValue(e.RowHandle, grvsbfundetf.Columns("AMT"), cellValue)
            CalDifAndValue()
        End If

        grvsbfundetf.Columns("APQTTY").DisplayFormat.FormatString = "n2"
        grvsbfundetf.Columns("APQTTY").DisplayFormat.FormatType = FormatType.Numeric
        grvsbfundetf.Columns("HOLD").DisplayFormat.FormatString = "n2"
        grvsbfundetf.Columns("HOLD").DisplayFormat.FormatType = FormatType.Numeric
    End Sub



    Private Sub grvsbfundetf_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles grvsbfundetf.CustomUnboundColumnData
        Try
            If (e.IsGetData() And e.Column.UnboundType = UnboundColumnType.Object) Then
                Dim dr As DataRow = CType(gridsbfundetf.DataSource, DataTable).Rows(e.ListSourceRowIndex)
                If (dr Is Nothing) Then
                    Return
                End If

                If (e.Column.FieldName = "AMOUNT") Then
                    Dim qty As Decimal = 0
                    Dim hold4Sell As Decimal = 0
                    Dim apQty As Decimal = 0
                    Dim price As Decimal = 0

                    If (dr.Table.Columns.Contains("PRICE")) Then
                        Decimal.TryParse(dr("PRICE").ToString(), price)
                    End If
                    If (dr.Table.Columns.Contains("QTTY")) Then
                        Decimal.TryParse(dr("QTTY").ToString(), qty)
                    End If
                    If (dr.Table.Columns.Contains("HOLD") AndAlso grvsbfundetf.Columns("HOLD").Visible) Then
                        Decimal.TryParse(dr("HOLD").ToString(), hold4Sell)
                    End If
                    If (dr.Table.Columns.Contains("APQTTY") AndAlso grvsbfundetf.Columns("APQTTY").Visible) Then
                        Decimal.TryParse(dr("APQTTY").ToString(), apQty)
                    End If
                    e.Value = (qty + hold4Sell + apQty) * price
                    If dr("AMT") Is DBNull.Value OrElse e.Value <> dr("AMT") Then
                        dr("AMT") = e.Value
                        CalDifAndValue()
                    End If
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub AddColumnExtGridControl()
        'InitGridFromSearchCodeNotUseTask("SBFUNDETF", Me.gridsbfundetf, Me.grvsbfundetf, , "Y", "Y", UserLanguage, "Y")

        'grvsbfundetf.OptionsBehavior.Editable = True
        'grvsbfundetf.OptionsBehavior.ReadOnly = False

        'grvsbfundetf.OptionsView.ShowIndicator = True
        'FormatColumnGrid()
    End Sub

    Private Sub FormatColumnGrid()
        Dim repositoryItemSpinEdit As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit = New Repository.RepositoryItemSpinEdit()
        repositoryItemSpinEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
        repositoryItemSpinEdit.AutoHeight = False
        repositoryItemSpinEdit.Name = "repositoryItemSpinEdit1"

        'If (grvsbfundetf.Columns.Count > 0) Then
        'cln2.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far
        'cln2.AppearanceCell.Options.UseTextOptions = True
        Dim cln As GridColumn = New GridColumn()
        'cln.FieldName = "AMOUNT"
        'cln.OptionsColumn.AllowEdit = False
        'cln.OptionsColumn.FixedWidth = True
        'cln.DisplayFormat.FormatString = "n0"
        'cln.DisplayFormat.FormatType = FormatType.Numeric
        'cln.UnboundType = DevExpress.Data.UnboundColumnType.Object
        'cln.Visible = True
        cln.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far
        cln.AppearanceCell.Options.UseTextOptions = True
        'For Each col As GridColumn In grvsbfundetf.Columns
        '    If (col.FieldName <> "CODEID") Then
        '        col.ColumnEdit = repositoryItemSpinEdit
        '    End If
        'Next
        'grvsbfundetf.Columns.Add(cln)

        cln.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {
        New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AMOUNT", "Sum= {0:n0}")})

        'grvsbfundetf.Columns.Insert(1, cln)
        grvsbfundetf.Columns.Add(cln)
        gridsbfundetf.RefreshDataSource()
        'End If
    End Sub

    'Private Sub grvsbfundetf_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grvsbfundetf.CellValueChanging
    '    Dim cellValue As Double
    '    If e.Column.FieldName = "PRICE" Then
    '        grvsbfundetf.Columns("AMT").DisplayFormat.FormatString = "n2"
    '        grvsbfundetf.Columns("AMT").DisplayFormat.FormatType = FormatType.Numeric
    '        cellValue = grvsbfundetf.GetRowCellValue(e.RowHandle, grvsbfundetf.Columns("QTTY")) * grvsbfundetf.GetRowCellValue(e.RowHandle, grvsbfundetf.Columns("PRICE"))
    '        grvsbfundetf.SetRowCellValue(e.RowHandle, grvsbfundetf.Columns("AMT"), cellValue)
    '    End If
    'End Sub

    Private Sub grvsbfundetf_ValidatingEditor(sender As Object, e As BaseContainerValidateEditorEventArgs) Handles grvsbfundetf.ValidatingEditor
        Dim selectedRows() As Integer = grvsbfundetf.GetSelectedRows()
        For Each rowHandle As Integer In selectedRows
            If grvsbfundetf.FocusedColumn.FieldName = "QTTY" Then
                If IsNumeric(grvsbfundetf.EditingValue) = True Then
                    If grvsbfundetf.EditingValue < 0 Then
                        e.Valid = False
                        e.ErrorText = mv_resourceManager.GetString("valueQTTY")
                    Else
                        grvsbfundetf.ClearColumnErrors()
                    End If
                End If
            End If
            If grvsbfundetf.FocusedColumn.FieldName = "CODEID" Then
                For i As Integer = 0 To grvsbfundetf.DataRowCount - 1
                    If grvsbfundetf.EditingValue = grvsbfundetf.GetRowCellValue(i, "CODEID") Then
                        e.Valid = False
                        e.ErrorText = mv_resourceManager.GetString("DUPLICATECKCC")
                    Else
                        grvsbfundetf.ClearColumnErrors()
                    End If
                Next
            End If
        Next
    End Sub


    Private Sub cbotype_EditValueChanged(sender As Object, e As EventArgs) Handles cbotype.EditValueChanged
        Try
            InitVisibleColumnGrid(cbotype.EditValue)
        Catch ex As Exception
        End Try
    End Sub

    Private Function GetQTTYCKCC(ByVal CUSTID As String, ByVal CODEID As String) As Integer
        Try
            Dim v_strCmdSQL As String, v_strObjMsg As String
            Dim v_ws As New BDSDeliveryManagement
            Dim v_nodeList As XmlNodeList
            Dim v_xmlDocument As New XmlDocument
            v_strCmdSQL = "SELECT TRADE from semast WHERE custid ='" & CUSTID & "' and codeid = '" & CODEID & "'"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            Dim v_strValue, v_strFLDNAME, v_strTEXT, v_strMINBRATIO, v_strMAXBRATIO As String, i, j As Integer

            If v_nodeList.Count > 0 Then
                For i = 0 To v_nodeList.Count - 1
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            'Ghi nhận thuật toán để kiểm tra và tính toán cho từng trư?ng c�ủa giao dịch
                            v_strValue = .InnerText.ToString
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "TRADE"
                                    Return Trim(v_strValue)
                            End Select
                        End With
                    Next
                Next
            Else
                Return 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function GetNextDate(ByVal tradedate As String) As String
        Try
            Dim v_strCmdSQL As String, v_strObjMsg As String
            Dim v_ws As New BDSDeliveryManagement
            Dim v_nodeList As XmlNodeList
            Dim v_xmlDocument As New XmlDocument
            v_strCmdSQL = "select getnextdate('" & tradedate & "')  NEXTDATE from dual"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            Dim v_strValue, v_strFLDNAME, v_strTEXT, v_strMINBRATIO, v_strMAXBRATIO As String, i, j As Integer

            If v_nodeList.Count > 0 Then
                For i = 0 To v_nodeList.Count - 1
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            'Ghi nhận thuật toán để kiểm tra và tính toán cho từng trư?ng c�ủa giao dịch
                            v_strValue = .InnerText.ToString
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), XmlAttribute).Value)
                            Select Case Trim(v_strFLDNAME)
                                Case "NEXTDATE"
                                    Return Trim(v_strValue)
                            End Select
                        End With
                    Next
                Next
            Else
                Return 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Sub dtpmsktxdate_EditValueChanged(sender As Object, e As EventArgs) Handles dtpmsktxdate.EditValueChanged
        Dim v_strValue As String
        Dim aDate As Date
        If ExeFlag = ExecuteFlag.AddNew Then
            'v_strValue = dtpmsktxdate.EditValue
            'aDate = CDate(dtpmsktxdate.EditValue).AddDays(1)
            'If v_strValue <> "" Then
            '    dtpmsktxdate.EditValue = gf_Cdate(v_strValue)
            '    'dtpmsksetdate.EditValue = DateTime.ParseExact(v_strValue, gc_FORMAT_DATE, System.Globalization.CultureInfo.InvariantCulture).AddDays(1)
            '    dtpmsksetdate.EditValue = gf_Cdate(v_strValue).AddDays(1)
            'End If
            dtpmsksetdate.EditValue = GetNextDate(dtpmsktxdate.EditValue)
        End If
    End Sub

    Private Sub CalDifAndValue()
        Dim value As Decimal = 0
        Dim qty As Decimal = 0
        Dim navqty As Decimal = 0
        Dim totalAmount As Decimal = 0
        Dim dt As DataTable = Me.gridsbfundetf.DataSource
        If (dt IsNot Nothing AndAlso dt.Columns.Contains("AMT")) Then
            If (dt.Rows.Count > 0) Then
                For Each r As DataRow In dt.Rows
                    Try
                        totalAmount += Decimal.Parse(r("AMT"))
                    Catch ex As Exception

                    End Try
                Next

            End If
        End If
        Decimal.TryParse(txtETXQUANTITY.Text, qty)
        Decimal.TryParse(txtmsknavccq.Text, navqty)
        txtmskamount.Text = (qty * navqty * 100000).ToString()
        txtmskdiffe.Text = qty * navqty * 100000 - totalAmount

        'txtmskamount.Text = CDbl(txtmskamount.Text).ToString("#,###")
        'txtmskdiffe.Text = CDbl(txtmskdiffe.Text).ToString("#,###")
    End Sub

    Private Sub cboETFID_EditValueChanged(sender As Object, e As EventArgs) Handles cboETFID.EditValueChanged
        GetETFNAME(Trim(Me.cboETFID.EditValue))
    End Sub

    Private Sub InitVisibleColumnGrid(ByVal type As String)
        Try
            If (Not String.IsNullOrEmpty(type) And grvsbfundetf.Columns.Count > 0) Then
                grvsbfundetf.Columns("HOLD").Visible = True
                grvsbfundetf.Columns("APQTTY").Visible = True
                If (type = "NS") Then
                    lblETXQUANTITY.Text = mv_resourceManager.GetString("QTTY")
                    grvsbfundetf.Columns("APQTTY").Visible = False
                ElseIf type = "NB" Then
                    lblETXQUANTITY.Text = mv_resourceManager.GetString("ETXQUANTITY")
                    grvsbfundetf.Columns("HOLD").Visible = False
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtETXQUANTITY_EditValueChanged(sender As Object, e As EventArgs) Handles txtETXQUANTITY.EditValueChanged
        CalDifAndValue()
    End Sub

    Private Sub txtmsknavccq_EditValueChanged(sender As Object, e As EventArgs) Handles txtmsknavccq.EditValueChanged
        CalDifAndValue()
    End Sub
End Class