using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace GasolineraPUMA.Clases
{
    class ClaCompra
    {
        //---------Encabezado compra-----------
        private int idencabezado;
        private DateTime fecha;
        private string idProveedor;
        private decimal subtotal;
        private decimal impuesto;
        private decimal total;

        //---------Detalle Compra--------------

        private int idProducto;
        private string nombreProducto;
        private int idCategoria;
        private decimal precioProducto;
        private int cantidadProducto;
        


        private Conexion conexion;
        private MySqlException error;


        public ClaCompra()
        {
            fecha = DateTime.Today;
            idProveedor = string.Empty;
            subtotal = 0;
            impuesto = 0;
            total = 0;

            //--------Detalle----------
            idProducto = 0;
            nombreProducto = string.Empty;
            idCategoria = 0;
            precioProducto = 0;
            cantidadProducto = 0;
            idencabezado = 0;
            conexion = new Conexion();
        }

        public ClaCompra(int id, DateTime fe, string idProv, decimal sub, decimal imp, decimal tot, int idPro, string nombre,
            int idCa, decimal precio, int cantidad)
        {
            //--------Encabezado----------
            fecha = fe;
            idProveedor = idProv;
            subtotal = sub;
            impuesto = imp;
            total = tot;

            //--------Detalle----------
            idProducto = idPro;
            nombreProducto = nombre;
            idCategoria = idCa;
            precioProducto = precio;
            cantidadProducto = cantidad;
            idencabezado = id;
            conexion = new Conexion();
        }


        //---------Encabezado compra-----------

        public int IDEncabezado
        {
            get { return idencabezado; }
            set { idencabezado = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public string IDProveedor
        {
            get { return idProveedor; }
            set { idProveedor = value; }
        }

        public decimal Subtotal
        {
            get { return subtotal; }
            set { subtotal = value ; }
        }

        public decimal Impuesto
        {
            get { return impuesto; }
            set { impuesto = value; }
        }

        public decimal Total
        {
            get { return total; }
            set {total = value; }
        }


        //---------Detalle compra-----------
        public int IDProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }

        public string NombreProducto
        {
            get { return nombreProducto; }
            set { nombreProducto =value; }
        }

        public int IDCategoria
        {
            get => idCategoria;
            set { idCategoria = value; }
        }


        public decimal PrecioProducto
        {
            get { return precioProducto; }
            set { precioProducto = value; }
        }

        public int CantidadProducto
        {
            get { return cantidadProducto; }
            set {cantidadProducto = value; }
        }

       



        public Boolean GuardarEncabezado()
        {
            if (conexion.Ejecutar(string.Format("INSERT INTO dbpuma.encabezadocompra (idEncabezadoCompra, idProveedor, subtotal, impuesto, total) value('{0}','{1}','{2}','{3}','{4}')", IDEncabezado, IDProveedor, Subtotal, Impuesto, Total)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean GuardarDetalleCompra()
        {
            if (conexion.Ejecutar(string.Format("INSERT INTO dbpuma.detallecompra(nombreProducto, idCategoria, precioProducto, cantidadProducto, idencabezado) value('{0}','{1}','{2}','{3}','{4}')", NombreProducto, IDCategoria, PrecioProducto, CantidadProducto, IDEncabezado)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public MySqlException Error
        {
            get { return error; }
        }
    }
}
