using PropertyApp.VistaModelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using WorkingWithMaps;
using WSGOPLAY.Models.red;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PropertyApp.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            //var personList = await App.SQLiteDb.GetItemsAsync();
            //if (personList != null)
            //{
            //    foreach (var item in personList)
            //    {
            //        var usuario = new ObservableCollection<WoUsers>();
            //        usuario.Add (new WoUsers { Username = item.Name });
            //        //VistaModelo.LoginViewModel.Usuarios.Add(new WSGOPLAY.Models.red.WoUsers { Username = item.Name });  
            //        VistaModelo.LoginViewModel.Usuarios = usuario;
            //    }
            //    //contexto.IsLogueado = false;
            //    await Application.Current.MainPage.DisplayAlert("count", personList.Count.ToString(), "OK");
            //    //lstPersons.ItemsSource = personList;
            //}
        }
        MainPageVistaModel contexto => ((MainPageVistaModel)BindingContext);
        private async void BtnContinuar_Clicked(object sender, EventArgs e)
        {
            bool cerrar = false;
            try
            {

                var usuario = new Usuario();
                if (string.IsNullOrEmpty(Password.Text))
                {
                    await DisplayAlert("", "Ingresar usuario", "OK");
                    return;
                }

                if (string.IsNullOrEmpty(Password.Text))
                {
                    await DisplayAlert("", "Ingresar contraseña", "OK");
                    return;
                }
                ocupado.IsRunning = true;
                usuario.Name = Email.Text.Trim();
                usuario.Contraseña = Password.Text.Trim();

                var login = await LoginViewModel.CargarUsuarioAsync(usuario);
                if (login != null)
                {
                    await App.SQLiteDb.SaveItemAsync(usuario);
                    Email.Text = string.Empty;
                    Password.Text = string.Empty;
                    contexto.IsLogueado = false;
                    contexto.IsLogueadoNO = true;
                    cerrar = true;
                }
                else
                    await DisplayAlert("", "Usuario o contraseña incorrecto", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Required", ex.ToString(), "OK");
            }
            ocupado.IsRunning = false;

            if (cerrar == true)
            {
                await Navigation.PopModalAsync();
            }
        }
    }
}