using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.SP
{
    public static class Extensora {

        public static string InformarNovedad(this CartucheraLlenaException excepcion) {
            return excepcion.Message;
        }
    }
}
