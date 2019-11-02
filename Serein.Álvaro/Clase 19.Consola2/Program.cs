using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Clase_19.Entidades_2;
using System.Xml.Serialization;
using System.IO;

namespace Clase_19.Consola2 {

    class Program {

        static void Main(string[] args) {

            List<Persona> lista = new List<Persona>();

            Persona persona1 = new Persona("Persona1", "PERSONA1", 1);
            Empleado empleado1 = new Empleado("Empleado1", "EMPLEADO1", 1, 11, 1111);
            Alumno alumno1 = new Alumno("Alumno1", "ALUMNO1", 1, 11);
            Persona persona2 = new Persona("Persona2", "PERSONA2", 2);
            Empleado empleado2 = new Empleado("Empleado2", "EMPLEADO2", 2, 22, 2222);
            Alumno alumno2 = new Alumno("Alumno2", "ALUMNO2", 2, 22);

            lista.Add(persona1);
            lista.Add(empleado1);
            lista.Add(alumno1);
            lista.Add(persona2);
            lista.Add(empleado2);
            lista.Add(alumno2);

            try {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Persona>));
                StreamWriter streamWriter = new StreamWriter("lista.xml");
                xmlSerializer.Serialize(streamWriter, lista);
                streamWriter.Close();
            } catch (Exception e) {
                Console.WriteLine(e);
            }

            List<Persona> listaNueva = new List<Persona>();

            try {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Persona>));
                StreamReader streamReader = new StreamReader("lista.xml");
                listaNueva = (List<Persona>)xmlSerializer.Deserialize(streamReader);
                streamReader.Close();

                foreach (Persona p in listaNueva) {
                    Console.WriteLine(p + "\n\n");
                }
            } catch (Exception e) {
                Console.WriteLine(e);
            }

            // Observar contenido del archivo xml
            // Deserializar la lista

            #if DEBUG
            Console.ReadKey();
            #endif
        }
            
    }
}
