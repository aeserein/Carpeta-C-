using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades.Externa.Sellada;
using System.Data.SqlClient;

namespace Clase_23.Entidades {

    public static class Extensora {

        public static string ObtenerInfo(this PersonaExternaSellada persona) {
            return String.Format("Método extendido: {0} {1}, {2}, {3}\n",
                                 persona.Nombre,
                                 persona.Apellido,
                                 persona.Edad,
                                 persona.Sexo.ToString());
        }

        public static bool EsNulo(this Object obj) {
            return (Object.Equals(obj, null));
        }

        public static List<Persona> ObtenerListadoBD(this Persona persona) {
            List<Persona> lista = new List<Persona>();

            string consulta = "SELECT * FROM persona";
            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.ConexiónSQL);
            SqlCommand sqlCommand = new SqlCommand();

            try
            {
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlCommand.CommandText = consulta;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Persona p = new Persona((string)sqlDataReader["nombre"], (string)sqlDataReader["apellido"], (int)sqlDataReader["edad"]);
                    lista.Add(p);
                }
                sqlConnection.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine("-----------------------------------------------\n" +
                                  e.Message +
                                  "\n-----------------------------------------------");
            }

            return lista;
        }
    }
}
