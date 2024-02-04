using Material.Components.Maui.Extensions;
using Microsoft.Maui.Platform;
using OpenEqiSports.Layouts.Main;
using OpenEqiSports.Modules;

namespace OpenEqiSports.DependencyInjection;

public static class DependencyInjectionExtensions
{
    public static MauiAppBuilder AddFrontend(this MauiAppBuilder builder)
    {
        builder.UseMaterialComponents();
        builder.Services.AddLayouts();
        builder.Services.AddSingleton<AppShell>();
        builder.Services.AddModuleRoots();
        return builder;
    }

    private static IServiceCollection AddLayouts(this IServiceCollection services)
    {
        services.AddSingleton<MainLayout>();
        services.AddTransient<MainLayoutViewModel>();
        return services;
    }

    private static IServiceCollection AddModuleRoots(this IServiceCollection services)
    {
        List<Type> moduleRoots = typeof(App).Assembly.GetTypes()
            .Where(x => x.IsAssignableTo(typeof(IModuleRootPage)) && x is { IsInterface: false, IsAbstract: false })
            .ToList();
        
        foreach (Type screen in moduleRoots)
        {
            services.Add(new(typeof(IModuleRootPage), screen, ServiceLifetime.Singleton));
        }
        
        return services;
    }
}