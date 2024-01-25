Imports Microsoft.Extensions.DependencyInjection
Imports EasyCaching.Core.Configurations
Imports EasyCaching.InMemory
Imports EasyCaching.Core

Module CachingConfigurator
    Private ReadOnly _serviceProvider As ServiceProvider

    Sub New()
        Dim services = New ServiceCollection()

        ' Configure EasyCaching to use in-memory caching
        services.AddEasyCaching(Sub(options)
                                    ' Register in-memory caching as the caching provider
                                    options.UseInMemory("Host_Cache_Manager")
                                End Sub)

        ' Build the service provider
        _serviceProvider = services.BuildServiceProvider()
    End Sub

    Public Function GetCachingProviderFactory() As IEasyCachingProviderFactory
        ' Get the caching provider factory
        Return _serviceProvider.GetService(Of IEasyCachingProviderFactory)()
    End Function
End Module
