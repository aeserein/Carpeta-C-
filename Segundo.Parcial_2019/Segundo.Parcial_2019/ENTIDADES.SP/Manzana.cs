using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;
using System.IO;

namespace ENTIDADES.SP {

    
    public class Manzana : Fruta, ISerializar, IDeserializar {

        //Manzana-> _provinciaOrigen:string (protegido); Nombre:string (prop. s/l, retornará 'Manzana'); 
        //Reutilizar FrutaToString en ToString() (mostrar todos los valores). TieneCarozo->true

        private string provinciaOrigen;

        public string Nombre {
            get { return "Manzana"; }
        }
        public double Peso
        {
            get { return base.Peso; }
        }

        public override bool TieneCarozo {
            get { return true; }
        }

        public string ProvinciaOrigen {
            get => provinciaOrigen;
            set => provinciaOrigen = value;
        }

        public Manzana() {

        }
        public Manzana(string color, double peso, string provinciaOrigen)
            : base(color, peso) {
            this.ProvinciaOrigen = provinciaOrigen;
        }

        public override string ToString() {
            return string.Format("{0} - {1} - Provincia: {2} - Tiene carozo: {3}",
                                 this.Nombre,
                                 base.FrutaToString(),
                                 this.ProvinciaOrigen,
                                 this.TieneCarozo);
        }

        public bool Xml(string archivo) {

            try {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Manzana));
                StreamWriter streamWriter = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + archivo);
                xmlSerializer.Serialize(streamWriter, this);
                streamWriter.Close();
                return true;
            } catch (Exception) {
                return false;
            }
        }

        bool IDeserializar.Xml(string archivo, out Fruta fruta) {
            XmlSerializer xmlSerializer;
            StreamReader streamReader = null;

            Manzana aux;

            try {
                xmlSerializer = new XmlSerializer(typeof(Manzana));
                streamReader = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + archivo);
                aux = (Manzana) xmlSerializer.Deserialize(streamReader);
                fruta = aux;
                streamReader.Close();
                return true;
            }
            catch (Exception) {
                fruta = default(Manzana);
                return false;
            }
        }
    }
}
