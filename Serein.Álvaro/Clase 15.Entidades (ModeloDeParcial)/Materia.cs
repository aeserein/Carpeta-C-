using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_15.Entidades__ModeloDeParcial_ {

    public class Materia {

        private List<Alumno> _alumnos;
        private EMateria _nombre;
        private static Random _notaParaUnAlumno;

        #region Propiedades
        public List<Alumno> Alumnos {
            get { return this._alumnos; }
            set { this._alumnos = value; }
        }
        private EMateria Nombre {
            get { return this._nombre; }
            set { this._nombre = value; }
        }
        #endregion

        #region Constructores
        static Materia() {
            Materia._notaParaUnAlumno = new Random();
        } 

        private Materia() {
            this.Alumnos = new List<Alumno>();
        }
        private Materia(EMateria nombre) : this() {
            this.Nombre = nombre;
        }
        #endregion

        #region Métodos
        private string Mostrar() {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Materia: " + this._nombre.ToString());
            sb.AppendLine("*************************************");
            sb.AppendLine("**************ALUMNOS****************");
            foreach (Alumno a in this.Alumnos) {
                sb.AppendLine(Alumno.Mostrar(a));
            }
            sb.AppendLine("");
            return sb.ToString();
        }

        public void CalificarAlumnos() {
            for (int f=0; f<this.Alumnos.Count; f++) {
                this.Alumnos[f].Nota = Materia._notaParaUnAlumno.Next(1, 11);
            }
        }
        #endregion

        #region Operadores
        public static implicit operator Materia(EMateria nombre) {
            return new Materia(nombre);
        }

        public static implicit operator float(Materia m) {
            float aNotas = 0;
            int cAlumnos = 0;
            foreach (Alumno a in m.Alumnos) {
                aNotas += a.Nota;
                cAlumnos++;
            }
            return aNotas / cAlumnos;
        }

        public static explicit operator string(Materia materia) {
            return "\n" + materia.Mostrar();
        }

        public static bool operator ==(Materia m, Alumno a) {
            if (!Object.Equals(m, null) && !Object.Equals(a, null)) {
                foreach(Alumno aux in m.Alumnos) {
                    if (a == aux)
                        return true;
                }
            }
            return false;
        }
        public static bool operator !=(Materia m, Alumno a) {
            return !(m == a);
        }

        public static Materia operator +(Materia m, Alumno a) {
            if (m!=a) {
                Console.WriteLine("Se agregó un alumno a la materia " + m.Nombre.ToString() + "!!!");
                m.Alumnos.Add(a);
            } else { 
                Console.WriteLine("El alumno ya está en la materia " + m.Nombre.ToString() + "!!!");
            }
            return m;
        }

        public static Materia operator -(Materia m, Alumno a) {
            if (m == a) {
                Console.WriteLine("Se quitó un alumno a la materia " + m.Nombre.ToString() + "!!!");
                m.Alumnos.Remove(a);
            } else {
                Console.WriteLine("El alumno no está en la materia " + m.Nombre.ToString() + "!!!");
            }
            return m;
        }
        #endregion
        
    }
}
