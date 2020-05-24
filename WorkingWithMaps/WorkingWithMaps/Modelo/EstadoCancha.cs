using System;
using System.Collections.Generic;

namespace WSGOPLAY.Models
{
    public partial class EstadoCancha
    {
        //public EstadoCancha()
        //{
        //    Reserva = new HashSet<Reserva>();
        //}

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
