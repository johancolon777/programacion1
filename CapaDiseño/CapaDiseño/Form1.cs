using CapaDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDiseño
{
   
     
    public partial class Form1 : Form
    {
        //creamos nuestra nuestra instancia de nuestra clase procedimiento

       Procedimiento pr = new Procedimiento();
        private string id = null;
        private bool editar = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mostrarDatos();
        }
        //metodo para mostrar los datos en el datagridview
        private void mostrarDatos()
        {
            Procedimiento obj = new Procedimiento();
            dataGridView1.DataSource = obj.Mostrar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (editar == false)
            {
                try
                {
                    pr.Insertar(txtNombre.Text, txtApellido.Text, txtCargo.Text);
                    MessageBox.Show("Se han insertado los datos correctamente");
                    mostrarDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL ASIGNAR LOS DATOS"+ex);
                }
            }
            if (editar == true)
            {
                try
                {
                    pr.Update(Convert.ToInt32(id), txtNombre.Text, txtApellido.Text, txtCargo.Text);
                    MessageBox.Show("Se han modificado los datos correctamente");   
                    mostrarDatos();
                    editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR AL MODIFICAR LOS DATOS"+ex);
                }



            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                editar = true;
                id = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                txtApellido.Text = dataGridView1.CurrentRow.Cells["Apellidos"].Value.ToString();
                txtCargo.Text = dataGridView1.CurrentRow.Cells["Cargo"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione una fila para modificar");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                id = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                pr.Delete(Convert.ToInt32(id));
                MessageBox.Show("Se han eliminado los datos correctamente");
                mostrarDatos();
            }
            else
            {
                MessageBox.Show("ERROR AL ELIMINAR LOS DATOS !!!");
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtCargo.Clear();

        }
    }
  }
