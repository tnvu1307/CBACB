﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System


'This class was auto-generated by the StronglyTypedResourceBuilder
'class via a tool like ResGen or Visual Studio.
'To add or remove a member, edit your .ResX file then rerun ResGen
'with the /str option, or rebuild your VS project.
'''<summary>
'''  A strongly-typed resource class, for looking up localized strings, etc.
'''</summary>
<Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0"),  _
 Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
 Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
Friend Class frmViewAcc_EN
    
    Private Shared resourceMan As Global.System.Resources.ResourceManager
    
    Private Shared resourceCulture As Global.System.Globalization.CultureInfo
    
    <Global.System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")>  _
    Friend Sub New()
        MyBase.New
    End Sub
    
    '''<summary>
    '''  Returns the cached ResourceManager instance used by this class.
    '''</summary>
    <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Friend Shared ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
        Get
            If Object.ReferenceEquals(resourceMan, Nothing) Then
                Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("_DIRECT.frmViewAcc-EN", GetType(frmViewAcc_EN).Assembly)
                resourceMan = temp
            End If
            Return resourceMan
        End Get
    End Property
    
    '''<summary>
    '''  Overrides the current thread's CurrentUICulture property for all
    '''  resource lookups using this strongly typed resource class.
    '''</summary>
    <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Friend Shared Property Culture() As Global.System.Globalization.CultureInfo
        Get
            Return resourceCulture
        End Get
        Set
            resourceCulture = value
        End Set
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Account number.
    '''</summary>
    Friend Shared ReadOnly Property ACCTNO() As String
        Get
            Return ResourceManager.GetString("ACCTNO", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Bank Account.
    '''</summary>
    Friend Shared ReadOnly Property BANKACCTNO() As String
        Get
            Return ResourceManager.GetString("BANKACCTNO", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Brank Name.
    '''</summary>
    Friend Shared ReadOnly Property BANKNAME() As String
        Get
            Return ResourceManager.GetString("BANKNAME", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Cancel.
    '''</summary>
    Friend Shared ReadOnly Property btnCancel() As String
        Get
            Return ResourceManager.GetString("btnCancel", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Connect.
    '''</summary>
    Friend Shared ReadOnly Property btnConnect() As String
        Get
            Return ResourceManager.GetString("btnConnect", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Export.
    '''</summary>
    Friend Shared ReadOnly Property btnExport() As String
        Get
            Return ResourceManager.GetString("btnExport", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to License No.
    '''</summary>
    Friend Shared ReadOnly Property CUSTID() As String
        Get
            Return ResourceManager.GetString("CUSTID", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Sub account.
    '''</summary>
    Friend Shared ReadOnly Property CUSTODYCD() As String
        Get
            Return ResourceManager.GetString("CUSTODYCD", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Export Successful.
    '''</summary>
    Friend Shared ReadOnly Property ExportSuccessful() As String
        Get
            Return ResourceManager.GetString("ExportSuccessful", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to View corebank account status on day.
    '''</summary>
    Friend Shared ReadOnly Property frmViewAcc() As String
        Get
            Return ResourceManager.GetString("frmViewAcc", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Fullname.
    '''</summary>
    Friend Shared ReadOnly Property FULLNAME() As String
        Get
            Return ResourceManager.GetString("FULLNAME", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Nothing to export.
    '''</summary>
    Friend Shared ReadOnly Property NothingToExport() As String
        Get
            Return ResourceManager.GetString("NothingToExport", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Status.
    '''</summary>
    Friend Shared ReadOnly Property STATUS() As String
        Get
            Return ResourceManager.GetString("STATUS", resourceCulture)
        End Get
    End Property
End Class
