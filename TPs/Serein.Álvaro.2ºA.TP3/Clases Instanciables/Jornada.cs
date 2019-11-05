using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using Archivos;

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
        public static bool Guardar(Jornada jornada) {
            Texto texto = new Texto();
            try {
                texto.Guardar("Jornada.txt", jornada.ToString());
                return true;
            } catch {
                return false;
            }            
        }
        public string Leer() {
            Texto texto = new Texto();
            try {
                string datos;
                texto.Leer("Jornada.txt", out datos);
                return datos;
            } catch {
                return "-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_";
            }
        }
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");
            sb.AppendFormat("CLASE DE {0} POR NOMBRE COMPLETO: {1}", this.Clase, this.Instructor);
            foreach(Alumno alumno in this.alumnos) {
                sb.AppendLine(alumno.ToString());
            }
            sb.AppendLine("CLASE: " + this.clase.ToString());
            sb.AppendLine("PROFESOR: " + instructor.ToString());
            return sb.ToString();
        }
        #endregion

        #region Operadores
        public static bool operator == (Jornada j, Alumno a) {
            foreach(Alumno alumno in j.alumnos) {
                if (alumno == a)
                    return true;
            }
            return false;
        }
        public static bool operator != (Jornada j, Alumno a) {
            return !(j == a);
        }
        public static Jornada operator + (Jornada j, Alumno a) {
            if (j!=a) {
                j.alumnos.Add(a);
            }
            return j;
        }
        #endregion
    }
}
