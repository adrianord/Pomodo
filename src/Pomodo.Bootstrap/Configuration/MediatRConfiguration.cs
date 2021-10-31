using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Pomodo.Bootstrap.Helpers;

namespace Pomodo.Bootstrap.Configuration;

public static class MediatRConfiguration
{
    public static IServiceCollection AddMediatRWithAssemblyScanning(this IServiceCollection services) =>
        services.AddMediatR(AssemblyScanner.GetAssemblies());

}