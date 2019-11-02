using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_19.Entidades_2 {

    class Empleado : Persona {
        public int legajo;
        public double sueldo;


        public Empleado(string nombre, string apellido, int edad, int legajo, double sueldo)
            : base(nombre, apellido, edad) {
            this.legajo = legajo;
            this.sueldo = sueldo;
        }


        public override string ToString() {
            return base.ToString() + "\n" +
                   "Legajo: " + this.legajo + "\n" +
                   "Sueldo: " + this.sueldo;
        }
    }
}
