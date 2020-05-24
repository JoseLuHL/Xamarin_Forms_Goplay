using System;
using System.Collections.Generic;

namespace WSGOPLAY.Models
{
    public partial class Sinreserva
    {
        public int Idsin { get; set; }
        public string Sinfecha { get; set; }
        public string Sinhora { get; set; }
        public int? Sinidhorario { get; set; }

        public virtual Horario SinidhorarioNavigation { get; set; }
    }
}
