Imports CommonLibrary

Public Class frmMsgBoxData
    Private mv_resourceManager As Resources.ResourceManager
    Public Const c_RootNamespace = "Appcore"

    Private v_strReturn As String

    Public Property ReturnText() As String
        Get
            Return v_strReturn
        End Get
        Set(ByVal Value As String)
            v_strReturn = Value
        End Set
    End Property


    Public Sub New(ByVal pv_strTitle As String, ByVal pv_strMsg As String, Optional ByVal pv_strLanguage As String = "VN")
        MyBase.New()
        Try
            ' This call is required by the Windows Form Designer.
            InitializeComponent()
            mv_resourceManager = New Resources.ResourceManager(c_RootNamespace & "." & Me.Name & "-" & pv_strLanguage, System.Reflection.Assembly.GetExecutingAssembly())
            Me.Text = pv_strTitle
            Me.lblMsg.Text = pv_strMsg
            Me.btnCancel.Text = mv_resourceManager.GetString("btnCancel")
            Me.btnOK.Text = mv_resourceManager.GetString("btnOK")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Me.rtbMsgReturn.Text.Trim.Length = 0 Then
            MsgBox(mv_resourceManager.GetString("ReturnValueIsNull"), MsgBoxStyle.OkOnly, Me.Text)
            rtbMsgReturn.Focus()
            Exit Sub
        End If
        ReturnText = Me.rtbMsgReturn.Text
        Dispose()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Dispose()
    End Sub
End Class