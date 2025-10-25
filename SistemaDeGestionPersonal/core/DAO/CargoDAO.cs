using Microsoft.Data.SqlClient;
using SistemaDeGestionPersonal.core.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeGestionPersonal.core.DAO
{
    internal class CargoDAO
    {
        public List<Cargo> ObtenerTodos()
        {
            var lista = new List<Cargo>();
            using (var conn = _Conexion.ObtenerConexion())
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT id, nombre, nivel, salarioBase FROM Cargo", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Cargo
                            {
                                Id = (int)reader["id"],
                                Nombre = reader["nombre"].ToString(),
                                Nivel = reader["nivel"].ToString(),
                                SalarioBase = (decimal)reader["salarioBase"]
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}
