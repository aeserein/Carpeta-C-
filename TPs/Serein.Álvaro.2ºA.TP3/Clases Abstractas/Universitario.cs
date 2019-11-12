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
        /// <summary>
        /// Constructor para los atributos de Universitario
        /// </summary>
        public Universitario() : base() {
        }

        /// <summary>
        /// Constructor para los atributos de Universitario
        /// </summary>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad) {
            this.legajo = legajo;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Verifica si el objeto es igual al argumento.
        /// </summary>
        /// <param name="obj">Argumento con el cual comparar.</param>
        /// <returns>Verdadero, si los objetis son iguales.</returns>
        public override bool Equals(object obj) {
            if (obj is Universitario) {
                return (this == (Universitario)obj); 
            } else {
                return false;
            }
        }

        /// <summary>
        /// Muestra los datos del Universitario como cadena de caratéres.
        /// </summary>
        /// <returns>Cadena de caracteres con los datos del Universitario.</returns>
        protected virtual string MostrarDatos() {
            return  base.ToString() + "\n" +
                   "LEGAJO NÚMERO : " + this.legajo;
        }

        protected abstract string ParticiparEnClase();
        #endregion

        #region Operadores
        /// <summary>
        /// Compara dos instancias de Universitario.
        /// </summary>
        /// <param name="pg1">Primer Universitario.</param>
        /// <param name="pg2">Segundo Universitario.</param>
        /// <returns>Verdadero si tienen el mismo DNI o legajo.</returns>
        public static bool operator == (Universitario pg1, Universitario pg2) {
            if ( (pg1.GetType() == pg2.GetType()) &&
                 (pg1.DNI == pg2.DNI || pg1.legajo == pg2.legajo) ) {
                throw new AlumnoRepetidoException();
            } else {
                return false;
            }
        }

        /// <summary>
        /// Compara dos instancias de Universitario.
        /// </summary>
        /// <param name="pg1">Primer Universitario.</param>
        /// <param name="pg2">Segundo Universitario.</param>
        /// <returns>Verdadero si tienen diferente DNI y legajo.</returns>
        public static bool operator != (Universitario pg1, Universitario pg2) {
            return !(pg1 == pg2);
        }
        #endregion
    }
}
