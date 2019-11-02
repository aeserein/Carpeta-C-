using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio_47bis {

    public class Persona {

        private long dni;
        private string nombre;

        #region Propiedades
        public long DNI {
            get {
                return this.dni;
            }
            set {
                this.dni = value;
            }
        }

        public string Nombre {
            get {
                return this.nombre;
            }
            set {
                this.nombre = value;
            }
        }
        #endregion

        #region Constructores
        public Persona(string nombre) {
            this.DNI = 0;
            this.Nombre = nombre;
        }
        public Persona(long dni, string nombre) : this(nombre) {
            this.DNI = dni;
        }
        #endregion

        #region Métodos
        public string MostrarDatos() {
            return "DNI:\t" + this.DNI + "\n" +
                   "Nombre:\t" + this.Nombre + "\n";
        }
        #endregion

        #region Operadores
        public static bool operator ==(Persona p1, Persona p2) {
            return (p1.DNI == p2.DNI && p1.Nombre == p2.Nombre);
        }
        public static bool operator !=(Persona p1, Persona p2) {
            return !(p1 == p2);
        }
        #endregion
    }
}
