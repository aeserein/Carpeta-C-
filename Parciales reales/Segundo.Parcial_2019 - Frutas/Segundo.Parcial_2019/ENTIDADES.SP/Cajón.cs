using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;
using System.IO;

namespace ENTIDADES.SP {

    //Si el precio total del cajon supera los 55 pesos, se disparará el evento EventoPrecio. 
    //Diseñarlo (de acuerdo a las convenciones vistas) en la clase cajon. 
    //Crear el manejador necesario para que se imprima en un archivo de texto: 
    //la fecha (con hora, minutos y segundos) y el total del precio del cajón en un nuevo renglón.

    

    public class Cajon<T> : ISerializar where T : Fruta {

        //Crear la clase Cajon<T>
        //atributos: _capacidad:int, _elementos:List<T> y _precioUnitario:double (todos protegidos)             
        //Propiedades
        //Elementos:(sólo lectura) expone al atributo de tipo List<T>.
        //PrecioTotal:(sólo lectura) retorna el precio total del cajón (precio * cantidad de elementos).
        //Constructor
        //Cajon(), Cajon(int), Cajon(double, int); 
        //El por default: es el único que se encargará de inicializar la lista.
        //Métodos
        //ToString: Mostrará en formato de tipo string, la capacidad, la cantidad total de elementos, el precio total 
        //y el listado de todos los elementos contenidos en el cajón. Reutilizar código.
        //Sobrecarga de operador
        //(+) Será el encargado de agregar elementos al cajón, siempre y cuando no supere la capacidad del mismo.

        protected List<T> _elementos;
        private int capacidad;
        private double precioUnitario;

        public delegate void EventoPrecio(double precio);
        public event EventoPrecio eventoPrecio;

        #region Propiedades
        public List<T> Elementos {
            get { return this._elementos; }
        }
        public double PrecioTotal {
            get { return (this.PrecioUnitario * this.Elementos.Count); }
        }

        public int Capacidad {
            get => capacidad;
            set => capacidad = value;
        }
        public double PrecioUnitario {
            get => precioUnitario;
            set => precioUnitario = value;
        }
        #endregion

        #region Constructor
        public Cajon() {
            this._elementos = new List<T>();
        }
        public Cajon(int capacidad) : this() {
            this.Capacidad = capacidad;
        }
        public Cajon(double precioUnitario, int capacidad) : this(capacidad) {
            this.PrecioUnitario = precioUnitario;
        }
        #endregion

        #region Métodos
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Capacidad: {0} - Cantidad: {1} - Precio: {2}",
                            this.Capacidad,
                            this.Elementos.Count,
                            this.PrecioTotal);
            sb.AppendLine();
            foreach(T fruta in this.Elementos) {
                sb.AppendLine(fruta.ToString());
            }
            return sb.ToString();
        }
        #endregion

        #region Operador

        //Crear el manejador necesario para que se imprima en un archivo de texto: 
        //la fecha (con hora, minutos y segundos) y el total del precio del cajón en un nuevo renglón.
        public static Cajon<T> operator +(Cajon<T> cajon, T fruta) {
            if (cajon.Elementos.Count < cajon.Capacidad) {
                cajon.Elementos.Add(fruta);
                
                if (cajon.PrecioTotal > 55) {
                    try {
                        cajon.eventoPrecio(cajon.PrecioTotal);
                    }
                    catch {
                    }
                    
                }

                return cajon;
            } else {
                throw new CajonLlenoException("No queda más lugar en el cajón");
            }
            
        }
        #endregion


        #region ISerializar
        public bool Xml(string archivo) {

            XmlSerializer xmlSerializer;
            StreamWriter streamWriter = null;

            try {
                xmlSerializer = new XmlSerializer(typeof(Cajon<T>));
                streamWriter = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + archivo);
                xmlSerializer.Serialize(streamWriter, this);
                streamWriter.Close();
                return true;
            } catch (Exception) {
                return false;
            }
        }
        #endregion
    }
}
