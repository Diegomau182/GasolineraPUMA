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
    internal class ClaListaCategorias
    {

        private List<ClaCategoria> categorias;
        private Conexion conexion;

        private DataTable tabla;

        public ClaListaCategorias()
        {
            categorias = new List<ClaCategoria>();
            conexion = new Conexion();
            tabla = new DataTable();
            Cargar_Datos();
        }

        public void Cargar_Datos()
        {
            conexion.Establecerconexion();
            tabla = conexion.consulta(string.Format("SELECT idCategoria, nombreCategoria, descripcionCategoria FROM dbPuma.categoria"));
            foreach (DataRow f in tabla.Rows)
            {
                ClaCategoria C = new ClaCategoria();
                C.IdCategoria = f.Field<int>(0);
                C.Nombre = f.Field<string>(1);
                C.Descripcion = f.Field<string>(2);
                categorias.Add(C);
            }
        }
        public List<ClaCategoria> ListaCategorias
        {
            get
            {
                return ListaCategorias;
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
