﻿using Microsoft.Data.SqlClient;
using SistemaDeGestionPersonal.core.Clases;
using SistemaDeGestionPersonal.core.Lip;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeGestionPersonal.core.DAO
{
    internal class AsistenciaDAO : Cnn, IAsistenciasDAO
    {
        private SqlConnection con = null;
        private SqlCommand command = null;
        public bool Delete(int id)
        {
            try { con = OpenDb(); command = new SqlCommand("DELETE FROM Asistencia WHERE id = @id", con); command.Parameters.Add("@id", SqlDbType.Int).Value = id; return command.ExecuteNonQuery() == 1; }
            finally { command?.Dispose(); CloseDb(); }
        }

        public List<Asistencias> GetAll(string filtro = "")
        {
            var lista = new List<Asistencias>(); SqlDataReader rd = null;
            try
            {
                con = OpenDb();
                string sql = "SELECT id, fecha, horaEntrada, horaSalida, estado, nota, empleadoId FROM Asistencia /** where **/ ORDER BY fecha DESC";
                if (!string.IsNullOrEmpty(filtro)) sql = sql.Replace("/** where **/", " WHERE CAST(fecha AS VARCHAR) LIKE @f OR estado LIKE @f");
                else sql = sql.Replace("/** where **/", "");
                command = new SqlCommand(sql, con);
                if (!string.IsNullOrEmpty(filtro)) command.Parameters.Add("@f", SqlDbType.NVarChar, 100).Value = $"%{filtro}%";
                rd = command.ExecuteReader();
                while (rd.Read()) lista.Add(new Asistencias
                {
                    Id = rd.GetInt32(0),
                    Fecha = rd.GetDateTime(1),
                    HoraEntrada = rd.GetTimeSpan(2),
                    HoraSalida = rd.GetTimeSpan(3),
                    Estado = rd.GetString(4),
                    Nota = rd.IsDBNull(5) ? null : rd.GetString(5),
                    EmpleadoId = rd.GetInt32(6)
                });
            }
            finally { rd?.Close(); command?.Dispose(); CloseDb(); }
            return lista;
        }

        public Asistencias GetById(int id)
        {
            SqlDataReader rd = null;
            try
            {
                con = OpenDb();
                command = new SqlCommand("SELECT id, fecha, horaEntrada, horaSalida, estado, nota, empleadoId FROM Asistencia WHERE id = @id", con);
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                rd = command.ExecuteReader();
                if (!rd.Read()) return null;
                return new Asistencias
                {
                    Id = rd.GetInt32(0),
                    Fecha = rd.GetDateTime(1),
                    HoraEntrada = rd.GetTimeSpan(2),
                    HoraSalida = rd.GetTimeSpan(3),
                    Estado = rd.GetString(4),
                    Nota = rd.IsDBNull(5) ? null : rd.GetString(5),
                    EmpleadoId = rd.GetInt32(6)
                };
            }
            finally { rd?.Close(); command?.Dispose(); CloseDb(); }
        }

        public int Insert(Asistencias asistencia)
        {
            try
            {
                con = OpenDb();
                command = new SqlCommand(@"
                    INSERT INTO Asistencia (fecha, horaEntrada, horaSalida, estado, nota, empleadoId)
                    OUTPUT INSERTED.id
                    VALUES (@fecha, @horaE, @horaS, @estado, @nota, @empId)", con);
                command.Parameters.Add("@fecha", SqlDbType.Date).Value = asistencia.Fecha;
                command.Parameters.Add("@horaE", SqlDbType.Time).Value = asistencia.HoraEntrada;
                command.Parameters.Add("@horaS", SqlDbType.Time).Value = asistencia.HoraSalida;
                command.Parameters.Add("@estado", SqlDbType.NVarChar, 20).Value = asistencia.Estado;
                command.Parameters.Add("@nota", SqlDbType.NVarChar, 500).Value = (object?)asistencia.Nota ?? DBNull.Value;
                command.Parameters.Add("@empId", SqlDbType.Int).Value = asistencia.EmpleadoId;
                return (int)command.ExecuteScalar();
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                throw new ApplicationException("Ya existe un registro de asistencia para este empleado en esta fecha.");
            }
            finally { command?.Dispose(); CloseDb(); }
        }



        public bool Update(Asistencias asistencia)
        {
            try
            {
                con = OpenDb();
                command = new SqlCommand(@"
                    UPDATE Asistencia 
                    SET fecha = @fecha, horaEntrada = @horaE, horaSalida = @horaS,
                        estado = @estado, nota = @nota, empleadoId = @empId
                    WHERE id = @id", con);
                command.Parameters.Add("@id", SqlDbType.Int).Value = asistencia.Id;
                command.Parameters.Add("@fecha", SqlDbType.Date).Value = asistencia.Fecha;
                command.Parameters.Add("@horaE", SqlDbType.Time).Value = asistencia.HoraEntrada;
                command.Parameters.Add("@horaS", SqlDbType.Time).Value = asistencia.HoraSalida;
                command.Parameters.Add("@estado", SqlDbType.NVarChar, 20).Value = asistencia.Estado;
                command.Parameters.Add("@nota", SqlDbType.NVarChar, 500).Value = (object?)asistencia.Nota ?? DBNull.Value;
                command.Parameters.Add("@empId", SqlDbType.Int).Value = asistencia.EmpleadoId;
                return command.ExecuteNonQuery() == 1;
            }
            finally { command?.Dispose(); CloseDb(); }
        }
    }
}

