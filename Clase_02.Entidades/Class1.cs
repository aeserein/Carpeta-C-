using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_02.Entidades {

    public class Sello {

        public static string mensaje;
        public static ConsoleColor colorFondo, colorLetra;

        public static string Imprimir() {
            return Sello.mensaje;
        }

        public static void ImprimirEnColor() {
            Console.BackgroundColor = colorFondo;
            Console.ForegroundColor = colorLetra;
            Console.WriteLine(Sello.mensaje);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void Borrar() {
            Sello.mensaje = "";
        }

    }
}
