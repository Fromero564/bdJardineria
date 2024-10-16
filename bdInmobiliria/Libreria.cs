using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bdInmobiliria
{
    public  class Libreria
    {

        public static void Ejecutar(string sql)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString= ConfigurationManager.ConnectionStrings["miBase"].ConnectionString;
            conn.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conn;
            comando.CommandType = CommandType.Text;
            comando.CommandText = sql;
            comando.ExecuteNonQuery();
           conn.Close();
        }

        public static DataTable Recuperar(string sql)
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = ConfigurationManager.ConnectionStrings["mibase"].ConnectionString;
            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = sql;
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());

            return tabla;
        }



    }
}
