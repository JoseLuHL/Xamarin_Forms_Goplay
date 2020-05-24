using PlacesApp.Views;
using PropertyApp.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkingWithMaps.Modelo;
using Xamarin.Forms;
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
            this.Navigation.PopAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            DetailsView.TranslationY = 600;
            DetailsView.TranslateTo(0, 0, 500, Easing.SinInOut);
        }

        private async void BtnReservar_Clicked(object sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new PgReserva (cont.Id));
        }
    }
}