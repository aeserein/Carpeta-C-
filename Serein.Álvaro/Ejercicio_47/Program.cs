using System;
using Ejercicio_47bis; 

namespace Ejercicio_47 {

    class Program {

        static void Main(string[] args) {

            Console.WriteLine("Torneo de fútbol y de básquet");

            #region Creo torneos
            Torneo<EquipoFutbol> torneoFutbol = new Torneo<EquipoFutbol>("Torneo de fútbol");
            Torneo<EquipoBasquet> torneoBasquet = new Torneo<EquipoBasquet>("Torneo de básquet");
            #endregion

            #region Creo jugadores
            Jugador buster = new Jugador(1001, "Buster");
            Jugador babs = new Jugador(1002, "Babs");
            Jugador hamton = new Jugador(1003, "Hamton");
            Jugador plucky = new Jugador(1004, "Plucky");
            Jugador shirley = new Jugador(1005, "Shirley");
            Jugador coyote = new Jugador(1006, "Coyote");
            Jugador lilbeeper = new Jugador(1007, "Lil Beeper");
            Jugador dizzy = new Jugador(1008, "Dizzy");
            Jugador fifi = new Jugador(1009, "Fifi");
            Jugador maxMontana = new Jugador(1010, "Max Montana");
            Jugador elmyra = new Jugador(1011, "Elmyra");
            Jugador furball = new Jugador(1012, "Furball");
            #endregion

            #region Equipos de fútbol
            EquipoFutbol ef1 = new EquipoFutbol(4, "Equipo A");
            EquipoFutbol ef2 = new EquipoFutbol(4, "Equipo B");
            EquipoFutbol ef3 = new EquipoFutbol(4, "Equipo C");

            if (ef1 + plucky &&
                ef1 + buster &&
                ef1 + babs &&
                ef1 + hamton) ;

            if (ef2 + dizzy &&
                ef2 + coyote &&
                ef2 + shirley &&
                ef2 + lilbeeper) ;

            if (ef3 + maxMontana &&
                ef3 + elmyra &&
                ef3 + fifi &&
                ef3 + furball) ;
            #endregion

            #region Equipos de básquet
            EquipoBasquet eb1 = new EquipoBasquet(3, "Equipo A");
            EquipoBasquet eb2 = new EquipoBasquet(3, "Equipo B");
            EquipoBasquet eb3 = new EquipoBasquet(3, "Equipo C");
            EquipoBasquet eb4 = new EquipoBasquet(3, "Equipo D");

            if (eb1 + plucky &&
                eb1 + buster &&
                eb1 + hamton) ;

            if (eb2 + babs &&
                eb2 + fifi &&
                eb2 + shirley) ;

            if (eb3 + coyote &&
                eb3 + lilbeeper &&
                eb3 + dizzy) ;

            if (eb4 + maxMontana &&
                eb4 + elmyra &&
                eb4 + furball) ;
            #endregion

            #region Agrego equipos a sus torneos
            if (torneoFutbol + ef1 &&
                torneoFutbol + ef2 &&
                torneoFutbol + ef3) ;

            if (torneoBasquet + eb1 &&
                torneoBasquet + eb2 &&
                torneoBasquet + eb3 &&
                torneoBasquet + eb4) ;
            #endregion

            Console.WriteLine(torneoFutbol.Mostrar());
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine(torneoBasquet.Mostrar());
            Console.ReadLine();
            Console.Clear();

            for (byte f=0; f<3; f++)
                Console.WriteLine(torneoFutbol.JugarPartido);
            Console.ReadLine();
            Console.Clear();

            for (byte f = 0; f < 3; f++)
                Console.WriteLine(torneoBasquet.JugarPartido);
        }
    }
}
