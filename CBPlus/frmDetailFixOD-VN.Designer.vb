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
Friend Class frmDetailFixOD_VN
    
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
                Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("_DIRECT.frmDetailFixOD-VN", GetType(frmDetailFixOD_VN).Assembly)
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
    '''  Looks up a localized string similar to Số tiểu khoản.
    '''</summary>
    Friend Shared ReadOnly Property AFACCTNO() As String
        Get
            Return ResourceManager.GetString("AFACCTNO", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Số tiểu khoản không hợp lệ.
    '''</summary>
    Friend Shared ReadOnly Property Afacctno_is_invalid() As String
        Get
            Return ResourceManager.GetString("Afacctno_is_invalid", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Vui lòng duyệt giao dịch.
    '''</summary>
    Friend Shared ReadOnly Property Approve_message() As String
        Get
            Return ResourceManager.GetString("Approve_message", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Mua hoặc bán.
    '''</summary>
    Friend Shared ReadOnly Property BORS() As String
        Get
            Return ResourceManager.GetString("BORS", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to &amp;Thoát.
    '''</summary>
    Friend Shared ReadOnly Property btnCancel() As String
        Get
            Return ResourceManager.GetString("btnCancel", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Thực hiện.
    '''</summary>
    Friend Shared ReadOnly Property btnExecute() As String
        Get
            Return ResourceManager.GetString("btnExecute", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to &amp;Chấp nhận.
    '''</summary>
    Friend Shared ReadOnly Property btnOK() As String
        Get
            Return ResourceManager.GetString("btnOK", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Số lưu ký.
    '''</summary>
    Friend Shared ReadOnly Property CUSTODYCD() As String
        Get
            Return ResourceManager.GetString("CUSTODYCD", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Chuyển lệnh.
    '''</summary>
    Friend Shared ReadOnly Property DESC() As String
        Get
            Return ResourceManager.GetString("DESC", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to KL điều chỉnh.
    '''</summary>
    Friend Shared ReadOnly Property EDITEDQTTY() As String
        Get
            Return ResourceManager.GetString("EDITEDQTTY", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Khối lượng điều chỉnh phải nhỏ hơn khối lượng khớp.
    '''</summary>
    Friend Shared ReadOnly Property EditedQtty_mustbe_smaller() As String
        Get
            Return ResourceManager.GetString("EditedQtty_mustbe_smaller", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Chuyển lệnh.
    '''</summary>
    Friend Shared ReadOnly Property frmDetailFixOD() As String
        Get
            Return ResourceManager.GetString("frmDetailFixOD", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Tổng số bản ghi:.
    '''</summary>
    Friend Shared ReadOnly Property GridEx_FooterRow() As String
        Get
            Return ResourceManager.GetString("GridEx.FooterRow", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Kéo cột để nhóm (F6:vào lưới, F9: Tìm kiếm).
    '''</summary>
    Friend Shared ReadOnly Property GridEx_GroupByRow() As String
        Get
            Return ResourceManager.GetString("GridEx.GroupByRow", resourceCulture)
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
    '''  Looks up a localized string similar to Số tiểu khoản chuyển đến.
    '''</summary>
    Friend Shared ReadOnly Property lblAFACCTNO() As String
        Get
            Return ResourceManager.GetString("lblAFACCTNO", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Số lưu ký gốc.
    '''</summary>
    Friend Shared ReadOnly Property lblCUSTODYCD() As String
        Get
            Return ResourceManager.GetString("lblCUSTODYCD", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to KL điều chỉnh.
    '''</summary>
    Friend Shared ReadOnly Property lblEditQuantity() As String
        Get
            Return ResourceManager.GetString("lblEditQuantity", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Số hiệu lệnh.
    '''</summary>
    Friend Shared ReadOnly Property lblOrderID() As String
        Get
            Return ResourceManager.GetString("lblOrderID", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Giá khớp.
    '''</summary>
    Friend Shared ReadOnly Property lblPrice() As String
        Get
            Return ResourceManager.GetString("lblPrice", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Khối lượng khớp.
    '''</summary>
    Friend Shared ReadOnly Property lblQuantity() As String
        Get
            Return ResourceManager.GetString("lblQuantity", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Trade lot.
    '''</summary>
    Friend Shared ReadOnly Property lblTradeLot() As String
        Get
            Return ResourceManager.GetString("lblTradeLot", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Lô không hợp lệ.
    '''</summary>
    Friend Shared ReadOnly Property Lot_is_invalid() As String
        Get
            Return ResourceManager.GetString("Lot_is_invalid", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Giá khớp.
    '''</summary>
    Friend Shared ReadOnly Property MATCHPRICE() As String
        Get
            Return ResourceManager.GetString("MATCHPRICE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to KL khớp.
    '''</summary>
    Friend Shared ReadOnly Property MATCHQTTY() As String
        Get
            Return ResourceManager.GetString("MATCHQTTY", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Yêu cầu nhập số!.
    '''</summary>
    Friend Shared ReadOnly Property Number_is_required() As String
        Get
            Return ResourceManager.GetString("Number_is_required", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Số hiệu lệnh.
    '''</summary>
    Friend Shared ReadOnly Property ORGORDERID() As String
        Get
            Return ResourceManager.GetString("ORGORDERID", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Giá đặt.
    '''</summary>
    Friend Shared ReadOnly Property PRICE() As String
        Get
            Return ResourceManager.GetString("PRICE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to KL đặt.
    '''</summary>
    Friend Shared ReadOnly Property QTTY() As String
        Get
            Return ResourceManager.GetString("QTTY", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Mã Refconfirm.
    '''</summary>
    Friend Shared ReadOnly Property REFCONFIRMNUMBER() As String
        Get
            Return ResourceManager.GetString("REFCONFIRMNUMBER", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to KL chờ khớp.
    '''</summary>
    Friend Shared ReadOnly Property REMAINQTTY() As String
        Get
            Return ResourceManager.GetString("REMAINQTTY", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Mã chứng khoán.
    '''</summary>
    Friend Shared ReadOnly Property SYMBOL() As String
        Get
            Return ResourceManager.GetString("SYMBOL", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Lô giao dịch.
    '''</summary>
    Friend Shared ReadOnly Property TRADELOT() As String
        Get
            Return ResourceManager.GetString("TRADELOT", resourceCulture)
        End Get
    End Property
End Class
