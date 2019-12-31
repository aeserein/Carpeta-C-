using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.SP
{

    //Si el precio total de la cartuchera supera los 85 pesos, se disparará el evento EventoPrecio. 
    //Diseñarlo (de acuerdo a las convenciones vistas) en la clase cartuchera. 
    //Adaptar la sobrecarga del operador +, para que lance el evento, según lo solicitado.
    //Crear el manejador necesario para que, una vez capturado el evento, se imprima en un archivo de texto: 
    //la fecha (con hora, minutos y segundos) y el total de la cartuchera (en un nuevo renglón). 
    //Se deben acumular los mensajes. El archivo se guardará con el nombre tickets.log en la carpeta 'Mis documentos' del cliente.
    //El manejador de eventos (c_gomas_EventoPrecio) invocará al método (de clase) 
    //ImprimirTicket (se alojará en la clase Ticketeadora), que retorna un booleano indicando si se pudo escribir o no
    public class Cartuchera<T> where T : Utiles {
        protected int capacidad;
        protected List<T> elementos;

        public delegate void EventoPrecio(object sender, EventArgs e);
        public event EventoPrecio eventoPrecio;

        #region Propiedades
        public List<T> Elementos {
            get { return this.elementos; }
        }
        public double PrecioTotal {
            get {
                double precio=0;
                foreach (Utiles util in this.Elementos)
                {
                    precio += util.precio;
                }
                return precio;
            }
        }
        #endregion

        #region Constructores
        public Cartuchera() {
            this.elementos = new List<T>();
        }
        public Cartuchera(int capacidad) : this() {
            this.capacidad = capacidad;
        }
        #endregion

        #region Métodos
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Tipo: {0} - Capacidad: {1} - Cantidad: {2} - Precio total - {3}",
                            typeof(T).Name, this.capacidad, this.Elementos.Count, this.PrecioTotal);
            sb.AppendLine();
            foreach (Utiles util in this.Elementos) {
                sb.AppendLine(util.ToString());
            }
            return sb.ToString();
        }
        #endregion

        #region Operadores
        public static Cartuchera<T> operator + (Cartuchera<T> cartuchera, T util)
        {
            if (cartuchera.Elementos.Count < cartuchera.capacidad) {
                cartuchera.Elementos.Add(util);

                if (cartuchera.PrecioTotal > 85) {
                    try {
                        cartuchera.eventoPrecio(null, null);
                    } catch {
                    }

                }

                return cartuchera;
            } else {
                throw new CartucheraLlenaException("La cartuchera ya está llena.");
            }            
        }
        #endregion
    }
}
