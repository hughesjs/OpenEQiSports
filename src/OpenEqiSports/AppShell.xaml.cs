using OpenEqiSports.Layouts.Main;

namespace OpenEqiSports;

public partial class AppShell : Shell
{
    public AppShell(MainLayout mainLayout)
    {
        ShellContent.ContentTemplate = new(() => mainLayout);
        InitializeComponent();
    }
}