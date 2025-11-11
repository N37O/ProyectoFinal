using Microsoft.Data.SqlClient;
using SistemaDeGestionPersonal.core.Clases;
using SistemaDeGestionPersonal.core.Lip;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeGestionPersonal.core.DAO
{
    internal class CargoDAO : Cnn, ICargoDAO
    {
        private SqlConnection con = null;
        private SqlCommand command = null;

        // Elimina un registro de la tabla Cargo según su ID.
        // Retorna true si se eliminó exactamente un registro.
        public bool Delete(int id)
        {
            try
            {
                con = OpenDb();
                command = new SqlCommand("DELETE FROM Cargo WHERE id = @id", con);
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                return command.ExecuteNonQuery() == 1;
            }
            finally
            {
                command?.Dispose();
                CloseDb();
            }
        }

        // Obtiene todos los cargos, opcionalmente filtrando por nombre.
        public List<Cargo> GetAll(string filtro = "")
        {
            var lista = new List<Cargo>();
            SqlDataReader rd = null;

            try
            {
                con = OpenDb();
                string sql = @"
                    SELECT id, nombre, nivel, salarioBase 
                    FROM Cargo /** where **/
                    ORDER BY id;";

                if (!string.IsNullOrEmpty(filtro))
                    sql = sql.Replace("/** where **/", " WHERE nombre LIKE @f");
                else
                    sql = sql.Replace("/** where **/", string.Empty);

                command = new SqlCommand(sql, con);
                if (!string.IsNullOrEmpty(filtro))
                    command.Parameters.Add("@f", SqlDbType.NVarChar, 100).Value = $"%{filtro}%";

                rd = command.ExecuteReader();
                // Se mapean los resultados a objetos Cargo.

                while (rd.Read())
                {
                    lista.Add(Map(rd));
                }
            }
            finally
            {
                rd?.Close();
                command?.Dispose();
                CloseDb();
            }
            return lista;
        }

        // Convierte una fila del SqlDataReader en un objeto Cargo.
        private Cargo Map(SqlDataReader rd) =>  new Cargo
         {
            Id = rd.GetInt32(0),
            Nombre = rd.GetString(1),
            Nivel = rd.IsDBNull(2) ? null : rd.GetString(2),
            SalarioBase = rd.GetDecimal(3)
        };


        // Obtiene un cargo por su ID.
        // Retorna null si no se encuentra.
        public Cargo GetById(int id)
        {
            SqlDataReader rd = null;
            try
            {
                con = OpenDb();
                command = new SqlCommand("SELECT id, nombre, nivel, salarioBase FROM Cargo WHERE id = @id", con);
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                // Se usa CommandBehavior.SingleRow para optimizar la lectura de una sola fila.
                rd = command.ExecuteReader(CommandBehavior.SingleRow);
                if (!rd.Read())
                {
                    return null;

                }
                return Map(rd);
            }
            finally
            {
                rd?.Close();
                command?.Dispose();
                CloseDb();
            }
        }

        // Inserta un nuevo cargo en la base de datos y retorna el ID generado.
        public int Insert(Cargo cargo)
        {
            try
            {
                con = OpenDb();
                command = new SqlCommand(@"
                    INSERT INTO Cargo (nombre, nivel, salarioBase)
                    OUTPUT INSERTED.id
                    VALUES (@nombre, @nivel, @salarioBase);", con);

                command.Parameters.Add("@nombre", SqlDbType.NVarChar, 100).Value = cargo.Nombre;
                command.Parameters.Add("@nivel", SqlDbType.NVarChar, 50).Value = (object?)cargo.Nivel ?? DBNull.Value;
                command.Parameters.Add("@salarioBase", SqlDbType.Decimal).Value = cargo.SalarioBase;

                var result = command.ExecuteScalar();
                return Convert.ToInt32(result);
            }
            finally
            {
                command?.Dispose();
                CloseDb();
            }
        }

        // Actualiza los datos de un cargo existente en la base de datos
        public bool Update(Cargo cargo)
        {
            try
            {
                con = OpenDb();
                command = new SqlCommand(@"
                    UPDATE Cargo 
                    SET nombre = @nombre, nivel = @nivel, salarioBase = @salarioBase
                    WHERE id = @id;", con);

                command.Parameters.Add("@nombre", SqlDbType.NVarChar, 100).Value = cargo.Nombre;
                command.Parameters.Add("@nivel", SqlDbType.NVarChar, 50).Value = (object?)cargo.Nivel ?? DBNull.Value;
                command.Parameters.Add("@salarioBase", SqlDbType.Decimal).Value = cargo.SalarioBase;
                command.Parameters.Add("@id", SqlDbType.Int).Value = cargo.Id;

                return command.ExecuteNonQuery() == 1;
            }
            finally
            {
                command?.Dispose();
                CloseDb();
            }
        }
    }
    
}
