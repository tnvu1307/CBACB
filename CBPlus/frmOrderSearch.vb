Imports CommonLibrary

Public Class frmOrderSearch
    Inherits AppCore.frmSearch

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal pv_strLanguage As String)
        MyBase.New(pv_strLanguage)

        'This call is required by the Windows Form Designer.
        InitializeComponent()

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

#Region " Overrides "
    Protected Overrides Function ShowForm(ByVal pv_intExecFlag As Integer) As DialogResult
        Dim v_strFullObjName, v_strOODSTATUS As String
        MyBase.ShowForm(pv_intExecFlag)

        Try
            If pv_intExecFlag <> ExecuteFlag.Delete Then
                If pv_intExecFlag <> ExecuteFlag.AddNew Then
                    If (SearchGrid.CurrentRow Is Nothing) Then
                        MsgBox(ResourceManager.GetString("frmSearch.NotSelected"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text)
                        Exit Function
                    End If
                    If (SearchGrid.CurrentRow Is SearchGrid.FixedFooterRows.Item(0)) Then
                        MsgBox(ResourceManager.GetString("frmSearch.Footer"), MsgBoxStyle.Information + MsgBoxStyle.OKOnly, Me.Text)
                        Exit Function
                    End If
                End If

                v_strOODSTATUS = CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells("OODSTATUS").Value()
                If v_strOODSTATUS = "B" Then
                    MessageBox.Show("This order already in use by other user, can't view", "Can't view", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Function
                End If

                Dim v_frm As New frmOOD
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
                v_frm.AuthString = AuthString
                v_frm.BranchId = BranchId
                v_frm.BusDate = Me.BusDate
                v_frm.KeyFieldName = KeyColumn
                v_frm.KeyFieldType = KeyFieldType
                If pv_intExecFlag <> ExecuteFlag.AddNew Then
                    v_frm.KeyFieldValue = Replace(Trim(CType(SearchGrid.CurrentRow, Xceed.Grid.DataRow).Cells(KeyColumn).Value), ".", String.Empty)
                End If

                Dim frmResult As DialogResult = v_frm.ShowDialog()
                Return frmResult

                OnSearch()


            End If
        Catch ex As Exception
            LogError.Write("Error source: " & ex.Source & vbNewLine _
                         & "Error code: System error!" & vbNewLine _
                         & "Error message: " & ex.Message, EventLogEntryType.Error)
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OKOnly, gc_ApplicationTitle)
        End Try
    End Function
    Protected Overrides Function OnQuery() As Integer
        Try
            Dim v_strView As String
            If Len(Trim(AuthString)) > 0 Then
                v_strView = Mid(Trim(AuthString), 1, 1)
                If v_strView = "Y" Then
                    ShowForm(ExecuteFlag.View)
                Else
                    Return ERR_SYSTEM_OK
                End If
            End If
            Return 1
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region



End Class
