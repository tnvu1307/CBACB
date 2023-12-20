Imports CommonLibrary
Imports System.Text
Imports ZetaCompressionLibrary
Imports System.Math
Imports System.Threading

Public Class frmDefineProduct
    Inherits System.Windows.Forms.Form

    Private v_threadnum As Integer
    Private v_cntorder As Integer = 0
    Private v_numberorders As Integer = 0
    Private v_tag As String
    Private v_blnLoadTest As Boolean = False
    Dim v_strStartTime, v_strEndTime As String

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal mynumber As Integer, ByVal mytag As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        v_threadnum = mynumber
        v_tag = mytag
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
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents txtNumberOfOrders As System.Windows.Forms.TextBox
    Friend WithEvents lblNumberOfOrders As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblFeedback As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSleepTime As System.Windows.Forms.TextBox
    Friend WithEvents tmLoadTest As System.Windows.Forms.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.btnSubmit = New System.Windows.Forms.Button
        Me.txtNumberOfOrders = New System.Windows.Forms.TextBox
        Me.lblNumberOfOrders = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.lblFeedback = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtSleepTime = New System.Windows.Forms.TextBox
        Me.tmLoadTest = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(232, 6)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.TabIndex = 0
        Me.btnSubmit.Text = "&Submit"
        '
        'txtNumberOfOrders
        '
        Me.txtNumberOfOrders.Location = New System.Drawing.Point(112, 8)
        Me.txtNumberOfOrders.Name = "txtNumberOfOrders"
        Me.txtNumberOfOrders.Size = New System.Drawing.Size(48, 20)
        Me.txtNumberOfOrders.TabIndex = 1
        Me.txtNumberOfOrders.Text = "10"
        '
        'lblNumberOfOrders
        '
        Me.lblNumberOfOrders.Location = New System.Drawing.Point(8, 8)
        Me.lblNumberOfOrders.Name = "lblNumberOfOrders"
        Me.lblNumberOfOrders.TabIndex = 2
        Me.lblNumberOfOrders.Text = "Number of orders:"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(232, 34)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "&Close"
        '
        'lblFeedback
        '
        Me.lblFeedback.Location = New System.Drawing.Point(0, 64)
        Me.lblFeedback.Name = "lblFeedback"
        Me.lblFeedback.Size = New System.Drawing.Size(304, 23)
        Me.lblFeedback.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Sleep time(s):"
        '
        'txtSleepTime
        '
        Me.txtSleepTime.Location = New System.Drawing.Point(112, 32)
        Me.txtSleepTime.Name = "txtSleepTime"
        Me.txtSleepTime.Size = New System.Drawing.Size(48, 20)
        Me.txtSleepTime.TabIndex = 4
        Me.txtSleepTime.Text = "1"
        '
        'tmLoadTest
        '
        '
        'frmDefineProduct
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(312, 86)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSleepTime)
        Me.Controls.Add(Me.lblFeedback)
        Me.Controls.Add(Me.lblNumberOfOrders)
        Me.Controls.Add(Me.txtNumberOfOrders)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.btnClose)
        Me.Name = "frmDefineProduct"
        Me.Text = "frmDefineProduct"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub Run()
        'Ham nay duoc su dung de loadtest giao dich trong he thong
        'Giao dich se duoc phong thanh cac thread: Tham so hoa khoi luong giao dich de chia tai de cho cac thread
        Dim i, v_intNumberOfOrders, v_intSleep As Integer       
        v_strStartTime = Now.ToLongTimeString

        Select Case v_tag
            Case "ORDER"
                Me.Text = v_tag & ": " & v_threadnum.ToString
                Me.Show()
                If Not IsNumeric(Me.txtNumberOfOrders.Text) Then
                    v_intNumberOfOrders = 10    'default value
                Else
                    v_intNumberOfOrders = CInt(Me.txtNumberOfOrders.Text)
                End If
                If Not IsNumeric(Me.txtSleepTime.Text) Then
                    v_intSleep = 2000    'default sleep time
                Else
                    v_intSleep = CInt(Me.txtSleepTime.Text) * 1000
                End If
                Me.tmLoadTest.Interval = v_intSleep
                v_numberorders = v_intNumberOfOrders
                v_blnLoadTest = True
                Me.tmLoadTest.Enabled = v_blnLoadTest

                'For i = 1 To v_intNumberOfOrders
                '    Me.Text = v_tag & ": " & v_threadnum.ToString & "." & i.ToString
                '    TestPlaceOrder()
                'Next
        End Select

        'v_strEndTime = Now.ToLongTimeString
        'Me.lblFeedback.Text = "[Start at: " & v_strStartTime & "] [Finish at: " & v_strEndTime & "]"
    End Sub

    Private Function SendMessage2Host(ByRef pv_strMessage As String) As Long
        'Call Host WebService 
        'Dim v_ws As New TradingEngine.TradingEngine
        'Dim v_lngErr As Long
        'Try
        '    v_ws.Timeout = gc_WEB_SERVICE_TIMEOUT
        '    'Compress message
        '    Dim pv_arrByteMessage() As Byte = ZetaCompressionLibrary.CompressionHelper.CompressString(pv_strMessage)
        '    v_lngErr = v_ws.RequestMessage(pv_arrByteMessage)
        '    'Decompress
        '    pv_strMessage = ZetaCompressionLibrary.CompressionHelper.DecompressString(pv_arrByteMessage)
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'Finally
        '    v_ws = Nothing
        'End Try
    End Function

    Private Sub TestPlaceOrder()
        'Ham nay duoc su dung de loadtest giao dich trong he thong
        'Giao dich se duoc phong thanh cac thread: Tham so hoa khoi luong giao dich de chia tai de cho cac thread
        Dim v_lngQTTY, v_lngPRICE, v_lngTEMP As Long
        Dim v_intSleep, i, j As Integer
        Dim v_strAccount As String
        Dim v_strErrorSource, v_strErrorMessage, v_strEXECTYPE As String

        'Generate ngau nhien loai lenh, khoi luong va gia
        Dim v_obj As New Random
        v_lngTEMP = v_obj.Next(3)
        If v_lngTEMP = 1 Then
            v_strEXECTYPE = "NB"
        Else
            v_strEXECTYPE = "NS"
        End If
        v_lngQTTY = v_obj.Next(1, 5) * 50   'Khoi luong tu 10 den 50 luong
        v_lngPRICE = v_obj.Next(170, 180) * 100 'Gia tu 17 den 18
        v_strAccount = Strings.Right("00000000" & v_obj.Next(1, 20), 8) 'tai khoan tu 1 den 20

        'BUILD TRANSACTION & SUBMIT
        Dim v_strXMLBuilder As New StringBuilder
        v_strXMLBuilder.Append("<Order CLASS='PLACEORDER'>" + ControlChars.CrLf)
        v_strXMLBuilder.Append("<AFACCTNO>" & v_strAccount & "</AFACCTNO>" + ControlChars.CrLf)
        v_strXMLBuilder.Append("<EXECTYPE>" + v_strEXECTYPE + "</EXECTYPE>" + ControlChars.CrLf)
        v_strXMLBuilder.Append("<TRADINGPWD>vodanh</TRADINGPWD>" + ControlChars.CrLf)
        v_strXMLBuilder.Append("<SYMBOL>SJC</SYMBOL>" + ControlChars.CrLf)
        v_strXMLBuilder.Append("<CODEID>000001</CODEID>" + ControlChars.CrLf)
        v_strXMLBuilder.Append("<QUANTITY>" + v_lngQTTY.ToString + "</QUANTITY>" + ControlChars.CrLf)
        v_strXMLBuilder.Append("<QUOTEPRICE>" + v_lngPRICE.ToString + "</QUOTEPRICE>" + ControlChars.CrLf)
        v_strXMLBuilder.Append("<PRICE>" + v_lngPRICE.ToString + "</PRICE>" + ControlChars.CrLf)
        v_strXMLBuilder.Append("<PRICETYPE>LO</PRICETYPE>" + ControlChars.CrLf)
        v_strXMLBuilder.Append("<TIMETYPE>T</TIMETYPE>" + ControlChars.CrLf)
        v_strXMLBuilder.Append("<BOOK>A</BOOK>" + ControlChars.CrLf)
        v_strXMLBuilder.Append("</Order>")
        Dim v_strMessage As String = "<RootTrade FUNCNAME='PLACEORDER'><objPARA></objPARA><objBODY>" + v_strXMLBuilder.ToString + "</objBODY></RootTrade>"
        Dim v_lngReturn As Long = SendMessage2Host(v_strMessage) 'v_ws.RequestMessage(v_strMessage)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Run()
    End Sub

    Private Sub tmLoadTest_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmLoadTest.Tick
        If v_blnLoadTest Then
            v_cntorder = v_cntorder + 1
            If v_cntorder <= v_numberorders Then
                Me.Text = v_tag + "." + v_cntorder.ToString
                TestPlaceOrder()
            Else
                v_blnLoadTest = False
                v_cntorder = 0
                tmLoadTest.Enabled = False
                v_strEndTime = Now.ToLongTimeString
                Me.lblFeedback.Text = "[Start at: " & v_strStartTime & "] [Finish at: " & v_strEndTime & "]"
                v_strStartTime = String.Empty
                v_strEndTime = String.Empty
            End If
        Else
            v_cntorder = 0
        End If
    End Sub
End Class
