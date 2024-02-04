namespace OpenEqiSports.Modules.Overview;

public partial class Overview : IModuleRootPage
{
    public Overview()
    {
        InitializeComponent();
    }

    public string Icon => IconPacks.IconKind.Material.Overview;
}