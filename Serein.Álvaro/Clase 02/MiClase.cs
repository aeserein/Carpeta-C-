using System;
using System.Collections.Generic;
using System.Text;

namespace Clase_02 {

    class MiClase {

        public static string nombre;
        public static int edad;

        public static void MostrarEdad() {
            Console.WriteLine("Método MostrarEdad:\nEdad: {0}", MiClase.edad);
        }

        public static string RetornarNombre() {
            return MiClase.nombre;
        }

        public static bool CompararNombres (string nombre) {
            return (MiClase.nombre == nombre);
        }

    }

}
