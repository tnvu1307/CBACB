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
Friend Class frmDFGroupView_EN
    
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
                Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("_DIRECT.frmDFGroupView-EN", GetType(frmDFGroupView_EN).Assembly)
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
    '''  Looks up a localized string similar to Submit.
    '''</summary>
    Friend Shared ReadOnly Property btnSubmit() As String
        Get
            Return ResourceManager.GetString("btnSubmit", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to The release amount  exceeds the initial request!.
    '''</summary>
    Friend Shared ReadOnly Property ConfirmAmtIsBiggerThanExpectedAmt() As String
        Get
            Return ResourceManager.GetString("ConfirmAmtIsBiggerThanExpectedAmt", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Release amount is null!.
    '''</summary>
    Friend Shared ReadOnly Property ConfirmAmtIsNull() As String
        Get
            Return ResourceManager.GetString("ConfirmAmtIsNull", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to The release amount  exceeds the limit allow!.
    '''</summary>
    Friend Shared ReadOnly Property ConfirmAmtIsOverLimit() As String
        Get
            Return ResourceManager.GetString("ConfirmAmtIsOverLimit", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Cust bank field can&apos;t be null!.
    '''</summary>
    Friend Shared ReadOnly Property CustBankIsNull() As String
        Get
            Return ResourceManager.GetString("CustBankIsNull", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Release.
    '''</summary>
    Friend Shared ReadOnly Property DefaultDescription() As String
        Get
            Return ResourceManager.GetString("DefaultDescription", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to DF type not found.
    '''</summary>
    Friend Shared ReadOnly Property DFTYPEINVALID() As String
        Get
            Return ResourceManager.GetString("DFTYPEINVALID", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Amount field can&apos;t be null!.
    '''</summary>
    Friend Shared ReadOnly Property ExpectedAmtIsNull() As String
        Get
            Return ResourceManager.GetString("ExpectedAmtIsNull", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Total release amt..
    '''</summary>
    Friend Shared ReadOnly Property lblCONFIRMAMT() As String
        Get
            Return ResourceManager.GetString("lblCONFIRMAMT", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Bank.
    '''</summary>
    Friend Shared ReadOnly Property lblCUSTBANK() As String
        Get
            Return ResourceManager.GetString("lblCUSTBANK", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Credit line.
    '''</summary>
    Friend Shared ReadOnly Property lblCUSTLIMIT() As String
        Get
            Return ResourceManager.GetString("lblCUSTLIMIT", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Description.
    '''</summary>
    Friend Shared ReadOnly Property lblDESC() As String
        Get
            Return ResourceManager.GetString("lblDESC", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to DF type.
    '''</summary>
    Friend Shared ReadOnly Property lblDFTYPE() As String
        Get
            Return ResourceManager.GetString("lblDFTYPE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Expected amt.
    '''</summary>
    Friend Shared ReadOnly Property lblEXPECTEDAMT() As String
        Get
            Return ResourceManager.GetString("lblEXPECTEDAMT", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Used limit.
    '''</summary>
    Friend Shared ReadOnly Property lblINUSEDLIMIT() As String
        Get
            Return ResourceManager.GetString("lblINUSEDLIMIT", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Sources.
    '''</summary>
    Friend Shared ReadOnly Property RRTYPEDESC() As String
        Get
            Return ResourceManager.GetString("RRTYPEDESC", resourceCulture)
        End Get
    End Property
End Class
