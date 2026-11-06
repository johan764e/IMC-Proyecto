using Microsoft.Maui.Controls;
using IMC_MVVM_JAPD.ViewModels;

namespace IMC_MVVM_JAPD.Views;

public partial class ImcPage : ContentPage
{
    public ImcPage()
    {
        InitializeComponent();
        BindingContext = new ImcViewModel();
    }
}