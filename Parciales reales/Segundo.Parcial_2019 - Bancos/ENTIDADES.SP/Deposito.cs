using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Serialization;

namespace ENTIDADES.SP {

    //Crear dos objetos de tipo Deposito, cada uno de estos objetos contiene un Array de la clase Producto.
    //Un constructor por default (inicializa en 3 productos) y una sobrecarga que reciba la cantidad de productos 
    //del depósito (REUTILIZAR CODIGO). 
    //La clase Producto tiene dos atributos: nombre y stock y un único constructor.
    //Se debe poder sumar los Array de los dos depósitos (con la sobrecarga de un operador en la clase Deposito) y guardar 
    //el valor que retorna en un Array de Productos, recordar que si un producto está en los dos Arrays, 
    //se debe sumar el stock y no agregar dos veces al mismo producto.
    //Mostrar el contenido del array resultante (nombre y stock)

    [XmlInclude(typeof(DepositoHeredado))]
    public class Deposito {

        public Producto[] productos;


        public Deposito() : this(3) {
        }
        public Deposito(int i) {
            this.productos = new Producto[i];
        }

        public static Producto[] operator + (Deposito d1, Deposito d2) {

            List<Producto> lista = new List<Producto>();
            bool encontro;

            for(int i = 0; i<d1.productos.Length; i++) {

                encontro = false;

                for(int f = 0; f<lista.Count; f++) {

                    if (lista[f].nombre == d1.productos[i].nombre) {
                        lista[f].stock += d1.productos[i].stock;
                        encontro = true;
                    }
                }

                if (!encontro) {
                    lista.Add(d1.productos[i]);
                }

            }

            for (int i = 0; i < d2.productos.Length; i++) {

                encontro = false;

                for (int f = 0; f < lista.Count; f++) {

                    if (lista[f].nombre == d2.productos[i].nombre) {
                        lista[f].stock += d2.productos[i].stock;
                        encontro = true;
                    }
                }

                if (!encontro) {
                    lista.Add(d2.productos[i]);
                }

            }

            return lista.ToArray();
        }
    }
}