using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace Entidades {

    public static class PaqueteDAO {

        static private SqlCommand comando;
        static private SqlConnection conexion;

        #region Constructores
        /// <summary>
        /// Inicializa la conexión y el comando SQL.
        /// </summary>
        static PaqueteDAO() {
            PaqueteDAO.conexion = new SqlConnection(Properties.Settings.Default.ConexiónSQL);
            PaqueteDAO.comando = new SqlCommand();            
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Guarda la instancia de Paquete en la base de datos.
        /// </summary>
        /// <param name="p">Una instancia de Paquete</param>
        /// <returns>Verdadero, si pudo guardarlo.</returns>
        static public bool Insertar(Paquete p) {
            try {
                PaqueteDAO.comando.CommandType = System.Data.CommandType.Text;
                PaqueteDAO.comando.CommandText = string.Format("INSERT INTO Paquetes (direccionEntrega, trackingID, alumno) VALUES('{0}','{1}','{2}')",
                                                               p.DireccionEntrega,
                                                               p.TrackingID,
                                                               "Serein Álvaro Enuel");
                PaqueteDAO.comando.Connection = PaqueteDAO.conexion;

                PaqueteDAO.conexion.Open();
                PaqueteDAO.comando.ExecuteNonQuery();                
                return true;
            } catch (Exception) {
                throw new Exception("No se pudo subir la lista a la base de datos.");
            } finally {
                PaqueteDAO.conexion.Close();
            }
        }
        #endregion
    }
}
