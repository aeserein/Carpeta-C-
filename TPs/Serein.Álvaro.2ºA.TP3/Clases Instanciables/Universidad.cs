using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Excepciones;
using Archivos;

namespace Clases_Instanciables {

    public class Universidad {

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        #region Propiedades
        public List<Alumno> Alumnos {
            get => alumnos;
            set => alumnos = value;
        }
        public List<Jornada> Jornadas {
            get => jornada;
            set => jornada = value;
        }
        public List<Profesor> Profesores {
            get => profesores;
            set => profesores = value;
        }
        public Jornada this[int i] {
            get => jornada[i];
            set => jornada[i] = value;
        }
        #endregion

        #region Constructores
        public Universidad() {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
        #endregion

        #region Métodos
        public static bool Guardar(Universidad uni) {
            Xml<Universidad> xml = new Xml<Universidad>();
            try {
                xml.Guardar("Universidad.xml", uni);
                return true;
            } catch {
                return false;
            }
        }
        public static Universidad Leer() {
            Xml<Universidad> xml = new Xml<Universidad>();
            Universidad universidad;
            try {
                xml.Leer("Universidad.xml", out universidad);
            } catch {
                universidad = null;
            }
            return universidad;
        }
        private static string MostrarDatos(Universidad uni) {
            StringBuilder sb = new StringBuilder();
            foreach(Jornada jornada in uni.Jornadas)
                sb.AppendLine(jornada.ToString());
            return sb.ToString();
        }
        public override string ToString() {
            return Universidad.MostrarDatos(this);
        }
        #endregion

        #region Operadores
        public static bool operator == (Universidad g, Alumno a) {
            foreach (Alumno alumno in g.Alumnos) {
                if (alumno == a)
                    return true;
            }
            return false;
        }
        public static bool operator != (Universidad g, Alumno a) {
            return !(g == a);
        }
        public static bool operator == (Universidad g, Profesor i) {
            foreach (Profesor profesor in g.Profesores) {
                if (profesor == i)
                    return true;
            }
            return false;
        }
        public static bool operator != (Universidad g, Profesor i) {
            return !(g == i);
        }
        public static Profesor operator == (Universidad u, EClases clase) {
            foreach (Profesor profesor in u.Profesores) {
                if (profesor == clase)
                    return profesor;
            }
            throw new SinProfesorException();
        }
        public static Profesor operator != (Universidad u, EClases clase) {
            foreach (Profesor profesor in u.Profesores) {
                if (profesor != clase)
                    return profesor;
            }
            throw new SinProfesorException();
        }
        public static Universidad operator + (Universidad g, EClases clase) {
            Jornada jornada = new Jornada(clase, g == clase);
            foreach (Alumno alumno in g.Alumnos) {
                if (alumno == clase)
                    jornada.Alumnos.Add(alumno);
            }
            g.Jornadas.Add(jornada);
            return g;
        }
        public static Universidad operator + (Universidad u, Alumno a) {
            if (u != a)
                u.Alumnos.Add(a);
            else
                throw new AlumnoRepetidoException();
            return u;
        }
        public static Universidad operator + (Universidad u, Profesor i) {
            if (u != i) {
                u.Profesores.Add(i);
            }
            return u;
        }
        #endregion

        #region Enumerados
        public enum EClases {
            Programacion,   // 0
            Laboratorio,    // 1
            Legislacion,    // 2
            SPD             // 3
        }
        #endregion
    }
}