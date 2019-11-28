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
        static PaqueteDAO() {
            PaqueteDAO.conexion = new SqlConnection(Properties.Settings.Default.ConexiónSQL);
            PaqueteDAO.comando = new SqlCommand();
            
        }
        #endregion

        #region Métodos
        static public bool Insertar(Paquete p) {

            try {
                PaqueteDAO.comando.CommandType = System.Data.CommandType.Text;
                PaqueteDAO.comando.CommandText = string.Format("INSERT INTO Paquetes VALUES('{0}','{1}','{2}')",
                                                               p.DireccionEntrega,
                                                               p.TrackingID,
                                                               "Serein Álvaro Enuel");
                PaqueteDAO.comando.Connection = PaqueteDAO.conexion;

                PaqueteDAO.conexion.Open();
                PaqueteDAO.comando.ExecuteNonQuery();                
                return true;
            } catch (Exception e) {
                throw e;
            } finally {
                PaqueteDAO.conexion.Close();
            }
        }
        #endregion
    }
}
