namespace OpenEqiSports.Modules.Settings;

public partial class Settings : IModuleRootPage
{
    public Settings()
    {
        InitializeComponent();
    }

    public string Icon => IconPacks.IconKind.Material.Settings;
}