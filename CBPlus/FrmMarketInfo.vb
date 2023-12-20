Imports AppCore
Imports System.Resources
Imports CommonLibrary
Imports System.Xml
Imports System.IO
Public Class FrmMarketInfo

#Region "Variables"


    Private _s As Rectangle
    Private _nextDate As String

    Private _moduleCode As String

    Private _objectName As String

    Private _busDate As String

    Private _branchId As String

    Private _tellerId As String

    Private _userLanguage As String

    Private _resourceManager As ResourceManager
    Private ResultGrid As GridEx
    Const c_ResourceManager = "_Direct.FrmMarketInfo-"
#End Region
#Region "Properties"
    Public Property userLanguage() As String
        Get
            Return _userLanguage
        End Get
        Set(ByVal value As String)
            _userLanguage = value
        End Set
    End Property
    Public Property moduleCode() As String
        Get
            Return _moduleCode
        End Get
        Set(ByVal value As String)
            _moduleCode = value
        End Set
    End Property
    Public Property objectName() As String
        Get
            Return _objectName
        End Get
        Set(ByVal value As String)
            _objectName = value
        End Set
    End Property
    Public Property busDate() As String
        Get
            Return _busDate
        End Get
        Set(ByVal value As String)
            _busDate = value
        End Set
    End Property
    Public Property branchId() As String
        Get
            Return _branchId
        End Get
        Set(ByVal value As String)
            _branchId = value
        End Set
    End Property
    Public Property tellerId() As String
        Get
            Return _tellerId
        End Get
        Set(ByVal value As String)
            _tellerId = value
        End Set
    End Property
    Public Property ResourceManager() As ResourceManager
        Get
            Return _resourceManager
        End Get
        Set(ByVal value As ResourceManager)
            _resourceManager = value
        End Set
    End Property
