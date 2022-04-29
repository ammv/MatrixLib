# MatrixLib
## Classes

 - Matrix
 - Fraction
 - Equation
 
## Examples
The examples of code:
- [Matrix](Matrix/EXAMPLES.md)
- [Fraction](Fraction/EXAMPLES.md)
- [Equation](Equation/EXAMPLES.md)
 
## Matrix
The class uses fractions instead of real numbers. Without them, calculations could return non-neat numbers, for example 1.3333.

What can this class do:
- Transpose
- Calculate the determinant
- Find a minor
- Calculate the algebraic complement
- Find a matrix of algebraic complements
- Find the inverse matrix

Operations with matrices:
- Addition, subtraction, multiplication, division of a matrix by a number
- Addition, subtraction, multiplication, division of a matrix by a matrix

| Constructors | What does |
| ------------ | --------- |
| Matrix(`double[,]`) | Transform `double[,]` into `Fraction[,]` |
| Matrix(`long[,]`) | Transform `long[,]` into `Fraction[,]` |
| Matrix(`Fraction[,]`) | just assigns values to fields |

| Properties | Output | What does |
| ------ | ------ | ------ |
| T | `Matrix` | Returns the transposed matrix |
| Rank | `int`| Returns the rank of the matrix |
| Det | `Fraction` | Returns the determinant of the matrix |
| Inv | `Matrix` | Returns the inverse matrix |
| Rows | `int` |  Returns the number of rows |
| Columns | `int` | Returns the number of columns |
| Red | `Matrix` | Returns a reduced matrix |

| Methods | Output | What does |
| ------ | ------ | ------ |
| Transpose | `Matrix` | Returns the transposed matrix |
| Determinant | `Fraction` | Returns the determinant of the matrix |
| CompareSizes(`Matrix`) | `bool` | Checks whether the matrix is the <br>same as the other in size |
| Clone | `Matrix` | Returns a clone of the matrix |
| EmptyMatrix(`int`, `int`) | `Matrix` | Returns an N x M matrix filled with zeros |
| CutColumn(`int`) | `Matrix` | Returns a matrix without the specified column | 
| CutColumns(`int[]`) | `Matrix` | Returns a matrix without the specified columns |
| CutRow(`int`) | `Matrix` | Returns a matrix without the specified row | 
| CutRows(`int[]`) | `Matrix` | Returns a matrix without the specified rows |
| Pow(`int`) | `Matrix` | Returns a matrix to the specified power. <br>`Power must be greater than zero` |  
| Minor(`int`) | `Matrix` | Returns the minor of the matrix of the <br>first row and the specified column |
| Minor(`int`, `int`) | `Matrix` | Returns the minor of the matrix of the <br>specified row and the specified column | 
| AlgComp(`int`, `int`) | `Fraction` | Returns the algebraic complement of the<br> matrix of the specified row and the specified column |
| Display(`string`, `bool`) | | Outputs a matrix to the console with the specified text<br> and a new line at the end if the second parameter is **true**| 
| AlgComp(`int`, `int`) | `Fraction` | Returns the algebraic complement of the matrix<br> of the specified row and the specified column |
| SingleMatrix(`int`) | `Matrix` | Returns a unit matrix of size N x N |
| Reduce | `Matrix` | Return a reduced matrix |
| IsInvertible | `bool` | Returns a value indicating whether it is<br>possible to get an inverse matrix from the matrix |

## Fraction

A class for creating fractions using the Matrix class.

A fraction can be created from the following types:
- Integer types: sbyte, byte, short, ushort, int, uint, long, ulong
- Real types: float, double, decimal

Operations with fractions:
- Addition, subtraction, multiplication, division of a fraction by a number
- Addition, subtraction, multiplication, division of a fraction by a fraction

| Constructors | What does |
| ------------ | --------- |
| Fraction(`long`, `long`) | Creates a fraction with the specified<br>numerator and the specified denominator | 
| Fraction(`long`) | Create a fraction with the specified<br>numerator and the denominator equals to 1 |
| Fraction() | Creates a fraction with a numerator equal<br>to zero and a denominator equal to 1 |

| Properties | Output | What does |
| ------ | ------ |------ |
| N | `int` | Returns the numerator |
| D | `int` |Returns the denominator |
| GCD | `long` |Returns the  greatest commom diviser |
| Reduce | `Fraction` | Returns a reduced fraction |

| Methods | Output | What does |
| ------ | ------ |------ |
| ReduceArray(`Fraction[]`) | `Fraction[]` | Returns a reduced array of fractions |
| ReduceArray(`Fraction[,]`) | `Fraction[,]` |Returns a reduced two-dimensional array of fractions |
| GetRawString | `string` | Returns an unformatted fraction |
| ZeroArray(`int`) | `Fraction[]` | Returns an array of fractions equal to zero |
| ZeroArray(`int`, `int`) | `Fraction[,]` | Returns a two-dimensional array of fractions equal to zero |
| ToFraction(`T`) | `Fraction` |Converts a number to a fraction |
| ToDouble | `double` | Converts a number to a double |
| ToFloat | `float` | Converts a number to a float |
| ToLong | `long` | Converts a number to a long |
| ToInt | `int` | Converts a number to a int |

## Equation

Provides methods for solving matrix equations.

| Methods | Output | What does |
| ------ | ------ |------ |
| IsSolvable(`Matrix`) | `bool`| Returns true if the matrix equation has one solution, otherwise false |
| KramerMethod(`Matrix`) | `Fraction[]` | Returns the roots of the equation |
