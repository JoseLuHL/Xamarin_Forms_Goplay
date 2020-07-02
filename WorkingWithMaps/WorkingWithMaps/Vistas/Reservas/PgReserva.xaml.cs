
using Amazon.SimpleNotificationService.Util;
using BurgerSpot.Views;
using PropertyApp.Modelo;
using PropertyApp.VistaModelo;
using System;
using System.Linq;
using System.Threading.Tasks;
using WorkingWithMaps.Servicio;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlacesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PgReserva : ContentPage
    {
        //Place Place => ((Place)BindingContext);
        ReservaVistaModelo Contexto => ((ReservaVistaModelo)BindingContext);
        public string id { get; set; }
        public PgReserva()
        {
            //BindingContext = context;
            InitializeComponent();
            //NavigationPage.SetHasBackButton(this, false);
            this.id = id;
            //descriptionContainer.FadeTo(1, 350, Easing.CubicInOut);
            //descriptionContainer.TranslateTo(0, 0, 350, Easing.CubicInOut);
        }


        protected override async void OnAppearing()
        {
            //var contexto = new ReservaVistaModelo(id);
            //BindingContext = contexto;
        }

        private async void listViewEjemplo1_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                Contexto.IsBusy = true;
                var item = e.SelectedItem as HorarioModelo;

                if (item==null)
                {
                    Contexto.IsBusy = false;
                    await DisplayAlert("", "Vuelva a intentarlo", "OK");
                    return;
                }

                Contexto.HorariosSelect = item;
                if (item.Estado != "Disponible")
                {
                    Contexto.IsBusy = false;
                    await DisplayAlert("", "El horario no esta disponible", "OK");
                    return;
                }

                var estado = await ReservaEstadoStatic.Estado(item.Id, item.Fecha, item.Hora);

                if (estado)
                {
                    Contexto.IsBusy = false;
                    await DisplayAlert("", "El horario no esta disponible", "OK");
                    await Contexto.Load();
                    return;
                }

                await Navigation.PushModalAsync(new DetalleReserva { BindingContext = Contexto });
                Contexto.IsBusy = false;
            }
            catch (Exception)
            {
                Contexto.IsBusy = false;
                await DisplayAlert("", "Vuelva a intentarlo","OK");
            }
        }

        private async void date_DateSelected(object sender, DateChangedEventArgs e)
        {
            Contexto.IsBusy = true;
            await Task.Delay(2000);
            Contexto.Fecha = date.Date.ToShortDateString();
            Contexto.FechaComando.Execute(false);
            Contexto.IsBusy = false;
        }
    }
}

