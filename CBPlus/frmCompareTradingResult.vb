Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports System.IO
Imports CommonLibrary
Imports System.Collections
'Imports Microsoft.Office.Core
'Imports Microsoft.Office.Interop.Excel
'Imports Microsoft.Office.Interop
Imports AppCore
Imports AppCore.modCoreLib
Imports System.Reflection
Imports System.Text
Imports Microsoft.VisualBasic
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO.Path
Imports System.Windows.Forms.Application

Public Class frmCompareTradingResult
    Inherits System.Windows.Forms.Form

    Private mv_srcFileName As String
    Private mv_strObjName As String
    Private mv_strFileCode As String
    Private mv_strClause As String
    Private SearchGrid As GridEx
    Private ResultGrid As GridEx
    Private mv_strFILEPATH As String = ""
    Private mv_strSHEETNAME As String = "SHEET1"
    Private mv_strEXTENTION As String = ".xls"
    Private mv_strHOSEEXTENTION As String = ".txt"
    Private mv_strFileTypeHO As String = ""
    Private mv_intROWTITLE As String = 1
    Private mv_intPAGE As String = 0
    Private mv_strTableName As String = 0

    Public Enum HNXTRADINGRESULT
        AUTOID = 1
        TRADING_DATE = 2
        SYMBOL = 3
        PRICE = 4
        QTTY = 5
        MATCHAMOUNT = 6
        MATCHTIME = 7
        SELLACCOUNT = 8
        BUYACCOUNT = 9
    End Enum

#Region "Property"

    Const c_ResourceManager = gc_RootNamespace & ".frmCompareTradingResult-"

    Private mv_strLanguage As String
    Private mv_ResourceManager As Resources.ResourceManager

    'Private mv_strFileName As String
    Private mv_strSaveTableName As String
    Private mv_strModuleCode As String
    Private mv_strIsLocalSearch As String
    Private mv_strCaption As String
    Private mv_strEnCaption As String
    Private mv_strAuthCode As String

    Private mv_strBusDate As String
    Public Property BusDate() As String
        Get
            Return mv_strBusDate
        End Get
        Set(ByVal Value As String)
            mv_strBusDate = Value

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
#End Region

#Region "Các cấu trúc file do HoSE gui ve"

    '�?�ịnh nghĩa cấu trúc file kết quả khớp lệnh cũ
    Structure file_ASTDL
        <VBFixedString(6)> Dim deal_confirm_no As String    'Right justified
        <VBFixedString(8)> Dim buyer_order_no As String     'Right justified
        <VBFixedString(10)> Dim buyer_order_date As String  ''DD/MM/YYYY'
        <VBFixedString(8)> Dim seller_order_no As String    'Right justified
        <VBFixedString(10)> Dim seller_order_date As String ''DD/MM/YYYY'
        <VBFixedString(6)> Dim next_deal_buyer As String    'Right justified
        <VBFixedString(6)> Dim next_deal_seller As String   'Right justified
        <VBFixedString(8)> Dim deal_time As String          ''HHMMSSSS'
        <VBFixedString(10)> Dim deal_date As String         ''DD/MM/YYYY'
        <VBFixedString(4)> Dim buyer_trader_id As String    'Right justified
        <VBFixedString(4)> Dim seller_trader_id As String   'Right justified
        <VBFixedString(1)> Dim buyer_PCFLag As String
        <VBFixedString(1)> Dim seller_PCFLag As String
        <VBFixedString(3)> Dim buyer_firmno As String       'Leading with "0"       
        <VBFixedString(3)> Dim seller_firmno As String      'Leading with "0"       
        <VBFixedString(1)> Dim trading_board As String
        <VBFixedString(2)> Dim deal_status As String        'Left justified
        <VBFixedString(8)> Dim scrip_symbol As String       'Left justified
        <VBFixedString(8)> Dim deal_volume As String        'Right justified
        <VBFixedString(9)> Dim deal_price As String         'Right justified 6.2
        <VBFixedString(10)> Dim buyer_customerid As String  'Left justified
        <VBFixedString(10)> Dim seller_customerid As String 'Left justified
        <VBFixedString(8)> Dim filler1 As String            '
        <VBFixedString(8)> Dim buyer_ordertime As String    ''HHMMSSSS'
        <VBFixedString(8)> Dim seller_ordertime As String   ''HHMMSSSS'
        <VBFixedString(6)> Dim filler2 As String            'Blank value
    End Structure

    Structure file_ASTPT
        <VBFixedString(6)> Dim deal_confirm_no As String    'Right justified
        <VBFixedString(8)> Dim deal_time As String     'Right justified
        <VBFixedString(10)> Dim deal_date As String  ''DD/MM/YYYY'
        <VBFixedString(4)> Dim buyer_trader_id As String    'Right justified
        <VBFixedString(4)> Dim seller_trader_id As String ''DD/MM/YYYY'
        <VBFixedString(3)> Dim buyer_firm_no As String    'Right justified
        <VBFixedString(3)> Dim seller_firm_no As String   'Right justified
        <VBFixedString(1)> Dim board As String          ''HHMMSSSS'
        <VBFixedString(2)> Dim deal_status As String         ''DD/MM/YYYY'
        <VBFixedString(8)> Dim deal_security_symbol As String    'Right justified
        <VBFixedString(13)> Dim deal_price As String   'Right justified
        <VBFixedString(10)> Dim buyer_customer_id As String
        <VBFixedString(10)> Dim seller_customer_id As String
        <VBFixedString(5)> Dim deal_id As String       'Leading with "0"       
        <VBFixedString(8)> Dim filler1 As String      'Leading with "0"       
        <VBFixedString(8)> Dim buyer_brk_portfolio_vol As String
        <VBFixedString(8)> Dim buyer_brk_customer_vol As String        'Left justified
        <VBFixedString(8)> Dim buyer_brk_mutual_fund_vol As String       'Left justified
        <VBFixedString(8)> Dim buyer_brk_foreign_vol As String        'Right justified
        <VBFixedString(32)> Dim filler2 As String         'Right justified 6.2
        <VBFixedString(8)> Dim seller_brk_portfolio_vol As String
        <VBFixedString(8)> Dim seller_brk_customer_vol As String        'Left justified
        <VBFixedString(8)> Dim seller_brk_mutual_fund_vol As String       'Left justified
        <VBFixedString(8)> Dim seller_brk_foreign_vol As String        'Right justified
        <VBFixedString(40)> Dim filler3 As String  'Left justified
        <VBFixedString(8)> Dim buyer_approved_time As String 'Left justified
        <VBFixedString(22)> Dim filler4 As String            '

    End Structure

