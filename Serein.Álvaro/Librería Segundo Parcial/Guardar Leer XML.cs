using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Librerías para serializar
using System.Xml.Serialization;
using System.IO;

namespace Librería_Segundo_Parcial {

    public class Serializar<T> : IInterfaz_de_Guardar_Leer<T> {


        public void Guardar(string archivo, T datos) {

            XmlSerializer xmlSerializer;
            StreamWriter streamWriter = null;

            try {
                xmlSerializer = new XmlSerializer(typeof(T));

                // Verificar 
                // Verificar de dónde se va a leer
                streamWriter = new StreamWriter(archivo);

                xmlSerializer.Serialize(streamWriter, datos);

                streamWriter.Close();

            } catch (Exception) {

                // Verificar qué hay que hacer por consigna
                throw;

            }
        }

        public void Leer(string archivo, out T datos) {

            XmlSerializer xmlSerializer;
            StreamReader streamReader = null;

            // Creo auxiliar de out T datos

            try {
                xmlSerializer = new XmlSerializer(typeof(T));

                // Verificar 
                // Verificar de dónde se va a leer
                streamReader = new StreamReader(archivo);

                // Leo a aux y casteo
                // aux = (T) xmlSerializer.Deserialize(streamReader);

                // Me fijo si hay que hacer algo

                streamReader.Close();

                // Asigno el auxiliar a out datos
                // aux = datos
                // Borrar línea de abajo que está para que no salte el compilador
                datos = default(T);

            } catch (Exception) {

                // Verificar qué hay que hacer por consigna
                throw;

            }
        }
    }
}
