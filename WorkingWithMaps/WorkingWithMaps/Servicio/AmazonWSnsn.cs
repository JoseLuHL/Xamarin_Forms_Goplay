using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
namespace WorkingWithMaps.Servicio
{
   public class AmazonWSnsn
    {
        public async Task<string> VerificarTel(string cel)
        {
            //var Key = "AKIAJB3CSNSAALHFF63Q";
            //var secre = "78OXUIflntsXwVtkWGwTxlL0FMxZlDiyuitA3d3M";
            //AmazonSimpleNotificationServiceClient snsClient = new AmazonSimpleNotificationServiceClient(Key, secre, Amazon.RegionEndpoint.USWest2);
            //PublishRequest pubRequest = new PublishRequest();
            //pubRequest.Message = $"GOPLAY: {GenerarCodigoVerificacion()} es tu codigo";
            //pubRequest.PhoneNumber = "+573105483152";
            //PublishResponse pubResponse = await snsClient.PublishAsync(pubRequest);
            return GenerarCodigoVerificacion();
        }

        private string GenerarCodigoVerificacion()
        {
            List<long> numeros10Digitos = new List<long>();
            long numeroAleatorio = 0;
            do
            {
                numeroAleatorio = Convert.ToInt64(
                    $"{new Random().Next(10, 49)}{new Random().Next(50, 99)}");
            } while (numeros10Digitos.Contains(numeroAleatorio));
            numeros10Digitos.Add(numeroAleatorio);
            return numeroAleatorio.ToString();
        }

    }
}
