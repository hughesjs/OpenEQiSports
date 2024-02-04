using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenEqiSports.Layouts.Main;

namespace OpenEqiSports;

public partial class MainLayout : ContentPage
{
    public MainLayout(MainLayoutViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
}