using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace negocio
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }


        // Conexión para la base de datos
        public AccesoDatos()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true");
            comando = new SqlCommand();
        }

        // Método para setear una consulta
        public void consulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }


        // Método para hacer la lectura a la base de datos
        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la ejecución de la consulta: " + ex.Message);
            }
        } 


        // Método para ejecutar acciones a la base de datos que no sean de lectura 
        public void ejecutarAccion() {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
        }


        // Método para setear @parámetros en la query
        public void setearParametro(string param, object obj)
        {
            comando.Parameters.AddWithValue(param, obj);
        }


        // Método para cerrar la conexión de la base de datos
        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }
    }
}
