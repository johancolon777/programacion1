using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class Procedimiento
    {
        //Creamos una instancia privada de la clase CapaDatos
        private CapaDatos Conexion = new CapaDatos();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        //Crear una tabla de datos para mostrar los datos
        public DataTable Mostrar()
        {
            comando.Connection = Conexion.abrir();
            comando.CommandText = "sp_MostratDatos";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            leer.Close();
            Conexion.cerrar();                   //ojo aca
            return tabla;
        }

        public void Insertar(string Nombre, string Apellidos, string Cargo)
        {
            comando.Connection = Conexion.abrir();
            comando.CommandText = "sp_Agregar";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", Nombre);
            comando.Parameters.AddWithValue("@Apellidos", Apellidos);
            comando.Parameters.AddWithValue("@Cargo", Cargo);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            Conexion.cerrar();
        }
        public void Update(int Id, string Nombre, string Apellidos, string Cargo)
        {
            comando.Connection = Conexion.abrir();
            comando.CommandText = "sp_Modificar";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id", Id);
            comando.Parameters.AddWithValue("@Nombre", Nombre);
            comando.Parameters.AddWithValue("@Apellidos", Apellidos);
            comando.Parameters.AddWithValue("@Cargo", Cargo);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            Conexion.cerrar();
        }
        public void Delete(int Id)
        {
            comando.Connection = Conexion.abrir();
            comando.CommandText = "sp_Eliminar";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id", Id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            Conexion.cerrar();
        }
    }
}
