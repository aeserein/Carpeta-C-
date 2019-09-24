using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio_36 {

    public class Competencia {

        private short cantidadDeCompetidores;
        private short cantidadVueltas;
        private List<VehiculoDeCarrera> competidores;
        private TipoCompetencia tipo;

        #region Propiedades
        public short CantidadDeCompetidores {
            get { return this.cantidadDeCompetidores; }
            set { this.cantidadDeCompetidores = value; }
        }
        public short CantidadVueltas {
            get { return this.cantidadVueltas; }
            set { this.cantidadVueltas = value; }
        }
        public VehiculoDeCarrera this[int i] {
            get { return this.competidores[i]; }
        }
        private TipoCompetencia Tipo {
            get { return this.tipo; }
            set { this.tipo = value; }
        }
        #endregion

        #region Constructores
        private Competencia() {
            this.competidores = new List<VehiculoDeCarrera>();
        }
        public Competencia(short cantidadVueltas, short cantidadDeCompetidores, TipoCompetencia tipo) : this() {
            this.CantidadVueltas = cantidadVueltas;
            this.CantidadDeCompetidores = cantidadDeCompetidores;
            this.Tipo = tipo;
        }
        #endregion

        #region Operadores
        public static bool operator -(Competencia c, VehiculoDeCarrera a) {
            if (c == a && c.competidores.Contains(a)) {
                c.competidores.Remove(a);
                return true;
            } else {
                return false;
            }
        }
        public static bool operator +(Competencia c, VehiculoDeCarrera a) {
            if (c.competidores.Count<c.CantidadDeCompetidores &&
                c==a &&
                !c.competidores.Contains(a)) {

                Random r = new Random();

                a.EnCompetencia = true;
                a.VueltasRestantes = c.CantidadVueltas;
                a.CantidadCombustible = (short)r.Next(15, 101);
                c.competidores.Add(a);
                return true;
            } else {
                return false;
            }
        }
        public static bool operator ==(Competencia c, VehiculoDeCarrera a) {
            return ( (c.Tipo == TipoCompetencia.F1 && (a is AutoF1))   ||
                     (c.Tipo == TipoCompetencia.MotoCross && (a is MotoCross)) );
        }
        public static bool operator !=(Competencia c, VehiculoDeCarrera a) {
            return !(c == a);
        }
        #endregion

        #region Métodos
        public string Mostrar() {
            string r = "Cantidad de competidores: " + this.CantidadDeCompetidores + "\n" +
                       "Cantidad de vueltas: " + this.CantidadVueltas + "\n" +
                       "------------------------------------------\n";
            foreach (VehiculoDeCarrera v in competidores) {
                if (v is AutoF1) {
                    AutoF1 aAux = (AutoF1)v;
                    r += aAux.MostrarDatos();
                    r += "\n------------------------------------------\n";
                } else {
                    MotoCross mAux = (MotoCross)v;
                    r += mAux.MostrarDatos();
                    r += "\n------------------------------------------\n";
                }
            }
            return r;
        }
        #endregion

        #region Enumerados
        public enum TipoCompetencia {
            F1,
            MotoCross
        }
        #endregion
    }
}
