using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeGestionPersonal.core.Clases
{
    internal class Empleado
    {
        private int id;
        private string nombreCompleto;
        private string dui;
        private string telefono;
        private string estado;
        private int departamentoId;
        private int cargoId;
        private string nombreDepartamento;
        private string nombreCargo;



        public int Id { get => id; set => id = value; }
        public string NombreCompleto { get => nombreCompleto; set => nombreCompleto = value; }
        public string Dui { get => dui; set => dui = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Estado { get => estado; set => estado = value; }
        public int DepartamentoId { get => departamentoId; set => departamentoId = value; }
        public int CargoId { get => cargoId; set => cargoId = value; }
        public string NombreCargo { get => nombreCargo; set => nombreCargo = value; }
        public string NombreDepartamento { get => nombreDepartamento; set => nombreDepartamento = value; }
    }
}
