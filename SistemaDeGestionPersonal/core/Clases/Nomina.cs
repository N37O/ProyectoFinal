using SistemaDeGestionPersonal.core.Lip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeGestionPersonal.core.Clases
{
    internal class Nomina
    {
        private int empleadoId;
        private string nombreCompleto;
        private decimal salarioBase;
        private int diasLaborables;
        private int diasPresentes;
        private int diasJustificados;
        private int diasTarde;
        private int diasAsuente;
        private decimal descuentosTarde;
        private decimal descuentosAsuente;
        private decimal pagoNeto;

        public int EmpleadoId { get => empleadoId; set => empleadoId = value; }
        public string NombreCompleto { get => nombreCompleto; set => nombreCompleto = value; }
        public decimal SalarioBase { get => salarioBase; set => salarioBase = value; }
        public int DiasLaborables { get => diasLaborables; set => diasLaborables = value; }
        public int DiasPresentes { get => diasPresentes; set => diasPresentes = value; }
        public int DiasJustificados { get => diasJustificados; set => diasJustificados = value; }
        public int DiasTarde { get => diasTarde; set => diasTarde = value; }
        public int DiasAsuente { get => diasAsuente; set => diasAsuente = value; }
        public decimal DescuentosTarde { get => descuentosTarde; set => descuentosTarde = value; }
        public decimal DescuentosAsuente { get => descuentosAsuente; set => descuentosAsuente = value; }
        public decimal PagoNeto { get => pagoNeto; set => pagoNeto = value; }

    }
}
