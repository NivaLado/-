#include<iostream>
#include<math.h>

using namespace std;

void show(double* arr, int n);

int main()
{
	const int n = 3;

	double matrix[n][n] = {
		{2, -5, 3},
		{4, -2, 1},
		{1, 2, -3},
	};

	double vector[n] = { -7, 0, 1,};

	for (int i = 0; i < n; i++) {
		for (int k = i; k < n; k++) {
			if (fabs(matrix[i][i] < fabs(matrix[k][i]))) {
				swap(matrix[i], matrix[k]);
				swap(vector[i], vector[k]);
			}
		}

		for (int j = i + 1; j < n; j++) {
			double d = (matrix[j][i] / matrix[i][i]);
			for (int k = i; k < n; k++) {
				matrix[j][k] = matrix[j][k] - d * matrix[i][k];
			}
			vector[j] = vector[j] - d * vector[i];
		}
	}

	double *X = new double[n];

	for (int i = n - 1; i >= 0; i--) {
		double result = 0;
		for (int j = i + 1; j < n; j++) {
			result += matrix[i][j] * X[j];
		}
		X[i] = (vector[i] - result) / matrix[i][i];
	}

	cout << "X" << endl;
	show(X, n);
	system("PAUSE");
}

void show(double* arr, int n)
{
	for (int i = 0; i < n; i++)
	{
		cout << arr[i] << " ";
	}
	cout << endl;
}