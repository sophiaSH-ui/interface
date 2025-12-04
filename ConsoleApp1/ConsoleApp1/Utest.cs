using NUnit.Framework;
using lab_Interfaces;
using System;
using System.Numerics;

namespace lab_Interfaces.Tests
{
    [TestFixture]
    public class AllTests
    {
        [Test]
        public void Frac_Constructor_ShouldSimplify()
        {
            var frac = new MyFrac(2, 4);
            Assert.That(frac.Nom, Is.EqualTo(new BigInteger(1)));
            Assert.That(frac.Denom, Is.EqualTo(new BigInteger(2)));
        }

        [Test]
        public void Frac_Add_ShouldWork()
        {
            var a = new MyFrac(1, 3);
            var b = new MyFrac(1, 6);
            var result = a.Add(b);
            Assert.That(result.ToString(), Is.EqualTo("1/2"));
        }

        [Test]
        public void Frac_Subtract_ShouldWork()
        {
            var a = new MyFrac(1, 2);
            var b = new MyFrac(1, 3);
            var result = a.Subtract(b);
            Assert.That(result.ToString(), Is.EqualTo("1/6"));
        }

        [Test]
        public void Frac_Multiply_ShouldWork()
        {
            var a = new MyFrac(2, 3);
            var b = new MyFrac(3, 4);
            var result = a.Multiply(b);
            Assert.That(result.ToString(), Is.EqualTo("1/2"));
        }

        [Test]
        public void Frac_Divide_ShouldWork()
        {
            var a = new MyFrac(1, 2);
            var b = new MyFrac(1, 4);
            var result = a.Divide(b);
            Assert.That(result.ToString(), Is.EqualTo("2/1"));
        }

        [Test]
        public void Frac_DivideByZero_Error()
        {
            var a = new MyFrac(1, 2);
            var zero = new MyFrac(0, 1);
            Assert.Throws<DivideByZeroException>(() => a.Divide(zero));
        }

        [Test]
        public void Complex_Add_ShouldWork()
        {
            var a = new MyComplex(1, 2);
            var b = new MyComplex(3, 4);
            var result = a.Add(b);
            Assert.That(result.Re, Is.EqualTo(4));
            Assert.That(result.Im, Is.EqualTo(6));
        }

        [Test]
        public void Complex_Multiply_ShouldWork()
        {
            var a = new MyComplex(1, 1);
            var b = new MyComplex(1, 1);
            var result = a.Multiply(b);
            Assert.That(result.Re, Is.EqualTo(0).Within(0.001));
            Assert.That(result.Im, Is.EqualTo(2).Within(0.001));
        }

        [Test]
        public void Complex_StringParsing_ShouldWork()
        {
            var c = new MyComplex("3+4i");
            Assert.That(c.Re, Is.EqualTo(3));
            Assert.That(c.Im, Is.EqualTo(4));
        }
    }
}