using Newtonsoft.Json;
using PropertyApp.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WorkingWithMaps.Modelo;
using WSGOPLAY.Models;

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

        public async Task<T> PostGuardarAsync<T>(T datos, string url)
        {
            var re = new Exitoso();
            var json = JsonConvert.SerializeObject(datos);
            var reserva = new ObservableCollection<T>() ;
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                var peti = await http.PostAsync(url, content);
                if (peti.IsSuccessStatusCode)
                {
                    var conte = await peti.Content.ReadAsStringAsync();
                    reserva.Add( JsonConvert.DeserializeObject<T>(conte));
                    re.Estado = true;
                }
                else
                {
                    re.Mensaje = peti.StatusCode.ToString();
                    re.Estado = false;
                }
            }
            catch (Exception ex)
            {
                re.Mensaje = ex.Message;
                re.Estado = false;

            }
            return reserva[0];
        }
        public async Task<Exitoso> PutActualizarAsync<T>(T datos, string url)
        {
            var re = new Exitoso();
            var json = JsonConvert.SerializeObject(datos);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                var peti = await http.PutAsync(url, content);
                if (peti.IsSuccessStatusCode)
                {
                    var conte = await peti.Content.ReadAsStringAsync();
                    re.Estado = true;
                }
                else
                {
                    re.Mensaje = peti.StatusCode.ToString();
                    re.Estado = false;
                }
            }
            catch (Exception ex)
            {
                re.Mensaje = ex.Message;
                re.Estado = false;

            }
            return re;
        }
        public async Task<Exitoso> DeleteAsync(string url)
        {
            var re = new Exitoso();
            try
            {
                var peti = await http.DeleteAsync(url);
                if (peti.IsSuccessStatusCode)
                {
                    var conte = await peti.Content.ReadAsStringAsync();
                    re.Estado = true;
                }
                else
                {
                    re.Mensaje = peti.StatusCode.ToString();
                    re.Estado = false;
                }
            }
            catch (Exception ex)
            {
                re.Mensaje = ex.Message;
                re.Estado = false;

            }
            return re;
        }
    }
}
