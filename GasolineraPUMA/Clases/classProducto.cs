﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data;

namespace GasolineraPUMA.Clases
{
    class classProducto
    {
        //LLamado de las variables segun la catidad en la tabla
        private int id_Producto;
        private int id_Categoria;
        private int id_Proveedor;
        private string nombre_Producto;
        private string descripcion_Producto;
        private decimal precio_Producto;
        private int cantidad_Producto;
        private Conexion conexion;
        private DataTable tabla;


        //constructores 
        public classProducto()
        {
            id_Producto = 0;
            id_Categoria = 0;
            id_Proveedor =  0;
            nombre_Producto = "";
            descripcion_Producto = "";
            precio_Producto = 0;
            cantidad_Producto = 0;
            conexion = new Conexion();
        }

        public classProducto(decimal py, string nom, string mar, string ex) {
            id_Producto = 0;
            id_Categoria = 0;
            id_Proveedor = 0;
            precio_Producto = 0;
            conexion = new Conexion();
        }

        public int idProducto
        {
            get { return id_Producto; }
            set { id_Producto = value; }
        }

        public int idCategoria
        {
            get { return id_Categoria; }
            set { id_Categoria = value; }
        }
        public int idProveedor
        {
            get { return id_Proveedor; }
            set { id_Proveedor = value; }
        }
        public string nombreProducto
        {
            get { return nombre_Producto; }
            set { nombre_Producto = value; }
        }
        public string descripcionProducto
        {
            get { return descripcion_Producto; }
            set { descripcion_Producto = value; }
        }
        public decimal precionPrducto
        {
            get { return precio_Producto; }
            set { precio_Producto = value; }
        }
        public int cantidadProducto
        {
            get { return cantidad_Producto; }
            set { cantidad_Producto = value; }
        }
        public DataTable Tabla
        {
            get { return tabla; }
        }


        //QUERYS DE GUARDAR,INSERTAR, MODIFICAR Y ELIMINAR
        //GUARDAR

        public Boolean GuardarProducto()
        {
            Boolean dataQuery = false;
            dataQuery = conexion.Ejecutar(string.Format("INSERT INTO producto (nombreProducto,descripcionProducto,idCategoria,idProveedor,precioProducto,cantidadProducto) VALUES({0},{1},{2},{3},{4},{5}) ",nombre_Producto,descripcion_Producto,id_Categoria,id_Proveedor,precio_Producto,cantidad_Producto));
            return dataQuery;
        }


        public Boolean ModificarProducto()
        {
            Boolean dataQuery = false;
            dataQuery = conexion.Ejecutar(string.Format("UPDATE producto SET nombreProducto = {0}, descripcionProducto = {1}, idCategoria = {2}, idProveedor = {3}, precioProducto = {4}, cantidadProducto = {5} WHERE idProducto = {6}",nombreProducto,descripcionProducto,idCategoria,idProveedor,precionPrducto,cantidadProducto,idProducto));
            return dataQuery;
        }

        public Boolean EliminarProducto()
        {
            Boolean dataQuery = false;
            dataQuery = conexion.Ejecutar(string.Format("DELETE FROM producto WHERE idProducto = {0};",idProducto));
            return dataQuery;
        }
    }
}
