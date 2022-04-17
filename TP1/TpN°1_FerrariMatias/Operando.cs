using System;

namespace Entidades
{
    public class Operando
    {
        
        private double numero;
        

        #region Constructores
        /// <summary>
        /// Inicializa el valor del numero en 0
        /// </summary>
        public Operando():this(0)
        {
        }
        /// <summary>
        /// Construye la entidad con el valor de numero
        /// </summary>
        /// <param name="number"></param>
        public Operando(double number)
        {
            this.numero = number;
        }
        /// <summary>
        /// Trata de convertir el numero string a un numero double 
        /// </summary>
        /// <param name="strNumber"></param>
        public Operando(string strNumber)
        {
            this.Numero = strNumber;
        }
        #endregion

        
        /// <summary>
        /// Llama al metodo validarOperando y setea la entidad
        /// </summary>
        private string Numero
        {
            set{ this.numero = ValidarOperando(value); }
        }
        

        #region MetodosBinarios
        /// <summary>
        ///  Convierte un numero decimal a un numero binario
        /// </summary>
        /// <param name="dec"></param>
        /// <returns></returns>
        public string DecimalBinario(double dec)
        {
            string numeroBinario = string.Empty;
            int numeroEntero = (int)Math.Abs(dec);

            if (numeroEntero == 0)
            {
                numeroBinario = "0";
            }
            else
            {
                while (numeroEntero > 0)
                {
                    numeroBinario = numeroEntero % 2 + numeroBinario;//(int)
                    numeroEntero /= 2;
                }
            }
            
            return numeroBinario;
        }
        /// <summary>
        /// Trata de convertir un numero string a un numero binario en formato string
        /// </summary>
        /// <param name="binStr"></param>
        /// <returns></returns>
        public string DecimalBinario(string binStr)
        {
            if(double.TryParse(binStr, out double dec))
            {
                return DecimalBinario(dec);
            }

            return"Valor invalido";
        }

        /// <summary>
        /// Convierte un numero binario a un numero decimal en formato double
        /// </summary>
        /// <param name="binStr"></param>
        /// <returns></returns>
        public string BinarioDecimal(string binStr)
        {
            char[] binaryArray = binStr.ToCharArray();
            Array.Reverse(binaryArray);

            int dec = 0;
            string mensajeError = "Valor Invalido";

            if (EsBinario(binStr))
            {
                for (int i = 0; i < binaryArray.Length; i++)
                {
                    if (binaryArray[i] == '1')
                    { 
                        dec += (int)Math.Pow(2, i);
                    }
                }
                return dec.ToString();
            }
            return mensajeError;

        }
        #endregion

        
        /// <summary>
        /// Comprueba que el valor recibido sea numerico y retorna el numero en formato double en caso de serlo, de lo contrario retorna 0
        /// </summary>
        /// <param name="strNumber"></param>
        /// <returns></returns>
        private double ValidarOperando(string strNumber)
        {
            if(double.TryParse(strNumber, out double valorRetornado))
            {
                return valorRetornado;
            }
            return 0;
        }
        /// <summary>
        /// Valida que el numero pasado por paramtros sea un numero binario verdadero
        /// </summary>
        /// <param name="binary"></param>
        /// <returns></returns>
        private bool EsBinario(string binary)
        {
            bool EsBinario = false;
            for (int i = 0; i < binary.Length; i++)
            {
                if (binary[i] == '1' || binary[i] == '0')
                {
                    EsBinario = true;
                }
                else
                {
                    EsBinario = false;
                }
            }
            return EsBinario;
        }
        

        #region Operadores
        /// <summary>
        /// Hace la suma de dos numeros
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator +(Operando n1,Operando n2)
        {
            return (n1.numero+n2.numero);
        }
        /// <summary>
        /// Hace la resta de dos numeros
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return (n1.numero - n2.numero);
        }
        /// <summary>
        /// Hace la multiplicion entre dos numeros
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return (n1.numero * n2.numero);
        }
        /// <summary>
        /// Trata de hacer la division entre dos numeros, en caso de no ser posible retorna el numero mas bajo posible
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator /(Operando n1, Operando n2)
        {
            if(n2.numero>0)
            {
                return (n1.numero / n2.numero);
            }else{
                return double.MinValue;
            }
        }
        #endregion
    }
}
