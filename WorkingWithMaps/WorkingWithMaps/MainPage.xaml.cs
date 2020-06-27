using PlacesApp.ViewModels.Equipo;
using PropertyApp.Modelo;
using PropertyApp.Servicio;
using PropertyApp.url;
using PropertyApp.VistaModelo;
using PropertyApp.Vistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WorkingWithMaps;
using Xamarin.Forms;

namespace PropertyApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        //MainPageVistaModel MainPageVistaModel;
        MainPageVistaModel contexto => ((MainPageVistaModel)BindingContext);

        public MainPage()
        {
            InitializeComponent();
            buscarCancha.TextChanged += BuscarCancha_TextChanged;
        }

        protected override async void OnAppearing()
        {
            if (contexto.IsBusy)
            {
                contexto.IsOcupado = true;
                await Task.Delay(2000);
                contexto.IsOcupado = false;
            }
            contexto.IsBusy = false;
        }

        private void BuscarCancha_TextChanged(object sender, TextChangedEventArgs e)
        {
            contexto.BuscarCanchaCommando.Execute(buscarCancha.Text);
        }

        private void SelectType(object sender, EventArgs e)
        {
            var view = sender as View;
            var parent = view.Parent as StackLayout;

            foreach (var child in parent.Children)
            {
                VisualStateManager.GoToState(child, "Normal");
                ChangeTextColor(child, "#707070");
            }

            VisualStateManager.GoToState(view, "Selected");
            ChangeTextColor(view, "#FFFFFF");

            var bindi32 = view.BindingContext as WorkingWithMaps.Modelo.PropertyType;

            if (bindi32.Name=="todas")
            {
                contexto.TodasCanchasComando.Execute(false);
            }

            if (bindi32.Name == "miequipo")
            {
                contexto.MiEquipoComando.Execute(false);
            }

            if (bindi32.Name == "mapa")
            {
                contexto.MapaComando.Execute(false);
            }
            if (bindi32.Name == "todasReservas")
            {
                contexto.misReservas.Execute(false);
            }
        }

        private void ChangeTextColor(View child, string hexColor)
        {
            var txtCtrl = child.FindByName<Label>("PropertyTypeName");

            if (txtCtrl != null)
                txtCtrl.TextColor = Color.FromHex(hexColor);
        }

        private async void PropertySelected(object sender, EventArgs e)
        {
            var property = (sender as View).BindingContext as WorkingWithMaps.Modelo.Property;
            await Navigation.PushAsync(new DetailsPage(property));
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Contenido.BindingContext = contexto.PropertyList;
            await DisplayAlert("", contexto.PropertyList.Count.ToString(), "OK");
        }

        private async void CerrarSesion_Clicked(object sender, EventArgs e)
        {
            contexto.IsLogueadoNO = false;
            await App.SQLiteDb.DeleteItemAsync();
            contexto.IsLogueado = true;
        }

        private async void BtnConfiguracion_Tapped_1(object sender, EventArgs e)
        {
            await DisplayAlert("", "Imagen", "OK");
        }
    }
}
