using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyApp.url
{
   public static class Url
    {
        //http://192.168.1.10/WSGOPLAY/api/
        private const  string urlBase = "http://192.168.1.10/WSGOPLAY/api/";
        public static string urlReserva  => $"{urlBase}Reservas";
        public static string urlCanchas => $"{urlBase}Canchas";
        public static string urlHorario => $"{urlBase}Horarios";
        public static string urlPages => $"{urlBase}WoPages/";
        public static string urlPagesBuscar => $"{urlBase}WoPages/Buscar/";
        public static string urlGroup => $"{urlBase}WoGroupMembers";
        public static string urlUsuario => $"{urlBase}WoUsers/buscar/";
        public static string urlPagesTodas => $"{urlBase}WoPages/todos";
        public static string urlPagesid => $"{urlBase}WoPages/pagina/horario/";
    }
}
