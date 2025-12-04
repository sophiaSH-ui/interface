using NUnit.Framework;
using lab_Interfaces;
using System;
using System.Numerics;

namespace lab_Interfaces.Tests
{
    [TestFixture]
    public class MyFracTests
    {
        [Test]
        public void Constructor_ShouldSimplifyFraction()
        {
            var frac = new MyFrac(2, 4);
            Assert.AreEqual(new BigInteger(1), frac.nom);
            Assert.AreEqual(new BigInteger(2), frac.denom);
        }

        [Test]
        public void Constructor_ShouldHandleNegativeSigns()
        {
            var frac = new MyFrac(1, -2);
            Assert.AreEqual(new BigInteger(-1), frac.nom);
            Assert.AreEqual(new BigInteger(2), frac.denom);
        }

        [Test]
        public void Add_ShouldCalculateCorrectly()
        {
            var a = new MyFrac(1, 3);
            var b = new MyFrac(1, 6);
            var result = a.Add(b);
            Assert.AreEqual("1/2", result.ToString());
        }

        [Test]
        public void Subtract_ShouldCalculateCorrectly()
        {
            var a = new MyFrac(1, 2);
            var b = new MyFrac(1, 3);
            var result = a.Subtract(b);
            Assert.AreEqual("1/6", result.ToString());
        }

        [Test]
        public void Multiply_ShouldCalculateCorrectly()
        {
            var a = new MyFrac(2, 3);
            var b = new MyFrac(3, 4);
            var result = a.Multiply(b);
            Assert.AreEqual("1/2", result.ToString());
        }

        [Test]
        public void Divide_ShouldCalculateCorrectly()
        {
            var a = new MyFrac(1, 2);
            var b = new MyFrac(1, 4);
            var result = a.Divide(b);
            Assert.AreEqual("2/1", result.ToString());
        }

        [Test]
        public void Divide_ByZeroFraction_ShouldThrowException()
        {
            var a = new MyFrac(1, 2);
            var zero = new MyFrac(0, 1);
            Assert.Throws<DivideByZeroException>(() => a.Divide(zero));
        }

        [Test]
        public void Constructor_StringParsing_ShouldWork()
        {
            var frac = new MyFrac("-3/4");
            Assert.AreEqual("-3/4", frac.ToString());
        }
    }

    [TestFixture]
    public class MyComplexTests
    {
        [Test]
        public void Constructor_ShouldSetValues()
        {
            var c = new MyComplex(1.5, -2.5);
            Assert.AreEqual(1.5, c.re);
            Assert.AreEqual(-2.5, c.im);
        }

        [Test]
        public void Add_ShouldCalculateCorrectly()
        {
            var a = new MyComplex(1, 2);
            var b = new MyComplex(3, 4);
            var result = a.Add(b);
            Assert.AreEqual(4, result.re);
            Assert.AreEqual(6, result.im);
        }

        [Test]
        public void Multiply_ShouldCalculateCorrectly()
        {
            var a = new MyComplex(1, 1);
            var b = new MyComplex(1, 1);
            var result = a.Multiply(b);
            Assert.AreEqual(0, result.re, 0.0001);
            Assert.AreEqual(2, result.im, 0.0001);
        }

        [Test]
        public void Constructor_StringParsing_ShouldWork()
        {
            var c = new MyComplex("3+4i");
            Assert.AreEqual(3, c.re);
            Assert.AreEqual(4, c.im);
        }

        [Test]
        public void ToString_ShouldFormatCorrectly()
        {
            var c = new MyComplex(3, -4);
            Assert.AreEqual("3-4i", c.ToString());
        }
    }
}