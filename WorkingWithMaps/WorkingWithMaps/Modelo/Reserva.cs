using System;
using System.Collections.Generic;

namespace WSGOPLAY.Models
{
    public partial class Reserva
    {
        public int IdReserva { get; set; }
        public int Idhorario { get; set; }
        public string Fecha { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFinal { get; set; }
        public string Usuario { get; set; }
        public int? Idestado { get; set; }
        public string Reto { get; set; }
        public string Reserva1 { get; set; }

        public virtual EstadoCancha IdestadoNavigation { get; set; }
        public virtual Horario IdhorarioNavigation { get; set; }
    }
}
