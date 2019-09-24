using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio_35 {

    public class Equipo {

        private short cantidadDeJugadores;
        private List<Jugador> jugadores;
        private DirectorTecnico dt;
        private string nombre;

        #region Propiedades //Fuera de consigna
        internal DirectorTecnico DT {
            set {
                this.dt = value;
            }
        }
        #endregion


        private Equipo() {
            jugadores = new List<Jugador>();
        }
        public Equipo(short cantidadDeJugadores, string nombre) : this() {
            this.cantidadDeJugadores = cantidadDeJugadores;
            this.nombre = nombre;
        }

        public string MostrarEquipo() {
            string r = "";
            r += "Nombre: " + this.nombre + "\n" +
                 "Cantidad máxima de jugadores: " + this.cantidadDeJugadores + "\n" +
                 "-----------------------------------\n" +
                 "DT:\n" + this.dt.MostrarDatos() + "\n" +
                 "-----------------------------------\n";
            foreach (Jugador j in this.jugadores) {
                r += j.MostrarDatos();
                r += "\n-----------------------------------\n";
            }
            return r;
        }



        public static bool operator +(Equipo e, Jugador j) {

            if (e.jugadores.Count < e.cantidadDeJugadores &&
                !e.jugadores.Contains(j)) {

                e.jugadores.Add(j);
                return true;
            } else {
                return false;
            }
        }
    }
}
