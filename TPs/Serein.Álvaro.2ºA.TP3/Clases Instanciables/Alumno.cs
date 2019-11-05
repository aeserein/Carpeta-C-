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
        public Alumno() {
        }
        public Alumno(int id, string nombre, string apellido, string dni,
                      ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
                      : base(id, nombre, apellido, dni, nacionalidad) {
            this.claseQueToma = claseQueToma;
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad,
                      Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
                      : this(id, nombre, apellido, dni, nacionalidad, claseQueToma) {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Métodos
        protected override string MostrarDatos() {
            return base.MostrarDatos() + "\n" +
                   "ESTADO DE CUENTA: " + this.estadoCuenta.ToString() +
                   this.ParticiparEnClase();
        }
        protected override string ParticiparEnClase() {
            return "TOMA CLASE DE " + this.claseQueToma.ToString();
        }
        public override string ToString() {
            return this.MostrarDatos();
        }
        #endregion

        #region Operadores
        public static bool operator == (Alumno a, Universidad.EClases clase) {
            return (a.claseQueToma == clase &&
                    a.estadoCuenta != EEstadoCuenta.Deudor);
        }
        public static bool operator != (Alumno a, Universidad.EClases clase) {
            return (a.claseQueToma != clase);
        }
        #endregion

        #region Enumerados
        public enum EEstadoCuenta {
            AlDia,      // 0
            Deudor,     // 1
            Becado      // 2
        }
        #endregion
    }
}
