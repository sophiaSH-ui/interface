using System;
using System.Collections.Generic;
using System;

namespace lab_Interfaces
{
    public class Program
    {
        static void Main(string[] args)
        {
            Tests.TestAPlusBSquare(new MyFrac(1, 3), new MyFrac(1, 6));
            Tests.TestAPlusBSquare(new MyComplex(1, 3), new MyComplex(1, 6));

            Console.ReadKey();
        }
    }
}
