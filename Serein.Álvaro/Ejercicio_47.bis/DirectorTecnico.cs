using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio_47bis { 

    public class DirectorTecnico : Persona {

        private DateTime fechaNacimiento;

        #region Constructores
        private DirectorTecnico(string nombre) : base(nombre) {
            this.fechaNacimiento = DateTime.Today;
        }
        public DirectorTecnico(string nombre, DateTime fechaNacimiento) : base(nombre) {
            this.fechaNacimiento = fechaNacimiento;
        }
        #endregion

        #region Métodos
        new public string MostrarDatos() {
            string s;
            s = base.MostrarDatos();
            s += "Fecha de Nacimiento: " + this.fechaNacimiento;
            return s;
        }
        #endregion

        #region Operadores
        /*
        public static bool operator == (DirectorTecnico dt1, DirectorTecnico dt2) {
            return (dt1.DNI == dt2.DNI && dt1.Nombre == dt2.Nombre);
        }
        public static bool operator !=(DirectorTecnico dt1, DirectorTecnico dt2) {
            return !(dt1 == dt2);
        }
        */

        // Por consigna me pide operadores == y != en DT y Jugador,
        // pero son iguales y usan variables de persona.
        // Los muevo a persona para que los hereden DT y Jugador.
        #endregion
    }
}
