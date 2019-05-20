using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        private string SetNumero { set { this.numero = validarNumero(value); } }

        public Numero() : this(0)
        {}
        public Numero(double numero)
        {
            this.numero = numero;
        }
        public Numero(string numero)
        {
            this.SetNumero = numero;
        }

        private double validarNumero(string strNumero)
        {
            double salida = 0;

            if (double.TryParse(strNumero, out salida))
                return salida;
            else
                return salida;
        }


        public string DecimalBinario(string numero){ return ""; }
        public string DecimalBinario(double numero){ return ""; }
        public string BinarioDecimal(string binario){
            return "";

        }

        public static double operator +(Numero n1, Numero n2) {
            return n1.numero + n2.numero;
        }
        public static double operator -(Numero n1, Numero n2) {
            return n1.numero - n2.numero;
        }
        public static double operator *(Numero n1, Numero n2) {
            return n1.numero * n2.numero;
        }
        public static double operator /(Numero n1, Numero n2) {
            return n1.numero / n2.numero;
        }

    }
}
