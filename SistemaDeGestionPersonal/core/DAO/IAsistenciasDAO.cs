using SistemaDeGestionPersonal.core.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeGestionPersonal.core.DAO
{
    internal interface IAsistenciasDAO
    {
        int Insert(Asistencias asistencia);
        bool Update(Asistencias asistencia);
        bool Delete(int id);
        Asistencias GetById(int id);
        List<Asistencias> GetAll(string filtro = "");
    }
}
