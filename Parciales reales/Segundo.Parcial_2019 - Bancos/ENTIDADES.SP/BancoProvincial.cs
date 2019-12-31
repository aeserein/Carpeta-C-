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

    public class BancoProvincial : BancoNacional {

        private string provincia;

        public string Provincia { get => provincia; set => provincia = value; }

        public BancoProvincial(BancoNacional bancoNacional, string provincia)
            : base(bancoNacional.Nombre, bancoNacional.Pais) {
            this.provincia = provincia;
        }

        public override string Mostrar() {
            return this.Nombre;
        }

        public override string ToString() {
            return string.Format("{0} - Provincia: {1}",
                                 base.ToString(),
                                 this.Provincia);
        }
    }
}
