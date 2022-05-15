using System;

namespace MatrixLib
{
	public partial class Matrix
	{
		// Compute operations with matrix * /
		private static Matrix ComputeOP(Matrix A, Matrix B)
		{
			if(A.columns != B.rows)
				throw new SizeMatrixException("Matrix A must have the number of columns equal to the number of rows of matrix B");
			
			Fraction[,] values = Fraction.ZeroArray(A.rows, B.columns);
			
			for (int i = 0; i < A.rows; i++)
			for (int j = 0; j < B.columns; j++)
			for (int k = 0; k < B.rows; k++)
			values[i,j] += A[i,k] * B[k,j];
		
            return new Matrix(values);
		}
		// Compute operations with matrix + -
		private static Matrix ComputeOP(Matrix A, Matrix B, Func<Fraction, Fraction, Fraction> op)
		{
			if(!SizeEquals(A, B))
				throw new Exception("Matrix A and matrix B must have the same size for addition/subtraction operations");
			Fraction[,] values = new Fraction[A.rows, A.columns];
			
			for(int i = 0; i < A.rows; i++)
			for(int k = 0; k < A.columns; k++)
			values[i,k] = op(A[i,k], B[i,k]);
		
			return new Matrix(values);
		}
		// Compute operations with nums
		private static Matrix ComputeOP(Matrix A, Func<Fraction, Fraction> op)
		{
			Fraction[,] values = new Fraction[A.rows, A.columns];
			
			for(int i = 0; i < A.rows; i++)
			for(int k = 0; k < A.columns; k++)
			values[i,k] = op(A[i,k]);
		
			return new Matrix(values);
		}
		/// Arithmetic Operations
		// Divide
		public static Matrix operator /(Matrix A, double value) =>
			ComputeOP(A, x => x / Fraction.ToFraction(value));
			
		public static Matrix operator /(double value, Matrix A) =>
			ComputeOP(A, x => x / Fraction.ToFraction(value));
			
		public static Matrix operator /(Fraction value, Matrix A) =>
			ComputeOP(A, x => x / value);
			
		public static Matrix operator /(Matrix A, Fraction value) =>
			ComputeOP(A, x => x / value);
			
		// Substraction
		public static Matrix operator -(Matrix A, double value) =>
			ComputeOP(A, x => x - Fraction.ToFraction(value));
			
		public static Matrix operator -(Matrix A) =>
			ComputeOP(A, x => -x);
			
		public static Matrix operator -(double value, Matrix A) =>
			ComputeOP(A, x => x - Fraction.ToFraction(value));
			
		public static Matrix operator -(Fraction value, Matrix A) =>
			ComputeOP(A, x => x - value);
			
		public static Matrix operator -(Matrix A, Fraction value) =>
			ComputeOP(A, x => x - value);
			
		// Addition
		public static Matrix operator +(Matrix A, double value) =>
			ComputeOP(A, x => x + Fraction.ToFraction(value));
			
		public static Matrix operator +(double value, Matrix A) =>
			ComputeOP(A, x => x + Fraction.ToFraction(value));
			
		public static Matrix operator +(Fraction value, Matrix A) =>
			ComputeOP(A, x => x + value);
			
		public static Matrix operator +(Matrix A, Fraction value) =>
			ComputeOP(A, x => x + value);
			
		// Multiple
		public static Matrix operator *(Matrix A, double value) =>
			ComputeOP(A, x => x * Fraction.ToFraction(value));
			
		public static Matrix operator *(double value, Matrix A) =>
			ComputeOP(A, x => x * Fraction.ToFraction(value));
			
		public static Matrix operator *(Fraction value, Matrix A) =>
			ComputeOP(A, x => x * value);
			
		public static Matrix operator *(Matrix A, Fraction value) =>
			ComputeOP(A, x => x * value);
			
		// matrix addition
		public static Matrix operator +(Matrix A, Matrix B) =>
			ComputeOP(A, B, (x,y) => x + y);
			
		// matrix substraction
		public static Matrix operator -(Matrix A, Matrix B) =>
			ComputeOP(A, B, (x,y) => x - y);
			
		// matrix multiple
		public static Matrix operator *(Matrix A, Matrix B) =>
			ComputeOP(A, B);
			
		// matrix division
		public static Matrix operator /(Matrix A, Matrix B) =>
			ComputeOP(A, B.Inverse());
	}
}