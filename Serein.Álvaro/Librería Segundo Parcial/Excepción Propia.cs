using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería_Segundo_Parcial {

    class Excepción_Propia : Exception {

        public Excepción_Propia(string mensaje)
            : base(mensaje) {
        }

        public Excepción_Propia(string mensaje, Exception innerException)
            : base(mensaje, innerException) {
        }
    }
}
