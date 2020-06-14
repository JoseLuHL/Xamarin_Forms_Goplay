using Newtonsoft.Json;
using PropertyApp.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PropertyApp.Servicio
{
    public class GoPlayServicio
    {
        HttpClient http;
        public string Error { get; set; }
        public Exitoso Exitoso { get; set; }
        public GoPlayServicio()
        {
            if (http == null)
            {
                http = new HttpClient();
            }
        }
        public async Task<ObservableCollection<T>> GetDatosAsync<T>(string url)
        {
            var retornar = new ObservableCollection<T>();
            var conte = await http.GetAsync(url);
            try
            {
                if (conte.IsSuccessStatusCode)
                {
                    var resp = await conte.Content.ReadAsStringAsync();
                    retornar = JsonConvert.DeserializeObject<ObservableCollection<T>>(resp);
                }
                else
                    Error = conte.IsSuccessStatusCode.ToString();
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
            return retornar;
        }

        public async Task<T> Get<T>(string url)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }
        public async Task<T> GetDatoAsync<T>(string url)
        {
            var retornar = new ObservableCollection<T>();
            try
            {
                var conte = await http.GetAsync(url);
                if (conte.IsSuccessStatusCode)
                {
                    var resp = await conte.Content.ReadAsStringAsync();
                    var retornar2 = JsonConvert.DeserializeObject<T>(resp);
                    retornar.Add(retornar2);
                }
                else
                    Error = conte.IsSuccessStatusCode.ToString();
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
            return retornar[0];
        }

        public async Task<Exitoso> PostGuardarAsync<T>(T datos, string url)
        {
            var json = JsonConvert.SerializeObject(datos);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                var peti = await http.PostAsync(url, content);
                if (peti.IsSuccessStatusCode)
                {
                    var conte = await peti.Content.ReadAsStringAsync();
                    Exitoso = JsonConvert.DeserializeObject<Exitoso>(conte);
                }
                else
                {
                    Exitoso.Mensaje = peti.StatusCode.ToString();
                }
            }
            catch (Exception ex)
            {
                Exitoso.Mensaje = ex.Message;
            }
            return Exitoso;
        }
    }
}
