using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_15.Entidades__ModeloDeParcial_ {

    public class Alumno {

        private string _apellido;
        private int _legajo;
        private string _nombre;
        private float _nota;

        #region Propiedades
        public string Apellido {
            get { return this._apellido; }
            set { this._apellido = value; }
        }
        public int Legajo {
            get { return this._legajo; }
            set { this._legajo = value; }
        }
        public string Nombre {
            get { return this._nombre; }
            set { this._nombre = value; }
        }
        public float Nota {
            get { return this._nota; }
            set { this._nota = value; }
        }
        #endregion

        #region Constructores
        public Alumno(string apellido, int legajo, string nombre) {
            this.Apellido = apellido;
            this.Legajo = legajo;
            this.Nombre = nombre;
        }

        ///////////////////////////////// Sobrecargas agregadas

        public Alumno(string apellido, int legajo, string nombre, float nota)
            : this (apellido, legajo, nombre) {
            this.Nota = nota;
        }

        public Alumno(string nombre, string apellido, int legajo)
            : this(apellido, legajo, nombre) {
        }

        public Alumno(int legajo, string nombre, string apellido)
            : this(apellido, legajo, nombre) {
        }

        public Alumno(string nombre, string apellido, float nota, int legajo)
            : this(apellido, legajo, nombre, nota) {
        }
        #endregion

        #region Métodos
        private string Mostrar() {
            return "Apellido y nombre: " + this.Apellido + ", " + this.Nombre +
                   " - Legajo: " + this.Legajo +
                   " - Nota: " + this.Nota + "\n" ;
        }

        public static string Mostrar(Alumno alumno) {
            return alumno.Mostrar();
        }
        #endregion

        #region Operadores
        public static bool operator == (Alumno a1, Alumno a2) {
            return (a1.Legajo == a2.Legajo);
        }

        public static bool operator !=(Alumno a1, Alumno a2)
        {
            return !(a1 == a2);
        }
        #endregion
    }
}
