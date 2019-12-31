using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ENTIDADES.SP {

    //Crear jerarquía que contenga los siguientes constructores (1 por clase):
    //Banco(nombre)
    //BancoNacional(nombre, pais)
    //BancoProvincial(bancoNacional, provincia)
    //BancoMunicipal(bancoProvincial, municipio)
    //Crear una instancia de cada clase e inicializar los atributos del form _bancoNacional, _bancoProvincial y _bancoMunicipal. 

    //Agregar en Banco el método Mostrar():string y Mostrar(Banco):string, ambos abstractos.
    //El método que no recibe parámetros, retornará el nombre, mientras que el otro
    //retornará todas las características de la instancia que recibe como parametro. REUTILIZAR CODIGO.

    //[XmlInclude(typeof(Derivada_1))]
    abstract public class Banco {

        protected string nombre;

        public string Nombre {
            get => nombre;
            set => nombre = value;
        }

        public Banco() { }

        public Banco(string nombre) {
            this.nombre = nombre;
        }

        public abstract string Mostrar();
        public abstract string Mostrar(Banco banco);
    }
}
