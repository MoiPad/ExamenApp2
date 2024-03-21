

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExamenApp2.Models;
using ExamenApp2.Services;
using ExamenApp2.Views;
using System.Collections.ObjectModel;

namespace ExamenApp2.ViewModels
{
    public partial class ProveedorMainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Proveedor> proveedorCollection = new ObservableCollection<Proveedor>();

        private readonly ProveedoresServices proveedoresServices;

        public ProveedorMainPageViewModel()
        {
            proveedoresServices = new ProveedoresServices();
        }

        public void GetAll()
        {
            var getAll = proveedoresServices.GetAll();

            if(getAll.Count > 0)
            {
                ProveedorCollection.Clear();

                foreach (var proveedor in getAll)
                {
                    ProveedorCollection.Add(proveedor);
                }
            }
        }

        [RelayCommand]
        private async Task GotoProveedorFormPage()
        {
            await App.Current!.MainPage!.Navigation.PushAsync(new ProveedorFormPage());
        }

        [RelayCommand]
        private async Task SelectProveedor(Proveedor proveedor)
        {
            try
            {
                string res = await App.Current!.MainPage!.DisplayActionSheet("Operación","Cancelar", null, "Actualizar", "Eliminar");

                switch(res)
                {
                    case "Actualizar":
                        await App.Current.MainPage.Navigation.PushAsync(new ProveedorFormPage(proveedor));
                        break;

                    case "Eliminar":

                        bool respuesta = await App.Current!.MainPage!.DisplayAlert("Eliminar Proveedor","¿Esta seguro de eliminar el proveedor?", "Si", "No");

                        if(respuesta)
                        {
                            int del = proveedoresServices.Delete(proveedor);
                            if(del > 0)
                            {
                                ProveedorCollection.Remove(proveedor);
                            }
                        }
                        break;  
                }

            }catch (Exception ex) 
            {
                Alerta("Error!", $"Excepción{ex.Message}");
            }
        }

        private void Alerta(string tipo, string mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(tipo, mensaje, "Aceptar"));
        }
    }
}
