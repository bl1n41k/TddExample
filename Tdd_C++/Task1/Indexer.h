#pragma once
class Indexer
{
private:
	double* arr;
	int begin;
	int length;

public:
	Indexer(double* arr, int, int, int);
	~Indexer() {}
	int getLength() { return length; }
	double& operator[] (int index);

};