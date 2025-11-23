using System;

namespace lab_Interfaces
{
    public static class Tests
    {
        public static void TestAPlusBSquare<T>(T a, T b) where T : IMyNumber<T>
        {
            Console.WriteLine("=== (a+b)^2 test, a = " + a + ", b = " + b + " ===");

            T aPlusB = a.Add(b);
            Console.WriteLine("a + b = " + aPlusB);

            T left = aPlusB.Multiply(aPlusB);
            Console.WriteLine("(a + b)^2 = " + left);

            T right = a.Multiply(a);
            T ab = a.Multiply(b);
            T twoab = ab.Add(ab);
            T b2 = b.Multiply(b);

            right = right.Add(twoab);
            right = right.Add(b2);

            Console.WriteLine("a^2 + 2ab + b^2 = " + right);
            Console.WriteLine();
        }
    }
}
