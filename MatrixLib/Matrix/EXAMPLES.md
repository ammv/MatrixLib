# Matrix examples

## Arithmetic operations
```cs
double[,] values = {{1,2,3},
					{6,1,-5},
					{0,5,11}};
Matrix A = new Matrix(values);
Matrix B = Matrix.ZeroArray(3,3);
Matrix C = B - A;
C.Pow(2).Display("Matrix C");
```

## Compares links and values
```cs
double[,] values = {{1,2,3},
					{6,1,-5},
					{0,5,11}};
Matrix A = new Matrix(values);
Console.WriteLine(A*A == A.Pow(2));

Matrix B = A.Clone();
Console.WriteLine(A == B);
```

## Get minor and algebraic complement
```cs
double[,] values = {{1,2,3},
			{6,1,-5},
			{0,5,11}};
Matrix A = new Matrix(values);
A.Minor(1).Display("Minor", true);
Console.WriteLine("Determinant = " + A.Minor(2,1).Det);
```