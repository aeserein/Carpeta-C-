using System;
using System.Collections.Generic;
using System.Text;

namespace Práctica_Parcial_01 {

    class Grupo {

        private List<Mascota> manada;
        private string nombre;
        private static TipoManada tipo;

        #region Propiedades
        public static TipoManada Tipo {
            set { Grupo.Tipo = value; }
        }

        #endregion

        #region Constructores
        static Grupo() {
            Grupo.Tipo = TipoManada.Unica;
        }
        private Grupo() {
            this.manada = new List<Mascota>();
        }
        public Grupo(string nombre) : this() {
            this.nombre = nombre;
        }
        public Grupo(string nombre, TipoManada tipo) : this(nombre) {
            Grupo.Tipo = tipo;
        }
        #endregion

        #region Operadores
        public static bool operator ==(Grupo e, Mascota j) {
            foreach (Mascota m in e.manada) {
                if (m == j)
                    return true;
            }
            return false;
        }
        public static bool operator !=(Grupo e, Mascota j) {
            return !(e == j);
        }
        public static Grupo operator +(Grupo e, Mascota j) {
            if (e != j)
                e.manada.Add(j);
            return e;
        }
        public static Grupo operator -(Grupo e, Mascota j) {
            if (e == j)
                e.manada.Remove(j);
            return e;
        }
        public static implicit operator string(Grupo e) {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("**" + e.nombre + " " + Grupo.tipo.ToString() + "**");
            sb.AppendLine("Integrantes");
            foreach(Mascota m in e.manada) {
                sb.AppendLine(m.ToString());
            }
            return sb.ToString();
        }
        #endregion

        #region Enumerados
        public enum TipoManada {
            Unica,  // 0
            Mixta   // 1
        }
        #endregion
    }
}
