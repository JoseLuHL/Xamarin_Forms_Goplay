using PlacesApp.Views;
using Plugin.Messaging;
using PropertyApp.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkingWithMaps;
using WorkingWithMaps.Modelo;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.OpenWhatsApp;
using Xamarin.Forms.Xaml;

namespace PropertyApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        Property cont;
        public DetailsPage(Property property)
        {
            InitializeComponent();
            this.Property = property;
            cont = new Property();
            cont = property;
            this.BindingContext = this;
            
        }

        public Property Property { get; set; }

        private void GoBack(object sender, EventArgs e)
        {
            this.Navigation.PopModalAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            DetailsView.TranslationY = 600;
            DetailsView.TranslateTo(0, 0, 500, Easing.SinInOut);
        }

        private async void BtnReservar_Clicked(object sender, EventArgs e)
        {
            var contexto = new ReservaVistaModelo(cont.Id);
            var PgReserva = new PgReserva();
            PgReserva.id = cont.Id;
            PgReserva.BindingContext = contexto;
            await Navigation.PushModalAsync(PgReserva);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            try
            {
                PhoneDialer.Open(cont.Bed);
            }
            catch (ArgumentNullException anEx)
            {
                // Number was null or white space
                DisplayAlert("","No se ha proporcionado numero telefonico","OK");
            }
            catch (FeatureNotSupportedException ex)
            {
                DisplayAlert("", "No se ha proporcionado numero telefonico", "OK");

                // Phone Dialer is not supported on this device.
            }
            catch (Exception ex)
            {
                DisplayAlert("", "No se ha proporcionado numero telefonico", "OK");
            }
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            try
            {
                Chat.Open("+57"+ cont.Bed, "Hola!");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new PinPage(cont));
        }
    }
}