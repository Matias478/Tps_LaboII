using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Se encarga de hacer todas las operaciones una vez se halla verificado que el operador es el correcto
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(Operando n1, Operando n2, char operador)
        {
            double resultado=0;
            char operadorCorrecto = ValidarOperador(operador);
                        
            switch(operadorCorrecto)
            {
                case '+':
                    resultado = n1 + n2;
                    break;
                case '-':
                    resultado = n1 - n2;
                    break;
                case '*':
                    resultado = n1 * n2;
                    break;
                case '/':
                    resultado = n1 / n2;
                    break;
            }

            return resultado;
        }
        /// <summary>
        /// Valida que el operador pasado por parametro sea el correcto y sino no lo es retorna un + como operador
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static char ValidarOperador(char operador)
        {
            if(operador=='+' || operador=='-' || operador=='/' || operador=='*')
            {
                return operador;
            }else{
                return '+';
            }
        }
    }
}
