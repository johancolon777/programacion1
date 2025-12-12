using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CapaNegocio
    {
        // creamos nueva instancia
        private Procedimiento procedure = new Procedimiento();

        // CREAMOS OTRA TABLA 
        public DataTable mostrarPersonal()
        {
            DataTable table = new DataTable();
            table = procedure.Mostrar();
            return table;
        }
        // creamos los metodos 
        public void insertData(string Nombre, string Apellidos, string Cargo)
        {
            procedure.Insertar(Nombre, Apellidos, Cargo);
        }
        public void updateData(int Id, string Nombre, string Apellidos, string Cargo)
        {
            procedure.Update(Convert.ToInt32 (Id), Nombre, Apellidos, Cargo);
        }
        public void deleteData(int Id)
        {
            procedure.Delete(Convert.ToInt32 (Id));
        }

    }
}
