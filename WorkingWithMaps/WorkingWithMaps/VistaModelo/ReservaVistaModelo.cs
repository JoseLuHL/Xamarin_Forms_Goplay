using MvvmHelpers;
using PlacesApp.Views;
using Prism.Commands;
using PropertyApp.Modelo;
using PropertyApp.Servicio;
using PropertyApp.url;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using WorkingWithMaps;
using WorkingWithMaps.Modelo;
using WorkingWithMaps.Servicio;
using WorkingWithMaps.Vistas.Reservas;
using WSGOPLAY.Models;
using Xamarin.Forms;

namespace PropertyApp.VistaModelo
{
    public class ReservaVistaModelo : BaseViewModel
    {
        GoPlayServicio goplayServicio;
        private string nombre;
        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                SetProperty(ref nombre, value);
                SetProperty(ref concepto, value);
            }
        }

        private string hora;
        public string Hora
        {
            get { return hora; }
            set
            {
                SetProperty(ref hora, value);
                SetProperty(ref concepto, value);
            }
        }
        private string precio;
        public string Precio
        {
            get { return Convert.ToInt32(precio).ToString("#,##0"); }
            set
            {
                SetProperty(ref precio, value);
                SetProperty(ref concepto, value);
            }
        }

        private string fecha = DateTime.Now.Date.ToShortDateString();
        public string Fecha
        {
            get => fecha;
            set
            {
                SetProperty(ref fecha, value);
                SetProperty(ref concepto, value);
            }
        }

        public DateTime FechaMin
        {
            get => DateTime.Now.Date;
        }

        public ICommand FechaComando => new Command(async () =>
        {
            //await Application.Current.MainPage.DisplayAlert("", Fecha, "OK");
            IsBusy = true;
            Load();
            IsBusy = false;
        });

        public DelegateCommand ResumenComando
        {
            get
            {
                return new DelegateCommand(() =>
                {

                    Application.Current.MainPage.Navigation.PushAsync(new PgReserva()
                    {
                        BindingContext = this
                    }
                   );
                });
            }
        }

        public string codigoVerificacion { get; set; }

        public DelegateCommand ContinuarComando
        {
            get
            {

                return new DelegateCommand(async () =>
                {

                if (string.IsNullOrEmpty(hora))
                {
                    await Application.Current.MainPage.DisplayAlert("", "Por favor seleccione una hora", "OK");
                    return;
                }

                if (string.IsNullOrEmpty(fecha))
                {
                    await Application.Current.MainPage.DisplayAlert("", "Por favor seleccione una fecha", "OK");
                    return;
                }

                // VERIFICACION DEL NUMERO DE TELEFONO:::
                //if (string.IsNullOrEmpty(codigoVerificacion))
                //{

                var tel = await Application.Current.MainPage.DisplayPromptAsync("GOPLAY:", "Numero de telefono", "OK", "Cancel", null, 10, keyboard: Keyboard.Numeric, "");
                if (tel.Length == 10)
                {
                    var reserva = new ReservaModelo();
                    AmazonWSnsn amazonW = new AmazonWSnsn();
                    var codigo = await amazonW.VerificarTel(tel);
                    IsBusy = true;
                    Concepto = $"Reserva de cancha {nombre} para la fecha {fecha} hora {hora} por el valor de {precio}";
                    reserva.Idhorario = horariosSelect.Id;
                    reserva.Idestado = 1;
                    reserva.Fecha = horariosSelect.Fecha + " " + DateTime.Now.Date.ToShortTimeString();
                    reserva.HoraInicio = horariosSelect.Hora;
                    reserva.HoraFinal = horariosSelect.Precio.ToString();
                    reserva.Idhorario = horariosSelect.Id;
                    reserva.Reto = "NA";
                    reserva.Tel = tel;
                    reserva.codigoVerificacion = codigo;
                    reserva.Usuario = tel;
                    reserva.Reserva1 = concepto;
                    codigoVerificacion = codigo;
                    IsBusy = false;
                    await Application.Current.MainPage.Navigation.PushModalAsync(
                    new ConfirmarTelVista { BindingContext = reserva });

                //    await Application.Current.MainPage.Navigation.PushModalAsync(
                //new PagosVista { BindingContext = reserva });
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Numero de no valido", "OK");
                        return;
                    }
                    //}
                    //else
                    //{
                    //    await Application.Current.MainPage.Navigation.PushModalAsync(
                    //           new ConfirmarTelVista { BindingContext = reserva });
                    //}

                });
            }
        }
        public string Id { get; set; }
        public string Image { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string Foto { get; set; }
        public string Estado { get; set; }

        private string celular;
        public string Celular
        {
            get => $"{"Celular: "} {celular}";
            set => SetProperty(ref celular, value);
        }
        public string User { get; set; }
        public string Creada { get; set; }
        //public string Direccion { get; set; }
        private string direccion;
        public string Direccion
        {
            get => $"{"Dirección:"} {direccion}";
            set => SetProperty(ref direccion, value);
        }
        public List<string> Images { get; set; }

        private string concepto = $"{"Reserva de cancha"}  {"para la fecha "}";
        public string Concepto
        {
            get { return $"Reserva de cancha {nombre} para la fecha {fecha} hora {hora} por el valor de {precio}"; }
            set { SetProperty(ref concepto, value); }
        }
        private ObservableCollection<Horario> horario;
        public ObservableCollection<Horario> Horario
        {
            get => horario;
            set => SetProperty(ref horario, value);
        }

        private string idCancha;

        public string IdCancha
        {
            get => idCancha;
            set
            {
                SetProperty(ref idCancha, value);

            }
        }

        //public string idCancha { get; set; }

        private WoPages paginaHorario;

        public WoPages PaginaHorario
        {
            get => paginaHorario;
            set => SetProperty(ref paginaHorario, value);
        }

        private ObservableCollection<HorarioModelo> horarios;

        public ObservableCollection<HorarioModelo> Horarios
        {
            get => horarios;
            set => SetProperty(ref horarios, value);
        }

        private HorarioModelo horariosSelect;

        public HorarioModelo HorariosSelect
        {
            get => horariosSelect;
            set
            {
                SetProperty(ref horariosSelect, value);
                SetProperty(ref nombre, HorariosSelect.NombreCancha);
                SetProperty(ref hora, HorariosSelect.Hora);
                SetProperty(ref precio, HorariosSelect.Precio.ToString("#,##0"));

            }
        }

        public ReservaVistaModelo(string id)
        {

            goplayServicio = new GoPlayServicio();
            IdCancha = id;
            Load();
            //Task.Run( async () => await Load()) ;
        }

        private async void Load()
        {
            IsBusy = true;
            var PaginaHorario = await goplayServicio.Get<WoPages>(Url.urlPagesid + idCancha);
            var horario = new ObservableCollection<HorarioModelo>();
            var fe = Convert.ToDateTime(this.fecha).ToString().Substring(0, 10).Trim();

            foreach (var item in PaginaHorario.Horario)
            {
                var variables = new HorarioModelo();
                variables.Id = item.Id;
                variables.NombreCancha = PaginaHorario.PageTitle;
                variables.Imagen = PaginaHorario.Avatar;
                variables.Hora = item.ProNombre;
                if (string.IsNullOrEmpty(item.ProPrecio))
                    variables.Precio = Convert.ToDecimal(0);
                else
                    variables.Precio = Convert.ToDecimal(item.ProPrecio);

                if (item.Reserva.Count > 0)
                {
                    foreach (var res in item.Reserva)
                    {
                        if (res.Fecha == fe && item.ProNombre == res.HoraInicio)
                        {
                            if (res.IdestadoNavigation.Descripcion == "Ocupada")
                            {
                                variables.Estado = res.IdestadoNavigation.Descripcion;
                                variables.Color = "Red";
                                variables.idEstado = res.IdestadoNavigation.Id;

                            }
                            if (res.IdestadoNavigation.Descripcion == "Pendiente")
                            {
                                variables.Estado = res.IdestadoNavigation.Descripcion;
                                variables.Color = "Orange";
                                variables.idEstado = res.IdestadoNavigation.Id;
                            }

                        }
                        else
                        {
                            variables.Estado = "Disponible";
                            variables.idEstado = 3;
                            variables.Color = "Green";
                        }
                    }
                }
                else
                {
                    variables.Estado = "Disponible";
                    variables.idEstado = 3;
                    variables.Color = "Green";
                }


                if (item.Sinreserva.Count > 0)
                {
                    foreach (var sinreserva in item.Sinreserva)
                    {
                        if (sinreserva.Sinidhorario == item.Id && fe == sinreserva.Sinfecha)
                        {
                            variables.Estado = "Cerrado";
                            variables.Color = "Red";
                            variables.idEstado = 4;

                        }
                    }
                }

                variables.Fecha = this.Fecha;

                horario.Add(variables);
            }
            Horarios = horario;
            IsBusy = false;
            //await Application.Current.MainPage.DisplayAlert("", Horarios.Count.ToString(), "OK");
        }

    }
}
