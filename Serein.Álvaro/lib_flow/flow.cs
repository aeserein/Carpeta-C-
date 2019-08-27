using System;

namespace lib_flow {

    public class ValidarRespuesta {

        public static bool ValidaS_N(char c) {
            c = char.ToUpper(c);
            return (c == 'S');
        }

    }
}
