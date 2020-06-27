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

            if (TxtCodigoverificacion.Text.Trim() != contexto.codigoVerificacion)
            {
                await DisplayAlert("Error", "Numero de verificacion no valido", "OK");
                return;
            }



            //var confirmar = await Application.Current.MainPage.DisplayAlert("Confirmar",
            //    $"Datos de la reserva \n\n Cancha: {contexto.} \n Fecha: {contexto.fecha} \n Hora: {contextohora} \n Precio: {contextoprecio} ",
            //    "SI", "NO");
            //if (!confirmar)
            //    return;

            await Application.Current.MainPage.Navigation.PushModalAsync(new PagosVista {BindingContext = contexto });

        }
    }
}