#include "pch.h"
#include "CppUnitTest.h"
#include"../Task2/LinearEquation.h";
#include"../Task2/LinearEquation.cpp";
using namespace Microsoft::VisualStudio::CppUnitTestFramework;
using namespace std;
namespace LinearEquationTest
{
	TEST_CLASS(LinearEquationTest)
	{
	public:

		TEST_METHOD(CorrectIndex1)
		{
			vector<double>coefficient{ 1.7, 2, 3.1, 4, 5 };
			LinearEquation a(coefficient);
			Assert::AreEqual(3.1, a[2]);
		}
		TEST_METHOD(CorrectIndex2)
		{
			string s = "1, 2, 3, 4,5, 5.5, 12";
			LinearEquation a(s);
			Assert::AreEqual(12.0, a[6]);
		}

		TEST_METHOD(CorrectIndex3)
		{
			LinearEquation a(6);
			Assert::AreEqual(0.0, a[5]);
		}
		TEST_METHOD(CorrectMult1)
		{
			string s = "1, 2, 3, 4, 7";
			LinearEquation a(s);
			a = a * 10.0;
			Assert::AreEqual(30.0, a[2]);
		}
		TEST_METHOD(CorrectMult2)
		{
			string s = "1, 2, 3, 4, 7";
			LinearEquation a(s);
			a = 10.0 * a;
			Assert::AreEqual(70.0, a[4]);
		}

		TEST_METHOD(CorrectSum)
		{
			string s1 = "5, 2, 4, 4, 8, 10, 17.3";
			string s2 = "-5, -2, -4, -4, 0, -10.5, -7.3";
			LinearEquation a1(s1);
			LinearEquation a2(s2);
			LinearEquation result("12,18,51.7,0,8,6.1,6,8");
			Assert::AreEqual(true, result == (a1 + a2));
		}
		TEST_METHOD(CorrectSub)
		{
			string s1 = "0, 1, 3, 0, 12";
			string s2 = "0, 2, 2, 4, 6";
			LinearEquation a1(s1);
			LinearEquation a2(s2);
			LinearEquation result("0, -1, 1, -4, 6");
			Assert::AreEqual(true, result == (a1 - a2));
		}

		TEST_METHOD(CorrectSameInitialization)
		{
			LinearEquation a(5);
			a.same_initialization(1.7);
			Assert::AreEqual(1.7, a[3]);
		}

		TEST_METHOD(CorrectUnaryMinus)
		{
			LinearEquation a("1, 4, -3, -4, 5");
			a = -a;
			Assert::AreEqual(3.0, a[2]);
		}

		TEST_METHOD(ContradictoryEquation)
		{
			LinearEquation a("0, 0, 0, 10");
			bool check = (a) ? true : false;
			Assert::AreEqual(false, check);
		}


		TEST_METHOD(SolvableEquation)
		{
			LinearEquation a("12, 5, 3, 10");
			bool check = (a) ? true : false;
			Assert::AreEqual(true, check);
		}

		TEST_METHOD(CopyToList)
		{
			LinearEquation a("4,2,1,5");
			list<double> temp = a;
			Assert::AreEqual(4.0, temp.front());
		}
	};
}
