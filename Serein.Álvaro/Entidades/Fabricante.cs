using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades {

    public class Fabricante {

        private string marca;
        private EPais pais;

        #region Constructores
        public Fabricante(string marca, EPais pais) {
            this.marca = marca;
            this.pais = pais;
        }
        #endregion

        #region Operadores
        public static bool operator ==(Fabricante a, Fabricante b) {
            return (a.marca == b.marca &&
                    a.pais == b.pais);
        }
        public static bool operator !=(Fabricante a, Fabricante b) {
            return !(a == b);
        }
        public static implicit operator String(Fabricante f) {
            return f.marca + " - " + f.pais.ToString();
        }
        #endregion
    }
}
