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
            return Sello.ArmarFormatoMensaje();
        }

        public static void ImprimirEnColor() {
            Console.BackgroundColor = colorFondo;
            Console.ForegroundColor = colorLetra;
            Console.WriteLine(Sello.ArmarFormatoMensaje());
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void Borrar() {
            Sello.mensaje = "";
        }

        private static string ArmarFormatoMensaje() {
            short f;
            string mensajeConFormato = "\n";

            for (f=0; f< mensaje.Length+2; f++) {
                mensajeConFormato += "#";
            }
            mensajeConFormato = mensajeConFormato + "\n#" + Sello.mensaje + "#\n";
            for (f = 0; f < mensaje.Length + 2; f++) {
                mensajeConFormato += "#";
            }

            return mensajeConFormato;
        }
    }
}
