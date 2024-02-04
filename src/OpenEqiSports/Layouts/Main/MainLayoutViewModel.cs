using Material.Components.Maui;
using OpenEqiSports.Modules;

namespace OpenEqiSports.Layouts.Main;

public class MainLayoutViewModel
{
    public List<NavigationBarItem> Items { get;  }

    public MainLayoutViewModel(IEnumerable<IModuleRootPage> moduleRootPages)
    {
        Items = GenerateNavigationBarItems(moduleRootPages);
    }

    private List<NavigationBarItem> GenerateNavigationBarItems(IEnumerable<IModuleRootPage> moduleRoots)
    {
        List<NavigationBarItem> items = moduleRoots.Select(moduleRoot => new NavigationBarItem { Text = "TITLE", IconData = moduleRoot.Icon }).ToList();
        return items;
    }
}