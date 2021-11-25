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
        private DateTime fecha;
        private string idProveedor;
        private decimal subtotal;
        private decimal impuesto;
        private decimal total;

        //---------Detalle Compra--------------

        private int idProducto;
        private string nombreProducto;
        private string descripcionProducto;
        private int idCategoria;
        private decimal precioProducto;
        private int cantidadProducto;
        private int idencabezado;

        private int comodin;
        private string comodin2;

        private int comodinID;


        private Conexion conexion;
        private MySqlException error;


        public ClaCompra()
        {
            //--------Encabezado----------
            fecha = DateTime.Today;
            idProveedor = string.Empty;
            subtotal = 0;
            impuesto = 0;
            total = 0;

            //--------Detalle----------
            idProducto = 0;
            nombreProducto = string.Empty;
            descripcionProducto = string.Empty;
            idCategoria = 0;
            precioProducto = 0;
            cantidadProducto = 0;
            idencabezado = 0;
            conexion = new Conexion();
        }

        public ClaCompra(int id, DateTime fe, string idProv, decimal sub, decimal imp, decimal tot, int idPro, string nombre, string descripcion,
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
            descripcionProducto = descripcion;
            idCategoria = idCa;
            precioProducto = precio;
            cantidadProducto = cantidad;
            idencabezado = id;
            conexion = new Conexion();
        }

        public int Comodin
        {
            get => comodin;
            set
            {
                comodin = value;
            }
        }

        public int ComodinID
        {
            get => comodinID;
            set
            {
                comodinID = value;
            }
        }

        public string Comodin2
        {
            get => comodin2;
            set
            {
                comodin2 = value;
            }
        }

        //---------Encabezado compra-----------

        public DateTime Fecha
        {
            get { return fecha; }
            set { value = fecha; }
        }

        public string IDProveedor
        {
            get { return idProveedor; }
            set { value = idProveedor; }
        }

        public decimal Subtotal
        {
            get { return subtotal; }
            set { value = subtotal; }
        }

        public decimal Impuesto
        {
            get { return impuesto; }
            set { value = impuesto; }
        }

        public decimal Total
        {
            get { return total; }
            set { value = total; }
        }


        //---------Detalle compra-----------
        public int IDProducto
        {
            get { return idProducto; }
            set { value = idProducto; }
        }

        public string NombreProducto
        {
            get { return nombreProducto; }
            set { value = nombreProducto; }
        }

        public string DescripcionProducto
        {
            get { return descripcionProducto; }
            set { value = descripcionProducto; }
        }

        public int IDCategoria
        {
            get => idCategoria;
            set { value = idCategoria; }
        }


        public decimal PrecioProducto
        {
            get { return precioProducto; }
            set { value = precioProducto; }
        }

        public int CantidadProducto
        {
            get { return cantidadProducto; }
            set { value = cantidadProducto; }
        }

        public int IDEncabezado
        {
            get { return idencabezado; }
            set { value = idencabezado; }
        }



        public Boolean GuardarEncabezado()
        {
            if (conexion.Ejecutar(string.Format("INSERT INTO dbpuma.encabezadocompra (fecha, idProveedor, subtotal, impuesto, total) value('{0}','{1}','{2}','{3}','{4}')", Fecha, IDProveedor, Subtotal, Impuesto, Total)))
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
            if (conexion.Ejecutar(string.Format("INSERT INTO dbpuma.detalle_compra (nombreProducto, idCategoria, precioProducto, cantidadProducto, idencabezado) value('{0}','{1}','{2}','{3}','{4}')", NombreProducto, IDCategoria, PrecioProducto, CantidadProducto, IDEncabezado)))
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
