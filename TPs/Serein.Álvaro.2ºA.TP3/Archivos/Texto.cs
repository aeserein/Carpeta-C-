using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using Excepciones;

namespace Archivos {

    public class Texto : IArchivo<string> {

        /// <summary>
        /// Guarda un archivo de texto.
        /// </summary>
        /// <param name="archivo">Path al archivo.</param>
        /// <param name="datos">Datos a guardar.</param>
        /// <returns>Verdadero si pudo escribir el archivo.</returns>
        public bool Guardar(string archivo, string datos) {
            try {
                File.WriteAllText(archivo, datos, Encoding.UTF8);
                return true;
            } catch (Exception e) {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// Lee un archivo de texto.
        /// </summary>
        /// <param name="archivo">Path al archivo.</param>
        /// <param name="datos">Instancia donde guardar los datos.</param>
        /// <returns>>Verdadero si pudo leer el archivo.</returns>
        public bool Leer(string archivo, out string datos) {
            try {
                datos = File.ReadAllText("Jornada.txt");
                return true;
            } catch (Exception e) {
                throw new ArchivosException(e);
            }
        }
    }
}
