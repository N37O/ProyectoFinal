using SistemaDeGestionPersonal.core.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeGestionPersonal.core.DAO
{
    internal interface IEmpleadoDAO
    {
        int Insert(Empleado empleado);
        bool Update(Empleado empleado);
        bool Delete(int id);
        Empleado GetById(int id);
        List<Empleado> GetAll(string filtro = "");
        List<Empleado> GetAllWithRelations(string filtro = "");

    }
}
