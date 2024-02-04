using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenEqiSports.Modules.Overview;

public partial class Overview : IModuleRootPage
{
    public Overview()
    {
        InitializeComponent();
    }

    public string Icon => IconPacks.IconKind.Material.Overview;
}