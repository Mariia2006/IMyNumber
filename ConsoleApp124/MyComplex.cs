using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp124
{
    // комплексні числа
    public class MyComplex : IMyNumber<MyComplex>
    {
        private double re; // реальна частина
        private double im; // уявна частина

        // конструктори
        public MyComplex(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        public MyComplex Add(MyComplex that)
        {
            return new MyComplex(re + that.re, im + that.im);
        }

        public MyComplex Subtract(MyComplex that)
        {
            return new MyComplex(re - that.re, im - that.im);
        }

        public MyComplex Multiply(MyComplex that)
        {
            double newRe = re * that.re - im * that.im;
            double newIm = re * that.im + im * that.re;
            return new MyComplex(newRe, newIm);
        }

        public MyComplex Divide(MyComplex that)
        {
            double denominator = that.re * that.re + that.im * that.im;
            if (denominator == 0)
                throw new DivideByZeroException("Cannot divide by zero.");
            double newRe = (re * that.re + im * that.im) / denominator;
            double newIm = (im * that.re - re * that.im) / denominator;
            return new MyComplex(newRe, newIm);
        }

        public override string ToString()
        {
            return $"{re} + {im}i";
        }
    }
}
