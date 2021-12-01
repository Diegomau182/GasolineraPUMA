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
        /// <summary>
        ///  Funcion para que le DatagridView no sea editable.
        /// </summary>
        public void DataGridLectura()
        {
            dataGridView2.Columns["idCategoria"].ReadOnly = true;
            dataGridView2.Columns["nombreCategoria"].ReadOnly = true;
            dataGridView2.Columns["descripcionCategoria"].ReadOnly = true;
        }

        /// <summary>
        ///  Carga la informacion de la categoria de la base da datos, cuando existe una nueva
        /// </summary>
        private void Cargar_Datos()
        {
            txtIdCategoria.Text = categoria.IdCategoria.ToString();
            txtNombreCategoria.Text = categoria.Nombre;
            txtDescripcion.Text = categoria.Descripcion;
            txtNombreCategoria.Focus();
            txtIdCategoria.Enabled = false;
            ajustarTamañodetalle();

        }
        /// <summary>
        ///  Funcion para Limpiar la informacion de las cajas de texto
        /// </summary>
        private void limpiar()
        {
            txtIdCategoria.Text = "";
            txtNombreCategoria.Text = "";
            txtDescripcion.Text = "";
            txtIdCategoria.Enabled = false;
            txtNombreCategoria.Focus();
        }

        /// <summary>
        ///  Carga la informacion del registro seleccionado en el datagridView en los campos 
        ///  de texto correspondientes.
        /// </summary>

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdCategoria.Enabled = false;
            txtIdCategoria.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            txtNombreCategoria.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            txtDescripcion.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
        }

        /// <summary>
        ///  Validaciones para poder insertar una nueva categoria 
        /// </summary>
        private Boolean validarCamposInsertar()
        {
            ajustarTamañodetalle();
            Boolean r = true;
            if (categoria.BuscarCategoria(txtNombreCategoria.Text))
            {
                MessageBox.Show(string.Format("Ya existe el nombre de la categoria \n{0}\t{1}", categoria.IdCategoria, categoria.Nombre));

                r = false;
            }
            else
                r = true;
            return r;

        }


        /// <summary>
        ///  Validaciones para poder modificar una categoria existente
        /// </summary>
        private Boolean ValidarModificar()
        {
            Boolean r = true;

            if (txtNombreCategoria.Text == "")
            {
                MessageBox.Show("Escriba el nombre de la categoria", "Categoria", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreCategoria.Focus();
                r = false;
            }
            else if (!categoria.BuscarIdCategoria(txtIdCategoria.Text))
            {
                MessageBox.Show(string.Format("No existe el codigo de la categoria\n{0}\t{1}", categoria.IdCategoria, categoria.Nombre));
                r = false;
            }

            else if (categoria.Nombre == txtNombreCategoria.Text)
            {
                MessageBox.Show(string.Format("Modificaste la categoria \n{0}\t{1}", categoria.IdCategoria, categoria.Nombre));
            }

            else if (categoria.BuscarCategoria(txtNombreCategoria.Text))
            {
                MessageBox.Show(string.Format("Ya existe el nombre de la categoria \n{0}\t{1}", categoria.IdCategoria, categoria.Nombre));

                r = false;
            }
            else
                r = true;
            return r;
        }


        /// <summary>
        ///  Codigo para insertar una nueva categoria
        /// </summary>

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (validarCamposInsertar())
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
            else
            {
                MessageBox.Show("Se cancelo la insercion");

            }

            limpiar();

        }
        /// <summary>
        ///  Codigo para Modificar una categoria
        /// </summary>
        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            if (ValidarModificar())
            {
                categoria.IdCategoria = Convert.ToInt32(txtIdCategoria.Text.ToString());
                categoria.Nombre = txtNombreCategoria.Text;
                categoria.Descripcion = txtDescripcion.Text;
                if (categoria.ModificarCategoria())
                {
                    MessageBox.Show("Registro actualizado correctamente", "Categoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            }
            else
            {
                MessageBox.Show("Se cancelo la edicion");

            }
            limpiar();


        }

        /// <summary>
        ///  Codigo para Eliminar una categoria
        /// </summary>

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            if (txtIdCategoria.Text != "")
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

            }
            else
            {
                MessageBox.Show("Debe seleccionar la categoria que sea eliminar");

            }
            limpiar();

        }

        /// <summary>
        ///  Codigo para limpiar las textbox
        /// </summary>
        private void pictureBox7_Click_1(object sender, EventArgs e)
        {
            limpiar();
        }
        /// <summary>
        ///  Codigo para cerrar el formulario
        /// </summary>
        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Metodo para validad que la categoria ingresada existe
        /// </summary>
        private Boolean Validar()
        {
            Boolean r = true;
            if (categoria.BuscarCategoria(txtNombreCategoria.Text))
            {
                MessageBox.Show(string.Format("Ya existe el nombre de la categoria \n{0}\t{1}", categoria.IdCategoria, categoria.Nombre));

                r = false;
            }
            else
                r = true;
            return r;

        }

        /// <summary>
        /// Metodo para ajustar el datagridview2 al largo de su espacio correspondiente
        /// </summary>
        public void ajustarTamañodetalle()
        {
            this.dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridLectura();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
