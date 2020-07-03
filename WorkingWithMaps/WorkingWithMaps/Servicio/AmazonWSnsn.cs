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
            //var Key = "AKIAJ5GD4RUHUY5LKBZA";
            //var secre = "mOUhq4qGt1AKhI18o0uFKlvJ/dEz8WNVu6Kbr7GV";
            //AmazonSimpleNotificationServiceClient snsClient = new AmazonSimpleNotificationServiceClient(Key, secre, Amazon.RegionEndpoint.USWest2);
            //PublishRequest pubRequest = new PublishRequest();
            var codigo = GenerarCodigoVerificacion();
            //pubRequest.Message = $"GOPLAY: {codigo} es tu codigo";
            //pubRequest.PhoneNumber = $"+57{cel}";
            //PublishResponse pubResponse = await snsClient.PublishAsync(pubRequest);
            return codigo;
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
