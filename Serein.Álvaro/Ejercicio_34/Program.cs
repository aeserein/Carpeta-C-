using System;

namespace Ejercicio_34 {

    class Program {

        static void Main(string[] args) {

            Console.WriteLine("Auto, moto y camión con herencia de 'VehiculoTerrestre'\n");

            Automovil auto = new Automovil(4, 4, Colores.Azul, 5, 2);
            Moto moto = new Moto(2, 0, Colores.Negro, 200);
            Camion camion = new Camion(8, 2, Colores.Blanco, 10, 2000);

            Console.WriteLine("AUTO:\n" + auto.Mostrar() + "\n");
            Console.WriteLine("MOTO:\n" + moto.Mostrar() + "\n");
            Console.WriteLine("CAMIÓN:\n" + camion.Mostrar() + "\n");
        }
    }
}
