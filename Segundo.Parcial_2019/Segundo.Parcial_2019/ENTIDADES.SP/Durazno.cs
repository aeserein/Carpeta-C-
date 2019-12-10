using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES.SP {

    public class Durazno : Fruta {

        //Durazno-> _cantPelusa:int (protegido); Nombre:string (prop. s/l, retornará 'Durazno'); 
        //Reutilizar FrutaToString en ToString() (mostrar todos los valores). TieneCarozo->true

        protected int _cantPelusa;

        public string Nombre {
            get { return "Durazno"; }
        }
        public double Peso
        {
            get { return base.Peso; }
        }

        public override bool TieneCarozo {
            get { return true; }
        }


        public Durazno(string color, double peso, int pelusa)
            : base(color, peso) {
            this._cantPelusa = pelusa;
        }




        public override string ToString() {
            return string.Format("{0} - {1} - Pelusa: {2} - Tiene carozo: {3}",
                                 this.Nombre,
                                 base.FrutaToString(),
                                 this._cantPelusa,
                                 this.TieneCarozo);
        }
    }
}
