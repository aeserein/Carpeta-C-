using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;
using System.IO;
using Excepciones;

namespace Archivos {

    public class Xml<T> : IArchivo<T> {

        /// <summary>
        /// Guarda un archivo XML.
        /// </summary>
        /// <param name="archivo">Path al archivo.</param>
        /// <param name="datos">Datos a serializar.</param>
        /// <returns>Verdadero si pudo escribir el archivo.</returns>
        public bool Guardar(string archivo, T datos) {
            try {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                StreamWriter streamWriter = new StreamWriter(archivo);
                xmlSerializer.Serialize(streamWriter, (T)datos);
                streamWriter.Close();
                return true;
            } catch (Exception e) {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// Lee un archivo XML.
        /// </summary>
        /// <param name="archivo">Path al archivo.</param>
        /// <param name="datos">Instancia donde guardar los datos.</param>
        /// <returns>>Verdadero si pudo leer el archivo.</returns>
        public bool Leer(string archivo, out T datos) {
            try {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                StreamReader streamReader = new StreamReader(archivo);
                datos = (T)xmlSerializer.Deserialize(streamReader);
                streamReader.Close();
                return true;
            } catch (Exception e) {
                throw new ArchivosException(e);
            }
        }
    }
}
