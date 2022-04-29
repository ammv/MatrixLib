using System;

namespace MatrixLib
{
	class SizeMatrixException: Exception
	{
		public SizeMatrixException(string text): base(text){}
	}
	class DeterminantException: Exception
	{
		public DeterminantException(string text): base(text){}
	}
	public partial class Matrix
	{
		public override bool Equals(object? obj)
		{
			Matrix?	A = obj as Matrix;
			if(A == null) return false;
			if(!SizeEquals(this, A)) return false;
			
			for(int i = 0; i < rows; i++)
			for(int k = 0; k < columns; k++)
			if(!this[i,k].Equals(A[i,k])) return false;
			
			return true;
		}
		public static bool SizeEquals(object? obj1, object? obj2)
		{
			Matrix? A = obj1 as Matrix;
			Matrix? B = obj2 as Matrix;
			if(A == null || B == null)
				return false;
			else
				return (B.rows == A.rows) && (B.columns == A.columns);
		}
		public bool SizeEquals(object? obj)
		{
			Matrix? A = obj as Matrix;
			if(A == null)
				return false;
			return rows == A.rows && columns == A.columns;
		}
		public override int GetHashCode()
		{
			unchecked
			{
				int sum = 0;
				for(int i = 0; i < rows; i++)
				for(int k = 0; k < columns; k++)
				sum += this[i,k].ToInt()*(i+k+1);
				
				return rows*columns*sum;
			}
		}
		public bool IsInvertible()
		{
			return Determinant().Equals(Fraction.Zero) ? false : true;
		}
		public Matrix Clone()
		{
			Fraction[,] result = new Fraction[rows, columns];
			Array.Copy(this.values, result, rows * columns);
			return new Matrix(result);
		}
		public static Matrix EmptyMatrix(int rows, int columns)
		{
			double[,] values = new double[rows, columns];
			for(int i = 0; i < rows; i++)
			for(int k = 0; k < columns; k++)
			values[i,k] = 0;
		
			return new Matrix(values);
		}
		public Matrix CutColumn(int column)
		{
			return CutColumns(new int[]{column});
		}
		public Matrix CutRows(int row)
		{
			return CutColumns(new int[]{row});
		}
		public Matrix CutColumns(int[] columns)
		{
			Fraction[,] values = new Fraction[rows, this.columns - columns.Length];
			int j = 0;
			
			for(int i = 0; i < rows; i++)
			{
				for(int k = 0; k < this.columns; k++)
				{
					if(!columns.Contains(k))
					{
						values[i,j] = this[i,k];
						j++;
					}
				}
				j = 0;
			}
			return new Matrix(values);
		}
		public Matrix CutRows(int[] rows)
		{
			Fraction[,] values = new Fraction[this.rows-rows.Length, columns];
			int j = 0;
			
			for(int i = 0; i < this.rows; i++)
			{
				for(int k = 0; k < this.columns; k++)
				{
					if(!rows.Contains(i))
					{
						values[j,k] = this[i,k];
						j++;
					}
				}
				j = 0;
			}
			return new Matrix(values);
		}
		public Matrix Pow(int x)
		{
			Matrix A = this;
			for(int i = 0; i < x-1; i++)
			A = A * A;
		
			return A;
		}
		// input values from console by user
		public static Matrix Input()
		{
			Console.Write("Enter count of rows: ");
			int rows = Convert.ToInt32(Console.ReadLine());
			
			Console.Write("Enter count of columns: ");
			int columns = Convert.ToInt32(Console.ReadLine());
			
			double[,] values = new double[rows, columns];
			string[] input;
			
			Console.WriteLine("Enter a numbers across space");
			for(int i = 0; i < rows; i++)
			{
				Console.Write("[" + i + "]: ");
				input = Console.ReadLine()!.Split(' ');
				for(int k = 0; k < columns; k++)
				{
					values[i, k] = Convert.ToDouble(input[k]);
				}
			}
			return new Matrix(values);
		}
		public Matrix Minor(int column)
		{
			Fraction[,] minor = new Fraction[rows-1, columns-1];
			
			int j = 0;
			
			for(int i = 1; i < rows; i++)
			{
				for(int k = 0; k < columns; k++)
				{
					if(k != column)
					{
						minor[i-1,j] = this[i,k];
						
						j++;
					}
				}
				j = 0;
			}
			return new Matrix(minor);
		}
		public Matrix Minor(int row, int column)
		{
			Fraction[,] minor = new Fraction[rows-1, columns-1];
			int j = 0;
			int n = 0;
			
			for(int i = 0; i < rows; i++)
			{
				if(i != row)
				{
					for(int k = 0; k < columns; k++)
					if(k != column)
					{
						minor[n,j] = this[i,k];
						j++;
					}
					j = 0;
					n++;
				}	
			}
			return new Matrix(minor);
		}
		public Fraction AlgAdd(int row, int column)
		{
			return Math.Pow(-1, row+column)*Minor(row, column).Determinant();
		}
		public Matrix FillAlgAdd()
		{
			Fraction[,] valuesAlgAdd = new Fraction[rows, columns];
			for(int i = 0; i < rows; i++)
			for(int k = 0; k < columns; k++)
			valuesAlgAdd[i,k] = AlgAdd(i,k);	
		
			return new Matrix(valuesAlgAdd);
		}
		public Matrix Inverse()
		{
			Fraction det = Determinant();
			if(det.ToDouble() == 0d)
				throw new DeterminantException("Can`t calculate inverse matrix, because its determinant equals 0");
			return 1/det * FillAlgAdd().T;
		}
		public Matrix Reduce()
		{
			return new Matrix(Fraction.ReduceArray(values));
		}
		public static Matrix SingleMatrix(int rank)
		{
			double[,] values = new double[rank, rank];
			
			for(int i = 0; i < rank; i++)
			for(int k = 0; k < rank; k++)
			{
				if(i==k) values[i,k] = 1;
				else values[i,k] = 0;
			}
			return new Matrix(values);
		}
		private Fraction DetRank2()
		{
			return this[0,0]*this[1,1]-this[1,0]*this[0,1];
		}
		private Fraction DetRank3()
		{
			return this[0,0]*this[1,1]*this[2,2] + this[0,1]*this[1,2]*this[2,0]
					+ this[0,2]*this[1,0]*this[2,1] - this[0,2]*this[1,1]*this[2,0]
					- this[0,1]*this[1,0]*this[2,2]  - this[0,0]*this[1,2]*this[2,1];
		}
		public Fraction Determinant()
		{
			if(rows != columns)
			{
				string ErrorMessage = "A matrix having a different number of rows and columns has no determinant\n";
					ErrorMessage += String.Format("rows({0}) != columns({1})",rows, columns);
				throw new SizeMatrixException(ErrorMessage);
			}
			if(Rank == 1) return this[0,0];
			if(Rank == 2) return DetRank2();
			if(Rank == 3) return DetRank3();
			
			Fraction sum = new Fraction();
			for(int i = 0; i < columns; i++)
				sum += this[0,i]*Math.Pow(-1, 2+i)*Minor(i).Determinant();
			
			return sum;
		}
		public Matrix Transposition()
		{
			Fraction[,] valuesT = new Fraction[columns, rows];
			for(int i = 0; i < columns; i++)
			for(int k = 0; k < rows; k++)
			valuesT[i,k] = this[k,i];
		
			return new Matrix(valuesT);
		}
		public void Display(string text = "", bool newline = false)
		{
			if(text != "")
			Console.WriteLine(text);
		
			for(int i = 0; i < rows; i++)
			{
				for(int k = 0; k < columns; k++)
				{
					Console.Write(values[i,k] + "  ");
				}
				Console.WriteLine();
			}
			if(newline)
				Console.WriteLine();
		}
	}
}