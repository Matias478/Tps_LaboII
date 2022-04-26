using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        #region Enumerados
        public enum ETipo { CuatroPuertas, CincoPuertas }
        #endregion


        ETipo tipo;

        /// <summary>
        /// Contructor por defecto que inicializa el TIPO "CuatroPuertas"
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color) : this(marca,chasis,color,ETipo.CuatroPuertas)
        {
        }
        /// <summary>
        /// Constructor de instancia de Sedan que setea sus atributos
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo) : base(chasis, marca, color)
        {
            this.tipo = tipo;
        }


        /// <summary>
        /// Propiedad ReadOnly que retornara el tamaño para Sedan: "Mediano"
        /// </summary>
        protected override ETamanio Tamanio { get { return ETamanio.Mediano; } }


        /// <summary>
        /// Muestra todos los datos de vehiculo y ademas el tamanio y el tipo de Sedan
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendLine(base.Mostrar());
            sb.Append("TAMAÑO : "+ this.Tamanio);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

    }
}
