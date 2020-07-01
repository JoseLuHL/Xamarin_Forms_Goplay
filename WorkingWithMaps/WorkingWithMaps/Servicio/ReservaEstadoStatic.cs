using PropertyApp.Servicio;
using PropertyApp.url;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WSGOPLAY.Models;

namespace WorkingWithMaps.Servicio
{
    public static class ReservaEstadoStatic
    {
        public static async Task<bool> Estado(int idHorario, string fecha, String hora)
        {
            var r = false;
            fecha = (fecha.Length > 10) ? fecha.Replace("/", "").Replace(".", "").Substring(0, 9) : fecha.Replace("/", "").Replace(".", "");
            var servicio = new GoPlayServicio();
            var res = await servicio.GetDatoAsync<Reserva>(Url.urlReservaEstado + idHorario + "/" + fecha + "/" + hora);
            if (res != null)
                r = true;

            return r;
        }
        public static async Task<bool> Estado2(int idHorario, string fecha)
        {
            var r = false;
            fecha = fecha.Replace("/", "").Replace(".", "").Substring(0, 9);
            var servicio = new GoPlayServicio();
            var res = await servicio.GetDatoAsync<Reserva>(Url.urlReservaEstado + idHorario + "/" + fecha);
            if (res != null)
            {
                var hora = Convert.ToDateTime(res.Fecha).Minute;
                if (hora >= 15)
                {
                    r = true;
                }
            }
            return r;
        }
    }
}
