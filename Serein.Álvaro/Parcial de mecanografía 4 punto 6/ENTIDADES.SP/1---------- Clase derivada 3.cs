using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace ENTIDADES.SP {

    public class Derivada_3 : Base {

        public string UNA_VARIABLE_______VER_TIPO_Y_MOD;


        public override bool PROPIEDAD_ABSTRACTA {
            get { throw new NotImplementedException(); }
        }


        public Derivada_3(string STRING_BASE, double DOUBLE_BASE, string STRING_DE_THIS)
            : base(STRING_BASE, DOUBLE_BASE) {
            this.UNA_VARIABLE_______VER_TIPO_Y_MOD = STRING_DE_THIS;
        }


        public override string ToString() {
            return string.Format("{0} - {1}",
                                 base.BASE_A_STRING(),
                                 this.UNA_VARIABLE_______VER_TIPO_Y_MOD);
        }
    }
}
