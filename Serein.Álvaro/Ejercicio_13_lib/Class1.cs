using System;

namespace Ejercicio_13_lib {

    public class Conversor {

        public static string DecimalABinario(double numero) {

            // no trabaja con parte decimal
            // y ni siquiera existe binario con coma
            // acepta tipo doble por consigna pero no funciona con numeros con coma

            string binario = "";
            int parteEntera;
            int len = 0;

            while (numero>=1) {
                binario = (int)numero % 2 + binario;
                parteEntera = (int)(numero /= 2);
            }

            len = binario.Length;

            while (len%8 > 0) {
                binario = '0' + binario;
                len = binario.Length;
            }

            return binario;

        }

        public static double BinarioADecimal(string binario) {

            double numero=0;

            int f, exponente;
            exponente = binario.Length;

            for (f=0 ; f<binario.Length; f++) {

                exponente--;
                if (binario[f] == '1')
                    numero += Math.Pow(2, exponente);
            }

            return numero;  //devuelvo un long que se convierte a doble

        }

    }

    public class NumeroBinario {

        private string numero;

        private NumeroBinario(string numero) {
            this.numero = numero;
        }

        public string GetNumero() {
            return this.numero;
        }
        public void SetNumero(string numero) {
            this.numero = numero;
        }


        public static implicit operator NumeroBinario(string s) {
            return new NumeroBinario(s);
        }
        public static explicit operator string(NumeroBinario s) {
            return s.GetNumero();
        }


        public static bool operator ==(NumeroBinario bin, NumeroDecimal dec) {
            string decimalABinario;
            decimalABinario = Conversor.DecimalABinario(dec.GetNumero());
            return (decimalABinario == bin.GetNumero());
        }
        public static bool operator !=(NumeroBinario bin, NumeroDecimal dec) {
            string decimalABinario;
            decimalABinario = Conversor.DecimalABinario(dec.GetNumero());
            return (decimalABinario != bin.GetNumero());
        }

        public static string operator +(NumeroBinario bin, NumeroDecimal dec) {
            double binarioADecimal;
            double resultadoEnDecimal;
            string resultadoEnBinario;

            binarioADecimal = Conversor.BinarioADecimal(bin.GetNumero());
            resultadoEnDecimal = binarioADecimal + dec.GetNumero();
            resultadoEnBinario = Conversor.DecimalABinario(resultadoEnDecimal);

            return resultadoEnBinario;

        }
        public static string operator -(NumeroBinario bin, NumeroDecimal dec) {

            double binarioADecimal;
            double resultadoEnDecimal;
            string resultadoEnBinario;

            binarioADecimal = Conversor.BinarioADecimal(bin.GetNumero());
            resultadoEnDecimal = binarioADecimal - dec.GetNumero();
            resultadoEnBinario = Conversor.DecimalABinario(resultadoEnDecimal);

            return resultadoEnBinario;
        }

        public bool Validar() {
            string sAux = this.GetNumero();
            for (byte f=0; f<sAux.Length; f++) {
                if (sAux[f] != '0' && sAux[f] != '1')
                    return false;
            }
            return true;
        }
    }

    public class NumeroDecimal {

        private double numero;

        private NumeroDecimal(double numero) {
            this.numero = numero;
        }

        public double GetNumero() {
            return this.numero;
        }


        public static implicit operator NumeroDecimal(double d) {
            return new NumeroDecimal(d);
        }
        public static explicit operator double(NumeroDecimal d) {
            return d.GetNumero();
        }


        public static bool operator ==(NumeroDecimal dec, NumeroBinario bin) {
            double binarioADecimal;
            binarioADecimal = Conversor.BinarioADecimal(bin.GetNumero());
            return (binarioADecimal == dec.GetNumero());
        }
        public static bool operator !=(NumeroDecimal dec, NumeroBinario bin) {
            double binarioADecimal;
            binarioADecimal = Conversor.BinarioADecimal(bin.GetNumero());
            return (binarioADecimal != dec.GetNumero());
        }
        
        public static double operator +(NumeroDecimal dec, NumeroBinario bin) {
            double binarioADecimal;
            binarioADecimal = Conversor.BinarioADecimal(bin.GetNumero());
            return (dec.GetNumero() + binarioADecimal);
        }
        public static double operator -(NumeroDecimal dec, NumeroBinario bin) {
            double binarioADecimal;
            binarioADecimal = Conversor.BinarioADecimal(bin.GetNumero());
            return (dec.GetNumero() - binarioADecimal);
        }
    }

}
