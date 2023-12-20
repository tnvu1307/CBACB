Imports HostCommonLibrary
Imports DataAccessLayer

'Imports System.EnterpriseServices
'<JustInTimeActivation(False), _
'Transaction(TransactionOption.Supported), _
'ObjectPooling(Enabled:=True, MinPoolSize:=30)> _
Public Class CFCONTACT
 Inherits CoreBusiness.Maintain

    Public Sub New()
        ATTR_TABLE = "CFCONTACT"
    End Sub
#Region " Overrides functions "

#End Region

End Class
