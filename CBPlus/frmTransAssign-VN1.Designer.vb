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
Friend Class frmTransAssign_VN
    
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
                Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("_DIRECT.frmTransAssign-VN", GetType(frmTransAssign_VN).Assembly)
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
    '''  Looks up a localized string similar to Phân quyền giao dịch.
    '''</summary>
    Friend Shared ReadOnly Property frmTransAssign() As String
        Get
            Return ResourceManager.GetString("frmTransAssign", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Hạn mức thanh toán phải là số dương!.
    '''</summary>
    Friend Shared ReadOnly Property frmTransAssign_CashierMsg() As String
        Get
            Return ResourceManager.GetString("frmTransAssign.CashierMsg", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Hạn mức duyệt rủi ro phải là số dương!.
    '''</summary>
    Friend Shared ReadOnly Property frmTransAssign_CheckerMsg() As String
        Get
            Return ResourceManager.GetString("frmTransAssign.CheckerMsg", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Phân quyền.
    '''</summary>
    Friend Shared ReadOnly Property frmTransAssign_grbTransAssign() As String
        Get
            Return ResourceManager.GetString("frmTransAssign.grbTransAssign", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Phân quyền giao dịch cho người sử dụng: .
    '''</summary>
    Friend Shared ReadOnly Property frmTransAssign_lblCaption() As String
        Get
            Return ResourceManager.GetString("frmTransAssign.lblCaption", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Hạn mức thanh toán:.
    '''</summary>
    Friend Shared ReadOnly Property frmTransAssign_lblCASHIERLIMIT() As String
        Get
            Return ResourceManager.GetString("frmTransAssign.lblCASHIERLIMIT", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Hạn mức duyệt rủi ro:.
    '''</summary>
    Friend Shared ReadOnly Property frmTransAssign_lblCHECKERLIMIT() As String
        Get
            Return ResourceManager.GetString("frmTransAssign.lblCHECKERLIMIT", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Mã tiền tệ:.
    '''</summary>
    Friend Shared ReadOnly Property frmTransAssign_lblCURRCOD() As String
        Get
            Return ResourceManager.GetString("frmTransAssign.lblCURRCOD", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Hạn mức duyệt:.
    '''</summary>
    Friend Shared ReadOnly Property frmTransAssign_lblOFFICERLIMIT() As String
        Get
            Return ResourceManager.GetString("frmTransAssign.lblOFFICERLIMIT", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Hạn mức nhập GD:.
    '''</summary>
    Friend Shared ReadOnly Property frmTransAssign_lblTELLERLIMIT() As String
        Get
            Return ResourceManager.GetString("frmTransAssign.lblTELLERLIMIT", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Hạn mức duyệt phải là số dương!.
    '''</summary>
    Friend Shared ReadOnly Property frmTransAssign_OfficerMsg() As String
        Get
            Return ResourceManager.GetString("frmTransAssign.OfficerMsg", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Phân quyền không thành công!.
    '''</summary>
    Friend Shared ReadOnly Property frmTransAssign_SavingFailed() As String
        Get
            Return ResourceManager.GetString("frmTransAssign.SavingFailed", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Phân quyền giao dịch thành công!.
    '''</summary>
    Friend Shared ReadOnly Property frmTransAssign_SavingSuccess() As String
        Get
            Return ResourceManager.GetString("frmTransAssign.SavingSuccess", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to &amp;Thoát.
    '''</summary>
    Friend Shared ReadOnly Property frmTransAssign_tbnCancel() As String
        Get
            Return ResourceManager.GetString("frmTransAssign.tbnCancel", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to &amp;Chấp nhận.
    '''</summary>
    Friend Shared ReadOnly Property frmTransAssign_tbnSave() As String
        Get
            Return ResourceManager.GetString("frmTransAssign.tbnSave", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Hạn mức nhập giao dịch phải là số dương!.
    '''</summary>
    Friend Shared ReadOnly Property frmTransAssign_TellerMsg() As String
        Get
            Return ResourceManager.GetString("frmTransAssign.TellerMsg", resourceCulture)
        End Get
    End Property
End Class
