using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ExcepcionNueva;

namespace Clase_16_Archivos {

  class Program {

    static void Main(string[] args) {

      try {
        Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
        Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.MyComputer));
        StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\miArchivo.txt", false);
        // Si no existe el archivo, lo crea
        // No crea carpetas
        // Parámetro boolean "append" para agregar o sobreescrbir

        sw.WriteLine("Hola mundo");
        sw.WriteLine(DateTime.Now);
        sw.Close();

      } catch (DirectoryNotFoundException e) {  // Los itpos de excepciones se encuentran rompiéndolo a propósito
        Console.WriteLine(e.ToString());

      } catch (ArgumentException e) {
        Console.WriteLine(e.ToString());

      } catch (Exception e) {   // Excepción por defecto que no sean las otras
        Console.WriteLine(e.ToString());

      } finally {

      }

        // Try no puede ir solo
        // Catch no puede ir solo
        // Finally es opcional
        // Si hay finally, siempre va a pasar por él
        // Por lo general se usa para liberar los recursos utilizados

      ///////////////////////////////////////////////////////////////////////////////

      StreamReader sr;
      string unString;
      string linea;


      //unString = sr.ReadToEnd();

      //Console.Write(unString);
      //Console.WriteLine("--------------------------");

      try {
        using (sr = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\miArchivo.txt")) {
          while ((linea = sr.ReadLine()) != null)
            Console.WriteLine(linea);
        }
        // Un bloque using ejecuta lo que tiene adentro y libera los recursos
        // Sirve para cualquier objeto, no solo streams
        // Se va a liberar lo que está instanciado dentro del parámetro de using

      } catch (FileNotFoundException e) {
        Console.WriteLine(e.Message);
        Console.WriteLine("No se puede abrir archivo-----------------------");
      }

      ///////////////////////////////////////////////////////////////////////////////
      Console.WriteLine();
      try {
        Metodo1();
      } catch (Exception e) {
        Console.WriteLine("\nExcepción agarrada en main");
        Console.WriteLine(e.Message);
        Console.WriteLine(e.InnerException.Message);
        Console.WriteLine(e.InnerException.InnerException.Message);
        Console.WriteLine(e.StackTrace);

        try {
          StreamWriter sw2 = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Incidencias.log", true);
          sw2.WriteLine(e.Message);
          sw2.WriteLine(e.InnerException.Message);
          sw2.WriteLine(e.StackTrace);
        } catch {
          Console.WriteLine("No se puede escribir archivo");
        }
      }
            Console.WriteLine("ASDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD");
            Console.ReadKey();
    }

    static void Metodo1() {
      try {
        Program.Metodo2();
      } catch (Exception e) {
        Console.WriteLine("\nEn Método1");
        Console.WriteLine(e.Message);
        throw new Exception("\nExcepción tirada en método 1", e);
      }
    }

    static void Metodo2() {
      try {
        Program.Metodo3();
      } catch (Exception e) {
        Console.WriteLine("\nEn Método2");
        Console.WriteLine(e.Message);

        throw new Exception("Excepción tirada de método 2", e);
      }
    }

    static void Metodo3() {
      try {
        Program.Metodo4();
      } catch (Metodo4Exception e) {
        Console.WriteLine("\nEn Método3");
        Console.WriteLine(e.Message);
      }

    }

    static void Metodo4() {
      Console.WriteLine("\nEn Método4");
      throw new Metodo4Exception();
    }
  }
}




/*  Windows Forms
 *  TextBox Nombre Archivo
 *  ComboBox Ubicación
 *  ListBox Texto con multiline en true;
 *
 *  Botón Guardar
 *  Botón Leer
 * 
 */ 
