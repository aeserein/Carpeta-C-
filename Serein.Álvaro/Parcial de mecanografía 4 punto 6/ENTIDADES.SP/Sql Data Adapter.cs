using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace Librería_Segundo_Parcial {

    class Sql_Data_Adapter {

        private SqlDataAdapter sqlDataAdapter;
        private SqlConnection conexion;
        private DataTable dataTable;

        public Sql_Data_Adapter() {

            #region SELECT y sqlDataAdapter.Fill
            SqlCommand comandoSelect = new SqlCommand();
            comandoSelect.Connection = conexion;
            comandoSelect.CommandType = CommandType.Text;
            comandoSelect.CommandText = "SELECT * FROM Persona";
            sqlDataAdapter = new SqlDataAdapter(comandoSelect.CommandText, this.conexion);
            sqlDataAdapter.Fill(this.dataTable);
            //El data adapter abre y cierra la conexión con Fill(dataTable);
            #endregion

            #region INSERT
            SqlCommand comandoInsert = new SqlCommand();
            comandoInsert.CommandType = CommandType.Text;
            comandoInsert.CommandText = "INSERT INTO Persona VALUES(@arg1,@arg2,@arg3)";
            comandoInsert.Connection = conexion;
            sqlDataAdapter.InsertCommand = comandoInsert;
            sqlDataAdapter.InsertCommand.Parameters.Add("@arg1", SqlDbType.VarChar, 50, "nombre");
            sqlDataAdapter.InsertCommand.Parameters.Add("@arg2", SqlDbType.VarChar, 50, "apellido");
            sqlDataAdapter.InsertCommand.Parameters.Add("@arg3", SqlDbType.Int, 10, "edad");
            #endregion

            #region UPDATE
            SqlCommand comandoUpdate = new SqlCommand();
            comandoUpdate.CommandType = CommandType.Text;
            comandoUpdate.CommandText = "UPDATE Persona SET nombre = @arg1, apellido = @arg2, edad = @arg3 WHERE id = @arg0";
            comandoUpdate.Connection = conexion;
            sqlDataAdapter.UpdateCommand = comandoUpdate;
            sqlDataAdapter.UpdateCommand.Parameters.Add("@arg1", SqlDbType.VarChar, 50, "nombre");
            sqlDataAdapter.UpdateCommand.Parameters.Add("@arg2", SqlDbType.VarChar, 50, "apellido");
            sqlDataAdapter.UpdateCommand.Parameters.Add("@arg3", SqlDbType.Int, 10, "edad");
            sqlDataAdapter.UpdateCommand.Parameters.Add("@arg0", SqlDbType.Int, 10, "id");
            #endregion

            #region DELETE
            SqlCommand comandoDelete = new SqlCommand();
            comandoDelete.CommandType = CommandType.Text;
            comandoDelete.CommandText = "DELETE FROM Persona WHERE id = @arg0";
            comandoDelete.Connection = conexion;
            sqlDataAdapter.DeleteCommand = comandoDelete;
            sqlDataAdapter.DeleteCommand.Parameters.Add("@arg0", SqlDbType.Int, 10, "id");
            #endregion

            // 1º parámetro: Los "argX" deben coincidir con los parámetros del comando sql
            // 2º parámetro: Tipo de variable
            // 3º parámetro: longitud para visualizarse (?)
            // 4º parámetro: nombre de la variable en la base de datos

            /*
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            dataTable.Load(sqlDataReader);
            sqlDataReader.Close();
            */

            /*  Otra forma más simple de hacerlo
            sqlDataAdapter.InsertCommand = new SqlCommand("INSERT INTO Persona VALUES(@arg1,@arg2,@arg3)", sqlConnection);
            sqlDataAdapter.UpdateCommand = new SqlCommand("UPDATE Persona SET nombre = @arg1, apellido = @arg2, edad = @arg3 WHERE id = @arg0", sqlConnection);
            sqlDataAdapter.DeleteCommand = new SqlCommand("DELETE FROM Persona WHERE id = @arg0", sqlConnection);
            */
        }
    }
}
