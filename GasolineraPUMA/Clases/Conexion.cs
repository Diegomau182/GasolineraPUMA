using MySql.Data.MySqlClient;
using System;
using System.Data;

    class Conexion
    {
        private MySqlConnection conexion;
        //Establecimiento de la conexion
        private string BD;
        private string usuario;
        private string pass;
        private string servidor;

        //Contructor
        public Conexion()
        {
            conexion = new MySqlConnection();
            BD = "dbpuma";
            usuario = "root";
            pass = "";
            servidor = "127.0.0.1";
            conexion = new MySqlConnection();
        }

        public Conexion(string b, string se, string u, string p)
        {
            BD = b;
            servidor = se;
            usuario = u;
            pass = p;
            conexion = new MySqlConnection();
        }
        
        public void Establecerconexion()
        {
            try
            {
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.ConnectionString = string.Format("Database = {0}; Server = {1} ; Uid = {2};Pwd = {3};SslMode = none ", BD, servidor, usuario, pass);
                conexion.Open();

            }
            else
            {
                conexion.Close();
                conexion.ConnectionString = string.Format("Database = {0}; Server = {1} ; Uid = {2};Pwd = {3};SslMode = none ", BD, servidor, usuario, pass);
                conexion.Open();

            }

            }
            catch (MySqlException e)
            {
                System.Windows.Forms.MessageBox.Show(string.Format("Error: {0}", e.ToString()));

            }
        }
        public DataTable consulta(string sql)
        {
            Establecerconexion();
            DataTable t = new DataTable();
            MySqlCommand comando = conexion.CreateCommand();
            MySqlDataAdapter adaptador = new MySqlDataAdapter();
            comando.Connection = conexion;
            comando.CommandText = sql;
            adaptador.SelectCommand = comando;
            adaptador.Fill(t);
            return t;
        }
        public Boolean Ejecutar(string sql)
        {
        //Boolean r = false;

            Establecerconexion();
            MySqlCommand comando = conexion.CreateCommand();
            comando.Connection = conexion;
            comando.CommandText = sql;
            comando.ExecuteNonQuery();
            return true;
        }

    }

