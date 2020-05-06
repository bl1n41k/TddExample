using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2;

namespace LinearEquationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
         public void InitializationArray()
        {
            const int n = 5;
            double[] coefficient = new double[n] { 1.7, 2, 3.1, 4, 5 };
            LinearEquation a1 = new LinearEquation(coefficient);
            Assert.AreEqual(3.1, a1[2]);
        }

        [TestMethod]
        public void InitializationList()
        {
            List<double> coefficient = new List<double>() { 1, 2.5, 3, 4, 5, 6 };
            LinearEquation a1 = new LinearEquation(coefficient);
            Assert.AreEqual(4, a1[3]);
        }

        [TestMethod]
        public void InitializationString()
        {
            string coefficient = "1, 2, 3, 4,5, 5.5, 12";
            LinearEquation a1 = new LinearEquation(coefficient);
            Assert.AreEqual(12, a1[6]);
        }

        [TestMethod]
        public void InitializationZero()
        {
            int n = 6;
            LinearEquation a = new LinearEquation(n);
            Assert.AreEqual("0x1+0x2+0x3+0x4+0x5+0x6=0", a.ToString());
        }

        [TestMethod]
        public void CorrectSum()
        {
            string coefficient_1 = "5, 2, 4, 4, 8, 10, 17.3";
            LinearEquation a1 = new LinearEquation(coefficient_1);
            string coefficient_2 = "-5, -2, -4, -4, 0, -10.5, -7.3";
            LinearEquation a2 = new LinearEquation(coefficient_2);
            string result = "0, 0, 0, 0, 8, -0.5, 10";
            Assert.AreEqual(new LinearEquation(result), a1 + a2);
        }

        [TestMethod]
        public void CorrectSub()
        {
            string coefficient_1 = "0, 1, 3, 0, 12";
            LinearEquation a1 = new LinearEquation(coefficient_1);
            string coefficient_2 = "0, 2, 2, 4, 6";
            LinearEquation a2 = new LinearEquation(coefficient_2);
            string result = "0, -1, 1, -4, 6";
            Assert.AreEqual(new LinearEquation(result), a1 - a2);
        }

        [TestMethod]
        public void CorrectUnaryMinus()
        {
            string coefficient = "1, 4, -3, -4, 5";
            LinearEquation a = new LinearEquation(coefficient);
            string result = "-1, -4, 3, 4, -5";
            Assert.AreEqual(new LinearEquation(result), -a);
        }

        [TestMethod]
        public void CorrectMult1()
        {
            string coefficient = "1, 2, 3, 4, 7";
            LinearEquation a = new LinearEquation(coefficient);
            string result = "10, 20, 30, 40, 70";
            Assert.AreEqual(new LinearEquation(result), a * 10);
        }

        [TestMethod]
        public void CorrectMult2()
        {
            string coefficient = "1, 2, 3, 4, 7";
            LinearEquation a = new LinearEquation(coefficient);
            string result = "10, 20, 30, 40, 70";
            Assert.AreEqual(new LinearEquation(result), 10 * a);
        }

        [TestMethod]
        public void CorrectIndexing()
        {
            string coefficient = "1, 2, 3, 4, 5";
            LinearEquation a = new LinearEquation(coefficient);
            Assert.AreEqual(4, a[3]);
        }

        [TestMethod]
        public void CorrectSameInitialization()
        {
            LinearEquation a = new LinearEquation(5);
            a.SameInitialization(1.7);
            string result = "1.7, 1.7, 1.7, 1.7, 1.7";
            Assert.AreEqual(new LinearEquation(result), a);
        }

        [TestMethod]
        public void ContradictoryEquation()
        {
            string result = "0, 0, 0, 10";
            LinearEquation a = new LinearEquation(result);
            bool check = (a) ? true: false;
            Assert.AreEqual(false, check);
        }

        [TestMethod]
        public void SolvableEquation()
        {
            string result = "12, 5, 3, 10";
            LinearEquation a = new LinearEquation(result);
            bool check = (a) ? true : false;
            Assert.AreEqual(true, check);
        }
    }
}
