using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeGestionPersonal.core.Clases
{
    internal class Asistencias
    {
        private int id;
        private DateTime fecha;
        private TimeSpan horaEntrada;
        private TimeSpan horaSalida;
        private string estado;
        private int empleadoId;
        private string nombreEmpleado;

        public int Id { get => id; set => id = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public TimeSpan HoraEntrada { get => horaEntrada; set => horaEntrada = value; }
        public TimeSpan HoraSalida { get => horaSalida; set => horaSalida = value; }
        public string Estado { get => estado; set => estado = value; }
        public int EmpleadoId { get => empleadoId; set => empleadoId = value; }
        public string NombreEmpleado { get => nombreEmpleado; set => nombreEmpleado = value; }
    }
}
