using PropertyApp.Servicio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkingWithMaps.Modelo;

namespace WorkingWithMaps.Servicio
{
    public static class OperacionesCRUD
    {
        public async static Task<T> GuardarAsync<T>(T modelo, string url)
        {
            GoPlayServicio goplay = new GoPlayServicio();
            await Task.Delay(500);
            var res = await goplay.PostGuardarAsync(modelo, url);
            return res;
        }
        public async static Task<Boolean> ActualizarAsync<T>(T modelo, string url)
        {
            GoPlayServicio goplay = new GoPlayServicio();
            await Task.Delay(500);
            var ope = await goplay.PutActualizarAsync(modelo, url);
            return ope.Estado;

        }
        public async static Task<Boolean> EliminarAsync(string url)
        {
            GoPlayServicio goplay = new GoPlayServicio();
            await Task.Delay(500);
            var ope = await goplay.DeleteAsync(url);
            return ope.Estado;

        }

    }
}
