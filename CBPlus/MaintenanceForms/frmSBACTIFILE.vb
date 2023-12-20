Imports CommonLibrary
Imports System.Xml.XmlNode
Imports System.Xml
Imports TestBase64
Imports ZetaCompressionLibrary
Imports System.IO
Imports AppCore
Imports System.IO.File
Imports System.IO.Path
Imports System.Windows.Forms.Application
Imports System.Text
Imports System.Globalization
Imports System.Configuration
Imports System.Threading
Imports log4ne
Imports DevExpress.XtraEditors
Imports DevExpress.XtraPdfViewer

Public Class frmSBACTIFILE
    Inherits AppCore.frmXtraMaintenance
#Region "Declare constants and variables"
    Public mv_strAUTID As String
    Public mv_strREFID As String
    Private mv_arrImageUpload() As ImageUpload
    Private mv_CurrImageUpload As ImageUpload
    Private mv_srcFileName As String
    Private mv_srcFiletype As String
    Private mv_base64 As String
    Private mv_byarray As Byte()

    Public frm_SBACTIDTL As frmSBACTIDTL

    Property extImageFileAllows As String() = {"*.jpg", "*.jpeg", "*.jpe", "*.jfif", "*.png"}
    Property extFileAllows As String = String.Join(",", extImageFileAllows) + "," + "*.pdf" + "," + "*.zip"
    Property extFileAllows2 As String = String.Join(";", extImageFileAllows) + ";" + "*.pdf" + ";" + "*.zip"


#Region "publich sub"
    Public Sub New(ByVal frm As frmSBACTIDTL)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.frm_SBACTIDTL = frm
    End Sub
#End Region

#End Region

