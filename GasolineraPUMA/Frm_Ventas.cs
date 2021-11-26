using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GasolineraPUMA
{
    public partial class Frm_Ventas : Form
    {
        private Clases.Ventas ventas;
        private Clases.TablaVentas tabla;
        private Conexion conexion;
        private int idFactura;
        private string nombreProducto;
        private int idProducto;
        private decimal precio;
        private string fila;
        public Frm_Ventas()
        {
            InitializeComponent();
            conexion = new Conexion();
            ventas = new Clases.Ventas();
            tabla = new Clases.TablaVentas();
            conexion.Establecerconexion();
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            decimal subtotal = Convert.ToInt32(txtCantidad.Text) * precio;
            dvgFactura.Rows.Add(idProducto, nombreProducto, txtCantidad.Text, precio, subtotal);

            txtCantidad.Text = "";
        }
        private void CargarDatosproductos()
        {
            string sql = "";

            sql = String.Format("SELECT idProducto , nombreProducto, precioProducto FROM producto ;");

            DataTable t2 = tabla.SQL(sql);
            dtgrProducto.DataSource = null;
            dtgrProducto.DataSource = t2;
            dtgrProducto.Refresh();


        }
        public void ajustarTamañoFactura()
        {
            this.dvgFactura.Columns[0].Visible = false;
            this.dvgFactura.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dvgFactura.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dvgFactura.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dvgFactura.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dvgFactura.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        public void ajustarTamañoProducto()
        {
            this.dtgrProducto.Columns[0].Visible = false;
            this.dtgrProducto.Columns[2].Visible = false;
            this.dtgrProducto.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dtgrProducto.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dtgrProducto.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void TraerId()
        {
                idFactura = Convert.ToInt32(conexion.consulta(string.Format("SELECT COUNT(idEncabezadoVenta) as numero FROM `encabezadoventa`;")).Rows[0][0].ToString());
                txtIdFactura.Text = Convert.ToString(idFactura + 1);
                txtIdFactura.Enabled = false;
        }

        private void Limpiar()
        {
            
            TraerId();
            CargarDatosproductos();
            ajustarTamañoProducto();
            ajustarTamañoFactura();
            dvgFactura.AllowUserToAddRows = false;
            dvgFactura.Rows.Clear();
            txtNombreCliente.Text = "";
            txtCantidad.Text = " ";
        }

        private void Frm_Ventas_Load(object sender, EventArgs e)
        {
            dvgFactura.Columns.Add("idProducto", "Id Producto");
            dvgFactura.Columns.Add("Nombre", "Nombre Producto");
            dvgFactura.Columns.Add("cantidad", "Cantidad");
            dvgFactura.Columns.Add("precio", "Precio");
            dvgFactura.Columns.Add("subtotal", "subTotal");
            ajustarTamañoFactura();
            Limpiar();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            if (txtNombreCliente.Text == string.Empty)
            {
                ventas.Nombre ="Sin Nombre";
            }
            else
            {
                ventas.Nombre = Convert.ToString(txtNombreCliente.Text);
            }
            ventas.IdFactura = Convert.ToInt32(txtIdFactura.Text);
            ventas.guardarventa();
            foreach (DataGridViewRow dgvRenglon in dvgFactura.Rows)
            {
                ventas.IdProducto =Convert.ToInt32(dgvRenglon.Cells[0].Value.ToString());
                ventas.Cantidades= Convert.ToInt32(dgvRenglon.Cells[2].Value.ToString());
                ventas.Precio =  Convert.ToDecimal(dgvRenglon.Cells[3].Value.ToString());
                ventas.Subtotal = Convert.ToDecimal(dgvRenglon.Cells[4].Value.ToString());

                ventas.guardarDetalleVenta();

            }

            MessageBox.Show("Factura Creada");
            Limpiar();
        }

        private void dtgrProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idProducto = Convert.ToInt32(dtgrProducto.CurrentRow.Cells[0].Value);
            nombreProducto = Convert.ToString(dtgrProducto.CurrentRow.Cells[1].Value);
            precio = Convert.ToDecimal(dtgrProducto.CurrentRow.Cells[2].Value);
        }

        private void dvgFactura_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             fila = " ";
             fila = dvgFactura.CurrentCell.RowIndex.ToString();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            dvgFactura.Rows.RemoveAt(Convert.ToInt32(fila));
        }

        private void btnSalida_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
