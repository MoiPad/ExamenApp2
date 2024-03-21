using ExamenApp2.Models;
using ExamenApp2.ViewModels;

namespace ExamenApp2.Views;

public partial class ProveedorFormPage : ContentPage
{
	private ProveedorFormPageViewModel viewModel;
	public ProveedorFormPage()
	{
		InitializeComponent();
		viewModel = new ProveedorFormPageViewModel();
		this.BindingContext = viewModel;
	}

	public ProveedorFormPage(Proveedor proveedor)
	{
        InitializeComponent();
		viewModel = new ProveedorFormPageViewModel(proveedor);
		this.BindingContext = viewModel;
    }
}