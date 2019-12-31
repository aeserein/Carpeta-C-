using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Librería para SqlConnection y SqlCommand
using System.Data.SqlClient;

namespace Librería_Segundo_Parcial {

    // Verificar uso de genéricas
    public class SQL<T> : IInterfaz_de_Guardar_Leer<T> {

        private SqlConnection conexion;
        private SqlCommand comando;

        public SQL() {
            // Completar con connectionString seteado
            //                                Properties.Settings.Default.-----
            this.conexion = new SqlConnection(Properties.Settings.Default.ConexiónSQL);

            this.comando.CommandType = System.Data.CommandType.Text;
            this.comando.Connection = this.conexion;
        }


        public void Guardar(string tabla, T datos) {

            try {
                this.conexion.Open();

                /* Ciclo foreach para subir cada elemento, en caso de que datos sea una lista
                
                foreach (Cosa c in datos) {
                    // Verificar formato de tabla para insentar bien los valores
                    string consulta = string.Format("INSERT INTO {0} VALUES('{1}', '{2}')",
                                                    tabla,
                                                    valor1.ToString(),
                                                    valor2.ToString());
                    this.comando.CommandText = consulta;
                    this.comando.ExecuteNonQuery();
                }
                */
                this.conexion.Close();

            } catch (Exception e) {

                // Verificar qué hay que hacer por consigna
                throw;

            } finally {

                

                // Verifico si hay que hacer algo más por consigna
            }
        }
        public void Leer(string tabla, out T datos) {

            // Verificar qué hay que seleccionar de la tabla
            string consulta = string.Format("SELECT * FROM {0}", tabla);
            this.comando.CommandText = consulta;

            // Si el parámetro es out y es una lista, crear lista auxiliar acá

            try {
                this.conexion.Open();

                // Creo SqlDataReader y lo corro
                // Lo creo afuera para cerrarlo en el finally
                SqlDataReader sqlDataReader = null;
                sqlDataReader = this.comando.ExecuteReader();


                while (sqlDataReader.Read()) {
                    // Creo auxiliar del tipo de dato T
                    // Crear clase que se va a usar acá previamente para saber qué poner en el constructor
                    // T t = new T();

                    // Hago lo que haya que hacer con el objeto
                    // Sumar a una lista, verificar algo, etc
                }

                this.conexion.Close();

                // Pasar la lista auxiliar al out datos acá
                // datos = aux
                // Borrar la línea de abajo, solo está para que no sale el compilador
                datos = default(T);

            } catch (Exception e) {

                // Verificar qué hay que hacer por consigna
                throw;

            }        
        }
        public void Borrar(string tabla, int id) {
            try {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.ConexiónSQL);
                SqlCommand comando;
                comando.CommandType = System.Data.CommandType.Text;
                comando.Connection = conexion;
                comando.CommandText = string.Format("DELETE FROM {0} WHERE -------id?------- = {1}",
                                                    tabla,
                                                    id);
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
            } catch (Exception e) {
                throw
            }
        }

    }
}