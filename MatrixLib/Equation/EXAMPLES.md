# Equation examples

## Kramer Method
```cs
double[,] values = {{1,4, 2}, {5,1,7}};
Matrix A = new Matrix(values);

Fraction[] solution = Equation.Method(A);
for(int i = 0; i < solution.Length; i++)
Console.WriteLine("x{0} = {1}", i+1, solution[i]);
```

## Gauss Method
```cs
double[,] values = {{1,4, 2}, {5,1,7}};
Matrix A = new Matrix(values);

Fraction[] solution = Equation.GaussMethod(A);
for(int i = 0; i < solution.Length; i++)
Console.WriteLine("x{0} = {1}", i+1, solution[i]);
```

## Matrix Method
```cs
double[,] values = {{1,4, 2},{5,1,7}};
Matrix A = new Matrix(values);

Fraction[] solution = Equation.MatrixMethod(A);
for(int i = 0; i < solution.Length; i++)
Console.WriteLine("x{0} = {1}", i+1, solution[i]);
```
