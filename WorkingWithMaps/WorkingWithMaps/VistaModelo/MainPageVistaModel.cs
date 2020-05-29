using MvvmHelpers;
using PlacesApp.Views.Equipo;
using PropertyApp.Servicio;
using PropertyApp.url;
using PropertyApp.Vistas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using WorkingWithMaps;
using WorkingWithMaps.Modelo;
using WSGOPLAY.Models;
using WSGOPLAY.Models.red;
using Xamarin.Forms;

namespace PropertyApp.VistaModelo
{
    public class MainPageVistaModel : BaseViewModel
    {
        public string mensajeLogueo => "Lo sentimos, para acceder a esta opción debe iniciar sesión";
        //Servicio de canchas
        CanchasServicio CanchasServicio;

        GoPlayServicio GoPlayServicio;

        private Boolean isOcupado = true;

        public Boolean IsOcupado
        {
            get => isOcupado;
            set => SetProperty(ref isOcupado, value);
        }

        private string resultadoBusqueda;

        public string ResultadoBusqueda
        {
            get => resultadoBusqueda;
            set => SetProperty(ref resultadoBusqueda, value);
        }

        private bool isLogueado;

        public bool IsLogueado
        {
            get => isLogueado;
            set => SetProperty(ref isLogueado, value);
        }

        private bool isLogueadoNo;

        public bool IsLogueadoNO
        {
            get => isLogueadoNo;
            set => SetProperty(ref isLogueadoNo, value);
        }

        private ObservableCollection<WoPages> canchas;
        public ObservableCollection<WoPages> Canchas
        {
            get => canchas;
            set => SetProperty(ref canchas, value);
        }

        public string Name { get; set; }
        public List<PropertyType> PropertyTypeList => GetPropertyTypes();

        private ObservableCollection<Property> propertyList;

        public ObservableCollection<Property> PropertyList
        {
            get => propertyList;
            set => SetProperty(ref propertyList, value);
        }

        public ICommand MiEquipoComando => new Command(async () =>
         {
             await Application.Current.MainPage.Navigation.PushAsync(new MiequipoVista());
         });

        public ICommand ReservaComando => new Command(async () =>
        {

        });

        public ICommand PartidoComando => new Command(async () =>
        {

        });

        public ICommand BuscarCanchaCommando => new Command<string>(async (string buscar) =>
       {
           //if (IsLogueado == true)
           //{
           //    await Application.Current.MainPage.DisplayAlert("...", mensajeLogueo, "OK");
           //    return;
           //}

           if (string.IsNullOrEmpty(buscar))
           {
               Canchas = await GoPlayServicio.GetDatosAsync<WoPages>(Url.urlPages);
               PropertyList = CargarCanchas(Canchas);
               return;
           }

           IsOcupado = true;
           Canchas = new ObservableCollection<WoPages>();
           Canchas = await GoPlayServicio.GetDatosAsync<WoPages>(Url.urlPagesBuscar + buscar);
           PropertyList = null;
           if (canchas.Count > 0)
           {
               ResultadoBusqueda = string.Empty;
               PropertyList = CargarCanchas(Canchas);
           }
           else
               ResultadoBusqueda = "No se han encontrado resultados";
           IsOcupado = false;

       });

        public ICommand MapaComando => new Command(
            async () =>
            {
                await Application.Current.MainPage.Navigation.PushModalAsync(new PinPage { BindingContext = this });
            });

        public ICommand IniciarCommand => new Command(async () =>
           {
               await Application.Current.MainPage.Navigation.PushModalAsync(new LoginView { BindingContext = this });
           });

        public ICommand TodasCanchasComando => new Command(async () =>
        {
            //if (IsLogueado == true)
            //{
            //    await Application.Current.MainPage.DisplayAlert("...", mensajeLogueo, "OK");
            //    return;
            //}
            IsOcupado = true;
            Canchas = await GoPlayServicio.GetDatosAsync<WoPages>(Url.urlPagesTodas);
            PropertyList = CargarCanchas(Canchas);
            IsOcupado = false;
        });
        public int pag { get; set; } = 1;
        public ICommand RefrescarComando => new Command(async () =>
       {
           //if (IsLogueado == true)
           //{
           //    await Application.Current.MainPage.DisplayAlert("...", mensajeLogueo, "OK");
           //    return;
           //}
           pag++;
           IsRefresh = true;
           Canchas = await GoPlayServicio.GetDatosAsync<WoPages>(Url.urlPages + pag);
           if (Canchas.Count <= 0)
           {
               IsRefresh = false;
               pag--;
               var retornar = await Application.Current.MainPage.DisplayAlert("", "No hay mas canchas \n ¿Desea volver al inicio?", "SI", "NO");
               if (retornar)
               {
                   pag = 1;
                   Canchas = await GoPlayServicio.GetDatosAsync<WoPages>(Url.urlPages + pag);
               }
               else
                   return;
           }

           IsRefresh = false;
           PropertyList = CargarCanchas(Canchas);

       });

        private Boolean isRefresh;

        public Boolean IsRefresh
        {
            get => isRefresh;
            set => SetProperty(ref isRefresh, value);
        }


        public MainPageVistaModel()
        {
            IsBusy = true;
            IsRefresh = false;
            pag = 1;
            IsOcupado = true;
            GoPlayServicio = new GoPlayServicio();
            PropertyList = new ObservableCollection<Property>();
            Load();
            IsOcupado = false;
        }
        private List<PropertyType> GetPropertyTypes()
        {
            return new List<PropertyType>
            {
                new PropertyType { TypeName = "Todas", Name="todas" },
                new PropertyType { TypeName = "Mapa", Name="mapa" },
                new PropertyType { TypeName = "Favorita", Name="favorita" },
                new PropertyType { TypeName = "Recomendada" , Name="recomendada"},
                new PropertyType { TypeName = "Mi equipo", Name="miequipo" },
                new PropertyType { TypeName = "Reservas", Name="todasReservas" },
                new PropertyType { TypeName = "Partidos", Name="partidos" }
            };
        }

        private async Task Load()
        {
            try
            {
                IsOcupado = true;
                var personList = await App.SQLiteDb.GetItemsAsync();
                if (personList.Count > 0)
                {
                    IsLogueado = false;
                    IsLogueadoNO = true;
                    foreach (var item in personList)
                    {
                        var usuario = new ObservableCollection<WoUsers>();
                        usuario.Add(new WoUsers { Username = item.Name });
                        VistaModelo.LoginViewModel.Usuarios = usuario.First();
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("...", "Para mejorar la experiencia en GoPlay debe iniciar sesión", "OK");
                    IsLogueado = true;
                    IsLogueadoNO = false;
                }

                Canchas = await GoPlayServicio.GetDatosAsync<WoPages>(Url.urlPages + pag);
                PropertyList = CargarCanchas(Canchas);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Main", ex.Message, "OK");
            }

        }

        private ObservableCollection<Property> CargarCanchas(ObservableCollection<WoPages> canchas)
        {
            var y = new ObservableCollection<Property>();
            if (canchas.Count > 0)
            {
                foreach (var item in canchas)
                {
                    y.Add(
                        new Property
                        {
                            Id = item.PageId.ToString(),
                            Image = item.Avatar,
                            Address = item.Address,
                            Location = item.Registered,
                            Price = item.PageTitle,
                            Bed = item.Phone,
                            Bath = "",
                            Space = item.Address,
                            Lat = item.Lat,
                            Lng = item.Lng,
                            Details = item.PageDescription
                        });
                }
            }
            return y;
        }

    }
}
