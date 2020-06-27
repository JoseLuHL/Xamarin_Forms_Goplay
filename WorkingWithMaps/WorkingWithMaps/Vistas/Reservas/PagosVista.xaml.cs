using PropertyApp.url;
using PropertyApp.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
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
            TasAsync();
        }

        protected void OnNavigating(object sender, WebNavigatingEventArgs e)
        {
            progress.IsVisible = true;
        }

        protected void OnNavigated(object sender, WebNavigatedEventArgs e)
        {
            progress.IsVisible = false;
            try
            {
                var urlweb = e.Url;
                var url = urlweb.Split('?');
                var ref_payco = url[1].Split('=');
                if (ref_payco[0] == "ref_payco")
                {
                    DisplayAlert("", ref_payco[1], "OK");
                }
            }
            catch (Exception)
            {
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