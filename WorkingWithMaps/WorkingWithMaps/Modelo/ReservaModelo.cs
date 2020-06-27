using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkingWithMaps.Modelo
{
   public class ReservaModelo: BaseViewModel
    {
        public int IdReserva { get; set; }
        public int Idhorario { get; set; }
        public string Fecha { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFinal { get; set; }
        public string Usuario { get; set; }
        public int? Idestado { get; set; }
        public string Reto { get; set; }
        public string Tel { get; set; }
        public string codigoVerificacion { get; set; }


        public string Reserva1 { get; set; }
    }
}
