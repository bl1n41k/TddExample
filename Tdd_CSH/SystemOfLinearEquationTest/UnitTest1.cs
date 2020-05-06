using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2;

namespace SystemOfLinearEquationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CorrectIndexing()
        {
            int n = 3;
            SystemOfLinearEquation s = new SystemOfLinearEquation(n);
            s.Add(new LinearEquation("1, -2, 4, 3"));
            s.Add(new LinearEquation("-2, 5, 7, 3"));
            s.Add(new LinearEquation("-3, 3, -7, 6"));
            Assert.AreEqual(new LinearEquation("-3, 3, -7, 6"), s[2]);
        }

        [TestMethod]
        public void CorrectAnswer()
        {
            int n = 3;
            SystemOfLinearEquation s = new SystemOfLinearEquation(n);
            s.Add(new LinearEquation("1, -2, 4, 3"));
            s.Add(new LinearEquation("-4, 5, 7, 3"));
            s.Add(new LinearEquation("-3, 3, -7, 6"));
            s.StepUp();
            double[] solve1 = new double[] {-7, -5, 0};
            double[] solve2 = s.Solve();
            bool check = true;
            for (int i = 0; i < n; i++)
            {
                if (Math.Abs(solve1[i] - solve2[i]) > 1e-9) check = false;
            }
            Assert.AreEqual(true, check);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckNoSolutions()
        {
            int n = 3;
            SystemOfLinearEquation s = new SystemOfLinearEquation(n);
            s.Add(new LinearEquation("3, 6, 4, 5"));
            s.Add(new LinearEquation("5, 10, 8, 7"));
            s.Add(new LinearEquation("-5, -10, -8, -7"));
            s.StepUp();
            Assert.Equals(typeof(ArgumentException), s.Solve());
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InfinitelyManySolutions()
        {
            int n = 3;
            SystemOfLinearEquation s = new SystemOfLinearEquation(n);
            s.Add(new LinearEquation("1, 4,-7, 10"));
            s.Add(new LinearEquation("-1, 4, 3, -14"));
            s.Add(new LinearEquation("-1, 4, 3, -14"));
            s.StepUp();
            Assert.Equals(typeof(ArgumentException), s.Solve());
        }
    }
}
