using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ciclomotor : Vehiculo
    {

        /// <summary>
        /// Constructor por defecto que llama al constructor base
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color) :base(chasis,marca,color)
        {
        }
        

        
        /// <summary>
        /// Propiedad ReadOnly que retornara el tamaño para Ciclomotor: "Chico"
        /// </summary>
        protected override ETamanio Tamanio 
        {
            get { return ETamanio.Chico; }
        }
       

        /// <summary>
        /// Muestra todos los datos de vehiculo y ademas el tamaño retornado de la propiedad
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CICLOMOTOR");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("TAMAÑO : "+ this.Tamanio);
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
