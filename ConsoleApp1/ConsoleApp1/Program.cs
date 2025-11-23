using System;
using System.Collections.Generic;

namespace lab_Interfaces
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Tests.TestAPlusBSquare(new MyFrac(1, 3), new MyFrac(1, 6));
            Tests.TestAPlusBSquare(new MyComplex(1, 3), new MyComplex(1, 6));

            List<MyFrac> list = new List<MyFrac>();
            list.Add(new MyFrac(1, 6));
            list.Add(new MyFrac(1, 3));
            list.Add(new MyFrac(1, 2));

            Console.WriteLine("Before sort:");
            foreach (var f in list)
                Console.WriteLine(f);

            list.Sort();
            Console.WriteLine("After sort:");
            foreach (var f in list)
                Console.WriteLine(f);

            Console.ReadKey();
        }
    }
}
