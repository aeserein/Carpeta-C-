using System;
using Geometria;

namespace PruebaGeometria {

    class Program {

        static void Main(string[] args) {

            Console.WriteLine("Puntos y rectángulos\n");

            Punto punto1 = new Punto(2, 2);
            Punto punto3 = new Punto(5, 6);
            Rectangulo unRectangulo = new Rectangulo(punto1, punto3);

            Console.WriteLine("{0}{1}\n" +
                              "{2}{3}\n",
                              "ÁREA: ", unRectangulo.GetArea(),
                              "PERÍMETRO: ", unRectangulo.GetPerimetro());

            Rectangulo.Mostrar(unRectangulo);

        }

    }

}

namespace Geometria {

    class Punto {

        private int x;
        private int y;

        public Punto(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public int GetX() {
            return this.x;
        }

        public int GetY() {
            return this.y;
        }

    }

    class Rectangulo {

        private float area;
        private float perimetro;
        private Punto vertice1;
        private Punto vertice2;
        private Punto vertice3;
        private Punto vertice4;

        public Rectangulo (Punto vertice1, Punto vertice3) {

            this.vertice1 = vertice1;
            this.vertice3 = vertice3;

            Punto vertice2;
            Punto vertice4;
            int ancho;
            int alto;

            ancho = Math.Abs(vertice3.GetX() - vertice1.GetX());
            alto = Math.Abs(vertice3.GetY() - vertice1.GetY());

            vertice2 = new Punto(vertice3.GetX(), vertice1.GetY());
            vertice4 = new Punto(vertice1.GetX(), vertice3.GetY());

            this.vertice2 = vertice2;
            this.vertice4 = vertice4;

            this.perimetro = (ancho + alto) * 2;
            this.area = ancho * alto;

        }

        public float GetArea() {
            return this.area;
        }
        public float GetPerimetro() {
            return this.perimetro;
        }

        public static void Mostrar(Rectangulo rectangulo) {
            Console.WriteLine("Función mostrar\n---------------------------------");
            Console.WriteLine("\nPunto 1: " + rectangulo.vertice1.GetX() + ", " + rectangulo.vertice1.GetY() +
                              "\nPunto 2: " + rectangulo.vertice2.GetX() + ", " + rectangulo.vertice2.GetY() +
                              "\nPunto 4: " + rectangulo.vertice4.GetX() + ", " + rectangulo.vertice4.GetY() +
                              "\nPunto 3: " + rectangulo.vertice3.GetX() + ", " + rectangulo.vertice3.GetY() +
                              "\nArea: " + rectangulo.GetArea() +
                              "\nPerímetro: " + rectangulo.GetPerimetro());
        }
    }

}