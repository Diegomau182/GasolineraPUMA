using System;
using System.Collections.Generic;
using System.Data;

namespace GasolineraPUMA.Clases
{
    class TablaVentas
    {
        private List<Ventas> ventas;
        private Conexion conexion;
        private DataTable tabla;
        public TablaVentas()
        {
            ventas = new List<Ventas>();
            conexion = new Conexion();
            tabla = new DataTable();
        }
        public List<Ventas> Lista_Venta
        {
            get
            {
                return Lista_Venta;
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
