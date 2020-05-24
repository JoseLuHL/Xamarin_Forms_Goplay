using System;
using System.Collections.Generic;

namespace WSGOPLAY.Models
{
    public partial class Horario
    {
        public int Id { get; set; }
        public string ProNombre { get; set; }
        public string ProPrecio { get; set; }
        public int? IdCancha { get; set; }

        public virtual List<Sinreserva> Sinreserva { get; set; }
        public virtual WoPages IdCanchaNavigation { get; set; }
        public virtual List<Reserva> Reserva { get; set; }
    }
}
