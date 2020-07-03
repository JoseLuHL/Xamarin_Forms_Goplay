using Newtonsoft.Json;
using PropertyApp.Servicio;
using PropertyApp.url;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WorkingWithMaps.Modelo;
using WSGOPLAY.Models;
using Xamarin.Forms;

namespace WorkingWithMaps.Servicio
{
    public static class ReservaEstadoStatic
    {
        public static async Task<bool> Estado(int idHorario, string fecha, String hora)
        {
            var r = false;
            fecha = (fecha.Length > 10) ? fecha.Replace("/", "").Replace(".", "").Substring(0, 9).Trim() : fecha.Replace("/", "").Replace(".", "");
            //var servicio = new GoPlayServicio();
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(Url.urlReservaEstado + idHorario + "/" + fecha + "/" + hora);
            var json = await response.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<Reserva>(json);
            //var res = await servicio.GetDatoAsync<Reserva>(Url.urlReservaEstado + idHorario + "/" + fecha + "/" + hora);
            if (res != null)
                r = true;

            return r;
        }
        public static async Task<Reserva> EstadoDisponible(int idHorario, string fecha, String hora)
        {
            int r = 0;
            var est = false;
            var fecha2 = (fecha.Length > 10) ? fecha.Replace("/", "").Replace(".", "").Substring(0, 9).Trim() : fecha.Replace("/", "").Replace(".", "");
            var servicio = new GoPlayServicio();
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(Url.urlReservaEstado + idHorario + "/" + fecha2 + "/" + hora);
            var json = await response.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<Reserva>(json);
            //var res = await servicio.GetDatoAsync<Reserva>(Url.urlReservaEstado + idHorario + "/" + fecha + "/" + hora);
            if (res != null)
            {
                r = res.IdestadoNavigation.Id;

                if (r == 6 || r == 1)
                {
                    var horaReserva = Convert.ToDateTime(res.Fecha);
                    var minutos = DateTime.Now;
                    var dife = (minutos - horaReserva);

                    var op = dife.TotalMinutes;

                    if (op >= 15 && r == 6)
                    {
                        est = true;
                    }

                    if (op >= 40 && r == 1)
                    {
                        if (!string.IsNullOrEmpty(res.Reto))
                        {
                            var estado  = await ReservasEpayCo.CmabiarEstadoAsync(res.Reto, CambioModelo.ReservaModelo(res));

                        }
                        else
                            est = true;
                    }
                }
            }
            //r = true;
            if (!est)
            {
                res = null;
            }
            return res;
        }
    }
}
