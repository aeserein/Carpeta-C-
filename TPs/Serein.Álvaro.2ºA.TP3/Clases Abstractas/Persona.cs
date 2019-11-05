using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;
using Excepciones;

namespace EntidadesAbstractas {

    public abstract class Persona {

        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        #region Propiedades
        public string Apellido {
            get => this.apellido;
            set => this.apellido = value;
        }
        public int DNI {
            get => this.dni;
            set => this.dni = Persona.ValidarDni(this.Nacionalidad, value);
        }
        public ENacionalidad Nacionalidad {
            get => this.nacionalidad;
            set => this.nacionalidad = value;
        }
        public string Nombre {
            get => this.nombre;
            set {
                if (Persona.ValidarNombreApellido(value) != "")
                    this.nombre = value;
            }
        }
        public string StringToDNI {
            set => this.dni = Persona.ValidarDni(this.nacionalidad, value);
        }
        #endregion

        #region Constructores
        public Persona() {
        }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this (nombre, apellido, nacionalidad) {
            this.DNI = dni;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad) {
            this.StringToDNI = dni;
        }
        #endregion

        #region Métodos
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Apellido y nombre: {0}, {1}\n", this.Apellido, this.Nombre);
            sb.AppendFormat("Nacionalidad: {0}\n", this.Nacionalidad);
            sb.AppendFormat("DNI: {0}", this.DNI);
            return sb.ToString();
        }
        static private int ValidarDni(ENacionalidad nacionalidad, int dato) {
            switch (nacionalidad) {
                case ENacionalidad.Argentino : {
                    if (dato > 0 && dato <= 89999999)
                        return dato;
                    else
                        goto Excepción;                        
                }
                case ENacionalidad.Extranjero : {
                    if (dato > 90000000 && dato <= 99999999)
                        return dato;
                    else
                        goto Excepción;
                }
            }

            Excepción:
                throw new NacionalidadInvalidaException();
        }
        static private int ValidarDni(ENacionalidad nacionalidad, string dato) {
            dato.Trim();
            dato.Replace(".", "");

            if (dato.Length <= 6 ||
                dato.Length > 8 ||
                Regex.Matches(dato, @"[a-zA-Z]").Count > 0)
                throw new DniInvalidoException();
            else
                return Persona.ValidarDni(nacionalidad, Convert.ToInt32(dato));
        }
        static private string ValidarNombreApellido(string dato) {
            dato.Trim();
            if (dato.All(Char.IsLetter)) {
                Char.ToUpper(dato[0]);
                for (short f = 0; f < dato.Length; f++) {
                    if (dato[f]==' ') {
                        Char.ToUpper(dato[f+1]);
                    }
                }
                return dato;
            } else {
                return "";
            }
        }
        #endregion

        #region Enumerados
        public enum ENacionalidad {
            Argentino,  // 0
            Extranjero  // 1
        }
        #endregion
    }
}
