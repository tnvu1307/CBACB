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
Friend Class frmProductManagement_VN
    
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
                Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("_DIRECT.frmProductManagement-VN", GetType(frmProductManagement_VN).Assembly)
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
    '''  Looks up a localized string similar to Thêm mới.
    '''</summary>
    Friend Shared ReadOnly Property ExecuteFlag_AddNew() As String
        Get
            Return ResourceManager.GetString("ExecuteFlag.AddNew", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Xoá.
    '''</summary>
    Friend Shared ReadOnly Property ExecuteFlag_Delete() As String
        Get
            Return ResourceManager.GetString("ExecuteFlag.Delete", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Sửa.
    '''</summary>
    Friend Shared ReadOnly Property ExecuteFlag_Edit() As String
        Get
            Return ResourceManager.GetString("ExecuteFlag.Edit", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Xem.
    '''</summary>
    Friend Shared ReadOnly Property ExecuteFlag_View() As String
        Get
            Return ResourceManager.GetString("ExecuteFlag.View", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to 4.
    '''</summary>
    Friend Shared ReadOnly Property frmSearch_btnAdd() As String
        Get
            Return ResourceManager.GetString("frmSearch.btnAdd", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to BACK.
    '''</summary>
    Friend Shared ReadOnly Property frmSearch_btnBACK() As String
        Get
            Return ResourceManager.GetString("frmSearch.btnBACK", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Kết xuất.
    '''</summary>
    Friend Shared ReadOnly Property frmSearch_btnExport() As String
        Get
            Return ResourceManager.GetString("frmSearch.btnExport", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to NEXT.
    '''</summary>
    Friend Shared ReadOnly Property frmSearch_btnNEXT() As String
        Get
            Return ResourceManager.GetString("frmSearch.btnNEXT", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to 3.
    '''</summary>
    Friend Shared ReadOnly Property frmSearch_btnRemove() As String
        Get
            Return ResourceManager.GetString("frmSearch.btnRemove", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to 7.
    '''</summary>
    Friend Shared ReadOnly Property frmSearch_btnRemoveAll() As String
        Get
            Return ResourceManager.GetString("frmSearch.btnRemoveAll", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to &amp;Tìm kiếm.
    '''</summary>
    Friend Shared ReadOnly Property frmSearch_btnSearch() As String
        Get
            Return ResourceManager.GetString("frmSearch.btnSearch", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Đồng ý xoá dữ liệu?.
    '''</summary>
    Friend Shared ReadOnly Property frmSearch_DelConfirm() As String
        Get
            Return ResourceManager.GetString("frmSearch.DelConfirm", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Xoá dữ liệu thành công!.
    '''</summary>
    Friend Shared ReadOnly Property frmSearch_DelSuccess() As String
        Get
            Return ResourceManager.GetString("frmSearch.DelSuccess", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Kết xuất dữ liệu thành công!.
    '''</summary>
    Friend Shared ReadOnly Property frmSearch_ExportSuccessful() As String
        Get
            Return ResourceManager.GetString("frmSearch.ExportSuccessful", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Đây là footer, không thể xem, sửa, xoá dữ liệu!.
    '''</summary>
    Friend Shared ReadOnly Property frmSearch_Footer() As String
        Get
            Return ResourceManager.GetString("frmSearch.Footer", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Điều kiện:.
    '''</summary>
    Friend Shared ReadOnly Property frmSearch_grbCondition() As String
        Get
            Return ResourceManager.GetString("frmSearch.grbCondition", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Danh sách điều kiện tìm kiếm:.
    '''</summary>
    Friend Shared ReadOnly Property frmSearch_grbConditionList() As String
        Get
            Return ResourceManager.GetString("frmSearch.grbConditionList", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Điều kiện tìm kiếm:.
    '''</summary>
    Friend Shared ReadOnly Property frmSearch_grbSearchFilter() As String
        Get
            Return ResourceManager.GetString("frmSearch.grbSearchFilter", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Kết quả tìm kiếm:.
    '''</summary>
    Friend Shared ReadOnly Property frmSearch_grbSearchResult() As String
        Get
            Return ResourceManager.GetString("frmSearch.grbSearchResult", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Tiêu chí:.
    '''</summary>
    Friend Shared ReadOnly Property frmSearch_lblField() As String
        Get
            Return ResourceManager.GetString("frmSearch.lblField", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Điều kiện:.
    '''</summary>
    Friend Shared ReadOnly Property frmSearch_lblOperator() As String
        Get
            Return ResourceManager.GetString("frmSearch.lblOperator", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Giá trị:.
    '''</summary>
    Friend Shared ReadOnly Property frmSearch_lblValue() As String
        Get
            Return ResourceManager.GetString("frmSearch.lblValue", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Không có dữ liệu để kết xuất!.
    '''</summary>
    Friend Shared ReadOnly Property frmSearch_NothingToExport() As String
        Get
            Return ResourceManager.GetString("frmSearch.NothingToExport", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Phải chọn dòng thông tin cần xem, sửa, xoá!.
    '''</summary>
    Friend Shared ReadOnly Property frmSearch_NotSelected() As String
        Get
            Return ResourceManager.GetString("frmSearch.NotSelected", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Đang thực hiện tìm kiếm....
    '''</summary>
    Friend Shared ReadOnly Property frmSearch_Searching() As String
        Get
            Return ResourceManager.GetString("frmSearch.Searching", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Thêm mới.
    '''</summary>
    Friend Shared ReadOnly Property frmSearch_tbnAdd() As String
        Get
            Return ResourceManager.GetString("frmSearch.tbnAdd", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Xoá.
    '''</summary>
    Friend Shared ReadOnly Property frmSearch_tbnDelete() As String
        Get
            Return ResourceManager.GetString("frmSearch.tbnDelete", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Sửa.
    '''</summary>
    Friend Shared ReadOnly Property frmSearch_tbnEdit() As String
        Get
            Return ResourceManager.GetString("frmSearch.tbnEdit", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Thoát.
    '''</summary>
    Friend Shared ReadOnly Property frmSearch_tbnExit() As String
        Get
            Return ResourceManager.GetString("frmSearch.tbnExit", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Xem.
    '''</summary>
    Friend Shared ReadOnly Property frmSearch_tbnView() As String
        Get
            Return ResourceManager.GetString("frmSearch.tbnView", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Tổng số bản ghi tìm kiếm: .
    '''</summary>
    Friend Shared ReadOnly Property GridEx_FooterRow() As String
        Get
            Return ResourceManager.GetString("GridEx.FooterRow", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Hãy kéo cột cần nhóm vào đây! (F6: Focus to grid, F7: Prev, F8: Next, F9: Choose).
    '''</summary>
    Friend Shared ReadOnly Property GridEx_GroupByRow() As String
        Get
            Return ResourceManager.GetString("GridEx.GroupByRow", resourceCulture)
        End Get
    End Property
End Class
