﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;
using System.Xml;

namespace Clase_19.Entidades_2 {

    public class Auto : IXML {

        public string marca;
        public double precio;

        #region Métodos
        public override string ToString() {
            return this.marca + " - " + this.precio;
        }
        #endregion

        #region IXML
        public bool Guardar(string path) {

            try {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Auto));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(path, Encoding.UTF8);
                xmlSerializer.Serialize(xmlTextWriter, this);
                xmlTextWriter.Close();
                return true;
            } catch {
                return false;
            }
        }

        public bool Leer(string path, out object obj) {
            try {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Auto));
                XmlTextReader xmlTextReader = new XmlTextReader(path);
                obj = xmlSerializer.Deserialize(xmlTextReader);
                xmlTextReader.Close();
                return true;
            } catch {
                obj = null;
                return false;
            }
        }
        #endregion

    }
}
