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
        private classListadoProducto pro;

        //Validacion v = new Validacion();
        //claConexion2 conexion;
        //private claProducto Productos;
        //private claseListaPRoductos pro;

        public Frm_BuscarProductos()
        {
            InitializeComponent();
            //conexion = new Conexion();
            //Productos = new classProducto();
            pro = new classListadoProducto();
            //conexion.Establecerconexion();
        }

        private void Frm_BuscarProductos_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
        private void CargarDatos()
        {
            string sql = "";


            if (rbOtrosProductos.Checked)
            {
                sql = String.Format("SELECT id_producto , nombre FROM uma.producto where id_tipo_producto = 1 ;");
            }
            else if (rbRepuesto.Checked)
            {
                sql = String.Format("SELECT id_producto , nombre FROM uma.producto where id_tipo_producto = 2 ;");
            }
            else if (rbServicio.Checked)
            {
                sql = String.Format("SELECT id_producto , nombre FROM uma.producto where id_tipo_producto = 3 ;");
            }
            else
            {
                sql = String.Format("SELECT id_producto , nombre FROM uma.producto where habilitado = 1 ;");
            }
            DataTable t2 = pro.SQL(sql);
            dgv_BuscarProducto.DataSource = null;
            dgv_BuscarProducto.DataSource = t2;
            dgv_BuscarProducto.Refresh();

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = String.Format("SELECT id_producto , nombre FROM uma.producto where id_producto  like '%{0}%' or nombre like '%{0}%'", txtBuscar.Text);
            DataTable t2 = pro.SQL(sql);
            dgv_BuscarProducto.DataSource = null;
            dgv_BuscarProducto.DataSource = t2;
            dgv_BuscarProducto.Refresh();
        }
    }
}
