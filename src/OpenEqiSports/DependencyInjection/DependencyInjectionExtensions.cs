using Material.Components.Maui.Extensions;
using Microsoft.Maui.Platform;

namespace OpenEqiSports.DependencyInjection;

public static class DependencyInjectionExtensions
{
    public static MauiAppBuilder AddFrontend(this MauiAppBuilder builder)
    {
        builder.UseMaterialComponents();
        builder.Services.AddSingleton<AppShell>();
        builder.Services.AddAllScreens();
        return builder;
    }
    
    public static IServiceCollection AddAllScreens(this IServiceCollection services)
    {
        List<Type> screens = typeof(App).Assembly.GetTypes()
            .Where(x => x.IsSubclassOf(typeof(ContentPage)))
            .ToList();
        
        foreach (Type screen in screens)
        {
            services.AddSingleton(screen);
        }
        
        return services;
    }
}