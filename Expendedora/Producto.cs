using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expendedora
{
    internal class Producto
    {
        private int Clave;
        private int Stock;
        private string Nombre;
        private double Precio;
        private double TotalVenta;

        public int Clave1 { get => Clave; set => Clave = value; }
        public int Stock1 { get => Stock; set => Stock = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public double Precio1 { get => Precio; set => Precio = value; }
        public double TotalVenta1 { get => TotalVenta; set => TotalVenta = value; }
    }
}