#End Region

#Region "Build SQL Insert command"
    Public Function GenerateInsertSQL(ByVal obj) As String
        'LogImpl.Write(obj.GetType.Name, LogEntryType.Information)
        Dim sb As New StringBuilder(), sbfields As New StringBuilder(), sbvalues As New StringBuilder()
        'Loop for each column
        Dim parmcount As Integer = 0
        For Each attr As FieldInfo In obj.GetType.GetFields()
            'LogImpl.Write(attr.Name, LogEntryType.Information)
            'LogImpl.Write(attr.GetValue(obj), LogEntryType.Information)
            'LogImpl.Write(attr.FieldType.Name, LogEntryType.Information)
            'LogImpl.Write(obj.GetType.GetProperty(attr.Name, BindingFlags.IgnoreCase).GetValue(, LogEntryType.Information)
            sbfields.Append(attr.Name).Append(",")
            Select Case attr.FieldType.Name
                Case "Int32", "Int16", "Double"
                    sbvalues.Append("" & IIf(attr.GetValue(obj) Is Nothing, "NULL", attr.GetValue(obj)) & ",")
                Case "String"
                    sbvalues.Append("'" & Convert.ToString(IIf(attr.GetValue(obj) Is Nothing, "NULL", attr.GetValue(obj))).Trim & "',")
                Case Else
            End Select
        Next
        sb.Append("INSERT INTO ")
        sb.Append(obj.GetType.Name)
        sb.Append(" (")
        sb.Append(sbfields.ToString(0, sbfields.Length - 1))
        sb.Append(") VALUES (")
        sb.Append(sbvalues.ToString(0, sbvalues.Length - 1))
        sb.Append(")")
        LogImpl.Write(sb.ToString(), LogEntryType.Information)
        'nghiemnt commment
        'GenerateDDLSQL(obj)
        Return sb.ToString()
    End Function

#End Region

