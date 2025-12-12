using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CapaDatos
    {    // Cadena de conexión a la base de datos
        private SqlConnection conexion = new SqlConnection("Data Source=ATF_LAPTOP;Initial Catalog=DB_EmpresaXYZ;Integrated Security=true");

        // Método para abrir la conexión
        public SqlConnection abrir ()
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }
            return conexion;
        }
        // Método para cerrar la conexión
        public void cerrar()
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
        }
    }
}
