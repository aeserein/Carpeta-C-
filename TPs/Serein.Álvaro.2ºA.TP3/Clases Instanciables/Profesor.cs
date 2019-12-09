using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesAbstractas;

namespace Clases_Instanciables {

    public sealed class Profesor : Universitario {

        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        #region Constructores
        /// <summary>
        /// Constructor que inicializa la instancia de Random.
        /// </summary>
        static Profesor() {
            Profesor.random = new Random();
        }

        /// <summary>
        /// Crea una instancia de Profesor.
        /// </summary>
        public Profesor() : base() {
        }

        /// <summary>
        /// Crea una instancia de Profesor
        /// </summary>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad) {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Asigna dos clases aleatorias al profesor.
        /// </summary>
        private void _randomClases() {
            Array aux = Enum.GetValues(typeof(Universidad.EClases));
            for (byte f = 0; f < 2; f++)
                this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, aux.Length));
        }

        /// <summary>
        /// Muestra los datos del Profesor como cadena de caratéres.
        /// </summary>
        /// <returns>Cadena de caracteres con los datos del Profesor.</returns>
        protected override string MostrarDatos() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.Append(this.ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// Lista las clases en las que participa el Profesor..
        /// </summary>
        /// <returns>Cadena de caracteres con las clases del Profesor.</returns>
        protected override string ParticiparEnClase() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DÍA:");
            foreach (Universidad.EClases c in this.clasesDelDia) {
                sb.AppendLine(c.ToString());
            }
            sb.AppendLine("");
            return sb.ToString();
        }

        /// <summary>
        /// Muestra los datos del Profesor como cadena de caratéres.
        /// </summary>
        /// <returns>Cadena de caracteres con los datos del Profesor.</returns>
        public override string ToString() {
            return this.MostrarDatos();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Verifica si el Profesor participa de la clase.
        /// </summary>
        /// <param name="i">Un profesor.</param>
        /// <param name="clase">Una clase.</param>
        /// <returns>Verdadero si es profesor de esa clase.</returns>
        public static bool operator == (Profesor i, Universidad.EClases clase) {
            foreach (Universidad.EClases eClases in i.clasesDelDia) {
                if (eClases == clase)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Verifica si el Profesor participa de la clase.
        /// </summary>
        /// <param name="i">Un profesor.</param>
        /// <param name="clase">Una clase.</param>
        /// <returns>Verdadero si no es profesor de esa clase.</returns>
        public static bool operator != (Profesor i, Universidad.EClases clase) {
            return !(i == clase);
        }
        #endregion
    }
}