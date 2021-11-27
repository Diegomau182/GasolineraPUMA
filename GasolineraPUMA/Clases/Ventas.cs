using System;
using System.Data;

namespace GasolineraPUMA.Clases
{
    class Ventas
    {
        private int idFactura;
        private string nombre;
        private int idProducto;
        private int cantidad;
        private decimal precio;
        private decimal subTotal;
        private decimal total;
        private decimal isv;
        private Conexion conexion;
       
        //Constructor
        public Ventas()
        {
            idFactura = 0;
            nombre = "";
            cantidad = 0;
            idProducto = 0;
            subTotal = 0;
            precio = 0;
            total = 0;
            isv = 0;
            conexion = new Conexion();
        }
      
        public int IdFactura
        {
            get
            {
                return idFactura;
            }
            set
            {
                idFactura = value;
            }

        }
        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }

        }
        public int Cantidades
        {
            get
            {
                return cantidad;
            }
            set
            {
                cantidad = value;
            }
        }
        public int IdProducto
        {
            get
            {
                return idProducto;
            }
            set
            {
                idProducto = value;
            }
        }
        public decimal Subtotal
        {
            get
            {
                return subTotal;
            }
            set
            {
                subTotal = value;
            }
        }
        public decimal Precio
        {
            get
            {
                return precio;
            }
            set
            {
                precio = value;
            }
        }

        public decimal Total
        {
            get
            {
                return total;
            }
            set
            {
                total = value;
            }
        }

        public decimal ISV
        {
            get
            {
                return isv;
            }
            set
            {
                isv = value;
            }
        }
        

        public Boolean guardarventa()
        {
            if (conexion.Ejecutar(string.Format("INSERT INTO `encabezadoventa`(`idEncabezadoVenta`, `cliente`, `isv`, `total`) VALUES ('{0}','{1}','{2}','{3}')", IdFactura, Nombre,ISV,Total)))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public Boolean guardarDetalleVenta()
        {
            if (conexion.Ejecutar(string.Format("INSERT INTO `detalleventa`(`idEncabezadoVenta`, `idProducto`, `cantidad`, `precio`, `subTotal`) VALUES ('{0}','{1}','{2}','{3}','{4}')", IdFactura, IdProducto,Cantidades,Precio,Subtotal)))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}