using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExamenApp2.Models;
using ExamenApp2.Services;


namespace ExamenApp2.ViewModels
{
    public partial class ProveedorFormPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private string nombre;

        [ObservableProperty]
        private string tipo;

        [ObservableProperty]
        private string telefono;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string servicio;

        [ObservableProperty]
        private string direccion;

        private readonly ProveedoresServices proveedoresServices;

        public ProveedorFormPageViewModel() 
        {
            proveedoresServices = new ProveedoresServices();
        }

        public ProveedorFormPageViewModel(Proveedor proveedor)
        {
            Id = proveedor.Id;
            Nombre = proveedor.Nombre;
            Tipo = proveedor.Tipo;
            Telefono = proveedor.Telefono;
            Email = proveedor.Email;
            Servicio = proveedor.Servicio;
            Direccion = proveedor.Direccion;

            proveedoresServices = new ProveedoresServices();

        }

        [RelayCommand]
        private async Task CreateUpdate()
        {
            try 
            {
                Proveedor proveedor = new Proveedor
                {
                    Id = id,
                    Nombre = nombre,
                    Tipo = tipo,
                    Telefono = telefono,
                    Email = email,
                    Servicio = servicio,
                    Direccion = direccion
                };

                if(Validar(proveedor))
                {
                    if(Id == 0)
                    {
                        proveedoresServices.Insert(proveedor);
                    }
                    else 
                    {
                        proveedoresServices.Update(proveedor);  
                    }

                    await App.Current!.MainPage!.Navigation.PopAsync();
                }
            
            }catch (Exception ex) 
            {
                Alerta("Error!", $"Excepción: {ex.Message}");
            }
        }

        private bool Validar(Proveedor proveedor)
        {
            try
            {
                if(string.IsNullOrEmpty(proveedor.Nombre))
                {
                    Alerta("Advertencia!","Los campos no pueder ir vacios, escriba el nombre");
                    return false; 
                }
                else if (string.IsNullOrEmpty(proveedor.Tipo))
                {
                    Alerta("Advertencia!", "Los campos no pueder ir vacios, escriba el tipo de proveedor");
                    return false;
                }
                else if (string.IsNullOrEmpty(proveedor.Telefono))
                {
                    Alerta("Advertencia!", "Los campos no pueder ir vacios, escriba el telefono");
                    return false;
                }
                else if (string.IsNullOrEmpty(proveedor.Email))
                {
                    Alerta("Advertencia!", "Los campos no pueder ir vacios, escriba el correo");
                    return false;
                }
                else if (string.IsNullOrEmpty(proveedor.Servicio))
                {
                    Alerta("Advertencia!", "Los campos no pueder ir vacios, escriba el servicio");
                    return false;
                }
                else if (string.IsNullOrEmpty(proveedor.Direccion))
                {
                    Alerta("Advertencia!", "Los campos no pueder ir vacios, escriba la dirección");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex) 
            {
                Alerta("Error", $"Excepción: {ex.Message}");
                return false;
            }
        }

        private void Alerta(string tipo, string mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(tipo, mensaje, "Aceptar"));
        }




    }
}
