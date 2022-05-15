using System;

namespace MatrixLib
{
	public partial struct Fraction
	{
		// Add
		public static Fraction operator +(Fraction A, Fraction B)
		{
			long n = A.n*B.d+B.n*A.d;
			long d = A.d*B.d;
			
			if(n < 0 & d < 0)
			{
				n *= -1;
				d *= -1;
			}
			return new Fraction(n, d).Reduce;
		}
		public static Fraction operator +(byte A, Fraction B) => ToFraction(A) + B;
		public static Fraction operator +(sbyte A, Fraction B) => ToFraction(A) + B;
		public static Fraction operator +(short A, Fraction B) => ToFraction(A) + B;
		public static Fraction operator +(ushort A, Fraction B) => ToFraction(A) + B;
		public static Fraction operator +(int A, Fraction B) => ToFraction(A) + B;
		public static Fraction operator +(uint A, Fraction B) => ToFraction(A) + B;
		public static Fraction operator +(long A, Fraction B) => ToFraction(A) + B;
		public static Fraction operator +(ulong A, Fraction B) => ToFraction(A) + B;
		public static Fraction operator +(float A, Fraction B) => ToFraction(A) + B;
		public static Fraction operator +(double A, Fraction B) => ToFraction(A) + B;
		public static Fraction operator +(decimal A, Fraction B) => ToFraction(A) + B;
		
		public static Fraction operator +(Fraction A, byte B) => ToFraction(B) + A;
		public static Fraction operator +(Fraction A, sbyte B) => ToFraction(B) + A;
		public static Fraction operator +(Fraction A, short B) => ToFraction(B) + A;
		public static Fraction operator +(Fraction A, ushort B) => ToFraction(B) + A;
		public static Fraction operator +(Fraction A, int B) => ToFraction(B) + A;
		public static Fraction operator +(Fraction A, uint B) => ToFraction(B) + A;
		public static Fraction operator +(Fraction A, long B) => ToFraction(B) + A;
		public static Fraction operator +(Fraction A, ulong B) => ToFraction(B) + A;
		public static Fraction operator +(Fraction A, float B) => ToFraction(B) + A;
		public static Fraction operator +(Fraction A, double B) => ToFraction(B) + A;
		public static Fraction operator +(Fraction A, decimal B) => ToFraction(B) + A;
		// Sub
		public static Fraction operator -(Fraction A, Fraction B)
		{
			long n = A.n*B.d-B.n*A.d;
			long d = A.d*B.d;
			if(n < 0 & d < 0)
			{
				n *= -1;
				d *= -1;
			}
			return new Fraction(n, d).Reduce;
		}
		public static Fraction operator -(byte A, Fraction B) => ToFraction(A) - B;
		public static Fraction operator -(sbyte A, Fraction B) => ToFraction(A) - B;
		public static Fraction operator -(short A, Fraction B) => ToFraction(A) - B;
		public static Fraction operator -(ushort A, Fraction B) => ToFraction(A) - B;
		public static Fraction operator -(int A, Fraction B) => ToFraction(A) - B;
		public static Fraction operator -(uint A, Fraction B) => ToFraction(A) - B;
		public static Fraction operator -(long A, Fraction B) => ToFraction(A) - B;
		public static Fraction operator -(ulong A, Fraction B) => ToFraction(A) - B;
		public static Fraction operator -(float A, Fraction B) => ToFraction(A) - B;
		public static Fraction operator -(double A, Fraction B) => ToFraction(A) - B;
		public static Fraction operator -(decimal A, Fraction B) => ToFraction(A) - B;
		
		public static Fraction operator -(Fraction A, byte B) => ToFraction(B) - A;
		public static Fraction operator -(Fraction A, sbyte B) => ToFraction(B) - A;
		public static Fraction operator -(Fraction A, short B) => ToFraction(B) - A;
		public static Fraction operator -(Fraction A, ushort B) => ToFraction(B) - A;
		public static Fraction operator -(Fraction A, int B) => ToFraction(B) - A;
		public static Fraction operator -(Fraction A, uint B) => ToFraction(B) - A;
		public static Fraction operator -(Fraction A, long B) => ToFraction(B) - A;
		public static Fraction operator -(Fraction A, ulong B) => ToFraction(B) - A;
		public static Fraction operator -(Fraction A, float B) => ToFraction(B) - A;
		public static Fraction operator -(Fraction A, double B) => ToFraction(B) - A;
		public static Fraction operator -(Fraction A, decimal B) => ToFraction(B) - A;
		public static Fraction operator -(Fraction A)
		{
			return new Fraction(-A.n, A.d);
		}
		// Mul
		public static Fraction operator *(Fraction A, Fraction B)
		{
			long n = A.n*B.n;
			long d = A.d*B.d;
			if(n < 0 & d < 0)
			{
				n *= -1;
				d *= -1;
			}
			return new Fraction(n, d).Reduce;
		}
		public static Fraction operator *(byte A, Fraction B) => ToFraction(A) * B;
		public static Fraction operator *(sbyte A, Fraction B) => ToFraction(A) * B;
		public static Fraction operator *(short A, Fraction B) => ToFraction(A) * B;
		public static Fraction operator *(ushort A, Fraction B) => ToFraction(A) * B;
		public static Fraction operator *(int A, Fraction B) => ToFraction(A) * B;
		public static Fraction operator *(uint A, Fraction B) => ToFraction(A) * B;
		public static Fraction operator *(long A, Fraction B) => ToFraction(A) * B;
		public static Fraction operator *(ulong A, Fraction B) => ToFraction(A) * B;
		public static Fraction operator *(float A, Fraction B) => ToFraction(A) * B;
		public static Fraction operator *(double A, Fraction B) => ToFraction(A) * B;
		public static Fraction operator *(decimal A, Fraction B) => ToFraction(A) * B;
										
