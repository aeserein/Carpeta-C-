using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_19.Entidades {

    public class Persona {

        public string nombre;
        public string apellido;
        private int edad;
        private List<String> apodos;

        #region Propiedades
        public int Edad
        {
            get => this.edad;
            set => this.edad = value;
        }

        public List<string> Apodos
        {
            get => apodos;
        }
        #endregion

        #region Constructores
        public Persona()
        {
            this.apodos = new List<string>();
        }

        public Persona(string nombre, string apellido, int edad) : this()
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
        }
        #endregion



        #region Métodos
        public override string ToString()
        {
            return "Nombre: " + this.nombre + " " + this.apellido;
        }
        #endregion
    }
}
