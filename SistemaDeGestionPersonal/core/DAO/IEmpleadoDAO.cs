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
        int Insert(Cargo cargo);
        bool Update(Cargo cargo);
        bool Delete(int id);
        Cargo GetById(int id);
        List<Cargo> GetAll(string filtro = "");

    }
}
