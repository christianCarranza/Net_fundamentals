using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto3
{
    class Program
    {
        static void Main(string[] args)
        {
            double DblPrecio, DblResultado, DblComision;
            int IntCant;

            Console.WriteLine("Ingrese el precio del producto");
            DblPrecio = double.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la cantidad");
            IntCant = int.Parse(Console.ReadLine());

            DblResultado = IntCant * DblPrecio;
            DblComision = DblResultado * 0.15;

            Console.WriteLine("El total es " + DblResultado);
            Console.WriteLine("La comision del vendedor es " + DblComision);
            Console.ReadKey();

        }
    }
}
