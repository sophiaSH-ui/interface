using System;
using System.Numerics;

namespace lab_Interfaces
{
    public class MyFrac : IMyNumber<MyFrac>, IComparable<MyFrac>
    {
        public BigInteger nom;  
        public BigInteger denom; 

        public MyFrac(BigInteger nom, BigInteger denom)
        {
            if (denom == 0)
            {
                throw new DivideByZeroException("Denominator cannot be zero.");
            }

            if (denom < 0)
            {
                nom = -nom;
                denom = -denom;
            }

            BigInteger absNom = BigInteger.Abs(nom);
            BigInteger gcd = BigInteger.GreatestCommonDivisor(absNom, denom);
            this.nom = nom / gcd;
            this.denom = denom / gcd;
        }

        public MyFrac(long nom, long denom)
            : this(new BigInteger(nom), new BigInteger(denom))
        {
        }

        public MyFrac(long n)
            : this(new BigInteger(n), BigInteger.One)
        {
        }

        public MyFrac(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                throw new ArgumentException("Empty string is not a valid fraction.");

            s = s.Trim();
            string[] parts = s.Split('/');
            if (parts.Length != 2)
                throw new ArgumentException("String must be in 'a/b' format.");

            BigInteger parsedNom;
            BigInteger parsedDenom;

            bool okNom = BigInteger.TryParse(parts[0].Trim(), out parsedNom);
            bool okDen = BigInteger.TryParse(parts[1].Trim(), out parsedDenom);

            if (!okNom)
                throw new ArgumentException("Cannot parse numerator.");

            if (!okDen)
                throw new ArgumentException("Cannot parse denominator.");

            if (parsedDenom == 0)
                throw new DivideByZeroException("Denominator cannot be zero.");

            MyFrac tmp = new MyFrac(parsedNom, parsedDenom);
            this.nom = tmp.nom;
            this.denom = tmp.denom;
        }

        public static MyFrac operator +(MyFrac a, MyFrac b)
        {
            BigInteger newNom = a.nom * b.denom + b.nom * a.denom;
            BigInteger newDen = a.denom * b.denom;
            return new MyFrac(newNom, newDen);
        }

        public static MyFrac operator -(MyFrac a, MyFrac b)
        {
            BigInteger newNom = a.nom * b.denom - b.nom * a.denom;
            BigInteger newDen = a.denom * b.denom;
            return new MyFrac(newNom, newDen);
        }

        public static MyFrac operator *(MyFrac a, MyFrac b)
        {
            BigInteger newNom = a.nom * b.nom;
            BigInteger newDen = a.denom * b.denom;
            return new MyFrac(newNom, newDen);
        }

        public static MyFrac operator /(MyFrac a, MyFrac b)
        {
            if (b.nom == 0)
                throw new DivideByZeroException("Cannot divide by zero fraction.");

            BigInteger newNom = a.nom * b.denom;
            BigInteger newDen = a.denom * b.nom;
            return new MyFrac(newNom, newDen);
        }

        public MyFrac Add(MyFrac b) { return this + b; }
        public MyFrac Subtract(MyFrac b) { return this - b; }
        public MyFrac Multiply(MyFrac b) { return this * b; }
        public MyFrac Divide(MyFrac b) { return this / b; }

        public override string ToString()
        {
            return nom.ToString() + "/" + denom.ToString();
        }

        public int CompareTo(MyFrac other)
        {
            if (other == null) return 1;

            BigInteger left = this.nom * other.denom;
            BigInteger right = other.nom * this.denom;
            return left.CompareTo(right);
        }
    }
}

