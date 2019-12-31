using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.SP
{

    //Goma-> soloLapiz:bool(publico); PreciosCuidados->true; 
    //Reutilizar UtilesToString en ToString() (mostrar todos los valores).
    public class Goma : Utiles {

        public bool soloLapiz;



        public override bool PreciosCuidados
        {
            get { return true; }
        }


        public Goma(bool soloLapiz, string marca, double precio)
            : base (marca, precio) {
            this.soloLapiz = soloLapiz;
        }


        public override string ToString()
        {
            return string.Format("{0} - Solo lapiz: {1}",
                                 base.UtilesToString(),
                                 this.soloLapiz.ToString());
        }
    }
}
