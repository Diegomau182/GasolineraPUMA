using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using GasolineraPUMA.Clases;

namespace GasolineraPUMA
{
    public partial class Frm_ListaProveedores : Form
    {
        Conexion conexion;
        private proveedor proveedores;
        private listaProveedores prov;
        public Frm_ListaProveedores()

        {
            InitializeComponent();
            conexion = new Conexion();
            proveedores = new proveedor();
            prov = new listaProveedores();
            conexion.Establecerconexion();
            CargarDatos();
            ajustarTamaño();
            dataGridView3.Refresh();

        }

        public void ajustarTamaño()
        {
            this.dataGridView3.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView3.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView3.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView3.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView3.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView3.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void CargarDatos()
        {
            string sql = "";
            sql = String.Format("SELECT  RTNProveedor,empresaProveedor,nombreProveedor,apellidoProveedor,emailProveedor,telefonoProveedor FROM proveedor WHERE habilitado = 1 ");
            DataTable t2 = prov.SQL(sql);
            dataGridView3.DataSource = null;
            dataGridView3.DataSource = t2;
            dataGridView3.Columns[0].HeaderText = "RTN";
            dataGridView3.Refresh();
        }
       
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form formulario = new Frm_AgregarProveedores();
            formulario.Show();
        }

        private void Frm_ListaProveedores_Load(object sender, EventArgs e)
        {
            CargarDatos();
            ajustarTamaño();

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void btn_buscarProv_Click(object sender, EventArgs e)
        {

        }

        private void txt_BuscarProv_TextChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = String.Format("SELECT  RTNProveedor,empresaProveedor,nombreProveedor,apellidoProveedor,emailProveedor,telefonoProveedor FROM proveedor where  habilitado = 1 AND (RTNProveedor  like '%{0}%' or empresaProveedor like '%{0}%')  ", txt_BuscarProv.Text);
            DataTable t2 = prov.SQL(sql);
            dataGridView3.DataSource = null;
            dataGridView3.DataSource = t2;
            dataGridView3.Refresh();
            ajustarTamaño();
        }
    }
}