		public static Fraction operator *(Fraction A, byte B) => ToFraction(B) * A;
		public static Fraction operator *(Fraction A, sbyte B) => ToFraction(B) * A;
		public static Fraction operator *(Fraction A, short B) => ToFraction(B) * A;
		public static Fraction operator *(Fraction A, ushort B) => ToFraction(B) * A;
		public static Fraction operator *(Fraction A, int B) => ToFraction(B) * A;
		public static Fraction operator *(Fraction A, uint B) => ToFraction(B) * A;
		public static Fraction operator *(Fraction A, long B) => ToFraction(B) * A;
		public static Fraction operator *(Fraction A, ulong B) => ToFraction(B) * A;
		public static Fraction operator *(Fraction A, float B) => ToFraction(B) * A;
		public static Fraction operator *(Fraction A, double B) => ToFraction(B) * A;
		public static Fraction operator *(Fraction A, decimal B) => ToFraction(B) * A;
		// Div
		public static Fraction operator /(Fraction A, Fraction B)
		{
			long n = A.n*B.d;
			long d = A.d*B.n;
			if(n < 0 & d < 0)
			{
				n *= -1;
				d *= -1;
			}
			return new Fraction(n, d).Reduce;
		}
		public static Fraction operator /(byte A, Fraction B) => ToFraction(A) / B;
		public static Fraction operator /(sbyte A, Fraction B) => ToFraction(A) / B;
		public static Fraction operator /(short A, Fraction B) => ToFraction(A) / B;
		public static Fraction operator /(ushort A, Fraction B) => ToFraction(A) / B;
		public static Fraction operator /(int A, Fraction B) => ToFraction(A) / B;
		public static Fraction operator /(uint A, Fraction B) => ToFraction(A) / B;
		public static Fraction operator /(long A, Fraction B) => ToFraction(A) / B;
		public static Fraction operator /(ulong A, Fraction B) => ToFraction(A) / B;
		public static Fraction operator /(float A, Fraction B) => ToFraction(A) / B;
		public static Fraction operator /(double A, Fraction B) => ToFraction(A) / B;
		public static Fraction operator /(decimal A, Fraction B) => ToFraction(A) / B;
										
		public static Fraction operator /(Fraction A, byte B) => ToFraction(B) / A;
		public static Fraction operator /(Fraction A, sbyte B) => ToFraction(B) / A;
		public static Fraction operator /(Fraction A, short B) => ToFraction(B) / A;
		public static Fraction operator /(Fraction A, ushort B) => ToFraction(B) / A;
		public static Fraction operator /(Fraction A, int B) => ToFraction(B) / A;
		public static Fraction operator /(Fraction A, uint B) => ToFraction(B) / A;
		public static Fraction operator /(Fraction A, long B) => ToFraction(B) / A;
		public static Fraction operator /(Fraction A, ulong B) => ToFraction(B) / A;
		public static Fraction operator /(Fraction A, float B) => ToFraction(B) / A;
		public static Fraction operator /(Fraction A, double B) => ToFraction(B) / A;
		public static Fraction operator /(Fraction A, decimal B) => ToFraction(B) / A;
		
		public static bool operator >(Fraction A, Fraction B)
		{
			return A.ToDouble() > B.ToDouble();
		}
		public static bool operator >=(Fraction A, Fraction B)
		{
			return A.ToDouble() >= B.ToDouble();
		}
		public static bool operator <(Fraction A, Fraction B)
		{
			return A.ToDouble() < B.ToDouble();
		}
		public static bool operator <=(Fraction A, Fraction B)
		{
			return A.ToDouble() <= B.ToDouble();
		}
		public static implicit operator Fraction(sbyte A) => ToFraction(A);
		public static implicit operator Fraction(byte A) => ToFraction(A);
		public static implicit operator Fraction(short A) => ToFraction(A);
		public static implicit operator Fraction(ushort A) => ToFraction(A);
		public static implicit operator Fraction(int A) => ToFraction(A);
		public static implicit operator Fraction(uint A) => ToFraction(A);
		public static implicit operator Fraction(long A) => ToFraction(A);
		public static implicit operator Fraction(ulong A) => ToFraction(A);
		public static implicit operator Fraction(float A) => ToFraction(A);
		public static implicit operator Fraction(double A) => ToFraction(A);
		public static implicit operator Fraction(decimal A) => ToFraction(A);
		
		public static explicit operator sbyte(Fraction A) => (sbyte)((sbyte)A.n/(sbyte)A.d);
		public static explicit operator byte(Fraction A) => (byte)((byte)A.n/(byte)A.d);
		public static explicit operator short(Fraction A) => (short)((short)A.n/(short)A.d);
		public static explicit operator ushort(Fraction A) => (ushort)((ushort)A.n/(ushort)A.d);
		public static explicit operator int(Fraction A) => (int)A.n/(int)A.d;
		public static explicit operator uint(Fraction A) => (uint)A.n/(uint)A.d;
		public static explicit operator long(Fraction A) => A.n/A.d;
		public static explicit operator ulong(Fraction A) => (ulong)A.n/(ulong)A.d;
		public static explicit operator float(Fraction A) => (float)A.n/A.d;
		public static explicit operator double(Fraction A) => (double)A.n/A.d;
		public static explicit operator decimal(Fraction A) => (decimal)A.n/A.d;
	}
}