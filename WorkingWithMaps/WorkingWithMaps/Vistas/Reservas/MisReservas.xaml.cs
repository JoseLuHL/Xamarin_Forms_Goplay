using BurgerSpot.Views;
using PropertyApp.Modelo;
using PropertyApp.url;
using PropertyApp.VistaModelo;
using System;
using WorkingWithMaps.Modelo;
using WorkingWithMaps.Servicio;
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
                misReservasVistaModelo.IsBusy = true;
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
                    var estado1 = await ReservaEstadoStatic.EstadoDisponible(horario.Id, horario.Fecha, horario.Hora);
                    //await DisplayAlert("", estado1.IdReserva.ToString(), "OK");
                    if (estado1 != null)
                    {
                        if (estado1.Usuario==horario.Usuario)
                        {
                            horario.IsBoton = true;
                        }
                        else
                        {
                            misReservasVistaModelo.IsBusy = false;
                            misReservasVistaModelo.buscarReserca.Execute(SearchBar.Text);
                            return;
                        }
                    }
                }

                misReservasVistaModelo.IsBusy = false;
                misReservasVistaModelo.HorariosSelect = horario;
                await Navigation.PushModalAsync(new DetalleReserva { BindingContext = misReservasVistaModelo });

            }
            catch (Exception ex)
            {
                await DisplayAlert("", ex.ToString(), "OK");
            }
        }
    }
}