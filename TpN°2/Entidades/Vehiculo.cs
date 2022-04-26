using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        #region Enumerados
        public enum ETamanio
        {
            Chico, Mediano, Grande
        }
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda, HarleyDavidson
        }
        #endregion


        private EMarca marca;
        private string chasis;
        private ConsoleColor color;



        /// <summary>
        /// Constructor que setea los atributos de vehiculo
        /// </summary>
        /// <param name="chasis"></param>
        /// <param name="marca"></param>
        /// <param name="color"></param>
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }


        /// <summary>
        /// ReadOnly: Retornará el tamaño cuando sea invocada
        /// </summary>
        protected abstract ETamanio Tamanio { get ; }


        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar() 
        {
            return (string)this;
        }

        #region Operadores
        /// <summary>
        /// Muestra explicitamente los dato de un vehiculo 
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CHASIS: "+ p.chasis);
            sb.AppendLine("MARCA : "+ p.marca.ToString());
            sb.AppendLine("COLOR : "+ p.color.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        
        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            bool retorno = false;
            if (!(v1 is null) && !(v2 is null))
            {
                retorno = v1.chasis == v2.chasis;
            }
            return retorno;
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }
        #endregion

    }
}
