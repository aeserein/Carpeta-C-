using System;

namespace Ejercicio_29 {

    class Program {

        static void Main(string[] args) {

            Console.WriteLine("Equipo y jugadores\n");

            Equipo e = new Equipo(4, "División A");
            Jugador arquero = new Jugador(1111, "Dizzy", 0, 10);
            Jugador defensor = new Jugador(2222, "Buster", 6, 10);
            Jugador medio = new Jugador(3333, "Max Montana", 8, 10);
            Jugador delantero = new Jugador(4444, "Furball", 19, 10);

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
