using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;
using Excepciones;

namespace EntidadesAbstractas {

    public abstract class Universitario : Persona {

        private int legajo;

        #region Constructores
        public Universitario() {
        }
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad) {
            this.legajo = legajo;
        }
        #endregion

        #region Métodos
        public override bool Equals(object obj) {
            if (obj is Universitario) {
                return (this == (Universitario)obj); 
            } else {
                return false;
            }
        }
        protected virtual string MostrarDatos() {
            return  base.ToString() + "\n" +
                   "Legajo: " + this.legajo;
        }
        protected abstract string ParticiparEnClase();
        #endregion

        #region Operadores
        public static bool operator == (Universitario pg1, Universitario pg2) {
            if ( (pg1.GetType() == pg2.GetType()) &&
                 (pg1.DNI == pg2.DNI || pg1.legajo == pg2.legajo) ) {
                throw new AlumnoRepetidoException();
            } else {
                return false;
            }
        }
        public static bool operator != (Universitario pg1, Universitario pg2) {
            return !(pg1 == pg2);
        }
        #endregion
    }
}
