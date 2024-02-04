namespace OpenEqiSports.Modules.History;

public partial class History : IModuleRootPage
{
    public History()
    {
        InitializeComponent();
    }

    public string Icon => IconPacks.IconKind.Material.History;
}