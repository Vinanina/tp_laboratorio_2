﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        #region Constructores
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
        #endregion
        #region Metodos
        private double validarNumero(string strNumero)
        {
            double salida = 0;

            if (double.TryParse(strNumero, out salida))
                return salida;
            else
                return salida;
        }


        public string DecimalBinario(string numero){
            double num;
            // se trata de parsiar el numero a double, si se puede se llama a DecimalBinario(double numero)
            if (Double.TryParse(numero,out num)) {

                return DecimalBinario(num);

            }
            else
            {
                return "Valor inválido";
            }
               
        }
        public string DecimalBinario(double numero){
            //convierte double a int
           return Convert.ToInt32(numero).ToString();

        }
        public string BinarioDecimal(string binario){
            //Se trata de parsear el string a un int si se pudo se convierte el int a double
            int num;
            if (Int32.TryParse(binario, out num))
            {

                return Convert.ToDouble(num).ToString("0.00");
            }
            else
            {
                return "Valor inválido";
            }
           

        }
        #endregion
        #region Sobrecargas
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
            // Si se divide por 0 se devuelve double.MinValue
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            else
            {
                return n1.numero / n2.numero;
            }
        }
#endregion
    }
}
