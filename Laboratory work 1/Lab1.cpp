#include <iostream>
#include <iomanip>
#include <vector>

using namespace std;

// Algorithm
	// 1. Forward Elimination ( Made matrix to satisfy Echelon form)
	// 2. Back Substitution (Going backwards solve equations)

double firstEquation[3][4] =
{
	{ 1, -2,  3,  2},
	{ 2, -5, -1, -1},
	{ -7,  2,  3, -2},
};

void OutputMatrix(double** matrix, int dimension);

int main()
{
	int dimension = 3;
	//cin >> dimension;
	cout.precision(4);
	const int COLUMNS = dimension + 1;
	const int ROWS = dimension;

	// Memory allocated for elements of rows.
	double** dynamicArray = nullptr;

	// Memory allocated for  elements of each column.
	dynamicArray = new double* [ROWS];

	for (int i = 0; i < ROWS; i++)
	{
		dynamicArray[i] = new double[COLUMNS];
	}

	// Fill matrix with data
	for (int i = 0; i < ROWS; i++)
	{
		for (int j = 0; j < COLUMNS; j++)
		{
			dynamicArray[i][j] = firstEquation[i][j];
		}
	}

	OutputMatrix(dynamicArray, dimension);

	// Pick of lead selection (Pivot)
	for (int i = 0; i < dimension; i++) 
	{
		for (int k = i + 1; k < dimension; k++)
		{
			if (abs(dynamicArray[i][i]) < abs(dynamicArray[k][i])) // Bubble row with the largest module of current column
			{
				for (int j = 0; j <= dimension; j++) // Swap whole row
				{
					double temp = dynamicArray[i][j];
					dynamicArray[i][j] = dynamicArray[k][j];
					dynamicArray[k][j] = temp;
				}
			}
		}
	}

	//OutputMatrix(dynamicArray, dimension);

	// Forward Elimination
	for (int i = 0; i < dimension - 1; i++)
	{
		for (int k = i + 1; k < dimension; k++)
		{
			double t = dynamicArray[k][i] / dynamicArray[i][i];
			for (int j = 0; j <= dimension; j++)
			{
				dynamicArray[k][j] = dynamicArray[k][j] - (t * dynamicArray[i][j]);
			}
		}
	}

	OutputMatrix(dynamicArray, dimension);

	// Back Substitution
	double x[3];
	for (int i = dimension-1; i >= 0; i--)
	{
		x[i] = dynamicArray[i][dimension];

		for (int j = 0; j < dimension; j++)
		{
			if (j != i)
			{
				x[i] = x[i] - dynamicArray[i][j] * x[j];
			}
		}

		x[i] = x[i] / dynamicArray[i][i];
	}

	cout << "\n";
	for (int i = 0; i < 3; i++)
	{
		cout << "\n"; 
		cout << "X " << i <<  " is equal to : " << x[i] << endl;;
	}

	// GC
	for (int i = 0; i < ROWS; i++)
		delete[] dynamicArray[i];

	delete[] dynamicArray;

	return 0;
}

void OutputMatrix(double** matrix, int dimension)
{
	cout << "\n";
	for (int i = 0; i < dimension; i++)
	{
		cout << "\n";
		for (int j = 0; j < dimension + 1; j++)
		{
			cout << matrix[i][j] << " ";
		}
	}
}