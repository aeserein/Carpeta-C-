using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

///////////////////////////////////////////////////////////////////////////

using System.Xml.Serialization;
using System.Xml;
using System.IO;
using Clase_19.Entidades_2;

namespace Clase_19 {

    class Program {

        static void Main(string[] args) {

            Persona persona = new Persona("Vote por", "El Donaldo", 420);
            persona.Apodos.Add("I love China");
            persona.Apodos.Add("Small loan of a million dollars");
            Console.WriteLine(persona);

            #region Crear archivo XML
            try {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Persona));
                // typeof para acceder al tipo de una clase

                StreamWriter streamWriter = new StreamWriter("persona.xml");
                // archivo persona.xml en la carpeta del ejecutable

                //XmlTextWriter xmlTextWriter = new XmlTextWriter("persona.xml", Encoding.UTF8);
                // Este no lo uso. Si no lo comento tira excepción
                // porque "persona.xml" está tomado por el StreamWriter

                xmlSerializer.Serialize(streamWriter, persona);
                // serialize recibe stream, textWriter y xmlWriter

                streamWriter.Close();
                // cierro el constructor de archivos (o pongo todo en un using)

                //xmlTextWriter.Close();
                // cierro el XmlTextWriter
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            #endregion
            #region Leer archivo XML
            try {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Persona));

                XmlTextReader xmlTextReader = new XmlTextReader("persona.xml");

                Persona persona2 = (Persona)xmlSerializer.Deserialize(xmlTextReader);

                xmlTextReader.Close();

                Console.WriteLine(persona2);
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            #endregion

            #region Guardar lista genérica en XML
            List<Persona> lista = new List<Persona>();
            lista.Add(persona);
            lista.Add(new Persona("Chau", "Beccacece", 10));
            lista.Add(new Persona("Trago", "Camote", 69));
            lista.Add(new Persona("Tomás", "Obala", 091218));

            try {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Persona>));
                XmlTextWriter xmlTextWriter = new XmlTextWriter("lista de personas.xml", Encoding.UTF8);
                xmlSerializer.Serialize(xmlTextWriter, lista);
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            #endregion

            Console.ReadKey();
        }
    }
}

/*  Necesita un constructor por defecto
 *  Necesita clase pública y atributos públicos
 *  No escribe variables no públicas -> Solo las escribe si tiene propiedad de lectura y escritura
 *  
 *  El serializador usa el constructor por defecto y las propiedades.
 *  Todo lo que esté fuera de estos está fuera de su alcance
 *  
 *  StreamWriter en System.IO
 *  o
 *  XmlTextWriter en System.Xml.Serialization
 */
