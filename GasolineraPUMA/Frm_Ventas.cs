using System;
using System.Data;
using System.Windows.Forms;

namespace GasolineraPUMA
{
    public partial class Frm_Ventas : Form
    {
        private Clases.Ventas ventas;
        private Clases.TablaVentas tabla;
        private Conexion conexion;
        private Clases.Validaciones validaciones;
        private int idFactura;
        private string nombreProducto;
        private int idProducto;
        private decimal precio;
        private string fila;
        private decimal total;
        private decimal totalTotal;
        private decimal subtotalEliminar;
       
        

        public Frm_Ventas()
        {
            InitializeComponent();
            conexion = new Conexion();
            ventas = new Clases.Ventas();
            tabla = new Clases.TablaVentas();
            validaciones = new Clases.Validaciones();
            conexion.Establecerconexion();
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dtgrProducto.SelectedRows.Count == 0 || dtgrProducto.SelectedRows.Count > 1 || txtCantidad.Text == " ") 
            {
                MessageBox.Show("Debe selecionar solo un objeto y la cantidad debe ser mayor a 0 ", "Error");
            }
            else { 
            decimal subtotal = Convert.ToInt32(txtCantidad.Text) * precio;
            dvgFactura.Rows.Add(idProducto, nombreProducto, txtCantidad.Text, precio, subtotal);
            total = total + subtotal;
            txtCantidad.Text = "";
            txtISV.Text = Convert.ToString(total * Convert.ToDecimal(0.15));
            totalTotal = total - Convert.ToDecimal(txtISV.Text);
            txtTotal.Text = Convert.ToString(totalTotal);
             }
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
            txtTotal.Text = " ";
            txtISV.Text = " ";
            txtTotal.ReadOnly = false;
            txtISV.ReadOnly = false;
            txtIdFactura.ReadOnly = false;
            Fecha.Enabled = false;
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
            if (dvgFactura.Rows.Count == 0) {
                MessageBox.Show("La factura debe tener mas de un producto agregado", "Error en crear Factura");
            }
            else
            {
                if (txtNombreCliente.Text == string.Empty)
                {
                    ventas.Nombre = "Sin Nombre";
                }
                else
                {
                    ventas.Nombre = Convert.ToString(txtNombreCliente.Text);
                }
                ventas.IdFactura = Convert.ToInt32(txtIdFactura.Text);
                ventas.ISV = Convert.ToDecimal(txtISV.Text);
                ventas.Total = Convert.ToDecimal(txtTotal.Text);
                ventas.guardarventa();

                foreach (DataGridViewRow dgvRenglon in dvgFactura.Rows)
                {
                    ventas.IdProducto = Convert.ToInt32(dgvRenglon.Cells[0].Value.ToString());
                    ventas.Cantidades = Convert.ToInt32(dgvRenglon.Cells[2].Value.ToString());
                    ventas.Precio = Convert.ToDecimal(dgvRenglon.Cells[3].Value.ToString());
                    ventas.Subtotal = Convert.ToDecimal(dgvRenglon.Cells[4].Value.ToString());

                    ventas.guardarDetalleVenta();

                }
                DialogResult dr = MessageBox.Show("Desea Imprir la Factura",
                      "Mood Test", MessageBoxButtons.YesNo);
                switch (dr)
                {
                    case DialogResult.Yes:
                        MessageBox.Show("Factura Creada Sactifactoria mente","Se creo la factura");
                        ImprimirFactura ImpFacu = new ImprimirFactura();
                        ImpFacu.Show();
                        break;
                    case DialogResult.No:
                        MessageBox.Show("Factura Creada Sactifactoria mente", "Se creo la factura");
                        break;
                }
                Limpiar();
            }
           
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
            if (dvgFactura.SelectedRows.Count == 0 || dvgFactura.SelectedRows.Count > 1)
            {
                MessageBox.Show("Debe selecionar mas una fila para que operacion pueda llevarse acabo", "Error");
            } 
            else { 
            dvgFactura.Rows.RemoveAt(Convert.ToInt32(fila));
            total = total - Convert.ToDecimal(subtotalEliminar);
            txtISV.Text = Convert.ToString(total * Convert.ToDecimal(0.15));
            totalTotal = total - Convert.ToDecimal(txtISV.Text);
            txtTotal.Text = Convert.ToString(totalTotal);
            }
        }
            private void btnSalida_Click(object sender, EventArgs e)
        {
            Frm_Ventas ventas = new Frm_Ventas();
            ventas.Close();
            Menu menu = new Menu();
            menu.Show();
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dvgFactura_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            subtotalEliminar = Convert.ToDecimal(dvgFactura.CurrentRow.Cells[4].Value.ToString());
        }

        private void txtNombreCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            validaciones.soloLetras(e);
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            validaciones.soloNumeros(e);
        }

        private void btnSalida_Click_1(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
