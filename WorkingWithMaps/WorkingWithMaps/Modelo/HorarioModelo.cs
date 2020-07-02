using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyApp.Modelo
{
   public class HorarioModelo
    {
        public int Id { get; set; }
        public string NombreCancha { get; set; }
        public string Imagen { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Estado { get; set; }
        public string Color { get; set; }
        public bool IsBoton { get; set; } = true;
        public decimal Precio { get; set; }
        public int? idEstado { get; set; }
        public string Usuario { get; set; }
    }
}
