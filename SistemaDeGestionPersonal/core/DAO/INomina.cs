using SistemaDeGestionPersonal.core.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeGestionPersonal.core.DAO
{
    internal interface INomina
    {
        List<Nomina> CalcularNominaMensual(DateTime mes);
    }
}
