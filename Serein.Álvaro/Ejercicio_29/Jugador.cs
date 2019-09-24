using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio_29 {

    public class Jugador {

        private int dni;
        private string nombre;
        private int partidosJugados;
        //private float promedioGoles;  //Eliminado por ejercicio 32
        private int totalGoles;

        #region Propiedades

        public int PartidosJugados {
            get {
                return this.partidosJugados;
            }
        }

        public float PromedioGoles {
            get {
                return (float)this.totalGoles / this.PartidosJugados;
            }
        }

        public int TotalGoles {
            get {
                return this.totalGoles;
            }
        }

        public int DNI {
            get {
                return this.dni;
            }
            set {
                this.dni = value;
            }
        }

        public string Nombre {
            get {
                return this.nombre;
            }
            set {
                this.nombre = value;
            }
        }

        #endregion

        #region Constructores
        private Jugador() {
            this.DNI = 0;
            this.Nombre = "";
            this.partidosJugados = 0;
            this.totalGoles = 0;
        }

        public Jugador(int dni, string nombre) : this() {
            this.DNI = dni;
            this.Nombre = nombre;
        }

        public Jugador(int dni, string nombre, int totalGoles, int totalPartidos) : this(dni, nombre) {
            this.totalGoles = totalGoles;
            this.partidosJugados = totalPartidos;
        }
        #endregion

        #region Métodos
        public string MostrarDatos() {
            return "Nombre: " + this.Nombre + "\n" +
                   "DNI: " + this.DNI + "\n" +
                   "Partidos jugados: " + this.PartidosJugados + "\n" +
                   "Cantidad de goles: " + this.totalGoles + "\n" +
                   "Promedio de goles: " + this.PromedioGoles;

        }
        #endregion

        #region Operadores
        public static bool operator ==(Jugador j1, Jugador j2) {
            return (j1.DNI == j2.DNI);
        }
        public static bool operator !=(Jugador j1, Jugador j2) {
            return !(j1.DNI == j2.DNI);
        }
        #endregion
    }
}
