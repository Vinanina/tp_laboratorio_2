﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {

        #region Metodos
        public double Operar(Numero num1, Numero num2, string operador)
        {
            // Se realiza la operacion segun el operador seleccionado
            double resultado = 0;

            switch (Calculadora.ValidarOperador(operador))
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;

            }

            return resultado;
            
        }


        private static string ValidarOperador(string operador)
        {
            // Se validan Operadores 

            if (operador == "+" || operador == "-" || operador == "*" || operador == "/")
            {
                return operador;
            }
            else { return "+"; }
        }
        #endregion
    }
}
