using PlacesApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSGOPLAY.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlacesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MisReservas : ContentPage
    {
        //PlacesPageViewModel Page => ((PlacesPageViewModel)BindingContext);
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
            if (string.IsNullOrEmpty(searchBar.Text))
            {
                //Page.Reservas = null;
            }
        }

        private async void vistaReservas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var item = e.CurrentSelection as Reserva;
            ////await DisplayAlert("", item.Cancha.Nombre, "OK");
            //if (item == null)
            //    return;
            //await DisplayAlert("", item.Cancha.Nombre, "OK");
        }
    }
}