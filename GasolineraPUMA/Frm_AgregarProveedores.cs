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
    public partial class Frm_AgregarProveedores : Form
    {
        private Clases.proveedor prov;
        private Conexion c;

        public Frm_AgregarProveedores()
        {
            InitializeComponent();
            prov = new Clases.proveedor();
            c = new Conexion();
        }

        public void limpiarPantallaPro()
        {
            txt_rtnPro.Text = "";
            txt_empresaPro.Text = "";
            txt_nombrePro.Text = "";
            txt_apellidoPro.Text = "";
            txt_correoPro.Text = "";
            txt_telefonoPro.Text = "";
        }
        public void guardarProveedor()
        {
            prov.RtnProveedor = txt_rtnPro.Text;
            prov.EmpresaProveedor = txt_empresaPro.Text;
            prov.NombreProveedor = txt_nombrePro.Text;
            prov.ApellidoProveedor = txt_apellidoPro.Text;
            prov.EmalProveedor = txt_correoPro.Text;
            prov.TelefonoProveedor = txt_telefonoPro.Text;

            if (prov.GuardarProveedor())
            {
                limpiarPantallaPro();
                MessageBox.Show("Producto Guardado");
                Form formulario = new Frm_ListaProveedores();
                formulario.Show();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void selectProveedor()
        {
           listaProveedores proveedor = new listaProveedores();

            if (txt_rtnPro.Text == null)
            {
                MessageBox.Show("Debe ingresar el RTN del proveedor oara poder editarlo");
            }
            else
            {
                string rtn = txt_rtnPro.Text;
                string sql = "";
                sql = String.Format("SELECT RTNProveedor, empresaProveedor,nombreProveedor,apellidoProveedor,emailProveedor,telefonoProveedor FROM proveedor WHERE RTNProveedor = '{0}' AND habilitado = 1", rtn);
                DataTable t2 = proveedor.SQL(sql);
                txt_rtnPro.Text = t2.Rows[0].ItemArray[0].ToString();
                txt_empresaPro.Text = t2.Rows[0].ItemArray[1].ToString();
                txt_nombrePro.Text = t2.Rows[0].ItemArray[2].ToString();
                txt_apellidoPro.Text = t2.Rows[0].ItemArray[3].ToString();
                txt_correoPro.Text = t2.Rows[0].ItemArray[4].ToString();
                txt_telefonoPro.Text = t2.Rows[0].ItemArray[5].ToString();
            }
        }
        private void modificarProveedor()
        {
            listaProveedores proveedor = new listaProveedores();


            prov.RtnProveedor = txt_rtnPro.Text;
            prov.EmpresaProveedor = txt_empresaPro.Text;
            prov.NombreProveedor = txt_nombrePro.Text;
            prov.ApellidoProveedor = txt_apellidoPro.Text;
            prov.EmalProveedor = txt_correoPro.Text;
            prov.TelefonoProveedor = txt_telefonoPro.Text;

            if (prov.ModificarProveedor())
            {
                MessageBox.Show("Proveedor ha sido modificado Correctamente");
                limpiarPantallaPro();
            }
            else
            {
                MessageBox.Show("Error");
            }


        }

        private void eliminarProveedor()
        {
            prov.RtnProveedor = txt_rtnPro.Text;


            if (prov.EliminarProveedor())
            {
                MessageBox.Show("Proveedor ha sido eliminado Correctamente");
                limpiarPantallaPro();
            }
            else
            {
                MessageBox.Show("Error");
            }


        }
        private void guardarPro_Click(object sender, EventArgs e)
        {

            guardarProveedor();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void empresaPro_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            modificarProveedor();
            this.Close();
        }

        private void txtEditar_Click(object sender, EventArgs e)
        {
            
        }

        private void eliminarPro_Click(object sender, EventArgs e)
        {
            eliminarProveedor();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            selectProveedor();
        }
    }
}

