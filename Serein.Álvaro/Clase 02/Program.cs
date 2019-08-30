using System;

using Clase_02.Entidades;

namespace Clase_02 {

    class Program {

        static void Main(string[] args) {

            string unString, otroString, tercerString;

            MiClase.nombre = "Cacho";
            MiClase.edad = 420;
            MiClase.MostrarEdad();

            unString = MiClase.RetornarNombre();
            Console.WriteLine("\n----------------------------------\n{0}, {1}\n", unString, MiClase.edad);

            if (MiClase.CompararNombres(unString)) {
                Console.WriteLine("Nombres iguales");
            } else {
                Console.WriteLine("Nombres diferentes");
            }

            Console.WriteLine("\nCambio de nombre");
            unString = "Ricardo Rubén";

            if (MiClase.CompararNombres(unString)) {
                Console.WriteLine("Nombres iguales");
            }
            else {
                Console.WriteLine("Nombres diferentes");
            }

            Console.WriteLine("\n----------------------------------\nNombre desde librería");
            //MiLibrería.MiClase.nombre = "El Donaldo";
            //otroString = MiLibrería.MiClase.MostrarNombre();
            //Console.WriteLine(otroString);

            Console.WriteLine("\n----------------------------------\nNombre desde otra libreria con 'using'");
            Sello.mensaje = "Mensaje";
            tercerString = Sello.Imprimir();
            Console.WriteLine(tercerString);
            Sello.Borrar();

            Sello.mensaje = "Asd (va a color)";
            Sello.colorFondo = ConsoleColor.Red;
            Sello.colorFondo = ConsoleColor.DarkRed;
            Sello.ImprimirEnColor();
            Console.WriteLine("\n----------------------------------\n{0}", Sello.mensaje);
            Console.Read();
        }
    }

}

/* Clase    ---> "Estados" o "atributos" = Variables
 *          ---> "Comportamientos" o "métodos" = Funciones
 *          
 *          Declarar clase  ---> [modificadores] class Nombre
 *                          ---> Modificadores -> Comportamiento y visibilidad
 *                          ---> Privado por defecto -> "class Nombre"
 *                          
 *          Privado = Solo visible dentro del namespace. Símbolo -
 *          Publico = Visibilidad fuera del namespace y proyecto. Símbolo +
 *                          
 *          Static = Se puede usar sin instanciar la clase
 *          Miembro "de clase" -> static
 *          Miembro "de instancia" -> no static
 *                          
 *          El modificador de visibilidad se escribe siempre,
 *          pero C# no permite poner el "private" redundante dentro de un namespace
 *                          
 *          Nombre de clases    ---> Sustantivo. Siempre primera letra mayúscula
 *  
 *  Variables   ---> [modificadores] tipo Nombre
 *          
 *          Las variables se usan dentro de la clase como "MiClase.nombre" para distinguirlas
 *          a simple vista de las variables locales que no son atributos de la clase
 *  
 *  Métodos     ---> [modificadores] tipo Nombre(args)
 *  
 *          Nombre de métodos   ---> Verbo. Siempre primera letra mayúscula
 * 
 */
