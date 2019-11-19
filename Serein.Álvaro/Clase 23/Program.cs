using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Clase_23.Entidades;
//using Entidades.Externa;
using Entidades.Externa.Sellada;

namespace Clase_23 {

    class Program {

        static void Main(string[] args) {

            Persona persona = new Persona("Nombre", "Apellido", 1111111);
            Console.Write($"¿Cómo hago para mostrar por consola los datos de la persona cuando son privados?");
            Console.WriteLine("        1 - Agregando propiedad");
            Console.WriteLine("        2 - Haciendo un getter\n");

            Console.WriteLine("Persona: {0} {1}, {2}", persona.Nombre, persona.Apellido, persona.Dni);
            Console.WriteLine("Por método: " + persona.Mostrar());

            /////////////////////////////////////// Agrego el .dll ya compilado y que no puedo editar.

            Console.WriteLine($"¿Cómo hago para mostrar por consola los datos de una persona en un dll?");
            Console.WriteLine("        1 - Creo una clase y la heredo");
            //PersonaQueHereda personaQueHereda = new PersonaQueHereda("Nombre", "Apellido", 11, ESexo.Masculino);

            //Console.WriteLine("Persona que hereda: " + personaQueHereda.Mostrar());

            //Comentado porque agregué otra liberia con el mismo nombre

            /////////////////////////////////////// Agrego el .dll con una clase sealed que no puedo heredar
            Console.WriteLine();
            Console.WriteLine($"¿Cómo hago para mostrar por consola los datos de una persona sealed en un dll?");
            Console.WriteLine("        1 - Creo una clase estática y la uso ahí");

            PersonaExternaSellada personaExternaSellada = new PersonaExternaSellada("Nombre", "Apellido", 11, ESexo.Masculino);
            Console.WriteLine(personaExternaSellada.ObtenerInfo());

            Console.WriteLine();
            Object obj = new Object();
            Console.WriteLine("¿obj es nulo? -> " + obj.EsNulo());
            Console.WriteLine("¿personaExtendidaSellada es nulo? -> " + personaExternaSellada.EsNulo());

            List<Persona> lista = new List<Persona>();
            lista = persona.ObtenerListadoBD();
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Imprimo lista");
            foreach (Persona p in lista) {
                Console.WriteLine(p.Mostrar());
            }
            Console.ReadKey();
        }
    }
}

/*  La clase debe ser pública y estática
 *  Los métodos también deben ser públicos y estaticos 
 * 
 */