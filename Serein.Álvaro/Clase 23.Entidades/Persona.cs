using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_23.Entidades {

    public class Persona {

        private string nombre;
        private string apellido;
        private int dni;

        #region Propiedades
        public string Nombre {
            get => nombre;
            set => nombre = value;
        }
        public string Apellido {
            get => apellido;
            set => apellido = value;
        }
        public int Dni {
            get => dni;
            set => dni = value;
        }
        #endregion

        #region Constructores
        public Persona(string nombre, string apellido, int dni) {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Dni = dni;
        }
        #endregion

        #region Métodos
        public string Mostrar() {
            return String.Format("Persona: {0} {1}, {2}\n", this.Nombre, this.Apellido, this.Dni);
        }
        #endregion
    }
}
