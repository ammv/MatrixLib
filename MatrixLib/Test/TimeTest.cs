using MatrixLib;
using System.Diagnostics;

class TimeTest
{
	static int N = 1000;
	static Stopwatch sw = new Stopwatch();
	static Stopwatch sw2 = new Stopwatch();
	public static void Run()
	{
		sw2.Start();
		TestEquation();
		TestMatrix();
		TestFraction();
		sw2.Stop();
		Console.WriteLine("Test taked time - {0}ms",
			sw2.Elapsed.Milliseconds);
	}
	public static void TestEquation()
	{
		double[,] equation = {{1,-10, -15},
							{-10, 6, 38}};
		double[,] equation2 = {
			{15,73,-34.64, 67918.08},
			{14,16,17,-15494.5},
			{-15,-1/6, 1/3,-439.0}};

		Matrix A = new Matrix(equation);
		Matrix B = new Matrix(equation2);
		
		sw.Start();
		for(int i = 0; i < N; i++)
			Equation.KramerMethod(A);
		sw.Stop();
		Console.WriteLine("Equation with 2 roots taked time - {0}ms",
			sw.Elapsed.Milliseconds/(double)N );
			
		sw.Reset();
		sw.Start();
		for(int i = 0; i < N; i++)
			Equation.KramerMethod(B);
		sw.Stop();
		Console.WriteLine("Equation with 3 roots taked time - {0}ms",
			sw.Elapsed.Milliseconds/(double)N);
	}
	public static void TestMatrix()
	{
		double[,] values2 = {
			{1,6},
			{-63,21}};
		double[,] values3 = {
			{1,6,16},
			{-63,21,-10},
			{144,152,134}};
		double[,] values4 = {
			{1,6,16,11},
			{-63,21,-10,64},
			{144,152,134,0.55},
			{43,154,11,2}};
			
		Matrix A = new Matrix(values2);
		Matrix B = new Matrix(values3);
		Matrix C = new Matrix(values4);
		Matrix temp;
			
		sw.Reset();
		sw.Start();
		for(int i = 0; i < N; i++)
			temp = (A * A.Inv);
		
		sw.Stop();
		Console.WriteLine("Rank2: Getting single matrix from product Matrix and Inverse Matrix taked time - {0}ms",
			sw.Elapsed.Milliseconds/(double)N );
		
		sw.Reset();		
		sw.Start();
		for(int i = 0; i < N; i++)
			temp = (B * B.Inv);
		
		sw.Stop();
		Console.WriteLine("Rank3: Getting single matrix from product Matrix and Inverse Matrix taked time - {0}ms",
			sw.Elapsed.Milliseconds/(double)N );
		
		sw.Reset();
		sw.Start();
		for(int i = 0; i < N; i++)
			temp = (C * C.Inv);
		
		sw.Stop();
		Console.WriteLine("Rank4: Getting single matrix from product Matrix and Inverse Matrix taked time - {0}ms",
			sw.Elapsed.Milliseconds/(double)N );
		
	}
	public static void TestFraction()
	{
		Fraction temp;
		sw.Reset();
		sw.Start();
		for(int i = 0; i < N; i++)
			temp = Fraction.ToFraction(124.345643d);
		
		sw.Stop();
		Console.WriteLine("ToFraction(double) taked time - {0}ms",
			sw.Elapsed.Milliseconds/(double)N );
			
		sw.Reset();
		sw.Start();
		for(int i = 0; i < N; i++)
			temp = Fraction.ToFraction(2525234);
		
		sw.Stop();
		Console.WriteLine("ToFraction(int) taked time - {0}ms",
			sw.Elapsed.Milliseconds/(double)N );
		
		sw.Reset();
		sw.Start();
		for(int i = 0; i < N; i++)
			temp = new Fraction(12312, 25325);
		
		sw.Stop();
		Console.WriteLine("new Fraction(long, long) taked time - {0}ms",
			sw.Elapsed.Milliseconds/(double)N );
	}
}