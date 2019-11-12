using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesAbstractas;

namespace Clases_Instanciables {

    public sealed class Alumno : Universitario {

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        #region Constructores
        /// <summary>
        /// Crea una instancia de Alumno
        /// </summary>
        public Alumno() {
        }

        /// <summary>
        /// Crea una instancia de Alumno
        /// </summary>
        public Alumno(int id, string nombre, string apellido, string dni,
                      ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
                      : base(id, nombre, apellido, dni, nacionalidad) {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Crea una instancia de Alumno
        /// </summary>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad,
                      Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
                      : this(id, nombre, apellido, dni, nacionalidad, claseQueToma) {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Muestra los datos del Alumno como cadena de caratéres.
        /// </summary>
        /// <returns>Cadena de caracteres con los datos del Alumno.</returns>
        protected override string MostrarDatos() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos() + "\n");
            sb.Append("ESTADO DE CUENTA: ");
            if (this.estadoCuenta == EEstadoCuenta.AlDia)
                sb.AppendLine("Cuota al día");
            else
                sb.AppendLine(this.estadoCuenta.ToString());
            sb.Append(this.ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// Devuelve la clase en la que participa el Alumno.
        /// </summary>
        /// <returns>La clase en la que participa como cadena de caracteres.</returns>
        protected override string ParticiparEnClase() {
            return "TOMA CLASES DE " + this.claseQueToma.ToString();
        }

        /// <summary>
        /// Muestra los datos del Alumno como cadena de caratéres.
        /// </summary>
        /// <returns>Cadena de caracteres con los datos del Alumno.</returns>
        public override string ToString() {
            return this.MostrarDatos();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Verifica si el Alumno participa de una clase.
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Clase</param>
        /// <returns>Verdadero si participa de la clase.</returns>
        public static bool operator == (Alumno a, Universidad.EClases clase) {
            return (a.claseQueToma == clase &&
                    a.estadoCuenta != EEstadoCuenta.Deudor);
        }

        /// <summary>
        /// Verifica si el Alumno participa de una clase.
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Clase</param>
        /// <returns>Verdadero si no participa de la clase.</returns>
        public static bool operator != (Alumno a, Universidad.EClases clase) {
            return (a.claseQueToma != clase);
        }
        #endregion

        #region Enumerados
        /// <summary>
        /// Estado de cuenta de un Alumno.
        /// </summary>
        public enum EEstadoCuenta {
            AlDia,      // 0
            Deudor,     // 1
            Becado      // 2
        }
        #endregion
    }
}
