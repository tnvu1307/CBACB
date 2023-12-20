﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On



<System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
 System.ServiceModel.ServiceContractAttribute(ConfigurationName:="IHostServiceStreamed")>  _
Public Interface IHostServiceStreamed
    
    <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IHostServiceStreamed/UploadFile", ReplyAction:="http://tempuri.org/IHostServiceStreamed/UploadFileResponse")>  _
    Function UploadFile(ByVal data() As Byte, ByVal fieldname As String, ByVal pk_fieldname As String, ByVal pk_value As String, ByVal tableName As String) As Long
    
    <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IHostServiceStreamed/UploadFile", ReplyAction:="http://tempuri.org/IHostServiceStreamed/UploadFileResponse")>  _
    Function UploadFileAsync(ByVal data() As Byte, ByVal fieldname As String, ByVal pk_fieldname As String, ByVal pk_value As String, ByVal tableName As String) As System.Threading.Tasks.Task(Of Long)
    
    <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IHostServiceStreamed/DownloadFile", ReplyAction:="http://tempuri.org/IHostServiceStreamed/DownloadFileResponse")>  _
    Function DownloadFile(ByVal pv_FieldName As String, ByVal pv_pkFieldName As String, ByVal pv_pkValue As String, ByVal pv_TableName As String) As Byte()
    
    <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IHostServiceStreamed/DownloadFile", ReplyAction:="http://tempuri.org/IHostServiceStreamed/DownloadFileResponse")>  _
    Function DownloadFileAsync(ByVal pv_FieldName As String, ByVal pv_pkFieldName As String, ByVal pv_pkValue As String, ByVal pv_TableName As String) As System.Threading.Tasks.Task(Of Byte())
End Interface

<System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
Public Interface IHostServiceStreamedChannel
    Inherits IHostServiceStreamed, System.ServiceModel.IClientChannel
End Interface

<System.Diagnostics.DebuggerStepThroughAttribute(),  _
 System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
Partial Public Class HostServiceStreamedClient
    Inherits System.ServiceModel.ClientBase(Of IHostServiceStreamed)
    Implements IHostServiceStreamed
    
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
    
    Public Function UploadFile(ByVal data() As Byte, ByVal fieldname As String, ByVal pk_fieldname As String, ByVal pk_value As String, ByVal tableName As String) As Long Implements IHostServiceStreamed.UploadFile
        Return MyBase.Channel.UploadFile(data, fieldname, pk_fieldname, pk_value, tableName)
    End Function
    
    Public Function UploadFileAsync(ByVal data() As Byte, ByVal fieldname As String, ByVal pk_fieldname As String, ByVal pk_value As String, ByVal tableName As String) As System.Threading.Tasks.Task(Of Long) Implements IHostServiceStreamed.UploadFileAsync
        Return MyBase.Channel.UploadFileAsync(data, fieldname, pk_fieldname, pk_value, tableName)
    End Function
    
    Public Function DownloadFile(ByVal pv_FieldName As String, ByVal pv_pkFieldName As String, ByVal pv_pkValue As String, ByVal pv_TableName As String) As Byte() Implements IHostServiceStreamed.DownloadFile
        Return MyBase.Channel.DownloadFile(pv_FieldName, pv_pkFieldName, pv_pkValue, pv_TableName)
    End Function
    
    Public Function DownloadFileAsync(ByVal pv_FieldName As String, ByVal pv_pkFieldName As String, ByVal pv_pkValue As String, ByVal pv_TableName As String) As System.Threading.Tasks.Task(Of Byte()) Implements IHostServiceStreamed.DownloadFileAsync
        Return MyBase.Channel.DownloadFileAsync(pv_FieldName, pv_pkFieldName, pv_pkValue, pv_TableName)
    End Function
End Class
