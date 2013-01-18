using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace CalculatorTests
{
    [TestClass]
    public class CalculatorModelTest
    {
        private CalculatorModel _calc;

        [TestInitialize]
        public void Init()
        {
            _calc = new CalculatorModel();
        }

        [TestMethod]
        public void TestCantDoOperatorInitially()
        {
            Assert.IsFalse(_calc.CanDoOperator());
        }

        [TestMethod]
        public void TestCanDoOperatorAfterNumber()
        {
            _calc.Number(5);
            Assert.IsTrue(_calc.CanDoOperator());
        }

        [TestMethod]
        public void TestCantDoOperatorAfterOperator()
        {
            _calc.Number(5);
            _calc.Plus();
            Assert.IsFalse(_calc.CanDoOperator());
        }

        [TestMethod]
        public void TestCantDoOperatorAfterEquals()
        {
            _calc.Number(5);
            _calc.Plus();
            _calc.Number(5);
            _calc.Equals();
            Assert.IsFalse(_calc.CanDoOperator());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestOperatorThrowsOnInappropriateCall()
        {
            _calc.Plus();
        }

        [TestMethod]
        public void TestCanDoEasyAddition()
        {
            _calc.Number(5);
            _calc.Plus();
            _calc.Number(3);
            _calc.Equals();
            Assert.AreEqual(8, _calc.Result);
        }

        [TestMethod]
        public void TestCanDoHardAddition()
        {
            _calc.Number(5);
            _calc.Number(8);
            _calc.Number(2);
            _calc.Plus();
            _calc.Number(3);
            _calc.Number(3);
            _calc.Number(7);
            _calc.Number(1);
            _calc.Number(2);
            _calc.Equals();
            Assert.AreEqual(34294, _calc.Result);
        }

        [TestMethod]
        public void TestCanDoSubtraction()
        {
            _calc.Number(8);
            _calc.Number(2);
            _calc.Minus();
            _calc.Number(1);
            _calc.Number(3);
            _calc.Equals();
            Assert.AreEqual(69, _calc.Result);
        }

        [TestMethod]
        public void TestCanDoMultiplication()
        {
            _calc.Number(1);
            _calc.Number(1);
            _calc.Times();
            _calc.Number(1);
            _calc.Number(3);
            _calc.Equals();
            Assert.AreEqual(143, _calc.Result);
        }

        [TestMethod]
        public void TestCanDoDivision()
        {
            _calc.Number(3);
            _calc.Number(2);
            _calc.Over();
            _calc.Number(8);
            _calc.Equals();
            Assert.AreEqual(4, _calc.Result);
        }

        [TestMethod]
        public void TestCanDoNumberInitially()
        {
            Assert.IsTrue(_calc.CanDoNumber());
        }

        [TestMethod]
        public void TestCanDoNumberAfterOperator()
        {
            _calc.Number(5);
            _calc.Plus();
            Assert.IsTrue(_calc.CanDoNumber());
        }

        [TestMethod]
        public void TestCantDoNumberAfterEquals()
        {
            _calc.Number(5);
            _calc.Plus();
            _calc.Number(5);
            _calc.Equals();
            Assert.IsFalse(_calc.CanDoNumber());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestNumberThrowsOnInappropriateCall()
        {
            _calc.Number(5);
            _calc.Plus();
            _calc.Number(5);
            _calc.Equals();
            _calc.Number(5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNoNegativeNumbers()
        {
            _calc.Number(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNoLargeNumbers()
        {
            _calc.Number(10);
        }

        [TestMethod]
        public void TestCantDoEqualsInitially()
        {
            Assert.IsFalse(_calc.CanDoEquals());
        }

        [TestMethod]
        public void TestCanDoEqualsAfterSecondOperand()
        {
            _calc.Number(5);
            _calc.Plus();
            _calc.Number(5);
            Assert.IsTrue(_calc.CanDoEquals());
        }

        [TestMethod]
        public void TestCantDoEqualsAfterEquals()
        {
            _calc.Number(5);
            _calc.Plus();
            _calc.Number(5);
            _calc.Equals();
            Assert.IsFalse(_calc.CanDoEquals());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestEqualsThrowsOnInappropriateCall()
        {
            _calc.Equals();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestResultThrowsOnInappropriateCall()
        {
            var test = _calc.Result;
        }

        [TestMethod]
        public void TestCanDoClear()
        {
            Assert.IsTrue(_calc.CanDoClear());
        }

        [TestMethod]
        public void TestCanDoNumberAfterClear()
        {
            _calc.Number(5);
            _calc.Plus();
            _calc.Number(5);
            _calc.Equals();
            _calc.Clear();
            Assert.IsTrue(_calc.CanDoNumber());
        }

        [TestMethod]
        public void TestCanDoOperatorAfterClear()
        {
            _calc.Number(5);
            _calc.Plus();
            _calc.Number(5);
            _calc.Equals();
            _calc.Clear();
            _calc.Number(5);
            Assert.IsTrue(_calc.CanDoOperator());
        }

        [TestMethod]
        public void TestDisplayShouldBeZeroInitially()
        {
            Assert.AreEqual("0", _calc.Display);
        }

        [TestMethod]
        public void TestDisplayShouldShowOperand1()
        {
            _calc.Number(1);
            _calc.Number(2);
            _calc.Number(3);
            Assert.AreEqual("123", _calc.Display);
        }

        [TestMethod]
        public void TestDisplayShouldShowOperator()
        {
            _calc.Number(1);
            _calc.Plus();
            Assert.AreEqual("1 + ", _calc.Display);
        }

        [TestMethod]
        public void TestDisplayShouldShowOperand2()
        {
            _calc.Number(1);
            _calc.Number(2);
            _calc.Number(3);
            _calc.Plus();
            _calc.Number(4);
            _calc.Number(5);
            _calc.Number(6);
            Assert.AreEqual("123 + 456", _calc.Display);
        }

        [TestMethod]
        public void TestDisplayShouldShowResult()
        {
            _calc.Number(1);
            _calc.Number(2);
            _calc.Times();
            _calc.Number(4);
            _calc.Number(4);
            _calc.Equals();
            Assert.AreEqual("528", _calc.Display);
        }

        [TestMethod]
        public void TestDisplayShouldBeZeroAfterClear()
        {
            _calc.Number(1);
            _calc.Plus();
            _calc.Clear();
            Assert.AreEqual("0", _calc.Display);
        }
    }
}
