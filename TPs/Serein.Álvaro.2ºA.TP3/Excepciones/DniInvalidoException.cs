using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones {

    public class DniInvalidoException : Exception {

        private string mensajeBase;

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        public DniInvalidoException() {
            this.mensajeBase = "Error: Formato de DNI inválido.";
        }
        public DniInvalidoException(Exception e)
            : this() {
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        public DniInvalidoException(string message)
            : base(message) {
        }
        public DniInvalidoException(string message, Exception e)
            : base(message, e) {
        }
    }
}
