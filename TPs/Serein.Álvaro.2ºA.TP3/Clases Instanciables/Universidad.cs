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
        /// <summary>
        /// Lee o devuelve la lista de Alumnos de la Universidad.
        /// </summary>
        public List<Alumno> Alumnos {
            get => alumnos;
            set => alumnos = value;
        }

        /// <summary>
        /// Lee o devuelve la lista de Profesores de la Universidad.
        /// </summary>
        public List<Profesor> Instructores {
            get => profesores;
            set => profesores = value;
        }

        /// <summary>
        /// Lee o devuelve la lista de Jornadas de la Universidad.
        /// </summary>
        public List<Jornada> Jornadas {
            get => jornada;
            set => jornada = value;
        }

        /// <summary>
        /// Indexador de Jornadas en una instancia de Universidad.
        /// </summary>
        public Jornada this[int i] {
            get => jornada[i];
            set => jornada[i] = value;
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Crea una instancia de Universidad.
        /// </summary>
        public Universidad() {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Guarda un archivo XML con los datos de la Universidad.
        /// </summary>
        /// <param name="uni">Universidad a serializar.</param>
        /// <returns>Verdadero si pudo escribir el archivo. Falso si algo salió mal.</returns>
        public static bool Guardar(Universidad uni) {
            Xml<Universidad> xml = new Xml<Universidad>();
            try {
                xml.Guardar("Universidad.xml", uni);
                return true;
            } catch {
                return false;
            }
        }

        /// <summary>
        /// Lee un archivo XML con los datos de una Universidad.
        /// </summary>
        /// <returns>Instancia de Universidad con los datos del archivo.</returns>
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

        /// <summary>
        /// Muestra los datos de una Universidad como cadena de caratéres.
        /// </summary>
        /// <param name="uni">Universidad a mostrar.</param>
        /// <returns>Cadena de caracteres con los datos de la Universidad.</returns>
        private static string MostrarDatos(Universidad uni) {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");
            foreach (Jornada jornada in uni.Jornadas)
                sb.AppendLine(jornada.ToString());
            return sb.ToString();
        }

        /// <summary>
        /// Muestra los datos de una Universidad como cadena de caratéres.
        /// </summary>
        /// <returns>Cadena de caracteres con los datos de la Universidad.</returns>
        public override string ToString() {
            return Universidad.MostrarDatos(this);
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Verifica si una Universidad contiene un determinado Alumno.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>Verdadero si el Alumno forma parte de la Universidad.</returns>
        public static bool operator == (Universidad g, Alumno a) {
            foreach (Alumno alumno in g.Alumnos) {
                if (alumno == a)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Verifica si una Universidad contiene un determinado Alumno.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>Verdadero si el Alumno no forma parte de la Universidad.</returns>
        public static bool operator != (Universidad g, Alumno a) {
            return !(g == a);
        }

        /// <summary>
        /// Verifica si una Universidad contiene un determinado Profesor.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>Verdadero si el Profesor forma parte de la Universidad.</returns>
        public static bool operator == (Universidad g, Profesor i) {
            foreach (Profesor p in g.Instructores) {
                if (p == i)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Verifica si una Universidad contiene un determinado Profesor.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>Verdadero si el Profesor no forma parte de la Universidad.</returns>
        public static bool operator != (Universidad g, Profesor i) {
            return !(g == i);
        }

        /// <summary>
        /// Devuelve un Profesor que dé la clase solicitada.
        /// </summary>
        /// <param name="u">Profesor</param>
        /// <param name="clase">Clase</param>
        /// <returns>Una instancia de Profesor que dé la clase solicitada.</returns>
        public static Profesor operator == (Universidad u, EClases clase) {
            foreach (Profesor profesor in u.Instructores) {
                if (profesor == clase)
                    return profesor;
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Devuelve un Profesor que dé la clase solicitada.
        /// </summary>
        /// <param name="u">Profesor</param>
        /// <param name="clase">Clase</param>
        /// <returns>Una instancia de Profesor que no dé la clase solicitada.</returns>
        public static Profesor operator != (Universidad u, EClases clase) {
            foreach (Profesor profesor in u.Instructores) {
                if (profesor != clase)
                    return profesor;
            }
            return null;
        }

        /// <summary>
        /// Agrega una Jornada a una instancia de Universidad.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">Clase de la Jornada</param>
        /// <returns>Una instancia de Universidad con la Jornada agregada.</returns>
        public static Universidad operator + (Universidad g, EClases clase) {
            Jornada jornada = new Jornada(clase, g == clase);
            foreach (Alumno alumno in g.Alumnos) {
                if (alumno == clase)
                    jornada.Alumnos.Add(alumno);
            }
            g.Jornadas.Add(jornada);
            return g;
        }

        /// <summary>
        /// Agrega un Alumno a una Universidad, si este no está en la lista.
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>Una instancia de Universidad con el Alumno agregado.</returns>
        public static Universidad operator + (Universidad u, Alumno a) {
            if (u != a)
                u.Alumnos.Add(a);
            else
                throw new AlumnoRepetidoException();
            return u;
        }

        /// <summary>
        /// Agrega un Profesor a una Universidad, si este no está en la lista.
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>Una instancia de Universidad con el Profesor agregado.</returns>
        public static Universidad operator + (Universidad u, Profesor i) {
            if (u != i) {
                u.Instructores.Add(i);
            }
            return u;
        }
        #endregion

        #region Enumerados
        /// <summary>
        /// Listado de clases.
        /// </summary>
        public enum EClases {
            Programacion,   // 0
            Laboratorio,    // 1
            Legislacion,    // 2
            SPD             // 3
        }
        #endregion
    }
}