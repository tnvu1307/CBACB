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
Friend Class frmAFSERULE_VN
    
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
                Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("_DIRECT.frmAFSERULE-VN", GetType(frmAFSERULE_VN).Assembly)
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
    '''  Looks up a localized string similar to &amp;Hiệu chỉnh.
    '''</summary>
    Friend Shared ReadOnly Property btnAdjust() As String
        Get
            Return ResourceManager.GetString("btnAdjust", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to &amp;Phân bổ.
    '''</summary>
    Friend Shared ReadOnly Property btnAllocate() As String
        Get
            Return ResourceManager.GetString("btnAllocate", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to &amp;Thoát.
    '''</summary>
    Friend Shared ReadOnly Property btnCANCEL() As String
        Get
            Return ResourceManager.GetString("btnCANCEL", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Xuống.
    '''</summary>
    Friend Shared ReadOnly Property btnDOWN() As String
        Get
            Return ResourceManager.GetString("btnDOWN", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to ?.
    '''</summary>
    Friend Shared ReadOnly Property btnGetDeal() As String
        Get
            Return ResourceManager.GetString("btnGetDeal", resourceCulture)
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
    '''  Looks up a localized string similar to Lên.
    '''</summary>
    Friend Shared ReadOnly Property btnUP() As String
        Get
            Return ResourceManager.GetString("btnUP", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Mã tham chiếu không hợp lệ.
    '''</summary>
    Friend Shared ReadOnly Property DEALINVALID() As String
        Get
            Return ResourceManager.GetString("DEALINVALID", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Khối lượng không hợp lệ!.
    '''</summary>
    Friend Shared ReadOnly Property ERR_ADDQTTY_INVALID() As String
        Get
            Return ResourceManager.GetString("ERR_ADDQTTY_INVALID", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Số tiền không hợp lệ.
    '''</summary>
    Friend Shared ReadOnly Property ERR_AMT_INFO() As String
        Get
            Return ResourceManager.GetString("ERR_AMT_INFO", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Bổ sung chứng khoán vào Deal tổng.
    '''</summary>
    Friend Shared ReadOnly Property frmAddSEToGRDeal() As String
        Get
            Return ResourceManager.GetString("frmAddSEToGRDeal", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Mã sản phẩm.
    '''</summary>
    Friend Shared ReadOnly Property lblAcType() As String
        Get
            Return ResourceManager.GetString("lblAcType", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Giá trị cần bổ sung.
    '''</summary>
    Friend Shared ReadOnly Property lblAddValue() As String
        Get
            Return ResourceManager.GetString("lblAddValue", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Số hiệu Deal.
    '''</summary>
    Friend Shared ReadOnly Property lblDealNo() As String
        Get
            Return ResourceManager.GetString("lblDealNo", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Diễn giải.
    '''</summary>
    Friend Shared ReadOnly Property lblDescription() As String
        Get
            Return ResourceManager.GetString("lblDescription", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Tổng dư nợ.
    '''</summary>
    Friend Shared ReadOnly Property lblDFAMT() As String
        Get
            Return ResourceManager.GetString("lblDFAMT", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Giá trị bổ sung.
    '''</summary>
    Friend Shared ReadOnly Property lblEXSEMor() As String
        Get
            Return ResourceManager.GetString("lblEXSEMor", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Tỷ lệ an toàn.
    '''</summary>
    Friend Shared ReadOnly Property lblIRATE() As String
        Get
            Return ResourceManager.GetString("lblIRATE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Trả phí phạt.
    '''</summary>
    Friend Shared ReadOnly Property lbllPAIDPENAFEE() As String
        Get
            Return ResourceManager.GetString("lbllPAIDPENAFEE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Tỷ lệ xử lý.
    '''</summary>
    Friend Shared ReadOnly Property lblLRATE() As String
        Get
            Return ResourceManager.GetString("lblLRATE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Tỷ lệ cảnh báo.
    '''</summary>
    Friend Shared ReadOnly Property lblMRATE() As String
        Get
            Return ResourceManager.GetString("lblMRATE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Số tiền trả gốc.
    '''</summary>
    Friend Shared ReadOnly Property lblPAIDAMT() As String
        Get
            Return ResourceManager.GetString("lblPAIDAMT", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Trả phí DV.
    '''</summary>
    Friend Shared ReadOnly Property lblPAIDFEE() As String
        Get
            Return ResourceManager.GetString("lblPAIDFEE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Trả lãi.
    '''</summary>
    Friend Shared ReadOnly Property lblPAIDINT() As String
        Get
            Return ResourceManager.GetString("lblPAIDINT", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Tiền bán.
    '''</summary>
    Friend Shared ReadOnly Property lblSELLAMT() As String
        Get
            Return ResourceManager.GetString("lblSELLAMT", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Tổng phí DV.
    '''</summary>
    Friend Shared ReadOnly Property lblTOTALFEE() As String
        Get
            Return ResourceManager.GetString("lblTOTALFEE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Tổng lãi.
    '''</summary>
    Friend Shared ReadOnly Property lblTOTALINT() As String
        Get
            Return ResourceManager.GetString("lblTOTALINT", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Tổng phí phạt.
    '''</summary>
    Friend Shared ReadOnly Property lblTOTALPENAFEE() As String
        Get
            Return ResourceManager.GetString("lblTOTALPENAFEE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to TSBS đảm bảo tỉ lệ an toàn.
    '''</summary>
    Friend Shared ReadOnly Property lblTSBSRat() As String
        Get
            Return ResourceManager.GetString("lblTSBSRat", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to TT Vay.
    '''</summary>
    Friend Shared ReadOnly Property lblTTLOAN() As String
        Get
            Return ResourceManager.GetString("lblTTLOAN", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Tỷ lệ thực tế.
    '''</summary>
    Friend Shared ReadOnly Property lblTTRATE() As String
        Get
            Return ResourceManager.GetString("lblTTRATE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Giá trị sau bổ sung.
    '''</summary>
    Friend Shared ReadOnly Property lblValue() As String
        Get
            Return ResourceManager.GetString("lblValue", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Nghĩa vụ phải trả nợ.
    '''</summary>
    Friend Shared ReadOnly Property lblVNDSELLDF() As String
        Get
            Return ResourceManager.GetString("lblVNDSELLDF", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Tiền được rút.
    '''</summary>
    Friend Shared ReadOnly Property lblWITHDRAMT() As String
        Get
            Return ResourceManager.GetString("lblWITHDRAMT", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Diễn giải của giao dịch.
    '''</summary>
    Friend Shared ReadOnly Property txtDescription() As String
        Get
            Return ResourceManager.GetString("txtDescription", resourceCulture)
        End Get
    End Property
End Class
