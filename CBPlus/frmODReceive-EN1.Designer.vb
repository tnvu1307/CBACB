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
Friend Class frmODReceive_EN
    
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
                Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("_DIRECT.frmODReceive-EN", GetType(frmODReceive_EN).Assembly)
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
    '''  Looks up a localized string similar to AF Account No.
    '''</summary>
    Friend Shared ReadOnly Property AFACCTNO() As String
        Get
            Return ResourceManager.GetString("AFACCTNO", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to All or none.
    '''</summary>
    Friend Shared ReadOnly Property AORN() As String
        Get
            Return ResourceManager.GetString("AORN", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Buy or sell.
    '''</summary>
    Friend Shared ReadOnly Property BORS() As String
        Get
            Return ResourceManager.GetString("BORS", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to &amp;Close.
    '''</summary>
    Friend Shared ReadOnly Property btnCANCEL() As String
        Get
            Return ResourceManager.GetString("btnCANCEL", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Auto &amp;Match.
    '''</summary>
    Friend Shared ReadOnly Property btnMatch() As String
        Get
            Return ResourceManager.GetString("btnMatch", resourceCulture)
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
    '''  Looks up a localized string similar to &amp;Receive.
    '''</summary>
    Friend Shared ReadOnly Property btnReceive() As String
        Get
            Return ResourceManager.GetString("btnReceive", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to &amp;Receive All.
    '''</summary>
    Friend Shared ReadOnly Property btnReceiveAll() As String
        Get
            Return ResourceManager.GetString("btnReceiveAll", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to &gt;.
    '''</summary>
    Friend Shared ReadOnly Property btnViewTradingResult() As String
        Get
            Return ResourceManager.GetString("btnViewTradingResult", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to All?.
    '''</summary>
    Friend Shared ReadOnly Property chkAORN() As String
        Get
            Return ResourceManager.GetString("chkAORN", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to CI Account No.
    '''</summary>
    Friend Shared ReadOnly Property CIACCTNO() As String
        Get
            Return ResourceManager.GetString("CIACCTNO", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Calendar.
    '''</summary>
    Friend Shared ReadOnly Property CLEARCD() As String
        Get
            Return ResourceManager.GetString("CLEARCD", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Clear day.
    '''</summary>
    Friend Shared ReadOnly Property CLEARDAY() As String
        Get
            Return ResourceManager.GetString("CLEARDAY", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Code ID.
    '''</summary>
    Friend Shared ReadOnly Property CODEID() As String
        Get
            Return ResourceManager.GetString("CODEID", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Trading account.
    '''</summary>
    Friend Shared ReadOnly Property CUSTODYCD() As String
        Get
            Return ResourceManager.GetString("CUSTODYCD", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Incorrect time format !.
    '''</summary>
    Friend Shared ReadOnly Property ERR_INVTIMEFORMAT() As String
        Get
            Return ResourceManager.GetString("ERR_INVTIMEFORMAT", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Price and quantity not matching with reference order trading result!.
    '''</summary>
    Friend Shared ReadOnly Property ERR_PQNOTMATCHING() As String
        Get
            Return ResourceManager.GetString("ERR_PQNOTMATCHING", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Exec quantity.
    '''</summary>
    Friend Shared ReadOnly Property EXECQTTY() As String
        Get
            Return ResourceManager.GetString("EXECQTTY", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Executed price.
    '''</summary>
    Friend Shared ReadOnly Property EXPRICE() As String
        Get
            Return ResourceManager.GetString("EXPRICE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Executed quantity.
    '''</summary>
    Friend Shared ReadOnly Property EXQTTY() As String
        Get
            Return ResourceManager.GetString("EXQTTY", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Order matching.
    '''</summary>
    Friend Shared ReadOnly Property frmODReceive() As String
        Get
            Return ResourceManager.GetString("frmODReceive", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Total records:.
    '''</summary>
    Friend Shared ReadOnly Property GridEx_FooterRow() As String
        Get
            Return ResourceManager.GetString("GridEx.FooterRow", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Drag column to group by (F6: Focus to grid, F9: Search).
    '''</summary>
    Friend Shared ReadOnly Property GridEx_GroupByRow() As String
        Get
            Return ResourceManager.GetString("GridEx.GroupByRow", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Invalid reference order trading result!.
    '''</summary>
    Friend Shared ReadOnly Property INV_REFORDER() As String
        Get
            Return ResourceManager.GetString("INV_REFORDER", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Buy or sell.
    '''</summary>
    Friend Shared ReadOnly Property lblBORS() As String
        Get
            Return ResourceManager.GetString("lblBORS", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Clear calendar.
    '''</summary>
    Friend Shared ReadOnly Property lblClearCD() As String
        Get
            Return ResourceManager.GetString("lblClearCD", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Clear day.
    '''</summary>
    Friend Shared ReadOnly Property lblClearDay() As String
        Get
            Return ResourceManager.GetString("lblClearDay", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Select Order you want to select and then click Receive to match!.
    '''</summary>
    Friend Shared ReadOnly Property lblDesc() As String
        Get
            Return ResourceManager.GetString("lblDesc", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Executed.
    '''</summary>
    Friend Shared ReadOnly Property lblEXECQTTY() As String
        Get
            Return ResourceManager.GetString("lblEXECQTTY", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Execute type.
    '''</summary>
    Friend Shared ReadOnly Property lblExecType() As String
        Get
            Return ResourceManager.GetString("lblExecType", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Ex Price.
    '''</summary>
    Friend Shared ReadOnly Property lblExPrice() As String
        Get
            Return ResourceManager.GetString("lblExPrice", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Ex quantity.
    '''</summary>
    Friend Shared ReadOnly Property lblExQuantity() As String
        Get
            Return ResourceManager.GetString("lblExQuantity", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Match type.
    '''</summary>
    Friend Shared ReadOnly Property lblMatchType() As String
        Get
            Return ResourceManager.GetString("lblMatchType", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Norl or put.
    '''</summary>
    Friend Shared ReadOnly Property lblNORP() As String
        Get
            Return ResourceManager.GetString("lblNORP", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Price.
    '''</summary>
    Friend Shared ReadOnly Property lblPrice() As String
        Get
            Return ResourceManager.GetString("lblPrice", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Quantity.
    '''</summary>
    Friend Shared ReadOnly Property lblQuantity() As String
        Get
            Return ResourceManager.GetString("lblQuantity", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Ref CustCD.
    '''</summary>
    Friend Shared ReadOnly Property lblREFCUSTCD() As String
        Get
            Return ResourceManager.GetString("lblREFCUSTCD", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Ref OrderID.
    '''</summary>
    Friend Shared ReadOnly Property lblRefOrderID() As String
        Get
            Return ResourceManager.GetString("lblRefOrderID", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Remain.
    '''</summary>
    Friend Shared ReadOnly Property lblREMAINQTTY() As String
        Get
            Return ResourceManager.GetString("lblREMAINQTTY", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Buy or Sell.
    '''</summary>
    Friend Shared ReadOnly Property lblSBORS() As String
        Get
            Return ResourceManager.GetString("lblSBORS", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Symbol.
    '''</summary>
    Friend Shared ReadOnly Property lblSSymbol() As String
        Get
            Return ResourceManager.GetString("lblSSymbol", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Symbol.
    '''</summary>
    Friend Shared ReadOnly Property lblSymbol() As String
        Get
            Return ResourceManager.GetString("lblSymbol", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Description.
    '''</summary>
    Friend Shared ReadOnly Property lblTxDesc() As String
        Get
            Return ResourceManager.GetString("lblTxDesc", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Match time(HH:MM:SS).
    '''</summary>
    Friend Shared ReadOnly Property lblTXTIME() As String
        Get
            Return ResourceManager.GetString("lblTXTIME", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Match quantity.
    '''</summary>
    Friend Shared ReadOnly Property MATCHQTTY() As String
        Get
            Return ResourceManager.GetString("MATCHQTTY", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Successful.
    '''</summary>
    Friend Shared ReadOnly Property MSG_SUCCESS() As String
        Get
            Return ResourceManager.GetString("MSG_SUCCESS", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Norl or put.
    '''</summary>
    Friend Shared ReadOnly Property NORP() As String
        Get
            Return ResourceManager.GetString("NORP", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to OOD_All or none.
    '''</summary>
    Friend Shared ReadOnly Property OOD_AORN() As String
        Get
            Return ResourceManager.GetString("OOD_AORN", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to OOD_Buy or sell.
    '''</summary>
    Friend Shared ReadOnly Property OOD_BORS() As String
        Get
            Return ResourceManager.GetString("OOD_BORS", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to OOD_CodeID.
    '''</summary>
    Friend Shared ReadOnly Property OOD_CODEID() As String
        Get
            Return ResourceManager.GetString("OOD_CODEID", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to OOD_Custody code.
    '''</summary>
    Friend Shared ReadOnly Property OOD_CUSTODYCD() As String
        Get
            Return ResourceManager.GetString("OOD_CUSTODYCD", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to OOD_Norl or put.
    '''</summary>
    Friend Shared ReadOnly Property OOD_NORP() As String
        Get
            Return ResourceManager.GetString("OOD_NORP", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to OOD_Order ID.
    '''</summary>
    Friend Shared ReadOnly Property OOD_ORGORDERID() As String
        Get
            Return ResourceManager.GetString("OOD_ORGORDERID", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to OOD_Symbol.
    '''</summary>
    Friend Shared ReadOnly Property OOD_SYMBOL() As String
        Get
            Return ResourceManager.GetString("OOD_SYMBOL", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Order ID.
    '''</summary>
    Friend Shared ReadOnly Property ORGORDERID() As String
        Get
            Return ResourceManager.GetString("ORGORDERID", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Price.
    '''</summary>
    Friend Shared ReadOnly Property PRICE() As String
        Get
            Return ResourceManager.GetString("PRICE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Price should be a number!.
    '''</summary>
    Friend Shared ReadOnly Property PRICEISNOTNUMBER() As String
        Get
            Return ResourceManager.GetString("PRICEISNOTNUMBER", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Price should be greater than zero!.
    '''</summary>
    Friend Shared ReadOnly Property PRICEISSHOULDBEGREATERTHANOREQUALZERO() As String
        Get
            Return ResourceManager.GetString("PRICEISSHOULDBEGREATERTHANOREQUALZERO", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Price should be greater than ExPrice.
    '''</summary>
    Friend Shared ReadOnly Property PRICESHOULDBEGREATEROREQUALTOEXPRICE() As String
        Get
            Return ResourceManager.GetString("PRICESHOULDBEGREATEROREQUALTOEXPRICE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Price should be  in range !.
    '''</summary>
    Friend Shared ReadOnly Property PRICESHOULDBEINRANGE() As String
        Get
            Return ResourceManager.GetString("PRICESHOULDBEINRANGE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Price should be smaller than or equal to ExPrice.
    '''</summary>
    Friend Shared ReadOnly Property PRICESHOULDBESMALLEROREQUALTOEXPRICE() As String
        Get
            Return ResourceManager.GetString("PRICESHOULDBESMALLEROREQUALTOEXPRICE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Price type.
    '''</summary>
    Friend Shared ReadOnly Property PRICETYPE() As String
        Get
            Return ResourceManager.GetString("PRICETYPE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Quantity.
    '''</summary>
    Friend Shared ReadOnly Property QTTY() As String
        Get
            Return ResourceManager.GetString("QTTY", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Quantity should be a number!.
    '''</summary>
    Friend Shared ReadOnly Property QTTYISNOTNUMBER() As String
        Get
            Return ResourceManager.GetString("QTTYISNOTNUMBER", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Quantity should be greater than zero!.
    '''</summary>
    Friend Shared ReadOnly Property QTTYISSHOULDBEGREATERTHANOREQUALZERO() As String
        Get
            Return ResourceManager.GetString("QTTYISSHOULDBEGREATERTHANOREQUALZERO", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Quantity should be a number!.
    '''</summary>
    Friend Shared ReadOnly Property QUANTITYISNOTNUMBER() As String
        Get
            Return ResourceManager.GetString("QUANTITYISNOTNUMBER", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Quantity should be greater than zero!.
    '''</summary>
    Friend Shared ReadOnly Property QUANTITYISSHOULDBEGREATERTHANOREQUALZERO() As String
        Get
            Return ResourceManager.GetString("QUANTITYISSHOULDBEGREATERTHANOREQUALZERO", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Matching quantity should be in trade lot!.
    '''</summary>
    Friend Shared ReadOnly Property QUANTITYSHOULDBEINTRADELOD() As String
        Get
            Return ResourceManager.GetString("QUANTITYSHOULDBEINTRADELOD", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Quantity should be smaller than ex quantity.
    '''</summary>
    Friend Shared ReadOnly Property QUANTITYSHOULDBESMALLERTHANEXQTTY() As String
        Get
            Return ResourceManager.GetString("QUANTITYSHOULDBESMALLERTHANEXQTTY", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Remain quantity.
    '''</summary>
    Friend Shared ReadOnly Property REMAINQTTY() As String
        Get
            Return ResourceManager.GetString("REMAINQTTY", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Result Buy or sell.
    '''</summary>
    Friend Shared ReadOnly Property RESULT_BORS() As String
        Get
            Return ResourceManager.GetString("RESULT_BORS", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Result Confirm No.
    '''</summary>
    Friend Shared ReadOnly Property RESULT_CONFIRM_NO() As String
        Get
            Return ResourceManager.GetString("RESULT_CONFIRM_NO", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Result Custody code.
    '''</summary>
    Friend Shared ReadOnly Property RESULT_CUSTODYCD() As String
        Get
            Return ResourceManager.GetString("RESULT_CUSTODYCD", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Result price.
    '''</summary>
    Friend Shared ReadOnly Property RESULT_PRICE() As String
        Get
            Return ResourceManager.GetString("RESULT_PRICE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Result quantity.
    '''</summary>
    Friend Shared ReadOnly Property RESULT_QUANTITY() As String
        Get
            Return ResourceManager.GetString("RESULT_QUANTITY", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Resutl Securities code.
    '''</summary>
    Friend Shared ReadOnly Property RESULT_SEC_CODE() As String
        Get
            Return ResourceManager.GetString("RESULT_SEC_CODE", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to SE Account No.
    '''</summary>
    Friend Shared ReadOnly Property SEACCTNO() As String
        Get
            Return ResourceManager.GetString("SEACCTNO", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Settled day.
    '''</summary>
    Friend Shared ReadOnly Property SETTLEDDAY() As String
        Get
            Return ResourceManager.GetString("SETTLEDDAY", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Symbol.
    '''</summary>
    Friend Shared ReadOnly Property SYMBOL() As String
        Get
            Return ResourceManager.GetString("SYMBOL", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Automatic.
    '''</summary>
    Friend Shared ReadOnly Property tpgAutomatic() As String
        Get
            Return ResourceManager.GetString("tpgAutomatic", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Manual.
    '''</summary>
    Friend Shared ReadOnly Property tpgManual() As String
        Get
            Return ResourceManager.GetString("tpgManual", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Trade lot.
    '''</summary>
    Friend Shared ReadOnly Property TRADELOT() As String
        Get
            Return ResourceManager.GetString("TRADELOT", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Trade unit.
    '''</summary>
    Friend Shared ReadOnly Property TRADEUNIT() As String
        Get
            Return ResourceManager.GetString("TRADEUNIT", resourceCulture)
        End Get
    End Property
    
    '''<summary>
    '''  Looks up a localized string similar to Match date.
    '''</summary>
    Friend Shared ReadOnly Property TXDATE() As String
        Get
            Return ResourceManager.GetString("TXDATE", resourceCulture)
        End Get
    End Property
End Class
