using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;
using Excepciones;

namespace EntidadesAbstractas {

    public abstract class Persona {

        private int dni;
        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;

        #region Propiedades
        /// <summary>
        /// Lee o devuelve el DNI de la persona
        /// </summary>
        public int DNI {
            get => this.dni;
            set => this.dni = Persona.ValidarDni(this.Nacionalidad, value);
        }

        /// <summary>
        /// Lee o devuelve el nombre de la persona. Valida al asignar.
        /// </summary>
        public string Nombre {
            get => this.nombre;
            set {
                if (Persona.ValidarNombreApellido(value) != "")
                    this.nombre = value;
            }
        }

        /// <summary>
        /// Lee o devuelve el apellido de la persona. Valida al asignar.
        /// </summary>
        public string Apellido {
            get => this.apellido;
            set {
                if (Persona.ValidarNombreApellido(value) != "")
                    this.apellido = value;
            }
        }

        /// <summary>
        /// Lee o devuelve la nacionalidad de la persona
        /// </summary>
        public ENacionalidad Nacionalidad {
            get => this.nacionalidad;
            set => this.nacionalidad = value;
        }

        /// <summary>
        /// Lee el DNI como una cadena de caracteres.
        /// </summary>
        public string StringToDNI {
            set => this.dni = Persona.ValidarDni(this.nacionalidad, value);
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor para los atributos de Persona
        /// </summary>
        public Persona() {
        }

        /// <summary>
        /// Constructor para los atributos de Persona
        /// </summary>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this() {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor para los atributos de Persona
        /// </summary>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this (nombre, apellido, nacionalidad) {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor para los atributos de Persona
        /// </summary>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad) {
            this.StringToDNI = dni;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Devuelve en formato de texto los datos de la persona.
        /// </summary>
        /// <returns>Una cadena de caracteres que representa los datos de la persona.</returns>
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n", this.Apellido, this.Nombre);
            sb.AppendFormat("NACIONALIDAD: {0}\n", this.Nacionalidad);
            return sb.ToString();
        }

        /// <summary>
        /// Valida el DNI de acuerdo a la nacionalidad.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        /// <param name="dato">DNI de la persona.</param>
        /// <returns>Devuelve el DNI si es válido.</returns>
        static private int ValidarDni(ENacionalidad nacionalidad, int dato) {
            switch (nacionalidad) {
                case ENacionalidad.Argentino : {
                    if (dato > 0 && dato <= 89999999)
                        return dato;
                    else
                        throw new NacionalidadInvalidaException();
                }
                case ENacionalidad.Extranjero : {
                    if (dato > 90000000 && dato <= 99999999)
                        return dato;
                    else
                        throw new NacionalidadInvalidaException();
                }
                default : {
                    throw new NacionalidadInvalidaException();
                }
            }
        }

        /// <summary>
        /// Valida el DNI de acuerdo a la nacionalidad.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        /// <param name="dato">DNI de la persona.</param>
        /// <returns>Devuelve el DNI si es válido.</returns>
        static private int ValidarDni(ENacionalidad nacionalidad, string dato) {
            dato.Trim();
            dato.Replace(".", "");

            if (dato.Length <= 6 || dato.Length > 8 || Regex.Matches(dato, @"[a-zA-Z]").Count > 0)
                throw new DniInvalidoException();
            else
                return Persona.ValidarDni(nacionalidad, Convert.ToInt32(dato));
        }

        /// <summary>
        /// Verifica que un nombre o apellido contenga caracteres válidos.
        /// </summary>
        /// <param name="dato">Nombre o apellido a validar.</param>
        /// <returns>El dato ingresado si es válido o una cadena vacía si no lo es.</returns>
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
        /// <summary>
        /// Valores de nacionalidad utilizados en la clase Persona
        /// </summary>
        public enum ENacionalidad {
            Argentino,  // 0
            Extranjero  // 1
        }
        #endregion
    }
}
