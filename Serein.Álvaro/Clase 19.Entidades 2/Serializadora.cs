using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_19.Entidades_2 {

    public static class Serializadora {
        
        public static bool Serializar(IXML ixml) {
            return ixml.Guardar("archivo.xml");
        }

        public static bool Deserializar(IXML ixml, out object obj) {
            return ixml.Leer("archivo.xml", out obj);
        }
    }
}
