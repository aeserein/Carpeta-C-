using System;

namespace Ejercicio_31 {

    class Program {

        static void Main(string[] args) {

            Console.WriteLine("Atención al cliente. Clases 'Cliente', 'Negocio' y 'PuestoAtencion'\n");

            Negocio negocio = new Negocio("El Donaldo");
            Cliente c1 = new Cliente(111, "Cacho");
            Cliente c2 = new Cliente(222, "Pepe");
            Cliente c3 = new Cliente(333, "Pompín");

            if (negocio + c1)
                Console.WriteLine("c1 agregado");
            if (negocio + c2)
                Console.WriteLine("c2 agregado");
            if (negocio + c3)
                Console.WriteLine("c3 agregado");

            if (~negocio)
                Console.WriteLine("c1 atendido");
            if (~negocio)
                Console.WriteLine("c2 atendido");
            if (~negocio)
                Console.WriteLine("c3 atendido");
            if (~negocio)
                Console.WriteLine("falso atendido");
        }
    }
}
