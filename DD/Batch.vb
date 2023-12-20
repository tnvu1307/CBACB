Imports HostCommonLibrary
Imports DataAccessLayer
Public Class Batch
    Inherits CoreBusiness.Batch
    Public Sub New()
        ATTR_MODULE = "DD"
        ATTR_TABLE = "DDMAST"
    End Sub
End Class
