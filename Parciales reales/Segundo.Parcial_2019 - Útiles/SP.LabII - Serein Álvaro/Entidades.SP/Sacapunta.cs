using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.SP
{

    //Sacapunta-> deMetal:bool(publico); 
    //Reutilizar UtilesToString en ToString() (mostrar todos los valores).

    public class Sacapunta : Utiles {

        public bool deMetal;

        public Sacapunta(bool deMetal, double precio, string marca)
            : base(marca, precio) {
            this.deMetal = deMetal;
        }

        public override bool PreciosCuidados
        {
            get { return false; }
        }

        public override string ToString()
        {
            return string.Format("{0} - Solo lapiz: {1}",
                                 base.UtilesToString(),
                                 this.deMetal.ToString());
        }
    }
}
