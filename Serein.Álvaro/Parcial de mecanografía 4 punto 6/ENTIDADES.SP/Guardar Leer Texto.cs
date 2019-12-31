using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Librerías para guardar y leer texto
using System.IO;

namespace Librería_Segundo_Parcial {

    class Guardar_Leer_Texto<T> : IInterfaz_de_Guardar_Leer<T> {

        public void Guardar(string archivo, T datos) {

            StreamWriter streamWriter = null;

            try {
                // Verificar ruta
                // Verificar append
                streamWriter = new StreamWriter(archivo, false);

                // Si es una lista entera
                streamWriter.Write(datos.ToString());

                /* Si es archivo por archivo
                
                foreach (Cosa c in datos) {
                    streamWriter.WriteLine(c.ToString());
                }
                */
            } catch (Exception) {
                //Verificar qué hay que hacer acá por consigna
                throw;
            } finally {
                streamWriter.Close();
                // Verificar si hay que hacer algo más por consigna
            }
        }

        public void Leer(string archivo, out T datos) {

            StreamReader streamReader = null;

            // Crear auxiliar de out T datos

            try {
                string sAux;

                // Verificar ruta
                streamReader = new StreamReader(archivo);

                while (!streamReader.EndOfStream) {
                    sAux = streamReader.ReadLine();

                    // Crear el objeto a partir de aux
                    // Parsear según formato, según cómo haya pedido
                }

                // Pasar el auxiliar de datos a datos
                // datos = auxiliar de out T datos;
                // Borrar la línea de abajo que solo está para que no salte el compilador
                datos = default(T);

            } catch (Exception) {
                //Verificar qué hay que hacer acá por consigna
                throw;
            } finally {
                streamReader.Close();
                // Verificar si hay que hacer algo más por consigna
            }
        }
    }
}
