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
Friend Class frmLookup_VN
    
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
                Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("FLEX.frmLookup-VN", GetType(frmLookup_VN).Assembly)
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
    '''  Looks up a localized string similar to Mô tả.
    '''</summary>
    Friend Shared ReadOnly Property DESCRIPTION() As String
        Get
            Return ResourceManager.GetString("DESCRIPTION", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Hiển thị.
    '''</summary>
    Friend Shared ReadOnly Property DISPLAY() As String
        Get
            Return ResourceManager.GetString("DISPLAY", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Tra cứu.
    '''</summary>
    Friend Shared ReadOnly Property frmLookup() As String
        Get
            Return ResourceManager.GetString("frmLookup", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Đóng.
    '''</summary>
    Friend Shared ReadOnly Property frmLookup_btnCANCEL() As String
        Get
            Return ResourceManager.GetString("frmLookup.btnCANCEL", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Đồng ý.
    '''</summary>
    Friend Shared ReadOnly Property frmLookup_btnOK() As String
        Get
            Return ResourceManager.GetString("frmLookup.btnOK", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Tìm kiếm nhanh:.
    '''</summary>
    Friend Shared ReadOnly Property frmLookup_lblSearch() As String
        Get
            Return ResourceManager.GetString("frmLookup.lblSearch", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Không tìm thấy dữ liệu. Bạn có muốn tìm từ đầu danh sách không?.
    '''</summary>
    Friend Shared ReadOnly Property frmLookup_SearchConfirm() As String
        Get
            Return ResourceManager.GetString("frmLookup.SearchConfirm", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Bắt đầu bằng.
    '''</summary>
    Friend Shared ReadOnly Property SearchOption_BeginWith() As String
        Get
            Return ResourceManager.GetString("SearchOption.BeginWith", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Chứa.
    '''</summary>
    Friend Shared ReadOnly Property SearchOption_Contains() As String
        Get
            Return ResourceManager.GetString("SearchOption.Contains", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Giá trị.
    '''</summary>
    Friend Shared ReadOnly Property VALUECD() As String
        Get
            Return ResourceManager.GetString("VALUECD", resourceCulture)
        End Get
    End Property
End Class
