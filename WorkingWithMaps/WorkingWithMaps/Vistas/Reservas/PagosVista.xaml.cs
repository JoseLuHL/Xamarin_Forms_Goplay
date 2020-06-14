using PropertyApp.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkingWithMaps.Vistas.Reservas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagosVista : ContentPage
    {
        //ReservaVistaModelo Contexto => ((ReservaVistaModelo)BindingContext);
        public string precio { get; set; }
        public string description { get; set; }
        public PagosVista()
        {
            InitializeComponent();
            _ = TasAsync();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await progress.ProgressTo(0.9, 900, Easing.SpringIn);
        }

        protected void OnNavigating(object sender, WebNavigatingEventArgs e)
        {
            progress.IsVisible = true;
        }

        protected void OnNavigated(object sender, WebNavigatedEventArgs e)
        {
            progress.IsVisible = false;
        }

        async Task TasAsync()
        {
            Webview.IsVisible = false;
            await Task.Delay(2000);
            //progress.IsVisible = false;
            Webview.IsVisible = true;
            Webview.Source = $"http://192.168.1.10:8080/prueba/prueba.php?precio={precio}&descripcion={description.Replace(" ", "%20")}";
        }
    }
}