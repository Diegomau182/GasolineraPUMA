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
        private Conexion c;

        public Frm_AgregarProveedores()
        {
            InitializeComponent();
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
            proveedor prov = new proveedor();
            prov.RtnProveedor = txt_rtnPro.Text;
            prov.EmpresaProveedor = txt_empresaPro.Text;
            prov.NombreProveedor = txt_nombrePro.Text;
            prov.ApellidoProveedor = txt_apellidoPro.Text;
            prov.EmalProveedor = txt_correoPro.Text;
            prov.TelefonoProveedor = txt_telefonoPro.Text;
            if(prov.GuardarProveedor())
            {
                limpiarPantallaPro();
                MessageBox.Show("Producto Guardado");
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
    }
}
