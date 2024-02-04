namespace OpenEqiSports.Layouts.Main;

public partial class MainLayout : ContentPage
{
    public MainLayout(MainLayoutViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
}