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
Friend Class frmRMBankRequest_VN
    
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
                Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("_DIRECT.frmRMBankRequest-VN", GetType(frmRMBankRequest_VN).Assembly)
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
    '''  Looks up a localized string similar to Tên TK chuyển.
    '''</summary>
    Friend Shared ReadOnly Property ACCNAME() As String
        Get
            Return ResourceManager.GetString("ACCNAME", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Số tiền.
    '''</summary>
    Friend Shared ReadOnly Property AMOUNT() As String
        Get
            Return ResourceManager.GetString("AMOUNT", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to AUTOGV: Auto run general view.
    '''</summary>
    Friend Shared ReadOnly Property AUTOGV() As String
        Get
            Return ResourceManager.GetString("AUTOGV", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to BAMTTRF: Bank transfer buy amount.
    '''</summary>
    Friend Shared ReadOnly Property BAMTTRF() As String
        Get
            Return ResourceManager.GetString("BAMTTRF", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Mã ngân hàng.
    '''</summary>
    Friend Shared ReadOnly Property BANKCODE() As String
        Get
            Return ResourceManager.GetString("BANKCODE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Tên ngân hàng.
    '''</summary>
    Friend Shared ReadOnly Property BANKNAME() As String
        Get
            Return ResourceManager.GetString("BANKNAME", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to BFEETRF: Bank transfer buy fee.
    '''</summary>
    Friend Shared ReadOnly Property BFEETRF() As String
        Get
            Return ResourceManager.GetString("BFEETRF", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Reset &amp;cache.
    '''</summary>
    Friend Shared ReadOnly Property btnCache() As String
        Get
            Return ResourceManager.GetString("btnCache", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Thay đổi thông tin.
    '''</summary>
    Friend Shared ReadOnly Property btnChangRequest() As String
        Get
            Return ResourceManager.GetString("btnChangRequest", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to &amp;Thoát.
    '''</summary>
    Friend Shared ReadOnly Property btnClose() As String
        Get
            Return ResourceManager.GetString("btnClose", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Thay đổi trạng thái.
    '''</summary>
    Friend Shared ReadOnly Property btnEditRequest() As String
        Get
            Return ResourceManager.GetString("btnEditRequest", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Lấy DS Ngân Hàng.
    '''</summary>
    Friend Shared ReadOnly Property btnGetBank() As String
        Get
            Return ResourceManager.GetString("btnGetBank", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Lấy KQ chi hộ.
    '''</summary>
    Friend Shared ReadOnly Property btnGetTransferResult() As String
        Get
            Return ResourceManager.GetString("btnGetTransferResult", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Tạo điện thủ công.
    '''</summary>
    Friend Shared ReadOnly Property btnManualMsg() As String
        Get
            Return ResourceManager.GetString("btnManualMsg", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Lấy D/S thu hộ.
    '''</summary>
    Friend Shared ReadOnly Property btnReceiveRequest() As String
        Get
            Return ResourceManager.GetString("btnReceiveRequest", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Đối chiếu.
    '''</summary>
    Friend Shared ReadOnly Property btnReconcide() As String
        Get
            Return ResourceManager.GetString("btnReconcide", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Làm mới thông tin.
    '''</summary>
    Friend Shared ReadOnly Property btnRefresh() As String
        Get
            Return ResourceManager.GetString("btnRefresh", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Gửi Y/C chi hộ.
    '''</summary>
    Friend Shared ReadOnly Property btnSendRequest() As String
        Get
            Return ResourceManager.GetString("btnSendRequest", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to &amp;Submit.
    '''</summary>
    Friend Shared ReadOnly Property btnSubmit() As String
        Get
            Return ResourceManager.GetString("btnSubmit", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Reset &amp;ticker.
    '''</summary>
    Friend Shared ReadOnly Property btnTicker() As String
        Get
            Return ResourceManager.GetString("btnTicker", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Auto-process (s).
    '''</summary>
    Friend Shared ReadOnly Property CheckBox1() As String
        Get
            Return ResourceManager.GetString("CheckBox1", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Tự động chạy (s).
    '''</summary>
    Friend Shared ReadOnly Property chkAuto() As String
        Get
            Return ResourceManager.GetString("chkAuto", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Ngày tạo.
    '''</summary>
    Friend Shared ReadOnly Property CREATEDT() As String
        Get
            Return ResourceManager.GetString("CREATEDT", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to TK chuyển.
    '''</summary>
    Friend Shared ReadOnly Property DESBANKACCOUNT() As String
        Get
            Return ResourceManager.GetString("DESBANKACCOUNT", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Mô tả lỗi.
    '''</summary>
    Friend Shared ReadOnly Property ERRORDESC() As String
        Get
            Return ResourceManager.GetString("ERRORDESC", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Control board.
    '''</summary>
    Friend Shared ReadOnly Property frmRMOperation() As String
        Get
            Return ResourceManager.GetString("frmRMOperation", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to GET_ORDERBOOK: Get HoSE Order book.
    '''</summary>
    Friend Shared ReadOnly Property GET_ORDERBOOK() As String
        Get
            Return ResourceManager.GetString("GET_ORDERBOOK", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to GET_TRADEBOOK: Get HoSE Trade book.
    '''</summary>
    Friend Shared ReadOnly Property GET_TRADEBOOK() As String
        Get
            Return ResourceManager.GetString("GET_TRADEBOOK", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to GET_VNMARKETWATCH: Get HaSTC Market watch.
    '''</summary>
    Friend Shared ReadOnly Property GET_VNMARKETWATCH() As String
        Get
            Return ResourceManager.GetString("GET_VNMARKETWATCH", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to GET_VSMARKETWATCH: Get HoSE Market watch.
    '''</summary>
    Friend Shared ReadOnly Property GET_VSMARKETWATCH() As String
        Get
            Return ResourceManager.GetString("GET_VSMARKETWATCH", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to TK Thụ hưởng.
    '''</summary>
    Friend Shared ReadOnly Property KEYACCT1() As String
        Get
            Return ResourceManager.GetString("KEYACCT1", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Tên KH thụ hưởng.
    '''</summary>
    Friend Shared ReadOnly Property KEYACCT2() As String
        Get
            Return ResourceManager.GetString("KEYACCT2", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Tỉnh/Thành phố.
    '''</summary>
    Friend Shared ReadOnly Property LOCATION() As String
        Get
            Return ResourceManager.GetString("LOCATION", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Hoàn tất chuyển khoản đến ngân hàng!.
    '''</summary>
    Friend Shared ReadOnly Property MSG_CTRSUCCESS() As String
        Get
            Return ResourceManager.GetString("MSG_CTRSUCCESS", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Lấy danh sách mã ngân hàng chuyển tiền thành công!.
    '''</summary>
    Friend Shared ReadOnly Property MSG_GETLISTTRANFER() As String
        Get
            Return ResourceManager.GetString("MSG_GETLISTTRANFER", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Lấy trạng thái thành công. Xem lại danh sách chi hộ để có thông tin chi tiết!.
    '''</summary>
    Friend Shared ReadOnly Property MSG_GETSTATUS() As String
        Get
            Return ResourceManager.GetString("MSG_GETSTATUS", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Nhận yêu cầu từ ngân hàng thành công!.
    '''</summary>
    Friend Shared ReadOnly Property MSG_REVSUCCESS() As String
        Get
            Return ResourceManager.GetString("MSG_REVSUCCESS", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Hoàn tất nhận báo có từ ngân hàng!.
    '''</summary>
    Friend Shared ReadOnly Property MSG_REVTRSUCCESS() As String
        Get
            Return ResourceManager.GetString("MSG_REVTRSUCCESS", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Gửi yêu cầu sang ngân hàng thành công!.
    '''</summary>
    Friend Shared ReadOnly Property MSG_SENDCOMPLETE() As String
        Get
            Return ResourceManager.GetString("MSG_SENDCOMPLETE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Mã tham chiếu.
    '''</summary>
    Friend Shared ReadOnly Property REFCODE() As String
        Get
            Return ResourceManager.GetString("REFCODE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Tỉnh/Thành phố.
    '''</summary>
    Friend Shared ReadOnly Property REGIONAL() As String
        Get
            Return ResourceManager.GetString("REGIONAL", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to RMEX8894: Tạo bảng kê thanh toán tiền bán CK lô lẻ.
    '''</summary>
    Friend Shared ReadOnly Property RMEX8879() As String
        Get
            Return ResourceManager.GetString("RMEX8879", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to RMEX8894DF: Xuất bảng kê thanh toán thuế từ bán lô lẻ.
    '''</summary>
    Friend Shared ReadOnly Property RMEX8879DF() As String
        Get
            Return ResourceManager.GetString("RMEX8879DF", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to RMEXCA3350: Tạo bảng kê thanh toán cổ tức bằng tiền.
    '''</summary>
    Friend Shared ReadOnly Property RMEXCA3350() As String
        Get
            Return ResourceManager.GetString("RMEXCA3350", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to RMEXCA3350DF: Xuất bảng kê thanh toán thuế cổ tức.
    '''</summary>
    Friend Shared ReadOnly Property RMEXCA3350DF() As String
        Get
            Return ResourceManager.GetString("RMEXCA3350DF", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to RMEXCA3384: Tạo bảng kê đăng ký quyền mua.
    '''</summary>
    Friend Shared ReadOnly Property RMEXCA3384() As String
        Get
            Return ResourceManager.GetString("RMEXCA3384", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to RMEXCA3386: Tao bang ke huy dang ky quyen mua.
    '''</summary>
    Friend Shared ReadOnly Property RMEXCA3386() As String
        Get
            Return ResourceManager.GetString("RMEXCA3386", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to RMEXTRFQUEUE: Xử lý hàng đợi tạo batch gửi sang NH.
    '''</summary>
    Friend Shared ReadOnly Property RMEXTRFQUEUE() As String
        Get
            Return ResourceManager.GetString("RMEXTRFQUEUE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to RMEXTRFSTS: Lấy trạng thái các bảng kê đang chờ xác nhận.
    '''</summary>
    Friend Shared ReadOnly Property RMEXTRFSTS() As String
        Get
            Return ResourceManager.GetString("RMEXTRFSTS", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Tên khách hàng.
    '''</summary>
    Friend Shared ReadOnly Property S_ACCNAME() As String
        Get
            Return ResourceManager.GetString("S_ACCNAME", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Số tiểu khoản.
    '''</summary>
    Friend Shared ReadOnly Property S_AFACCTNO() As String
        Get
            Return ResourceManager.GetString("S_AFACCTNO", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Số tài khoản NH.
    '''</summary>
    Friend Shared ReadOnly Property S_BANKACCT() As String
        Get
            Return ResourceManager.GetString("S_BANKACCT", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Thành phố.
    '''</summary>
    Friend Shared ReadOnly Property S_BANKCITY() As String
        Get
            Return ResourceManager.GetString("S_BANKCITY", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Số lưu ký.
    '''</summary>
    Friend Shared ReadOnly Property S_CUSTODYCD() As String
        Get
            Return ResourceManager.GetString("S_CUSTODYCD", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Số tài khoản KH.
    '''</summary>
    Friend Shared ReadOnly Property S_DESACCTNO() As String
        Get
            Return ResourceManager.GetString("S_DESACCTNO", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Diễn giải.
    '''</summary>
    Friend Shared ReadOnly Property S_NOTES() As String
        Get
            Return ResourceManager.GetString("S_NOTES", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Mã giao dịch.
    '''</summary>
    Friend Shared ReadOnly Property S_OBJKEY() As String
        Get
            Return ResourceManager.GetString("S_OBJKEY", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Mã tham chiếu.
    '''</summary>
    Friend Shared ReadOnly Property S_REFCODE() As String
        Get
            Return ResourceManager.GetString("S_REFCODE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Trạng thái.
    '''</summary>
    Friend Shared ReadOnly Property S_STATUS() As String
        Get
            Return ResourceManager.GetString("S_STATUS", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Số tiền.
    '''</summary>
    Friend Shared ReadOnly Property S_TXAMT() As String
        Get
            Return ResourceManager.GetString("S_TXAMT", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Ngày giao dịch.
    '''</summary>
    Friend Shared ReadOnly Property S_TXDATE() As String
        Get
            Return ResourceManager.GetString("S_TXDATE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to SENDCMP: Send order from FO to company.
    '''</summary>
    Friend Shared ReadOnly Property SENDCMP() As String
        Get
            Return ResourceManager.GetString("SENDCMP", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to SENDGTC: Send GTC order from FO to company.
    '''</summary>
    Friend Shared ReadOnly Property SENDGTC() As String
        Get
            Return ResourceManager.GetString("SENDGTC", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to SENDHAGTC: Send Hastc GTC order from FO to company.
    '''</summary>
    Friend Shared ReadOnly Property SENDHAGTC() As String
        Get
            Return ResourceManager.GetString("SENDHAGTC", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to SENDHASL: Send Hastc stop limit order from FO to company.
    '''</summary>
    Friend Shared ReadOnly Property SENDHASL() As String
        Get
            Return ResourceManager.GetString("SENDHASL", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to SENDHOGTC: Send Hose GTC order from FO to company.
    '''</summary>
    Friend Shared ReadOnly Property SENDHOGTC() As String
        Get
            Return ResourceManager.GetString("SENDHOGTC", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to SENDHOSL: Send Hostc stop limit order from FO to company.
    '''</summary>
    Friend Shared ReadOnly Property SENDHOSL() As String
        Get
            Return ResourceManager.GetString("SENDHOSL", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to START_MAP_SECURITIESINFO: Synchronize Securities with Stock Exchange.
    '''</summary>
    Friend Shared ReadOnly Property START_MAP_SECURITIESINFO() As String
        Get
            Return ResourceManager.GetString("START_MAP_SECURITIESINFO", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to START_MAP_STCORDERBOOK: Map exchange order book to company order book.
    '''</summary>
    Friend Shared ReadOnly Property START_MAP_STCORDERBOOK() As String
        Get
            Return ResourceManager.GetString("START_MAP_STCORDERBOOK", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to START_MAP_STCTRADEBOOK: Map exchange trade book to company order book.
    '''</summary>
    Friend Shared ReadOnly Property START_MAP_STCTRADEBOOK() As String
        Get
            Return ResourceManager.GetString("START_MAP_STCTRADEBOOK", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to START_VNMKTINFO: Start HaSTC Listed market info download.
    '''</summary>
    Friend Shared ReadOnly Property START_VNMKTINFO() As String
        Get
            Return ResourceManager.GetString("START_VNMKTINFO", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to START_VNTRADE: Start HaSTC Listed trading data download.
    '''</summary>
    Friend Shared ReadOnly Property START_VNTRADE() As String
        Get
            Return ResourceManager.GetString("START_VNTRADE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to START_VSMKTINFO: Start HoSE Listed market info download.
    '''</summary>
    Friend Shared ReadOnly Property START_VSMKTINFO() As String
        Get
            Return ResourceManager.GetString("START_VSMKTINFO", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to START_VSTRADE: Start HoSE Listed trading data download.
    '''</summary>
    Friend Shared ReadOnly Property START_VSTRADE() As String
        Get
            Return ResourceManager.GetString("START_VSTRADE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Trạng thái.
    '''</summary>
    Friend Shared ReadOnly Property STATUS() As String
        Get
            Return ResourceManager.GetString("STATUS", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to SYNCTRANS: Process asynchronous transaction.
    '''</summary>
    Friend Shared ReadOnly Property SYNCTRANS() As String
        Get
            Return ResourceManager.GetString("SYNCTRANS", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Diễn giải.
    '''</summary>
    Friend Shared ReadOnly Property TRANSACTIONDESCRIPTION() As String
        Get
            Return ResourceManager.GetString("TRANSACTIONDESCRIPTION", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Mã giao dịch.
    '''</summary>
    Friend Shared ReadOnly Property TRANSACTIONNUMBER() As String
        Get
            Return ResourceManager.GetString("TRANSACTIONNUMBER", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Ngày tạo.
    '''</summary>
    Friend Shared ReadOnly Property TRN_DT() As String
        Get
            Return ResourceManager.GetString("TRN_DT", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Số tham chiếu.
    '''</summary>
    Friend Shared ReadOnly Property TRNREF() As String
        Get
            Return ResourceManager.GetString("TRNREF", resourceCulture)
        End Get
    End Property
End Class
