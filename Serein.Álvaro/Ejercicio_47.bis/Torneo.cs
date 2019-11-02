using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio_47bis {

    public class Torneo<T> where T : Equipo {

        public string nombre;
        public List<T> equipos;

        #region Propiedades
        public string JugarPartido {
            get {
                if (this.equipos.Count>1) {
                    Random random = new Random();
                    T equipo1 = this.equipos[random.Next(0, equipos.Count)];
                    T equipo2;
                    do {
                        equipo2 = this.equipos[random.Next(0, equipos.Count)];
                    } while (equipo2 == equipo1);
                    return CalcularPartido(equipo1, equipo2);
                } else {
                    return "No hay suficientes equipos para un partido";
                }
            }
        }
        #endregion

        #region Constructores
        public Torneo(string nombre) {
            this.equipos = new List<T>();
            this.nombre = nombre;
        }
        #endregion

        #region Métodos
        public string Mostrar() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Torneo " + this.nombre);
            foreach(T e in this.equipos) {
                sb.AppendLine(e.MostrarEquipo());
            }
            return sb.ToString();
        }

        private string CalcularPartido(T equipo1, T equipo2) {
            Random random = new Random();
            return String.Format("{0} {1} - {2} {3}",
                                 equipo1.Nombre, random.Next(0, 11),
                                 equipo2.Nombre, random.Next(0, 11));
        }
        #endregion

        #region Operadores
        public static bool operator ==(Torneo<T> torneo, T equipo) {
            foreach (T e in torneo.equipos) {
                if (e == equipo)
                    return true;
            }
            return false;
        }

        public static bool operator !=(Torneo<T> torneo, T equipo) {
            return !(torneo == equipo);
        }

        public static bool operator +(Torneo<T> torneo, T equipo) {
            if (torneo != equipo) {
                torneo.equipos.Add(equipo);
                return true;
            } else {
                return false;
            }
        }
        #endregion
    }
}
