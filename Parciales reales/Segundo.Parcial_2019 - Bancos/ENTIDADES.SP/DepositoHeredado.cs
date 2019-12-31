using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Serialization;
using System.IO;

namespace ENTIDADES.SP {

    //Crear la clase DepositoHeredado, que derive de Desposito y que implemente: 
    //ISerializar(Xml(string):bool) de forma implicita y
    //IDeserializar(Xml(string, out Deposito):bool) de forma explícita
    public class DepositoHeredado : Deposito, ISerializar, IDeserializar {
        public bool Xml(string path) {
            try {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(DepositoHeredado));
                StreamWriter streamWriter = new StreamWriter(path);
                xmlSerializer.Serialize(streamWriter, this);
                streamWriter.Close();
                return true;
            } catch (Exception) {
                return false;
            }
        }

        bool IDeserializar.Xml(string path, out DepositoHeredado deposito) {
            try {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(DepositoHeredado));
                StreamReader streamReader = new StreamReader(path);
                deposito = (DepositoHeredado) xmlSerializer.Deserialize(streamReader);
                return true;
            } catch (Exception) {
                deposito = default;
                return false;
            }
        }
    }
}