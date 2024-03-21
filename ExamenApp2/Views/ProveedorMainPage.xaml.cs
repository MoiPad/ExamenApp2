using ExamenApp2.ViewModels;

namespace ExamenApp2.Views;

public partial class ProveedorMainPage : ContentPage
{
	private ProveedorMainPageViewModel viewModel;
	public ProveedorMainPage()
	{
		InitializeComponent();
		viewModel = new ProveedorMainPageViewModel();
		this.BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		viewModel.GetAll();
    }
}