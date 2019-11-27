using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES.SP {

    abstract public class Fruta {
        //Fruta-> _color:string y _peso:double (protegidos); TieneCarozo:bool (prop. s/l, abstracta);
        //constructor con 2 parametros y FrutaToString():string (protegido y virtual, retorna los valores de la fruta)
        protected string _color;
        protected double _peso;



        public abstract bool TieneCarozo {
            get;
        }



        protected Fruta(string color, double peso) {
            this._color = color;
            this._peso = peso;
        }


        protected virtual string FrutaToString() {
            return string.Format("{0} - {1}", this._color, this._peso);
        }
    }
}
