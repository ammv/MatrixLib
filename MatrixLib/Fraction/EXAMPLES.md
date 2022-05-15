# Fraction examples

## Compare
```cs
Fraction A = new Fraction(13,26); // 13/26
Fraction B = new Fraction(4, 7); // 4/7
Fraction C = (A * B) / B; // 13/26 -> 1/2
Console.WriteLine(A == C); // true
Console.WriteLine(B > C); // true
Console.WriteLine(A >= B); // false
```

## Arithmetic operations
```cs
double pi = 3.14;
sbyte x = -50;
Fraction A = Fraction.ToFraction(pi);
Fraction B = Fraction.ToFraction(x);
Fraction C = (A + B) / x;
Fraction D = (C * pi) + (x + A) * -B;
Console.WriteLine(D);
```

## Operations with arrays
```cs
int n = 10;
Fraction[] A = new Fraction[n];
Fraction[] B = Fraction.ZeroArray(n);
for(int i = 0; i < n; i++)
{
	A[i] = (B[i] - new Fraction(i, i*i+1))*2;
	Console.WriteLine(A[i]);
}
Console.WriteLine();

for(int i = 0; i < n; i++)
Console.WriteLine(B[i] - A[i]);
```