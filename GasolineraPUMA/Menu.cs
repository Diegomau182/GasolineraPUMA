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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            Frm_Ventas ventas = new Frm_Ventas();
            ventas.Close();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Frm_BuscarProductos frm_Buscar = new Frm_BuscarProductos();
            frm_Buscar.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Categoria categoria = new Categoria();
            categoria.Show();
     
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Frm_Ventas ventas = new Frm_Ventas();
            ventas.Show();

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            FmCompra compra = new FmCompra();
            compra.Show();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Frm_ListaProveedores proveedoresLista = new Frm_ListaProveedores();
            proveedoresLista.Show();
        }
    }
}
