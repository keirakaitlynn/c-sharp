using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MyCalculator;

namespace MyCalculator.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [Ignore]
        [TestCategory("Add")]
        [TestMethod]
        public void AddSimple()
        {
            Calculator calculator = new Calculator();
            int sum = calculator.Add(1, 2);
            Assert.AreEqual(3, sum);
        }

        [TestCategory("Divide")]
        [TestMethod]
        public void DivideSimple()
        {
            Calculator calculator = new Calculator();
            int quotient = calculator.Divide(10, 5);
            Assert.AreEqual(2, quotient);
        }

        [TestCategory("Divide")]
        [ExpectedException(typeof(DivideByZeroException))]
        [TestMethod]
        public void DivideByZero()
        {
            Calculator calculator = new Calculator();
            calculator.Divide(10, 0);
        }

    }
}
