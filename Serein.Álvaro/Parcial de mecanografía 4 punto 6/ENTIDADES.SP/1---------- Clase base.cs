using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ENTIDADES.SP {
    
    //[XmlInclude(typeof(Derivada_1))]
    abstract public class Base {

        #region VARIABLES PUBLICAS
        public string UN_STRING;
        public double UN_DOBLE;
        #endregion


        #region VARIABLES PRIVADAS
        private string UN_STRING_privado;
        private double UN_DOBLE_privado;

        public string UN_STRING_PRIVADO {
            get => UN_STRING_privado;
            set => UN_STRING_privado = value;
        }
        public double UN_DOBLE_PRIVADO {
            get => UN_DOBLE_privado;
            set => UN_DOBLE_privado = value;
        }
        #endregion


        #region VARIABLES PROTECTED
        protected string UN_STRING_protected;
        protected double UN_DOBLE_protected;

        public string UN_STRING_PROTECTED {
            get => UN_STRING_protected;
            set => UN_STRING_protected = value;
        }
        public double UN_DOBLE_PROTECTED {
            get => UN_DOBLE_protected;
            set => UN_DOBLE_protected = value;
        }
        #endregion


        public abstract bool PROPIEDAD_ABSTRACTA {
            get;
        }


        public Base() { }
        public Base(string UN_STRING, double UN_DOBLE) {
            this.UN_STRING = UN_STRING;
            this.UN_DOBLE = UN_DOBLE;
        } 


        protected string BASE_A_STRING() {
            return string.Format("{0} - {1}", this.UN_STRING, this.UN_DOBLE);
        }
    }
}
