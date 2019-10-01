using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades {

    public class AlumnoCalificado : Alumno {

        private double nota;

        #region Constructores
        public AlumnoCalificado(string nombre,
                                string apellido,
                                int legajo,
                                ETipoExamen examen,
                                double nota)
            : this(new Alumno(nombre, apellido, legajo, examen), nota) { }

        public AlumnoCalificado(Alumno a, double nota)
            : base(a.Nombre, a.Apellido, a.Legajo, a.Examen) {
            this.nota = nota;
        }
        #endregion

        #region Propiedades
        public double Nota {
            get { return this.nota; }
        }
        #endregion

        #region Métoodos
        public string Mostrar() {
            return Alumno.Mostrar(this) + " Nota: " + this.Nota;
        }

        public override string ToString() {
            return this.Mostrar();
        }
        #endregion
    }

}