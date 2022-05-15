/*
	Created by Artem Momatov
	github.com/ammv
*/

using System;

namespace MatrixLib
{
	public partial class Matrix
	{
		private int rows;
		private int columns;
		private Fraction[,] values;
		
		public int Rank
		{
			get => rows == columns ? rows: -1;
		}
		public int Rows
		{
			get => rows;
		}
		public int Columns
		{
			get => columns;
		}
		public Matrix T
		{
			get => Transposition();
		}
		public Fraction Det
		{
			get => Determinant();
		}
		public Matrix Inv
		{
			get => Inverse();
		}
		public Fraction[,] Values
		{
			get => values;
		}
		public Matrix Red
		{
			get => Reduce();
		}
		// Indexator
		public Fraction this[int index, int index2]
		{
			get => values[index, index2];
			set => values[index, index2] = value;
		}
		public Matrix(double[,] values)
		{
			this.rows = values.GetLength(0);
			this.columns = values.GetLength(1);
			this.values = new Fraction[rows, columns];
			
			for(int i = 0; i < rows; i++)
			for(int k = 0; k < columns; k++)
			this.values[i,k] = Fraction.ToFraction(values[i,k]);
		}
		public Matrix(long[,] values)
		{
			this.rows = values.GetLength(0);
			this.columns = values.GetLength(1);
			this.values = new Fraction[rows, columns];
			
			for(int i = 0; i < rows; i++)
			for(int k = 0; k < columns; k++)
			this.values[i,k] = Fraction.ToFraction(values[i,k]);
		}
		public Matrix(Fraction[,] values)
		{
			this.rows = values.GetLength(0);
			this.columns = values.GetLength(1);
			this.values = values;
		}
	}
}