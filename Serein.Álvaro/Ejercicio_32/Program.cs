using System;
using Ejercicio_29;

namespace Ejercicio_32 {

    class Program {

        static void Main(string[] args) {

            Console.WriteLine("Usa el ejercicio 29 como base\n");

            Console.WriteLine("Equipo y jugadores\n");

            Equipo e = new Equipo(4, "División B");
            Jugador arquero = new Jugador(1111, "Plucky", 0, 10);
            Jugador defensor = new Jugador(2222, "Elmyra", 3, 10);
            Jugador medio = new Jugador(3333, "Babs", 12, 10);
            Jugador delantero = new Jugador(4444, "Beep Beep", 13, 10);

            Console.WriteLine(e.MostrarEquipo());

            if (e + arquero) {
                Console.WriteLine(e.MostrarEquipo());
                Console.ReadKey();
                Console.Clear();
            }

            if (e + defensor) {
                Console.WriteLine(e.MostrarEquipo());
                Console.ReadKey();
                Console.Clear();
            }

            if (e + medio) {
                Console.WriteLine(e.MostrarEquipo());
                Console.ReadKey();
                Console.Clear();
            }

            if (e + delantero) {
                Console.WriteLine(e.MostrarEquipo());
                Console.ReadKey();
            }

            if (e + medio) {
                Console.WriteLine("REPETIDO\n");
                Console.WriteLine(e.MostrarEquipo());
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
