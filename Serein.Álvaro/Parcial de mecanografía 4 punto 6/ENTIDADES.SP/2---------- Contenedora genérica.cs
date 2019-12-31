using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENTIDADES.SP {

    public class Contenedora<T> where T : Base {

        protected List<T> elementos;
        protected int capacidad;


        public List<T> Elementos {
            get { return this.elementos; }
        }
        public int CAPACIDAD {
            get => capacidad;
            set => capacidad = value;
        }
        public double ALGUNA_PROPIEDAD_MÁS {
            get => 1;
        }



        public Contenedora() {
            this.elementos = new List<T>();
        }
        public Contenedora(int capacidad) : this() {
            this.capacidad = capacidad;
        }



        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} - Capacidad: {1} - Cantidad: {2}",
                            typeof(T).Name,
                            this.capacidad,
                            this.Elementos.Count);
            sb.AppendLine();
            foreach (T item in this.elementos) {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }



        public static Contenedora<T> operator +(Contenedora<T> contenedora, T item) {
            if (contenedora.Elementos.Count < contenedora.capacidad) {
                contenedora.Elementos.Add(item);
                return contenedora;
            } else {
                throw new EXCEPCIÓN_PROPIA("----------LA COSA ESTÁ LLENA----------");
            }
        }
    }
}
