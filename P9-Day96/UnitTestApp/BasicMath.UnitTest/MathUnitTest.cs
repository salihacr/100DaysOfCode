using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BasicMath.UnitTest
{
    [TestClass]
    public class MathUnitTest
    {
        [TestMethod]
        public void Test_AddMethod()
        {
            BasicMaths bm = new BasicMaths();
            double result = bm.Add(10, 10);
            Assert.AreEqual(result, 20);
        }
        [TestMethod]
        public void Test_SubstractMethod()
        {
            BasicMaths bm = new BasicMaths();
            double result = bm.Substract(10, 10);
            Assert.AreEqual(result, 0);
        }
        [TestMethod]
        public void Test_DivideMethod()
        {
            BasicMaths bm = new BasicMaths();
            double result = bm.Divide(10, 5);
            Assert.AreEqual(result, 2);
        }
        [TestMethod]
        public void Test_MultiplyMethod()
        {
            BasicMaths bm = new BasicMaths();
            double result = bm.Multiply(10, 10);
            Assert.AreEqual(result, 100);
        }
    }
}
