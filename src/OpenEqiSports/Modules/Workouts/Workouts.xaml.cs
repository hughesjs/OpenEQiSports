namespace OpenEqiSports.Modules.Workouts;

public partial class Workouts : IModuleRootPage
{
    public Workouts()
    {
        InitializeComponent();
    }

    public string Icon => IconPacks.IconKind.Material.FitnessCenter;
}