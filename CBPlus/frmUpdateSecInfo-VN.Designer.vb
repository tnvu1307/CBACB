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
Friend Class frmUpdateSecInfo_VN
    
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
                Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("_DIRECT.frmUpdateSecInfo-VN", GetType(frmUpdateSecInfo_VN).Assembly)
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
    '''  Looks up a localized string similar to ....
    '''</summary>
    Friend Shared ReadOnly Property btnBrowse() As String
        Get
            Return ResourceManager.GetString("btnBrowse", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to &amp;Tính toán.
    '''</summary>
    Friend Shared ReadOnly Property btnCalc() As String
        Get
            Return ResourceManager.GetString("btnCalc", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to &amp;Đóng.
    '''</summary>
    Friend Shared ReadOnly Property btnCancel() As String
        Get
            Return ResourceManager.GetString("btnCancel", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to &amp;Ghi.
    '''</summary>
    Friend Shared ReadOnly Property btnOK() As String
        Get
            Return ResourceManager.GetString("btnOK", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to &amp;Đọc.
    '''</summary>
    Friend Shared ReadOnly Property btnRead() As String
        Get
            Return ResourceManager.GetString("btnRead", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Tính toán sẽ tính lại giá trần, sàn của chứng khoán dựa trên giá đóng cửa hoặc giá bình quân. Thực hiện?.
    '''</summary>
    Friend Shared ReadOnly Property CALC_CONFIRMATION() As String
        Get
            Return ResourceManager.GetString("CALC_CONFIRMATION", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to xxx.
    '''</summary>
    Friend Shared ReadOnly Property DEFAULT_VALUE() As String
        Get
            Return ResourceManager.GetString("DEFAULT_VALUE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Tên file không hợp lệ. Gõ lại tên và đường dẫn đến file hoặc click nút &lt;Browse&gt; và chọn file giá..
    '''</summary>
    Friend Shared ReadOnly Property FILENAME_MUST_VALID() As String
        Get
            Return ResourceManager.GetString("FILENAME_MUST_VALID", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Cập nhật thông tin chứng khoán.
    '''</summary>
    Friend Shared ReadOnly Property frmUpdateSecInfo() As String
        Get
            Return ResourceManager.GetString("frmUpdateSecInfo", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Files:.
    '''</summary>
    Friend Shared ReadOnly Property grbFiles() As String
        Get
            Return ResourceManager.GetString("grbFiles", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Tuỳ chọn:.
    '''</summary>
    Friend Shared ReadOnly Property grbOptions() As String
        Get
            Return ResourceManager.GetString("grbOptions", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Quote server:.
    '''</summary>
    Friend Shared ReadOnly Property grbQuoteSvr() As String
        Get
            Return ResourceManager.GetString("grbQuoteSvr", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Thông tin chứng khoán:.
    '''</summary>
    Friend Shared ReadOnly Property grbSecInfo() As String
        Get
            Return ResourceManager.GetString("grbSecInfo", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Nguồn:.
    '''</summary>
    Friend Shared ReadOnly Property grbSources() As String
        Get
            Return ResourceManager.GetString("grbSources", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Không khởi tạo được cửa sổ!.
    '''</summary>
    Friend Shared ReadOnly Property InitDialogFailed() As String
        Get
            Return ResourceManager.GetString("InitDialogFailed", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Cập nhật thông tin chứng khoán từ Quote Server hoặc các file giá..
    '''</summary>
    Friend Shared ReadOnly Property lblCaption() As String
        Get
            Return ResourceManager.GetString("lblCaption", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Chọn sàn:.
    '''</summary>
    Friend Shared ReadOnly Property lblFromCenter() As String
        Get
            Return ResourceManager.GetString("lblFromCenter", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Tên file:.
    '''</summary>
    Friend Shared ReadOnly Property lblFromFile() As String
        Get
            Return ResourceManager.GetString("lblFromFile", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Địa chỉ Server.
    '''</summary>
    Friend Shared ReadOnly Property lblServerAddress() As String
        Get
            Return ResourceManager.GetString("lblServerAddress", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Trade unit :.
    '''</summary>
    Friend Shared ReadOnly Property lblSystemTradeUnit() As String
        Get
            Return ResourceManager.GetString("lblSystemTradeUnit", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Đ.vị:.
    '''</summary>
    Friend Shared ReadOnly Property lblTradeUnit() As String
        Get
            Return ResourceManager.GetString("lblTradeUnit", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Từ file.
    '''</summary>
    Friend Shared ReadOnly Property radioFiles() As String
        Get
            Return ResourceManager.GetString("radioFiles", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Từ Quote Server.
    '''</summary>
    Friend Shared ReadOnly Property radioQuoteSvr() As String
        Get
            Return ResourceManager.GetString("radioQuoteSvr", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Bạn thực sự muốn đọc giá chứng khoán từ file file @?.
    '''</summary>
    Friend Shared ReadOnly Property READ_CONFIRMATION() As String
        Get
            Return ResourceManager.GetString("READ_CONFIRMATION", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Đọc thông tin chứng khoán từ file @ thành công!.
    '''</summary>
    Friend Shared ReadOnly Property READ_FILE_SUCCESSFULLY() As String
        Get
            Return ResourceManager.GetString("READ_FILE_SUCCESSFULLY", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Bạn thực sự muốn ghi thông tin chứng khoán?.
    '''</summary>
    Friend Shared ReadOnly Property SAVE_CONFIRMATION() As String
        Get
            Return ResourceManager.GetString("SAVE_CONFIRMATION", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Lưu thông tin chứng khoán thành công!.
    '''</summary>
    Friend Shared ReadOnly Property SAVED_STATUS() As String
        Get
            Return ResourceManager.GetString("SAVED_STATUS", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Đang ghi dòng @... Hãy chờ trong giây lát!.
    '''</summary>
    Friend Shared ReadOnly Property SAVING_STATUS() As String
        Get
            Return ResourceManager.GetString("SAVING_STATUS", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Không lưu được thông tin giá chứng khoán!.
    '''</summary>
    Friend Shared ReadOnly Property SavingFailed() As String
        Get
            Return ResourceManager.GetString("SavingFailed", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Lưu thông tin giá chứng khoán thành công!.
    '''</summary>
    Friend Shared ReadOnly Property SavingSuccessful() As String
        Get
            Return ResourceManager.GetString("SavingSuccessful", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Đơn vị phải là kiểu số!.
    '''</summary>
    Friend Shared ReadOnly Property TRADEUNIT_MUST_NUMERIC() As String
        Get
            Return ResourceManager.GetString("TRADEUNIT_MUST_NUMERIC", resourceCulture)
        End Get
    End Property
End Class