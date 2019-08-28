using System;

namespace Ejercicio_16 {

    class Program {

        static void Main(string[] args) {

            Console.WriteLine("Crea 3 alumnos por instancia. Los muestra.\n");

            Alumno alumno1 = new Alumno("Ricardo", "Rubén", 100);
            Alumno alumno2 = new Alumno("Vote por", "El Donaldo", 101);
            Alumno alumno3 = new Alumno("Aquiles", "Vai Loyó", 103);

            alumno1.Estudiar(8, 10);
            alumno2.Estudiar(6, 6);
            alumno3.Estudiar(2, 3);

            alumno1.CalcularFinal();
            alumno2.CalcularFinal();
            alumno3.CalcularFinal();

            alumno1.Mostrar();
            alumno2.Mostrar();
            alumno3.Mostrar();

        }
    }

    class Alumno {

        private byte nota1;
        private byte nota2;
        private float notaFinal;
        public string nombre;
        public string apellido;
        public int legajo;

        //////////////////////////////////////////////////////////////////////////// 

        public Alumno(string nombre, string apellido, int legajo) {
            this.nombre = nombre;
            this.apellido = apellido;
            this.legajo = legajo;
        }

        ////////////////////////////////////////////////////////////////////////////

        public void CalcularFinal() {

            if (this.nota1>=4 && this.nota2>=4) {
                Random numAleatorio = new Random();
                this.notaFinal = (float)numAleatorio.Next(1, 10);
            } else {
                this.notaFinal = -1;
            }
        }

        public void Estudiar(byte nota1, byte nota2) {
            this.nota1 = nota1;
            this.nota2 = nota2;
        }

        public void Mostrar() {     // Lo pide como string, pero no hay nada para devolver
            Console.WriteLine("\n    Apellido y nombre: {0}, {1}", this.apellido, this.nombre);
            Console.WriteLine("    Legajo: " + this.legajo);
            Console.WriteLine("    Primera nota: " + this.nota1);
            Console.WriteLine("    Segunda nota: " + this.nota2);
            Console.WriteLine("    -----------------------------------------------");
            if (this.notaFinal != -1)
                Console.WriteLine("    Nota final: " + this.notaFinal + "\n\n\n");
            else
                Console.WriteLine("    Alumno desaprobado\n\n");
        }

    }

}