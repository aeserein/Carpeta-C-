using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;
using System.IO;

namespace ModeloParcial2.Archivo {

    public class Xml<T> : IArchivo<T> {

        public void Guardar(string archivo, T datos) {

            XmlSerializer xmlSerializer;
            StreamWriter streamWriter = null;

            try {
                xmlSerializer = new XmlSerializer(typeof(T));
                streamWriter = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + archivo + ".xml");
                xmlSerializer.Serialize(streamWriter, datos);
            } catch (Exception e) {
                throw;
            } finally {
                streamWriter.Close();
            }
        }

        public void Leer(string archivo, out T datos) {
            XmlSerializer xmlSerializer;
            StreamReader streamReader = null;

            try {
                xmlSerializer = new XmlSerializer(typeof(T));
                streamReader = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + archivo + ".xml");
                datos = (T)xmlSerializer.Deserialize(streamReader);
            } catch (Exception e) {
                throw;
            } finally {
                streamReader.Close();
            }
        }
    }
}