#Region "private sub"
    Public Overrides Sub OnInit()

        ResourceManager = New Resources.ResourceManager(gc_RootNamespace & "." & Me.Name & "-" & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
        LocalObject = gc_IsNotLocalMsg
        MyBase.OnInit()
        LoadUserInterface(Me)
        FormInit()
    End Sub

    Private Sub FormInit()
        Dim v_strSQL As String
        Dim v_ds As New DataSet
        Dim v_strObjMsg As String
        Dim v_xmlDocument As New Xml.XmlDocument, v_xmlDocumentData As New Xml.XmlDocument
        Dim v_ws As New BDSDeliveryManagement 'Dim v_ws As New BDSDelivery.BDSDelivery
        Dim v_nodeList As Xml.XmlNodeList, v_nodetxData As Xml.XmlNode
        Dim v_strValue, v_strFLDNAME As String
        txtREFID.Text = mv_strAUTID
        If ExeFlag = ExecuteFlag.AddNew Then
            GetAUTOID()
        End If
    End Sub

    Overrides Sub LoadUserInterface(ByRef pv_ctrl As Windows.Forms.Control)
        MyBase.LoadUserInterface(pv_ctrl)
        'Load rieng cho form
    End Sub

    Private Function VerifyRule(Optional ByVal pv_blnSaved As Boolean = False) As Boolean
        Try
            'Check valid
            Return MyBase.VerifyRules
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function

    Private Sub GetAUTOID()
        Dim v_ws As New BDSDeliveryManagement
        Dim v_strSQL As String = "SELECT SEQ_SBACTIFILE.NEXTVAL ID from DUAL"
        Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_SY_SEARCHFLD, _
            gc_ActionInquiry, v_strSQL, , )
        v_ws.Message(v_strObjMsg)
        Dim v_nodeList As Xml.XmlNodeList
        Dim XmlDocument As New Xml.XmlDocument
        Dim v_strFLDNAME, v_strValue, v_strID, v_strFUNDNAME As String
        v_strID = String.Empty
        XmlDocument.LoadXml(v_strObjMsg)
        v_nodeList = XmlDocument.SelectNodes("/ObjectMessage/ObjData")

        For i As Integer = 0 To v_nodeList.Count - 1
            For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
                With v_nodeList.Item(i).ChildNodes(j)
                    v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)
                    v_strValue = .InnerText.ToString

                    Select Case Trim(v_strFLDNAME)
                        Case "ID"
                            v_strID = CStr(v_strValue).Trim
                            txtAUTOID.Text = v_strID
                    End Select
                End With
            Next
        Next
    End Sub

    Private Sub frmSBACTIFILE_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Public Sub PreviewFilePath(ByVal pathFile As String)
        panelPreview.Controls.Clear()
        Dim ext As String = Path.GetExtension(pathFile)
        If Not String.IsNullOrEmpty(ext) Then
            Dim extImageFileStr As String = String.Join(",", extImageFileAllows)
            If (extFileAllows.Contains(ext.ToLower)) Then
                If (ext.ToUpper().Contains("PDF")) Then
                    Dim pdfViewer As PdfViewer = New PdfViewer()
                    pdfViewer.DocumentFilePath = pathFile
                    pdfViewer.Dock = DockStyle.Fill
                    panelPreview.AutoScroll = True
                    panelPreview.Controls.Add(pdfViewer)
                ElseIf (ext.ToUpper().Contains("ZIP")) Then
                    Dim txtzip As TextBox = New TextBox()
                    txtzip.Text = pathFile
                    txtzip.Dock = DockStyle.Left
                    txtzip.Enabled = False
                    txtzip.Dock = DockStyle.Top
                    txtzip.ReadOnly = True
                    panelPreview.AutoScroll = True
                    panelPreview.Controls.Add(txtzip)
                Else 'Image
                    Dim picture As PictureBox = New PictureBox()
                    picture.Image = Image.FromFile(pathFile)
                    picture.SizeMode = PictureBoxSizeMode.AutoSize
                    panelPreview.AutoScroll = True
                    panelPreview.Controls.Add(picture)
                End If
            End If
        End If

    End Sub

    Public Sub PreviewFilePath(ByVal byteArr As Byte())
        panelPreview.Controls.Clear()

        Dim pdfViewer As PdfViewer = New PdfViewer()
        If (IsValidImage(byteArr)) Then
            Dim picture As PictureBox = New PictureBox()
            picture.Image = ByteToImage(byteArr)
            picture.SizeMode = PictureBoxSizeMode.AutoSize
            panelPreview.AutoScroll = True
            panelPreview.Controls.Add(picture)
            byteArr = Nothing
        ElseIf IsValidPdf(byteArr, pdfViewer) Then
            pdfViewer.Dock = DockStyle.Fill
            panelPreview.AutoScroll = True
            panelPreview.Controls.Add(pdfViewer)
            byteArr = Nothing
        Else
            Dim txtzip As TextBox = New TextBox()
            txtzip.Text = ResourceManager.GetString("ZIP")
            txtzip.Dock = DockStyle.Left
            txtzip.Dock = DockStyle.Top
            txtzip.Enabled = False
            txtzip.ReadOnly = True
            panelPreview.AutoScroll = True
            panelPreview.Controls.Add(txtzip)
            byteArr = Nothing
        End If
    End Sub

    Public Function IsValidPdf(ByVal bytes As Byte(), ByVal pdfViewer As PdfViewer) As Boolean
        Try
            Dim ms As MemoryStream = New MemoryStream(bytes)
            pdfViewer.LoadDocument(ms)
            Return True
        Catch ex As Exception

            Return False
        End Try
        Return False
    End Function

    Public Function ByteToImage(ByVal blob As Byte()) As Bitmap
        Dim mStream As MemoryStream = New MemoryStream()
        mStream.Write(blob, 0, Convert.ToInt32(blob.Length))
        Dim bm As Bitmap = New Bitmap(mStream, False)
        mStream.Dispose()
        Return bm
    End Function

    Public Function IsValidImage(ByVal bytes As Byte()) As Boolean
        Try
            Using ms As MemoryStream = New MemoryStream(bytes)
                Image.FromStream(ms)
            End Using
        Catch ex As Exception

            Return False
        End Try
        Return True
    End Function

    Public Overrides Sub OnSave()
        Dim v_strObjMsg As String

        Try
            'Update mouse pointer
            Cursor.Current = Cursors.WaitCursor

            'Verify data 
            If (VerifyRule() = False) Then
                Exit Sub
            End If

            MyBase.OnSave()
            If Not DoDataExchange(True) Then
                Exit Sub
            End If

            Select Case ExeFlag
                Case ExecuteFlag.AddNew

                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionAdd, , " AUTOID = '" & txtAUTOID.Text & "'", , gc_AutoIdUnused)
                    BuildXMLObjData(mv_dsInput, v_strObjMsg)

                    Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                    Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                    If (v_lngErrorCode = 0) Then
                        v_ws.UploadFile(mv_dsTypeBytes, "AUTOID", txtAUTOID.Text, TableName)
                        mv_dsTypeBytes = Nothing
                    End If

                    'Kiểm tra thông tin và xử lý lỗi (nếu có) từ message trả v?
                    Dim v_strErrorSource, v_strErrorMessage As String

                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage)
                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Sub
                    End If

                    MsgBox(ResourceManager.GetString("AddnewSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Me.DialogResult = DialogResult.OK
                    MyBase.OnClose()
                Case ExecuteFlag.Edit

                    v_strObjMsg = BuildXMLObjMsg(, BranchId, , TellerId, LocalObject, gc_MsgTypeObj, ObjectName, gc_ActionEdit, , " AUTOID = '" & txtAUTOID.Text & "'")
                    BuildXMLObjData(mv_dsInput, v_strObjMsg, mv_dsOldInput, ExecuteFlag.Edit)

                    Dim v_ws As New BDSDeliveryManagement 'BDSDelivery.BDSDelivery
                    Dim v_lngErrorCode As Long = v_ws.Message(v_strObjMsg)

                    If (v_lngErrorCode = 0) Then
                        v_ws.UploadFile(mv_dsTypeBytes, "AUTOID", txtAUTOID.Text, TableName)
                        mv_dsTypeBytes = Nothing
                    End If

                    'Ki�ểm tra thông tin và xử lý lỗi (nếu có) từ message trả v?
                    Dim v_strErrorSource, v_strErrorMessage As String

                    GetErrorFromMessage(v_strObjMsg, v_strErrorSource, v_lngErrorCode, v_strErrorMessage)
                    If v_lngErrorCode <> 0 Then
                        'Update mouse pointer
                        Cursor.Current = Cursors.Default
                        MsgBox(v_strErrorMessage, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                        Exit Sub
                    End If

                    MsgBox(ResourceManager.GetString("EditSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    Me.DialogResult = DialogResult.OK
                    MyBase.OnClose()

            End Select
            Me.frm_SBACTIDTL.InitExternal()
            'Update mouse pointer
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ResourceManager.GetString("SavingFailed"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
        End Try
    End Sub


#End Region

#Region "event"

#End Region
    Dim mv_lngFileSize As Long = 0
    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Using openFileDialog As OpenFileDialog = New OpenFileDialog()
            openFileDialog.Filter = "Image & Pdf files (" + extFileAllows + ") | " + extFileAllows2
            openFileDialog.FilterIndex = 2
            openFileDialog.RestoreDirectory = True
            If openFileDialog.ShowDialog() = DialogResult.OK Then
                Dim urlFile As String = openFileDialog.FileName
                mv_lngFileSize = FileLen(urlFile)
                'txtSIGNATURE.Text = urlFile 'Path.GetFileName(urlFile)
                txtFILEDATA.SetPath(urlFile)
                txtFILETYP.Text = Path.GetExtension(urlFile)
                PreviewFilePath(urlFile)
            End If
        End Using
    End Sub

    Private Sub txtFILEDATA_EditValueChanged(sender As Object, e As EventArgs) Handles txtFILEDATA.EditValueChanged
        Dim control As ButtonEditCustom = CType(sender, ButtonEditCustom)
        If control IsNot Nothing And Not String.IsNullOrEmpty(control.Text) Then
            control.Properties.Buttons(0).Visible = True
            If (control.ActionControl = ButtonEditCustom.ActionEnum.EDIT) Then
                mv_byarray = control.DataByte
                PreviewFilePath(control.DataByte)
            End If

        Else
            control.Properties.Buttons(0).Visible = False
        End If
    End Sub

    Private Sub txtFILEDATA_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtFILEDATA.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete Then
            txtFILEDATA.SetPath(Nothing)
            txtFILEDATA.DataByte = Nothing
            panelPreview.Controls.Clear()
        End If
    End Sub

    Private Sub panelPreview_MouseDown(sender As Object, e As MouseEventArgs) Handles panelPreview.MouseDown
        Try
            If (e.Button = Windows.Forms.MouseButtons.Right) Then
                btnDownLoad.Caption = ResourceManager.GetString("DOWNLOAD")
                popmenu.ShowPopup(Control.MousePosition)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnDownLoad_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDownLoad.ItemClick
        If panelPreview.Controls.Count > 0 Then
            Dim ctrls = panelPreview.Controls
            If (ctrls Is Nothing OrElse ctrls.Count <> 1) Then
                MsgBox("File not found!")
                Return
            End If

            Dim ctrl = ctrls(0)
            Try
                If (TypeOf (ctrl) Is PdfViewer) Then
                    Dim pth As SaveFileDialog = New SaveFileDialog()
                    pth.Filter = "Images|*.pdf"
                    Dim format As System.Drawing.Imaging.ImageFormat = System.Drawing.Imaging.ImageFormat.Png

                    If pth.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                        Using ms As System.IO.MemoryStream = New System.IO.MemoryStream()
                            CType(ctrl, PdfViewer).SaveDocument(ms)
                            Dim file As FileStream = New FileStream(pth.FileName, FileMode.Create, FileAccess.Write)
                            ms.WriteTo(file)
                            MsgBox(ResourceManager.GetString("DownloadSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        End Using
                    End If
                ElseIf (TypeOf (ctrl) Is PictureBox) Then
                    Dim pth As SaveFileDialog = New SaveFileDialog()
                    pth.Filter = "Images|*.jpg"
                    Dim format As System.Drawing.Imaging.ImageFormat = System.Drawing.Imaging.ImageFormat.Png
                    If pth.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                        CType(ctrl, PictureBox).Image.Save(pth.FileName, System.Drawing.Imaging.ImageFormat.Jpeg)
                        MsgBox(ResourceManager.GetString("DownloadSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    End If
                Else
                    Dim pth As SaveFileDialog = New SaveFileDialog()
                    pth.Filter = "Images|*.zip"
                    If pth.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                        Dim filename As String = pth.FileName
                        If IsValidZip(mv_byarray, pth.FileName) Then
                            MsgBox(ResourceManager.GetString("DownloadSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            mv_byarray = Nothing
                        Else
                            MsgBox(ResourceManager.GetString("Downloadfail"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        End If
                    End If
                End If
            Catch ex As Exception
                MsgBox(ResourceManager.GetString("Downloadfail"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            End Try
        End If
    End Sub

    Public Function IsValidZip(ByVal bytes As Byte(), ByVal path As String) As Boolean
        Try
            File.WriteAllBytes(path, bytes)
            Return True
        Catch ex As Exception

            Return False
        End Try
        Return True
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If panelPreview.Controls.Count > 0 Then
            Dim ctrls = panelPreview.Controls
            If (ctrls Is Nothing OrElse ctrls.Count <> 1) Then
                MsgBox("File not found!")
                Return
            End If

            Dim ctrl = ctrls(0)
            Try
                If (TypeOf (ctrl) Is PdfViewer) Then
                    Dim pth As SaveFileDialog = New SaveFileDialog()
                    pth.Filter = "Images|*.pdf"
                    Dim format As System.Drawing.Imaging.ImageFormat = System.Drawing.Imaging.ImageFormat.Png

                    If pth.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                        Using ms As System.IO.MemoryStream = New System.IO.MemoryStream()
                            CType(ctrl, PdfViewer).SaveDocument(ms)
                            Dim file As FileStream = New FileStream(pth.FileName, FileMode.Create, FileAccess.Write)
                            ms.WriteTo(file)
                            MsgBox(ResourceManager.GetString("DownloadSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        End Using
                    End If
                ElseIf (TypeOf (ctrl) Is PictureBox) Then
                    Dim pth As SaveFileDialog = New SaveFileDialog()
                    pth.Filter = "Images|*.jpg"
                    Dim format As System.Drawing.Imaging.ImageFormat = System.Drawing.Imaging.ImageFormat.Png
                    If pth.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                        CType(ctrl, PictureBox).Image.Save(pth.FileName, System.Drawing.Imaging.ImageFormat.Jpeg)
                        MsgBox(ResourceManager.GetString("DownloadSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                    End If
                Else
                    Dim pth As SaveFileDialog = New SaveFileDialog()
                    pth.Filter = "Images|*.zip"
                    If pth.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                        Dim filename As String = pth.FileName
                        If IsValidZip(mv_byarray, pth.FileName) Then
                            MsgBox(ResourceManager.GetString("DownloadSuccessful"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                            mv_byarray = Nothing
                        Else
                            MsgBox(ResourceManager.GetString("Downloadfail"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
                        End If
                    End If
                End If
            Catch ex As Exception
                MsgBox(ResourceManager.GetString("Downloadfail"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, gc_ApplicationTitle)
            End Try
        End If
    End Sub


End Class