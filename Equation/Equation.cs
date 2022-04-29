using System;

namespace MatrixLib
{
	static class Equation
	{
		public static Fraction[] KramerMethod(Matrix A)
		{
			if(!IsSolvable(A))
				throw new SizeMatrixException("It is impossible to solve the matrix equation," + 
					"because the number of columns-1 is not equal to the number of rows");
			
			if(A.CutColumn(A.Columns-1).Determinant().Equals(0))
				throw new DeterminantException("It is impossible to solve the matrix equation, because the determinant is 0");
			
			int rank = A.Columns-1;
			
			Matrix B = A.CutColumn(rank);
			Matrix temp;
			
			Fraction[] solutions = new Fraction[rank];
			Fraction det = B.Det;
			
			for(int i = 0; i < rank; i++)
			{
				temp = B.Clone();
				for(int k = 0; k < rank; k++)
					temp[k,i] = A[k, rank];
				solutions[i] = temp.Det/det;
			}
			return solutions;
		}
		public static Fraction[] GaussMethod(Matrix A)
		{
			if(!IsSolvable(A))
				throw new SizeMatrixException("It is impossible to solve the matrix equation," + 
					"because the number of columns-1 is not equal to the number of rows");
			
			Fraction n;
			for(int j = 0; j < A.Rows; j++)
			{
				n = A[j,j];
				// Получение в j,j позиции 1
				for(int k = j; k < A.Columns; k++)
				A[j,k] /= n;
			
				// Получение нулей под диагональю
				for(int i = j+1; i < A.Rows; i++)
				for(int k = 0; k < A.Columns; k++)
				A[i, k] -= A[j,k] * A[i,j];
			}
			Fraction[] solution = new Fraction[A.Rows];
			Fraction sum;
			// Получение корней СЛАУ
			for(int i = A.Rows-1; i >= 0; i--)
			{
				sum = Fraction.Zero;
				for(int k = i+1; k != A.Rows; k++)
					sum += solution[k] * A[i,k];
				solution[i] = A[i,A.Columns-1] - sum;
			}
			return solution;
		}
		public static Fraction[] MatrixMethod(Matrix A)
		{
			if(!IsSolvable(A))
				throw new SizeMatrixException("It is impossible to solve the matrix equation," + 
					"because the number of columns-1 is not equal to the number of rows");
			
			if(A.CutColumn(A.Columns-1).Determinant().Equals(0))
				throw new DeterminantException("It is impossible to solve the matrix equation, because the determinant is 0");
			
			int[] columns = new int[A.Columns-1];
			for(int i = 0; i < A.Columns-1; i++)
				columns[i] = i;
		
			Matrix B = A.CutColumn(A.Columns-1).Inv * A.CutColumns(columns);
			Fraction[] solutions = new Fraction[B.Rows];
			for(int i = 0; i < B.Rows; i++)
				solutions[i] = B[i,0];
			return solutions; 
		}
		public static bool IsSolvable(Matrix A)
		{
			return A.Columns - 1 == A.Rows;
		}
	}
	
}