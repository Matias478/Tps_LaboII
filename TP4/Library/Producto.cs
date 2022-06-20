using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Producto
    {
        int id;
        string name;
        double precio;
        int cantidad;

        public Producto()
        {

        }
        public Producto(int id, string name, double precio, int cantidad)
        {
            this.id = id;
            this.name = name;
            this.precio = precio;
            this.cantidad = cantidad;
        }
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public double Precio { get => precio; set => precio = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"ID: {Id} \n Nombre: {Name}");
            sb.Append($"Precio: {Precio} ");
            return sb.ToString();
        }

    }
}
