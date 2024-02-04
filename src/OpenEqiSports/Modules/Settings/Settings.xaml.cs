using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenEqiSports.Modules.Settings;

public partial class Settings : IModuleRootPage
{
    public Settings()
    {
        InitializeComponent();
    }

    public string Icon => IconPacks.IconKind.Material.Settings;
}