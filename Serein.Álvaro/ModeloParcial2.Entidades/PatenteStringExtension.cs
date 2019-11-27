using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace ModeloParcial2.Entidades {

    public static class PatenteStringExtension {

        private static string patente_mercosur = "^[A-Z]{2}[0-9]{3}[A-Z]{2}$";
        private static string patente_vieja = "^[A-Z]{3}[0-9]{3}";

        public static Patente ValidarPatente(this string str) {
            Regex regexMercosur = new Regex(PatenteStringExtension.patente_mercosur);
            Regex regexVieja = new Regex(PatenteStringExtension.patente_vieja);

            if (regexMercosur.IsMatch(str)) {
                Patente patente = new Patente(str, Patente.Tipo.Mercosur);
                return patente;
            } else if (regexVieja.IsMatch(str)) {
                Patente patente = new Patente(str, Patente.Tipo.Vieja);
                return patente;
            } else {
                string mensaje = string.Format("{0} no cumple el formato.", str);
                throw new PatenteInvalidaException(mensaje);
            }
        }
    }
}
