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

Namespace My.Resources
    
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
    Friend Class frmMail_VN
        
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
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("_DIRECT.frmMail-VN", GetType(frmMail_VN).Assembly)
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
        '''  Looks up a localized string similar to Đường dẫn đến Thư mục báo cáo không được để trống  !.
        '''</summary>
        Friend Shared ReadOnly Property ATTACHMENTSNOTNULL() As String
            Get
                Return ResourceManager.GetString("ATTACHMENTSNOTNULL", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Nội dung Email không được để trống !.
        '''</summary>
        Friend Shared ReadOnly Property BODYNOTNULL() As String
            Get
                Return ResourceManager.GetString("BODYNOTNULL", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to &amp;Broadcast.
        '''</summary>
        Friend Shared ReadOnly Property frmMail_btnBroadcast() As String
            Get
                Return ResourceManager.GetString("frmMail.btnBroadcast", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to &amp;Đóng.
        '''</summary>
        Friend Shared ReadOnly Property frmMail_btnClose() As String
            Get
                Return ResourceManager.GetString("frmMail.btnClose", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to &amp;Gửi mail.
        '''</summary>
        Friend Shared ReadOnly Property frmMail_btnSubcribed() As String
            Get
                Return ResourceManager.GetString("frmMail.btnSubcribed", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Parameters.
        '''</summary>
        Friend Shared ReadOnly Property frmMail_grbParameters() As String
            Get
                Return ResourceManager.GetString("frmMail.grbParameters", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Attachments.
        '''</summary>
        Friend Shared ReadOnly Property frmMail_grpAttachments() As String
            Get
                Return ResourceManager.GetString("frmMail.grpAttachments", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Attachment folder:.
        '''</summary>
        Friend Shared ReadOnly Property frmMail_lblATTACHMENTS() As String
            Get
                Return ResourceManager.GetString("frmMail.lblATTACHMENTS", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Nội dung:.
        '''</summary>
        Friend Shared ReadOnly Property frmMail_lblBODYFILE() As String
            Get
                Return ResourceManager.GetString("frmMail.lblBODYFILE", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Mailer system .
        '''</summary>
        Friend Shared ReadOnly Property frmMail_lblCaption() As String
            Get
                Return ResourceManager.GetString("frmMail.lblCaption", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Email gửi:.
        '''</summary>
        Friend Shared ReadOnly Property frmMail_lblFROM() As String
            Get
                Return ResourceManager.GetString("frmMail.lblFROM", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Mật khẩu:.
        '''</summary>
        Friend Shared ReadOnly Property frmMail_lblPASSWORD() As String
            Get
                Return ResourceManager.GetString("frmMail.lblPASSWORD", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Chữ ký.
        '''</summary>
        Friend Shared ReadOnly Property frmMail_lblPathSignature() As String
            Get
                Return ResourceManager.GetString("frmMail.lblPathSignature", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Địa chỉ Server Mail:.
        '''</summary>
        Friend Shared ReadOnly Property frmMail_lblSMTPSERVER() As String
            Get
                Return ResourceManager.GetString("frmMail.lblSMTPSERVER", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Tiêu đề:.
        '''</summary>
        Friend Shared ReadOnly Property frmMail_lblTITLE() As String
            Get
                Return ResourceManager.GetString("frmMail.lblTITLE", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to User name:.
        '''</summary>
        Friend Shared ReadOnly Property frmMail_lblUSERNAME() As String
            Get
                Return ResourceManager.GetString("frmMail.lblUSERNAME", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Địa chỉ Email gửi không được để trống !.
        '''</summary>
        Friend Shared ReadOnly Property FROMNOTNULL() As String
            Get
                Return ResourceManager.GetString("FROMNOTNULL", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Mật khẩu Email không được để trống !.
        '''</summary>
        Friend Shared ReadOnly Property PASSWORDNOTNULL() As String
            Get
                Return ResourceManager.GetString("PASSWORDNOTNULL", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Mail server không được để trống !.
        '''</summary>
        Friend Shared ReadOnly Property SMTPSERVERNOTNULL() As String
            Get
                Return ResourceManager.GetString("SMTPSERVERNOTNULL", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Tiêu đề của Email không được để trống !.
        '''</summary>
        Friend Shared ReadOnly Property TITLENOTNULL() As String
            Get
                Return ResourceManager.GetString("TITLENOTNULL", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to User Email không được để trống !.
        '''</summary>
        Friend Shared ReadOnly Property USERNAMENOTNULL() As String
            Get
                Return ResourceManager.GetString("USERNAMENOTNULL", resourceCulture)
            End Get
        End Property
    End Class
End Namespace
