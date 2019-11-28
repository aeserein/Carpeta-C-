using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades {

    public class TrackingIdRepetidoException : Exception {

        /// <summary>
        /// Crea una excepción de ID repetido.
        /// </summary>
        /// <param name="mensaje">Mensaje a mostrar</param>
        public TrackingIdRepetidoException(string mensaje)
            : base(mensaje) {
        }

        /// <summary>
        /// Crea una excepción de ID repetido.
        /// </summary>
        /// <param name="mensaje">Mensaje a mostrar</param>
        /// <param name="inner">Excepción interna</param>
        public TrackingIdRepetidoException(string mensaje, Exception inner)
            : base(mensaje, inner) {
        }
    }
}