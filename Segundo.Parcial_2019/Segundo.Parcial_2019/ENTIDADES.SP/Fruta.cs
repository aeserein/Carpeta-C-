using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace ENTIDADES.SP {

    [XmlInclude(typeof(Manzana))]
    abstract public class Fruta {

        //Fruta-> _color:string y _peso:double (protegidos); TieneCarozo:bool (prop. s/l, abstracta);
        //constructor con 2 parametros y FrutaToString():string (protegido y virtual, retorna los valores de la fruta)
        private string color;
        private double peso;



        public abstract bool TieneCarozo {
            get;
        }
        public string Color {
            get => color;
            set => color = value;
        }
        public double Peso {
            get => peso;
            set => peso = value;
        }

        public Fruta() {

        }

        protected Fruta(string color, double peso) {
            this.Color = color;
            this.Peso = peso;
        }


        protected virtual string FrutaToString() {
            return string.Format("{0} - {1}", this.Color, this.Peso);
        }
    }
}
