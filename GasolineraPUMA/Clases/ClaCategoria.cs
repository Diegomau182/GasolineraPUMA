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
    class ClaCategoria
    {
        /// <summary>
        /// Variables a utilizar dentro de la clase
        /// </summary>
        private int idCategoria;
        private string nombre;
        private string descripcion;
        private Conexion conexion;
        private MySqlException error;

        /// <summary>
        /// Constructor de la clase con valores por defecto
        /// </summary>
        public ClaCategoria()
        {
            idCategoria = 0;
            nombre = string.Empty;
            descripcion = string.Empty;
            conexion = new Conexion();
        }

        /// <summary>
        /// Constructor con la asignacion de valores a las variables
        /// </summary>
        public ClaCategoria(string n, string d)
        {
            idCategoria = 0;
            nombre = n;
            descripcion = d;
            conexion = new Conexion();
        }

        /// <summary>
        /// Propiedades de las variables a utilizar
        /// </summary>
        public int IdCategoria
        {
            get { return idCategoria; }
            set { idCategoria = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        /// <summary>
        /// Metodo para realizar la insercion de una nueva categoria a la base de datos
        /// </summary>
        public Boolean Guardar()
        {
            if (conexion.Ejecutar(string.Format("INSERT INTO categoria (nombreCategoria, descripcionCategoria) value('{0}','{1}')", Nombre, Descripcion)))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Metodo para eliminar una categoria de la base de datos
        /// </summary>
        public Boolean Eliminar()
        {
            if (conexion.Ejecutar(string.Format("Update producto Set Habilitado = 0  WHERE idcategoria={0}", IdCategoria)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Metodo para Modificar una categoria de la base de datos
        /// </summary>
        public Boolean ModificarCategoria()
        {
            if (conexion.Ejecutar(string.Format("UPDATE dbPuma.categoria SET nombreCategoria='{0}', descripcionCategoria='{1}'  WHERE idCategoria={2}", Nombre, Descripcion, IdCategoria)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Metodos para verificar la existencia de una categoria tanto por su id
        /// (idCategoriria) como por su nombre (nombreCategoria)
        /// </summary>
        public Boolean BuscarIdCategoria(string id)
        {
            DataTable t1 = conexion.consulta(string.Format("SELECT idCategoria, nombreCategoria, descripcionCategoria FROM dbPuma.categoria where idCategoria= '{0}'", id));
            if (t1.Rows.Count > 0)
            {
                IdCategoria = Convert.ToInt32(t1.Rows[0][0].ToString());
                Nombre = t1.Rows[0][1].ToString();
                Descripcion = t1.Rows[0][2].ToString();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean BuscarCategoria(string ca)
        {
            DataTable t1 = conexion.consulta(string.Format("SELECT idCategoria, nombreCategoria, descripcionCategoria FROM dbPuma.categoria where nombreCategoria = '{0}'", ca));
            if (t1.Rows.Count > 0)
            {
                IdCategoria = Convert.ToInt32(t1.Rows[0][0].ToString());
                Nombre = t1.Rows[0][1].ToString();
                Descripcion = t1.Rows[0][2].ToString();
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
