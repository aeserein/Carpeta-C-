using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES.SP {

    public class Banana : Fruta {
        //Banana-> _paisOrigen:string (protegido); Nombre:string (prop. s/l, retornará 'Banana'); 
        //Reutilizar FrutaToString en ToString() (mostrar todos los valores). TieneCarozo->false

        protected string _paisOrigen;

        public string Nombre {
            get { return "Banana"; }
        }
        public double Peso
        {
            get { return base.Peso; }
        }


        public override bool TieneCarozo {
            get { return false; }
        }


        public Banana(string color, double peso, string paisOrigen)
            : base(color, peso) {
            this._paisOrigen = paisOrigen;
        }




        public override string ToString() {
            return string.Format("{0} - {1} - Pais: {2} - Tiene carozo: {3}",
                                 this.Nombre,
                                 base.FrutaToString(),
                                 this._paisOrigen,
                                 this.TieneCarozo);
        }
    }
}
