#pragma once
#include<vector>
#include<string>
#include<list>
using namespace std;
class LinearEquation
{
private:
	vector<double> coefficients;
	vector<string> resplit(const string&, string);
public:

	LinearEquation(list<double>);
	LinearEquation(vector<double>);
	LinearEquation(string coeff);
	LinearEquation(int n);
	~LinearEquation() { vector<double>().swap(coefficients); };

	int size() { return coefficients.size(); }
	void random_initialization();
	void same_initialization(double);
	bool isNull();

	double& operator[] (int index);
	LinearEquation operator+(LinearEquation&);
	LinearEquation operator-(LinearEquation&);
	LinearEquation operator-();
	operator bool();
	operator string();
	operator list<double>();
	LinearEquation operator*(const double&);
	friend LinearEquation operator*(double, LinearEquation&);
};
bool operator!=(LinearEquation&, LinearEquation&);
bool operator==(LinearEquation&, LinearEquation&);
