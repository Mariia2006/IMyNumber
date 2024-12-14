using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp124
{
    // цілі числа
    public class MyFrac : IMyNumber<MyFrac>, IComparable<MyFrac>
    {
        private BigInteger nom; // чисельник
        private BigInteger denom; // знаменник

        // конструктори
        public MyFrac(BigInteger nom, BigInteger denom)
        {
            if (denom == 0)
                throw new DivideByZeroException("Denominator cannot be zero.");
            this.nom = nom;
            this.denom = denom;
            Simplify();
        }

        // викликає інший конструктор, який працює з типом BigInteger
        public MyFrac(int nom, int denom) : this((BigInteger)nom, (BigInteger)denom) { }

        // скорочення дробів та приведення до канонічного вигляду
        private void Simplify()
        {
            var gcd = BigInteger.GreatestCommonDivisor(nom, denom);
            nom /= gcd;
            denom /= gcd;

            // переконаймося, що знаменник завжди додатний (- перед чисельником)
            if (denom < 0)
            {
                nom = -nom;
                denom = -denom;
            }
        }

        public int CompareTo(MyFrac other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));

            // порівняння дробів шляхом приведення до спільного знаменника
            BigInteger left = nom * other.denom;
            BigInteger right = other.nom * denom;

            return left.CompareTo(right);
        }

        /* this посилається на поточний дріб (об'єкт, на якому викликано метод)
         * that — це інший об'єкт класу MyFrac, переданий як аргумент
         */

        public MyFrac Add(MyFrac that)
        {
            BigInteger newNom = nom * that.denom + that.nom * denom;
            BigInteger newDenom = denom * that.denom;
            return new MyFrac(newNom, newDenom);
        }

        public MyFrac Subtract(MyFrac that)
        {
            BigInteger newNom = nom * that.denom - that.nom * denom;
            BigInteger newDenom = denom * that.denom;
            return new MyFrac(newNom, newDenom);
        }

        public MyFrac Multiply(MyFrac that)
        {
            return new MyFrac(nom * that.nom, denom * that.denom);
        }

        public MyFrac Divide(MyFrac that)
        {
            if (that.nom == 0)
                throw new DivideByZeroException("Cannot divide by zero.");
            return new MyFrac(nom * that.denom, denom * that.nom);
        }

        // якщо треба буде виконати операцію: 'ціле число' і 'комплексне число'
        public double DoubleValue => (double)nom / (double)denom;

        public override string ToString()
        {
            return $"{nom}/{denom}";
        }
    }
}
