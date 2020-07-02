using Amazon.SimpleNotificationService.Util;
using Newtonsoft.Json;
using PropertyApp.Servicio;
using PropertyApp.url;
using PropertyApp.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WorkingWithMaps.Modelo;
using WSGOPLAY.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkingWithMaps.Vistas.Reservas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagosVista : ContentPage
    {
        ReservaModelo Contexto => ((ReservaModelo)BindingContext);

        //public string precio { get; set; }
        //public string description { get; set; }
        public PagosVista()
        {
            InitializeComponent();
            Webview.IsVisible = true;

        }

        protected async override void OnAppearing()
        {
            //var c = Contexto;
            base.OnAppearing();
            await progress.ProgressTo(0.9, 900, Easing.SpringIn);
            await TasAsync();
        }

        protected void OnNavigating(object sender, WebNavigatingEventArgs e)
        {
            progress.IsVisible = true;
        }

        protected async void OnNavigated(object sender, WebNavigatedEventArgs e)
        {
            progress.IsVisible = false;
            try
            {
                Contexto.IsBusy = true;
                var urlweb = e.Url;
                var url = urlweb.Split('?');
                var ref_payco = url[1].Split('=');
                if (ref_payco[0] == "ref_payco")
                {
                    await DisplayAlert("", ref_payco[1], "OK");
                    await Epayco(ref_payco[1]);
                }
            }
            catch (Exception)
            {
            }
            Contexto.IsBusy = false;
        }

        async Task Epayco(string refe)
        {
            var contenido = new EpayCoModelo();
            var cliente = new HttpClient();
            GoPlayServicio playServicio = new GoPlayServicio();
            var urlapp = "https://secure.epayco.co/validation/v1/reference/" + refe;
            var http = new HttpClient();
            var res = await http.GetAsync(urlapp);
            var response = await res.Content.ReadAsStringAsync();
            contenido = JsonConvert.DeserializeObject<EpayCoModelo>(response);

            var goplay = new GoPlayServicio();
            Contexto.Reto = refe;


            if (contenido.data.x_response == "Aceptada")
            {
                //Acuatular el estado de la cancha
                await DisplayAlert("", "Cancha reservada", "OK");
                Contexto.Idestado = 2;
                var ope = await goplay.PutActualizarAsync(Contexto, Url.urlReserva + "/" + Contexto.IdReserva);
                if (ope.Estado == false)
                {
                    Contexto.IsBusy = false;
                    await DisplayAlert("", "Lo sentomos al parecer hay un poblema \n vuelva a intentarlo", "OK");
                }
                //
            }

            else if (contenido.data.x_response == "Pendiente")
            {
                //Acuatular el estado de la cancha
                await DisplayAlert("", "Si en 40 minutos no ha completado el pago \n su reserva sera cancelada", "OK");
                Contexto.Idestado = 1;
                var ope = await goplay.PutActualizarAsync(Contexto, Url.urlReserva+"/"+ Contexto.IdReserva);
                if (ope.Estado == false)
                {
                    Contexto.IsBusy = false;
                    await DisplayAlert("", "Lo sentomos al parecer hay un poblema \n vuelva a intentarlo", "OK");
                    return;
                }
            }

            else if (contenido.data.x_response == "Rechazada")
            {
                //Eliminar la reserva
                await DisplayAlert("", "El pago ha sido rechachazado \n Vulava a intentarlo", "OK");
                var ope = await goplay.DeleteAsync(Url.urlReserva + "/" + Contexto.IdReserva);
                if (ope.Estado == false)
                {
                    Contexto.IsBusy = false;
                    await DisplayAlert("", "Lo sentomos al parecer hay un poblema \n vuelva a intentarlo", "OK");
                    return;
                }
            }

            else
            {
                //Eliminar la reserva
                await DisplayAlert("", "El pago ha sido rechachazado \n Vulava a intentarlo", "OK");
                var ope = await goplay.DeleteAsync(Url.urlReserva + "/" + Contexto.IdReserva);
                if (ope.Estado == false)
                {
                    Contexto.IsBusy = false;
                    await DisplayAlert("", "Lo sentomos al parecer hay un poblema \n vuelva a intentarlo", "OK");
                    return;
                }
            }


        }

        async Task TasAsync()
        {
            Webview.IsVisible = false;
            await Task.Delay(2000);
            //progress.IsVisible = false;
            Webview.IsVisible = true;

            var url = $"http://192.168.1.10:8080/prueba/prueba.php?hora={Contexto.HoraInicio}&horario={Contexto.Idhorario}&tel={Contexto.Tel}&precio={Contexto.HoraFinal}&descripcion={Contexto.Reserva1.Replace(" ", "%20")}";
            Webview.Source = url;
            //Webview.Source = "http://192.168.1.10:8080/sesiones-master/sesion.php";

        }
    }
}