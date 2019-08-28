using System;
using Ejercicio_17_Boligrafo;

namespace Ejercicio_17 {

    class Program {

        static void Main(string[] args) {

            Console.WriteLine("Hello World!");

            string dibujo;
            bool pudoPintarTodo;

            Boligrafo bol1 = new Boligrafo(100, ConsoleColor.Blue);
            Boligrafo bol2 = new Boligrafo(50, ConsoleColor.Red);

            pudoPintarTodo = bol1.Pintar(10, out dibujo);
            if (!pudoPintarTodo)
                bol1.Recargar();

            pudoPintarTodo = bol2.Pintar(20, out dibujo);
            if (!pudoPintarTodo)
                bol2.Recargar();

            pudoPintarTodo = bol2.Pintar(60, out dibujo);
            if (!pudoPintarTodo)
                bol2.Recargar();


        }

    }

}

namespace Ejercicio_17_Boligrafo {

    class Boligrafo {

        public static short cantidadTintaMaxima;
        private ConsoleColor color;
        private short tinta;

        ////////////////////////////////////////////////////////////////////////////

        static Boligrafo() {
            cantidadTintaMaxima = 100;
        }

        public Boligrafo(short tinta, ConsoleColor color) {
            this.tinta = tinta;
            this.color = color;
        }

        ////////////////////////////////////////////////////////////////////////////

        public ConsoleColor GetColor() {
            return this.color;
        }

        public short GetTinta() {
            return this.tinta;
        }

        ////////////////////////////////////////////////////////////////////////////

        private void SetTinta(short tinta) {
            short valorNuevoTinta;
            valorNuevoTinta = (short)(this.GetTinta() + tinta);

            if (valorNuevoTinta > Boligrafo.cantidadTintaMaxima)
                this.tinta = cantidadTintaMaxima;
            else if (valorNuevoTinta < 0)
                this.tinta = 0;
            else    // Entre 0 y 100
                this.tinta = (short)valorNuevoTinta;
        }

        ////////////////////////////////////////////////////////////////////////////

        public void Recargar() {
            Console.WriteLine("Recargando... \n");
            short valor = (short)(Boligrafo.cantidadTintaMaxima - this.GetTinta());
            this.SetTinta(valor);
        }

        public bool Pintar(short gasto, out string dibujo) {


            dibujo = "";
            bool pudoPintar;

            if (gasto <= this.GetTinta()) {

                for (; gasto > 0; gasto--) {
                    dibujo += '*';
                }
                this.SetTinta((short)(gasto * (-1)));
                pudoPintar = true;

            } else {

                pudoPintar = false;
                for (; this.tinta > 0; this.tinta--) {
                    dibujo += '*';
                }
                pudoPintar = false;

            }

            Console.ForegroundColor = this.GetColor();
            Console.WriteLine(dibujo);
            Console.ForegroundColor = ConsoleColor.White;
            return pudoPintar;
        }

    }

}
