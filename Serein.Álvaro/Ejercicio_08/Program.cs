using System;

namespace Ejercicio_08 {

    class Program {

        static void Main(string[] args) {

            Console.WriteLine("Imprime un recibo para cada empleado.\n");
            int salarioPorHora;
            string nombre;
            int antiguedad;
            int horasTrabajadas;
            short cantEmpleados=0;
            bool ingresarMas=true;
            char respuesta;
            int salarioBruto;
            float salarioDescontado, todosLosSalarios=0;
    
            while (ingresarMas==true) {

                Console.Write("Nombre:\t");
                nombre = Console.ReadLine();
                Console.Write("Salario por hora: ");
                salarioPorHora = int.Parse(Console.ReadLine());
                Console.Write("Horas trabajadas: ");
                horasTrabajadas = int.Parse(Console.ReadLine());
                Console.Write("Antiguedad:\t");
                antiguedad = int.Parse(Console.ReadLine());

                salarioBruto = (horasTrabajadas * salarioPorHora) + (antiguedad * 150);
                salarioDescontado = salarioBruto * (float)0.87;

                todosLosSalarios += salarioDescontado;
                cantEmpleados++;

                Console.WriteLine("\n\n\t| Nombre:        " + nombre);
                Console.WriteLine("\t| Antigüedad:    " + antiguedad + " años");
                Console.WriteLine("\t| Valor hora:    $" + salarioPorHora);
                Console.WriteLine("\t| Salario bruto: $" + salarioBruto);
                Console.WriteLine("\t| Salario neto:  $" + salarioDescontado);
                Console.WriteLine("\t| Descuento:     $-" + salarioDescontado + "\n\n");

                Console.Write("¿Desea ingresar otro empleado? (S/N) ");
                respuesta = Console.ReadKey().KeyChar;
                respuesta = char.ToUpper(respuesta);
                
                if (respuesta!='S' && respuesta!='N') {
                    Console.Write("\t¿Desea ingresar otro empleado? (S/N) ");
                    respuesta = Console.ReadKey().KeyChar;
                    respuesta = char.ToUpper(respuesta);
                } else if (respuesta=='S') {
                    ingresarMas = true;
                } else {
                    ingresarMas = false;
                }

                Console.Write("\n\n");

            }

            Console.WriteLine("\t| Cantidad de empleados:       $" + cantEmpleados);
            Console.WriteLine("\t| Total de salarios a pagar:   $" + todosLosSalarios);


        }

    }

}
