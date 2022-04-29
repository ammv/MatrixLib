using System;

namespace MatrixLib
{
	public partial struct Fraction
	{
		private static long _GCD(Fraction A)
		{
			if(A.d == 1) return 1;
			long a = A.n > 0 ? A.n: A.n * -1;
			long b = A.d > 0 ? A.d: A.d * -1;
				
			while(a != 0 && b != 0)
			{
				if(a > b)
					a %= b;
				else
					b %= a;
			}
			return a | b;
		}
		private static Fraction _Reduce(Fraction A)
		{
			long gcd = _GCD(A);
			return new Fraction(A.n / gcd, A.d / gcd);
		}
		public static Fraction[] ReduceArray(Fraction[] A)
		{
			for(int i = 0; i < A.Length; i++)
				A[i] = _Reduce(A[i]);
			return A;
		}
		public static Fraction[,] ReduceArray(Fraction[,] A)
		{
			for(int i = 0; i < A.GetLength(0); i++)
			for(int k = 0; k < A.GetLength(1); k++)
			{
				A[i, k] = _Reduce(A[i, k]);
			}
			return A;
		}
		public bool Equals<T>(T B) where T: struct
		{	
			Fraction A = _Reduce(this);
			Fraction C = _Reduce(Fraction.ToFraction(B));
			
			return A.n == C.n && A.d == C.d;
		}
		public bool Equals(Fraction B)
		{	
			if(n + B.n == 0) return true;
			return this.ToDouble() == B.ToDouble();
		}
		public override int GetHashCode()
		{
			unchecked
			{
				return n.GetHashCode() ^ d.GetHashCode();
			}
		}
		public override string ToString()
		{
			if(n == 0)
				return "0";
			if(d == 1)
				return n.ToString();
			if(d == -1)
				return "-" + n.ToString();
			return n + "/" + d;
		}
		public string GetRawString()
		{
			return n + "/" + d;
		}
		public double ToDouble()
		{
			return (double)n/d;
		}
		public float ToFloat()
		{
			return (float)n/d;
		}
		public long ToLong()
		{
			return n/d;
		}
		public int ToInt()
		{
			return (int)n/(int)d;
		}
		public static Fraction[,] ZeroArray(int rows, int columns)
		{
			Fraction[,] zeros = new Fraction[rows, columns];
			for(int i = 0; i < rows; i++)
			for(int k = 0; k < columns; k++)
			zeros[i,k] = Zero;
		
			return zeros;
		}
		public static Fraction[] ZeroArray(int columns)
		{
			Fraction[] zeros = new Fraction[columns];
			for(int i = 0; i < columns; i++)
			zeros[i] = Zero;
		
			return zeros;
		}
		public static Fraction ToFraction<T>(T A) 
			where T: struct
		{
			var t = A.GetType();
			if(FloatTypes.Contains(t))
				return ToFractionFloat(A, t);
			else if(IntTypes.Contains(t))
				return ToFractionInt(A);
			throw new Exception("Incorrect type - " + t.Name);
		}
		private static Fraction ToFractionFloat(object A, Type t) 
		{
			dynamic a = Convert.ChangeType(A, t);
			if(Convert.ToInt64(a) == a) 
				return new Fraction((long)(a), 1);
			
			if(a >= Int64.MaxValue || (a < 0 & a < Int64.MinValue))
				throw new Exception(String.Format("Number {0} is too big. A must be lower or equals than {1}",
					a, Int64.MaxValue));
	
			if(a.ToString().Length - (a < 0? 2: 1) > 19)
			{
				var whole = Math.Truncate(a);
				var frac = a - whole;
				string sWhole = whole.ToString();
				string sFrac = frac.ToString().Remove(0, 2+(frac < 0 ? 1: 0));
				int numberOfDigitsRemoved = sFrac.Length + sWhole.Length - 19;
				
				if(sFrac.Length > sWhole.Length)
				{
					a = Math.Round(a, sFrac.Length - numberOfDigitsRemoved);
					sFrac = sFrac.Remove(sFrac.Length - numberOfDigitsRemoved);
				}
				else
				{
					if(numberOfDigitsRemoved > 0)
					{
						a = Math.Round(a, sFrac.Length - numberOfDigitsRemoved);
						sFrac = sFrac.Remove(sFrac.Length - numberOfDigitsRemoved);
					}	
					else
						throw new Exception(String.Format("Number {0} is too big. A must be lower or equals than {1}",
					a, Int64.MaxValue));
				}
			}
			string strA = a.ToString();
			int fracLength = strA.Length - strA.IndexOf(',') - 1;
			strA = strA.Remove(strA.IndexOf(','), 1);
			
			return new Fraction(Int64.Parse(strA), (long)Math.Pow(10, fracLength));
		}
		private static Fraction ToFractionInt(object A) => new Fraction(Convert.ToInt64(A), 1);
	}
}