Imports CommonLibrary
Imports System.Windows.Forms
Imports Xceed.SmartUI.Controls
Imports System.Collections
Imports System.IO

Public Class frmRECONCILE
    Inherits System.Windows.Forms.Form
    Public v_dtgLookupData As New GridEx

#Region " Declare constant and variables "
    Const c_WEB_SERVICE_TIMEOUT = 3600000
    Const c_ResourceManager = "AppCore.frmRECONCILE-"
    Const WIDTH_GRID_LOOKUP = 550

    Const SEARCH_OPTION_BEGIN = "SearchOption.BeginWith"
    Const SEARCH_OPTION_CONTAINS = "SearchOption.Contains"

    Private mv_blnAutoClosed As Boolean = False
    Private mv_blnAcceptedClose As Boolean = True
    Private mv_strCaption As String
    Private mv_strSQLCommand As String
    Private mv_strReturnData As String
    Private mv_strLanguage As String
    Private mv_ResourceManager As Resources.ResourceManager
    Private mv_strXMLData As String
#End Region

#Region " Properties "
    Public Property AcceptedClose() As Boolean
        Get
            Return mv_blnAcceptedClose
        End Get
        Set(ByVal Value As Boolean)
            mv_blnAcceptedClose = Value
        End Set
    End Property

    Public Property AutoClosed() As Boolean
        Get
            Return mv_blnAutoClosed
        End Get
        Set(ByVal Value As Boolean)
            mv_blnAutoClosed = Value
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

    Public Property CAPTION() As String
        Get
            Return mv_strCaption
        End Get
        Set(ByVal Value As String)
            mv_strCaption = Value
        End Set
    End Property

    Public Property SQLCMD() As String
        Get
            Return mv_strSQLCommand
        End Get
        Set(ByVal Value As String)
            mv_strSQLCommand = Value
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

    Public Property FULLDATA() As String
        Get
            Return mv_strXMLData
        End Get
        Set(ByVal Value As String)
            mv_strXMLData = Value
        End Set
    End Property
