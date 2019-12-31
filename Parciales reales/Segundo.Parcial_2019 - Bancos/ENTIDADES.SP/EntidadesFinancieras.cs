using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENTIDADES.SP {

    //Generar la clase genérica EntidadesFinancieras. Dicha clase tendrá el atributo _elementos:List del tipo genérico.
    //(este sólo se podrá inicializar en el constructor por defecto, que además será privado)
    //y _capacidad:int (generar un constructor que lo reciba como parámetros). Realizar validaciones necesarias
    //Realizar el método Add, que permite agregar un elemento a la colección. 
    //Cada elemento par agregado en la clase EntidadesFinacieras, disparará un evento (ElementosParesEvent).
    //Asociar el manejador del evento anterior a un método de instancia del formulario. 
    //Mostrar en dicho manejador las características por MessageBox.
    public class EntidadesFinancieras<T> where T : Banco {

        private List<T> _elementos;
        private int _capacidad;

        public event ElementosParesEvent ElementosParesEvent;


        public List<T> Elementos {
            get { return this._elementos; }
        }



        public EntidadesFinancieras() {
            this._elementos = new List<T>();
        }
        public EntidadesFinancieras(int capacidad) : this() {
            if (capacidad>0)
                this._capacidad = capacidad;
        }

        public void Add(T elemento) {
            if (this.Elementos.Count < this._capacidad) {
                this.Elementos.Add(elemento);

                if ( (this.Elementos.Count % 2) == 0) {
                    this.ElementosParesEvent(elemento,null);
                }
            }
        }
      
    }
}
