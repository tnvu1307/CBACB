Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports CommonLibrary
Imports System.Collections
'Imports Microsoft.Office.Core
'Imports Microsoft.Office.Interop
Imports AppCore
Imports System.IO
Imports AppCore.modCoreLib
Imports System.Xml
Public Class frmSMSEMAIL
    Inherits System.Windows.Forms.Form
    Private m_BusLayer As CBusLayer = Nothing
    Private mv_strObjName As String
    Private mv_strTableName As String = 0
    Private mv_blnApprove As Boolean = False
    Private mv_blnIsImport As Boolean = False
    Private mv_strFILEPATH As String = ""
    Private mv_strSHEETNAME As String = "SHEET1"
    Private mv_strEXTENTION As String = ".xls"
    Private mv_intROWTITLE As String = 0
    Private mv_PhoneList As String = ""

    Private mv_ResourceManager As Resources.ResourceManager
    Private mv_strModuleCode As String
    Private mv_strLanguage As String
    Private mv_strIsLocalSearch As String
    Private mv_strCaption As String
    Private mv_srcFileName As String
    Private mv_strAuthCode As String
    '  Private mv_strMODCODE As String

    Private mv_strBusDate As String
    Private mv_strTellerID As String
    Private mv_strBranchId As String
    Private mv_strIpAddress As String
    'Friend WithEvents txtCAMASTID As AppCore.FlexMaskEditBox
    Private mv_strWsName As String

    Public Property IsImport() As Boolean
        Get
            Return mv_blnIsImport
        End Get
        Set(ByVal Value As Boolean)
            mv_blnIsImport = Value
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

    Public Property BranchId() As String
        Get
            Return mv_strBranchId
        End Get
        Set(ByVal Value As String)
            mv_strBranchId = Value
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

    Public Property TellerID() As String
        Get
            Return mv_strTellerID
        End Get
        Set(ByVal Value As String)
            mv_strTellerID = Value
        End Set
    End Property

    Public Property IsApprove() As Boolean
        Get
            Return mv_blnApprove
        End Get
        Set(ByVal Value As Boolean)
            mv_blnApprove = Value
        End Set
    End Property


    Public Property AuthCode() As String
        Get
            Return mv_strAuthCode
        End Get
        Set(ByVal Value As String)
            mv_strAuthCode = Value
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
    Public ReadOnly Property ObjectName() As String
        Get
            Return mv_strObjName
        End Get
    End Property
    Public ReadOnly Property ResourceManager() As Resources.ResourceManager
        Get
            Return mv_ResourceManager
        End Get
    End Property

    Public Property IsLocalSearch() As String
        Get
            Return mv_strIsLocalSearch
        End Get
        Set(ByVal Value As String)
            mv_strIsLocalSearch = Value
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
    Public Property FormCaption() As String
        Get
            Return mv_strCaption
        End Get
        Set(ByVal Value As String)
            mv_strCaption = Value
        End Set
    End Property

    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mv_strLanguage = pv_strLanguage
        OnInit()
    End Sub

    Public Overridable Sub OnInit()
        Try
            'Khởi tạo kích thước form và load resource
            mv_ResourceManager = New Resources.ResourceManager("_DIRECT.frmSMSEMAIL-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            LoadUserInterface(Me)
            dtpFRMDATE.Value = Now()
            dtpRETURNTRADE.Value = Now()
            dtpTODATE.Value = Now()
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            Dim v_strCmdSQL As String, v_strObjMsg As String

            v_strCmdSQL = "SELECT CDVAL VALUE, CDCONTENT DISPLAY, CDCONTENT EN_DISPLAY, LSTODR FROM ALLCODE WHERE cdname='SENTSMS' and cdtype ='SA'ORDER BY LSTODR"
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerID, gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            FillComboEx(v_strObjMsg, cboTYPESMS, "", Me.UserLanguage)
        Catch ex As Exception

        End Try
    End Sub

    Public Overridable Sub LoadUserInterface(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control

        Try

            For Each v_ctrl In pv_ctrl.Controls
                If TypeOf (v_ctrl) Is Panel Then
                    LoadUserInterface(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is GroupBox Then
                    CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString(v_ctrl.Name)
                    LoadUserInterface(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is Label Then
                    CType(v_ctrl, Label).Text = mv_ResourceManager.GetString(v_ctrl.Name)
                ElseIf TypeOf (v_ctrl) Is Button Then
                    CType(v_ctrl, Button).Text = mv_ResourceManager.GetString(v_ctrl.Name)
                ElseIf TypeOf (v_ctrl) Is CheckBox Then
                    CType(v_ctrl, CheckBox).Text = mv_ResourceManager.GetString(v_ctrl.Name)
                End If
            Next

            'Load caption of form, label caption
            Me.Text = mv_ResourceManager.GetString("frmSMSEMAIL")
            'lblCaption.Text = mv_ResourceManager.GetString("frmChangePassword.lblCaption") & TellerName

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cboTYPESMS_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTYPESMS.SelectedValueChanged
        If cboTYPESMS.SelectedValue.ToString = "006" Then
            txtDESC.Enabled = True
        Else
            txtDESC.Enabled = False
        End If
    End Sub
    Private Sub OnBrowser()
        Try
            Dim v_dlgOpen As New OpenFileDialog
            'v_dlgOpen.Filter = "Open files (*" & mv_strEXTENTION & ")|*" & mv_strEXTENTION & ""
            v_dlgOpen.Filter = "Excel files (*.xlsx)|*.xlsx|Excel files(2003) (*.xls)|*.xls|All files (*.*)|*.*"
            v_dlgOpen.RestoreDirectory = True

            Dim v_res As DialogResult = v_dlgOpen.ShowDialog(Me)
            If v_res = DialogResult.OK Then
                mv_srcFileName = v_dlgOpen.FileName
                Me.txtBROWSER.Text = mv_srcFileName
            End If
        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmReadFile.OnBrowser" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBROWSER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBROWSER.Click
        OnBrowser()
    End Sub

    Private Sub btnSent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSent.Click
        If chkSYSTEMSMS.Checked = True Then
            SmsSystem()
        Else
            If txtBROWSER.Text.ToString = "" Or txtBROWSER.Text.ToString Is Nothing Then
                MessageBox.Show(mv_ResourceManager.GetString("CHOOSEFILEPATH"), Me.Text, MessageBoxButtons.OK)
            Else
                OnReadFile()
            End If
        End If

    End Sub
    Private Sub SmsSystem()
        Dim v_strFunctionName As String = "SMSSYSTEM"
        Dim v_strClause, v_strErrorSource, v_strErrorMessage As String
        Dim v_strSQL, v_strObjMsg, v_strValue As String
        Dim v_frmdate, v_todate, v_returntrading, v_cboTYPESMS As String
        Dim v_ws As New BDSDeliveryManagement

        v_frmdate = dtpFRMDATE.Value.ToString("dd/MM/yyyy")
        v_todate = dtpTODATE.Value.ToString("dd/MM/yyyy")
        v_returntrading = dtpRETURNTRADE.Value.ToString("dd/MM/yyyy")
        v_cboTYPESMS = cboTYPESMS.SelectedValue.ToString()
        Dim v_SMSCUSTOM = txtDESC.Text.ToString

        v_strClause = mv_PhoneList.ToString
        v_strObjMsg = BuildXMLObjMsg(, , , Me.TellerID, gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.SENTSMS", _
                gc_ActionAdhoc, , v_strClause, v_strFunctionName, v_frmdate, v_todate, v_returntrading, v_cboTYPESMS, v_SMSCUSTOM)
        Dim v_lngError As Long = v_ws.Message(v_strObjMsg)
        If v_lngError <> ERR_SYSTEM_OK Then
            'Thông báo lỗi
            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage)
            Cursor.Current = Cursors.Default
            'MessageBox.Show(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text, MessageBoxIcon.Error)
            MessageBox.Show(v_strErrorMessage, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            MessageBox.Show(mv_ResourceManager.GetString("SMSSUCCESS"), Me.Text, MessageBoxButtons.OK)
        End If

    End Sub
    Private Sub OnReadFile()

        Dim v_strFunctionName As String = "SENTSMS"
        Dim v_strClause, v_strErrorSource, v_strErrorMessage As String
        Dim v_strSQL, v_strObjMsg, v_strValue As String
        Dim v_frmdate, v_todate, v_returntrading, v_cboTYPESMS As String
        Dim v_ws As New BDSDeliveryManagement

        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim range As Excel.Range
        Dim rCnt As Integer
        Dim cCnt As Integer
        Dim Obj As Object
        Dim v_xColumn As Xceed.Grid.Column
        'Chuyen doi cau hinh User Account Windows theo cau hinh cua Office
        Dim oldCI As Globalization.CultureInfo
        oldCI = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Open(mv_srcFileName)

        If xlWorkBook Is Nothing Then
            MessageBox.Show("Đường dẫn không hợp lệ, vui lòng chọn lại đường dẫn!")
            Me.ActiveControl = Me.btnBROWSER
            Exit Sub
        End If

        xlWorkSheet = xlWorkBook.Worksheets(CInt(1))
        'If range.Columns.Count > 0 And range.Rows.Count > 1 Then
        '    For cCnt = 1 To range.Columns.Count
        '        If Not CType(range.Cells(mv_intROWTITLE, cCnt), Excel.Range).Value Is Nothing Then
        '            SearchGrid.Columns.Add(New Xceed.Grid.Column(cCnt.ToString, GetType(System.String)))
        '            SearchGrid.Columns(cCnt.ToString).Title = gf_CorrectStringField(CType(range.Cells(mv_intROWTITLE, cCnt), Excel.Range).Value).Trim
        '            SearchGrid.Columns(cCnt.ToString).HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
        '            SearchGrid.Columns(cCnt.ToString).Width = 100
        '        End If
        '    Next
        'End If
        range = xlWorkSheet.UsedRange
        mv_PhoneList = ""
        If range.Rows.Count >= mv_intROWTITLE + 1 Then
            For rCnt = mv_intROWTITLE + 1 To range.Rows.Count

                mv_PhoneList = mv_PhoneList & gf_CorrectStringField(CType(range.Cells(rCnt, 1), Excel.Range).Value) & ";"

            Next

        End If

        xlWorkBook.Close()
        xlApp.Quit()

        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)

        v_frmdate = dtpFRMDATE.Value.ToString("dd/MM/yyyy")
        v_todate = dtpTODATE.Value.ToString("dd/MM/yyyy")
        v_returntrading = dtpRETURNTRADE.Value.ToString("dd/MM/yyyy")
        v_cboTYPESMS = cboTYPESMS.SelectedValue.ToString()
        Dim v_SMSCUSTOM = txtDESC.Text.ToString

        v_strClause = mv_PhoneList.ToString
        v_strObjMsg = BuildXMLObjMsg(, , , Me.TellerID, gc_IsNotLocalMsg, gc_MsgTypeObj, "SA.SENTSMS", _
                gc_ActionAdhoc, , v_strClause, v_strFunctionName, v_frmdate, v_todate, v_returntrading, v_cboTYPESMS, v_SMSCUSTOM)
        Dim v_lngError As Long = v_ws.Message(v_strObjMsg)
        If v_lngError <> ERR_SYSTEM_OK Then
            'Thông báo lỗi
            GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage)
            Cursor.Current = Cursors.Default
            'MessageBox.Show(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text, MessageBoxIcon.Error)
            MessageBox.Show(v_strErrorMessage, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            MessageBox.Show(mv_ResourceManager.GetString("SMSSUCCESS"), Me.Text, MessageBoxButtons.OK)
        End If

    End Sub
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

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        OnClose()
    End Sub
    Private Sub OnClose()
        Me.Dispose()
    End Sub

    Private Sub chkSYSTEMSMS_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSYSTEMSMS.CheckedChanged
        If chkSYSTEMSMS.Checked = True Then
            btnBROWSER.Enabled = False
        Else
            btnBROWSER.Enabled = True
        End If
    End Sub
End Class