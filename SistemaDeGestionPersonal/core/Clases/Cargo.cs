using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeGestionPersonal.core.Clases
{
    internal class Cargo
    {
        private int id;
        private string nombre;
        private string nivel;
        private decimal salarioBase;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Nivel { get => nivel; set => nivel = value; }
        public decimal SalarioBase { get => salarioBase; set => salarioBase = value; }
    }
}