#End Region

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        mv_strLanguage = pv_strLanguage
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
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCANCEL As System.Windows.Forms.Button
    Friend WithEvents pnRECONCILE As System.Windows.Forms.Panel
    Friend WithEvents btnExport As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCANCEL = New System.Windows.Forms.Button
        Me.pnRECONCILE = New System.Windows.Forms.Panel
        Me.btnExport = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(424, 375)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(80, 23)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "btnOK"
        '
        'btnCANCEL
        '
        Me.btnCANCEL.Location = New System.Drawing.Point(508, 375)
        Me.btnCANCEL.Name = "btnCANCEL"
        Me.btnCANCEL.Size = New System.Drawing.Size(80, 23)
        Me.btnCANCEL.TabIndex = 4
        Me.btnCANCEL.Text = "btnCANCEL"
        '
        'pnRECONCILE
        '
        Me.pnRECONCILE.BackColor = System.Drawing.Color.Transparent
        Me.pnRECONCILE.Location = New System.Drawing.Point(6, 8)
        Me.pnRECONCILE.Name = "pnRECONCILE"
        Me.pnRECONCILE.Size = New System.Drawing.Size(582, 352)
        Me.pnRECONCILE.TabIndex = 5
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(6, 374)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.TabIndex = 6
        Me.btnExport.Text = "&Export"
        '
        'frmRECONCILE
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ClientSize = New System.Drawing.Size(594, 405)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.pnRECONCILE)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCANCEL)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRECONCILE"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmRECONCILE"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Other methods "
    Protected Overridable Function InitDialog()
        'Khởi tạo kích thước form và load resource
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LoadResource(Me)

        'Thiết lập các thuộc tính ban đầu cho form
        DoResizeForm()


        'Nạp dữ liệu hiển thị thông tin tra cứu
        If Len(Trim(SQLCMD)) > 0 Then
            LoadLookupData()
        End If

    End Function

    Private Sub LoadLookupData()
        Dim v_nodeList As Xml.XmlNodeList
        Dim v_strValue, v_strFLDNAME, v_strFLDTYPE, v_strTEXT As String

        Try
            'Create message to inquiry object fields
            Dim v_strObjMsg As String
            Dim v_xmlDocument As New Xml.XmlDocument
            Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
            'TruongLD Comment when convert
            'v_ws.Timeout = c_WEB_SERVICE_TIMEOUT
            'Lấy thông tin chung về giao dịch
            v_strObjMsg = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_CI_CIMAST, gc_ActionInquiry, SQLCMD, "")
            v_ws.Message(v_strObjMsg)

            'Lưu trữ danh sách tìm kiếm trả về
            FULLDATA = v_strObjMsg

            v_xmlDocument.LoadXml(v_strObjMsg)
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            Dim i, j As Integer

            'Hiển thị toàn bộ nội dung của dữ liệu tìm kiếm trả về
            If v_nodeList.Count > 0 Then
                v_dtgLookupData.Dock = DockStyle.Fill
                Dim v_cmrHeader As New Xceed.Grid.ColumnManagerRow
                v_cmrHeader.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
                v_cmrHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
                v_dtgLookupData.FixedHeaderRows.Add(v_cmrHeader)
                'Tạo Header của Grid
                For j = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                    With v_nodeList.Item(0).ChildNodes(j)
                        v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                        v_strFLDTYPE = CStr(CType(.Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)
                        v_dtgLookupData.Columns.Add(New Xceed.Grid.Column(v_strFLDNAME, GetType(System.String)))
                        v_dtgLookupData.Columns(v_strFLDNAME).Title = mv_ResourceManager.GetString("frmRECONCILE." & v_strFLDNAME)
                        'v_dtgLookupData.Columns(v_strFLDNAME).Title = UCase(v_strFLDNAME)
                        v_dtgLookupData.Columns(v_strFLDNAME).HorizontalAlignment = Xceed.Grid.HorizontalAlignment.Default
                        v_dtgLookupData.Columns(v_strFLDNAME).Width = 100

                    End With
                Next

                'Điền thông tin tra cứu
                v_dtgLookupData.DataRows.Clear()
                v_dtgLookupData.BeginInit()
                For i = 0 To v_nodeList.Count - 1
                    'Tạo row dữ liệu
                    Dim v_xDataRow As Xceed.Grid.DataRow = v_dtgLookupData.DataRows.AddNew()
                    For j = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = Trim(.InnerText)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_xDataRow.Cells(v_strFLDNAME).Value = v_strValue
                        End With
                    Next
                    'Dùng để trả về giá trị RETURNDATA cho form lookup
                    v_xDataRow.EndEdit()
                Next
                v_dtgLookupData.EndInit()
                Me.pnRECONCILE.Controls.Add(v_dtgLookupData)

                'Tự động đóng màn hình nếu chỉ có 01 bản ghi và AutoClosed=True
                If v_nodeList.Count = 0 And AutoClosed Then
                    OnAccept()
                    MessageBox.Show("Valid database!")
                End If
                pnRECONCILE.Select()

            Else
                If AutoClosed Then
                    OnAccept()
                    MessageBox.Show("Valid database!")
                End If
            End If

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub DoResizeForm()

    End Sub


    Private Sub Grid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    OnAccept()
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub OnClose()
        Me.Close()
    End Sub

    Private Sub OnAccept()
        Me.Close()
    End Sub


    Private Sub LoadResource(ByRef pv_ctrl As Windows.Forms.Control)
        Dim v_ctrl As Windows.Forms.Control

        For Each v_ctrl In pv_ctrl.Controls
            If TypeOf (v_ctrl) Is Label Then
                CType(v_ctrl, Label).Text = mv_ResourceManager.GetString("frmRECONCILE." & v_ctrl.Name)
            ElseIf TypeOf (v_ctrl) Is GroupBox Then
                CType(v_ctrl, GroupBox).Text = mv_ResourceManager.GetString("frmRECONCILE." & v_ctrl.Name)
                LoadResource(v_ctrl)
            ElseIf TypeOf (v_ctrl) Is Button Then
                CType(v_ctrl, Button).Text = mv_ResourceManager.GetString("frmRECONCILE." & v_ctrl.Name)
            End If
        Next
    End Sub

    Private Function OnExport() As Int32
        Try
            Dim v_dlgSave As New SaveFileDialog
            v_dlgSave.Filter = "Text files (*.txt)|*.txt|Excel files (*.xls)|*.xls|All files (*.*)|*.*"
            v_dlgSave.RestoreDirectory = True
            Dim v_res As DialogResult = v_dlgSave.ShowDialog(Me)
            If v_res = DialogResult.OK Then
                Dim v_strFileName As String = v_dlgSave.FileName
                Dim v_strData As String
                Dim v_streamWriter As New StreamWriter(v_strFileName, False, System.Text.Encoding.Unicode)

                If (v_dtgLookupData.DataRows.Count > 0) Then
                    'Write file's header
                    v_strData = String.Empty
                    For idx As Integer = 0 To v_dtgLookupData.Columns.Count - 1
                        If v_dtgLookupData.Columns(idx).Visible Then
                            v_strData &= v_dtgLookupData.Columns(idx).Title & vbTab
                        End If
                    Next
                    v_streamWriter.WriteLine(v_strData)

                    'Write data
                    For i As Integer = 0 To v_dtgLookupData.DataRows.Count - 1
                        v_strData = String.Empty

                        For j As Integer = 0 To v_dtgLookupData.DataRows(i).Cells.Count - 1
                            If v_dtgLookupData.Columns(j).Visible Then
                                v_strData &= v_dtgLookupData.DataRows(i).Cells(j).Value & vbTab
                            End If
                        Next

                        'Write data to the file
                        v_streamWriter.WriteLine(v_strData)
                    Next
                Else
                    MsgBox("Nothing to export", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
                    Exit Function
                End If

                'Close StreamWriter
                v_streamWriter.Close()

                MsgBox("Export successful!", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Function

#End Region

#Region " Form events "
    Private Sub frmRECONCILE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitDialog()
    End Sub

    Private Sub frmRECONCILE_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        DoResizeForm()
    End Sub

    Private Sub btnCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCANCEL.Click
        OnClose()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        OnAccept()
    End Sub

    Private Sub frmRECONCILE_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Escape
                OnClose()
            Case Keys.Enter
        End Select
    End Sub
#End Region

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        OnExport()
    End Sub
End Class
