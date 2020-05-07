#include "LinearEquation.h"
#include<ctime>
#include<iostream>
#include<stdexcept>
#include<regex>
#include<list>
using namespace std;

vector<string> LinearEquation::resplit(const string& s, string rgx_str) {
	vector<string> element;
	regex Regex(rgx_str);
	sregex_token_iterator iterator(s.begin(), s.end(), Regex, -1);
	std::sregex_token_iterator end;
	while (iterator != end) {
		element.push_back(*iterator);
		++iterator;
	}
	return element;
}
LinearEquation::LinearEquation(string _s)
{
	vector<string> s = resplit(_s, "[^\\d-.]");
	for (int i = 0; i < s.size(); i++)
		if (s[i] != "") coefficients.push_back(stod(s[i].c_str()));
}
LinearEquation::LinearEquation(list<double>a)
{
	copy(a.begin(), a.end(), back_inserter(coefficients));
}
LinearEquation::LinearEquation(vector<double>a)
{
	coefficients = a;
}
LinearEquation::LinearEquation(int n)
{
	coefficients.resize(n + 1);
}

void LinearEquation::random_initialization()
{

	for_each(coefficients.begin(), coefficients.end(), [](double& t) {t = (rand() % 100) / 10.0; });
}

void LinearEquation::same_initialization(double value)
{
	for_each(coefficients.begin(), coefficients.end(), [value](double& t) {t = value; });
}
double& LinearEquation::operator[](int index)
{
	if (index >= 0 && index < coefficients.size())
		return coefficients.at(index);
	else
		throw std::out_of_range("����� �� �������.");
}
LinearEquation LinearEquation::operator*(const double& k)
{
	vector<double> result = coefficients;
	for_each(result.begin(), result.end(), [k](double& t) {t *= k; });
	return LinearEquation(result);
}

LinearEquation operator*(double k, LinearEquation& a)
{
	return a * k;
}

LinearEquation LinearEquation::operator+(LinearEquation& b)
{
	vector<double> result = coefficients;
	for (int i = 0; i < size(); i++)
		result[i] += b[i];
	return LinearEquation(result);
}

LinearEquation LinearEquation::operator-(LinearEquation& b)
{
	vector<double> result = coefficients;
	for (int i = 0; i < size(); i++)
		result[i] -= b[i];
	return LinearEquation(result);
}
LinearEquation LinearEquation::operator-()
{
	vector<double> result = coefficients;
	for_each(result.begin(), result.end(), [](double& t) {t = -t; });
	return LinearEquation(result);
}
LinearEquation::operator string()
{
	string result = "";
	int i;
	for (i = 0; i < size() - 2; i++)
	{
		result += (coefficients[i + 1] >= 0) ? (to_string(coefficients[i]) + 'x' + to_string((i + 1)) + '+') : (to_string(coefficients[i]) + 'x' + to_string((i + 1)));
	}
	result += (to_string(coefficients[i]) + 'x' + to_string((i + 1)));
	result += '=' + to_string(coefficients[size() - 1]);
	return result;
}
LinearEquation::operator bool()
{
	for (int i = 0; i < size() - 1; i++)
		if (coefficients[i] != 0) return true;
	return (coefficients[size() - 1] != 0) ? false : true;
}

LinearEquation::operator list<double>()
{
	list<double> coefficient;
	copy(coefficients.begin(), coefficients.end(), back_inserter(coefficient));
	return coefficient;
}
bool LinearEquation::isNull()
{
	for (int i = 0; i < size(); i++)
		if (coefficients[i] != 0)
			return false;
	return true;
}
bool operator==(LinearEquation& a, LinearEquation& b)
{
	for (int i = 0; i < a.size(); i++) {
		if (abs(a[i] - b[i]) > 1e-9)
			return false;
	}
	return true;
}

bool operator!=(LinearEquation& a, LinearEquation& b)
{
	return !(a == b);
}