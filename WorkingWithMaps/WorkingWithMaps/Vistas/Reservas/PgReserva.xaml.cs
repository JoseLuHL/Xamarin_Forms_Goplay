
using BurgerSpot.Views;
using PropertyApp.Modelo;
using PropertyApp.VistaModelo;
using System;
using System.Linq;
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
        public PgReserva(string id)
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
            var contexto = new ReservaVistaModelo(id);
            BindingContext = contexto;
        }

        private void listViewEjemplo1_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as HorarioModelo;
            Contexto.HorariosSelect = item;
            Navigation.PushModalAsync(new DetalleReserva { BindingContext = Contexto });
        }

        private void date_DateSelected(object sender, DateChangedEventArgs e)
        {
            Contexto.Fecha = date.Date.ToShortDateString();
            Contexto.FechaComando.Execute(false);
        }
    }
}

