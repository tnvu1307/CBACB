Public Class frmFixORDER
    Private mv_strObjectName As String
    Private mv_strLanguage As String
    Private mv_ResourceManager As Resources.ResourceManager
    Const c_ResourceManager As String = "_DIRECT.frmFixORDER-"
    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New(pv_strLanguage)
        InitializeComponent()        
        mv_ResourceManager = New Resources.ResourceManager(c_ResourceManager & UserLanguage, System.Reflection.Assembly.GetExecutingAssembly())
    End Sub

    Protected Overrides Function OnExecute() As Int32

        If Me.SearchGrid.DataRows.Count > 0 Then
            For i As Integer = 0 To SearchGrid.DataRows.Count - 1
                If SearchGrid.DataRows(i).Cells(0).Value = "X" Then
                    Dim frm As New frmDetailFixOD
                    frm.OrderId = SearchGrid.DataRows(i).Cells("ORDERID").Value.ToString.Trim()
                    frm.ModuleCode = Me.ModuleCode
                    frm.UserLanguage = Me.UserLanguage
                    frm.BranchId = Me.BranchId
                    frm.TellerId = Me.TellerId
                    frm.WsName = Me.WsName
                    frm.IpAddress = Me.IpAddress
                    frm.ShowDialog(Me)
                    Exit For
                End If
            Next
        End If
    End Function
End Class
