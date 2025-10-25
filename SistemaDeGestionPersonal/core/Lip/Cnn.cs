using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SistemaDeGestionPersonal.core.Lip
{
    internal class Cnn
    {
        private readonly SqlConnection _conexion;

        public Cnn()
        {
            string cadena = ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString;
            _conexion = new SqlConnection(cadena);
            ;
        }
        public SqlConnection OpenDb()
        {
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                {
                    _conexion.Open();

                }
                return _conexion;

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al abrir la conexion a la DB: " + ex.Message, "Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public void CloseDb()
        {
            try
            {
                if (_conexion.State == ConnectionState.Open)
                {
                    _conexion.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al cerrar la conexion: " + ex.Message, "Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
}
