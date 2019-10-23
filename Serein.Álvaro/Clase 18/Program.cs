using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase_18_Entidades;

namespace Clase_18 {

    class Program {

        static void Main(string[] args) {

            Carreta carreta = new Carreta(1000);

            Familiar autoFamiliar = new Familiar(20000, "ABC123", 5);
            Deportivo autoDepotivo = new Deportivo(200000, "DEF456", 800);

            Avion avion = new Avion(3000000, 500);
            Privado avionPrivado = new Privado(5000000, 500, 5);
            Comercial avionComercial = new Comercial(7000000, 500, 70);

            #region Carreta
            Console.WriteLine("Carreta:\n" +
                              carreta.MostrarPrecio());
            Console.WriteLine("\n------------------------------------------------\n");
            #endregion

            #region Autos
            Console.WriteLine("Auto familiar:\n" +
                              autoFamiliar.MostrarPrecio());
            autoFamiliar.MostrarPatente();
            Console.WriteLine("Asientos: " + autoFamiliar.CantidadAsientos + "\n" +
                              "\n------------------------\n");

            Console.WriteLine("Auto deportivo:\n" +
                              autoDepotivo.MostrarPrecio());
            autoDepotivo.MostrarPatente();
            Console.WriteLine("Caballos de fuerza: " + autoDepotivo.CaballosDeFuerza + "\n" +
                              "Precio con impuesto: " + autoDepotivo.PrecioConImpuesto + "\n" +
                              "\n------------------------------------------------\n");
            #endregion

            #region Aviones
            Console.WriteLine("Avión:\n" +
                              avion.MostrarPrecio() + "\n" +
                              "Precio con impuesto: " + avion.PrecioConImpuesto + "\n" +
                              "Velocidad máxima: " + avion.VelocidadMaxima + "\n" +
                              "\n------------------------\n");

            Console.WriteLine("Avión privado:\n" +
                              avionPrivado.MostrarPrecio() + "\n" +
                              "Precio con impuesto: " + avionPrivado.PrecioConImpuesto + "\n" +
                              "Velocidad máxima: " + avionPrivado.VelocidadMaxima + "\n" +
                              "Valoración: " + avionPrivado.Valoracion + "\n" +
                              "\n------------------------\n");

            Console.WriteLine("Avión comercial:\n" +
                              avionComercial.MostrarPrecio() + "\n" +
                              "Precio con impuesto: " + avionComercial.PrecioConImpuesto + "\n" +
                              "Velocidad máxima: " + avionComercial.VelocidadMaxima + "\n" +
                              "Cantidad de pasajeros: " + avionComercial.CantidadDePasajeros);
            #endregion

            Console.ReadKey();
        }
    }
}
