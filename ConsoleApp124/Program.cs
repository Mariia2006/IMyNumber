using System;
using System.Numerics;

namespace ConsoleApp124
{
    internal class Program
    {
        static void Sorting()
        {
            MyFrac[] fractions = new MyFrac[]
            {
                new MyFrac(1, 2),
                new MyFrac(3, 4), 
                new MyFrac(1, 3),
                new MyFrac(5, 6),
                new MyFrac(2, 5)
            };

            Console.WriteLine("Unsorted array of fractions: ");
            foreach (var frac in fractions)
                Console.WriteLine(frac);

            Array.Sort(fractions);

            Console.WriteLine("\nSorted array of fractions: ");
            foreach (var frac in fractions)
                Console.WriteLine(frac);
        }

        static void testAPlusBSquare<T>(T a, T b) where T : IMyNumber<T>
        {
            Console.WriteLine("=== Starting testing (a + b)^2 = a^2 + 2ab + b^2 with a = " + a + ", b = " + b + " ===");
            T aPlusB = a.Add(b);
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            Console.WriteLine("(a + b) = " + aPlusB);
            Console.WriteLine("(a + b)^2 = " + aPlusB.Multiply(aPlusB));
            Console.WriteLine(" = = = ");
            T curr = a.Multiply(a);
            Console.WriteLine("a^2 = " + curr);
            T wholeRightPart = curr;
            curr = a.Multiply(b);
            curr = curr.Add(curr); 
            Console.WriteLine("2ab = " + curr);
            wholeRightPart = wholeRightPart.Add(curr);
            curr = b.Multiply(b);
            Console.WriteLine("b^2 = " + curr);
            wholeRightPart = wholeRightPart.Add(curr);
            Console.WriteLine("a^2 + 2ab + b^2 = " + wholeRightPart);
            Console.WriteLine("=== Finishing testing (a + b)^2 = a^2 + 2ab + b^2 with a = " + a + ", b = " + b + " ===");
        }

        static void testSquaresDifference<T>(T a, T b) where T : IMyNumber<T>
        {
            Console.WriteLine("=== Starting testing (a - b) = (a^2 - b^2) / (a + b) with a = " + a + ", b = " + b + " ===");
            T aMinusB = a.Subtract(b);
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            Console.WriteLine("(a - b) = " + aMinusB);
            Console.WriteLine(" = = = ");
            T aSquare = a.Multiply(a);
            Console.WriteLine("a^2 = " + aSquare);
            T bSquare = b.Multiply(b);
            Console.WriteLine("b^2 = " + bSquare);
            T squareDifference = aSquare.Subtract(bSquare);
            Console.WriteLine("(a^2 - b^2) = " + squareDifference);
            T aPlusB = a.Add(b);
            Console.WriteLine("(a + b) = " + aPlusB);
            T wholeRightPart = squareDifference.Divide(aPlusB);
            Console.WriteLine("(a^2 - b^2) / (a + b) = " + wholeRightPart);
            Console.WriteLine(wholeRightPart + " = " + aMinusB);
            Console.WriteLine("=== Finishing testing (a - b) = (a^2 - b^2) / (a + b) with a = " + a + ", b = " + b + " ===");
        }

        static void Main(string[] args)
        {
            testAPlusBSquare(new MyFrac(1, 3), new MyFrac(1, 6));
            testAPlusBSquare(new MyComplex(1, 3), new MyComplex(1, 6));
            testSquaresDifference(new MyFrac(2, 5), new MyFrac(3, 10));
            testSquaresDifference(new MyComplex(1, 4), new MyComplex(5, 11));
            Sorting();
            Console.ReadKey();
        }
    }
}