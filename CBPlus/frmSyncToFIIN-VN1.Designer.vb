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
Friend Class frmSyncToFIIN_VN
    
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
                Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("_DIRECT.frmSyncToFIIN-VN", GetType(frmSyncToFIIN_VN).Assembly)
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
    '''  Looks up a localized string similar to Thoát.
    '''</summary>
    Friend Shared ReadOnly Property _exit() As String
        Get
            Return ResourceManager.GetString("exit", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Thêm dòng.
    '''</summary>
    Friend Shared ReadOnly Property ADD() As String
        Get
            Return ResourceManager.GetString("ADD", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Thêm mới dữ liệu thành công!.
    '''</summary>
    Friend Shared ReadOnly Property AddnewSuccessful() As String
        Get
            Return ResourceManager.GetString("AddnewSuccessful", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Địa chỉ.
    '''</summary>
    Friend Shared ReadOnly Property ADDRESS() As String
        Get
            Return ResourceManager.GetString("ADDRESS", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Giá trị giao dịch phải lớn hơn 0.
    '''</summary>
    Friend Shared ReadOnly Property AMOUNTERR() As String
        Get
            Return ResourceManager.GetString("AMOUNTERR", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Duyệt.
    '''</summary>
    Friend Shared ReadOnly Property Approve() As String
        Get
            Return ResourceManager.GetString("Approve", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Duyệt dữ liệu thành công.
    '''</summary>
    Friend Shared ReadOnly Property ApproveSuccessful() As String
        Get
            Return ResourceManager.GetString("ApproveSuccessful", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Đồng bộ.
    '''</summary>
    Friend Shared ReadOnly Property btnsync() As String
        Get
            Return ResourceManager.GetString("btnsync", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Mã sự kiện.
    '''</summary>
    Friend Shared ReadOnly Property CAID() As String
        Get
            Return ResourceManager.GetString("CAID", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized resource of type System.Data.DataTable similar to COMBOBOX.
    '''</summary>
    Friend Shared ReadOnly Property cboLink_ComboData() As System.Data.DataTable
        Get
            Dim obj As Object = ResourceManager.GetObject("cboLink.ComboData", resourceCulture)
            Return CType(obj,System.Data.DataTable)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Xác nhận.
    '''</summary>
    Friend Shared ReadOnly Property confirm() As String
        Get
            Return ResourceManager.GetString("confirm", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Số tài khoản giao dịch.
    '''</summary>
    Friend Shared ReadOnly Property Custodycd() As String
        Get
            Return ResourceManager.GetString("Custodycd", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Xóa dòng.
    '''</summary>
    Friend Shared ReadOnly Property DEL() As String
        Get
            Return ResourceManager.GetString("DEL", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Diễn giải.
    '''</summary>
    Friend Shared ReadOnly Property desc() As String
        Get
            Return ResourceManager.GetString("desc", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Chưa đủ thông tin để thực hiện!.
    '''</summary>
    Friend Shared ReadOnly Property EMPTYVOTING() As String
        Get
            Return ResourceManager.GetString("EMPTYVOTING", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Ghi nhận kết quả đại hội.
    '''</summary>
    Friend Shared ReadOnly Property frmCAVOTING() As String
        Get
            Return ResourceManager.GetString("frmCAVOTING", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Đồng bộ dữ liệu về FIIN.
    '''</summary>
    Friend Shared ReadOnly Property frmSyncToFIIN() As String
        Get
            Return ResourceManager.GetString("frmSyncToFIIN", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Thông tin chung.
    '''</summary>
    Friend Shared ReadOnly Property genaraletf() As String
        Get
            Return ResourceManager.GetString("genaraletf", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Từ ngày.
    '''</summary>
    Friend Shared ReadOnly Property lblFr() As String
        Get
            Return ResourceManager.GetString("lblFr", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Đến ngày.
    '''</summary>
    Friend Shared ReadOnly Property lblTo() As String
        Get
            Return ResourceManager.GetString("lblTo", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Loại.
    '''</summary>
    Friend Shared ReadOnly Property lblType() As String
        Get
            Return ResourceManager.GetString("lblType", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Đồng bộ thất bại!.
    '''</summary>
    Friend Shared ReadOnly Property SyncFail() As String
        Get
            Return ResourceManager.GetString("SyncFail", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Đồng bộ thành công!.
    '''</summary>
    Friend Shared ReadOnly Property SyncSuccessful() As String
        Get
            Return ResourceManager.GetString("SyncSuccessful", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Tạo giao dịch thành công. .
    '''</summary>
    Friend Shared ReadOnly Property TRANSSUCCESS() As String
        Get
            Return ResourceManager.GetString("TRANSSUCCESS", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Giao dịch cần kiểm soát duyệt !.
    '''</summary>
    Friend Shared ReadOnly Property TRANSSUCCESS1() As String
        Get
            Return ResourceManager.GetString("TRANSSUCCESS1", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Thông tin chung.
    '''</summary>
    Friend Shared ReadOnly Property TTC() As String
        Get
            Return ResourceManager.GetString("TTC", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Mã sự kiện không được để trống!.
    '''</summary>
    Friend Shared ReadOnly Property txtCAID() As String
        Get
            Return ResourceManager.GetString("txtCAID", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Tỷ lệ tán thành không được âm!.
    '''</summary>
    Friend Shared ReadOnly Property valueRATE() As String
        Get
            Return ResourceManager.GetString("valueRATE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Giá trị không hợp lệ!.
    '''</summary>
    Friend Shared ReadOnly Property valueRATE1() As String
        Get
            Return ResourceManager.GetString("valueRATE1", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Tỷ lệ tán thành không được để trống!.
    '''</summary>
    Friend Shared ReadOnly Property valueRATEEMPTY() As String
        Get
            Return ResourceManager.GetString("valueRATEEMPTY", resourceCulture)
        End Get
    End Property
End Class
