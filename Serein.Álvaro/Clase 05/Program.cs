using System;
using Clase05.Entidades;

namespace Clase_05 {

  class Program {

    static void Main(string[] args) {

      Console.WriteLine("Clase 5. Sobrecarga de operadores y casteos. Enumeradores\n");
      Tinta tinta = new Tinta();
      Pluma pluma = new Pluma();

      string unString = (string)tinta;
      Console.WriteLine(unString);

      pluma += tinta;
      unString = pluma;

      
      Console.WriteLine(pluma);

      Console.ReadKey();

    }

  }

}

/* Sobrecarga de operadores
 *
 * Operadores binarios (x+y;) y unarios (x++;)
 *
 * [mod. visibilidad] static [tipo dato] operator [signo (ej: +)] (arg/s) { }
 *     ^ public                ^return                             ^binario o unario (1 o 2 params)
 *
 *  Uno de los 3 tipos tienen que ser del tipo de la clase (el return o el/los argumentos)
 *  Adentro funciona como cualquier otro método
 *
 *
 *  Sobrecarga de casteos
 *
 *  [mod visibilidad] static [explicit/implicit] operator [tipo dato] (arg) { }
 *
 *  Uno de los dos tipos (return o parámetro) debe ser del tipo clase que contiene esta sobrecarga
 *
 *
 *
 *  Enumerado
 *  
 *  Va en el mismo namespace que otras funciones, pero en otro archivo para organizar
 *  Agregar -> Archivo de código al proyecto (no a la solucíón)
 *  Empiezan con E mayúscula
 * 
 */
