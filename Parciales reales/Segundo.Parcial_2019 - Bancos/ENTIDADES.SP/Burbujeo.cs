using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace ENTIDADES.SP {

    public class Burbujeo {

        static public void MetodoClase() {
            Burbujeo burbujeo = new Burbujeo();

            try {
                burbujeo.TirarExcepcion();
            } catch (Exception) {
                StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\burbujeo.txt", true);
                sw.WriteLine("Funcion de CLASE MetodoClase:");
                sw.WriteLine(DateTime.Now.ToString());
                sw.Close();
                throw;
            }
            
        }

        public void TirarExcepcion() {
            StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\burbujeo.txt");
            sw.WriteLine("Funcion de INSTANCIA TirarExcepcion:");
            sw.WriteLine(DateTime.Now.ToString());
            sw.Close();
            throw new MiException("Aquí MiException de burbujeo");
        }
    }
}
