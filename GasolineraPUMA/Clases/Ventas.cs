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
        private float precio;
        private float subTotal;
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
        public float Subtotal
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
        public float Precio
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

        public Boolean guardarventa()
        {
            if (conexion.Ejecutar(string.Format("INSERT INTO `encabezadoventa`(`idEncabezadoVenta`, `cliente`) Values ('{0}','{1}')", IdFactura, Nombre)))
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