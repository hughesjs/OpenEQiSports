namespace OpenEqiSports.DependencyInjection;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddFrontend(this IServiceCollection services)
    {
        services.AddSingleton<AppShell>();
        services.AddAllScreens();
        return services;
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