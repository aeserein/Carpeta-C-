using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Entidades {

    public static class GuardaString {

        /// <summary>
        /// Guarda el texto en un archivo en el escritorio.
        /// </summary>
        /// <param name="texto">Texto a guardar</param>
        /// <param name="archivo">Nombre del archivo</param>
        /// <returns>Verdadero si pudo guardarlo, falso si no pudo.</returns>
        public static bool Guardar(this string texto, string archivo) {
            StreamWriter streamWriter = null;
            try {
                streamWriter = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + archivo, true);
                streamWriter.WriteLine(texto);                
                return true;
            } catch (Exception) {
                return false;
            } finally {
                streamWriter.Close();
            }     
        }
    }
}
