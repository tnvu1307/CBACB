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
Friend Class frmRptAssign_EN
    
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
                Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("_DIRECT.frmRptAssign-EN", GetType(frmRptAssign_EN).Assembly)
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
    '''  Looks up a localized string similar to Report Assignment.
    '''</summary>
    Friend Shared ReadOnly Property frmRptAssign() As String
        Get
            Return ResourceManager.GetString("frmRptAssign", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to View information/create report.
    '''</summary>
    Friend Shared ReadOnly Property frmRptAssign_ckbADD() As String
        Get
            Return ResourceManager.GetString("frmRptAssign.ckbADD", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Delete.
    '''</summary>
    Friend Shared ReadOnly Property frmRptAssign_ckbDELETE() As String
        Get
            Return ResourceManager.GetString("frmRptAssign.ckbDELETE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Print.
    '''</summary>
    Friend Shared ReadOnly Property frmRptAssign_ckbPRINT() As String
        Get
            Return ResourceManager.GetString("frmRptAssign.ckbPRINT", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Register.
    '''</summary>
    Friend Shared ReadOnly Property frmRptAssign_ckbREGISTER() As String
        Get
            Return ResourceManager.GetString("frmRptAssign.ckbREGISTER", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to View.
    '''</summary>
    Friend Shared ReadOnly Property frmRptAssign_ckbVIEW() As String
        Get
            Return ResourceManager.GetString("frmRptAssign.ckbVIEW", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Access right.
    '''</summary>
    Friend Shared ReadOnly Property frmRptAssign_grbAccessRight() As String
        Get
            Return ResourceManager.GetString("frmRptAssign.grbAccessRight", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Report assignment for user: .
    '''</summary>
    Friend Shared ReadOnly Property frmRptAssign_lblCaption() As String
        Get
            Return ResourceManager.GetString("frmRptAssign.lblCaption", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Assign fail!.
    '''</summary>
    Friend Shared ReadOnly Property frmRptAssign_SavingFailed() As String
        Get
            Return ResourceManager.GetString("frmRptAssign.SavingFailed", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Report assignment successful!.
    '''</summary>
    Friend Shared ReadOnly Property frmRptAssign_SavingSuccess() As String
        Get
            Return ResourceManager.GetString("frmRptAssign.SavingSuccess", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to &amp;Cancel.
    '''</summary>
    Friend Shared ReadOnly Property frmRptAssign_tbnCancel() As String
        Get
            Return ResourceManager.GetString("frmRptAssign.tbnCancel", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to &amp;Save.
    '''</summary>
    Friend Shared ReadOnly Property frmRptAssign_tbnSave() As String
        Get
            Return ResourceManager.GetString("frmRptAssign.tbnSave", resourceCulture)
        End Get
    End Property
End Class
