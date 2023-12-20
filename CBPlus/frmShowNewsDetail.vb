Public Class frmShowNewsDetail
    ' Fields...
    Private _newTitle As string
    Private _newDetail As string

    Public Property NewDetail() As string
        Get
            Return _newDetail
        End Get
        Set(ByVal Value As string)
            _newDetail = Value
        End Set
    End Property

    Public Property NewTitle() As string
        Get
            Return _newTitle
        End Get
        Set(ByVal Value As string)
            _newTitle = Value
        End Set
    End Property


    Private Sub frmShowNewsDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = NewTitle
        Me.reDetail.HtmlText = NewDetail
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class