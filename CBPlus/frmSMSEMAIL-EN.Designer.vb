﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.5466
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Class frmSMSEMAIL_EN
        
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
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("_DIRECT.frmSMSEMAIL-EN", GetType(frmSMSEMAIL_EN).Assembly)
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
        '''  Looks up a localized string similar to Tìm File.
        '''</summary>
        Friend Shared ReadOnly Property btnBROWSER() As String
            Get
                Return ResourceManager.GetString("btnBROWSER", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Thoát.
        '''</summary>
        Friend Shared ReadOnly Property btnCancel() As String
            Get
                Return ResourceManager.GetString("btnCancel", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Gửi.
        '''</summary>
        Friend Shared ReadOnly Property btnSent() As String
            Get
                Return ResourceManager.GetString("btnSent", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Bạn chưa chọn đường dẫn đến file danh sách số điện thoại.
        '''</summary>
        Friend Shared ReadOnly Property CHOOSEFILEPATH() As String
            Get
                Return ResourceManager.GetString("CHOOSEFILEPATH", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Gửi SMS theo danh sách.
        '''</summary>
        Friend Shared ReadOnly Property frmSMSEMAIL() As String
            Get
                Return ResourceManager.GetString("frmSMSEMAIL", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Nội dung SMS.
        '''</summary>
        Friend Shared ReadOnly Property lblDESC() As String
            Get
                Return ResourceManager.GetString("lblDESC", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Từ ngày :.
        '''</summary>
        Friend Shared ReadOnly Property lblFROMDATE() As String
            Get
                Return ResourceManager.GetString("lblFROMDATE", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Đường dẫn file: .
        '''</summary>
        Friend Shared ReadOnly Property lblLISTPHONE() As String
            Get
                Return ResourceManager.GetString("lblLISTPHONE", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Ngày giao dịch trở lại.
        '''</summary>
        Friend Shared ReadOnly Property lblRETURNTRADE() As String
            Get
                Return ResourceManager.GetString("lblRETURNTRADE", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to đến ngày :.
        '''</summary>
        Friend Shared ReadOnly Property lblTODATE() As String
            Get
                Return ResourceManager.GetString("lblTODATE", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Loại tin SMS: .
        '''</summary>
        Friend Shared ReadOnly Property lblTYPESMS() As String
            Get
                Return ResourceManager.GetString("lblTYPESMS", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Gửi SMS thành công.
        '''</summary>
        Friend Shared ReadOnly Property SMSSUCCESS() As String
            Get
                Return ResourceManager.GetString("SMSSUCCESS", resourceCulture)
            End Get
        End Property
    End Class
End Namespace
