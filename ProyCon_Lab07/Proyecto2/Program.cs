using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2
{
    class Program
    {
        static void Main(string[] args)
        {
            int IntNum1, IntNum2, IntNum3;
            int IntSuma, IntProm;

            Console.WriteLine("Ingrese el primer numero");
            IntNum1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el segundo numero");
            IntNum2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el tercer numero");
            IntNum3 = int.Parse(Console.ReadLine());

            IntSuma = IntNum1 + IntNum2 + IntNum3;

            IntProm = IntSuma / 3;


            Console.WriteLine("la suma es: " + IntSuma);
            Console.WriteLine("El promedio es: " + IntProm);

            Console.ReadKey();
        }
    }
}
