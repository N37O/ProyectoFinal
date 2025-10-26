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
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                using (var cmd = new SqlCommand("DELETE FROM Cargo WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<Cargo> GetAll(string filtro = "")
        {
            var lista = new List<Cargo>();
            string sql = "SELECT id, nombre, nivel, salarioBase FROM Cargo";
            if (!string.IsNullOrEmpty(filtro))
                sql += " WHERE nombre LIKE @filtro";

            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    if (!string.IsNullOrEmpty(filtro))
                        cmd.Parameters.AddWithValue("@filtro", $"%{filtro}%");

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

        public Cargo GetById(int id)
        {
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string sql = "SELECT id, nombre, nivel, salarioBase FROM Cargo WHERE id = @id";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Cargo
                            {
                                Id = (int)reader["id"],
                                Nombre = reader["nombre"].ToString(),
                                Nivel = reader["nivel"].ToString(),
                                SalarioBase = (decimal)reader["salarioBase"]
                            };
                        }
                    }
                }
            }
            return null;
        }

        public int Insert(Cargo cargo)
        {
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string sql = "INSERT INTO Cargo (nombre, nivel, salarioBase) OUTPUT INSERTED.id VALUES (@nombre, @nivel, @salarioBase)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", cargo.Nombre);
                    cmd.Parameters.AddWithValue("@nivel", cargo.Nivel ?? "");
                    cmd.Parameters.AddWithValue("@salarioBase", cargo.SalarioBase);
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public bool Update(Cargo cargo)
        {
            using (var conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string sql = "UPDATE Cargo SET nombre = @nombre, nivel = @nivel, salarioBase = @salarioBase WHERE id = @id";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", cargo.Id);
                    cmd.Parameters.AddWithValue("@nombre", cargo.Nombre);
                    cmd.Parameters.AddWithValue("@nivel", cargo.Nivel ?? "");
                    cmd.Parameters.AddWithValue("@salarioBase", cargo.SalarioBase);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
