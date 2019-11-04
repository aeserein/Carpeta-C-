using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Universidad;

namespace Clases_Instanciables {

    public class Jornada {

        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        #region Propiedades
        public List<Alumno> Alumnos {
            get => alumnos;
            set => alumnos = value;
        }
        public Universidad.EClases Clase {
            get => clase;
            set => clase = value;
        }
        public Profesor Instructor {
            get => instructor;
            set => instructor = value;
        }
        #endregion

        #region Constructores
        private Jornada() {
            this.alumnos = new List<Alumno>();
        }
        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this() {
            this.Clase = clase;
            this.instructor = instructor;
        }
        #endregion

        #region Métodos
        public bool GuardarJornada(Jornada jornada) {
            throw new NotImplementedException();
        }
        public string Leer() {
            throw new NotImplementedException();
        }
        public override string ToString() {
            throw new NotImplementedException();
        }
        #endregion

        #region Operadores
        public static bool operator == (Jornada j, Alumno a) {
            throw new NotImplementedException();
        }
        public static bool operator != (Jornada j, Alumno a) {
            return !(j == a);
        }
        public static Jornada operator + (Jornada j, Alumno a) {
            throw new NotImplementedException();
        }
        #endregion
    }
}
