using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using ModeloParcial2.Entidades;

namespace ModeloParcial2.Archivo {

    public class Sql : IArchivo<Queue<Patente>> {

        private SqlConnection conexion;
        private SqlCommand comando;

        public Sql() {

            //this.conexion = new SqlConnection(Properties.Settings.Default.-------CONEXION------);
            this.conexion = new SqlConnection("ConnectionString");

            this.comando.Connection = this.conexion;
            this.comando.CommandType = System.Data.CommandType.Text;
        }

        public void Guardar(string tabla, Queue<Patente> datos) {
            try {
                this.conexion.Open();
                foreach (Patente patente in datos) {
                    string consulta = string.Format("INSERT INTO {0} VALUES('{1}','{2}')",
                                                    tabla,
                                                    patente.CodigoPatente,
                                                    patente.TipoCodigo.ToString());
                    this.comando.CommandText = consulta;
                    this.comando.ExecuteNonQuery();
                }

            } catch (Exception e) {

                throw;

            } finally {

                this.conexion.Close();

            }
        }

        public void Leer(string tabla, out Queue<Patente> datos) {
            try {
                string consulta = string.Format("SELECT * FROM {0}", tabla);
                this.comando.CommandText = consulta;
                this.conexion.Open();
                SqlDataReader sqlDataReader = comando.ExecuteReader();
                Queue<Patente> aux = new Queue<Patente>();

                while (sqlDataReader.Read()) {
                    Patente patente = new Patente(sqlDataReader["patente"].ToString(), (Patente.Tipo)sqlDataReader["tipo"]);
                    aux.Enqueue(patente);
                }
                datos = aux;

            } catch (Exception e) {

                throw;

            } finally {

                this.conexion.Close();

            }

        }
    }
}
