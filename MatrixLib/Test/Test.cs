using MatrixLib;
using System;

class Test
{
	public static void Main()
	{
		TestFraction();
		TestMatrix();
		TestEquation();
	}
	public static void TestEquation()
	{
		double[,] equation = {{3,5,1,484.5},
		
							  {-244,-54,6, -25549.0},
							  {33,-22,11, -21235.5}};
		
		Matrix A = new Matrix(equation);
		
		bool isSolvable = Equation.IsSolvable(A);
		
		if(isSolvable)
		{
			Console.WriteLine("Solvable equation");
			Fraction[] roots = Equation.KramerMethod(A);
			for(int i = 0; i < roots.Length; i++)
				Console.WriteLine("x{0} = {1}", i+1, roots[i].ToDouble());
		}
		else
			Console.WriteLine("Unsolable equation");
			
	}
	public static void TestMatrix()
	{
		double[,] values = {{1,2,3},
							{6,34.3, 9.74},
							{13.5, 64.3, 13.6}};
		double[,] values2 = {{13,345,234},
							{6,34.3, 454},
							{-0.5, 111, 13.6}};
							
		Matrix A = new Matrix(values);
		Matrix B = new Matrix(values2);
		
		A.Reduce().Display("Matrix A", true);
		B.Reduce().Display("Matrix B", true);
		
		/* In this code calls follows methods:
			C.Inv ->
			1. Determinant ->
				Minor
			2. FillAlgAdd ->
				AlgAdd
				Minor
				Determinant
			3. Transpose
			4. 1/Determinant * Matrix
		*/
		Matrix C = (-A + B).Reduce();
		Matrix invC = C.Inv;
		
		C.Display("Matrix C", true);
		C.Inv.Display("Matrix inverse C", true);
		(C * C.Inv).Display("Matrix C * C.Inv, here must be single matrix", true);
		Console.WriteLine((C*C.Inv).Equals(Matrix.SingleMatrix(3)));
		
		Console.WriteLine((A * A).Equals(A.Pow(2)));
		
		(A - 1  * (A + 1)).Inv.Reduce().Display();
	}
	public static void TestFraction()
	{
		Type[] smallTypes = {typeof(sbyte), typeof(byte), typeof(short), typeof(ushort), typeof(int), typeof(uint),
			typeof(long), typeof(ulong), typeof(float), typeof(double), typeof(decimal)};
			
		// Small numbers
		sbyte s1 = -121;
		byte s2 = 122;
		short s3 = -3;
		ushort s4 = 5;
		int s5 = 123545;
		uint s6 = 234234;
		long s7 = -2334234;
		ulong s8 = 3434;
		float s9 = 344.53f;
		double s10 = 341.644534;
		decimal s11 = 24.214M;
		
		Type[] bigTypes = {typeof(int), typeof(int), typeof(long), typeof(long), typeof(float), typeof(float),
		typeof(float), typeof(double), typeof(double), typeof(double), typeof(decimal), typeof(decimal), typeof(decimal)};
		
		//Big numbers
		int b1 = Int32.MaxValue;
		int b2 = Int32.MinValue;
		long b3 = Int64.MaxValue;
		long b4 = Int64.MinValue;
		float b5 = 12345678.12345678f;
		float b6 = -0.1234567890f;
		float b7 = 123456789123456789.1235f;
		double b8 = 111222333.111222333;
		double b9 = -0.1234567890123456789;
		double b10 = 111333444555666.1234567890;
		decimal b11 = 123133113.22342432242m;
		decimal b12 = -0.222333444555m;
		decimal b13 = 12345678234234.22342432242m;
		
		Console.WriteLine("#1 Converting small numbers into fractions");
		
		Fraction sf1 = Fraction.ToFraction(s1);
		Console.WriteLine("s1 = {0}\tsf1 = {1}", s1, sf1);
		Fraction sf2 = Fraction.ToFraction(s2);
		Console.WriteLine("s2 = {0}\tsf2 = {1}", s2, sf2);
		Fraction sf3 = Fraction.ToFraction(s3);
		Console.WriteLine("s3 = {0}\t\tsf3 = {1}", s3, sf3);
		Fraction sf4 = Fraction.ToFraction(s4);
		Console.WriteLine("s4 = {0}\t\tsf4 = {1}", s4, sf4);
		Fraction sf5 = Fraction.ToFraction(s5);
		Console.WriteLine("s5 = {0}\tsf5 = {1}", s5, sf5);
		Fraction sf6 = Fraction.ToFraction(s6);
		Console.WriteLine("s6 = {0}\tsf6 = {1}", s6, sf6);
		Fraction sf7 = Fraction.ToFraction(s7);
		Console.WriteLine("s7 = {0}\tsf7 = {1}", s7, sf7);
		Fraction sf8 = Fraction.ToFraction(s8);
		Console.WriteLine("s8 = {0}\tsf8 = {1}", s8, sf8);
		Fraction sf9 = Fraction.ToFraction(s9);
		Console.WriteLine("s9 = {0}\tsf9 = {1}", s9, sf9);
		Fraction sf10 = Fraction.ToFraction(s10);
		Console.WriteLine("s10 = {0}\tsf10 = {1}", s10, sf10);
		Fraction sf11 = Fraction.ToFraction(s11);
		Console.WriteLine("s11 = {0}\tsf11 = {1}\n", s11, sf11);
		
		Console.WriteLine("#2 Converting big numbers into fractions");
		
		Fraction bf1 = Fraction.ToFraction(b1);
		Console.WriteLine("b1 = {0}\nbf1 = {1}\n", b1, bf1);
		Fraction bf2 = Fraction.ToFraction(b2);
		Console.WriteLine("b2 = {0}\nbf2 = {1}\n", b2, bf2);
		Fraction bf3 = Fraction.ToFraction(b3);
		Console.WriteLine("b3 = {0}\nbf3 = {1}\n", b3, bf3);
		Fraction bf4 = Fraction.ToFraction(b4);
		Console.WriteLine("b4 = {0}\nbf4 = {1}\n", b4, bf4);
		Fraction bf5 = Fraction.ToFraction(b5);
		Console.WriteLine("b5 = {0}\nbf5 = {1}\n", b5, bf5);
		Fraction bf6 = Fraction.ToFraction(b6);
		Console.WriteLine("b6 = {0}\nbf6 = {1}\n", b6, bf6);
		Fraction bf7 = Fraction.ToFraction(b7);
		Console.WriteLine("b7 = {0}\nbf7 = {1}\n", b7, bf7);
		Fraction bf8 = Fraction.ToFraction(b8);
		Console.WriteLine("b8 = {0}\nbf8 = {1}\n", b8, bf8);
		Fraction bf9 = Fraction.ToFraction(b9);
		Console.WriteLine("b9 = {0}\nbf9 = {1}\n", b9, bf9);
		Fraction bf10 = Fraction.ToFraction(b10);
		Console.WriteLine("b10 = {0}\nbf10 = {1}\n", b10, bf10);
		Fraction bf11 = Fraction.ToFraction(b11);
		Console.WriteLine("b11 = {0}\nbf11 = {1}\n", b11, bf11);
		Fraction bf12 = Fraction.ToFraction(b12);
		Console.WriteLine("b12 = {0}\nbf12 = {1}\n", b12, bf12);
		Fraction bf13 = Fraction.ToFraction(b13);
		Console.WriteLine("b13 = {0}\nbf13 = {1}\n\n", b13, bf13);
		
		// Test reduce method
		Fraction[] smallNums = {sf1,sf2,sf3,sf4,sf5,sf6,sf7,sf8,sf9,sf10,sf11};
		
		Fraction[] bigNums = {bf1, bf2, bf3, bf4, bf5, bf6, bf7,
			bf8,bf9,bf10,bf11,bf12,bf13};
			
		Console.WriteLine("#3 Test reduce small fractions");
		for(int i = 0; i < smallNums.Length; i++)
			Console.WriteLine("sf{0} = {1}\nAfter reduce: {2}\n", i+1, smallNums[i], smallNums[i].Reduce);
		
		Console.WriteLine("\n#4 Test reduce big fractions");
		for(int i = 0; i < bigNums.Length; i++)
			Console.WriteLine("bf{0} = {1}\nAfter reduce: {2}\n", i+1, bigNums[i], bigNums[i].Reduce);
		
		// Test arithmetic operations
		object[] sNums = {s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11};
		object[] bNums = {b1, b2, b3, b4, b5, b6, b7, b8, b9, b10, b11, b12, b13};
		char[] ops = {'-', '+', '*', '/'};
		
		Console.WriteLine("#5 Arithmetic operations with small nums");
		for(int i = 0; i < smallNums.Length; i++)
		{
			switch(ops[i%4])
			{
				case '-':
					Console.WriteLine("{0} - {1} = {2}", 
						smallNums[i], sNums[i], smallNums[i] - (dynamic)Convert.ChangeType(sNums[i], smallTypes[i]));
						break;
				case '+':
					Console.WriteLine("{0} + {1} = {2}", 
						smallNums[i], sNums[i], smallNums[i] + (dynamic)Convert.ChangeType(sNums[i], smallTypes[i]));
						break;
				case '*':
					Console.WriteLine("{0} * {1} = {2}", 
						smallNums[i], sNums[i], smallNums[i] * (dynamic)Convert.ChangeType(sNums[i], smallTypes[i]));
						break;
				case '/':
					Console.WriteLine("{0} / {1} = {2}", 
						smallNums[i], sNums[i], smallNums[i] / (dynamic)Convert.ChangeType(sNums[i], smallTypes[i]));
						break;
			}
		}
		Console.WriteLine("\n\n#6 Arithmetic operations with big nums");
		
		for(int i = 0; i < bigNums.Length; i++)
		{
			switch(ops[i%4])
			{
				case '-':
					Console.WriteLine("{0} - {1} = {2}", 
						bigNums[i], bNums[i], bigNums[i] - (dynamic)Convert.ChangeType(bNums[i], bigTypes[i]));
						break;
				case '+':
					Console.WriteLine("{0} + {1} = {2}", 
						bigNums[i], bNums[i], bigNums[i] + (dynamic)Convert.ChangeType(bNums[i], bigTypes[i]));
						break;
				case '*':
					Console.WriteLine("{0} * {1} = {2}", 
						bigNums[i], bNums[i], bigNums[i] * (dynamic)Convert.ChangeType(bNums[i], bigTypes[i]));
						break;
				case '/':
					Console.WriteLine("{0} / {1} = {2}", 
						bigNums[i], bNums[i], bigNums[i] / (dynamic)Convert.ChangeType(bNums[i], bigTypes[i]));
						break;
			}
		}
		// Test Fraction methods
		Console.WriteLine("#7 Methods");
		for(int i = 0; i < bigNums.Length; i++)
		{
			Console.WriteLine("Raw fraction " + bigNums[i].GetRawString());
			Console.WriteLine("Fraction to double " + bigNums[i].ToDouble());
			Console.WriteLine("Fraction to int " + bigNums[i].ToInt());
			Console.WriteLine("Fraction to long " + bigNums[i].ToLong());
			Console.WriteLine("Fraction to float " + bigNums[i].ToFloat());
			Console.WriteLine();
		}
		Console.WriteLine("ZeroArray method");
		Console.WriteLine(Fraction.ZeroArray(6));
		Console.WriteLine(Fraction.ZeroArray(6, 2));
		
		Console.WriteLine("Reduce method");
		Console.WriteLine(Fraction.ReduceArray(Fraction.ZeroArray(6)));
		Console.WriteLine(Fraction.ReduceArray(Fraction.ZeroArray(6, 2)));
		
		Console.ReadLine();
	}
}