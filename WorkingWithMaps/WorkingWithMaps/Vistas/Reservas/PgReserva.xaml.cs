
using Amazon.SimpleNotificationService.Util;
using BurgerSpot.Views;
using PropertyApp.Modelo;
using PropertyApp.Servicio;
using PropertyApp.url;
using PropertyApp.VistaModelo;
using System;
using System.Linq;
using System.Threading.Tasks;
using WorkingWithMaps.Servicio;
using WSGOPLAY.Models;
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
                //var item = CambioModelo.HorarioModelo(item1);

                if (item==null)
                {
                    Contexto.IsBusy = false;
                    await DisplayAlert("", "Vuelva a intentarlo", "OK");
                    return;
                }

                Contexto.HorariosSelect = item;
                if (item.Estado != "Disponible")
                {
                    //Contexto.IsBusy = false;
                    if (item.Estado == "En reserva")
                    {
                        var estado1 = await ReservaEstadoStatic.EstadoDisponible(item.Id, item.Fecha, item.Hora);
                        //await DisplayAlert("", estado1.IdReserva.ToString(), "OK");
                        if (estado1!=null)
                        {
                            //Eliminar la reserva
                            //await DisplayAlert("", "El pago ha sido rechachazado \n Vulava a intentarlo", "OK");
                            //GoPlayServicio playServicio = new GoPlayServicio();
                            //var ope = await playServicio.DeleteAsync(Url.urlReserva + "/" + estado1.IdReserva);
                            var ope = await OperacionesCRUD.EliminarAsync(Url.urlReserva + "/" + estado1.IdReserva);
                            await Contexto.Load();
                            if (ope == false)
                            {
                                Contexto.IsBusy = false;
                                await DisplayAlert("", "Lo sentomos al parecer hay un poblema \n vuelva a intentarlo", "OK");
                                return;
                            }
                        }
                        else
                        {
                            Contexto.IsBusy = false;
                            await DisplayAlert("", "El horario no esta disponible", "OK");
                            return;
                        }
                    }
                    else
                    {
                        Contexto.IsBusy = false;
                        await DisplayAlert("", "El horario no esta disponible", "OK");
                        return;
                    }
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

