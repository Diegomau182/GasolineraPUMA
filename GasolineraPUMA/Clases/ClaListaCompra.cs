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
    class ClaListaCompra
    {

        private List<ClaCompra> compras;
        private Conexion conexion;
        private DataTable tabla;

        public ClaListaCompra()
        {
            compras = new List<ClaCompra>();
            conexion = new Conexion();
            tabla = new DataTable();

            Cargar_Datos();
        }


        public void Cargar_Datos()
        {
            conexion.Establecerconexion();
            tabla = conexion.consulta(string.Format("Select e.idEncabezadoCompra, e.fecha, e.idProveedor, " +
                " d.nombreProducto, d.idCategoria, d.precioProducto, d.cantidadProducto, e.subtotal, e.impuesto, e.total," +
                "d.idencabezado FROM dbpuma.encabezadocompra AS e INNER JOIN dbpuma.detalle_compra AS d ON e.idEncabezadoCompra = d.idencabezado"));

            foreach (DataRow f  in tabla.Rows)
            {
                ClaCompra Cm = new ClaCompra();
                Cm.IDEncabezadoCompra = f.Field<int>(0);
                Cm.Fecha = f.Field<DateTime>(1);
                Cm.IDProveedor = f.Field<string>(2);
                Cm.NombreProducto = f.Field<string>(3);
                Cm.IDCategoria = f.Field<int>(4);
                Cm.PrecioProducto = f.Field<decimal>(5);
                Cm.CantidadProducto = f.Field<int>(6);
                Cm.Subtotal = f.Field<decimal>(7);
                Cm.Impuesto = f.Field<decimal>(8);
                Cm.Total = f.Field<decimal>(9);
                compras.Add(Cm);
            }

        }

        public List<ClaCompra> ListaCompras
        {
            get
            {
                return ListaCompras;
            }
        }
        public DataTable Tabla
        {
            get { return tabla; }
        }
        public DataTable SQL(string sql)
        {
            DataTable t = conexion.consulta(sql);
            return t;
        }
    }
}
