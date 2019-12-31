using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENTIDADES.SP {

    public class EXCEPCIÓN_PROPIA : Exception {

        public EXCEPCIÓN_PROPIA(string message) : base(message) {
        }
    }
}
