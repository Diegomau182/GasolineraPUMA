using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace GasolineraPUMA.Clases
{
    class proveedor
    {
        private string rtn_proveedor;
        private string empresa_proveedor;
        private string nombre_proveedor;
        private string apellido_proveedor;
        private string email_proveedor;
        private string telefono_proveedor;
        private int habilitado;
        private Conexion conexion;
        private DataTable tabla;



        //Constructores
        public proveedor()
        {
            rtn_proveedor = "";
            empresa_proveedor = "";
            nombre_proveedor = "";
            apellido_proveedor = "";
            email_proveedor = "";
            telefono_proveedor = "";
            habilitado = 1;
            conexion = new Conexion();
        }
        public proveedor(string r, string e, string n, string a, string c, string t, int h)
        {
            rtn_proveedor = r;
            empresa_proveedor = e;
            nombre_proveedor = n;
            apellido_proveedor = a;
            email_proveedor = c;
            telefono_proveedor = t;
            habilitado = h;
            conexion = new Conexion();
        }

        public string RtnProveedor
        {
            get
            {
                return rtn_proveedor;
            }
            set
            {
                rtn_proveedor = value;
            }
        }
        public string EmpresaProveedor
        {
            get
            {
                return empresa_proveedor;
            }
            set
            {
                empresa_proveedor = value;
            }
        }
        public string NombreProveedor
        {
            get
            {
                return nombre_proveedor;
            }
            set
            {
                nombre_proveedor = value;
            }
        }
        public string ApellidoProveedor
        {
            get
            {
                return apellido_proveedor;
            }
            set
            {
                apellido_proveedor = value;
            }
        }
        public string EmalProveedor
        {
            get
            {
                return email_proveedor;
            }
            set
            {
                email_proveedor = value;
            }
        }
        public string TelefonoProveedor
        {
            get
            {
                return telefono_proveedor;
            }
            set
            {
                telefono_proveedor = value;
            }
        }
        public int Habilitado
        {
            get
            {
                return habilitado;
            }
            set
            {
                habilitado = value;
            }
        }
        public DataTable Tabla
        {
            get { return tabla; }
        }
        public Boolean GuardarProveedor()

        {
            Boolean r = false;

            r = conexion.Ejecutar(string.Format("INSERT INTO proveedor (RTNProveedor,empresaProveedor,nombreProveedor,apellidoProveedor,emailProveedor,telefonoProveedor,habilitado) " +
                "VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}');", RtnProveedor, EmpresaProveedor, NombreProveedor, ApellidoProveedor, EmalProveedor, TelefonoProveedor, Habilitado));

            return r;
        }
        public Boolean ModificarProveedor()
        {
            Boolean r = false;

            r = conexion.Ejecutar(string.Format("UPDATE proveedor SET RTNProveedor = '{0}', empresaProveedor = '{1}' ,nombreProveedor = '{2}'" +
                " ,apellidoProveedor = '{3}' ,emailProveedor = '{4}' ,telefonoProveedor = '{5}'  WHERE RTNProveedor = '{0}'",
                RtnProveedor, EmpresaProveedor, NombreProveedor, ApellidoProveedor, EmalProveedor, TelefonoProveedor));
            return r;
        }

       
        public Boolean EliminarProveedor()
        {
            Boolean r = false;

            r = conexion.Ejecutar(string.Format("UPDATE proveedor SET  habilitado = 0  WHERE RTNProveedor = '{0}'",RtnProveedor));
            return r;
        }

       
    }
}
