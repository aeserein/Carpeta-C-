using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloParcial2.Entidades {

    class PatenteInvalidaException : Exception {

        public PatenteInvalidaException(string mensaje)
            : base(mensaje) {

        }
        public PatenteInvalidaException(string mensaje, Exception innerException)
            : base(mensaje, innerException) {
        }
    }
}
