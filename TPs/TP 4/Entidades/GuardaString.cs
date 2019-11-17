using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Entidades {

    public static class GuardaString {

        public static bool Guardar(this string texto, string archivo) {

            //throw new NotImplementedException();
            
            try {
                StreamWriter streamWriter = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + archivo + ".txt", true);
                streamWriter.Write(texto + "\n");
                streamWriter.Close();
                return true;
            } catch {
                return false;
            }
            
        }
    }
}
