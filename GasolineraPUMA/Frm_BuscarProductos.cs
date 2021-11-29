using GasolineraPUMA.Clases;
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
    public partial class Frm_BuscarProductos : Form
    {
        //Validacion v = new Validacion();
        Conexion conexion;
        private classProducto Productos;
        private classListadoProducto listadoProduc;

        public Frm_BuscarProductos()
        {
            InitializeComponent();
            conexion = new Conexion();
            Productos = new classProducto();
            listadoProduc = new classListadoProducto();
            conexion.Establecerconexion();
        }
        private void CargarDatos()
        {
            string sql = "";
            sql = String.Format("SELECT producto.idProducto, producto.nombreProducto, producto.descripcionProducto, categoria.nombreCategoria, producto.cantidadProducto, producto.precioProducto FROM producto INNER JOIN categoria ON producto.idCategoria=categoria.idCategoria;");
            //sql = String.Format("SELECT idProducto, nombreProducto, descripcionProducto, idCategoria, idProveedor, precioProducto, cantidadProducto from producto;");
            DataTable t2 = listadoProduc.SQL(sql);
            dgvBuscarProducto.DataSource = null;
            dgvBuscarProducto.DataSource = t2;
            dgvBuscarProducto.Refresh();

        }
         private void ajustarColumnas()
        {
            this.dgvBuscarProducto.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBuscarProducto.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBuscarProducto.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBuscarProducto.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBuscarProducto.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvBuscarProducto.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //this.dgvBuscarProducto.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        

        private void Frm_BuscarProductos_Load(object sender, EventArgs e)
        {
            CargarDatos();
            ajustarColumnas();
        }
        

        private void txtboxBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = String.Format("SELECT  idProducto, nombreProducto, descripcionProducto,idCategoria, precioProducto, cantidadProducto FROM producto WHERE idProducto LIKE'%{0}%' OR nombreProducto LIKE '%{0}%'", txtboxBuscarProducto.Text);
            DataTable t2 = listadoProduc.SQL(sql);
            dgvBuscarProducto.DataSource = null;
            dgvBuscarProducto.DataSource = t2;
            dgvBuscarProducto.Refresh();
    
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            Producto frmProduc = new Producto();
            frmProduc.Show();
            Visible = false;
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            Frm_ReporteProducto cambiarFrm = new Frm_ReporteProducto();
            cambiarFrm.Show();
        }
    }
}
