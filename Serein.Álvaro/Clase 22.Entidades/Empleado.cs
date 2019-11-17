using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_22.Entidades {

    public class Empleado {

        private string nombre;
        private string apellido;
        private int legajo;
        private double sueldo;
        public event Delegado_LimiteSueldo limiteSueldo;
        public event Delegado_ConEventArgs limiteSueldoMejorado;

        #region Propiedades
        public string Nombre {
            get => nombre;
            set => nombre = value;
        }
        public string Apellido {
            get => apellido;
            set => apellido = value;
        }
        public int Legajo {
            get => legajo;
            set => legajo = value;
        }
        public double Sueldo {
            get => sueldo;
            set {
                if (value>30000) {
                    try {
                        EmpleadoEventArgs eea = new EmpleadoEventArgs();
                        eea.SueldoAsignar = value;
                        this.limiteSueldoMejorado(this, eea);
                    } catch { }

                } else if (value > 18000) {
                    try {
                        this.limiteSueldo(value, this);
                    } catch { }

                } else {
                    sueldo = value;
                }
            }
        }
        #endregion

        #region Constructores
        public Empleado(string nombre, string apellido, int legajo) {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Legajo = legajo;
        }
        #endregion

        #region Métodos
        public override string ToString() {
            return "Apellido y nombre: " + this.Apellido + ", " + this.Nombre + "\n" +
                   "Legajo: " + this.Legajo + "\n" +
                   "Sueldo: " + this.Sueldo;
        }
        #endregion
    }
}
