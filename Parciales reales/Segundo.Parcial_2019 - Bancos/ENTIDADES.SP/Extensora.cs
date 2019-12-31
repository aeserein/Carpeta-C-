using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;

namespace ENTIDADES.SP {

    public static class Extensora {

        public static string MostrarBD(this Producto producto) {

            try {
                SqlCommand comando = new SqlCommand("SELECT * FROM productos");
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.ConexiónSQL);
                comando.Connection = conexion;

                conexion.Open();

                SqlDataReader sqlDataReader = comando.ExecuteReader();
                StringBuilder sb = new StringBuilder();

                while (sqlDataReader.Read()) {                    
                    sb.AppendLine(string.Format("Nombre: {0} - Stock: {1}",
                                                 sqlDataReader["nombre"].ToString(), sqlDataReader["stock"].ToString()));
                }

                conexion.Close();
                return sb.ToString();

            } catch (Exception e) {

                return "Error";
            }
        }
    }
}
