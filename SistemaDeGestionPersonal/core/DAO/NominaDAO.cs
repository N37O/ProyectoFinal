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
    internal class NominaDAO : Cnn, INomina
    {
        public List<Nomina> CalcularNominaMensual(DateTime mes)
        {
            var inicio = new DateTime(mes.Year, mes.Month, 1);
            var fin = inicio.AddMonths(1).AddDays(-1);

            int diasLaborables = 0;
            for (DateTime d = inicio; d <= fin; d = d.AddDays(1))
                if (d.DayOfWeek != DayOfWeek.Saturday && d.DayOfWeek != DayOfWeek.Sunday)
                    diasLaborables++;

            var lista = new List<Nomina>();
            SqlDataReader rd = null;
            SqlConnection con = null;
            SqlCommand cmd = null;

            try
            {
                con = OpenDb();
                string sql = @"
                    SELECT 
                        e.id, e.nombreCompleto, c.salarioBase,
                        COUNT(CASE WHEN a.estado = 'Presente' THEN 1 END) AS presente,
                        COUNT(CASE WHEN a.estado = 'Justificado' THEN 1 END) AS justificado,
                        COUNT(CASE WHEN a.estado = 'Tarde' THEN 1 END) AS tarde,
                        COUNT(CASE WHEN a.estado = 'Ausente' THEN 1 END) AS ausente
                    FROM Empleado e
                    INNER JOIN Cargo c ON e.cargoId = c.id
                    INNER JOIN Asistencia a ON e.id = a.empleadoId
                    WHERE e.Estado = 'Activo'
                      AND a.fecha BETWEEN @inicio AND @fin
                    GROUP BY e.id, e.nombreCompleto, c.salarioBase";

                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@inicio", SqlDbType.Date).Value = inicio;
                cmd.Parameters.Add("@fin", SqlDbType.Date).Value = fin;

                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    var nom = new Nomina
                    {
                        EmpleadoId = rd.GetInt32(0),
                        NombreCompleto = rd.GetString(1),
                        SalarioBase = rd.GetDecimal(2),
                        DiasPresentes = rd.GetInt32(3),
                        DiasJustificados = rd.GetInt32(4),
                        DiasTarde = rd.GetInt32(5),
                        DiasAusentes = rd.GetInt32(6),
                        DiasLaborables = diasLaborables
                    };

                    decimal salarioDiario = nom.SalarioBase / 30;
                    nom.DescuentosAusente = nom.DiasAusentes * salarioDiario;
                    nom.DescuentosTarde = nom.DiasTarde * (salarioDiario * 0.30m);
                    nom.PagoNeto = Math.Max(0, nom.SalarioBase - nom.DescuentosAusente - nom.DescuentosTarde);

                    lista.Add(nom);
                }
            }
            finally
            {
                rd?.Close();
                cmd?.Dispose();
                CloseDb();
            }
            return lista;
        }
    }
 }

