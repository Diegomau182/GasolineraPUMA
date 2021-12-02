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
    public partial class Producto : Form
    {
        Validaciones validar = new Validaciones();
        private Conexion c;
        private classListadoProducto productos;

        public Producto()
        {
            InitializeComponent();
            c = new Conexion();
            productos = new classListadoProducto();
        }

        private void Frm_Productos_Load(object sender, EventArgs e)
        {
            //Categoria
            DataTable t1 = productos.SQL(String.Format("SELECT idCategoria, nombreCategoria FROM categoria;"));
            cmbx_Categoria.DataSource = null;
            cmbx_Categoria.DataSource = t1;
            cmbx_Categoria.DisplayMember = "nombreCategoria";
            cmbx_Categoria.ValueMember = "idCategoria";

            DataTable t2 = productos.SQL(String.Format("SELECT nombreProveedor, RTNProveedor FROM proveedor;"));
            cmbx_Proveedor.DataSource = null;
            cmbx_Proveedor.DataSource = t2;
            cmbx_Proveedor.DisplayMember = "nombreProveedor";
            cmbx_Proveedor.ValueMember = "RTNProveedor";

        }
        public void limpiarPantallaPro()
        {
            txt_IDProducto.Text = "";
            txt_NombreProducto.Text = "";
            txt_DescProducto.Text = "";
            cmbx_Categoria.SelectedIndex = -1;
            cmbx_Proveedor.SelectedIndex = -1;
            txt_PrecioProducto.Text = "";
            txt_CantidadProducto.Text = "";
            txt_IDProducto.Enabled = true;
        }
        public void GuardarProducto()
        {
            if (txt_IDProducto.Text == string.Empty || txt_NombreProducto.Text== string.Empty || txt_PrecioProducto.Text == string.Empty || txt_CantidadProducto.Text == string.Empty)
            {
                MessageBox.Show("Debe llenar todos los campos", "Error en guardar");
            }
            else {
                classProducto producto = new classProducto();
                producto.idProducto = Convert.ToInt32(txt_IDProducto.Text);
                producto.nombreProducto = txt_NombreProducto.Text;
                producto.descripcionProducto = txt_DescProducto.Text;
                producto.idCategoria = Convert.ToInt32(cmbx_Categoria.SelectedValue);
                producto.idProveedor = Convert.ToString(cmbx_Proveedor.SelectedValue);
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
        }
        public void llenarProducto()
        {


            DataTable t1 = productos.SQL(String.Format("SELECT  nombreProducto, descripcionProducto, idCategoria, idProveedor, precioProducto, cantidadProducto FROM producto where idProducto = {0} ; ", txt_IDProducto.Text));
            if (t1.Rows.Count != 0)
            {
                txt_NombreProducto.Text = t1.Rows[0]["nombreProducto"].ToString();
                txt_DescProducto.Text = t1.Rows[0]["descripcionProducto"].ToString();
                cmbx_Categoria.SelectedValue = t1.Rows[0]["idCategoria"].ToString();
                cmbx_Proveedor.SelectedValue = t1.Rows[0]["idProveedor"].ToString();
                txt_PrecioProducto.Text = t1.Rows[0]["precioProducto"].ToString();
                txt_CantidadProducto.Text = t1.Rows[0]["cantidadProducto"].ToString();
                txt_IDProducto.Enabled = false;
            }
            else
            {
                MessageBox.Show("El producto no existe");
            }



        }
        private void btn_Ingresar_Click(object sender, EventArgs e)
        {
            GuardarProducto();
        }

        private void btn_Salir_Click_1(object sender, EventArgs e)
        {
            Frm_BuscarProductos buscarProductos = new Frm_BuscarProductos();
            buscarProductos.Show();
            this.Close();
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            if (txt_IDProducto.Text != "")
            {
                llenarProducto();
            }
            else
            {
                MessageBox.Show("Ingrese el producto a buscar");
            }

        }

        private void btn_Eliminar_Click_1(object sender, EventArgs e)
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
                }
                else
                {
                    MessageBox.Show("Error");
                }

            }
        }

        private void btn_Modificar_Click_1(object sender, EventArgs e)
        {
            if (txt_IDProducto.Text == string.Empty || txt_NombreProducto.Text == string.Empty || txt_PrecioProducto.Text == string.Empty || txt_CantidadProducto.Text == string.Empty)
            {
                MessageBox.Show("Debe llenar todos los campos", "Error en Editar");
            }
            else
            {
                classProducto producto = new classProducto();
                producto.idProducto = Convert.ToInt32(txt_IDProducto.Text);
                producto.nombreProducto = txt_NombreProducto.Text;
                producto.descripcionProducto = txt_DescProducto.Text;
                producto.idCategoria = Convert.ToInt32(cmbx_Categoria.SelectedValue);
                producto.idProveedor = Convert.ToString(cmbx_Proveedor.SelectedValue);
                producto.precioPrducto = Convert.ToDecimal(txt_PrecioProducto.Text);
                producto.cantidadProducto = Convert.ToInt32(txt_CantidadProducto.Text);


                if (producto.ModificarProducto())
                {
                    MessageBox.Show("Producto Modificado", "Confirmacion", MessageBoxButtons.OK);
                    limpiarPantallaPro();
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void btn_LimpiarPantallaP_Click(object sender, EventArgs e)
        {
            limpiarPantallaPro();
        }

        //Validaciones
        private void txt_IDProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.soloNumeros(e);
        }

        private void txt_NombreProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.soloLetras(e);
        }

        private void txt_DescProducto_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txt_PrecioProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txt_CantidadProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.soloNumeros(e);
        }
    }
}
