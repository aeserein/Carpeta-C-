using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.SP
{
    public class CartucheraLlenaException : Exception {

        public CartucheraLlenaException(string mensaje)
            : base(mensaje) {
        }


    }
}
