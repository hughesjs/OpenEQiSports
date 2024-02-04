using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenEqiSports.Modules.History;

public partial class History : IModuleRootPage
{
    public History()
    {
        InitializeComponent();
    }

    public string Icon => IconPacks.IconKind.Material.History;
}