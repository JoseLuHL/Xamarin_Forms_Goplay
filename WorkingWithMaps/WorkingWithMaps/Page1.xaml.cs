using PlacesApp.ViewModels.Equipo;
using PropertyApp.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PropertyApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        //MainPageVistaModel MainPageVistaModel;
        //MiEquipoViewModel MiEquipoView;
        public Page1()
        {
            InitializeComponent();
            //MiEquipoView = new MiEquipoViewModel();
            //this.BindingContext = MiEquipoView;
            //MainPageVistaModel = new MainPageVistaModel();
            //this.BindingContext = MainPageVistaModel;
        }
    }
}