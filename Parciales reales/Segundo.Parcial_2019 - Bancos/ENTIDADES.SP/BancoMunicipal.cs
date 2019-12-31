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


    public class BancoMunicipal : BancoProvincial {

        private string municipio;

        public string Municipio { get => municipio; set => municipio = value; }

        public BancoMunicipal(BancoProvincial bancoProvincial, string municipio)
            : base( new BancoNacional(bancoProvincial.Nombre, bancoProvincial.Pais), bancoProvincial.Provincia) {
            this.municipio = municipio;
        }

        public override string Mostrar() {
            return this.Nombre;
        }

        public override string ToString() {
            return string.Format("{0} - Municipio: {1}",
                                 base.ToString(),
                                 this.Municipio);
        }
    }
}
