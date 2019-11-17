using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Clase_22.Entidades;

namespace Clase_22 {

    public class Program {

        static void Main(string[] args) {

            Empleado camaradaPerez = new Empleado("Juan", "Perez", 108020);
            Program unaInstanciaDeProgram = new Program();

            camaradaPerez.limiteSueldo += new Delegado_LimiteSueldo(unaInstanciaDeProgram.ManejadorLimiteSueldo);
            camaradaPerez.limiteSueldoMejorado += new Delegado_ConEventArgs(ManejadorDeLimiteSueldoMejorado);
            camaradaPerez.limiteSueldoMejorado += new Delegado_ConEventArgs(unaInstanciaDeProgram.ManejadorDeLimiteSueldoMejorado2);

            camaradaPerez.Sueldo = 33000;

            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine(camaradaPerez);

            Console.ReadKey();
        }

        public void ManejadorLimiteSueldo(double sueldo, Empleado empleado) {
            Console.WriteLine("El empleado " + empleado.Nombre + " " + empleado.Apellido +
                              " se hizo la rata y se asignó un sueldo de " + sueldo + " mangos");
        }

        public static void ManejadorDeLimiteSueldoMejorado(Empleado empleado, EmpleadoEventArgs eea) {
            Console.WriteLine("MEJORADO");
            Console.WriteLine("El empleado " + empleado.Nombre + " " + empleado.Apellido +
                              " se hizo la rata y se asignó un sueldo de " + eea.SueldoAsignar + " mangos");
        }

        public void ManejadorDeLimiteSueldoMejorado2(Empleado empleado, EmpleadoEventArgs eea) {
            Console.WriteLine("MEJORADO");
            Console.WriteLine("El empleado " + empleado.Nombre + " " + empleado.Apellido +
                              " se hizo la rata y se asignó un sueldo de " + eea.SueldoAsignar + " mangos");
        }
    }
}

/*      Defino delegado
 *      [modificador] delegate [tipo] [nombre] (args);
 *      Se hace en un archivo vacío de código, como los enumerados
 *      
 *      Sin implementación cuando se define
 *      
 *      Se declara -> public event [nombre del delegado] [nombre de variable]
 *      
 *      Una vez que declaro el evento dentro de una clase se puede ver con el intellisense (instancia. -> aparece ahí)
 *      
 *      Asigno al evento ( this.evento(argumentos) )
 *      
 *      Creo el manejador en program ( public static void ManejadorLimiteSueldo(double sueldo, Empleado empleado) )
 *      
 *      instancia.evento += [nombre del delegado]([nombre del manejador]);
 * 
 */
