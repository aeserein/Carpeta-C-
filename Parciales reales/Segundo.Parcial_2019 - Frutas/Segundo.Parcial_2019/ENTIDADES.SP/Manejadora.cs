using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace ENTIDADES.SP {

    public class Manejadora {

        public void Manejadora_EventoPrecio(double precio) {

            //la fecha (con hora, minutos y segundos) y el total del precio del cajón en un nuevo renglón.

            StreamWriter streamWriter = null;

            try {
                streamWriter = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\archivo de evento.txt", false);
                
                streamWriter.WriteLine(DateTime.Now.ToString());
                streamWriter.Write("Precio: " + precio);
            }
            catch { }
            finally {
                streamWriter.Close();
            }
        }
    }
}
