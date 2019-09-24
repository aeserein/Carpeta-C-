using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio_35 {

    public class Jugador : Persona {

        private int partidosJugados;
        private int totalGoles;

        #region Propiedades

        public int PartidosJugados {
            get {
                return this.partidosJugados;
            }
            set {
                this.partidosJugados = value;
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
            set {
                this.totalGoles = value;
            }
        }

        #endregion

        #region Constructores
        public Jugador(int dni, string nombre) : this(dni, nombre, 0, 0) { }

        public Jugador(int dni, string nombre, int totalGoles, int totalPartidos) : base(dni, nombre) {
            this.totalGoles = totalGoles;
            this.partidosJugados = totalPartidos;
        }
        #endregion

        #region Métodos
        new public string MostrarDatos() {
            string s;
            s = base.MostrarDatos();
            s += "Partidos jugados: " + this.PartidosJugados + "\n" +
                 "Cantidad de goles: " + this.TotalGoles + "\n" +
                 "Promedio de goles: " + this.PromedioGoles;
            return s;
        }
        #endregion

        #region Operadores
        /*
        public static bool operator ==(Jugador j1, Jugador j2) {
            return (j1.DNI == j2.DNI);
        }
        public static bool operator !=(Jugador j1, Jugador j2) {
            return !(j1.DNI == j2.DNI);
        }
        */
        #endregion
    }
}
