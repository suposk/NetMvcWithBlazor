using Microsoft.Extensions.DependencyInjection;

namespace RazMudBla;

public static class DependencyInjection
{
    /// <summary>
    /// Common Service registration
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection RegisterRazMudBlaServices(this IServiceCollection services)
    {
        services.AddScoped<ICustomDialogService, CustomDialogService>();

        //AddSingleton
        //services.AddSingleton<ICacheProvider, CacheProvider>(); //can be configer in config setting in appsettings.json
        return services;
    }
}
