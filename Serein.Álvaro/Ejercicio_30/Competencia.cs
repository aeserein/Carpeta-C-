using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio_30 {

    class Competencia {

        private short cantidadDeCompetidores;
        private short cantidadVueltas;
        private List<AutoF1> competidores;


        private Competencia() {
            competidores = new List<AutoF1>();
        }
        public Competencia(short cantidadVueltas, short cantidadDeCompetidores) : this() {
            this.cantidadVueltas = cantidadVueltas;
            this.cantidadDeCompetidores = cantidadDeCompetidores;
        }


        public static bool operator -(Competencia c, AutoF1 a) {
            if (c == a) {
                c.competidores.Remove(a);
                return true;
            } else {
                return false;
            }
        }
        public static bool operator +(Competencia c, AutoF1 a) {
            if (c.competidores.Count<c.cantidadDeCompetidores && c!=a) {
                Random r = new Random();

                a.EnCompetencia = true;
                a.VueltasRestantes = c.cantidadVueltas;
                a.CantidadCombustible = (short)r.Next(15, 101);
                c.competidores.Add(a);
                return true;

            } else {
                return false;
            }
        }
        public static bool operator ==(Competencia c, AutoF1 a) {
            return c.competidores.Contains(a);
        }
        public static bool operator !=(Competencia c, AutoF1 a) {
            return !(c == a);
        }


        public string Mostrar() {
            string r = "Cantidad de competidores: " + this.cantidadDeCompetidores + "\n" +
                       "Cantidad de vueltas: " + this.cantidadVueltas + "\n" +
                       "------------------------------------------\n";
            foreach (AutoF1 auto in competidores) {
                r += auto.MostrarDatos();
                r += "\n------------------------------------------\n";
            }
            return r;
        }
    }
}
