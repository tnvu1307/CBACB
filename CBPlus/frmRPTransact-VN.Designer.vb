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
Friend Class frmRPTransact_VN
    
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
                Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("_DIRECT.frmRPTransact-VN", GetType(frmRPTransact_VN).Assembly)
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
    '''  Looks up a localized string similar to Điều khoản phá vỡ HĐ phải là số!.
    '''</summary>
    Friend Shared ReadOnly Property BreakTermISNOTNUMBER() As String
        Get
            Return ResourceManager.GetString("BreakTermISNOTNUMBER", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Điều khoản phá vỡ HĐ phải là số dương!.
    '''</summary>
    Friend Shared ReadOnly Property BreakTermSHOULDBEPOSITIVENUMBER() As String
        Get
            Return ResourceManager.GetString("BreakTermSHOULDBEPOSITIVENUMBER", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to &amp;Huỷ.
    '''</summary>
    Friend Shared ReadOnly Property btnCANCEL() As String
        Get
            Return ResourceManager.GetString("btnCANCEL", resourceCulture)
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
    '''  Looks up a localized string similar to Số hợp đồng không đúng!.
    '''</summary>
    Friend Shared ReadOnly Property CONTRACTINVALID() As String
        Get
            Return ResourceManager.GetString("CONTRACTINVALID", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Tỷ lệ hợp đồng phải là số!.
    '''</summary>
    Friend Shared ReadOnly Property ContractRateISNOTNUMBER() As String
        Get
            Return ResourceManager.GetString("ContractRateISNOTNUMBER", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Tỷ lệ hợp đồng phải là số dương!.
    '''</summary>
    Friend Shared ReadOnly Property ContractRateSHOULDBEPOSITIVENUMBER() As String
        Get
            Return ResourceManager.GetString("ContractRateSHOULDBEPOSITIVENUMBER", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Trường không thể trống!.
    '''</summary>
    Friend Shared ReadOnly Property ERR_FIELD_NULL() As String
        Get
            Return ResourceManager.GetString("ERR_FIELD_NULL", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Ngày đặt trước không được nhỏ hơn ngày hợp đồng!.
    '''</summary>
    Friend Shared ReadOnly Property FORWARDDATEISSMALLERTHANRPDATE() As String
        Get
            Return ResourceManager.GetString("FORWARDDATEISSMALLERTHANRPDATE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Ngày đặt trước không được nhỏ hơn ngày giao!.
    '''</summary>
    Friend Shared ReadOnly Property FORWARDDATEISSMALLERTHANSPOTDATE() As String
        Get
            Return ResourceManager.GetString("FORWARDDATEISSMALLERTHANSPOTDATE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Giá đặt trước phải là số.
    '''</summary>
    Friend Shared ReadOnly Property ForwardPRICEISNOTNUMBER() As String
        Get
            Return ResourceManager.GetString("ForwardPRICEISNOTNUMBER", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Giá đặt trước phải là số dương.
    '''</summary>
    Friend Shared ReadOnly Property ForwardPRICESHOULDBEPOSITIVENUMBER() As String
        Get
            Return ResourceManager.GetString("ForwardPRICESHOULDBEPOSITIVENUMBER", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Giá trị đặt trước phải là số.
    '''</summary>
    Friend Shared ReadOnly Property ForwardVALUEISNOTNUMBER() As String
        Get
            Return ResourceManager.GetString("ForwardVALUEISNOTNUMBER", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Giá trị đặt trước phải là số dương.
    '''</summary>
    Friend Shared ReadOnly Property ForwardVALUESHOULDBEPOSITIVENUMBER() As String
        Get
            Return ResourceManager.GetString("ForwardVALUESHOULDBEPOSITIVENUMBER", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Giao dịch repo:.
    '''</summary>
    Friend Shared ReadOnly Property frmRPTransact() As String
        Get
            Return ResourceManager.GetString("frmRPTransact", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Mã hợp đồng RP.
    '''</summary>
    Friend Shared ReadOnly Property lblACCTNO() As String
        Get
            Return ResourceManager.GetString("lblACCTNO", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Hợp đồng KH:.
    '''</summary>
    Friend Shared ReadOnly Property lblAFACCTNO() As String
        Get
            Return ResourceManager.GetString("lblAFACCTNO", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to .
    '''</summary>
    Friend Shared ReadOnly Property lblAFNAME() As String
        Get
            Return ResourceManager.GetString("lblAFNAME", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Đ/k phá vỡ HĐ:.
    '''</summary>
    Friend Shared ReadOnly Property lblBreakTerm() As String
        Get
            Return ResourceManager.GetString("lblBreakTerm", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Lịch:.
    '''</summary>
    Friend Shared ReadOnly Property lblCalendar() As String
        Get
            Return ResourceManager.GetString("lblCalendar", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Quyền:.
    '''</summary>
    Friend Shared ReadOnly Property lblCARight() As String
        Get
            Return ResourceManager.GetString("lblCARight", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Tỷ lệ hợp đồng:.
    '''</summary>
    Friend Shared ReadOnly Property lblContractRate() As String
        Get
            Return ResourceManager.GetString("lblContractRate", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Loại hình:.
    '''</summary>
    Friend Shared ReadOnly Property lblExecType() As String
        Get
            Return ResourceManager.GetString("lblExecType", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Đặt trước:.
    '''</summary>
    Friend Shared ReadOnly Property lblForward() As String
        Get
            Return ResourceManager.GetString("lblForward", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Ngày đặt trước:.
    '''</summary>
    Friend Shared ReadOnly Property lblForwardDate() As String
        Get
            Return ResourceManager.GetString("lblForwardDate", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Giá đặt trước:.
    '''</summary>
    Friend Shared ReadOnly Property lblForwardPrice() As String
        Get
            Return ResourceManager.GetString("lblForwardPrice", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Giá trị đặt trước:.
    '''</summary>
    Friend Shared ReadOnly Property lblForwardValue() As String
        Get
            Return ResourceManager.GetString("lblForwardValue", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Kiểu khớp:.
    '''</summary>
    Friend Shared ReadOnly Property lblMatchType() As String
        Get
            Return ResourceManager.GetString("lblMatchType", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Phạt(%):.
    '''</summary>
    Friend Shared ReadOnly Property lblPenanty() As String
        Get
            Return ResourceManager.GetString("lblPenanty", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Số lượng:.
    '''</summary>
    Friend Shared ReadOnly Property lblQuantity() As String
        Get
            Return ResourceManager.GetString("lblQuantity", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Số tài khoản RP:.
    '''</summary>
    Friend Shared ReadOnly Property lblRPACCTNO() As String
        Get
            Return ResourceManager.GetString("lblRPACCTNO", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Ngày repo: .
    '''</summary>
    Friend Shared ReadOnly Property lblRPDate() As String
        Get
            Return ResourceManager.GetString("lblRPDate", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Tỷ lệ ký quỹ(%).
    '''</summary>
    Friend Shared ReadOnly Property lblSECUREDRATIO() As String
        Get
            Return ResourceManager.GetString("lblSECUREDRATIO", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Giao ngay:.
    '''</summary>
    Friend Shared ReadOnly Property lblSpot() As String
        Get
            Return ResourceManager.GetString("lblSpot", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Ngày giao:.
    '''</summary>
    Friend Shared ReadOnly Property lblSpotDate() As String
        Get
            Return ResourceManager.GetString("lblSpotDate", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Giá giao:.
    '''</summary>
    Friend Shared ReadOnly Property lblSpotPrice() As String
        Get
            Return ResourceManager.GetString("lblSpotPrice", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Giá trị giao:.
    '''</summary>
    Friend Shared ReadOnly Property lblSpotValue() As String
        Get
            Return ResourceManager.GetString("lblSpotValue", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Chứng khoán.
    '''</summary>
    Friend Shared ReadOnly Property lblSymbol() As String
        Get
            Return ResourceManager.GetString("lblSymbol", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Tỷ lệ TPR(%):.
    '''</summary>
    Friend Shared ReadOnly Property lblTPRRate() As String
        Get
            Return ResourceManager.GetString("lblTPRRate", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Ngày theo năm.
    '''</summary>
    Friend Shared ReadOnly Property lblYearDay() As String
        Get
            Return ResourceManager.GetString("lblYearDay", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Phạt phải là số dương!.
    '''</summary>
    Friend Shared ReadOnly Property PenantySHOULDBEPOSITIVENUMBER() As String
        Get
            Return ResourceManager.GetString("PenantySHOULDBEPOSITIVENUMBER", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Phạt phải là số!.
    '''</summary>
    Friend Shared ReadOnly Property PenantyVALUEISNOTNUMBER() As String
        Get
            Return ResourceManager.GetString("PenantyVALUEISNOTNUMBER", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Số lượng phải là số!.
    '''</summary>
    Friend Shared ReadOnly Property QTTYISNOTNUMBER() As String
        Get
            Return ResourceManager.GetString("QTTYISNOTNUMBER", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Số lượng phải là số dương!.
    '''</summary>
    Friend Shared ReadOnly Property QTTYSHOULDBEPOSITIVENUMBER() As String
        Get
            Return ResourceManager.GetString("QTTYSHOULDBEPOSITIVENUMBER", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Tỷ lệ ký quỹ phải là số!.
    '''</summary>
    Friend Shared ReadOnly Property SECUREDRATIOISNOTNUMBER() As String
        Get
            Return ResourceManager.GetString("SECUREDRATIOISNOTNUMBER", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to T/L ký quỹ phải nằm trong 0..100!.
    '''</summary>
    Friend Shared ReadOnly Property SECUREDRATIOSHOULDBEINRANGENUMBER() As String
        Get
            Return ResourceManager.GetString("SECUREDRATIOSHOULDBEINRANGENUMBER", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Ngày giao không được nhỏ hơn ngày hợp đồng!.
    '''</summary>
    Friend Shared ReadOnly Property SPOTDATEISSMALLERTHANCONTRACTDATE() As String
        Get
            Return ResourceManager.GetString("SPOTDATEISSMALLERTHANCONTRACTDATE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Giá giao phải là số!.
    '''</summary>
    Friend Shared ReadOnly Property SPOTPRICEISNOTNUMBER() As String
        Get
            Return ResourceManager.GetString("SPOTPRICEISNOTNUMBER", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Giá giao phải là số dương!.
    '''</summary>
    Friend Shared ReadOnly Property SPOTPRICESHOULDBEPOSITIVENUMBER() As String
        Get
            Return ResourceManager.GetString("SPOTPRICESHOULDBEPOSITIVENUMBER", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Giá trị giao ngay phải là số!.
    '''</summary>
    Friend Shared ReadOnly Property SPOTVALUEISNOTNUMBER() As String
        Get
            Return ResourceManager.GetString("SPOTVALUEISNOTNUMBER", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Giá trị giao ngay phải là số dương!.
    '''</summary>
    Friend Shared ReadOnly Property SPOTVALUESHOULDBEPOSITIVENUMBER() As String
        Get
            Return ResourceManager.GetString("SPOTVALUESHOULDBEPOSITIVENUMBER", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Tỷ lệ TPR phải là số!.
    '''</summary>
    Friend Shared ReadOnly Property TPRRateISNOTNUMBER() As String
        Get
            Return ResourceManager.GetString("TPRRateISNOTNUMBER", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Tỷ lệ TPR phải là số dương!.
    '''</summary>
    Friend Shared ReadOnly Property TPRRateSHOULDBEPOSITIVENUMBER() As String
        Get
            Return ResourceManager.GetString("TPRRateSHOULDBEPOSITIVENUMBER", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Lô giao dịch không đúng.
    '''</summary>
    Friend Shared ReadOnly Property TRADELOTINVALID() As String
        Get
            Return ResourceManager.GetString("TRADELOTINVALID", resourceCulture)
        End Get
    End Property
End Class
