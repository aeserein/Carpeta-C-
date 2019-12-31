using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ENTIDADES.SP {

    public class MANEJADOR_DE_EVENTO {

        public void FUNCION_DE_MANEJADOR(double UNA_VARIABLE) {

            StreamWriter streamWriter = null;

            try {
                streamWriter = new StreamWriter("UN PATH", false);

                streamWriter.WriteLine("ALGO PARA IMPRIMIR EN EL ARCHIVO");
                streamWriter.WriteLine("LA VARIABLE A IMPRIMIR: " + UNA_VARIABLE);
            } catch { } finally {
                streamWriter.Close();
            }
        }
    }
}
