using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades {

    public class Catedra {

        private List<Alumno> alumnos;

        #region Propiedades
        public List<Alumno> Alumnos {
            get { return this.alumnos; }
        }
        #endregion

        #region Constructores
        public Catedra() {
            this.alumnos = new List<Alumno>();
        }
        #endregion

        #region Enumerados
        public enum ETipoOrdenamiento {
            LegajoAscendente,
            LegajoDescendente,
            ApellidoAscendente,
            ApellidoDescendente
        }
        #endregion

        #region Operadores
        public static bool operator ==(Catedra c, Alumno a) {
            if (!Object.ReferenceEquals(c, null) && !Object.ReferenceEquals(a, null)) {
                foreach (Alumno value in c.alumnos) {
                    if (value == a) {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool operator !=(Catedra c, Alumno a) {
            return !(c == a);
        }

        public static bool operator +(Catedra c, Alumno a) {
            if (c != a) {
                c.alumnos.Add(a);
                return true;
            } else {
                return false;
            }
        }

        public static int operator |(Alumno a, Catedra c) {
            if (c == a) {
                return c.alumnos.IndexOf(a);
            } else {
                return -1;
            }
        }

        public static bool operator -(Catedra c, Alumno a) {
            if (c == a) {
                c.alumnos.Remove(a);
                return true;
            } else {
                return false;
            }
        }
        #endregion

        #region Métodos
        public override string ToString() {
            string s = "";
            foreach(Alumno a in alumnos) {
                s = s + a.ToString();
            }
            return s;
        }
        #endregion
    }
}