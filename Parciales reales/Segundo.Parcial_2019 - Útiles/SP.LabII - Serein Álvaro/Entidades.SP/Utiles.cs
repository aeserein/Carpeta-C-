using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades.SP
{
    //Crear la siguiente jerarquía de clases:
    //Utiles-> marca:string y precio:double (publicos); PreciosCuidados:bool (prop. s/l, abstracta);
    //constructor con 2 parametros y UtilesToString():string (protegido y virtual, retorna los valores del útil)
    //ToString():string (polimorfismo; reutilizar código)

    [XmlInclude(typeof(Lapiz))]
    public abstract class Utiles {

        public string marca;
        public double precio;



        abstract public bool PreciosCuidados {
            get;
        }

        public Utiles()        {

        }
        public Utiles(string marca, double precio) {
            this.marca = marca;
            this.precio = precio;
        }


        protected virtual string UtilesToString()
        {
            return string.Format("Marca: {0} - Precio: {1}", this.marca, this.precio);
        }
        public override string ToString()
        {
            return this.UtilesToString();
        }
    }
}
