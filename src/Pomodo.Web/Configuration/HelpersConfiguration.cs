using Pomodo.Infrastructure.Helpers;

namespace Pomodo.Web.Configuration;

public static class HelpersConfiguration
{
    public static IServiceCollection AddHelpers(this IServiceCollection serviceCollection) =>
        serviceCollection.AddSingleton<IAboutInfoHelper, AboutInfoHelper>();
}