using System;

namespace Ejercicio_35 {

    class Program {

        static void Main(string[] args) {

            Console.WriteLine("Equipo con clases 'DirectorTecnico' y 'Jugador' heredadas de 'Persona'.\n");

            Equipo e = new Equipo(4, "División C");
            DirectorTecnico dt = new DirectorTecnico("Sebastían Besacheque", DateTime.Today);

            e.DT = dt;

            Console.WriteLine(e.MostrarEquipo());
            Console.ReadKey();
            Console.Clear();

            Jugador arquero = new Jugador(1111, "Calamity Coyote", 0, 10);
            if (e + arquero) {
                Console.WriteLine(e.MostrarEquipo());
                Console.ReadKey();
                Console.Clear();
            }

            Jugador defensor = new Jugador(2222, "Hamton", 9, 10);
            if (e + defensor) {
                Console.WriteLine(e.MostrarEquipo());
                Console.ReadKey();
                Console.Clear();
            }

            Jugador medio = new Jugador(3333, "Shirley", 4, 10);
            if (e + medio) {
                Console.WriteLine(e.MostrarEquipo());
                Console.ReadKey();
                Console.Clear();
            }

            Jugador delantero = new Jugador(4444, "Fifi", 12, 10);
            if (e + delantero) {
                Console.WriteLine(e.MostrarEquipo());
                Console.ReadKey();
                Console.Clear();
            }

            // Comparo jugadores
            Jugador copia = defensor;
            Console.Write("Copia\n" + copia.MostrarDatos() + "\n\n" +
                          "Defensor original\n" + defensor.MostrarDatos() + "\n\n");
            if (defensor==copia)
                Console.Write("Son iguales\n\n");
            else
                Console.Write("Son diferentes\n\n");

            // Comparo dts
            DirectorTecnico copiaDT = new DirectorTecnico("César Luis Mentirotti", DateTime.Today);
            Console.Write("Copia\n" + copiaDT.MostrarDatos() + "\n\n" +
                          "DT original\n" + dt.MostrarDatos() + "\n\n");
            if (dt == copiaDT)
                Console.Write("Son iguales\n\n");
            else
                Console.Write("Son diferentes\n\n");
        }
    }
}