#End Region
    Private Sub FrmMarketInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OnInit()
        GetInfo()
    End Sub

    Private Sub OnInit()
        Try
            ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & Me.Name & "-" & userLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            Me.Text = ResourceManager.GetString("FORM_TITLE")
            lblInfoDetail.Text = ResourceManager.GetString("LBLINFODETAIL")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Grid_DblClick(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not ResultGrid.CurrentRow Is Nothing Then
            Dim frm As New frmShowNewsDetail()
            frm.NewTitle = CType(ResultGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TITLE").Value
            frm.NewDetail = CType(ResultGrid.CurrentRow, Xceed.Grid.DataRow).Cells("DETAIL").Value
            frm.showDialog()
            'Exit Sub
        End If
    End Sub

    Private Sub GetInfo()
        Try
            Dim v_strObjMsg, v_strFLDNAME, v_strFLDTYPE, v_strTEXT, v_strValue As String
            Dim v_xmlDocument As New Xml.XmlDocument
          
            Dim v_ws As New BDSDeliveryManagement
            'Tao message gui len HOST de xu ly
            v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_AUTHENTICATION, gc_ActionInquiry, , , "GetMarketIdentified")
            v_ws.Message(v_strObjMsg)
            'Lay gia tri tra ve
            v_xmlDocument.LoadXml(v_strObjMsg)
            Dim v_nodeList As Xml.XmlNodeList
            v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
            If v_nodeList.Count > 0 Then
                ResultGrid = New GridEx
                Dim v_cmrODBuyGrid As New Xceed.Grid.ColumnManagerRow
                v_cmrODBuyGrid.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(216, Byte), CType(84, Byte), CType(2, Byte))
                v_cmrODBuyGrid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)

                'ODBuyGrid.FixedHeaderRows.Add(v_grODBuyGrid)
                ResultGrid.FixedHeaderRows.Add(v_cmrODBuyGrid)


                ResultGrid.Columns.Add(New Xceed.Grid.Column("STT", GetType(System.Int32)))
                ResultGrid.Columns("STT").Title = ResourceManager.GetString("STT")

                ResultGrid.Columns("STT").Width = 80
                For j As Integer = 0 To v_nodeList.Item(0).ChildNodes.Count - 1
                    v_strFLDNAME = CStr(CType(v_nodeList.Item(0).ChildNodes(j).Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strFLDTYPE = CStr(CType(v_nodeList.Item(0).ChildNodes(j).Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)
                    

                    If v_strFLDNAME = "NEWS_ID" Then
                        ResultGrid.Columns.Add(New Xceed.Grid.Column(v_strFLDNAME, GetType(System.String)))
                        ResultGrid.Columns(v_strFLDNAME).Title = ResourceManager.GetString(v_strFLDNAME)
                        ResultGrid.Columns(v_strFLDNAME).Width = 100
                    ElseIf v_strFLDNAME = "POST_DATE" Then
                        ResultGrid.Columns.Add(New Xceed.Grid.Column(v_strFLDNAME, GetType(System.String)))
                        ResultGrid.Columns(v_strFLDNAME).Title = ResourceManager.GetString(v_strFLDNAME)
                        ResultGrid.Columns(v_strFLDNAME).Width = 160
                    ElseIf v_strFLDNAME = "TITLE" Then
                        ResultGrid.Columns.Add(New Xceed.Grid.Column(v_strFLDNAME, GetType(System.String)))
                        ResultGrid.Columns(v_strFLDNAME).Title = ResourceManager.GetString(v_strFLDNAME)
                        ResultGrid.Columns(v_strFLDNAME).Width = 300
                    Else
                        Select Case v_strFLDTYPE
                            Case "System.String"
                                ResultGrid.Columns.Add(New Xceed.Grid.Column(v_strFLDNAME, GetType(System.String)))
                            Case "System.DateTime"
                                ResultGrid.Columns.Add(New Xceed.Grid.Column(v_strFLDNAME, GetType(System.String)))
                            Case Else
                                ResultGrid.Columns.Add(New Xceed.Grid.Column(v_strFLDNAME, GetType(System.Double)))
                        End Select
                        ResultGrid.Columns(v_strFLDNAME).Title = v_strFLDNAME
                        ResultGrid.Columns(v_strFLDNAME).Visible = False
                    End If

                    
                Next
                
                'Fill du lieu vao Grid
                Dim v_stt As Int32 = 0
                For i As Integer = 0 To v_nodeList.Count - 1
                    v_strTEXT = String.Empty
                    Dim v_xDataRow As Xceed.Grid.DataRow = ResultGrid.DataRows.AddNew()
                    For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                        With v_nodeList.Item(i).ChildNodes(j)
                            v_strValue = Trim(.InnerText.ToString)
                            v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                            v_strFLDTYPE = CStr(CType(.Attributes.GetNamedItem("fldtype"), Xml.XmlAttribute).Value)
                            Select Case v_strFLDTYPE
                                Case "System.String"
                                    v_xDataRow.Cells(v_strFLDNAME).Value = IIf(v_strValue Is DBNull.Value, "", CStr(v_strValue))
                                Case "System.DateTime"
                                    v_xDataRow.Cells(v_strFLDNAME).Value = IIf(v_strValue Is DBNull.Value, "", CStr(v_strValue))
                                Case Else
                                    If v_strFLDNAME = "NEWS_ID" Then
                                        v_xDataRow.Cells(v_strFLDNAME).Value = IIf(v_strValue Is DBNull.Value, "", CStr(v_strValue))
                                    Else
                                        v_xDataRow.Cells(v_strFLDNAME).Value = IIf(v_strValue Is DBNull.Value, 0, CDbl(v_strValue))
                                    End If
                            End Select
                            v_stt = v_stt + 1
                            v_xDataRow.Cells("STT").Value = v_stt
                        End With
                    Next
                    v_xDataRow.EndEdit()
                Next
              

                Me.Panel1.Controls.Clear()
                Me.Panel1.Controls.Add(ResultGrid)
                ResultGrid.Dock = System.Windows.Forms.DockStyle.Fill
                AddHandler ResultGrid.DoubleClick, AddressOf Grid_DblClick
                If Me.ResultGrid.DataRowTemplate.Cells.Count >= 0 Then
                    For i As Integer = 0 To Me.ResultGrid.DataRowTemplate.Cells.Count - 1
                        AddHandler ResultGrid.DataRowTemplate.Cells(i).DoubleClick, AddressOf Grid_DblClick
                    Next
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub OnExport()
        Try
            Dim v_dlgSave As New SaveFileDialog
            Dim v_strTemp As String
            v_dlgSave.Filter = "Text files (*.txt)|*.txt|Doc File (*.Doc)|*.doc|All files (*.*)|*.*"
            v_dlgSave.RestoreDirectory = True
            Dim v_res As DialogResult = v_dlgSave.ShowDialog(Me)

            If v_res = DialogResult.OK Then
                Dim v_strFileName As String = v_dlgSave.FileName
                If Mid(v_strFileName, Len(v_strFileName) - 3) <> ".xls" Then
                    Dim v_strData As String
                    Dim v_streamWriter As New StreamWriter(v_strFileName, False, System.Text.Encoding.Unicode)

                    If Not (ResultGrid.CurrentRow Is Nothing) Then
                        'Write file's header
                        v_strData = String.Empty

                        v_strData &= CType(ResultGrid.CurrentRow, Xceed.Grid.DataRow).Cells("TITLE").Value

                        v_streamWriter.WriteLine(v_strData)

                        'Write data
                        v_strData = String.Empty
                        RichEditControl1.Text = CType(ResultGrid.CurrentRow, Xceed.Grid.DataRow).Cells("DETAIL").Value

                        v_strData &= RichEditControl1.Text

                        v_streamWriter.WriteLine(v_strData)
                    Else
                        MsgBox(ResourceManager.GetString("NothingToExport"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        Exit Sub
                    End If

                    'Close StreamWriter
                    v_streamWriter.Close()
                Else
                    MsgBox(ResourceManager.GetString("XLSFILENOTSUPPORT"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Exit Sub
                End If


                MsgBox(ResourceManager.GetString("ExportSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            End If

            Exit Sub

        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub

    Private Sub FrmMarketInfo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

    End Sub

    Private Sub FrmMarketInfo_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.F5
                GetInfo()
        End Select
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        GetInfo()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        OnExport()
    End Sub
End Class