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
    public partial class FmCompras : Form
    {

        Conexion c;
        private Clases.ClaListaCompra compras;
        private Clases.ClaCompra Compra;
        private int idFactura;
        private string fila;
        private double precio;
        private double subtotal;
        private double suma;
        public FmCompras()
        {
            InitializeComponent();

            c = new Conexion();

            compras = new Clases.ClaListaCompra();
            Compra = new Clases.ClaCompra();

            TraerId();
            Datos_Categoria();
            Datos_Proveedor();
            Bloqueartxt();
            Limpiar();
        }


        private void Bloqueartxt()
        {
            txtNFactura.Enabled = false;
            txtSubtotal.Enabled = false;
            txtIVA.Enabled = false;
            txtTotal.Enabled = false;
        }

        private void Limpiar()
        {
            txtfecha.Value = DateTime.Today;
            txtNFactura.Focus();
            txtProveedor.Text = string.Empty;
            txtproducto.Text = string.Empty;
            txtCategoria.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtSubtotal.Text = string.Empty;
            txtIVA.Text = string.Empty;
            txtTotal.Text = string.Empty;
        }

        private void LimpiarAlgunosCampos()
        {
            txtfecha.Value = DateTime.Today;
            txtproducto.Text = string.Empty;
            txtCategoria.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            txtCantidad.Text = string.Empty;
        }


        public void Datos_Categoria()
        {

            DataTable t1 = compras.SQL(String.Format("SELECT idCategoria, nombreCategoria FROM  dbpuma.categoria"));
            txtCategoria.DataSource = null;
            txtCategoria.DataSource = t1;
            txtCategoria.DisplayMember = "nombreCategoria";
            txtCategoria.ValueMember = "idCategoria";

        }

        public void Datos_Proveedor()
        {

            DataTable t2 = compras.SQL(String.Format("SELECT RTNProveedor, empresaProveedor FROM  dbpuma.proveedor"));
            txtProveedor.DataSource = null;
            txtProveedor.DataSource = t2;
            txtProveedor.DisplayMember = "empresaProveedor";
            txtProveedor.ValueMember = "RTNProveedor";

        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            LimpiarAlgunosCampos();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FmCompra frm = new FmCompra();
            frm.Show();
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void ajustarTamañoFactura()
        {
            this.txtcompra.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.txtcompra.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.txtcompra.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.txtcompra.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.txtcompra.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void FmCompras_Load(object sender, EventArgs e)
        {
                txtcompra.Columns.Add("nombreProducto", "Nombre Producto");
                txtcompra.Columns.Add("idCategoria", "Categoria");
                txtcompra.Columns.Add("cantidadProducto", "Cantidad");
                txtcompra.Columns.Add("precioProducto", "Precio");
                txtcompra.Columns.Add("subtotal", "Subtotal");
                //txtcompra.Columns.Add("subtotal", "subTotal");
                ajustarTamañoFactura();
                Limpiar();
        }

        private void TraerId()
        {
            idFactura = Convert.ToInt32(c.consulta(string.Format("SELECT COUNT(idEncabezadoCompra) as numero FROM `encabezadocompra`;")).Rows[0][0].ToString());
            txtNFactura.Text = Convert.ToString(idFactura + 1);
            txtNFactura.Enabled = false;
        }

        private void txtcompra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            fila = " ";
            fila = txtcompra.CurrentCell.RowIndex.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            precio = Convert.ToUInt32(txtPrecio.Text);
            subtotal = Convert.ToInt32(txtCantidad.Text) * precio;
            suma = suma + subtotal;
            double imp = suma * 0.15;
            double tot = suma + imp;
            txtIVA.Text = Convert.ToString(imp);
            txtSubtotal.Text = Convert.ToString(suma);
            txtTotal.Text = Convert.ToString(tot);
            txtcompra.Rows.Add(txtproducto.Text, txtCategoria.Text, txtCantidad.Text, txtPrecio.Text, subtotal);

            LimpiarAlgunosCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            txtcompra.Rows.RemoveAt(Convert.ToInt32(fila));
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Compra.IDEncabezado = Convert.ToInt32(txtNFactura.Text);
            Compra.Fecha = Convert.ToDateTime(txtfecha.Text);
            Compra.IDProveedor = Convert.ToString(txtProveedor.SelectedValue);
            Compra.Subtotal = Convert.ToDecimal(txtSubtotal.Text);
            Compra.Impuesto = Convert.ToDecimal(txtIVA.Text);
            Compra.Total = Convert.ToDecimal(txtTotal.Text);
            Compra.GuardarEncabezado();
            /*
                foreach (DataGridViewRow dgvRenglon in txtcompra.Rows)
            {
                Compra.NombreProducto = Convert.ToString(dgvRenglon.Cells[0].Value.ToString());
                Compra.IDCategoria = Convert.ToInt32(dgvRenglon.Cells[1].Value.ToString());
                Compra.PrecioProducto = Convert.ToDecimal(dgvRenglon.Cells[2].Value.ToString());
                Compra.CantidadProducto = Convert.ToInt32(dgvRenglon.Cells[3].Value.ToString());

                Compra.GuardarDetalleCompra();

            }
            */
            MessageBox.Show("Factura Ingresada");
            Limpiar();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
