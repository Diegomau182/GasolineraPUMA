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
    public partial class Pro : Form
    {
        //Validacion validar = new Validacion();
        private Conexion c;
        private classListadoProducto productos;

        public Pro()
        {
            InitializeComponent();
            c = new Conexion();
            productos = new classListadoProducto();
        }

        private void Frm_Productos_Load(object sender, EventArgs e)
        {
            DataTable t1 = productos.SQL(String.Format("SELECT idCategoria, nombreCategoria FROM categoria ;"));
            cmbx_Categoria.DataSource = null;
            cmbx_Categoria.DataSource = t1;
            cmbx_Categoria.DisplayMember = "nombreCategoria";
            cmbx_Categoria.ValueMember = "idCategoria";
            btn_LimpiarPantallaP.Visible = true;

            //falta el 2
            //DataTable t2 = productos.SQL(String.Format("SELECT prov.nombreProveedor, prod.idProveedor FROM producto CROSS JOIN proveedor ;"));
            //cmbx_Proveedor.DataSource = null;
            //cmbx_Proveedor.DataSource = t1;
            //cmbx_Proveedor.DisplayMember = "nombreProveedor";
            //cmbx_Proveedor.ValueMember = "idProveedor";
            //btn_LimpiarPantallaP.Visible = true;

        }
        public void limpiarPantallaPro()
        {
            txt_IDProducto.Text = "";
            txt_NombreProducto.Text = "";
            txt_DescProducto.Text = "";
            cmbx_Categoria.SelectedIndex = -1;
            cmbx_Proveedor.SelectedIndex = -1;
            txt_CantidadProducto.Text = "";
        }
        public void GuardarProductoGeneral()
        {
            txt_IDProducto.Enabled = true;
            //btnbuscar.Enabled = true;
            classProducto producto = new classProducto();
            producto.nombreProducto = txt_NombreProducto.Text;
            producto.descripcionProducto = txt_DescProducto.Text;
            producto.idCategoria = Convert.ToInt32(cmbx_Categoria.SelectedValue);
            //producto.idProveedor = Convert.ToInt32(cmbx_Proveedor.SelectedValue);
            producto.idProveedor = txt_Proveedor.Text;
            producto.precioPrducto = Convert.ToDecimal(txt_PrecioProducto.Text);
            producto.cantidadProducto = Convert.ToInt32(txt_CantidadProducto.Text);
            if (producto.GuardarProducto())
            {

                limpiarPantallaPro();
                MessageBox.Show("Producto Guardado");


            }
            else
            {
                MessageBox.Show("Error");
            }
        }
        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            btn_Ingresar.Visible = false;
            btn_Ingresar.Visible = true;
            //btnCancelar.Visible = true;
            btn_Eliminar.Visible = true;
            //btnCancelar.Visible = true;
            btn_LimpiarPantallaP.Visible = true;
            txt_IDProducto.Visible = true;
            btn_LimpiarPantallaP.Location = new Point(460, 290);
            btn_LimpiarPantallaP.Text = "Limpiar Pantalla";
            classProducto producto = new classProducto();
            producto.idProducto = Convert.ToInt32(txt_IDProducto.Text);
            producto.nombreProducto = txt_NombreProducto.Text;
            producto.descripcionProducto = txt_DescProducto.Text;
            producto.idCategoria = Convert.ToInt32(cmbx_Categoria.SelectedValue);
            //producto.idProveedor = Convert.ToInt32(cmbx_Proveedor.SelectedValue);
            producto.precioPrducto = Convert.ToDecimal(txt_PrecioProducto.Text);
            producto.cantidadProducto = Convert.ToInt32(txt_CantidadProducto.Text);


            if (producto.ModificarProducto())
            {
                MessageBox.Show("Producto Modificado", "Confirmacion", MessageBoxButtons.OK);
                limpiarPantallaPro();
                btn_Ingresar.Visible = true;

            }
            else
            {
                MessageBox.Show("Error");
            }

        }
        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (txt_IDProducto.Text == "")
            {
                MessageBox.Show("Ingrese producto a eliminar");
            }
            else
            {
                classProducto producto = new classProducto();
                producto.idProducto = Convert.ToInt32(txt_IDProducto.Text);


                if (producto.EliminarProducto())
                {
                    MessageBox.Show("Producto Eliminado", "Confirmacion", MessageBoxButtons.OK);
                    limpiarPantallaPro();
                    btn_Ingresar.Visible = true;

                }
                else
                {
                    MessageBox.Show("Error");
                }

            }
            btn_Ingresar.Visible = false;
            btn_Ingresar.Visible = true;
            //btnCancelar.Visible = true;
            btn_Eliminar.Visible = true;
            //btnCancelar.Visible = true;
            btn_LimpiarPantallaP.Visible = true;
            txt_IDProducto.Visible = true;
            btn_LimpiarPantallaP.Location = new Point(460, 290);
            btn_LimpiarPantallaP.Text = "Limpiar Pantalla";
        }
        private void btn_LimpiarPantalla_Click(object sender, EventArgs e)
        {

            if (btn_LimpiarPantallaP.Text == "Cancelar")
            {
                limpiarPantallaPro();
                btn_Ingresar.Visible = true;
                btn_LimpiarPantallaP.Location = new Point(460, 290);
                btn_LimpiarPantallaP.Text = "Limpiar Pantalla";

            }
            else
            {
                limpiarPantallaPro();
            }

        }


        private void btn_Ingresar_Click(object sender, EventArgs e)
        {
            GuardarProductoGeneral();
        }

        private void btn_Salir_Click_1(object sender, EventArgs e)
        {
            //Form formulario = new Menu();
            //formulario.Show();
            Visible = false;
        }

    }
}
