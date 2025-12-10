using System;

namespace lab_Interfaces
{
    public static class Test
    {
        public static void TestAPlusBSquare<T>(T a, T b) where T : IMyNumber<T>
        {
            Console.WriteLine("=== Starting testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
            T aPlusB = a.Add(b);
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            Console.WriteLine("(a + b) = " + aPlusB);
            Console.WriteLine("(a+b)^2 = " + aPlusB.Multiply(aPlusB));
            Console.WriteLine(" = = = ");
            T curr = a.Multiply(a);
            Console.WriteLine("a^2 = " + curr);
            T wholeRightPart = curr;
            curr = a.Multiply(b); // ab
            curr = curr.Add(curr); // ab + ab = 2ab
            Console.WriteLine("2*a*b = " + curr);
            wholeRightPart = wholeRightPart.Add(curr);
            curr = b.Multiply(b);
            Console.WriteLine("b^2 = " + curr);
            wholeRightPart = wholeRightPart.Add(curr);
            Console.WriteLine("a^2+2ab+b^2 = " + wholeRightPart);
            Console.WriteLine("=== Finishing testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
            Console.WriteLine();
        }

        public static void TestSquaresDifference<T>(T a, T b) where T : IMyNumber<T>
        {
            Console.WriteLine("=== Starting testing (a-b) = (a^2-b^2)/(a+b) with a = " + a + ", b = " + b + " ===");

            T aMinusB = a.Subtract(b);
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            Console.WriteLine("(a - b) = " + aMinusB);

            Console.WriteLine(" = = = ");

            // a^2
            T a2 = a.Multiply(a);
            Console.WriteLine("a^2 = " + a2);

            // b^2
            T b2 = b.Multiply(b);
            Console.WriteLine("b^2 = " + b2);

            // a^2 - b^2
            T diffSquares = a2.Subtract(b2);
            Console.WriteLine("a^2 - b^2 = " + diffSquares);

            // a + b
            T sum = a.Add(b);
            Console.WriteLine("a + b = " + sum);

            try
            {
                T result = diffSquares.Divide(sum);
                Console.WriteLine("(a^2-b^2)/(a+b) = " + result);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Result: Division by Zero (a+b equals 0)");
            }

            Console.WriteLine("=== Finishing testing (a-b) = (a^2-b^2)/(a+b) ===");
            Console.WriteLine();
        }
    }
}