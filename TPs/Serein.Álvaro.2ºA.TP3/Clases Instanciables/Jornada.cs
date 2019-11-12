using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using Archivos;
using Excepciones;

namespace Clases_Instanciables {

    public class Jornada {

        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        #region Propiedades
        /// <summary>
        /// Lee o devuelve la lista de Alumnos.
        /// </summary>
        public List<Alumno> Alumnos {
            get => alumnos;
            set => alumnos = value;
        }

        /// <summary>
        /// Lee o devuelve la clase.
        /// </summary>
        public Universidad.EClases Clase {
            get => clase;
            set => clase = value;
        }

        /// <summary>
        /// Lee o devuelve el profesor de la Jornada.
        /// </summary>
        public Profesor Instructor {
            get => instructor;
            set => instructor = value;
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Crea una instancia de Jornada.
        /// </summary>
        private Jornada() {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Crea una instancia de Jornada.
        /// </summary>
        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this() {
            this.Clase = clase;
            this.instructor = instructor;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Guarda los datos de la Jornada en un archivo de texto "Jornada.txt".
        /// </summary>
        /// <param name="jornada">Instancia de Jornada a guardar.</param>
        /// <returns>Verdadero si pudo escribir el archivo. Falso si algo salió mal.</returns>
        public static bool Guardar(Jornada jornada) {
            Texto texto = new Texto();
            try {
                texto.Guardar("Jornada.txt", jornada.ToString());
                return true;
            } catch {
                return false;
            }            
        }

        /// <summary>
        /// Lee los datos del archivo "Jornada.txt".
        /// </summary>
        /// <returns>Una cadena de caracteres con los datos de la Jornada en el archivo.</returns>
        public static string Leer() {
            Texto texto = new Texto();
            try {
                string datos;
                texto.Leer("Jornada.txt", out datos);
                return datos;
            } catch {
                return "Error al leer 'Jornada.txt'";
            }
        }

        /// <summary>
        /// Muestra los datos de la Jornada como cadena de caratéres.
        /// </summary>
        /// <returns>Cadena de caracteres con los datos de la Jornada.</returns>
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CLASE DE {0} POR ", this.Clase);
            sb.AppendFormat(this.Instructor.ToString());
            sb.AppendLine  ("ALUMNOS:");
            foreach(Alumno alumno in this.alumnos) {
                sb.AppendLine(alumno.ToString());
            }
            sb.Append("<------------------------------------------------>\n");
            return sb.ToString();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Verifica si un Alumno participa de la Jornada.
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>Verdadero si el Alumno participa de la Jornada.</returns>
        public static bool operator == (Jornada j, Alumno a) {
            foreach(Alumno alumno in j.alumnos) {
                if (alumno == a)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Verifica si un Alumno participa de la Jornada.
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>Verdadero si el Alumno no participa de la Jornada.</returns>
        public static bool operator != (Jornada j, Alumno a) {
            return !(j == a);
        }

        /// <summary>
        /// Agrega un Alumno a la lista de Alumnos de una Jornada si no está previamente en su lista.
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno a aregar</param>
        /// <returns>Una Jornada con el Alumno agregado.</returns>
        public static Jornada operator + (Jornada j, Alumno a) {
            if (j!=a) {
                j.alumnos.Add(a);
            }
            return j;
        }
        #endregion
    }
}
