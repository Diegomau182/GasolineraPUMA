using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Configuration;



namespace GasolineraPUMA
{
    public partial class Categoria : Form
    {
        Conexion c;
        private Clases.ClaCategoria categoria;
        private Clases.ClaListaCategorias categorias;


        public Categoria()
        {
            InitializeComponent();
            c = new Conexion();
            categoria = new Clases.ClaCategoria();
            categorias = new Clases.ClaListaCategorias();
            txtIdCategoria.Enabled = false;


        }


        private void Categoria_Load_1(object sender, EventArgs e)
        {
            DataTable t1 = categorias.SQL(String.Format("SELECT idCategoria, nombreCategoria, descripcionCategoria FROM dbPuma.categoria"));
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = t1;
            dataGridView2.Refresh();
            Cargar_Datos();
            DataGridLectura();
            ajustarTamañodetalle();


        }

        public void DataGridLectura()
        {
            dataGridView2.Columns["idCategoria"].ReadOnly = true;
            dataGridView2.Columns["nombreCategoria"].ReadOnly = true;
            dataGridView2.Columns["descripcionCategoria"].ReadOnly = true;
        }
        private void Cargar_Datos()
        {
            txtIdCategoria.Text = categoria.IdCategoria.ToString();
            txtNombreCategoria.Text = categoria.Nombre;
            txtDescripcion.Text = categoria.Descripcion;
            txtNombreCategoria.Focus();
            txtIdCategoria.Enabled = false;
            ajustarTamañodetalle();

        }

 


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {
           
        }


        private void limpiar()
        {
            txtIdCategoria.Text = "";
            txtNombreCategoria.Text = "";
            txtDescripcion.Text = "";
            txtIdCategoria.Enabled = false;
            txtNombreCategoria.Focus();
        }
    

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

      

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }


        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

     
        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

       

       

        private void button3_Click(object sender, EventArgs e) { }

        private void button2_Click(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e) { }

       

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdCategoria.Enabled = false;
            txtIdCategoria.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            txtNombreCategoria.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            txtDescripcion.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                categoria.IdCategoria = Convert.ToInt32(txtIdCategoria.Text);
                if (categoria.Eliminar())
                {
                    MessageBox.Show("Registro eliminado correctamente", "Categoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataTable t1 = categorias.SQL(String.Format("SELECT idCategoria, nombreCategoria, descripcionCategoria FROM dbPuma.categoria"));
                    dataGridView2.DataSource = null;
                    dataGridView2.DataSource = t1;
                    dataGridView2.Refresh();
                    Cargar_Datos();
                }
                else
                {
                    MessageBox.Show("Error al momento de eliminar la categoria", "Categoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                limpiar();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                txtIdCategoria.Enabled = false;
                categoria.Nombre = txtNombreCategoria.Text;
                categoria.Descripcion = txtDescripcion.Text;
                if (categoria.Guardar())
                {
                    MessageBox.Show("Registro guardado correctamente", "Categoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataTable t1 = categorias.SQL(String.Format("SELECT idCategoria, nombreCategoria, descripcionCategoria FROM dbPuma.categoria"));
                    dataGridView2.DataSource = null;
                    dataGridView2.DataSource = t1;
                    dataGridView2.Refresh();
                    Cargar_Datos();

                }
                else
                {
                    MessageBox.Show("Errores al insertar la nueva categoria", "Categoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
            limpiar();

        }

        private void pictureBox7_Click_1(object sender, EventArgs e)
        {
            limpiar();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }


        private Boolean validarCampos()
        {
            ajustarTamañodetalle();
            Boolean r = true;
            if (txtIdCategoria.Text == "" || txtNombreCategoria.Text == "")
            {
                MessageBox.Show("No se permiten campos vacios", "Categoria", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIdCategoria.Focus();
                r = false;
            }
            else
                r = true;
            return r;

            
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            if(validarCampos())
            {
                categoria.IdCategoria = Convert.ToInt32(txtIdCategoria.Text.ToString());
                categoria.Nombre = txtNombreCategoria.Text;
                categoria.Descripcion = txtDescripcion.Text;
                if (categoria.ModificarCategoria())
                {
                    MessageBox.Show("Registro actulizado correctamente", "Categoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataTable t1 = categorias.SQL(String.Format("SELECT idCategoria, nombreCategoria, descripcionCategoria FROM dbPuma.categoria"));
                    dataGridView2.DataSource = null;
                    dataGridView2.DataSource = t1;
                    dataGridView2.Refresh();
                    Cargar_Datos();
                }
                else
                {
                    MessageBox.Show("Errores al modificar la nueva categoria", "Categoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                limpiar();
            }
            else
            {

            }
           
            
        }


        public void ajustarTamañodetalle()
        {
            this.dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

    }

}
