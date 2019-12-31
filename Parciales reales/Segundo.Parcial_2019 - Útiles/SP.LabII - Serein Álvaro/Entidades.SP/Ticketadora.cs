using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace Entidades.SP
{
    public static class Ticketeadora
    {
        public static bool ImprimirTicket(double precio)
        {

            StreamWriter streamWriter = null;

            try
            {
                streamWriter = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\tickets.log", true);

                streamWriter.WriteLine(DateTime.Now.ToString());
                streamWriter.WriteLine("Precio: " + precio);
                streamWriter.Close();
                return true;
            } 
            catch {
                return false;
            }
        }
    }
}
