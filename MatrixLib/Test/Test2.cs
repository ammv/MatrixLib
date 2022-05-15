using MatrixLib;
using System.Diagnostics;

class Test2
{
	static void Main()
	{
		double[,] values = {
			{3,2,-1,4},
			{2,-1,5,23},
			{1,7,-1,5}
		};
		double[,] values2 = {
			{-1, 2, 3, -4, 30, 78}, 
			{7, 2, 5, 1, 30, 41},
			{3, -8, 1, 6, 46, 12},
			{4, 3, -7, 2, 39, 11},
			{1,9,-9,-19,63,42}
			};
		Matrix A = new Matrix(values2);
		var solution = Equation.GaussMethod(A);
		solution[2] -= 1;
		Console.WriteLine(String.Join(", ", solution));
		Console.WriteLine(Equation.CheckVariables(A, solution));
	}
	static void TimeTestMethods()
	{
		// Extended matrix
		Console.Clear();
		
		double[,] values = {
			{-1, 2, 3, -4, 30, 78}, 
			{7, 2, 5, 1, 30, 41},
			{3, -8, 1, 6, 46, 12},
			{4, 3, -7, 2, 39, 11},
			{1,9,-9,-19,63,42}
			};
			
		Matrix A = new Matrix(values);
		
		int N = 1000; // Loops
		Fraction[] solution;
		double[] time = new double[3];
		
		Stopwatch swMethods = new Stopwatch(); // Timer for methods
		Stopwatch swTest = new Stopwatch(); // Timer for test
		
		string[] methodsTitles = {"Gauss", "Kramer", "Matrix"}; // Titles of methods
		var methods = new Func<Matrix, Fraction[]>[3]{ // Methods
			Equation.GaussMethod,
			Equation.KramerMethod,
			Equation.MatrixMethod};
		
		Console.WriteLine("Testing the methods for solving equations." +
			"\nRank of the coefficient matrix: " + values.GetLength(0) + 
			"\nLoops: " + N + "\n");
			
		swTest.Start();
		for(int i = 0; i < methodsTitles.Length; i++)
		{
			swMethods.Start();
			for(int k = 0; k < N; k++)
				solution = methods[i](A);
			swMethods.Stop();
			time[i] = swMethods.Elapsed.Milliseconds / (double)N;
			Console.WriteLine("[+] {0} method took {1}ms.",
				methodsTitles[i],
				time[i]);
			swMethods.Reset();
		}
		swTest.Stop();
		double sumTimes = 0;
		foreach(var i in time) sumTimes += i;
		Console.WriteLine("\nThe methods took {0}ms together.", sumTimes);
		Console.WriteLine("Test took {0}ms.", swTest.Elapsed.Milliseconds);
	}
}

/*
	Testing the methods for solving equations.
	Rank of the coefficient matrix: 4
	Loops: 100
	
	[+] Gauss solution took 24 seconds
	[+] Matrix solution took 24 seconds
	[+] Kramer solution took 24 seconds
	
	Test took 465 seconds
*/
