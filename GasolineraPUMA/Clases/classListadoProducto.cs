using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace GasolineraPUMA.Clases
{
    class classListadoProducto
    {
        private List<classProducto> productos;
        private Conexion conexion;
        private DataTable tabla;

        public classListadoProducto()
        {
            productos = new List<classProducto>();
            conexion = new Conexion();
            tabla = new DataTable();
        }

        //Constructores

        public List<classProducto> ListadoProductos
        {
            get { return ListadoProductos; }
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