#Region "Private Function"

    Private Sub OnBrowser(ByVal mv_strEXTENTION As String)
        Try
            Dim v_dlgOpen As New OpenFileDialog
            v_dlgOpen.Filter = "Open files (*" & mv_strEXTENTION & ")|*" & mv_strEXTENTION & ""
            v_dlgOpen.RestoreDirectory = True

            Dim v_res As DialogResult = v_dlgOpen.ShowDialog(Me)
            If v_res = DialogResult.OK Then
                mv_srcFileName = v_dlgOpen.FileName
                If (mv_strEXTENTION = ".xls") Then
                    If (mv_strFileCode = "IHNX") Then
                        Me.txtPath.Text = mv_srcFileName
                    ElseIf (mv_strFileCode = "UPCOM") Then
                        Me.txtPathUP.Text = mv_srcFileName
                    End If

                ElseIf mv_strEXTENTION = ".txt" Then
                    Me.txtPathHOSE.Text = mv_srcFileName
                End If

            End If
        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmReadFile.OnBrowser" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub OnInit()
        Try
            'Me.btnExport.Text = "Kết xuất ra Excel"
            'Me.txtPath.Text = ""
            'Me.GroupBox1.Text = "Kết quả"
            'Me.GroupBox2.Text = "Kết quả"
            'Me.GroupBoxupcom.Text = "Kết quả"
            'Me.TabTradingHNX.Tag = "IHNX"
            'Me.TabTradingHOSE.Tag = "IHOSE"
            'Me.TabTradingUPCOM.Tag = "UPCOM"
            'Me.btnCompare.Text = "So sánh"
            'Me.btnReadFile.Text = "Đọc dữ liệu"
            'Me.btnCompareHO.Text = " So sánh"
            'Me.btnReadFileHO.Text = "Đọc dữ liệu"
            'Me.btnReadFileUp.Text = "Đọc dữ liệu"
            'Me.btnCompareUP.Text = "So sánh "
            'Me.btnCompare.Enabled = False
            'Me.btnCompareHO.Enabled = False
           
            mv_ResourceManager = New Resources.ResourceManager("_DIRECT.frmCompareTradingResult-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            LoadUserInterface(Me)
            DisplayOption()
            
            mv_strFileTypeHO = "HO:LO"
            Me.SuspendLayout()
            SearchGrid = New GridEx
            mv_strFileCode = Me.TabControlTrading.SelectedTab.Text
            GetFileInfo(mv_strFileCode)
            TabControlTrading.TabPages.Remove(TabTradingUPCOM)

        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmCompareTradingResult.OnBrowser" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub DisplayOption()
        Me.btnCompare.Enabled = False
        Me.btnCompareHO.Enabled = False
        If mv_strLanguage = "VN" Then
            Me.CboxTypeFile.Items.Insert(0, "Lệnh thường")
            Me.CboxTypeFile.Items.Insert(1, "Lệnh thỏa thuận")
            Me.CboxTypeFile.SelectedIndex = 0
        Else
            Me.CboxTypeFile.Items.Insert(0, "Normal")
            Me.CboxTypeFile.Items.Insert(1, "Put Through")
            Me.CboxTypeFile.SelectedIndex = 0
        End If

    End Sub
    Private Sub LoadUserInterface(ByRef pv_ctrl As System.Windows.Forms.Control)
        Dim v_ctrl As System.Windows.Forms.Control

        Try

            For Each v_ctrl In pv_ctrl.Controls
                If TypeOf (v_ctrl) Is Panel Then
                    LoadUserInterface(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is TabControl Then
                    LoadUserInterface(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is System.Windows.Forms.GroupBox Then
                    CType(v_ctrl, System.Windows.Forms.GroupBox).Text = mv_ResourceManager.GetString("frmCompareTradingResult." & v_ctrl.Name)
                    LoadUserInterface(v_ctrl)
                ElseIf TypeOf (v_ctrl) Is System.Windows.Forms.Label Then
                    CType(v_ctrl, System.Windows.Forms.Label).Text = mv_ResourceManager.GetString("frmCompareTradingResult." & v_ctrl.Name)
                ElseIf TypeOf (v_ctrl) Is System.Windows.Forms.Button Then
                    CType(v_ctrl, System.Windows.Forms.Button).Text = mv_ResourceManager.GetString("frmCompareTradingResult." & v_ctrl.Name)
                ElseIf TypeOf (v_ctrl) Is System.Windows.Forms.CheckBox Then
                    CType(v_ctrl, System.Windows.Forms.CheckBox).Text = mv_ResourceManager.GetString("frmCompareTradingResult." & v_ctrl.Name)
                End If
            Next

            'Load caption of form, label caption
            Me.Text = mv_ResourceManager.GetString("frmCompareTradingResult")
            Me.TabTradingHNX.Text = mv_ResourceManager.GetString("IHNX")
            Me.TabTradingHOSE.Text = mv_ResourceManager.GetString("IHOSE")
            Me.TabTradingUPCOM.Text = mv_ResourceManager.GetString("UPCOM")

        Catch ex As Exception
            Throw ex
        End Try
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

    Private Sub GetFileInfo(ByVal pv_strFile As String)
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_xmlDocument As New Xml.XmlDocument
        Dim v_strValue, v_strFLDNAME, v_strTEXT As String
        Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
        Dim v_strCmdSQL As String, v_strObjMsg As String
        Try
            v_strCmdSQL = "SELECT * FROM filemaster WHERE filecode='" & pv_strFile & "'"
            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SA_LOOKUP, gc_ActionInquiry, v_strCmdSQL)
            v_ws.Message(v_strObjMsg)
            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            For i As Integer = 0 To v_nodeList.Count - 1
                v_strTEXT = String.Empty
                For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                    With v_nodeList.Item(i).ChildNodes(j)
                        v_strValue = Trim(.InnerText.ToString)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        Select Case Trim(v_strFLDNAME)
                            Case "FILEPATH"
                                mv_strFILEPATH = v_strValue
                                Me.txtPath.Text = v_strValue
                            Case "SHEETNAME"
                                mv_strSHEETNAME = v_strValue
                            Case "ROWTITLE"
                                mv_intROWTITLE = CInt(v_strValue)
                            Case "EXTENTION"
                                mv_strEXTENTION = v_strValue
                            Case "PAGE"
                                mv_intPAGE = CInt(v_strValue)
                            Case "TABLENAME"
                                mv_strSaveTableName = v_strValue
                        End Select
                    End With
                Next
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function OnLoadData(ByVal v_strcode As String) As Boolean
        Try

            If v_strcode = "IHNX" Then
                If Me.txtPath.Text.Trim.Length = 0 Then
                    MessageBox.Show("Vui lòng chọn đường dẫn đến file.xsl cần đọc!")
                    Me.ActiveControl = Me.Button2
                    Return False
                End If
            ElseIf v_strcode = "UPCOM" Then
                If Me.txtPathUP.Text.Trim.Length = 0 Then
                    MessageBox.Show("Vui lòng chọn đường dẫn đến file.xsl cần đọc!")
                    Me.ActiveControl = Me.Button2
                    Return False
                End If
            End If

            If v_strcode = "IHNX" Then
                Me.btnReadFile.Enabled = False
            ElseIf v_strcode = "UPCOM" Then
                Me.btnReadFileUp.Enabled = False
            End If

            SearchGrid = New GridEx
            Dim v_cmrContactsHeader As New Xceed.Grid.ColumnManagerRow
            v_cmrContactsHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            v_cmrContactsHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            SearchGrid.FixedHeaderRows.Add(v_cmrContactsHeader)

            Dim xlApp As Excel.Application
            Dim xlWorkBook As Excel.Workbook
            Dim xlWorkSheet As Excel.Worksheet
            Dim range As Excel.Range
            Dim rCnt As Integer
            Dim cCnt As Integer
            Dim cCntType As Integer
            Dim Obj As Object
            Dim v_xColumn As Xceed.Grid.Column
            xlApp = New Excel.Application
            xlWorkBook = xlApp.Workbooks.Open(mv_srcFileName)
            If xlWorkBook Is Nothing Then
                MessageBox.Show("Đường dẫn không hợp lệ, vui lòng chọn lại đường dẫn!")
                Me.ActiveControl = Me.Button2
                Return False
                'Exit Function
            End If
            'xlWorkSheet = xlWorkBook.Worksheets(mv_strSHEETNAME)
            xlWorkSheet = xlWorkBook.Worksheets(CInt(mv_strSHEETNAME))

            range = xlWorkSheet.UsedRange
            If range.Columns.Count > 0 And range.Rows.Count > 1 Then
                If (v_strcode = "IHNX") Then
                    cCntType = mv_intROWTITLE + 1
                Else : cCntType = mv_intROWTITLE
                End If
                For cCnt = 1 To range.Columns.Count
                    SearchGrid.Columns.Add(New Xceed.Grid.Column(cCnt.ToString, GetType(System.String)))
                    SearchGrid.Columns(cCnt.ToString).Title = gf_CorrectStringField(CType(range.Cells(cCntType, cCnt), Excel.Range).Value)
                    SearchGrid.Columns(cCnt.ToString).HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
                    SearchGrid.Columns(cCnt.ToString).Width = 100
                Next
            End If
            SearchGrid.DataRows.Clear()
            SearchGrid.BeginInit()

            If range.Rows.Count >= mv_intROWTITLE + 1 Then
                If (v_strcode = "IHNX") Then
                    rCnt = mv_intROWTITLE + 2
                Else : rCnt = mv_intROWTITLE + 1
                End If
                For rCnt = mv_intROWTITLE + 2 To range.Rows.Count
                    Dim v_xDataRow As Xceed.Grid.DataRow = SearchGrid.DataRows.AddNew()
                    For Each v_xColumn In SearchGrid.Columns
                        v_xDataRow.Cells(v_xColumn.FieldName).Value = gf_CorrectStringField(CType(range.Cells(rCnt, CInt(v_xColumn.FieldName)), Excel.Range).Value)
                    Next
                    v_xDataRow.EndEdit()
                Next

            End If

            Dim v_frSearchGrid = New Xceed.Grid.TextRow("Dữ liệu nhận từ file " & range.Rows.Count - mv_intROWTITLE & " dòng!")
            v_frSearchGrid.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            v_frSearchGrid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic)
            SearchGrid.FixedFooterRows.Clear()
            SearchGrid.FixedFooterRows.Add(v_frSearchGrid)


            SearchGrid.EndInit()
            xlWorkBook.Close()
            xlApp.Quit()

            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)

            If (v_strcode = "IHNX") Then

                Me.PnResultLoadHNX.Controls.Clear()
                Me.PnResultLoadHNX.Controls.Add(SearchGrid)
                SearchGrid.Dock = System.Windows.Forms.DockStyle.Fill
                Me.btnCompare.Enabled = True
            Else
                Me.PnUpcom.Controls.Clear()
                Me.PnUpcom.Controls.Add(SearchGrid)
                SearchGrid.Dock = System.Windows.Forms.DockStyle.Fill
                Me.btnCompareUP.Enabled = True
            End If

            Return True


        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmCompareTradingResult.OnLoadData" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End Try
    End Function

    Private Function OnLoadDataASTDL(ByVal v_strFileCode As String) As Boolean
        Try
            If Me.txtPathHOSE.Text.Trim.Length = 0 Then
                MessageBox.Show("Vui lòng chọn đường dẫn đến file.txt cần đọc!")
                Me.ActiveControl = Me.Button2
                Return False
                'Exit Function
            End If
            Me.btnReadFileHO.Enabled = False
            SearchGrid = New GridEx
            Dim v_cmrContactsHeader As New Xceed.Grid.ColumnManagerRow
            v_cmrContactsHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
            v_cmrContactsHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            SearchGrid.FixedHeaderRows.Add(v_cmrContactsHeader)

            Dim v_strtype = v_strFileCode.Split(":")
            If (v_strtype(1) = "LO") Then
                Dim v_strCMDSQL As String
                Dim v_strTotalCmdSql As New StringBuilder
                Dim fileStream As Integer
                Dim newRecord As Integer = 0
                Dim i As Long

                fileStream = FreeFile()
                Dim objFile As New file_ASTDL
                'FileOpen(fileStream, txtPathHOSE.Text, OpenMode.Random, , , Len(objFile))
                FileOpen(fileStream, txtPathHOSE.Text, OpenMode.Random, OpenAccess.Read, OpenShare.Shared, Len(objFile))
                newRecord = LOF(fileStream) / Len(objFile)
                For i = 1 To newRecord 'LOF(fileStream) / Len(objFile)
                    FileGet(fileStream, objFile, i)
                    v_strCMDSQL = GenerateInsertSQL(objFile)
                    v_strTotalCmdSql.Append("" & v_strCMDSQL & "|")
                Next
                Dim v_strFunctionName As String = "ImportXMLFileASTDL"
                Dim v_strClause, v_strErrorSource, v_strErrorMessage As String
                mv_strObjName = "SA.READFILE"
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                Dim v_strSQL, v_strObjMsg, v_strValue As String
                v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, mv_strObjName, _
                        gc_ActionAdhoc, , v_strTotalCmdSql.ToString, v_strFunctionName, , , v_strFileCode, )
                Dim v_lngError As Long = v_ws.Message(v_strObjMsg)

                If v_lngError <> ERR_SYSTEM_OK Then
                    MessageBox.Show(" Lỗi ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

                Else
                    MessageBox.Show("Ghi dữ liệu thành công.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.btnCompareHO.Enabled = True
                End If
                Me.btnReadFileHO.Enabled = True
            Else
                Dim v_strCMDSQL As String
                Dim v_strTotalCmdSql As New StringBuilder
                Dim fileStream As Integer
                Dim newRecord As Integer = 0
                Dim i As Long

                fileStream = FreeFile()
                Dim objFile As New file_ASTPT
                'FileOpen(fileStream, txtPathHOSE.Text, OpenMode.Random, , , Len(objFile))
                FileOpen(fileStream, txtPathHOSE.Text, OpenMode.Random, OpenAccess.Read, OpenShare.Shared, Len(objFile))
                newRecord = LOF(fileStream) / Len(objFile)
                For i = 1 To newRecord 'LOF(fileStream) / Len(objFile)
                    FileGet(fileStream, objFile, i)
                    v_strCMDSQL = GenerateInsertSQL(objFile)
                    v_strTotalCmdSql.Append("" & v_strCMDSQL & "|")
                Next
                Dim v_strFunctionName As String = "ImportXMLFileASTDL"
                Dim v_strClause, v_strErrorSource, v_strErrorMessage As String
                mv_strObjName = "SA.READFILE"
                Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
                Dim v_strSQL, v_strObjMsg, v_strValue As String
                v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, mv_strObjName, _
                        gc_ActionAdhoc, , v_strTotalCmdSql.ToString, v_strFunctionName, , , v_strFileCode, )
                Dim v_lngError As Long = v_ws.Message(v_strObjMsg)

                If v_lngError <> ERR_SYSTEM_OK Then
                    MessageBox.Show(" Lỗi ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

                Else
                    MessageBox.Show("Ghi dữ liệu thành công.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.btnCompareHO.Enabled = True
                End If

                Me.btnReadFileHO.Enabled = True

            End If
            Me.PnResultLoadHNX.Controls.Clear()
            'Me.PnResultLoadHNX.Controls.Add(SearchGrid)
            SearchGrid.Dock = System.Windows.Forms.DockStyle.Fill
            Return True

        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmCompareTradingResult.OnLoadData" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show(ex.Message, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End Try
    End Function


    Private Sub OnSave(ByVal v_strfilecode As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim v_strFunctionName As String = "ImportXMLFileToDBTradingResult"
            Dim v_strClause, v_strErrorSource, v_strErrorMessage As String
            mv_strObjName = "SA.READFILE"
            'mv_strFileCode = mv_strFileCode
            'If (MessageBox.Show("Bạn có muốn ghi dữ liệu bây giờ?", gc_ApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            'TruongLD Comment when convert
            'v_ws.Timeout = gc_WEB_SERVICE_TIMEOUT
            Dim v_strSQL, v_strObjMsg, v_strValue As String
            Dim v_strBuffer As New System.Text.StringBuilder
            'Gan title
            For Each v_xColumn As Xceed.Grid.Column In SearchGrid.Columns
                If Not CType(v_xColumn, Xceed.Grid.Column).Title Is DBNull.Value Then
                    v_strValue = CType(v_xColumn, Xceed.Grid.Column).Title
                Else
                    v_strValue = ""
                End If
                v_strBuffer.Append("" & v_strValue & "~")
            Next
            v_strBuffer.Append("|")
            'Gan noi dung
            For i As Integer = 0 To SearchGrid.DataRows.Count - 1
                With SearchGrid.DataRows(i)
                    For Each v_xColumn As Xceed.Grid.Column In SearchGrid.Columns

                        If Not .Cells(v_xColumn.FieldName).Value() Is DBNull.Value Then
                            v_strValue = CStr(.Cells(v_xColumn.FieldName).Value)
                        Else
                            v_strValue = ""
                        End If
                        v_strBuffer.Append("" & v_strValue & "~")
                    Next
                    v_strBuffer.Append("|")
                End With
            Next
            v_strClause = v_strBuffer.ToString
            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, mv_strObjName, _
                    gc_ActionAdhoc, , v_strClause, v_strFunctionName, , , v_strfilecode, )
            Dim v_lngError As Long = v_ws.Message(v_strObjMsg)
            'TruongLD Comment when convert
            'v_ws.Dispose()
            If v_lngError <> ERR_SYSTEM_OK Then
                'Thông báo lỗi
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                Cursor.Current = Cursors.Default
                'MessageBox.Show(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text, MessageBoxIcon.Error)
                MessageBox.Show(v_strErrorMessage, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            Dim pv_xmlDocument As New Xml.XmlDocument
            pv_xmlDocument.LoadXml(v_strObjMsg)
            Dim v_strFeedBackMessage As String = pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value
            pv_xmlDocument = Nothing
            Cursor.Current = Cursors.Default
            'check error here

            If v_strFeedBackMessage.Trim.Length = 0 Then
                MessageBox.Show("Ghi dữ liệu thành công", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.btnCompare.Enabled = True
            Else
                MessageBox.Show("Ghi dữ liệu thành công" & ControlChars.CrLf & v_strFeedBackMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            'enable button
            If v_strfilecode = "IHNX" Then
                Me.btnReadFile.Enabled = True
            ElseIf v_strfilecode = "UPCOM" Then
                Me.btnReadFileUp.Enabled = True
            End If
        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmCompareTradingResults.OnSave" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show("File dư liệu đầu vào không hợp lệ!!", gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub OnSaveToDB(ByVal v_strfilecode As String)
        Dim v_strFunctionName As String = "ImportXMLFileToDBTradingResult"
        Dim v_strErrorSource, v_strErrorMessage As String
        Dim v_strSQL, v_strObjMsg, v_strValue As String
        Dim v_strBuffer, v_strBufferTemp As New System.Text.StringBuilder
        Dim v_ws As New BDSDeliveryManagement
        mv_strObjName = "SA.READFILE"

        Dim v_frm As New frmProcessing

        'Show processing message
        If UserLanguage Is Nothing Then
            v_frm.UserLanguage = gc_LANG_VIETNAMESE
        Else
            v_frm.UserLanguage = UserLanguage
        End If

        v_frm.ProcessType = ProcessType.Processing
        v_frm.InitDialog()
        v_frm.Show()
        'End of show processing message

        Try
            If v_strfilecode = "IHNX" Then
                If Me.txtPath.Text.Trim.Length = 0 Then
                    MessageBox.Show("Vui lòng chọn đường dẫn đến file.xsl cần đọc!")
                    Me.ActiveControl = Me.Button2
                    v_frm.Close()
                End If
            ElseIf v_strfilecode = "UPCOM" Then
                If Me.txtPathUP.Text.Trim.Length = 0 Then
                    MessageBox.Show("Vui lòng chọn đường dẫn đến file.xsl cần đọc!")
                    Me.ActiveControl = Me.Button2
                    v_frm.Close()
                End If
            End If

            If v_strfilecode = "IHNX" Then
                Me.btnReadFile.Enabled = False
            ElseIf v_strfilecode = "UPCOM" Then
                Me.btnReadFileUp.Enabled = False
            End If

            Dim xlApp As Excel.Application
            Dim xlWorkBook As Excel.Workbook
            Dim xlWorkSheet As Excel.Worksheet
            Dim range As Excel.Range
            Dim rCnt As Integer
            Dim cCnt As Integer
            Dim cCntType As Integer
            Dim Obj As Object
            Dim v_xColumn As Xceed.Grid.Column
            xlApp = New Excel.Application
            xlWorkBook = xlApp.Workbooks.Open(mv_srcFileName)
            If xlWorkBook Is Nothing Then
                MessageBox.Show("Đường dẫn không hợp lệ, vui lòng chọn lại đường dẫn!")
                Me.ActiveControl = Me.Button2
                v_frm.Close()
                Exit Sub
            End If
            xlWorkSheet = xlWorkBook.Worksheets(CInt(mv_strSHEETNAME))

            range = xlWorkSheet.UsedRange
            'Set value for name
            If range.Columns.Count > 0 And range.Rows.Count > 1 Then
                If (v_strfilecode = "IHNX") Then
                    cCntType = mv_intROWTITLE + 1
                Else : cCntType = mv_intROWTITLE
                End If
                For cCnt = 1 To range.Columns.Count
                    If Not gf_CorrectStringField(CType(range.Cells(cCntType, cCnt), Excel.Range).Value) Is Nothing Then
                        Select Case cCnt
                            Case hnxtradingresult.AUTOID
                                v_strValue = "AUTOID"
                            Case hnxtradingresult.BUYACCOUNT
                                v_strValue = "BUYACCOUNT"
                            Case hnxtradingresult.MATCHAMOUNT
                                v_strValue = "MATCHAMOUNT"
                            Case hnxtradingresult.MATCHTIME
                                v_strValue = "MATCHTIME"
                            Case hnxtradingresult.PRICE
                                v_strValue = "PRICE"
                            Case hnxtradingresult.QTTY
                                v_strValue = "QTTY"
                            Case hnxtradingresult.SELLACCOUNT
                                v_strValue = "SELLACCOUNT"
                            Case hnxtradingresult.SYMBOL
                                v_strValue = "SYMBOL"
                            Case hnxtradingresult.TRADING_DATE
                                v_strValue = "TRADING_DATE"
                        End Select
                        v_strBuffer.Append("" & v_strValue & "~")
                    End If
                Next
                v_strBuffer.Append("|")
            End If

            'Set value for field
            If range.Rows.Count >= mv_intROWTITLE + 1 Then
                If (v_strfilecode = "IHNX") Then
                    rCnt = mv_intROWTITLE + 2
                Else : rCnt = mv_intROWTITLE + 1
                End If
                For rCnt = mv_intROWTITLE + 2 To range.Rows.Count

                    For cCnt = 1 To range.Columns.Count

                        If Not gf_CorrectStringField(CType(range.Cells(rCnt, cCnt), Excel.Range).Value) Is Nothing Then

                            v_strValue = gf_CorrectStringField(CType(range.Cells(rCnt, cCnt), Excel.Range).Value)

                            If v_strValue.Length > 0 Then
                                v_strBufferTemp.Append("" & v_strValue & "~")
                            End If

                        Else
                            v_strValue = String.Empty
                            Exit For
                        End If

                    Next

                    If v_strBufferTemp.Length > 0 And Not v_strBufferTemp Is Nothing Then
                        v_strBuffer.Append(v_strBufferTemp.ToString() & "|")
                        v_strBufferTemp.Remove(0, v_strBufferTemp.Length)
                    End If

                Next

            End If

            mv_strClause = v_strBuffer.ToString

            xlWorkBook.Close()
            xlApp.Quit()

            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)

            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, mv_strObjName, _
                    gc_ActionAdhoc, , mv_strClause, v_strFunctionName, , , v_strfilecode, )

            mv_strClause = String.Empty

            Dim v_lngError As Long = v_ws.Message(v_strObjMsg)
            If v_lngError <> ERR_SYSTEM_OK Then
                'Thông báo lỗi
                GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngError, v_strErrorMessage, Me.UserLanguage)
                Cursor.Current = Cursors.Default
                MessageBox.Show(v_strErrorMessage, gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
                v_frm.Close()
            End If
            Dim pv_xmlDocument As New Xml.XmlDocument
            pv_xmlDocument.LoadXml(v_strObjMsg)
            Dim v_strFeedBackMessage As String = pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value
            pv_xmlDocument = Nothing
            Cursor.Current = Cursors.Default

            v_frm.Close()

            If v_strFeedBackMessage.Trim.Length = 0 Then
                MessageBox.Show("Đọc và ghi dữ liệu thành công", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.btnCompare.Enabled = True
            Else
                MessageBox.Show("Đọc và ghi dữ liệu thành công" & ControlChars.CrLf & v_strFeedBackMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            If (v_strfilecode = "IHNX") Then
                Me.btnCompare.Enabled = True
                Me.btnReadFile.Enabled = True
            Else
                Me.btnCompareUP.Enabled = True
                Me.btnReadFileUp.Enabled = True
            End If

        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmCompareTradingResults.OnSaveToDB" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show("File dư liệu đầu vào không hợp lệ!!", gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            mv_strClause = String.Empty
        End Try
    End Sub


    Private Sub OnCompare(ByVal v_strcode As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim v_strFunctionName As String = "CompareDBTradingResult"
            Dim v_strClause, v_strErrorSource, v_strErrorMessage As String
            mv_strObjName = "SA.READFILE"
            'mv_strFileCode = mv_strFileCode
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            'TruongLD Comment when convert
            'v_ws.Timeout = gc_WEB_SERVICE_TIMEOUT
            Dim v_strSQL, v_strObjMsg, v_strValue As String

            v_strClause = String.Empty
            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, mv_strObjName, _
                    gc_ActionAdhoc, , v_strClause, v_strFunctionName, , , v_strcode, )
            Dim v_lngError As Long = v_ws.Message(v_strObjMsg)
            'TruongLD Comment when convert
            'v_ws.Dispose()
            Dim pv_xmlDocument As New Xml.XmlDocument
            pv_xmlDocument.LoadXml(v_strObjMsg)
            Dim v_strFeedBackMessage As String = pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value
            pv_xmlDocument = Nothing
            Cursor.Current = Cursors.Default
            'check error here
            If v_strFeedBackMessage.Trim.Length = 0 Then
                'SearchGrid = New GridEx
                If (SearchGrid.DataRows.Count >= 0) Then
                    SearchGrid.Clear()
                    Me.PnResultLoadHNX.Controls.Clear()
                    Me.PnResultLoadHNX.Controls.Add(SearchGrid)
                End If
                MessageBox.Show("Không có dữ liệu khớp lệnh bị thiếu.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                'MessageBox.Show("Ghi dữ liệu thành công" & ControlChars.CrLf & v_strFeedBackMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                SearchGrid = New GridEx
                Dim v_cmrContactsHeader As New Xceed.Grid.ColumnManagerRow
                v_cmrContactsHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
                v_cmrContactsHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
                SearchGrid.FixedHeaderRows.Add(v_cmrContactsHeader)
                Dim v_strTotalTitle As String = "STT | Ngày giao dịch | Mã CK | Giá khớp | KL khớp |Giá trị khớp | Mua/Bán | Số tài khoản LK | Diễn giải"
                Dim v_xColumn As Xceed.Grid.Column
                Dim v_xcell As Xceed.Grid.Cell
                Dim v_arrData() As String
                Dim v_RowData As String
                Dim v_ChildData() As String
                v_arrData = v_strFeedBackMessage.Split("|")
                For i As Integer = 0 To v_arrData.Count - 1
                    v_RowData = v_arrData(i)
                    v_ChildData = v_RowData.Split(":")
                    Dim v_xDataRow As Xceed.Grid.DataRow = SearchGrid.DataRows.AddNew()
                    Dim v_strTitle() As String = v_strTotalTitle.Split("|")
                    For j As Integer = 0 To v_ChildData.Count - 2
                        If (i = 0) Then
                            SearchGrid.Columns.Add(New Xceed.Grid.Column(j.ToString, GetType(System.String)))
                            SearchGrid.Columns(j.ToString).Title = v_strTitle(j)
                            SearchGrid.Columns(j.ToString).HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
                            SearchGrid.Columns(j.ToString).Width = 100
                        End If
                        v_xDataRow.Cells(j).Value = v_ChildData(j)
                    Next
                    v_xDataRow.EndEdit()
                Next

                Dim v_frSearchGrid = New Xceed.Grid.TextRow("Dữ liệu nhận từ file " & v_arrData.Count - 1 & " dòng!")
                v_frSearchGrid.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
                v_frSearchGrid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic)
                SearchGrid.FixedFooterRows.Clear()
                SearchGrid.FixedFooterRows.Add(v_frSearchGrid)

                If (v_strcode = "IHNX") Then

                    SearchGrid.EndInit()
                    Me.PnResultLoadHNX.Controls.Clear()
                    Me.PnResultLoadHNX.Controls.Add(SearchGrid)
                    SearchGrid.Dock = System.Windows.Forms.DockStyle.Fill
                    MessageBox.Show("Tổng số deal còn thiếu là : " & v_arrData.Count - 1 & ".", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    SearchGrid.EndInit()
                    Me.PnUpcom.Controls.Clear()
                    Me.PnUpcom.Controls.Add(SearchGrid)
                    SearchGrid.Dock = System.Windows.Forms.DockStyle.Fill
                    MessageBox.Show("Tổng số deal còn thiếu là : " & v_arrData.Count - 1 & ".", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If



            End If

        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmCompareTradingResults.OnSave" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show("So sánh dữ liệu không thành công!!", gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub OnCompareHO(ByVal v_strtype As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim v_strFunctionName As String = "CompareDBTradingResult"
            Dim v_strClause, v_strErrorSource, v_strErrorMessage As String
            mv_strObjName = "SA.READFILE"
            'mv_strFileCode = mv_strFileCode
            Dim v_ws As New BDSDeliveryManagement    'BDSDelivery.BDSDelivery
            'TruongLD Comment when convert
            'v_ws.Timeout = gc_WEB_SERVICE_TIMEOUT
            Dim v_strSQL, v_strObjMsg, v_strValue As String

            v_strClause = String.Empty
            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, mv_strObjName, _
                    gc_ActionAdhoc, , v_strClause, v_strFunctionName, , , v_strtype, )
            Dim v_lngError As Long = v_ws.Message(v_strObjMsg)
            'TruongLD Comment when convert
            'v_ws.Dispose()
            Dim pv_xmlDocument As New Xml.XmlDocument
            pv_xmlDocument.LoadXml(v_strObjMsg)
            Dim v_strFeedBackMessage As String = pv_xmlDocument.DocumentElement.Attributes.GetNamedItem(gc_AtributeRESERVER).Value
            pv_xmlDocument = Nothing
            Cursor.Current = Cursors.Default
            'check error here
            If v_strFeedBackMessage.Trim.Length = 0 Then
                'SearchGrid = New GridEx
                If (SearchGrid.DataRows.Count >= 0) Then
                    SearchGrid.Clear()
                    Me.PnHOSE.Controls.Clear()
                    Me.PnHOSE.Controls.Add(SearchGrid)
                End If
                MessageBox.Show("Không có dữ liệu khớp lệnh bị thiếu.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                'MessageBox.Show("Ghi dữ liệu thành công" & ControlChars.CrLf & v_strFeedBackMessage, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                SearchGrid = New GridEx
                Dim v_cmrContactsHeader As New Xceed.Grid.ColumnManagerRow
                v_cmrContactsHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
                v_cmrContactsHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
                SearchGrid.FixedHeaderRows.Add(v_cmrContactsHeader)
                Dim v_strTotalTitle As String = "STT | Số HL khớp | Ngày giao dịch | Mã CK | Giá khớp | KL khớp |Giá trị khớp | Mua/Bán | Số tài khoản LK | Diễn giải "
                Dim v_xColumn As Xceed.Grid.Column
                Dim v_xcell As Xceed.Grid.Cell
                Dim v_arrData() As String
                Dim v_RowData As String
                Dim v_ChildData() As String
                v_arrData = v_strFeedBackMessage.Split("|")
                For i As Integer = 0 To v_arrData.Count - 1
                    v_RowData = v_arrData(i)
                    v_ChildData = v_RowData.Split(":")
                    Dim v_xDataRow As Xceed.Grid.DataRow = SearchGrid.DataRows.AddNew()
                    Dim v_strTitle() As String = v_strTotalTitle.Split("|")
                    For j As Integer = 0 To v_ChildData.Count - 2
                        If (i = 0) Then
                            SearchGrid.Columns.Add(New Xceed.Grid.Column(j.ToString, GetType(System.String)))
                            SearchGrid.Columns(j.ToString).Title = v_strTitle(j)
                            SearchGrid.Columns(j.ToString).HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Left
                            SearchGrid.Columns(j.ToString).Width = 100
                        End If
                        v_xDataRow.Cells(j).Value = v_ChildData(j)
                    Next
                    v_xDataRow.EndEdit()
                Next

                Dim v_frSearchGrid = New Xceed.Grid.TextRow("Dữ liệu nhận từ file " & v_arrData.Count - 1 & " dòng!")
                v_frSearchGrid.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
                v_frSearchGrid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic)
                SearchGrid.FixedFooterRows.Clear()
                SearchGrid.FixedFooterRows.Add(v_frSearchGrid)

                SearchGrid.EndInit()
                Me.PnHOSE.Controls.Clear()
                Me.PnHOSE.Controls.Add(SearchGrid)
                SearchGrid.Dock = System.Windows.Forms.DockStyle.Fill
                MessageBox.Show("Tổng số deal còn thiếu là : " & v_arrData.Count - 1 & ".", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)


            End If

        Catch ex As Exception
            LogError.Write("Error source: @DIRECT.frmCompareTradingResults.OnSave" & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MessageBox.Show("So sánh dữ liệu không thành công!!", gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub OnExport(ByVal v_strtype As String)
        Try
            If ((SearchGrid.Columns.Count = 0) Or (SearchGrid.DataRows.Count = 0)) Then
                MessageBox.Show("Không có thông tin để kết xuất !!", gc_ApplicationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            'Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            'Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            'Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim excel As New Excel.Application
            Dim wBook As Excel.Workbook
            Dim wSheet As Excel.Worksheet

            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            Dim colIndex As Integer = 0
            Dim rowIndex As Integer = 0

            For Each v_xColumn As Xceed.Grid.Column In SearchGrid.Columns
                colIndex = colIndex + 1
                If Not CType(v_xColumn, Xceed.Grid.Column).Title Is DBNull.Value Then
                    excel.Cells(1, colIndex) = CType(v_xColumn, Xceed.Grid.Column).Title
                Else
                    excel.Cells(1, colIndex) = ""
                End If
            Next

            'Gan noi dung
            For i As Integer = 0 To SearchGrid.DataRows.Count - 1
                With SearchGrid.DataRows(i)
                    rowIndex = rowIndex + 1
                    colIndex = 0
                    For Each v_xColumn As Xceed.Grid.Column In SearchGrid.Columns
                        colIndex = colIndex + 1
                        If Not .Cells(v_xColumn.FieldName).Value() Is DBNull.Value Then
                            excel.Cells(rowIndex + 1, colIndex) = CStr(.Cells(v_xColumn.FieldName).Value)
                        Else
                            excel.Cells(rowIndex + 1, colIndex) = ""
                        End If
                    Next
                End With
            Next
            wSheet.Columns.AutoFit()

            Dim strCurDr As String = Directory.GetCurrentDirectory()
            Dim strFileName As String = strCurDr + "\TradingResultException.xls"
            Dim blnFileOpen As Boolean = False
            Try
                Dim fileTemp As System.IO.FileStream = System.IO.File.OpenWrite(strFileName)
                fileTemp.Close()
            Catch ex As Exception
                blnFileOpen = False
            End Try

            If System.IO.File.Exists(strFileName) Then
                System.IO.File.Delete(strFileName)
            End If

            wBook.SaveAs(strFileName)
            excel.Workbooks.Open(strFileName)
            excel.Visible = True

        Catch ex As Exception

        End Try
    End Sub

#End Region

    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mv_strLanguage = pv_strLanguage
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        OnBrowser(mv_strEXTENTION)
    End Sub

    Private Sub frmCompareTradingResult_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OnInit()
    End Sub


    Private Sub btnReadFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadFile.Click
        'If (OnLoadData(mv_strFileCode) = True) Then
        '    OnSave(mv_strFileCode)
        'End If
        OnSaveToDB(mv_strFileCode)
    End Sub

    Private Sub TabControlTrading_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControlTrading.SelectedIndexChanged
        If Not Me.TabControlTrading.SelectedTab Is Nothing Then
            Dim v_strFile As String
            mv_strFileCode = Me.TabControlTrading.SelectedTab.Tag
            v_strFile = mv_strFileCode
            GetFileInfo(v_strFile)
        End If
    End Sub

    Private Sub btnCompare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompare.Click
        OnCompare(mv_strFileCode)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        OnBrowser(mv_strHOSEEXTENTION)
    End Sub

    Private Sub btnReadFileHO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadFileHO.Click
        OnLoadDataASTDL(mv_strFileTypeHO)

    End Sub

    Private Sub btnCompareHO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompareHO.Click
        OnCompareHO(mv_strFileTypeHO)
    End Sub

    Private Sub CboxTypeFile_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboxTypeFile.SelectedIndexChanged
        If (CboxTypeFile.SelectedIndex = 0) Then
            mv_strFileTypeHO = "HO:LO"
        Else : mv_strFileTypeHO = "HO:PT"
        End If
    End Sub

    Private Sub btnCompareUP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompareUP.Click
        OnCompare(mv_strFileCode)
    End Sub

    Private Sub btnbrowseupcom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbrowseupcom.Click
        OnBrowser(mv_strEXTENTION)
    End Sub

    Private Sub btnReadFileUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadFileUp.Click
        'If (OnLoadData(mv_strFileCode) = True) Then
        '    OnSave(mv_strFileCode)
        'End If
        OnSaveToDB(mv_strFileCode)
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        If (MessageBox.Show("Bạn có muốn kết xuất ra file excel ?", gc_ApplicationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
            OnExport(mv_strFileCode)
        End If
    End Sub


    Private Sub frmCompareTradingResult_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub
End Class