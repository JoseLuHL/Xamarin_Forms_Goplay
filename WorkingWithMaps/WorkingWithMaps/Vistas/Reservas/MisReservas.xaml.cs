using BurgerSpot.Views;
using PropertyApp.Modelo;
using PropertyApp.VistaModelo;
using System;
using WorkingWithMaps.Modelo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlacesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MisReservas : ContentPage
    {
        ReservaVistaModelo misReservasVistaModelo => ((ReservaVistaModelo)BindingContext);
        public MisReservas()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            //Page.Reservas = null;
            //Page.IsActivado = false;
        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchBar.Text))
            {
                misReservasVistaModelo.buscarReserca.Execute(SearchBar.Text);

                //Page.Reservas = null;
            }
        }

        private async void vistaReservas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ReservaModelo datos = e.CurrentSelection[0] as ReservaModelo;

                if (datos == null)
                    return;
                var horario = new HorarioModelo
                {
                    Id = datos.IdhorarioNavigation.Id,
                    Fecha = datos.Fecha,
                    Hora = datos.HoraInicio,
                    NombreCancha = datos.IdhorarioNavigation.IdCanchaNavigation.PageTitle,
                    Usuario = datos.Usuario,
                    Imagen = datos.IdhorarioNavigation.IdCanchaNavigation.Avatar,
                    Precio = datos.IdhorarioNavigation.ProPrecio,
                    Estado = datos.IdestadoNavigation.Descripcion,
                    idEstado = datos.Idestado,
                    IsBoton = false
                };
                if (horario.idEstado == 6)
                {
                    horario.IsBoton = true;
                }

                misReservasVistaModelo.HorariosSelect = horario;
                await Navigation.PushModalAsync(new DetalleReserva { BindingContext = misReservasVistaModelo });
                //await DisplayAlert("", datos.IdhorarioNavigation.IdCanchaNavigation.PageTitle, "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("", ex.ToString(), "OK");
            }

        }
    }
}