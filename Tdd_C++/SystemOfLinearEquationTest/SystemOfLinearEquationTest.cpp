#include "pch.h"
#include "CppUnitTest.h"
#include"../Task2/SystemLinearEquation.h"
#include"../Task2/SystemLinearEquation.cpp"
#include"../Task2/LinearEquation.h"
#include"../Task2/LinearEquation.cpp"
using namespace Microsoft::VisualStudio::CppUnitTestFramework;
using namespace std;
namespace SystemLinearEquationTest
{
	TEST_CLASS(SystemLinearEquationTest)
	{
	public:

		TEST_METHOD(CorrectIndex)
		{   
			int n = 3;
			SystemLinearEquation s(n);
			s.Add(LinearEquation("1, -2, 4, 3"));
			s.Add(LinearEquation("-2, 5, 7, 3"));
			s.Add(LinearEquation("-3, 3, -7, 6"));
			Assert::AreEqual(7.0, s[1][2]);
		}
		TEST_METHOD(CorrectAnswer)
		{
			int n = 3;
			SystemLinearEquation s(n);
			LinearEquation a1("1, -2, 4, 3");
			LinearEquation a2("-4, 5, 7, 3");
			LinearEquation a3("-3, 3, -7, 6");
			s.Add(a1);
			s.Add(a2);
			s.Add(a3);
			s.StepUp();
			vector<double> solve1 = s.solveSystem();
			bool check = true;
			vector<double>solve2{-7,-5,0};
			for (int i = 0; i < solve1.size(); i++)
			{
				if (abs(solve1[i] - solve2[i]) > 1e-9) check = false;
			}
			Assert::AreEqual(true, check);
		}

		TEST_METHOD(CheckNoSolutions)
		{
			auto func = []()
			{
				int n = 3;
				SystemLinearEquation s(n);
				LinearEquation a1("3, 6, 4, 5");
				LinearEquation a2("5, 10, 8, 7");
				LinearEquation a3("-5, -10, -8, -7");
				s.Add(a1);
				s.Add(a2);
				s.Add(a3);
				s.StepUp();
				vector<double> solve1 = s.solveSystem();
			};
			Assert::ExpectException<invalid_argument>(func);
		}

		TEST_METHOD(InfinitelyManySolutions)
		{
			auto func = []()
			{
				int n = 3;
				SystemLinearEquation s(n);
				LinearEquation a1("1, 4,-7, 10");
				LinearEquation a2("-1, 4, 3, -14");
				LinearEquation a3("-1, 4, 3, -14");
				s.Add(a1);
				s.Add(a2);
				s.Add(a3);
				s.StepUp();
				vector<double> solve1 = s.solveSystem();
			};
			Assert::ExpectException<invalid_argument>(func);
		}
	};
}