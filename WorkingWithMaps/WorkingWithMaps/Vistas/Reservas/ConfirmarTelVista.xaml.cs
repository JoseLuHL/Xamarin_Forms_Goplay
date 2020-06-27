using PropertyApp.Servicio;
using PropertyApp.url;
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
    public partial class ConfirmarTelVista : ContentPage
    {
        public string codigoVerificacion { get; set; }
        ReservaModelo contexto => ((ReservaModelo)BindingContext);
        public ConfirmarTelVista()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Lblmensaje.Text = $"Se ha enviado un mensaje a su telefono {contexto.Tel}";
        }

        private async void BtnContinuar_Clicked(object sender, EventArgs e)
        {
            contexto.IsBusy = true;
            if (TxtCodigoverificacion.Text.Trim() != contexto.codigoVerificacion)
            {
                await DisplayAlert("Error", "Numero de verificacion no valido", "OK");
                contexto.IsBusy =false;
                return;
            }

            //var confirmar = await Application.Current.MainPage.DisplayAlert("Confirmar",
            //    $"Datos de la reserva \n\n Cancha: {contexto.} \n Fecha: {contexto.fecha} \n Hora: {contextohora} \n Precio: {contextoprecio} ",
            //    "SI", "NO");
            //if (!confirmar)
            //    return;
            try
            {
                var goplay = new GoPlayServicio();
                var res = await goplay.PostGuardarAsync(contexto, Url.urlReserva);
                if (res.Estado == false)
                {
                    contexto.IsBusy = false;
                    await DisplayAlert("", "Lo sentomos al parecer hay un poblema \n vuelva a intentarlo", "OK");
                    return;
                }
                await Application.Current.MainPage.Navigation.PushModalAsync(new PagosVista { BindingContext = contexto });
            }
            catch (Exception ex)
            {
                await DisplayAlert("", ex.ToString(), "OK");
                contexto.IsBusy = false;
            }
            contexto.IsBusy = false;

        }
    }
}