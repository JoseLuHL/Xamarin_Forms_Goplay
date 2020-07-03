using Newtonsoft.Json;
using PropertyApp.Servicio;
using PropertyApp.url;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WorkingWithMaps.Modelo;

namespace WorkingWithMaps.Servicio
{
   public static class ReservasEpayCo
    {

        public static async Task<EpayCoModelo> EpaycoAsync(string referencia)
        {
            var urlapp = "https://secure.epayco.co/validation/v1/reference/" + referencia;
            var http = new HttpClient();
            var res = await http.GetAsync(urlapp);
            var response = await res.Content.ReadAsStringAsync();
            var  contenido = JsonConvert.DeserializeObject<EpayCoModelo>(response);
            return contenido;
        }

        public static async Task<string> CmabiarEstadoAsync(string referencia ,ReservaModelo Contexto)
        {
            //EpayCoModelo contenido = new EpayCoModelo();
            var contenido = await EpaycoAsync(referencia);
            var goplay = new GoPlayServicio();
            Contexto.Reto = referencia;
            string respuesta = "";

            if (contenido.data.x_response == "Aceptada")
            {
                //Acuatular el estado de la cancha
                //await DisplayAlert("", "Cancha reservada", "OK");
                Contexto.Idestado = 2;
                var ope = await goplay.PutActualizarAsync(Contexto, Url.urlReserva + "/" + Contexto.IdReserva);
                if (ope.Estado == false)
                {
                    Contexto.IsBusy = false;
                    //await DisplayAlert("", "Lo sentomos al parecer hay un poblema \n vuelva a intentarlo", "OK");
                }
            }

            else if (contenido.data.x_response == "Pendiente")
            {
                //Acuatular el estado de la cancha
                //await DisplayAlert("", "", "OK");
                Contexto.Idestado = 1;
                respuesta = "Si en 40 minutos no ha completado el pago \n su reserva será cancelada";
                var ope = await goplay.PutActualizarAsync(Contexto, Url.urlReserva + "/" + Contexto.IdReserva);
                if (ope.Estado == false)
                {
                    Contexto.IsBusy = false;
                    //await DisplayAlert("", "Lo sentomos al parecer hay un poblema \n vuelva a intentarlo", "OK");
                    respuesta = "Lo sentomos al parecer hay un poblema \n vuelva a intentarlo";
                }
            }

            else if (contenido.data.x_response == "Rechazada")
            {
                //Eliminar la reserva
                respuesta = "El pago ha sido rechachazado \n Vulava a intentarlo";
                //var ope = await goplay.DeleteAsync(Url.urlReserva + "/" + Contexto.IdReserva);
                var ope = await OperacionesCRUD.EliminarAsync(Url.urlReserva + "/" + Contexto.IdReserva);
                if (ope == false)
                {
                    Contexto.IsBusy = false;
                    respuesta = "Lo sentomos al parecer hay un poblema \n vuelva a intentarlo";
                }
            }

            else
            {
                //Eliminar la reserva
                respuesta = "El pago ha sido rechachazado \n Vulava a intentarlo";
                //var ope = await goplay.DeleteAsync(Url.urlReserva + "/" + Contexto.IdReserva);
                var ope = await OperacionesCRUD.EliminarAsync(Url.urlReserva + "/" + Contexto.IdReserva);
                if (ope == false)
                {
                    Contexto.IsBusy = false;
                    respuesta = "Lo sentomos al parecer hay un poblema \n vuelva a intentarlo";
                }
            }
            return respuesta;
        }

    }
}
