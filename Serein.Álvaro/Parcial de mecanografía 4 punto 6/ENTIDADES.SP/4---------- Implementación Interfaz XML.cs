using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace ENTIDADES.SP {

    class Implementación_Interfaz_XML : ISerializar, IDeserializar {

        public bool Xml(string archivo) {
            try {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Derivada_1));
                StreamWriter streamWriter = new StreamWriter(  /* VER PATH */  archivo);
                //  DESCOMENTAR  xmlSerializer.Serialize(streamWriter, this);
                streamWriter.Close();
                return true;
            } catch (Exception) {
                return false;
            }
        }

        bool IDeserializar.Xml(string archivo, out Base NOMBRE_DE_BASE) {
            try {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Derivada_1));
                StreamReader streamReader = new StreamReader(  /* VER PATH */  archivo);
                NOMBRE_DE_BASE = (Base) xmlSerializer.Deserialize(streamReader);
                return true;
            } catch (Exception) {
                NOMBRE_DE_BASE = default;
                return false;
            }
        }
    }
}
