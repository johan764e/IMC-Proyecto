using System;
using System.Collections.Generic;
using System.Text;

namespace IMC_MVVM_JAPD.Models
{
    internal class Persona
    {
        // Datos numéricos necesarios para el cálculo
        public double Peso { get; set; }
        public double Estatura { get; set; }

        // Devuelve el IMC con los datos de esta persona
        public double CalcularImc()
        {
            return Peso / (Estatura * Estatura);
        }
    }
}
