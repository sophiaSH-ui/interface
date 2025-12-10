using System;
using System.Numerics;

namespace lab_Interfaces
{
    public class MyComplex : IMyNumber<MyComplex>
    {
        private double re;
        private double im;

        public double Re
        {
            get
            {
                return re;
            }
        }
        public double Im
        {
            get
            {
                return im;
            }
        }

        public MyComplex(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        public MyComplex(double re)
            : this(re, 0.0)
        {
        }

        public MyComplex(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                throw new ArgumentException("Empty string is not a valid complex number.");

            s = s.Trim();
            if (!s.EndsWith("i"))
                throw new ArgumentException("String must end with 'i'.");

            string withoutI = s.Substring(0, s.Length - 1);

            int indexSign = -1;
            for (int i = withoutI.Length - 1; i > 0; i--)
            {
                char c = withoutI[i];
                if (c == '+' || c == '-')
                {
                    indexSign = i;
                    break;
                }
            }

            if (indexSign == -1)
                throw new ArgumentException("String must be in 'a+bi' or 'a-bi' format.");

            string realPart = withoutI.Substring(0, indexSign);
            string imagPart = withoutI.Substring(indexSign);

            double parsedRe;
            double parsedIm;

            bool okRe = double.TryParse(realPart, out parsedRe);
            bool okIm = double.TryParse(imagPart, out parsedIm);

            if (!okRe)
                throw new ArgumentException("Cannot parse real part.");
            if (!okIm)
                throw new ArgumentException("Cannot parse imaginary part.");

            this.re = parsedRe;
            this.im = parsedIm;
        }

        public static MyComplex operator +(MyComplex a, MyComplex b)
        {
            double newRe = a.re + b.re;
            double newIm = a.im + b.im;
            return new MyComplex(newRe, newIm);
        }

        public static MyComplex operator -(MyComplex a, MyComplex b)
        {
            double newRe = a.re - b.re;
            double newIm = a.im - b.im;
            return new MyComplex(newRe, newIm);
        }

        public static MyComplex operator *(MyComplex a, MyComplex b)
        {
            double aRe = a.re;
            double aIm = a.im;
            double bRe = b.re;
            double bIm = b.im;

            double newRe = aRe * bRe - aIm * bIm;
            double newIm = aRe * bIm + aIm * bRe;
            return new MyComplex(newRe, newIm);
        }

        public static MyComplex operator /(MyComplex a, MyComplex b)
        {
            double aRe = a.re;
            double aIm = a.im;
            double bRe = b.re;
            double bIm = b.im;

            double denom = bRe * bRe + bIm * bIm;
            if (denom == 0.0)
                throw new DivideByZeroException("Cannot divide by 0+0i.");

            double newRe = (aRe * bRe + aIm * bIm) / denom;
            double newIm = (aIm * bRe - aRe * bIm) / denom;
            return new MyComplex(newRe, newIm);
        }

        public MyComplex Add(MyComplex b) { return this + b; }
        public MyComplex Subtract(MyComplex b) { return this - b; }
        public MyComplex Multiply(MyComplex b) { return this * b; }
        public MyComplex Divide(MyComplex b) { return this / b; }

        public override string ToString()
        {
            string sign;
            double imagAbs;
            if (im >= 0)
            {
                sign = "+";
                imagAbs = im;
            }
            else
            {
                sign = "-";
                imagAbs = -im;
            }

            return re.ToString() + sign + imagAbs.ToString() + "i";
        }
    }
}
