using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades.Externa;

namespace Clase_23 {

    class PersonaQueHereda : PersonaExterna {

        #region Propiedades
        public string Apellido { get { return base._apellido; } }
        public string Nombre { get { return base._nombre; } }
        public int Edad { get { return base._edad; } }
        public ESexo Sexo { get { return base._sexo; } }
        #endregion

        #region Constructores
        public PersonaQueHereda(string nombre, string apellido, int edad, ESexo sexo)
            : base(nombre, apellido, edad, sexo) {
        }
        #endregion

        public string Mostrar() {
            return String.Format("Persona: {0} {1}, {2}, {3}\n", this.Nombre, this.Apellido, this.Edad, this.Sexo.ToString());
        }
    }
}
