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
<Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"),  _
 Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
 Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
Friend Class frmRMCmpBankBalance_VN
    
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
                Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("_DIRECT.frmRMCmpBankBalance-VN", GetType(frmRMCmpBankBalance_VN).Assembly)
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
    '''  Looks up a localized string similar to Đã gửi yêu cầu lấy số dư NH thành công!.
    '''</summary>
    Friend Shared ReadOnly Property BankInqSuccess() As String
        Get
            Return ResourceManager.GetString("BankInqSuccess", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Đối chiếu.
    '''</summary>
    Friend Shared ReadOnly Property bbiBalanceCompare() As String
        Get
            Return ResourceManager.GetString("bbiBalanceCompare", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Thoát.
    '''</summary>
    Friend Shared ReadOnly Property bbiClose() As String
        Get
            Return ResourceManager.GetString("bbiClose", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Kết xuất.
    '''</summary>
    Friend Shared ReadOnly Property bbiExport() As String
        Get
            Return ResourceManager.GetString("bbiExport", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Lấy số dư.
    '''</summary>
    Friend Shared ReadOnly Property bbiInqBank() As String
        Get
            Return ResourceManager.GetString("bbiInqBank", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Tự động Refresh.
    '''</summary>
    Friend Shared ReadOnly Property bciRefeshAuto() As String
        Get
            Return ResourceManager.GetString("bciRefeshAuto", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Kết xuất dữ liệu thành công!.
    '''</summary>
    Friend Shared ReadOnly Property ExportSuccessful() As String
        Get
            Return ResourceManager.GetString("ExportSuccessful", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Kết quả.
    '''</summary>
    Friend Shared ReadOnly Property gcResult() As String
        Get
            Return ResourceManager.GetString("gcResult", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Vui lòng chọn tài khoản cần lấy số dư NH!.
    '''</summary>
    Friend Shared ReadOnly Property NotChooseAcct() As String
        Get
            Return ResourceManager.GetString("NotChooseAcct", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Không có dữ liệu để kết xuất!.
    '''</summary>
    Friend Shared ReadOnly Property NothingToExport() As String
        Get
            Return ResourceManager.GetString("NothingToExport", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Số dư ngân hàng.
    '''</summary>
    Friend Shared ReadOnly Property rpBankMenu() As String
        Get
            Return ResourceManager.GetString("rpBankMenu", resourceCulture)
        End Get
    End Property
End Class
