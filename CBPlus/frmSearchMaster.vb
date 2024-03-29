Imports CommonLibrary
Imports System.Timers
Imports System.Reflection
Imports System.Text

Public Class frmSearchMaster
    'Inherits AppCore.frmSearch
    Inherits AppCore.frmXtraSearch
    Public mv_Timer As Timer
    Public mv_frmProcessOrder As frmProcessOrder
    Public mv_frmMarginProcess As frmMarginProcess

    Private mv_COUNTRYTable As New DataTable
    Private mv_PROVINCETable As New DataTable

    Public Property CELLSDEFINETable() As DataTable
        Get
            Return mv_strCELLSDEFINETable
        End Get
        Set(ByVal Value As DataTable)
            mv_strCELLSDEFINETable = Value
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


#Region " Windows Form Designer generated code "

    Public Sub New()

        MyBase.New("ENG")

    End Sub

    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New(pv_strLanguage)

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        mv_Timer = New Timer
        AddHandler Me.mv_Timer.Elapsed, New ElapsedEventHandler(AddressOf Me.TimerReport_Elapsed)
        'Add any initialization after the InitializeComponent() call



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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

#End Region
    Protected Overrides Sub ProcessOrder(ByVal pv_TableName As String, ByVal pv_GridRow As Xceed.Grid.DataRow)
        Select Case pv_TableName
            Case "MR0103", "MR0008"
                mv_frmProcessOrder = New frmProcessOrder(Me.UserLanguage, pv_TableName)
                mv_frmProcessOrder.ObjectName = pv_TableName
                mv_frmProcessOrder.ACTYPE = pv_GridRow.Cells("ACTYPE").Value
                mv_frmProcessOrder.RTNAMOUNT = 0
                mv_frmProcessOrder.ADDRTNAMOUNT = CDbl(pv_GridRow.Cells("RTNAMOUNTREF").Value)
                mv_frmProcessOrder.OVDAMOUNT = CDbl(pv_GridRow.Cells("OVDAMOUNTREF").Value)
                mv_frmProcessOrder.SELLLOSTASS = CDbl(pv_GridRow.Cells("SELLLOSTASSREF").Value)
                mv_frmProcessOrder.SELLAMOUNT = CDbl(pv_GridRow.Cells("SELLAMOUNTREF").Value)
                mv_frmProcessOrder.MRIRATE = IIf(CDbl(pv_GridRow.Cells("MRIRATE").Value) <= 0, 100, CDbl(pv_GridRow.Cells("MRIRATE").Value))
                If pv_TableName = "MR0008" Then
                    CType(mv_frmProcessOrder, frmProcessOrder).AFACCTNO = pv_GridRow.Cells("AFACCTNO").Value
                    CType(mv_frmProcessOrder, frmProcessOrder).GROUPLEADER = ""
                    mv_frmProcessOrder.lblCustomerInfo.Text = pv_GridRow.Cells("AFACCTNO").Value & ":" & pv_GridRow.Cells("FULLNAME").Value
                    mv_frmProcessOrder.lblAddAmt.Text = Format(CDbl(pv_GridRow.Cells("RTNREMAINAMT").Value), "#,##0")
                    mv_frmProcessOrder.lblLeftAMT.Text = Format(CDbl(pv_GridRow.Cells("RTNREMAINAMT").Value), "#,##0")
                Else
                    CType(mv_frmProcessOrder, frmProcessOrder).AFACCTNO = pv_GridRow.Cells("ACCTNO").Value
                    CType(mv_frmProcessOrder, frmProcessOrder).GROUPLEADER = pv_GridRow.Cells("GROUPLEADER").Value
                    mv_frmProcessOrder.lblCustomerInfo.Text = pv_GridRow.Cells("ACCTNO").Value & ":" & pv_GridRow.Cells("FULLNAME").Value
                    mv_frmProcessOrder.lblAddAmt.Text = Format(CDbl(pv_GridRow.Cells("RTNREMAINAMT").Value), "#,##0")
                    mv_frmProcessOrder.lblLeftAMT.Text = Format(CDbl(pv_GridRow.Cells("RTNREMAINAMT").Value), "#,##0")
                End If

                mv_frmProcessOrder.lblSecinfo.Text = ""

                CType(mv_frmProcessOrder, frmProcessOrder).BranchId = Me.BranchId
                CType(mv_frmProcessOrder, frmProcessOrder).TellerId = Me.TellerId
                CType(mv_frmProcessOrder, frmProcessOrder).IpAddress = Me.IpAddress
                CType(mv_frmProcessOrder, frmProcessOrder).WsName = Me.WsName
                CType(mv_frmProcessOrder, frmProcessOrder).BusDate = Me.BusDate
                'Lay theo gio cua timer
                mv_frmProcessOrder.SYMBOLLIST = mv_strSymbolList
                mv_frmProcessOrder.mv_SymbolTalble = mv_SymbolTable
                mv_frmProcessOrder.ShowDialog()
                mv_frmProcessOrder.Dispose()

            Case "MR9000"
                mv_frmProcessOrder = New frmProcessOrder(Me.UserLanguage, pv_TableName)
                mv_frmProcessOrder.ObjectName = pv_TableName
                mv_frmProcessOrder.ACTYPE = pv_GridRow.Cells("ACTYPE").Value
                mv_frmProcessOrder.RTNAMOUNT = 0
                mv_frmProcessOrder.MRIRATE = 100

                CType(mv_frmProcessOrder, frmProcessOrder).AFACCTNO = pv_GridRow.Cells("AFACCTNO").Value
                CType(mv_frmProcessOrder, frmProcessOrder).GROUPLEADER = ""
                mv_frmProcessOrder.lblCustomerInfo.Text = pv_GridRow.Cells("AFACCTNO").Value & ":" & pv_GridRow.Cells("FULLNAME").Value
                mv_frmProcessOrder.lblAddAmt.Text = Format(CDbl(pv_GridRow.Cells("CALLAMT").Value), "#,##0")
                mv_frmProcessOrder.lblLeftAMT.Text = CDbl(pv_GridRow.Cells("CALLAMT").Value) - 0
                mv_frmProcessOrder.lblSecinfo.Text = ""

                CType(mv_frmProcessOrder, frmProcessOrder).BranchId = Me.BranchId
                CType(mv_frmProcessOrder, frmProcessOrder).TellerId = Me.TellerId
                CType(mv_frmProcessOrder, frmProcessOrder).IpAddress = Me.IpAddress
                CType(mv_frmProcessOrder, frmProcessOrder).WsName = Me.WsName
                CType(mv_frmProcessOrder, frmProcessOrder).BusDate = Me.BusDate
                'Lay theo gio cua timer
                mv_frmProcessOrder.SYMBOLLIST = mv_strSymbolList
                mv_frmProcessOrder.mv_SymbolTalble = mv_SymbolTable
                mv_frmProcessOrder.ShowDialog()
                mv_frmProcessOrder.Dispose()
            Case "DF1050"
                mv_frmProcessOrder = New frmProcessOrder(Me.UserLanguage, pv_TableName)
                mv_frmProcessOrder.ObjectName = pv_TableName
                'mv_frmProcessOrder.ACTYPE = pv_GridRow.Cells("ACTYPE").Value
                mv_frmProcessOrder.RTNAMOUNT = 0
                mv_frmProcessOrder.MRIRATE = 100

                CType(mv_frmProcessOrder, frmProcessOrder).AFACCTNO = pv_GridRow.Cells("AFACCTNO").Value
                CType(mv_frmProcessOrder, frmProcessOrder).GROUPLEADER = pv_GridRow.Cells("GROUPID").Value
                mv_frmProcessOrder.lblCustomerInfo.Text = pv_GridRow.Cells("GROUPID").Value & ": " & pv_GridRow.Cells("FULLNAME").Value
                mv_frmProcessOrder.lblAddAmt.Text = Format(CDbl(pv_GridRow.Cells("ODSELLDF").Value), "#,##0")
                mv_frmProcessOrder.lblLeftAMT.Text = Format(CDbl(pv_GridRow.Cells("ODSELLDF").Value) - 0, "#,##0")
                mv_frmProcessOrder.lblSecinfo.Text = ""
                mv_frmProcessOrder.mv_strCustodyCD = pv_GridRow.Cells("CUSTODYCD").Value
                CType(mv_frmProcessOrder, frmProcessOrder).BranchId = Me.BranchId
                CType(mv_frmProcessOrder, frmProcessOrder).TellerId = Me.TellerId
                CType(mv_frmProcessOrder, frmProcessOrder).IpAddress = Me.IpAddress
                CType(mv_frmProcessOrder, frmProcessOrder).WsName = Me.WsName
                CType(mv_frmProcessOrder, frmProcessOrder).BusDate = Me.BusDate
                'Lay theo gio cua timer
                mv_frmProcessOrder.SYMBOLLIST = mv_strSymbolList
                mv_frmProcessOrder.mv_SymbolTalble = mv_SymbolTable
                mv_frmProcessOrder.ShowDialog()
                mv_frmProcessOrder.Dispose()


            Case "DF1003", "DF1004", "DF1005"
                Dim v_strAFACCTNO, v_strSYMBOL, v_strEXECTYPE, v_strPriceType, v_strSellQtty, v_strDEALNO, v_strDFQtty As String
                v_strSellQtty = pv_GridRow.Cells("SELLDFTRADING").Value
                v_strDFQtty = pv_GridRow.Cells("DFTRADING").Value
                If v_strDFQtty > 0 Then
                    Dim v_strInputParam As String = ""
                    Dim frm As New frmQuickOrderTransact(UserLanguage)
                    v_strAFACCTNO = pv_GridRow.Cells("AFACCTNO").Value
                    v_strInputParam &= "CONTRACTNO#" & v_strAFACCTNO
                    v_strSYMBOL = pv_GridRow.Cells("SYMBOL").Value
                    v_strInputParam &= "|SYMBOL#" & v_strSYMBOL
                    v_strEXECTYPE = "MS"
                    v_strInputParam &= "|EXECTYPE#" & v_strEXECTYPE
                    v_strPriceType = "LO"
                    v_strInputParam &= "|PRICETYPE#" & v_strPriceType

                    v_strInputParam &= "|QUANTITY#" & v_strSellQtty
                    v_strDEALNO = pv_GridRow.Cells("ACCTNO").Value
                    v_strInputParam &= "|DEALNO#" & v_strDEALNO

                    frm.InitParam = v_strInputParam
                    frm.TellerName = "Liquidity processing"
                    frm.ObjectName = ""
                    frm.ModuleCode = "OD"
                    frm.LocalObject = gc_IsNotLocalMsg
                    frm.BranchId = Me.BranchId
                    frm.TellerId = Me.TellerId
                    frm.IpAddress = Me.IpAddress
                    frm.WsName = Me.WsName
                    frm.BusDate = Me.BusDate
                    frm.SYMBOLLIST = mv_strSymbolList
                    frm.mv_SymbolTalble = mv_SymbolTable
                    frm.AdvanceOrder = True
                    frm.ShowDialog()
                    frm.Dispose()
                Else
                    MsgBox(ResourceManager.GetString("ERR_CANNOT_FORCE_SELL_DEAL"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    Exit Sub
                End If
            Case "MR0001"
                If pv_GridRow.Cells("GRPAFACCTNO").Value = String.Empty Then
                    Dim frm As New frmMarginInfo(Me.UserLanguage)
                    frm.TellerName = ""
                    frm.ObjectName = ""
                    frm.ModuleCode = "MR"
                    frm.LocalObject = gc_IsNotLocalMsg
                    frm.BranchId = Me.BranchId
                    frm.TellerId = Me.TellerId
                    frm.IpAddress = Me.IpAddress
                    frm.WsName = Me.WsName
                    frm.BusDate = Me.BusDate
                    frm.AFACCTNO = pv_GridRow.Cells("ACCTNO").Value
                    frm.ShowDialog()
                    frm.Dispose()
                End If
            Case "MR0003", "MR1003"
                mv_frmMarginProcess = New frmMarginProcess(Me.UserLanguage, pv_TableName)
                mv_frmMarginProcess.ObjectName = pv_TableName
                mv_frmMarginProcess.ACTYPE = pv_GridRow.Cells("ACTYPE").Value
                mv_frmMarginProcess.RTNAMOUNT = 0
                mv_frmMarginProcess.ADDRTNAMOUNT = CDbl(pv_GridRow.Cells("RTNAMOUNTREF").Value)
                mv_frmMarginProcess.OVDAMOUNT = CDbl(pv_GridRow.Cells("OVDAMOUNTREF").Value)
                mv_frmMarginProcess.SELLLOSTASS = CDbl(pv_GridRow.Cells("SELLLOSTASSREF").Value)
                mv_frmMarginProcess.SELLAMOUNT = CDbl(pv_GridRow.Cells("SELLAMOUNTREF").Value)
                mv_frmMarginProcess.MRIRATE = IIf(CDbl(pv_GridRow.Cells("MRIRATE").Value) <= 0, 100, CDbl(pv_GridRow.Cells("MRIRATE").Value))
                mv_frmMarginProcess.SELLRATE = CDbl(pv_GridRow.Cells("SELLRATE").Value)
                mv_frmMarginProcess.MRRATE = CDbl(pv_GridRow.Cells("MRRATE").Value)
                mv_frmMarginProcess.GROUPID = pv_GridRow.Cells("GROUPID").Value
                mv_frmMarginProcess.ADDVND = CDbl(pv_GridRow.Cells("ADDVND").Value)
                'If pv_TableName = "MR0003" Then
                'mv_frmMarginProcess.RTLAMT_MR = CDbl(pv_GridRow.Cells("RTLAMT_MR").Value)
                'mv_frmMarginProcess.RTLAMT_MC = CDbl(pv_GridRow.Cells("RTLAMT_MC").Value)
                'mv_frmMarginProcess.RTLAMT_MB = CDbl(pv_GridRow.Cells("RTLAMT_MB").Value)
                'mv_frmMarginProcess.RTSELLAMT_MR = CDbl(pv_GridRow.Cells("RTSELLAMT_MR").Value)
                'mv_frmMarginProcess.RTSELLAMT_MC = CDbl(pv_GridRow.Cells("RTSELLAMT_MC").Value)
                'mv_frmMarginProcess.RTSELLAMT_MB = CDbl(pv_GridRow.Cells("RTSELLAMT_MB").Value)
                'mv_frmMarginProcess.OUTSTANDING = CDbl(pv_GridRow.Cells("OUTSTANDING").Value)
                'mv_frmMarginProcess.TOTALVND = CDbl(pv_GridRow.Cells("TOTALVND").Value)
                'mv_frmMarginProcess.MINODAMT = CDbl(pv_GridRow.Cells("MINODAMT").Value)
                'mv_frmMarginProcess.MRSRATE = CDbl(pv_GridRow.Cells("MRSRATE").Value)
                'mv_frmMarginProcess.MCSRATE = CDbl(pv_GridRow.Cells("MCSRATE").Value)
                'mv_frmMarginProcess.MBSRATE = CDbl(pv_GridRow.Cells("MBSRATE").Value)

                'End If


                CType(mv_frmMarginProcess, frmMarginProcess).AFACCTNO = pv_GridRow.Cells("ACCTNO").Value
                CType(mv_frmMarginProcess, frmMarginProcess).GROUPLEADER = pv_GridRow.Cells("GROUPLEADER").Value
                'mv_frmMarginProcess.lblCustomerInfo.Text = pv_GridRow.Cells("ACCTNO").Value & ":" & pv_GridRow.Cells("FULLNAME").Value
                mv_frmMarginProcess.lblAddAmt.Text = Format(CDbl(pv_GridRow.Cells("RTNREMAINAMT").Value), "#,##0")
                mv_frmMarginProcess.lblLeftAMT.Text = Format(CDbl(pv_GridRow.Cells("RTNREMAINAMT").Value), "#,##0")
                mv_frmMarginProcess.lblvCustodycd.Text = pv_GridRow.Cells("CUSTODYCD").Value
                mv_frmMarginProcess.lblvCustName.Text = pv_GridRow.Cells("FULLNAME").Value
                mv_frmMarginProcess.lblvBroker.Text = pv_GridRow.Cells("REFULLNAME").Value
                mv_frmMarginProcess.lblvGBroker.Text = pv_GridRow.Cells("REGRLEADER").Value
                mv_frmMarginProcess.lblvBfOdrAMT.Text = Format(CDbl(pv_GridRow.Cells("RTNREMAINAMT").Value), "#,##0")
                mv_frmMarginProcess.lblvLstOdrAMT.Text = Format(CDbl(pv_GridRow.Cells("RTNREMAINAMT").Value), "#,##0")
                mv_frmMarginProcess.lblvBfOdrAMT_G.Text = Format(CDbl(pv_GridRow.Cells("RTNREMAINAMT_G").Value), "#,##0")
                mv_frmMarginProcess.lblvLstOdrAMT_G.Text = Format(CDbl(pv_GridRow.Cells("RTNREMAINAMT_G").Value), "#,##0")


                mv_frmMarginProcess.lblSecinfo.Text = ""

                CType(mv_frmMarginProcess, frmMarginProcess).BranchId = Me.BranchId
                CType(mv_frmMarginProcess, frmMarginProcess).TellerId = Me.TellerId
                CType(mv_frmMarginProcess, frmMarginProcess).IpAddress = Me.IpAddress
                CType(mv_frmMarginProcess, frmMarginProcess).WsName = Me.WsName
                CType(mv_frmMarginProcess, frmMarginProcess).BusDate = Me.BusDate
                'Lay theo gio cua timer
                mv_frmMarginProcess.SYMBOLLIST = mv_strSymbolList
                mv_frmMarginProcess.mv_SymbolTalble = mv_SymbolTable
                mv_frmMarginProcess.ShowDialog()
                mv_frmMarginProcess.Dispose()

        End Select

    End Sub

    Protected Overrides Sub SetTransactForm()
        mv_frmTransactScreen = New frmXtraTransactMaster(Me.UserLanguage)
    End Sub

    Protected Overrides Sub RegisterOnline(ByRef pv_AUTOID As String, ByRef pv_CustomerType As String, ByRef pv_CustomerName As String, _
                                             ByRef pv_CustomerBirth As String, ByRef pv_IDType As String, ByRef pv_IDCode As String, _
                                             ByRef pv_Iddate As String, ByRef pv_Idplace As String, ByRef pv_Expiredate As String, _
                                             ByRef pv_Address As String, ByRef pv_Taxcode As String, ByRef pv_PrivatePhone As String, _
                                             ByRef pv_Mobile As String, ByRef pv_Fax As String, ByRef pv_Email As String, _
                                             ByRef pv_Office As String, ByRef pv_Position As String, ByRef pv_Country As String, _
                                             ByRef pv_CustomerCity As String, ByRef pv_TKTGTT As String)
        Dim v_frm As New frmCFMAST_bk
        v_frm.ExeFlag = ExecuteFlag.AddNew
        v_frm.UserLanguage = UserLanguage
        v_frm.ModuleCode = "CF"
        v_frm.ObjectName = "CF.CFMAST"
        v_frm.TableName = "CFMAST"
        v_frm.LocalObject = "N"
        v_frm.KeyFieldName = "CUSTID"
        v_frm.KeyFieldType = "C"
        v_frm.GroupCareBy = GroupCareBy
        v_frm.TellerId = TellerId
        v_frm.TellerRight = TellerRight
        v_frm.AuthString = AuthString
        v_frm.BranchId = BranchId
        v_frm.BusDate = Me.BusDate
        v_frm.PROVINCETable = PROVINCETable
        v_frm.COUNTRYTable = COUNTRYTable
        v_frm.IsOnlineRegister = True

        v_frm.mv_OLAUTOID = pv_AUTOID
        v_frm.mv_CustomerType = pv_CustomerType
        v_frm.mv_CustomerName = pv_CustomerName
        v_frm.mv_CustomerBirth = pv_CustomerBirth
        v_frm.mv_IDType = pv_IDType
        v_frm.mv_IDCode = pv_IDCode
        v_frm.mv_Iddate = pv_Iddate
        v_frm.mv_Idplace = pv_Idplace
        v_frm.mv_Expiredate = pv_Expiredate
        v_frm.mv_Address = pv_Address
        v_frm.mv_Taxcode = pv_Taxcode
        v_frm.mv_PrivatePhone = pv_PrivatePhone
        v_frm.mv_Mobile = pv_Mobile
        v_frm.mv_Fax = pv_Fax
        v_frm.mv_Email = pv_Email
        v_frm.mv_Office = pv_Office
        v_frm.mv_Position = pv_Position
        v_frm.mv_Country = pv_Country
        v_frm.mv_CustomerCity = pv_CustomerCity
        v_frm.mv_TKTGTT = pv_TKTGTT
        Dim frmResult As DialogResult = v_frm.ShowDialog()
    End Sub
    Protected Overrides Function ShowForm(ByVal pv_intExecFlag As Integer) As DialogResult
        Dim v_strFullObjName As String
        MyBase.ShowForm(pv_intExecFlag)

        Try
            If pv_intExecFlag <> ExecuteFlag.Delete Then
                If pv_intExecFlag <> ExecuteFlag.AddNew Then
                    If (SearchGridView.GetFocusedRow Is Nothing) Then
                        MsgBox(ResourceManager.GetString("frmSearch.NotSelected"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Function
                    End If
                End If

                If Me.MenuType = "O" Then
                    If ObjectName.IndexOf(".") = -1 Then
                        v_strFullObjName = ModuleCode & "." & ObjectName
                    Else
                        v_strFullObjName = ObjectName
                    End If
                    v_strFullObjName = ModuleCode & "." & ObjectName
                    Dim v_strKeyValue As String = String.Empty
                    If pv_intExecFlag <> ExecuteFlag.AddNew Then
                        v_strKeyValue = Replace(Trim(SearchGridView.GetFocusedRow()(KeyColumn).ToString), ".", String.Empty)
                    End If
                    Dim v_frm As New frmMaintenanceMaster(ObjectName, pv_intExecFlag, UserLanguage, ModuleCode, v_strFullObjName, IsLocalSearch, _
                                                FormCaption, TellerId, TellerRight, GroupCareBy, AuthString, BranchId, BusDate, KeyColumn, _
                                                KeyFieldType, v_strKeyValue, LinkValue, LinkFieldDes, String.Empty, String.Empty, String.Empty, _
                                                Nothing, String.Empty, Me.CompanyCode, Me.CompanyName)
                    Dim frmResult As DialogResult = v_frm.ShowDialog()
                    Return frmResult
                Else
                    Dim v_frm As Object
                    v_frm = GetFormByName(MaintenanceFormName)
                    'N?u trong ObjectName chua có ModuleCode thì ghép thêm ModuleCode vào
                    If ObjectName.IndexOf(".") = -1 Then
                        v_strFullObjName = ModuleCode & "." & ObjectName
                        v_frm.TableName = ObjectName
                    Else
                        v_strFullObjName = ObjectName
                        v_frm.TableName = ObjectName.Substring(ObjectName.IndexOf(".") + 1)
                    End If
                    v_strFullObjName = ModuleCode & "." & ObjectName
                    v_frm.ExeFlag = pv_intExecFlag
                    v_frm.UserLanguage = UserLanguage
                    v_frm.ModuleCode = ModuleCode
                    v_frm.ObjectName = v_strFullObjName
                    v_frm.TableName = ObjectName
                    v_frm.LocalObject = IsLocalSearch
                    v_frm.Text = FormCaption
                    v_frm.TellerId = TellerId
                    v_frm.TellerRight = TellerRight
                    v_frm.GroupCareBy = GroupCareBy
                    v_frm.AuthString = AuthString
                    v_frm.BranchId = BranchId
                    v_frm.Busdate = Me.BusDate
                    v_frm.KeyFieldName = KeyColumn
                    v_frm.KeyFieldType = KeyFieldType
                    If v_strFullObjName = OBJNAME_CF_CFMAST Then
                        v_frm.COUNTRYTable = mv_COUNTRYTable
                        v_frm.PROVINCETable = mv_PROVINCETable
                    End If

                    'If v_strFullObjName = OBJNAME_CA_CAMAST Then
                    '    CType(v_frm, frmCAMAST).mv_strCATYPE = Strings.Right(Me.CMDMenu, 3)
                    'End If
                    If pv_intExecFlag <> ExecuteFlag.AddNew Then
                        v_frm.KeyFieldValue = Replace(Trim(SearchGridView.GetFocusedRow()(KeyColumn).ToString), ".", String.Empty)
                    End If
                    v_frm.LinkValue = LinkValue
                    v_frm.LinkFIeld = LinkFieldDes


                    Dim frmResult As DialogResult = v_frm.ShowDialog()
                    Return frmResult
                End If

            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Function
    Protected Overrides Sub ExecuteCA(ByVal v_strKeyValue As String)
        Dim v_strSQLString As String
        Dim v_strClause As String
        Dim i, j As Integer
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryLongTimeOutManagement    'BDSDelivery.BDSDelivery
        Try
            'get cash information
            v_strSQLString = "sp_exec_ca_action"
            v_strClause = "p_camastid!" & v_strKeyValue & "!varchar2!20"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString, v_strClause, , , , , , , gc_CommandProcedure)
            v_ws.Message(v_strObjMsg)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_ws = Nothing
        End Try
    End Sub

    Protected Overrides Sub ExecuteCA_Money(ByVal v_strKeyValue As String)
        Dim v_strSQLString As String
        Dim v_strClause As String
        Dim i, j As Integer
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryLongTimeOutManagement    'BDSDelivery.BDSDelivery
        Try
            'get cash information
            v_strSQLString = "cspks_caproc.pr_exec_money_cop_action"
            v_strClause = "p_camastid!" & v_strKeyValue & "!varchar2!20"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString, v_strClause, , , , , , , gc_CommandProcedure)
            v_ws.Message(v_strObjMsg)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_ws = Nothing
        End Try
    End Sub

    Protected Overrides Sub ExecuteCA_Securities(ByVal v_strKeyValue As String)
        Dim v_strSQLString As String
        Dim v_strClause As String
        Dim i, j As Integer
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryLongTimeOutManagement    'BDSDelivery.BDSDelivery
        Try
            'get cash information
            v_strSQLString = "cspks_caproc.pr_exec_sec_cop_action"
            v_strClause = "p_camastid!" & v_strKeyValue & "!varchar2!20"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString, v_strClause, , , , , , , gc_CommandProcedure)
            v_ws.Message(v_strObjMsg)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_ws = Nothing
        End Try
    End Sub

    Protected Overrides Sub ExecuteOD9996(ByVal v_strKeyValue As String)
        Dim v_strSQLString As String
        Dim v_strClause As String
        Dim i, j As Integer
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryLongTimeOutManagement    'BDSDelivery.BDSDelivery
        Try
            ''get cash information
            'v_strSQLString = "cspks_seproc.pr_ExecuteOD9996"
            'v_strClause = "p_orderid!" & v_strKeyValue & "!varchar2!20"
            'v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString, v_strClause, , , , , , , gc_CommandProcedure)
            'v_ws.Message(v_strObjMsg)

            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, "OD.ODMAST", _
                     gc_ActionAdhoc, , v_strClause, "ExecuteOD9996", , , v_strKeyValue, )
            Dim v_lngError As Long = v_ws.Message(v_strObjMsg)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_ws = Nothing
        End Try
    End Sub

    Protected Overrides Sub ConfirmCA(ByVal v_strKeyValue As String)
        Dim v_strSQLString As String
        Dim v_strClause As String
        Dim i, j As Integer
        Dim v_strObjMsg As String
        Dim v_ws As New BDSDeliveryLongTimeOutManagement    'BDSDelivery.BDSDelivery
        Try
            'get cash information
            v_strSQLString = "cspks_caproc.pr_send_cop_action"
            v_strClause = "p_camastid!" & v_strKeyValue & "!varchar2!20"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_ALLCODE, gc_ActionInquiry, v_strSQLString, v_strClause, , , , , , , gc_CommandProcedure)
            v_ws.Message(v_strObjMsg)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            v_ws = Nothing
        End Try
    End Sub
    'Protected Overrides Sub InitDialog()
    '    MyBase.InitDialog()
    '    If InStr("/CA9999/CA9998/", TableName) > 0 Then
    '        For Each mi As MenuItem In SearchGrid.ContextMenu.MenuItems
    '            mi.Enabled = False
    '        Next
    '    End If
    'End Sub

    'Protected Overrides Sub Grid_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    '    If InStr("/CA9999/CA9998/", TableName) > 0 Then
    '        'For i As Integer = 0 To SearchGrid.DataRows.Count - 1
    '        '    CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("__TICK").Value = String.Empty
    '        'Next

    '        For Each dr As Xceed.Grid.DataRow In SearchGrid.DataRows

    '            If Not dr.Equals(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow)) Then

    '                dr.Cells("__TICK").Value = String.Empty
    '            End If
    '        Next

    '    End If

    '    MyBase.Grid_Click(sender, e)

    'End Sub

    Protected Overrides Sub SendEmailCall(ByVal v_strObjMsg As String, ByRef v_strEmaillogmessage As String)
        Dim v_xmlDocument As New XmlDocumentEx
        Dim v_xmlNodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strVALUE, v_strBODY, v_strSignature, v_strAFACCTNO, v_strEMAIL, v_strFULLNAME, v_strSHORTNAME, v_strCUSTODYCD As String
        Dim objMail As New Delivery, v_strTO, v_strTXTIME, v_strEmaillogmessageTemp As String
        Dim v_strSQL, v_strObjMsgVar, v_strBodyMail, v_strToEmail, v_strFromEmail, v_strUsername, v_strPassword, v_strMailServer, v_strTitle, v_strHeader, v_strHeaderOrg, v_strBodyMailOrg As String
        Dim v_wsObj As New BDSDeliveryManagement
        Dim v_lngErrorCode As Long
        'Dim v_strErrorSource, v_strErrorMessage As String

        Try
            v_strSQL = "SELECT (SELECT VARDESC FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'MESSDF1002') MESSDF1002 " _
                    & ", (SELECT VARDESC FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'MESSDF1002TITLE') MESSDF1002TITLE " _
                    & ", (SELECT VARDESC FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'MESSDF1003FROEM') MESSDF1003FROEM " _
                    & ", (SELECT VARDESC FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'MESSDF1003USER') MESSDF1003USER " _
                    & ", (SELECT VARDESC FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'MESSDF1003PASS') MESSDF1003PASS " _
                    & ", (SELECT VARDESC FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'MAILSERVERNAME') MAILSERVERNAME " _
                    & ", (SELECT VARDESC FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'MAILHEADER') MAILHEADER " _
                    & ", (SELECT VARDESC FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'MESSDF1003SIGN') MESSDF1003SIGN FROM DUAL"
            v_strObjMsgVar = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_RPTMASTER, _
                                            gc_ActionInquiry, v_strSQL)
            v_wsObj.Message(v_strObjMsgVar)
            v_xmlDocument.LoadXml(v_strObjMsgVar)
            v_xmlNodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i As Integer = 0 To v_xmlNodeList.Count - 1
                v_strBodyMail = ""
                v_strToEmail = ""
                v_strFromEmail = ""
                v_strUsername = ""
                v_strPassword = ""
                v_strMailServer = ""
                v_strTitle = ""
                v_strSignature = ""
                v_strHeader = ""
                For l As Integer = 0 To v_xmlNodeList.Item(i).ChildNodes.Count - 1
                    With v_xmlNodeList.Item(i).ChildNodes(l)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strVALUE = .InnerText.ToString
                        Select Case v_strFLDNAME.Trim()
                            Case "MESSDF1002"
                                v_strBodyMailOrg = v_strVALUE.Trim()
                            Case "MESSDF1002TITLE"
                                v_strTitle = v_strVALUE.Trim()
                            Case "MESSDF1003FROEM"
                                v_strFromEmail = v_strVALUE.Trim()
                            Case "MESSDF1003USER"
                                v_strUsername = v_strVALUE.Trim()
                            Case "MESSDF1003PASS"
                                v_strPassword = v_strVALUE.Trim()
                            Case "MAILSERVERNAME"
                                v_strMailServer = v_strVALUE.Trim()
                            Case "MESSDF1003SIGN"
                                v_strSignature = v_strVALUE.Trim()
                            Case "MAILHEADER"
                                v_strHeaderOrg = v_strVALUE.Trim()
                        End Select
                    End With
                Next
            Next

            If v_strBodyMailOrg.Length > 0 Then
                v_strBodyMail = v_strBodyMailOrg
                v_strHeader = v_strHeaderOrg
                v_strEmaillogmessageTemp = v_strEmaillogmessage

                v_xmlDocument.LoadXml(v_strObjMsg)
                v_xmlNodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                For j As Integer = 0 To v_xmlNodeList.Count - 1
                    For k As Integer = 0 To v_xmlNodeList.Item(j).ChildNodes.Count - 1
                        With v_xmlNodeList.Item(j).ChildNodes(k)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strVALUE = .InnerText.ToString
                            v_strBodyMail = v_strBodyMail.Replace("<" & v_strFLDNAME & ">", v_strVALUE)
                            Select Case v_strFLDNAME.Trim.ToUpper()
                                Case "EMAIL"
                                    v_strToEmail = v_strVALUE.Trim
                                Case "FULLNAME"
                                    v_strHeader = v_strHeader.Replace("<FULLNAME>", v_strVALUE.Trim)
                                Case "ACCTNO"
                                    v_strEmaillogmessageTemp = v_strEmaillogmessageTemp.Replace("[ACCTNO]", v_strVALUE.Trim)
                            End Select
                        End With
                    Next
                    v_strBodyMail = v_strBodyMail.Replace("<BUSDATE>", BusDate)
                    Delivery.SendMail(v_strSignature, v_strFromEmail, v_strToEmail, v_strTitle, v_strUsername, v_strPassword, v_strBodyMail, v_strMailServer, , v_strHeader)

                    v_strTXTIME = Format(DateTime.Now, "HH:mm:ss")
                    v_strEmaillogmessageTemp = v_strEmaillogmessageTemp.Replace("[TXDATE]", BusDate)
                    v_strEmaillogmessageTemp = v_strEmaillogmessageTemp.Replace("[TXTIME]", v_strTXTIME)
                    v_strEmaillogmessageTemp = v_strEmaillogmessageTemp.Replace("[REPORTNAME]", "DF1002")
                    v_strEmaillogmessageTemp = v_strEmaillogmessageTemp.Replace("[NOTE]", "Sent Email CALL")

                    v_lngErrorCode = v_wsObj.Message(v_strEmaillogmessageTemp)

                    'GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage, Me.UserLanguage)
                    'If v_lngErrorCode <> 0 Then
                    '    'Update mouse pointer
                    '    Cursor.Current = Cursors.Default
                    '    MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                    '    Exit Sub
                    'End If

                    'MsgBox(ResourceManager.GetString("AddnewSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    'Me.DialogResult = DialogResult.OK

                    v_strBodyMail = v_strBodyMailOrg
                    v_strHeader = v_strHeaderOrg
                    v_strEmaillogmessageTemp = v_strEmaillogmessage
                Next
            Else
                If Me.UserLanguage = gc_LANG_ENGLISH Then
                    MsgBox("Lack email infomation to send for customer! ", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Else
                    MsgBox("Thiếu thông tin nội dung Email sẽ gửi cho khách hàng !", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                End If
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
    Protected Overrides Sub SendEmailTrigger(ByVal v_strObjMsg As String, ByRef v_strEmaillogmessage As String)
        Dim v_xmlDocument As New XmlDocumentEx
        Dim v_xmlNodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strVALUE, v_strBODY, v_strSignature, v_strAFACCTNO, v_strEMAIL, v_strFULLNAME, v_strSHORTNAME, v_strCUSTODYCD As String
        Dim objMail As New Delivery, v_strTO, v_strTXTIME, v_strTRIGGERDATE, v_strEmaillogmessageTemp As String
        Dim v_strSQL, v_strObjMsgVar, v_strBodyMail, v_strToEmail, v_strFromEmail, v_strUsername, v_strPassword, v_strMailServer, v_strTitle, v_strHeader, v_strHeaderOrg, v_strBodyMailOrg As String
        Dim v_wsObj As New BDSDeliveryManagement
        Dim v_lngErrorCode As Long

        Try
            v_strSQL = "SELECT (SELECT VARDESC FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'MESSDF1003') MESSDF1003 " _
                    & ", (SELECT VARDESC FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'MESSDF1003TITLE') MESSDF1003TITLE " _
                    & ", (SELECT VARDESC FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'MESSDF1003FROEM') MESSDF1003FROEM " _
                    & ", (SELECT VARDESC FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'MESSDF1003USER') MESSDF1003USER " _
                    & ", (SELECT VARDESC FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'MESSDF1003PASS') MESSDF1003PASS " _
                    & ", (SELECT VARDESC FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'MAILSERVERNAME') MAILSERVERNAME " _
                    & ", (SELECT VARDESC FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'MAILHEADER') MAILHEADER " _
                    & ", (SELECT VARDESC FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'MESSDF1003SIGN') MESSDF1003SIGN FROM DUAL"
            v_strObjMsgVar = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_RPTMASTER, _
                                            gc_ActionInquiry, v_strSQL)
            v_wsObj.Message(v_strObjMsgVar)
            v_xmlDocument.LoadXml(v_strObjMsgVar)
            v_xmlNodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i As Integer = 0 To v_xmlNodeList.Count - 1
                v_strBodyMail = ""
                v_strToEmail = ""
                v_strFromEmail = ""
                v_strUsername = ""
                v_strPassword = ""
                v_strMailServer = ""
                v_strTitle = ""
                v_strSignature = ""
                v_strHeader = ""
                For l As Integer = 0 To v_xmlNodeList.Item(i).ChildNodes.Count - 1
                    With v_xmlNodeList.Item(i).ChildNodes(l)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strVALUE = .InnerText.ToString
                        Select Case v_strFLDNAME.Trim()
                            Case "MESSDF1003"
                                v_strBodyMailOrg = v_strVALUE.Trim()
                            Case "MESSDF1003TITLE"
                                v_strTitle = v_strVALUE.Trim()
                            Case "MESSDF1003FROEM"
                                v_strFromEmail = v_strVALUE.Trim()
                            Case "MESSDF1003USER"
                                v_strUsername = v_strVALUE.Trim()
                            Case "MESSDF1003PASS"
                                v_strPassword = v_strVALUE.Trim()
                            Case "MAILSERVERNAME"
                                v_strMailServer = v_strVALUE.Trim()
                            Case "MESSDF1003SIGN"
                                v_strSignature = v_strVALUE.Trim()
                            Case "MAILHEADER"
                                v_strHeaderOrg = v_strVALUE.Trim()
                        End Select
                    End With
                Next
            Next

            If v_strBodyMailOrg.Length > 0 Then
                v_strBodyMail = v_strBodyMailOrg
                v_strHeader = v_strHeaderOrg
                v_strEmaillogmessageTemp = v_strEmaillogmessage

                v_xmlDocument.LoadXml(v_strObjMsg)
                v_xmlNodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                For j As Integer = 0 To v_xmlNodeList.Count - 1
                    For k As Integer = 0 To v_xmlNodeList.Item(j).ChildNodes.Count - 1
                        With v_xmlNodeList.Item(j).ChildNodes(k)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strVALUE = .InnerText.ToString
                            v_strBodyMail = v_strBodyMail.Replace("<" & v_strFLDNAME & ">", v_strVALUE)
                            Select Case v_strFLDNAME.Trim.ToUpper()
                                Case "EMAIL"
                                    v_strToEmail = v_strVALUE.Trim
                                Case "FULLNAME"
                                    v_strHeader = v_strHeader.Replace("<FULLNAME>", v_strVALUE.Trim)
                                Case "ACCTNO"
                                    v_strEmaillogmessageTemp = v_strEmaillogmessageTemp.Replace("[ACCTNO]", v_strVALUE.Trim)
                                Case "TRIGGERDATE"
                                    v_strTRIGGERDATE = v_strVALUE.Trim
                            End Select
                        End With
                    Next
                    v_strBodyMail = v_strBodyMail.Replace("<BUSDATE>", v_strTRIGGERDATE)
                    Delivery.SendMail(v_strSignature, v_strFromEmail, v_strToEmail, v_strTitle, v_strUsername, v_strPassword, v_strBodyMail, v_strMailServer, , v_strHeader)
                    v_strTXTIME = Format(DateTime.Now, "HH:mm:ss")
                    v_strEmaillogmessageTemp = v_strEmaillogmessageTemp.Replace("[TXDATE]", BusDate)
                    v_strEmaillogmessageTemp = v_strEmaillogmessageTemp.Replace("[TXTIME]", v_strTXTIME)
                    v_strEmaillogmessageTemp = v_strEmaillogmessageTemp.Replace("[REPORTNAME]", "DF1003")
                    v_strEmaillogmessageTemp = v_strEmaillogmessageTemp.Replace("[NOTE]", "Sent Email TRIGGER")
                    v_lngErrorCode = v_wsObj.Message(v_strEmaillogmessageTemp)

                    v_strEmaillogmessageTemp = v_strEmaillogmessage
                    v_strBodyMail = v_strBodyMailOrg
                    v_strHeader = v_strHeaderOrg
                Next
            Else
                If Me.UserLanguage = gc_LANG_ENGLISH Then
                    MsgBox("Lack email infomation to send for customer! ", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Else
                    MsgBox("Thiếu thông tin nội dung Email sẽ gửi cho khách hàng !", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                End If
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
    Protected Overrides Sub SendEmailTodue(ByVal v_strObjMsg As String, ByRef v_strEmaillogmessage As String)
        Dim v_xmlDocument As New XmlDocumentEx
        Dim v_xmlNodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strVALUE, v_strBODY, v_strSignature, v_strAFACCTNO, v_strEMAIL, v_strFULLNAME, v_strSHORTNAME, v_strCUSTODYCD As String
        Dim objMail As New Delivery, v_strTO, v_strTXTIME, v_strEmaillogmessageTemp As String
        Dim v_strSQL, v_strObjMsgVar, v_strBodyMail, v_strToEmail, v_strFromEmail, v_strUsername, v_strPassword, v_strMailServer, v_strTitle, v_strHeader, v_strHeaderOrg, v_strBodyMailOrg As String
        Dim v_wsObj As New BDSDeliveryManagement
        Dim v_lngErrorCode As Long

        Try
            v_strSQL = "SELECT (SELECT VARDESC FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'MESSDF1004') MESSDF1004 " _
                    & ", (SELECT VARDESC FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'MESSDF1004TITLE') MESSDF1004TITLE " _
                    & ", (SELECT VARDESC FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'MESSDF1003FROEM') MESSDF1003FROEM " _
                    & ", (SELECT VARDESC FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'MESSDF1003USER') MESSDF1003USER " _
                    & ", (SELECT VARDESC FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'MESSDF1003PASS') MESSDF1003PASS " _
                    & ", (SELECT VARDESC FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'MAILSERVERNAME') MAILSERVERNAME " _
                    & ", (SELECT VARDESC FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'MAILHEADER') MAILHEADER " _
                    & ", (SELECT VARDESC FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'MESSDF1003SIGN') MESSDF1003SIGN FROM DUAL"
            v_strObjMsgVar = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_RPTMASTER, _
                                            gc_ActionInquiry, v_strSQL)
            v_wsObj.Message(v_strObjMsgVar)
            v_xmlDocument.LoadXml(v_strObjMsgVar)
            v_xmlNodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i As Integer = 0 To v_xmlNodeList.Count - 1
                v_strBodyMail = ""
                v_strToEmail = ""
                v_strFromEmail = ""
                v_strUsername = ""
                v_strPassword = ""
                v_strMailServer = ""
                v_strTitle = ""
                v_strSignature = ""
                v_strHeader = ""
                For l As Integer = 0 To v_xmlNodeList.Item(i).ChildNodes.Count - 1
                    With v_xmlNodeList.Item(i).ChildNodes(l)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strVALUE = .InnerText.ToString
                        Select Case v_strFLDNAME.Trim()
                            Case "MESSDF1004"
                                v_strBodyMailOrg = v_strVALUE.Trim()
                            Case "MESSDF1004TITLE"
                                v_strTitle = v_strVALUE.Trim()
                            Case "MESSDF1003FROEM"
                                v_strFromEmail = v_strVALUE.Trim()
                            Case "MESSDF1003USER"
                                v_strUsername = v_strVALUE.Trim()
                            Case "MESSDF1003PASS"
                                v_strPassword = v_strVALUE.Trim()
                            Case "MAILSERVERNAME"
                                v_strMailServer = v_strVALUE.Trim()
                            Case "MESSDF1003SIGN"
                                v_strSignature = v_strVALUE.Trim()
                            Case "MAILHEADER"
                                v_strHeaderOrg = v_strVALUE.Trim()
                        End Select
                    End With
                Next
            Next

            If v_strBodyMailOrg.Length > 0 Then
                v_strBodyMail = v_strBodyMailOrg
                v_strHeader = v_strHeaderOrg
                v_strEmaillogmessageTemp = v_strEmaillogmessage

                v_xmlDocument.LoadXml(v_strObjMsg)
                v_xmlNodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                For j As Integer = 0 To v_xmlNodeList.Count - 1
                    For k As Integer = 0 To v_xmlNodeList.Item(j).ChildNodes.Count - 1
                        With v_xmlNodeList.Item(j).ChildNodes(k)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strVALUE = .InnerText.ToString
                            v_strBodyMail = v_strBodyMail.Replace("<" & v_strFLDNAME & ">", v_strVALUE)
                            Select Case v_strFLDNAME.Trim.ToUpper()
                                Case "EMAIL"
                                    v_strToEmail = v_strVALUE.Trim
                                Case "FULLNAME"
                                    v_strHeader = v_strHeader.Replace("<FULLNAME>", v_strVALUE.Trim)
                                Case "ACCTNO"
                                    v_strEmaillogmessageTemp = v_strEmaillogmessageTemp.Replace("[ACCTNO]", v_strVALUE.Trim)
                            End Select
                        End With
                    Next
                    v_strBodyMail = v_strBodyMail.Replace("<BUSDATE>", BusDate)
                    Delivery.SendMail(v_strSignature, v_strFromEmail, v_strToEmail, v_strTitle, v_strUsername, v_strPassword, v_strBodyMail, v_strMailServer, , v_strHeader)
                    v_strTXTIME = Format(DateTime.Now, "HH:mm:ss")
                    v_strEmaillogmessageTemp = v_strEmaillogmessageTemp.Replace("[TXDATE]", BusDate)
                    v_strEmaillogmessageTemp = v_strEmaillogmessageTemp.Replace("[TXTIME]", v_strTXTIME)
                    v_strEmaillogmessageTemp = v_strEmaillogmessageTemp.Replace("[REPORTNAME]", "DF1004")
                    v_strEmaillogmessageTemp = v_strEmaillogmessageTemp.Replace("[NOTE]", "Sent Email TODUE")
                    v_lngErrorCode = v_wsObj.Message(v_strEmaillogmessageTemp)

                    v_strBodyMail = v_strBodyMailOrg
                    v_strHeader = v_strHeaderOrg
                    v_strEmaillogmessageTemp = v_strEmaillogmessage
                Next
            Else
                If Me.UserLanguage = gc_LANG_ENGLISH Then
                    MsgBox("Lack email infomation to send for customer! ", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Else
                    MsgBox("Thiếu thông tin nội dung Email sẽ gửi cho khách hàng !", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                End If
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
    Protected Overrides Sub SendEmailOVD(ByVal v_strObjMsg As String, ByRef v_strEmaillogmessage As String)
        Dim v_xmlDocument As New XmlDocumentEx
        Dim v_xmlNodeList As Xml.XmlNodeList
        Dim v_strFLDNAME, v_strVALUE, v_strBODY, v_strSignature, v_strAFACCTNO, v_strEMAIL, v_strFULLNAME, v_strSHORTNAME, v_strCUSTODYCD As String
        Dim objMail As New Delivery, v_strTO, v_strTXTIME, v_strEmaillogmessageTemp As String
        Dim v_strSQL, v_strObjMsgVar, v_strBodyMail, v_strToEmail, v_strFromEmail, v_strUsername, v_strPassword, v_strMailServer, v_strTitle, v_strHeader, v_strHeaderOrg, v_strBodyMailOrg As String
        Dim v_wsObj As New BDSDeliveryManagement
        Dim v_lngErrorCode As Long

        Try
            v_strSQL = "SELECT (SELECT VARDESC FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'MESSDF1005') MESSDF1005 " _
                    & ", (SELECT VARDESC FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'MESSDF1005TITLE') MESSDF1005TITLE " _
                    & ", (SELECT VARDESC FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'MESSDF1003FROEM') MESSDF1003FROEM " _
                    & ", (SELECT VARDESC FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'MESSDF1003USER') MESSDF1003USER " _
                    & ", (SELECT VARDESC FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'MESSDF1003PASS') MESSDF1003PASS " _
                    & ", (SELECT VARDESC FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'MAILSERVERNAME') MAILSERVERNAME " _
                    & ", (SELECT VARDESC FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'MAILHEADER') MAILHEADER " _
                    & ", (SELECT VARDESC FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'MESSDF1003SIGN') MESSDF1003SIGN FROM DUAL"
            v_strObjMsgVar = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_RPTMASTER, _
                                            gc_ActionInquiry, v_strSQL)
            v_wsObj.Message(v_strObjMsgVar)
            v_xmlDocument.LoadXml(v_strObjMsgVar)
            v_xmlNodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

            For i As Integer = 0 To v_xmlNodeList.Count - 1
                v_strBodyMail = ""
                v_strToEmail = ""
                v_strFromEmail = ""
                v_strUsername = ""
                v_strPassword = ""
                v_strMailServer = ""
                v_strTitle = ""
                v_strSignature = ""
                v_strHeader = ""
                For l As Integer = 0 To v_xmlNodeList.Item(i).ChildNodes.Count - 1
                    With v_xmlNodeList.Item(i).ChildNodes(l)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strVALUE = .InnerText.ToString
                        Select Case v_strFLDNAME.Trim()
                            Case "MESSDF1005"
                                v_strBodyMailOrg = v_strVALUE.Trim()
                            Case "MESSDF1005TITLE"
                                v_strTitle = v_strVALUE.Trim()
                            Case "MESSDF1003FROEM"
                                v_strFromEmail = v_strVALUE.Trim()
                            Case "MESSDF1003USER"
                                v_strUsername = v_strVALUE.Trim()
                            Case "MESSDF1003PASS"
                                v_strPassword = v_strVALUE.Trim()
                            Case "MAILSERVERNAME"
                                v_strMailServer = v_strVALUE.Trim()
                            Case "MESSDF1003SIGN"
                                v_strSignature = v_strVALUE.Trim()
                            Case "MAILHEADER"
                                v_strHeaderOrg = v_strVALUE.Trim()
                        End Select
                    End With
                Next
            Next

            If v_strBodyMailOrg.Length > 0 Then
                v_strBodyMail = v_strBodyMailOrg
                v_strHeader = v_strHeaderOrg
                v_strEmaillogmessageTemp = v_strEmaillogmessage

                v_xmlDocument.LoadXml(v_strObjMsg)
                v_xmlNodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")

                For j As Integer = 0 To v_xmlNodeList.Count - 1
                    For k As Integer = 0 To v_xmlNodeList.Item(j).ChildNodes.Count - 1
                        With v_xmlNodeList.Item(j).ChildNodes(k)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strVALUE = .InnerText.ToString
                            v_strBodyMail = v_strBodyMail.Replace("<" & v_strFLDNAME & ">", v_strVALUE)
                            Select Case v_strFLDNAME.Trim.ToUpper()
                                Case "EMAIL"
                                    v_strToEmail = v_strVALUE.Trim
                                Case "FULLNAME"
                                    v_strHeader = v_strHeader.Replace("<FULLNAME>", v_strVALUE.Trim)
                                Case "ACCTNO"
                                    v_strEmaillogmessageTemp = v_strEmaillogmessageTemp.Replace("[ACCTNO]", v_strVALUE.Trim)
                            End Select
                        End With
                    Next
                    v_strBodyMail = v_strBodyMail.Replace("<BUSDATE>", BusDate)
                    Delivery.SendMail(v_strSignature, v_strFromEmail, v_strToEmail, v_strTitle, v_strUsername, v_strPassword, v_strBodyMail, v_strMailServer, , v_strHeader)
                    v_strTXTIME = Format(DateTime.Now, "HH:mm:ss")
                    v_strEmaillogmessageTemp = v_strEmaillogmessageTemp.Replace("[TXDATE]", BusDate)
                    v_strEmaillogmessageTemp = v_strEmaillogmessageTemp.Replace("[TXTIME]", v_strTXTIME)
                    v_strEmaillogmessageTemp = v_strEmaillogmessageTemp.Replace("[REPORTNAME]", "DF1005")
                    v_strEmaillogmessageTemp = v_strEmaillogmessageTemp.Replace("[NOTE]", "Sent Email OVD")
                    v_lngErrorCode = v_wsObj.Message(v_strEmaillogmessageTemp)

                    v_strBodyMail = v_strBodyMailOrg
                    v_strHeader = v_strHeaderOrg
                    v_strEmaillogmessageTemp = v_strEmaillogmessage

                Next
            Else
                If Me.UserLanguage = gc_LANG_ENGLISH Then
                    MsgBox("Lack email infomation to send for customer! ", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                Else
                    MsgBox("Thiếu thông tin nội dung Email sẽ gửi cho khách hàng !", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                End If
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub
    Private Sub TimerReport_Elapsed(ByVal sender As Object, ByVal e As ElapsedEventArgs)

        If Me.isAutoSearch Then
            OnSearch(IsLocalSearch, ModuleCode & "." & ObjectName, 1)
        End If
    End Sub

    'Creates form from form name - CASE SENSITIVE
    Public Function GetFormByName(ByVal formName As String) As Form
        ''  Dim assemblyName As String = [Assembly].GetEntryAssembly().GetName.Name.Replace("@", "_")
        Dim assemblyName As String = "_DIRECT"
        Dim myType As Type = Type.GetType(assemblyName & "." & formName)
        Return CType(Activator.CreateInstance(myType), Form)
    End Function

    Protected Overrides Sub SendNotification(ByVal v_strSENDVIA As String)
        Dim v_strSQL, v_strClause, v_strObjMsg, v_strFLDNAME, v_strVALUE, v_strSELECTED, v_strDESC, v_strREFNAME, v_strMAILUSER, v_strMAILPASS, _
            v_strBODYTEMPLATE, v_strHEADER, v_strMAILSERVER, v_strSIGNATURE, v_strFRFULLNAME, v_strFREMAIL, v_strTOEMAIL, v_strTOSMS, V_strSEARCHCODE As String
        Dim v_strTMPCODE, v_strTMPNAME, v_strTMPTYPE, v_strTMPPATH, v_strTMPBODY, v_strACCTNO, _
            v_strREFSENDER, v_strREFFLDACCT, v_strREFMODCODE, v_strTAGFLDNAME, v_strTAGFLDVAL, v_strNOTIFICATIONSTATUS As String
        Dim v_intIndex, v_intNodeIndex, v_intCol, i, j, v_strCount As Integer
        Dim v_lngErrCode As Long = ERR_SYSTEM_OK
        Dim v_strErrorSource As String = "@DIRECT.frmSearchMaster.SendNotification", v_strErrorMessage As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_nodeList As Xml.XmlNodeList

        Dim v_strXMLBuilder As New StringBuilder
        Dim v_xmlBuilder As New Xml.XmlDocument
        Dim nodeItem As Xml.XmlNode, nodeList As Xml.XmlNodeList
        v_strCount = 0
        Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
        Try
            'AnTB 10/07/2014 Them Xu ly gui nhieu SMS cung luc
            If (SearchGridView.GetSelectedRows().Count > 0) Then
                'XÁC ĐỊNH THAM SỐ ĐỂ TẠO NỘI DUNG NOTIFICATION
                '=============================================================================================================================================
                v_strSQL = "SELECT MST.TMPCODE VALUECD, MST.TMPCODE VALUE, MST.TMPNAME DISPLAY, MST.TMPNAME EN_DISPLAY, MST.TMPNAME DESCRIPTION, " & ControlChars.CrLf _
                    & "MST.TMPCODE, MST.TMPNAME, MST.TMPTYPE, MST.TMPPATH, MST.TMPBODY, DTL.SEARCHCODE, DTL.SENDER, DTL.FIELDNAME, DTL.MODCODE, DTL.NOTES " & ControlChars.CrLf _
                    & "FROM CONTENTTMP MST, VIEWLNK2TMP DTL WHERE MST.TMPCODE=DTL.TMPCODE AND DTL.SEARCHCODE='" & mv_strTableName & "' AND MST.SENDVIA='" & v_strSENDVIA & "'"
                Dim frm As New AppCore.frmLookUp(UserLanguage)
                frm.SQLCMD = v_strSQL
                frm.IsLocalSearch = gc_IsNotLocalMsg
                frm.AutoClosed = True
                frm.ShowDialog()
                v_intIndex = InStr(frm.RETURNDATA, vbTab)
                If v_intIndex > 0 Then
                    v_strSELECTED = Mid(frm.RETURNDATA, 1, v_intIndex - 1)
                    v_strDESC = Mid(frm.RETURNDATA, v_intIndex + 1)
                    'Xác định các giá trị của Template
                    v_xmlDocument.LoadXml(frm.FULLDATA)
                    'Xac dinh node chua du lieu
                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                    For i = 0 To v_nodeList.Count - 1
                        For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                            With v_nodeList.Item(i).ChildNodes(j)
                                If String.Compare(CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value), "VALUE") = 0 _
                                    And v_strSELECTED = Trim(.InnerText.ToString) Then
                                    v_intNodeIndex = i
                                    Exit For
                                End If
                            End With
                        Next
                    Next
                    'Xác định giá trị cho các biến
                    For j = 0 To v_nodeList.Item(v_intNodeIndex).ChildNodes.Count - 1
                        With v_nodeList.Item(v_intNodeIndex).ChildNodes(j)
                            v_strREFNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value).Trim
                            Select Case v_strREFNAME
                                Case "TMPCODE"
                                    v_strTMPCODE = .InnerText.ToString.Trim
                                Case "TMPNAME"
                                    v_strTMPNAME = .InnerText.ToString.Trim
                                Case "TMPTYPE"
                                    v_strTMPTYPE = .InnerText.ToString.Trim
                                Case "TMPPATH"
                                    v_strTMPPATH = .InnerText.ToString.Trim
                                Case "TMPBODY"
                                    v_strTMPBODY = .InnerText.ToString.Trim
                                Case "MODCODE"
                                    v_strREFMODCODE = .InnerText.ToString.Trim
                                Case "SEARCHCODE"
                                    V_strSEARCHCODE = .InnerText.ToString.Trim
                                Case "SENDER"
                                    v_strREFSENDER = .InnerText.ToString.Trim
                                Case "FIELDNAME"
                                    v_strREFFLDACCT = .InnerText.ToString.Trim
                                Case "NOTES"
                                    v_strHEADER = .InnerText.ToString.Trim
                            End Select
                        End With
                    Next
                End If
                frm.Dispose()
                For Each k As Integer In SearchGridView.GetSelectedRows
                    'Dim dr As DataRow = CType(SearchGridView.GetRow(k), DataRowView).Row

                    'TẠO NỘI DUNG NOTIFICATION
                    '=============================================================================================================================================
                    'v_strBODYTEMPLATE = ""
                    If String.Compare(v_strTMPTYPE, "T") = 0 Then
                        v_strBODYTEMPLATE = v_strTMPBODY
                    ElseIf String.Compare(v_strTMPTYPE, "H") = 0 Then
                        'Body thi phai lay tu file len
                        Dim oFile As System.IO.File
                        Dim oRead As System.IO.StreamReader                '    oRead = oFile.OpenText(v_strTMPPATH) 'filename (like attachment name)
                        v_strBODYTEMPLATE = oRead.ReadToEnd()
                        oRead.Close()
                    End If
                    '  If v_strBODYTEMPLATE.Length > 0 Then
                    'Thay thế các nội dung của body template bằng các trường trong bản ghi tìm kiếm đang được chọn

                    For v_intCol = 0 To SearchGridView.Columns.Count - 1
                        v_strTAGFLDNAME = SearchGridView.Columns(v_intCol).FieldName
                        v_strTAGFLDVAL = SearchGridView.GetDataRow(k)(v_strTAGFLDNAME).ToString
                        v_strBODYTEMPLATE = v_strBODYTEMPLATE.Replace("[" & v_strTAGFLDNAME & "]", v_strTAGFLDVAL)
                        If String.Compare(v_strREFFLDACCT, v_strTAGFLDNAME) = 0 Then
                            'Ghi nhận giá trị trường tiểu khoản
                            v_strACCTNO = v_strTAGFLDVAL
                        End If

                        If Len(v_strTAGFLDVAL) > 0 Then
                            v_strBODYTEMPLATE = v_strBODYTEMPLATE & "'" & v_strTAGFLDVAL & "' " & v_strTAGFLDNAME & ","
                        End If
                    Next

                    v_strBODYTEMPLATE = "select " & v_strBODYTEMPLATE & "'aa' aa from dual "

                    If String.Compare(mv_strTableName, "DD0003") = 0 Then
                        v_strTOEMAIL = String.Empty
                        v_strTOSMS = String.Empty
                    Else
                        v_strSQL = "SELECT CF.MOBILESMS, CF.EMAIL FROM cfmast CF, ddmast AF WHERE CF.CUSTID=AF.CUSTID AND AF.ACCTNO='" & v_strACCTNO.Replace(".", "") & "'"
                        v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_RPTMASTER, _
                                                        gc_ActionInquiry, v_strSQL)
                        v_ws.Message(v_strObjMsg)
                        v_xmlDocument.LoadXml(v_strObjMsg)
                        v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
                        'Thay thế các trường nội dung liên quan đến thông tin khách hàng
                        For i = 0 To v_nodeList.Count - 1
                            For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                                With v_nodeList.Item(i).ChildNodes(j)
                                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                                    v_strVALUE = .InnerText.ToString
                                    v_strBODYTEMPLATE = v_strBODYTEMPLATE.Replace("[$" & v_strFLDNAME & "]", v_strVALUE)
                                    If String.Compare(v_strFLDNAME, "EMAIL") = 0 Then
                                        v_strTOEMAIL = v_strVALUE
                                    ElseIf String.Compare(v_strFLDNAME, "MOBILESMS") = 0 Then
                                        v_strTOSMS = v_strVALUE
                                    End If
                                End With
                            Next
                        Next
                    End If
                    'GỬI NOTIFICATION
                    '=============================================================================================================================================
                    If String.Compare(v_strSENDVIA, gc_SEND_VIA_SMS) = 0 Then
                        v_strNOTIFICATIONSTATUS = "P"
                    ElseIf String.Compare(v_strSENDVIA, "E") = 0 Then
                        v_strNOTIFICATIONSTATUS = "S"
                    End If

                    'Log noi dung gui cho khach hang: TẠO ADDNEW OBJECT SENDMSGLOG
                    'TLID, SENDVIA, TOADDR, ACCTNO, MODCODE, MSGTITLE, MSGBODY, STATUS
                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, "N", gc_MsgTypeObj, "SA.SENDMSGLOG", gc_ActionAdd, , , , "Y")
                    v_xmlDocument.LoadXml(v_strObjMsg)
                    v_strXMLBuilder = New StringBuilder
                    v_strXMLBuilder.Append("<ObjData>")
                    v_strXMLBuilder.Append("<Entry fldname='AUTOID' fldtype='System.String' oldval=''>" & "0" & "</Entry>")
                    v_strXMLBuilder.Append("<Entry fldname='TLID' fldtype='System.String' oldval=''>" & Me.TellerId & "</Entry>")
                    v_strXMLBuilder.Append("<Entry fldname='SENDVIA' fldtype='System.String' oldval=''>" & v_strSENDVIA & "</Entry>")
                    v_strXMLBuilder.Append("<Entry fldname='TOADDR' fldtype='System.String' oldval=''>" & IIf(v_strSENDVIA = "S", v_strTOSMS, v_strTOEMAIL) & "</Entry>")
                    v_strXMLBuilder.Append("<Entry fldname='ACCTNO' fldtype='System.String' oldval=''>" & v_strACCTNO & "</Entry>")
                    v_strXMLBuilder.Append("<Entry fldname='MODCODE' fldtype='System.String' oldval=''>" & v_strREFMODCODE & "</Entry>")
                    v_strXMLBuilder.Append("<Entry fldname='MSGTITLE' fldtype='System.String' oldval=''>" & v_strHEADER & "</Entry>")
                    v_strXMLBuilder.Append("<Entry fldname='MSGBODY' fldtype='System.String' oldval=''>" & IIf(v_strTMPTYPE = "T", v_strBODYTEMPLATE.Replace("''", ",").Replace("[BUSDATE]", BusDate), v_strTMPPATH) & "</Entry>")
                    v_strXMLBuilder.Append("<Entry fldname='STATUS' fldtype='System.String' oldval=''>" & v_strNOTIFICATIONSTATUS & "</Entry>")
                    v_strXMLBuilder.Append("<Entry fldname='TXTIME' fldtype='System.String' oldval=''>" & Format(DateTime.Now, "HH:mm:ss") & "</Entry>")
                    v_strXMLBuilder.Append("<Entry fldname='TXDATE' fldtype='System.String' oldval=''>" & Me.BusDate & "</Entry>")
                    v_strXMLBuilder.Append("<Entry fldname='SEARCHCODE' fldtype='System.String' oldval=''>" & V_strSEARCHCODE & "</Entry>")
                    v_strXMLBuilder.Append("</ObjData>")
                    v_xmlBuilder.LoadXml(v_strXMLBuilder.ToString)
                    nodeItem = v_xmlDocument.ImportNode(v_xmlBuilder.SelectSingleNode("/ObjData"), True)
                    v_xmlDocument.DocumentElement.AppendChild(nodeItem)
                    v_strObjMsg = v_xmlDocument.InnerXml
                    'Gửi message
                    v_lngErrCode = v_ws.Message(v_strObjMsg)
                    'Get error description
                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrCode, v_strErrorMessage)
                    If v_lngErrCode <> ERR_SYSTEM_OK Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Sub
                    Else
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        'v_strCount = v_strCount + 1
                        'MsgBox(Me.Text & ": " & IIf(v_strSENDVIA = gc_SEND_VIA_SMS, "SMS", "EMAIL") & "-" & IIf(v_strSENDVIA = gc_SEND_VIA_SMS, v_strTOSMS, v_strTOEMAIL), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        'Exit Sub
                    End If
                Next
            End If

            MsgBox(IIf(v_strSENDVIA = gc_SEND_VIA_SMS, ResourceManager.GetString("frmSearch.SMSSuccess"), ResourceManager.GetString("frmSearch.EmailSuccess")), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
            'v_strCount = 0

        Catch ex As Exception
        Finally
            v_ws = Nothing
        End Try
    End Sub


    'Protected Overrides Sub SendNotification(ByVal v_strSENDVIA As String)
    '    Dim v_strSQL, v_strClause, v_strObjMsg, v_strFLDNAME, v_strVALUE, v_strSELECTED, v_strDESC, v_strREFNAME, v_strMAILUSER, v_strMAILPASS, _
    '        v_strBODYTEMPLATE, v_strHEADER, v_strMAILSERVER, v_strSIGNATURE, v_strFRFULLNAME, v_strFREMAIL, v_strTOEMAIL, v_strTOSMS, V_strSEARCHCODE As String
    '    Dim v_strTMPCODE, v_strTMPNAME, v_strTMPTYPE, v_strTMPPATH, v_strTMPBODY, v_strACCTNO, _
    '        v_strREFSENDER, v_strREFFLDACCT, v_strREFMODCODE, v_strTAGFLDNAME, v_strTAGFLDVAL, v_strNOTIFICATIONSTATUS As String
    '    Dim v_intIndex, v_intNodeIndex, v_intCol, i, j, v_strCount As Integer, v_dgROW As Xceed.Grid.DataRow
    '    Dim v_lngErrCode As Long = ERR_SYSTEM_OK
    '    Dim v_strErrorSource As String = "@DIRECT.frmSearchMaster.SendNotification", v_strErrorMessage As String
    '    Dim v_xmlDocument As New Xml.XmlDocument, v_nodeList As Xml.XmlNodeList

    '    Dim v_strXMLBuilder As New StringBuilder
    '    Dim v_xmlBuilder As New Xml.XmlDocument
    '    Dim nodeItem As Xml.XmlNode, nodeList As Xml.XmlNodeList
    '    v_strCount = 0
    '    Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
    '    Try
    '        'AnTB 10/07/2014 Them Xu ly gui nhieu SMS cung luc
    '        If (SearchGrid.DataRows.Count > 0) Then
    '            'XÁC ĐỊNH THAM SỐ ĐỂ TẠO NỘI DUNG NOTIFICATION
    '            '=============================================================================================================================================
    '            v_strSQL = "SELECT MST.TMPCODE VALUECD, MST.TMPCODE VALUE, MST.TMPNAME DISPLAY, MST.TMPNAME EN_DISPLAY, MST.TMPNAME DESCRIPTION, " & ControlChars.CrLf _
    '                & "MST.TMPCODE, MST.TMPNAME, MST.TMPTYPE, MST.TMPPATH, MST.TMPBODY, DTL.SEARCHCODE, DTL.SENDER, DTL.FIELDNAME, DTL.MODCODE, DTL.NOTES " & ControlChars.CrLf _
    '                & "FROM CONTENTTMP MST, VIEWLNK2TMP DTL WHERE MST.TMPCODE=DTL.TMPCODE AND DTL.SEARCHCODE='" & mv_strTableName & "' AND MST.SENDVIA='" & v_strSENDVIA & "'"
    '            Dim frm As New AppCore.frmLookUp(UserLanguage)
    '            frm.SQLCMD = v_strSQL
    '            frm.IsLocalSearch = gc_IsNotLocalMsg
    '            frm.AutoClosed = True
    '            frm.ShowDialog()
    '            v_intIndex = InStr(frm.RETURNDATA, vbTab)
    '            If v_intIndex > 0 Then
    '                v_strSELECTED = Mid(frm.RETURNDATA, 1, v_intIndex - 1)
    '                v_strDESC = Mid(frm.RETURNDATA, v_intIndex + 1)
    '                'Xác định các giá trị của Template
    '                v_xmlDocument.LoadXml(frm.FULLDATA)
    '                'Xac dinh node chua du lieu
    '                v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
    '                For i = 0 To v_nodeList.Count - 1
    '                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
    '                        With v_nodeList.Item(i).ChildNodes(j)
    '                            If String.Compare(CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value), "VALUE") = 0 _
    '                                And v_strSELECTED = Trim(.InnerText.ToString) Then
    '                                v_intNodeIndex = i
    '                                Exit For
    '                            End If
    '                        End With
    '                    Next
    '                Next
    '                'Xác định giá trị cho các biến
    '                For j = 0 To v_nodeList.Item(v_intNodeIndex).ChildNodes.Count - 1
    '                    With v_nodeList.Item(v_intNodeIndex).ChildNodes(j)
    '                        v_strREFNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value).Trim
    '                        Select Case v_strREFNAME
    '                            Case "TMPCODE"
    '                                v_strTMPCODE = .InnerText.ToString.Trim
    '                            Case "TMPNAME"
    '                                v_strTMPNAME = .InnerText.ToString.Trim
    '                            Case "TMPTYPE"
    '                                v_strTMPTYPE = .InnerText.ToString.Trim
    '                            Case "TMPPATH"
    '                                v_strTMPPATH = .InnerText.ToString.Trim
    '                            Case "TMPBODY"
    '                                v_strTMPBODY = .InnerText.ToString.Trim
    '                            Case "MODCODE"
    '                                v_strREFMODCODE = .InnerText.ToString.Trim
    '                            Case "SEARCHCODE"
    '                                V_strSEARCHCODE = .InnerText.ToString.Trim
    '                            Case "SENDER"
    '                                v_strREFSENDER = .InnerText.ToString.Trim
    '                            Case "FIELDNAME"
    '                                v_strREFFLDACCT = .InnerText.ToString.Trim
    '                            Case "NOTES"
    '                                v_strHEADER = .InnerText.ToString.Trim
    '                        End Select
    '                    End With
    '                Next
    '            End If
    '            frm.Dispose()
    '            For k As Integer = 0 To SearchGrid.DataRows.Count - 1
    '                If SearchGrid.DataRows(k).Cells("__TICK").Value = "X" Then
    '                    'If Not (SearchGrid.CurrentRow Is Nothing) Then

    '                    'TẠO NỘI DUNG NOTIFICATION
    '                    '=============================================================================================================================================
    '                    'v_strBODYTEMPLATE = ""
    '                    If String.Compare(v_strTMPTYPE, "T") = 0 Then
    '                        v_strBODYTEMPLATE = v_strTMPBODY
    '                    ElseIf String.Compare(v_strTMPTYPE, "H") = 0 Then
    '                        'Body thi phai lay tu file len
    '                        Dim oFile As System.IO.File
    '                        Dim oRead As System.IO.StreamReader                '    oRead = oFile.OpenText(v_strTMPPATH) 'filename (like attachment name)
    '                        v_strBODYTEMPLATE = oRead.ReadToEnd()
    '                        oRead.Close()
    '                    End If
    '                    '  If v_strBODYTEMPLATE.Length > 0 Then
    '                    'Thay thế các nội dung của body template bằng các trường trong bản ghi tìm kiếm đang được chọn
    '                    v_dgROW = CType(SearchGrid.DataRows(k), Xceed.Grid.DataRow)
    '                    For v_intCol = 1 To v_dgROW.Cells.Count - 1
    '                        v_strTAGFLDNAME = v_dgROW.Cells(v_intCol).FieldName
    '                        v_strTAGFLDVAL = v_dgROW.Cells(v_intCol).Value
    '                        v_strBODYTEMPLATE = v_strBODYTEMPLATE.Replace("[" & v_strTAGFLDNAME & "]", v_strTAGFLDVAL)
    '                        If String.Compare(v_strREFFLDACCT, v_strTAGFLDNAME) = 0 Then
    '                            'Ghi nhận giá trị trường tiểu khoản
    '                            v_strACCTNO = v_strTAGFLDVAL
    '                        End If

    '                        If Len(v_strTAGFLDVAL) > 0 Then
    '                            v_strBODYTEMPLATE = v_strBODYTEMPLATE & "'" & v_strTAGFLDVAL & "' " & v_strTAGFLDNAME & ","
    '                        End If
    '                    Next

    '                    v_strBODYTEMPLATE = "select " & v_strBODYTEMPLATE & "'aa' aa from dual "

    '                    'End If

    '                    'Xác định thông tin về khách hàng
    '                    'If String.Compare(v_strREFMODCODE, "AF") = 0 Then
    '                    '    v_strSQL = "SELECT CF.* FROM CFMAST CF, AFMAST AF WHERE CF.CUSTID=AF.CUSTID AND AF.ACCTNO='" & v_strACCTNO.Replace(".", "") & "'"
    '                    'Else
    '                    '    v_strSQL = "SELECT CF.* FROM CFMAST CF, AFMAST AF, " & v_strREFMODCODE & "MAST MST WHERE CF.CUSTID=AF.CUSTID AND AF.ACCTNO=MST.AFACCTNO AND MST.ACCTNO='" & v_strACCTNO.Replace(".", "") & "'"
    '                    'End If
    '                    'v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_RPTMASTER, _
    '                    '                                gc_ActionInquiry, v_strSQL)
    '                    'v_ws.Message(v_strObjMsg)
    '                    'v_xmlDocument.LoadXml(v_strObjMsg)
    '                    'v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
    '                    ''Thay thế các trường nội dung liên quan đến thông tin khách hàng
    '                    'For i = 0 To v_nodeList.Count - 1
    '                    '    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
    '                    '        With v_nodeList.Item(i).ChildNodes(j)
    '                    '            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
    '                    '            v_strVALUE = .InnerText.ToString
    '                    '            v_strBODYTEMPLATE = v_strBODYTEMPLATE.Replace("[$" & v_strFLDNAME & "]", v_strVALUE)
    '                    '            If String.Compare(v_strFLDNAME, "EMAIL") = 0 Then
    '                    '                v_strTOEMAIL = v_strVALUE
    '                    '            ElseIf String.Compare(v_strFLDNAME, "MOBILE") = 0 Then
    '                    '                v_strTOSMS = v_strVALUE
    '                    '            End If
    '                    '        End With
    '                    '    Next
    '                    'Next
    '                    If String.Compare(v_strREFMODCODE, "AF") = 0 Then
    '                        v_strSQL = "SELECT CF.*, CF.MOBILESMS FAX2, CF.EMAIL EMAIL1 FROM VW_CFMAST_SMS CF, AFMAST AF WHERE CF.CUSTID=AF.CUSTID AND AF.ACCTNO='" & v_strACCTNO.Replace(".", "") & "'"
    '                    ElseIf String.Compare(v_strREFMODCODE, "CF") = 0 Then
    '                        v_strSQL = "SELECT CF.*, CF.MOBILESMS FAX2, CF.EMAIL EMAIL1 FROM VW_CFMAST_SMS CF WHERE CF.CUSTID='" & v_strACCTNO.Replace(".", "") & "'"
    '                    Else
    '                        v_strSQL = "SELECT CF.*, CF.MOBILESMS FAX2, CF.EMAIL EMAIL1 FROM VW_CFMAST_SMS CF, AFMAST AF, " & v_strREFMODCODE & "MAST MST WHERE CF.CUSTID=AF.CUSTID AND AF.ACCTNO=MST.AFACCTNO AND MST.ACCTNO='" & v_strACCTNO.Replace(".", "") & "'"
    '                    End If
    '                    v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_RPTMASTER, _
    '                                                    gc_ActionInquiry, v_strSQL)
    '                    v_ws.Message(v_strObjMsg)
    '                    v_xmlDocument.LoadXml(v_strObjMsg)
    '                    v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
    '                    'Thay thế các trường nội dung liên quan đến thông tin khách hàng
    '                    For i = 0 To v_nodeList.Count - 1
    '                        For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
    '                            With v_nodeList.Item(i).ChildNodes(j)
    '                                v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
    '                                v_strVALUE = .InnerText.ToString
    '                                v_strBODYTEMPLATE = v_strBODYTEMPLATE.Replace("[$" & v_strFLDNAME & "]", v_strVALUE)
    '                                If String.Compare(v_strFLDNAME, "EMAIL1") = 0 Then
    '                                    v_strTOEMAIL = v_strVALUE
    '                                ElseIf String.Compare(v_strFLDNAME, "FAX2") = 0 Then
    '                                    v_strTOSMS = v_strVALUE
    '                                End If
    '                            End With
    '                        Next
    '                    Next

    '                    'GỬI NOTIFICATION
    '                    '=============================================================================================================================================
    '                    If String.Compare(v_strSENDVIA, gc_SEND_VIA_SMS) = 0 Then
    '                        'Gửi qua SMS: Sẽ log vào bảng tin SMS cần gửi. Một tiến trình chạy ngầm sẽ connect với ISP để đẩy tin SMS đi
    '                        v_strNOTIFICATIONSTATUS = "P"   'Đẩy lên HOST để hệ thống tự động chuyển tin nhắn đến khách hàng
    '                        'If v_strTOSMS.Length < 10 Then
    '                        '    Exit For
    '                        'End If
    '                    ElseIf String.Compare(v_strSENDVIA, "E") = 0 Then
    '                        'Gửi qua EMAIL luôn từ Client
    '                        v_strNOTIFICATIONSTATUS = "S"

    '                        '19/08/2015, TruongLD Add
    '                        'PHS yeu cau, khi mail cho khach hang, phai cc cho MG, 
    '                        'Flex dang xu ly trigger, --> TH khach hang ko co email van phai day vao Emaillog
    '                        'If String.IsNullOrEmpty(v_strTOEMAIL) Then
    '                        'Exit For
    '                        'End If
    '                        'End TruongLD

    '                        ''ThongPM comment nho user cua PhuongHT
    '                        ''Xác định mailserver
    '                        'v_strSQL = "SELECT (SELECT VARVALUE FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'SYSMAILSERVER') SYSMAILSERVER " _
    '                        '        & ", (SELECT VARVALUE FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'SYSSIGNATURE') SYSSIGNATURE " _
    '                        '        & ", (SELECT VARVALUE FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'SYSUSEREMAIL') SYSUSEREMAIL " _
    '                        '        & ", (SELECT VARVALUE FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'SYSUERPASS') SYSUERPASS " _
    '                        '        & ", (SELECT VARVALUE FROM SYSVAR WHERE GRNAME = 'SYSTEM' AND VARNAME = 'SYSUERNAME') SYSUERNAME FROM DUAL"
    '                        'v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SA_RPTMASTER, _
    '                        '                                gc_ActionInquiry, v_strSQL)
    '                        'v_ws.Message(v_strObjMsg)
    '                        'v_xmlDocument.LoadXml(v_strObjMsg)
    '                        'v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
    '                        'For i = 0 To v_nodeList.Count - 1
    '                        '    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
    '                        '        With v_nodeList.Item(i).ChildNodes(j)
    '                        '            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
    '                        '            v_strVALUE = .InnerText.ToString
    '                        '            Select Case v_strFLDNAME.Trim()
    '                        '                Case "SYSMAILSERVER"
    '                        '                    v_strMAILSERVER = v_strVALUE.Trim()
    '                        '                Case "SYSUERNAME"
    '                        '                    v_strFRFULLNAME = v_strVALUE.Trim()
    '                        '                    v_strMAILUSER = v_strFRFULLNAME
    '                        '                Case "SYSUERPASS"
    '                        '                    v_strMAILPASS = v_strVALUE.Trim()
    '                        '                Case "SYSUSEREMAIL"
    '                        '                    v_strFREMAIL = v_strVALUE.Trim()    'Default gửi từ sysuser
    '                        '                Case "SYSSIGNATURE"
    '                        '                    v_strSIGNATURE = v_strVALUE.Trim()
    '                        '            End Select
    '                        '        End With
    '                        '    Next
    '                        'Next

    '                        ''Gửi mail
    '                        'Delivery.SendMail(v_strSIGNATURE, v_strFREMAIL, v_strTOEMAIL, v_strHEADER, v_strMAILUSER, v_strMAILPASS, v_strBODYTEMPLATE, v_strMAILSERVER, , v_strHEADER)
    '                    End If

    '                    'Log noi dung gui cho khach hang: TẠO ADDNEW OBJECT SENDMSGLOG
    '                    'TLID, SENDVIA, TOADDR, ACCTNO, MODCODE, MSGTITLE, MSGBODY, STATUS
    '                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, "N", gc_MsgTypeObj, "SA.SENDMSGLOG", gc_ActionAdd, , , , "Y")
    '                    v_xmlDocument.LoadXml(v_strObjMsg)
    '                    v_strXMLBuilder = New StringBuilder
    '                    v_strXMLBuilder.Append("<ObjData>")
    '                    v_strXMLBuilder.Append("<Entry fldname='AUTOID' fldtype='System.String' oldval=''>" & "0" & "</Entry>")
    '                    v_strXMLBuilder.Append("<Entry fldname='TLID' fldtype='System.String' oldval=''>" & Me.TellerId & "</Entry>")
    '                    v_strXMLBuilder.Append("<Entry fldname='SENDVIA' fldtype='System.String' oldval=''>" & v_strSENDVIA & "</Entry>")
    '                    v_strXMLBuilder.Append("<Entry fldname='TOADDR' fldtype='System.String' oldval=''>" & IIf(v_strSENDVIA = "S", v_strTOSMS, v_strTOEMAIL) & "</Entry>")
    '                    v_strXMLBuilder.Append("<Entry fldname='ACCTNO' fldtype='System.String' oldval=''>" & v_strACCTNO & "</Entry>")
    '                    v_strXMLBuilder.Append("<Entry fldname='MODCODE' fldtype='System.String' oldval=''>" & v_strREFMODCODE & "</Entry>")
    '                    v_strXMLBuilder.Append("<Entry fldname='MSGTITLE' fldtype='System.String' oldval=''>" & v_strHEADER & "</Entry>")
    '                    v_strXMLBuilder.Append("<Entry fldname='MSGBODY' fldtype='System.String' oldval=''>" & IIf(v_strTMPTYPE = "T", v_strBODYTEMPLATE.Replace("''", ",").Replace("[BUSDATE]", BusDate), v_strTMPPATH) & "</Entry>")
    '                    v_strXMLBuilder.Append("<Entry fldname='STATUS' fldtype='System.String' oldval=''>" & v_strNOTIFICATIONSTATUS & "</Entry>")
    '                    v_strXMLBuilder.Append("<Entry fldname='TXTIME' fldtype='System.String' oldval=''>" & Format(DateTime.Now, "HH:mm:ss") & "</Entry>")
    '                    v_strXMLBuilder.Append("<Entry fldname='TXDATE' fldtype='System.String' oldval=''>" & Me.BusDate & "</Entry>")
    '                    v_strXMLBuilder.Append("<Entry fldname='SEARCHCODE' fldtype='System.String' oldval=''>" & V_strSEARCHCODE & "</Entry>")
    '                    v_strXMLBuilder.Append("</ObjData>")
    '                    v_xmlBuilder.LoadXml(v_strXMLBuilder.ToString)
    '                    nodeItem = v_xmlDocument.ImportNode(v_xmlBuilder.SelectSingleNode("/ObjData"), True)
    '                    v_xmlDocument.DocumentElement.AppendChild(nodeItem)
    '                    v_strObjMsg = v_xmlDocument.InnerXml
    '                    'Gửi message
    '                    v_lngErrCode = v_ws.Message(v_strObjMsg)
    '                    'Get error description
    '                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrCode, v_strErrorMessage)
    '                    If v_lngErrCode <> ERR_SYSTEM_OK Then
    '                        'Update mouse pointer
    '                        Cursor.Current = Cursors.Default
    '                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
    '                        Exit Sub
    '                    Else
    '                        'Update mouse pointer
    '                        Cursor.Current = Cursors.Default
    '                        'v_strCount = v_strCount + 1
    '                        'MsgBox(Me.Text & ": " & IIf(v_strSENDVIA = gc_SEND_VIA_SMS, "SMS", "EMAIL") & "-" & IIf(v_strSENDVIA = gc_SEND_VIA_SMS, v_strTOSMS, v_strTOEMAIL), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
    '                        'Exit Sub
    '                    End If

    '                    'End If
    '                End If
    '            Next

    '        End If
    '        MsgBox(IIf(v_strSENDVIA = gc_SEND_VIA_SMS, ResourceManager.GetString("frmSearch.SMSSuccess"), ResourceManager.GetString("frmSearch.EmailSuccess")), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
    '        'v_strCount = 0

    '    Catch ex As Exception
    '    Finally
    '        v_ws = Nothing
    '    End Try
    'End Sub

End Class
