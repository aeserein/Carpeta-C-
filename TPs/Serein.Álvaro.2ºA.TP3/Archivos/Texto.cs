using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using Excepciones;

namespace Archivos {

    public class Texto : IArchivo<string> {

        public bool Guardar(string archivo, string datos) {
            try {
                File.WriteAllText(archivo, datos, Encoding.UTF8);
                return true;
            } catch (Exception e) {
                throw new ArchivosException(e);
            }
        }
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
