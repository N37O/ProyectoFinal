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
    internal class DepartamentoDAO : Cnn, IDepartamentoDAO
    {
        private SqlConnection con = null;
        private SqlCommand command = null;

        public bool Delete(int id)
        {
            try { con = OpenDb(); command = new SqlCommand("DELETE FROM Departamento WHERE id = @id", con); command.Parameters.Add("@id", SqlDbType.Int).Value = id; return command.ExecuteNonQuery() == 1; }
            finally { command?.Dispose(); CloseDb(); }
        }

        public List<Departamentos> GetAll(string filtro = "")
        {
            var List = new List<Departamentos>(); 
            SqlDataReader rd = null;
            try
            {
                con = OpenDb();
                string sql = "SELECT id, nombre FROM Departamento /** where **/ ORDER BY id";
                if (!string.IsNullOrEmpty(filtro)) sql = sql.Replace("/** where **/", " WHERE nombre LIKE @f");
                else sql = sql.Replace("/** where **/", "");
                command = new SqlCommand(sql, con);
                if (!string.IsNullOrEmpty(filtro)) command.Parameters.Add("@f", SqlDbType.NVarChar, 100).Value = $"%{filtro}%";
                rd = command.ExecuteReader();
                while (rd.Read()) List.Add(new Departamentos { Id = rd.GetInt32(0), Nombre = rd.GetString(1) });
            }
            finally { rd?.Close(); command?.Dispose(); CloseDb(); }
            return List;
        }

        public Departamentos GetById(int id)
        {
            SqlDataReader rd = null;
            try
            {
                con = OpenDb();
                command = new SqlCommand("SELECT id, nombre FROM Departamento WHERE id = @id", con);
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rd = command.ExecuteReader();
                return rd.Read() ? new Departamentos { Id = rd.GetInt32(0), Nombre = rd.GetString(1) } : null;
            }
            finally { rd?.Close(); command?.Dispose(); CloseDb(); }
        }


        public int Insert(Departamentos departamento)
        {
            try { con = OpenDb(); command = new SqlCommand("INSERT INTO Departamento (nombre) OUTPUT INSERTED.id VALUES (@nombre)", con); command.Parameters.Add("@nombre", SqlDbType.NVarChar, 100).Value = d.Nombre; return (int)command.ExecuteScalar(); }
            finally { command?.Dispose(); CloseDb(); }
        }
        public bool Update(Departamentos departamento)
        {
            try { con = OpenDb(); command = new SqlCommand("UPDATE Departamento SET nombre = @nombre WHERE id = @id", con); command.Parameters.Add("@nombre", SqlDbType.NVarChar, 100).Value = d.Nombre; command.Parameters.Add("@id", SqlDbType.Int).Value = d.Id; return command.ExecuteNonQuery() == 1; }
            finally { command?.Dispose(); CloseDb(); }
        }
    }
}