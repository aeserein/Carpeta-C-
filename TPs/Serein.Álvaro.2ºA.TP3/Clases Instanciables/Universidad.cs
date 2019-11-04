using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables {

    public class Universidad {

        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;

        #region Propiedades
        public List<Alumno> Alumnos {
            get => alumnos;
            set => alumnos = value;
        }
        public List<Jornada> Jornadas {
            get => jornadas;
            set => jornadas = value;
        }
        public List<Profesor> Profesores {
            get => profesores;
            set => profesores = value;
        }
        public Jornada this[int i] {
            get => jornadas[i];
            set => jornadas[i] = value;
        }
        #endregion

        #region Constructores
        public Universidad() {
            this.alumnos = new List<Alumno>();
            this.jornadas = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
        #endregion

        #region Métodos
        public bool Guardar(Universidad uni) {
            throw new NotImplementedException();
        }
        public Universidad Leer() {
            throw new NotImplementedException();
        }
        private static string MostrarDatos(Universidad uni) {
            throw new NotImplementedException();
        }
        public override string ToString() {
            throw new NotImplementedException();
        }
        #endregion

        #region Operadores
        public static bool operator == (Universidad g, Alumno a) {
            throw new NotImplementedException();
        }
        public static bool operator != (Universidad g, Alumno a) {
            return !(g == a);
        }
        public static bool operator == (Universidad g, Profesor a) {
            throw new NotImplementedException();
        }
        public static bool operator != (Universidad g, Profesor a) {
            return !(g == a);
        }
        public static Profesor operator ==(Universidad u, EClases clase) {
            throw new NotImplementedException();
        }
        public static Profesor operator !=(Universidad u, EClases clase) {
            throw new NotImplementedException();
        }
        #endregion

        #region Enumerados
        public enum EClases {
            Programación,   // 0
            Laboratorio,    // 1
            Legislación,    // 2
            SPD             // 3
        }
        #endregion
    }
}