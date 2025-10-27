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
    internal class EmpleadoDAO : Cnn, IEmpleadoDAO
    {
        private SqlConnection con = null;
        private SqlCommand command = null;

        public bool Delete(int id)
        {
            if (TieneAsistencias(id))
            {
                try { con = OpenDb(); command = new SqlCommand("UPDATE Empleado SET Estado = 'Desactivo' WHERE id = @id", con); command.Parameters.Add("@id", SqlDbType.Int).Value = id; return command.ExecuteNonQuery() == 1; }
                finally { command?.Dispose(); CloseDb(); }
            }
            else
            {
                try { con = OpenDb(); command = new SqlCommand("DELETE FROM Empleado WHERE id = @id", con); command.Parameters.Add("@id", SqlDbType.Int).Value = id; return command.ExecuteNonQuery() == 1; }
                finally { command?.Dispose(); CloseDb(); }
            }
        }
        private bool TieneAsistencias(int id)
        {
            using (var c = OpenDb())
            {
                var cmd = new SqlCommand("SELECT COUNT(1) FROM Asistencia WHERE empleadoId = @id", c);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        public List<Empleado> GetAll(string filtro = "")
        {
            var lista = new List<Empleado>(); SqlDataReader rd = null;
            try
            {
                con = OpenDb();
                string sql = "SELECT id, nombreCompleto, DUI, Telefono, Estado, departamentoId, cargoId FROM Empleado /** where **/ ORDER BY id";
                if (!string.IsNullOrEmpty(filtro)) sql = sql.Replace("/** where **/", " WHERE nombreCompleto LIKE @f OR DUI LIKE @f");
                else sql = sql.Replace("/** where **/", "");
                command = new SqlCommand(sql, con);
                if (!string.IsNullOrEmpty(filtro)) command.Parameters.Add("@f", SqlDbType.NVarChar, 200).Value = $"%{filtro}%";
                rd = command.ExecuteReader();
                while (rd.Read()) lista.Add(Map(rd));
            }
            finally { rd?.Close(); command?.Dispose(); CloseDb(); }
            return lista;
        }

        private Empleado Map(SqlDataReader rd) => new Empleado
        {
            Id = rd.GetInt32(0),
            NombreCompleto = rd.GetString(1),
            Dui = rd.GetString(2),
            Telefono = rd.IsDBNull(3) ? null : rd.GetString(3),
            Estado = rd.GetString(4),
            DepartamentoId = rd.GetInt32(5),
            CargoId = rd.GetInt32(6)
        };

        public Empleado GetById(int id)
        {
            SqlDataReader rd = null;
            try
            {
                con = OpenDb();
                command = new SqlCommand("SELECT id, nombreCompleto, DUI, Telefono, Estado, departamentoId, cargoId FROM Empleado WHERE id = @id", con);
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rd = command.ExecuteReader();
                return rd.Read() ? Map(rd) : null;
            }
            finally { rd?.Close(); command?.Dispose(); CloseDb(); }
        }

        public int Insert(Empleado empleado)
        {
            if (empleado.Estado == "Activo" && (empleado.CargoId <= 0 || empleado.DepartamentoId <= 0))
                throw new ApplicationException("Un empleado activo debe tener cargo y departamento asignados.");

            try
            {
                con = OpenDb();
                command = new SqlCommand(@"
                    INSERT INTO Empleado (nombreCompleto, DUI, Telefono, Estado, departamentoId, cargoId)
                    OUTPUT INSERTED.id
                    VALUES (@nombre, @dui, @telefono, @estado, @deptoId, @cargoId)", con);
                command.Parameters.Add("@nombre", SqlDbType.NVarChar, 200).Value = empleado.NombreCompleto;
                command.Parameters.Add("@dui", SqlDbType.VarChar, 10).Value = empleado.Dui;
                command.Parameters.Add("@telefono", SqlDbType.VarChar, 10).Value = (object?)empleado.Telefono ?? DBNull.Value;
                command.Parameters.Add("@estado", SqlDbType.NVarChar, 20).Value = empleado.Estado;
                command.Parameters.Add("@deptoId", SqlDbType.Int).Value = empleado.DepartamentoId;
                command.Parameters.Add("@cargoId", SqlDbType.Int).Value = empleado.CargoId;
                return (int)command.ExecuteScalar();
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                throw new ApplicationException("El DUI ya está registrado.", ex);
            }
            finally { command?.Dispose(); CloseDb(); }
        }

        public bool Update(Empleado empleado)
        {
            if (empleado.Estado == "Activo" && (empleado.CargoId <= 0 || empleado.DepartamentoId <= 0))
                throw new ApplicationException("Un empleado activo debe tener cargo y departamento asignados.");

            try
            {
                con = OpenDb();
                command = new SqlCommand(@"
                    UPDATE Empleado 
                    SET nombreCompleto = @nombre, DUI = @dui, Telefono = @telefono,
                        Estado = @estado, departamentoId = @deptoId, cargoId = @cargoId
                    WHERE id = @id", con);
                command.Parameters.Add("@id", SqlDbType.Int).Value = empleado.Id;
                command.Parameters.Add("@nombre", SqlDbType.NVarChar, 200).Value = empleado.NombreCompleto;
                command.Parameters.Add("@dui", SqlDbType.VarChar, 10).Value = empleado.Dui;
                command.Parameters.Add("@telefono", SqlDbType.VarChar, 10).Value = (object?)empleado.Telefono ?? DBNull.Value;
                command.Parameters.Add("@estado", SqlDbType.NVarChar, 20).Value = empleado.Estado;
                command.Parameters.Add("@deptoId", SqlDbType.Int).Value = empleado.DepartamentoId;
                command.Parameters.Add("@cargoId", SqlDbType.Int).Value = empleado.CargoId;
                return command.ExecuteNonQuery() == 1;
            }
            finally { command?.Dispose(); CloseDb(); }
        }
        


        public List<Empleado> GetAllWithRelations(string filtro = "")
        {
            var lista = new List<Empleado>(); SqlDataReader rd = null;
            try
            {
                con = OpenDb();
                string sql = @"
                    SELECT e.id, e.nombreCompleto, e.DUI, e.Telefono, e.Estado,
                           e.departamentoId, e.cargoId, d.nombre, c.nombre
                    FROM Empleado e
                    INNER JOIN Departamento d ON e.departamentoId = d.id
                    INNER JOIN Cargo c ON e.cargoId = c.id /** where **/
                    ORDER BY e.id";
                if (!string.IsNullOrEmpty(filtro)) sql = sql.Replace("/** where **/", " WHERE e.nombreCompleto LIKE @f OR e.DUI LIKE @f");
                else sql = sql.Replace("/** where **/", "");
                command = new SqlCommand(sql, con);
                if (!string.IsNullOrEmpty(filtro)) command.Parameters.Add("@f", SqlDbType.NVarChar, 200).Value = $"%{filtro}%";
                rd = command.ExecuteReader();
                while (rd.Read()) lista.Add(new Empleado
                {
                    Id = rd.GetInt32(0),
                    NombreCompleto = rd.GetString(1),
                    Dui = rd.GetString(2),
                    Telefono = rd.IsDBNull(3) ? null : rd.GetString(3),
                    Estado = rd.GetString(4),
                    DepartamentoId = rd.GetInt32(5),
                    CargoId = rd.GetInt32(6),
                    NombreDepartamento = rd.GetString(7),
                    NombreCargo = rd.GetString(8)
                });
            }
            finally { rd?.Close(); command?.Dispose(); CloseDb(); }
            return lista;
        }
    }
}




