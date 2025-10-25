using Microsoft.Data.SqlClient;
using SistemaDeGestionPersonal.core.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeGestionPersonal.core.DAO
{
    internal class CargoDAO : Cnn, ICargoDAO
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cargo> GetAll(string filtro = "")
        {
            throw new NotImplementedException();
        }

        public Cargo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Cargo cargo)
        {
            throw new NotImplementedException();
        }

        public bool Update(Cargo cargo)
        {
            throw new NotImplementedException();
        }
    }
}
