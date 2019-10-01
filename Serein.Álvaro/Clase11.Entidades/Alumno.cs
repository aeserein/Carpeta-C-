using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades {

    public class Alumno {

        protected string nombre;
        protected string apellido;
        protected int legajo;
        protected ETipoExamen examen;

        #region Propiedades
        public string Nombre {
            get { return this.nombre; }
        }

        public string Apellido {
            get { return this.apellido; }
        }

        public int Legajo {
            get { return this.legajo; }
        }

        public ETipoExamen Examen {
            get { return this.examen; }
        }

        #endregion

        #region Constructores
        public Alumno(string nombre, string apellido, int legajo, ETipoExamen examen) {
            this.nombre = nombre;
            this.apellido = apellido;
            this.legajo = legajo;
            this.examen = examen;
        }
        #endregion

        #region Enumerados
        public enum ETipoExamen {
            Primero,
            Segundo,
            Final
        }
        #endregion

        #region Sobrecarga de Operadores
        public static bool operator ==(Alumno a, Alumno b) {
            if (!Object.ReferenceEquals(a, null) && !Object.ReferenceEquals(b, null)) {
                if (a.legajo == b.legajo) {
                    return true;
                }
            }
            return false;
        }

        public static bool operator !=(Alumno a, Alumno b) {
            return !(a == b);
        }

        #endregion

        #region Metodos
        public static string Mostrar(Alumno a) {
            string s = "";
            if (!Object.Equals(a, null))
                s = a.apellido + ", " + a.nombre + " - Legajo: " + a.legajo + " -  Examen: " + a.examen;
            else
                s = "No existe el alumno";
            return s;
        }

        public static int OrdenarPorLegajoAsc(Alumno a, Alumno b) {
            int r = 0;
            if (a.legajo > b.legajo) {
                r = 1;
            }
            else if (a.legajo < b.legajo) {
                r = -1;
            }
            return r;
        }

        public static int OrdenarPorLegajoDesc(Alumno a, Alumno b) {
            return (Alumno.OrdenarPorLegajoAsc(b, a));
        }

        public static int OrdenarPorApellidoAsc(Alumno a, Alumno b) {
            int r = 0;
            if (string.Compare(a.apellido, b.apellido) < 0) {
                r = 1;
            } else {
                r = -1;
            }
            return r;
        }

        public static int OrdenarPorApellidoDesc(Alumno a, Alumno b) {
            return -1 * Alumno.OrdenarPorApellidoAsc(a, b);
        }

        public override string ToString() {
            return Alumno.Mostrar(this);
        }
        #endregion
    }
}