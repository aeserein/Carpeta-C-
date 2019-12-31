using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENTIDADES.SP {

    //Crear jerarquía que contenga los siguientes constructores (1 por clase):
    //Banco(nombre)
    //BancoNacional(nombre, pais)
    //BancoProvincial(bancoNacional, provincia)
    //BancoMunicipal(bancoProvincial, municipio)
    //Crear una instancia de cada clase e inicializar los atributos del form _bancoNacional, _bancoProvincial y _bancoMunicipal. 

    public class BancoNacional : Banco {

        protected string pais;

        public string Pais {
            get => pais;
            set => pais = value;
        }

        public BancoNacional(string nombre, string pais) : base(nombre) {
            this.pais = pais;
        }

        public override string Mostrar() {
            return this.Nombre;
        }

        public override string ToString() {
            return string.Format("Pais: {0}", this.Pais);
        }

        public override string Mostrar(Banco banco) {
            return banco.ToString();
        }
    }
}
