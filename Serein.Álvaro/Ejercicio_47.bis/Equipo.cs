using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio_47bis {

    abstract public class Equipo {

        private short cantidadDeJugadores;
        private List<Jugador> jugadores;
        private string nombre;
        private DateTime fechaDeCreacion;

        #region Propiedades
        internal string Nombre {
            get {
                return this.nombre;
            }
        }
        #endregion

        #region Constructores
        private Equipo() {
            this.jugadores = new List<Jugador>();
            this.fechaDeCreacion = DateTime.Now;
        }
        public Equipo(short cantidadDeJugadores, string nombre) : this() {
            this.cantidadDeJugadores = cantidadDeJugadores;
            this.nombre = nombre;
        }
        #endregion

        #region Métodos
        public string MostrarEquipo() {
            string r = "";
            r += "Nombre: " + this.nombre + "\n" +
                 "Cantidad máxima de jugadores: " + this.cantidadDeJugadores + "\n" +
                 "-----------------------------------\n";
            foreach (Jugador j in this.jugadores) {
                r += j.MostrarDatos();
                r += "\n-----------------------------------\n";
            }
            return r;
        }

        public string Ficha() {
            return this.Nombre + " fundado el " + this.fechaDeCreacion.Date.ToString();
        }
        #endregion

        #region Operadores
        public static bool operator ==(Equipo equipo1, Equipo equipo2) {
            return (equipo1.Nombre == equipo2.Nombre &&
                    equipo1.fechaDeCreacion == equipo2.fechaDeCreacion);
        }

        public static bool operator !=(Equipo equipo1, Equipo equipo2) {
            return !(equipo1 == equipo2);
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
        #endregion
    }
}
