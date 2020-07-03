using PropertyApp.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkingWithMaps.Modelo;
using WSGOPLAY.Models;

namespace WorkingWithMaps.Servicio
{
   public static class CambioModelo
    {
        public static ReservaModelo ReservaModelo(Reserva reserva)
        {
            var horario = new ReservaModelo
            {
                IdReserva = reserva.IdReserva,
                Idhorario = reserva.IdhorarioNavigation.Id,
                Fecha = reserva.Fecha,
                HoraInicio = reserva.HoraInicio,
                Usuario = reserva.Usuario,
                HoraFinal = reserva.HoraFinal,
                Idestado = reserva.Idestado,
                Reto = reserva.Reto,
                Tel = reserva.Usuario,
                Reserva1 = reserva.Reserva1
            };

            return horario;
        }

        public static HorarioModelo HorarioModelo(Horario datos)
        {
            var horario = new HorarioModelo
            {
                Id = datos.Id,
                Hora = datos.ProNombre,
                NombreCancha = datos.IdCanchaNavigation.PageTitle,
                Imagen = datos.IdCanchaNavigation.Avatar,
                Precio = datos.ProPrecio,
                IsBoton = false
            };

            return horario;
        }

    }
}
