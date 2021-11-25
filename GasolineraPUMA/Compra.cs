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
    public partial class FmCompra : Form
    {

        Conexion c;

        private Clases.ClaListaCompra compras;
        private Clases.ClaCompra compra;


        public FmCompra()
        {
            InitializeComponent();

            c = new Conexion();

            compras = new Clases.ClaListaCompra();
            compra = new Clases.ClaCompra();

            Compras_Load();
        }


        private void Compras_Load()
        {
            DataTable t2 = compras.SQL(String.Format("Select e.idEncabezadoCompra, e.fecha, e.idProveedor, " +
                " d.nombreProducto, d.idCategoria, d.precioProducto, d.cantidadProducto, e.subtotal, e.impuesto, e.total," +
                "d.idencabezado FROM dbpuma.encabezadocompra AS e INNER JOIN dbpuma.detallecompra AS d ON e.idEncabezadoCompra = d.idencabezado"));
            //DataTable t2 = compras.SQL(String.Format("SELECT * FROM taller.vistacompraproducto;"));
            ListCompras.DataSource = null;
            ListCompras.DataSource = t2;
            ListCompras.Refresh();
            ListCompras.Enabled = false;

            DataGridLectura();

        }



        public void DataGridLectura()
        {
            /// Para el DataGrid de compras
            ListCompras.Columns["idEncabezadoCompra"].ReadOnly = true;
            ListCompras.Columns["fecha"].ReadOnly = true;
            ListCompras.Columns["idProveedor"].ReadOnly = true;
            ListCompras.Columns["nombreProducto"].ReadOnly = true;
            ListCompras.Columns["idCategoria"].ReadOnly = true;
            ListCompras.Columns["precioProducto"].ReadOnly = true;
            ListCompras.Columns["cantidadProducto"].ReadOnly = true;
            ListCompras.Columns["subtotal"].ReadOnly = true;
            ListCompras.Columns["impuesto"].ReadOnly = true;
            ListCompras.Columns["total"].ReadOnly = true;

            ListCompras.Enabled = false;

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListCompras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable t3 = compras.SQL(String.Format("SELECT * FROM dbpuma.detallecompra WHERE idencabezado LIKE '" + txtBuscar.Text + "'"));
            ListCompras.DataSource = null;
            ListCompras.DataSource = t3;
            ListCompras.Refresh();
            ListCompras.Enabled = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.Hide();
            FmCompras frm = new FmCompras();
            frm.Show();

        }


      


        private void btnBuscar_Click(object sender, EventArgs e)
        {

            if (Filtro())
            {
                DataTable t1 = compras.SQL(String.Format("SELECT * FROM dbpuma.encabezadocompra WHERE idEncabezadoCompra LIKE '" + txtBuscar.Text + "'"));
                ListCompras.DataSource = null;
                ListCompras.DataSource = t1;
                ListCompras.Refresh();
                ListCompras.Enabled = true;
            }
            
        }

        private Boolean Filtro()
        {
            Boolean r = true;
            if (txtBuscar.Text == "")
            {
                MessageBox.Show("Escriba algo en la caja de texto", "Compra", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBuscar.Focus();
                r = false;
            }
            else if (txtBuscar.Text == "")
            {
                DataTable t2 = compras.SQL(String.Format("Select e.idEncabezadoCompra, e.fecha, e.idProveedor, " +
                " d.nombreProducto, d.idCategoria, d.precioProducto, d.cantidadProducto, e.subtotal, e.impuesto, e.total," +
                "d.idencabezado FROM dbpuma.encabezadocompra AS e INNER JOIN dbpuma.detallecompra AS d ON e.idEncabezadoCompra = d.idencabezado"));
                //DataTable t2 = compras.SQL(String.Format("SELECT * FROM taller.vistacompraproducto;"));
                ListCompras.DataSource = null;
                ListCompras.DataSource = t2;
                ListCompras.Refresh();

                DataGridLectura();
            }
            else
                r = true;
            return r;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = string.Empty;
            Compras_Load();
        }

        private void FmCompra_Load(object sender, EventArgs e)
        {

        }
    }
}
