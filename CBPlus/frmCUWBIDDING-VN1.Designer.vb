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
Friend Class frmCUWBIDDING_VN
    
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
                Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("_DIRECT.frmCUWBIDDING-VN", GetType(frmCUWBIDDING_VN).Assembly)
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
    '''  Looks up a localized string similar to Hiệu chỉnh.
    '''</summary>
    Friend Shared ReadOnly Property btnAdjust() As String
        Get
            Return ResourceManager.GetString("btnAdjust", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Chấp nhận.
    '''</summary>
    Friend Shared ReadOnly Property btnApply() As String
        Get
            Return ResourceManager.GetString("btnApply", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Thoát.
    '''</summary>
    Friend Shared ReadOnly Property btnCancel() As String
        Get
            Return ResourceManager.GetString("btnCancel", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to In chứng từ.
    '''</summary>
    Friend Shared ReadOnly Property btnPRINT() As String
        Get
            Return ResourceManager.GetString("btnPRINT", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Vui lòng chọn loại hình!.
    '''</summary>
    Friend Shared ReadOnly Property CHECKBIDTYPE() As String
        Get
            Return ResourceManager.GetString("CHECKBIDTYPE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Dữ liệu nhập vào phải là kiểu số!.
    '''</summary>
    Friend Shared ReadOnly Property ERR_NUMBER_TYPE() As String
        Get
            Return ResourceManager.GetString("ERR_NUMBER_TYPE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Giao dịch cần duyệt!.
    '''</summary>
    Friend Shared ReadOnly Property ERR_SA_CHECKER_OVR() As String
        Get
            Return ResourceManager.GetString("ERR_SA_CHECKER_OVR", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Không tìm thấy giao dịch này!.
    '''</summary>
    Friend Shared ReadOnly Property ERR_TLTXCD_NOTFOUND() As String
        Get
            Return ResourceManager.GetString("ERR_TLTXCD_NOTFOUND", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Hoàn tiền cọc không trúng thầu.
    '''</summary>
    Friend Shared ReadOnly Property frmCUWBIDDING() As String
        Get
            Return ResourceManager.GetString("frmCUWBIDDING", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Hoàn tiền cọc không trúng đấu giá.
    '''</summary>
    Friend Shared ReadOnly Property frmCUWBIDDING_auction() As String
        Get
            Return ResourceManager.GetString("frmCUWBIDDING_auction", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Hoàn tiền cọc không trúng đấu đấu thầu.
    '''</summary>
    Friend Shared ReadOnly Property frmCUWBIDDING_bidding() As String
        Get
            Return ResourceManager.GetString("frmCUWBIDDING_bidding", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Lịch cắt tiền cọc đấu thầu.
    '''</summary>
    Friend Shared ReadOnly Property grbCPSchd() As String
        Get
            Return ResourceManager.GetString("grbCPSchd", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Tiểu khoản không hợp lệ!.
    '''</summary>
    Friend Shared ReadOnly Property INVALIDACCTNO() As String
        Get
            Return ResourceManager.GetString("INVALIDACCTNO", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Giá trị đấu thầu không được bé hơn 0!.
    '''</summary>
    Friend Shared ReadOnly Property INVALIDBIDDINGAMT() As String
        Get
            Return ResourceManager.GetString("INVALIDBIDDINGAMT", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to % Phí chuyển tiền không được bé hơn 0!.
    '''</summary>
    Friend Shared ReadOnly Property INVALIDCASHRATE() As String
        Get
            Return ResourceManager.GetString("INVALIDCASHRATE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Thông tin khách hàng không đúng!.
    '''</summary>
    Friend Shared ReadOnly Property INVALIDCUSTINFO() As String
        Get
            Return ResourceManager.GetString("INVALIDCUSTINFO", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to TK lưu ký không hợp lệ!.
    '''</summary>
    Friend Shared ReadOnly Property INVALIDCUSTODYCD() As String
        Get
            Return ResourceManager.GetString("INVALIDCUSTODYCD", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to % Phí môi giới không được bé hơn 0!.
    '''</summary>
    Friend Shared ReadOnly Property INVALIDRERATE() As String
        Get
            Return ResourceManager.GetString("INVALIDRERATE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Mã chứng khoán không hợp lệ!.
    '''</summary>
    Friend Shared ReadOnly Property INVALIDSYMBOL() As String
        Get
            Return ResourceManager.GetString("INVALIDSYMBOL", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Tiểu khoản.
    '''</summary>
    Friend Shared ReadOnly Property lblAFACCTNO() As String
        Get
            Return ResourceManager.GetString("lblAFACCTNO", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Giá trị đấu thầu.
    '''</summary>
    Friend Shared ReadOnly Property lblBIDDINGAMT() As String
        Get
            Return ResourceManager.GetString("lblBIDDINGAMT", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Loại.
    '''</summary>
    Friend Shared ReadOnly Property lblBIDTYPE() As String
        Get
            Return ResourceManager.GetString("lblBIDTYPE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Phí chuyển tiền.
    '''</summary>
    Friend Shared ReadOnly Property lblCASHFEE() As String
        Get
            Return ResourceManager.GetString("lblCASHFEE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to % Phí chuyển tiền.
    '''</summary>
    Friend Shared ReadOnly Property lblCASHRATE() As String
        Get
            Return ResourceManager.GetString("lblCASHRATE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Mã trái phiếu.
    '''</summary>
    Friend Shared ReadOnly Property lblCODEID() As String
        Get
            Return ResourceManager.GetString("lblCODEID", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to TK lưu ký.
    '''</summary>
    Friend Shared ReadOnly Property lblCUSTODYCD() As String
        Get
            Return ResourceManager.GetString("lblCUSTODYCD", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Giá trị cắt cọc hoàn lại.
    '''</summary>
    Friend Shared ReadOnly Property lblCUTEDAMT() As String
        Get
            Return ResourceManager.GetString("lblCUTEDAMT", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Ngày phát hành.
    '''</summary>
    Friend Shared ReadOnly Property lblISSUEDATE() As String
        Get
            Return ResourceManager.GetString("lblISSUEDATE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Phí môi giới.
    '''</summary>
    Friend Shared ReadOnly Property lblREFEE() As String
        Get
            Return ResourceManager.GetString("lblREFEE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Giá trị cọc còn lại.
    '''</summary>
    Friend Shared ReadOnly Property lblREMAININGAMT() As String
        Get
            Return ResourceManager.GetString("lblREMAININGAMT", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to % Phí môi giới.
    '''</summary>
    Friend Shared ReadOnly Property lblRERATE() As String
        Get
            Return ResourceManager.GetString("lblRERATE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Tổng giá trị thanh toán.
    '''</summary>
    Friend Shared ReadOnly Property lblTOTALAMT() As String
        Get
            Return ResourceManager.GetString("lblTOTALAMT", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Giá trị cọc đã cắt.
    '''</summary>
    Friend Shared ReadOnly Property SchdAMT() As String
        Get
            Return ResourceManager.GetString("SchdAMT", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Mã tự tăng.
    '''</summary>
    Friend Shared ReadOnly Property SchdAUTOID() As String
        Get
            Return ResourceManager.GetString("SchdAUTOID", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Diễn giải.
    '''</summary>
    Friend Shared ReadOnly Property SchdDESCRIPTION() As String
        Get
            Return ResourceManager.GetString("SchdDESCRIPTION", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Ngày chứng từ.
    '''</summary>
    Friend Shared ReadOnly Property SchdTXDATE() As String
        Get
            Return ResourceManager.GetString("SchdTXDATE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Giao dịch đã được thực hiện!.
    '''</summary>
    Friend Shared ReadOnly Property TransactionSuccessful() As String
        Get
            Return ResourceManager.GetString("TransactionSuccessful", resourceCulture)
        End Get
    End Property
End Class
