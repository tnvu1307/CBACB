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
Friend Class frmChangeOrderCustody_EN
    
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
                Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("_DIRECT.frmChangeOrderCustody-EN", GetType(frmChangeOrderCustody_EN).Assembly)
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
    '''  Looks up a localized string similar to &amp;Exit.
    '''</summary>
    Friend Shared ReadOnly Property btnExit() As String
        Get
            Return ResourceManager.GetString("btnExit", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to &amp;OK.
    '''</summary>
    Friend Shared ReadOnly Property btnOK() As String
        Get
            Return ResourceManager.GetString("btnOK", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Order matched!Can not change!.
    '''</summary>
    Friend Shared ReadOnly Property ERR_MATCHED_ORDER() As String
        Get
            Return ResourceManager.GetString("ERR_MATCHED_ORDER", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Not enough money to buy.
    '''</summary>
    Friend Shared ReadOnly Property ERR_NENOUGHT_MONEY() As String
        Get
            Return ResourceManager.GetString("ERR_NENOUGHT_MONEY", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Not enough security to sell.
    '''</summary>
    Friend Shared ReadOnly Property ERR_NENOUGHT_STOCK() As String
        Get
            Return ResourceManager.GetString("ERR_NENOUGHT_STOCK", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Can&apos;t buy/sell same day.
    '''</summary>
    Friend Shared ReadOnly Property ERR_TRADE_BUYSELL() As String
        Get
            Return ResourceManager.GetString("ERR_TRADE_BUYSELL", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Change custody code.
    '''</summary>
    Friend Shared ReadOnly Property frmChangeOrderCustody() As String
        Get
            Return ResourceManager.GetString("frmChangeOrderCustody", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to New CustodyCD.
    '''</summary>
    Friend Shared ReadOnly Property lblNewCustodyCD() As String
        Get
            Return ResourceManager.GetString("lblNewCustodyCD", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Order ID.
    '''</summary>
    Friend Shared ReadOnly Property lblOrderID() As String
        Get
            Return ResourceManager.GetString("lblOrderID", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Do you sure to confirm send change order message?.
    '''</summary>
    Friend Shared ReadOnly Property MSG_CONFIRM() As String
        Get
            Return ResourceManager.GetString("MSG_CONFIRM", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Can&apos;t chance P/C plag.
    '''</summary>
    Friend Shared ReadOnly Property MSG_ERR_CANT_CHANGE() As String
        Get
            Return ResourceManager.GetString("MSG_ERR_CANT_CHANGE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Create message successful.
    '''</summary>
    Friend Shared ReadOnly Property MSG_SS() As String
        Get
            Return ResourceManager.GetString("MSG_SS", resourceCulture)
        End Get
    End Property
End Class
