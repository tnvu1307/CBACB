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


Namespace HOSTRptService
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.ServiceContractAttribute(ConfigurationName:="HOSTRptService.IHOSTRptService")>  _
    Public Interface IHOSTRptService
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IHOSTRptService/DoWork", ReplyAction:="http://tempuri.org/IHOSTRptService/DoWorkResponse")>  _
        Function DoWork(ByVal request As HOSTRptService.DoWorkRequest) As HOSTRptService.DoWorkResponse
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IHOSTRptService/DoWork", ReplyAction:="http://tempuri.org/IHOSTRptService/DoWorkResponse")>  _
        Function DoWorkAsync(ByVal request As HOSTRptService.DoWorkRequest) As System.Threading.Tasks.Task(Of HOSTRptService.DoWorkResponse)
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IHOSTRptService/MessageString", ReplyAction:="http://tempuri.org/IHOSTRptService/MessageStringResponse")>  _
        Function MessageString(ByVal request As HOSTRptService.MessageStringRequest) As HOSTRptService.MessageStringResponse
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IHOSTRptService/MessageString", ReplyAction:="http://tempuri.org/IHOSTRptService/MessageStringResponse")>  _
        Function MessageStringAsync(ByVal request As HOSTRptService.MessageStringRequest) As System.Threading.Tasks.Task(Of HOSTRptService.MessageStringResponse)
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IHOSTRptService/MessageByte", ReplyAction:="http://tempuri.org/IHOSTRptService/MessageByteResponse")>  _
        Function MessageByte(ByVal request As HOSTRptService.MessageByteRequest) As HOSTRptService.MessageByteResponse
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IHOSTRptService/MessageByte", ReplyAction:="http://tempuri.org/IHOSTRptService/MessageByteResponse")>  _
        Function MessageByteAsync(ByVal request As HOSTRptService.MessageByteRequest) As System.Threading.Tasks.Task(Of HOSTRptService.MessageByteResponse)
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IHOSTRptService/GetErrorMessage", ReplyAction:="http://tempuri.org/IHOSTRptService/GetErrorMessageResponse")>  _
        Function GetErrorMessage(ByVal request As HOSTRptService.GetErrorMessageRequest) As HOSTRptService.GetErrorMessageResponse
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IHOSTRptService/GetErrorMessage", ReplyAction:="http://tempuri.org/IHOSTRptService/GetErrorMessageResponse")>  _
        Function GetErrorMessageAsync(ByVal request As HOSTRptService.GetErrorMessageRequest) As System.Threading.Tasks.Task(Of HOSTRptService.GetErrorMessageResponse)
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.MessageContractAttribute(WrapperName:="DoWork", WrapperNamespace:="http://tempuri.org/", IsWrapped:=true)>  _
    Partial Public Class DoWorkRequest
        
        Public Sub New()
            MyBase.New
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.MessageContractAttribute(WrapperName:="DoWorkResponse", WrapperNamespace:="http://tempuri.org/", IsWrapped:=true)>  _
    Partial Public Class DoWorkResponse
        
        Public Sub New()
            MyBase.New
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.MessageContractAttribute(WrapperName:="MessageString", WrapperNamespace:="http://tempuri.org/", IsWrapped:=true)>  _
    Partial Public Class MessageStringRequest
        
        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="http://tempuri.org/", Order:=0)>  _
        Public pv_strMessage As String
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal pv_strMessage As String)
            MyBase.New
            Me.pv_strMessage = pv_strMessage
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.MessageContractAttribute(WrapperName:="MessageStringResponse", WrapperNamespace:="http://tempuri.org/", IsWrapped:=true)>  _
    Partial Public Class MessageStringResponse
        
        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="http://tempuri.org/", Order:=0)>  _
        Public MessageStringResult As Long
        
        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="http://tempuri.org/", Order:=1)>  _
        Public pv_strMessage As String
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal MessageStringResult As Long, ByVal pv_strMessage As String)
            MyBase.New
            Me.MessageStringResult = MessageStringResult
            Me.pv_strMessage = pv_strMessage
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.MessageContractAttribute(WrapperName:="MessageByte", WrapperNamespace:="http://tempuri.org/", IsWrapped:=true)>  _
    Partial Public Class MessageByteRequest
        
        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="http://tempuri.org/", Order:=0)>  _
        Public pv_arrByteMessage() As Byte
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal pv_arrByteMessage() As Byte)
            MyBase.New
            Me.pv_arrByteMessage = pv_arrByteMessage
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.MessageContractAttribute(WrapperName:="MessageByteResponse", WrapperNamespace:="http://tempuri.org/", IsWrapped:=true)>  _
    Partial Public Class MessageByteResponse
        
        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="http://tempuri.org/", Order:=0)>  _
        Public MessageByteResult As Long
        
        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="http://tempuri.org/", Order:=1)>  _
        Public pv_arrByteMessage() As Byte
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal MessageByteResult As Long, ByVal pv_arrByteMessage() As Byte)
            MyBase.New
            Me.MessageByteResult = MessageByteResult
            Me.pv_arrByteMessage = pv_arrByteMessage
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.MessageContractAttribute(WrapperName:="GetErrorMessage", WrapperNamespace:="http://tempuri.org/", IsWrapped:=true)>  _
    Partial Public Class GetErrorMessageRequest
        
        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="http://tempuri.org/", Order:=0)>  _
        Public pv_lngErrorCode As Long
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal pv_lngErrorCode As Long)
            MyBase.New
            Me.pv_lngErrorCode = pv_lngErrorCode
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.MessageContractAttribute(WrapperName:="GetErrorMessageResponse", WrapperNamespace:="http://tempuri.org/", IsWrapped:=true)>  _
    Partial Public Class GetErrorMessageResponse
        
        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="http://tempuri.org/", Order:=0)>  _
        Public GetErrorMessageResult As String
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal GetErrorMessageResult As String)
            MyBase.New
            Me.GetErrorMessageResult = GetErrorMessageResult
        End Sub
    End Class
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Public Interface IHOSTRptServiceChannel
        Inherits HOSTRptService.IHOSTRptService, System.ServiceModel.IClientChannel
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Partial Public Class HOSTRptServiceClient
        Inherits System.ServiceModel.ClientBase(Of HOSTRptService.IHOSTRptService)
        Implements HOSTRptService.IHOSTRptService
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String)
            MyBase.New(endpointConfigurationName)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(binding, remoteAddress)
        End Sub
        
        Public Function DoWork(ByVal request As HOSTRptService.DoWorkRequest) As HOSTRptService.DoWorkResponse Implements HOSTRptService.IHOSTRptService.DoWork
            Return MyBase.Channel.DoWork(request)
        End Function
        
        Public Function DoWorkAsync(ByVal request As HOSTRptService.DoWorkRequest) As System.Threading.Tasks.Task(Of HOSTRptService.DoWorkResponse) Implements HOSTRptService.IHOSTRptService.DoWorkAsync
            Return MyBase.Channel.DoWorkAsync(request)
        End Function
        
        Public Function MessageString(ByVal request As HOSTRptService.MessageStringRequest) As HOSTRptService.MessageStringResponse Implements HOSTRptService.IHOSTRptService.MessageString
            Return MyBase.Channel.MessageString(request)
        End Function
        
        Public Function MessageStringAsync(ByVal request As HOSTRptService.MessageStringRequest) As System.Threading.Tasks.Task(Of HOSTRptService.MessageStringResponse) Implements HOSTRptService.IHOSTRptService.MessageStringAsync
            Return MyBase.Channel.MessageStringAsync(request)
        End Function
        
        Public Function MessageByte(ByVal request As HOSTRptService.MessageByteRequest) As HOSTRptService.MessageByteResponse Implements HOSTRptService.IHOSTRptService.MessageByte
            Return MyBase.Channel.MessageByte(request)
        End Function
        
        Public Function MessageByteAsync(ByVal request As HOSTRptService.MessageByteRequest) As System.Threading.Tasks.Task(Of HOSTRptService.MessageByteResponse) Implements HOSTRptService.IHOSTRptService.MessageByteAsync
            Return MyBase.Channel.MessageByteAsync(request)
        End Function
        
        Public Function GetErrorMessage(ByVal request As HOSTRptService.GetErrorMessageRequest) As HOSTRptService.GetErrorMessageResponse Implements HOSTRptService.IHOSTRptService.GetErrorMessage
            Return MyBase.Channel.GetErrorMessage(request)
        End Function
        
        Public Function GetErrorMessageAsync(ByVal request As HOSTRptService.GetErrorMessageRequest) As System.Threading.Tasks.Task(Of HOSTRptService.GetErrorMessageResponse) Implements HOSTRptService.IHOSTRptService.GetErrorMessageAsync
            Return MyBase.Channel.GetErrorMessageAsync(request)
        End Function
    End Class
End Namespace
