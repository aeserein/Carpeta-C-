using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades {

    public class Concesionaria {

        private int capacidad;
        private List<Vehiculo> vehiculos;

        #region Propiedades
        public double PrecioDeAutos {
            get { return this.ObtenerPrecio(EVehiculo.PrecioDeAutos); }
        }
        public double PrecioDeMotos {
            get { return this.ObtenerPrecio(EVehiculo.PrecioDeMotos); }
        }
        public double PrecioTotal {
            get { return this.ObtenerPrecio(EVehiculo.PrecioTotal); }
        }
        #endregion

        #region Constructores
        private Concesionaria() {
            this.vehiculos = new List<Vehiculo>();
        }
        private Concesionaria(int capacidad) : this() {
            this.capacidad = capacidad;
        }
        #endregion

        #region Métodos
        public static string Mostrar(Concesionaria c) {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Capacidad: " + c.capacidad);
            sb.AppendLine("Total por autos: " + c.PrecioDeAutos);
            sb.AppendLine("Total por motos: " + c.PrecioDeMotos);
            sb.AppendLine("Total: " + c.PrecioTotal);
            sb.AppendLine("**************************************************");
            sb.AppendLine("Listado de vehículos");
            sb.AppendLine("**************************************************");
            foreach(Vehiculo v in c.vehiculos) {
                sb.AppendLine(v.ToString());
                sb.AppendLine("");
            }
            return sb.ToString();
        }
        private double ObtenerPrecio(EVehiculo tipoVehiculo) {
            double acumulador = 0;
            foreach (Vehiculo v in this.vehiculos) {

                switch (tipoVehiculo) {
                    case EVehiculo.PrecioDeAutos: {
                        if (v is Auto)
                            acumulador += (Single)(Auto)v;
                        break;
                    }
                    case EVehiculo.PrecioDeMotos: {
                        if (v is Moto)
                            acumulador += (Moto)v;
                        break;
                    }
                    case EVehiculo.PrecioTotal: {
                        if (v is Auto)
                            acumulador += (Single)(Auto)v;
                        else if (v is Moto)
                            acumulador += (Moto)v;
                        break;
                    }
                }
            }
            return acumulador;
        }
        #endregion

        #region Operadores
        public static implicit operator Concesionaria(int capacidad) {
            return new Concesionaria(capacidad);
        }
        public static bool operator ==(Concesionaria c, Vehiculo v) {
            foreach (Vehiculo aux in c.vehiculos) {
                if (v is Auto && aux is Auto) {
                    if ((Auto)aux == (Auto)v)
                        return true;
                } else if (v is Moto && aux is Moto) {
                    if ((Moto)aux == (Moto)v)
                        return true;
                }
            }
            return false;
        }
        public static bool operator !=(Concesionaria c, Vehiculo v) {
            return !(c == v);
        }
        public static Concesionaria operator +(Concesionaria c, Vehiculo v) {
            if (c.vehiculos.Count < c.capacidad) {
                if (c != v) {
                    c.vehiculos.Add(v);
                } else {
                    Console.WriteLine("El vehículo ya está en la concesionaria!!!");
                }
            } else {
                Console.WriteLine("No hay más lugar en la concesionaria!!!");
            }
            return c;
        }
        #endregion
    }
}
