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
        private double imp;
        private double tot;
        public FmCompras()
        {
            InitializeComponent();

            c = new Conexion();

            compras = new Clases.ClaListaCompra();
            Compra = new Clases.ClaCompra();

            //TraerId();
            Datos_Categoria();
            Datos_Proveedor();
            Bloqueartxt();
            Limpiar();
        }


        private void Bloqueartxt()
        {
            //txtNFactura.Enabled = false;
            txtSubtotal.Enabled = false;
            txtIVA.Enabled = false;
            txtTotal.Enabled = false;
            txtfecha.Enabled = false;
        }

        private void Limpiar()
        {
            txtfecha.Value = DateTime.Today;
            txtNFactura.Focus();
            txtNFactura.Text = string.Empty;
            txtProveedor.Text = string.Empty;
            txtproducto.Text = string.Empty;
            txtCategoria.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtSubtotal.Text = string.Empty;
            txtIVA.Text = string.Empty;
            txtTotal.Text = string.Empty;
            txtCodigo.Text = string.Empty;
            txtcompra.AllowUserToAddRows = false;
            txtcompra.Rows.Clear();
        }

        private void LimpiarAlgunosCampos()
        {
            txtCodigo.Text = string.Empty;
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
            this.txtcompra.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void FmCompras_Load(object sender, EventArgs e)
        {
                txtcompra.Columns.Add("codigoProducto", "Codigo Producto");
                txtcompra.Columns.Add("nombreProducto", "Nombre Producto");
                txtcompra.Columns.Add("idCategoria", "Categoria");
                txtcompra.Columns.Add("cantidadProducto", "Cantidad");
                txtcompra.Columns.Add("precioProducto", "Precio");
                txtcompra.Columns.Add("subtotal", "Subtotal");
                //txtcompra.Columns.Add("subtotal", "subTotal");
                ajustarTamañoFactura();
                Limpiar();
        }

       /* private void TraerId()
        {
            idFactura = Convert.ToInt32(c.consulta(string.Format("SELECT COUNT(idEncabezadoCompra) as numero FROM `encabezadocompra`;")).Rows[0][0].ToString());
            txtNFactura.Text = Convert.ToString(idFactura + 1);
            txtNFactura.Enabled = false;
        }*/

        private void txtcompra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            fila = " ";
            fila = txtcompra.CurrentCell.RowIndex.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text == string.Empty || txtCodigo.Text == string.Empty || txtproducto.Text == string.Empty || txtPrecio.Text == string.Empty) {
                MessageBox.Show("Debe llenar todos los campos", "Error en agregar");
            }
            else
            {
                precio = Convert.ToUInt32(txtPrecio.Text);
                subtotal = Convert.ToInt32(txtCantidad.Text) * precio;
                txtcompra.Rows.Add(txtCodigo.Text, txtproducto.Text, txtCategoria.SelectedValue, txtCantidad.Text, txtPrecio.Text, subtotal);

                foreach (DataGridViewRow dgvRenglon in txtcompra.Rows)
                {
                    double su = Convert.ToDouble(dgvRenglon.Cells[5].Value.ToString());
                    suma = suma + su;
                    imp = suma * 0.15;
                    tot = suma + imp;
                }

                txtIVA.Text = Convert.ToString(imp);
                txtSubtotal.Text = Convert.ToString(suma);
                txtTotal.Text = Convert.ToString(tot);

                suma = 0;
                imp = 0;
                tot = 0;


                LimpiarAlgunosCampos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            txtcompra.Rows.RemoveAt(Convert.ToInt32(fila));
            foreach (DataGridViewRow dgvRenglon in txtcompra.Rows)
            {
                double su = Convert.ToDouble(dgvRenglon.Cells[5].Value.ToString());
                suma = suma + su;
                imp = suma * 0.15;
                tot = suma + imp;
            }

            txtIVA.Text = Convert.ToString(imp);
            txtSubtotal.Text = Convert.ToString(suma);
            txtTotal.Text = Convert.ToString(tot);

            suma = 0;
            imp = 0;
            tot = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNFactura.Text == string.Empty || txtcompra.Rows.Count == 0) {
                MessageBox.Show("Debe ingresar el numero de la Factura y la compra no debe ir vacia", "Error en guardar");
            }
            else
            {

                Compra.IDEncabezado = Convert.ToString(txtNFactura.Text);
                Compra.IDProveedor = Convert.ToString(txtProveedor.SelectedValue);
                Compra.Subtotal = Convert.ToDecimal(txtSubtotal.Text);
                Compra.Impuesto = Convert.ToDecimal(txtIVA.Text);
                Compra.Total = Convert.ToDecimal(txtTotal.Text);
                Compra.GuardarEncabezado();

                foreach (DataGridViewRow dgvRenglon in txtcompra.Rows)
                {
                    Compra.Codigo = Convert.ToInt32(dgvRenglon.Cells[0].Value.ToString());
                    Compra.NombreProducto = Convert.ToString(dgvRenglon.Cells[1].Value.ToString());
                    Compra.IDCategoria = Convert.ToInt32(dgvRenglon.Cells[2].Value.ToString());
                    Compra.PrecioProducto = Convert.ToDecimal(dgvRenglon.Cells[4].Value.ToString());
                    Compra.CantidadProducto = Convert.ToInt32(dgvRenglon.Cells[3].Value.ToString());


                    Compra.GuardarDetalleCompra();

                }
                MessageBox.Show("Productos ingresados","Guardado Correcto");
                Limpiar();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
