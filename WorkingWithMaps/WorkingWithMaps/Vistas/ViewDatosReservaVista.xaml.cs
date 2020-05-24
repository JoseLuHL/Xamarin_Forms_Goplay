using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlacesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewDatosReserva : ContentPage
    {
        public ViewDatosReserva()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            //detailContainer.FadeTo(1, 200, Easing.CubicInOut);
            //detailContainer.TranslateTo(0, 0, 200, Easing.CubicInOut);

            descriptionContainer1.FadeTo(1, 350, Easing.CubicInOut);
            descriptionContainer1.TranslateTo(0, 0, 350, Easing.CubicInOut);
            descriptionContainer2.FadeTo(1, 350, Easing.CubicInOut);
            descriptionContainer2.TranslateTo(0, 0, 350, Easing.CubicInOut);
            descriptionContainer3.FadeTo(1, 350, Easing.CubicInOut);
            descriptionContainer3.TranslateTo(0, 0, 350, Easing.CubicInOut);
            //ViewModelsReservas view = new ViewModelsReservas();
            //BindingContext = view;
        }
    }
}