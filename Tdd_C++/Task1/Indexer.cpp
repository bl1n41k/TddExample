#include "Indexer.h"
#include<stdexcept>
#include<exception>
using namespace std;

Indexer::Indexer(double* arr, int arrLength, int begin, int length)
{
	if (begin<0 || length <= 0 || begin + length>arrLength) throw invalid_argument("Недопустимое значение");
	else
	{
		this->arr = arr;
		this->begin = begin;
		this->length = length;
	}
}
double& Indexer::operator[](int index)
{
	if (index<0 || index + begin>length) throw out_of_range("Недопустимое значение");
	else return arr[begin + index];
}
