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
        }
        #endregion

        #region Métodos
        static public bool Insertar(Paquete p) {

            try {
                PaqueteDAO.comando = new SqlCommand();
                PaqueteDAO.comando.CommandType = System.Data.CommandType.Text;

                    PaqueteDAO.comando.CommandText = "INSERT INTO Paquetes VALUES('" + p.DireccionEntrega + "','" + p.TrackingID + "','Serein Álvaro')";
			        //sqlCommand = new SqlCommand("INSERT INTO dbo.Paquetes (direccionEntrega, trackingID, alumno) VALUES ('" + p.DireccionEntrega + "','" + p.TrackingID + "','" + "Ducau Arley" + "')", sqlConnection);

                PaqueteDAO.comando.Connection = PaqueteDAO.conexion;

                PaqueteDAO.conexion.Open();
                PaqueteDAO.comando.ExecuteNonQuery();
                PaqueteDAO.conexion.Close();
                return true;
            } catch (Exception e) {
                throw e;
            }
        }
        #endregion
    }
}
