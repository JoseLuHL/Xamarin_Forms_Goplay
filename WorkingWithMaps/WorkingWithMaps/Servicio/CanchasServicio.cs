using PropertyApp.Modelo;
using PropertyApp.url;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WSGOPLAY.Models;
using Xamarin.Forms;

namespace PropertyApp.Servicio
{
    public class CanchasServicio
    {
        GoPlayServicio GoPlayServicio;

        //public ObservableCollection<CanchasModel> Canchas => CanchasModels();
        public ObservableCollection<WoPages> Canchas { get; set; }
        string error;
        public CanchasServicio()
        {
            Canchas =  new ObservableCollection<WoPages>();
            GoPlayServicio = new GoPlayServicio();
            CanchasModels();            
        }
       public async void CanchasModels()
        {
            Canchas = await GoPlayServicio.GetDatosAsync<WoPages>(Url.urlPages);
            error = GoPlayServicio.Error;
            //Application.Current.MainPage.DisplayAlert("CAnSER", Canchas.Count.ToString(), "OK");
        }

    }
}
