using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace GasolineraPUMA.Clases
{
    class listaProveedores
    {
        private List<proveedor> proveedores;
        private Conexion conexion;
        private DataTable tabla;

        public listaProveedores()
        {
            proveedores = new List<proveedor>();
            conexion = new Conexion();
            tabla = new DataTable();
        }



        public List<proveedor> ListaProveedores
        {
            get
            {
                return ListaProveedores;
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
