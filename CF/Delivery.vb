Imports HostCommonLibrary
Imports System.Text
Imports System.IO
Imports System.Security.Cryptography
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Runtime.Serialization
Imports System.Web.Mail

Public Class Delivery

    Public Shared Function SendMail(ByVal v_strSignature As String, ByVal FromEmail As String, ByVal ToEmail As String, ByVal Subject As String,
        ByVal UserName As String, ByVal UserPassword As String,
        ByVal Body As String, ByVal SmtpServer As String, Optional ByVal attachFiles As ArrayList = Nothing, Optional ByVal v_StrHeader As String = "") As Boolean

    End Function

End Class

