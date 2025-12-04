using System;
using System.Collections.Generic;
using System;

namespace lab_Interfaces
{
    public class Program
    {
        static void Main(string[] args)
        {
            Test.TestAPlusBSquare(new MyFrac(1, 3), new MyFrac(1, 6));
            Test.TestAPlusBSquare(new MyComplex(1, 3), new MyComplex(1, 6));
            MyFrac[] frac = new MyFrac[5];
            Random r = new Random();

            for (int i = 0; i < 5; i++)
            {
                frac[i] = new MyFrac(r.Next(-100, 100), r.Next(-100, 100));
            }


            foreach (var f in frac)
            {
                Console.Write(f.ToString() + " ");
            } 
            Console.WriteLine();
            Array.Sort(frac);

            foreach (var f in frac)
            {
                Console.Write(f.ToString() + " ");
            }

            Console.ReadKey();
        }


    }
}
