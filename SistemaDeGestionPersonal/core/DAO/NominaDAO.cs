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
        /// Calcula la nómina mensual para todos los empleados activos en el mes especificado por la fecha proporcionada.
        public List<Nomina> CalcularNominaMensual(DateTime mes)
        {
            // Se obtiene el primer día del mes.

            var inicio = new DateTime(mes.Year, mes.Month, 1);

            // Se calcula el último día del mes sumando un mes y restando un día.

            var fin = inicio.AddMonths(1).AddDays(-1);

            int diasLaborables = 0;
            // Se recorre cada día del mes.
            for (DateTime d = inicio; d <= fin; d = d.AddDays(1))

                // Si el día no es sábado ni domingo, se considera laborable.
                if (d.DayOfWeek != DayOfWeek.Saturday && d.DayOfWeek != DayOfWeek.Sunday)
                    diasLaborables++;

            // Se crea una lista vacía para almacenar los resultados de la nómina.
            var lista = new List<Nomina>();
            SqlDataReader rd = null;
            SqlConnection con = null;
            SqlCommand cmd = null;
           
            // Se define la consulta SQL que obtiene datos de empleados activos y su asistencia mensual.
            try
            {
                con = OpenDb();
                string sql = @"
                    SELECT 
                        e.id, 
                        e.nombreCompleto, 
                        e.cargoId,
                        c.salarioBase,
                        COUNT(CASE WHEN a.estado = 'Presente' THEN 1 END) AS presente,
                        COUNT(CASE WHEN a.estado = 'Justificado' THEN 1 END) AS justificado,
                        COUNT(CASE WHEN a.estado = 'Tarde' THEN 1 END) AS tarde,
                        COUNT(CASE WHEN a.estado = 'Ausente' THEN 1 END) AS ausente
                    FROM Empleado e
                    INNER JOIN Cargo c ON e.cargoId = c.id
                    INNER JOIN Asistencia a ON e.id = a.empleadoId
                    WHERE e.Estado = 'Activo'
                      AND a.fecha BETWEEN @inicio AND @fin
                    GROUP BY e.id, e.nombreCompleto, e.cargoId, c.salarioBase";

                cmd = new SqlCommand(sql, con);
                
                // Se agregan los parámetros de fecha para el rango del mes.
                cmd.Parameters.Add("@inicio", SqlDbType.Date).Value = inicio;
                cmd.Parameters.Add("@fin", SqlDbType.Date).Value = fin;

                rd = cmd.ExecuteReader();


                // Se recorre cada fila del resultado.
                while (rd.Read())
                {
                    // Se crea un objeto Nomina con los datos del empleado y su asistencia.
                    var nom = new Nomina
                    {
                        EmpleadoId = rd.GetInt32("id"),
                        NombreCompleto = rd.GetString("nombreCompleto"),
                        CargoId = rd.GetInt32("cargoId"),
                        SalarioBase = rd.GetDecimal("salarioBase"),
                        DiasPresentes = rd.GetInt32("presente"),
                        DiasJustificados = rd.GetInt32("justificado"),
                        DiasTarde = rd.GetInt32("tarde"),
                        DiasAusentes = rd.GetInt32("ausente"),
                        DiasLaborables = diasLaborables
                    };

                    // Se calcula el salario diario suponiendo 30 días en el mes.
                    decimal salarioDiario = nom.SalarioBase / 30m;
                    nom.DescuentosAusente = Math.Round(nom.DiasAusentes * salarioDiario, 2);
                    nom.DescuentosTarde = Math.Round(nom.DiasTarde * (salarioDiario * 0.30m), 2);
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