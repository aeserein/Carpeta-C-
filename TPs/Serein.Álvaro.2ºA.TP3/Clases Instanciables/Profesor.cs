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
        static Profesor() {
            Profesor.random = new Random();
        }
        public Profesor() {
        }
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad) {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        #endregion

        #region Métodos
        private void _randomClases() {
            Array aux = Enum.GetValues(typeof(Universidad.EClases));
            for (byte f = 0; f < 2; f++)
                this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, aux.Length));
        }
        protected override string MostrarDatos() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.Append(this.ParticiparEnClase());
            return sb.ToString();
        }
        protected override string ParticiparEnClase() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES:");
            foreach (Universidad.EClases c in this.clasesDelDia) {
                sb.AppendLine(c.ToString());
            }
            return sb.ToString();
        }
        public override string ToString() {
            return this.MostrarDatos();
        }
        #endregion

        #region Operadores
        public static bool operator == (Profesor i, Universidad.EClases clase) {
            return i.clasesDelDia.Contains(clase);
        }
        public static bool operator != (Profesor i, Universidad.EClases clase) {
            return !(i == clase);
        }
        #endregion
    }
}