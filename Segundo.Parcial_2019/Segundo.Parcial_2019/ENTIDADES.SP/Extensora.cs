using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace ENTIDADES.SP
{
    public static class Extensora {

        //Agregar un método de extensión a la clase Cajon que:
        //Reciba como parámetro un entero (será usado como valor del campo ID)
        //Elimine de la base de datos la fruta cuyo ID coincida con el parámetro recibido
        //Retorne un booleano que indique: 
        //TRUE, si se ha eliminado la fruta. 
        //FALSE, si no se elimino.
        //Excepción, si se probocó algún error en la base de datos

        public static bool EliminarFruta(this Cajon<Manzana> cajon, int id) {
            SqlConnection conexion;
            SqlCommand comando;

            try {
                conexion = new SqlConnection(Properties.Settings.Default.ConexiónSQL);
                comando = new SqlCommand("DELETE FROM frutas WHERE id = " + id);
                comando.CommandType = System.Data.CommandType.Text;
                comando.Connection = conexion;
                conexion.Open();
                comando.ExecuteNonQuery();
                return true;
            } catch (Exception e) {
                throw;
            }
        }

    }
}
