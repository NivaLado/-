#include <iostream>
#include <iomanip>
#include <vector>

using namespace std;

// Algorithm
	// 1. Forward Elimination ( Made matrix to satisfy Echelon form)
	// 2. Back Substitution (Going backwards solve equations)

float firstEquation[3][4] =
{
	{ 1, -2,  3,  2},
	{ 2, -5, -1, -1},
	{ -7,  2,  3, -2},
};

void OutputMatrix(int** matrix, int dimension);

int main()
{
	int dimension = 3;
	//cin >> dimension;

	const int COLUMNS = dimension + 1;
	const int ROWS = dimension;

	// Memory allocated for elements of rows.
	int** dynamicArray = nullptr;

	// Memory allocated for  elements of each column.
	dynamicArray = new int* [ROWS];

	for (int i = 0; i < ROWS; i++)
	{
		dynamicArray[i] = new int[COLUMNS];
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

	for (int i = 0; i < dimension; i++) // Pick of lead selection (Pivot)
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

	OutputMatrix(dynamicArray, dimension);

	// GC
	for (int i = 0; i < ROWS; i++)
		delete[] dynamicArray[i];

	delete[] dynamicArray;

	return 0;
}

void OutputMatrix(int** matrix, int dimension)
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